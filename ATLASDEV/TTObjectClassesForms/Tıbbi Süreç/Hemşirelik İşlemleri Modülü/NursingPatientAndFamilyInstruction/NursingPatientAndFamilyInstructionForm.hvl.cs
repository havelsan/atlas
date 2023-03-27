
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
    /// Eğitim
    /// </summary>
    public partial class NursingPatientAndFamilyInstructionForm : TTForm
    {
        protected TTObjectClasses.NursingPatientAndFamilyInstruction _NursingPatientAndFamilyInstruction
        {
            get { return (TTObjectClasses.NursingPatientAndFamilyInstruction)_ttObject; }
        }

        protected ITTLabel labelInstructor;
        protected ITTObjectListBox Instructor;
        protected ITTCheckBox CompanionGetInstruction;
        protected ITTCheckBox PatientGetInstruction;
        protected ITTLabel labelPatientAndFamilyInstruction;
        protected ITTObjectListBox PatientAndFamilyInstruction;
        protected ITTLabel labelNote;
        protected ITTTextBox Note;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        override protected void InitializeControls()
        {
            labelInstructor = (ITTLabel)AddControl(new Guid("3f47dc9f-a109-46cc-af77-bc82841e3731"));
            Instructor = (ITTObjectListBox)AddControl(new Guid("925ac7c5-3510-4dd1-9ab7-b8ec535bb97e"));
            CompanionGetInstruction = (ITTCheckBox)AddControl(new Guid("7cea86d3-bc82-421e-8141-98d2ffb2bf58"));
            PatientGetInstruction = (ITTCheckBox)AddControl(new Guid("728c3d37-881b-4559-855a-0d1ccbdd09e4"));
            labelPatientAndFamilyInstruction = (ITTLabel)AddControl(new Guid("5fb8df20-129b-43ef-b79c-5e62f0ecc134"));
            PatientAndFamilyInstruction = (ITTObjectListBox)AddControl(new Guid("d2ae94e9-67b4-4c26-8a88-a9d659345ae5"));
            labelNote = (ITTLabel)AddControl(new Guid("35a58859-a343-4471-869c-3eaf8ac55bfb"));
            Note = (ITTTextBox)AddControl(new Guid("8a477eec-8f89-4aac-854f-f4a8133e6039"));
            labelActionDate = (ITTLabel)AddControl(new Guid("d1dacc5c-34fa-49b4-b2b2-7eea8133d01c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("1421574c-db6e-4232-9ffd-8bd9ccc2bfdd"));
            base.InitializeControls();
        }

        public NursingPatientAndFamilyInstructionForm() : base("NURSINGPATIENTANDFAMILYINSTRUCTION", "NursingPatientAndFamilyInstructionForm")
        {
        }

        protected NursingPatientAndFamilyInstructionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}