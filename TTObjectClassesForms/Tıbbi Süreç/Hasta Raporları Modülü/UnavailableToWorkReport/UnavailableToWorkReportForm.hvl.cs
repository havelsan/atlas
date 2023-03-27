
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
    /// İş Göremezlik Belgesi
    /// </summary>
    public partial class UnavailableToWorkReportForm : EpisodeActionForm
    {
    /// <summary>
    /// İş Görmezlik Belgesi
    /// </summary>
        protected TTObjectClasses.UnavailableToWorkReport _UnavailableToWorkReport
        {
            get { return (TTObjectClasses.UnavailableToWorkReport)_ttObject; }
        }

        protected ITTButton btnTCileRaporBul;
        protected ITTMaskedTextBox txtGun;
        protected ITTLabel ttlabel23;
        protected ITTLabel ttlabel22;
        protected ITTGrid DoctorsGrid;
        protected ITTListBoxColumn UnavailableToWorkReportDoctorGrid;
        protected ITTPanel pnlMedulaSonuc;
        protected ITTLabel labelReportRowNumber;
        protected ITTTextBox ReportRowNumber;
        protected ITTLabel labelMedulaChasingNo;
        protected ITTTextBox MedulaChasingNo;
        protected ITTLabel labelResultExplanation;
        protected ITTLabel labelResultCode;
        protected ITTTextBox ResultCode;
        protected ITTTextBox ResultExplanation;
        protected ITTPanel pnlMedulaGonderim;
        protected ITTButton btnRaporBilgisiGetir;
        protected ITTButton btnRaporOnSecim;
        protected ITTButton btnMedulaSaglikKurulunaSevketIptal;
        protected ITTButton btnMedulaKaydet;
        protected ITTButton btnMedulaSaglikKurulunaSevket;
        protected ITTButton btnMdedulaSil;
        protected ITTButton btnMedulaRaporGuncelle;
        protected ITTButton btnMedulaRapor2Ver;
        protected ITTButton btnMedulaRapor2Iptal;
        protected ITTLabel ttlblTaburcuKodu;
        protected ITTEnumComboBox DischargedCodeType;
        protected ITTLabel ttlblDevamDurum;
        protected ITTEnumComboBox ttCmbCarryCaseType;
        protected ITTLabel ttlblYatisDevam;
        protected ITTEnumComboBox ContinuedHospitalizationType;
        protected ITTLabel ttSigortalininOlupOlmedigi;
        protected ITTEnumComboBox DeathType;
        protected ITTLabel ttlblRaporDuzenlemeTuru;
        protected ITTEnumComboBox EditingTourType;
        protected ITTTabControl tttabcontrolReportType;
        protected ITTTabPage tttabIsKazasi;
        protected ITTLabel ttlabel19;
        protected ITTObjectListBox lstBoxWoundType;
        protected ITTLabel ttlabel18;
        protected ITTObjectListBox lstBoxWoundPosition;
        protected ITTLabel ttIsKazasiTarihi;
        protected ITTLabel ttlblNuks;
        protected ITTDateTimePicker ttNuksDate;
        protected ITTEnumComboBox ttCmbNuksType;
        protected ITTTabPage tttabMeslekHastaligi;
        protected ITTLabel ttlabel21;
        protected ITTLabel ttlabel20;
        protected ITTObjectListBox lstBoxMHWoundType;
        protected ITTObjectListBox lstBoxMHWoundPosition;
        protected ITTEnumComboBox ttCmbMHNuksType;
        protected ITTLabel ttlabel1;
        protected ITTTabPage tttabHastalik;
        protected ITTLabel ttlabel17;
        protected ITTEnumComboBox ttCmbHastalikNuksType;
        protected ITTTabPage tttabAnalik;
        protected ITTLabel ttlabel11;
        protected ITTTextBox ttTxtCanliDoganBebekSayisi;
        protected ITTLabel ttlabel10;
        protected ITTTextBox ttTxtDoganCocukSayisi;
        protected ITTLabel ttlabel9;
        protected ITTEnumComboBox ttCmbBirthType;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttBabyBirthDate;
        protected ITTLabel ttlabel7;
        protected ITTLabel ttlabel6;
        protected ITTEnumComboBox ttCmbPregnancyType;
        protected ITTEnumComboBox ttCmbMaternityReportType;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTTextBox tttTxtAktarmaHaftasi;
        protected ITTTextBox ttTxtBebekDogumHaftasi;
        protected ITTTextBox ttTxtGebelikHaftasi2;
        protected ITTTextBox ttTxtGebelikHaftasi1;
        protected ITTTabPage tttabEmzirme;
        protected ITTCheckBox NotWorkMother;
        protected ITTLabel labelFatherTCNo;
        protected ITTTextBox FatherTCNo;
        protected ITTLabel ttlabel16;
        protected ITTTextBox tttxtMotherTcNo;
        protected ITTDateTimePicker ttTransferringDate;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel14;
        protected ITTLabel ttlabel13;
        protected ITTTextBox ttTxTEDoganCocukSayisi;
        protected ITTTextBox ttTXTECanliDoganSayisi;
        protected ITTLabel ttlabel12;
        protected ITTDateTimePicker ttEBabyBirthDate;
        protected ITTTabPage tttabRaporlar;
        protected ITTGrid gridRaporlar;
        protected ITTTextBoxColumn raporTakipNo;
        protected ITTTextBoxColumn raporNo;
        protected ITTTextBoxColumn raporSiraNo;
        protected ITTTextBoxColumn raporSonucKodu;
        protected ITTTextBoxColumn raporSonucAciklama;
        protected ITTTextBoxColumn raporBaslangicTarihi;
        protected ITTTextBoxColumn raporBitisTarihi;
        protected ITTButtonColumn raporSil;
        protected ITTTextBoxColumn raporExcuse;
        protected ITTTextBoxColumn objectID;
        protected ITTButtonColumn raporSec;
        protected ITTTextBox PoliclinicSequenceNo;
        protected ITTEnumComboBox FirstOrSecondTenDays;
        protected ITTLabel labelPoliclinicSequenceNo;
        protected ITTLabel labelVdate;
        protected ITTLabel labelFirstOrSecondTenDays;
        protected ITTLabel labelExcuse;
        protected ITTEnumComboBox Excuse;
        protected ITTLabel labelDiagnosis;
        protected ITTDateTimePicker ResStartDate;
        protected ITTDateTimePicker ResEndDate;
        protected ITTLabel labelResStartDate;
        protected ITTLabel labelResEndDate;
        protected ITTLabel labelSituationDate;
        protected ITTLabel labelSituation;
        protected ITTEnumComboBox Situation;
        protected ITTDateTimePicker SituationDate;
        protected ITTLabel labelAbsence;
        protected ITTDateTimePicker AbsenceStartDate;
        protected ITTDateTimePicker AbsenceEndDate;
        protected ITTDateTimePicker DischargeDate;
        protected ITTLabel lblTaburcuTarihi;
        protected ITTDateTimePicker ProtocolDate;
        protected ITTLabel labelProtocolDate;
        protected ITTObjectListBox ListDiagnosisDefinition;
        override protected void InitializeControls()
        {
            btnTCileRaporBul = (ITTButton)AddControl(new Guid("c377debf-f27f-43b4-aeec-04ed2f73f77d"));
            txtGun = (ITTMaskedTextBox)AddControl(new Guid("e43c31a5-e2a9-4318-8947-9d417b175b5a"));
            ttlabel23 = (ITTLabel)AddControl(new Guid("cb2ee3df-4036-4165-b447-e8ef8f8ae72b"));
            ttlabel22 = (ITTLabel)AddControl(new Guid("93507317-16f0-4b12-9d5a-22eaa75c8f49"));
            DoctorsGrid = (ITTGrid)AddControl(new Guid("6a8b2516-2138-4f32-b023-9c1bbeda9c2a"));
            UnavailableToWorkReportDoctorGrid = (ITTListBoxColumn)AddControl(new Guid("b3776cad-dee4-42f9-b50f-3e8c36945168"));
            pnlMedulaSonuc = (ITTPanel)AddControl(new Guid("45c3b4b5-4341-4127-9f4e-b6100adc879a"));
            labelReportRowNumber = (ITTLabel)AddControl(new Guid("8dbc40f6-662a-409f-8229-358772e86993"));
            ReportRowNumber = (ITTTextBox)AddControl(new Guid("ee54f71c-3ff0-4bb8-95cf-dd3426747b66"));
            labelMedulaChasingNo = (ITTLabel)AddControl(new Guid("bad3f1ec-ac37-42df-990c-02c337d3cf28"));
            MedulaChasingNo = (ITTTextBox)AddControl(new Guid("62e7515f-e332-4683-9efb-9cb81735f673"));
            labelResultExplanation = (ITTLabel)AddControl(new Guid("6ae621c6-9216-4fb5-9323-caf7d4ce0335"));
            labelResultCode = (ITTLabel)AddControl(new Guid("d2d34ffb-872c-433d-a430-fed6eeea99a8"));
            ResultCode = (ITTTextBox)AddControl(new Guid("bc50a350-7ef8-4d76-95d5-f95d677a1bc1"));
            ResultExplanation = (ITTTextBox)AddControl(new Guid("01460fd9-6e32-42fd-81f0-93e79e2b97e5"));
            pnlMedulaGonderim = (ITTPanel)AddControl(new Guid("d7cf9121-98e5-40c9-88a0-181612507c0e"));
            btnRaporBilgisiGetir = (ITTButton)AddControl(new Guid("0fdfe6da-4fc1-4574-af51-94cb4762503a"));
            btnRaporOnSecim = (ITTButton)AddControl(new Guid("a265b68b-0fa0-4f68-9ae1-51ca086cc1e6"));
            btnMedulaSaglikKurulunaSevketIptal = (ITTButton)AddControl(new Guid("900b28a0-49f5-4fd7-a731-3ce45cd19b7c"));
            btnMedulaKaydet = (ITTButton)AddControl(new Guid("be6dce4d-e343-4bfb-98c5-61f85a1047d9"));
            btnMedulaSaglikKurulunaSevket = (ITTButton)AddControl(new Guid("2a716b11-6030-4ce7-aab5-e3e08f7e3010"));
            btnMdedulaSil = (ITTButton)AddControl(new Guid("b6535e42-a30a-448c-9360-4d5d2e144fef"));
            btnMedulaRaporGuncelle = (ITTButton)AddControl(new Guid("e618c48b-73b0-4d40-bcf9-f0800981d387"));
            btnMedulaRapor2Ver = (ITTButton)AddControl(new Guid("c87b6a1f-27c0-4f86-807c-91cda848adcb"));
            btnMedulaRapor2Iptal = (ITTButton)AddControl(new Guid("39dd1ec7-3979-4f67-a587-e0466f946693"));
            ttlblTaburcuKodu = (ITTLabel)AddControl(new Guid("dc6e40ff-aca9-4163-a26c-8319c16d349c"));
            DischargedCodeType = (ITTEnumComboBox)AddControl(new Guid("93b09828-bf32-4ecd-8dc9-012a1adccb2e"));
            ttlblDevamDurum = (ITTLabel)AddControl(new Guid("f66df4b3-061e-48ff-8306-f678013a0576"));
            ttCmbCarryCaseType = (ITTEnumComboBox)AddControl(new Guid("8cbe650b-4d6e-4b70-aa21-8f66a16c4eb9"));
            ttlblYatisDevam = (ITTLabel)AddControl(new Guid("9c2fbb64-8947-4eb6-8b89-66d639c8f512"));
            ContinuedHospitalizationType = (ITTEnumComboBox)AddControl(new Guid("7b6539a6-4f6e-41de-ae41-0d72eef4d66d"));
            ttSigortalininOlupOlmedigi = (ITTLabel)AddControl(new Guid("13c1f158-03e2-4c00-92e4-e29a3dd7d6be"));
            DeathType = (ITTEnumComboBox)AddControl(new Guid("879bf1de-c5ce-4de4-bca6-9184427ab19d"));
            ttlblRaporDuzenlemeTuru = (ITTLabel)AddControl(new Guid("253e6604-ac6a-42a6-9e3c-629c74376917"));
            EditingTourType = (ITTEnumComboBox)AddControl(new Guid("4f18a2fb-32c0-47d8-b384-3380aefffac6"));
            tttabcontrolReportType = (ITTTabControl)AddControl(new Guid("0ba5df50-f1a0-46b4-b2db-574cc74030ad"));
            tttabIsKazasi = (ITTTabPage)AddControl(new Guid("4cfb5cfd-a4e7-4608-89d6-109fa56d0f7b"));
            ttlabel19 = (ITTLabel)AddControl(new Guid("b619e4e8-16a9-41bf-b999-0966083030e9"));
            lstBoxWoundType = (ITTObjectListBox)AddControl(new Guid("8030ca39-ceb2-4576-965d-d4f450d78aca"));
            ttlabel18 = (ITTLabel)AddControl(new Guid("2d027923-08d7-4f2f-994f-719d7d7a33db"));
            lstBoxWoundPosition = (ITTObjectListBox)AddControl(new Guid("03ba9c1a-98a1-48bf-8e11-1ff3ead2e188"));
            ttIsKazasiTarihi = (ITTLabel)AddControl(new Guid("9283ffef-ad31-45ef-b58c-af9d6fced2e7"));
            ttlblNuks = (ITTLabel)AddControl(new Guid("9a3dd5d8-ac2e-4aca-aa88-53ac6bcddb17"));
            ttNuksDate = (ITTDateTimePicker)AddControl(new Guid("19a353c8-3016-4692-824c-13d1f3748dbd"));
            ttCmbNuksType = (ITTEnumComboBox)AddControl(new Guid("6873eadd-0cea-48c4-a440-0b86514492ac"));
            tttabMeslekHastaligi = (ITTTabPage)AddControl(new Guid("4471e15c-e889-42db-a76f-5216aed95b5f"));
            ttlabel21 = (ITTLabel)AddControl(new Guid("0b484de7-03a9-4a3d-9622-199957c12fa3"));
            ttlabel20 = (ITTLabel)AddControl(new Guid("82c549a9-ce6d-40da-b81e-240c73a7c5d5"));
            lstBoxMHWoundType = (ITTObjectListBox)AddControl(new Guid("d2392de9-558b-4e93-90a4-d30e238a960a"));
            lstBoxMHWoundPosition = (ITTObjectListBox)AddControl(new Guid("2b66ba03-cfbe-4288-bf71-2d7aaea87d82"));
            ttCmbMHNuksType = (ITTEnumComboBox)AddControl(new Guid("cf2b82e0-5330-4e18-8283-d8ae97b4084a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("81b18b4c-c9dd-499d-91f6-57de5cc6aff9"));
            tttabHastalik = (ITTTabPage)AddControl(new Guid("6c4de2e7-66ff-4754-9a30-cde885e956ac"));
            ttlabel17 = (ITTLabel)AddControl(new Guid("33d834ec-e91f-4be5-ad03-39ffcf2f0891"));
            ttCmbHastalikNuksType = (ITTEnumComboBox)AddControl(new Guid("8ae55ffb-6b2d-4ad5-bc82-8b221e299478"));
            tttabAnalik = (ITTTabPage)AddControl(new Guid("e1970f1e-ae66-4e03-b40d-e7288e8c09b5"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("c60907c9-54da-4a1a-a858-6344eee2ad19"));
            ttTxtCanliDoganBebekSayisi = (ITTTextBox)AddControl(new Guid("deb9349a-47ba-4cba-91c4-1e308334b87c"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("32926699-944d-41f1-9e1a-962038df59c7"));
            ttTxtDoganCocukSayisi = (ITTTextBox)AddControl(new Guid("aa440590-76b0-41fc-bf98-e5334bb6f19c"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("a92b5b12-4271-447b-b0f3-2200456825bb"));
            ttCmbBirthType = (ITTEnumComboBox)AddControl(new Guid("b2a9770d-0acc-48bb-a0e4-29ffc10f1c8f"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("89e9a74c-a63c-4c93-b56b-34942c1f0137"));
            ttBabyBirthDate = (ITTDateTimePicker)AddControl(new Guid("db6cb8d2-fa96-4a17-b9ec-43744ca3d9a2"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("0a6f1166-4d48-4fed-94cc-51d537d06918"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("ed500091-bb7a-4996-b793-ed39c2fb48b8"));
            ttCmbPregnancyType = (ITTEnumComboBox)AddControl(new Guid("3a9bbf48-b3be-4a23-84fa-f79ee796b7ce"));
            ttCmbMaternityReportType = (ITTEnumComboBox)AddControl(new Guid("38656ff6-ff96-40ba-888f-27148ee0bbe5"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("741a1d6e-5ab6-4d3e-9f44-8c5bd00b457f"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a8cb41ad-b605-4947-aa54-1dcbc9ca6eac"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("268c59af-4b74-4c70-b3bd-2a97ca750881"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("e8059c9b-fa33-4009-9dbc-40d962d6b3b0"));
            tttTxtAktarmaHaftasi = (ITTTextBox)AddControl(new Guid("2e665c3e-c5bf-40cc-a7d5-cc296dc78392"));
            ttTxtBebekDogumHaftasi = (ITTTextBox)AddControl(new Guid("a6b36f86-bcbb-43aa-8bb2-52f8f209acdf"));
            ttTxtGebelikHaftasi2 = (ITTTextBox)AddControl(new Guid("9c933398-b8f1-49bc-a586-34eeef9f7943"));
            ttTxtGebelikHaftasi1 = (ITTTextBox)AddControl(new Guid("dad498fd-6b8c-4123-9c73-e14f32316870"));
            tttabEmzirme = (ITTTabPage)AddControl(new Guid("3c101772-fa08-47a4-b527-8b9800b26a09"));
            NotWorkMother = (ITTCheckBox)AddControl(new Guid("e63df421-7970-451d-9b97-45d321e8d4c8"));
            labelFatherTCNo = (ITTLabel)AddControl(new Guid("80ef6e40-5362-4216-8405-9ddd2a022837"));
            FatherTCNo = (ITTTextBox)AddControl(new Guid("0b13cb3e-43e8-4329-9449-67532b448d00"));
            ttlabel16 = (ITTLabel)AddControl(new Guid("8b2c91d1-ec57-498c-bc80-fc268e53cecc"));
            tttxtMotherTcNo = (ITTTextBox)AddControl(new Guid("239d3207-719f-43f2-80c3-d8833dbf04be"));
            ttTransferringDate = (ITTDateTimePicker)AddControl(new Guid("2307cfd4-2764-470e-ab20-0797806f1643"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("6e332908-0733-45c3-99b9-13308b1e60a3"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("ba423933-b26c-49e7-a36d-df83362e7847"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("89513ecc-0550-408f-b016-32cbfaa86578"));
            ttTxTEDoganCocukSayisi = (ITTTextBox)AddControl(new Guid("e1689b20-3c98-4377-b114-d22eebd60df6"));
            ttTXTECanliDoganSayisi = (ITTTextBox)AddControl(new Guid("c61ce814-22b9-44be-9aa0-489f8980f54f"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("01837f95-5338-4db2-97dd-d63711d0087e"));
            ttEBabyBirthDate = (ITTDateTimePicker)AddControl(new Guid("3d86a330-5470-442a-ba67-6c9fd4b0a3c5"));
            tttabRaporlar = (ITTTabPage)AddControl(new Guid("d9a8a12e-bd44-4702-a6f4-0a6854e56a02"));
            gridRaporlar = (ITTGrid)AddControl(new Guid("29ff0926-d5d7-4ff0-821e-ef25e0007f52"));
            raporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("93bde02b-13cb-4742-a62a-5d0aa64d86d5"));
            raporNo = (ITTTextBoxColumn)AddControl(new Guid("084e568b-056e-4d01-8715-6920dc009bc1"));
            raporSiraNo = (ITTTextBoxColumn)AddControl(new Guid("bd54f26f-3b1d-4491-802d-797213afbd75"));
            raporSonucKodu = (ITTTextBoxColumn)AddControl(new Guid("ba0475d6-a8af-4727-8253-30fedbae6a6c"));
            raporSonucAciklama = (ITTTextBoxColumn)AddControl(new Guid("75444ca1-5486-4a18-bd10-73be61558f96"));
            raporBaslangicTarihi = (ITTTextBoxColumn)AddControl(new Guid("a9003ded-1d8f-471b-a579-30d0092d1d84"));
            raporBitisTarihi = (ITTTextBoxColumn)AddControl(new Guid("2372e8dd-ccee-46d1-960f-8d468ed694cd"));
            raporSil = (ITTButtonColumn)AddControl(new Guid("51483d33-6ea0-4b94-9775-a752484803c1"));
            raporExcuse = (ITTTextBoxColumn)AddControl(new Guid("d375f896-16fd-4331-9011-f96ec7891759"));
            objectID = (ITTTextBoxColumn)AddControl(new Guid("f380bd49-13d2-4d32-8dac-2b4ca4e56eef"));
            raporSec = (ITTButtonColumn)AddControl(new Guid("4fb12c7b-f25c-40a7-be95-31c45cf5227f"));
            PoliclinicSequenceNo = (ITTTextBox)AddControl(new Guid("1f36e9cc-693f-47d8-9aa0-11204d8748de"));
            FirstOrSecondTenDays = (ITTEnumComboBox)AddControl(new Guid("2a0afe23-e99c-4c5b-8dbe-b9bd3b3bce1e"));
            labelPoliclinicSequenceNo = (ITTLabel)AddControl(new Guid("e22b806e-5918-49cc-877c-b3c44f4b6743"));
            labelVdate = (ITTLabel)AddControl(new Guid("335c657a-700b-49ac-a8ed-dd6aa4563929"));
            labelFirstOrSecondTenDays = (ITTLabel)AddControl(new Guid("da49f4a8-b183-4070-9472-de33288481fd"));
            labelExcuse = (ITTLabel)AddControl(new Guid("72c6b3a6-d8b4-405e-beab-9e62bca2eae2"));
            Excuse = (ITTEnumComboBox)AddControl(new Guid("d5b845ce-32bc-422f-a608-41ea544ff9c6"));
            labelDiagnosis = (ITTLabel)AddControl(new Guid("cda07030-bfe4-4b9e-9430-38341daa21df"));
            ResStartDate = (ITTDateTimePicker)AddControl(new Guid("d4aa9044-71ec-422a-804a-72171ed2a912"));
            ResEndDate = (ITTDateTimePicker)AddControl(new Guid("49a10ff2-b5af-4ffb-9d7d-ad963f443834"));
            labelResStartDate = (ITTLabel)AddControl(new Guid("8fa613b0-ab1a-459a-a6e7-dcc0c42a1b08"));
            labelResEndDate = (ITTLabel)AddControl(new Guid("2a6d6139-62d2-4613-aa93-bf4eeb2325e3"));
            labelSituationDate = (ITTLabel)AddControl(new Guid("5c4f69aa-044a-4fde-8d64-69300168af64"));
            labelSituation = (ITTLabel)AddControl(new Guid("3a6f0e8c-226a-49d0-8292-d8da87191b27"));
            Situation = (ITTEnumComboBox)AddControl(new Guid("126b4925-4859-470a-b6cb-686bd010c675"));
            SituationDate = (ITTDateTimePicker)AddControl(new Guid("273e41ef-a420-4cec-8173-71ac1eb65722"));
            labelAbsence = (ITTLabel)AddControl(new Guid("5ff191d0-0ce4-4594-a6b6-32e773ddeaa1"));
            AbsenceStartDate = (ITTDateTimePicker)AddControl(new Guid("bdec53a8-9d42-45a1-91f1-f03b93774135"));
            AbsenceEndDate = (ITTDateTimePicker)AddControl(new Guid("6c9ad259-8ec7-44e0-a0f5-a8bc08270396"));
            DischargeDate = (ITTDateTimePicker)AddControl(new Guid("b965cc63-1667-4f56-97ca-ef5c7f9531d3"));
            lblTaburcuTarihi = (ITTLabel)AddControl(new Guid("4e08ce8a-5b3e-4495-953f-f887937b567d"));
            ProtocolDate = (ITTDateTimePicker)AddControl(new Guid("ff6e961a-981c-4ae0-b9ed-b5b71a237661"));
            labelProtocolDate = (ITTLabel)AddControl(new Guid("973cc05a-9e9a-40d0-b0fb-21a2bae7fe99"));
            ListDiagnosisDefinition = (ITTObjectListBox)AddControl(new Guid("ebc40bcf-af5f-4113-9792-63f12361871c"));
            base.InitializeControls();
        }

        public UnavailableToWorkReportForm() : base("UNAVAILABLETOWORKREPORT", "UnavailableToWorkReportForm")
        {
        }

        protected UnavailableToWorkReportForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}