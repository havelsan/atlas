
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
    /// Randevu Tanımlama
    /// </summary>
    public partial class AppointmentDefinitionForm : TTDefinitionForm
    {
        protected TTObjectClasses.AppointmentDefinition _AppointmentDefinition
        {
            get { return (TTObjectClasses.AppointmentDefinition)_ttObject; }
        }

        protected ITTCheckBox SentToMHRS;
        protected ITTTextBox txtFormDefID;
        protected ITTTextBox AppointmentDefinitionID;
        protected ITTComboBox cbFormDef;
        protected ITTEnumComboBox AppointmentDefinitionName;
        protected ITTLabel labelAppointmentCarriers;
        protected ITTGrid AppointmentCarriers;
        protected ITTCheckBoxColumn IsDefault;
        protected ITTTextBoxColumn CarrierName;
        protected ITTTextBoxColumn MasterResource;
        protected ITTTextBoxColumn MasterResourceCaption;
        protected ITTTextBoxColumn SubResource;
        protected ITTTextBoxColumn SubResourceCaption;
        protected ITTTextBoxColumn RelationParentName;
        protected ITTTextBoxColumn AppointmentCount;
        protected ITTTextBoxColumn AppointmentDuration;
        protected ITTTextBoxColumn MasterResourceFilter;
        protected ITTLabel labelReasonForAdmission;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTCheckBox StateOnly;
        protected ITTLabel labelAppointmentDefinitionName;
        protected ITTLabel labelAppointmentDefinitionID;
        protected ITTGrid AppointmentDefinitionRolesGrid;
        protected ITTComboBoxColumn Role;
        protected ITTTextBoxColumn RoleID;
        protected ITTEnumComboBoxColumn RightType;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox GiveToMaster;
        protected ITTCheckBox OverlapAllowed;
        protected ITTCheckBox ScheduleOverlapAllowed;
        protected ITTCheckBox GiveFromResource;
        protected ITTLabel ttlabel2;
        protected ITTCheckBox IsActive;
        protected ITTCheckBox IsDescReqForNonScheduledApps;
        override protected void InitializeControls()
        {
            SentToMHRS = (ITTCheckBox)AddControl(new Guid("b2c1cc38-1575-4d99-ab30-2cd3e06edbda"));
            txtFormDefID = (ITTTextBox)AddControl(new Guid("1fcff0cb-1c11-41ec-96d0-40e0b1f8cc28"));
            AppointmentDefinitionID = (ITTTextBox)AddControl(new Guid("332df73c-399a-47b2-8b91-51a6f9defa62"));
            cbFormDef = (ITTComboBox)AddControl(new Guid("18124203-cb14-486d-90ef-7f3742b41d81"));
            AppointmentDefinitionName = (ITTEnumComboBox)AddControl(new Guid("6dcccc16-661d-44fa-873d-4492edbff210"));
            labelAppointmentCarriers = (ITTLabel)AddControl(new Guid("1cb04dac-13f3-4dae-8331-6dadc0ad505b"));
            AppointmentCarriers = (ITTGrid)AddControl(new Guid("56c415e7-970c-4484-9b8a-6a69b5d7924d"));
            IsDefault = (ITTCheckBoxColumn)AddControl(new Guid("5e88c04b-86f4-4ba4-b0d9-2aa39edffc2b"));
            CarrierName = (ITTTextBoxColumn)AddControl(new Guid("83ecfc9c-6cf4-412e-9094-c5b4ed486bd2"));
            MasterResource = (ITTTextBoxColumn)AddControl(new Guid("bfdb0757-151d-4740-bca5-fcf7d1aebd68"));
            MasterResourceCaption = (ITTTextBoxColumn)AddControl(new Guid("5af94784-2dd6-446d-b22e-0e8d523ffb01"));
            SubResource = (ITTTextBoxColumn)AddControl(new Guid("f69370f1-ec7c-495a-8a25-75f9acda1e6a"));
            SubResourceCaption = (ITTTextBoxColumn)AddControl(new Guid("67114721-0661-42cf-bcf7-5e3053fb5e87"));
            RelationParentName = (ITTTextBoxColumn)AddControl(new Guid("634b23f7-093e-4b65-b6b9-edec6ba486cb"));
            AppointmentCount = (ITTTextBoxColumn)AddControl(new Guid("5f911077-22f0-403d-b446-a912b6daf8ed"));
            AppointmentDuration = (ITTTextBoxColumn)AddControl(new Guid("4cd05272-1d47-4fb5-95fb-ad61acbb8a03"));
            MasterResourceFilter = (ITTTextBoxColumn)AddControl(new Guid("e37adce9-87e7-4392-8636-3c32826d70f5"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("d5be5569-e70d-4201-a33e-286046c484bd"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("9684cdcd-45d7-46ee-8a13-aaf43754a962"));
            StateOnly = (ITTCheckBox)AddControl(new Guid("c9055e56-2ba9-44b5-a6e9-50807a4ea7f2"));
            labelAppointmentDefinitionName = (ITTLabel)AddControl(new Guid("0a0b856f-bb87-4fd0-a6d8-61a388819873"));
            labelAppointmentDefinitionID = (ITTLabel)AddControl(new Guid("a75283e9-eac4-48ec-820b-37228301592c"));
            AppointmentDefinitionRolesGrid = (ITTGrid)AddControl(new Guid("57d4f758-e626-476b-8a33-41fb80b681b4"));
            Role = (ITTComboBoxColumn)AddControl(new Guid("182a23bb-6f29-47cd-9ed3-aeb2e9256e9a"));
            RoleID = (ITTTextBoxColumn)AddControl(new Guid("1bf23022-f10b-4990-9a12-66d8fccda276"));
            RightType = (ITTEnumComboBoxColumn)AddControl(new Guid("a3cb63de-577d-4911-b349-06dc0ca09a9a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("998d2984-ebea-4e1b-8daa-d2f8cf7622a9"));
            GiveToMaster = (ITTCheckBox)AddControl(new Guid("9a843380-94e9-4fbd-815b-3ff932fb1ad5"));
            OverlapAllowed = (ITTCheckBox)AddControl(new Guid("c29a7ed7-877c-4b15-9025-0c6314da0e24"));
            ScheduleOverlapAllowed = (ITTCheckBox)AddControl(new Guid("9f498d3b-6779-4a8a-b86d-7dbeab9c40fc"));
            GiveFromResource = (ITTCheckBox)AddControl(new Guid("8e118714-7ca2-4814-86df-260706b382b2"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("957b97cf-d64a-4022-b93f-0a29c2166f02"));
            IsActive = (ITTCheckBox)AddControl(new Guid("9ebe8ad7-0515-4a2b-ae4b-8b9b431c3dc4"));
            IsDescReqForNonScheduledApps = (ITTCheckBox)AddControl(new Guid("8292533d-2083-4b6d-a62a-6f66f6745513"));
            base.InitializeControls();
        }

        public AppointmentDefinitionForm() : base("APPOINTMENTDEFINITION", "AppointmentDefinitionForm")
        {
        }

        protected AppointmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}