
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
    /// Tetkik Birimi Tanımı
    /// </summary>
    public partial class ObservationUnitDepartmentDefinitionForm : TTForm
    {
    /// <summary>
    /// Tetkik Birimi
    /// </summary>
        protected TTObjectClasses.ResObservationUnit _ResObservationUnit
        {
            get { return (TTObjectClasses.ResObservationUnit)_ttObject; }
        }

        protected ITTLabel labelResourceEndTime;
        protected ITTDateTimePicker ResourceEndTime;
        protected ITTLabel labelResourceStartTime;
        protected ITTDateTimePicker ResourceStartTime;
        protected ITTCheckBox IsmedicalWasteResSection;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox textContactPhone;
        protected ITTTextBox textContactAddress;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTLabel labelStore;
        protected ITTObjectListBox Store;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox ObservationDepartment;
        protected ITTGrid ResourceSpecialities;
        protected ITTListBoxColumn Speciality;
        protected ITTLabel ttlabel3;
        protected ITTCheckBox NotChargeHCExaminationPrice;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel6;
        protected ITTCheckBox DontShowHCDepartmentReport;
        protected ITTCheckBox ttcheckbox1;
        protected ITTCheckBox ttcheckbox2;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        override protected void InitializeControls()
        {
            labelResourceEndTime = (ITTLabel)AddControl(new Guid("2e491465-62c7-4c83-9b15-e7734946137c"));
            ResourceEndTime = (ITTDateTimePicker)AddControl(new Guid("67a00837-7e83-4ddd-b606-f4826b9e99b6"));
            labelResourceStartTime = (ITTLabel)AddControl(new Guid("df0ae1d6-f0bd-4789-898a-7999ca0d6cf2"));
            ResourceStartTime = (ITTDateTimePicker)AddControl(new Guid("5c596126-c711-46a3-8ca7-c26d0a625983"));
            IsmedicalWasteResSection = (ITTCheckBox)AddControl(new Guid("94f5214a-df4a-48c8-a9db-3e278dabddaa"));
            Qref = (ITTTextBox)AddControl(new Guid("383e430b-a5a1-4326-b04c-02ff98949c17"));
            Name = (ITTTextBox)AddControl(new Guid("f3a3fad6-e2c3-4f58-ae42-23d1d8b69b2c"));
            textContactPhone = (ITTTextBox)AddControl(new Guid("4d8c52e8-a112-4c6a-aece-d109c52c5e48"));
            textContactAddress = (ITTTextBox)AddControl(new Guid("1c3a2e05-9b4f-4173-bb44-a06054970daa"));
            Location = (ITTTextBox)AddControl(new Guid("9911a41e-96f0-42bd-a8be-4c9bf7b173de"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("a0bf3593-02a3-4690-9f76-e178c61fc7ba"));
            labelQref = (ITTLabel)AddControl(new Guid("b03ca9d8-c5d1-4dca-87c0-507553098e3d"));
            labelName = (ITTLabel)AddControl(new Guid("bb96568c-1c9e-4585-b09f-846e46a5f078"));
            labelStore = (ITTLabel)AddControl(new Guid("f8abdd1d-a320-4fb8-85e4-c68d8e65cfcc"));
            Store = (ITTObjectListBox)AddControl(new Guid("b6419675-7af6-4276-b14e-9d1e886214d0"));
            IsActive = (ITTCheckBox)AddControl(new Guid("ea04be4d-69f2-4e2b-a232-8e3b8436ee60"));
            labelDepartment = (ITTLabel)AddControl(new Guid("bddb7fec-2765-4b4c-8d1b-624e705ba334"));
            ObservationDepartment = (ITTObjectListBox)AddControl(new Guid("16c2c14e-fb47-4368-bca4-111be444665a"));
            ResourceSpecialities = (ITTGrid)AddControl(new Guid("e6c8456b-cceb-48b6-a739-e4910536cf6d"));
            Speciality = (ITTListBoxColumn)AddControl(new Guid("34c9ba50-67b9-49d4-9230-ac1eae55e669"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("04e2b0c8-0d52-4f32-8053-1adced328d7c"));
            NotChargeHCExaminationPrice = (ITTCheckBox)AddControl(new Guid("736b2dff-9814-4d85-862a-e69f5461036c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("dba7b413-b92f-4ff4-94ac-9439c4d11836"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("53aa5f9a-3a27-4abe-907d-54262ca320cb"));
            DontShowHCDepartmentReport = (ITTCheckBox)AddControl(new Guid("37bc797a-2ecc-4a72-bc55-812b2ba47d4c"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("48375c08-2b7f-4f8f-ac05-6cf29165f393"));
            ttcheckbox2 = (ITTCheckBox)AddControl(new Guid("16c764ac-7fc9-4bc8-8e34-ad0227c759b7"));
            labelLocation = (ITTLabel)AddControl(new Guid("63f522ca-5eff-42b0-a683-db028c5be034"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("06a1eee5-cbef-46d2-a295-1cc997742fee"));
            base.InitializeControls();
        }

        public ObservationUnitDepartmentDefinitionForm() : base("RESOBSERVATIONUNIT", "ObservationUnitDepartmentDefinitionForm")
        {
        }

        protected ObservationUnitDepartmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}