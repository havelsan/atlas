
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
    /// Diş Şeması
    /// </summary>
    public partial class DentalToothShemaExSuggTreatmentForm : TTForm
    {
    /// <summary>
    /// Önerilen Diş Tedavi
    /// </summary>
        protected TTObjectClasses.DentalExaminationSuggestedTreatment _DentalExaminationSuggestedTreatment
        {
            get { return (TTObjectClasses.DentalExaminationSuggestedTreatment)_ttObject; }
        }

        protected ITTEnumComboBox ToothNumber;
        protected ITTLabel labelDentalRequestType;
        protected ITTObjectListBox DentalRequestType;
        protected ITTLabel labelSuggestedTreatmentProcedure;
        protected ITTObjectListBox SuggestedTreatmentProcedure;
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
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("80b60d76-5438-4854-a85e-62c87fe11ec0"));
            labelDentalRequestType = (ITTLabel)AddControl(new Guid("81faf142-ff18-4d28-bb24-a98c51ea1cfb"));
            DentalRequestType = (ITTObjectListBox)AddControl(new Guid("374c36c6-7a51-4644-867a-cd5ed6b1e847"));
            labelSuggestedTreatmentProcedure = (ITTLabel)AddControl(new Guid("c4270e65-7142-4e16-aba8-20cc93f99345"));
            SuggestedTreatmentProcedure = (ITTObjectListBox)AddControl(new Guid("b9ec505c-9f47-45b7-b3eb-15a4f4f756b1"));
            labelDepartment = (ITTLabel)AddControl(new Guid("342c2efc-073e-48ae-9b8a-a68ff4b7d9eb"));
            Department = (ITTObjectListBox)AddControl(new Guid("3186d9d9-39a4-4ddc-8ee4-9727eec6c294"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("38a8b6f5-0bcf-4bcd-bf4b-748ce2fefb7a"));
            Definition = (ITTTextBox)AddControl(new Guid("cf4eacf4-f82c-40d9-8d2b-3831aee368b2"));
            Emergency = (ITTCheckBox)AddControl(new Guid("d4d56bb5-1267-4a23-a3db-78e8101030ee"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("e99d58b7-0a74-4368-b65c-b3449292f757"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("0b905914-5ecf-43b1-a24f-739ae925a4a6"));
            labelDefinition = (ITTLabel)AddControl(new Guid("f9280e84-967f-42d3-996b-0ff39c4b4681"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("6117374d-e23e-4115-b13a-58cdcd9b1e52"));
            ttbutton4 = (ITTButton)AddControl(new Guid("48af0e89-dcf6-4865-9d63-80f6be10f142"));
            ttbutton2 = (ITTButton)AddControl(new Guid("16f4f18c-dfe3-4202-a560-aad3b5bdf739"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("2ce52ff7-bd47-43d8-bb3d-a4146189380e"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("88958156-2136-4349-8cdb-39a21a122291"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("046f9df2-358a-4934-895e-047712ea0820"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("564f6148-0a99-4655-b0cb-cbe6e7d7dfaa"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("6d6c08e1-d69b-42ce-bc1e-93e7cc1a1294"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("20c36f97-aece-4073-9cb1-609f72902ef0"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("eec1b9c1-03db-4d91-8adf-83a33a19d111"));
            ttbutton9 = (ITTButton)AddControl(new Guid("fc7f7222-c4f2-4f65-94b4-306353e852dd"));
            ttbutton8 = (ITTButton)AddControl(new Guid("c5f88e14-71fe-44d8-9d86-5704033f67f0"));
            ttbutton7 = (ITTButton)AddControl(new Guid("8ba85d79-2b85-45cd-a9c6-d59f68e02a5d"));
            ttbutton6 = (ITTButton)AddControl(new Guid("5f01b7e8-f8ba-4686-a45e-8f8c0789506e"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("07016d2d-2be7-4dcf-b049-1e63dab71a17"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("b31936af-0131-4e14-9f43-b66889daccb3"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("11cc4b88-a804-4497-8340-364e2201ff42"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("1873c218-9130-41e3-93c8-1b4431224630"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("6be3d20a-9aab-4353-a491-d58aa6b24cd4"));
            ttbutton37 = (ITTButton)AddControl(new Guid("64b49415-8189-4a6b-a232-6c8dddef1cf1"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("b8e4f1e8-d23c-411d-bad3-9ee1f488d27f"));
            ttbutton32 = (ITTButton)AddControl(new Guid("701c6a35-20c4-428e-926a-c0793837ac53"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("633da893-1760-4ab3-ba7e-38a9af6492c3"));
            ttbutton94 = (ITTButton)AddControl(new Guid("7813b893-1ac8-4016-98c4-67d548166811"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("139bf186-c0f1-4348-a455-3ae763c64984"));
            ttbutton38 = (ITTButton)AddControl(new Guid("963ff5aa-4fd5-4679-8154-07c6b3bd3d4b"));
            ttbutton42 = (ITTButton)AddControl(new Guid("2eb78678-7577-41cc-9229-cdeef336d12c"));
            ttbutton71 = (ITTButton)AddControl(new Guid("be99a9b5-f4c3-4c88-a1ba-067fd5d2acd9"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("6eb9a5d9-ca69-48be-ac82-1292a9c6f6e8"));
            ttbutton33 = (ITTButton)AddControl(new Guid("be2dafea-4f78-442b-87a9-6cd700fbb80d"));
            ttbutton47 = (ITTButton)AddControl(new Guid("0295eb23-19d0-4fe4-ae68-e1d26897560c"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("def659cd-a75a-43fb-908d-a292f34fecf2"));
            ttbutton28 = (ITTButton)AddControl(new Guid("b55ed1c5-5b02-495a-845b-c43b00e515f1"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("23e7c008-03f7-41e7-8aff-d7ad76ca5dbd"));
            ttbutton81 = (ITTButton)AddControl(new Guid("62a6f7a0-a7ac-455e-ad27-958f5a319217"));
            ttbutton31 = (ITTButton)AddControl(new Guid("8054da49-9304-4bcb-9cf9-3e269718d568"));
            ttbutton92 = (ITTButton)AddControl(new Guid("1e020ea5-424e-4543-b87c-6a41b8062bc9"));
            ttbutton75 = (ITTButton)AddControl(new Guid("17146e19-3fca-4f38-af8a-91545abf0c67"));
            ttbutton41 = (ITTButton)AddControl(new Guid("cecc31b6-b01b-4dfd-adbd-b78514d2fbcf"));
            ttbutton34 = (ITTButton)AddControl(new Guid("8537ba82-1ec4-4ac1-b151-9daddc0875ad"));
            ttbutton21 = (ITTButton)AddControl(new Guid("d5d4e3f9-694b-4f29-be5a-5144695d8d21"));
            ttbutton74 = (ITTButton)AddControl(new Guid("c62fc4f2-681e-49cb-be18-86c2360cc50d"));
            ttbutton93 = (ITTButton)AddControl(new Guid("d2f5d615-eafb-4e9d-a364-e66f90447ce3"));
            ttbutton35 = (ITTButton)AddControl(new Guid("332f89b5-430b-48ba-ba3a-d90f25a716e6"));
            ttbutton52 = (ITTButton)AddControl(new Guid("1853f87f-68d3-47af-b6cb-ab6e7dfadcd5"));
            ttbutton73 = (ITTButton)AddControl(new Guid("9046fb82-fe85-4e56-8bc3-d906ff522a6c"));
            ttbutton46 = (ITTButton)AddControl(new Guid("63345ca1-3a73-4ff1-a5da-9729b4fe5cfe"));
            ttbutton36 = (ITTButton)AddControl(new Guid("2e131e17-03d9-409c-84b7-3f13cacd53c7"));
            ttbutton27 = (ITTButton)AddControl(new Guid("cd1fb230-104e-40bc-9678-73ed20381aee"));
            ttbutton72 = (ITTButton)AddControl(new Guid("6e701250-0904-482f-bf27-a3b0b9aa5515"));
            ttbutton82 = (ITTButton)AddControl(new Guid("50e2b475-0e3e-449d-8efc-9ae101e04975"));
            ttbutton61 = (ITTButton)AddControl(new Guid("083c62e6-6e69-429f-940e-fa01580487b8"));
            ttbutton83 = (ITTButton)AddControl(new Guid("e9cab410-f5a4-4852-b001-284289669b80"));
            ttbutton26 = (ITTButton)AddControl(new Guid("8fd0ddb9-79e0-42fb-a4d6-735801b3b37f"));
            ttbutton48 = (ITTButton)AddControl(new Guid("a894f617-edce-4923-ba4b-76b3c2ce5979"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("bb70d326-de46-448e-b0e2-3db2d5c9e99a"));
            ttbutton84 = (ITTButton)AddControl(new Guid("43f98794-2f41-4b3c-b6aa-b32a94999de4"));
            ttbutton25 = (ITTButton)AddControl(new Guid("842c80c2-6c33-4839-adef-a26d2e154ea4"));
            ttbutton45 = (ITTButton)AddControl(new Guid("33262911-b1ce-45f4-8206-312af071513c"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("f5c88a7c-d156-46ff-9514-a885895bcb3c"));
            ttbutton85 = (ITTButton)AddControl(new Guid("5c3a976e-a5d6-477d-a2ea-5d27ee63c240"));
            ttbutton24 = (ITTButton)AddControl(new Guid("4c29df7a-9197-4327-bd5b-a3c4a8d19ba1"));
            ttbutton44 = (ITTButton)AddControl(new Guid("ea2cb4ef-f255-4b1b-8efa-b3f65ec8ecac"));
            ttbutton23 = (ITTButton)AddControl(new Guid("fa74791b-5946-43ab-8db1-f1c15098c703"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("d87f2af8-18cd-40c9-a671-895b4593bb35"));
            ttbutton11 = (ITTButton)AddControl(new Guid("04fc31a0-b7a6-433a-97cb-df1f0092dc5b"));
            ttbutton43 = (ITTButton)AddControl(new Guid("c04cdad2-9b3a-48ec-90a5-66af2dd66faf"));
            ttbutton22 = (ITTButton)AddControl(new Guid("74884330-cde0-49e2-9eec-a1ccb691ba09"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("c8d2ce8f-a130-437a-a5d6-f7a6f8322abf"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("c2ce82be-bbb8-4e97-9d0a-44f0230cf89f"));
            ttbutton51 = (ITTButton)AddControl(new Guid("84172f6f-76bd-4193-901b-9f2e67872929"));
            ttbutton65 = (ITTButton)AddControl(new Guid("d3d09f03-93fb-4073-b75b-207b0d4230d8"));
            ttbutton64 = (ITTButton)AddControl(new Guid("29e6f277-6ef9-475c-b2c0-467142de4b35"));
            ttbutton18 = (ITTButton)AddControl(new Guid("1056067d-53fd-43df-83ce-622aa6271a03"));
            ttbutton63 = (ITTButton)AddControl(new Guid("e1e6313b-da07-4d75-bb42-00f0526b4b4d"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("bea66967-38fc-4713-b523-0874f7de3d0b"));
            ttbutton62 = (ITTButton)AddControl(new Guid("8737bf4d-aaa7-4999-9826-14e61eee85d0"));
            ttbutton12 = (ITTButton)AddControl(new Guid("cc06e0df-af28-405e-abfe-fde0bd3c23d7"));
            ttbutton13 = (ITTButton)AddControl(new Guid("2ac41aa3-7b95-4a73-997c-741dd2a078b2"));
            ttbutton91 = (ITTButton)AddControl(new Guid("29c3a1e4-d92a-403c-afed-8eed381c40ae"));
            ttbutton14 = (ITTButton)AddControl(new Guid("15ca616c-35d1-494d-945d-08e5324b23c2"));
            ttbutton55 = (ITTButton)AddControl(new Guid("164e1312-f6c3-434e-9958-34032ced42cc"));
            ttbutton15 = (ITTButton)AddControl(new Guid("ffbfde64-10bf-4d8a-9fc3-84a2cbf36a1d"));
            ttbutton54 = (ITTButton)AddControl(new Guid("a85fdd41-742c-46fb-9042-0ec9091cbff3"));
            ttbutton16 = (ITTButton)AddControl(new Guid("283676dc-96ec-4fbd-8938-4c68a6e3d578"));
            ttbutton53 = (ITTButton)AddControl(new Guid("c2da5dd5-7a8d-4493-96b1-f6d82bba0c97"));
            ttbutton17 = (ITTButton)AddControl(new Guid("fd845537-8129-4c94-88e6-5d425f13290e"));
            base.InitializeControls();
        }

        public DentalToothShemaExSuggTreatmentForm() : base("DENTALEXAMINATIONSUGGESTEDTREATMENT", "DentalToothShemaExSuggTreatmentForm")
        {
        }

        protected DentalToothShemaExSuggTreatmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}