
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
    public partial class EmergencySpecialityObjectForm : TTForm
    {
    /// <summary>
    /// Acil Muayene Hasta Değerlendirme Objesi
    /// </summary>
        protected TTObjectClasses.EmergencySpecialityObject _EmergencySpecialityObject
        {
            get { return (TTObjectClasses.EmergencySpecialityObject)_ttObject; }
        }

        protected ITTGrid EmergencyDefinitions;
        protected ITTListBoxColumn Definitions;
        protected ITTObjectListBox Triage;
        protected ITTCheckBox cbxTetanoz;
        protected ITTTextBox txtAlcoholPromile;
        protected ITTTextBox LastEatingInfo;
        protected ITTLabel lblAlcohol;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTGroupBox ttgroupbox7;
        protected ITTLabel labelEyes;
        protected ITTObjectListBox Eyes;
        protected ITTLabel labelOralAnswer;
        protected ITTObjectListBox OralAnswer;
        protected ITTLabel labelMotorAnswer;
        protected ITTObjectListBox MotorAnswer;
        protected ITTLabel labelTotalScore;
        protected ITTEnumComboBox TotalScore;
        protected ITTGroupBox ttgroupbox16;
        protected ITTTextBox FaceScala;
        protected ITTLabel ttlabel2;
        protected ITTTextBox PainPlace;
        protected ITTLabel ttlabel3;
        protected ITTTextBox PainDegree;
        protected ITTLabel ttlabel4;
        protected ITTTextBox PainPeriod;
        protected ITTLabel ttlabel5;
        protected ITTGroupBox GenelDurum;
        protected ITTCheckBox GeneralEvaluationGood;
        protected ITTCheckBox GeneralEvaluationCold;
        protected ITTCheckBox GeneralEvaluationSweaty;
        protected ITTCheckBox GeneralEvaluationDehidrate;
        protected ITTCheckBox GeneralEvaluationDispneic;
        protected ITTCheckBox GeneralEvaluationPainly;
        protected ITTCheckBox GeneralEvaluationBad;
        protected ITTCheckBox GeneralEvaluationMedium;
        protected ITTGroupBox ttgroupbox15;
        protected ITTTextBox PsychologicalEvaluationOther;
        protected ITTLabel ttlabel1;
        protected ITTCheckBox PsychologicalEvaluationNormal;
        protected ITTCheckBox PsychologicalEvaluationIrrelevant;
        protected ITTCheckBox PsychologicalEvaluationWorried;
        protected ITTCheckBox PsychologicalEvaluationSad;
        protected ITTCheckBox PsychologicalEvaluationAngry;
        protected ITTCheckBox cbxGebe;
        protected ITTLabel ttlabel8;
        protected ITTLabel labelLastMenstrualPeriod;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage tttabpage1;
        protected ITTRichTextBoxControl rbxContinuousDrugs;
        protected ITTLabel lblContinuousDrugs;
        protected ITTRichTextBoxControl rchHabit;
        protected ITTLabel lblHabit;
        protected ITTRichTextBoxControl rchAllergy;
        protected ITTLabel lblAlerji;
        protected ITTEnumComboBox ComplaintDurationType;
        protected ITTTextBox ComplaintDuration;
        protected ITTObjectListBox Complaint;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTObjectListBox PatientHistory;
        protected ITTRichTextBoxControl ttrichtextboxcontrol2;
        protected ITTLabel ttlabel11;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage AllergyVaccination;
        protected ITTGrid ttgrid1;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn Reaction;
        protected ITTEnumComboBoxColumn Risk2;
        protected ITTLabel ttlabel14;
        protected ITTLabel labelAllergyInformation;
        protected ITTGrid ttgrid2;
        protected ITTTextBoxColumn Aşı;
        protected ITTTextBoxColumn Geçerliliği;
        protected ITTEnumComboBoxColumn Risk;
        protected ITTTextBox PainQualityDescription;
        protected ITTTextBox AchingSide;
        protected ITTTextBox DurationofPain;
        protected ITTTextBox PainTime;
        protected ITTTextBox PainDetail;
        protected ITTLabel labelPainQuality;
        protected ITTObjectListBox PainQuality;
        protected ITTLabel labelPainFrequency;
        protected ITTObjectListBox PainFrequency;
        protected ITTLabel labelPainPlaces;
        protected ITTObjectListBox PainPlaces;
        protected ITTLabel labelApplicationDate;
        protected ITTDateTimePicker ApplicationDate;
        protected ITTLabel labelPainFaceScale;
        protected ITTEnumComboBox PainFaceScale;
        protected ITTLabel labelPainQualityDescription;
        protected ITTLabel labelAchingSide;
        protected ITTLabel labelDurationofPain;
        protected ITTLabel labelPainTime;
        protected ITTLabel labelPainDetail;
        override protected void InitializeControls()
        {
            EmergencyDefinitions = (ITTGrid)AddControl(new Guid("213cf29b-ce30-4729-b8e1-2c4b8923bd0d"));
            Definitions = (ITTListBoxColumn)AddControl(new Guid("0e6b73ac-9bdd-41d9-9d25-d5e1e0939af3"));
            Triage = (ITTObjectListBox)AddControl(new Guid("89883152-fbd1-4ac6-9f91-7dbf65f43a18"));
            cbxTetanoz = (ITTCheckBox)AddControl(new Guid("8efcf075-400c-4049-a0a8-abf9cd93ca82"));
            txtAlcoholPromile = (ITTTextBox)AddControl(new Guid("05f870da-86c4-489f-be7c-a79324b1ec94"));
            LastEatingInfo = (ITTTextBox)AddControl(new Guid("768c2e62-c4db-45a3-8d85-5e6b2dbf2234"));
            lblAlcohol = (ITTLabel)AddControl(new Guid("26b4a20f-ea1c-4bdb-8cdb-2dd7a659998a"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("5ef3d5f0-401c-4e17-9599-d075b22882a4"));
            ttgroupbox7 = (ITTGroupBox)AddControl(new Guid("8bd6a225-9912-4fc1-a841-51f887dad2ce"));
            labelEyes = (ITTLabel)AddControl(new Guid("c471a04c-b3a6-4a83-9f50-027a85fdc908"));
            Eyes = (ITTObjectListBox)AddControl(new Guid("0ea1e28f-3a12-4278-ba4a-d8df5bd36cfc"));
            labelOralAnswer = (ITTLabel)AddControl(new Guid("602355b2-f51d-4a44-848c-fdca905fa6e5"));
            OralAnswer = (ITTObjectListBox)AddControl(new Guid("d5331383-9c3c-4a55-8259-a8d07200e23a"));
            labelMotorAnswer = (ITTLabel)AddControl(new Guid("4fd96677-7f20-477e-8eb0-2c40aa7ab053"));
            MotorAnswer = (ITTObjectListBox)AddControl(new Guid("c1163798-f406-473f-9556-b4a08a8b28f0"));
            labelTotalScore = (ITTLabel)AddControl(new Guid("f2a8e0d1-c0f4-47db-9d2c-641cc1c6e0e7"));
            TotalScore = (ITTEnumComboBox)AddControl(new Guid("621c6e8b-f1ae-4a2a-946a-ac15507b5956"));
            ttgroupbox16 = (ITTGroupBox)AddControl(new Guid("04380b27-9fa0-4954-b460-4c9c4ea293c4"));
            FaceScala = (ITTTextBox)AddControl(new Guid("fe126242-d1c7-44b6-933b-4958e43a7264"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("a361bd07-177f-4ff3-a7f7-9123bd2c690e"));
            PainPlace = (ITTTextBox)AddControl(new Guid("0a4e3cfa-94f5-410c-9ead-a724b9f927b2"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b1ef420a-1dee-4c84-b677-676f12d029b8"));
            PainDegree = (ITTTextBox)AddControl(new Guid("d4a5e8e9-9419-4427-9914-5cd9e4d0d9ca"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("0789ab6c-0f73-4a98-a9ee-346daf6d1b84"));
            PainPeriod = (ITTTextBox)AddControl(new Guid("c426b5a4-1f89-42ab-bed0-0acf47b43b9c"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("44ad6e1e-fa49-4c9e-9fb7-4db38bbad3bc"));
            GenelDurum = (ITTGroupBox)AddControl(new Guid("0e600939-b59d-4769-9938-cdc199715cf1"));
            GeneralEvaluationGood = (ITTCheckBox)AddControl(new Guid("2d8f414a-a5d7-4f47-b292-2b3a95207efe"));
            GeneralEvaluationCold = (ITTCheckBox)AddControl(new Guid("feea79a5-bc4c-4363-8150-9cbaf869e52c"));
            GeneralEvaluationSweaty = (ITTCheckBox)AddControl(new Guid("ab16a26f-050c-47f4-8220-fcb7c543a81f"));
            GeneralEvaluationDehidrate = (ITTCheckBox)AddControl(new Guid("4d5343c4-d7d5-4b0c-9b59-f624b71f3da7"));
            GeneralEvaluationDispneic = (ITTCheckBox)AddControl(new Guid("1a9c1784-9567-416e-b27f-f3815d2cf248"));
            GeneralEvaluationPainly = (ITTCheckBox)AddControl(new Guid("a9a1173e-42bf-4225-9762-15ad3770e32c"));
            GeneralEvaluationBad = (ITTCheckBox)AddControl(new Guid("f6a1ab3d-6eb4-48fe-a5c5-738a658f873c"));
            GeneralEvaluationMedium = (ITTCheckBox)AddControl(new Guid("718f346c-ff76-42c0-95a2-dfa8076da65a"));
            ttgroupbox15 = (ITTGroupBox)AddControl(new Guid("ba041431-0aab-44b9-8c35-b1a885aada90"));
            PsychologicalEvaluationOther = (ITTTextBox)AddControl(new Guid("75889963-a188-4e6f-a425-0b455785eeef"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("93cc3d47-b2c9-45ff-893c-8b6e843ea969"));
            PsychologicalEvaluationNormal = (ITTCheckBox)AddControl(new Guid("5e40a9ff-4099-4071-9fd8-af7efec4987e"));
            PsychologicalEvaluationIrrelevant = (ITTCheckBox)AddControl(new Guid("a6068b6a-ac20-41ca-8e81-7287659278cc"));
            PsychologicalEvaluationWorried = (ITTCheckBox)AddControl(new Guid("aaf594ff-d0de-42b7-98fd-d8bbf267650e"));
            PsychologicalEvaluationSad = (ITTCheckBox)AddControl(new Guid("34eae129-3a00-4516-8913-945346505680"));
            PsychologicalEvaluationAngry = (ITTCheckBox)AddControl(new Guid("abd5230c-9a03-4109-b053-fc30ee833066"));
            cbxGebe = (ITTCheckBox)AddControl(new Guid("6631e3b8-3450-4b28-b2cc-dada08a2f668"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("4e4a638f-eaac-47f1-9e72-b7b9464322b8"));
            labelLastMenstrualPeriod = (ITTLabel)AddControl(new Guid("0ab15a01-b6b6-4418-9e6c-134fd9f08a28"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("9e280565-6573-45d0-8773-e9057c56afa0"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("bfd1ee34-a4c8-46a8-940b-13c370b6145d"));
            rbxContinuousDrugs = (ITTRichTextBoxControl)AddControl(new Guid("26347451-4d54-4776-8f80-9fa7587dbdf3"));
            lblContinuousDrugs = (ITTLabel)AddControl(new Guid("74d14edc-65ca-4285-b3f8-8af803648944"));
            rchHabit = (ITTRichTextBoxControl)AddControl(new Guid("cc3a1c80-ddf0-4356-8139-c13f9e9a6022"));
            lblHabit = (ITTLabel)AddControl(new Guid("e7c1c4fc-0f77-4ec2-9f42-e16a9504953b"));
            rchAllergy = (ITTRichTextBoxControl)AddControl(new Guid("7135956f-5a2b-4c34-b61c-4c5c4b03b239"));
            lblAlerji = (ITTLabel)AddControl(new Guid("f9744cd2-5230-403f-a5b8-9fc147557599"));
            ComplaintDurationType = (ITTEnumComboBox)AddControl(new Guid("e7fd5d39-c5b3-470a-8016-de227937a634"));
            ComplaintDuration = (ITTTextBox)AddControl(new Guid("d9834753-7e49-4f6b-b6ba-62367440fc95"));
            Complaint = (ITTObjectListBox)AddControl(new Guid("692e61bd-ef71-4099-8b52-ba3cb90336d6"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("1d81002e-5a2a-4e9f-bfc3-8f948122cc4e"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("2cb64307-5d85-40a1-a943-81c6f5b4ce15"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e0672a33-cefc-4bed-9265-466e5b88fb52"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("0ffc54b4-146b-44e3-98e8-41ae0deead20"));
            PatientHistory = (ITTObjectListBox)AddControl(new Guid("410331a3-2c0b-441a-a33a-c66d091d20f6"));
            ttrichtextboxcontrol2 = (ITTRichTextBoxControl)AddControl(new Guid("781cfa5b-9076-4a5a-b41e-527b3ebfb760"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("4b840164-9f83-4557-bc09-e75f7fdf07b2"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("0c5ef002-662e-4938-9468-7f4292483919"));
            AllergyVaccination = (ITTTabPage)AddControl(new Guid("f3c578b6-0c44-42d1-9554-8dec966d3ef1"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("4996be18-cc2e-47e9-86fc-6723a9a2c820"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("1fefbfd1-a369-441f-aa9a-d14d04855782"));
            Reaction = (ITTTextBoxColumn)AddControl(new Guid("e24b1d62-a6a6-45d0-a732-9f979f097f1c"));
            Risk2 = (ITTEnumComboBoxColumn)AddControl(new Guid("21c21f7e-b7a5-4c20-9496-0003b91d90ed"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("0804e458-3fc2-47a3-bfb9-d5f1da1b858d"));
            labelAllergyInformation = (ITTLabel)AddControl(new Guid("b0cc9a81-3ae9-4f6e-b937-a98216e3ffd4"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("6265635b-a0fb-4330-9251-accd79bb860a"));
            Aşı = (ITTTextBoxColumn)AddControl(new Guid("2d6f4948-112b-4bef-acc7-6f2f7566b4df"));
            Geçerliliği = (ITTTextBoxColumn)AddControl(new Guid("586f1760-2629-47e4-9c5f-324ef6f904ab"));
            Risk = (ITTEnumComboBoxColumn)AddControl(new Guid("3dc85adf-aac2-47a9-a408-db428cf09772"));
            PainQualityDescription = (ITTTextBox)AddControl(new Guid("717da5e2-e7a6-4f89-b09f-51176cd73799"));
            AchingSide = (ITTTextBox)AddControl(new Guid("e495a828-f6cf-4188-baac-5b4d0fb67510"));
            DurationofPain = (ITTTextBox)AddControl(new Guid("671a2fa7-02c2-4f71-8531-11362e6f32e2"));
            PainTime = (ITTTextBox)AddControl(new Guid("64bd3770-f7a8-4fc2-93fb-448363bfdbcd"));
            PainDetail = (ITTTextBox)AddControl(new Guid("377aa97d-dd27-44b5-a6d0-b1a8c3610d92"));
            labelPainQuality = (ITTLabel)AddControl(new Guid("d8ecb533-6ef1-4f4e-ac34-26af2f2b7c57"));
            PainQuality = (ITTObjectListBox)AddControl(new Guid("9969f7b2-581d-4c28-90e9-10fb259ce833"));
            labelPainFrequency = (ITTLabel)AddControl(new Guid("a5b5ec8a-bb63-41ce-a0b0-e1cb280794d6"));
            PainFrequency = (ITTObjectListBox)AddControl(new Guid("41000acb-d621-4160-b933-a6055d5953c4"));
            labelPainPlaces = (ITTLabel)AddControl(new Guid("1f69e114-fb08-435a-bbe3-ac04d5c3a391"));
            PainPlaces = (ITTObjectListBox)AddControl(new Guid("5ba6aaa4-2e36-4a3e-a5cc-006231dc4643"));
            labelApplicationDate = (ITTLabel)AddControl(new Guid("75f93686-bef6-47c8-9950-7b9908d3ac36"));
            ApplicationDate = (ITTDateTimePicker)AddControl(new Guid("387d24bf-a040-499a-9164-ea2bf40180e3"));
            labelPainFaceScale = (ITTLabel)AddControl(new Guid("aa33239b-e6ad-4bf9-8f73-8914f388ce38"));
            PainFaceScale = (ITTEnumComboBox)AddControl(new Guid("42e77a9b-0879-410a-a198-e8329e1cb451"));
            labelPainQualityDescription = (ITTLabel)AddControl(new Guid("3178fd72-b417-4db6-883c-a922b9c698bb"));
            labelAchingSide = (ITTLabel)AddControl(new Guid("5580bca0-734a-4048-9ddf-86efcbcbcf0d"));
            labelDurationofPain = (ITTLabel)AddControl(new Guid("cd826a1d-ea72-4e15-9df1-bb1c57f3c905"));
            labelPainTime = (ITTLabel)AddControl(new Guid("980d0687-0a6d-4c87-93f4-017d871f4102"));
            labelPainDetail = (ITTLabel)AddControl(new Guid("a7dc8d50-a980-4389-bd08-e2574e9560b0"));
            base.InitializeControls();
        }

        public EmergencySpecialityObjectForm() : base("EMERGENCYSPECIALITYOBJECT", "EmergencySpecialityObjectForm")
        {
        }

        protected EmergencySpecialityObjectForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}