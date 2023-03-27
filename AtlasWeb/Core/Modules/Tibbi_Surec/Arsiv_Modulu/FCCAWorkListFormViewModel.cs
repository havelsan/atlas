using Infrastructure.Helpers;
using System.Collections.Generic;
using System.Linq;
using Core.Models;
using System.Collections;
using TTDefinitionManagement;
using TTInstanceManagement;
using Infrastructure.Filters;
using Infrastructure.Models;
using Core.Services;
using System;
using TTObjectClasses;
using TTUtils;
using TTStorageManager.Security;
using System.ComponentModel;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using TTConnectionManager;
using Core.Security;
using Newtonsoft.Json;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class FCCAWorkListServiceController : Controller
    {

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Arsiv_Bolum_islemleri, TTRoleNames.Arsiv_Arsiv_Islemleri, TTRoleNames.Fatura_Islemleri)]
        public FCCAWorkListFormViewModel FCCAWorkListQuery(WorkListQueryFilter param)
        {
            FCCAWorkListFormViewModel viewModel = new FCCAWorkListFormViewModel();
            DateTime startDate = Common.RecTime();//  böyle bir case olmamalı Clientda bunlar hep seçili gelmeli ancak olduda seçilmezse rectime alınır çünkü Queryde tarih zorunlu
            DateTime endDate = Common.RecTime().AddDays(1);
            string filterExpression = "";
            if (!string.IsNullOrEmpty(param.episodeFolderID))
            {
                string manuelArchiveNoControl = TTObjectClasses.SystemParameter.GetParameterValue("MANUELARSIVNUMARASIKULLAN", "FALSE");
                if (manuelArchiveNoControl.Equals("TRUE"))
                {
                    filterExpression += " AND this.ManuelArchiveNo = '" + param.episodeFolderID + "'";
                }
                else
                {
                    filterExpression += " AND this.EpisodeFolderID = '" + param.episodeFolderID + "'";
                }
            }
            else
            {
                if (param.StartDate != null)
                {
                    startDate = param.StartDate.Date;
                }
                if (param.EndDate != null)
                {
                    endDate = param.EndDate.Date.AddDays(1);// ÖR:Girilen bitiş tarihi 30.08.2017 15:50  iken  31.08.2017 00:00 dan küçüçük işlem tarihliler gelsin diye
                }
                if (param.Location != null)
                    filterExpression = "AND this.EpisodeFolderLocation = '" + param.Location.ToString() + "'";
                else
                    filterExpression = "AND this.EpisodeFolderLocation <>" + "'" + TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationInvoiceGuid", "e2f883dc-e42c-4728-bf2c-01f301b7080f") + "'" + "AND this.EpisodeFolderLocation <>" + "'" + TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationTIGGuid", "bd7396be-17ca-478b-a045-9e7fdae563fa") + "'" + " AND this.EpisodeFolderLocation <>" + "'" + TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationArchiveGuid", "2e4789c1-d71a-4fc1-b9ad-209daf62871d") + "'";
                if (param.ArchiveStartDate != null)
                    filterExpression += " AND this.FileCreationAndAnalysis.ActionDate > TODATE('" + param.ArchiveStartDate?.Date.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                if (param.ArchiveStartDate != null)
                    filterExpression += " AND this.FileCreationAndAnalysis.ActionDate < TODATE('" + param.ArchiveEndDate?.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                if (param.PatientUniqueRefNo != null && param.PatientUniqueRefNo != "")
                    filterExpression += " AND this.MyEpisode.Patient.UniqueRefNo = " + param.PatientUniqueRefNo.Trim();
                if (param.PatientObjectID != Guid.Empty)
                    filterExpression += " AND this.MyEpisode.Patient = '" + param.PatientObjectID.ToString() + "'";
                if (param.ProtocolNo != null && param.ProtocolNo != "")
                    filterExpression += " AND this.LastInPatientTreatment.SubEpisode.ProtocolNo = '" + param.ProtocolNo.Trim() + "'";
            }
            if (!Common.CurrentUser.HasRole(TTRoleNames.Adli_Dosya_Goruntuleme))
            {
                filterExpression += " AND IFNULL(this.FileCreationAndAnalysis.AdliVaka,0) = 0 ";
            }
            List<EpisodeFolder.EpisodeFolderWorklistNQL_Class> archiveDataSource = new List<EpisodeFolder.EpisodeFolderWorklistNQL_Class>();
            archiveDataSource = EpisodeFolder.EpisodeFolderWorklistNQL(param.psEnum, startDate, endDate, filterExpression).ToList();
            List<WorkListModel> dataSource = new List<WorkListModel>();

            foreach (EpisodeFolder.EpisodeFolderWorklistNQL_Class item in archiveDataSource)
            {
                WorkListModel model = new WorkListModel();
                model.BirthDate = item.BirthDate;
                model.Cabinetname = item.Cabinetname;
                model.CurrentStateDefID = item.CurrentStateDefID;
                model.DisplayText = item.DisplayText;
                model.Episode = item.Episode;
                model.EpisodeFolderID = item.EpisodeFolderID;
                model.FatherName = item.FatherName;
                model.FileCreationAndAnalysis = item.FileCreationAndAnalysis;
                model.HospitalDischargeDate = item.ClinicDischargeDate;
                model.HospitalInPatientDate = item.ClinicInpatientDate;
                model.ManuelArchiveNo = item.ManuelArchiveNo;
                model.MotherName = item.MotherName;
                model.Name = item.Name;
                model.ObjectID = item.ObjectID;
                model.PatientFolderID = item.PatientFolderID;
                model.ProcedureDoctor = item.ProcedureDoctor;
                model.ProtocolNo = item.ProtocolNo;
                model.Ptname = item.Ptname;
                model.Row = item.Row;
                model.Shelf = item.Shelf;
                model.ShelfName = item.ShelfName;
                model.UniqueRefNo = item.UniqueRefNo;
                if(item.ShelfName != null)
                {
                    model.Shelf = item.ShelfName;
                }
                dataSource.Add(model);

            }
            viewModel.dataSource = dataSource;
            return viewModel;
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Arsiv_Bolum_islemleri, TTRoleNames.Arsiv_Arsiv_Islemleri, TTRoleNames.Fatura_Islemleri)]

        public FCCAWorkListFormViewModel Archive(WorkListQueryFilter param)
        {
            FCCAWorkListFormViewModel viewModel = new FCCAWorkListFormViewModel();
            IList<Guid> episodeFolderLocationList = new List<Guid>();
            episodeFolderLocationList.Add(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationInvoiceGuid", "e2f883dc-e42c-4728-bf2c-01f301b7080f")));
            episodeFolderLocationList.Add(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationTIGGuid", "bd7396be-17ca-478b-a045-9e7fdae563fa")));
            string filterExpression = "";

            if (!string.IsNullOrEmpty(param.episodeFolderID))
            {
                string manuelArchiveNoControl = TTObjectClasses.SystemParameter.GetParameterValue("MANUELARSIVNUMARASIKULLAN", "FALSE");
                if (manuelArchiveNoControl.Equals("TRUE"))
                {
                    filterExpression += " AND this.ManuelArchiveNo = '" + param.episodeFolderID + "'";
                }
                else
                {
                    filterExpression += " AND this.EpisodeFolderID = '" + param.episodeFolderID + "'";
                }
            }
            else
            {
                if (param.ArchiveStartDate != null)
                    filterExpression += " AND this.FileCreationAndAnalysis.ActionDate > TODATE('" + param.ArchiveStartDate?.Date.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                if (param.ArchiveStartDate != null)
                    filterExpression += " AND this.FileCreationAndAnalysis.ActionDate < TODATE('" + param.ArchiveEndDate?.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + "')";
                if (param.PatientUniqueRefNo != null && param.PatientUniqueRefNo != "")
                    filterExpression += " AND this.MyEpisode.Patient.UniqueRefNo = " + param.PatientUniqueRefNo.Trim();
                if (param.PatientObjectID != Guid.Empty)
                    filterExpression += " AND this.MyEpisode.Patient = '" + param.PatientObjectID.ToString() + "'";
                if (param.ProtocolNo != null && param.ProtocolNo != "")
                    filterExpression += " AND this.LastInPatientTreatment.SubEpisode.ProtocolNo = '" + param.ProtocolNo.Trim() + "'";
                dynamic selectedDiagnosis = null;
                if (!String.IsNullOrEmpty(param.selectedDiagnosisStr))
                    selectedDiagnosis = JsonConvert.DeserializeObject(param.selectedDiagnosisStr);
       
                string whereCriteria_Diagnose = string.Empty;
                if (selectedDiagnosis != null)
                {
                    foreach (var diagnose in selectedDiagnosis)
                    {
                        if (string.IsNullOrEmpty(whereCriteria_Diagnose))
                            whereCriteria_Diagnose = " AND this.MyEpisode.Diagnosis.DiagnosisSubEpisodes.DiagnosisGrid.Diagnose.Code IN (";
                        whereCriteria_Diagnose += "'" + diagnose.Code + "',";
                    }
                    if (!String.IsNullOrEmpty(whereCriteria_Diagnose))
                    {
                        whereCriteria_Diagnose = whereCriteria_Diagnose.Remove(whereCriteria_Diagnose.Length - 1, 1);
                        whereCriteria_Diagnose += ")";
                    }
                    filterExpression += whereCriteria_Diagnose;
                }

            }
            if (!Common.CurrentUser.HasRole(TTRoleNames.Adli_Dosya_Goruntuleme))
            {
                filterExpression += " AND IFNULL(this.FileCreationAndAnalysis.AdliVaka,0) = 0 ";
            }


            List<EpisodeFolder.GetFileCreationAndAnalyse_Class> archiveDataSource = new List<EpisodeFolder.GetFileCreationAndAnalyse_Class>();
        archiveDataSource = EpisodeFolder.GetFileCreationAndAnalyse(FileCreationAndAnalysis.States.Archive, episodeFolderLocationList, filterExpression).ToList();
        List<WorkListModel> dataSource = new List<WorkListModel>();

            foreach (EpisodeFolder.GetFileCreationAndAnalyse_Class item in archiveDataSource)
            {
                WorkListModel model = new WorkListModel();
                model.BirthDate = item.BirthDate;
                model.Cabinetname = item.Cabinetname;
                model.CurrentStateDefID = item.CurrentStateDefID;
                model.DisplayText = item.DisplayText;
                model.Episode = item.Episode;
                model.EpisodeFolderID = item.EpisodeFolderID;
                model.EpisodeFolderLocation = item.EpisodeFolderLocation;
                model.FatherName = item.FatherName;
                model.FileCreationAndAnalysis = item.FileCreationAndAnalysis;
                model.HospitalDischargeDate = item.ClinicDischargeDate;
                model.HospitalInPatientDate = item.ClinicInpatientDate;
                model.ManuelArchiveNo = item.ManuelArchiveNo;
                model.MotherName = item.MotherName;
                model.Name = item.Name;
                model.ObjectID = item.ObjectID;
                model.PatientFolderID = item.PatientFolderID;
                model.ProcedureDoctor = item.ProcedureDoctor;
                model.ProtocolNo = item.ProtocolNo;
                model.Ptname = item.Ptname;
                model.Row = item.Row;
                model.Shelf = item.Shelf;
                model.ShelfName = item.ShelfName;
                model.UniqueRefNo = item.UniqueRefNo;
                if (item.ShelfName != null)
                {
                    model.Shelf = item.ShelfName;
                }
                dataSource.Add(model);
      
            }
            viewModel.archiveDataSource = dataSource;
            return viewModel;
        }
        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Arsiv_Bolum_islemleri, TTRoleNames.Arsiv_Arsiv_Islemleri, TTRoleNames.Fatura_Islemleri)]
        public void transfer(TransferClass param)
        {
            for (int i = 0; i < param.EpisodeFolders.Count; i++)
            {
                TTObjectContext context = new TTObjectContext(false);
                EpisodeFolder episodeFolder = (EpisodeFolder)context.GetObject(new Guid(param.EpisodeFolders[i]), "EpisodeFolder");
                //6C6F9948-5394-4465-8CDB-6C88DE2E5E36 =>Arşivde ???? Analizde ?????

                ResSection oldsectionLocation;
                if (episodeFolder.LastEpisodeFolderTransaction == null)
                    oldsectionLocation = (ResSection)context.GetObject(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationArchiveGuid", "2e4789c1-d71a-4fc1-b9ad-209daf62871d")), "ResSection");
                else
                    oldsectionLocation = episodeFolder.LastEpisodeFolderTransaction.EpisodeFolderLocation;

                ResSection sectionLocation = (ResSection)context.GetObject(param.Location, "ResSection");
                episodeFolder.AddEpisodeFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.SendToDepartment, sectionLocation);
                if (param.Location.ToString() == TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationArchiveGuid", "2e4789c1-d71a-4fc1-b9ad-209daf62871d"))
                {
                    var fileCreationAndAnalysis = new FileCreationAndAnalysis(context, sectionLocation, oldsectionLocation, episodeFolder.LastInPatientTreatment.SubEpisode, episodeFolder);
                }
                context.Save();
            }

        }


        [HttpPost]
        public void CompleteArchiveRequest(List<ArchiveRequestSource> param)
        {
            foreach (ArchiveRequestSource item in param)
            {
                TTObjectContext context = new TTObjectContext(false);
                EpisodeFolder episodeFolder = context.GetObject<EpisodeFolder>((Guid)item.ObjectID);
                FileCreationAndAnalysis file = context.GetObject<FileCreationAndAnalysis>((Guid)item.FileCreationAndAnalysis);
                ArchiveRequest request = context.GetObject<ArchiveRequest>((Guid)item.RequestID);
                //6C6F9948-5394-4465-8CDB-6C88DE2E5E36 =>Arşivde ???? Analizde ?????

                ResSection oldsectionLocation;
                if (episodeFolder.LastEpisodeFolderTransaction == null)
                    oldsectionLocation = (ResSection)context.GetObject(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationArchiveGuid", "2e4789c1-d71a-4fc1-b9ad-209daf62871d")), "ResSection");
                else
                    oldsectionLocation = episodeFolder.LastEpisodeFolderTransaction.EpisodeFolderLocation;

                ResSection sectionLocation = context.GetObject<ResSection>((Guid)item.RequesterSectionID);
                episodeFolder.AddEpisodeFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.SendToDepartment, sectionLocation);
                if (item.RequesterSectionID.ToString() == TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationArchiveGuid", "2e4789c1-d71a-4fc1-b9ad-209daf62871d"))
                {
                    var fileCreationAndAnalysis = new FileCreationAndAnalysis(context, sectionLocation, oldsectionLocation, episodeFolder.LastInPatientTreatment.SubEpisode, episodeFolder);
                }
                file.CurrentStateDefID = FileCreationAndAnalysis.States.Archive;
                request.RequestCompleted = true;

                context.Save();
            }

        }
        [AtlasRequiredRoles(TTRoleNames.Arsiv_Bolum_islemleri, TTRoleNames.Arsiv_Arsiv_Islemleri, TTRoleNames.Fatura_Islemleri)]
        public void Undo(TransferClass param)
        {
            for (int i = 0; i < param.EpisodeFolders.Count; i++)
            {
                // geri al butonunun içi
                TTObjectContext context = new TTObjectContext(false);
                EpisodeFolder episodeFolder = (EpisodeFolder)context.GetObject(new Guid(param.EpisodeFolders[i]), "EpisodeFolder");

                ResSection oldsectionLocation1;
                if (episodeFolder.LastEpisodeFolderTransaction == null)
                    oldsectionLocation1 = (ResSection)context.GetObject(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationArchiveGuid", "2e4789c1-d71a-4fc1-b9ad-209daf62871d")), "ResSection");
                else
                    oldsectionLocation1 = episodeFolder.LastEpisodeFolderTransaction.EpisodeFolderLocation;

                var lastEpisodeFileTransition = episodeFolder.Transactions.Where(dr => dr.EpisodeFolderLocation.ObjectID != oldsectionLocation1.ObjectID).OrderByDescending(dr => dr.TransactionDate).FirstOrDefault();
                if (lastEpisodeFileTransition == null)
                {
                    //Hata
                }
                else
                {
                    episodeFolder.AddEpisodeFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.SendToDepartment, ((EpisodeFolderTransaction)lastEpisodeFileTransition).EpisodeFolderLocation);
                }
                context.Save();
            }
        }

        [HttpPost]
        // [AtlasRequiredRoles(TTRoleNames.Arsiv_Bolum_islemleri, TTRoleNames.Arsiv_Arsiv_Islemleri, TTRoleNames.Fatura_Islemleri)]
        public FCCAWorkListFormViewModel ArchiveRequestQuery(WorkListQueryFilter param)
        {
            FCCAWorkListFormViewModel viewModel = new FCCAWorkListFormViewModel();
            string filterExpression = "";
            List<EpisodeFolder.EpisodeFolderDataForRequest_Class> folderList = new List<EpisodeFolder.EpisodeFolderDataForRequest_Class>();
            List<ArchiveRequestSourceModel> archiveRequestDataSource = new List<ArchiveRequestSourceModel>();
            filterExpression += " WHERE this.FileCreationAndAnalysis IS NOT NULL";

            if (param.PatientUniqueRefNo != null && param.PatientUniqueRefNo != "")
                filterExpression += " AND this.MyEpisode.Patient.UniqueRefNo = " + param.PatientUniqueRefNo.Trim();
            if (param.PatientObjectID != Guid.Empty)
                filterExpression += " AND this.MyEpisode.Patient = '" + param.PatientObjectID.ToString() + "'";
            if (param.ProtocolNo != null && param.ProtocolNo != "")
                filterExpression += " AND this.LastInPatientTreatment.SubEpisode.ProtocolNo = '" + param.ProtocolNo.Trim() + "'";
            if (!Common.CurrentUser.HasRole(TTRoleNames.Adli_Dosya_Goruntuleme))
            {
                filterExpression += " AND IFNULL(this.FileCreationAndAnalysis.AdliVaka,0) = 0 ";
            }
            filterExpression += " AND this.FileCreationAndAnalysis.CURRENTSTATEDEFID <> '98948f30-d50e-4f63-80f2-d64412aef173'";
            filterExpression += " AND this.FileCreationAndAnalysis.CURRENTSTATEDEFID <> '2a894dd3-31e2-4730-b7f1-35333067a156'";

            folderList = EpisodeFolder.EpisodeFolderDataForRequest(filterExpression).ToList();
            foreach (EpisodeFolder.EpisodeFolderDataForRequest_Class item in folderList)
            {
                ArchiveRequestSourceModel model = new ArchiveRequestSourceModel();
                model.BirthDate = item.BirthDate;
                model.DisplayText = item.DisplayText;
                model.CurrentStateDefID = item.CurrentStateDefID;
                model.Episode = item.Episode;
                model.EpisodeFolderID = item.EpisodeFolderID;
                model.FatherName = item.FatherName;
                model.FileCreationAndAnalysis = item.FileCreationAndAnalysis;
                model.FolderLocation = item.Location;
                model.HospitalDischargeDate = item.HospitalDischargeDate;
                model.HospitalInPatientDate = item.HospitalInPatientDate;
                model.ManuelArchiveNo = item.ManuelArchiveNo;
                model.MotherName = item.MotherName;
                model.Name = item.Name;
                model.ObjectID = item.ObjectID;
                model.PatientFolderID = item.PatientFolderID;
                model.ProcedureDoctor = item.ProcedureDoctor;
                model.ProtocolNo = item.ProtocolNo;
                model.Ptname = item.Ptname;
                model.Row = item.Row;
                model.Shelf = item.Shelf;
                model.ProcedureDoctor = item.ProcedureDoctor;
                model.UniqueRefNo = item.UniqueRefNo;
                archiveRequestDataSource.Add(model);
            }
            viewModel.archiveRequestDataSource = archiveRequestDataSource;
            return viewModel;
        }

        public Guid CreateArchiveRequest(Guid episodeFolderId, Guid fileCreationAndAnalysis, string description, Guid requesterSectionId)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                EpisodeFolder ef = objectContext.GetObject<EpisodeFolder>(episodeFolderId);
                FileCreationAndAnalysis fcaa = objectContext.GetObject<FileCreationAndAnalysis>(fileCreationAndAnalysis);
                ArchiveRequest request = new ArchiveRequest(objectContext);
                EpisodeFolderRequest episodeFolderRequest = new EpisodeFolderRequest(objectContext);

                request.ArchiveRequestDate = Common.RecTime();
                request.Requester = Common.CurrentResource;
                request.RequestCompleted = false;
                request.RequesterSection = objectContext.GetObject<ResSection>(requesterSectionId);
                request.ArchiveRequestDescription = description;
                episodeFolderRequest.EpisodeFolder = ef;
                episodeFolderRequest.ArchiveRequest = request;

                fcaa.CurrentStateDefID = FileCreationAndAnalysis.States.Request;
                objectContext.Save();

                return request.ObjectID;
            }


        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Arsiv_Bolum_islemleri, TTRoleNames.Arsiv_Arsiv_Islemleri, TTRoleNames.Fatura_Islemleri)]

        public FCCAWorkListFormViewModel ArchiveRequests()
        {
            FCCAWorkListFormViewModel viewModel = new FCCAWorkListFormViewModel();
            List<ArchiveRequestSource> source = new List<ArchiveRequestSource>();
            List<ArchiveRequest.GetArchiveRequests_Class> requests = ArchiveRequest.GetArchiveRequests("").ToList();
            foreach (ArchiveRequest.GetArchiveRequests_Class item in requests)
            {
                ArchiveRequestSource WLObject = new ArchiveRequestSource();

                WLObject.BirthDate = item.BirthDate;
                WLObject.DisplayText = item.DisplayText;
                WLObject.CurrentStateDefID = item.CurrentStateDefID;
                WLObject.Episode = item.Episode;
                WLObject.EpisodeFolderID = item.EpisodeFolderID;
                WLObject.FatherName = item.FatherName;
                WLObject.FileCreationAndAnalysis = item.FileCreationAndAnalysis;
                WLObject.HospitalDischargeDate = item.HospitalDischargeDate;
                WLObject.HospitalInPatientDate = item.HospitalInPatientDate;
                WLObject.ManuelArchiveNo = item.ManuelArchiveNo;
                WLObject.MotherName = item.MotherName;
                WLObject.Name = item.Name;
                WLObject.ObjectID = item.ObjectID;
                WLObject.PatientFolderID = item.PatientFolderID;
                WLObject.ProcedureDoctor = item.ProcedureDoctor;
                WLObject.ProtocolNo = item.ProtocolNo;
                WLObject.Ptname = item.Ptname;
                WLObject.Row = item.Row;
                WLObject.Shelf = item.Shelf;
                WLObject.ProcedureDoctor = item.ProcedureDoctor;
                WLObject.UniqueRefNo = item.UniqueRefNo;
                WLObject.Description = item.Description;
                WLObject.RequesterName = item.Requester;
                WLObject.RequestDate = item.Date;
                WLObject.Description = item.Description;
                WLObject.RequesterSection = item.Section;
                WLObject.RequesterSectionID = item.Sectionid;
                WLObject.RequestID = item.Requestid;

                source.Add(WLObject);

            }

            viewModel.requestWorkListModel = source;
            return viewModel;
        }

        [HttpPost]
        public List<RequesterSectionModel> GetArchiveRequesterSections()
        {
            TTObjectContext context = new TTObjectContext(false);
            FCCAWorkListFormViewModel viewModel = new FCCAWorkListFormViewModel();
            BindingList<ResSection> resources = ResSection.GetResSections(context, " WHERE ISACTIVE = 1");
            List<RequesterSectionModel> RequesterSection = new List<RequesterSectionModel>();

            foreach (var resource in resources)
            {
                RequesterSectionModel section = new RequesterSectionModel();
                section.RequesterSectionName = resource.Name;
                section.RequesterSectionID = resource.ObjectID;
                RequesterSection.Add(section);
            }
            return RequesterSection;
        }
    }
}

