
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
    public partial class DentalToothShemaDiagnoseForm : TTForm
    {
        protected TTObjectClasses.BaseDentalEpisodeActionDiagnosisGrid _BaseDentalEpisodeActionDiagnosisGrid
        {
            get { return (TTObjectClasses.BaseDentalEpisodeActionDiagnosisGrid)_ttObject; }
        }

        protected ITTEnumComboBox ToothNumber;
        protected ITTObjectListBox DiagnoseehrDiagnosis;
        protected ITTLabel labelDiagnoseDateehrDiagnosis;
        protected ITTDateTimePicker DiagnoseDateehrDiagnosis;
        protected ITTLabel labelResponsibleUser;
        protected ITTObjectListBox ResponsibleUser;
        protected ITTCheckBox IsMainDiagnose;
        protected ITTCheckBox AddToHistory;
        protected ITTLabel labelToothNumber;
        protected ITTEnumComboBox DentalPosition;
        protected ITTLabel labelDentalPosition;
        protected ITTLabel labelDiagnoseehrDiagnosis;
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
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("a7ae21ab-8275-4111-a47c-7aa526d3c4da"));
            DiagnoseehrDiagnosis = (ITTObjectListBox)AddControl(new Guid("e54bf94a-e123-48ab-abcb-2be257e04fe7"));
            labelDiagnoseDateehrDiagnosis = (ITTLabel)AddControl(new Guid("4b664a69-9f9d-42d8-a982-a188d3e59c77"));
            DiagnoseDateehrDiagnosis = (ITTDateTimePicker)AddControl(new Guid("f1f9a8a6-944e-4817-ae0e-51b2574de296"));
            labelResponsibleUser = (ITTLabel)AddControl(new Guid("71447513-dd99-4fbb-8551-79a742c15c5c"));
            ResponsibleUser = (ITTObjectListBox)AddControl(new Guid("f92b062e-e65b-441e-9a4d-7e435d896900"));
            IsMainDiagnose = (ITTCheckBox)AddControl(new Guid("b0292d14-bfd4-4cd8-937a-ccf845535424"));
            AddToHistory = (ITTCheckBox)AddControl(new Guid("2f3617e6-dac2-442f-8480-c0411f6d9bb1"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("69c50b41-2dde-4268-afeb-ad50bca6ac75"));
            DentalPosition = (ITTEnumComboBox)AddControl(new Guid("5874801e-3484-4351-b62d-6426cb295c96"));
            labelDentalPosition = (ITTLabel)AddControl(new Guid("97a7cedd-6dd6-4fe5-9f52-3c367f643144"));
            labelDiagnoseehrDiagnosis = (ITTLabel)AddControl(new Guid("ecc0b0f9-14e0-4ae0-b25d-869cae6d8c2c"));
            ttgroupboxToothSchema = (ITTGroupBox)AddControl(new Guid("c829f22b-a137-4d7a-bca4-af37e5e7aba4"));
            ttbutton4 = (ITTButton)AddControl(new Guid("86287390-ebaa-4da2-8f86-647e8ff7c45f"));
            ttbutton2 = (ITTButton)AddControl(new Guid("0daba5b8-3592-4977-a6cf-32215366867a"));
            ttlabelMouthPositionNum = (ITTLabel)AddControl(new Guid("7f2761eb-1c6b-4707-b760-cc756d076c06"));
            ttbuttonLeftUpperJaw = (ITTButton)AddControl(new Guid("61b85822-20ba-467d-a394-2e32454a2205"));
            ttbuttonRightUpperJaw = (ITTButton)AddControl(new Guid("42e5267a-0d8e-427d-aa62-642c767c1005"));
            ttbuttonUpper = (ITTButton)AddControl(new Guid("20879727-5fc4-4359-8e11-45dec0c79050"));
            ttbuttonUpperJaw = (ITTButton)AddControl(new Guid("a80be45e-c384-46d3-b331-6029b0362f59"));
            ttbuttonWholeJaw = (ITTButton)AddControl(new Guid("4b7b8fa7-6c19-4f3f-ab92-94adf5cc2785"));
            ttlabelAdultTooth = (ITTLabel)AddControl(new Guid("45e8d020-8f07-4a23-a1b3-35d3db427b5c"));
            ttbutton9 = (ITTButton)AddControl(new Guid("da7f3c44-0f8f-4ee5-9a62-9b82286a9df3"));
            ttbutton8 = (ITTButton)AddControl(new Guid("23f6e2cc-3297-4fae-b705-7be681074722"));
            ttbutton7 = (ITTButton)AddControl(new Guid("a18ae119-84d0-4d33-9bfe-0454ed15dee3"));
            ttbutton6 = (ITTButton)AddControl(new Guid("5eca1812-31c9-48f9-b772-cfd6097425a0"));
            ttlabelMilkTooth = (ITTLabel)AddControl(new Guid("5785c556-961a-40f8-ab5f-dafe5ef27cdf"));
            ttlabelAnamoliPositionNum = (ITTLabel)AddControl(new Guid("93140328-15fb-4749-8f47-252a1780d2c9"));
            ttbuttonRight = (ITTButton)AddControl(new Guid("0cdad0a4-2a64-409d-99c1-56a30c7ec723"));
            ttbuttonLeft = (ITTButton)AddControl(new Guid("dfd82d4d-e1ae-4bec-af34-eb3f0a028ae7"));
            ttbuttonLeftLowerJaw = (ITTButton)AddControl(new Guid("6c1de613-e06e-4310-b1c1-1e439aeb1ba0"));
            ttbutton37 = (ITTButton)AddControl(new Guid("9c2bd0f6-f8f7-4bc2-92d9-e30d7ad084d3"));
            ttbuttonWholeJaw2 = (ITTButton)AddControl(new Guid("fb8a4333-d6f3-4556-9ee4-fd4ae910b358"));
            ttbutton32 = (ITTButton)AddControl(new Guid("8b41bb11-7cee-4af3-b799-470103c03966"));
            ttbuttonLowerJaw = (ITTButton)AddControl(new Guid("39828454-bce8-4274-a391-6063160487b9"));
            ttbutton94 = (ITTButton)AddControl(new Guid("99c4d656-a038-4088-9632-fefe73bf270e"));
            ttbuttonRightLowerJaw = (ITTButton)AddControl(new Guid("a47d8fe0-57d0-4a0e-aede-a87bc8c3fd66"));
            ttbutton38 = (ITTButton)AddControl(new Guid("9857836f-ebf2-4c31-b012-6a5bda44f1c5"));
            ttbutton42 = (ITTButton)AddControl(new Guid("427d9149-c623-453c-8ec1-1ebb1606fdd1"));
            ttbutton71 = (ITTButton)AddControl(new Guid("144065e9-4c5b-4d2f-81d2-d8716488e5b1"));
            ttbuttonLower = (ITTButton)AddControl(new Guid("ad69d47b-b100-4979-a90f-c4fb420fdf2f"));
            ttbutton33 = (ITTButton)AddControl(new Guid("04fc99db-b680-4cf7-af85-5a03ebb19617"));
            ttbutton47 = (ITTButton)AddControl(new Guid("2f338633-8662-407c-941b-b8b48cc717f4"));
            ttbuttonLL1 = (ITTButton)AddControl(new Guid("35e6fd79-4a0a-4240-9011-3c66deca7886"));
            ttbutton28 = (ITTButton)AddControl(new Guid("1054c23f-fa07-49f4-85a2-67a295914d72"));
            ttbuttonLL2 = (ITTButton)AddControl(new Guid("0a40cdb1-d7c8-41c9-b48c-7ce7952abe4f"));
            ttbutton81 = (ITTButton)AddControl(new Guid("2f7f7a95-b363-4ab6-ad39-dcaedb50d473"));
            ttbutton31 = (ITTButton)AddControl(new Guid("ad4b1582-0380-4d1d-9ee0-7f92e28ad585"));
            ttbutton92 = (ITTButton)AddControl(new Guid("4d80b7d9-4fc7-4023-9688-f1bbfb0d2fa9"));
            ttbutton75 = (ITTButton)AddControl(new Guid("e77b999c-26d5-4f61-a698-7808d302fae6"));
            ttbutton41 = (ITTButton)AddControl(new Guid("d56d9888-5a7a-4d62-817a-ac58c484482a"));
            ttbutton34 = (ITTButton)AddControl(new Guid("1479d353-210c-4c26-a9e6-2da3cedf3b49"));
            ttbutton21 = (ITTButton)AddControl(new Guid("b5be6b63-51ba-48cd-b7ad-383d085773b5"));
            ttbutton74 = (ITTButton)AddControl(new Guid("0cf06ea7-ba00-4dde-9b97-3a5ef8f984eb"));
            ttbutton93 = (ITTButton)AddControl(new Guid("82980894-f6e3-47c3-b8b2-57df984fb646"));
            ttbutton35 = (ITTButton)AddControl(new Guid("31d6e779-72dc-43cf-8047-05f38e2253a3"));
            ttbutton52 = (ITTButton)AddControl(new Guid("f532f9d9-191d-4c38-9fda-8329a2cb73c5"));
            ttbutton73 = (ITTButton)AddControl(new Guid("5e759a5e-f930-48b3-89a1-484082e6a628"));
            ttbutton46 = (ITTButton)AddControl(new Guid("80ff03d2-04fa-4fbe-9bb7-d5cbfe6b2cb5"));
            ttbutton36 = (ITTButton)AddControl(new Guid("328c82d8-83a3-40c6-867c-34721abc76f3"));
            ttbutton27 = (ITTButton)AddControl(new Guid("eccee66f-4188-40e6-993b-fbdce6576785"));
            ttbutton72 = (ITTButton)AddControl(new Guid("4e35b370-22a6-46e2-95ec-39f02d77a62b"));
            ttbutton82 = (ITTButton)AddControl(new Guid("30ebee54-52c3-4e5a-967d-ec0f1c88aa63"));
            ttbutton61 = (ITTButton)AddControl(new Guid("4a6f83ac-8f95-429d-ad49-24b559fed8a1"));
            ttbutton83 = (ITTButton)AddControl(new Guid("a5e45782-8049-4253-9120-494cac30fee1"));
            ttbutton26 = (ITTButton)AddControl(new Guid("fd2f5b81-bc42-4be2-bca3-16db6ad8fe91"));
            ttbutton48 = (ITTButton)AddControl(new Guid("a36787c9-0cb9-4a7d-bd24-d6c1faf8de7d"));
            ttbuttonRU1 = (ITTButton)AddControl(new Guid("db496ecc-0658-4f98-b909-e2cff26a8cae"));
            ttbutton84 = (ITTButton)AddControl(new Guid("225062f0-917f-4c06-af6e-adbe92f9bd0e"));
            ttbutton25 = (ITTButton)AddControl(new Guid("df59dbee-7e46-4d7b-8997-64bd72067c77"));
            ttbutton45 = (ITTButton)AddControl(new Guid("0c182278-1e6b-46f2-88cb-c240b4e479af"));
            ttbuttonLU2 = (ITTButton)AddControl(new Guid("454b18ac-ba4c-44b2-b10a-8c4147ac7911"));
            ttbutton85 = (ITTButton)AddControl(new Guid("06f79af0-7025-406d-bbc6-0308da17add2"));
            ttbutton24 = (ITTButton)AddControl(new Guid("c834c258-9db4-42b1-ac31-7c225f459c7c"));
            ttbutton44 = (ITTButton)AddControl(new Guid("2a2434fc-18e4-4b9a-abfc-5d5835119476"));
            ttbutton23 = (ITTButton)AddControl(new Guid("86194590-001d-428b-850e-88adb28a84c4"));
            ttbuttonRL2 = (ITTButton)AddControl(new Guid("ba985577-f318-48cc-b0c6-b371617baae5"));
            ttbutton11 = (ITTButton)AddControl(new Guid("78968293-517a-47d9-9313-de744dcc5b0f"));
            ttbutton43 = (ITTButton)AddControl(new Guid("207c2a08-9fec-4383-923e-81e771e72ad0"));
            ttbutton22 = (ITTButton)AddControl(new Guid("7313d263-5ca2-4e8f-94fc-f3c44ca0eb1d"));
            ttbuttonRL1 = (ITTButton)AddControl(new Guid("695c02d1-5ddb-4451-b196-20d090e0027f"));
            ttbuttonLU1 = (ITTButton)AddControl(new Guid("19c55f39-d265-4f8a-80b3-19f3f3a983ce"));
            ttbutton51 = (ITTButton)AddControl(new Guid("56ee5869-37c9-476c-adcd-9d7128281494"));
            ttbutton65 = (ITTButton)AddControl(new Guid("36236b39-b9d2-4e16-8eae-fead90ca96b4"));
            ttbutton64 = (ITTButton)AddControl(new Guid("ff77641d-3fc1-4a30-b2a8-fb0672bdd5b6"));
            ttbutton18 = (ITTButton)AddControl(new Guid("3429a52d-def1-4b6d-852a-ee89cd9f6665"));
            ttbutton63 = (ITTButton)AddControl(new Guid("a5fb103e-cc52-4439-8eba-b669c9baa4f5"));
            ttbuttonRU2 = (ITTButton)AddControl(new Guid("6d6a720b-f603-4efa-88f8-e0a348d252c5"));
            ttbutton62 = (ITTButton)AddControl(new Guid("471d82b2-88c0-4fc2-a28a-84a7bac6824e"));
            ttbutton12 = (ITTButton)AddControl(new Guid("c047f675-3643-43ed-8570-e2122ea57f54"));
            ttbutton13 = (ITTButton)AddControl(new Guid("cb5a3ae7-7534-4052-bf06-4ac3be551b9a"));
            ttbutton91 = (ITTButton)AddControl(new Guid("429c0a16-73e2-494a-acc2-584aa9e44dee"));
            ttbutton14 = (ITTButton)AddControl(new Guid("a41ba0e5-4e89-4f02-b4eb-5798fed3435b"));
            ttbutton55 = (ITTButton)AddControl(new Guid("45335a36-5399-4140-9cec-afb3f9167432"));
            ttbutton15 = (ITTButton)AddControl(new Guid("b12e8b30-038f-4efe-b090-d84c9005f1e5"));
            ttbutton54 = (ITTButton)AddControl(new Guid("79b3c0fb-fcfa-465d-97ce-b38c758cda2d"));
            ttbutton16 = (ITTButton)AddControl(new Guid("bf3e06d2-e9db-46c7-a795-82f8b3d39420"));
            ttbutton53 = (ITTButton)AddControl(new Guid("523d120c-6ef3-40c7-9a55-c99204301b95"));
            ttbutton17 = (ITTButton)AddControl(new Guid("80cbae04-8af3-4cb3-bbd9-25aa7bc2cda8"));
            base.InitializeControls();
        }

        public DentalToothShemaDiagnoseForm() : base("BASEDENTALEPISODEACTIONDIAGNOSISGRID", "DentalToothShemaDiagnoseForm")
        {
        }

        protected DentalToothShemaDiagnoseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}