
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
    /// Medula Fatura Türü Tanım Ekranı
    /// </summary>
    public partial class MedulaInvoiceTypeDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Medula Fatura Türü Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.MedulaInvoiceTypeDefinition _MedulaInvoiceTypeDefinition
        {
            get { return (TTObjectClasses.MedulaInvoiceTypeDefinition)_ttObject; }
        }

        protected ITTLabel lblTedaviTuru;
        protected ITTObjectListBox TTListBoxTedaviTuru;
        protected ITTLabel lblPayer;
        protected ITTObjectListBox TTListBox;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            lblTedaviTuru = (ITTLabel)AddControl(new Guid("aa15ad2e-c2be-443c-90de-35b95d3df341"));
            TTListBoxTedaviTuru = (ITTObjectListBox)AddControl(new Guid("460851c1-589f-4689-872a-f27f6ca0c7d4"));
            lblPayer = (ITTLabel)AddControl(new Guid("8bc040f1-5881-47c7-a85a-cfe18bf0b660"));
            TTListBox = (ITTObjectListBox)AddControl(new Guid("69da23d4-0482-4f50-92e5-f2f917437f1c"));
            labelName = (ITTLabel)AddControl(new Guid("418ac795-2dd6-4231-8a43-dcc630497a5a"));
            Name = (ITTTextBox)AddControl(new Guid("44aa186a-2548-47cb-9f62-3b50b3136d42"));
            base.InitializeControls();
        }

        public MedulaInvoiceTypeDefForm() : base("MEDULAINVOICETYPEDEFINITION", "MedulaInvoiceTypeDefForm")
        {
        }

        protected MedulaInvoiceTypeDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}