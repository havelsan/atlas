
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
    /// Emekli XXXXXX Kabülü
    /// </summary>
    public partial class PA_MilitaryRetiredForm : PatientAdmissionForm
    {
    /// <summary>
    /// Emekli XXXXXX
    /// </summary>
        protected TTObjectClasses.PA_MilitaryRetired _PA_MilitaryRetired
        {
            get { return (TTObjectClasses.PA_MilitaryRetired)_ttObject; }
        }

        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelProtocol;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelCity;
        protected ITTLabel labelFoundation;
        protected ITTObjectListBox PayerCity;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox Payer;
        protected ITTObjectListBox Protocol;
        protected ITTTextBox DocumentNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox MilitaryClass;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelMilitaryClass;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox Rank;
        protected ITTTextBox RetirementFundID;
        override protected void InitializeControls()
        {
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("d1355dfc-3bf0-4c15-ab77-82b62a262717"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("0d495d79-a6f9-42f6-bfa8-1a174f97fe56"));
            labelProtocol = (ITTLabel)AddControl(new Guid("348eb734-eb6a-49ab-85dc-1788b202cf0d"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("b12008e4-495f-48fb-8077-2bf02095f7d6"));
            labelCity = (ITTLabel)AddControl(new Guid("038d5718-bbf9-4b41-b6fa-e14175354195"));
            labelFoundation = (ITTLabel)AddControl(new Guid("69ef29ad-c86b-44b5-a9ec-adc3b1fe6247"));
            PayerCity = (ITTObjectListBox)AddControl(new Guid("82fd0231-344a-4aab-80a5-ad8cb51f2e2c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("46cc9b7e-2fb0-4cac-8f22-37e7a267053e"));
            Payer = (ITTObjectListBox)AddControl(new Guid("7a18fe0a-5c81-400b-8f60-8d04bcc368bf"));
            Protocol = (ITTObjectListBox)AddControl(new Guid("8cc7726a-60f8-42a8-b93e-ba9415bf0fa6"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("c72050ef-843e-48bf-aaf3-8b8e02ec7e97"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("33439e2b-8a9d-4d58-b445-2f6cb82f2e27"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("2101efce-1666-471b-80d6-6cec03d9dcac"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("11281463-f0cf-4b60-bb5c-6fc942f83d9c"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("cff36d41-f3cd-4ec1-b794-07b5b6bbbe8e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d5e26a60-bba9-458b-94b5-fbf370bd4cfe"));
            Rank = (ITTObjectListBox)AddControl(new Guid("2c015656-584e-4096-8a5c-5f0f0b36c6bd"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("da2f8bef-c930-437a-8d81-c4f2d0868a34"));
            base.InitializeControls();
        }

        public PA_MilitaryRetiredForm() : base("PA_MILITARYRETIRED", "PA_MilitaryRetiredForm")
        {
        }

        protected PA_MilitaryRetiredForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}