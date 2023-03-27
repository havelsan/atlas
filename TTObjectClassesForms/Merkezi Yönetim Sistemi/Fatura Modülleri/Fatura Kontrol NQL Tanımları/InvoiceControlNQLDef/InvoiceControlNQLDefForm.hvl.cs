
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
    public partial class InvoiceControlNQLDefForm : TTDefinitionForm
    {
    /// <summary>
    /// Fatura Kontrol NQL Tanımları
    /// </summary>
        protected TTObjectClasses.InvoiceControlNQLDef _InvoiceControlNQLDef
        {
            get { return (TTObjectClasses.InvoiceControlNQLDef)_ttObject; }
        }

        protected ITTTextBox OrderNo;
        protected ITTTextBox NQL;
        protected ITTTextBox Name;
        protected ITTLabel lblOrderNo;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel labelNQL;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            OrderNo = (ITTTextBox)AddControl(new Guid("da3a943e-749b-4253-90d2-78963eb3e4e4"));
            NQL = (ITTTextBox)AddControl(new Guid("bb646b76-1f8f-4f55-9ef5-023e98130716"));
            Name = (ITTTextBox)AddControl(new Guid("6c297099-d03c-44e0-b6a0-1433c08b7811"));
            lblOrderNo = (ITTLabel)AddControl(new Guid("a91d07bf-f8cb-4fc8-984b-3aa7c8981281"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("a0719aea-f8bd-403f-baaf-94dd269c1bfc"));
            labelNQL = (ITTLabel)AddControl(new Guid("0e734d71-c06e-4434-9490-67eaf1e0483a"));
            labelName = (ITTLabel)AddControl(new Guid("afe2be04-dd1d-405d-bf71-776139a7dc8f"));
            base.InitializeControls();
        }

        public InvoiceControlNQLDefForm() : base("INVOICECONTROLNQLDEF", "InvoiceControlNQLDefForm")
        {
        }

        protected InvoiceControlNQLDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}