namespace Core.Models
{
    public class FCCAWorkListFormViewModel
    {
      //  public List<EpisodeFolder.EpisodeFolderWorklistNQL_Class> dataSource = new List<EpisodeFolder.EpisodeFolderWorklistNQL_Class>();
       // public List<EpisodeFolder.GetFileCreationAndAnalyse_Class> archiveDataSource = new List<EpisodeFolder.GetFileCreationAndAnalyse_Class>();
        public List<ArchiveRequestSourceModel> archiveRequestDataSource = new List<ArchiveRequestSourceModel>(); //Arsiv istek ekraninda listeleme icin
        public List<ArchiveRequestSource> requestWorkListModel = new List<ArchiveRequestSource>(); //yeri:istek olan arsivleri arsiv is listesi ekraninda listelemek icin
        public List<WorkListModel> dataSource = new List<WorkListModel>();
        public List<WorkListModel> archiveDataSource = new List<WorkListModel>();


        public WorkListQueryFilter QueryModel { get; set; }

        public FCCAWorkListFormViewModel()
        {
            QueryModel = new WorkListQueryFilter();
        }

    }
    public class TransferClass
    {
        public List<string> EpisodeFolders = new List<string>();
        public Guid Location
        {
            get;
            set;
        }

    }
    public class WorkListQueryFilter
    {
        public PatientStatusEnum psEnum
        {
            get;
            set;
        }

