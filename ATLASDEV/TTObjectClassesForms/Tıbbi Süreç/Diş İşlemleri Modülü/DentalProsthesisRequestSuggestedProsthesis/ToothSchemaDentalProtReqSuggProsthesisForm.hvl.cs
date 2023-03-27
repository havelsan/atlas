
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
    public partial class ToothSchemaDentalProtReqSuggProsthesis : TTForm
    {
        protected TTObjectClasses.DentalProsthesisRequestSuggestedProsthesis _DentalProsthesisRequestSuggestedProsthesis
        {
            get { return (TTObjectClasses.DentalProsthesisRequestSuggestedProsthesis)_ttObject; }
        }

        protected ITTEnumComboBox ToothNumber;
        protected ITTLabel labelSuggestedProsthesisProcedure;
        protected ITTObjectListBox SuggestedProsthesisProcedure;
        protected ITTLabel labelDepartment;
        protected ITTObjectListBox Department;
        protected ITTLabel labelToothNumber;
        protected ITTTextBox Definition;
        protected ITTCheckBox Emergency;
        protected ITTLabel labelDentalPosition;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelDefinition;
        protected ITTGroupBox ttgroupboxToothSchema;
        protected ITTButton ttbutton4;
        protected ITTButton ttbutton2;
        protected ITTLabel ttlabelMouthPositionNum;
        protected ITTButton ttbuttonLeftUpperJaw;
        protected ITTButton ttbuttonRightUpperJaw;
        protected ITTButton ttbuttonUpper;
        protected ITTButton ttbuttonUpperJaw;
        protected ITTButton ttbuttonWholeJaw;
        protected ITTLabel ttlabelAdultTooth;
        protected ITTButton ttbutton9;
        protected ITTButton ttbutton8;
        protected ITTButton ttbutton7;
        protected ITTButton ttbutton6;
        protected ITTLabel ttlabelMilkTooth;
        protected ITTLabel ttlabelAnamoliPositionNum;
        protected ITTButton ttbuttonRight;
        protected ITTButton ttbuttonLeft;
        protected ITTButton ttbuttonLeftLowerJaw;
        protected ITTButton ttbutton37;
        protected ITTButton ttbuttonWholeJaw2;
        protected ITTButton ttbutton32;
        protected ITTButton ttbuttonLowerJaw;
        protected ITTButton ttbutton94;
        protected ITTButton ttbuttonRightLowerJaw;
        protected ITTButton ttbutton38;
        protected ITTButton ttbutton42;
        protected ITTButton ttbutton71;
        protected ITTButton ttbuttonLower;
        protected ITTButton ttbutton33;
        protected ITTButton ttbutton47;
        protected ITTButton ttbuttonLL1;
        protected ITTButton ttbutton28;
        protected ITTButton ttbuttonLL2;
        protected ITTButton ttbutton81;
        protected ITTButton ttbutton31;
        protected ITTButton ttbutton92;
        protected ITTButton ttbutton75;
        protected ITTButton ttbutton41;
        protected ITTButton ttbutton34;
        protected ITTButton ttbutton21;
        protected ITTButton ttbutton74;
        protected ITTButton ttbutton93;
        protected ITTButton ttbutton35;
        protected ITTButton ttbutton52;
        protected ITTButton ttbutton73;
        protected ITTButton ttbutton46;
        protected ITTButton ttbutton36;
        protected ITTButton ttbutton27;
        protected ITTButton ttbutton72;
        protected ITTButton ttbutton82;
        protected ITTButton ttbutton61;
        protected ITTButton ttbutton83;
        protected ITTButton ttbutton26;
        protected ITTButton ttbutton48;
        protected ITTButton ttbuttonRU1;
        protected ITTButton ttbutton84;
        protected ITTButton ttbutton25;
        protected ITTButton ttbutton45;
        protected ITTButton ttbuttonLU2;
        protected ITTButton ttbutton85;
        protected ITTButton ttbutton24;
        protected ITTButton ttbutton44;
        protected ITTButton ttbutton23;
        protected ITTButton ttbuttonRL2;
        protected ITTButton ttbutton11;
        protected ITTButton ttbutton43;
        protected ITTButton ttbutton22;
        protected ITTButton ttbuttonRL1;
        protected ITTButton ttbuttonLU1;
        protected ITTButton ttbutton51;
        protected ITTButton ttbutton65;
        protected ITTButton ttbutton64;
        protected ITTButton ttbutton18;
        protected ITTButton ttbutton63;
        protected ITTButton ttbuttonRU2;
        protected ITTButton ttbutton62;
        protected ITTButton ttbutton12;
        protected ITTButton ttbutton13;
        protected ITTButton ttbutton91;
        protected ITTButton ttbutton14;
        protected ITTButton ttbutton55;
        protected ITTButton ttbutton15;
        protected ITTButton ttbutton54;
        protected ITTButton ttbutton16;
        protected ITTButton ttbutton53;
        protected ITTButton ttbutton17;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("083e22cf-3a59-45d2-9b15-f21104de297d"));
            labelSuggestedProsthesisProcedure = (ITTLabel)AddControl(new Guid("740e7b67-3898-4426-85cb-1f9803b363a9"));
            SuggestedProsthesisProcedure = (ITTObjectListBox)AddControl(new Guid("1ef181c2-1e9b-430e-b609-7fc469253a51"));
            labelDepartment = (ITTLabel)AddControl(new Guid("ba6c43eb-225a-45a6-8dbb-ce41b6be200f"));
            Department = (ITTObjectListBox)AddControl(new Guid("4d25a4be-f199-412f-bfca-87de69591098"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("afc62d1c-01d5-426d-b806-a5ce65a87c9f"));
            Definition = (ITTTextBox)AddControl(new Guid("66eedab4-fc2d-4039-a68b-44ede2ced270"));
            Emergency = (ITTCheckBox)AddControl(new Guid("fd1694b0-9544-4d42-bb53-764bf4c11380"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("6951bc63-28e7-482f-a9e2-df5a4cc38232"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("79a2c6da-5735-4097-ba91-c3f221e1c9ae"));
            labelDefinition = (ITTLabel)AddControl(new Guid("af9de9b6-065c-4839-a394-6390cee33fcd"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("97b3fef7-e308-4166-8c3b-68eda209107c"));
            ttbutton4 = (ITTButton)AddControl(new Guid("6d3eba51-5aba-46b4-bbba-875873403d32"));
            ttbutton2 = (ITTButton)AddControl(new Guid("a6750e68-e044-4514-9ccd-3a10ba4d6d6f"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("5b55b7a8-0359-42f7-9bf7-d71aa984464d"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("38f98fbc-3bdd-4ee6-af81-280e23a9e961"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("4a07265a-59da-457d-baf8-cbb493531cf2"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("17c182a5-0c4f-4c49-91e2-0d566d0b436c"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("48a3930c-02fe-4ceb-8d1a-bea223d5893e"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("572a12d9-6848-429c-8d4a-02f1684ac3c2"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("ade13dec-5db1-404f-8a8a-8ad067922a16"));
            ttbutton9 = (ITTButton)AddControl(new Guid("2b958096-e339-4765-89d4-61f095b20296"));
            ttbutton8 = (ITTButton)AddControl(new Guid("c1773563-3b56-4629-ab67-ec3f2520dd35"));
            ttbutton7 = (ITTButton)AddControl(new Guid("4c2b1fed-555d-4b6b-8801-16382ce8e762"));
            ttbutton6 = (ITTButton)AddControl(new Guid("b1cfb125-4d0c-40a5-ba93-c9fd21dedf0e"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("0c1b9649-3d97-4db9-b22c-87c32e21066d"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("4395f42e-e5b6-43e0-9894-74c0bee5c133"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("688360f6-6d74-4c8d-baf9-27f37cec6960"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("49791d81-94c3-410f-a4b0-eac53db5b8a6"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("af91db7b-c301-4f0c-87c2-31833fb14a97"));
            ttbutton37 = (ITTButton)AddControl(new Guid("dd9e49c2-884b-4e74-a3f0-db4c9f6fb682"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("178f896a-4df8-45d3-b21d-b0e7a9417d31"));
            ttbutton32 = (ITTButton)AddControl(new Guid("42a6b07f-d672-40bb-a86c-44a08c14acdf"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("ab786cef-f709-44fa-837f-df5c76d5f151"));
            ttbutton94 = (ITTButton)AddControl(new Guid("39e7ecf7-c79f-4a57-afc7-e73a8944172e"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("b40f655c-eb69-4b81-a620-e749d3277303"));
            ttbutton38 = (ITTButton)AddControl(new Guid("92412244-9558-43ca-82ba-a0fa85057960"));
            ttbutton42 = (ITTButton)AddControl(new Guid("afefb804-c8b8-4769-99b7-9b2192824d58"));
            ttbutton71 = (ITTButton)AddControl(new Guid("901648d2-9b04-41a3-a6a0-4fb04803ab20"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("30940fd9-0b2f-4ae9-8c62-7eda36cd75a3"));
            ttbutton33 = (ITTButton)AddControl(new Guid("6419be64-41fc-48aa-a6fe-297d10965f10"));
            ttbutton47 = (ITTButton)AddControl(new Guid("827bd361-fb97-4447-bb7c-b7b5cb15498c"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("02c6a20e-2b26-4dcf-88ea-73f0b4ac6d1a"));
            ttbutton28 = (ITTButton)AddControl(new Guid("d81c657a-d0b7-4c7e-bf84-23bcb965b39b"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("b93d6f1e-dbde-45bb-aaec-576c69c4c4b9"));
            ttbutton81 = (ITTButton)AddControl(new Guid("08e8d464-4acb-4353-9767-bf0a3663820f"));
            ttbutton31 = (ITTButton)AddControl(new Guid("3a85beb4-b042-43ab-8fcb-b115aff6d309"));
            ttbutton92 = (ITTButton)AddControl(new Guid("283d84c0-ea7a-4cb3-bbe8-bd992c0eef6d"));
            ttbutton75 = (ITTButton)AddControl(new Guid("84e814c4-dd6b-455f-b541-cabea8b3b998"));
            ttbutton41 = (ITTButton)AddControl(new Guid("555d3cb7-d23c-45c6-aba2-49355d53106d"));
            ttbutton34 = (ITTButton)AddControl(new Guid("6389ae6f-89ae-4c54-bd53-4505a04d3625"));
            ttbutton21 = (ITTButton)AddControl(new Guid("68fc9a93-d703-4766-8ed9-90593b04f576"));
            ttbutton74 = (ITTButton)AddControl(new Guid("ced01a5f-f5c8-48c1-83f5-8cadfb33d207"));
            ttbutton93 = (ITTButton)AddControl(new Guid("f964535f-44a7-40c9-9445-4254dfb3c167"));
            ttbutton35 = (ITTButton)AddControl(new Guid("74083849-2912-47e3-a830-55fbae459022"));
            ttbutton52 = (ITTButton)AddControl(new Guid("fbf6af4f-7e42-4f2e-ac7c-823bea139323"));
            ttbutton73 = (ITTButton)AddControl(new Guid("48942263-982f-4bd4-937d-f547d92ddaf5"));
            ttbutton46 = (ITTButton)AddControl(new Guid("e7826478-0fc0-49a1-873b-675b99d9c1bb"));
            ttbutton36 = (ITTButton)AddControl(new Guid("d15b979f-1c4c-44d9-a5ab-74258aeb6981"));
            ttbutton27 = (ITTButton)AddControl(new Guid("472d8220-aeef-4db8-b706-eb13b4a77cb1"));
            ttbutton72 = (ITTButton)AddControl(new Guid("44327277-a96d-42bf-81a8-3bd7147aee2e"));
            ttbutton82 = (ITTButton)AddControl(new Guid("3b7e1593-851e-4ca0-9701-92643dce58b7"));
            ttbutton61 = (ITTButton)AddControl(new Guid("865a7cee-e623-4d94-a7d2-7ecd3d9c973e"));
            ttbutton83 = (ITTButton)AddControl(new Guid("cbd8422a-f7b1-4f5d-8006-b27b088ac2ac"));
            ttbutton26 = (ITTButton)AddControl(new Guid("bc2690fb-5d12-451f-9a55-8abc0031335e"));
            ttbutton48 = (ITTButton)AddControl(new Guid("c4af52c9-3c29-427f-888e-cdd5ee2c6e91"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("9058a989-139f-490e-9c79-b0c642b48275"));
            ttbutton84 = (ITTButton)AddControl(new Guid("e570bdeb-84c5-47b4-90a6-b0e1688dcd02"));
            ttbutton25 = (ITTButton)AddControl(new Guid("27ed8d17-d6b3-4c90-a04f-e58db11b226f"));
            ttbutton45 = (ITTButton)AddControl(new Guid("0e07e9e0-253f-4651-a60e-8c11491b5a4a"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("3256d3c8-6637-4e2d-b79e-7077ee556a01"));
            ttbutton85 = (ITTButton)AddControl(new Guid("4270b011-aea2-4e28-80e2-61feb11a6aa2"));
            ttbutton24 = (ITTButton)AddControl(new Guid("7e8e5330-bf12-4d13-b777-e0e016e77028"));
            ttbutton44 = (ITTButton)AddControl(new Guid("06e2d43a-aba5-4fdb-b516-d0a6121d6584"));
            ttbutton23 = (ITTButton)AddControl(new Guid("afc9bf92-18cb-4f4f-a1f5-a4c21d9d7378"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("3cddec99-30b1-49f3-8d9a-6e3fbf6cbb4a"));
            ttbutton11 = (ITTButton)AddControl(new Guid("40145d67-9a62-4527-9fc8-8cbdb817ff9e"));
            ttbutton43 = (ITTButton)AddControl(new Guid("8f74557b-4188-4f42-a882-3e790c64e13c"));
            ttbutton22 = (ITTButton)AddControl(new Guid("4a298743-eda3-4d11-ba12-442bbcc9c6e6"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("5590800d-486b-42a2-af95-2f948366a34c"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("ccc03687-7406-4862-9292-3faa29146c04"));
            ttbutton51 = (ITTButton)AddControl(new Guid("708b0b8a-5600-41bc-a6fb-e2b4672126e0"));
            ttbutton65 = (ITTButton)AddControl(new Guid("6b53924f-c89c-4bb4-8669-5545d10da2a1"));
            ttbutton64 = (ITTButton)AddControl(new Guid("915801e3-9c73-470d-b206-56cf56791d64"));
            ttbutton18 = (ITTButton)AddControl(new Guid("c0b06af1-6d87-43f6-b84b-d8689babeb70"));
            ttbutton63 = (ITTButton)AddControl(new Guid("6dbc4362-d245-4828-a65c-af253fd76d54"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("4e75e3ec-284e-4976-a002-0b5eecf9d8bf"));
            ttbutton62 = (ITTButton)AddControl(new Guid("8d749cfb-f802-4440-bb17-af8399a6ca33"));
            ttbutton12 = (ITTButton)AddControl(new Guid("43960292-eddd-46b5-8964-89a74a738b5d"));
            ttbutton13 = (ITTButton)AddControl(new Guid("c6ced022-8935-40e6-b943-5ce240c606ed"));
            ttbutton91 = (ITTButton)AddControl(new Guid("2be01b7d-8323-473a-a93c-a6590a6257be"));
            ttbutton14 = (ITTButton)AddControl(new Guid("186dc585-0610-499d-ac40-13a99989c5f9"));
            ttbutton55 = (ITTButton)AddControl(new Guid("39900354-1239-4956-a797-596030c37d6c"));
            ttbutton15 = (ITTButton)AddControl(new Guid("f71ed6ac-16af-4b41-8b6c-67e59de60a9d"));
            ttbutton54 = (ITTButton)AddControl(new Guid("4d9930f5-b9d2-4163-b7ef-694c5fb11c58"));
            ttbutton16 = (ITTButton)AddControl(new Guid("09a2bec4-9585-463d-9e81-fc2be1fb6738"));
            ttbutton53 = (ITTButton)AddControl(new Guid("68ae0a8a-12fc-49d6-b90b-1cb6c8a750ca"));
            ttbutton17 = (ITTButton)AddControl(new Guid("6c6873d6-3555-4c6b-bbb3-c55361d7a057"));
            base.InitializeControls();
        }

        public ToothSchemaDentalProtReqSuggProsthesis() : base("DENTALPROSTHESISREQUESTSUGGESTEDPROSTHESIS", "ToothSchemaDentalProtReqSuggProsthesis")
        {
        }

        protected ToothSchemaDentalProtReqSuggProsthesis(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}