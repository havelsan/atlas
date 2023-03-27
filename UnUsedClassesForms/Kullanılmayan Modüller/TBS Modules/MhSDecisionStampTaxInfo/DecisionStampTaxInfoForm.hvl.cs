
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
    /// Karar Pulu Vergi Bilgileri
    /// </summary>
    public partial class DecisionStampTaxInfoForm : TTForm
    {
    /// <summary>
    /// Karar Pulu Vergi Bilgileri
    /// </summary>
        protected TTObjectClasses.MhSDecisionStampTaxInfo _MhSDecisionStampTaxInfo
        {
            get { return (TTObjectClasses.MhSDecisionStampTaxInfo)_ttObject; }
        }

        protected ITTLabel labelTaxNumber;
        protected ITTLabel labelOrderNo;
        protected ITTTextBox TaxDepartment;
        protected ITTTextBox PrivateNo;
        protected ITTTextBox Reciever;
        protected ITTTextBox TenderPrice;
        protected ITTLabel labelDate;
        protected ITTLabel labelTotalAmount;
        protected ITTLabel labelTenderPrice;
        protected ITTLabel labelReciever;
        protected ITTLabel labelTaxDepartment;
        protected ITTTextBox DelivererAddress;
        protected ITTLabel labelDelivererNameSurname;
        protected ITTTextBox DelivererNameSurname;
        protected ITTLabel labelDelivererAddress;
        protected ITTLabel labelPrivateNo;
        protected ITTTextBox TaxNumber;
        protected ITTListDefComboBox ttlistdefcombobox1;
        protected ITTDateTimePicker Date;
        protected ITTTextBox OrderNo;
        protected ITTLabel labelOperationType;
        protected ITTTextBox TotalAmount;
        override protected void InitializeControls()
        {
            labelTaxNumber = (ITTLabel)AddControl(new Guid("34b8d1a2-6e4f-4dd5-ad58-0f1c3b6c0fbd"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("1b7a895a-411a-4469-97a4-bdad634f2a2d"));
            TaxDepartment = (ITTTextBox)AddControl(new Guid("83468fe6-69d6-46d0-bb8f-b55160629b76"));
            PrivateNo = (ITTTextBox)AddControl(new Guid("7598fffa-8662-42b3-9f67-87775549ff87"));
            Reciever = (ITTTextBox)AddControl(new Guid("0f6b1254-c08e-4bcc-816d-9aa88f4d84c9"));
            TenderPrice = (ITTTextBox)AddControl(new Guid("b230dae9-5650-469e-aff6-91b899c412cf"));
            labelDate = (ITTLabel)AddControl(new Guid("3e113f25-ad2c-4cc3-be79-76bede340e45"));
            labelTotalAmount = (ITTLabel)AddControl(new Guid("b5b9b2ce-8c23-4e0f-a016-5856c25f7f31"));
            labelTenderPrice = (ITTLabel)AddControl(new Guid("c43f97e5-dd4b-4c19-9ef5-5f1fb1199ddc"));
            labelReciever = (ITTLabel)AddControl(new Guid("90f01ff4-ee44-4833-8c36-2634feaabb12"));
            labelTaxDepartment = (ITTLabel)AddControl(new Guid("f5c53fd8-19c5-4a55-9a8e-3c68d788b112"));
            DelivererAddress = (ITTTextBox)AddControl(new Guid("cfcf16a8-19ad-4d0c-b7ea-25ed613637d8"));
            labelDelivererNameSurname = (ITTLabel)AddControl(new Guid("71025fd7-8f52-4f62-902c-2172e76420af"));
            DelivererNameSurname = (ITTTextBox)AddControl(new Guid("6c0cc1f3-1eb0-496f-ab7a-4f1312c83321"));
            labelDelivererAddress = (ITTLabel)AddControl(new Guid("3f3b78c8-876b-4b32-9bfe-1e7667df84ea"));
            labelPrivateNo = (ITTLabel)AddControl(new Guid("9260a97e-5cbe-4aa3-959c-1e9b4a5233fb"));
            TaxNumber = (ITTTextBox)AddControl(new Guid("3a263e81-c15e-4823-89e2-1eba08851739"));
            ttlistdefcombobox1 = (ITTListDefComboBox)AddControl(new Guid("2403dcc6-c073-466a-85f8-2c76bd43e1c1"));
            Date = (ITTDateTimePicker)AddControl(new Guid("cf0a70a0-1257-4b2d-a179-18f796ce81cf"));
            OrderNo = (ITTTextBox)AddControl(new Guid("3eb5ecae-b1aa-4908-9cad-175a7eef7cce"));
            labelOperationType = (ITTLabel)AddControl(new Guid("c12ae773-25e2-4a72-a6cc-ca796c9555e4"));
            TotalAmount = (ITTTextBox)AddControl(new Guid("49e36bf0-f8ac-4f41-b2d9-f056f51da317"));
            base.InitializeControls();
        }

        public DecisionStampTaxInfoForm() : base("MHSDECISIONSTAMPTAXINFO", "DecisionStampTaxInfoForm")
        {
        }

        protected DecisionStampTaxInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}