
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
    /// Malzeme Muvazene İstek
    /// </summary>
    public partial class MaterialStabilitySiteForm : CentralActionBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdOutputDocument.Click += new TTControlEventDelegate(cmdOutputDocument_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdOutputDocument.Click -= new TTControlEventDelegate(cmdOutputDocument_Click);
            base.UnBindControlEvents();
        }

        private void cmdOutputDocument_Click()
        {
#region MaterialStabilitySiteForm_cmdOutputDocument_Click
   this.AddStateButton(MaterialStabilityAction.States.CreateStability);
            ChattelDocumentOutputWithAccountancy chattelDocumentOutputWithAccountancy = new ChattelDocumentOutputWithAccountancy(_MaterialStabilityAction.ObjectContext);
            chattelDocumentOutputWithAccountancy.Accountancy = _MaterialStabilityAction.ReceiveAccountancy;
            MainStoreDefinition mainStore = (MainStoreDefinition)_MaterialStabilityAction.ObjectContext.GetObject((Guid)_MaterialStabilityAction.MainStoreID,typeof(MainStoreDefinition));
            chattelDocumentOutputWithAccountancy.Store = mainStore;
            chattelDocumentOutputWithAccountancy.Description = _MaterialStabilityAction.Description;
            chattelDocumentOutputWithAccountancy.MaterialStabilityActionID = _MaterialStabilityAction.ObjectID;
            ChattelDocumentOutputDetailWithAccountancy chattelDocumentOutputDetailWithAccountancy = chattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.AddNew();
            chattelDocumentOutputDetailWithAccountancy.Material = _MaterialStabilityAction.Material;
            chattelDocumentOutputDetailWithAccountancy.Amount = _MaterialStabilityAction.Amount;
            chattelDocumentOutputWithAccountancy.CurrentStateDefID = ChattelDocumentOutputWithAccountancy.States.New;
            this.cmdOutputDocument.Enabled = false;
            this.cmdOutputDocument.ReadOnly = true;
#endregion MaterialStabilitySiteForm_cmdOutputDocument_Click
        }

        protected override void PreScript()
        {
#region MaterialStabilitySiteForm_PreScript
    base.PreScript();
    this.DropStateButton(MaterialStabilityAction.States.CreateStability);
#endregion MaterialStabilitySiteForm_PreScript

            }
                }
}