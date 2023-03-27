
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
    /// İstek Kalemi Tanım Formu
    /// </summary>
    public partial class PurchaseGroupDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// İstek Kalemi Tanımı
    /// </summary>
        protected TTObjectClasses.PurchaseGroup _PurchaseGroup
        {
            get { return (TTObjectClasses.PurchaseGroup)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTCheckBox IsMaterial;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("2177884e-b1a3-4c77-bbbf-43188c3c45fb"));
            Name = (ITTTextBox)AddControl(new Guid("99f852cc-257a-451a-a9fe-6a5866317ec1"));
            Code = (ITTTextBox)AddControl(new Guid("38c67181-9021-45e3-a331-1694bc3f6bd9"));
            IsMaterial = (ITTCheckBox)AddControl(new Guid("d65059a4-512f-4c62-91a8-f79c8d63e710"));
            labelCode = (ITTLabel)AddControl(new Guid("4232a385-8bea-4234-81dc-894cb01dff0e"));
            base.InitializeControls();
        }

        public PurchaseGroupDefinitionForm() : base("PURCHASEGROUP", "PurchaseGroupDefinitionForm")
        {
        }

        protected PurchaseGroupDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}