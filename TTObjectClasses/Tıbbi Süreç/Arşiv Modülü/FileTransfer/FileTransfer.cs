
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
    /// <summary>
    /// Dosya Transfer (Arşiv Karşılama) İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class FileTransfer : EpisodeAction, IWorkListEpisodeAction
    {
        protected void PostTransition_FullfilmentFromMR2Cancelled()
        {
            // From State : FullfilmentFromMR   To State : Cancelled
#region PostTransition_FullfilmentFromMR2Cancelled
            
            PatientFolderTransaction currentTR = Episode.Patient.PatientFolder.LastPatientFolderTransaction;
            int i= 0; 
            foreach(FileTransferRequestersInQueueGrid reqQueue in Episode.Patient.FTRequestersInQueue )
            {
                if(reqQueue.CurrentStateDefID.Equals(FileTransferRequestersInQueueGrid.States.Request)){
                    reqQueue.CurrentStateDefID= FileTransferRequestersInQueueGrid.States.Cancelled;
                    reqQueue.SendDepartment= false; // cancelled istekler hide olmasına rağmen bir sonraki istekte, collectionda görülürler.Cancelled bir isteğin SendDept'ı checkli olursa, departmana yollamaya çalışıyor. Hatalı oluyor. Bu nedenle  senddeptların undo olması gerek.
                    reqQueue.NoInQueue= 0; 
                }
                else if(reqQueue.CurrentStateDefID.Equals(FileTransferRequestersInQueueGrid.States.Fullfilled)){
                    i++;
                    reqQueue.NoInQueue = i;
                }
            }
            PatientFolder pFolder = Episode.Patient.PatientFolder;
            pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Cancelled, (ResSection)currentTR.FolderLocation);

#endregion PostTransition_FullfilmentFromMR2Cancelled
        }

        protected void UndoTransition_FullfilmentFromMR2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FullfilmentFromMR   To State : Cancelled
#region UndoTransition_FullfilmentFromMR2Cancelled
            
            
            NoBackStateBack();

#endregion UndoTransition_FullfilmentFromMR2Cancelled
        }

        protected void PostTransition_FullfilmentFromMR2MissingFile()
        {
            // From State : FullfilmentFromMR   To State : MissingFile
#region PostTransition_FullfilmentFromMR2MissingFile
            

            ResSection missingFile = (ResSection)ObjectContext.GetObject(new Guid("343dc2a3-f698-4519-b98c-5e0b702876b3"),"ResSection");
            PatientFolder pFolder = Episode.Patient.PatientFolder;
            pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Missing ,missingFile);
            FileLocation = missingFile;
            foreach(FileTransferRequestersInQueueGrid theInqueueGrid in Episode.Patient.FTRequestersInQueue)
            {
                theInqueueGrid.SendDepartment = false;
            }

#endregion PostTransition_FullfilmentFromMR2MissingFile
        }

        protected void UndoTransition_FullfilmentFromMR2MissingFile(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FullfilmentFromMR   To State : MissingFile
#region UndoTransition_FullfilmentFromMR2MissingFile
            
            
            NoBackStateBack();

#endregion UndoTransition_FullfilmentFromMR2MissingFile
        }

        protected void PostTransition_FullfilmentFromMR2AcknowledgementReceipt()
        {
            // From State : FullfilmentFromMR   To State : AcknowledgementReceipt
#region PostTransition_FullfilmentFromMR2AcknowledgementReceipt
            
            // Fullfillment FormPostta

#endregion PostTransition_FullfilmentFromMR2AcknowledgementReceipt
        }

        protected void UndoTransition_FullfilmentFromMR2AcknowledgementReceipt(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FullfilmentFromMR   To State : AcknowledgementReceipt
#region UndoTransition_FullfilmentFromMR2AcknowledgementReceipt
            
            
            NoBackStateBack();

#endregion UndoTransition_FullfilmentFromMR2AcknowledgementReceipt
        }

        protected void PostTransition_AcknowledgementReceipt2FileIsMissing()
        {
            // From State : AcknowledgementReceipt   To State : FileIsMissing
#region PostTransition_AcknowledgementReceipt2FileIsMissing
            
            PatientFolder pFolder = Episode.Patient.PatientFolder;
            pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.PreMissing ,null);
            foreach(FileTransferRequestersInQueueGrid theInqueueGrid in Episode.Patient.FTRequestersInQueue)
            {
                theInqueueGrid.SendDepartment = false;
            }

