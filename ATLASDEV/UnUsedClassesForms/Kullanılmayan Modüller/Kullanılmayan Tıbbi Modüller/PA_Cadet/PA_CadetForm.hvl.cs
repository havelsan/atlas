
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
    /// XXXXXX Öğrenci Kabulü
    /// </summary>
    public partial class PA_CadetForm : PatientAdmissionForm
    {
    /// <summary>
    /// XXXXXX Öğrenci Kabul
    /// </summary>
        protected TTObjectClasses.PA_Cadet _PA_Cadet
        {
            get { return (TTObjectClasses.PA_Cadet)_ttObject; }
        }

        protected ITTLabel labelRetirementFundID;
        protected ITTTextBox RetirementFundID;
        protected ITTLabel labelSenderChair;
        protected ITTTextBox EmploymentRecordID;
        protected ITTLabel labelHealtSlipNumber;
        protected ITTTextBox DocumentNumber;
        protected ITTLabel labelDocumentNumber;
        protected ITTLabel labelMilitaryClass;
        protected ITTObjectListBox MilitaryClass;
        protected ITTDateTimePicker DocumentDate;
        protected ITTObjectListBox SenderChair;
        protected ITTLabel labelDocumentDate;
        protected ITTLabel labelEmploymentRecordID;
        protected ITTTextBox HealtSlipNumber;
        protected ITTTextBox Academy;
        protected ITTLabel labelForcesCommand;
        protected ITTLabel labelAcademy;
        protected ITTObjectListBox ForcesCommand;
        override protected void InitializeControls()
        {
            labelRetirementFundID = (ITTLabel)AddControl(new Guid("615ef72e-3f72-424c-b5b5-d13febd9b162"));
            RetirementFundID = (ITTTextBox)AddControl(new Guid("6e2ad46b-5e7f-4159-8bc4-824234031484"));
            labelSenderChair = (ITTLabel)AddControl(new Guid("3290af87-34e8-41f8-9e61-05d582706cdd"));
            EmploymentRecordID = (ITTTextBox)AddControl(new Guid("c7f7ee17-78fa-4868-b1e0-0d0557e5303f"));
            labelHealtSlipNumber = (ITTLabel)AddControl(new Guid("386d0d98-de0d-47b9-88d0-156c4a88be3d"));
            DocumentNumber = (ITTTextBox)AddControl(new Guid("fc99aeb3-03de-4c7a-925c-18b4755e2b64"));
            labelDocumentNumber = (ITTLabel)AddControl(new Guid("1520dd1a-b499-4d12-a294-1c24b0cbb82b"));
            labelMilitaryClass = (ITTLabel)AddControl(new Guid("bfff1bce-ade6-46e0-8ad7-34dde139ffec"));
            MilitaryClass = (ITTObjectListBox)AddControl(new Guid("f9f5fd9d-1b55-471f-ae71-34ee59ba299c"));
            DocumentDate = (ITTDateTimePicker)AddControl(new Guid("5830fb05-c564-4345-ad0d-3aff4a994c0b"));
            SenderChair = (ITTObjectListBox)AddControl(new Guid("cdf286c1-7325-47e7-8ac0-3e1222872da8"));
            labelDocumentDate = (ITTLabel)AddControl(new Guid("8277778b-0a0a-476c-bdbb-750ccc80b134"));
            labelEmploymentRecordID = (ITTLabel)AddControl(new Guid("833244f5-c074-42e1-a83b-84a7a8e2d9e2"));
            HealtSlipNumber = (ITTTextBox)AddControl(new Guid("eeb6885b-2563-4929-80b4-9e6316c822c2"));
            Academy = (ITTTextBox)AddControl(new Guid("2e6393ac-6972-420e-9ffa-9fc01e564cd6"));
            labelForcesCommand = (ITTLabel)AddControl(new Guid("44bba094-f40e-439f-a088-c9f43189fa97"));
            labelAcademy = (ITTLabel)AddControl(new Guid("1f3e27a8-eee2-41bc-bb8e-dba9d4492279"));
            ForcesCommand = (ITTObjectListBox)AddControl(new Guid("bfcf2380-bb9b-4944-aa56-de23e69df1c4"));
            base.InitializeControls();
        }

        public PA_CadetForm() : base("PA_CADET", "PA_CadetForm")
        {
        }

        protected PA_CadetForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}