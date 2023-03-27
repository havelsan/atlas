
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
using Newtonsoft.Json;




using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Dosya Oluşturma ve Analiz (Arşiv Oluşturma) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class FileCreationAndAnalysis : EpisodeAction, IWorkListEpisodeAction
    {


        public FileCreationAndAnalysis(TTObjectContext objectContext, ResSection masterResource, ResSection fromResource, SubEpisode subepisode,EpisodeFolder episodeFolder) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = masterResource;
            FromResource = fromResource;
            CurrentStateDefID = FileCreationAndAnalysis.States.NewRecord;
            Episode = subepisode.Episode;
            SubEpisode = subepisode;
            //this.SelectedEpisode = this.Episode;
            episodeFolder.FileCreationAndAnalysis = this;
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FileCreationAndAnalysis).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FileCreationAndAnalysis.States.NewRecord && toState == FileCreationAndAnalysis.States.Archive)
                PostTransition_NewRecord2Archive();
        }

        private void NotifyIncompleteArchive()
        {
            EpisodeAction ea = SubEpisode.EpisodeActions.Where(action => action is InPatientTreatmentClinicApplication && action.CurrentStateDefID != InPatientTreatmentClinicApplication.States.Cancelled).FirstOrDefault();
            ResUser ProcedureDoctor = ea.ProcedureDoctor;
            ResUser Nurse = ((InPatientTreatmentClinicApplication)ea).ResponsibleNurse;
            List<string> userList = new List<string>();

            List<ArchiveDeliveryForm> forms = ArchiveDeliveryForm.GetArchiveDeliveryFormBySubepisodeID(ObjectContext, SubEpisode.ObjectID).ToList();
            foreach (ArchiveDeliveryForm item in forms)
            {
                userList.Add(item.Deliverer.ObjectID.ToString());
            }

            if (forms.Count == 0)
            {

                if (ProcedureDoctor != null)
                {
                    userList.Add(ProcedureDoctor.ObjectID.ToString());
                }
                if (Nurse != null)
                {
                    userList.Add(Nurse.ObjectID.ToString());
                }
            }
            string messageText = "";
            EpisodeFolder ef = ((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission.EpisodeFolder;
            if (userList.Count > 0)
            {
                messageText += ("Sayın Yetkili, ");
                messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";
                messageText += "arşive gönderilen ";
                if (ef.ManuelArchiveNo != null)
                {
                    messageText += "'" + ef.ManuelArchiveNo+ "'";
                }
                else if (ef.EpisodeFolderID != null)
                {
                    messageText += "'" + ef.EpisodeFolderID + "'";
                }
                messageText += " numaralı arşiv dosyasında ";

                if (HKANESTEZI == true || HKCERTARONFORM == true || HKDIGER == true || HKDUSRISOL == true || HKEPIKRIZ == true || HKGUCCERKONT == true || HKGUNMUSKAG == true || HKHASTTAB == true
                    || HKMESANFORM == true || HKONAM == true || HKSAGKURRAP == true || HKTABHASTBIL == true)
                {
                    messageText += " Hekim Kaynaklı; ";

                    if (HKANESTEZI == true)
                    {
                        messageText += "Anestezi Formları, ";
                    }
                    if (HKCERTARONFORM == true)
                    {
                        messageText += "Cerrahi Taraf Onam Formu, ";
                    }
                    if (HKDUSRISOL == true)
                    {
                        messageText += "Düşme Riski Ölçeği, ";
                    }
                    if (HKEPIKRIZ == true)
                    {
                        messageText += "Epikriz, ";
                    }
                    if (HKGUCCERKONT == true)
                    {
                        messageText += "Güvenli Cerrahi Kontrol Listesi, ";
                    }
                    if (HKGUNMUSKAG == true)
                    {
                        messageText += "Günlük Müşahede ve Müdahele Kağıdı, ";
                    }
                    if (HKHASTTAB == true)
                    {
                        messageText += "Hasta Tabelası, ";
                    }
                    if (HKMESANFORM == true)
                    {
                        messageText += "Meslek Anamnez Formu, ";
                    }
                    if (HKONAM == true)
                    {
                        messageText += "Onam Formları, ";
                    }
                    if (HKSAGKURRAP == true)
                    {
                        messageText += "Sağlık Kurulu Raporu, ";
                    }
                    if (HKTABHASTBIL == true)
                    {
                        messageText += "Taburcu Olan Hastaları Bilgilendirme Formu, ";
                    }
                    if (HKDIGER == true)
                    {
                        messageText += "Diğer, ";
                    }

                    messageText = messageText.Remove(messageText.LastIndexOf(", "));
                }

                if(HMDIGER == true || HMHASTAYAKINI == true || HMHASTYAKFORM == true || HMHEMGOZFORM == true || HMHEMSBAKPL == true || HMHEMSHIZ == true || HMSIVIZFORM == true)
                {
                    messageText += " Hemşire Kaynaklı; ";

                    if (HMHASTAYAKINI == true)
                    {
                        messageText += "Hasta ve Yakınının Bölüm Uyum Eğitimi, ";
                    }
                    if (HMHASTYAKFORM == true)
                    {
                        messageText += "Hasta ve Hasta Yakını Bilgilendirme Formu, ";
                    }
                    if (HMHEMGOZFORM == true)
                    {
                        messageText += "Hemşire Gözlem Formu, ";
                    }
                    if (HMHEMSBAKPL == true)
                    {
                        messageText += "Hemşirelik Bakım Planı, ";
                    }
                    if (HMHEMSHIZ == true)
                    {
                        messageText += "Hemşirelik Hizmetleri Eğitim Formu, ";
                    }
                    if (HMSIVIZFORM == true)
                    {
                        messageText += "Sıvı İzlem Formu, ";
                    }
                    if (HMDIGER == true)
                    {
                        messageText += "Diğer, ";
                    }

                    messageText = messageText.Remove(messageText.LastIndexOf(", "));

                }

                if (SEKHASGIRKAG == true)
                {
                    messageText += " Sekreter Kaynaklı; Hasta Girişi Kağıdı";

                }

                messageText += " belgeleri eksiktir.";

                TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                atlasNotification.users = userList;
                atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                atlasNotification.contentType = TTUtils.AtlasContentType.Notification;

                atlasNotification.content = messageText;
                string notificationStr = JsonConvert.SerializeObject(atlasNotification);
                try
                {
                    TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);

                }
                catch (Exception)
                {

                }
            }
        }


        protected void PostTransition_NewRecord2Archive()
        {
            // From State : NewRecord   To State : Archive
            #region PostTransition_NewRecord2Archive

            PatientFolder pFolder = Episode.Patient.PatientFolder;
            if (pFolder != null)
            {


                //6C6F9948-5394-4465-8CDB-6C88DE2E5E36 =>Arşivde ???? Analizde ?????
                //   ResSection sectionLocation = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"), "ResSection");
                //    pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, sectionLocation);
            }


            if (HKANESTEZI == true || HKCERTARONFORM == true || HKDIGER == true
                || HKDUSRISOL == true || HKEPIKRIZ == true || HKGUCCERKONT == true
                || HKGUNMUSKAG == true || HKHASTTAB == true
                || HKMESANFORM == true || HKONAM == true || HKSAGKURRAP == true
                || HKTABHASTBIL == true || HMDIGER == true || HMHASTAYAKINI == true
                || HMHASTYAKFORM == true || HMHEMGOZFORM == true || HMHEMSBAKPL == true || HMHEMSHIZ == true || HMSIVIZFORM == true || SEKHASGIRKAG == true)
            {
                NotifyIncompleteArchive();
            }

            #endregion PostTransition_NewRecord2Archive
        }
        public void PrepareNewFileCreation()
        {
            if (string.IsNullOrEmpty(OnlyYear))
                OnlyYear = Common.RecTime().Date.Year.ToString();
        }
        protected void UndoTransition_NewRecord2Archive(TTObjectStateTransitionDef transitionDef)
        {
            // From State : NewRecord   To State : Archive
            #region UndoTransition_NewRecord2Archive

            ResSection selectedLocation = null;
            Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, selectedLocation);

            #endregion UndoTransition_NewRecord2Archive
        }

        protected void PostTransition_NewRecord2PatientFileAnalysis()
        {
            // From State : NewRecord   To State : PatientFileAnalysis
            #region PostTransition_NewRecord2PatientFileAnalysis

            PatientFolder pFolder = Episode.Patient.PatientFolder;
            if (pFolder != null)
            {
                //43ACA6E1-931D-443D-B846-8829B752CF46 => Analizde
                ResSection sectionLocation = (ResSection)ObjectContext.GetObject(new Guid("43ACA6E1-931D-443D-B846-8829B752CF46"), "ResSection");
                pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.FileCreated, sectionLocation);
            }
            #endregion PostTransition_NewRecord2PatientFileAnalysis
        }

        protected void UndoTransition_NewRecord2PatientFileAnalysis(TTObjectStateTransitionDef transitionDef)
        {
            // From State : NewRecord   To State : PatientFileAnalysis
            #region UndoTransition_NewRecord2PatientFileAnalysis

            ResSection selectedLocation = null;
            Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, selectedLocation);


            #endregion UndoTransition_NewRecord2PatientFileAnalysis
        }

        protected void UndoTransition_PatientFileAnalysis2Incomplete(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PatientFileAnalysis   To State : Incomplete
            #region UndoTransition_PatientFileAnalysis2Incomplete

            ResSection selectedLocation = null;
            selectedLocation = (ResSection)ObjectContext.GetObject(new Guid("43ACA6E1-931D-443D-B846-8829B752CF46"), "ResSection"); // 43ACA6E1-931D-443D-B846-8829B752CF46  => Analizde
            Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, selectedLocation);

            #endregion UndoTransition_PatientFileAnalysis2Incomplete
        }

        protected void UndoTransition_PatientFileAnalysis2Archive(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PatientFileAnalysis   To State : Archive
            #region UndoTransition_PatientFileAnalysis2Archive

            ResSection selectedLocation = null;
            selectedLocation = (ResSection)ObjectContext.GetObject(new Guid("43ACA6E1-931D-443D-B846-8829B752CF46"), "ResSection"); // 43ACA6E1-931D-443D-B846-8829B752CF46  => Analizde
            Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, selectedLocation);

            #endregion UndoTransition_PatientFileAnalysis2Archive
        }

        protected void PostTransition_PatientFileAnalysis2Cancelled()
        {
            // From State : PatientFileAnalysis   To State : Cancelled
            #region PostTransition_PatientFileAnalysis2Cancelled


            ResSection selectedLocation = null;
            Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, selectedLocation);

            foreach(var starterEpisodeFolder in StarterEpisodeFolder)
            {
                //Episode folder içindeki episodeları  boşaltıyoruz.
                starterEpisodeFolder.FolderContents.Clear();

                starterEpisodeFolder.PatientFolder.Shelf = "";
                RequestDate = Common.RecTime();
                //this.Episode.Patient.PatientFolder.PatientFolderID =0 ;
                starterEpisodeFolder.EpisodeFolderID = "0";
                starterEpisodeFolder.PatientFolder.Row = "";
                OnlyYear = "";
                starterEpisodeFolder.FolderInformation = "";
            }






            #endregion PostTransition_PatientFileAnalysis2Cancelled
        }

        protected void UndoTransition_PatientFileAnalysis2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : PatientFileAnalysis   To State : Cancelled
            #region UndoTransition_PatientFileAnalysis2Cancelled


            throw new Exception(SystemMessage.GetMessage(929));

            #endregion UndoTransition_PatientFileAnalysis2Cancelled
        }

        #region Methods
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList;
            if (base.OldActionPropertyList() == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            else
                propertyList = base.OldActionPropertyList();
            //-------------------------------------

            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25533", "Dosyanın Yeri"), Common.ReturnObjectAsString(FileLocation)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16650", "İstek Tarihi"), Common.ReturnObjectAsString(RequestDate)));
            //propertyList.Add(new OldActionPropertyObject(TTUtils.CultureService.GetText("M12254", "Cilt Numarası"), Common.ReturnObjectAsString(SelectedEpisode.EpisodeFolder.EpisodeFolderID)));
            //propertyList.Add(new OldActionPropertyObject(TTUtils.CultureService.GetText("M20708", "Raf"), Common.ReturnObjectAsString(SelectedEpisode.Patient.PatientFolder.Shelf)));
            //propertyList.Add(new OldActionPropertyObject("Sıra", Common.ReturnObjectAsString(SelectedEpisode.Patient.PatientFolder.Row)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M24661", "Yıl"), Common.ReturnObjectAsString(OnlyYear)));

            //---------------------------------------
            return propertyList;

        }

        protected override List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<EpisodeAction.OldActionPropertyObject>>> gridList;
            if (base.OldActionChildRelationList() == null)
                gridList = new List<List<List<EpisodeAction.OldActionPropertyObject>>>();
            else
                gridList = base.OldActionChildRelationList();

            List<List<EpisodeAction.OldActionPropertyObject>> gridFolderContentsRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();

            //foreach (EpisodeFolderContent folderContent in SelectedEpisode.EpisodeFolder.FolderContents)
            //{
            //    List<OldActionPropertyObject> gridFolderContentsRowColumnList = new List<OldActionPropertyObject>();
            //    gridFolderContentsRowColumnList.Add(new OldActionPropertyObject(TTUtils.CultureService.GetText("M26017", "İçerik"), Common.ReturnObjectAsString(folderContent.File.FileName)));
            //    gridFolderContentsRowColumnList.Add(new OldActionPropertyObject("Durum", Common.ReturnObjectAsString(folderContent.FolderContentStatus)));
            //    gridFolderContentsRowColumnList.Add(new OldActionPropertyObject(TTUtils.CultureService.GetText("M12254", "Cilt Numarası"), Common.ReturnObjectAsString(folderContent.EpisodeFolder.EpisodeFolderID)));
            //    gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
            //}
            gridList.Add(gridFolderContentsRowList);
            return gridList;
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.FileCreationAndAnalysis;
            }
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            ITTObject ttObject = (ITTObject)this;

            if (ttObject.IsNew)
            {

                //Hastanın patientFolder ı yoksa oluşturulur.
                if (subEpisode.Episode.Patient.PatientFolder == null)
                {
                    subEpisode.Episode.Patient.PatientFolder = (PatientFolder)ObjectContext.CreateObject("PatientFolder");
                }
                //Hastanın yatansa ve episodeFolder ı yoksa oluşturulur. Şimdilik ayaktan için Episode folder yok zaten

                if (subEpisode.InpatientAdmission != null && subEpisode.InpatientAdmission.EpisodeFolder == null)
                {
                    subEpisode.InpatientAdmission.EpisodeFolder = (EpisodeFolder)ObjectContext.CreateObject("EpisodeFolder");
                    subEpisode.Episode.Patient.PatientFolder.EpisodeFolders.Add(subEpisode.InpatientAdmission.EpisodeFolder);

                }
            }
        }

        #endregion Methods

        //protected void PostTransition(TTObjectStateTransitionDef transDef)
        //{

        //TODO: Arsıv aktarımı ıcın commetnlendı sonra acılacak

        //    // Eğer hiç cilt içeriği girilmemişse hata mesajı alınır.

        //    if (Episode.EpisodeFolder.FolderContents.Count < 1)
        //    {
        //        throw new TTException((SystemMessage.GetMessage(933)));
        //    }
        //    //Cilt içerileri arasında mükerrer belge olup olmadığına bakar. Varsa hata mesajı verir.
        //    foreach (var fcMain in Episode.EpisodeFolder.FolderContents)
        //    {
        //        int count = 0;
        //        foreach (var fc in Episode.EpisodeFolder.FolderContents)
        //        {
        //            if (fcMain.File.ObjectID.ToString() == fc.File.ObjectID.ToString())
        //            {
        //                count++;
        //                if (count > 1)
        //                    throw new Exception((SystemMessage.GetMessage(934)));
        //            }
        //        }
        //    }
        //    if (transDef != null)
        //    {
        //        ResSection selectedLocation = null;
        //        // Eğer seçilen step Arşivse ve bütün cilt içerikleri tamsa, dosya arşive gönderilir. Eğer ciltlerden herhangibirinde eksik belde varsa, o zaman dosya arşive gönderilemez hatası alınır.
        //        if (transDef.ToStateDefID.Equals(FileCreationAndAnalysis.States.Archive))
        //        {
        //            selectedLocation = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"), "ResSection"); //6C6F9948-5394-4465-8CDB-6C88DE2E5E36 => Arşivde
        //            foreach (var content in SelectedEpisode.EpisodeFolder.FolderContents)
        //            {
        //                if (content.FolderContentStatus.Value == EpisodeFolderContentStatusEnum.InComplete)
        //                    throw new Exception((SystemMessage.GetMessage(930)));
        //            }
        //            if (string.IsNullOrEmpty(Episode.Patient.PatientFolder.Shelf) || string.IsNullOrEmpty(Episode.Patient.PatientFolder.Row))
        //                throw new TTException(SystemMessage.GetMessage(931));
        //        }

        //        // this._FileCreationAndAnalysis.Episode.Patient.PatientFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Analysed, selectedLocation);
        //        this.FileLocation = selectedLocation;
        //    }






        //    if (transDef.ObjectDef.CodeName != typeof(FileCreationAndAnalysis).Name)
        //        return;

        //    var fromState = transDef.FromStateDefID;
        //    var toState = transDef.ToStateDefID;

        //    if (fromState == States.NewRecord && toState == States.Archive)
        //        PostTransition_NewRecord2Archive();
        //}

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FileCreationAndAnalysis).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FileCreationAndAnalysis.States.NewRecord && toState == FileCreationAndAnalysis.States.Archive)
                UndoTransition_NewRecord2Archive(transDef);

        }

    }
}