#endregion PostTransition_AcknowledgementReceipt2FileIsMissing
        }

        protected void UndoTransition_AcknowledgementReceipt2FileIsMissing(TTObjectStateTransitionDef transitionDef)
        {
            // From State : AcknowledgementReceipt   To State : FileIsMissing
#region UndoTransition_AcknowledgementReceipt2FileIsMissing
            
            NoBackStateBack();

#endregion UndoTransition_AcknowledgementReceipt2FileIsMissing
        }

        protected void PostTransition_AcknowledgementReceipt2SendChart()
        {
            // From State : AcknowledgementReceipt   To State : SendChart
#region PostTransition_AcknowledgementReceipt2SendChart
            
            
            FileTransferRequestersInQueueGrid theGrid = null;
            bool checkedSendDeptFound= false;
            
            // İstekliler arasında SendDept checkli olan varsa, onun fullfilled'ı da true yapılır, ilgili bilgieri gridden forma atılır. Satırın current state i karşılandı yapılır. Transition atılır. 
            
            foreach(FileTransferRequestersInQueueGrid reqQueue in Episode.Patient.FTRequestersInQueue)
            {
                if(reqQueue.SendDepartment == true && reqQueue.Fullfilled == false  && !reqQueue.CurrentStateDefID.Equals(FileTransferRequestersInQueueGrid.States.Cancelled))
                {
                    checkedSendDeptFound= true;
                    theGrid= reqQueue;
                    break;
                }
            }
            if(checkedSendDeptFound){
                FileLocation = theGrid.RequesterUnit;
                MasterResource = (ResSection)theGrid.RequesterUnit;
                theGrid.Fullfilled= true;
                theGrid.SendDepartment = false; 
                theGrid.CurrentStateDefID = FileTransferRequestersInQueueGrid.States.Fullfilled;
                PatientFolder pFolder = Episode.Patient.PatientFolder;
                pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.AcknowledgedByDepartment,MasterResource);
            }
#endregion PostTransition_AcknowledgementReceipt2SendChart
        }

        protected void UndoTransition_AcknowledgementReceipt2SendChart(TTObjectStateTransitionDef transitionDef)
        {
            // From State : AcknowledgementReceipt   To State : SendChart
#region UndoTransition_AcknowledgementReceipt2SendChart
            
            NoBackStateBack();

#endregion UndoTransition_AcknowledgementReceipt2SendChart
        }

        protected void PostTransition_FileAcceptanceByMR2AcknowledgementReceipt()
        {
            // From State : FileAcceptanceByMR   To State : AcknowledgementReceipt
#region PostTransition_FileAcceptanceByMR2AcknowledgementReceipt
            
            // Fullfillment FormPostta.


#endregion PostTransition_FileAcceptanceByMR2AcknowledgementReceipt
        }

        protected void UndoTransition_FileAcceptanceByMR2AcknowledgementReceipt(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FileAcceptanceByMR   To State : AcknowledgementReceipt
#region UndoTransition_FileAcceptanceByMR2AcknowledgementReceipt
            
            
            NoBackStateBack();
            

#endregion UndoTransition_FileAcceptanceByMR2AcknowledgementReceipt
        }

        protected void PostTransition_FileAcceptanceByMR2Accept()
        {
            // From State : FileAcceptanceByMR   To State : Accept
#region PostTransition_FileAcceptanceByMR2Accept
            
            ResSection archive = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection"); // MR= ARŞİV : ESKİSİ: 90F73FF4-47E5-4547-95A6-D90BA6C1534A
            FileLocation= archive;
            PatientFolder pFolder = Episode.Patient.PatientFolder;
            pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.AcknowledgedByMR,archive);
            foreach(FileTransferRequestersInQueueGrid theInqueueGrid in Episode.Patient.FTRequestersInQueue)
            {
                theInqueueGrid.SendDepartment = false;
            }

#endregion PostTransition_FileAcceptanceByMR2Accept
        }

        protected void UndoTransition_FileAcceptanceByMR2Accept(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FileAcceptanceByMR   To State : Accept
#region UndoTransition_FileAcceptanceByMR2Accept
            
            
            NoBackStateBack();

#endregion UndoTransition_FileAcceptanceByMR2Accept
        }

        protected void PostTransition_FileAcceptanceByMR2MissingFile()
        {
            // From State : FileAcceptanceByMR   To State : MissingFile
#region PostTransition_FileAcceptanceByMR2MissingFile
            
            
            // missing(yeni:)  343dc2a3-f698-4519-b98c-5e0b702876b3
            // arşiv(yeni:) 6C6F9948-5394-4465-8CDB-6C88DE2E5E36
            // eksik dosyalarda (yeni:) 91129d5e-54ea-4345-82c9-7dd0718ebbb9
            // analizde(yeni:) 43aca6e1-931d-443d-b846-8829b752cf46
            // yolda(yeni:) 107A9C49-DFAE-4896-928F-810DD9FF03E0
            ResSection missingFile = (ResSection)ObjectContext.GetObject(new Guid("343dc2a3-f698-4519-b98c-5e0b702876b3"),"ResSection");
            PatientFolder pFolder = Episode.Patient.PatientFolder;
            pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.Missing ,missingFile);
            FileLocation = missingFile;
            foreach(FileTransferRequestersInQueueGrid theInqueueGrid in Episode.Patient.FTRequestersInQueue)
            {
                theInqueueGrid.SendDepartment = false;
            }

