//$5C414B4A
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Xml.Serialization;
using Core.Security;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class TigEpisodeServiceController
    {
        public TigEpisodeFormSearchModel TigEpisodeFormSearchModel
        {
            get;
            set;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public TagBoxObject[] GetDoctor()
        {
            TagBoxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResUser.DoctorListNQL(objectContext, "");
                var query =
                    from i in ttList
                    orderby i.Name
                    select new TagBoxObject
                    {
                        ObjectID = i.ObjectID,
                        Name = i.Name,
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public TagBoxObject[] GetClinics()
        {
            TagBoxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResClinic.GetAllClinics(objectContext);
                var query =
                    from i in ttList
                    orderby i.Name
                    select new TagBoxObject
                    {
                        ObjectID = i.ObjectID,
                        Name = i.Name,
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public TagBoxObject[] GetSpecialities()
        {
            TagBoxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = SpecialityDefinition.GetAllSpecialityDefinition(objectContext, "");
                var query =
                    from i in ttList
                    orderby i.Name
                    select new TagBoxObject
                    {
                        ObjectID = i.ObjectID,
                        Name = i.Name,
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public TagBoxObject[] GetTigPersonelList()
        {
            TagBoxObject[] result;
            using (var objectContext = new TTObjectContext(true))
            {
                var ttList = ResUser.GetResUserByUserType(objectContext, UserTypeEnum.TigResponsible);
                var query =
                    from i in ttList
                    orderby i.Name
                    select new TagBoxObject
                    {
                        ObjectID = i.ObjectID,
                        Name = i.Name,
                    };
                result = query.ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
            return result;
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Everyone)]
        public Guid? GetFileCreationAndAnalysis(Guid EpisodeID)
        {
            Guid? fcaa = null;
            using (var objectContext = new TTObjectContext(true))
            {
                BindingList<EpisodeFolder.GetFCAAForTIG_Class> episodeList = EpisodeFolder.GetFCAAForTIG(EpisodeID);
                if (episodeList.Count > 0)
                    fcaa = episodeList[0].FileCreationAndAnalysis;

            }

            return fcaa;

        }


        private string createSearchFilterExpression(TigEpisodeFormSearchModel searchModel)
        {
            string filterExpression = string.Empty;
            if (searchModel.DischargeDateBegin.HasValue == false)
            {
                if (searchModel.DischargeDateEnd.HasValue == false)
                    filterExpression += " AND (DISCHARGEDATE BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59'))";
                else
                    filterExpression += " AND (  DISCHARGEDATE BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchModel.DischargeDateEnd.Value.Year, searchModel.DischargeDateEnd.Value.Month, searchModel.DischargeDateEnd.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') )";
            }
            else
            {
                if (searchModel.DischargeDateEnd.HasValue == false)
                    filterExpression += " AND (  DISCHARGEDATE BETWEEN TODATE('" + (new DateTime(searchModel.DischargeDateBegin.Value.Year, searchModel.DischargeDateBegin.Value.Month, searchModel.DischargeDateBegin.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59'))";
                else
                    filterExpression += " AND (  DISCHARGEDATE BETWEEN TODATE('" + (new DateTime(searchModel.DischargeDateBegin.Value.Year, searchModel.DischargeDateBegin.Value.Month, searchModel.DischargeDateBegin.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchModel.DischargeDateEnd.Value.Year, searchModel.DischargeDateEnd.Value.Month, searchModel.DischargeDateEnd.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') )";
            }

            if (searchModel.XMLCreationDateBegin.HasValue == false)
            {
                if (searchModel.XMLCreationDateEnd.HasValue == false)
                    filterExpression += " AND ( ( XMLCREATIONDATE BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59') OR XMLCREATIONDATE IS NULL ))";
                else
                    filterExpression += " AND ( ( XMLCREATIONDATE BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchModel.XMLCreationDateEnd.Value.Year, searchModel.XMLCreationDateEnd.Value.Month, searchModel.XMLCreationDateEnd.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') OR XMLCREATIONDATE IS NOT NULL ))";
            }
            else
            {
                if (searchModel.XMLCreationDateEnd.HasValue == false)
                    filterExpression += " AND ( ( XMLCREATIONDATE BETWEEN TODATE('" + (new DateTime(searchModel.XMLCreationDateBegin.Value.Year, searchModel.XMLCreationDateBegin.Value.Month, searchModel.XMLCreationDateBegin.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59') OR XMLCREATIONDATE IS NOT NULL ))";
                else
                    filterExpression += " AND ( ( XMLCREATIONDATE BETWEEN TODATE('" + (new DateTime(searchModel.XMLCreationDateBegin.Value.Year, searchModel.XMLCreationDateBegin.Value.Month, searchModel.XMLCreationDateBegin.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchModel.XMLCreationDateEnd.Value.Year, searchModel.XMLCreationDateEnd.Value.Month, searchModel.XMLCreationDateEnd.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') OR XMLCREATIONDATE IS NOT NULL ))";
            }

            if (searchModel.CodingDateBegin.HasValue == false)
            {
                if (searchModel.CodingDateEnd.HasValue == false)
                    filterExpression += " AND ( ( CODINGDATE BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59') OR CODINGDATE IS NULL ))";
                else
                    filterExpression += " AND ( ( CODINGDATE BETWEEN TODATE('" + DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchModel.CodingDateEnd.Value.Year, searchModel.CodingDateEnd.Value.Month, searchModel.CodingDateEnd.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') OR CODINGDATE IS NOT NULL ))";
            }
            else
            {
                if (searchModel.CodingDateEnd.HasValue == false)
                    filterExpression += " AND (( CODINGDATE BETWEEN TODATE('" + (new DateTime(searchModel.CodingDateBegin.Value.Year, searchModel.CodingDateBegin.Value.Month, searchModel.CodingDateBegin.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + Common.RecTime().ToString("yyyy-MM-dd") + " " + "23:59:59') OR CODINGDATE IS NOT NULL ))";
                else
                    filterExpression += " AND (( CODINGDATE BETWEEN TODATE('" + (new DateTime(searchModel.CodingDateBegin.Value.Year, searchModel.CodingDateBegin.Value.Month, searchModel.CodingDateBegin.Value.Day, 00, 00, 00)).ToString("yyyy-MM-dd HH:mm:ss") +
                        "') AND TODATE('" + (new DateTime(searchModel.CodingDateEnd.Value.Year, searchModel.CodingDateEnd.Value.Month, searchModel.CodingDateEnd.Value.Day, 23, 59, 59)).ToString("yyyy-MM-dd HH:mm:ss") + "') OR CODINGDATE IS NOT NULL ))";
            }

            filterExpression += " AND CANCELLED <> 1 ";

            if (searchModel.SelectedDoctorsListItems != null)
            {
                if (searchModel.SelectedDoctorsListItems.Count != 0)
                {
                    filterExpression += " AND DISCHARGERDOCTORGUID IN (";
                    foreach (Guid t in searchModel.SelectedDoctorsListItems)
                    {
                        filterExpression += "'" + t + "',";
                    }
                    filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                    filterExpression += ")";
                }
            }



            if (searchModel.XMLStatus != null)
            {
                if (searchModel.XMLStatus != 2)
                {
                    filterExpression += " AND XMLSTATUS = " + searchModel.XMLStatus;
                }
            }

            if (searchModel.CodingStatus != null)
            {
                if (searchModel.CodingStatus != 2)
                {
                    filterExpression += " AND CODINGSTATUS = " + searchModel.CodingStatus;
                }
            }

            if (searchModel.InvoiceStatus != null)
            {
                if (searchModel.InvoiceStatus != 2)
                {
                    filterExpression += " AND INVOICESTATUS = " + searchModel.InvoiceStatus;
                }
            }

            if (searchModel.PathologyRequestStatus != null)
            {
                if (searchModel.PathologyRequestStatus != 2)
                {
                    filterExpression += " AND PATHOLOGYREQUESTSTATUS = " + searchModel.PathologyRequestStatus;
                }
            }

            if (searchModel.PathologyReportStatus != null)
            {
                if (searchModel.PathologyReportStatus != 2)
                {
                    filterExpression += " AND PATHOLOGYREPORTSTATUS = " + searchModel.PathologyReportStatus;
                }
            }

            if (searchModel.AppointmentStatus != null)
            {
                if (searchModel.AppointmentStatus != 2)
                {
                    filterExpression += " AND APPOINTMENTSTATUS = " + searchModel.AppointmentStatus;
                }
            }

            if (searchModel.EpicrisisStatus != null)
            {
                if (searchModel.EpicrisisStatus != 2)
                {
                    filterExpression += " AND EPICRISISSTATUS = " + searchModel.EpicrisisStatus;
                }
            }


            if (searchModel.SelectedClinicsListItems != null)
            {
                if (searchModel.SelectedClinicsListItems.Count != 0)
                {
                    filterExpression += " AND RESOURCEGUID IN (";
                    foreach (Guid t in searchModel.SelectedClinicsListItems)
                    {
                        filterExpression += "'" + t + "',";
                    }
                    filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                    filterExpression += ")";
                }
            }

            if (searchModel.SelectedSpecialitiesListItems != null)
            {
                if (searchModel.SelectedSpecialitiesListItems.Count != 0)
                {
                    filterExpression += " AND BRANCHGUID IN (";
                    foreach (Guid t in searchModel.SelectedSpecialitiesListItems)
                    {
                        filterExpression += "'" + t + "',";
                    }
                    filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                    filterExpression += ")";
                }
            }

            if (searchModel.SelectedXMLCreatedByUserListItems != null)
            {
                if (searchModel.SelectedXMLCreatedByUserListItems.Count != 0)
                {
                    filterExpression += " AND XMLCREATEDBYUSER IN (";
                    foreach (Guid t in searchModel.SelectedXMLCreatedByUserListItems)
                    {
                        filterExpression += "'" + t + "',";
                    }
                    filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                    filterExpression += ")";
                }
            }

            if (searchModel.SelectedCodingByUserListItems != null)
            {
                if (searchModel.SelectedCodingByUserListItems.Count != 0)
                {
                    filterExpression += " AND CODINGBYUSER IN (";
                    foreach (Guid t in searchModel.SelectedCodingByUserListItems)
                    {
                        filterExpression += "'" + t + "',";
                    }
                    filterExpression = filterExpression.Remove(filterExpression.Length - 1);
                    filterExpression += ")";
                }
            }
            if (searchModel.PatientType != null)
                filterExpression += " AND PATIENTTYPE=" + (int)searchModel.PatientType;

            if(!String.IsNullOrEmpty(searchModel.Description))
            {
                filterExpression += " AND DESCRIPTION LIKE '%" + searchModel.Description + "%'";
            }

            if(searchModel.ProtocolNo != null)
            {
                filterExpression += " AND INPATIENTPROTOCOLNO = '" + searchModel.ProtocolNo + "'";
            }

            if(!String.IsNullOrEmpty(searchModel.ArchiveNo))
            {
                BindingList<EpisodeFolder.GetEpisodeIDForTIG_Class> episodeList = EpisodeFolder.GetEpisodeIDForTIG(searchModel.ArchiveNo);
                if(episodeList.Count > 0)
                {
                    string episodeIDList = "(";
                    foreach (EpisodeFolder.GetEpisodeIDForTIG_Class item in episodeList)
                    {
                        if(item.Episodeobjectid != null)
                            episodeIDList += "'" + item.Episodeobjectid + "',"; 
                    }
                    episodeIDList = episodeIDList.Remove(episodeIDList.Length - 1, 1);
                    episodeIDList += ")";
                    filterExpression += " AND EPISODEGUID IN " + episodeIDList;
                }
            }

            if (searchModel.PatientID != null)
            {
                filterExpression += " AND PATIENTGUID = '" + searchModel.PatientID + "'";
            }

            return filterExpression;
        }


        [AtlasRequiredRoles(TTRoleNames.Tig_Islemleri)]
        public TigEpisodeSearchResultModel[] GetTigEpisodeRecords(TigEpisodeFormSearchModel searchModel)
        {
            List<TigEpisodeSearchResultModel> tigEpisodeSearchResultList = new List<TigEpisodeSearchResultModel>();
            using (var objectContext = new TTObjectContext(true))
            {
                string filterExpression = this.createSearchFilterExpression(searchModel);
                List<TigEpisode.TigEpisodeNQL_Class> tigEpisodeList = new List<TigEpisode.TigEpisodeNQL_Class>();

                tigEpisodeList = TigEpisode.TigEpisodeNQL(objectContext, filterExpression).ToList();

                if (tigEpisodeList.Count > 0)
                {
                    List<string> EpisodeNoList = new List<string>();
                    foreach (TigEpisode.TigEpisodeNQL_Class tigEpisodeObject in tigEpisodeList)
                    {
                        var episodeCheck = false;
                        foreach (string item in EpisodeNoList)
                        {
                            if (item == tigEpisodeObject.EpisodeGuid.ToString())
                            {
                                episodeCheck = true;
                                break;
                            }
                        }
                        if (episodeCheck == false || tigEpisodeObject.IsCreatedByTreatmentCure == true)
                        {
                            bool isDaily = false;
                            if(tigEpisodeObject.IsCreatedByTreatmentCure != true)
                                EpisodeNoList.Add(tigEpisodeObject.EpisodeGuid.ToString());
                            TigEpisode.TigEpisodeNQL_Class tE = null;
                            if (tigEpisodeObject.IsCreatedByTreatmentCure != true)
                                tE = tigEpisodeList.Where(t => t.EpisodeGuid == tigEpisodeObject.EpisodeGuid && t.IsCreatedByTreatmentCure != true).OrderByDescending(t => t.DischargeDate).FirstOrDefault();
                            else
                                tE = tigEpisodeObject;
                            TigEpisodeSearchResultModel resultModel = new TigEpisodeSearchResultModel();
                            Episode ep = objectContext.GetObject((Guid)tE.EpisodeGuid, typeof(Episode)) as Episode;
                            SpecialityDefinition speciality = objectContext.GetObject((Guid)tE.BranchGuid, typeof(SpecialityDefinition)) as SpecialityDefinition;
                            ResUser dischargeDoctor = objectContext.GetObject((Guid)tE.DischargerDoctorGuid, typeof(ResUser)) as ResUser;
                            ResSection resource = objectContext.GetObject((Guid)tE.ResourceGuid, typeof(ResSection)) as ResSection;
                            Patient patient = objectContext.GetObject((Guid)tE.PatientGuid, typeof(Patient)) as Patient;
                            ResUser doctor = objectContext.GetObject((Guid)tE.DoctorGuid, typeof(ResUser)) as ResUser;
                            SubEpisodeProtocol sep = objectContext.GetObject((Guid)tE.SEPGuid, typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;
                            if (sep.MedulaTedaviTuru.tedaviTuruKodu == "G")
                                isDaily = true;
                            resultModel.TigObjectID = (Guid)tE.ObjectID;
                            resultModel.InvoiceNum = tE.InvoiceStatus != false ? sep.InvoiceCollectionDetail.PayerInvoiceDocument.DocumentNo : "";
                            resultModel.EpisodeGuid = ep.ObjectID;
                            resultModel.EpisodeNo = ep.ID.ToString();
                            resultModel.PatientName = patient.Name;
                            resultModel.PatientSurname = patient.Surname;
                            resultModel.PatientUniqueRefNo = patient.UniqueRefNo.ToString();
                            if (resource != null)
                                resultModel.Resource = resource.Name;
                            else
                                resultModel.Resource = sep.Brans.Name;
                            resultModel.DischargeDate = (DateTime)tE.DischargeDate;
                            resultModel.XMLStatus = (bool)tE.XMLStatus;
                            resultModel.XMLCreationDate = tE.XMLCreationDate != null ? tE.XMLCreationDate.ToString() : "";
                            resultModel.CodingStatus = (bool)tE.CodingStatus;
                            resultModel.CodingDate = tE.CodingDate != null ? tE.CodingDate.ToString() : "";
                            resultModel.Description = tE.Description;
                            resultModel.DoctorName = doctor.Name;
                            resultModel.DoctorUniqueRefNo = doctor.Person.UniqueRefNo.ToString();
                            resultModel.DischargerDoctorName = dischargeDoctor.Name;
                            resultModel.BranchName = speciality.Name;
                            resultModel.BranchCode = speciality.Code;
                            resultModel.PayerName = ep.Payer.Name;
                            resultModel.PatientType = Common.GetDisplayTextOfEnumValue("TIGPatientTypeEnum", (int)tE.PatientType);
                            if (isDaily == true)
                                resultModel.PatientType = Common.GetDisplayTextOfEnumValue("TIGPatientTypeEnum", (int)TIGPatientTypeEnum.Outpatient);
                            resultModel.Diagnosis = string.Empty;
                            resultModel.AppointmentDate = (DateTime)ep.OpeningDate;
                            resultModel.InPatientProtocolNo = tE.InPatientProtocolNo;

                            resultModel.Surgeries = "";
                            List<SurgeryProcedure.GetSurgeriesByEpisode_Class> surgeryList = new List<SurgeryProcedure.GetSurgeriesByEpisode_Class>();
                            foreach (SurgeryProcedure.GetSurgeriesByEpisode_Class surgeryProc in surgeryList)
                            {
                                resultModel.Surgeries += surgeryProc.Name + ", ";
                            }
                            if (resultModel.Surgeries != "")
                                resultModel.Surgeries = resultModel.Surgeries.Remove(resultModel.Surgeries.Length - 2);

                            resultModel.InpatientDate = (DateTime)tE.InpatientDate;
                            resultModel.PathologyRequest = tE.PathologyRequestStatus == true ? "Var" : TTUtils.CultureService.GetText("M24703", "Yok");
                            resultModel.PathologyStatus = tE.PathologyReportStatus == true ? TTUtils.CultureService.GetText("M26638", "Onaylanmış") : TTUtils.CultureService.GetText("M26637", "Onaylanmamış");
                            resultModel.XMLCreatedByUserName = tE.Xmlcreatedbyusername;
                            resultModel.CodingByUserName = tE.Codingbyusername;
                            if (tE.IsCreatedByTreatmentCure == true)
                                resultModel.RecordType = "Seans";
                            else
                                resultModel.RecordType = "Tedavi";

                            DiagnosisGrid[] episodeDiagnosis = ep.Diagnosis.ToArray();
                            if (episodeDiagnosis.Length > 0)
                            {
                                foreach (DiagnosisGrid dG in episodeDiagnosis)
                                {
                                    resultModel.Diagnosis += dG.DiagnoseCode + "-" + dG.Diagnose.Name + ", ";
                                }
                                resultModel.Diagnosis = resultModel.Diagnosis.Remove(resultModel.Diagnosis.Length - 2);

                            }



                            if (isDaily == true && searchModel.PatientType != null && searchModel.PatientType == TIGPatientTypeEnum.Outpatient)
                                tigEpisodeSearchResultList.Add(resultModel);
                            else if (isDaily == false && searchModel.PatientType != null && searchModel.PatientType == TIGPatientTypeEnum.Inpatient)
                                tigEpisodeSearchResultList.Add(resultModel);
                            else if (searchModel.PatientType == null)
                                tigEpisodeSearchResultList.Add(resultModel);
                        }

                    }


                }
            }



            return tigEpisodeSearchResultList.ToArray();
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Tig_Islemleri)]
        public void MarkCodedForSelectedEpisodes(TigEpisodeSearchResultModel[] tigObjectList)
        {

            TTObjectContext objectContext = new TTObjectContext(false);

            try
            {
                foreach (TigEpisodeSearchResultModel tigObject in tigObjectList)
                {
                    TigEpisode tigEpisode = (TigEpisode)objectContext.GetObject(tigObject.TigObjectID, "TIGEPISODE");
                    if (tigEpisode.XMLStatus == true)
                    {
                        tigEpisode.CodingStatus = true;
                        tigEpisode.CodingByUser = (ResUser)Common.CurrentUser.UserObject;
                        tigEpisode.CodingDate = Common.RecTime();
                    }

                }
                objectContext.Save();
            }
            catch (Exception ex)
            {

            }
        }

        [HttpGet]
        public void CreateDescriptionForSelectedTIG(Guid TIGEpisodeID, string description)
        {
            TTObjectContext objectContext = new TTObjectContext(false);
            TigEpisode tigEpisode = (TigEpisode)objectContext.GetObject(TIGEpisodeID, "TIGEPISODE");
            tigEpisode.Description = description;
            objectContext.Save();
        }

    }


}

namespace Core.Models
{
    public partial class TigEpisodeFormViewModel
    {
        public TigEpisodeFormSearchModel TigEpisodeFormSearchModel { get; set; }
        public List<TigEpisodeSearchResultModel> TigEpisodeCollectionList { get; set; }

        public TigEpisodeFormViewModel()
        {
            TigEpisodeFormSearchModel = new TigEpisodeFormSearchModel();
            TigEpisodeCollectionList = new List<TigEpisodeSearchResultModel>();
        }
    }

    public class TigEpisodeFormSearchModel
    {
        public DateTime? DischargeDateBegin
        {
            get;
            set;
        }

        public DateTime? DischargeDateEnd
        {
            get;
            set;
        }

        public DateTime? XMLCreationDateBegin
        {
            get;
            set;
        }

        public DateTime? XMLCreationDateEnd
        {
            get;
            set;
        }

        public DateTime? CodingDateBegin
        {
            get;
            set;
        }

        public DateTime? CodingDateEnd
        {
            get;
            set;
        }
        public TIGPatientTypeEnum? PatientType
        {
            get;
            set;
        }

        public int? XMLStatus
        {
            get;
            set;
        }

        public int? CodingStatus
        {
            get;
            set;
        }

        public int? InvoiceStatus
        {
            get;
            set;
        }

        public int? PathologyRequestStatus
        {
            get;
            set;
        }

        public int? PathologyReportStatus
        {
            get;
            set;
        }

        public int? AppointmentStatus
        {
            get;
            set;
        }

        public int? EpicrisisStatus
        {
            get;
            set;
        }

        public List<Guid> SelectedDoctorsListItems { get; set; }

        public List<Guid> SelectedClinicsListItems { get; set; }

        public List<Guid> SelectedSpecialitiesListItems { get; set; }

        public List<Guid> SelectedXMLCreatedByUserListItems { get; set; }

        public List<Guid> SelectedCodingByUserListItems { get; set; }
        public string Description { get; set; }
        public string ProtocolNo { get; set; }
        public string ArchiveNo { get; set; }
        public Guid? PatientID { get; set; }

    }

    public class TigEpisodeSearchResultModel
    {
        public Guid TigObjectID
        {
            get;
            set;
        }

        public Guid EpisodeGuid
        {
            get;
            set;
        }

        public string EpisodeNo
        {
            get;
            set;
        }

        public string PatientName
        {
            get;
            set;
        }

        public string PatientSurname
        {
            get;
            set;
        }

        public string PatientUniqueRefNo
        {
            get;
            set;
        }

        public string Resource
        {
            get;
            set;
        }

        public DateTime InpatientDate
        {
            get;
            set;
        }

        public DateTime DischargeDate
        {
            get;
            set;
        }

        public bool XMLStatus
        {
            get;
            set;
        }

        public string XMLCreationDate
        {
            get;
            set;
        }

        public bool CodingStatus
        {
            get;
            set;
        }

        public string CodingDate
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string InvoiceNum
        {
            get;
            set;
        }

        public string DoctorName
        {
            get;
            set;
        }

        public string DoctorUniqueRefNo
        {
            get;
            set;
        }

        public string DischargerDoctorName
        {
            get;
            set;
        }

        public string BranchName
        {
            get;
            set;
        }

        public string BranchCode
        {
            get;
            set;
        }

        public string PayerName
        {
            get;
            set;
        }

        public string PatientType
        {
            get;
            set;
        }

        public string Diagnosis
        {
            get;
            set;
        }

        public string InPatientProtocolNo
        {
            get;
            set;
        }

        public string Surgeries
        {
            get;
            set;
        }

        public DateTime AppointmentDate
        {
            get;
            set;
        }

        public string PathologyRequest
        {
            get;
            set;
        }

        public string PathologyStatus
        {
            get;
            set;
        }

        public string XMLCreatedByUserName
        {
            get;
            set;
        }

        public string CodingByUserName
        {
            get;
            set;
        }

        public string RecordType
        {
            get;
            set;
        }
    }

    public class TagBoxObject
    {
        public Guid? ObjectID { get; set; }

        public string Name { get; set; }
    }

    public class DrgPatientDto
    {
        public string HospitalCode { get; set; }
        [XmlElement(IsNullable = true)]
        public string PatientNo { get; set; }
        public string BirthDate { get; set; }
        public string SexId { get; set; }
        public string AdmissionDate { get; set; }
        public string AdmissionNo { get; set; }
        public string DischargeTypeId { get; set; }
        public string DischargeDate { get; set; }
        public bool IsNewBorn { get; set; }
        [XmlElement(IsNullable = true)]
        public string BirthWeight { get; set; }
        [XmlElement(IsNullable = true)]
        public string BabyBirthDate { get; set; }
        [XmlElement(IsNullable = true)]
        public string BabySexId { get; set; }
        public bool IsPermitted { get; set; }
        public int PermittedDays { get; set; }
        public string PatientName { get; set; }
        public int StatusId { get; set; }
        public int IntensiveCareDays { get; set; }
        public string AdmissionTypeId { get; set; }
        public string CareTypeId { get; set; }
        public string TakipNo { get; set; }
        public string DrTcKimlik { get; set; }
        public string DrBrans { get; set; }
        public string DrBransId { get; set; }
        public int PatientTypeId { get; set; }
        [XmlElement(IsNullable = true)]
        public string PatientIdentification { get; set; }
        [XmlElement(IsNullable = true)]
        public string BabySequenceNumber { get; set; }

    }

    public class DrgPatientDtos
    {
        public List<DrgPatientDto> drgPatientDtos = new List<DrgPatientDto>();


    }
}