        public Guid? FolderLocation
        {
            get;
            set;
        }

        public Guid? Location
        {
            get;
            set;
        }



        public DateTime StartDate
        {
            get;
            set;
        }

        public DateTime EndDate
        {
            get;
            set;
        }
        public DateTime? ArchiveStartDate
        {
            get;
            set;
        }

        public DateTime? ArchiveEndDate
        {
            get;
            set;
        }
        public string ProtocolNo
        {
            get;
            set;
        }
        public string PatientUniqueRefNo
        {
            get;
            set;
        }
        public Guid PatientObjectID
        {
            get;
            set;
        }

        public string selectedDiagnosisStr
        {
            get;
            set;
        }

        public string episodeFolderID
        {
            get;
            set;
        }
    }

    public class ArchiveRequestSourceModel
    {
        public Guid? FileCreationAndAnalysis
        {
            get;
            set;
        }

        public Guid? ObjectID
        {
            get;
            set;
        }

        public string EpisodeFolderID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Guid? ProcedureDoctor
        {
            get;
            set;
        }

        public Object Ptname
        {
            get;
            set;
        }

        public string MotherName
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public DateTime? BirthDate
        {
            get;
            set;
        }

        public long? UniqueRefNo
        {
            get;
            set;
        }

        public string Shelf
        {
            get;
            set;
        }

