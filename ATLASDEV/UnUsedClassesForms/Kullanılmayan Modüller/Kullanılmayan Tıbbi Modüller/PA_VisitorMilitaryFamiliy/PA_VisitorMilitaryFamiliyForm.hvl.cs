
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
    /// Misafir XXXXXX Personel Ailesi Kabulü
    /// </summary>
    public partial class PA_VisitorMilitaryFamiliyForm : PatientAdmissionForm
    {
    /// <summary>
    /// Misafir XXXXXX Personel Ailesi
    /// </summary>
        protected TTObjectClasses.PA_VisitorMilitaryFamiliy _PA_VisitorMilitaryFamiliy
        {
            get { return (TTObjectClasses.PA_VisitorMilitaryFamiliy)_ttObject; }
        }

        protected ITTGroupBox FamiliyInfo;
        protected ITTLabel ttlabel3;
        protected ITTTextBox HeadOfFamilyName;
        protected ITTLabel ttlabel5;
        protected ITTMaskedTextBox HeadOfFamtxt;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTLabel labelVisitingReason;
        protected ITTEnumComboBox VisitingReason;
        protected ITTLabel labelCountry;
        protected ITTObjectListBox Country;
        protected ITTTextBox HealtSlipNumber;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel6;
        protected ITTTextBox DocumentNumber;
        protected ITTObjectListBox Relationship;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel ttlabel10;
        override protected void InitializeControls()
        {
            FamiliyInfo = (ITTGroupBox)AddControl(new Guid("deae2cd0-0506-465e-978d-101fc0979bb1"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("d846967b-da7c-4dd9-8c32-98fc2e7ec1c8"));
            HeadOfFamilyName = (ITTTextBox)AddControl(new Guid("d0824159-3815-4079-907a-5c4383f824c5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("2752a7b4-e19f-49f2-bcfc-fbe5bc0081c0"));
            HeadOfFamtxt = (ITTMaskedTextBox)AddControl(new Guid("6bdf553b-71b2-4476-b3cb-7724b254fd16"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("7b08ac60-769a-4f8d-b2bc-9c345cd9ca90"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2b77fbc2-e95a-4b6e-8d2f-d33af7f5c1c6"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("c5331f66-0aa3-499e-a69f-b9f304f4dac6"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("1f27c0ad-40f4-42a3-8426-345fddb955b7"));
            labelVisitingReason = (ITTLabel)AddControl(new Guid("6bcc8350-91ca-48d2-bbd8-273b6d928f49"));
            VisitingReason = (ITTEnumComboBox)AddControl(new Guid("e5d1329c-15e2-43cc-a10c-e7561af7f800"));
            labelCountry = (ITTLabel)AddControl(new Guid("508909e5-69b9-46c9-8ea7-729a9cb83186"));
            Country = (ITTObjectListBox)AddControl(new Guid("325e1dcd-43d2-4188-a39d-1a6f981310f9"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("1276d023-10e9-4a17-828d-bf7f557cb449"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("db686fa0-b23b-46e2-97d7-65e2d2f1cae1"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("1f790c24-d9c7-4ca3-a2b5-6625778a6063"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("0ac448fb-a568-4aa5-b560-f11e71adeef6"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("df78c5f8-9c7e-4c0a-9ff5-014c9c9bf0e5"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("24d48fef-6ab4-4a0c-b1ba-03ba41aef2b7"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("d521a1cb-4c8c-4c2d-8100-b23b86ffd68e"));
            Relationship = (ITTObjectListBox)AddControl(new Guid("4757e7ae-f13e-4ddf-80fe-146ad60d6413"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("fa0c1c0d-cea2-424b-95eb-a56e5184c067"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("983f1327-297e-404c-a31b-7b2640d85b5c"));
            base.InitializeControls();
        }

        public PA_VisitorMilitaryFamiliyForm() : base("PA_VISITORMILITARYFAMILIY", "PA_VisitorMilitaryFamiliyForm")
        {
        }

        protected PA_VisitorMilitaryFamiliyForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}