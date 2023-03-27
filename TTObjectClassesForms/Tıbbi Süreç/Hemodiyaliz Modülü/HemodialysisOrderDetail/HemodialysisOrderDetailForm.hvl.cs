
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
    /// Hemodiyaliz Uygulama Formu
    /// </summary>
    public partial class HemodialysisOrderDetailForm : TTForm
    {
    /// <summary>
    /// Diyaliz Emrinin  Uygulanmasını Sağlayan Nesnedir
    /// </summary>
        protected TTObjectClasses.HemodialysisOrderDetail _HemodialysisOrderDetail
        {
            get { return (TTObjectClasses.HemodialysisOrderDetail)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabGenelBilgiler;
        protected ITTLabel labelAntihypertensive;
        protected ITTObjectListBox Antihypertensive;
        protected ITTLabel labelPeritonealComplication;
        protected ITTObjectListBox PeritonealComplication;
        protected ITTLabel labelPeritonealDialysisTunnel;
        protected ITTObjectListBox PeritonealDialysisTunnel;
        protected ITTLabel labelCatheterInsertionMethod;
        protected ITTObjectListBox CatheterInsertionMethod;
        protected ITTLabel labelCatheterType;
        protected ITTObjectListBox CatheterType;
        protected ITTLabel labelDialysisTreatment;
        protected ITTObjectListBox DialysisTreatment;
        protected ITTLabel labelCatheter;
        protected ITTObjectListBox Catheter;
        protected ITTLabel labelPET;
        protected ITTObjectListBox PET;
        protected ITTLabel labelSinekalsetUsage;
        protected ITTObjectListBox SinekalsetUsage;
        protected ITTLabel labelPreviousRRT;
        protected ITTObjectListBox PreviousRRT;
        protected ITTLabel labelPhosphorusAgent;
        protected ITTObjectListBox PhosphorusAgent;
        protected ITTLabel labelDialysisFrequency;
        protected ITTObjectListBox DialysisFrequency;
        protected ITTLabel labelSuggestions;
        protected ITTTextBox Suggestions;
        protected ITTLabel labelSessionDate;
        protected ITTDateTimePicker SessionDate;
        protected ITTLabel labelHepatitis;
        protected ITTTextBox Hepatitis;
        protected ITTLabel labelHeparinization;
        protected ITTTextBox Heparinization;
        protected ITTLabel labelGeneralInfo;
        protected ITTTextBox GeneralInfo;
        protected ITTLabel labelEtiology;
        protected ITTTextBox Etiology;
        protected ITTLabel labelDiagnosis;
        protected ITTTextBox Diagnosis;
        protected ITTLabel labelAllergy;
        protected ITTTextBox Allergy;
        protected ITTTabPage tabSeansBilgileri;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox LiquidNa;
        protected ITTLabel labelLiquidNa;
        protected ITTLabel labelLiquidK;
        protected ITTTextBox LiquidK;
        protected ITTTextBox LiquidCa;
        protected ITTLabel labelLiquidCa;
        protected ITTLabel labelLiquidMg;
        protected ITTTextBox LiquidMg;
        protected ITTTextBox LiquidCl;
        protected ITTLabel labelLiquidCl;
        protected ITTTextBox LiquidCH3COO;
        protected ITTLabel labelLiquidCH3COO;
        protected ITTTextBox LiquidHCO3;
        protected ITTLabel labelLiquidHCO3;
        protected ITTLabel ttlabel26;
        protected ITTLabel ttlabel25;
        protected ITTLabel ttlabel24;
        protected ITTLabel labelBloodFlow;
        protected ITTObjectListBox BloodFlow;
        protected ITTLabel labelDialyzatorArea;
        protected ITTObjectListBox DialyzatorArea;
        protected ITTLabel labelDialyzatorType;
        protected ITTObjectListBox DialyzatorType;
        protected ITTLabel labelIntravenous;
        protected ITTObjectListBox Intravenous;
        protected ITTLabel labelCareNurse;
        protected ITTObjectListBox CareNurse;
        protected ITTLabel labelNurse;
        protected ITTObjectListBox Nurse;
        protected ITTLabel labelDoctor;
        protected ITTObjectListBox Doctor;
        protected ITTLabel labelWeightBefore;
        protected ITTTextBox WeightBefore;
        protected ITTLabel labelWeightAfter;
        protected ITTTextBox WeightAfter;
        protected ITTLabel labelSessionStartTime;
        protected ITTDateTimePicker SessionStartTime;
        protected ITTLabel labelSessionFinishTime;
        protected ITTDateTimePicker SessionFinishTime;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTLabel labelLiquid;
        protected ITTTextBox Liquid;
        protected ITTLabel labelInformation;
        protected ITTTextBox Information;
        protected ITTLabel labelDialysateTransferSpeed;
        protected ITTTextBox DialysateTransferSpeed;
        protected ITTLabel labelDevice;
        protected ITTTextBox Device;
        protected ITTCheckBox CatheterCare;
        protected ITTCheckBox AVFCare;
        protected ITTTabPage tabSaglikNet;
        protected ITTGroupBox grpKtv;
        protected ITTLabel labelURR;
        protected ITTLabel labelBunPre;
        protected ITTLabel labelKtv;
        protected ITTTextBox Ktv;
        protected ITTTextBox URR;
        protected ITTTextBox BunPre;
        protected ITTLabel labelBunPost;
        protected ITTTextBox BunPost;
        protected ITTGroupBox grpSaglikNet;
        protected ITTObjectListBox DialysisTreatmentMethod;
        protected ITTLabel labelTreatmentCourse;
        protected ITTObjectListBox TreatmentCourse;
        protected ITTLabel labelDialysisTreatmentMethod;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelVitaminDusage;
        protected ITTLabel ttlabel2;
        protected ITTObjectListBox VitaminDusage;
        protected ITTObjectListBox AnemiaTreatmentMethod;
        protected ITTLabel labelAnemiaTreatmentMethod;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("0084e4a8-cdc8-4caf-afa6-7bb344a3ab5e"));
            tabGenelBilgiler = (ITTTabPage)AddControl(new Guid("2895e096-bd75-4466-9293-efb90a428e26"));
            labelAntihypertensive = (ITTLabel)AddControl(new Guid("32f1df47-15db-4b8e-a219-049827840854"));
            Antihypertensive = (ITTObjectListBox)AddControl(new Guid("f5f4c169-8e79-4bae-9a98-d2694ebdfc09"));
            labelPeritonealComplication = (ITTLabel)AddControl(new Guid("c0d053fc-cd34-48d2-a8b7-447a84604a8c"));
            PeritonealComplication = (ITTObjectListBox)AddControl(new Guid("fdf0792f-9016-4bac-92ab-cacf7a5c5365"));
            labelPeritonealDialysisTunnel = (ITTLabel)AddControl(new Guid("15603d7d-be7a-4ab4-8c97-e6d20f91eb1d"));
            PeritonealDialysisTunnel = (ITTObjectListBox)AddControl(new Guid("0123aacf-575a-4593-8611-c5dbef3ec935"));
            labelCatheterInsertionMethod = (ITTLabel)AddControl(new Guid("996275fd-dba0-4cee-8860-cee151242969"));
            CatheterInsertionMethod = (ITTObjectListBox)AddControl(new Guid("e07091e8-969f-4064-a8f7-5774e9bb9015"));
            labelCatheterType = (ITTLabel)AddControl(new Guid("ddb56f50-0b33-4d6d-8c92-278ed7174e45"));
            CatheterType = (ITTObjectListBox)AddControl(new Guid("8417d1a2-e035-462e-afab-764accb10b4e"));
            labelDialysisTreatment = (ITTLabel)AddControl(new Guid("fc944d2f-2cd6-4eed-be02-7d8a80388bd6"));
            DialysisTreatment = (ITTObjectListBox)AddControl(new Guid("af55f4c9-03bb-4b2c-a85e-1d2a5431ce52"));
            labelCatheter = (ITTLabel)AddControl(new Guid("8b27d792-f0b0-454b-9130-a6bbba93abf6"));
            Catheter = (ITTObjectListBox)AddControl(new Guid("85395281-a858-4b06-bfdf-09d0cb4d7124"));
            labelPET = (ITTLabel)AddControl(new Guid("7261a70c-2ad5-4288-97cf-0f314378278d"));
            PET = (ITTObjectListBox)AddControl(new Guid("cbff342c-a2ba-4c8b-ba22-713b0b7609e5"));
            labelSinekalsetUsage = (ITTLabel)AddControl(new Guid("0b370572-fc74-48be-903d-6801e39219f7"));
            SinekalsetUsage = (ITTObjectListBox)AddControl(new Guid("0ce2b044-0297-4747-b55a-eb5cda90dfd8"));
            labelPreviousRRT = (ITTLabel)AddControl(new Guid("19ef56e6-9bad-45c2-af9e-ffd5b125fb4d"));
            PreviousRRT = (ITTObjectListBox)AddControl(new Guid("a7d5d842-5d9c-4377-b55b-e4379ed718a3"));
            labelPhosphorusAgent = (ITTLabel)AddControl(new Guid("7608fde2-61e5-451d-8b13-705f1ecdd041"));
            PhosphorusAgent = (ITTObjectListBox)AddControl(new Guid("487dba92-644a-40c0-8a08-258ee8ddcf84"));
            labelDialysisFrequency = (ITTLabel)AddControl(new Guid("97090a30-cda7-4866-a892-aab4438f8115"));
            DialysisFrequency = (ITTObjectListBox)AddControl(new Guid("cca63c88-5fc2-4a7f-9cae-c4452eefa15b"));
            labelSuggestions = (ITTLabel)AddControl(new Guid("fa5eb909-8ac0-46ae-a003-24fd06ecb79f"));
            Suggestions = (ITTTextBox)AddControl(new Guid("abb4c2da-ba31-4c25-8b53-f9644a8eab74"));
            labelSessionDate = (ITTLabel)AddControl(new Guid("488a8b29-fe9e-4d2a-9acb-496e2ff7bac1"));
            SessionDate = (ITTDateTimePicker)AddControl(new Guid("dcbc5749-5045-4d69-8696-66bb22648892"));
            labelHepatitis = (ITTLabel)AddControl(new Guid("7b14db1a-18e2-494f-8696-87bb248909e4"));
            Hepatitis = (ITTTextBox)AddControl(new Guid("9d22eca4-dae2-4be0-8a7e-43788f398a93"));
            labelHeparinization = (ITTLabel)AddControl(new Guid("5a552a6a-6514-4a96-aee2-bd8ec15fc2ef"));
            Heparinization = (ITTTextBox)AddControl(new Guid("abbaf540-d2b6-412c-b35b-4eadbbd5e14a"));
            labelGeneralInfo = (ITTLabel)AddControl(new Guid("af929597-acb7-463e-8b6e-f5e51145624b"));
            GeneralInfo = (ITTTextBox)AddControl(new Guid("62b8dd6e-09ca-4481-ab6d-0958bad6a01d"));
            labelEtiology = (ITTLabel)AddControl(new Guid("087fda96-61df-42b9-b64e-0da76f26bd60"));
            Etiology = (ITTTextBox)AddControl(new Guid("9533504a-91bc-4ad7-9046-1449df467847"));
            labelDiagnosis = (ITTLabel)AddControl(new Guid("5eedcea4-2e84-475c-845e-279cf49ffc09"));
            Diagnosis = (ITTTextBox)AddControl(new Guid("5f8ae183-4ec6-4f1e-8ff4-3069c3703063"));
            labelAllergy = (ITTLabel)AddControl(new Guid("f76cbde0-17e3-4a9f-9505-183524a27894"));
            Allergy = (ITTTextBox)AddControl(new Guid("b9295812-7236-40d3-8e5e-ee1b53ca4b1c"));
            tabSeansBilgileri = (ITTTabPage)AddControl(new Guid("9ef4a254-16ad-44ee-9b35-cf6b117d8ad3"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("113c2b42-d0d0-4cd3-a091-fc1eb095ac08"));
            LiquidNa = (ITTTextBox)AddControl(new Guid("57ece766-7ec8-4785-8c29-15d0a474ad61"));
            labelLiquidNa = (ITTLabel)AddControl(new Guid("273f8ccd-0ce2-4e7c-92cb-06cfca533cf0"));
            labelLiquidK = (ITTLabel)AddControl(new Guid("6c3791c4-596e-49e4-8fc4-75b1898b6b92"));
            LiquidK = (ITTTextBox)AddControl(new Guid("2989f1ee-d13a-4297-9faa-04dc63552041"));
            LiquidCa = (ITTTextBox)AddControl(new Guid("3cbe99de-9ee3-418e-984b-8183a91ce09a"));
            labelLiquidCa = (ITTLabel)AddControl(new Guid("0bc028d3-ad27-453c-8c50-9aadb2c8c3c9"));
            labelLiquidMg = (ITTLabel)AddControl(new Guid("f993df5e-a6b0-4f39-8b50-2382c44b2e77"));
            LiquidMg = (ITTTextBox)AddControl(new Guid("f2ed5f1f-3158-475c-ab3a-a5f3625d1fd3"));
            LiquidCl = (ITTTextBox)AddControl(new Guid("353fcc8f-96c9-4e52-ade8-e5705c9481b2"));
            labelLiquidCl = (ITTLabel)AddControl(new Guid("1d0a0ed8-d887-423a-bb40-babaf15502ca"));
            LiquidCH3COO = (ITTTextBox)AddControl(new Guid("2938475b-9f58-44e3-b020-2428a394c17e"));
            labelLiquidCH3COO = (ITTLabel)AddControl(new Guid("fdfe0db1-53f9-4cbb-8b03-78906b703c79"));
            LiquidHCO3 = (ITTTextBox)AddControl(new Guid("095b4e67-90ca-4041-bd34-f20b401507a0"));
            labelLiquidHCO3 = (ITTLabel)AddControl(new Guid("6c3a9e92-38b3-4153-a05e-f503d5905ea3"));
            ttlabel26 = (ITTLabel)AddControl(new Guid("03ae9775-395a-42eb-af72-6bf837a0e0d7"));
            ttlabel25 = (ITTLabel)AddControl(new Guid("46175121-2d42-441a-88f3-c851dc7ec2b7"));
            ttlabel24 = (ITTLabel)AddControl(new Guid("5f6750f1-20f7-4d56-8b6c-6ceacf3ed1e2"));
            labelBloodFlow = (ITTLabel)AddControl(new Guid("871ff9d8-10dd-408b-885d-9db0666eb483"));
            BloodFlow = (ITTObjectListBox)AddControl(new Guid("1d7baa8d-3eb8-4ee4-9f9b-d83f0d4938ed"));
            labelDialyzatorArea = (ITTLabel)AddControl(new Guid("7eb6aa2d-15ca-4a77-808d-9815dee275fc"));
            DialyzatorArea = (ITTObjectListBox)AddControl(new Guid("60db83cd-b739-4bd2-b025-f74b1b0da849"));
            labelDialyzatorType = (ITTLabel)AddControl(new Guid("bfefed18-64b3-40de-a11d-19da56f6cf66"));
            DialyzatorType = (ITTObjectListBox)AddControl(new Guid("fa7ac9f5-9dd0-4660-a5ab-f264bfb17a37"));
            labelIntravenous = (ITTLabel)AddControl(new Guid("d2973d0d-c565-4077-ba5c-befbedd269db"));
            Intravenous = (ITTObjectListBox)AddControl(new Guid("f2be2134-cfa1-4459-859e-ef7547376017"));
            labelCareNurse = (ITTLabel)AddControl(new Guid("b7541008-3235-410d-b006-69adae6ca679"));
            CareNurse = (ITTObjectListBox)AddControl(new Guid("0815bbcb-e082-4109-bfe2-0774bdab0629"));
            labelNurse = (ITTLabel)AddControl(new Guid("5f2e4151-80d4-4f1e-9d3a-b27f2680371f"));
            Nurse = (ITTObjectListBox)AddControl(new Guid("8903e97b-2dfe-486f-8c49-14bf207966ff"));
            labelDoctor = (ITTLabel)AddControl(new Guid("a56e1041-a6b3-4230-8a1f-d0b05856e9e0"));
            Doctor = (ITTObjectListBox)AddControl(new Guid("4449dd2c-37b2-461c-8790-51c182996769"));
            labelWeightBefore = (ITTLabel)AddControl(new Guid("58e1796b-8c56-4941-b9c9-ec9bcb038736"));
            WeightBefore = (ITTTextBox)AddControl(new Guid("fe4fd4c7-d0f8-451b-8dec-c5d19d8d595f"));
            labelWeightAfter = (ITTLabel)AddControl(new Guid("562a0687-285a-4fff-af47-3b777a894f09"));
            WeightAfter = (ITTTextBox)AddControl(new Guid("8c1f7073-94b6-4f58-b062-ec5e095f7141"));
            labelSessionStartTime = (ITTLabel)AddControl(new Guid("bd2b7201-c260-423c-ab64-682d4e8b0b5c"));
            SessionStartTime = (ITTDateTimePicker)AddControl(new Guid("1dfb9135-4cde-406d-8f28-84f38b239dc5"));
            labelSessionFinishTime = (ITTLabel)AddControl(new Guid("abd9f872-09b6-4c8c-9f54-6ae69bf5cd07"));
            SessionFinishTime = (ITTDateTimePicker)AddControl(new Guid("a5c04e1a-ebb7-490b-95c4-f7eac7d28d1e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("8fd701cf-6372-4cc7-b74d-e2a2230089d0"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("97565b30-a368-4b1d-a9eb-2ce2e5ad7ba7"));
            labelLiquid = (ITTLabel)AddControl(new Guid("32164817-4893-4a1e-bc98-2f8e2e672c6f"));
            Liquid = (ITTTextBox)AddControl(new Guid("ba415f6a-05dd-4c88-9b95-164ed90e36df"));
            labelInformation = (ITTLabel)AddControl(new Guid("9dd77b9e-6d01-49bb-8795-c2a12ad6bb3c"));
            Information = (ITTTextBox)AddControl(new Guid("b02d1fd1-1574-4441-896f-81f1a0361463"));
            labelDialysateTransferSpeed = (ITTLabel)AddControl(new Guid("a51d6264-a1c0-4529-b348-48657bf320f0"));
            DialysateTransferSpeed = (ITTTextBox)AddControl(new Guid("487b4316-159c-4c6c-9d96-9feda333586f"));
            labelDevice = (ITTLabel)AddControl(new Guid("2d225eee-b8e2-4d2a-b322-fbf8fea10079"));
            Device = (ITTTextBox)AddControl(new Guid("13290512-bcd3-4feb-a02a-14f69b796ea0"));
            CatheterCare = (ITTCheckBox)AddControl(new Guid("d77969de-dfc2-451b-9c3d-045bdaf00146"));
            AVFCare = (ITTCheckBox)AddControl(new Guid("e47ee3dc-fab7-4650-8241-9d1b1db96d0a"));
            tabSaglikNet = (ITTTabPage)AddControl(new Guid("55eef3ff-d495-4e06-9458-0ffce6c6eec2"));
            grpKtv = (ITTGroupBox)AddControl(new Guid("ff5ec1d9-2676-4486-9f9c-e815a5100c3c"));
            labelURR = (ITTLabel)AddControl(new Guid("40a63840-fb57-4df9-b386-6daab978d660"));
            labelBunPre = (ITTLabel)AddControl(new Guid("390c413d-6894-4aca-bbec-48ffc81cffe4"));
            labelKtv = (ITTLabel)AddControl(new Guid("38089b33-ab93-473a-b0d5-a2caeca82fa6"));
            Ktv = (ITTTextBox)AddControl(new Guid("9c065cef-9938-4072-8280-3d3629e3156f"));
            URR = (ITTTextBox)AddControl(new Guid("782a2212-690f-4ae9-99e1-f4d4a88122c0"));
            BunPre = (ITTTextBox)AddControl(new Guid("ca8a7ad4-0bdd-4c23-84e9-76f7b7248475"));
            labelBunPost = (ITTLabel)AddControl(new Guid("2f90c76d-fb06-4251-b22f-5cd2d1f76b31"));
            BunPost = (ITTTextBox)AddControl(new Guid("82d7d765-7b72-46cd-8555-8f25e022078c"));
            grpSaglikNet = (ITTGroupBox)AddControl(new Guid("daf871dc-17e7-4572-8379-9e71557b6fb7"));
            DialysisTreatmentMethod = (ITTObjectListBox)AddControl(new Guid("cdb58688-013a-4019-9f7e-2156981a9829"));
            labelTreatmentCourse = (ITTLabel)AddControl(new Guid("de7d4ee3-fd17-447c-bf70-37f347ee6b04"));
            TreatmentCourse = (ITTObjectListBox)AddControl(new Guid("d3323e3f-4624-4db4-9f6f-81111012d997"));
            labelDialysisTreatmentMethod = (ITTLabel)AddControl(new Guid("7b9f0339-a5f7-4035-a77a-a935afb7aacf"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("67512aeb-37ec-4d36-9adc-4889266b99be"));
            labelVitaminDusage = (ITTLabel)AddControl(new Guid("882dbfa5-94cc-415c-8953-bed3fb960ae4"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e8f5f730-f92e-427b-8afb-dbda39cc0274"));
            VitaminDusage = (ITTObjectListBox)AddControl(new Guid("d7309158-6dd7-4d04-b17e-b2f98d372a9d"));
            AnemiaTreatmentMethod = (ITTObjectListBox)AddControl(new Guid("f929ee31-679e-49e7-8660-23eac462a96f"));
            labelAnemiaTreatmentMethod = (ITTLabel)AddControl(new Guid("0e217527-58ed-493e-a016-536b20e1c80d"));
            base.InitializeControls();
        }

        public HemodialysisOrderDetailForm() : base("HEMODIALYSISORDERDETAIL", "HemodialysisOrderDetailForm")
        {
        }

        protected HemodialysisOrderDetailForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}