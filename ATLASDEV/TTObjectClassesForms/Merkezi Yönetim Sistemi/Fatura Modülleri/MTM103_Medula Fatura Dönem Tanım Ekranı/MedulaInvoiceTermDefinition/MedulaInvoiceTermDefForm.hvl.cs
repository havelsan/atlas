
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
    /// Medula Fatura Dönem Tanım Ekranı
    /// </summary>
    public partial class MedulaInvoiceTermDefForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Medula Fatura Dönem Tanım Ekranı
    /// </summary>
        protected TTObjectClasses.MedulaInvoiceTermDefinition _MedulaInvoiceTermDefinition
        {
            get { return (TTObjectClasses.MedulaInvoiceTermDefinition)_ttObject; }
        }

        protected ITTTextBox DocumentNo;
        protected ITTTextBox Name;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEndDate;
        protected ITTDateTimePicker EndDate;
        protected ITTLabel labelStartDate;
        protected ITTDateTimePicker StartDate;
        protected ITTLabel labelName;
        protected ITTLabel lblDocumentNo;
        override protected void InitializeControls()
        {
            DocumentNo = (ITTTextBox)AddControl(new Guid("ae9b2777-9680-4664-bb3f-39c619ebb456"));
            Name = (ITTTextBox)AddControl(new Guid("bcf03d5f-5e93-4e9e-9786-787b96101005"));
            IsActive = (ITTCheckBox)AddControl(new Guid("0b3697f9-e256-49e1-825f-ee7fe2b8a424"));
            labelEndDate = (ITTLabel)AddControl(new Guid("a44b842a-67a0-49a0-bb63-5578f5740271"));
            EndDate = (ITTDateTimePicker)AddControl(new Guid("33d705e9-5e20-484a-88bc-106b3ce124b3"));
            labelStartDate = (ITTLabel)AddControl(new Guid("c137e6bb-e896-4840-9a4c-37c784af8724"));
            StartDate = (ITTDateTimePicker)AddControl(new Guid("acaaf615-e4b3-4bb6-b46f-e41284d8e098"));
            labelName = (ITTLabel)AddControl(new Guid("37e40faa-a266-4667-9c89-9ccac8f997e8"));
            lblDocumentNo = (ITTLabel)AddControl(new Guid("a1148fc0-b636-48ed-9ce8-686419f22e50"));
            base.InitializeControls();
        }

        public MedulaInvoiceTermDefForm() : base("MEDULAINVOICETERMDEFINITION", "MedulaInvoiceTermDefForm")
        {
        }

        protected MedulaInvoiceTermDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}