
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
    public partial class InvoiceInclusionNQLForm : TTDefinitionForm
    {
    /// <summary>
    /// Fatura Dahillik Sorgu Tanımları
    /// </summary>
        protected TTObjectClasses.InvoiceInclusionNQL _InvoiceInclusionNQL
        {
            get { return (TTObjectClasses.InvoiceInclusionNQL)_ttObject; }
        }

        protected ITTLabel labelProcedureMaterialType;
        protected ITTEnumComboBox ProcedureMaterialType;
        protected ITTLabel labelOrderNo;
        protected ITTTextBox OrderNo;
        protected ITTTextBox NQL;
        protected ITTTextBox Name;
        protected ITTLabel labelNQL;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelProcedureMaterialType = (ITTLabel)AddControl(new Guid("0377f267-cb2a-450f-8f42-05f3eb3baf37"));
            ProcedureMaterialType = (ITTEnumComboBox)AddControl(new Guid("1af4aeb4-a793-4290-a0a3-fca100628d6f"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("fc71cc8c-03cf-4b7a-bf79-b9ce0334c5d4"));
            OrderNo = (ITTTextBox)AddControl(new Guid("b6c564fa-17e7-443c-90cb-0808614ae14d"));
            NQL = (ITTTextBox)AddControl(new Guid("f5b9dbef-594a-41b3-9f6b-fdbe212e30d3"));
            Name = (ITTTextBox)AddControl(new Guid("773181b4-d852-41c2-9a35-340f6b9f27a0"));
            labelNQL = (ITTLabel)AddControl(new Guid("24c91f16-c375-4597-8bf5-3478e1c35b99"));
            labelName = (ITTLabel)AddControl(new Guid("c49d8f58-13fa-46b2-98bd-2bc002debee5"));
            base.InitializeControls();
        }

        public InvoiceInclusionNQLForm() : base("INVOICEINCLUSIONNQL", "InvoiceInclusionNQLForm")
        {
        }

        protected InvoiceInclusionNQLForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}