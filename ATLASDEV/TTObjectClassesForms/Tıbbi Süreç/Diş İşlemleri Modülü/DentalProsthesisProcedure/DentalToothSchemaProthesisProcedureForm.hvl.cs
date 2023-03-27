
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
    public partial class DentalToothSchemaProthesisProcedure : TTForm
    {
    /// <summary>
    /// Diş Protez Prosedür
    /// </summary>
        protected TTObjectClasses.DentalProsthesisProcedure _DentalProsthesisProcedure
        {
            get { return (TTObjectClasses.DentalProsthesisProcedure)_ttObject; }
        }

        protected ITTEnumComboBox ToothNumber;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelToothNumber;
        protected ITTLabel labelDentalPosition;
        protected ITTObjectListBox ProcedureObject;
        protected ITTLabel labelProcedure;
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
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("003e6fe1-09c6-4987-ae59-1e9fd6929972"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("e2c7f853-87b4-43f1-b6c3-fcbcdb333763"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("bb737b04-6a86-457d-abca-01188c52f9aa"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("e9fdbd47-2c51-4bef-bfac-ac79191fe51d"));
            ProcedureObject = (ITTObjectListBox)AddControl(new Guid("36ec444b-e49f-40b1-ac3d-80aad9eee8e2"));
            labelProcedure = (ITTLabel)AddControl(new Guid("c3857d11-bdd7-4d82-9c76-718e39f74cf4"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("09ba976e-d316-45e4-954a-5bead3af3388"));
            ttbutton4 = (ITTButton)AddControl(new Guid("ce50be84-cf52-45a3-8fd2-23f5332906bb"));
            ttbutton2 = (ITTButton)AddControl(new Guid("5e021b5f-36ba-4575-a91b-fc49c566a5b2"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("f97061b4-a43f-44e9-a6c8-9f624402fa43"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("2d4d253d-2c5c-4291-8e7e-6c703c711944"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("09be0d78-9794-4a3b-a92e-30890f1d9bdf"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("928b27b9-cbe7-4e86-8ca2-e2eba12c1f7d"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("77aeb47a-3160-4102-9f87-bd377c58bc2e"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("2d88c2e3-479e-4cfe-816f-fb23f142bf8a"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("150c32d8-bcae-45ff-98ab-baa140a2af2b"));
            ttbutton9 = (ITTButton)AddControl(new Guid("df736127-8e47-4c34-aaa8-59af4ea3cc0f"));
            ttbutton8 = (ITTButton)AddControl(new Guid("de9c71be-6291-441b-b73c-6f04f05e4d00"));
            ttbutton7 = (ITTButton)AddControl(new Guid("3d30bdda-ae6a-45f0-8952-1f8a6d2496b6"));
            ttbutton6 = (ITTButton)AddControl(new Guid("761808d9-27bd-4ccd-ab90-fc0bd3171ab6"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("fd4155c0-486c-4348-acb8-f1ad1586800c"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("96f1a2f2-2c13-4f17-a412-76dcf93dbe9c"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("aecf4496-7506-41ee-a282-7ba2866441a3"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("8e6fdf54-ed41-4212-bda8-498f8d130f8d"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("cbd68318-89fb-4b6b-b1c1-81b4c24f9b3d"));
            ttbutton37 = (ITTButton)AddControl(new Guid("74565f86-43a2-4a0b-a190-6ee6db9fdc2d"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("325719cf-86dd-410b-9179-ba7a388d1bed"));
            ttbutton32 = (ITTButton)AddControl(new Guid("ddb26a0b-f92e-449a-84c1-9914792e06d2"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("451110ba-f1b3-4424-8284-eb8f7ccc6b91"));
            ttbutton94 = (ITTButton)AddControl(new Guid("25beb544-5cc4-48ee-88a5-d6c6b0d20ab5"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("ea731d1f-ba0c-4914-b847-0d8789a7d729"));
            ttbutton38 = (ITTButton)AddControl(new Guid("de984ba8-d8be-47cd-be2f-fb24c3214ec4"));
            ttbutton42 = (ITTButton)AddControl(new Guid("baad02b5-563f-4c7b-ac1a-9c47665416cc"));
            ttbutton71 = (ITTButton)AddControl(new Guid("cf1629f9-cf8b-4d08-9868-abade2258cb5"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("577cd864-963a-4261-9f59-48deb25a1621"));
            ttbutton33 = (ITTButton)AddControl(new Guid("b9276791-f482-4c1e-b096-127a4c50f9d8"));
            ttbutton47 = (ITTButton)AddControl(new Guid("d8af81da-5adf-4626-8703-3a172eed23f9"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("e042efd9-c14c-420a-8f80-8e8490d6fdb4"));
            ttbutton28 = (ITTButton)AddControl(new Guid("aa544438-f7d7-4f3f-ac9d-cbd2fe066859"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("61a9b525-4c28-47ab-86ce-22cd19da2f73"));
            ttbutton81 = (ITTButton)AddControl(new Guid("55f747b1-fed7-42c1-ac78-21510d05cfca"));
            ttbutton31 = (ITTButton)AddControl(new Guid("9191317e-e9e0-4b6d-994e-74c7e7bbd4e1"));
            ttbutton92 = (ITTButton)AddControl(new Guid("239afdb4-2e64-40fc-98f6-75789661dfa6"));
            ttbutton75 = (ITTButton)AddControl(new Guid("8e8d9e10-5f14-4ea0-a204-5dbe3a1282de"));
            ttbutton41 = (ITTButton)AddControl(new Guid("936df405-73e2-4d9f-9d21-e5ad62a31505"));
            ttbutton34 = (ITTButton)AddControl(new Guid("28534b36-95e4-4570-a457-e345ce34dd8f"));
            ttbutton21 = (ITTButton)AddControl(new Guid("424daa12-51ac-4de7-8d14-07ced681d571"));
            ttbutton74 = (ITTButton)AddControl(new Guid("831c4ea6-9b98-43b9-b9a8-5bdf83ae4216"));
            ttbutton93 = (ITTButton)AddControl(new Guid("4d9e8ce5-6e7f-46d8-b70c-1003b54d1c10"));
            ttbutton35 = (ITTButton)AddControl(new Guid("4431ff71-afbe-4994-b2ee-520ff971dadb"));
            ttbutton52 = (ITTButton)AddControl(new Guid("3884da14-a73c-4d1d-acca-284b79064e66"));
            ttbutton73 = (ITTButton)AddControl(new Guid("d137a0fb-17bb-4288-bb7e-3191ae6b7a8d"));
            ttbutton46 = (ITTButton)AddControl(new Guid("51965827-fd61-4f46-ab09-243c1c3d66c2"));
            ttbutton36 = (ITTButton)AddControl(new Guid("a88e7783-2577-45ed-8f11-177335ba94f9"));
            ttbutton27 = (ITTButton)AddControl(new Guid("b99f4e60-c680-4d39-9644-e5b990b83746"));
            ttbutton72 = (ITTButton)AddControl(new Guid("ff4be9d2-eca7-4116-8f95-3c48b06afc8d"));
            ttbutton82 = (ITTButton)AddControl(new Guid("79e7959c-210a-4234-9121-e03eff414c9a"));
            ttbutton61 = (ITTButton)AddControl(new Guid("ac155e21-50cd-4591-9245-44c5f779b73a"));
            ttbutton83 = (ITTButton)AddControl(new Guid("bbc621f6-6b26-4a4c-a4c9-b4aabce32e7f"));
            ttbutton26 = (ITTButton)AddControl(new Guid("f002faa2-811b-4509-acae-2f0e03fff1de"));
            ttbutton48 = (ITTButton)AddControl(new Guid("b5c88840-0a3f-46ad-a50b-6b3ab3eb22c8"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("78b55089-b9fd-4a04-aab9-72b5637d5fdf"));
            ttbutton84 = (ITTButton)AddControl(new Guid("e2c61d57-876a-47c4-96c5-68efb58b56bd"));
            ttbutton25 = (ITTButton)AddControl(new Guid("90e186db-265a-4e1e-b320-b05b788c2e2c"));
            ttbutton45 = (ITTButton)AddControl(new Guid("2ca5134d-ccc1-42e5-9d87-c6406ab91e19"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("597fcbf0-0106-492e-917b-b4cc728c5eda"));
            ttbutton85 = (ITTButton)AddControl(new Guid("8b5ee66e-b979-428e-9836-da4c54af3a29"));
            ttbutton24 = (ITTButton)AddControl(new Guid("50acf7c9-d2dc-4f41-a383-eeb7c7843483"));
            ttbutton44 = (ITTButton)AddControl(new Guid("daaeebae-f054-4c86-9b31-720b82aa9686"));
            ttbutton23 = (ITTButton)AddControl(new Guid("e320cb0d-2716-477f-8ba8-5d87f36b31b7"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("7d621245-59a6-4d71-afb7-092cd62fc2da"));
            ttbutton11 = (ITTButton)AddControl(new Guid("88bdbd7d-9516-4cf7-8787-92b17978e65e"));
            ttbutton43 = (ITTButton)AddControl(new Guid("78dd19de-f0e6-4878-8062-8b91e7ab1d7f"));
            ttbutton22 = (ITTButton)AddControl(new Guid("041c089e-e24a-48b1-a37a-5dc9ad7f9dd6"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("714b8b1b-e349-4ecc-b25f-6a9eedf70f05"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("3878ad7d-4132-4e57-87d3-fe6ea5cf2fbc"));
            ttbutton51 = (ITTButton)AddControl(new Guid("ac9a6682-433d-41e0-932f-a21a2c74a2c3"));
            ttbutton65 = (ITTButton)AddControl(new Guid("32a9785e-10a4-4c10-bfcf-a0b1601131cf"));
            ttbutton64 = (ITTButton)AddControl(new Guid("cdfe232a-df13-4f11-a2ab-3953deb165ef"));
            ttbutton18 = (ITTButton)AddControl(new Guid("7f8959bb-de06-40f0-807a-005fb979ee20"));
            ttbutton63 = (ITTButton)AddControl(new Guid("02b5752a-4d7d-4a0d-9649-7564c91044f9"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("992fae29-157f-4de4-bc66-d7d4425c927e"));
            ttbutton62 = (ITTButton)AddControl(new Guid("498168ee-4621-435f-a65d-e908d4e1fcf6"));
            ttbutton12 = (ITTButton)AddControl(new Guid("09835af5-409c-487b-9952-21a4e4438509"));
            ttbutton13 = (ITTButton)AddControl(new Guid("d07ebd6d-5fbd-4f0a-bc59-ca8a46c1a919"));
            ttbutton91 = (ITTButton)AddControl(new Guid("bdbb8f50-3a3b-4e9c-b654-6105445ddc51"));
            ttbutton14 = (ITTButton)AddControl(new Guid("794c5c2c-e498-4078-9cef-461cdc52574c"));
            ttbutton55 = (ITTButton)AddControl(new Guid("d0938024-afb5-469a-9036-9dcaea185f48"));
            ttbutton15 = (ITTButton)AddControl(new Guid("8ee03cdf-45a0-49c1-8acd-5d07276b9bcf"));
            ttbutton54 = (ITTButton)AddControl(new Guid("201f0fa9-256a-4a21-9fc9-7b55802c53f9"));
            ttbutton16 = (ITTButton)AddControl(new Guid("984ab5e0-f56f-406d-906d-b89817e2cbf4"));
            ttbutton53 = (ITTButton)AddControl(new Guid("64e90c25-8ef8-4a1d-aae5-a1c35484e78a"));
            ttbutton17 = (ITTButton)AddControl(new Guid("671ffa0d-54e9-4fa7-bd61-c13c75106146"));
            base.InitializeControls();
        }

        public DentalToothSchemaProthesisProcedure() : base("DENTALPROSTHESISPROCEDURE", "DentalToothSchemaProthesisProcedure")
        {
        }

        protected DentalToothSchemaProthesisProcedure(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}