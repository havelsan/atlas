
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
    /// Terhisli Erbaş/Er (Özel Statülü)  Kabülü
    /// </summary>
    public partial class PA_DischargedPrivateForm : PatientAdmissionForm
    {
    /// <summary>
    /// Terhisli Erbaş/Er (Özel Statülü) Kabul 
    /// </summary>
        protected TTObjectClasses.PA_DischargedPrivate _PA_DischargedPrivate
        {
            get { return (TTObjectClasses.PA_DischargedPrivate)_ttObject; }
        }

        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel3;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel ttlabel4;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelRetirementFundID;
        protected ITTDateTimePicker ServisEndTime;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTLabel ttlabel2;
        protected ITTTextBox HealtSlipNumber;
        protected ITTObjectListBox ttobjectlistboxForcesCommand;
        protected ITTLabel ttlabel5;
        protected ITTLabel labelMilitaryOffice;
        protected ITTObjectListBox MilitaryOffice;
        protected ITTLabel labelSenderChair;
        protected ITTObjectListBox SenderChair;
        override protected void InitializeControls()
        {
            tttextbox1 = (ITTTextBox)AddControl(new Guid("2cd410c2-f371-43d1-a01e-16d976466344"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("3bbf564d-0dfd-4c40-84ef-bd86890506af"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("f2eb709e-5c2b-4aa2-9d05-9b1b75ca8b72"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("69a05cb7-e011-48ef-a284-9b4ebfa25331"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("78b9ddeb-d271-4ef9-a95f-4617cf435dd4"));
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("8d304a21-43fb-4947-bd4d-f5722a15d0cb"));
            ServisEndTime = (ITTDateTimePicker)AddControl(new Guid("b7abfcef-6182-4e59-b409-fa80e25bb85f"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("8ddff03d-7b6e-4b74-8b8f-46cbc4ff532a"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("85f1d853-a799-4024-9c4e-84d69be0720b"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("cceb3d4d-1b37-45a0-ae51-a013e7f23513"));
            ttobjectlistboxForcesCommand = (ITTObjectListBox)AddControl(new Guid("45d0f28b-b7c6-4810-acb7-78b01c1c0529"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("c685fae4-4c64-48ff-b5ea-c73f553799b1"));
            labelMilitaryOffice = (ITTLabel)AddControl(new Guid("7800e6e0-6ef7-40b3-a58a-0dd946851e2c"));
            MilitaryOffice = (ITTObjectListBox)AddControl(new Guid("b6db4b1d-f30d-4318-b56e-81e701a4ea97"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("2ef2a36c-080c-4ebf-9c82-930aa1b42f97"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("7e71d058-d064-423d-b2b0-ae2062c56987"));
            base.InitializeControls();
        }

        public PA_DischargedPrivateForm() : base("PA_DISCHARGEDPRIVATE", "PA_DischargedPrivateForm")
        {
        }

        protected PA_DischargedPrivateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}