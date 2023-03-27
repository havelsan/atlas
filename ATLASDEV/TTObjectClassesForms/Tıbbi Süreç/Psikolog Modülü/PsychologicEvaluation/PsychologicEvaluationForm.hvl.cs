
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
    public partial class PsychologicEvaluationForm : TTForm
    {
    /// <summary>
    /// Psikolojik Değerlendirme Formu
    /// </summary>
        protected TTObjectClasses.PsychologicEvaluation _PsychologicEvaluation
        {
            get { return (TTObjectClasses.PsychologicEvaluation)_ttObject; }
        }

        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelAddedUser;
        protected ITTObjectListBox AddedUser;
        protected ITTRichTextBoxControl Result;
        protected ITTLabel labelResult;
        protected ITTRichTextBoxControl ObservationDiscussionEvalNote;
        protected ITTLabel labelObservationDiscussionEvalNote;
        protected ITTRichTextBoxControl LongTermMemoryFunction;
        protected ITTLabel labelLongTermMemoryFunction;
        protected ITTRichTextBoxControl PersonalPathologyOrDeviation;
        protected ITTLabel labelPersonalPathologyOrDeviation;
        protected ITTRichTextBoxControl PsychopathologicalDisorder;
        protected ITTLabel labelPsychopathologicalDisorder;
        protected ITTRichTextBoxControl SocialEducationRetardationSit;
        protected ITTLabel labelSocialEducationRetardationSit;
        protected ITTRichTextBoxControl IQIntelligenceLevel;
        protected ITTLabel labelIQIntelligenceLevel;
        protected ITTRichTextBoxControl ShortTermMemoryFunction;
        protected ITTLabel labelShortTermMemoryFunction;
        protected ITTRichTextBoxControl MoodDisorder;
        protected ITTLabel labelMoodDisorder;
        protected ITTRichTextBoxControl PsychopathologicalDeviation;
        protected ITTLabel labelPsychopathologicalDeviation;
        protected ITTLabel labelEducationStatus;
        protected ITTObjectListBox EducationStatus;
        protected ITTLabel labelPatientJob;
        protected ITTObjectListBox PatientJob;
        override protected void InitializeControls()
        {
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("4a0c6754-188e-4420-bed3-25c6c9591909"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("7bdd330f-a1a5-4a98-bafd-8c6cc7db0fa7"));
            labelAddedUser = (ITTLabel)AddControl(new Guid("fbb3dbb4-2f5e-445a-9577-ac4bbbe3ff2a"));
            AddedUser = (ITTObjectListBox)AddControl(new Guid("1045895a-d5ac-4314-a23e-b76b4f53079e"));
            Result = (ITTRichTextBoxControl)AddControl(new Guid("36c8f501-d42e-4433-ae07-c58d8306278b"));
            labelResult = (ITTLabel)AddControl(new Guid("dc1cb3bf-8c10-451c-8a59-79bef2d2f967"));
            ObservationDiscussionEvalNote = (ITTRichTextBoxControl)AddControl(new Guid("b3e9eb8f-5632-47f5-87ce-e6f03c625994"));
            labelObservationDiscussionEvalNote = (ITTLabel)AddControl(new Guid("96e4bf73-686d-4454-85bf-b45ca7316229"));
            LongTermMemoryFunction = (ITTRichTextBoxControl)AddControl(new Guid("8b06d436-6b8c-485b-880f-22d72e5ccb19"));
            labelLongTermMemoryFunction = (ITTLabel)AddControl(new Guid("b34617a8-dd5e-455f-b420-4ee1096eb17f"));
            PersonalPathologyOrDeviation = (ITTRichTextBoxControl)AddControl(new Guid("ac6d52cd-b4e9-4c22-bea5-a7fbfb15dc90"));
            labelPersonalPathologyOrDeviation = (ITTLabel)AddControl(new Guid("98b95824-77b7-454a-8e1c-dfe7b0d78ddd"));
            PsychopathologicalDisorder = (ITTRichTextBoxControl)AddControl(new Guid("1748f93f-bc70-4caa-85e8-bb1f98758263"));
            labelPsychopathologicalDisorder = (ITTLabel)AddControl(new Guid("14a28a3f-477b-4a34-830a-bae484ead74b"));
            SocialEducationRetardationSit = (ITTRichTextBoxControl)AddControl(new Guid("d0f96659-00ee-41b1-90a6-640d6fa2ff16"));
            labelSocialEducationRetardationSit = (ITTLabel)AddControl(new Guid("38cd6439-02b2-49df-a15c-cdcde801e026"));
            IQIntelligenceLevel = (ITTRichTextBoxControl)AddControl(new Guid("ad453f09-3037-47c9-8a27-6d3217f9a15f"));
            labelIQIntelligenceLevel = (ITTLabel)AddControl(new Guid("7b7bd46e-ca8a-4ee1-a4c5-db8dcd761b9e"));
            ShortTermMemoryFunction = (ITTRichTextBoxControl)AddControl(new Guid("e2394109-b471-43e4-adde-0fb38f87b67b"));
            labelShortTermMemoryFunction = (ITTLabel)AddControl(new Guid("dc5e0c33-5c9c-455f-8d77-bc75faa62bce"));
            MoodDisorder = (ITTRichTextBoxControl)AddControl(new Guid("02d67c02-8432-41b2-8810-f31610d9f03b"));
            labelMoodDisorder = (ITTLabel)AddControl(new Guid("4797b5a6-7822-4357-ad4b-f8ccae094e05"));
            PsychopathologicalDeviation = (ITTRichTextBoxControl)AddControl(new Guid("2adf97fc-9205-419f-b297-2eaae0ad2cc4"));
            labelPsychopathologicalDeviation = (ITTLabel)AddControl(new Guid("6a62e929-289d-4324-b321-7fea7c5ef2cc"));
            labelEducationStatus = (ITTLabel)AddControl(new Guid("aef630ff-8b49-4b49-b8fa-123f39ebb669"));
            EducationStatus = (ITTObjectListBox)AddControl(new Guid("ff90b172-9682-4bca-b4f8-f810f81758e7"));
            labelPatientJob = (ITTLabel)AddControl(new Guid("95bd038d-2365-4814-929b-def6c78ce130"));
            PatientJob = (ITTObjectListBox)AddControl(new Guid("f3ff9515-6151-4037-a3ba-7d7e1f6f2fba"));
            base.InitializeControls();
        }

        public PsychologicEvaluationForm() : base("PSYCHOLOGICEVALUATION", "PsychologicEvaluationForm")
        {
        }

        protected PsychologicEvaluationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}