#endregion PostTransition_FileAcceptanceByMR2MissingFile
        }

        protected void UndoTransition_FileAcceptanceByMR2MissingFile(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FileAcceptanceByMR   To State : MissingFile
#region UndoTransition_FileAcceptanceByMR2MissingFile
            
            
            NoBackStateBack();

#endregion UndoTransition_FileAcceptanceByMR2MissingFile
        }

        protected void PostTransition_FileRequest2FullfilmentFromMR()
        {
            // From State : FileRequest   To State : FullfilmentFromMR
#region PostTransition_FileRequest2FullfilmentFromMR
            
            ResSection archive = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection"); // MR= ARŞİV : ESKİSİ: 90F73FF4-47E5-4547-95A6-D90BA6C1534A
            FileLocation= archive;

#endregion PostTransition_FileRequest2FullfilmentFromMR
        }

        protected void UndoTransition_FileRequest2FullfilmentFromMR(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FileRequest   To State : FullfilmentFromMR
#region UndoTransition_FileRequest2FullfilmentFromMR
            
            NoBackStateBack();

#endregion UndoTransition_FileRequest2FullfilmentFromMR
        }

        protected void PostTransition_FileRequest2FullfilmentFromDepartment()
        {
            // From State : FileRequest   To State : FullfilmentFromDepartment
#region PostTransition_FileRequest2FullfilmentFromDepartment
            
            ResSection archive = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection"); // MR= ARŞİV : ESKİSİ: 90F73FF4-47E5-4547-95A6-D90BA6C1534A
            FileLocation= archive;

#endregion PostTransition_FileRequest2FullfilmentFromDepartment
        }

        protected void UndoTransition_FileRequest2FullfilmentFromDepartment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FileRequest   To State : FullfilmentFromDepartment
#region UndoTransition_FileRequest2FullfilmentFromDepartment
            
            
            NoBackStateBack();

#endregion UndoTransition_FileRequest2FullfilmentFromDepartment
        }

        protected void PostTransition_FileRequest2WaitingForFullfilment()
        {
            // From State : FileRequest   To State : WaitingForFullfilment
#region PostTransition_FileRequest2WaitingForFullfilment
            
            
            ResSection archive = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection"); // MR= ARŞİV : ESKİSİ: 90F73FF4-47E5-4547-95A6-D90BA6C1534A
            FileLocation= archive;
            

#endregion PostTransition_FileRequest2WaitingForFullfilment
        }

        protected void UndoTransition_FileRequest2WaitingForFullfilment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FileRequest   To State : WaitingForFullfilment
#region UndoTransition_FileRequest2WaitingForFullfilment
            
            
            NoBackStateBack();

#endregion UndoTransition_FileRequest2WaitingForFullfilment
        }

        protected void PostTransition_SendChart2AcknowledgementReceipt()
        {
            // From State : SendChart   To State : AcknowledgementReceipt
#region PostTransition_SendChart2AcknowledgementReceipt
            
            // Fullfillment FormPostta

#endregion PostTransition_SendChart2AcknowledgementReceipt
        }

        protected void UndoTransition_SendChart2AcknowledgementReceipt(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SendChart   To State : AcknowledgementReceipt
#region UndoTransition_SendChart2AcknowledgementReceipt
            
            
            NoBackStateBack();

#endregion UndoTransition_SendChart2AcknowledgementReceipt
        }

        protected void PostTransition_SendChart2FileAcceptanceByMR()
        {
            // From State : SendChart   To State : FileAcceptanceByMR
#region PostTransition_SendChart2FileAcceptanceByMR
            
            ResSection fetching = (ResSection)ObjectContext.GetObject(new Guid("107A9C49-DFAE-4896-928F-810DD9FF03E0"),"ResSection"); // Dosya Yolda - Getiriliyor.
            ResSection archive = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection");  // Arşiv
            foreach(FileTransferRequestersInQueueGrid theInqueueGrid in Episode.Patient.FTRequestersInQueue)
            {
                theInqueueGrid.SendDepartment = false;
            }
            FileLocation = fetching; 
            MasterResource = archive;   
            PatientFolder pFolder = Episode.Patient.PatientFolder;
            pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.SendToMR, fetching);

