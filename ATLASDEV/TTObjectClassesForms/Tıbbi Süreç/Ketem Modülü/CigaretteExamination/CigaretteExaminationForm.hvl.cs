
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
    public partial class CigaretteExaminationForm : TTForm
    {
        protected TTObjectClasses.CigaretteExamination _CigaretteExamination
        {
            get { return (TTObjectClasses.CigaretteExamination)_ttObject; }
        }

        protected ITTGroupBox gb9;
        protected ITTLabel labelSFT;
        protected ITTTextBox SFT;
        protected ITTLabel labelCOCarboxyHB;
        protected ITTTextBox COCarboxyHB;
        protected ITTLabel labelEKG;
        protected ITTTextBox EKG;
        protected ITTLabel labelChestRadiography;
        protected ITTTextBox ChestRadiography;
        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelGastrointestinalSystem;
        protected ITTTextBox GastrointestinalSystem;
        protected ITTLabel labelCardiovascularSystem;
        protected ITTTextBox CardiovascularSystem;
        protected ITTLabel labelRespiratorySystem;
        protected ITTTextBox RespiratorySystem;
        protected ITTLabel labelHeadNeck;
        protected ITTTextBox HeadNeck;
        protected ITTLabel labelSkinMucosa;
        protected ITTTextBox SkinMucosa;
        protected ITTLabel labelRespirationRate;
        protected ITTTextBox RespirationRate;
        protected ITTLabel labelPulse;
        protected ITTTextBox Pulse;
        protected ITTLabel labelTensionArterial;
        protected ITTTextBox TensionArterial;
        protected ITTLabel labelOperationInfo;
        protected ITTTextBox OperationInfo;
        protected ITTLabel labelMedicineHistory;
        protected ITTTextBox MedicineHistory;
        protected ITTLabel labelPreviousDiseases;
        protected ITTTextBox PreviousDiseases;
        protected ITTGroupBox gb8;
        protected ITTCheckBox AKCOtherCancers;
        protected ITTCheckBox Embolism;
        protected ITTCheckBox PUlcus;
        protected ITTCheckBox KrBronchitis;
        protected ITTCheckBox InfarctionAngina;
        protected ITTCheckBox Hyperlipidemia;
        protected ITTCheckBox DM;
        protected ITTCheckBox HT;
        protected ITTGroupBox gb7;
        protected ITTLabel labelHowHeSheFeels;
        protected ITTTextBox HowHeSheFeels;
        protected ITTLabel labelPreviousPsychologicalTrt;
        protected ITTEnumComboBox PreviousPsychologicalTrt;
        protected ITTGroupBox gp6;
        protected ITTCheckBox LibidoLoss;
        protected ITTCheckBox Dysuria;
        protected ITTCheckBox Nocturia;
        protected ITTGroupBox gb5;
        protected ITTCheckBox GastricAcidity;
        protected ITTCheckBox Constipation;
        protected ITTCheckBox Diarrhea;
        protected ITTCheckBox Nausea;
        protected ITTGroupBox ttgroupbox4;
        protected ITTCheckBox HeadTrauma;
        protected ITTCheckBox Epilepsy;
        protected ITTCheckBox CerebrovascularSurgery;
        protected ITTCheckBox Convulsion;
        protected ITTGroupBox gb3;
        protected ITTCheckBox Palpitation;
        protected ITTCheckBox Ortopne;
        protected ITTCheckBox PND;
        protected ITTCheckBox Angina;
        protected ITTGroupBox GB2;
        protected ITTCheckBox ChestPain;
        protected ITTCheckBox BloodSpitting;
        protected ITTCheckBox ShortnessOfBreath;
        protected ITTCheckBox Phlegm;
        protected ITTCheckBox Cough;
        protected ITTGroupBox GB1;
        protected ITTCheckBox NasalBlockage;
        protected ITTCheckBox BadTaste;
        protected ITTCheckBox CoatedTongue;
        protected ITTCheckBox YellowTeeth;
        protected ITTCheckBox RedEye;
        protected ITTCheckBox HeadacheAndDizziness;
        override protected void InitializeControls()
        {
            gb9 = (ITTGroupBox)AddControl(new Guid("61965a49-0b86-45d9-b925-ac70d8dadae6"));
            labelSFT = (ITTLabel)AddControl(new Guid("dd5639ea-5ca5-446c-988d-d50eb72affd4"));
            SFT = (ITTTextBox)AddControl(new Guid("7707a77e-e219-482c-a1a7-bf157da6aa0e"));
            labelCOCarboxyHB = (ITTLabel)AddControl(new Guid("16650320-44b5-4843-83eb-a16bcccb02f1"));
            COCarboxyHB = (ITTTextBox)AddControl(new Guid("12a9d785-f6a3-4ce2-aea9-daa156b5ab5c"));
            labelEKG = (ITTLabel)AddControl(new Guid("f47cf437-5d49-4fb7-acea-fd0bd36b8924"));
            EKG = (ITTTextBox)AddControl(new Guid("f6f6ee75-64a0-455c-9800-38c9a76849ca"));
            labelChestRadiography = (ITTLabel)AddControl(new Guid("50f45956-8616-4c70-b234-93b916aef131"));
            ChestRadiography = (ITTTextBox)AddControl(new Guid("3a67c312-41c5-4d2d-bcd2-7f4c4392981b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("3924ee8c-0ae7-46e3-8d6c-cd8c1e605cd5"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0f10232a-c2e3-4985-9c8d-f8b7bb29199f"));
            labelGastrointestinalSystem = (ITTLabel)AddControl(new Guid("9c658124-e7fd-4def-a0d0-76df691005f2"));
            GastrointestinalSystem = (ITTTextBox)AddControl(new Guid("98c9634d-ab9f-48c6-831e-48f8a6e90108"));
            labelCardiovascularSystem = (ITTLabel)AddControl(new Guid("d1cc6635-7f5a-4563-8273-80ce6cbac1a7"));
            CardiovascularSystem = (ITTTextBox)AddControl(new Guid("f7b2206e-ca09-4c8d-afe1-50ab721fc48e"));
            labelRespiratorySystem = (ITTLabel)AddControl(new Guid("d58e3578-5780-4a8f-a2b6-434fb77cda46"));
            RespiratorySystem = (ITTTextBox)AddControl(new Guid("fb9701ef-e5ba-42b8-ba50-e02b4c58c7db"));
            labelHeadNeck = (ITTLabel)AddControl(new Guid("f2f1bed5-c65f-443a-b2a7-0f0eb22b94a4"));
            HeadNeck = (ITTTextBox)AddControl(new Guid("c613dd12-1634-41c0-a520-250796d86bb6"));
            labelSkinMucosa = (ITTLabel)AddControl(new Guid("bebf8f4d-563b-4a9a-aa5f-e68f2eb8cf6f"));
            SkinMucosa = (ITTTextBox)AddControl(new Guid("f5be9e4c-1f26-4da6-aac6-43a64ba3bb8a"));
            labelRespirationRate = (ITTLabel)AddControl(new Guid("eafdc716-a612-4599-992d-7c28acb7b368"));
            RespirationRate = (ITTTextBox)AddControl(new Guid("9331ec78-d08c-40d0-892f-49773aa6822f"));
            labelPulse = (ITTLabel)AddControl(new Guid("c78a4857-1853-40ec-908a-29f62d5b8641"));
            Pulse = (ITTTextBox)AddControl(new Guid("4617ee2e-395e-4765-b2e9-b36fd30d4930"));
            labelTensionArterial = (ITTLabel)AddControl(new Guid("e53457a6-0ab5-4f20-9ce7-5c70c159793c"));
            TensionArterial = (ITTTextBox)AddControl(new Guid("6cde1360-f0a5-4e69-8a40-4ecf7a939353"));
            labelOperationInfo = (ITTLabel)AddControl(new Guid("34a67bf6-425c-401b-9db2-c1a2566510e7"));
            OperationInfo = (ITTTextBox)AddControl(new Guid("9214a61d-f720-4e8e-9bac-631f499402fd"));
            labelMedicineHistory = (ITTLabel)AddControl(new Guid("bc8cff03-f5df-4048-9279-b7f708b7c8e2"));
            MedicineHistory = (ITTTextBox)AddControl(new Guid("b2b08f0c-5d8c-48c7-bc1d-beca57c7c3f3"));
            labelPreviousDiseases = (ITTLabel)AddControl(new Guid("ff51f5bc-0664-40f7-9929-67c4c732e6cf"));
            PreviousDiseases = (ITTTextBox)AddControl(new Guid("1cf1721d-b5c9-4212-a381-3f0028591245"));
            gb8 = (ITTGroupBox)AddControl(new Guid("8e51d92f-c770-4967-81c0-f61648f86623"));
            AKCOtherCancers = (ITTCheckBox)AddControl(new Guid("122966ce-41b8-4dad-b6e5-3cd0069fe289"));
            Embolism = (ITTCheckBox)AddControl(new Guid("96166391-0ed4-48a1-8d7e-f9aa84d7458d"));
            PUlcus = (ITTCheckBox)AddControl(new Guid("1b04b895-c08d-447b-ad8b-f221573d2441"));
            KrBronchitis = (ITTCheckBox)AddControl(new Guid("832be76c-f788-48f1-8088-984dc85d83e7"));
            InfarctionAngina = (ITTCheckBox)AddControl(new Guid("2c687c51-6228-491f-b29e-7e8c2ae8c83a"));
            Hyperlipidemia = (ITTCheckBox)AddControl(new Guid("d388a445-a4c9-4675-a8eb-794894a1d21a"));
            DM = (ITTCheckBox)AddControl(new Guid("d6445749-dd10-4b1d-89c4-5a98f5bd0d64"));
            HT = (ITTCheckBox)AddControl(new Guid("3cda668f-b34a-4354-ad20-31660c59aed4"));
            gb7 = (ITTGroupBox)AddControl(new Guid("722e14b8-3562-439a-8096-32c663692e17"));
            labelHowHeSheFeels = (ITTLabel)AddControl(new Guid("c1ac8754-5014-4b6e-8f6a-4f9f11edbc4e"));
            HowHeSheFeels = (ITTTextBox)AddControl(new Guid("55da2465-0ea5-425c-9b4d-6357aee90b33"));
            labelPreviousPsychologicalTrt = (ITTLabel)AddControl(new Guid("b66b5ae5-bc7c-4a1e-804d-dad124b5d31c"));
            PreviousPsychologicalTrt = (ITTEnumComboBox)AddControl(new Guid("09666bca-e9fe-49b0-839f-60a98e25193f"));
            gp6 = (ITTGroupBox)AddControl(new Guid("3baa9b0f-339b-4d63-b836-8de0ee44c4eb"));
            LibidoLoss = (ITTCheckBox)AddControl(new Guid("15fd27fa-d218-4172-8ee3-782f96beb83f"));
            Dysuria = (ITTCheckBox)AddControl(new Guid("9ae29643-4d16-4df4-bc45-89052de88c43"));
            Nocturia = (ITTCheckBox)AddControl(new Guid("254dc0ab-4b23-470c-bbae-4583721c4824"));
            gb5 = (ITTGroupBox)AddControl(new Guid("011ea23a-bcf4-4160-9891-394766f2a2fa"));
            GastricAcidity = (ITTCheckBox)AddControl(new Guid("be5af091-d44b-456a-bd5e-e258120bbe11"));
            Constipation = (ITTCheckBox)AddControl(new Guid("29c77feb-b4ff-412f-abca-29c7991d7ca7"));
            Diarrhea = (ITTCheckBox)AddControl(new Guid("2c3f5b11-430c-4a24-9277-850f71170694"));
            Nausea = (ITTCheckBox)AddControl(new Guid("f169a76b-d100-4a0a-affb-152a5d27b286"));
            ttgroupbox4 = (ITTGroupBox)AddControl(new Guid("cd166b2c-8d2c-4f08-929a-4969e9ec30b4"));
            HeadTrauma = (ITTCheckBox)AddControl(new Guid("6a00903c-17d4-427b-817b-8feab0151b2d"));
            Epilepsy = (ITTCheckBox)AddControl(new Guid("2c4f3dfa-0f10-4bdd-b941-ae51d0e23a84"));
            CerebrovascularSurgery = (ITTCheckBox)AddControl(new Guid("9a226a93-8f52-49a7-93ff-32babc6ecf3f"));
            Convulsion = (ITTCheckBox)AddControl(new Guid("dc482501-7e02-4a95-9666-68e7b1e3f905"));
            gb3 = (ITTGroupBox)AddControl(new Guid("1205f876-b00e-49f4-8ea0-302d0358e281"));
            Palpitation = (ITTCheckBox)AddControl(new Guid("f17144fc-cd86-4c0e-930d-9aedcdeade4c"));
            Ortopne = (ITTCheckBox)AddControl(new Guid("ba45cb73-63fb-4d73-b6ac-c15683c3d12d"));
            PND = (ITTCheckBox)AddControl(new Guid("310092f3-0882-4ec7-8eb2-192e8876a396"));
            Angina = (ITTCheckBox)AddControl(new Guid("5095fabf-527b-46de-b237-622fb8261817"));
            GB2 = (ITTGroupBox)AddControl(new Guid("9aacd78e-6a21-4f1e-ab54-271f8ca9863b"));
            ChestPain = (ITTCheckBox)AddControl(new Guid("7adfb77e-0020-46ef-bdbf-22655d0f9c99"));
            BloodSpitting = (ITTCheckBox)AddControl(new Guid("d4dff33b-82ca-49ad-8a1f-a0f4b39364d8"));
            ShortnessOfBreath = (ITTCheckBox)AddControl(new Guid("bae6ecf8-5a65-4238-ac30-3e245d2c02bb"));
            Phlegm = (ITTCheckBox)AddControl(new Guid("6759621c-52be-4cbd-8d72-930a13139224"));
            Cough = (ITTCheckBox)AddControl(new Guid("674f9f2c-0828-49a0-a1a3-d50feaccb838"));
            GB1 = (ITTGroupBox)AddControl(new Guid("56bc7618-21ce-43f8-ad99-6e125d2a6208"));
            NasalBlockage = (ITTCheckBox)AddControl(new Guid("76902365-1a85-4d24-b7b0-10c85a12b032"));
            BadTaste = (ITTCheckBox)AddControl(new Guid("e7d96f75-53b2-4bc1-834b-b980bba2a0a1"));
            CoatedTongue = (ITTCheckBox)AddControl(new Guid("6ff9c754-fee1-4d3e-bfa2-f998c3a97dea"));
            YellowTeeth = (ITTCheckBox)AddControl(new Guid("401e6a65-7658-4f45-9f2b-a15b4868bc8c"));
            RedEye = (ITTCheckBox)AddControl(new Guid("5c17a534-00a4-418d-adf5-9daa23161254"));
            HeadacheAndDizziness = (ITTCheckBox)AddControl(new Guid("e512aca7-3147-4524-a9c9-91b059501373"));
            base.InitializeControls();
        }

        public CigaretteExaminationForm() : base("CIGARETTEEXAMINATION", "CigaretteExaminationForm")
        {
        }

        protected CigaretteExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}