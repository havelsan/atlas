
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
    /// Sivil Emekli Kabulü
    /// </summary>
    public partial class PA_RetiredCivilianForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sivil Emekli Kabul 
    /// </summary>
        protected TTObjectClasses.PA_RetiredCivilian _PA_RetiredCivilian
        {
            get { return (TTObjectClasses.PA_RetiredCivilian)_ttObject; }
        }

        protected ITTCheckBox chkIsSGKPatient;
        protected ITTObjectListBox Protocol;
        protected ITTObjectListBox PayerCity;
        protected ITTObjectListBox Payer;
        protected ITTLabel labelProtocol;
        protected ITTLabel labelCity;
        protected ITTLabel labelPayer;
        protected ITTCheckBox IsRelativeOfSoldier;
        protected ITTLabel labelRelationship;
        protected ITTObjectListBox Relationship;
        protected ITTLabel labelHeadOfFamilyName;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel lblHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel lblRetirementFundID;
        protected ITTTextBox RetirementFundID;
        override protected void InitializeControls()
        {
            chkIsSGKPatient = (ITTCheckBox)AddControl(new Guid("4a6b2915-8e1c-472b-8269-298b15d2ad52"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("02542337-2b26-43d6-a351-bfc81129d10f"));
            PayerCity = (ITTObjectListBox)AddControl(new Guid("b4677b06-8d53-4258-80be-05f91d9b4a7a"));
            Payer = (ITTObjectListBox)AddControl(new Guid("d9544dbe-0faf-4830-a2e1-e1381f885be9"));
            labelProtocol = (ITTLabel)AddControl(new Guid("4ae4f5ef-70ec-4d59-8f2e-3310e7961e63"));
            labelCity = (ITTLabel)AddControl(new Guid("874b2666-e816-4bca-97b9-bb3eaca8ab53"));
            labelPayer = (ITTLabel)AddControl(new Guid("ef2f95ad-3cd3-446e-a25c-5d76424a17d4"));
            IsRelativeOfSoldier = (ITTCheckBox)AddControl(new Guid("c28ed556-5382-4a5f-9924-af937b6c6964"));
            labelRelationship = (ITTLabel)AddControl(new Guid("0fe9b66d-2585-47bf-bbd0-0fbecfcfb558"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("bb13afcf-b8f7-40a7-9d7f-358f1a102657"));
            labelHeadOfFamilyName = (ITTLabel)AddControl(new Guid("49eb5b9c-5029-41df-83e2-c9ccc6c0da69"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("e9a00e66-9984-4f08-a196-77169e4ff856"));
            lblHealtSlipNumber = (ITTLabel)AddControl(new Guid("16068644-f5cf-4c76-be3e-35ecc8cc1c8a"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("2afc1c6b-fc18-40c1-ae85-38d6261218f3"));
            lblRetirementFundID = (ITTLabel)AddControl(new Guid("bacccf06-f9b3-455a-b89c-8fa9d0e5683e"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("e1800304-f819-4d3f-b669-d0e15777e369"));
            base.InitializeControls();
        }

        public PA_RetiredCivilianForm() : base("PA_RETIREDCIVILIAN", "PA_RetiredCivilianForm")
        {
        }

        protected PA_RetiredCivilianForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}