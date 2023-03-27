
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
    public partial class ApacheScoreForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.ApacheScore _ApacheScore
        {
            get { return (TTObjectClasses.ApacheScore)_ttObject; }
        }

        protected ITTLabel labelPaO2;
        protected ITTTextBox PaO2;
        protected ITTTextBox PaCO2;
        protected ITTTextBox FIO2;
        protected ITTTextBox ExpectedMortalityRate;
        protected ITTTextBox ApacheIITotal;
        protected ITTTextBox P_BodyTemperature;
        protected ITTTextBox P_BreathRate;
        protected ITTTextBox P_NoAKG;
        protected ITTTextBox P_SerumPotassium;
        protected ITTTextBox P_Ht;
        protected ITTTextBox P_Age;
        protected ITTTextBox P_MeanBloodPressure;
        protected ITTTextBox P_FIO2Over;
        protected ITTTextBox P_ArterialpH;
        protected ITTTextBox P_SerumCreatinineYesFailure;
        protected ITTTextBox P_WBC;
        protected ITTTextBox P_HeartRate;
        protected ITTTextBox P_FIO2Under;
        protected ITTTextBox P_SerumSodium;
        protected ITTTextBox P_SerumCreatinineNoFailure;
        protected ITTTextBox P_GlasgowComaScale;
        protected ITTTextBox P_ChronicOrganFailure;
        protected ITTLabel labelPaCO2;
        protected ITTLabel labelFIO2;
        protected ITTLabel labelSerumCreatinineNoFailure;
        protected ITTEnumComboBox SerumCreatinineNoFailure;
        protected ITTLabel labelSerumCreatinineYesFailure;
        protected ITTEnumComboBox SerumCreatinineYesFailure;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelExpectedMortalityRate;
        protected ITTLabel labelApacheIITotal;
        protected ITTLabel labelChronicOrganFailure;
        protected ITTEnumComboBox ChronicOrganFailure;
        protected ITTLabel labelAge;
        protected ITTEnumComboBox Age;
        protected ITTLabel labelGlasgowComaScale;
        protected ITTEnumComboBox GlasgowComaScale;
        protected ITTLabel labelWBC;
        protected ITTEnumComboBox WBC;
        protected ITTLabel labelHt;
        protected ITTEnumComboBox Ht;
        protected ITTLabel labelSerumPotassium;
        protected ITTEnumComboBox SerumPotassium;
        protected ITTLabel labelSerumSodium;
        protected ITTEnumComboBox SerumSodium;
        protected ITTLabel labelArterialpH;
        protected ITTEnumComboBox ArterialpH;
        protected ITTLabel labelNoAKG;
        protected ITTEnumComboBox NoAKG;
        protected ITTLabel labelFIO2Under;
        protected ITTEnumComboBox FIO2Under;
        protected ITTLabel labelFIO2Over;
        protected ITTEnumComboBox FIO2Over;
        protected ITTLabel labelBreathRate;
        protected ITTEnumComboBox BreathRate;
        protected ITTLabel labelHeartRate;
        protected ITTEnumComboBox HeartRate;
        protected ITTLabel labelMeanBloodPressure;
        protected ITTEnumComboBox MeanBloodPressure;
        protected ITTLabel labelBodyTemperature;
        protected ITTEnumComboBox BodyTemperature;
        override protected void InitializeControls()
        {
            labelPaO2 = (ITTLabel)AddControl(new Guid("1751e3b6-ef17-4f57-93c4-486be9d3e330"));
            PaO2 = (ITTTextBox)AddControl(new Guid("ef507b9a-ee0c-4882-814b-bec8c4000d7e"));
            PaCO2 = (ITTTextBox)AddControl(new Guid("43ac65ad-7562-4d05-acfd-0ef3c15c9dd2"));
            FIO2 = (ITTTextBox)AddControl(new Guid("846389b5-da23-4b80-82df-1c32f8cf77d9"));
            ExpectedMortalityRate = (ITTTextBox)AddControl(new Guid("486315e3-13b1-4ba4-9b9a-9d235010a3c2"));
            ApacheIITotal = (ITTTextBox)AddControl(new Guid("c376adb6-c5a0-4bb8-ab0c-ff89c127aad4"));
            P_BodyTemperature = (ITTTextBox)AddControl(new Guid("cf817f98-3bd8-419b-a06a-ce6c07498761"));
            P_BreathRate = (ITTTextBox)AddControl(new Guid("920c40e9-c673-4557-a2f8-d3a2f349350e"));
            P_NoAKG = (ITTTextBox)AddControl(new Guid("6cf4cf43-b4fd-4118-be09-a1db06e46d73"));
            P_SerumPotassium = (ITTTextBox)AddControl(new Guid("8045670d-0754-4acd-896d-9d575e1a2944"));
            P_Ht = (ITTTextBox)AddControl(new Guid("a2c99671-3e32-49cc-8104-40aa7172ced7"));
            P_Age = (ITTTextBox)AddControl(new Guid("e4b86df9-73ed-442b-9c54-321de6e9aa99"));
            P_MeanBloodPressure = (ITTTextBox)AddControl(new Guid("2479d240-8109-48ab-b4bf-b6a41049c81b"));
            P_FIO2Over = (ITTTextBox)AddControl(new Guid("7d8bb127-a710-4018-a3f1-a2ee2e57c5a2"));
            P_ArterialpH = (ITTTextBox)AddControl(new Guid("8b1de57c-bb1c-4d96-9b3e-67f98d818266"));
            P_SerumCreatinineYesFailure = (ITTTextBox)AddControl(new Guid("88483b74-1b06-4130-931a-cac06d003fe6"));
            P_WBC = (ITTTextBox)AddControl(new Guid("91d25afd-16d0-46df-bef1-ef9fbedbd9ec"));
            P_HeartRate = (ITTTextBox)AddControl(new Guid("30a5ad6d-59fe-4fab-b28d-b0c20f145716"));
            P_FIO2Under = (ITTTextBox)AddControl(new Guid("154b7185-094d-4c44-af4c-955c29143d7a"));
            P_SerumSodium = (ITTTextBox)AddControl(new Guid("9c93ab4f-b7ff-4939-a771-e9f178337b2e"));
            P_SerumCreatinineNoFailure = (ITTTextBox)AddControl(new Guid("b159e264-2149-479f-ba15-2c94763d78f0"));
            P_GlasgowComaScale = (ITTTextBox)AddControl(new Guid("debba579-4f62-42bb-b0c0-87812ff1c7dc"));
            P_ChronicOrganFailure = (ITTTextBox)AddControl(new Guid("c91cd7da-77f0-4535-80cd-05bd209b93b2"));
            labelPaCO2 = (ITTLabel)AddControl(new Guid("27ad3280-a394-433e-8172-ea973b07f662"));
            labelFIO2 = (ITTLabel)AddControl(new Guid("284a12f9-67cb-45a8-83a9-d585081e01bb"));
            labelSerumCreatinineNoFailure = (ITTLabel)AddControl(new Guid("d30dea5d-d8c6-408a-8c17-4cc8160f866a"));
            SerumCreatinineNoFailure = (ITTEnumComboBox)AddControl(new Guid("07d43b1e-3dfd-45b3-8f33-f879e6a26385"));
            labelSerumCreatinineYesFailure = (ITTLabel)AddControl(new Guid("5b07d39e-f62d-4334-b67d-55bf1af8d96b"));
            SerumCreatinineYesFailure = (ITTEnumComboBox)AddControl(new Guid("1bf6c7a8-c556-4ad2-af44-4b0d46aee9e2"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("1d8503e0-6493-46eb-a585-e3d84aedc9a1"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("dc84148d-1147-4a0d-acc4-5ef60408ae25"));
            labelExpectedMortalityRate = (ITTLabel)AddControl(new Guid("42d8d5ba-3ced-4189-886f-58e7db3ba230"));
            labelApacheIITotal = (ITTLabel)AddControl(new Guid("ca714dd6-e4d0-4771-9305-0c690a3519c9"));
            labelChronicOrganFailure = (ITTLabel)AddControl(new Guid("7a46c316-66ae-4057-8bb3-18cff1af479a"));
            ChronicOrganFailure = (ITTEnumComboBox)AddControl(new Guid("afebc877-8c00-46b3-ac7c-f06baba97d53"));
            labelAge = (ITTLabel)AddControl(new Guid("3a3d0c61-481d-4ae0-8107-c7ff6ef14179"));
            Age = (ITTEnumComboBox)AddControl(new Guid("3c708703-083b-46f8-9038-686dcdf193fe"));
            labelGlasgowComaScale = (ITTLabel)AddControl(new Guid("5318cbf7-02a8-41d3-ae82-44cde1c23fea"));
            GlasgowComaScale = (ITTEnumComboBox)AddControl(new Guid("de015f44-c597-46de-8daa-41064e905902"));
            labelWBC = (ITTLabel)AddControl(new Guid("cd83e4e8-d9d6-4903-bb07-21a3efaabaaf"));
            WBC = (ITTEnumComboBox)AddControl(new Guid("3050d2d4-e530-4e84-81d1-ee22a3557175"));
            labelHt = (ITTLabel)AddControl(new Guid("6cfa0070-c4a7-437a-a689-8940834a3d93"));
            Ht = (ITTEnumComboBox)AddControl(new Guid("2b36befc-3656-4493-b9d9-c95766145160"));
            labelSerumPotassium = (ITTLabel)AddControl(new Guid("8dee4dcd-8ac7-400d-b19b-16c95d2f4710"));
            SerumPotassium = (ITTEnumComboBox)AddControl(new Guid("94769a08-5d13-40fa-933d-0e9361b3d610"));
            labelSerumSodium = (ITTLabel)AddControl(new Guid("fa0e3e7f-bbe8-41ef-8ada-240d5a3a7229"));
            SerumSodium = (ITTEnumComboBox)AddControl(new Guid("17c93ffe-947a-4802-9096-4832c6214431"));
            labelArterialpH = (ITTLabel)AddControl(new Guid("e6be7602-e219-4b51-9a43-d02f6767ed58"));
            ArterialpH = (ITTEnumComboBox)AddControl(new Guid("7f48907e-ed27-4f56-ab5e-6bdcb12104cb"));
            labelNoAKG = (ITTLabel)AddControl(new Guid("f1bad5d0-fe10-40c6-ae35-6746543ddb81"));
            NoAKG = (ITTEnumComboBox)AddControl(new Guid("d9efc871-1aaf-4962-9e7f-1746f776aef0"));
            labelFIO2Under = (ITTLabel)AddControl(new Guid("f02a9d6c-e9dd-4eb2-95fc-af3594041d78"));
            FIO2Under = (ITTEnumComboBox)AddControl(new Guid("1368b9b4-a69e-41c9-b64d-194a4f73b887"));
            labelFIO2Over = (ITTLabel)AddControl(new Guid("84001106-8cae-462d-87be-56b5fab8f472"));
            FIO2Over = (ITTEnumComboBox)AddControl(new Guid("d31295bc-8433-41b5-943a-8a846f0f5bcb"));
            labelBreathRate = (ITTLabel)AddControl(new Guid("beac0859-6bf4-42e1-a380-4d9e42d018cd"));
            BreathRate = (ITTEnumComboBox)AddControl(new Guid("4bd289f0-3f8f-4c6b-ae65-7d9e99e523de"));
            labelHeartRate = (ITTLabel)AddControl(new Guid("19f27b05-f163-4817-94e6-c5035003bd88"));
            HeartRate = (ITTEnumComboBox)AddControl(new Guid("faa99dad-c228-43e8-ae69-3e65484f9c9b"));
            labelMeanBloodPressure = (ITTLabel)AddControl(new Guid("5fbdd3d2-28e2-4d80-9bd6-493cd2afd090"));
            MeanBloodPressure = (ITTEnumComboBox)AddControl(new Guid("e75b873b-1683-4124-889a-a8e465a5f91d"));
            labelBodyTemperature = (ITTLabel)AddControl(new Guid("8e2ec8f2-5eb7-4e59-9b0e-e0d63daeb31a"));
            BodyTemperature = (ITTEnumComboBox)AddControl(new Guid("340a136c-80f7-4b80-a28d-df84741ccf12"));
            base.InitializeControls();
        }

        public ApacheScoreForm() : base("APACHESCORE", "ApacheScoreForm")
        {
        }

        protected ApacheScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}