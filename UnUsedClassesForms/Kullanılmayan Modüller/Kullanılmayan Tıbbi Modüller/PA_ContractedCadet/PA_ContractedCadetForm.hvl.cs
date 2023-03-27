
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
    /// Sözleşmeli XXXXXX Öğrenci Kabul
    /// </summary>
    public partial class PA_ContractedCadetForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sözleşmeli XXXXXX Öğrenci Kabul
    /// </summary>
        protected TTObjectClasses.PA_ContractedCadet _PA_ContractedCadet
        {
            get { return (TTObjectClasses.PA_ContractedCadet)_ttObject; }
        }

        protected ITTLabel labelForcesCommand;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelMilitaryClass;
        protected ITTTextBox Academy;
        protected ITTObjectListBox MilitaryClass;
        protected ITTTextBox HealtSlipNumber;
        protected ITTObjectListBox ForcesCommand;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTLabel labelAcademy;
        protected ITTLabel labelSenderChair;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelDocumentDate;
        override protected void InitializeControls()
        {
            labelForcesCommand = (ITTLabel)AddControl(new Guid("75c6ee00-efe3-4d47-a051-8427810cdfd5"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("788b5886-e317-4e4a-a814-b19cda2b5c34"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("96c9c814-11f5-4cb7-8c0c-fd625df084d0"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("b99ca02d-acc5-48fe-bc3e-76c5bb2f2dd1"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("f6500e02-7629-447a-8812-9502b0222d67"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("2b2d071c-5f27-406f-9025-eee4087098e2"));
            Academy = (ITTTextBox)AddControl(new Guid("d5adb75f-96bf-469f-9350-93686f4504c0"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("ebcb3fc9-b83c-46d8-92a3-e6f246fa7b17"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("bd2a58c9-4490-491f-9afc-7ccaa6c7a459"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("cd767d1e-3939-4444-941e-aaea30ab4de2"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("4466a310-59f6-4c0f-8f6f-6b3ac80bf876"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("0bfb1787-7275-4461-b99e-3ca489064db8"));
            labelAcademy = (ITTLabel)AddControl(new Guid("6eb204fc-b6cb-4fcf-806d-e8f133234336"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("a83a4d55-5ce0-47d5-86b4-029c38138d2e"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("3d0734e0-2861-46de-a799-036a867cef28"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("867fc2b0-e694-4fd0-a31f-6acd510d4951"));
            base.InitializeControls();
        }

        public PA_ContractedCadetForm() : base("PA_CONTRACTEDCADET", "PA_ContractedCadetForm")
        {
        }

        protected PA_ContractedCadetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}