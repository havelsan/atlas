using ReportClasses.ReportUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TTInstanceManagement;
using TTObjectClasses;

namespace AtlasDataSource.Controllers
{
    class TigXmlRaporu
    {
        public static TigXmlData GetReportData(string parameters)
        {
            return ApiCaller.CallAnyApiWithParams<TigXmlData>(parameters, "GetTigXmlRaporuData");
        }
        public static TigXmlData GetTigXmlRaporuData(string parameters)
        {
            TigXmlData data = new TigXmlData();
            DrgPatientDtos drgPatientDtoList = new DrgPatientDtos();

            if (parameters != null)
            {
                var param = Newtonsoft.Json.JsonConvert.DeserializeObject<TigXmlParameters>(parameters.ToString());
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    //try
                    //{
                    foreach (Guid tigObject in param.TigObjectIDs)
                    {
                        TigEpisode tigEpisode = (TigEpisode)objectContext.GetObject(tigObject, "TIGEPISODE");
                        tigEpisode.XMLStatus = true;
                        tigEpisode.XMLCreatedByUser = (ResUser)Common.CurrentUser.UserObject;
                        tigEpisode.XMLCreationDate = Common.RecTime();

                        Episode patientEpisode = objectContext.GetObject((Guid)tigEpisode.EpisodeGuid, typeof(Episode)) as Episode;
                        SubEpisodeProtocol patientSEP = objectContext.GetObject((Guid)tigEpisode.SEPGuid, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                        Patient patient = objectContext.GetObject((Guid)tigEpisode.PatientGuid, typeof(Patient)) as Patient;
                        Resource resource = objectContext.GetObject((Guid)tigEpisode.ResourceGuid, typeof(Resource)) as Resource;

                        DrgPatientDto drgPatientDto = new DrgPatientDto();
                        drgPatientDto.HospitalCode = TTObjectClasses.SystemParameter.GetSaglikTesisKodu().ToString();

                        if (patient.IsTrusted == true)
                        {
                            if (patient.Foreign == true)
                            {
                                drgPatientDto.PatientTypeId = 2;
                                if (patient.ForeignUniqueRefNo != null)
                                {
                                    drgPatientDto.PatientIdentification = patient.ForeignUniqueRefNo.ToString();
                                }
                                else if (patient.PassportNo != null)
                                {
                                    drgPatientDto.PatientIdentification = patient.PassportNo.ToString();
                                }
                                else
                                {
                                    SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                                    drgPatientDto.PatientIdentification = myTesisSKRSKurumlarDefinition.KODU.ToString() + "_" + patient.ID.ToString();
                                }
                            }
                            else
                            {
                                drgPatientDto.PatientTypeId = 1;
                                drgPatientDto.PatientNo = patient.UniqueRefNo.ToString();
                                drgPatientDto.PatientIdentification = drgPatientDto.PatientNo;
                            }
                        }
                        else
                        {
                            if (patient.Nationality.Kodu == "TR")
                            {
                                drgPatientDto.PatientTypeId = 1;
                                drgPatientDto.PatientNo = patient.UniqueRefNo.ToString();
                                drgPatientDto.PatientIdentification = drgPatientDto.PatientNo;
                            }
                            else
                            {
                                drgPatientDto.PatientTypeId = 2;
                                if (patient.ForeignUniqueRefNo != null)
                                {
                                    drgPatientDto.PatientIdentification = patient.ForeignUniqueRefNo.ToString();
                                }
                                else if (patient.PassportNo != null)
                                {
                                    drgPatientDto.PatientIdentification = patient.PassportNo.ToString();
                                }
                                else
                                {
                                    SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                                    drgPatientDto.PatientIdentification = myTesisSKRSKurumlarDefinition.KODU.ToString() + "_" + patient.ID.ToString();
                                }
                            }
                        }


                        if (patient.UniqueRefNo != null)
                        {
                            if (patient.Foreign != true)
                            {

                            }
                            else
                            {
                                drgPatientDto.PatientTypeId = 2;
                                if (patient.ForeignUniqueRefNo != null)
                                {
                                    drgPatientDto.PatientIdentification = patient.ForeignUniqueRefNo.ToString();
                                }
                                else if (patient.PassportNo != null)
                                {
                                    drgPatientDto.PatientIdentification = patient.PassportNo.ToString();
                                }
                                else
                                {
                                    SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                                    drgPatientDto.PatientIdentification = myTesisSKRSKurumlarDefinition.KODU.ToString() + "_" + patient.ID.ToString();
                                }
                            }


                        }

                        else if ((bool)patientEpisode.PatientAdmissions[0].IsNewBorn)
                        {
                            drgPatientDto.PatientTypeId = 4;
                            drgPatientDto.PatientNo = patient.Mother.UniqueRefNo.ToString();
                            drgPatientDto.PatientIdentification = patient.Mother.UniqueRefNo.ToString();
                        }
                        else if ((bool)patient.UnIdentified)
                        {
                            drgPatientDto.PatientTypeId = 6;
                        }
                        //drgPatientDto.PatientNo = patient.UniqueRefNo.ToString();
                        drgPatientDto.SexId = patient.Sex.KODU;
                        DateTime inPDate = (DateTime)tigEpisode.InpatientDate;
                        drgPatientDto.AdmissionDate = ((DateTime)tigEpisode.InpatientDate).ToString("yyyy-MM-ddThh:mm:ss");
                        drgPatientDto.BirthDate = ((DateTime)patient.BirthDate).ToString("yyyy-MM-ddThh:mm:ss");
                        drgPatientDto.AdmissionNo = patientSEP.SubEpisode.ProtocolNo;
                        //drgPatientDto.DischargeTypeId =       Taburcu Şekli
                        var discharge = patientEpisode.TreatmentDischarges.OrderByDescending(c => c.DischargeDate).FirstOrDefault();
                        if (discharge != null)
                        {
                            string dischargeType = discharge.DischargeType.SKRSCikisSekli.KODU;
                            if (dischargeType == "3")
                            {
                                drgPatientDto.DischargeTypeId = "1";
                            }
                            else if (dischargeType == "5")
                            {
                                drgPatientDto.DischargeTypeId = "6";
                            }
                            else if (dischargeType == "7" || dischargeType == "8" || dischargeType == "98")
                            {
                                drgPatientDto.DischargeTypeId = "9";
                            }
                            else if (dischargeType == "6")
                            {
                                drgPatientDto.DischargeTypeId = "8";
                            }
                            else
                            {
                                drgPatientDto.DischargeTypeId = "9";

                            }
                        }

                        drgPatientDto.DischargeDate = ((DateTime)tigEpisode.DischargeDate).ToString("yyyy-MM-ddThh:mm:ss");
                        drgPatientDto.IsNewBorn = false;
                        if (drgPatientDto.PatientTypeId == 4)
                        {
                            drgPatientDto.IsNewBorn = true;
                            drgPatientDto.BabySexId = drgPatientDto.SexId;
                            drgPatientDto.BabyBirthDate = drgPatientDto.BirthDate;
                            if (patient.Weight != null)
                                drgPatientDto.BirthWeight = patient.Weight.ToString();
                            var birthOrder = patient.BirthOrder;
                            if (birthOrder != null)
                            {
                                drgPatientDto.BabySequenceNumber = birthOrder.KODU;
                            }
                        }
                        drgPatientDto.IsPermitted = false;
                        drgPatientDto.PermittedDays = 0;
                        drgPatientDto.PatientName = patient.ToString();
                        PayerTypeEnum pt = (PayerTypeEnum)patientSEP.Payer.Type.PayerType;
                        if (pt == PayerTypeEnum.SGK)
                        {
                            drgPatientDto.StatusId = 1;
                            if (patientSEP.MedulaDevredilenKurum != null)
                            {
                                if (patientSEP.MedulaDevredilenKurum.devredilenKurumKodu == "4")
                                {
                                    drgPatientDto.StatusId = 2;
                                }
                            }

                        }
                        else if (pt == PayerTypeEnum.Paid)
                        {
                            drgPatientDto.StatusId = 3;
                        }
                        else if (pt == PayerTypeEnum.Insurance)
                        {
                            drgPatientDto.StatusId = 4;
                        }
                        else
                        {
                            drgPatientDto.StatusId = 5;
                        }

                        List<InPatientTreatmentClinicApplication> inpatientTreClinApps = patientEpisode.InPatientTreatmentClinicApplications.ToList();
                        int intensiveCareDays = 0;
                        foreach (InPatientTreatmentClinicApplication itca in inpatientTreClinApps)
                        {
                            var resclinic = itca.MasterResource as ResClinic;
                            if (resclinic != null)
                            {
                                if (resclinic is ResIntensiveCare)
                                {
                                    intensiveCareDays += (int)((DateTime)itca.ClinicDischargeDate - (DateTime)itca.ClinicInpatientDate).TotalDays;
                                }
                            }
                        }
                        drgPatientDto.IntensiveCareDays = intensiveCareDays;
                        var transfer = patientEpisode.InPatientTreatmentClinicApplications.FirstOrDefault(c => c.CurrentStateDef.Status != TTDefinitionManagement.StateStatusEnum.Cancelled && c.FromInPatientTrtmentClinicApp != null);
                        drgPatientDto.AdmissionTypeId = transfer == null ? "3" : "4";

                        //drgPatientDto.CareTypeId          Hasta Tipi
                        if (patientSEP.MedulaTedaviTuru != null && patientSEP.MedulaTedaviTuru.tedaviTuruKodu != null)
                        {
                            if (patientSEP.MedulaTedaviTuru.tedaviTuruKodu == "G")
                            {
                                drgPatientDto.CareTypeId = "4";
                            }
                            else if (resource is ResClinic && ((ResClinic)resource).ResSectionType != null && ((ResClinic)resource).ResSectionType == ResSectionTypeEnum.PalyatifBakim)
                            {
                                drgPatientDto.CareTypeId = "5";
                            }
                            else
                            {
                                drgPatientDto.CareTypeId = "1";
                            }
                        }
                        if (patientSEP.MedulaTakipNo == null)
                        {
                            var patientInpSep = patientSEP.Episode.AllSGKSubEpisodeProtocols().Where(t => t.MedulaTakipNo != null && t.MedulaTedaviTuru.tedaviTuruKodu == "Y").OrderBy(t => t.Id.Value).FirstOrDefault();
                            if (patientInpSep != null)
                            {
                                drgPatientDto.TakipNo = drgPatientDto.StatusId == 1 || drgPatientDto.StatusId == 2 ? patientInpSep.MedulaTakipNo : "";
                            }
                            else
                            {
                                drgPatientDto.TakipNo = "";
                            }

                        }
                        else
                        {
                            drgPatientDto.TakipNo = drgPatientDto.StatusId == 1 || drgPatientDto.StatusId == 2 ? patientSEP.MedulaTakipNo : "";

                        }

                        if (patientSEP.SubEpisode.StarterEpisodeAction != null)
                        {
                            drgPatientDto.DrTcKimlik = patientSEP.SubEpisode.StarterEpisodeAction.ProcedureDoctor.Person.UniqueRefNo.ToString();
                            if (patientSEP.SubEpisode.StarterEpisodeAction.ProcedureDoctor.Brans != null)
                            {
                                drgPatientDto.DrBrans = patientSEP.SubEpisode.StarterEpisodeAction.ProcedureDoctor.Brans.Code;
                                drgPatientDto.DrBransId = patientSEP.SubEpisode.StarterEpisodeAction.ProcedureDoctor.Brans.Code;
                            }


                        }
                        else
                        {
                            drgPatientDto.DrTcKimlik = patientSEP.SubEpisode.SubActionProcedures[0].ProcedureDoctor.Person.UniqueRefNo.ToString();
                            if (patientSEP.SubEpisode.SubActionProcedures[0].ProcedureDoctor.Brans != null)
                            {
                                drgPatientDto.DrBrans = patientSEP.SubEpisode.SubActionProcedures[0].ProcedureDoctor.Brans.Code;
                                drgPatientDto.DrBransId = patientSEP.SubEpisode.SubActionProcedures[0].ProcedureDoctor.Brans.Code;
                            }

                        }

                        drgPatientDtoList.drgPatientDtos.Add(drgPatientDto);

                    }

                }

                XmlSerializer serializer = new XmlSerializer(typeof(DrgPatientDtos));
                var memoryStream = new MemoryStream();
                serializer.Serialize(memoryStream, drgPatientDtoList);
                memoryStream.Position = 0;

                StreamReader reader = new StreamReader(memoryStream);
                string XmlStr = reader.ReadToEnd();

                XmlStr = XmlStr.Replace("drgPatientDtos", "DrgPatientDtos");
                data.XmlData = XmlStr;
            }
            return data;

        }
    }

