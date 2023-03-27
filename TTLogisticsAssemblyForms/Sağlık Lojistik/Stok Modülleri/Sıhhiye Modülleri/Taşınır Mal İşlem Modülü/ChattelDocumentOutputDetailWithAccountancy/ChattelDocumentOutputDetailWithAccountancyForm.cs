
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
    /// Malzeme Detayları
    /// </summary>
    public partial class ChattelDocumentOutputDetailWithAccountancyForm : BaseStockActionDetailOutForm
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
#region ChattelDocumentOutputDetailWithAccountancyForm_PreScript
    base.PreScript();
#endregion ChattelDocumentOutputDetailWithAccountancyForm_PreScript

            }
            
#region ChattelDocumentOutputDetailWithAccountancyForm_Methods
        protected override void OnLoad(EventArgs e)
        {
            TTFormClasses.ChattelDocumentOutputWithAccountancyNewForm frm =  this.Owner as TTFormClasses.ChattelDocumentOutputWithAccountancyNewForm;
            if(frm != null)
            {
            ChattelDocumentOutputWithAccountancy obj = frm._ttObject as  ChattelDocumentOutputWithAccountancy;
            this._ChattelDocumentOutputDetailWithAccountancy.setaccountancy = obj.Accountancy;
            }
            base.OnLoad(e);
        }
        
#endregion ChattelDocumentOutputDetailWithAccountancyForm_Methods
    }
}