#endregion PostTransition_SendChart2FileAcceptanceByMR
        }

        protected void UndoTransition_SendChart2FileAcceptanceByMR(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SendChart   To State : FileAcceptanceByMR
#region UndoTransition_SendChart2FileAcceptanceByMR
            
            
            NoBackStateBack();

#endregion UndoTransition_SendChart2FileAcceptanceByMR
        }

        protected void PostTransition_FileIsMissing2FileAcceptanceByMR()
        {
            // From State : FileIsMissing   To State : FileAcceptanceByMR
#region PostTransition_FileIsMissing2FileAcceptanceByMR
            
            ResSection archive = (ResSection)ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection");  // Arşiv
            MasterResource = archive;
            PatientFolder pFolder = Episode.Patient.PatientFolder;
            pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.NotifyMR, null);
            foreach(FileTransferRequestersInQueueGrid theInqueueGrid in Episode.Patient.FTRequestersInQueue)
            {
                theInqueueGrid.SendDepartment = false;
            }

#endregion PostTransition_FileIsMissing2FileAcceptanceByMR
        }

        protected void UndoTransition_FileIsMissing2FileAcceptanceByMR(TTObjectStateTransitionDef transitionDef)
        {
            // From State : FileIsMissing   To State : FileAcceptanceByMR
#region UndoTransition_FileIsMissing2FileAcceptanceByMR
            
            
            NoBackStateBack();

#endregion UndoTransition_FileIsMissing2FileAcceptanceByMR
        }