    [Serializable]
    public class TigXmlParameters
    {
        [DataMember]
        public Guid[] TigObjectIDs { get; set; }

    }

    [Serializable]
    public class TigXmlData
    {
        [DataMember]
        public string XmlData { get; set; }
    }

    public class DrgPatientDto
    {
        [DataMember]
        public string HospitalCode { get; set; }
        [DataMember]
        public string PatientNo { get; set; }
        [DataMember]
        public string BirthDate { get; set; }
        [DataMember]
        public string SexId { get; set; }
        [DataMember]
        public string AdmissionDate { get; set; }
        [DataMember]
        public string AdmissionNo { get; set; }
        [DataMember]
        public string DischargeTypeId { get; set; }
        [DataMember]
        public string DischargeDate { get; set; }
        [DataMember]
        public bool IsNewBorn { get; set; }
        [DataMember]
        public string BirthWeight { get; set; }
        [DataMember]
        public string BabyBirthDate { get; set; }
        [DataMember]
        public string BabySexId { get; set; }
        [DataMember]
        public bool IsPermitted { get; set; }
        [DataMember]
        public int PermittedDays { get; set; }
        [DataMember]
        public string PatientName { get; set; }
        [DataMember]
        public int StatusId { get; set; }
        [DataMember]
        public int IntensiveCareDays { get; set; }
        [DataMember]
        public string AdmissionTypeId { get; set; }
        [DataMember]
        public string CareTypeId { get; set; }
        [DataMember]
        public string TakipNo { get; set; }
        [DataMember]
        public string DrTcKimlik { get; set; }
        [DataMember]
        public string DrBrans { get; set; }
        [DataMember]
        public string DrBransId { get; set; }
        [DataMember]
        public int PatientTypeId { get; set; }
        [DataMember]
        public string PatientIdentification { get; set; }
        [DataMember]
        public string BabySequenceNumber { get; set; }

    }
    public class DrgPatientDtos
    {
        public List<DrgPatientDto> drgPatientDtos = new List<DrgPatientDto>();

    }
}
