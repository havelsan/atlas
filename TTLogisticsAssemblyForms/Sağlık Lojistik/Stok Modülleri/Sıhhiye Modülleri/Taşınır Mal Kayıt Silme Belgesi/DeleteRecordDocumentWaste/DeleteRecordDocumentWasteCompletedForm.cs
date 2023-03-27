
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
    public partial class DeleteRecordDocumentWasteCompletedForm : BaseDeleteRecordDocumentWasteForm
    {

        override protected void BindControlEvents()
        {
            SendToMKYS.Click += new TTControlEventDelegate(SendToMKYS_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SendToMKYS.Click -= new TTControlEventDelegate(SendToMKYS_Click);
            base.UnBindControlEvents();
        }

        private void SendToMKYS_Click()
        {
            #region DeleteRecordDocumentWasteCompletedForm_SendToMKYS_Click

            if (this._DeleteRecordDocumentWaste.CurrentStateDefID == DeleteRecordDocumentWaste.States.Completed)
            {
                if (this._DeleteRecordDocumentWaste.MKYS_AyniyatMakbuzID == null)
                {
                    this._DeleteRecordDocumentWaste.SendMKYSForOutputDocument(Common.CurrentResource.MkysPassword);
                }
            }
            if (this._DeleteRecordDocumentWaste.CurrentStateDefID == DeleteRecordDocumentWaste.States.Cancelled)
            {
                if (this._DeleteRecordDocumentWaste.MKYS_AyniyatMakbuzID != null)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    context.GetObject(_DeleteRecordDocumentWaste.ObjectID, _DeleteRecordDocumentWaste.ObjectDef);

                    ((ITTObject)this._DeleteRecordDocumentWaste).UndoLastTransition("MKYS ÝPTAL GÖNDERÝMDE HATA ALINDIGI ÝÇÝN ÝÞLEM TAMAMLANDIDAN TEKRAR ÝPTALE SÝSTEM TARAFINDAN ÇEKÝLMÝÞTÝR.");
                    context.Update();
                    this._DeleteRecordDocumentWaste.SendDeleteMessageToMkys(true, this._DeleteRecordDocumentWaste.MKYS_AyniyatMakbuzID.Value, Common.CurrentResource.MkysPassword);
                    _DeleteRecordDocumentWaste.CurrentStateDefID = DeleteRecordDocumentWaste.States.Cancelled;
                    context.Save();
                }
            }
            #endregion DeleteRecordDocumentWasteCompletedForm_SendToMKYS_Click
        }









        protected override void PreScript()
        {
#region DeleteRecordDocumentWasteCompletedForm_PreScript
    base.PreScript();
            
            if(this._DeleteRecordDocumentWaste.StockActionInspection == null)
                DropCurrentStateReport(TTObjectDefManager.Instance.ReportDefs[new Guid("1c95415c-307f-41fa-a79a-b8aa82cb0df3")].ReportDefID);
#endregion DeleteRecordDocumentWasteCompletedForm_PreScript

            }
                }
}