        public string Row
        {
            get;
            set;
        }

        public long? PatientFolderID
        {
            get;
            set;
        }

        public Guid? Episode
        {
            get;
            set;
        }

        public DateTime? HospitalDischargeDate
        {
            get;
            set;
        }

        public DateTime? HospitalInPatientDate
        {
            get;
            set;
        }
        public string ProtocolNo
        {
            get;
            set;
        }

        public String DisplayText
        {
            get;
            set;
        }

        public Guid? CurrentStateDefID
        {
            get;
            set;
        }

        public string ManuelArchiveNo
        {
            get;
            set;
        }
        public string FolderLocation
        {
            get;
            set;
        }
    }

    public class ArchiveRequestSource
    {
        public Guid? FileCreationAndAnalysis
        {
            get;
            set;
        }

        public Guid? ObjectID
        {
            get;
            set;
        }

        public string EpisodeFolderID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Guid? ProcedureDoctor
        {
            get;
            set;
        }

        public Object Ptname
        {
            get;
            set;
        }

        public string MotherName
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public DateTime? BirthDate
        {
            get;
            set;
        }

        public long? UniqueRefNo
        {
            get;
            set;
        }

        public string Shelf
        {
            get;
            set;
        }

        public string Row
        {
            get;
            set;
        }

        public long? PatientFolderID
        {
            get;
            set;
        }

