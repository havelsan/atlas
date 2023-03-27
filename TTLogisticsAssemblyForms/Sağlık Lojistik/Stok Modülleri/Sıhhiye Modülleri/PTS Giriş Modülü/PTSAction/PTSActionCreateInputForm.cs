
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
    /// PTS Giriş İşlemi
    /// </summary>
    public partial class PTSActionCreateInputForm : BasePTSActionForm
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
#region PTSActionCreateInputForm_PreScript
    bool completed = false;
            ChattelDocumentWithPurchase chattelDocumentWithPurchase = (ChattelDocumentWithPurchase)_PTSAction.ObjectContext.GetObject((Guid)_PTSAction.ChattelDocumentObjectID, typeof(ChattelDocumentWithPurchase));
            lblDocumentStatus.Text = chattelDocumentWithPurchase.StockActionID.ToString() + " numaralı Taşınır işlemi " + chattelDocumentWithPurchase.CurrentStateDef.DisplayText + " durumundadır";
            if (chattelDocumentWithPurchase.CurrentStateDefID == ChattelDocumentWithPurchase.States.Completed)
                completed = true;
            
            if (completed == false)
                this.DropStateButton(PTSAction.States.Completed);
#endregion PTSActionCreateInputForm_PreScript

            }
                }
}