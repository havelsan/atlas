
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
    public partial class InvoiceInclusionDetailForm : TTDefinitionForm
    {
    /// <summary>
    /// Fatura Dahillik Detay Tanımları
    /// </summary>
        protected TTObjectClasses.InvoiceInclusionDetail _InvoiceInclusionDetail
        {
            get { return (TTObjectClasses.InvoiceInclusionDetail)_ttObject; }
        }

        protected ITTLabel labelValue;
        protected ITTTextBox Value;
        protected ITTTextBox Code;
        protected ITTLabel labelType;
        protected ITTEnumComboBox Type;
        protected ITTLabel labelCode;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            labelValue = (ITTLabel)AddControl(new Guid("31ec28d4-ff59-4b66-b0cc-cc1d72efe902"));
            Value = (ITTTextBox)AddControl(new Guid("6de5cb20-6d12-44e6-98da-a87e25b928d9"));
            Code = (ITTTextBox)AddControl(new Guid("b939bdfc-b07f-4f74-a76d-35b0d85877ff"));
            labelType = (ITTLabel)AddControl(new Guid("82ec6f6a-164a-4881-8f95-7c7fff88f4a7"));
            Type = (ITTEnumComboBox)AddControl(new Guid("0098678e-5ef3-484b-b322-bc17f711e980"));
            labelCode = (ITTLabel)AddControl(new Guid("7d185511-bd66-4d26-a9f2-fee38174d40f"));
            Active = (ITTCheckBox)AddControl(new Guid("fa8a7c58-6080-4221-a12b-45eae0f530cf"));
            base.InitializeControls();
        }

        public InvoiceInclusionDetailForm() : base("INVOICEINCLUSIONDETAIL", "InvoiceInclusionDetailForm")
        {
        }

        protected InvoiceInclusionDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}