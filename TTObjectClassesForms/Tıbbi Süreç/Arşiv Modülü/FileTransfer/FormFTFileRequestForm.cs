
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Dosya Transfer
    /// </summary>
    public partial class FormFTFileRequest : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region FormFTFileRequest_PreScript
    //343dc2a3-f698-4519-b98c-5e0b702876b3		Dosya Kayıp
            //6c6f9948-5394-4465-8cdb-6c88de2e5e36		Arşiv
            //91129d5e-54ea-4345-82c9-7dd0718ebbb9		Eksik Dosya
            //107a9c49-dfae-4896-928f-810dd9ff03e0		Dosya Getiriliyor(Yolda)
            //43aca6e1-931d-443d-b846-8829b752cf46		Analiz
            
            base.PreScript();

            PatientFolderTransaction currentTR = this._FileTransfer.Episode.Patient.PatientFolder.LastPatientFolderTransaction;
            // Dosya lokasyonu Dosya Kayıp, Eksik Dosya, Analiz ya da boş ise, hata mesajı alınır. 
            if(currentTR.FolderLocation.ObjectID.Equals(new Guid("343DC2A3-F698-4519-B98C-5E0B702876B3")) || currentTR.FolderLocation.ObjectID.Equals(new Guid("91129d5e-54ea-4345-82c9-7dd0718ebbb9")) || currentTR.FolderLocation.ObjectID.Equals(new Guid("43aca6e1-931d-443d-b846-8829b752cf46")) || currentTR.FolderLocation.ObjectID.Equals(null) )
            {
                throw new Exception(SystemMessage.GetMessage(1030));
            }
            
            
            if(this._FileTransfer.CurrentStateDefID.HasValue && this._FileTransfer.CurrentStateDefID.Value.Equals(FileTransfer.States.FileRequest))
            {
                this._FileTransfer.NoInQueue = 0;
                if(string.IsNullOrEmpty(this.Requester.Text))
                    this.Requester.SelectedValue = Common.CurrentResource == null ? Guid.Empty : Common.CurrentResource.ObjectID;
                if(string.IsNullOrEmpty(this.RequesterDepartment.Text))
                    this.RequesterDepartment.SelectedValue = this._FileTransfer.MasterResource.ObjectID;

                //TODO..yilmaz..burdaki kontrol resource a göre yapılıp type ile get edilerek yapılmalı
                
                
                
                // Dosya bölümde değilse ya da Folder locationı null değilse FullfilmentFromDepartment (Departmandan karşılama bekliyor)
                
                if(currentTR.FolderLocation != null &&!currentTR.FolderLocation.ObjectID.Equals(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36")))  // ARŞİV
                {
                    this.DropStateButton(FileTransfer.States.FullfilmentFromMR);
                    this.DropStateButton(FileTransfer.States.WaitingForFullfilment);
                }
                else
                {
                    //Eğer açık olan episodelarda FullfilmentFromMR aşamasında bir action varsa bFound falag i true yapılır.
                    
                    bool bFound = false;
                    foreach(Episode episode in this._FileTransfer.Episode.Patient.Episodes)
                    {
                        if(!episode.CurrentStateDefID.Value.Equals(Episode.States.Closed))
                        {
                            foreach(BaseAction action in episode.EpisodeActions)
                            {
                                if(action is FileTransfer && action.CurrentStateDefID.Value.Equals(FileTransfer.States.FullfilmentFromMR))
                                {
                                    bFound = true;
                                    break;
                                }
                            }
                            if(bFound)
                                break;

                        }
                    }
                    
                    if(bFound) // Eğer açık olan episodelarda FullfilmentFromMR aşamasında bir action varsa WaitingForFullfilment (Karşılama bekliyor)
                    {
                        this.DropStateButton(FileTransfer.States.FullfilmentFromDepartment);
                        this.DropStateButton(FileTransfer.States.FullfilmentFromMR);
                    }
                    else // Eğer açık olan episodelarda FullfilmentFromMR aşamasında bir action yoksa FullfilmentFromMR (Arşiv dosya karşılama)
                    {
                        this.DropStateButton(FileTransfer.States.FullfilmentFromDepartment);
                        this.DropStateButton(FileTransfer.States.WaitingForFullfilment);
                    }
                }
                if(currentTR.FolderLocation != null )
                    this.FileLocation.SelectedValue = currentTR.FolderLocation.ObjectID;
                  
                if (this._FileTransfer.Episode.Patient.PatientFolder != null )  
                {
                    this._FileTransfer.Shelf = this._FileTransfer.Episode.Patient.PatientFolder.Shelf;
                    this._FileTransfer.Row = this._FileTransfer.Episode.Patient.PatientFolder.Row;
                }
            }
#endregion FormFTFileRequest_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FormFTFileRequest_PostScript
    base.PostScript(transDef);

            
            //1  Aynı bölümden aynı kişi istekte bulunursa hata mesajı verilir, işlem yapması engellenir. 
            foreach(FileTransferRequestersInQueueGrid reqQueue2 in this._FileTransfer.Episode.Patient.FTRequestersInQueue)
            {
                if(this.Requester.SelectedValue.Equals(reqQueue2.Requester.ObjectID)  && this.RequesterDepartment.SelectedValue.Equals(reqQueue2.RequesterUnit.ObjectID) && reqQueue2.CurrentStateDefID.Equals(FileTransferRequestersInQueueGrid.States.Request))
                {
                    throw new Exception (SystemMessage.GetMessage(1031));
                }
                
            }


            //Forma girilen istek yapan birim ve kişi bilgilerini girde atar.
            
            FileTransferRequestersInQueueGrid reqQueue = new FileTransferRequestersInQueueGrid(this._FileTransfer.ObjectContext);

            Int16 maxQueueNo= 0;
            foreach(FileTransferRequestersInQueueGrid reqQ in this._FileTransfer.Episode.Patient.FTRequestersInQueue){
                if(maxQueueNo < Convert.ToInt16(reqQ.NoInQueue) ){
                    maxQueueNo = Convert.ToInt16(reqQ.NoInQueue);
                }
            }
            ResSection archive = (ResSection)this._FileTransfer.ObjectContext.GetObject(new Guid("6C6F9948-5394-4465-8CDB-6C88DE2E5E36"),"ResSection");
            reqQueue.NoInQueue = maxQueueNo +1 ;
            reqQueue.Requester= (ResUser)this.Requester.SelectedObject;
            reqQueue.RequesterUnit= (ResSection)this.RequesterDepartment.SelectedObject;
            reqQueue.CurrentStateDefID = FileTransferRequestersInQueueGrid.States.Request; 
            this._FileTransfer.Episode.Patient.FTRequestersInQueue.Add(reqQueue);
            this._FileTransfer.MasterResource = archive;
#endregion FormFTFileRequest_PostScript

            }
                }
}