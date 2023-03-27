
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
    public partial class CognitiveEvaluationForm : TTForm
    {
    /// <summary>
    /// Kognitif Değerlendirme
    /// </summary>
        protected TTObjectClasses.CognitiveEvaluation _CognitiveEvaluation
        {
            get { return (TTObjectClasses.CognitiveEvaluation)_ttObject; }
        }

        protected ITTLabel labelAddedUser;
        protected ITTObjectListBox AddedUser;
        protected ITTRichTextBoxControl ObservationDiscussionEvalNote;
        protected ITTLabel labelObservationDiscussionEvalNote;
        protected ITTLabel labelRemembrance;
        protected ITTTextBox Remembrance;
        protected ITTTextBox RecordingMemory;
        protected ITTTextBox Orientation;
        protected ITTTextBox Language;
        protected ITTTextBox AttentionAndCalculation;
        protected ITTLabel labelRecordingMemory;
        protected ITTLabel labelOrientation;
        protected ITTLabel labelLanguage;
        protected ITTLabel labelAttentionAndCalculation;
        protected ITTRichTextBoxControl Other;
        protected ITTLabel labelOther;
        protected ITTRichTextBoxControl SocialEducationRetardationSit;
        protected ITTLabel labelSocialEducationRetardationSit;
        protected ITTRichTextBoxControl IQIntelligenceLevel;
        protected ITTLabel labelIQIntelligenceLevel;
        protected ITTRichTextBoxControl LongTermMemoryFunction;
        protected ITTLabel labelLongTermMemoryFunction;
        protected ITTRichTextBoxControl ShortTermMemoryFunction;
        protected ITTLabel labelShortTermMemoryFunction;
        protected ITTRichTextBoxControl JudgmentFunction;
        protected ITTLabel labelJudgmentFunction;
        protected ITTRichTextBoxControl ReasoningFunction;
        protected ITTLabel labelReasoningFunction;
        protected ITTRichTextBoxControl DetectionFunction;
        protected ITTLabel labelDetectionFunction;
        protected ITTLabel labelPatientJob;
        protected ITTObjectListBox PatientJob;
        protected ITTLabel labelEducationStatus;
        protected ITTObjectListBox EducationStatus;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        override protected void InitializeControls()
        {
            labelAddedUser = (ITTLabel)AddControl(new Guid("5462c07b-dd16-4614-b22e-44a495eec088"));
            AddedUser = (ITTObjectListBox)AddControl(new Guid("144375bb-70e8-44a1-b319-6d1757ac6821"));
            ObservationDiscussionEvalNote = (ITTRichTextBoxControl)AddControl(new Guid("22df403f-1313-4aaa-b0a1-1c2a4b2f8b53"));
            labelObservationDiscussionEvalNote = (ITTLabel)AddControl(new Guid("e348f583-3046-4c70-9449-2e9c3bdf123f"));
            labelRemembrance = (ITTLabel)AddControl(new Guid("4c92aff7-ff61-41a9-9630-208cfbaf0696"));
            Remembrance = (ITTTextBox)AddControl(new Guid("b9750b92-85da-4b65-8433-59c5be595c96"));
            RecordingMemory = (ITTTextBox)AddControl(new Guid("8a70088c-efc3-4425-987b-a283d37e1577"));
            Orientation = (ITTTextBox)AddControl(new Guid("e6fb2d28-a665-42e9-bb05-cdeb681256de"));
            Language = (ITTTextBox)AddControl(new Guid("c9fc8030-861f-4e5d-9e2f-82635594e2e4"));
            AttentionAndCalculation = (ITTTextBox)AddControl(new Guid("ce872b04-213a-4397-89c9-dd0d19e22500"));
            labelRecordingMemory = (ITTLabel)AddControl(new Guid("34918b47-2cd6-4416-b629-577c60246dad"));
            labelOrientation = (ITTLabel)AddControl(new Guid("b1e8a749-29ae-4083-86ea-c52d2911c8e1"));
            labelLanguage = (ITTLabel)AddControl(new Guid("553d62cc-e13b-4104-942f-33dc6e0083db"));
            labelAttentionAndCalculation = (ITTLabel)AddControl(new Guid("cb0d1c8a-aa19-4575-b1d6-4bcf03cafd00"));
            Other = (ITTRichTextBoxControl)AddControl(new Guid("41358034-bd5c-4196-9656-39517785f67c"));
            labelOther = (ITTLabel)AddControl(new Guid("1731257c-af9f-4996-9da5-4919a4e2c8de"));
            SocialEducationRetardationSit = (ITTRichTextBoxControl)AddControl(new Guid("0885c450-c014-4f18-b442-1c2e52f21253"));
            labelSocialEducationRetardationSit = (ITTLabel)AddControl(new Guid("fcfd7421-f38d-49e9-a615-41c7618d5477"));
            IQIntelligenceLevel = (ITTRichTextBoxControl)AddControl(new Guid("19551fc4-b2a4-4601-882d-a372010358ba"));
            labelIQIntelligenceLevel = (ITTLabel)AddControl(new Guid("d97f55db-810b-45db-98e6-05339e5badb0"));
            LongTermMemoryFunction = (ITTRichTextBoxControl)AddControl(new Guid("53c5f76f-0c40-4536-b3cf-950ad8c7764c"));
            labelLongTermMemoryFunction = (ITTLabel)AddControl(new Guid("b3c1b329-4fd7-4101-873c-7351a6f6913b"));
            ShortTermMemoryFunction = (ITTRichTextBoxControl)AddControl(new Guid("8dd53cdd-bc2a-4d0d-b0c9-deb0d5f1af60"));
            labelShortTermMemoryFunction = (ITTLabel)AddControl(new Guid("c1b5572f-e3fe-42a8-866b-a52b4d73acb4"));
            JudgmentFunction = (ITTRichTextBoxControl)AddControl(new Guid("78a1304f-12b3-4d9d-8266-ec3862a4dc3a"));
            labelJudgmentFunction = (ITTLabel)AddControl(new Guid("b50df953-86a3-4bfe-aead-b1b7cd9b9fd4"));
            ReasoningFunction = (ITTRichTextBoxControl)AddControl(new Guid("63406afb-a30c-46e3-89a3-9a435c8f85ef"));
            labelReasoningFunction = (ITTLabel)AddControl(new Guid("e9109841-9c49-44d5-b877-51c3e6a7a7b2"));
            DetectionFunction = (ITTRichTextBoxControl)AddControl(new Guid("37d5e0b4-0d03-47b7-a9f0-14d2a7544032"));
            labelDetectionFunction = (ITTLabel)AddControl(new Guid("b03aaa8b-918c-4375-8a8b-5da50277dcd6"));
            labelPatientJob = (ITTLabel)AddControl(new Guid("64e991cd-bdfa-4687-af12-687d01fc3ea7"));
            PatientJob = (ITTObjectListBox)AddControl(new Guid("fa5cd54f-8ae4-4c63-a52d-127690bfc764"));
            labelEducationStatus = (ITTLabel)AddControl(new Guid("76b0db5a-e66c-4c16-9ae7-358f96ca9c70"));
            EducationStatus = (ITTObjectListBox)AddControl(new Guid("f99bd471-73a7-4816-a434-2bc24a55887d"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("ca61eaa9-a625-4146-b86c-74b99c38bf96"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("7c40dc71-4999-48de-a996-53677af7de32"));
            base.InitializeControls();
        }

        public CognitiveEvaluationForm() : base("COGNITIVEEVALUATION", "CognitiveEvaluationForm")
        {
        }

        protected CognitiveEvaluationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}