
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
    public partial class DentalToothSchemaSugProsthesis : TTForm
    {
    /// <summary>
    /// Önerilen Diş  Protezi
    /// </summary>
        protected TTObjectClasses.DentalExaminationSuggestedProsthesis _DentalExaminationSuggestedProsthesis
        {
            get { return (TTObjectClasses.DentalExaminationSuggestedProsthesis)_ttObject; }
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
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("a970d8f6-946d-45ae-aab4-1a88ef068557"));
            labelSuggestedProsthesisProcedure = (ITTLabel)AddControl(new Guid("ff74ba1b-2834-4652-b1e3-df9abcab3271"));
            SuggestedProsthesisProcedure = (ITTObjectListBox)AddControl(new Guid("897ad400-d77e-49da-b201-e2b46f3f53d7"));
            labelDepartment = (ITTLabel)AddControl(new Guid("f02f6923-e9b9-497a-9960-fb6a0728ed16"));
            Department = (ITTObjectListBox)AddControl(new Guid("2fb8b6e2-bbb8-43cf-9dc4-6ab6ab07bd48"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("d6cb2640-baf2-45f8-b53d-8ee27d51658e"));
            Definition = (ITTTextBox)AddControl(new Guid("29d4a6f5-6a31-49e6-bbfc-bde83e39e30c"));
            Emergency = (ITTCheckBox)AddControl(new Guid("23b81ede-acc3-429b-9100-67308dcac1fc"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("7500fcfb-605c-42cf-bee7-06affced089d"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("f9ed28ba-0d15-4d34-827c-a376387041a9"));
            labelDefinition = (ITTLabel)AddControl(new Guid("dd2f1679-3132-42cc-b7fb-85784c435d82"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("db08c4c3-5bf4-4172-b30b-91ee446b13b4"));
            ttbutton4 = (ITTButton)AddControl(new Guid("4097e49b-7b82-47df-b681-00fc2c3da18e"));
            ttbutton2 = (ITTButton)AddControl(new Guid("3a6fb108-9e4b-482b-a3e1-61bb90bbca75"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("532a7b57-4805-4123-bedf-bd5870cf705a"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("45e75df1-265f-4d42-8f26-8956e23709df"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("8b296d2d-08c5-41e3-afd9-69eb2a38d606"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("5ecce13a-09a2-4d66-8e78-24954577fb6f"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("bd6b43d7-e002-49c6-b5f1-d5768cb90a68"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("ff321985-5048-4589-b82a-3a93259d45c8"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("ff831462-f2f9-41c8-9076-19cfa8be2df3"));
            ttbutton9 = (ITTButton)AddControl(new Guid("e2e117dd-44ec-4097-a0ab-b0b755406057"));
            ttbutton8 = (ITTButton)AddControl(new Guid("98561d0e-4668-4df9-8642-e0d1a345079a"));
            ttbutton7 = (ITTButton)AddControl(new Guid("abf80889-ff19-4f5d-aa09-68b1a6b3b844"));
            ttbutton6 = (ITTButton)AddControl(new Guid("6f5d8831-64ce-4a83-8ed7-1411816a4992"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("33b9c46c-bc9f-4ac2-b85e-76714bf84a4b"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("bd3d12ca-266d-407b-be7e-9c34ada1c733"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("167cf015-d4a4-4e23-b764-e68bcca24119"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("b1ab2bf6-d16e-45b8-8f82-c9943a987e7b"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("2fc68c76-a611-4088-a5fa-f73197569bf5"));
            ttbutton37 = (ITTButton)AddControl(new Guid("55b9e00f-2bfd-48f0-aca1-a72f92106bcf"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("d30b0cc2-9c21-4768-b35b-c0234d8c5c17"));
            ttbutton32 = (ITTButton)AddControl(new Guid("f9f318da-f977-4ccf-92b9-d8cdf60f43ce"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("8b5ccebc-e941-4417-9145-4ea27ddcf539"));
            ttbutton94 = (ITTButton)AddControl(new Guid("26056ca4-f8f4-420e-a076-8618a206f434"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("6c5d35b1-71e7-462a-a437-11c1e7ebe343"));
            ttbutton38 = (ITTButton)AddControl(new Guid("c3d90f01-cd16-4b9f-889f-2c15ce43aaa1"));
            ttbutton42 = (ITTButton)AddControl(new Guid("920d1a1f-cafb-4e77-ad99-bdf950808582"));
            ttbutton71 = (ITTButton)AddControl(new Guid("210fb6e5-15f7-4797-9b01-decfa426422a"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("7ee728c6-0a05-4a95-b749-797caf307f97"));
            ttbutton33 = (ITTButton)AddControl(new Guid("f64adb11-a227-4523-8b44-b21046ffe6b8"));
            ttbutton47 = (ITTButton)AddControl(new Guid("62744c20-de15-41f0-93ec-1886f6d845e6"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("4d7ffd69-bbb4-410c-9d28-d054fbf13aa7"));
            ttbutton28 = (ITTButton)AddControl(new Guid("383e8606-38d3-4be2-8306-079ed06b469d"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("b7332ed5-42f3-4a6b-aadb-34b2e9e4c0c8"));
            ttbutton81 = (ITTButton)AddControl(new Guid("b9af23d9-66c6-4440-95e8-95d1a57e8711"));
            ttbutton31 = (ITTButton)AddControl(new Guid("ce4e9e4d-6e3c-48f8-af39-343f6ea27d1c"));
            ttbutton92 = (ITTButton)AddControl(new Guid("5471002c-fc8e-4e05-96ec-96e032147811"));
            ttbutton75 = (ITTButton)AddControl(new Guid("dde3b4b2-5321-43e4-8d6c-e7c06d1db7e1"));
            ttbutton41 = (ITTButton)AddControl(new Guid("2fd78ec9-5589-4e2c-8034-f2735950805b"));
            ttbutton34 = (ITTButton)AddControl(new Guid("430cdd7f-32f6-4817-b3f0-137d1e0b352c"));
            ttbutton21 = (ITTButton)AddControl(new Guid("9d5f7693-4b61-4def-b8c8-60e8242f8c85"));
            ttbutton74 = (ITTButton)AddControl(new Guid("073927dd-fbfb-4eb8-a7c3-a7d213d65bdd"));
            ttbutton93 = (ITTButton)AddControl(new Guid("b98fd55f-eb6a-4747-bed3-57b5c2eeaaa7"));
            ttbutton35 = (ITTButton)AddControl(new Guid("150bf5a1-5807-4cbc-8bbe-57588a2705fd"));
            ttbutton52 = (ITTButton)AddControl(new Guid("aba38013-e6a7-4aa4-9a99-0297ce9c6114"));
            ttbutton73 = (ITTButton)AddControl(new Guid("5a360048-e326-4b45-931b-99a608d3e2ce"));
            ttbutton46 = (ITTButton)AddControl(new Guid("bdc8c343-75de-44a7-8195-d15abd2733bb"));
            ttbutton36 = (ITTButton)AddControl(new Guid("bdf0c72d-3dfe-4482-b2a4-f0978ec2ca89"));
            ttbutton27 = (ITTButton)AddControl(new Guid("2ed4561d-5a88-4c4f-b644-35f3cfe7dc11"));
            ttbutton72 = (ITTButton)AddControl(new Guid("b91279ce-785e-44a1-9320-4a482b440a94"));
            ttbutton82 = (ITTButton)AddControl(new Guid("6c8a3fee-adf3-4945-bdb6-d6787b9196b0"));
            ttbutton61 = (ITTButton)AddControl(new Guid("5b647328-b8af-44cf-aa7c-d890d1de794f"));
            ttbutton83 = (ITTButton)AddControl(new Guid("bf86ac02-916a-4fdb-bf69-f0d7f11e0e9f"));
            ttbutton26 = (ITTButton)AddControl(new Guid("78a3adf4-ce5e-430f-8301-8809def66f82"));
            ttbutton48 = (ITTButton)AddControl(new Guid("8504333e-5b88-4359-bc50-0b50d50c62f0"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("40f4e659-d6cb-4557-9d55-7afaa08a63b1"));
            ttbutton84 = (ITTButton)AddControl(new Guid("4877455d-953a-4c36-b504-051e8eaaabea"));
            ttbutton25 = (ITTButton)AddControl(new Guid("ebeccf72-f13d-4abe-9e68-1b06bd1530b6"));
            ttbutton45 = (ITTButton)AddControl(new Guid("c4c4e4dd-2a74-4f5f-a93f-8e65a5125df2"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("88b10234-7d6f-4507-8395-a1e0c15dc725"));
            ttbutton85 = (ITTButton)AddControl(new Guid("384ebf92-2c93-4da1-a324-f46855963f43"));
            ttbutton24 = (ITTButton)AddControl(new Guid("2791ad0e-58df-45de-9b6f-572f7fc475d4"));
            ttbutton44 = (ITTButton)AddControl(new Guid("9cae444b-ad6a-433b-bcd2-a26b54685662"));
            ttbutton23 = (ITTButton)AddControl(new Guid("b6ffd270-daba-47ad-9413-0e6f7d502ed5"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("9ba4bf43-a51e-48eb-927f-e0319f318b8f"));
            ttbutton11 = (ITTButton)AddControl(new Guid("2e878728-aef0-4fb9-bb1e-2faa05765de3"));
            ttbutton43 = (ITTButton)AddControl(new Guid("f5be4b7a-c228-4d12-99a5-4cfbfde348bb"));
            ttbutton22 = (ITTButton)AddControl(new Guid("a3d215ba-f0b8-4939-8050-cff4a9236560"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("53bf45ff-3198-4383-a0eb-ece1f0a11fa1"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("8e5119b3-6de9-4dab-8348-cd623dedd7c1"));
            ttbutton51 = (ITTButton)AddControl(new Guid("5f8a780f-c1f8-4094-bcf1-f5a0a59561ac"));
            ttbutton65 = (ITTButton)AddControl(new Guid("c379858e-7e90-40ea-b9ec-b68b92faa783"));
            ttbutton64 = (ITTButton)AddControl(new Guid("0f256f58-26a1-4691-b6e1-d9a9ada37fdc"));
            ttbutton18 = (ITTButton)AddControl(new Guid("557603c3-b346-4640-b554-7f82024f47bc"));
            ttbutton63 = (ITTButton)AddControl(new Guid("3393c5a1-70fd-4476-8690-3de6fb9c7044"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("b156e39b-8cc1-4231-b0d0-7ac17207fd94"));
            ttbutton62 = (ITTButton)AddControl(new Guid("153a85c9-cd6e-4fb0-89a1-7213aa0af83e"));
            ttbutton12 = (ITTButton)AddControl(new Guid("86dac6c5-1953-4096-b44e-f2f6f03796e2"));
            ttbutton13 = (ITTButton)AddControl(new Guid("a3762468-9474-4b3b-9316-6ba2a307effa"));
            ttbutton91 = (ITTButton)AddControl(new Guid("f8e7e689-c553-4bbe-b977-7a4536374974"));
            ttbutton14 = (ITTButton)AddControl(new Guid("b5f6394b-eaa6-4870-943e-63fe2d570077"));
            ttbutton55 = (ITTButton)AddControl(new Guid("5ea3ecac-78da-4efd-a8b7-9c4e3d75ab33"));
            ttbutton15 = (ITTButton)AddControl(new Guid("d461a161-ef16-4395-be1e-d844620d9034"));
            ttbutton54 = (ITTButton)AddControl(new Guid("d491e263-8a53-4c8c-ac38-73acbbc1cece"));
            ttbutton16 = (ITTButton)AddControl(new Guid("28c071c0-3001-4506-966f-573bd9e9c3ad"));
            ttbutton53 = (ITTButton)AddControl(new Guid("b26a467f-a5a5-4d06-98e5-d5a1d7726a76"));
            ttbutton17 = (ITTButton)AddControl(new Guid("1ab561b2-86c8-4b7a-b6d8-d439440063d1"));
            base.InitializeControls();
        }

        public DentalToothSchemaSugProsthesis() : base("DENTALEXAMINATIONSUGGESTEDPROSTHESIS", "DentalToothSchemaSugProsthesis")
        {
        }

        protected DentalToothSchemaSugProsthesis(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}