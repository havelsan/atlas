
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
    /// Vezne Tahsilat Türü Tanımı
    /// </summary>
    public partial class MainCashOfficePaymentTypeForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Vezne Tahsilat Türü Tanımı
    /// </summary>
        protected TTObjectClasses.MainCashOfficePaymentTypeDefinition _MainCashOfficePaymentTypeDefinition
        {
            get { return (TTObjectClasses.MainCashOfficePaymentTypeDefinition)_ttObject; }
        }

        protected ITTObjectListBox RevenueSubAccountCode;
        protected ITTTextBox CODE;
        protected ITTTextBox NAME;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel17;
        protected ITTCheckBox AccountEntegration;
        protected ITTCheckBox IsChattel;
        protected ITTCheckBox IsBankOperation;
        protected ITTCheckBox IsSubCashOfficePayment;
        protected ITTCheckBox SubCashierCanDo;
        protected ITTCheckBox cbxActive;
        override protected void InitializeControls()
        {
            RevenueSubAccountCode = (ITTObjectListBox)AddControl(new Guid("51ae2369-f503-404d-9fc2-6358692c63a2"));
            CODE = (ITTTextBox)AddControl(new Guid("7b9966d1-e912-47d1-9a15-72ac49a1398c"));
            NAME = (ITTTextBox)AddControl(new Guid("f7a6dd58-f1f7-4f56-8fc3-7e28c1277341"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("cf5cc7f2-91b7-46c8-8aba-72f688f2bf2b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("118e8e6f-e8ab-4b6d-9642-7b15dec417f2"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("e8bb4b50-21dd-497c-a509-e2dd4e8eb610"));
            AccountEntegration = (ITTCheckBox)AddControl(new Guid("3e595056-06d2-4b2a-9af1-55bcde18f560"));
            IsChattel = (ITTCheckBox)AddControl(new Guid("fdb1c682-18de-424a-85cf-e5c9f2527c3d"));
            IsBankOperation = (ITTCheckBox)AddControl(new Guid("ca4e7107-eb7c-41c4-be46-df97149bd972"));
            IsSubCashOfficePayment = (ITTCheckBox)AddControl(new Guid("8d27930d-9fb7-4d7c-8684-cd5b2649bd27"));
            SubCashierCanDo = (ITTCheckBox)AddControl(new Guid("6a78bb76-ea23-4d22-9f48-273a163a37e9"));
            cbxActive = (ITTCheckBox)AddControl(new Guid("51f4c82d-ce6f-46c3-a582-6dcc6af8051f"));
            base.InitializeControls();
        }

        public MainCashOfficePaymentTypeForm() : base("MAINCASHOFFICEPAYMENTTYPEDEFINITION", "MainCashOfficePaymentTypeForm")
        {
        }

        protected MainCashOfficePaymentTypeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}