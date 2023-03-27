using Infrastructure.Filters;
using Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TTDataDictionary;
using TTDefinitionManagement;
using TTInstanceManagement;
using TTObjectClasses; 
using TTUtils;
using TTStorageManager.Security;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using DevExpress.Map.Native;
using Core.Services;

namespace Core.Controllers.DoctorPerformance
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public class DoctorPerformanceApiController : Controller
    {
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Donem_Islemleri)]
        public string HelloWorld()
        {
            return "Hello World!";
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool SaveNewDoctorPerformanceTerm(DoctorPerformanceTerm newDpt)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (newDpt.StartDate > newDpt.EndDate)
                        throw new Exception("Dönem başlangıç tarihi, bitiş tarihinden büyük olamaz.");
                    else if(string.IsNullOrEmpty(newDpt.Name))
                        throw new Exception("Dönem adı boş olamaz.");

                    DoctorPerformanceTerm dpt = new DoctorPerformanceTerm(objectContext);
                    dpt.Name = newDpt.Name;
                    dpt.StartDate = newDpt.StartDate;
                    dpt.EndDate = newDpt.EndDate;
                    dpt.CurrentStateDefID = newDpt.CurrentStateDefID;
                    objectContext.Save();
                    return true;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool ApproveDPCommissionDecision(DoctorPerformanceDecisionModel newDpd)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                DPCommissionDecision dpt = objectContext.GetObject<DPCommissionDecision>(newDpd.ObjectID.Value) as DPCommissionDecision;
                dpt.CurrentStateDefID = DPCommissionDecision.States.Approval;
                objectContext.Save();
                return true;
            }
            
        }
            


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public Guid SaveNewDPCommissionDecision(DoctorPerformanceDecisionModel newDpd)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    if (newDpd.Date == null)
                        throw new Exception("Karar tarihi boş olamaz.");
                    else if (string.IsNullOrEmpty(newDpd.Name))
                        throw new Exception("Karar adı boş olamaz.");

                    DPCommissionDecision dpt = null;

                    if (newDpd.ObjectID == null || newDpd.ObjectID == Guid.Empty)
                    {
                        dpt = new DPCommissionDecision(objectContext);
                        dpt.CreateDate = DateTime.Now;
                        dpt.CreateUser = Common.CurrentResource;
                        dpt.CurrentStateDefID = DPCommissionDecision.States.New;
                    }
                    else
                    {
                        dpt = objectContext.GetObject<DPCommissionDecision>(newDpd.ObjectID.Value) as DPCommissionDecision;
                        List<DPCommissionMember> memberList = dpt.DPCommissionMembers.ToList();
                        foreach (var item in memberList)
                        {
                            var deleteItemX = dpt.DPCommissionMembers.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                            if (deleteItemX != null)
                            {
                                ((ITTObject)deleteItemX).Delete();
                            }
                        }
                    }

                    dpt.Name = newDpd.Name;
                    dpt.Date = newDpd.Date;
                    dpt.Decision = newDpd.Text;
                    if(newDpd.TermID.HasValue &&  newDpd.TermID != null)
                        dpt.Term = objectContext.GetObject<DoctorPerformanceTerm>(newDpd.TermID.Value) as DoctorPerformanceTerm;

                    foreach (var item in newDpd.MemberList)
                    {
                        DPCommissionMember DPcm = new DPCommissionMember(objectContext);
                        DPcm.DPCommissionDecision = dpt;
                        DPcm.Member = objectContext.GetObject<ResUser>(item.ObjectID) as ResUser;
                        DPcm.Duty = item.Duty;
                    }

                    objectContext.Save();
                    return dpt.ObjectID;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool UpdateDoctorPerformanceTerm(DoctorPerformanceTerm newDpt)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    DoctorPerformanceTerm dpt = objectContext.GetObject<DoctorPerformanceTerm>(newDpt.ObjectID) as DoctorPerformanceTerm;

                    if (newDpt.Name != null)
                        dpt.Name = newDpt.Name;
                    if (newDpt.StartDate != null)
                        dpt.StartDate = newDpt.StartDate;
                    if(newDpt.EndDate != null )
                        dpt.EndDate = newDpt.EndDate;
                    if(newDpt.CurrentStateDefID != null)
                        dpt.CurrentStateDefID = newDpt.CurrentStateDefID;

                    if(newDpt.CurrentStateDefID == DoctorPerformanceTerm.States.Approved)
                    {
                        int i = 0;
                        BindingList<DPDetail.GetDistinctSUBEPISODE_Class> distinctSEList = DPDetail.GetDistinctSUBEPISODE(dpt.ObjectID);
                        foreach (var item in distinctSEList)
                        {
                            SubEpisode se = objectContext.GetObject<SubEpisode>(item.ObjectID.Value) as SubEpisode;
                            new SendToENabiz(objectContext, se, dpt.ObjectID, "DOCTORPERFORMANCETERM", "268", Common.RecTime());
                            i++;
                            if (i % 100 == 0)
                                objectContext.Save();
                        }
                        
                    }

                    if (newDpt.CurrentStateDefID == DoctorPerformanceTerm.States.Close)
                    {
                        DPDetail.GetTotalPointOfTerm_Class tempTotal = DPDetail.GetTotalPointOfTerm(dpt.ObjectID).FirstOrDefault();
                        dpt.TotalPoint = tempTotal.Totalpoint != null ? Convert.ToInt32(tempTotal.Totalpoint) : 0;
                    }
                    if (newDpt.CurrentStateDefID == DoctorPerformanceTerm.States.Open)
                        dpt.TotalPoint = 0;

                    objectContext.Save();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DoctorPerformanceTermModel> GetAllDoctorPerformanceTerm()
        {
            List<DoctorPerformanceTermModel> result = new List<DoctorPerformanceTermModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var dpTermList = objectContext.QueryObjects<DoctorPerformanceTerm>().ToArray();
                    var query =
                        from i in dpTermList
                        select new DoctorPerformanceTermModel { ObjectID = i.ObjectID, Name = i.Name, CurrentState = i.CurrentStateDefID.Value,TotalPoint = i.TotalPoint.HasValue? i.TotalPoint.Value:0 , StartDate = (i.StartDate.HasValue ? i.StartDate.Value : DateTime.MaxValue), EndDate = (i.EndDate.HasValue ? i.EndDate.Value : DateTime.MaxValue) };
                    result = query.OrderByDescending(x => x.StartDate).ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BarChartModel> getHizmetChartDataSource(Guid TermID)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                try
                {
                    var y = context.DPDetail.Where(x => x.DPMaster.TermRef.Value == TermID).
                        GroupBy(x => x.GILCode).Select(g => new BarChartModel { ColumnName = g.Key, Value = g.Sum(t => (int)t.CalcPoint.Value) }).Take(7).ToList();
                    return y;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            } 
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BarChartModel> getDailyChartDataSource(Guid TermID)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                try
                {
                    List<BarChartModel> result = new List<BarChartModel>();
                    var y = context.DPDetail.Where(x => x.DPMaster.TermRef.Value == TermID && x.DPMaster.DoctorRef.Value == Common.CurrentResource.ObjectID).
                        GroupBy(x => x.PerformedDate.Value.Day).Select(g => new BarChartModel { ColumnName = g.Key.ToString(), Value = g.Sum(t => (int)t.CalcPoint.Value) }).ToList();

                    using (var objectContext = new TTObjectContext(false))
                    {

                        DoctorPerformanceTerm dpt = objectContext.GetObject<DoctorPerformanceTerm>(TermID) as DoctorPerformanceTerm;

                        var firstDay = dpt.StartDate.Value.Day;
                        var lastDay = dpt.EndDate.Value.Day;

                        for (int i = firstDay; i <= lastDay; i++)
                        {
                            var entry = new BarChartModel();
                            List<BarChartModel> temp = y.Where(r => r.ColumnName == i.ToString()).ToList();
                            if (temp != null && temp.Count > 0)
                            {
                                entry.ColumnName = temp[0].ColumnName;
                                entry.Value = temp[0].Value;
                            }
                            else
                            {
                                entry.ColumnName = i.ToString();
                                entry.Value = 0;
                            }

                            result.Add(entry);
                        }

                    }
                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BarChartModel> getProcedurePieChartDataSource(Guid TermID)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                try
                {
                    List<BarChartModel> result = new List<BarChartModel>();
                    var y = context.DPDetail.Where(x => x.DPMaster.TermRef.Value == TermID && x.DPMaster.DoctorRef.Value == Common.CurrentResource.ObjectID).
                        GroupBy(x => new { x.GILName, x.GILCode } ).Select(g => new BarChartModel { ColumnName = g.Key.GILCode.ToString(), Description = g.Key.GILName.ToString(), Value = g.Sum(t => (int)t.CalcPoint.Value) }).ToList();

                    return y;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        public class tempProcedureTypeModelModel
        {
            public int type { get; set; }
            public int value { get; set; }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BarChartModel> getProcedureTypePieChartDataSource(Guid TermID)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                try
                {
                    List<BarChartModel> result = new List<BarChartModel>();
                    var y = context.DPDetail.Where(x => x.DPMaster.TermRef.Value == TermID && x.DPMaster.DoctorRef.Value == Common.CurrentResource.ObjectID).
                        GroupBy(x =>  x.SubActionProcedure.ProcedureObject.ProcedureType.HasValue ? x.SubActionProcedure.ProcedureObject.ProcedureType.Value:ProcedureDefGroupEnum.digerIslemBilgileri ).Select(g => new BarChartModel { Description = g.Key.ToString(),ColumnName = Common.GetDisplayTextOfEnumValue("ProcedureDefGroupEnum", (int)g.Key), Value= g.Sum(t => (int)t.CalcPoint.Value) }).ToList();

                    
                    return y;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BarChartModel> getTedaviTuruPieChartDataSource(Guid TermID)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                try
                {
                    List<BarChartModel> result = new List<BarChartModel>();
                    var y = context.DPDetail.Where(x => x.DPMaster.TermRef.Value == TermID && x.DPMaster.DoctorRef.Value == Common.CurrentResource.ObjectID).
                        GroupBy(x => x.PatientStatus).Select(g => new BarChartModel { Description = g.Key, ColumnName = g.Key, Value = g.Sum(t => (int)t.CalcPoint.Value) }).ToList();


                    return y;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BarChartModel> getDoctorChartDataSource(Guid TermID)
        {
            using (var context = AtlasContextFactory.Instance.CreateContext())
            {
                try
                {
                    var y = context.DPDetail.Where(x => x.DPMaster.TermRef.Value == TermID).
                        GroupBy(x => x.DPMaster.Doctor.Person.Name + " " + x.DPMaster.Doctor.Person.Surname).Select(g => new BarChartModel { ColumnName = g.Key, Value = g.Sum(t => (int)t.CalcPoint.Value) }).Take(7).ToList();
                    return y;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BarChartModel> getBranchChartDataSource(Guid TermID)
        {
            try
            {
                List<BarChartModel> result = new List<BarChartModel>();
                var y = DPDetail.GetGroupedTotalPointOfTerm(TermID);
                var query =
                        from i in y
                        select new BarChartModel
                        {
                           ColumnName = i.Name,
                           Value = i.Totalpoint != null ? Convert.ToInt32(i.Totalpoint):0
                        };
                result = query.OrderByDescending(x => x.ColumnName).Take(7).ToList();
                
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DoctorPerformanceDecisionModel> GetAllDoctorPerformanceCommissionDecission()
        {
            List<DoctorPerformanceDecisionModel> result = new List<DoctorPerformanceDecisionModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var dpTermList = objectContext.QueryObjects<DPCommissionDecision>().ToArray();
                    var query =
                        from i in dpTermList
                        select new DoctorPerformanceDecisionModel
                        {
                            ObjectID = i.ObjectID,
                            Name = i.Name,
                            CurrentState = i.CurrentStateDefID.Value,
                            Date = (i.Date.HasValue ? i.Date.Value : DateTime.MaxValue),
                            CreateDate = (i.CreateDate.HasValue ? i.CreateDate.Value : DateTime.MaxValue),
                            TermID = i.Term?.ObjectID,
                            Text = i.Decision?.ToString(),
                            MemberList = i.DPCommissionMembers.Select(x => new DPCommissionMemberModel { ObjectID = x.Member.ObjectID, Name = x.Member.Name, Duty = x.Duty.Value }).ToList()
                        };
                    result = query.OrderByDescending(x => x.Date).ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DpKatsayiRaporModel> GetUnitPerformanceMultipleReport(Guid termID)
        {
            List<DoctorPerformanceTermModel> result = new List<DoctorPerformanceTermModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    List<DpKatsayiRaporModel> tempResultList = new List<DpKatsayiRaporModel>();
                    BindingList<ResUser.GetSpecialitiesForDP_Class> bransList = DPMaster.GetBransList();
                    foreach (var brans in bransList)
                    {
                        var cerrahiCodes = new[] { "2400", "2000", "1900", "2200", "2900", "2300", "2800", "2600", "2500", "2700", "2679" };
                        var dahiliCodes = new[] { "1171", "1300", "1800", "1000", "1500", "3600" };
                        //var digerTabipBranslari =  new[] {"3500","3300","4400","3400","4800","3200","4300","1700","3580","1200","1600","1400","9999","5100","5400","5700",
                        //                                  "1594","1593","1592","1590","1589","1585","1583","1079","1561","1062","1070","1073","1076","1078","1584","1586",
                        //                                  "1591","1053","1055","1975","2387","3197","1591","1855","3010","5900","3056"  } ;

                       
                        BindingList<ResUser.GetDoctorBySpecialtyForDP_Class> tempDoctors = DPMaster.GetDoctorListFromBransID(brans.ObjectID.Value);
                        foreach (var item in tempDoctors)
                        {
                            DPMaster dpm = DPMaster.GetMasterByTermAndDoctor(objectContext, termID, item.ObjectID.Value).FirstOrDefault();
                            DpKatsayiRaporModel tempResult = null;
                            if (dpm != null)
                            {
                                //   List<DPDetail> details = dpm.DPDetails.ToList();

                                if(brans.Code != "9999" && dpm.Doctor.DateOfJoin.HasValue && ((dpm.Term.EndDate.Value - dpm.Doctor.DateOfJoin.Value).TotalDays < 365 ))
                                    tempResult = GenerateDPKatsayiRaporModel(dpm, "Yeni Personel Birim Performans Katsayısı", brans.Code, brans.Name);
                                else if (brans.Code == "3000")
                                    tempResult = CalculateKadinDogum(dpm, brans.Code, brans.Name);
                                else if (brans.Code == "1100" || brans.Code == "1586")
                                    tempResult = CalculateInvazivKardiyoloji(dpm, brans.Code, brans.Name);
                                else if (brans.Code == "3100")
                                    tempResult = CalculateRejyonelAnestezi(dpm, brans.Code, brans.Name);
                                else if (dahiliCodes.Contains(brans.Code))
                                    tempResult = CalculateDahiliBrans(dpm, brans.Code, brans.Name);
                                else if (cerrahiCodes.Contains(brans.Code))
                                    tempResult = CalculateCerrahiBrans(dpm, brans.Code, brans.Name);

                                if (tempResult == null)//Diğer Tabipler Birim Performans Katsayısı
                                {
                                    tempResult = GenerateDPKatsayiRaporModel(dpm, "Diğer Tabipler Birim Performans Katsayısı", brans.Code, brans.Name);
                                }

                                if(tempResult != null && tempResult.TotalPoint > 1)
                                {
                                    tempResultList.Add(tempResult);
                                }
                            }
                        }

                       

                    }

                    decimal totalRatio = tempResultList.Where(x => x.GroupName != "Yeni Personel Birim Performans Katsayısı"
                      && x.GroupName != "Diğer Tabipler Birim Performans Katsayısı").Sum(y => y.Ratio);
                    int totalCount = tempResultList.Where(x => x.GroupName != "Yeni Personel Birim Performans Katsayısı"
                    && x.GroupName != "Diğer Tabipler Birim Performans Katsayısı").Count();
                    decimal tabipDisiDigerTabipRatio = decimal.Round(((decimal)totalRatio / (decimal)totalCount),2);


                    foreach (DpKatsayiRaporModel item in tempResultList)
                    {
                        if (item.GroupName == "Diğer Tabipler Birim Performans Katsayısı"
                            || (item.GroupName == "Rejyonel Anestezi Birim Performans Katsayısı" && item.Ratio < tabipDisiDigerTabipRatio))
                        {
                            item.Ratio = tabipDisiDigerTabipRatio;
                            item.LastPoint = (int)(tabipDisiDigerTabipRatio * item.TotalPoint);

                            if (item.GroupName == "Rejyonel Anestezi Birim Performans Katsayısı")
                                item.PersonelName += "/Diğ:" + tabipDisiDigerTabipRatio;
                        }
                    }
                    objectContext.FullPartialllyLoadedObjects();
                    return tempResultList;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
        }

        private DpKatsayiRaporModel GenerateDPKatsayiRaporModel(DPMaster dpm, string groupName, string branscode, string bransname)
        {
            List<DPDetail> details = dpm.DPDetails.ToList();
            double? allPoint = details.Sum(x => x.CalcPoint);
            if (allPoint == 0)
                allPoint = 1;

            DpKatsayiRaporModel returnObj = new DpKatsayiRaporModel(dpm.Doctor.ObjectID, dpm.Doctor.Name, bransname, branscode,(int) allPoint, (int)allPoint,(int)allPoint, 1,   groupName);
            return returnObj;
        }

        public DpKatsayiRaporModel CalculateDahiliBrans(DPMaster dpm, string branscode, string bransname)
        {
            
            var vizitCodes = new[] { "510123", "530075", "552001", "552002", "552003", "552004", "552005", "552006", "552007", "552008", "552009", "552010" };
            List<DPDetail> details = dpm.DPDetails.ToList();
            double? allPoint = details.Sum(x => x.CalcPoint);
            double? vizitPoint = details.Where(x => vizitCodes.Contains(x.GILCode)).Sum(x => x.CalcPoint);

            decimal ratio = 0;

            if (allPoint == 0)
                allPoint = 1;

            ratio = (decimal)(vizitPoint) / (decimal)allPoint;

            if (ratio == 0)
                ratio = (decimal)0.85;
            else if (ratio >= (decimal)0.05)
                ratio = 1;
            else if (ratio < (decimal)0.05 && ratio >= (decimal)0.03)
                ratio = (decimal)0.95;
            else if (ratio < (decimal)0.03 && ratio >= (decimal)0.01)
                ratio = (decimal)0.9;
            else if (ratio < (decimal)0.01)
                ratio = (decimal)0.85;
            else
                ratio = (decimal)0.85;

            DpKatsayiRaporModel returnObj = new DpKatsayiRaporModel(dpm.Doctor.ObjectID, dpm.Doctor.Name, bransname, branscode, (int)vizitPoint, (int)allPoint, 
                (int)((decimal)allPoint * ratio),ratio,   "Dahili Branşlar Birim Performans Katsayısı");
            return returnObj;
        }
        public DpKatsayiRaporModel CalculateInvazivKardiyoloji(DPMaster dpm, string branscode, string bransname)
        {
            List<DPDetail> details = dpm.DPDetails.ToList();
            double? allPoint = details.Sum(x => x.CalcPoint);
            double? InvazivPoint = details.Where(x => x.GILCode.CompareTo("700640") >= 0 && x.GILCode.CompareTo("701063") <= 0 ).Sum(x => x.CalcPoint);

            decimal ratioInv = 0, ratio = 0;
            var vizitCodes = new[] { "510123", "530075", "552001", "552002", "552003", "552004", "552005", "552006", "552007", "552008", "552009", "552010" };
            double? vizitPoint = details.Where(x => vizitCodes.Contains(x.GILCode)).Sum(x => x.CalcPoint);


            if (allPoint == 0)
                allPoint = 1;

            ratioInv = (decimal)(InvazivPoint) / (decimal)allPoint;

            if (ratioInv == 0)
                ratioInv = (decimal)0.85;
            else if (ratioInv >= (decimal)0.15)
                ratioInv = 1;
            else if (ratioInv < (decimal)0.15 && ratioInv >= (decimal)0.10)
                ratioInv = (decimal)0.95;
            else if (ratioInv < (decimal)0.10 && ratioInv >= (decimal)0.05)
                ratioInv = (decimal)0.9;
            else if (ratioInv < (decimal)0.05)
                ratioInv = (decimal)0.85;
            else
                ratioInv = (decimal)0.85;


            ratio = (decimal)(vizitPoint) / (decimal)allPoint;

            if (ratio == 0)
                ratio = (decimal)0.85;
            else if (ratio >= (decimal)0.05)
                ratio = 1;
            else if (ratio < (decimal)0.05 && ratio >= (decimal)0.03)
                ratio = (decimal)0.95;
            else if (ratio < (decimal)0.03 && ratio >= (decimal)0.01)
                ratio = (decimal)0.9;
            else if (ratio < (decimal)0.01)
                ratio = (decimal)0.85;
            else
                ratio = (decimal)0.85;


            string PersonelAdi = dpm.Doctor.Name +" - " + "İnv:" + ratioInv + "/" + "Viz:" + ratio;

            if (ratio > ratioInv)
            {
                ratioInv = ratio;
                InvazivPoint = vizitPoint;
            }

            DpKatsayiRaporModel returnObj = new DpKatsayiRaporModel(dpm.Doctor.ObjectID, PersonelAdi, bransname, branscode, 
                (int)InvazivPoint, (int)allPoint, (int)((decimal)allPoint * ratio), ratioInv,   "Kardiyoloji Birim Performans Katsayısı");

            return returnObj;
        }

        public DpKatsayiRaporModel CalculateRejyonelAnestezi(DPMaster dpm, string branscode, string bransname)
        {
             var rejyonelCodes = new[] { "550750", "550760", "550770", "550780", "550790", "550800", "550810", "550820", "550830", "551260", "551270" };
            List<DPDetail> details = dpm.DPDetails.ToList();
            double? allPoint = details.Sum(x => x.CalcPoint);
            double? rejyonelPoint = details.Where(x => rejyonelCodes.Contains(x.GILCode)).Sum(x => x.CalcPoint);

            decimal ratio = 0;
            if (allPoint == 0)
                allPoint = 1;

            ratio = (decimal)(rejyonelPoint) / (decimal)allPoint;

            if (ratio == 0)
                ratio = (decimal)0.85;
            else if (ratio >= (decimal)0.1)
                ratio = 1;
            else if (ratio < (decimal)0.1 && ratio >= (decimal)0.07)
                ratio = (decimal)0.95;
            else if (ratio < (decimal)0.07 && ratio >= (decimal)0.04)
                ratio = (decimal)0.9;
            else if (ratio < (decimal)0.04)
                ratio = (decimal)0.85;
            else
                ratio = (decimal)0.85;


            DpKatsayiRaporModel returnObj = new DpKatsayiRaporModel(dpm.Doctor.ObjectID, dpm.Doctor.Name +" - Rej:"+ ratio, bransname, branscode,
              (int)rejyonelPoint, (int)allPoint, (int)((decimal)allPoint * ratio), ratio,   "Rejyonel Anestezi Birim Performans Katsayısı");

            return returnObj;
        }

        public DpKatsayiRaporModel CalculateCerrahiBrans(DPMaster dpm, string branscode, string bransname)
        {
              var ameliyatCodes = new[] { "A1", "A2", "A3", "B", "C", "D" };
            List<DPDetail> details = dpm.DPDetails.ToList();
            double? surgeryPoint = details.Where(x => ameliyatCodes.Contains(x.SurgeryGroup)).Sum(x => x.CalcPoint);
            double? allPoint = details.Sum(x => x.CalcPoint);

            decimal ratio = 0;

            if (allPoint == 0)
                allPoint = 1;
            ratio = (decimal)(surgeryPoint) / (decimal)allPoint;

            if (ratio == 0)
                ratio = (decimal)0.85;
            else if (ratio >= (decimal)0.1)
                ratio = 1;
            else if (ratio < (decimal)0.1 && ratio >= (decimal)0.07)
                ratio = (decimal)0.95;
            else if (ratio < (decimal)0.07 && ratio >= (decimal)0.04)
                ratio = (decimal)0.9;
            else if (ratio < (decimal)0.04)
                ratio = (decimal)0.85;
            else
                ratio = (decimal)0.85;


            DpKatsayiRaporModel returnObj = new DpKatsayiRaporModel(dpm.Doctor.ObjectID, dpm.Doctor.Name, bransname, branscode,
             (int)surgeryPoint, (int)allPoint, (int)((decimal)allPoint * ratio), ratio,   "Cerrahi Branşlar Birim Performans Katsayısı");
             
            return returnObj;
        }
        public DpKatsayiRaporModel CalculateKadinDogum(DPMaster dpm, string branscode, string bransname)
        {
              var dogumCodes = new[] { "619910", "619911", "619912", "619913", "619920", "619921", "619922", "619923", "619925", "619926", "619927", "619929", "619930", "619931", "619932" };
            var ameliyatCodes = new[] { "A1", "A2", "A3", "B", "C", "D" };
            List<DPDetail> details = dpm.DPDetails.ToList();
            double? firstListSurgeryPoint = details.Where(x => ameliyatCodes.Contains(x.SurgeryGroup) && x.GILCode != "619.930" && x.GILCode != "619.929").Sum(x => x.CalcPoint);
            double? firstListAllPoint = details.Sum(x => x.CalcPoint);
            double? secondSezeryanPoint = details.Where(x => x.GILCode == "619929" || x.GILCode == "619930").Sum(x => x.CalcPoint);
            double? secondDogumPoint = details.Where(x => dogumCodes.Contains(x.GILCode)).Sum(x => x.CalcPoint);
             
            decimal ratioFirst = 0;
            decimal ratioSecond = 0;
            decimal katsayi = 0;
            if (firstListAllPoint == 0)
                firstListAllPoint = 1;

            ratioFirst = (decimal)(firstListSurgeryPoint) / (decimal)firstListAllPoint;

            if (ratioFirst == 0)
                ratioFirst = (decimal)0.85;
            else if (ratioFirst >= (decimal)0.08)
                ratioFirst = 1;
            else if (ratioFirst < (decimal)0.08 && ratioFirst >= (decimal)0.05)
                ratioFirst = (decimal)0.95;
            else if (ratioFirst < (decimal)0.05 && ratioFirst >= (decimal)0.02)
                ratioFirst = (decimal)0.9;
            else if (ratioFirst < (decimal)0.02)
                ratioFirst = (decimal)0.85;
            else
                ratioFirst = (decimal)0.85;

            if (secondDogumPoint != 0)
            {
                ratioSecond = (decimal)secondSezeryanPoint / (decimal)(secondDogumPoint);

                if (ratioSecond <= (decimal)0.15)
                    ratioSecond = 1;
                else if (ratioSecond > (decimal)0.15 && ratioSecond <= (decimal)0.2)
                    ratioSecond = (decimal)0.95;
                else if (ratioSecond > (decimal)0.2 && ratioSecond <= (decimal)0.25)
                    ratioSecond = (decimal)0.9;
                else if (ratioSecond > (decimal)0.25)
                    ratioSecond = (decimal)0.85;
                else
                    ratioSecond = (decimal)0.85;

                katsayi = (ratioFirst + ratioSecond) / 2;
            }
            else
                katsayi = ratioFirst;

              

            DpKatsayiRaporModel returnObj = new DpKatsayiRaporModel(dpm.Doctor.ObjectID, dpm.Doctor.Name + " - " + "Cer:" + ratioFirst + "/" + "Pri.Sez:" + ratioSecond, bransname, branscode,
           (int)firstListSurgeryPoint, (int)firstListAllPoint, (int)(katsayi * (decimal)firstListAllPoint), katsayi,   "Kadın Hastalıkları ve Doğum Branşı Birim Performans Katsayısı");
             
            return returnObj;
        }
        public class DpKatsayiRaporModel
        {
            public Guid Performer { get; set; }
            public string PersonelName { get; set; }
            public string BranchName { get; set; }
            public string BranchCode { get; set; }
            public int RatioPoint { get; set; }
            public int TotalPoint { get; set; }
            public int LastPoint { get; set; }
            public decimal Ratio { get; set; }
         
            public string GroupName { get; set; }

            public DpKatsayiRaporModel(Guid _performer, string _personelName, string _branchName, string _branchCode , int _ratioPoint , int _totalPoint, int _lastPoint, decimal _ratio , string _groupName)
            {
                this.BranchCode = _branchCode;
                this.BranchName = _branchName;
                this.GroupName = _groupName;
                this.LastPoint = _lastPoint;
                this.Performer = _performer;
                this.PersonelName = _personelName;
                this.Ratio = _ratio;
                this.RatioPoint = _ratioPoint;
                this.TotalPoint = _totalPoint;
            }
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DoctorPerformanceTermModel> GetDoctorPerformanceTerm()
        {
            List<DoctorPerformanceTermModel> result = new List<DoctorPerformanceTermModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    var dpTermList = objectContext.QueryObjects<DoctorPerformanceTerm>(" CURRENTSTATEDEFID <> '"+DoctorPerformanceTerm.States.Cancelled +"'", " STARTDATE DESC ").ToArray();
                    var query =
                        from i in dpTermList
                        select new DoctorPerformanceTermModel { ObjectID = i.ObjectID, Name = i.Name, CurrentState = i.CurrentStateDefID.Value, TotalPoint = 0, StartDate = (i.StartDate.HasValue ? i.StartDate.Value : DateTime.MaxValue), EndDate = (i.EndDate.HasValue ? i.EndDate.Value : DateTime.MaxValue) };
                    result = query.ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<BransGridModel> GetBransList()
        {
            List<BransGridModel> result = new List<BransGridModel>();

            try
            {
                var bransList = DPMaster.GetBransList();
                var query =
                    from i in bransList
                    select new BransGridModel { ObjectID = i.ObjectID.Value, Name = i.IsMinorSpeciality.HasValue && i.IsMinorSpeciality.Value ? i.Name + "<Yandal>" : i.Name, Code = i.Code };
                result = query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DoctorGridModel> GetDoctorList([FromQuery] Guid selectedBransID)
        {
            List<DoctorGridModel> result = new List<DoctorGridModel>();
            try
            {
                var doctorList = DPMaster.GetDoctorListFromBransID(selectedBransID);
                var query =
                    from i in doctorList
                    select new DoctorGridModel { ObjectID = i.ObjectID.Value, Name = i.Name,UniqueRefNo = i.UniqueRefNo,Title = i.Doctortitle != null ? i.Doctortitle.ToString():""};
                result = query.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
             
            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ServiceResultModel GetNewDetailData([FromQuery] Guid termID, [FromQuery] Guid doctorID)
        {

            //DPExecuteDaily dp = new DPExecuteDaily();
            //dp.TaskScript();
            ServiceResultModel result = new ServiceResultModel();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    DPMaster dpm = DPMaster.CreateDPMasterAndDetail(termID, doctorID, objectContext);
                    string doctorName = dpm.Doctor.Name;
                    foreach (var item in dpm.DPDetails)
                    {
                        DetailModel tempItem = new DetailModel();
                        tempItem.CalcPoint = item.CalcPoint;
                        tempItem.Code = item.GILCode;
                        tempItem.DoctorName = doctorName;
                        tempItem.Name = item.GILName;
                        tempItem.ObjectID = item.ObjectID;
                        tempItem.PerformedDate = item.PerformedDate.Value;
                        tempItem.PatientName = item.PateintName;
                        tempItem.Point = item.GILPoint;
                        tempItem.ProtocolNo = item.ProtocolNo;
                        tempItem.UniqueReFno = item.PatientUniqueRefno;
                        tempItem.RuleDescription = item.RuleDescription;
                        tempItem.RuleName = item.RuleName;
                        tempItem.IsModified = item.IsModified.HasValue ? item.IsModified.Value : false;
                        tempItem.RessectionName = item.RessectionName;
                        tempItem.PatientStatus = item.PatientStatus;
                        result.DetailList.Add(tempItem);
                    }
                    result.B1Point = result.DetailList.Sum(x => x.CalcPoint);
                    result.B2Point = 0;
                    result.B3Point = 0;
                    result.LastExecDate = dpm.ExecDate;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ServiceResultModel GetAllDetailsOfaTermOrBrans([FromQuery] Guid termID, [FromQuery] Guid bransID)
        {
            ServiceResultModel result = new ServiceResultModel();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    BindingList<ResUser.GetDoctorBySpecialtyForDP_Class> doctorList = new BindingList<ResUser.GetDoctorBySpecialtyForDP_Class>();
                    if (bransID != null && bransID != Guid.Empty)
                        doctorList = DPMaster.GetDoctorListFromBransID(bransID);
                    else
                    {
                        BindingList<ResUser.GetSpecialitiesForDP_Class> bransList = DPMaster.GetBransList();
                        foreach (var brans in bransList)
                        {
                            BindingList<ResUser.GetDoctorBySpecialtyForDP_Class> tempDoctors = DPMaster.GetDoctorListFromBransID(brans.ObjectID.Value);
                            foreach (var item in tempDoctors)
                            {
                                doctorList.Add(item);
                            }
                        }
                    }
                    foreach (var doctor in doctorList)
                    {
                        DPMaster dpm = DPMaster.GetMasterByTermAndDoctor(objectContext, termID, doctor.ObjectID.Value).FirstOrDefault();
                        if (dpm != null)
                        {
                            string doctorName = dpm.Doctor.Name;
                            foreach (var item in dpm.DPDetails)
                            {
                                DetailModel tempItem = new DetailModel();
                                tempItem.CalcPoint = item.CalcPoint;
                                tempItem.Code = item.GILCode;
                                tempItem.DoctorName = doctorName;
                                tempItem.Name = item.GILName;
                                tempItem.ObjectID = item.ObjectID;
                                tempItem.PerformedDate = item.PerformedDate.Value;
                                tempItem.PatientName = item.PateintName;
                                tempItem.Point = item.GILPoint;
                                tempItem.ProtocolNo = item.ProtocolNo;
                                tempItem.UniqueReFno = item.PatientUniqueRefno;
                                tempItem.RuleDescription = item.RuleDescription;
                                tempItem.RuleName = item.RuleName;
                                tempItem.IsModified = item.IsModified.HasValue ? item.IsModified.Value : false;
                                tempItem.RessectionName = item.RessectionName;
                                tempItem.PatientStatus = item.PatientStatus;
                                result.DetailList.Add(tempItem);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public ServiceResultModel GetDetailData([FromQuery] Guid termID, [FromQuery] Guid doctorID)
        {
            ServiceResultModel result = new ServiceResultModel();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    DPMaster dpm = DPMaster.GetMasterByTermAndDoctor(objectContext, termID, doctorID).FirstOrDefault();
                    if (dpm != null)
                    {
                        string doctorName = dpm.Doctor.Name;
                        foreach (var item in dpm.DPDetails)
                        {
                            DetailModel tempItem = new DetailModel();
                            tempItem.CalcPoint = item.CalcPoint;
                            tempItem.Code = item.GILCode;
                            tempItem.DoctorName = doctorName;
                            tempItem.Name = item.GILName;
                            tempItem.ObjectID = item.ObjectID;
                            tempItem.PerformedDate = item.PerformedDate.Value;
                            tempItem.PatientName = item.PateintName;
                            tempItem.Point = item.GILPoint;
                            tempItem.ProtocolNo = item.ProtocolNo;
                            tempItem.UniqueReFno = item.PatientUniqueRefno;
                            tempItem.RuleDescription =   item.RuleDescription;
                            tempItem.RuleName = item.RuleName;
                            tempItem.IsModified = item.IsModified.HasValue ? item.IsModified.Value : false;
                            tempItem.RessectionName = item.RessectionName;
                            tempItem.PatientStatus = item.PatientStatus;
                            result.DetailList.Add(tempItem);
                        }
                        result.B1Point = result.DetailList.Sum(x => x.CalcPoint);
                        result.B2Point = 0;
                        result.B3Point = 0;
                        result.LastExecDate = dpm.ExecDate;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<LogGridModel> GetDetailLogData([FromQuery] Guid termID, [FromQuery] Guid doctorID)
        {
            List<LogGridModel> result = new List<LogGridModel>();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    BindingList<DPDetailLog> tempList = DPDetailLog.GetDetailLogByTermAndDoctor(objectContext, termID, doctorID);

                    var query =
                        from i in tempList
                        select new LogGridModel { ObjectID = i.ObjectID,ExecDate = i.ExecDate.Value,TotalCalcPoint = i.TotalCalcPoint};
                    result = query.ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DPMaster.DPDiffLogDetailModel> CalculateDetailLogDiff([FromQuery] Guid firstLogID, [FromQuery] Guid secondLogID)
        {
            List<DPMaster.DPDiffLogDetailModel> result = new List<DPMaster.DPDiffLogDetailModel>();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    DPDetailLog firstLogItem = objectContext.GetObject<DPDetailLog>(firstLogID) as DPDetailLog;
                    List<DPMaster.DPDetailModel> firstDetails = (List<DPMaster.DPDetailModel>)firstLogItem.Log;
                    DPDetailLog secondLogItem = objectContext.GetObject<DPDetailLog>(secondLogID) as DPDetailLog;
                    List<DPMaster.DPDetailModel> secondDetails = (List<DPMaster.DPDetailModel>)secondLogItem.Log;
                     
                    HashSet<Guid> fSapObjectIDs = new HashSet<Guid>(firstDetails.Select(f => f.SAPObjectID));
                    HashSet<Guid> sSapObjectIDs = new HashSet<Guid>(secondDetails.Select(s => s.SAPObjectID));
                    List<DPMaster.DPDetailModel> deletedDetails = firstDetails.Where(x => !sSapObjectIDs.Contains(x.SAPObjectID)).ToList();
                    List<DPMaster.DPDetailModel> addedDetails = secondDetails.Where(x => !fSapObjectIDs.Contains(x.SAPObjectID)).ToList();
                     

                    var res1 = from f in firstDetails
                               group f.CalcPoint by f.SAPObjectID into fg
                               select new { sapID = fg.Key, point = fg.Sum() };
                    var res2 = from s in secondDetails
                               group s.CalcPoint by s.SAPObjectID into sg
                               select new { sapID = sg.Key, point = sg.Sum() };
                              
                    var changeQuery = from f in res1
                            join s in res2 on f.sapID equals s.sapID
                            where s.point != f.point
                            select new { sapID = f.sapID, fpoint = f.point,spoint = s.point };

                    //Deleted items.
                    foreach (var item in deletedDetails)
                    {
                        result.Add(new DPMaster.DPDiffLogDetailModel(item.ObjectID, item.SAPObjectID, item.Name, item.Code,
                                                                      item.DoctorName, item.PatientName, item.ProtocolNo, item.Point, item.CalcPoint, item.RuleName, item.RuleDescription, item.UniqueReFno,
                                                                      "Silinen", 0,  item.CalcPoint,0,item.PerformedDate.Value,item.IsModified,item.RessectionName,item.PatientStatus));
                    }
                    //added items.
                    foreach (var item in addedDetails)
                    {
                        result.Add(new DPMaster.DPDiffLogDetailModel(item.ObjectID, item.SAPObjectID, item.Name, item.Code,
                                                                      item.DoctorName, item.PatientName, item.ProtocolNo, item.Point, item.CalcPoint, item.RuleName, item.RuleDescription, item.UniqueReFno,
                                                                      "Yeni eklenen", 1, 0, item.CalcPoint, item.PerformedDate.Value, item.IsModified, item.RessectionName, item.PatientStatus));
                    }

                    List<DPMaster.DPDiffLogDetailModel> tempResult = (from c in changeQuery
                                                                      from f in firstDetails
                                                                      where c.sapID == f.SAPObjectID
                                                                      select new DPMaster.DPDiffLogDetailModel(f.ObjectID, c.sapID, f.Name, f.Code,
                                                                      f.DoctorName, f.PatientName, f.ProtocolNo, f.Point, f.CalcPoint, f.RuleName, f.RuleDescription, f.UniqueReFno,
                                                                      "Değişen", 2, c.fpoint, c.spoint,f.PerformedDate.Value, f.IsModified, f.RessectionName, f.PatientStatus)).ToList();
                    //changed items.
                    result.AddRange(tempResult);

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DetailModel> GetLogDetailData([FromQuery] Guid logID)
        {
            List<DetailModel> result = new List<DetailModel>();
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    DPDetailLog logItem = objectContext.GetObject<DPDetailLog>(logID) as DPDetailLog;
                    List<DPMaster.DPDetailModel> details = (List<DPMaster.DPDetailModel>)logItem.Log;

                    string doctorName = logItem.Doctor.Name;
                    foreach (var item in details)
                    {
                        DetailModel tempItem = new DetailModel();
                        tempItem.CalcPoint = item.CalcPoint;
                        tempItem.Code = item.Code;
                        tempItem.DoctorName = doctorName;
                        tempItem.Name = item.Name;
                        tempItem.ObjectID = item.ObjectID;
                        tempItem.PatientName = item.PatientName;
                        tempItem.Point = item.Point;
                        tempItem.ProtocolNo = item.ProtocolNo;
                        tempItem.UniqueReFno = item.UniqueReFno;
                        tempItem.RuleDescription = item.RuleDescription;
                        tempItem.RuleName = item.RuleName;
                        tempItem.PerformedDate = item.PerformedDate.Value;
                        tempItem.IsModified = item.IsModified;
                        tempItem.RessectionName = item.RessectionName;
                        tempItem.PatientStatus = item.PatientStatus;
                        result.Add(tempItem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<GILDefinitionDTO> getGILDefinitions()
        {
            List<GILDefinitionDTO> result = new List<GILDefinitionDTO>();
            using (var objectContext = new TTObjectContext(true))
            {
                try
                {
                    var dpTermList = GILDefinition.GetGILDefinitionWithMasterCount(objectContext).ToArray();
                    //var dpTermList = objectContext.QueryObjects<GILDefinition>().ToArray();
                    var query =
                        from i in dpTermList
                        where i.Point != null && i.Point > 0
                        select new GILDefinitionDTO { ObjectID = i.ObjectID.Value, Name = i.Name, Code = i.Code, Description = i.Description, Point = i.Point.Value, HasRule = i.Dpmastercount != null && Convert.ToInt32(i.Dpmastercount) > 0 ? true : false, SurgeryGroup = i.SurgeryGroup };
                    result = query.OrderBy(x => x.Code).ToList();
                    objectContext.FullPartialllyLoadedObjects();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public DoctorPerformanceRuleOperationDetailViewModel getDPRule(string code)
        {
            DoctorPerformanceRuleOperationDetailViewModel result = new DoctorPerformanceRuleOperationDetailViewModel();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    DPRuleMaster master = objectContext.QueryObjects<DPRuleMaster>(" CODE =  '" + code + "'").FirstOrDefault();
                    if (master != null)
                    {
                        result = getDPRuleDetailViewModel(master);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        private DoctorPerformanceRuleOperationDetailViewModel getDPRuleDetailViewModel(DPRuleMaster master)
        {
            DoctorPerformanceRuleOperationDetailViewModel result = new DoctorPerformanceRuleOperationDetailViewModel();
            var queryP =
            from i in master.DpRuleProcedures
            select new ProcedureModelForRule { Code = i.Code,Name = i.Name,BannOrMustType = i.BannOrMustType.Value,TimeType = i.TimeType.Value};
            if(queryP != null)
                result.ProcedureList = queryP.ToList();

            var queryS =
            from i in master.DpRuleSpecialities
            select new SpecialityModelForRule { Code = i.Code, Name = i.Name, BannOrMustType = i.BannOrMustType.Value };
            if (queryS != null)
                result.SpecialityList = queryS.ToList();

            var queryD =
            from i in master.DpRuleDiagnosis
            select new DiagnosisModelForRule { Code = i.Code, Name = i.Name };
            if (queryD != null)
                result.DiagnosisList = queryD.ToList();

            var querySc =
            from i in master.DpRuleScripts
            select new QueryScriptModelForRule { PointPercentage = i.PointPercentage.Value,ResultMessage = i.ResultMessage,RuleName = i.RuleName,Script = i.Script};
            if (querySc != null)
                result.QueryList = querySc.ToList();

            DpRuleDetail dpDetail = master.DpRuleDetails.FirstOrDefault();
            if(dpDetail != null)
            {
                result.Age = dpDetail.Age;
                result.AgeType = dpDetail.AgeType;
                result.Hospital = dpDetail.HospitalType;
                result.Kesi = dpDetail.Kesi;
                result.Period = dpDetail.Period;
                result.PeriodAmount = dpDetail.PeriodAmount;
                result.PeriodScope = dpDetail.PeriodScope;
                result.PeriodTimeType = dpDetail.PeriodTimeType;
                result.Sex = dpDetail.Sex;
                result.TedaviTuru = dpDetail.TedaviTuru;
            }
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool saveDPRule(string code, DoctorPerformanceRuleOperationDetailViewModel detail)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                GILDefinition gd = objectContext.QueryObjects<GILDefinition>(" CODE =  '" + code +"'").FirstOrDefault();
                DPRuleMaster master = objectContext.QueryObjects<DPRuleMaster>(" CODE =  '" + code + "'").FirstOrDefault();
                if (gd != null) {
                    if (master == null)
                    {
                        master = createDPRuleMaster(gd, objectContext);
                      
                    }
                    else
                    { 
                        deleteRuleDetailItems(master);
                    }
                    createNewDetailItems(objectContext, master, detail, code);
                    objectContext.Save();
                }
                return true;
            }
        }

        private DPRuleMaster createDPRuleMaster(GILDefinition gd, TTObjectContext objectContext)
        {
            DPRuleMaster master = new DPRuleMaster(objectContext);
            master.Code = gd.Code;
            master.Name = gd.Name;
            master.GILDefinition = gd;
            return master;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool deleteDPRule(GILDefinitionDTO deleteRule)
        {
            using (var objectContext = new TTObjectContext(false))
            { 
                DPRuleMaster master = objectContext.QueryObjects<DPRuleMaster>(" CODE =  '" + deleteRule.Code + "'").FirstOrDefault();
                if (master != null)
                {
                    GILDefinition gd = objectContext.QueryObjects<GILDefinition>(" CODE =  '" + deleteRule.Code + "'").FirstOrDefault();
                    deleteRuleDetailItems(master);
                    ((ITTObject)master).Delete();
                    objectContext.Save();
                }
                return true;
            }
        }
        
        private void deleteRuleDetailItems(DPRuleMaster master)
        {
            IList tempItemP = master.DpRuleProcedures.ToList();
            foreach (DpRuleProcedure item in tempItemP)
            {
                var deleteItem = master.DpRuleProcedures.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                if (deleteItem != null)
                {
                    BindingList<DpRuleProcedure> tempList = DpRuleProcedure.GetDPRuleProcedureWithParameters(deleteItem.ObjectContext,deleteItem.Master,deleteItem.Code,deleteItem.BannOrMustType.Value,deleteItem.TimeType.Value);
                    IList tempItemPX = tempList.ToList();
                    foreach (DpRuleProcedure itemX in tempItemPX)
                    {
                        var deleteItemX = tempList.Where(x => x.ObjectID == itemX.ObjectID).FirstOrDefault();
                        if (deleteItemX != null)
                        {
                            ((ITTObject)deleteItemX).Delete();
                        }
                    }
                    ((ITTObject)deleteItem).Delete();
                }
            }
            IList tempItemD = master.DpRuleDiagnosis.ToList();
            foreach (DpRuleDiagnos item in tempItemD)
            {
                var deleteItem = master.DpRuleDiagnosis.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                if (deleteItem != null)
                    ((ITTObject)deleteItem).Delete();
            }
            IList tempItemSc = master.DpRuleScripts.ToList();
            foreach (DpRuleScript item in tempItemSc)
            {
                var deleteItem = master.DpRuleScripts.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                if (deleteItem != null)
                    ((ITTObject)deleteItem).Delete();
            }
            IList tempItemS = master.DpRuleSpecialities.ToList();
            foreach (DpRuleSpeciality item in tempItemS)
            {
                var deleteItem = master.DpRuleSpecialities.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                if (deleteItem != null)
                    ((ITTObject)deleteItem).Delete();
            }
            IList tempItemDe = master.DpRuleDetails.ToList();
            foreach (DpRuleDetail item in tempItemDe)
            {
                var deleteItem = master.DpRuleDetails.Where(x => x.ObjectID == item.ObjectID).FirstOrDefault();
                if (deleteItem != null)
                    ((ITTObject)deleteItem).Delete();
            }
        }
        private void createNewDetailItems(TTObjectContext objectContext,DPRuleMaster master, DoctorPerformanceRuleOperationDetailViewModel detail, string code)
        {
            foreach (var item in detail.ProcedureList)
            {
                CreateDPRuleProcedure(item.Code,item.Name,item.TimeType,item.BannOrMustType,master,objectContext);
                ControlAndCreateCodeHasRule(item,master, objectContext);
            }
            foreach (var item in detail.DiagnosisList)
            {
                DpRuleDiagnos newDia = new DpRuleDiagnos(objectContext);
                newDia.Master = code;
                newDia.Name = item.Name;
                newDia.DPRuleMaster = master;
                newDia.Code = item.Code;
            }
            foreach (var item in detail.QueryList)
            {
                DpRuleScript newScr = new DpRuleScript(objectContext);
                newScr.DPRuleMaster = master;
                newScr.Master = code;
                newScr.RuleName = item.RuleName;
                newScr.PointPercentage = item.PointPercentage;
                newScr.ResultMessage = item.ResultMessage;
                newScr.Script = item.Script;
            }
            foreach (var item in detail.SpecialityList)
            {
                DpRuleSpeciality newSpec = new DpRuleSpeciality(objectContext);
                newSpec.Name = item.Name;
                newSpec.Code = item.Code;
                newSpec.BannOrMustType = item.BannOrMustType;
                newSpec.DPRuleMaster = master;
                newSpec.Master = code;
            }

            DpRuleDetail newDetail = new DpRuleDetail(objectContext);
            newDetail.DPRuleMaster = master;
            newDetail.Master = code;
            newDetail.Age = detail.Age;
            newDetail.AgeType = detail.AgeType;
            newDetail.HospitalType = detail.Hospital;
            newDetail.Kesi = detail.Kesi;
            newDetail.Period = detail.Period;
            newDetail.PeriodAmount = detail.PeriodAmount;
            newDetail.PeriodScope = detail.PeriodScope;
            newDetail.PeriodTimeType = detail.PeriodTimeType;
            newDetail.TedaviTuru = detail.TedaviTuru;
            newDetail.Sex = detail.Sex;

        }

        private void CreateDPRuleProcedure(string _code, string _name, int _timeType, int _bannOrMustType, DPRuleMaster _master, TTObjectContext _objectContext)
        {
            DpRuleProcedure newPro = new DpRuleProcedure(_objectContext);
            newPro.Code = _code;
            newPro.Name = _name;
            newPro.BannOrMustType = _bannOrMustType;
            newPro.DPRuleMaster = _master;
            newPro.TimeType = _timeType;
            newPro.Master = _master.Code;
        }
        private void ControlAndCreateCodeHasRule(ProcedureModelForRule _item, DPRuleMaster _master, TTObjectContext _objectContext)
        {
            BindingList<DpRuleProcedure> tempList = DpRuleProcedure.GetDPRuleProcedureWithParameters(_objectContext, _master.Code, _item.Code, _item.BannOrMustType, _item.TimeType);
            if(tempList.Count == 0)
            {
                DPRuleMaster master = _objectContext.QueryObjects<DPRuleMaster>(" CODE =  '" + _item.Code + "'").FirstOrDefault();
                if (master == null)
                {
                    GILDefinition gd = _objectContext.QueryObjects<GILDefinition>(" CODE =  '" + _item.Code + "'").FirstOrDefault();
                    master = createDPRuleMaster(gd, _objectContext);
                }
                CreateDPRuleProcedure(_master.Code, _master.Name, _item.TimeType, _item.BannOrMustType, master, _objectContext);
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<DetailModel> puanSifirlaGeriAl(List<DetailModel> selectedDetails, bool state)
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    foreach (var item in selectedDetails)
                    {
                        DPDetail detailItem = objectContext.GetObject<DPDetail>(item.ObjectID) as DPDetail;
                        detailItem.IsModified = state;
                        if (detailItem.DPMaster.Term.CurrentStateDefID == DoctorPerformanceTerm.States.Approved)
                            throw new TTException("Onaylı dönemler üzerinde sıfırlama işlemi yapılamaz.");
                        if (state)
                        {
                            detailItem.BeforeModifyPoint = detailItem.CalcPoint;
                            item.CalcPoint = detailItem.CalcPoint = 0;
                            item.RuleName = detailItem.RuleName = "Puan Sıfırlama";
                            item.RuleDescription = detailItem.RuleDescription = Common.CurrentUser.FullName + " tarafından "+Common.RecTime().ToString("dd/MM/yyyy HH:mm ")+" tarihinde puan sıfırlanmıştır.";
                        }
                        else
                        {
                            item.CalcPoint = detailItem.CalcPoint = detailItem.BeforeModifyPoint;
                            detailItem.BeforeModifyPoint = 0;
                            item.RuleName = detailItem.RuleName = "";
                            item.RuleDescription = detailItem.RuleDescription = "";
                        }
                        item.IsModified = state;
                    }

                    objectContext.Save();
                    return selectedDetails;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" puanSifirlaGeriAl: " + ex.Message, ex);
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<UnitManagerModel> GetAllUnitManagerList()
        {
            List<UnitManagerModel> result = new List<UnitManagerModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    List<TTUser> userList = TTUser.GetAllUsers();
                    foreach (TTUser item in userList)
                    {
                        if(item.HasRole(new Guid(TTRoleNames.DP_Birim_Sorumlusu)) && !item.IsSuperUser && !item.IsPowerUser)
                        {
                            UnitManagerModel umm = new UnitManagerModel();
                            umm.ObjectID = item.TTObjectID.Value;
                            umm.Name = item.FullName;
                            result.Add(umm);
                        }
                    }
                        
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<RelatedUserModel>  GetAllUserList()
        {
            List<RelatedUserModel> result = new List<RelatedUserModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {
                    BindingList<ResUser> doctorlist = ResUser.DoctorListObjectNQL(objectContext, "");
                    foreach (ResUser item in doctorlist)
                    {
                        if (item.IsActive.HasValue && item.IsActive.Value)
                        {
                            RelatedUserModel umm = new RelatedUserModel();
                            umm.ObjectID = item.ObjectID;
                            umm.Name = item.Person.FullName;
                            if (item.ResourceSpecialities.Count > 0)
                                umm.SpecialtyName = item.ResourceSpecialities.OrderByDescending(x => x.MainSpeciality.HasValue ? x.MainSpeciality.Value : true).FirstOrDefault().Speciality.Name;
                            if (!string.IsNullOrEmpty(umm.SpecialtyName))
                                result.Add(umm);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public List<RelatedUserModel> GetRelatedUserList(Guid UnitManagerID)
        {
            List<RelatedUserModel> result = new List<RelatedUserModel>();
            using (var objectContext = new TTObjectContext(false))
            {
                try
                {                    
                    BindingList<DPUnitManagerRelation> controlList = DPUnitManagerRelation.GetByUnitManager(objectContext, UnitManagerID);
                    foreach (var item in controlList)
                    {
                        RelatedUserModel umm = new RelatedUserModel();
                        umm.ObjectID = item.RelatedUser.ObjectID;
                        umm.Name = item.RelatedUser.Person.FullName;
                        if (item.RelatedUser.ResourceSpecialities.Count > 0)
                            umm.SpecialtyName = item.RelatedUser.ResourceSpecialities.OrderByDescending(x => x.MainSpeciality.HasValue ? x.MainSpeciality.Value : true).FirstOrDefault().Speciality.Name;
                        result.Add(umm);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public bool saveUnitManagerAndRelatedDoctors(saveUnitManagerAndRelatedDoctors saveList)
        {
            try
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    BindingList<DPUnitManagerRelation> controlList = DPUnitManagerRelation.GetByUnitManager(objectContext, saveList.UnitManagerObjectID);
                    if (controlList != null && controlList.Count > 0)
                    {
                        IList tempItemPX = controlList.ToList();
                        foreach (DPUnitManagerRelation itemX in tempItemPX)
                        {
                            var deleteItemX = controlList.Where(x => x.ObjectID == itemX.ObjectID).FirstOrDefault();
                            if (deleteItemX != null)
                            {
                                ((ITTObject)deleteItemX).Delete();
                            }
                        }
                    }

                    foreach (Guid item in saveList.ResUserObjectIDList)
                    {
                        ResUser ru = objectContext.GetObject<ResUser>(item);
                        if (ru != null)
                        {
                            DPUnitManagerRelation um = new DPUnitManagerRelation(objectContext);
                            um.TTUserUnitManager = saveList.UnitManagerObjectID;
                            um.RelatedUser = ru;
                        }
                    }
                    objectContext.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(" saveUnitManagerAndRelatedDoctors: " + ex.Message, ex);
            }
        }
        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public HasDPRolesModel HasDPRoles()
        {
            HasDPRolesModel result = new HasDPRolesModel();
            TTUser currentUser = Common.CurrentResource.GetMyTTUser();
            result.hasDPGrafikGenelRole = currentUser.HasRole(TTRoleNames.DP_Grafik_Genel);
            result.hasDPGrafikOzelRole = currentUser.HasRole(TTRoleNames.DP_Grafik_Ozel);
            result.hasDPYonetimPaneliRole = currentUser.HasRole(TTRoleNames.DP_Yonetim_Paneli); 
            
            return result;
        }

        

    }
}