        public Guid? Episode
        {
            get;
            set;
        }

        public DateTime? HospitalDischargeDate
        {
            get;
            set;
        }

        public DateTime? HospitalInPatientDate
        {
            get;
            set;
        }
        public string ProtocolNo
        {
            get;
            set;
        }

        public String DisplayText
        {
            get;
            set;
        }

        public Guid? CurrentStateDefID
        {
            get;
            set;
        }

        public string ManuelArchiveNo
        {
            get;
            set;
        }
        public string FolderLocation
        {
            get;
            set;
        }

        public string RequesterName
        {
            get;
            set;
        }

        public DateTime? RequestDate
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
        public string RequesterSection
        {
            get;
            set;
        }

        /*  public ArchiveRequestSourceModel RequestWorkListModel
          {
              get;set;
          }*/
        public Guid? RequesterSectionID
        {
            get;
            set;
        }
        public Guid? RequestID
        {
            get;
            set;
        }

    }

    public class RequesterSectionModel
    {
        public string RequesterSectionName
        {
            get;
            set;
        }

        public Guid? RequesterSectionID
        {
            get;
            set;
        }
    }

    public class WorkListModel
    {
        public Guid? FileCreationAndAnalysis
        {
            get;
            set;
        }

        public Guid? ObjectID
        {
            get;
            set;
        }

        public Guid? EpisodeFolderLocation
        {
            get;
            set;
        }

        public string EpisodeFolderID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Guid? ProcedureDoctor
        {
            get;
            set;
        }

        public Object Ptname
        {
            get;
            set;
        }

        public string MotherName
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public DateTime? BirthDate
        {
            get;
            set;
        }

        public long? UniqueRefNo
        {
            get;
            set;
        }

        public DateTime? HospitalDischargeDate
        {
            get;
            set;
        }

        public DateTime? HospitalInPatientDate
        {
            get;
            set;
        }

        public string Shelf
        {
            get;
            set;
        }

        public string Row
        {
            get;
            set;
        }

        public long? PatientFolderID
        {
            get;
            set;
        }

        public Guid? Episode
        {
            get;
            set;
        }

        public string ProtocolNo
        {
            get;
            set;
        }

        public String DisplayText
        {
            get;
            set;
        }

        public Guid? CurrentStateDefID
        {
            get;
            set;
        }

        public string ManuelArchiveNo
        {
            get;
            set;
        }

        public string Cabinetname
        {
            get;
            set;
        }

        public string ShelfName
        {
            get;
            set;

        }
    }
}
