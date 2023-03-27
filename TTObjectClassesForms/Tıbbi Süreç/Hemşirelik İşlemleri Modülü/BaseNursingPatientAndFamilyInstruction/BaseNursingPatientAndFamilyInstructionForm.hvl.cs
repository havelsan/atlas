
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
    public partial class BaseNursingPatientAndFamilyInstructionForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Hasta Eğitim Formu
    /// </summary>
        protected TTObjectClasses.BaseNursingPatientAndFamilyInstruction _BaseNursingPatientAndFamilyInstruction
        {
            get { return (TTObjectClasses.BaseNursingPatientAndFamilyInstruction)_ttObject; }
        }

        protected ITTCheckBox CompanionInstruction;
        protected ITTLabel labelInstructionNote;
        protected ITTTextBox InstructionNote;
        protected ITTGrid NursingPatientAndFamilyInstructions;
        protected ITTListBoxColumn PatientAndFamilyInstructionNursingPatientAndFamilyInstruction;
        protected ITTCheckBoxColumn CompanionGetInstructionNursingPatientAndFamilyInstruction;
        protected ITTCheckBoxColumn PatientGetInstructionNursingPatientAndFamilyInstruction;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        override protected void InitializeControls()
        {
            CompanionInstruction = (ITTCheckBox)AddControl(new Guid("159ee54d-22c3-4ae2-98ae-075038c38648"));
            labelInstructionNote = (ITTLabel)AddControl(new Guid("b8ff8a38-b485-4bd5-b9d7-289971bac283"));
            InstructionNote = (ITTTextBox)AddControl(new Guid("c75b7516-48da-4b1e-a5a1-ee2fd21ef491"));
            NursingPatientAndFamilyInstructions = (ITTGrid)AddControl(new Guid("6837a7ec-f03b-4c8d-aba5-ac4a6079ef70"));
            PatientAndFamilyInstructionNursingPatientAndFamilyInstruction = (ITTListBoxColumn)AddControl(new Guid("33f5e6eb-4f99-4c2f-96c4-2c5c09daee35"));
            CompanionGetInstructionNursingPatientAndFamilyInstruction = (ITTCheckBoxColumn)AddControl(new Guid("5b6deeb9-bb27-4223-bba1-afa2f69c7aa9"));
            PatientGetInstructionNursingPatientAndFamilyInstruction = (ITTCheckBoxColumn)AddControl(new Guid("40b8a2d3-f461-4bfa-a9d3-b64fed425bab"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("5140633c-8b35-4fad-b4ff-e61721ba8df0"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("de6eab4a-6224-4846-93e2-3b8b0eeb886a"));
            base.InitializeControls();
        }

        public BaseNursingPatientAndFamilyInstructionForm() : base("BASENURSINGPATIENTANDFAMILYINSTRUCTION", "BaseNursingPatientAndFamilyInstructionForm")
        {
        }

        protected BaseNursingPatientAndFamilyInstructionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}