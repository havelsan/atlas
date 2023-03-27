
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
    /// Diş İşlemleri
    /// </summary>
    public partial class DentalProcedure : TTForm
    {
        protected TTObjectClasses.DentalProcedure _DentalProcedure
        {
            get { return (TTObjectClasses.DentalProcedure)_ttObject; }
        }

        protected ITTLabel labelDentalPosition;
        protected ITTEnumComboBox ToothNumber;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelProcedureObject;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelToothNumber;
        protected ITTTextBox ExternalID;
        protected ITTLabel labelExternalID;
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
            labelDentalPosition = (ITTLabel)AddControl(new Guid("2a4f9291-52e8-49ce-b8bb-9365d9870802"));
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("b5adfb32-63c7-4a4a-a3e1-de75f5712546"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("b0429518-0bf7-4094-bd9b-d504d0342028"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("afd4bae5-5336-4c67-b83c-2a86d9b39b51"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("7b733b6f-f7ef-4273-99ee-47e5cbf8dc03"));
            labelProcedureObject = (ITTLabel)AddControl(new Guid("41c19531-3b3c-4c5d-9645-d1a6f23b1d24"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("f08d692c-716e-430c-b787-e2d9ded7a326"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("2b66d5a7-3a91-48f7-9516-8517d689a15f"));
            ExternalID = (ITTTextBox)AddControl(new Guid("7769b1be-960e-4b05-b70b-08320dbef6dc"));
            labelExternalID = (ITTLabel)AddControl(new Guid("f54723f3-10f7-4295-893e-b8b925dd0bf5"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("19cd8da9-e9f0-45eb-a524-6ac7d342df75"));
            ttbutton4 = (ITTButton)AddControl(new Guid("defaf761-2cfc-444d-a550-1be006443752"));
            ttbutton2 = (ITTButton)AddControl(new Guid("8d934c87-aa12-4cff-aed8-7ab0464e6c03"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("d8a1ee07-a330-45b9-88bd-d49a58fa809e"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("7956618f-baf8-4bb3-88a9-ed7cae30d976"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("6d5180c8-6712-47fb-ad62-d92759ac298c"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("bd724cb4-1cbb-4dcf-9874-c97c0cb9579e"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("dfb703e6-efd2-451c-948e-347bb3935a41"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("d164c4bb-c078-4ef1-8367-a0c39d697b9b"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("bba2281d-d494-4a0e-b662-b0a57b60cb6c"));
            ttbutton9 = (ITTButton)AddControl(new Guid("356df0a0-8049-47f8-9afa-36126cab854f"));
            ttbutton8 = (ITTButton)AddControl(new Guid("c388ade5-3187-48d7-84f5-a2f3d40451bc"));
            ttbutton7 = (ITTButton)AddControl(new Guid("b0450356-8067-42b6-bb74-204d163e94b0"));
            ttbutton6 = (ITTButton)AddControl(new Guid("016588fc-25cc-46dc-b649-e6b5e6982f84"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("abdddb52-a106-4bf6-a321-1f29d2278de2"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("3e759bfa-f3c5-4fc9-b2bc-3cbf1cb52249"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("70ab7417-f0d8-45bc-a014-a1d44d794c3e"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("a7f898e4-0c12-4e7d-a165-b340c2b4582f"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("9dc67024-651b-4f5d-b86b-25df15c7a547"));
            ttbutton37 = (ITTButton)AddControl(new Guid("9b959fc4-5248-4c21-89ca-562ed7724b61"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("f435a378-dacc-4c43-b13e-304bbdb29aa1"));
            ttbutton32 = (ITTButton)AddControl(new Guid("62e85e26-3727-433e-9a54-5fa44fefbb16"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("c720e55b-70f8-47b4-8d51-3ab2eb7df2fa"));
            ttbutton94 = (ITTButton)AddControl(new Guid("ad25e6e4-5b3e-413f-bcc5-989292d1b857"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("98b60d50-c0a9-4aee-94ae-9f9720cb9d5f"));
            ttbutton38 = (ITTButton)AddControl(new Guid("6f2b5d61-dbd5-4ee1-a567-fdc170ff2d1f"));
            ttbutton42 = (ITTButton)AddControl(new Guid("a8160119-630d-48c0-8455-38a202373411"));
            ttbutton71 = (ITTButton)AddControl(new Guid("954e9ee6-6a0d-4dd0-b816-6e3a5f6c8815"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("f4854227-c2c4-4bd2-b5ac-cad56a666d3e"));
            ttbutton33 = (ITTButton)AddControl(new Guid("ec377d61-b2f5-4379-8ddd-e48b833172fc"));
            ttbutton47 = (ITTButton)AddControl(new Guid("c1e7577d-493a-4c80-85c5-6f46a957f493"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("7c103abf-a354-44f6-a8ba-a6f04e75f89e"));
            ttbutton28 = (ITTButton)AddControl(new Guid("741061f3-bee4-4f4e-be32-991b4be53a62"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("a108e803-1218-4f8a-a1c3-bf6078c01afc"));
            ttbutton81 = (ITTButton)AddControl(new Guid("8631753a-6399-45e2-b452-4f710eda84c7"));
            ttbutton31 = (ITTButton)AddControl(new Guid("54b37e39-44df-4b1a-a929-fef337a7fbb7"));
            ttbutton92 = (ITTButton)AddControl(new Guid("e701c3e0-5a61-45c5-81b5-acb06f440900"));
            ttbutton75 = (ITTButton)AddControl(new Guid("3c0f4034-d5b8-4fd2-ba1e-54a8bd1aa8b9"));
            ttbutton41 = (ITTButton)AddControl(new Guid("75efec32-235d-4dca-a703-e0ef590cd9fe"));
            ttbutton34 = (ITTButton)AddControl(new Guid("f1681112-331b-4932-bac4-8909b385b19b"));
            ttbutton21 = (ITTButton)AddControl(new Guid("0e221647-ff8c-4b34-b774-8470b6fa275c"));
            ttbutton74 = (ITTButton)AddControl(new Guid("0384797e-15ed-4561-bb7e-42197c0ebf54"));
            ttbutton93 = (ITTButton)AddControl(new Guid("7d2e8d0a-0342-4458-949a-cc1adc213f18"));
            ttbutton35 = (ITTButton)AddControl(new Guid("7f42ecf9-ed52-4c4e-a940-14c30cdba0fb"));
            ttbutton52 = (ITTButton)AddControl(new Guid("27feef24-9363-4049-9811-9ab321d48f97"));
            ttbutton73 = (ITTButton)AddControl(new Guid("c4deef64-bae5-4bd8-ae7e-770c6c967812"));
            ttbutton46 = (ITTButton)AddControl(new Guid("2c86aeb1-887b-4743-bc6e-f0563e425bc0"));
            ttbutton36 = (ITTButton)AddControl(new Guid("f8edb097-2519-4247-9f4a-60233733ee49"));
            ttbutton27 = (ITTButton)AddControl(new Guid("e85c6a57-4caa-4a81-9e83-c5b672f58d32"));
            ttbutton72 = (ITTButton)AddControl(new Guid("8263771f-17bb-454a-9149-593775245820"));
            ttbutton82 = (ITTButton)AddControl(new Guid("2765dc5c-c0bf-4a0b-87a7-fdecaede9dfc"));
            ttbutton61 = (ITTButton)AddControl(new Guid("e045ec30-1f2d-4c10-b4c2-62f6d9bf3818"));
            ttbutton83 = (ITTButton)AddControl(new Guid("f8bb6e2e-3b88-4941-bf13-b118698da369"));
            ttbutton26 = (ITTButton)AddControl(new Guid("c0e1afda-5986-4c6e-b17e-ece7006e7937"));
            ttbutton48 = (ITTButton)AddControl(new Guid("2a0a6c72-3fd2-4e98-a1f2-e6c5a617fa29"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("917c83be-3936-4f68-a7b4-59fb8c2ae5d8"));
            ttbutton84 = (ITTButton)AddControl(new Guid("acbe99be-357a-440d-8c4b-4715a8e9d90e"));
            ttbutton25 = (ITTButton)AddControl(new Guid("97f27db5-22e4-410b-ad15-ec9e60ea7c12"));
            ttbutton45 = (ITTButton)AddControl(new Guid("c135e8f2-0964-4c11-9522-b2c9ddb1b202"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("ee69b5ae-c1be-4c85-a125-4e3b365df1ef"));
            ttbutton85 = (ITTButton)AddControl(new Guid("04729d73-2d7e-4e1d-8a08-c7cd398ecab5"));
            ttbutton24 = (ITTButton)AddControl(new Guid("19680628-4381-4adf-a5c7-43ecedc95448"));
            ttbutton44 = (ITTButton)AddControl(new Guid("02448714-d009-4721-b3e8-0488e2938b9f"));
            ttbutton23 = (ITTButton)AddControl(new Guid("4a329625-1e2a-454f-befd-905dade36545"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("6256259b-702a-401c-93e1-7d77c68e5e98"));
            ttbutton11 = (ITTButton)AddControl(new Guid("25b4316b-38d6-47b3-a1e3-df92fe3131d0"));
            ttbutton43 = (ITTButton)AddControl(new Guid("0b704cfa-4f76-4d08-a6d6-244497f2c14a"));
            ttbutton22 = (ITTButton)AddControl(new Guid("8e0c6470-91ab-449b-9a98-ce28fb0fd12b"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("2822df88-3e10-4f7c-b5c3-32c8a6b7925c"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("8c63b5da-25ae-41be-8bb0-ea66f6266c9f"));
            ttbutton51 = (ITTButton)AddControl(new Guid("1b700a9d-0dac-46e4-9028-8ab922c38a8a"));
            ttbutton65 = (ITTButton)AddControl(new Guid("8b2e5d32-dcbf-4965-acaa-9867043b4002"));
            ttbutton64 = (ITTButton)AddControl(new Guid("056bfb38-9b60-4235-9d78-27d6afa3992c"));
            ttbutton18 = (ITTButton)AddControl(new Guid("c18463dc-e20f-43ef-8d92-753e83e25170"));
            ttbutton63 = (ITTButton)AddControl(new Guid("a5e230bf-08cf-4dc0-b9ee-bd54d89631bf"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("63e81b3f-1e5f-48b8-8248-e7a83d3fc265"));
            ttbutton62 = (ITTButton)AddControl(new Guid("93e498a4-d29b-49f9-88e9-cf90627d34c7"));
            ttbutton12 = (ITTButton)AddControl(new Guid("218d308f-acdc-4ac1-8578-b531c32b5892"));
            ttbutton13 = (ITTButton)AddControl(new Guid("34fb996a-0607-4cee-b252-a0e8bdf90541"));
            ttbutton91 = (ITTButton)AddControl(new Guid("230664f6-2277-4c87-95fb-1944221321c1"));
            ttbutton14 = (ITTButton)AddControl(new Guid("07596121-c2d9-4dbd-a21f-2d54f6902009"));
            ttbutton55 = (ITTButton)AddControl(new Guid("3efcd8a0-1612-4fd6-88d7-e60f863d8304"));
            ttbutton15 = (ITTButton)AddControl(new Guid("5f0115ba-e9e8-4347-bcc4-d85bd295e325"));
            ttbutton54 = (ITTButton)AddControl(new Guid("61948aa7-892f-4c25-b227-3caecd2c53fc"));
            ttbutton16 = (ITTButton)AddControl(new Guid("3a315d0e-7393-4aa2-911a-a6920deb7fc0"));
            ttbutton53 = (ITTButton)AddControl(new Guid("45bfdfd9-a579-48bd-90ce-f4d47f34876c"));
            ttbutton17 = (ITTButton)AddControl(new Guid("ab748352-90eb-4043-9b27-05d0224655d9"));
            base.InitializeControls();
        }

        public DentalProcedure() : base("DENTALPROCEDURE", "DentalProcedure")
        {
        }

        protected DentalProcedure(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}