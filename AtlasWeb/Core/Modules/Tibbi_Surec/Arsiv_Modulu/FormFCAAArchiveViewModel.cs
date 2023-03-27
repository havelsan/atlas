//$01DA68EC
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Core.Security;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class FileCreationAndAnalysisServiceController
    {

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Arsiv_Bolum_islemleri, TTRoleNames.Arsiv_Arsiv_Islemleri, TTRoleNames.Fatura_Islemleri)]
        public Guid? FormFCAAObjectIDFromEpisode(Guid? id)
        {
            if (id.HasValue)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    var query = objectContext.QueryObjects<FileCreationAndAnalysis>($"EPISODE = '{id.Value.ToString()}'");
                    var objectFCAA = query.FirstOrDefault();
                    if (objectFCAA != null)
                        return objectFCAA.ObjectID;
                }
            }

            return null;
        }

        partial void PostScript_FormFCAAArchive(FormFCAAArchiveViewModel viewModel, FileCreationAndAnalysis fileCreationAndAnalysis, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            // StarterEpisdoeFolder child olduðu için Convertionla yüklenemiyor  ViewModel üzerinden yüklenip yollanýyor ve Contexte extra set ediliyor
            objectContext.AddToRawObjectList(viewModel.StarterEpisodeFolder);
            objectContext.AddToRawObjectList(viewModel.FolderContentsGridList);
            objectContext.ProcessRawObjects(false);

            var episodeFolderImported = (EpisodeFolder)objectContext.GetLoadedObject(viewModel.StarterEpisodeFolder.ObjectID); 
            if (episodeFolderImported != null)
            {
                if (viewModel.FolderContentsGridList != null)
                {
                    foreach (var item in viewModel.FolderContentsGridList)
                    {
                        var folderContentsImported = (EpisodeFolderContent)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)folderContentsImported).IsDeleted)
                            continue;
                        folderContentsImported.EpisodeFolder = episodeFolderImported;
                    }
                }
            }

            if (transDef != null)
            {
                ResSection selectedLocation = null;
                // Eðer seçilen step Arþivse ve bütün cilt içerikleri tamsa, dosya arþive gönderilir. Eðer ciltlerden herhangibirinde eksik belde varsa, o zaman dosya arþive gönderilemez hatasý alýnýr. 
                if (transDef.ToStateDefID.Equals(FileCreationAndAnalysis.States.Archive))
                {

                    selectedLocation = (ResSection)objectContext.GetObject(new Guid(TTObjectClasses.SystemParameter.GetParameterValue("EpisodeFolderLocationArchiveGuid", "2e4789c1-d71a-4fc1-b9ad-209daf62871d")), "ResSection"); //6C6F9948-5394-4465-8CDB-6C88DE2E5E36 => Arþivde

                        foreach (var content in episodeFolderImported.FolderContents)
                        {
                            if (content.FolderContentStatus.HasValue && content.FolderContentStatus == EpisodeFolderContentStatusEnum.InComplete) // burda bi saçmalýk var ama Çaðdaþ sonra mantýk deðiþcek zaten dedi
                                throw new Exception(SystemMessage.GetMessage(930));
                        }
                }
                else if (transDef.ToStateDefID.Equals(FileCreationAndAnalysis.States.Incomplete))
                {
                    selectedLocation = (ResSection)objectContext.GetObject(new Guid("91129D5E-54EA-4345-82C9-7DD0718EBBB9"), "ResSection"); // 91129D5E-54EA-4345-82C9-7DD0718EBBB9 => Eksik Dosyalarda

                }
                fileCreationAndAnalysis.Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, selectedLocation);
                fileCreationAndAnalysis.FileLocation = selectedLocation;

                //fileCreationAndAnalysis.Episode.EpisodeFolder.EpisodeFolderSequenceNo.GetNextValue();

                string archiveNoControl = TTObjectClasses.SystemParameter.GetParameterValue("MANUELARSIVNUMARASIKULLAN", "FALSE");

                   List<EpisodeFolder.GetEpisodeFolderIDByPatientID_Class> patientFolderList = EpisodeFolder.GetEpisodeFolderIDByPatientID(fileCreationAndAnalysis.Episode.Patient.ObjectID.ToString()).ToList();

                    long archiveNo = 0;
                    string archiveNoStr = "";
                    int archiveNoLength = 0;

                    if (patientFolderList != null && patientFolderList.Count == 0)
                    {
                        archiveNo = TTSequence.GetNextSequenceValueFromDatabase(TTDefinitionManagement.TTObjectDefManager.Instance.DataTypes["ARCHIEVENOSEQUENCE"], null, 0);
                        archiveNoLength = archiveNo.ToString().Length;
                        for (int i = 0; i < 8 - archiveNoLength; i++)
                        {
                            archiveNoStr = archiveNoStr + "0";
                        }
                        archiveNoStr = archiveNoStr + archiveNo.ToString() + "-" + (patientFolderList.Count + 1).ToString();


                    }
                    else if (patientFolderList != null && patientFolderList.Count > 0)
                        archiveNoStr = patientFolderList[0].Folderid.ToString().Split('-')[0] + "-" + (patientFolderList.Count + 1).ToString();


                if(archiveNoControl.Equals("TRUE"))
                {
                    List<EpisodeFolder.GetManuelArchiveNo_Class> archiveNumber = EpisodeFolder.GetManuelArchiveNo("AND THIS.ManuelArchiveNo = '"+ episodeFolderImported.ManuelArchiveNo+"'" + " OR THIS.ManuelArchiveNo LIKE '" + episodeFolderImported.ManuelArchiveNo + "-%' ").ToList();
                    string ManuelArchiveNo = "";

                    if (archiveNumber != null && archiveNumber.Count > 0)
                    {
                        if(archiveNumber.Count == 1 && archiveNumber[0].CurrentStateDefID != FileCreationAndAnalysis.States.Archive)
                        {
                            ManuelArchiveNo = episodeFolderImported.ManuelArchiveNo;
                        }
                        else if (archiveNumber[0].UniqueRefNo == fileCreationAndAnalysis.Episode.Patient.UniqueRefNo)
                        {
                            ManuelArchiveNo = archiveNumber[0].ManuelArchiveNo.ToString().Split('-')[0] + "-" + (archiveNumber.Count);
                        }

                        else
                        {
                            throw new Exception("Girilen arþiv numarasý baþka bir hastaya aittir.");
                        }
                    }

                    else
                        ManuelArchiveNo = episodeFolderImported.ManuelArchiveNo;

                    episodeFolderImported.ManuelArchiveNo = ManuelArchiveNo;
                }
                episodeFolderImported.EpisodeFolderID = archiveNoStr;

            }
        }
        partial void PreScript_FormFCAAArchive(FormFCAAArchiveViewModel viewModel, FileCreationAndAnalysis fileCreationAndAnalysis, TTObjectContext objectContext)
        {
            if(fileCreationAndAnalysis.StarterEpisodeFolder.Count>0)
            {
                List<PatientFolderContentDefinition> _PatientFolderContentDefinitionList = new List<PatientFolderContentDefinition>();
                viewModel.StarterEpisodeFolder = fileCreationAndAnalysis.StarterEpisodeFolder[0];
                viewModel.FolderContentsGridList = viewModel.StarterEpisodeFolder.FolderContents.ToArray();
                foreach (var folderContenst in viewModel.StarterEpisodeFolder.FolderContents)
                {
                    if (folderContenst.File != null)
                        _PatientFolderContentDefinitionList.Add(folderContenst.File);
                 }
                viewModel.PatientFolderContentDefinitions = _PatientFolderContentDefinitionList.ToArray();
            }

            if((fileCreationAndAnalysis.Episode.Patient.PatientFolder.Shelf != null || fileCreationAndAnalysis.Room != null) && fileCreationAndAnalysis.CurrentStateDefID != FileCreationAndAnalysis.States.NewRecord) {
                viewModel.isOldData = true;
            }

            //contexte ekledi.
            var a = fileCreationAndAnalysis.Episode?.Patient?.PatientFolder?.ResCabinet;
            var b = fileCreationAndAnalysis.Episode?.Patient?.PatientFolder?.ResShelf;
            var c = fileCreationAndAnalysis.ResArchiveRoom;

            ContextToViewModel(viewModel, objectContext);
        }

    }
}

namespace Core.Models
{
    public partial class FormFCAAArchiveViewModel
    {
        public EpisodeFolder StarterEpisodeFolder { get; set; }

        public TTObjectClasses.EpisodeFolderContent[] FolderContentsGridList { get; set; }
        public TTObjectClasses.PatientFolderContentDefinition[] PatientFolderContentDefinitions { get; set; }
        public bool isOldData { get; set; }

    }
}
