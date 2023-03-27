
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
    public partial class UpdateSourceDocumentRecordLogForm : TTForm
    {
    /// <summary>
    /// Taşınır Mal İşlemi Çıkış
    /// </summary>
        protected TTObjectClasses.ChattelDocumentOutputWithAccountancy _ChattelDocumentOutputWithAccountancy
        {
            get { return (TTObjectClasses.ChattelDocumentOutputWithAccountancy)_ttObject; }
        }

        protected ITTButton cmdSave;
        protected ITTTextBox txtSourceDocumentRecordLogNo;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            cmdSave = (ITTButton)AddControl(new Guid("e3ade172-104c-4e3b-a8f9-356e32a89a7e"));
            txtSourceDocumentRecordLogNo = (ITTTextBox)AddControl(new Guid("92738bc1-c1c9-4ec8-b26f-652997fef530"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cd0333d5-1774-4349-b93a-5ca036323b48"));
            base.InitializeControls();
        }

        public UpdateSourceDocumentRecordLogForm() : base("CHATTELDOCUMENTOUTPUTWITHACCOUNTANCY", "UpdateSourceDocumentRecordLogForm")
        {
        }

        protected UpdateSourceDocumentRecordLogForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}