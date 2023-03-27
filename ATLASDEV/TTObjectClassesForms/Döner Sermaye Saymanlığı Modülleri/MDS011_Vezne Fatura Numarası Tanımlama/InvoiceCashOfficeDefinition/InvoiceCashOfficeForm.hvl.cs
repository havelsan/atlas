
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
    /// Fatura Servisi Fatura Numarası Tanımlama
    /// </summary>
    public partial class InvoiceCashOfficeForm : TTDefinitionForm
    {
    /// <summary>
    /// Sayman Mutemetliği / Fatura Servisi Fatura Numarası Tanımlama
    /// </summary>
        protected TTObjectClasses.InvoiceCashOfficeDefinition _InvoiceCashOfficeDefinition
        {
            get { return (TTObjectClasses.InvoiceCashOfficeDefinition)_ttObject; }
        }

        protected ITTTextBox INVOICESTARTNUMBER;
        protected ITTTextBox INVOICEENDNUMBER;
        protected ITTTextBox INVOICESERIESNO;
        protected ITTTextBox CURRENTINVOICENUMBER;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox CASHOFFICENAME;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox cbxActive;
        override protected void InitializeControls()
        {
            INVOICESTARTNUMBER = (ITTTextBox)AddControl(new Guid("231ed422-6228-44ab-8035-2123526eb0e2"));
            INVOICEENDNUMBER = (ITTTextBox)AddControl(new Guid("27796bdc-5707-4148-97ca-3d98d8f8b649"));
            INVOICESERIESNO = (ITTTextBox)AddControl(new Guid("65c7d4c2-bc7f-466c-8071-54da3c0e7a12"));
            CURRENTINVOICENUMBER = (ITTTextBox)AddControl(new Guid("a823c9a7-e918-40ab-9d99-6051b70ae78c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("4d29d5de-4c12-452f-8d8d-29ddabb8742e"));
            CASHOFFICENAME = (ITTObjectListBox)AddControl(new Guid("9541ac35-44fd-4c72-89eb-5a10591af61f"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("d343807c-1b74-4ba6-babe-5c75be5a2086"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("841fb2f5-182e-4221-bd20-605da2437bb7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("7690bb9e-c53e-45c5-8b59-7e8c55bd974d"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ab6d8bad-c595-443c-b024-8f4a069ca199"));
            cbxActive = (ITTCheckBox)AddControl(new Guid("a1ed15da-9527-43a2-844e-54d31c744cee"));
            base.InitializeControls();
        }

        public InvoiceCashOfficeForm() : base("INVOICECASHOFFICEDEFINITION", "InvoiceCashOfficeForm")
        {
        }

        protected InvoiceCashOfficeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}