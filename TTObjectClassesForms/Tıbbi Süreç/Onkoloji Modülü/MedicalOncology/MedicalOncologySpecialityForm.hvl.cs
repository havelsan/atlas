
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
    /// Medikal Onkoloji Uzmanlığı Formu
    /// </summary>
    public partial class MedicalOncologySpecialityForm : TTForm
    {
        protected TTObjectClasses.MedicalOncology _MedicalOncology
        {
            get { return (TTObjectClasses.MedicalOncology)_ttObject; }
        }

        protected ITTLabel labelM2;
        protected ITTTextBox M2;
        protected ITTTextBox NB;
        protected ITTTextBox TA;
        protected ITTTextBox PS;
        protected ITTLabel labelNB;
        protected ITTLabel labelTA;
        protected ITTLabel labelPS;
        protected ITTLabel labelDescription;
        protected ITTRichTextBoxControl Description;
        protected ITTLabel labelPathology;
        protected ITTRichTextBoxControl Pathology;
        protected ITTLabel labelStory;
        protected ITTRichTextBoxControl Story;
        protected ITTLabel labelSecondLineTreatment;
        protected ITTRichTextBoxControl SecondLineTreatment;
        protected ITTLabel labelFirstLineTreatment;
        protected ITTRichTextBoxControl FirstLineTreatment;
        protected ITTLabel labelInterimEvaluation;
        protected ITTRichTextBoxControl InterimEvaluation;
        protected ITTLabel labelPreTreatmentStaging;
        protected ITTRichTextBoxControl PreTreatmentStaging;
        override protected void InitializeControls()
        {
            labelM2 = (ITTLabel)AddControl(new Guid("63fefa69-903d-4074-b1c3-971271d7f5d2"));
            M2 = (ITTTextBox)AddControl(new Guid("6e69627e-d8c9-4690-85e0-d5cc92830faa"));
            NB = (ITTTextBox)AddControl(new Guid("3a75b2e0-a82e-4b1a-98ab-27b481b8d1d3"));
            TA = (ITTTextBox)AddControl(new Guid("313dc158-ca22-4fa8-a06a-36eae4d7876f"));
            PS = (ITTTextBox)AddControl(new Guid("93410400-aec6-4e45-be47-cbaae908d29f"));
            labelNB = (ITTLabel)AddControl(new Guid("0937c4e3-20ea-4447-b85d-5db7a5eeafd5"));
            labelTA = (ITTLabel)AddControl(new Guid("c5c20407-f4db-487f-9795-901f4fecfaab"));
            labelPS = (ITTLabel)AddControl(new Guid("7f32ee1a-90a4-4252-a08f-8ec1debd8535"));
            labelDescription = (ITTLabel)AddControl(new Guid("7f3cd938-5304-4557-bd3f-24bfc04d4ae7"));
            Description = (ITTRichTextBoxControl)AddControl(new Guid("4ca5c1c8-7c36-4815-9db6-22be439b329b"));
            labelPathology = (ITTLabel)AddControl(new Guid("84b549e7-d85f-4afd-af3f-72a36b14da17"));
            Pathology = (ITTRichTextBoxControl)AddControl(new Guid("40fc70bb-3326-46f2-8c2e-0e39bd4b496e"));
            labelStory = (ITTLabel)AddControl(new Guid("ade3cb73-ad48-48d5-bbfc-445236081d71"));
            Story = (ITTRichTextBoxControl)AddControl(new Guid("40cfcae2-c097-4887-be94-daa45c62dc60"));
            labelSecondLineTreatment = (ITTLabel)AddControl(new Guid("6df686e8-c837-43a8-af4a-b5445fbb6861"));
            SecondLineTreatment = (ITTRichTextBoxControl)AddControl(new Guid("4cedbde8-15cc-4ff8-bbb2-ac3e4689e508"));
            labelFirstLineTreatment = (ITTLabel)AddControl(new Guid("911c22dc-46c0-4834-82fb-494efafa4e69"));
            FirstLineTreatment = (ITTRichTextBoxControl)AddControl(new Guid("b962447b-ab8b-4f2d-84f4-6a40f3332e6e"));
            labelInterimEvaluation = (ITTLabel)AddControl(new Guid("04ca7462-5d44-4dbd-80db-2a8756c65214"));
            InterimEvaluation = (ITTRichTextBoxControl)AddControl(new Guid("d34ed987-fde8-45c6-b745-f2b206ff7aa9"));
            labelPreTreatmentStaging = (ITTLabel)AddControl(new Guid("a29b5ef7-ff30-4baa-9e22-a5d09193e379"));
            PreTreatmentStaging = (ITTRichTextBoxControl)AddControl(new Guid("50a2d817-3eb5-4365-be10-6c7b358e190b"));
            base.InitializeControls();
        }

        public MedicalOncologySpecialityForm() : base("MEDICALONCOLOGY", "MedicalOncologySpecialityForm")
        {
        }

        protected MedicalOncologySpecialityForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}