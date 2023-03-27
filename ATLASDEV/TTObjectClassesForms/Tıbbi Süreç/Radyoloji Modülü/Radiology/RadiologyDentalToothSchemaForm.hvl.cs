
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
    public partial class RadiologyDentalToothSchema : TTForm
    {
    /// <summary>
    /// Radyoloji
    /// </summary>
        protected TTObjectClasses.Radiology _Radiology
        {
            get { return (TTObjectClasses.Radiology)_ttObject; }
        }

        protected ITTCheckBox Anomali;
        protected ITTGroupBox ttgroupboxToothSchema;
        protected ITTLabel ttlabelAdultTooth;
        protected ITTLabel ttlabelMilkTooth;
        protected ITTLabel ttlabelAnamoliPositionNum;
        protected ITTLabel ttlabelMouthPositionNum;
        protected ITTButton ttbutton6;
        protected ITTButton ttbutton3;
        protected ITTButton ttbutton2;
        protected ITTButton ttbutton1;
        protected ITTButton ttbutton94;
        protected ITTButton ttbuttonLL1;
        protected ITTButton ttbuttonLL2;
        protected ITTButton ttbutton75;
        protected ITTButton ttbutton74;
        protected ITTButton ttbutton73;
        protected ITTButton ttbutton72;
        protected ITTButton ttbutton71;
        protected ITTButton ttbutton37;
        protected ITTButton ttbutton36;
        protected ITTButton ttbutton35;
        protected ITTButton ttbutton38;
        protected ITTButton ttbutton34;
        protected ITTButton ttbutton31;
        protected ITTButton ttbutton32;
        protected ITTButton ttbutton33;
        protected ITTButton ttbuttonWholeJaw2;
        protected ITTButton ttbuttonLowerJaw;
        protected ITTButton ttbutton19;
        protected ITTButton ttbuttonRightLowerJaw;
        protected ITTButton ttbuttonLower;
        protected ITTButton ttbutton93;
        protected ITTButton ttbuttonRL1;
        protected ITTButton ttbutton84;
        protected ITTButton ttbutton85;
        protected ITTButton ttbuttonRL2;
        protected ITTButton ttbutton83;
        protected ITTButton ttbutton82;
        protected ITTButton ttbutton81;
        protected ITTButton ttbutton44;
        protected ITTButton ttbutton41;
        protected ITTButton ttbutton42;
        protected ITTButton ttbutton43;
        protected ITTButton ttbutton45;
        protected ITTButton ttbutton46;
        protected ITTButton ttbutton47;
        protected ITTButton ttbutton48;
        protected ITTButton ttbutton28;
        protected ITTButton ttbutton27;
        protected ITTButton ttbutton26;
        protected ITTButton ttbutton25;
        protected ITTButton ttbutton24;
        protected ITTButton ttbutton23;
        protected ITTButton ttbutton22;
        protected ITTButton ttbutton21;
        protected ITTButton ttbutton92;
        protected ITTButton ttbuttonLU2;
        protected ITTButton ttbuttonLU1;
        protected ITTButton ttbutton65;
        protected ITTButton ttbutton64;
        protected ITTButton ttbutton63;
        protected ITTButton ttbutton62;
        protected ITTButton ttbutton61;
        protected ITTButton ttbutton11;
        protected ITTButton ttbutton12;
        protected ITTButton ttbutton13;
        protected ITTButton ttbutton14;
        protected ITTButton ttbutton15;
        protected ITTButton ttbutton16;
        protected ITTButton ttbutton17;
        protected ITTButton ttbutton18;
        protected ITTButton ttbutton51;
        protected ITTButton ttbutton52;
        protected ITTButton ttbutton53;
        protected ITTButton ttbutton54;
        protected ITTButton ttbutton55;
        protected ITTButton ttbuttonRU2;
        protected ITTButton ttbuttonRU1;
        protected ITTButton ttbutton91;
        protected ITTButton ttbutton5;
        protected ITTButton ttbutton4;
        protected ITTButton ttbuttonRightUpperJaw;
        protected ITTButton ttbuttonLeftUpperJaw;
        protected ITTButton ttbuttonUpper;
        protected ITTButton ttbuttonUpperJaw;
        protected ITTButton ttbuttonWholeJaw;
        protected ITTButton ttbuttonLeft;
        protected ITTButton ttbuttonRight;
        protected ITTLabel labelDentalPosition;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelToothNumber;
        protected ITTEnumComboBox ToothNumber;
        override protected void InitializeControls()
        {
            Anomali = (ITTCheckBox)AddControl(new Guid("d195b744-39d3-4d18-8345-8035b7d7fe9c"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("e35cd6b5-dcb0-402c-808e-883073cd10e1"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("1a339fb1-5d22-4789-bbc2-bc02906b43c1"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("6632c030-6715-4fb3-97f3-541b89d672d3"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("12612d4f-c69d-4ac8-a6b3-0d6e815c4467"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("97d35b5d-e99f-497e-b3db-12a04e211cff"));
            ttbutton6 = (ITTButton)AddControl(new Guid("65e547fe-b3c4-4bc9-9b31-3ace7a334c81"));
            ttbutton3 = (ITTButton)AddControl(new Guid("c9707dc6-8100-45eb-9b1b-6dcd7a734dd7"));
            ttbutton2 = (ITTButton)AddControl(new Guid("6bf14706-3349-40af-b18d-567280e458ce"));
            ttbutton1 = (ITTButton)AddControl(new Guid("ea4dc331-7447-4c7c-97a2-23fda51150b8"));
            ttbutton94 = (ITTButton)AddControl(new Guid("9e541dab-055b-4e99-8669-bb7e26592138"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("fde59927-2249-489b-9af4-524bd8d9b1bc"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("0f0c06e6-fefe-4dc9-bc0e-aee4d07ca769"));
            ttbutton75 = (ITTButton)AddControl(new Guid("d95faf43-8929-4882-8b53-12ea47fd7c21"));
            ttbutton74 = (ITTButton)AddControl(new Guid("313563e2-1263-4583-a8bf-6faf2ea7c172"));
            ttbutton73 = (ITTButton)AddControl(new Guid("73be56e3-262e-4e0d-9079-722553e73f44"));
            ttbutton72 = (ITTButton)AddControl(new Guid("11262cc7-b99c-41e8-8960-67b3d474e2f8"));
            ttbutton71 = (ITTButton)AddControl(new Guid("bfdba4d8-0648-41eb-9e47-602fd5513c0d"));
            ttbutton37 = (ITTButton)AddControl(new Guid("ef89033a-a2ff-4f4e-b600-e51d30596778"));
            ttbutton36 = (ITTButton)AddControl(new Guid("79849f2c-244c-40f2-a51f-0f1d852246bc"));
            ttbutton35 = (ITTButton)AddControl(new Guid("204e7cf1-7028-4618-8f88-a5461a9ad1c6"));
            ttbutton38 = (ITTButton)AddControl(new Guid("dda90e16-27a5-4059-9185-62067998ea16"));
            ttbutton34 = (ITTButton)AddControl(new Guid("b85bb66f-af2f-4fa5-bda4-3962189c229f"));
            ttbutton31 = (ITTButton)AddControl(new Guid("d346bdda-bed3-4c58-8e80-87149736b1ef"));
            ttbutton32 = (ITTButton)AddControl(new Guid("9e538cf9-0a2a-4cf2-82b9-ba34be2c9ade"));
            ttbutton33 = (ITTButton)AddControl(new Guid("6fef0c2a-f5fb-4fab-b201-d19614af7797"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("f8138d18-a7cf-45b8-b532-f71688dbd499"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("af01a974-9c32-4f9e-aab7-dafb4d4c4f3f"));
            ttbutton19 = (ITTButton)AddControl(new Guid("49c47313-97e4-4008-a42e-b67c167a41eb"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("75405757-71d6-43a5-9cd9-4867d2a6b0f7"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("05009f3f-ea2b-444d-9979-75feba19432b"));
            ttbutton93 = (ITTButton)AddControl(new Guid("b1213cd8-d137-4cd1-85d7-f3f2b140e189"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("35450bf6-c908-4276-94c3-d80dd5ea5aca"));
            ttbutton84 = (ITTButton)AddControl(new Guid("f1c783da-9c04-44c3-8f30-45337cb88fd8"));
            ttbutton85 = (ITTButton)AddControl(new Guid("a6709566-92ae-42aa-94d6-86f029a9694e"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("6e9ca57e-f631-44d0-a8d5-b36fa199b5bc"));
            ttbutton83 = (ITTButton)AddControl(new Guid("7789a776-0cc0-4858-b26e-4ed73088c6d0"));
            ttbutton82 = (ITTButton)AddControl(new Guid("076ccb68-eb5e-4b35-afc0-06a797fd3dee"));
            ttbutton81 = (ITTButton)AddControl(new Guid("e62369d6-6a92-478c-a3d0-cada8a47cd6a"));
            ttbutton44 = (ITTButton)AddControl(new Guid("60df4656-fde5-433d-bda0-592ae86854c7"));
            ttbutton41 = (ITTButton)AddControl(new Guid("a31d0139-47e1-412f-9363-0f8572ebe00d"));
            ttbutton42 = (ITTButton)AddControl(new Guid("4a6a3e3c-93b0-4c86-a3ef-17536894424d"));
            ttbutton43 = (ITTButton)AddControl(new Guid("a30ae288-c753-4fe2-9653-e9a18c69f7ac"));
            ttbutton45 = (ITTButton)AddControl(new Guid("ae95e672-71ac-47cb-a989-d33e6cc49d93"));
            ttbutton46 = (ITTButton)AddControl(new Guid("1d7ce3a0-2803-4c22-93ee-e4b7092e6e2f"));
            ttbutton47 = (ITTButton)AddControl(new Guid("e4e2a0b4-f1e9-42ca-bcc8-6c061ffbf0f0"));
            ttbutton48 = (ITTButton)AddControl(new Guid("028c959f-3158-4e99-acfb-1063a6814ec8"));
            ttbutton28 = (ITTButton)AddControl(new Guid("0007bff4-4c6b-498b-9923-4b37b95f784b"));
            ttbutton27 = (ITTButton)AddControl(new Guid("20ac3de2-f124-42ab-b6cc-89c0fa91265d"));
            ttbutton26 = (ITTButton)AddControl(new Guid("83a112ab-500c-43a0-b77e-b4f8b404e251"));
            ttbutton25 = (ITTButton)AddControl(new Guid("0caf2ec7-c550-44b7-a4af-ec329302d68f"));
            ttbutton24 = (ITTButton)AddControl(new Guid("1799a3b7-2274-4bab-8bad-802ddf0252ab"));
            ttbutton23 = (ITTButton)AddControl(new Guid("b52ac84e-274a-4193-bcb3-d6703b6da683"));
            ttbutton22 = (ITTButton)AddControl(new Guid("b326b4ce-f1c9-424f-9818-b1d592fb6f9a"));
            ttbutton21 = (ITTButton)AddControl(new Guid("391e43cc-0f10-435a-a57f-a2cf107de875"));
            ttbutton92 = (ITTButton)AddControl(new Guid("fc6a3ee2-1480-46ef-8a77-1fd020e751d2"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("d28a2ad5-df6e-4a88-81df-634460ab4269"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("a2d2403b-9f44-4fde-9bcd-7f158360a9ac"));
            ttbutton65 = (ITTButton)AddControl(new Guid("53a687c6-7e81-4c70-a11b-1cc6c01b5f0b"));
            ttbutton64 = (ITTButton)AddControl(new Guid("3556a8b0-c2f6-4e0b-80f7-d4ea91387cd4"));
            ttbutton63 = (ITTButton)AddControl(new Guid("c88db81f-aabe-4413-a898-b42c676f336a"));
            ttbutton62 = (ITTButton)AddControl(new Guid("88af7c34-405e-46ac-896a-0ff812cd65aa"));
            ttbutton61 = (ITTButton)AddControl(new Guid("7ccccd17-3955-4613-a87f-6328c11fc605"));
            ttbutton11 = (ITTButton)AddControl(new Guid("75a72d21-ba68-4bf4-b702-5147bdef51ec"));
            ttbutton12 = (ITTButton)AddControl(new Guid("f5d7baec-0395-4f2e-9b42-d6fed668c0bc"));
            ttbutton13 = (ITTButton)AddControl(new Guid("bf1fce05-d527-4aaa-84bf-8a29e2ca0daa"));
            ttbutton14 = (ITTButton)AddControl(new Guid("f180a402-e4b7-4e7d-8c47-f646b6ff1906"));
            ttbutton15 = (ITTButton)AddControl(new Guid("ab7dfd8e-8f44-49f5-b891-406094b0456c"));
            ttbutton16 = (ITTButton)AddControl(new Guid("167c6cbc-6bf8-4e7f-b015-5a0fcede6335"));
            ttbutton17 = (ITTButton)AddControl(new Guid("13098a24-8443-4f45-8f03-f39b14193e21"));
            ttbutton18 = (ITTButton)AddControl(new Guid("928de585-6030-42d1-a7a7-b41a7edd664b"));
            ttbutton51 = (ITTButton)AddControl(new Guid("0d9307b4-7fdf-4f9d-9105-977222ee4a5a"));
            ttbutton52 = (ITTButton)AddControl(new Guid("24517d17-323c-47de-825e-e12b75956789"));
            ttbutton53 = (ITTButton)AddControl(new Guid("5cbc8aca-4486-407f-9248-c5ac5ff6ccde"));
            ttbutton54 = (ITTButton)AddControl(new Guid("c9fc9043-33ef-4ffd-9220-f952f866cd05"));
            ttbutton55 = (ITTButton)AddControl(new Guid("8277cbb4-d148-4e0e-8849-873b798a7b58"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("cfab4d27-105a-46d7-b5e2-a847d4df9720"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("8c5e4cac-b1bd-448f-a595-1ecdf7b564d8"));
            ttbutton91 = (ITTButton)AddControl(new Guid("bcb1dfc7-3de6-4cde-b492-85f412eaf5c6"));
            ttbutton5 = (ITTButton)AddControl(new Guid("2ccb8750-9313-43f5-88ea-ffdcd7fe7c87"));
            ttbutton4 = (ITTButton)AddControl(new Guid("6d5b847e-6ef0-47a5-92b1-588ffdbd94a7"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("7c80c5c3-ae12-4a1c-b385-38661fed5768"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("9b7998a1-889d-4764-9242-7da4287d74e0"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("60b8ef2b-e40f-49b0-b2d3-d6f75cf01eaa"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("306caedc-7148-4102-a729-117f7fd83dbc"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("4e00e3a7-f0b5-40fc-b060-f392a9534603"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("8b814f35-aa23-4ee7-9533-2b648df39e5e"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("0bad085e-4058-4ad1-ab3b-a3d230c6cb84"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("d2ba5dea-2b06-43c5-b60d-9775e8cdc8de"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("25a1ce44-bc5d-4f29-b63f-f04b5e16532d"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("f1c49305-1a7f-4ee0-8785-87c41800664b"));
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("2259639b-9b1f-448a-be1a-d9d914affe78"));
            base.InitializeControls();
        }

        public RadiologyDentalToothSchema() : base("RADIOLOGY", "RadiologyDentalToothSchema")
        {
        }

        protected RadiologyDentalToothSchema(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}