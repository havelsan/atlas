
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
    /// Doğum Bilgileri
    /// </summary>
    public partial class RegularObstetricInformationForm : EpisodeActionForm
    {
    /// <summary>
    /// Normal Doğum
    /// </summary>
        protected TTObjectClasses.RegularObstetric _RegularObstetric
        {
            get { return (TTObjectClasses.RegularObstetric)_ttObject; }
        }

        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelLastMenstrualPeriodPregnancy;
        protected ITTDateTimePicker LastMenstrualPeriodPregnancy;
        protected ITTLabel labelEstimatedBirthDatePregnancy;
        protected ITTDateTimePicker EstimatedBirthDatePregnancy;
        protected ITTLabel labelPregnancyRange;
        protected ITTObjectListBox PregnancyRange;
        protected ITTLabel labelBirthResult;
        protected ITTObjectListBox BirthResult;
        protected ITTLabel labelWhichPregnancy;
        protected ITTTextBox WhichPregnancy;
        protected ITTLabel labelPregnancyRiskInfo;
        protected ITTTextBox PregnancyRiskInfo;
        protected ITTLabel labelMotherAge;
        protected ITTTextBox MotherAge;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn RegularObstetricActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn RegularObstetricDoctor;
        protected ITTTextBoxColumn RaporTakipNo;
        protected ITTListDefComboBoxColumn OzelDurum;
        protected ITTListDefComboBoxColumn AyniFarkliKesi;
        protected ITTButtonColumn CokluOzelDurum;
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn StockOutAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTListDefComboBoxColumn MalzemeTuru;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTCheckBox ApprovalFormGiven;
        override protected void InitializeControls()
        {
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("68becc26-4227-4ab9-a96b-5d32a2791ef2"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("44c8c653-c26c-4720-ae24-7b997a5c55f0"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("a7eb608b-e367-4009-ad6e-2f20a109fc73"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("fb678d65-7aa8-4a74-b847-858f8615cfca"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("b894741f-392e-4a11-915b-344c70826b2b"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("68e29b9c-c0a0-46c3-a60a-2fef47561871"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("337947f5-bcef-49bb-888a-00cb72f0a1a3"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8926eaa2-15c0-42ce-a58b-284a048c3e73"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("0e42cbe9-f584-4138-9d7e-5f6684765257"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("728d7b2f-02d1-419c-8a43-465ffe2eceae"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("77b34c66-16c7-4492-a75e-dcfc3e2e14ee"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("13dc6909-c976-49cb-95a1-1ee7dc584552"));
            labelLastMenstrualPeriodPregnancy = (ITTLabel)AddControl(new Guid("dd835183-cff3-4569-bd4f-4d88a898950b"));
            LastMenstrualPeriodPregnancy = (ITTDateTimePicker)AddControl(new Guid("f1eca13e-be98-462d-a09f-f5db8c95a0b0"));
            labelEstimatedBirthDatePregnancy = (ITTLabel)AddControl(new Guid("216aa14a-d516-410e-97f0-8949082f6da4"));
            EstimatedBirthDatePregnancy = (ITTDateTimePicker)AddControl(new Guid("4135e362-1ca2-450d-85c0-83c2593a162b"));
            labelPregnancyRange = (ITTLabel)AddControl(new Guid("20936d8c-76f0-4105-a6f1-ab41622676f8"));
            PregnancyRange = (ITTObjectListBox)AddControl(new Guid("d92ee0b4-fc94-40f0-b398-4200b5f8f454"));
            labelBirthResult = (ITTLabel)AddControl(new Guid("598e25c5-280e-4512-8996-dee863c60e3e"));
            BirthResult = (ITTObjectListBox)AddControl(new Guid("0027898d-02a7-4f3b-af95-30c2839d69a9"));
            labelWhichPregnancy = (ITTLabel)AddControl(new Guid("8a811f5d-2551-4ae1-aa91-0569ba205776"));
            WhichPregnancy = (ITTTextBox)AddControl(new Guid("32abdecb-98cc-4e0b-8912-87eeca638002"));
            labelPregnancyRiskInfo = (ITTLabel)AddControl(new Guid("487052a2-095b-413a-a94c-dd10ddc3d669"));
            PregnancyRiskInfo = (ITTTextBox)AddControl(new Guid("5d64d34f-96ff-49c1-8f97-28055c021d98"));
            labelMotherAge = (ITTLabel)AddControl(new Guid("16911863-c5e0-4885-8995-24e86da5277d"));
            MotherAge = (ITTTextBox)AddControl(new Guid("3c305521-75fc-4f61-a017-206e2b9bf9c6"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("a1de7a01-7eba-441d-ba96-dbe8f6a27d6b"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("40db5617-9e46-4088-b480-d5c91711e042"));
            GridManipulations = (ITTGrid)AddControl(new Guid("e746bc12-a073-4ad7-8d50-169737edcb62"));
            RegularObstetricActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("38af782f-494c-4026-aed1-1fac8876359c"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("4262dab9-6db8-4cf2-8bea-c08e07ae40a6"));
            RegularObstetricDoctor = (ITTListBoxColumn)AddControl(new Guid("0e5d6e19-b88f-407f-a08d-dc4649df1ba1"));
            RaporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("dd1a2948-8788-4ffd-af48-b1e8a91363de"));
            OzelDurum = (ITTListDefComboBoxColumn)AddControl(new Guid("042814d2-ed5c-44ec-9279-ffe44404b604"));
            AyniFarkliKesi = (ITTListDefComboBoxColumn)AddControl(new Guid("14a21b4f-853e-4022-8af8-386839041263"));
            CokluOzelDurum = (ITTButtonColumn)AddControl(new Guid("032991fc-44b9-4d92-b0b3-7ab995bb47c3"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("8ed24962-3a21-464c-8a87-a205d708d14c"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("eb48879b-68f2-44e8-9893-2bf36169d449"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("ff0ed33a-9eb8-4371-b3e4-0cc477748451"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("3f480017-55fd-406c-9a5f-5652d53c7b73"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("1971978e-e4d7-4ef6-a5b5-96adcd1c0cad"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("400133cd-5f74-4c13-8070-e81c8aca0e31"));
            Material = (ITTListBoxColumn)AddControl(new Guid("91f5d71a-184f-43af-a189-f28c43c7bfc7"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("cc712a16-04d2-4917-bad6-f59e3da32c5f"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("67be7bf7-16b4-4371-85b1-2e36c1d7a93f"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("56936bb6-69c0-4d37-8c19-cd4c9990da6c"));
            StockOutAmount = (ITTTextBoxColumn)AddControl(new Guid("0953ec81-dd5b-4438-865a-87646351d335"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("5db94b26-4998-4d23-b609-ac40f5808401"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("a3b13f7b-d6e5-44e0-931d-728c22918a67"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("3aefa477-a513-4ebc-b902-7898c34c02fb"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("314395f8-3e19-4643-a4dc-ac487c0529cd"));
            MalzemeTuru = (ITTListDefComboBoxColumn)AddControl(new Guid("29cd90d2-1d8d-4a7b-9378-9c702eea295e"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("c0b1df40-48a9-4593-a38d-319e67ddd77f"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("34379887-037e-4c6b-93d0-c3796bf7f27b"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("e9c77dbe-53ae-4116-a2de-761a17f2a914"));
            ApprovalFormGiven = (ITTCheckBox)AddControl(new Guid("9426ce96-3000-433d-8a3b-9141b27ab83c"));
            base.InitializeControls();
        }

        public RegularObstetricInformationForm() : base("REGULAROBSTETRIC", "RegularObstetricInformationForm")
        {
        }

        protected RegularObstetricInformationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}