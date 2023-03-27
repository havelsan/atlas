
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Malzeme Detayları
    /// </summary>
    public partial class ChattelDocumentOutputDetailWithAccountancyForm : BaseStockActionDetailOutForm
    {
        protected TTObjectClasses.ChattelDocumentOutputDetailWithAccountancy _ChattelDocumentOutputDetailWithAccountancy
        {
            get { return (TTObjectClasses.ChattelDocumentOutputDetailWithAccountancy)_ttObject; }
        }

        protected ITTListBoxColumn ToAccountancy;
        protected ITTListBoxColumn FromAccountancy;
        override protected void InitializeControls()
        {
            ToAccountancy = (ITTListBoxColumn)AddControl(new Guid("d6e45f31-2a6a-4ee7-84e5-037f3ba810b0"));
            FromAccountancy = (ITTListBoxColumn)AddControl(new Guid("a38a90af-5f80-41e8-8121-f067f5fa2a57"));
            base.InitializeControls();
        }

        public ChattelDocumentOutputDetailWithAccountancyForm() : base("CHATTELDOCUMENTOUTPUTDETAILWITHACCOUNTANCY", "ChattelDocumentOutputDetailWithAccountancyForm")
        {
        }

        protected ChattelDocumentOutputDetailWithAccountancyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}