#region Methods
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList;
            if(base.OldActionPropertyList()==null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            else
                propertyList = base.OldActionPropertyList();
            //-------------------------------------
            
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25533", "Dosyanın Yeri"), Common.ReturnObjectAsString(FileLocation)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M16650", "İstek Tarihi"), Common.ReturnObjectAsString(RequestDate)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20708", "Raf"),Common.ReturnObjectAsString(Shelf)));
            propertyList.Add(new EpisodeAction.OldActionPropertyObject("Sıra",Common.ReturnObjectAsString(Row)));
    
            //---------------------------------------
            return propertyList;
            
        } 
        
        protected override List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<EpisodeAction.OldActionPropertyObject>>> gridList;
            if(base.OldActionChildRelationList()==null)
                gridList=new List<List<List<EpisodeAction.OldActionPropertyObject>>>();
            else
                gridList=base.OldActionChildRelationList();

            List<List<EpisodeAction.OldActionPropertyObject>> gridFolderContentsRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();

            foreach( FileTransferRequestersInQueueGrid requestersInQueue in Episode.Patient.FTRequestersInQueue )
            {
                List<EpisodeAction.OldActionPropertyObject> gridFolderContentsRowColumnList=new List<EpisodeAction.OldActionPropertyObject>();
                gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26152", "İstek Yapan Bölüm"),Common.ReturnObjectAsString(requestersInQueue.RequesterUnit.Name)));
                gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26154", "İstek Yapan Kişi"),Common.ReturnObjectAsString(requestersInQueue.Requester.Name)));
                gridFolderContentsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M26272", "Karşılandı"),Common.ReturnObjectAsString(requestersInQueue.Fullfilled)));
                gridFolderContentsRowList.Add(gridFolderContentsRowColumnList);
            }
            gridList.Add(gridFolderContentsRowList);
            return gridList;
        }
        
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.FileTransfer;
            }
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            if(subEpisode.Episode.Patient.PatientFolder == null)
                throw new Exception(SystemMessage.GetMessage(1028));
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FileTransfer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FileTransfer.States.FullfilmentFromMR && toState == FileTransfer.States.Cancelled)
                PostTransition_FullfilmentFromMR2Cancelled();
            else if (fromState == FileTransfer.States.FullfilmentFromMR && toState == FileTransfer.States.MissingFile)
                PostTransition_FullfilmentFromMR2MissingFile();
            else if (fromState == FileTransfer.States.FullfilmentFromMR && toState == FileTransfer.States.AcknowledgementReceipt)
                PostTransition_FullfilmentFromMR2AcknowledgementReceipt();
            else if (fromState == FileTransfer.States.AcknowledgementReceipt && toState == FileTransfer.States.FileIsMissing)
                PostTransition_AcknowledgementReceipt2FileIsMissing();
            else if (fromState == FileTransfer.States.AcknowledgementReceipt && toState == FileTransfer.States.SendChart)
                PostTransition_AcknowledgementReceipt2SendChart();
            else if (fromState == FileTransfer.States.FileAcceptanceByMR && toState == FileTransfer.States.AcknowledgementReceipt)
                PostTransition_FileAcceptanceByMR2AcknowledgementReceipt();
            else if (fromState == FileTransfer.States.FileAcceptanceByMR && toState == FileTransfer.States.Accept)
                PostTransition_FileAcceptanceByMR2Accept();
            else if (fromState == FileTransfer.States.FileAcceptanceByMR && toState == FileTransfer.States.MissingFile)
                PostTransition_FileAcceptanceByMR2MissingFile();
            else if (fromState == FileTransfer.States.FileRequest && toState == FileTransfer.States.FullfilmentFromMR)
                PostTransition_FileRequest2FullfilmentFromMR();
            else if (fromState == FileTransfer.States.FileRequest && toState == FileTransfer.States.FullfilmentFromDepartment)
                PostTransition_FileRequest2FullfilmentFromDepartment();
            else if (fromState == FileTransfer.States.FileRequest && toState == FileTransfer.States.WaitingForFullfilment)
                PostTransition_FileRequest2WaitingForFullfilment();
            else if (fromState == FileTransfer.States.SendChart && toState == FileTransfer.States.AcknowledgementReceipt)
                PostTransition_SendChart2AcknowledgementReceipt();
            else if (fromState == FileTransfer.States.SendChart && toState == FileTransfer.States.FileAcceptanceByMR)
                PostTransition_SendChart2FileAcceptanceByMR();
            else if (fromState == FileTransfer.States.FileIsMissing && toState == FileTransfer.States.FileAcceptanceByMR)
                PostTransition_FileIsMissing2FileAcceptanceByMR();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FileTransfer).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FileTransfer.States.FullfilmentFromMR && toState == FileTransfer.States.Cancelled)
                UndoTransition_FullfilmentFromMR2Cancelled(transDef);
            else if (fromState == FileTransfer.States.FullfilmentFromMR && toState == FileTransfer.States.MissingFile)
                UndoTransition_FullfilmentFromMR2MissingFile(transDef);
            else if (fromState == FileTransfer.States.FullfilmentFromMR && toState == FileTransfer.States.AcknowledgementReceipt)
                UndoTransition_FullfilmentFromMR2AcknowledgementReceipt(transDef);
            else if (fromState == FileTransfer.States.AcknowledgementReceipt && toState == FileTransfer.States.FileIsMissing)
                UndoTransition_AcknowledgementReceipt2FileIsMissing(transDef);
            else if (fromState == FileTransfer.States.AcknowledgementReceipt && toState == FileTransfer.States.SendChart)
                UndoTransition_AcknowledgementReceipt2SendChart(transDef);
            else if (fromState == FileTransfer.States.FileAcceptanceByMR && toState == FileTransfer.States.AcknowledgementReceipt)
                UndoTransition_FileAcceptanceByMR2AcknowledgementReceipt(transDef);
            else if (fromState == FileTransfer.States.FileAcceptanceByMR && toState == FileTransfer.States.Accept)
                UndoTransition_FileAcceptanceByMR2Accept(transDef);
            else if (fromState == FileTransfer.States.FileAcceptanceByMR && toState == FileTransfer.States.MissingFile)
                UndoTransition_FileAcceptanceByMR2MissingFile(transDef);
            else if (fromState == FileTransfer.States.FileRequest && toState == FileTransfer.States.FullfilmentFromMR)
                UndoTransition_FileRequest2FullfilmentFromMR(transDef);
            else if (fromState == FileTransfer.States.FileRequest && toState == FileTransfer.States.FullfilmentFromDepartment)
                UndoTransition_FileRequest2FullfilmentFromDepartment(transDef);
            else if (fromState == FileTransfer.States.FileRequest && toState == FileTransfer.States.WaitingForFullfilment)
                UndoTransition_FileRequest2WaitingForFullfilment(transDef);
            else if (fromState == FileTransfer.States.SendChart && toState == FileTransfer.States.AcknowledgementReceipt)
                UndoTransition_SendChart2AcknowledgementReceipt(transDef);
            else if (fromState == FileTransfer.States.SendChart && toState == FileTransfer.States.FileAcceptanceByMR)
                UndoTransition_SendChart2FileAcceptanceByMR(transDef);
            else if (fromState == FileTransfer.States.FileIsMissing && toState == FileTransfer.States.FileAcceptanceByMR)
                UndoTransition_FileIsMissing2FileAcceptanceByMR(transDef);
        }

    }
}