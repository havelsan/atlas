
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
    public partial class PregnancyFollowForm : TTForm
    {
        protected TTObjectClasses.PregnancyFollow _PregnancyFollow
        {
            get { return (TTObjectClasses.PregnancyFollow)_ttObject; }
        }

        protected ITTLabel labelInformerPhone;
        protected ITTTextBox InformerPhone;
        protected ITTTextBox InformerName;
        protected ITTTextBox Hemoglobin;
        protected ITTTextBox Varicose;
        protected ITTTextBox UltrasonicFinding;
        protected ITTTextBox PretibialEdema;
        protected ITTTextBox PregnancyDiseasesDescription;
        protected ITTTextBox PelvicCondition;
        protected ITTTextBox Openness;
        protected ITTTextBox MotherWeight;
        protected ITTTextBox Complaints;
        protected ITTLabel labelInformerName;
        protected ITTLabel labelSkrsGestationalDiabetes;
        protected ITTObjectListBox SkrsGestationalDiabetes;
        protected ITTLabel labelWomansHealthOperations;
        protected ITTObjectListBox WomansHealthOperations;
        protected ITTLabel labelCongenitalAnomalies;
        protected ITTObjectListBox CongenitalAnomalies;
        protected ITTLabel labelUrinaryProtein;
        protected ITTObjectListBox UrinaryProtein;
        protected ITTLabel labelHemoglobin;
        protected ITTGrid FetusFollow;
        protected ITTTextBoxColumn BabySizeFetusFollow;
        protected ITTTextBoxColumn BabyWeightFetusFollow;
        protected ITTTextBoxColumn FKAFetusFollow;
        protected ITTGrid PregnancyDangerSign;
        protected ITTListBoxColumn DangerPregnancyDangerSign;
        protected ITTTextBoxColumn DangerDescriptionPregnancyDangerSign;
        protected ITTGrid ObligedRiskFactors;
        protected ITTListBoxColumn RiskFactorsObligedRiskFactors;
        protected ITTTextBoxColumn RiskFactorDescriptionObligedRiskFactors;
        protected ITTGrid PregnancyComplications;
        protected ITTListBoxColumn ComplicationPregnancyComplications;
        protected ITTTextBoxColumn ComplicationsDescriptionPregnancyComplications;
        protected ITTLabel labelVitaminDSupplements;
        protected ITTObjectListBox VitaminDSupplements;
        protected ITTLabel labelIronSupplements;
        protected ITTObjectListBox IronSupplements;
        protected ITTLabel labelWhichPregnancyFollow;
        protected ITTObjectListBox WhichPregnancyFollow;
        protected ITTGroupBox ttgroupbox3;
        protected ITTLabel labelWeightFetusGrowingDefinition;
        protected ITTTextBox WeightFetusGrowingDefinition;
        protected ITTLabel labelPregnancyWeekFetusGrowingDefinition;
        protected ITTTextBox PregnancyWeekFetusGrowingDefinition;
        protected ITTLabel labelLengthFetusGrowingDefinition;
        protected ITTTextBox LengthFetusGrowingDefinition;
        protected ITTLabel labelHeadCircumferenceFetusGrowingDefinition;
        protected ITTTextBox HeadCircumferenceFetusGrowingDefinition;
        protected ITTLabel labelFemurLengthFetusGrowingDefinition;
        protected ITTTextBox FemurLengthFetusGrowingDefinition;
        protected ITTLabel labelBiparietalDiameterFetusGrowingDefinition;
        protected ITTTextBox BiparietalDiameterFetusGrowingDefinition;
        protected ITTLabel labelAbdominalCircumferenceFetusGrowingDefinition;
        protected ITTTextBox AbdominalCircumferenceFetusGrowingDefinition;
        protected ITTGroupBox ttgroupbox2;
        protected ITTGroupBox ttgroupbox1;
        protected ITTCheckBox Tension;
        protected ITTCheckBox GestationalDiabetes;
        protected ITTCheckBox Bleeding;
        protected ITTCheckBox CardiovascularDiseases;
        protected ITTCheckBox Nausea;
        protected ITTCheckBox Anemia;
        protected ITTLabel labelRiskFactors;
        protected ITTLabel labelVaricose;
        protected ITTLabel labelUltrasonicFinding;
        protected ITTLabel labelPretibialEdema;
        protected ITTLabel labelPregnancyDiseasesDescription;
        protected ITTLabel labelPelvicCondition;
        protected ITTLabel labelOpenness;
        protected ITTLabel labelMotherWeight;
        protected ITTLabel labelComplaints;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            labelInformerPhone = (ITTLabel)AddControl(new Guid("5956a160-93d8-4428-8691-24b5886c846a"));
            InformerPhone = (ITTTextBox)AddControl(new Guid("c6f58829-6b41-4264-8c28-a2fa609e5cbf"));
            InformerName = (ITTTextBox)AddControl(new Guid("435f9c15-c4cb-4d55-9845-41de74567460"));
            Hemoglobin = (ITTTextBox)AddControl(new Guid("15a04eae-8a09-4e09-83a9-b98677655a90"));
            Varicose = (ITTTextBox)AddControl(new Guid("b797c755-c467-4790-ac56-ad65a80e3c01"));
            UltrasonicFinding = (ITTTextBox)AddControl(new Guid("d8547602-bec1-492e-9e72-d2b20c489777"));
            PretibialEdema = (ITTTextBox)AddControl(new Guid("387731c5-1402-4ecc-8fc6-a3e16990ffe8"));
            PregnancyDiseasesDescription = (ITTTextBox)AddControl(new Guid("d0bd72e0-6c71-4c04-91c7-6ede68a73270"));
            PelvicCondition = (ITTTextBox)AddControl(new Guid("efb26265-f395-4c65-864c-0c41f9e37e22"));
            Openness = (ITTTextBox)AddControl(new Guid("9cf37581-7e79-43f3-b7bd-d9c7286cd0ef"));
            MotherWeight = (ITTTextBox)AddControl(new Guid("137f73ac-2d87-4567-9096-de5adbc015c6"));
            Complaints = (ITTTextBox)AddControl(new Guid("68479efe-6fa5-4881-9f9f-7737ad4d26e5"));
            labelInformerName = (ITTLabel)AddControl(new Guid("d6adc123-18af-4703-bf83-946afccae636"));
            labelSkrsGestationalDiabetes = (ITTLabel)AddControl(new Guid("520909c7-0f31-41d2-abbc-021847149ba2"));
            SkrsGestationalDiabetes = (ITTObjectListBox)AddControl(new Guid("99641524-d808-42de-b091-b9fbf50091af"));
            labelWomansHealthOperations = (ITTLabel)AddControl(new Guid("c7a923a9-5abe-4cf0-aca5-3ac3f40aae64"));
            WomansHealthOperations = (ITTObjectListBox)AddControl(new Guid("b7a93bdc-84a9-4c0c-a9bc-d931c454a28b"));
            labelCongenitalAnomalies = (ITTLabel)AddControl(new Guid("929f807d-695a-467b-a9a7-f0f77e632adb"));
            CongenitalAnomalies = (ITTObjectListBox)AddControl(new Guid("5a274aa3-931c-465f-bc9c-2d7792a196f8"));
            labelUrinaryProtein = (ITTLabel)AddControl(new Guid("0f24de13-c3c7-4aef-a97f-55d6d54e4146"));
            UrinaryProtein = (ITTObjectListBox)AddControl(new Guid("fe53a038-108d-4fec-9c7d-ac4777a2d295"));
            labelHemoglobin = (ITTLabel)AddControl(new Guid("bfa3bb71-fedd-44de-bf15-013c2b9fcf92"));
            FetusFollow = (ITTGrid)AddControl(new Guid("d6d5e903-64ca-40cd-a5a4-390c33bbf7ed"));
            BabySizeFetusFollow = (ITTTextBoxColumn)AddControl(new Guid("bb681dd1-0a91-4896-a521-75917063f3dd"));
            BabyWeightFetusFollow = (ITTTextBoxColumn)AddControl(new Guid("72fe61ab-7cf4-4d59-9687-3c7b890de0e4"));
            FKAFetusFollow = (ITTTextBoxColumn)AddControl(new Guid("485cc60d-694b-4703-a1e8-fd997143e55d"));
            PregnancyDangerSign = (ITTGrid)AddControl(new Guid("a9492bc8-9eee-4acf-ba06-526aade86212"));
            DangerPregnancyDangerSign = (ITTListBoxColumn)AddControl(new Guid("9de2bae6-4855-4fa0-b4ec-a195bb8d2115"));
            DangerDescriptionPregnancyDangerSign = (ITTTextBoxColumn)AddControl(new Guid("682d12f3-92e4-41e8-9f74-313cb7d126c4"));
            ObligedRiskFactors = (ITTGrid)AddControl(new Guid("b7219c68-505a-4be0-ae43-92c390466fc5"));
            RiskFactorsObligedRiskFactors = (ITTListBoxColumn)AddControl(new Guid("bdf050e1-55bd-4768-85e5-4e7aa83b01c2"));
            RiskFactorDescriptionObligedRiskFactors = (ITTTextBoxColumn)AddControl(new Guid("a5a400c1-9ccf-4ebb-8e47-425e3980c116"));
            PregnancyComplications = (ITTGrid)AddControl(new Guid("1e1264d7-8f8a-4fdf-a1a8-4f9ed85d5eec"));
            ComplicationPregnancyComplications = (ITTListBoxColumn)AddControl(new Guid("4e7c235e-fc74-4ba5-9ab6-6a774063d2e6"));
            ComplicationsDescriptionPregnancyComplications = (ITTTextBoxColumn)AddControl(new Guid("2ce756fc-fcad-4d63-a514-e06b61b9fe85"));
            labelVitaminDSupplements = (ITTLabel)AddControl(new Guid("4115d051-1a88-4ce3-a44e-f75053e3ab7c"));
            VitaminDSupplements = (ITTObjectListBox)AddControl(new Guid("42800dc9-3ac3-408f-a6f1-395388f1a8e3"));
            labelIronSupplements = (ITTLabel)AddControl(new Guid("42a5a78c-fbcc-4012-bff6-c179673fd637"));
            IronSupplements = (ITTObjectListBox)AddControl(new Guid("fb385830-e965-4368-b397-5a8e743e96fb"));
            labelWhichPregnancyFollow = (ITTLabel)AddControl(new Guid("f3443c63-d469-4e16-bdd5-51c6d9d0e288"));
            WhichPregnancyFollow = (ITTObjectListBox)AddControl(new Guid("6b3e75f4-e747-4c4f-95f6-7aea7aae832f"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("c1c74fb8-15d5-42bc-9781-15bf14a8ece4"));
            labelWeightFetusGrowingDefinition = (ITTLabel)AddControl(new Guid("0d93eda6-f98d-4b7b-a53f-da61518f2e4a"));
            WeightFetusGrowingDefinition = (ITTTextBox)AddControl(new Guid("55becf61-22ae-4531-aeda-7fef204a1884"));
            labelPregnancyWeekFetusGrowingDefinition = (ITTLabel)AddControl(new Guid("14068157-9e10-4830-824c-d8e6961a36fb"));
            PregnancyWeekFetusGrowingDefinition = (ITTTextBox)AddControl(new Guid("f0fb58f7-f611-4443-ade6-23e4287e93ef"));
            labelLengthFetusGrowingDefinition = (ITTLabel)AddControl(new Guid("49449bb5-3b4d-46ae-b7a5-b21c536999fb"));
            LengthFetusGrowingDefinition = (ITTTextBox)AddControl(new Guid("a207862d-79d3-4e12-9688-0f117141d4d5"));
            labelHeadCircumferenceFetusGrowingDefinition = (ITTLabel)AddControl(new Guid("51b1e9ee-4472-4372-af06-949f54e9817d"));
            HeadCircumferenceFetusGrowingDefinition = (ITTTextBox)AddControl(new Guid("0fb2d5e8-4555-4391-96eb-b02fd17fa3ab"));
            labelFemurLengthFetusGrowingDefinition = (ITTLabel)AddControl(new Guid("9d7c2e26-0613-405c-9cd9-f0abe44ab1dd"));
            FemurLengthFetusGrowingDefinition = (ITTTextBox)AddControl(new Guid("f4c1a450-64ba-4f6a-9d3c-e97e6ec8928a"));
            labelBiparietalDiameterFetusGrowingDefinition = (ITTLabel)AddControl(new Guid("e8b7fe52-b160-4756-b198-e5a4c3674d9f"));
            BiparietalDiameterFetusGrowingDefinition = (ITTTextBox)AddControl(new Guid("9fc4fde0-63e9-4efe-9a15-3bd418c0b0ee"));
            labelAbdominalCircumferenceFetusGrowingDefinition = (ITTLabel)AddControl(new Guid("5bcef8e5-cb52-4caa-8688-aa78f14d0122"));
            AbdominalCircumferenceFetusGrowingDefinition = (ITTTextBox)AddControl(new Guid("ace957c4-c492-4b82-b4f8-6b036df5545b"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("e85eb86e-2237-40d5-8303-8773afb29b23"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("c6dea6d8-0b5a-40d2-967e-0680d7873e01"));
            Tension = (ITTCheckBox)AddControl(new Guid("e9f5d425-0a89-40f8-9113-2fb8663bf2bb"));
            GestationalDiabetes = (ITTCheckBox)AddControl(new Guid("71c4d16a-862f-4550-8085-57d6a2dd14ca"));
            Bleeding = (ITTCheckBox)AddControl(new Guid("37a08c33-755e-4b39-99ce-7a2a196bfaaf"));
            CardiovascularDiseases = (ITTCheckBox)AddControl(new Guid("06bb5dd8-30cb-43a1-9ab2-dac023ba0b27"));
            Nausea = (ITTCheckBox)AddControl(new Guid("4b243008-fd5c-455c-83a2-ed28b81bde62"));
            Anemia = (ITTCheckBox)AddControl(new Guid("1001c4c5-3320-4dca-a9d7-d5f70ea22856"));
            labelRiskFactors = (ITTLabel)AddControl(new Guid("069d400a-0867-4f29-a927-eab72c41e185"));
            labelVaricose = (ITTLabel)AddControl(new Guid("fbba2746-fd2e-43b2-a215-b40909d2dde5"));
            labelUltrasonicFinding = (ITTLabel)AddControl(new Guid("9fac9a8e-4bb5-4ca4-9f7f-b41c8ba6aac2"));
            labelPretibialEdema = (ITTLabel)AddControl(new Guid("e38d64f5-c5c4-4384-bcf0-a736f835d9ab"));
            labelPregnancyDiseasesDescription = (ITTLabel)AddControl(new Guid("314e80b0-2501-4c17-8ac1-dae7f7ad10a9"));
            labelPelvicCondition = (ITTLabel)AddControl(new Guid("52c48d4d-5953-45b7-840d-4392bd10b50e"));
            labelOpenness = (ITTLabel)AddControl(new Guid("8f4ec941-9421-4643-b2c8-f84ed77449fd"));
            labelMotherWeight = (ITTLabel)AddControl(new Guid("a6e65c50-18fa-4e84-b567-7c811cb53098"));
            labelComplaints = (ITTLabel)AddControl(new Guid("26967dc8-3219-4beb-a6e4-3a8acaa99b91"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("748124ab-c612-4be5-95f0-e11f6e0011f9"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("82b98d72-b541-4e0a-9c5b-6dca85be3459"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("14258fb9-c3bf-4958-a831-b0d69704389f"));
            base.InitializeControls();
        }

        public PregnancyFollowForm() : base("PREGNANCYFOLLOW", "PregnancyFollowForm")
        {
        }

        protected PregnancyFollowForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}