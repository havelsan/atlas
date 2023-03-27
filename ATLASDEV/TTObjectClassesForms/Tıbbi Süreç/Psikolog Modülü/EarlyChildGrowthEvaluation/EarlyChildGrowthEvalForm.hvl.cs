
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
    public partial class EarlyChildGrowthEvalForm : TTForm
    {
    /// <summary>
    /// Erken Çocuk Gelişimi Değerlendirme Formu
    /// </summary>
        protected TTObjectClasses.EarlyChildGrowthEvaluation _EarlyChildGrowthEvaluation
        {
            get { return (TTObjectClasses.EarlyChildGrowthEvaluation)_ttObject; }
        }

        protected ITTLabel labelAddedUser;
        protected ITTObjectListBox AddedUser;
        protected ITTRichTextBoxControl PsychomotorEvolution;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTRichTextBoxControl Result;
        protected ITTRichTextBoxControl SocialSkillSelfCareEvolLevel;
        protected ITTRichTextBoxControl TongueCognitiveEvolutionLevel;
        protected ITTRichTextBoxControl ThinMotorEvolution;
        protected ITTRichTextBoxControl MajorMotorEvolution;
        protected ITTRichTextBoxControl GeneralEvolutionLevel;
        protected ITTRichTextBoxControl CognitiveEvolution;
        protected ITTLabel labelTongueCognitiveEvolutionLevel;
        protected ITTLabel labelThinMotorEvolution;
        protected ITTLabel labelSocialSkillSelfCareEvolLevel;
        protected ITTLabel labelResult;
        protected ITTLabel labelPsychomotorEvolution;
        protected ITTLabel labelMajorMotorEvolution;
        protected ITTLabel labelGeneralEvolutionLevel;
        protected ITTLabel labelCognitiveEvolution;
        override protected void InitializeControls()
        {
            labelAddedUser = (ITTLabel)AddControl(new Guid("b9b332c4-aaf1-4a6c-8fec-ccda4a883fb5"));
            AddedUser = (ITTObjectListBox)AddControl(new Guid("92df50ec-bb3d-46ad-b50f-da526e51f78b"));
            PsychomotorEvolution = (ITTRichTextBoxControl)AddControl(new Guid("10e40358-30bb-4b60-9cee-2d3117208e02"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("b4cd1a6a-1c30-4aea-ad4c-fc66a8d54a5a"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("0c26fd71-6aec-4961-bff6-e07961d829d7"));
            Result = (ITTRichTextBoxControl)AddControl(new Guid("c6f2bd50-1fa6-426d-82fe-ae1fc880cecf"));
            SocialSkillSelfCareEvolLevel = (ITTRichTextBoxControl)AddControl(new Guid("64bf7d67-2e6c-4e29-8c60-e85b49cb0352"));
            TongueCognitiveEvolutionLevel = (ITTRichTextBoxControl)AddControl(new Guid("87690d63-6039-4c1e-ab44-9e6e3e586f2d"));
            ThinMotorEvolution = (ITTRichTextBoxControl)AddControl(new Guid("500194c9-7099-4051-9fbe-c24ecdae4638"));
            MajorMotorEvolution = (ITTRichTextBoxControl)AddControl(new Guid("7f2711d3-67f2-456c-96c3-263681adf30c"));
            GeneralEvolutionLevel = (ITTRichTextBoxControl)AddControl(new Guid("83c326fc-f1df-426f-8438-fcddbf4fbdfb"));
            CognitiveEvolution = (ITTRichTextBoxControl)AddControl(new Guid("df309a53-1d76-436d-952a-941d587bcff2"));
            labelTongueCognitiveEvolutionLevel = (ITTLabel)AddControl(new Guid("23cebf40-4575-4878-9e78-b30e7d9d40b0"));
            labelThinMotorEvolution = (ITTLabel)AddControl(new Guid("3388cb67-cf2c-4a42-b769-37c5e5141978"));
            labelSocialSkillSelfCareEvolLevel = (ITTLabel)AddControl(new Guid("2c8f943e-fe3e-47ec-9758-ffe5e1ef58d2"));
            labelResult = (ITTLabel)AddControl(new Guid("d988f76c-9e00-4a55-a239-3c9d0627a614"));
            labelPsychomotorEvolution = (ITTLabel)AddControl(new Guid("ca43071e-4076-4526-8b88-ff34b5eee5cf"));
            labelMajorMotorEvolution = (ITTLabel)AddControl(new Guid("68fa937b-92ae-4b59-a1e0-83425e799231"));
            labelGeneralEvolutionLevel = (ITTLabel)AddControl(new Guid("6c766b77-65a9-416f-a141-aecd3a755c04"));
            labelCognitiveEvolution = (ITTLabel)AddControl(new Guid("a5346447-f58c-41ba-b9a9-09700a0bce4a"));
            base.InitializeControls();
        }

        public EarlyChildGrowthEvalForm() : base("EARLYCHILDGROWTHEVALUATION", "EarlyChildGrowthEvalForm")
        {
        }

        protected EarlyChildGrowthEvalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}