
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
    public partial class SapScoreForm : BaseMultipleDataEntryForm
    {
        protected TTObjectClasses.SapsScore _SapsScore
        {
            get { return (TTObjectClasses.SapsScore)_ttObject; }
        }

        protected ITTLabel labelPatientSex;
        protected ITTEnumComboBox PatientSex;
        protected ITTLabel labelPatientAge;
        protected ITTTextBox PatientAge;
        protected ITTTextBox WaitingMortalite;
        protected ITTTextBox SapsIIPointDetail;
        protected ITTTextBox SapsIIPoint;
        protected ITTTextBox P_InpatientType;
        protected ITTTextBox Age;
        protected ITTTextBox P_AgeForSap;
        protected ITTTextBox P_BodyTemperature;
        protected ITTTextBox P_HCO3;
        protected ITTTextBox P_WBC;
        protected ITTTextBox P_PaO2_FIO2;
        protected ITTTextBox P_SistolikBloodPressure;
        protected ITTTextBox P_SerumUre;
        protected ITTTextBox P_Sodium;
        protected ITTTextBox P_ChronicIllness;
        protected ITTTextBox P_Glasgow;
        protected ITTTextBox P_HeartRate;
        protected ITTTextBox P_Urine;
        protected ITTTextBox P_Potassium;
        protected ITTTextBox P_Bilirubin;
        protected ITTTextBox P_AgeForSapDetail;
        protected ITTTextBox P_Sex;
        protected ITTTextBox P_DurationOfStayBeforeIC;
        protected ITTTextBox P_InpatientResourceBeforeIC;
        protected ITTTextBox P_ClinicCategory;
        protected ITTTextBox P_Poising;
        protected ITTLabel labelWaitingMortalite;
        protected ITTLabel labelSapsIIPointDetail;
        protected ITTLabel labelSapsIIPoint;
        protected ITTLabel labelEntryDate;
        protected ITTDateTimePicker EntryDate;
        protected ITTLabel labelPoising;
        protected ITTEnumComboBox Poising;
        protected ITTLabel labelWBC;
        protected ITTEnumComboBox WBC;
        protected ITTLabel labelUrine;
        protected ITTEnumComboBox Urine;
        protected ITTLabel labelSodium;
        protected ITTEnumComboBox Sodium;
        protected ITTLabel labelSistolikBloodPressure;
        protected ITTEnumComboBox SistolikBloodPressure;
        protected ITTLabel labelSerumUre;
        protected ITTEnumComboBox SerumUre;
        protected ITTLabel labelPotassium;
        protected ITTEnumComboBox Potassium;
        protected ITTLabel labelPaO2_FIO2;
        protected ITTEnumComboBox PaO2_FIO2;
        protected ITTLabel labelInpatientType;
        protected ITTEnumComboBox InpatientType;
        protected ITTLabel labelInpatientResourceBeforeIC;
        protected ITTEnumComboBox InpatientResourceBeforeIC;
        protected ITTLabel labelHeartRate;
        protected ITTEnumComboBox HeartRate;
        protected ITTLabel labelHCO3;
        protected ITTEnumComboBox HCO3;
        protected ITTLabel labelGlasgow;
        protected ITTEnumComboBox Glasgow;
        protected ITTLabel labelDurationOfStayBeforeIC;
        protected ITTEnumComboBox DurationOfStayBeforeIC;
        protected ITTLabel labelClinicCategory;
        protected ITTEnumComboBox ClinicCategory;
        protected ITTLabel labelChronicIllness;
        protected ITTEnumComboBox ChronicIllness;
        protected ITTLabel labelBodyTemperature;
        protected ITTEnumComboBox BodyTemperature;
        protected ITTLabel labelBilirubin;
        protected ITTEnumComboBox Bilirubin;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            labelPatientSex = (ITTLabel)AddControl(new Guid("5d16d0b8-08e3-4222-851d-7ce4f6a53a49"));
            PatientSex = (ITTEnumComboBox)AddControl(new Guid("0599f5a4-e76d-4928-a0b4-bce6758e38b9"));
            labelPatientAge = (ITTLabel)AddControl(new Guid("801e224a-47a1-40ae-833e-efc9d5a2e08e"));
            PatientAge = (ITTTextBox)AddControl(new Guid("90aadb2a-b6f9-4750-85ec-c837948d3720"));
            WaitingMortalite = (ITTTextBox)AddControl(new Guid("c7eff1f8-57bc-475d-92f8-fd5933e83620"));
            SapsIIPointDetail = (ITTTextBox)AddControl(new Guid("e54cc81a-5e24-41fd-9b41-ae28de8459b0"));
            SapsIIPoint = (ITTTextBox)AddControl(new Guid("677ee93e-15d4-4d1f-aab8-a891ac88cff4"));
            P_InpatientType = (ITTTextBox)AddControl(new Guid("ececd00a-fd01-4e88-9c4e-04c9ef9b77ed"));
            Age = (ITTTextBox)AddControl(new Guid("27924f85-614f-4753-bae5-6bb17f91a358"));
            P_AgeForSap = (ITTTextBox)AddControl(new Guid("12ea126e-5dd0-4bcd-bcc1-7bed6d397e23"));
            P_BodyTemperature = (ITTTextBox)AddControl(new Guid("9c4c56c9-f11a-4e26-ba8a-27ffcadfecf8"));
            P_HCO3 = (ITTTextBox)AddControl(new Guid("69ee1f8f-b70c-437b-be92-816d449f14b6"));
            P_WBC = (ITTTextBox)AddControl(new Guid("85b9f0c5-f762-4662-8d65-f2b10193418c"));
            P_PaO2_FIO2 = (ITTTextBox)AddControl(new Guid("0066b3f9-68e4-41c5-8aae-d7664af4b4e4"));
            P_SistolikBloodPressure = (ITTTextBox)AddControl(new Guid("7560985c-7ef5-4a3b-acf9-f65048b3c104"));
            P_SerumUre = (ITTTextBox)AddControl(new Guid("bab0a13c-9bab-460f-b0ee-09b5a4899fae"));
            P_Sodium = (ITTTextBox)AddControl(new Guid("56e2484d-db82-4bf3-a2a5-5988defc3463"));
            P_ChronicIllness = (ITTTextBox)AddControl(new Guid("f1c471a5-7409-4b86-a073-40d8c5d563fc"));
            P_Glasgow = (ITTTextBox)AddControl(new Guid("52f08a1b-ca78-47e5-9f05-1c6763ee2986"));
            P_HeartRate = (ITTTextBox)AddControl(new Guid("e6066ec9-9c6f-4976-afce-ac45197cb32f"));
            P_Urine = (ITTTextBox)AddControl(new Guid("190ebc3a-e9fb-4bf3-9708-240dfe0a2056"));
            P_Potassium = (ITTTextBox)AddControl(new Guid("0db9d22a-9c82-47ac-b640-e8df948786f3"));
            P_Bilirubin = (ITTTextBox)AddControl(new Guid("6a58b532-cf40-484f-bfd7-338f10161deb"));
            P_AgeForSapDetail = (ITTTextBox)AddControl(new Guid("b7911240-b3b5-4694-9b9d-6cc4b5b67a4f"));
            P_Sex = (ITTTextBox)AddControl(new Guid("4a0d6dbe-43c3-4d33-b726-0eed2b979b82"));
            P_DurationOfStayBeforeIC = (ITTTextBox)AddControl(new Guid("79dbebd2-5baf-4001-ac95-2bebc155b05f"));
            P_InpatientResourceBeforeIC = (ITTTextBox)AddControl(new Guid("11c0aadd-c59b-47b3-bf10-dbadca99700b"));
            P_ClinicCategory = (ITTTextBox)AddControl(new Guid("9d5e7790-23b0-4db1-a0cd-90320bc18e9d"));
            P_Poising = (ITTTextBox)AddControl(new Guid("b4253d7e-d434-4c5e-9672-6b863bb833c2"));
            labelWaitingMortalite = (ITTLabel)AddControl(new Guid("a4798d57-fdd2-4e43-b2f4-783c39baae56"));
            labelSapsIIPointDetail = (ITTLabel)AddControl(new Guid("9d195024-2d51-4457-83d2-b46c774d5cf1"));
            labelSapsIIPoint = (ITTLabel)AddControl(new Guid("cf79b0ba-bd98-43b9-b370-4d0275583184"));
            labelEntryDate = (ITTLabel)AddControl(new Guid("0ec4426b-5242-4e7f-8b25-a4e9bd300367"));
            EntryDate = (ITTDateTimePicker)AddControl(new Guid("34ff29d3-a385-49fb-be00-7e429db74db6"));
            labelPoising = (ITTLabel)AddControl(new Guid("b74ef38c-8eef-49e5-a8ab-44d89838823a"));
            Poising = (ITTEnumComboBox)AddControl(new Guid("11f11ea3-c09a-44af-abe7-5557c25ba64f"));
            labelWBC = (ITTLabel)AddControl(new Guid("ab3ce8d5-daed-47e8-a62a-1cb78b6bf2ab"));
            WBC = (ITTEnumComboBox)AddControl(new Guid("5931a464-9b57-4058-b55b-b08741cb2d12"));
            labelUrine = (ITTLabel)AddControl(new Guid("47569ba3-2e03-4c8a-b0f4-a2b4842b10aa"));
            Urine = (ITTEnumComboBox)AddControl(new Guid("cc151c92-8eea-4a35-9719-a7dacf6b4c27"));
            labelSodium = (ITTLabel)AddControl(new Guid("f326ab03-cee5-4dde-97ee-1694e851ef65"));
            Sodium = (ITTEnumComboBox)AddControl(new Guid("ac7a2b4f-65fb-4b61-b1a9-d25923ace51b"));
            labelSistolikBloodPressure = (ITTLabel)AddControl(new Guid("886d8dc1-64bd-4166-acdc-ada3ade410e2"));
            SistolikBloodPressure = (ITTEnumComboBox)AddControl(new Guid("3967ef45-7912-4467-a4bf-9a7fe94a8fe6"));
            labelSerumUre = (ITTLabel)AddControl(new Guid("d4027e7d-6494-4e13-92ff-4cc8f964d524"));
            SerumUre = (ITTEnumComboBox)AddControl(new Guid("73532c8e-5e31-4f8d-8406-933bf8d0f584"));
            labelPotassium = (ITTLabel)AddControl(new Guid("52b18254-33cf-4197-b5bc-2e71ac019727"));
            Potassium = (ITTEnumComboBox)AddControl(new Guid("bb38c055-efc7-4963-9d12-be6f2796fe73"));
            labelPaO2_FIO2 = (ITTLabel)AddControl(new Guid("4d12bd27-14ea-40d7-99c5-8014b250ea38"));
            PaO2_FIO2 = (ITTEnumComboBox)AddControl(new Guid("eefbc4aa-8b60-4f31-af33-ffab7812276c"));
            labelInpatientType = (ITTLabel)AddControl(new Guid("5add90b5-bdae-432d-84a2-bba7a8fd6650"));
            InpatientType = (ITTEnumComboBox)AddControl(new Guid("8c25b375-66e0-40b7-8727-d63fc5bdeb22"));
            labelInpatientResourceBeforeIC = (ITTLabel)AddControl(new Guid("9442f4c1-9a98-4564-a3f4-ec5ba262b1f9"));
            InpatientResourceBeforeIC = (ITTEnumComboBox)AddControl(new Guid("05f2c2ed-f15e-43ef-a859-cb507ee4a072"));
            labelHeartRate = (ITTLabel)AddControl(new Guid("fe4321aa-74c1-4678-9e2e-d946c2d172f1"));
            HeartRate = (ITTEnumComboBox)AddControl(new Guid("59abf2e8-6446-42b7-b665-7cefba0609c9"));
            labelHCO3 = (ITTLabel)AddControl(new Guid("4f034e52-e385-4194-80ad-e375b928df4c"));
            HCO3 = (ITTEnumComboBox)AddControl(new Guid("9cf78e5a-14ec-40b1-983b-3eda06bd4096"));
            labelGlasgow = (ITTLabel)AddControl(new Guid("5a9e80a3-d0a9-41d4-b624-38f42404e4d2"));
            Glasgow = (ITTEnumComboBox)AddControl(new Guid("e574e6dc-db13-429b-9d9a-1e4c4b848961"));
            labelDurationOfStayBeforeIC = (ITTLabel)AddControl(new Guid("5cc784d8-1165-413b-8b92-fc690189f6be"));
            DurationOfStayBeforeIC = (ITTEnumComboBox)AddControl(new Guid("fa2a1362-62b5-42aa-9952-92c0021e3346"));
            labelClinicCategory = (ITTLabel)AddControl(new Guid("de95fc73-4b76-4e4f-95fb-23dc33b43455"));
            ClinicCategory = (ITTEnumComboBox)AddControl(new Guid("41531a7e-7218-4422-9f77-d7bece60cd3f"));
            labelChronicIllness = (ITTLabel)AddControl(new Guid("bf4ed596-d0ca-44e4-9b11-96a2dda2939e"));
            ChronicIllness = (ITTEnumComboBox)AddControl(new Guid("3ffd13f1-3e7e-4857-ab07-bf70790ba3e9"));
            labelBodyTemperature = (ITTLabel)AddControl(new Guid("e99e7b5f-7084-4382-81ba-dba5e9c394af"));
            BodyTemperature = (ITTEnumComboBox)AddControl(new Guid("92498b03-195e-44c5-90b1-7bcb54be441d"));
            labelBilirubin = (ITTLabel)AddControl(new Guid("a2cd9a83-8814-45b3-81a8-3901d040e694"));
            Bilirubin = (ITTEnumComboBox)AddControl(new Guid("ef4f6d4c-943f-4b50-8c8f-95fc0e3e6b6a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("65ffd6c7-2013-4510-931a-324ab1ec1685"));
            base.InitializeControls();
        }

        public SapScoreForm() : base("SAPSSCORE", "SapScoreForm")
        {
        }

        protected SapScoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}