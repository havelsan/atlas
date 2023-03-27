
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
    /// Sevk Eri Kabulü
    /// </summary>
    public partial class PA_ConsignmentPrivateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Sevk Eri Kabul 
    /// </summary>
        protected TTObjectClasses.PA_ConsignmentPrivate _PA_ConsignmentPrivate
        {
            get { return (TTObjectClasses.PA_ConsignmentPrivate)_ttObject; }
        }

        protected ITTLabel labelMilitaryNo;
        protected ITTTextBox MilitaryNo;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox HealtSlipNumber;
        protected ITTDateTimePicker DocumentDate;
        protected ITTLabel labelForcesCommand;
        protected ITTObjectListBox ForcesCommand;
        protected ITTTextBox ConscriptionPeriod;
        protected ITTLabel labelEnteranceTime;
        protected ITTLabel labelMilitaryOffice;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelFoundation;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelConscriptionPeriod;
        protected ITTDateTimePicker MilitaryAcceptanceTime;
        protected ITTLabel labelSenderChair;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelDocumentDate;
        override protected void InitializeControls()
        {
            labelMilitaryNo = (ITTLabel)AddControl(new Guid("cd88d1ae-7db5-44ef-b5da-bf3cb08fa144"));
            MilitaryNo = (ITTTextBox)AddControl(new Guid("0e841c92-2d9a-4677-b70b-04a0fec8eed3"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("cbaebd3e-eb50-4ff8-ae4b-debfe93838d0"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("4fe4305c-a938-4b98-b3c8-db4f4564e371"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("124a023f-0037-4961-8599-1e6a8b66eca3"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("03ea9953-82d3-4a07-af97-b458c0b38b81"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("39a791ed-b498-4e6c-bafb-dae98da4f38e"));
            ConscriptionPeriod = (ITTTextBox)AddControl(new Guid("cca2df00-9b05-4f74-9075-25b0a375b42b"));
            labelEnteranceTime = (ITTLabel)AddControl(new Guid("1e6cbe36-b7fc-4b62-b28e-2d0b889ef4db"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("8d8fdd2d-676f-47e2-8238-54d5e61c9e6c"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("80b82acb-a435-439c-8fda-5a571165d642"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("e9ba41e5-e11e-4b12-ae82-5babb0db5364"));
            labelFoundation = (ITTLabel)AddControl(new Guid("3842291d-21cf-4c78-b40e-801d198fc117"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("27b78613-d8fb-4cb6-9afa-b01b411e9938"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("5110424d-8884-4ac9-a047-b7d35f9f3d6b"));
            labelConscriptionPeriod = (ITTLabel)AddControl(new Guid("d8c0cc6c-1aa3-49fb-aa28-bbe7d41f80ea"));
            MilitaryAcceptanceTime = (ITTDateTimePicker)AddControl(new Guid("a4fd93e6-d406-440b-bb1d-c2927c53744c"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("364c67b2-c157-443d-89ac-f2b6b46af4a5"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("9c5e13a7-6cc5-42d3-b8d8-f9f989a511b2"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("3617bb10-7163-4a6f-8418-ff0847205f7e"));
            base.InitializeControls();
        }

        public PA_ConsignmentPrivateForm() : base("PA_CONSIGNMENTPRIVATE", "PA_ConsignmentPrivateForm")
        {
        }

        protected PA_ConsignmentPrivateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}