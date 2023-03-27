
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public partial class DPMaster : TTObject
    {
        public static DPMaster CreateDPMasterAndDetail(Guid termID, Guid doctorID, TTObjectContext objectContext)
        {
            DoctorPerformanceTerm dpt = objectContext.GetObject<DoctorPerformanceTerm>(termID) as DoctorPerformanceTerm;
            if (dpt.CurrentStateDefID == DoctorPerformanceTerm.States.Approved || dpt.CurrentStateDefID == DoctorPerformanceTerm.States.Close)
                throw new TTException("Onaylı/Kapalı dönemler üzerinde yeniden hesaplama işlemi yapılamaz.");
            ResUser doctor = objectContext.GetObject<ResUser>(doctorID) as ResUser;
            SpecialityDefinition speciality = doctor.ResourceSpecialities.OrderByDescending(x => x.MainSpeciality.HasValue ? x.MainSpeciality.Value : true).FirstOrDefault().Speciality;
            DPMaster dpm = DPMaster.GetMasterByTermAndDoctor(objectContext, termID, doctorID).FirstOrDefault();
            DateTime execDate = Common.RecTime();
            if (dpm != null)
            {
                dpm.DeleteDPDetails();
                dpm.ExecDate = execDate;
            }
            else
            {
                dpm = new DPMaster(objectContext);
                dpm.Term = dpt;
                dpm.Doctor = doctor;
                dpm.Speciality = speciality;
                dpm.ExecDate = execDate;
            }
            ProcedureDefinition pd520000 = null, pd520001 = null;
            Tuple<string, string, double?> newProcedure520000 = GetNewGILProcedureTuple("520000", objectContext, ref pd520000);//MHRS
            Tuple<string, string, double?> newProcedure520001 = GetNewGILProcedureTuple("520001", objectContext, ref pd520001);//Geçmiş inceleme

            var sapList = SubActionProcedure.GetProcedureForDP(objectContext, dpt.StartDate.Value, dpt.EndDate.Value, doctorID);
            SubActionProcedure.GetSAPForDP(objectContext, doctorID, dpt.StartDate.Value, dpt.EndDate.Value);// Bu nql sadece SAP ları toplu bir şekilde context e doldurabilmek için yazılmıştır.
            List<DPMaster.DPDetailModel> dpDetailModelList = new List<DPMaster.DPDetailModel>();
            foreach (var item in sapList)
            {
                SubActionProcedure sap = objectContext.GetObject<SubActionProcedure>(item.Sapid.Value) as SubActionProcedure;
                for (int i = 0; i < item.Amount; i++)
                {
                    if (item.GILPoint == null)
                        throw new TTException(item.GILCode + "-" + item.Procedurename + " işlemin GIL Puanı bulunamadı. Lütfen gerekli düzenlemeyi yapıp tekrar deneyiniz.");
                    if (item.GILCode == null)
                        throw new TTException(item.GILCode + "-" + item.Procedurename + " işlemin GIL Kodu bulunamadı. Lütfen gerekli düzenlemeyi yapıp tekrar deneyiniz.");

                    DPDetail dpd = new DPDetail(objectContext);
                    dpd.DPMaster = dpm;
                    dpd.SubActionProcedure = sap;
                    dpd.SubEpisode = sap.SubEpisode;
                    dpd.GILCode = item.GILCode;
                    dpd.GILPoint = item.GILPoint;
                    dpd.GILName = item.Procedurename;
                    dpd.PerformedDate = item.PerformedDate;
                    dpd.PatientBirthDate = item.Patientbirthdate;
                    dpd.PateintName = item.Patientname + ' ' + item.Patientsurname;
                    dpd.PatientUniqueRefno = item.Patientuniquerefno.HasValue ? item.Patientuniquerefno.Value.ToString() : "";
                    dpd.ProtocolNo = item.ProtocolNo;
                    dpd.Type = DPPointType.Normal; //TODO: AAE Diğer tiplere göre detaylı incelenip seçim yapılması lazım.
                    dpd.CalcPoint = item.GILPoint;
                    dpd.SurgeryGroup = item.SurgeryGroup;
                    dpd.RessectionName = item.Ressection;
                    dpd.PatientStatus = item.PatientStatus.HasValue ? Common.GetDisplayTextOfDataTypeEnum(item.PatientStatus.Value):"";

                    
                    if( (item.GILCode == "520020" || item.GILCode == "520021" || item.GILCode == "520030") && 
                            ((item.Ismhrs != null && Convert.ToInt32(item.Ismhrs) > 0)|| (item.IsPatientHistoryShown.HasValue && item.IsPatientHistoryShown.Value)))
                    {
                        if((item.Ismhrs != null && Convert.ToInt32(item.Ismhrs) > 0))
                        {
                            DPDetail extraPointMHRSDetail = (DPDetail)dpd.Clone();
                            ChangeProcedure(newProcedure520000, extraPointMHRSDetail);
                        }
                        if(item.IsPatientHistoryShown.HasValue && item.IsPatientHistoryShown.Value)
                        {
                            DPDetail extraPointHistoryDetail = (DPDetail)dpd.Clone();
                            ChangeProcedure(newProcedure520001, extraPointHistoryDetail);
                        }
                    }
                }
            }

            if(doctor.ResourceSpecialities != null)
                dpm.ReplaceSUTProcedureToGILProcedure(objectContext, doctor.ResourceSpecialities.OrderByDescending(x => x.MainSpeciality).FirstOrDefault().Speciality);
             

            //TODO: AAE Burada kurallar çalıştırılmalı.


            objectContext.Save();

            var storedProcedure = new StoredProcedure()
               .WithName("DPRULEENGINE")
               .AddParameter<string>("DPMASTER_INPUT", dpm.ObjectID.ToString(), 80);

            storedProcedure.ExecuteProcedure();

            //var outParameters = storedProcedure.GetOutputParameters();
            //foreach (var outParameter in outParameters)
            //{
            //    System.Diagnostics.Trace.WriteLine(outParameter.ParameterName);
            //    System.Diagnostics.Trace.WriteLine(outParameter.Value);
            //}

            var newObjectContext = new TTObjectContext(false);
            Guid TEMPobjectID = dpm.ObjectID;
            dpm = newObjectContext.GetObject<DPMaster>(TEMPobjectID);

            foreach (var item in dpm.DPDetails)
                dpDetailModelList.Add(new DPMaster.DPDetailModel(item.ObjectID, item.SubActionProcedure.ObjectID, item.GILName, item.GILCode, dpm.Doctor.Name, item.PateintName, item.ProtocolNo, item.GILPoint, item.CalcPoint, item.RuleName, item.RuleDescription, item.PatientUniqueRefno, item.PerformedDate.Value, item.IsModified.HasValue ? item.IsModified.Value : false,item.RessectionName,item.PatientStatus));

            DPDetailLog ddl = new DPDetailLog(newObjectContext);
            ddl.Term = dpt;
            ddl.Doctor = doctor;
            ddl.ExecDate = execDate;
            ddl.TotalCalcPoint = Convert.ToInt32(dpDetailModelList.Sum(x => x.CalcPoint));
            ddl.Log = dpDetailModelList;

            newObjectContext.Save();

            return dpm;

        }

        List<string> cocukYandalBransKodlari = new List<string>(new string[] {"1548","1561","1574","1582","1583","1584","1585","1586","1588","1589","1590","1591","1592","1593","1594","1595","1596","1599","5900"});
        List<string> digerYandalBransKodlari = new List<string>(new string[] { "1048","1053","1055","1062","1068","1069","1070","1073","1076","1078","1079","1080","1099","1148","1172","1173","1198","1301","1855",
                                                                                "1910","1975","2387","2579","2679","2781","2782","2796","3010","3050","3056","3197","3198","3199","3357","3359","3372","3554","3560",
                                                                                  "3664","3665","3666","3849","3852","3863","3869","3951","4658","4667","4695" });
        List<string> digerBransKodlari = new List<string>(new string[] { "1000", "1400", "1600"});

        private void ReplaceSUTProcedureToGILProcedure(TTObjectContext objectContext,SpecialityDefinition doctorSpeciality)
        {
            ProcedureDefinition pd041 = null,pd034 = null,pd033 = null,pd038 = null,pd039 = null,pd040 = null,pd042 = null;
            if (DPDetails.Where(x => x.GILCode == "520020" || x.GILCode == "520021" || x.GILCode == "520030").Count() > 0)
            {
                List<DPDetail> replaceable520030Details = DPDetails.Where(x => x.GILCode == "520030").ToList();
                if (cocukYandalBransKodlari.Contains(doctorSpeciality.Code))
                {
                    
                    Tuple<string, string, double?> newProcedure = GetNewGILProcedureTuple("520041", objectContext,ref pd041);
                    foreach (DPDetail item in replaceable520030Details)
                    {
                        ChangeProcedure(newProcedure, item);
                    }
                }
                else if (digerYandalBransKodlari.Contains(doctorSpeciality.Code) || doctorSpeciality.IsMinorSpeciality == true )
                {
                    string XXXXXXbasamakveturu = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXBASAMAKVETURU", "1.BASAMAK");
                    string code = "520034";
                    if (XXXXXXbasamakveturu == "EAH")
                        code = "520035";

                    Tuple<string, string, double?> newProcedure = GetNewGILProcedureTuple(code, objectContext, ref pd034);
                    var rowNumberWithPartitionBy = replaceable520030Details
                           .OrderBy(o => o.PerformedDate)
                           .GroupBy(g => g.PerformedDate.Value.ToString("yyyy-MM-dd"))
                           .Select(s => new { s, Count = s.Count() })
                           .SelectMany(sm => sm.s.Select(s => s)
                                             .Zip(Enumerable.Range(1, sm.Count), (tt, index)
                                                 => new { SequentialNumber = index, tt.PerformedDate, tt.ObjectID })
                                       ).ToList();
                    foreach (var item in rowNumberWithPartitionBy)
                    {
                        if ((item.SequentialNumber <= 35 && code == "520035") || (item.SequentialNumber <= 20 && code == "520034"))
                            ChangeProcedure(newProcedure, replaceable520030Details.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault());
                    }
                }
                else if(digerBransKodlari.Contains(doctorSpeciality.Code))
                {
                    Tuple<string, string, double?> newProcedure = GetNewGILProcedureTuple("520033", objectContext, ref pd033);
                    var rowNumberWithPartitionBy = replaceable520030Details
                          .OrderBy(o => o.PerformedDate)
                          .GroupBy(g => g.PerformedDate.Value.ToString("yyyy-MM-dd"))
                          .Select(s => new { s, Count = s.Count() })
                          .SelectMany(sm => sm.s.Select(s => s)
                                            .Zip(Enumerable.Range(1, sm.Count), (tt, index)
                                                => new { SequentialNumber = index, tt.PerformedDate, tt.ObjectID })
                                      ).ToList();
                    foreach (var item in rowNumberWithPartitionBy)
                    {
                        if (doctorSpeciality.Code.Equals("1400") && item.SequentialNumber <= 10)
                            ChangeProcedure(newProcedure, replaceable520030Details.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault());
                        else if (doctorSpeciality.Code.Equals("1600") && item.SequentialNumber <= 15)
                            ChangeProcedure(newProcedure, replaceable520030Details.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault());
                        else if (doctorSpeciality.Code.Equals("1000") && item.SequentialNumber <= 20)
                            ChangeProcedure(newProcedure, replaceable520030Details.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault());
                    }
                }
                List<DPDetail> replaceableAllDetails = DPDetails.Where(x => x.GILCode == "520020" || x.GILCode == "520021" || x.GILCode == "520030").ToList();

                foreach (var item in replaceableAllDetails)
                {
                    DateTime? bdate = item.PatientBirthDate;
                    if (bdate != null)
                    {
                        int monthCount = (((item.PerformedDate.Value.Year - bdate.Value.Year) * 12) + (item.PerformedDate.Value.Month - bdate.Value.Month));
                        if (monthCount <= 24)   //0 - 24 ay arası
                        {
                            Tuple<string, string, double?> newProcedure = GetNewGILProcedureTuple("520038", objectContext, ref pd038);
                            ChangeProcedure(newProcedure, item);
                        }
                        else if (monthCount >= 25 && monthCount <= 72) // 25 ay - 6 yaş arası
                        {
                            Tuple<string, string, double?> newProcedure = GetNewGILProcedureTuple("520039", objectContext, ref pd039);
                            ChangeProcedure(newProcedure, item);
                        }
                        else if (monthCount >= 73 && monthCount < 216) //6>= - <18 yaş arası
                        {
                            Tuple<string, string, double?> newProcedure = GetNewGILProcedureTuple("520040", objectContext, ref pd040);
                            ChangeProcedure(newProcedure, item);
                        }
                        else if (monthCount >= 780) //65 Yaş üzeri
                        {
                            Tuple<string, string, double?> newProcedure = GetNewGILProcedureTuple("520042", objectContext, ref pd042);
                            ChangeProcedure(newProcedure, item);
                        }
                    }
                }
            }
        }

        ///<summary>Item1 = Code,Item2 = Name,Item3 = Point
        ///</summary>
        private static Tuple<string, string, double?> GetNewGILProcedureTuple(string procedudeCode, TTObjectContext objectContext,ref ProcedureDefinition _pd)
        {
            ProcedureDefinition pd;
            if (_pd == null)
                pd = ProcedureDefinition.GetActiveByCode(objectContext, procedudeCode);
            else
                pd = _pd;

            _pd = pd;

            if (pd == null)
                throw new Exception(procedudeCode + " kodlu aktif hizmet tanımı bulunamadı");
            if(pd.GILPoint == null || pd.GILPoint == 0)
                throw new Exception(procedudeCode + " kodlu aktif hizmet tanımı tanımda girişimsel işlem puanı girilmemiş.");
            //Code,name,point
            Tuple<string, string, double?> result = Tuple.Create<string, string, double?>(pd.GILCode,pd.Name, pd.GILPoint);
            return result;
        }

        private static void ChangeProcedure(Tuple<string, string, double?> newProcedure,DPDetail detail)
        {
            detail.GILCode = newProcedure.Item1;
            detail.GILName = newProcedure.Item2;
            detail.GILPoint = newProcedure.Item3;
            detail.CalcPoint = newProcedure.Item3;
        }

        public static BindingList<ResUser.GetDoctorBySpecialtyForDP_Class> GetDoctorListFromBransID(Guid selectedBransID)
        {
            using (var objectContext = new TTObjectContext(false))
            {

                string tempNQL = " AND OBJECTID in (";
                TTUser currentUser = Common.CurrentResource.GetMyTTUser();
                if (currentUser.IsSuperUser)
                    tempNQL = " ";
                else if (currentUser.HasRole(TTRoleNames.DP_Birim_Sorumlusu))
                {
                    BindingList<DPUnitManagerRelation> controlList = DPUnitManagerRelation.GetByUnitManager(objectContext, currentUser.TTObjectID.Value);
                    foreach (var item in controlList)
                    {
                        tempNQL += "'" + item.RelatedUser.ObjectID.ToString() + "',";
                    }
                    tempNQL += "'" + Common.CurrentResource.ObjectID + "') ";
                }
                else
                    tempNQL += "'" + Common.CurrentResource.ObjectID + "') ";

                var doctorList = ResUser.GetDoctorBySpecialtyForDP(objectContext, selectedBransID, tempNQL);
                objectContext.FullPartialllyLoadedObjects();
                return doctorList;
            }
        }

        public static BindingList<ResUser.GetSpecialitiesForDP_Class> GetBransList()
        {
            using (var objectContext = new TTObjectContext(false))
            {

                string tempNQL = " AND OBJECTID in (";
                TTUser currentUser = Common.CurrentResource.GetMyTTUser();
                if (currentUser.IsSuperUser)
                    tempNQL = " ";
                else if (currentUser.HasRole(TTRoleNames.DP_Birim_Sorumlusu))
                {
                    BindingList<DPUnitManagerRelation> controlList = DPUnitManagerRelation.GetByUnitManager(objectContext, currentUser.TTObjectID.Value);
                    foreach (var item in controlList)
                    {
                        tempNQL += "'" + item.RelatedUser.ObjectID.ToString() + "',";
                    }
                    tempNQL += "'" + Common.CurrentResource.ObjectID + "') ";
                }
                else
                    tempNQL += "'" + Common.CurrentResource.ObjectID + "') ";

                var bransList = ResUser.GetSpecialitiesForDP(objectContext, tempNQL);
                return bransList;
            }
        }

        private void DeleteDPDetails()
        {
            List<DPDetail> detailList = DPDetails.ToList();
            foreach (DPDetail detail in detailList)
            {
                if (detail.IsModified != true)
                    ((ITTObject)detail).Delete();
            }
        }

        [Serializable]
        public class DPDetailModel
        {
            public Guid ObjectID { get; set; }
            public Guid SAPObjectID { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
            public string DoctorName { get; set; }
            public string PatientName { get; set; }
            public string ProtocolNo { get; set; }
            public DateTime? PerformedDate{ get; set; }
            public double? Point { get; set; }
            public double? CalcPoint { get; set; }
            public string RuleName { get; set; }
            public string RuleDescription { get; set; }
            public string UniqueReFno { get; set; }
            public string RessectionName { get; set; }
            public string PatientStatus { get; set; }
            public bool IsModified { get; set; }

            public DPDetailModel(Guid _objectID, Guid _sapObjectID, string _name, string _code, string _doctorName, string _patientName, string _protocolNo, double? _point, double? _calcPoint, string _ruleName, string _ruleDescription, string _uniqueReFno,DateTime _perforemDate,bool _isModified,string _ressectionName,string _patientStatus)
            {
                ObjectID = _objectID;
                SAPObjectID = _sapObjectID;
                Name = _name;
                Code = _code;
                DoctorName = _doctorName;
                PatientName = _patientName;
                ProtocolNo = _protocolNo;
                Point = _point;
                CalcPoint = _calcPoint;
                RuleName = _ruleName;
                RuleDescription = _ruleDescription;
                UniqueReFno = _uniqueReFno;
                PerformedDate = _perforemDate;
                IsModified = _isModified;
                RessectionName = _ressectionName;
                PatientStatus = _patientStatus;
            }
            public DPDetailModel()
            { }
        }

        public class DPDiffLogDetailModel : DPMaster.DPDetailModel
        {
            public string DiffDescription { get; set; }
            public int DiffType { get; set; }
            public double? OldPoint { get; set; }
            public double? NewPoint { get; set; }
            public DPDiffLogDetailModel(Guid _objectID, Guid _sapObjectID, string _name, string _code, 
                string _doctorName, string _patientName, string _protocolNo, double? _point, double? _calcPoint,
                string _ruleName, string _ruleDescription, string _uniqueReFno,
                string _diffDesc,int _diffType,double? _oldPoint,double? _newPoint,DateTime _performedDate,bool _isModified, 
                string _ressectionName, string _patientStatus) :
                base( _objectID, _sapObjectID, _name, _code, _doctorName, _patientName, _protocolNo,  _point, _calcPoint,
                    _ruleName, _ruleDescription, _uniqueReFno, _performedDate,_isModified,_ressectionName,_patientStatus)
            {
                DiffDescription = _diffDesc;
                OldPoint = _oldPoint;
                NewPoint = _newPoint;
                DiffType = _diffType;
            }
        }


    }
}