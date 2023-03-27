
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
    public partial class ToothSchemaDentalTreatReqSuggTreatmentForm : TTForm
    {
        protected TTObjectClasses.DentalTreatmentRequestSuggestedTreatment _DentalTreatmentRequestSuggestedTreatment
        {
            get { return (TTObjectClasses.DentalTreatmentRequestSuggestedTreatment)_ttObject; }
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
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("8d2b396e-6bc5-496d-aba7-a9878af0c090"));
            labelDentalRequestType = (ITTLabel)AddControl(new Guid("7d3b4c83-debf-4c61-9249-a7f61550d716"));
            DentalRequestType = (ITTObjectListBox)AddControl(new Guid("ffe17227-0da7-46dc-8685-d868fc14ce2d"));
            labelSuggestedTreatmentProcedure = (ITTLabel)AddControl(new Guid("3760d83f-9dd1-405e-9fe9-277fd25d7da7"));
            SuggestedTreatmentProcedure = (ITTObjectListBox)AddControl(new Guid("50d38203-58f9-4f6c-a936-2a26a265474a"));
            labelDepartment = (ITTLabel)AddControl(new Guid("336f8cc7-876c-4a77-8f1d-c534d54e2979"));
            Department = (ITTObjectListBox)AddControl(new Guid("e8adf797-bf31-4b89-a670-a006999bae28"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("f7fab5b0-fe00-4029-bf8f-3549873796e8"));
            Definition = (ITTTextBox)AddControl(new Guid("219c0769-ad21-4f5b-b49d-6ee7065980d6"));
            Emergency = (ITTCheckBox)AddControl(new Guid("a7d88a1b-71b7-4e6c-8e73-78a757db1aae"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("9f0eaf42-efa5-4d92-b27e-56c0aa7474b7"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("ea490e1a-4852-4f0e-9eba-27dc67b5d438"));
            labelDefinition = (ITTLabel)AddControl(new Guid("021755c5-bbec-47f6-bc53-1550d7875ffe"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("0b9e922a-0bc6-4d88-a311-10c0b63d84d4"));
            ttbutton4 = (ITTButton)AddControl(new Guid("5a955d6b-fd5d-4e06-951e-214613cfa9bf"));
            ttbutton2 = (ITTButton)AddControl(new Guid("cc836a2d-33c1-4356-ac66-cf1543d736e0"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("29e9c411-3d85-428f-a976-31b19f2130f8"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("30f4e9e8-78bd-4ca3-949e-c7902cf3989d"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("0cab08ea-f587-46d5-b4d2-7b34b12bf365"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("08cc128e-e9ff-4414-8e3b-e0f9b09ab34d"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("88304e2f-d4f0-4951-ad04-3a844451c454"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("a51ffa9e-80b2-43e8-b7f9-3cc02f6f21e2"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("450c9cf3-4246-4889-9de0-e3b58c004922"));
            ttbutton9 = (ITTButton)AddControl(new Guid("7534b9f9-a917-4434-b44f-65f7bf3e6084"));
            ttbutton8 = (ITTButton)AddControl(new Guid("f5259000-ab6e-4bab-8385-f3642b851297"));
            ttbutton7 = (ITTButton)AddControl(new Guid("667fed43-813c-4102-aecb-2af73334d30d"));
            ttbutton6 = (ITTButton)AddControl(new Guid("373d1b9a-4a9a-4bb5-a2f9-0fbe3e37bb22"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("ff60abb0-95d0-4df6-9862-6e08c4ea8042"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("308573da-3f1e-48dc-acac-f5bd4531f64b"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("a463806f-6d71-4e8e-9885-e9f6fd4ef75e"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("90ace9ad-6e75-4f53-bf60-f12ff60dd328"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("d9531591-dc51-40b5-b07f-9a14d4327f42"));
            ttbutton37 = (ITTButton)AddControl(new Guid("691f9c2c-8562-4c76-9d61-d47f0b5a5529"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("1224516d-5cc4-4639-83da-7b3aef580905"));
            ttbutton32 = (ITTButton)AddControl(new Guid("30656438-24e2-4382-81a5-4cfafe0efe39"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("b5aca883-590d-4882-b552-64937ecd741d"));
            ttbutton94 = (ITTButton)AddControl(new Guid("bbe49482-7e2d-451b-a03c-677101cae67c"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("be6471de-c423-4021-9166-e95a997327cc"));
            ttbutton38 = (ITTButton)AddControl(new Guid("572e6b31-5304-49c4-b120-317398c441fa"));
            ttbutton42 = (ITTButton)AddControl(new Guid("efbfe05d-9e49-4be1-af59-6dd0c7218800"));
            ttbutton71 = (ITTButton)AddControl(new Guid("4fd2008c-5700-40af-8d3d-afab40eba87e"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("ab1a9281-d5cb-4fd2-8fd7-469a988032de"));
            ttbutton33 = (ITTButton)AddControl(new Guid("cb769810-728d-4ed0-a3e5-1e958bd35660"));
            ttbutton47 = (ITTButton)AddControl(new Guid("e1c78547-ef14-4c69-9b94-a9b24451e9b6"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("6f64aff2-b8f1-4908-894f-67f97b7385dc"));
            ttbutton28 = (ITTButton)AddControl(new Guid("90e7545a-8729-4a4d-89ae-55f8c1cc9cf9"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("d478d738-cfa0-4b51-9a42-080825505495"));
            ttbutton81 = (ITTButton)AddControl(new Guid("5b9d743c-a6a7-464a-afb5-dbe61d309a15"));
            ttbutton31 = (ITTButton)AddControl(new Guid("04976c93-fbaa-445d-b5f0-489cc3a7e525"));
            ttbutton92 = (ITTButton)AddControl(new Guid("88167ef4-758c-4e58-a3fd-220e24de9a0b"));
            ttbutton75 = (ITTButton)AddControl(new Guid("42272484-8d6d-472e-a5e6-b738049c21cf"));
            ttbutton41 = (ITTButton)AddControl(new Guid("eae08408-e7c3-4d1f-888b-0ab822cc42e5"));
            ttbutton34 = (ITTButton)AddControl(new Guid("e4e9fc0a-a666-47f3-b632-e3e9860fe0ea"));
            ttbutton21 = (ITTButton)AddControl(new Guid("fa0df570-f94d-45cb-b379-980741b02c88"));
            ttbutton74 = (ITTButton)AddControl(new Guid("2b8f916e-ce56-4fc5-9432-351ebc8d8aa8"));
            ttbutton93 = (ITTButton)AddControl(new Guid("ff2238b3-223d-4a27-ba6b-96e3a798f37a"));
            ttbutton35 = (ITTButton)AddControl(new Guid("a5629db2-2044-482b-9add-8fe8906c6fbb"));
            ttbutton52 = (ITTButton)AddControl(new Guid("5a884479-048c-4baa-9467-cfe565cce5e1"));
            ttbutton73 = (ITTButton)AddControl(new Guid("01ddf4e8-5426-4e19-9e4e-508116c9de78"));
            ttbutton46 = (ITTButton)AddControl(new Guid("664ba73b-b4f3-4905-aae4-0b6cc228dafb"));
            ttbutton36 = (ITTButton)AddControl(new Guid("4273b06a-b6b6-4f9f-be89-4fe13c54e1b7"));
            ttbutton27 = (ITTButton)AddControl(new Guid("6732e56b-61e3-4b49-981c-b408b91bf627"));
            ttbutton72 = (ITTButton)AddControl(new Guid("89c73ac8-b311-4afc-8bbd-e15f6d770c0f"));
            ttbutton82 = (ITTButton)AddControl(new Guid("58b5b884-d108-440a-a82a-e0b684229620"));
            ttbutton61 = (ITTButton)AddControl(new Guid("5b8156e9-93c8-4966-b139-dc5f801dd7fb"));
            ttbutton83 = (ITTButton)AddControl(new Guid("275f95cc-5bfb-4434-88ac-7da32b3dbc3c"));
            ttbutton26 = (ITTButton)AddControl(new Guid("45affafa-c1fd-4936-9a5e-3467a78ca602"));
            ttbutton48 = (ITTButton)AddControl(new Guid("3c324e04-6c0a-4aff-93b0-6bd1e63ed45c"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("56d79bdf-ea1d-452e-a2b3-221b00fa85bc"));
            ttbutton84 = (ITTButton)AddControl(new Guid("50d944be-e0ce-403c-91fd-c46114de5e94"));
            ttbutton25 = (ITTButton)AddControl(new Guid("d87d6dd2-8720-4652-8519-c1f3c77d12d0"));
            ttbutton45 = (ITTButton)AddControl(new Guid("c8685698-1295-4a38-b1a5-caa074bbb8a5"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("a7d89ea1-a53c-478f-8c2f-c916b6f2b2e3"));
            ttbutton85 = (ITTButton)AddControl(new Guid("1d429725-c221-463f-8c3c-769cb3c18f8b"));
            ttbutton24 = (ITTButton)AddControl(new Guid("ba5f8d10-271b-4801-badb-f8f610dec3cc"));
            ttbutton44 = (ITTButton)AddControl(new Guid("fa7763bc-053b-4042-b8b2-18c096438d2c"));
            ttbutton23 = (ITTButton)AddControl(new Guid("b8ac6a14-b8de-4978-a8e4-49c144f1f496"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("60be44a7-c873-487b-a61b-2b4d78ed6754"));
            ttbutton11 = (ITTButton)AddControl(new Guid("e88a2bdc-aa36-4204-925f-397410f10d95"));
            ttbutton43 = (ITTButton)AddControl(new Guid("6df259ed-bc33-4abe-b427-2a1e065b9d3b"));
            ttbutton22 = (ITTButton)AddControl(new Guid("b8ab32c5-3797-483c-9aaf-7868ff22536a"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("32125bcd-1726-4bb0-a13b-e1309c1ed9c7"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("cad4ca4c-b17b-4d9d-a674-0ed529f34b3a"));
            ttbutton51 = (ITTButton)AddControl(new Guid("d938dbcc-20a0-43aa-8f24-6b09b3c1249a"));
            ttbutton65 = (ITTButton)AddControl(new Guid("692ac322-ac17-4678-9246-2382fac4d90c"));
            ttbutton64 = (ITTButton)AddControl(new Guid("30ee0fc5-7fa9-44e6-9a9b-854ce46a64ed"));
            ttbutton18 = (ITTButton)AddControl(new Guid("dbc47815-12a2-4c92-8fc6-8e34a4825614"));
            ttbutton63 = (ITTButton)AddControl(new Guid("dce3903c-8d11-4d07-a60f-21724ac091f1"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("ca78569e-4e08-4d84-91c3-3fc1b73981e0"));
            ttbutton62 = (ITTButton)AddControl(new Guid("417edc46-209e-4fb1-b558-2bfe4430924a"));
            ttbutton12 = (ITTButton)AddControl(new Guid("d02538f2-e5e0-4966-8994-e243059cd634"));
            ttbutton13 = (ITTButton)AddControl(new Guid("4c4bbd71-0daf-4ddc-9d33-34e08bd67010"));
            ttbutton91 = (ITTButton)AddControl(new Guid("f4c641b3-7f86-422a-9b58-bc358dcd25e9"));
            ttbutton14 = (ITTButton)AddControl(new Guid("07f6fc00-c31c-4f68-8f8a-b903fd77a70f"));
            ttbutton55 = (ITTButton)AddControl(new Guid("0320fc6b-5d15-4c5b-bbbe-6a59550670c3"));
            ttbutton15 = (ITTButton)AddControl(new Guid("6e0325c5-0e08-492d-b5c7-a0e0b784fee7"));
            ttbutton54 = (ITTButton)AddControl(new Guid("75cafa93-f612-4c40-b379-388c7d4edbe7"));
            ttbutton16 = (ITTButton)AddControl(new Guid("b9714b3b-9f34-4960-a03f-00bfac355d39"));
            ttbutton53 = (ITTButton)AddControl(new Guid("8e912583-64b1-4722-aa6a-561cd19556e0"));
            ttbutton17 = (ITTButton)AddControl(new Guid("dfddcd76-0cd7-4648-8c20-fe4137bf15a3"));
            base.InitializeControls();
        }

        public ToothSchemaDentalTreatReqSuggTreatmentForm() : base("DENTALTREATMENTREQUESTSUGGESTEDTREATMENT", "ToothSchemaDentalTreatReqSuggTreatmentForm")
        {
        }

        protected ToothSchemaDentalTreatReqSuggTreatmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}