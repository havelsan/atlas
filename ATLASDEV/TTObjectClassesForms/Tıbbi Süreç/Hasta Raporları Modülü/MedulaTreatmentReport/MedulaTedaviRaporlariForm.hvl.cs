
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
    /// Medula Tedavi Raporları
    /// </summary>
    public partial class MedulaTedaviRaporlari : TTForm
    {
    /// <summary>
    /// Medula Tedavi Raporları
    /// </summary>
        protected TTObjectClasses.MedulaTreatmentReport _MedulaTreatmentReport
        {
            get { return (TTObjectClasses.MedulaTreatmentReport)_ttObject; }
        }

        protected ITTTextBox tttextbox2;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel15;
        protected ITTLabel ttlabel3;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabAramaIslemleri;
        protected ITTTabControl tttabRaporlar;
        protected ITTTabPage tttabFtrRaporlari;
        protected ITTGrid gridFtrRaporlari;
        protected ITTTextBoxColumn raporTakipNo;
        protected ITTTextBoxColumn raporNumarasi;
        protected ITTTextBoxColumn raporSiraNo;
        protected ITTTextBoxColumn raporVucutBolgesi;
        protected ITTTextBoxColumn kur;
        protected ITTTextBoxColumn raporGonderimTarihi;
        protected ITTButtonColumn raporSil;
        protected ITTTextBoxColumn raporTesisi;
        protected ITTTabPage tttabTumRaporlar;
        protected ITTRichTextBoxControl txtResult;
        protected ITTTabPage tttabEswlRaporlari;
        protected ITTGrid gridEswlRaporlari;
        protected ITTTextBoxColumn raporTakipNoEswl;
        protected ITTTextBoxColumn raporNumarasiEswl;
        protected ITTTextBoxColumn raporSiraNoEswl;
        protected ITTTextBoxColumn raporGonderimTarihiEswl;
        protected ITTTextBoxColumn sonucKoduEswl;
        protected ITTTextBoxColumn sonucMesajiEswl;
        protected ITTButtonColumn raporSilEswl;
        protected ITTTextBoxColumn raporTesisiEswl;
        protected ITTTabPage tttabDiyalizRaporlari;
        protected ITTGrid gridDiyalizRaporlari;
        protected ITTTextBoxColumn raporTakipNoDiyaliz;
        protected ITTTextBoxColumn raporNumarasiDiyaliz;
        protected ITTTextBoxColumn raporSiraNoDiyaliz;
        protected ITTTextBoxColumn raporGonderimTarihiDiyaliz;
        protected ITTTextBoxColumn sonucKoduDiyaliz;
        protected ITTTextBoxColumn sonucMesajiDiyaliz;
        protected ITTButtonColumn raporSilDiyaliz;
        protected ITTTextBoxColumn raporTesisiDiyaliz;
        protected ITTTabPage tttabEvHemodiyalizRaporlari;
        protected ITTGrid gridEvHemodiyalizRaporlari;
        protected ITTTextBoxColumn raporTakipNoEvHemodiyaliz;
        protected ITTTextBoxColumn raporNumarasiEvHemodiyaliz;
        protected ITTTextBoxColumn raporSiraNoEvHemodiyaliz;
        protected ITTTextBoxColumn raporGonderimTarihiEvHemodiyaliz;
        protected ITTTextBoxColumn sonucKoduEvHemodiyaliz;
        protected ITTTextBoxColumn sonucMesajiEvHemodiyaliz;
        protected ITTButtonColumn raporSilEvHemodiyaliz;
        protected ITTTextBoxColumn raporTesisiEvHemodiyaliz;
        protected ITTGrid gridEvdiyalizRaporlari;
        protected ITTTabPage tttabTupBebekRaporlari;
        protected ITTGrid gridTupBebekRaporlari;
        protected ITTTextBoxColumn raporTakipNoTupBebek;
        protected ITTTextBoxColumn raporNumarasiTupBebek;
        protected ITTTextBoxColumn raporSiraNoTupBebek;
        protected ITTTextBoxColumn raporGonderimTarihiTupBebek;
        protected ITTTextBoxColumn sonucKoduTupBebek;
        protected ITTTextBoxColumn sonucMesajiTupBebek;
        protected ITTButtonColumn raporSilTupBebek;
        protected ITTTextBoxColumn raporTesisiTupBebek;
        protected ITTTabPage tttabHOTRaporlari;
        protected ITTGrid gridHOTRaporlari;
        protected ITTTextBoxColumn raporTakipNoHOT;
        protected ITTTextBoxColumn raporNumarasiHOT;
        protected ITTTextBoxColumn raporSiraNoHOT;
        protected ITTTextBoxColumn raporGonderimTarihiHOT;
        protected ITTTextBoxColumn sonucKoduHOT;
        protected ITTTextBoxColumn sonucMesajiHOT;
        protected ITTButtonColumn raporSilHOT;
        protected ITTTextBoxColumn raporTesisiHOT;
        protected ITTTabControl tttabSearchBenchMarks;
        protected ITTTabPage tttabReportSave;
        protected ITTTabControl tttabTedaviRaporlariKaydet;
        protected ITTTabPage tttabFtrRaporKaydet;
        protected ITTLabel lblOzelDurum;
        protected ITTEnumComboBox cmbOzelDurum;
        protected ITTCheckBox chkOzelDurum;
        protected ITTButton btnFtrIstek;
        protected ITTGrid gridFizyoTerapiIslemleri;
        protected ITTListBoxColumn FizyoterapiIslemi;
        protected ITTListBoxColumn VucutBolgesi;
        protected ITTTextBoxColumn SeansSayisi;
        protected ITTListBoxColumn TedaviTuru;
        protected ITTTabPage tttabESWTRaporKaydet;
        protected ITTGrid gridEswtIslemi;
        protected ITTListBoxColumn FizyoterapiIslemiESWT;
        protected ITTListBoxColumn VucutBolgesiESWT;
        protected ITTTextBoxColumn SeansSayisiESWT;
        protected ITTTabPage tttabESWLRaporKaydet;
        protected ITTObjectListBox lstBobrekBilgisi;
        protected ITTLabel lblBobrekBilgisi;
        protected ITTTextBox txtEswlSeansSayisi;
        protected ITTLabel lblEswlSeansSayisi;
        protected ITTTextBox txtTasSayisi;
        protected ITTLabel lblTasSayisi;
        protected ITTObjectListBox lstEswlRaporKodu;
        protected ITTGrid gridTasBilgisi;
        protected ITTListBoxColumn Lokalizasyon2;
        protected ITTTextBoxColumn TasBoyutu2;
        protected ITTLabel lblEswlRaporKodu;
        protected ITTTabPage tttabDiyalizRaporKaydet;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox cmbDiyalizSeansGun;
        protected ITTLabel lblDiyalizSeansSayisi;
        protected ITTTextBox txtDiyalizSeansSayisi;
        protected ITTLabel lblDiyalizRaporKodu;
        protected ITTObjectListBox lstDiyalizRaporKodu;
        protected ITTCheckBox chkRefakatVarYok;
        protected ITTTabPage tttabEvHemoDiyalizRaporKaydet;
        protected ITTLabel ttlabel14;
        protected ITTEnumComboBox cmbEvHemodiyalizSeansGun;
        protected ITTTextBox txtEvHemodiyalizTedaviSuresi;
        protected ITTLabel lblEvHemodiyalizTedaviSuresi;
        protected ITTTextBox txtEvHemodiyalizSeansSayisi;
        protected ITTLabel lblEvHemodiyalizSeansSayisi;
        protected ITTLabel lblEvHemodiyalizRaporKodu;
        protected ITTObjectListBox lstEvHemodiyalizRaporKodu;
        protected ITTTabPage tttabHOTRaporKaydet;
        protected ITTTextBox txtHOTTedaviSuresi;
        protected ITTLabel lblHOTTedaviSuresi;
        protected ITTTextBox txtHOTSeansSayisi;
        protected ITTLabel lblHOTSeansSayisi;
        protected ITTTabPage tttabTupBebekRaporKaydet;
        protected ITTEnumComboBox cmbTupBebekTuru;
        protected ITTLabel lblTupBebekTuru;
        protected ITTObjectListBox lstTupBebekRaporKodu;
        protected ITTLabel lblTupBebekRaporKodu;
        protected ITTGrid gridTani;
        protected ITTListBoxColumn lstTani;
        protected ITTTextBoxColumn FTRTaniGrubu;
        protected ITTLabel lblRaporTakipNo;
        protected ITTTextBox txtRaporTakipNo;
        protected ITTButton btnRaporKaydet;
        protected ITTTabPage tttabSearchTCKNo;
        protected ITTLabel ttlabel7;
        protected ITTEnumComboBox cmbReportType;
        protected ITTButton btnSearchTCKNo;
        protected ITTTabPage tttabSearchChasing;
        protected ITTTextBox txtReportChasing;
        protected ITTTextBox txtReportRow;
        protected ITTButton btnSearchChasing;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel8;
        protected ITTTabPage tttabSearchReportInfo;
        protected ITTButton btnSearchReportInfo;
        protected ITTEnumComboBox cmbRBReportType;
        protected ITTDateTimePicker dtReportDate;
        protected ITTTextBox txtRBReportChasing;
        protected ITTTextBox txtRBReportRow;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel12;
        protected ITTLabel ttlabel11;
        protected ITTLabel ttlabel10;
        protected ITTPanel pnlSearchResult;
        protected ITTGroupBox ttgroupbox3;
        protected ITTCheckBox chkFtrHeyetRaporu;
        protected ITTObjectListBox lstTabip3;
        protected ITTLabel lblTabip3;
        protected ITTLabel lblTabip2;
        protected ITTObjectListBox lstTabip2;
        protected ITTButton btnRaporArama;
        protected ITTGrid gridHastaAktifTumTakipler;
        protected ITTTextBoxColumn txtTakipNo2;
        protected ITTTextBoxColumn txtBrans2;
        protected ITTTextBoxColumn txtProvizyonTarihi2;
        protected ITTTextBoxColumn txtBagliTakipNo2;
        protected ITTTextBoxColumn txtXXXXXXProtocolNo2;
        protected ITTTextBoxColumn txtVakaAcilisTarihi2;
        protected ITTTextBoxColumn txtBransKodu2;
        protected ITTTextBoxColumn txtTedaviTuru2;
        protected ITTLabel lblRaporBitisTarihi;
        protected ITTLabel lblTabip;
        protected ITTLabel lblRaporBaslangicTarihi;
        protected ITTDateTimePicker RaporBitisTarihi;
        protected ITTObjectListBox lstTabip;
        protected ITTDateTimePicker RaporBaslangicTarihi;
        protected ITTLabel lblRapotTuru;
        protected ITTEnumComboBox cmbRaporTuru;
        protected ITTGrid gridHastaAktifTakipleri;
        protected ITTTextBoxColumn txtTakipNo1;
        protected ITTTextBoxColumn txtBrans1;
        protected ITTTextBoxColumn txtProvizyonTarihi1;
        protected ITTTextBoxColumn txtBagliTakipNo1;
        protected ITTTextBoxColumn txtXXXXXXProtocolNo1;
        protected ITTTextBoxColumn txtVakaAcilisTarihi1;
        protected ITTTextBoxColumn txtBransKodu1;
        protected ITTTextBoxColumn txtTedaviTuru1;
        protected ITTGroupBox ttgroupbox2;
        protected ITTCheckBox chkRaporKaydet;
        protected ITTCheckBox chkSearchReportInfo;
        protected ITTCheckBox chkSearchChasing;
        protected ITTCheckBox chkSearchTCKNo;
        protected ITTGroupBox ttgroupbox1;
        protected ITTTextBox txtSex;
        protected ITTTextBox txtName;
        protected ITTTextBox txtSurname;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel4;
        protected ITTTextBox txtTCKNo;
        protected ITTTextBox txtBirthDate;
        protected ITTLabel lblKimlikNo;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel5;
        protected ITTButton cmdSearchPatient;
        override protected void InitializeControls()
        {
            tttextbox2 = (ITTTextBox)AddControl(new Guid("54a95620-fff9-4e08-a7c7-72dd6555814d"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("0b92a7f5-7c7d-46c7-ae8e-8dcb55a34fda"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("10ba7b6b-415e-41a1-8b05-d63732cee8a0"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("da1efdfa-d59e-4eee-bfb6-434896a10d02"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("66d283c3-0bdd-474d-b483-5dc3e49cb791"));
            tttabAramaIslemleri = (ITTTabPage)AddControl(new Guid("93d7f05e-c38b-4c70-8469-dc982d68f32a"));
            tttabRaporlar = (ITTTabControl)AddControl(new Guid("f4cd1e93-5729-48a9-9e2d-e883ad517503"));
            tttabFtrRaporlari = (ITTTabPage)AddControl(new Guid("447976bf-2eba-4c42-ab4c-09b5492737f4"));
            gridFtrRaporlari = (ITTGrid)AddControl(new Guid("5ae4de1e-0185-4783-9b41-45c140ef3901"));
            raporTakipNo = (ITTTextBoxColumn)AddControl(new Guid("c3e17c8a-a611-4acd-bbf3-aabc52b9e7d6"));
            raporNumarasi = (ITTTextBoxColumn)AddControl(new Guid("3e0d70e7-de45-4007-bebf-7e01132e7612"));
            raporSiraNo = (ITTTextBoxColumn)AddControl(new Guid("0775f7bc-3219-49ad-9964-4be58d474c23"));
            raporVucutBolgesi = (ITTTextBoxColumn)AddControl(new Guid("0d47f46e-b675-4d88-b22f-8c2fca16d5ad"));
            kur = (ITTTextBoxColumn)AddControl(new Guid("edf83980-d4d3-40e7-acfc-be2100ff2651"));
            raporGonderimTarihi = (ITTTextBoxColumn)AddControl(new Guid("579c1594-c744-4330-ad94-ffcc8fadcf5d"));
            raporSil = (ITTButtonColumn)AddControl(new Guid("d0783096-2201-4c7f-b289-d73b625650c2"));
            raporTesisi = (ITTTextBoxColumn)AddControl(new Guid("da6922dd-e453-4c53-987a-f2771b1c954c"));
            tttabTumRaporlar = (ITTTabPage)AddControl(new Guid("771f55ba-66c5-4846-9edf-415bb9501e47"));
            txtResult = (ITTRichTextBoxControl)AddControl(new Guid("9a2efec3-0478-40bc-935e-732a07cc63e5"));
            tttabEswlRaporlari = (ITTTabPage)AddControl(new Guid("6728d297-657d-46e3-88ff-65a83ac36f7c"));
            gridEswlRaporlari = (ITTGrid)AddControl(new Guid("da1a6e91-126e-424e-bed0-b004ca23c3cc"));
            raporTakipNoEswl = (ITTTextBoxColumn)AddControl(new Guid("2e9e39be-627d-4311-9fe8-16cdae161bc9"));
            raporNumarasiEswl = (ITTTextBoxColumn)AddControl(new Guid("8b242c3a-93df-4e3f-808c-44a2a30d63d8"));
            raporSiraNoEswl = (ITTTextBoxColumn)AddControl(new Guid("05377a08-77ff-4e66-a7b3-cad7462f16f0"));
            raporGonderimTarihiEswl = (ITTTextBoxColumn)AddControl(new Guid("23531dd9-c6b8-42f4-9edb-ef48f05d0320"));
            sonucKoduEswl = (ITTTextBoxColumn)AddControl(new Guid("23dec763-59ae-4d9b-aa39-4f3e6e98ed1c"));
            sonucMesajiEswl = (ITTTextBoxColumn)AddControl(new Guid("45b69290-f695-40f5-a5e3-fc607e67615e"));
            raporSilEswl = (ITTButtonColumn)AddControl(new Guid("a01a0327-3608-444b-a763-b92fe66618e0"));
            raporTesisiEswl = (ITTTextBoxColumn)AddControl(new Guid("86fe6480-72ec-4f91-b534-0c48d580c228"));
            tttabDiyalizRaporlari = (ITTTabPage)AddControl(new Guid("00ea4fa4-f9d9-411e-b4d9-56074caa17dc"));
            gridDiyalizRaporlari = (ITTGrid)AddControl(new Guid("851eb37e-9e44-4db0-884a-b00221ee66d4"));
            raporTakipNoDiyaliz = (ITTTextBoxColumn)AddControl(new Guid("2c93731e-77f2-45e2-bec5-ed351fa302e5"));
            raporNumarasiDiyaliz = (ITTTextBoxColumn)AddControl(new Guid("e4b900c6-7a73-4ad0-aa29-84ea2dc538e4"));
            raporSiraNoDiyaliz = (ITTTextBoxColumn)AddControl(new Guid("76b60a63-9aaa-4ad1-8579-6d84e50e6b06"));
            raporGonderimTarihiDiyaliz = (ITTTextBoxColumn)AddControl(new Guid("989491f3-1c9b-4a8b-8920-3f5e47120a1b"));
            sonucKoduDiyaliz = (ITTTextBoxColumn)AddControl(new Guid("7c53f222-ba37-496a-99b4-5aaac4b75bd2"));
            sonucMesajiDiyaliz = (ITTTextBoxColumn)AddControl(new Guid("0849516e-82b1-4ec9-8fa3-2f2ca52f3d5b"));
            raporSilDiyaliz = (ITTButtonColumn)AddControl(new Guid("871e4d49-5b75-481f-8364-2c0f21786627"));
            raporTesisiDiyaliz = (ITTTextBoxColumn)AddControl(new Guid("288f9978-8807-44f3-97f6-9e549c9775cb"));
            tttabEvHemodiyalizRaporlari = (ITTTabPage)AddControl(new Guid("427d27bd-b55f-4811-8969-e7a8836d9b18"));
            gridEvHemodiyalizRaporlari = (ITTGrid)AddControl(new Guid("923976f3-ec5a-4fc5-ae86-dd9b180b6cdf"));
            raporTakipNoEvHemodiyaliz = (ITTTextBoxColumn)AddControl(new Guid("5c13a93c-062b-4a51-8a29-8c40359fb513"));
            raporNumarasiEvHemodiyaliz = (ITTTextBoxColumn)AddControl(new Guid("63165ae0-0072-4ac0-905f-ba34e627f906"));
            raporSiraNoEvHemodiyaliz = (ITTTextBoxColumn)AddControl(new Guid("2ae30f33-3490-4373-ba62-427365919f1a"));
            raporGonderimTarihiEvHemodiyaliz = (ITTTextBoxColumn)AddControl(new Guid("499b1945-bd58-4ab5-aa57-3b9c7d20dc3f"));
            sonucKoduEvHemodiyaliz = (ITTTextBoxColumn)AddControl(new Guid("a6609550-6030-40f3-8ef1-4519356c2e98"));
            sonucMesajiEvHemodiyaliz = (ITTTextBoxColumn)AddControl(new Guid("b8ef5969-1767-4efb-b911-6251eaccf184"));
            raporSilEvHemodiyaliz = (ITTButtonColumn)AddControl(new Guid("d31ec05f-9b91-4cbf-bd33-76aa648de0a0"));
            raporTesisiEvHemodiyaliz = (ITTTextBoxColumn)AddControl(new Guid("0703581d-94f0-44a8-b762-d8ccaa99b222"));
            gridEvdiyalizRaporlari = (ITTGrid)AddControl(new Guid("0f1afb62-a187-4b84-a580-0db05414170f"));
            tttabTupBebekRaporlari = (ITTTabPage)AddControl(new Guid("e0176ec2-713b-4110-bdfd-98e887c511b6"));
            gridTupBebekRaporlari = (ITTGrid)AddControl(new Guid("1b58fe28-2f2d-4662-8b27-fd2776b5b853"));
            raporTakipNoTupBebek = (ITTTextBoxColumn)AddControl(new Guid("5dbc4ca0-11c0-4667-a419-eea4ef099e50"));
            raporNumarasiTupBebek = (ITTTextBoxColumn)AddControl(new Guid("a001bbfc-a917-4ce3-a05e-5384a4c5e9b3"));
            raporSiraNoTupBebek = (ITTTextBoxColumn)AddControl(new Guid("9ccaa637-2bda-4057-8315-a9e4d7b43cfa"));
            raporGonderimTarihiTupBebek = (ITTTextBoxColumn)AddControl(new Guid("3ecc3225-7832-4f7d-82c6-a373b76c3327"));
            sonucKoduTupBebek = (ITTTextBoxColumn)AddControl(new Guid("c870e453-6499-4c3b-9b7f-54cf63efa54a"));
            sonucMesajiTupBebek = (ITTTextBoxColumn)AddControl(new Guid("352aba69-fdc4-4063-a293-366fa3a96e8a"));
            raporSilTupBebek = (ITTButtonColumn)AddControl(new Guid("e96449d3-eefd-428a-b240-a1112c402d38"));
            raporTesisiTupBebek = (ITTTextBoxColumn)AddControl(new Guid("1b4f9208-212d-4462-a0f9-458cf1359a49"));
            tttabHOTRaporlari = (ITTTabPage)AddControl(new Guid("8bda103d-6317-4a2e-ac3c-87397cbec2e3"));
            gridHOTRaporlari = (ITTGrid)AddControl(new Guid("04faab67-cd4d-4795-9409-9af8b4e902ab"));
            raporTakipNoHOT = (ITTTextBoxColumn)AddControl(new Guid("b555be2a-11fc-4c45-af4f-749adf334197"));
            raporNumarasiHOT = (ITTTextBoxColumn)AddControl(new Guid("688498e9-0ece-4ccb-9c51-a63afd203b73"));
            raporSiraNoHOT = (ITTTextBoxColumn)AddControl(new Guid("3ce75e94-9793-4f30-85c0-151fa4466222"));
            raporGonderimTarihiHOT = (ITTTextBoxColumn)AddControl(new Guid("37e27b87-3f96-4e1b-ba4b-1457ba618c7d"));
            sonucKoduHOT = (ITTTextBoxColumn)AddControl(new Guid("804d79d8-0392-4a75-aa1c-e53527a565ed"));
            sonucMesajiHOT = (ITTTextBoxColumn)AddControl(new Guid("ce945745-b50f-420d-85f1-b4d24289151b"));
            raporSilHOT = (ITTButtonColumn)AddControl(new Guid("788b3262-fb85-445f-b9bb-ea0d3ebe4d87"));
            raporTesisiHOT = (ITTTextBoxColumn)AddControl(new Guid("e37a72eb-25c0-4b1a-bfd5-6945221499d5"));
            tttabSearchBenchMarks = (ITTTabControl)AddControl(new Guid("b6466244-de4b-4f23-abe1-40ba2aed5aab"));
            tttabReportSave = (ITTTabPage)AddControl(new Guid("024f1145-ebdf-4239-b325-295027f8a542"));
            tttabTedaviRaporlariKaydet = (ITTTabControl)AddControl(new Guid("c38d6527-4da2-4464-8c69-20283c7bfa38"));
            tttabFtrRaporKaydet = (ITTTabPage)AddControl(new Guid("a41017c9-0635-4ac9-b9c5-fd2c29d2705d"));
            lblOzelDurum = (ITTLabel)AddControl(new Guid("c3dea1e4-871b-4ee0-8fe1-db9e3733267d"));
            cmbOzelDurum = (ITTEnumComboBox)AddControl(new Guid("87365ced-1def-4f16-b50f-0c56ed6f339a"));
            chkOzelDurum = (ITTCheckBox)AddControl(new Guid("92332bb1-f160-44d7-a1dd-5584ec95d492"));
            btnFtrIstek = (ITTButton)AddControl(new Guid("db27d5c0-d326-4dee-b990-e1e4e14b81d9"));
            gridFizyoTerapiIslemleri = (ITTGrid)AddControl(new Guid("95ce3c61-39a6-43db-a073-08a219341cee"));
            FizyoterapiIslemi = (ITTListBoxColumn)AddControl(new Guid("1666b733-b9d3-4643-bbc7-aa353db1a899"));
            VucutBolgesi = (ITTListBoxColumn)AddControl(new Guid("c625fa92-45f5-4041-a5d4-e1a667575758"));
            SeansSayisi = (ITTTextBoxColumn)AddControl(new Guid("f48ba75a-9af8-44af-aafb-a7b3a66dcf24"));
            TedaviTuru = (ITTListBoxColumn)AddControl(new Guid("92d417a8-12b1-4f4b-983f-42f8270d961d"));
            tttabESWTRaporKaydet = (ITTTabPage)AddControl(new Guid("2671694e-851c-4d7e-a4ab-5b2641144a02"));
            gridEswtIslemi = (ITTGrid)AddControl(new Guid("6d82d8cf-b629-4699-8d05-cece9b654b90"));
            FizyoterapiIslemiESWT = (ITTListBoxColumn)AddControl(new Guid("2ecb941c-89f9-4ce7-a943-712355dbbd18"));
            VucutBolgesiESWT = (ITTListBoxColumn)AddControl(new Guid("d5030f73-b6cd-42b3-94c9-0357201c3fea"));
            SeansSayisiESWT = (ITTTextBoxColumn)AddControl(new Guid("7c40c9c9-3ee5-4b02-9822-f63e195d4636"));
            tttabESWLRaporKaydet = (ITTTabPage)AddControl(new Guid("a498e806-fa0b-4a98-bcb1-539413489090"));
            lstBobrekBilgisi = (ITTObjectListBox)AddControl(new Guid("df72be08-47e8-457e-adfb-73857bf9cf9b"));
            lblBobrekBilgisi = (ITTLabel)AddControl(new Guid("a4ca9562-1dda-4051-9dd2-60a7717b44b7"));
            txtEswlSeansSayisi = (ITTTextBox)AddControl(new Guid("df70956f-42ac-47f2-ae9f-8779c4356565"));
            lblEswlSeansSayisi = (ITTLabel)AddControl(new Guid("81d6be94-6392-46a4-8e9a-2204d4c5453f"));
            txtTasSayisi = (ITTTextBox)AddControl(new Guid("376b7a59-806a-4a8e-9a13-87119d28cc4f"));
            lblTasSayisi = (ITTLabel)AddControl(new Guid("adea9b66-9595-4254-bddb-7f6f5a74f197"));
            lstEswlRaporKodu = (ITTObjectListBox)AddControl(new Guid("5f585380-534b-47a0-a1a0-fde0a303d36a"));
            gridTasBilgisi = (ITTGrid)AddControl(new Guid("285d80ba-3649-4d04-8d32-539a48d8a370"));
            Lokalizasyon2 = (ITTListBoxColumn)AddControl(new Guid("36fc4778-8cb2-40e8-b901-6c2fb096e370"));
            TasBoyutu2 = (ITTTextBoxColumn)AddControl(new Guid("e26e84ba-84aa-40f2-bcf3-1e9b6a49b30e"));
            lblEswlRaporKodu = (ITTLabel)AddControl(new Guid("8d572540-c89e-427b-acb2-976c173c3ab5"));
            tttabDiyalizRaporKaydet = (ITTTabPage)AddControl(new Guid("c1104c2e-6845-4a5c-ac36-b289b6f02dc2"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("31ec8953-5f67-4353-90f1-c66e10c5547b"));
            cmbDiyalizSeansGun = (ITTEnumComboBox)AddControl(new Guid("8b259cf7-3343-41b5-b1b6-e01a7dafff1f"));
            lblDiyalizSeansSayisi = (ITTLabel)AddControl(new Guid("9b9f8628-9bf5-45e2-a285-af5cf9b3632d"));
            txtDiyalizSeansSayisi = (ITTTextBox)AddControl(new Guid("9f2c3b11-117d-42b7-8a69-85c2788e71fd"));
            lblDiyalizRaporKodu = (ITTLabel)AddControl(new Guid("f6ac7517-9087-48bd-a32e-7c2736193db9"));
            lstDiyalizRaporKodu = (ITTObjectListBox)AddControl(new Guid("04ed24d1-e37d-42fe-b01e-b46c7541657e"));
            chkRefakatVarYok = (ITTCheckBox)AddControl(new Guid("607840f6-5ede-415f-9572-e1d8cccf78a6"));
            tttabEvHemoDiyalizRaporKaydet = (ITTTabPage)AddControl(new Guid("cc08c5d8-0798-497d-8822-5496166b986d"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("fdde571a-b36e-4263-abc4-c51833aec606"));
            cmbEvHemodiyalizSeansGun = (ITTEnumComboBox)AddControl(new Guid("217133c6-d4cb-47cc-b94b-dfb4048ba448"));
            txtEvHemodiyalizTedaviSuresi = (ITTTextBox)AddControl(new Guid("6b80b92d-d2e9-4267-97c8-22638be36af1"));
            lblEvHemodiyalizTedaviSuresi = (ITTLabel)AddControl(new Guid("678b4878-70bf-4807-a50c-6341aa25354e"));
            txtEvHemodiyalizSeansSayisi = (ITTTextBox)AddControl(new Guid("09573ed4-685e-46ab-817e-ab77a96dd48d"));
            lblEvHemodiyalizSeansSayisi = (ITTLabel)AddControl(new Guid("c37b8690-3a34-40a8-ba37-d949487c6fc6"));
            lblEvHemodiyalizRaporKodu = (ITTLabel)AddControl(new Guid("2d558f0e-16c0-4c4c-a2a4-6bbcae15ada3"));
            lstEvHemodiyalizRaporKodu = (ITTObjectListBox)AddControl(new Guid("b9c0f3d6-2103-4d9e-954c-263b5caf511e"));
            tttabHOTRaporKaydet = (ITTTabPage)AddControl(new Guid("3591d348-74f2-4f40-8a8d-2ddfcd422b13"));
            txtHOTTedaviSuresi = (ITTTextBox)AddControl(new Guid("e57a4431-f3d5-42e0-bcb9-316ed804ab0d"));
            lblHOTTedaviSuresi = (ITTLabel)AddControl(new Guid("3c30d63b-ef74-49c8-aa29-adfd8b038564"));
            txtHOTSeansSayisi = (ITTTextBox)AddControl(new Guid("9353eca0-f52f-4530-a595-2ded2de53f4d"));
            lblHOTSeansSayisi = (ITTLabel)AddControl(new Guid("1f71a8e4-1228-4547-b84d-f5ec60c93474"));
            tttabTupBebekRaporKaydet = (ITTTabPage)AddControl(new Guid("9e609540-7b5f-4356-a2e0-6c09ab4fb1ab"));
            cmbTupBebekTuru = (ITTEnumComboBox)AddControl(new Guid("6d69e059-50c6-4c67-a466-5880f423dce2"));
            lblTupBebekTuru = (ITTLabel)AddControl(new Guid("20632975-3176-4f92-8342-207ccc6b9e89"));
            lstTupBebekRaporKodu = (ITTObjectListBox)AddControl(new Guid("d6fa9109-cb59-4618-827d-1e2c22ec3319"));
            lblTupBebekRaporKodu = (ITTLabel)AddControl(new Guid("bf2f0bbc-a7bf-477a-ae60-2e172298f78a"));
            gridTani = (ITTGrid)AddControl(new Guid("461f8192-56ea-4bb1-9cf3-176350ee2f94"));
            lstTani = (ITTListBoxColumn)AddControl(new Guid("c0864511-78ed-41bb-a687-f0a98719f2e6"));
            FTRTaniGrubu = (ITTTextBoxColumn)AddControl(new Guid("6f41ced4-72f2-44f7-b962-94ba7cdd4577"));
            lblRaporTakipNo = (ITTLabel)AddControl(new Guid("bf226cba-1861-4810-bf82-bfe9034f160c"));
            txtRaporTakipNo = (ITTTextBox)AddControl(new Guid("877c9a7c-4738-4624-9de9-425a7ad94be6"));
            btnRaporKaydet = (ITTButton)AddControl(new Guid("dd07d051-a15a-4bcb-9425-98067f3aac43"));
            tttabSearchTCKNo = (ITTTabPage)AddControl(new Guid("d24ffbdc-2e92-44bf-8fbd-248a75129d53"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("337720da-1ae7-4cfb-8aba-a07dcb1122b3"));
            cmbReportType = (ITTEnumComboBox)AddControl(new Guid("d250a7d0-90c4-4e99-ac52-162152596861"));
            btnSearchTCKNo = (ITTButton)AddControl(new Guid("21a64f06-b92b-4328-a21b-b56b2723c27a"));
            tttabSearchChasing = (ITTTabPage)AddControl(new Guid("7adee14e-8cc3-43c9-a9b4-9a047cc30218"));
            txtReportChasing = (ITTTextBox)AddControl(new Guid("55dfbee4-7c32-48a2-a768-803e0666fe2b"));
            txtReportRow = (ITTTextBox)AddControl(new Guid("6b848427-f8c6-4d73-809d-322261ea55ad"));
            btnSearchChasing = (ITTButton)AddControl(new Guid("3c39286f-0d23-49bc-9d99-c2569346632f"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("7f5602e1-baf5-4cbd-92f1-1388b82c1be8"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("1e7ea90a-ccdc-4083-949f-3958ab4ff931"));
            tttabSearchReportInfo = (ITTTabPage)AddControl(new Guid("d0023452-2259-441d-90d3-c7c0b20d2de8"));
            btnSearchReportInfo = (ITTButton)AddControl(new Guid("ab9e33ca-9d11-4ef0-9dd9-49e61f263ce9"));
            cmbRBReportType = (ITTEnumComboBox)AddControl(new Guid("61b52865-bf3f-48c8-9d87-cb7f060ccf57"));
            dtReportDate = (ITTDateTimePicker)AddControl(new Guid("23d5f25a-f849-427f-a04c-56831d593353"));
            txtRBReportChasing = (ITTTextBox)AddControl(new Guid("1c201cf4-3f1a-48b8-b53b-a695f0ea01a2"));
            txtRBReportRow = (ITTTextBox)AddControl(new Guid("2d90fb22-62a5-4a1d-aac3-322614c7b778"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("859535f6-898b-49fb-bd03-7b47674b02a5"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("2fd7ee75-132d-4628-b2e9-695b823b26e6"));
            ttlabel11 = (ITTLabel)AddControl(new Guid("ce75519e-ee0b-46fc-bb11-60cec4d51563"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("c67f3384-e705-4719-9496-dc45b94579aa"));
            pnlSearchResult = (ITTPanel)AddControl(new Guid("a16c4c6d-5baa-402e-b048-2996796d55e4"));
            ttgroupbox3 = (ITTGroupBox)AddControl(new Guid("9d269960-ec49-4498-ab2e-75c6cc3ad923"));
            chkFtrHeyetRaporu = (ITTCheckBox)AddControl(new Guid("64c19a42-f7d6-402a-9363-62e981ecc90a"));
            lstTabip3 = (ITTObjectListBox)AddControl(new Guid("3e7f593b-03f5-484a-94ad-3c213782ff8d"));
            lblTabip3 = (ITTLabel)AddControl(new Guid("ba0bb6c2-4356-48d3-80f6-aa8bc4a646e7"));
            lblTabip2 = (ITTLabel)AddControl(new Guid("5df6dc1f-5191-4514-b616-b91b43f4846a"));
            lstTabip2 = (ITTObjectListBox)AddControl(new Guid("4c87c3db-594f-4c72-816f-f532f4040dbc"));
            btnRaporArama = (ITTButton)AddControl(new Guid("49e6ac14-6e03-49d3-89fb-91d0caf7fd44"));
            gridHastaAktifTumTakipler = (ITTGrid)AddControl(new Guid("9efd5102-8d52-4896-81d0-af19103229fd"));
            txtTakipNo2 = (ITTTextBoxColumn)AddControl(new Guid("9bb1f30d-3504-4b1a-829c-55260589094e"));
            txtBrans2 = (ITTTextBoxColumn)AddControl(new Guid("dcc07763-5557-41a1-997b-c27cdaeff28c"));
            txtProvizyonTarihi2 = (ITTTextBoxColumn)AddControl(new Guid("c599f22c-7381-4ca1-b454-719b7592bdf0"));
            txtBagliTakipNo2 = (ITTTextBoxColumn)AddControl(new Guid("90d37d24-8e18-4869-a5e8-97c770916fe8"));
            txtXXXXXXProtocolNo2 = (ITTTextBoxColumn)AddControl(new Guid("f3efb82f-7aa9-4226-9288-a66caca5ddee"));
            txtVakaAcilisTarihi2 = (ITTTextBoxColumn)AddControl(new Guid("42ad2ab2-71ac-46ac-8eef-6edb5bfb9f72"));
            txtBransKodu2 = (ITTTextBoxColumn)AddControl(new Guid("1f96e64e-dc96-4622-8816-a9b0e6bac701"));
            txtTedaviTuru2 = (ITTTextBoxColumn)AddControl(new Guid("cc3a09f6-0c37-4c55-8874-4945ab394571"));
            lblRaporBitisTarihi = (ITTLabel)AddControl(new Guid("df939117-b9bd-4c72-8f8b-c55259c374f1"));
            lblTabip = (ITTLabel)AddControl(new Guid("fbb3f69d-a74b-4930-aaba-4eaf9625334d"));
            lblRaporBaslangicTarihi = (ITTLabel)AddControl(new Guid("3511c9ff-3c20-4688-9a94-f3254780e58b"));
            RaporBitisTarihi = (ITTDateTimePicker)AddControl(new Guid("be4be418-a7d1-4f0d-8a2d-39bb86c3363f"));
            lstTabip = (ITTObjectListBox)AddControl(new Guid("b73bd451-9cc6-4bb4-8a6c-0f14a857312f"));
            RaporBaslangicTarihi = (ITTDateTimePicker)AddControl(new Guid("7e6bbfae-519f-4a89-8098-e41eb382e61d"));
            lblRapotTuru = (ITTLabel)AddControl(new Guid("92fcd159-a074-41f2-a4e5-06afed212fbd"));
            cmbRaporTuru = (ITTEnumComboBox)AddControl(new Guid("d1a7c58a-39a1-4f20-a07a-10dcb5e36b0f"));
            gridHastaAktifTakipleri = (ITTGrid)AddControl(new Guid("182e149f-4b11-4930-a84b-b87263bad56c"));
            txtTakipNo1 = (ITTTextBoxColumn)AddControl(new Guid("92f01226-26a2-4b01-991c-db4ba9c6cf40"));
            txtBrans1 = (ITTTextBoxColumn)AddControl(new Guid("e3a71084-6572-4118-b2b1-bb77111ef5c1"));
            txtProvizyonTarihi1 = (ITTTextBoxColumn)AddControl(new Guid("b94861f9-44c0-46ca-9e78-184b9a6bd310"));
            txtBagliTakipNo1 = (ITTTextBoxColumn)AddControl(new Guid("ac0109e1-7cd2-408e-b572-acbe5ec8d6a1"));
            txtXXXXXXProtocolNo1 = (ITTTextBoxColumn)AddControl(new Guid("b8caa130-74fd-42a5-b23a-233383537b18"));
            txtVakaAcilisTarihi1 = (ITTTextBoxColumn)AddControl(new Guid("564fa393-cac6-4a1e-ad16-44b0795a3249"));
            txtBransKodu1 = (ITTTextBoxColumn)AddControl(new Guid("fedf8f52-3496-42b9-b5b0-e6a314814681"));
            txtTedaviTuru1 = (ITTTextBoxColumn)AddControl(new Guid("c9492cd3-b22e-4ebd-8563-450b822ff0cd"));
            ttgroupbox2 = (ITTGroupBox)AddControl(new Guid("27292c33-9ae2-4646-8578-0af0b63e7cee"));
            chkRaporKaydet = (ITTCheckBox)AddControl(new Guid("bafd186a-d750-4591-a95b-eb88b046f2db"));
            chkSearchReportInfo = (ITTCheckBox)AddControl(new Guid("60c1d2ee-a9e9-4a5e-a17d-414e926bb621"));
            chkSearchChasing = (ITTCheckBox)AddControl(new Guid("047da7b0-eaa8-4c60-b9a4-54b3e47b51c2"));
            chkSearchTCKNo = (ITTCheckBox)AddControl(new Guid("a0c89a5f-d51c-4528-bba1-09c7c12d67a6"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5bae6c75-d38a-49c1-af41-de892a0e68f3"));
            txtSex = (ITTTextBox)AddControl(new Guid("a521953c-37af-4ea9-9276-a3502d8d7105"));
            txtName = (ITTTextBox)AddControl(new Guid("e7324e6a-a8fa-4003-b827-eb21ab88c532"));
            txtSurname = (ITTTextBox)AddControl(new Guid("f4cb863d-69b6-4971-8fdd-5331f1ef2771"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("37f9b975-44e7-4350-a7d0-29acfae64379"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("8766d254-34a7-455d-8f41-0fc94d99c1e2"));
            txtTCKNo = (ITTTextBox)AddControl(new Guid("2abc1a03-080d-4545-b42d-6662c8478a90"));
            txtBirthDate = (ITTTextBox)AddControl(new Guid("7c67e0b6-bf8c-4652-acef-56c561c8b5c6"));
            lblKimlikNo = (ITTLabel)AddControl(new Guid("4b1b26de-507f-4956-91d5-7ff69fb209d8"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8c59acc6-d035-4d18-9be9-7bbe21bc2fe1"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("b0820f41-1e9c-4727-b34d-8c45bc216083"));
            cmdSearchPatient = (ITTButton)AddControl(new Guid("e4b4e379-2594-4773-a5bf-ba9aea20fb15"));
            base.InitializeControls();
        }

        public MedulaTedaviRaporlari() : base("MEDULATREATMENTREPORT", "MedulaTedaviRaporlari")
        {
        }

        protected MedulaTedaviRaporlari(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}