
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
    public partial class RadiologyTestDentalToothSchema : TTForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
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
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ProcedureObject;
        override protected void InitializeControls()
        {
            Anomali = (ITTCheckBox)AddControl(new Guid("897db225-6f2e-4333-b8bf-56f0c2c8c904"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("a0fc51fc-0904-4890-91f0-315e4310bc12"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("16cf42bb-9c7e-410c-b7e3-159f658d8ee0"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("09a94617-36cb-4e6c-8566-d38a070dc881"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("87f7a4cf-be2d-4ca7-af97-be379cf21718"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("d6aaa464-e8ea-41e4-a1e9-2b4c3f707f4d"));
            ttbutton6 = (ITTButton)AddControl(new Guid("49368de2-b2c1-4d85-a112-0b9fc8e26010"));
            ttbutton3 = (ITTButton)AddControl(new Guid("0f0822bb-d409-47e8-9020-9d329199fee3"));
            ttbutton2 = (ITTButton)AddControl(new Guid("7033af30-6536-4a1a-b574-91492eb2327b"));
            ttbutton1 = (ITTButton)AddControl(new Guid("3abdebae-d5d0-46e6-949a-23357fb6ab8a"));
            ttbutton94 = (ITTButton)AddControl(new Guid("5fcee636-044c-4a9c-9f2d-ea60ccf50677"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("754e820c-d6e0-419e-97d4-f81524342541"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("904e12f0-4d86-4b5f-bb17-44118792e2e9"));
            ttbutton75 = (ITTButton)AddControl(new Guid("82d7e61b-261b-4d8a-ba0c-6fa9dac6d596"));
            ttbutton74 = (ITTButton)AddControl(new Guid("3150a045-b1a1-4a8b-a31d-53d0704d0f86"));
            ttbutton73 = (ITTButton)AddControl(new Guid("c9c56366-b33f-4948-92ff-aa0fc358b4c1"));
            ttbutton72 = (ITTButton)AddControl(new Guid("50e5868e-70ac-420b-881a-5364b8ffee8d"));
            ttbutton71 = (ITTButton)AddControl(new Guid("e341baa2-09b9-4e8b-818a-5e4c232afdcd"));
            ttbutton37 = (ITTButton)AddControl(new Guid("d1e383e3-9660-4564-b45b-dbfc3d90bd77"));
            ttbutton36 = (ITTButton)AddControl(new Guid("488bda2b-133f-46d5-9845-2f914638f220"));
            ttbutton35 = (ITTButton)AddControl(new Guid("bfbedd64-4dd9-4749-97b0-48965bdef2fc"));
            ttbutton38 = (ITTButton)AddControl(new Guid("d6202cef-064e-4970-9f66-f36b19fc488c"));
            ttbutton34 = (ITTButton)AddControl(new Guid("dc5987da-17b4-4500-89a1-e62f27233543"));
            ttbutton31 = (ITTButton)AddControl(new Guid("a87c7170-ed96-4b88-ad09-a20d63701a6c"));
            ttbutton32 = (ITTButton)AddControl(new Guid("cc285710-a059-4bea-9d18-9aeae92f3219"));
            ttbutton33 = (ITTButton)AddControl(new Guid("02e69960-4718-447a-8518-52d58db05041"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("0d62a4d3-6ca9-49bc-b324-5ae69f50975b"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("68621aa3-b9af-486d-a1f2-3e0a526bdd86"));
            ttbutton19 = (ITTButton)AddControl(new Guid("03fb1281-939c-4f8c-ac3b-d4ad3ce4ef22"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("5239cce0-8dc6-4188-9729-f371b462be7e"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("f4289ef9-03fd-471d-8a41-9e9493878983"));
            ttbutton93 = (ITTButton)AddControl(new Guid("0c75da95-d62f-4260-a54d-5154186fcc00"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("e21541eb-de5c-4563-9103-5fc43975733b"));
            ttbutton84 = (ITTButton)AddControl(new Guid("67a9bab2-7054-4a40-8973-f6052ef0fa69"));
            ttbutton85 = (ITTButton)AddControl(new Guid("89c6811c-77b1-4b9d-9661-a41838f6df41"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("97bce867-fa1a-43fa-a462-c54671f77586"));
            ttbutton83 = (ITTButton)AddControl(new Guid("74c9483b-9339-4411-b24a-ad20395ed994"));
            ttbutton82 = (ITTButton)AddControl(new Guid("88cdb713-ffcf-4083-8f2e-073226e02d31"));
            ttbutton81 = (ITTButton)AddControl(new Guid("579bb931-6fd6-4a13-b193-a75c6d100275"));
            ttbutton44 = (ITTButton)AddControl(new Guid("30850c43-9678-4a6a-bda6-77ed49f16147"));
            ttbutton41 = (ITTButton)AddControl(new Guid("beac5666-65af-4618-b036-d69960e19872"));
            ttbutton42 = (ITTButton)AddControl(new Guid("a119d4f8-ef35-4c3e-a0f6-bbae42ecf8dc"));
            ttbutton43 = (ITTButton)AddControl(new Guid("d603347a-3cf2-4267-9ed1-d53a2e095977"));
            ttbutton45 = (ITTButton)AddControl(new Guid("371d90e9-8790-497e-a351-f50851d800f5"));
            ttbutton46 = (ITTButton)AddControl(new Guid("5e262593-6884-4969-8b5f-e5a142207a77"));
            ttbutton47 = (ITTButton)AddControl(new Guid("31320243-355e-43d5-8045-5399835f5bf4"));
            ttbutton48 = (ITTButton)AddControl(new Guid("622edbd6-6db7-46f1-bb9d-957a9cd6847d"));
            ttbutton28 = (ITTButton)AddControl(new Guid("f0e54bfc-4017-4912-b110-9779ae6e04f3"));
            ttbutton27 = (ITTButton)AddControl(new Guid("b5bba784-2ce4-4bed-8963-dab32b12ebf9"));
            ttbutton26 = (ITTButton)AddControl(new Guid("e04b5e6e-9c2d-4272-82a0-646a9d0e7280"));
            ttbutton25 = (ITTButton)AddControl(new Guid("f18d5bd2-a720-48af-a784-58c46544f0cd"));
            ttbutton24 = (ITTButton)AddControl(new Guid("53524bb6-2d7f-43bd-8dae-8508f04e2590"));
            ttbutton23 = (ITTButton)AddControl(new Guid("1049260a-19e9-4df4-83e2-f4ffcc8b4b89"));
            ttbutton22 = (ITTButton)AddControl(new Guid("8c324195-d32a-4386-b52c-e0659fa8c24f"));
            ttbutton21 = (ITTButton)AddControl(new Guid("691db53e-7ee2-450c-ad88-841177a7c465"));
            ttbutton92 = (ITTButton)AddControl(new Guid("89e66b38-47b4-4e41-bb1d-668cd9785fbb"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("38f9392a-4e9b-4078-8b2e-12478f0e8684"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("0752da34-7137-46da-983c-aef3fd280329"));
            ttbutton65 = (ITTButton)AddControl(new Guid("3860abd4-cc20-4f07-819b-8c5ca173f91b"));
            ttbutton64 = (ITTButton)AddControl(new Guid("947da544-767e-4837-abc8-8c749bcd7406"));
            ttbutton63 = (ITTButton)AddControl(new Guid("822423c5-c0c2-4c33-aa16-baee04642bb4"));
            ttbutton62 = (ITTButton)AddControl(new Guid("89deba75-470f-44c7-b8df-70dae01e30f4"));
            ttbutton61 = (ITTButton)AddControl(new Guid("0dc600c1-3759-4c3a-aa56-a8f42e9384ab"));
            ttbutton11 = (ITTButton)AddControl(new Guid("ec1a19f7-5ab3-4614-a47f-79c385232958"));
            ttbutton12 = (ITTButton)AddControl(new Guid("a506ce55-0ef0-4093-a81c-d6f9d5654edb"));
            ttbutton13 = (ITTButton)AddControl(new Guid("7663bb3c-1aee-40c9-9994-ef80a31a4560"));
            ttbutton14 = (ITTButton)AddControl(new Guid("a53a54a1-da17-439a-93bb-f4afcc250887"));
            ttbutton15 = (ITTButton)AddControl(new Guid("8bc3ef53-8ef1-4404-b6f3-0009656f4669"));
            ttbutton16 = (ITTButton)AddControl(new Guid("a4094f94-4378-4646-b97e-3f7bfd432941"));
            ttbutton17 = (ITTButton)AddControl(new Guid("6533d9c5-590d-41d5-8ca9-a8fe1bb431ea"));
            ttbutton18 = (ITTButton)AddControl(new Guid("4908f131-0ddc-4b0f-b403-594092309512"));
            ttbutton51 = (ITTButton)AddControl(new Guid("7296c255-c0c1-4911-8e78-adbbfd4b892f"));
            ttbutton52 = (ITTButton)AddControl(new Guid("4bb49b53-2c15-4359-8c42-2b5ea5727a15"));
            ttbutton53 = (ITTButton)AddControl(new Guid("2a3d43e5-1aa0-4f6b-b0ee-7b1498ec3fce"));
            ttbutton54 = (ITTButton)AddControl(new Guid("b8eb3f72-e690-46b8-a1cd-00f446ee1905"));
            ttbutton55 = (ITTButton)AddControl(new Guid("35a5d838-5797-4e9b-af22-6f21598b276e"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("facc0cc9-244e-4234-94a0-3f7b71282ffd"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("4f4284f1-cf5e-4074-a043-343a6e7905d4"));
            ttbutton91 = (ITTButton)AddControl(new Guid("2037b92e-117a-4b07-9860-128667b3a783"));
            ttbutton5 = (ITTButton)AddControl(new Guid("def66401-0789-43dc-9b8c-b5280985f6b7"));
            ttbutton4 = (ITTButton)AddControl(new Guid("709aa8e4-3dcd-485f-9af7-4eb11b9258ac"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("8c6ef623-030b-4b9b-863f-da17dd378485"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("c18bf9ca-0379-446a-9903-a597dc8a0e88"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("2874dfa9-f91b-43fd-8e8d-0f0e7250b99c"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("8902a59c-f55c-4fae-b2f7-b6462e02d2bd"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("03c0a097-268f-42d4-b55c-54930acedb6b"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("d7dcf3d4-e015-48fd-823e-622d4a96c453"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("47dbdb5a-1fae-4f77-bdc3-f66a8117f70e"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("c23810cc-e6d6-41a6-8114-9785682fd172"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("ed34007c-d824-4415-b547-0b09a36592eb"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("2396cf6b-cf1d-4261-90e9-78bdcf1bd149"));
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("8d69bbb5-b37a-46c3-bc42-b1efbb6ce1cc"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0026249a-196b-4be0-9920-ceced4a926ab"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("62f4c559-789a-4b70-aecc-99e76864c51a"));
            base.InitializeControls();
        }

        public RadiologyTestDentalToothSchema() : base("RADIOLOGYTEST", "RadiologyTestDentalToothSchema")
        {
        }

        protected RadiologyTestDentalToothSchema(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}