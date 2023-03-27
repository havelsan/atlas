
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
    public partial class OldWomanSpecialityForm : TTForm
    {
        protected TTObjectClasses.WomanSpecialityObject _WomanSpecialityObject
        {
            get { return (TTObjectClasses.WomanSpecialityObject)_ttObject; }
        }

        protected ITTCheckBox AnemiaPregnancyFollow;
        protected ITTLabel labelCandidaInfertility;
        protected ITTTextBox CandidaInfertility;
        protected ITTTextBox CervixGynecology;
        protected ITTLabel labelCervixGynecology;
        protected ITTGrid PregnancyComplications;
        protected ITTListBoxColumn ComplicationPregnancyComplications;
        protected ITTTextBoxColumn ComplicationsDescriptionPregnancyComplications;
        protected ITTGrid ObligedRiskFactors;
        protected ITTListBoxColumn RiskFactorsObligedRiskFactors;
        protected ITTTextBoxColumn RiskFactorDescriptionObligedRiskFactors;
        protected ITTGrid PregnancyDangerSign;
        protected ITTListBoxColumn DangerPregnancyDangerSign;
        protected ITTTextBoxColumn DangerDescriptionPregnancyDangerSign;
        protected ITTGrid FetusFollow;
        protected ITTTextBoxColumn BabySizeFetusFollow;
        protected ITTTextBoxColumn BabyWeightFetusFollow;
        protected ITTTextBoxColumn FKAFetusFollow;
        protected ITTObjectListBox WhichPregnancyFollow;
        protected ITTObjectListBox WomansHealthOperations;
        protected ITTLabel labelCongenitalAnomalies;
        protected ITTObjectListBox CongenitalAnomalies;
        protected ITTLabel labelUrinaryProtein;
        protected ITTObjectListBox UrinaryProtein;
        protected ITTLabel labelVitaminDSupplements;
        protected ITTObjectListBox VitaminDSupplements;
        protected ITTLabel labelIronSupplements;
        protected ITTObjectListBox IronSupplements;
        protected ITTLabel labelWhichPregnancyFollow;
        protected ITTLabel labelWomansHealthOperations;
        override protected void InitializeControls()
        {
            AnemiaPregnancyFollow = (ITTCheckBox)AddControl(new Guid("3a0f8fd2-0227-4c70-a030-8c49026efd53"));
            labelCandidaInfertility = (ITTLabel)AddControl(new Guid("1950d415-c99b-4306-827e-0afe059d1b3b"));
            CandidaInfertility = (ITTTextBox)AddControl(new Guid("f1ccf0c6-bb97-4466-bec7-1b4385b707e3"));
            CervixGynecology = (ITTTextBox)AddControl(new Guid("75a8ce32-2db1-4fcf-9570-986733f46065"));
            labelCervixGynecology = (ITTLabel)AddControl(new Guid("10b934e9-733d-4272-91b7-b97f50824c81"));
            PregnancyComplications = (ITTGrid)AddControl(new Guid("9cb48867-a56a-4e77-8edd-7ba0a5c7058c"));
            ComplicationPregnancyComplications = (ITTListBoxColumn)AddControl(new Guid("827b1d38-aa65-4a35-a808-f583c501c41e"));
            ComplicationsDescriptionPregnancyComplications = (ITTTextBoxColumn)AddControl(new Guid("e266966c-8bee-4c6b-b599-8710b4536f35"));
            ObligedRiskFactors = (ITTGrid)AddControl(new Guid("e40ba5de-aa3f-4fd1-ad05-ac1313e58c17"));
            RiskFactorsObligedRiskFactors = (ITTListBoxColumn)AddControl(new Guid("6af5b3ef-e85d-4019-a927-1062c9bc0ae6"));
            RiskFactorDescriptionObligedRiskFactors = (ITTTextBoxColumn)AddControl(new Guid("d2a0709d-4e26-4cde-93c7-1d899d3c0580"));
            PregnancyDangerSign = (ITTGrid)AddControl(new Guid("2d93441a-9e16-4afc-809b-2be15461edae"));
            DangerPregnancyDangerSign = (ITTListBoxColumn)AddControl(new Guid("2f636e32-ba34-4306-b216-ccdac96b4bb2"));
            DangerDescriptionPregnancyDangerSign = (ITTTextBoxColumn)AddControl(new Guid("ea626aac-5b18-4739-a196-d054eb65fc43"));
            FetusFollow = (ITTGrid)AddControl(new Guid("02a8e513-bb7f-4404-96c6-5e7c4d7b69d8"));
            BabySizeFetusFollow = (ITTTextBoxColumn)AddControl(new Guid("404f9313-1c01-4bd9-a8e7-8e80ed6317ae"));
            BabyWeightFetusFollow = (ITTTextBoxColumn)AddControl(new Guid("a8884374-9ecb-408e-bd5e-8103fb0224cf"));
            FKAFetusFollow = (ITTTextBoxColumn)AddControl(new Guid("dfd45da0-dd5f-463f-84f4-53bbdfcf5bff"));
            WhichPregnancyFollow = (ITTObjectListBox)AddControl(new Guid("fa038803-f236-478c-bcf0-3f7fb9642408"));
            WomansHealthOperations = (ITTObjectListBox)AddControl(new Guid("fdd6d075-ae82-42ac-841b-05dfc75b4e08"));
            labelCongenitalAnomalies = (ITTLabel)AddControl(new Guid("e7e9a2e0-24f9-4c3f-b078-49ce60a1ff8e"));
            CongenitalAnomalies = (ITTObjectListBox)AddControl(new Guid("8d71bdce-6046-49b1-88af-4604e49a2b6e"));
            labelUrinaryProtein = (ITTLabel)AddControl(new Guid("e5e48813-f867-472b-82e1-9cb1a03b3c2c"));
            UrinaryProtein = (ITTObjectListBox)AddControl(new Guid("aae8efe3-4fb7-4c96-9598-b5faed7195ad"));
            labelVitaminDSupplements = (ITTLabel)AddControl(new Guid("61e8558e-52fa-4096-86be-b700a8e4f2bf"));
            VitaminDSupplements = (ITTObjectListBox)AddControl(new Guid("a47ee908-d2b2-471f-9d76-e514c41540c7"));
            labelIronSupplements = (ITTLabel)AddControl(new Guid("18ca83f9-9ef2-4e8d-9de2-6d68162141fd"));
            IronSupplements = (ITTObjectListBox)AddControl(new Guid("e1aa0fa1-cdba-4ee4-8a8c-efcd0a2c7893"));
            labelWhichPregnancyFollow = (ITTLabel)AddControl(new Guid("a9a4fd97-a0d7-4de9-8e55-1e58a09db3ce"));
            labelWomansHealthOperations = (ITTLabel)AddControl(new Guid("6ef709da-2f17-4c38-9f44-e71f52c066b5"));
            base.InitializeControls();
        }

        public OldWomanSpecialityForm() : base("WOMANSPECIALITYOBJECT", "OldWomanSpecialityForm")
        {
        }

        protected OldWomanSpecialityForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}