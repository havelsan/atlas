
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
    /// XXXXXXler Arası Sevk 
    /// </summary>
    public partial class DispatchToOtherHospitalForm : EpisodeActionForm
    {
    /// <summary>
    /// XXXXXXler Arası Sevk 
    /// </summary>
        protected TTObjectClasses.DispatchToOtherHospital _DispatchToOtherHospital
        {
            get { return (TTObjectClasses.DispatchToOtherHospital)_ttObject; }
        }

        protected ITTTabControl DispatchTabControl;
        protected ITTTabPage DispatchTabPage;
        protected ITTLabel labelIlSinir;
        protected ITTEnumComboBox IlSinir;
        protected ITTCheckBox NeedSpecialEquipment;
        protected ITTCheckBox EpicrisisDelivered;
        protected ITTPanel ttpanelMedulaSevkBilgileri;
        protected ITTTextBox txtMedulaSiteCode;
        protected ITTLabel labelSiteCode;
        protected ITTGroupBox ttgroupboxMutatDisiAracRaporBilgileri;
        protected ITTLabel ttlabelMutatDisiGerekcesi;
        protected ITTTextBox MutatDisiGerekcesi;
        protected ITTLabel ttlabelBitisTarihi;
        protected ITTLabel ttlabelBaslangicTarihi;
        protected ITTLabel ttlabelRaporTarihi;
        protected ITTDateTimePicker RaporBitisTarihi;
        protected ITTButton saglikTesisiAra;
        protected ITTDateTimePicker RaporBaslangicTarihi;
        protected ITTDateTimePicker RaporTarihi;
        protected ITTLabel labelMedulaSevkNedeni;
        protected ITTGrid ttgridSevkEdenDoktorlar;
        protected ITTListBoxColumn SevkEdenDoktor;
        protected ITTCheckBox medulaRefakatciDurumu;
        protected ITTLabel lblSevkTedaviTipi;
        protected ITTObjectListBox TTListBoxSevkTedaviTipi;
        protected ITTObjectListBox TTListBoxMedulaSevkVasitasi;
        protected ITTLabel labelMedulaSevkVasitasi;
        protected ITTObjectListBox TTListBoxMedulaSevkNedeni;
        protected ITTLabel labelRequestedExternalDepartment;
        protected ITTTextBox Description;
        protected ITTObjectListBox RequestedExternalDepartment;
        protected ITTLabel labelDescription;
        protected ITTLabel labelRequestedExternalHospital;
        protected ITTObjectListBox RequestedExternalHospital;
        protected ITTLabel labelReasonOfDispatch;
        protected ITTTextBox CompanionReason;
        protected ITTLabel labelCompanionReason;
        protected ITTLabel labelDispatchedSpeciality;
        protected ITTObjectListBox DispatchedSpeciality;
        protected ITTLabel labelDispatchCity;
        protected ITTTextBox ReasonOfDispatch;
        protected ITTObjectListBox DispatchCity;
        protected ITTTabPage DispatchResultTabPage;
        protected ITTTextBox DispatchedDoctorName;
        protected ITTLabel labelRestingStartDate;
        protected ITTLabel labelDispatchedDoctor;
        protected ITTDateTimePicker RestingStartDate;
        protected ITTLabel labelRestingEndDate;
        protected ITTLabel labelCompanionStatus;
        protected ITTTextBox CompanionStatus;
        protected ITTDateTimePicker RestingEndDate;
        protected ITTTextBox GSSOwnerUniquerefNo;
        protected ITTTextBox GSSOwnerName;
        protected ITTObjectListBox RequestedReferableHospital;
        protected ITTLabel labelGSSOwnerUniquerefNo;
        protected ITTLabel labelGSSOwnerName;
        protected ITTLabel labelRequestedReferableHospital;
        protected ITTLabel labelRequestedSite;
        protected ITTObjectListBox RequestedSite;
        protected ITTLabel labelRequestDate;
        protected ITTObjectListBox RequestedReferableResource;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelRequestedReferableResource;
        override protected void InitializeControls()
        {
            DispatchTabControl = (ITTTabControl)AddControl(new Guid("0c162684-9181-403b-8f83-4e44c61718c0"));
            DispatchTabPage = (ITTTabPage)AddControl(new Guid("de18a33f-0d4f-4ed1-8c18-712d635fed3d"));
            labelIlSinir = (ITTLabel)AddControl(new Guid("372d631d-f216-48a0-97e7-354f773771bb"));
            IlSinir = (ITTEnumComboBox)AddControl(new Guid("7e16aaf2-0e2e-4a52-b266-2be008575a49"));
            NeedSpecialEquipment = (ITTCheckBox)AddControl(new Guid("2f3b6884-25ee-4076-ba6a-1f842c8a89b6"));
            EpicrisisDelivered = (ITTCheckBox)AddControl(new Guid("efc4372a-f108-4f45-bb3f-c98a107a3736"));
            ttpanelMedulaSevkBilgileri = (ITTPanel)AddControl(new Guid("07194eb6-85f5-456b-864e-81d8c11c15d1"));
            txtMedulaSiteCode = (ITTTextBox)AddControl(new Guid("bb7e6672-68a3-4786-bddd-d2400817468c"));
            labelSiteCode = (ITTLabel)AddControl(new Guid("9237be54-00d3-42a9-b3d4-62a683817ecf"));
            ttgroupboxMutatDisiAracRaporBilgileri = (ITTGroupBox)AddControl(new Guid("47a86a90-cc14-481a-9349-d71a52b58f72"));
            ttlabelMutatDisiGerekcesi = (ITTLabel)AddControl(new Guid("12d45c6b-7f6f-4f59-b8fa-c7451408bff2"));
            MutatDisiGerekcesi = (ITTTextBox)AddControl(new Guid("5fe5c76d-d87b-471c-9fbe-fa20f051eb05"));
            ttlabelBitisTarihi = (ITTLabel)AddControl(new Guid("15327449-5f22-4cbe-8126-498b63a22543"));
            ttlabelBaslangicTarihi = (ITTLabel)AddControl(new Guid("16572fd9-4dfc-479d-b720-05ceb593e162"));
            ttlabelRaporTarihi = (ITTLabel)AddControl(new Guid("f331b15b-4551-4777-95d8-77a00c538e2a"));
            RaporBitisTarihi = (ITTDateTimePicker)AddControl(new Guid("735b9643-aed8-41cd-9b79-5b3a4b09a4ef"));
            saglikTesisiAra = (ITTButton)AddControl(new Guid("9d8bb6d9-de64-4473-9ca3-e7cb3cc6ba72"));
            RaporBaslangicTarihi = (ITTDateTimePicker)AddControl(new Guid("c83313dc-7357-4dc6-8a91-012efaa822eb"));
            RaporTarihi = (ITTDateTimePicker)AddControl(new Guid("fa788a03-8923-4a38-b6ec-9614e2f60ae4"));
            labelMedulaSevkNedeni = (ITTLabel)AddControl(new Guid("4c6fdce0-b925-4129-8945-84243979ffc6"));
            ttgridSevkEdenDoktorlar = (ITTGrid)AddControl(new Guid("ec6adcd7-2362-4ca6-9d51-fc72d6bf0a2b"));
            SevkEdenDoktor = (ITTListBoxColumn)AddControl(new Guid("7e70efae-7928-4cda-b90a-0b521e047640"));
            medulaRefakatciDurumu = (ITTCheckBox)AddControl(new Guid("98182143-7916-4713-a87a-7358fac232e8"));
            lblSevkTedaviTipi = (ITTLabel)AddControl(new Guid("48beb167-1eb7-41a2-bfc8-e9d759dc907f"));
            TTListBoxSevkTedaviTipi = (ITTObjectListBox)AddControl(new Guid("677015ad-165c-4755-9623-5599237c1e67"));
            TTListBoxMedulaSevkVasitasi = (ITTObjectListBox)AddControl(new Guid("3ecbb9b0-1a72-41aa-a411-97789ce3f7a0"));
            labelMedulaSevkVasitasi = (ITTLabel)AddControl(new Guid("878509ef-44ba-4781-b3f4-cf5e2dca5342"));
            TTListBoxMedulaSevkNedeni = (ITTObjectListBox)AddControl(new Guid("648c4613-2b63-4451-935c-ac91f81e6164"));
            labelRequestedExternalDepartment = (ITTLabel)AddControl(new Guid("b4288411-86dd-4515-8ed2-d327934d712e"));
            Description = (ITTTextBox)AddControl(new Guid("3735f6d5-a732-46e1-83c5-e5ccd7bf19a1"));
            RequestedExternalDepartment = (ITTObjectListBox)AddControl(new Guid("cc5c6aae-4065-4387-80b7-e8a703b138d8"));
            labelDescription = (ITTLabel)AddControl(new Guid("901c22fe-dab2-4921-8e22-7a81ff997b4d"));
            labelRequestedExternalHospital = (ITTLabel)AddControl(new Guid("bb149fa4-106a-4b3d-922b-89ffc96078e7"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("3363303e-9272-484a-a203-34fc75890489"));
            labelReasonOfDispatch = (ITTLabel)AddControl(new Guid("71cd7454-94e2-40a4-8522-8c7ce6430c5a"));
            CompanionReason = (ITTTextBox)AddControl(new Guid("7fc2a7cb-e9bf-403d-80f9-11469e25fa41"));
            labelCompanionReason = (ITTLabel)AddControl(new Guid("b4359b07-8582-4aa4-821f-80cfd4edb35c"));
            labelDispatchedSpeciality = (ITTLabel)AddControl(new Guid("89eaddb8-b20f-4cdb-b0d9-5ad0a4fed832"));
            DispatchedSpeciality = (ITTObjectListBox)AddControl(new Guid("588f834f-6764-40e4-bd60-68b48ad085ee"));
            labelDispatchCity = (ITTLabel)AddControl(new Guid("563e624e-a57c-4351-96ac-249808ae311b"));
            ReasonOfDispatch = (ITTTextBox)AddControl(new Guid("a6fb1e8d-78fa-4079-a858-9870bcb60eea"));
            DispatchCity = (ITTObjectListBox)AddControl(new Guid("be982f58-fd40-407d-8ff8-8099f7497c74"));
            DispatchResultTabPage = (ITTTabPage)AddControl(new Guid("4fc35e8a-412e-48fc-b7df-9431c769a175"));
            DispatchedDoctorName = (ITTTextBox)AddControl(new Guid("13408534-d8a8-404b-9b89-35aa0dff9d88"));
            labelRestingStartDate = (ITTLabel)AddControl(new Guid("aaa6f7a3-0b6a-4e67-8d81-07f90388c046"));
            labelDispatchedDoctor = (ITTLabel)AddControl(new Guid("839cbfc8-659a-44c9-b48a-5414ab007690"));
            RestingStartDate = (ITTDateTimePicker)AddControl(new Guid("c8d518fd-719a-4757-81d8-847999594aeb"));
            labelRestingEndDate = (ITTLabel)AddControl(new Guid("bf1b25eb-8d12-47eb-901e-b5aeaf4995c5"));
            labelCompanionStatus = (ITTLabel)AddControl(new Guid("ced3bb4e-51bd-4e80-8591-f66a2a9114eb"));
            CompanionStatus = (ITTTextBox)AddControl(new Guid("5bd032f8-f0c4-411e-800e-9daec7bacf7b"));
            RestingEndDate = (ITTDateTimePicker)AddControl(new Guid("af5970bf-2c8a-4cdb-8b42-966fe79eadb0"));
            GSSOwnerUniquerefNo = (ITTTextBox)AddControl(new Guid("7d601b0d-8b54-4466-aeb9-dd345ffde469"));
            GSSOwnerName = (ITTTextBox)AddControl(new Guid("3e6d37c6-3043-4688-bfd6-324aad9b1a87"));
            RequestedReferableHospital = (ITTObjectListBox)AddControl(new Guid("3fb020e7-7c5a-40ee-9cec-c28a05336009"));
            labelGSSOwnerUniquerefNo = (ITTLabel)AddControl(new Guid("fc3db273-d1d0-4917-b168-769333c87530"));
            labelGSSOwnerName = (ITTLabel)AddControl(new Guid("96b14013-04fa-42d4-968b-331ce0f5cd32"));
            labelRequestedReferableHospital = (ITTLabel)AddControl(new Guid("f9197912-7f79-4ea5-8219-424b14081742"));
            labelRequestedSite = (ITTLabel)AddControl(new Guid("08dd8785-cfbc-4991-817f-7ea768a682ed"));
            RequestedSite = (ITTObjectListBox)AddControl(new Guid("e156340e-62bc-4270-86df-fb00f0bec80c"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("fd021b8e-1ad8-45af-aaf2-f5feeacf132b"));
            RequestedReferableResource = (ITTObjectListBox)AddControl(new Guid("0f229a19-cad5-42f9-9580-fe29bd3f1191"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("8f4dac6c-e23b-437b-b67f-526dd217fa2e"));
            labelRequestedReferableResource = (ITTLabel)AddControl(new Guid("9aaf492b-02c6-481e-b1ff-2599d4de1638"));
            base.InitializeControls();
        }

        public DispatchToOtherHospitalForm() : base("DISPATCHTOOTHERHOSPITAL", "DispatchToOtherHospitalForm")
        {
        }

        protected DispatchToOtherHospitalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}