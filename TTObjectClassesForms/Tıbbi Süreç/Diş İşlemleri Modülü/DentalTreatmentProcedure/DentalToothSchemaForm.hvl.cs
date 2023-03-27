
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
    public partial class DentalToothSchema : TTForm
    {
    /// <summary>
    /// Diş Tedavi Prosedür
    /// </summary>
        protected TTObjectClasses.DentalTreatmentProcedure _DentalTreatmentProcedure
        {
            get { return (TTObjectClasses.DentalTreatmentProcedure)_ttObject; }
        }

        protected ITTEnumComboBox ToothNumber;
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
        protected ITTLabel labelDentalPosition;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelToothNumber;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelProcedure;
        override protected void InitializeControls()
        {
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("fbeb5d96-c810-4921-becf-4d58107c1dd5"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("dc88ff65-8691-42d2-8eee-9992ece0437b"));
            ttbutton4 = (ITTButton)AddControl(new Guid("9b56ac0a-261d-4a5c-973a-1a1dc18a6d16"));
            ttbutton2 = (ITTButton)AddControl(new Guid("e03c38dd-9422-4046-9975-264d3bb70b86"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("1f198af5-fb8e-4236-b508-b864fa2d7488"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("fdb61b3d-df78-4bc8-ab2f-2f97c7493a02"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("5d010aab-475c-4b57-b23c-edec0bba16c8"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("15726769-fb37-4cf9-9917-5342ae278e99"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("cd884ec4-a262-451b-b4aa-7203a79e9d5d"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("5ded2e81-4607-41e4-88f1-0ea4669a50ab"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("a7dbd573-e6b3-4fc8-b08c-a410dff0bc7f"));
            ttbutton9 = (ITTButton)AddControl(new Guid("ca1d7a4d-6c6b-4a7e-878c-b656304b30af"));
            ttbutton8 = (ITTButton)AddControl(new Guid("98c92314-477a-42c9-88eb-ef782561e394"));
            ttbutton7 = (ITTButton)AddControl(new Guid("15a38c75-65c5-4000-b607-45615eed201e"));
            ttbutton6 = (ITTButton)AddControl(new Guid("533d79be-2116-41f5-aeee-d40db96da777"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("7f2f8c98-a812-4750-8a4c-d6e7535170a8"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("714e7834-326f-48de-918c-bdfec3d50c5e"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("93fbf12e-fe23-4f6b-83fa-b8aabf442356"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("17faa295-4e01-4b98-adc8-470ecdfb75af"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("810bfb22-2562-4e93-bbc6-7d3fb2c07aaf"));
            ttbutton37 = (ITTButton)AddControl(new Guid("5341616e-d66a-490c-a0c8-630451905013"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("4090021e-c9af-434c-b18b-799aa7eb22b8"));
            ttbutton32 = (ITTButton)AddControl(new Guid("ee054bad-16fe-40b3-acef-3c1cd25e6d16"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("17e8dfa9-4576-4865-992b-d72d1de4130b"));
            ttbutton94 = (ITTButton)AddControl(new Guid("84c4fdfa-b6e3-4cd8-aac9-544bfe68f7d4"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("c37189eb-32f3-465c-8459-fcc32de1641c"));
            ttbutton38 = (ITTButton)AddControl(new Guid("2f4ffecc-85e9-47e3-a3f5-3d9589224036"));
            ttbutton42 = (ITTButton)AddControl(new Guid("b89b5963-0dfd-44a8-ae8c-4ad7c1ee2d94"));
            ttbutton71 = (ITTButton)AddControl(new Guid("8311a111-5872-4888-a91b-3fb278560317"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("aa290ab0-c6bc-43bf-aa83-a77b0836893c"));
            ttbutton33 = (ITTButton)AddControl(new Guid("38c0cb9b-c34c-487b-9eae-56a7b22d9c1b"));
            ttbutton47 = (ITTButton)AddControl(new Guid("dcbc877d-1f67-4944-992a-ff5eb29b5859"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("baca055c-e7a5-48f7-b13c-97490c0afb34"));
            ttbutton28 = (ITTButton)AddControl(new Guid("f8626ef7-4cad-4b6c-bce2-689fbd2746b1"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("de72ead6-bf41-47e7-88cd-994d2b8cedd8"));
            ttbutton81 = (ITTButton)AddControl(new Guid("5444c6dc-3e6d-424c-95a4-a885612fe41f"));
            ttbutton31 = (ITTButton)AddControl(new Guid("cfed5669-bfdd-4611-8c67-cb17eb8aa245"));
            ttbutton92 = (ITTButton)AddControl(new Guid("344ec498-e787-4277-92bf-522aac3922f5"));
            ttbutton75 = (ITTButton)AddControl(new Guid("01d7a3ff-223d-455a-a73b-ba97869d4d6e"));
            ttbutton41 = (ITTButton)AddControl(new Guid("eee9f1aa-94cb-456c-9bb2-6095f40bf790"));
            ttbutton34 = (ITTButton)AddControl(new Guid("398049df-c6b4-4cf0-bee6-3da184676ad4"));
            ttbutton21 = (ITTButton)AddControl(new Guid("cc2a36a1-671f-41e9-b8dc-645b82c41437"));
            ttbutton74 = (ITTButton)AddControl(new Guid("d9a47aa0-8245-4956-a8fc-64941f285bb7"));
            ttbutton93 = (ITTButton)AddControl(new Guid("2047be7f-b22d-4787-8041-0a1c5acbf89e"));
            ttbutton35 = (ITTButton)AddControl(new Guid("56faa769-693f-44d6-b567-63cebdc7f3ba"));
            ttbutton52 = (ITTButton)AddControl(new Guid("a980dd13-adc1-486c-8ad1-90756c4281d7"));
            ttbutton73 = (ITTButton)AddControl(new Guid("6e33e2fa-63be-40ec-98e6-97039015d2ce"));
            ttbutton46 = (ITTButton)AddControl(new Guid("8943fb83-7745-48c7-94f1-0d919a408d17"));
            ttbutton36 = (ITTButton)AddControl(new Guid("c8b6da8a-832f-4216-bf6b-f247316492f9"));
            ttbutton27 = (ITTButton)AddControl(new Guid("e17f3a5b-2d02-4a96-8941-346a87c528a7"));
            ttbutton72 = (ITTButton)AddControl(new Guid("370426ed-55b4-4265-aea0-afbb29dfe7a3"));
            ttbutton82 = (ITTButton)AddControl(new Guid("4431be56-82aa-4cfe-ba1e-416aeb5ece9d"));
            ttbutton61 = (ITTButton)AddControl(new Guid("1e7f394f-abbe-4075-a1c6-2271f29814a2"));
            ttbutton83 = (ITTButton)AddControl(new Guid("72764079-2cbe-4e51-9676-d78bd6978e99"));
            ttbutton26 = (ITTButton)AddControl(new Guid("5ff3040b-8bbc-4ace-ac29-5fc38265ccbc"));
            ttbutton48 = (ITTButton)AddControl(new Guid("8031ef54-db36-45af-90d2-04ee7b11a440"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("cc81ea38-3102-4594-900b-0abd3ca50bcf"));
            ttbutton84 = (ITTButton)AddControl(new Guid("f94ddee1-24c5-4f14-b5fa-8aa5b5c44a43"));
            ttbutton25 = (ITTButton)AddControl(new Guid("6bf5c96b-3447-4bc5-9412-587a20bff184"));
            ttbutton45 = (ITTButton)AddControl(new Guid("2473d520-8734-4235-9251-e13215543177"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("4f0a38cf-f72d-4a67-806b-97df8e05e4a4"));
            ttbutton85 = (ITTButton)AddControl(new Guid("4a15a2c5-bd30-483b-a832-4878a0ed84f9"));
            ttbutton24 = (ITTButton)AddControl(new Guid("df5c85f0-8bbb-492a-9f76-cebb91730965"));
            ttbutton44 = (ITTButton)AddControl(new Guid("1ee9a9d9-f522-4dbc-bda5-72e2eff0931a"));
            ttbutton23 = (ITTButton)AddControl(new Guid("6485102a-b2cb-4a72-8f76-738a01febaf0"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("8ecebd59-1035-48e9-97ac-4c2355c00476"));
            ttbutton11 = (ITTButton)AddControl(new Guid("ea5a8250-bcf7-4d4a-9027-efccbd3d7c01"));
            ttbutton43 = (ITTButton)AddControl(new Guid("7f374a4a-2880-48dd-9688-3e0167f114a4"));
            ttbutton22 = (ITTButton)AddControl(new Guid("aed55be3-b444-41f1-9b70-149d149a1022"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("438d1e9a-2cc3-4cb6-9ba7-59cd87f0e706"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("17ce17e2-7d75-4ce8-ad60-aeb821b4cf85"));
            ttbutton51 = (ITTButton)AddControl(new Guid("b6a68d56-43ca-445e-a116-ef413450303a"));
            ttbutton65 = (ITTButton)AddControl(new Guid("ee1345af-0429-48e9-bdec-4edb63ecc81f"));
            ttbutton64 = (ITTButton)AddControl(new Guid("36bb4f52-92c7-48be-8cba-c05ccf9ab902"));
            ttbutton18 = (ITTButton)AddControl(new Guid("40cfc9eb-ced8-4061-bf2e-4484e1dd559c"));
            ttbutton63 = (ITTButton)AddControl(new Guid("df62547b-8369-42b4-b742-93603224612c"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("6a036a62-8801-41e6-aafe-3860207f587a"));
            ttbutton62 = (ITTButton)AddControl(new Guid("9f64730f-235d-4261-b92d-0877b2520737"));
            ttbutton12 = (ITTButton)AddControl(new Guid("203eac52-9739-40a1-8dff-9ed0c708ea8e"));
            ttbutton13 = (ITTButton)AddControl(new Guid("252ee02b-48ba-457f-ba01-97c4d8e8302b"));
            ttbutton91 = (ITTButton)AddControl(new Guid("13b37261-0b2b-4fec-a6bf-1ff627b19137"));
            ttbutton14 = (ITTButton)AddControl(new Guid("3235a46a-b96a-43e2-95ea-d397f0e1f888"));
            ttbutton55 = (ITTButton)AddControl(new Guid("05f684bf-5e5e-467e-a809-5888e9cad25d"));
            ttbutton15 = (ITTButton)AddControl(new Guid("bc0f9bcd-e402-4d76-9095-515c4a6e4026"));
            ttbutton54 = (ITTButton)AddControl(new Guid("1fbc9f48-14de-485e-8ce3-ae4a5be3c0db"));
            ttbutton16 = (ITTButton)AddControl(new Guid("42a51be2-ab93-4563-bed4-0531a424b066"));
            ttbutton53 = (ITTButton)AddControl(new Guid("fb9840da-1930-42eb-b553-0da98ca17ad9"));
            ttbutton17 = (ITTButton)AddControl(new Guid("382f1f6e-1ee5-401e-a49e-abf8db1233a2"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("301c1077-693c-4998-ac7a-803fc2de4631"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("2d51784a-0933-4665-9da2-b2ee76e307da"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("49baa41d-5c7e-4b85-ae8e-cc1a68d1cf0e"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("97c6890b-e23d-4813-b14f-a4b6b59ba90e"));
            labelProcedure = (ITTLabel)AddControl(new Guid("3e698852-cd55-40ec-a8c1-62de39ba7085"));
            base.InitializeControls();
        }

        public DentalToothSchema() : base("DENTALTREATMENTPROCEDURE", "DentalToothSchema")
        {
        }

        protected DentalToothSchema(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}