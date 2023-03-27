
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
    public partial class NursingPatientPreAssessmentForm : BaseNursingDataEntryForm
    {
    /// <summary>
    /// Hemşirelik Hizmetleri Hasta Ön Değerlendirmesi
    /// </summary>
        protected TTObjectClasses.NursingPatientPreAssessment _NursingPatientPreAssessment
        {
            get { return (TTObjectClasses.NursingPatientPreAssessment)_ttObject; }
        }

        protected ITTLabel labelWeight;
        protected ITTTextBox Weight;
        protected ITTTextBox Height;
        protected ITTTextBox BloodTransfusionReaction;
        protected ITTTextBox AssistiveDevices;
        protected ITTTextBox PastIllnessesAndOperations;
        protected ITTTextBox HereditaryDiseases;
        protected ITTTextBox WhereThePatientCameFrom;
        protected ITTTextBox ChildCount;
        protected ITTTextBox PatientLanguage;
        protected ITTLabel labelHeight;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelBloodTransfusionReaction;
        protected ITTLabel labelBloodTransfusionPracticed;
        protected ITTEnumComboBox BloodTransfusionPracticed;
        protected ITTLabel labelAssistiveDevices;
        protected ITTLabel labelPastIllnessesAndOperations;
        protected ITTLabel labelHereditaryDiseases;
        protected ITTLabel labelTheWayThePatientArrive;
        protected ITTEnumComboBox TheWayThePatientArrive;
        protected ITTLabel labelWhereThePatientCameFrom;
        protected ITTLabel labelLastRehabDate;
        protected ITTDateTimePicker LastRehabDate;
        protected ITTLabel labelRehabHistory;
        protected ITTEnumComboBox RehabHistory;
        protected ITTLabel labelCauseOfInjury;
        protected ITTEnumComboBox CauseOfInjury;
        protected ITTLabel labelChildCount;
        protected ITTLabel labelPatientLanguage;
        override protected void InitializeControls()
        {
            labelWeight = (ITTLabel)AddControl(new Guid("f3a4ec42-afc9-4424-b9d4-959cd95e72d5"));
            Weight = (ITTTextBox)AddControl(new Guid("337021c3-d4f2-42b0-b5b8-c5e268846f34"));
            Height = (ITTTextBox)AddControl(new Guid("dd477527-c18a-4f1b-8e4b-99181c2fc7ff"));
            BloodTransfusionReaction = (ITTTextBox)AddControl(new Guid("50bf3155-2bab-4a2b-8fac-0bd1fc684d71"));
            AssistiveDevices = (ITTTextBox)AddControl(new Guid("19a9cf09-4c91-4a38-ac08-05fa22ea5b21"));
            PastIllnessesAndOperations = (ITTTextBox)AddControl(new Guid("14d020c7-d45c-4c32-a984-01a983e5541c"));
            HereditaryDiseases = (ITTTextBox)AddControl(new Guid("1af952d6-81ea-4618-ad84-05e7ea9579f2"));
            WhereThePatientCameFrom = (ITTTextBox)AddControl(new Guid("439c5854-13dc-4ec6-8216-c3c77348eaa8"));
            ChildCount = (ITTTextBox)AddControl(new Guid("77c7e3f6-a333-434f-9a3b-56673c6029ec"));
            PatientLanguage = (ITTTextBox)AddControl(new Guid("01decbd8-2536-43ee-a861-ecc17227eaac"));
            labelHeight = (ITTLabel)AddControl(new Guid("d0dec7e3-9680-4694-91e6-9f113d6ab5fe"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("7de7d57e-5a55-455a-9e4e-5460604eccc4"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("6c35b2e0-91ac-4dab-8fda-65d8742e4b06"));
            labelBloodTransfusionReaction = (ITTLabel)AddControl(new Guid("8ea6b210-3a05-4393-98b9-c59f3885f2d0"));
            labelBloodTransfusionPracticed = (ITTLabel)AddControl(new Guid("e5316d4c-1245-4320-a0b7-713a1307a190"));
            BloodTransfusionPracticed = (ITTEnumComboBox)AddControl(new Guid("396cb488-15de-4fe5-91a0-c7b07aba1c26"));
            labelAssistiveDevices = (ITTLabel)AddControl(new Guid("0f81bf6d-2092-41c5-b371-2c9af8fd6a09"));
            labelPastIllnessesAndOperations = (ITTLabel)AddControl(new Guid("25de9677-d1e1-46a7-bd09-3bd4eb67e9b9"));
            labelHereditaryDiseases = (ITTLabel)AddControl(new Guid("80307075-7ffe-4270-bb3f-964b408cf44c"));
            labelTheWayThePatientArrive = (ITTLabel)AddControl(new Guid("6840ac37-d25f-4a28-bc57-77df0b183716"));
            TheWayThePatientArrive = (ITTEnumComboBox)AddControl(new Guid("1146b929-3a3a-446e-9929-f8ad11af233c"));
            labelWhereThePatientCameFrom = (ITTLabel)AddControl(new Guid("53e085f6-2048-4d7e-9775-5f3786c51366"));
            labelLastRehabDate = (ITTLabel)AddControl(new Guid("b18e7b9d-7928-4f9b-8fed-8571d95543a9"));
            LastRehabDate = (ITTDateTimePicker)AddControl(new Guid("5e0f4b99-7c19-4f09-8df2-0c9bd0b86b43"));
            labelRehabHistory = (ITTLabel)AddControl(new Guid("294c5912-b154-4a43-a35c-351b8eb25d43"));
            RehabHistory = (ITTEnumComboBox)AddControl(new Guid("0b0502de-a3ec-439c-a1c9-0f20b117a75c"));
            labelCauseOfInjury = (ITTLabel)AddControl(new Guid("42d0310c-229e-42f1-98ab-570e1efcfaee"));
            CauseOfInjury = (ITTEnumComboBox)AddControl(new Guid("e0f8abb9-39ca-4079-9015-47cbf812fffc"));
            labelChildCount = (ITTLabel)AddControl(new Guid("8803894e-6ca6-44f0-86c6-19a983b9b8ac"));
            labelPatientLanguage = (ITTLabel)AddControl(new Guid("f0d88455-520a-48b9-ba43-d70acc9dff84"));
            base.InitializeControls();
        }

        public NursingPatientPreAssessmentForm() : base("NURSINGPATIENTPREASSESSMENT", "NursingPatientPreAssessmentForm")
        {
        }

        protected NursingPatientPreAssessmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}