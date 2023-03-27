
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
    /// Taş Kırma
    /// </summary>
    public partial class StoneBreakUpProcedureForm : EpisodeActionForm
    {
    /// <summary>
    /// Taş Kırma
    /// </summary>
        protected TTObjectClasses.StoneBreakUpRequest _StoneBreakUpRequest
        {
            get { return (TTObjectClasses.StoneBreakUpRequest)_ttObject; }
        }

        protected ITTButton btnRaporuMedulayaKaydet;
        protected ITTLabel labelReportEndDate;
        protected ITTDateTimePicker ReportEndDate;
        protected ITTLabel labelReportStartDate;
        protected ITTDateTimePicker ReportStartDate;
        protected ITTRichTextBoxControl Note;
        protected ITTRichTextBoxControl Symptom;
        protected ITTDateTimePicker ProcessDate;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage StoneBreakUp;
        protected ITTGrid StoneBreakUpProcedures;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn PartOfStone;
        protected ITTTextBoxColumn StoneDimension;
        protected ITTTextBoxColumn NumberOfProcedure;
        protected ITTEnumComboBoxColumn ZoneOfStone;
        protected ITTListBoxColumn Performer;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid TreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn MaterialNote;
        protected ITTTextBoxColumn KodsuzMalzemeFiyati;
        protected ITTTextBoxColumn Kdv;
        protected ITTTextBoxColumn MalzemeBrans;
        protected ITTDateTimePickerColumn MalzemeSatinAlisTarihi;
        protected ITTListBoxColumn MalzemeTuru;
        protected ITTListBoxColumn MalzemeBilgisi_OzelDurum;
        protected ITTTabPage MedulaBilgileri;
        protected ITTObjectListBox TTListBoxDrAnesteziTescilNo;
        protected ITTObjectListBox TTListBoxAyniFarkliKesi;
        protected ITTObjectListBox TTListBoxOzelDurum;
        protected ITTLabel labelAyniFarkliKesi;
        protected ITTLabel labelRaporTakipNo;
        protected ITTTextBox RaporTakipNo;
        protected ITTLabel labelDrAnesteziTescilNo;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn CokluOzelDurum;
        protected ITTLabel labelOzelDurum;
        protected ITTTabPage MedalaRaporBilgileri;
        protected ITTGrid MedulaReportResults;
        protected ITTTextBoxColumn ReportChasingNoMedulaReportResult;
        protected ITTTextBoxColumn ReportNumberMedulaReportResult;
        protected ITTTextBoxColumn ReportRowNumberMedulaReportResult;
        protected ITTTextBoxColumn ResultCodeMedulaReportResult;
        protected ITTTextBoxColumn ResultExplanationMedulaReportResult;
        protected ITTDateTimePickerColumn SendReportDateMedulaReportResult;
        protected ITTButtonColumn btnMedulaRaporSil;
        protected ITTTextBox ProtocolNo;
        protected ITTTextBox Age;
        protected ITTLabel labelProcedureDate;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTDateTimePicker RequestDate;
        protected ITTCheckBox Urgent;
        protected ITTLabel labelProtocolNo;
        protected ITTLabel labelRequestDate;
        protected ITTEnumComboBox PatientStatus;
        protected ITTLabel ttlabel3;
        protected ITTEnumComboBox Sex;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel4;
        protected ITTObjectListBox Equipment;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            btnRaporuMedulayaKaydet = (ITTButton)AddControl(new Guid("46b9972b-3b75-4d5e-8215-d83c8901dc51"));
            labelReportEndDate = (ITTLabel)AddControl(new Guid("d9f67887-0d92-4b07-a6d3-605f533ed03d"));
            ReportEndDate = (ITTDateTimePicker)AddControl(new Guid("69522a30-29c9-4b67-b0b9-19b8025f9480"));
            labelReportStartDate = (ITTLabel)AddControl(new Guid("03c021da-03de-4e70-aca0-791d2ea38de9"));
            ReportStartDate = (ITTDateTimePicker)AddControl(new Guid("d5a0cc64-532e-4af0-9fc3-6ce0432735d3"));
            Note = (ITTRichTextBoxControl)AddControl(new Guid("388b3fb5-c799-4e44-8951-456807f3369c"));
            Symptom = (ITTRichTextBoxControl)AddControl(new Guid("6d8943bc-4b40-4722-a373-816a2df4151b"));
            ProcessDate = (ITTDateTimePicker)AddControl(new Guid("f7cd0619-4205-4a9f-ac0d-713ae1686024"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("756ca1ab-d357-448e-a2bc-d87964c7dc3a"));
            StoneBreakUp = (ITTTabPage)AddControl(new Guid("7ea0fbf8-b3fa-415f-9cb5-1fb96c6cc46d"));
            StoneBreakUpProcedures = (ITTGrid)AddControl(new Guid("ac9018ae-a41d-405c-af13-8241e22b0c1b"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("e6772f72-7886-4609-93a5-8df0e3f666b2"));
            PartOfStone = (ITTListBoxColumn)AddControl(new Guid("c97d63ac-3bd7-4d7b-9640-b9ff4596c1da"));
            StoneDimension = (ITTTextBoxColumn)AddControl(new Guid("0a0bc72a-616d-462c-a273-e0006c601da3"));
            NumberOfProcedure = (ITTTextBoxColumn)AddControl(new Guid("25edc1b8-8e02-4f88-825e-4e0e25f74a23"));
            ZoneOfStone = (ITTEnumComboBoxColumn)AddControl(new Guid("55a8a085-a2be-4827-8204-adee3cf01bec"));
            Performer = (ITTListBoxColumn)AddControl(new Guid("8585ac27-53a6-4598-a760-b27490dc2c40"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("ee7bf589-7d50-44c0-8593-d6ead3061036"));
            TreatmentMaterials = (ITTGrid)AddControl(new Guid("7b6cea29-56a4-4a07-a4db-180898f7dd7f"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("6d86b3d6-c4c6-474b-ac56-26fe87ec85d4"));
            Material = (ITTListBoxColumn)AddControl(new Guid("cc92e35a-fb04-4236-a205-65f57b6ec822"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("c7e7cd4d-961a-4d5d-b47e-3fa083d8d997"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("9542e3be-5c06-495c-b3cf-27a62c404a4a"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b7ec6fa2-a7f8-4507-a0b8-d10ab31a9a18"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("64cbd299-8231-4d70-aa71-c8641bef1418"));
            MaterialNote = (ITTTextBoxColumn)AddControl(new Guid("71dd2ec9-5f41-4090-bfdb-f8a6f8f2df44"));
            KodsuzMalzemeFiyati = (ITTTextBoxColumn)AddControl(new Guid("15b53449-90d9-4a1d-8b33-4529d28cf206"));
            Kdv = (ITTTextBoxColumn)AddControl(new Guid("53277e81-4da0-4aa7-bc9d-06319f6ea299"));
            MalzemeBrans = (ITTTextBoxColumn)AddControl(new Guid("f824a007-7d60-421d-9118-2ffac9dd1319"));
            MalzemeSatinAlisTarihi = (ITTDateTimePickerColumn)AddControl(new Guid("60e552e0-02be-4908-a843-8ab56a436dc5"));
            MalzemeTuru = (ITTListBoxColumn)AddControl(new Guid("28d172b2-d912-473e-978b-0c05e9d82fcd"));
            MalzemeBilgisi_OzelDurum = (ITTListBoxColumn)AddControl(new Guid("f248b687-bd4b-4ce1-b9d0-4ee71a264522"));
            MedulaBilgileri = (ITTTabPage)AddControl(new Guid("b962497b-1081-41d0-af21-ed8b5309ddd4"));
            TTListBoxDrAnesteziTescilNo = (ITTObjectListBox)AddControl(new Guid("acaa40ad-a11f-4360-ac35-1724c7db0494"));
            TTListBoxAyniFarkliKesi = (ITTObjectListBox)AddControl(new Guid("02f3c204-9624-492b-a8b3-e4c533c9a0d5"));
            TTListBoxOzelDurum = (ITTObjectListBox)AddControl(new Guid("703b65d7-54bc-4071-bc1a-16908296d8c9"));
            labelAyniFarkliKesi = (ITTLabel)AddControl(new Guid("4d9d8e18-6ee4-420b-bd6b-bfe0be369883"));
            labelRaporTakipNo = (ITTLabel)AddControl(new Guid("92d19b78-ec45-4266-8784-0c4c39c2df69"));
            RaporTakipNo = (ITTTextBox)AddControl(new Guid("335cdf65-b386-4eaa-8f92-115fc9bafe9f"));
            labelDrAnesteziTescilNo = (ITTLabel)AddControl(new Guid("05c8258d-8bc9-48c0-8040-5e1a67616ad6"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("62745aaf-5a18-421c-b2d3-4004e55db46b"));
            CokluOzelDurum = (ITTListBoxColumn)AddControl(new Guid("f61d5564-a59d-42f5-9c5e-0a9c5744e168"));
            labelOzelDurum = (ITTLabel)AddControl(new Guid("73f4cc07-55d8-465f-9e72-b932615dcc8f"));
            MedalaRaporBilgileri = (ITTTabPage)AddControl(new Guid("0afcecc8-7dd7-4140-8276-16bf625a39bd"));
            MedulaReportResults = (ITTGrid)AddControl(new Guid("ad6293f1-37b1-4fda-8836-fa8008c79b9b"));
            ReportChasingNoMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("16e5fc72-da51-429a-b3e3-a446126592af"));
            ReportNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("a4e0fdc1-597b-474b-83f4-aa96b30af6da"));
            ReportRowNumberMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("153b9a92-c952-4ecb-8a2e-6d2c4759dca8"));
            ResultCodeMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("1c62c6b4-21ca-4c1f-b412-5adb8c20b319"));
            ResultExplanationMedulaReportResult = (ITTTextBoxColumn)AddControl(new Guid("8a98f6e4-0ada-4f75-981c-43d2e45ebaad"));
            SendReportDateMedulaReportResult = (ITTDateTimePickerColumn)AddControl(new Guid("7a88735e-41f7-49b1-bb8f-023cd97601bd"));
            btnMedulaRaporSil = (ITTButtonColumn)AddControl(new Guid("e41b2747-e341-420b-8b16-541a133a9066"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("1726eef9-c352-4918-aad8-11019cfdc0f8"));
            Age = (ITTTextBox)AddControl(new Guid("201f3a39-69f1-4d59-ab4f-789f6064c91c"));
            labelProcedureDate = (ITTLabel)AddControl(new Guid("66847222-1f7a-425f-b279-dfcfd75219c3"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("64628a45-bdc1-4be2-b929-122771584aa9"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("a3f7317e-1338-4e11-b84e-21e22afa4813"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("55dadbbc-e20e-42f0-beb1-084580e8e91f"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("5d8eb95a-b05d-4c98-8e96-3d705087571a"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("d9dddbe1-561f-4f93-8db8-b30fb50d294e"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("a5fbdbb1-8767-41de-b00e-74812522ba0f"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("d7eee882-7a6d-4cbc-9d22-1f4617a99c66"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2473c5ba-d5d1-4312-96da-033e69e489fa"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("061f3fd6-a5ec-4c91-90ff-64e18bde3f14"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("78d91bd7-b6f8-4280-b93e-13a1d3de4aee"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("1e5c8026-3f3e-44c4-8683-80090abe304f"));
            Urgent = (ITTCheckBox)AddControl(new Guid("646a5ab7-e786-4aaa-abb4-8897b117df9b"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("c63eaffd-5ce2-4288-9df9-72454b3d7cb1"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("27a01b12-6793-4f68-bbc8-1f169231ca78"));
            PatientStatus = (ITTEnumComboBox)AddControl(new Guid("b792960b-85c8-45dd-8b79-1c3d16e31ce5"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ac0093a2-1627-4f2b-b762-514799634edf"));
            Sex = (ITTEnumComboBox)AddControl(new Guid("3e840342-b06f-4005-9a9b-85e944803d95"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("3bd95a20-d2ec-4040-85cf-1fa8c9bf1703"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("061e8c95-5347-4410-9b70-10366a112d93"));
            Equipment = (ITTObjectListBox)AddControl(new Guid("63901e4a-7d8d-47a4-b072-f693a5845253"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("0f4e05d1-6f0d-4927-9c07-5a58bcc95c91"));
            base.InitializeControls();
        }

        public StoneBreakUpProcedureForm() : base("STONEBREAKUPREQUEST", "StoneBreakUpProcedureForm")
        {
        }

        protected StoneBreakUpProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}