
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
    public partial class FormFTFileFullfilment : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            RequestersInQueue.CellContentClick += new TTGridCellEventDelegate(RequestersInQueue_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RequestersInQueue.CellContentClick -= new TTGridCellEventDelegate(RequestersInQueue_CellContentClick);
            base.UnBindControlEvents();
        }

        private void RequestersInQueue_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region FormFTFileFullfilment_RequestersInQueue_CellContentClick
   if(RequestersInQueue.CurrentCell.OwningColumn.Name == "SendDepartment2")
            {
                if(RequestersInQueue.CurrentCell.Value.ToString()  == "False" ) //Kliklenirkenki değerini aldığı için eski değeri kalıyor. Aslında burası true olmuştu.
                {
                    // UAYRI: Burada FullFillment bir başka kolona taşınırsa, silinirse, sorun çıkabilir columnIndex+1'ten dolayı. 
                    if(RequestersInQueue.Rows[rowIndex].Cells[columnIndex+1].Value.ToString() == "True" )  // checklenen satırın Fullfilled'ı false ise hiç uğraşmadan, o satırın send dept ını false yapacak.
                    {             
                        RequestersInQueue.CurrentCell.Value = false;  // RequestersInQueue.Rows[rowIndex].Cells["SendDepartment"].Value = false;
                    }
                    else{ 
                        // SendDepartment checklenirken eğer bir başka rowda checkeli SendDept varsa, onu unchecked yapar.
                        foreach(ITTGridRow row in this.RequestersInQueue.Rows)
                        {
                            FileTransferRequestersInQueueGrid reqQueue = (FileTransferRequestersInQueueGrid)row.TTObject;
                            if((reqQueue.NoInQueue-1) != rowIndex )
                            {
                                reqQueue.SendDepartment = false ;
                            }
                            else 
                            {
                                reqQueue.SendDepartment= true; 
                            }
                        }
                    }
                }
            }
#endregion FormFTFileFullfilment_RequestersInQueue_CellContentClick
        }

        protected override void PreScript()
        {
#region FormFTFileFullfilment_PreScript
    base.PreScript();
 
            
            // Fullfilled i boş olan ilk satırın SendDepartmant'ını checkler.
            
            if(this._FileTransfer.CurrentStateDefID.Equals(FileTransfer.States.FullfilmentFromMR))
            {
                foreach(FileTransferRequestersInQueueGrid  reqQueue in this._FileTransfer.Episode.Patient.FTRequestersInQueue)
                {
                    if(reqQueue.Fullfilled == false  && !reqQueue.CurrentStateDefID.Equals(FileTransferRequestersInQueueGrid.States.Cancelled) ){
                        reqQueue.SendDepartment = true;
                        break;
                    }
                }
            }
            

            // TODO Test Edilecek.
            // Current state SEND CHART ya da FILEACCEPTANCEBYMR ise ve eğer griddeki bütün istekler karşılanmışsa,
            // Bölüme gönder buttonu drop edilir.
            
            bool unFullfilledFound= false;
            if(this._FileTransfer.CurrentStateDefID.Value.Equals(FileTransfer.States.SendChart) || this._FileTransfer.CurrentStateDefID.Value.Equals(FileTransfer.States.FileAcceptanceByMR) )
            {
                foreach(FileTransferRequestersInQueueGrid reqQueue in this._FileTransfer.Episode.Patient.FTRequestersInQueue)
                {
                    if(reqQueue.Fullfilled == false  && !reqQueue.CurrentStateDefID.Equals(FileTransferRequestersInQueueGrid.States.Cancelled))
                    {
                        unFullfilledFound= true;
                        break;
                    }
                }
                if(!unFullfilledFound)
                {
                    this.DropStateButton(FileTransfer.States.AcknowledgementReceipt);
                }
            }
#endregion FormFTFileFullfilment_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FormFTFileFullfilment_PostScript
    base.PostScript(transDef);

            // FullfilmentFromMR, SendChart, FileAcceptanceByMR transition postları ortak olduğu için, burada yapıldı.
            // Eğer AcknowledgementReciept a giden transitonların formunda istekliler arasında hiç gönderilecek bölüm
            // seçilmediyse, hata mesajı verilir; seçildiyese, formdaki alanlara griddeki seçilmiş istekli hakkındaki bilgileri set eder.
            if((transDef.FromStateDefID.Equals(FileTransfer.States.FullfilmentFromMR) ||
                transDef.FromStateDefID.Equals(FileTransfer.States.SendChart) ||
                transDef.FromStateDefID.Equals(FileTransfer.States.FileAcceptanceByMR)) &&
                transDef.ToStateDefID.Equals(FileTransfer.States.AcknowledgementReceipt))
            {
                bool bFound = false;
                bool sendDeptCheckedFound = false;
                FileTransferRequestersInQueueGrid reqQueue = null;
                ResSection fetching = (ResSection)this._FileTransfer.ObjectContext.GetObject(new Guid("107A9C49-DFAE-4896-928F-810DD9FF03E0"),"ResSection"); // Dosya Yolda - Getiriliyor.
                foreach(FileTransferRequestersInQueueGrid theGrid in this._FileTransfer.Episode.Patient.FTRequestersInQueue)
                {
                    if(theGrid.SendDepartment.Value && !theGrid.Fullfilled.Value  && !theGrid.CurrentStateDefID.Equals(FileTransferRequestersInQueueGrid.States.Cancelled))
                    {
                        bFound = true;
                        reqQueue= theGrid;
                        break;
                    }

                }
                if(!bFound)
                    throw new Exception(SystemMessage.GetMessage(1029));
                else
                {
                    this.Requester.SelectedObject = reqQueue.Requester ;
                    this.RequesterDepartment.SelectedObject = reqQueue.RequesterUnit;
                    //this._FileTransfer.FileLocation= fetching; 
                    this.FileLocation.SelectedObject  = fetching;
                    this._FileTransfer.MasterResource = (ResSection)reqQueue.RequesterUnit;
                    reqQueue.CurrentStateDefID = FileTransferRequestersInQueueGrid.States.Request; // Grid objesi yeni oluşturulduğunda state'i request
                    PatientFolder pFolder = this._FileTransfer.Episode.Patient.PatientFolder;
                    if(transDef.FromStateDefID.Equals(FileTransfer.States.FullfilmentFromMR) || transDef.FromStateDefID.Equals(FileTransfer.States.FileAcceptanceByMR) )
                    {
                        pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.FulfilledFromMR ,fetching);
                    }
                    else// FromStateDefID SendChart ise
                    {
                        pFolder.AddPatientFolderTransaction(Common.CurrentResource, FolderTransactionTypeEnum.FulfilledFromDepartment ,fetching);
                    }
                }
            }
#endregion FormFTFileFullfilment_PostScript

            }
                }
}