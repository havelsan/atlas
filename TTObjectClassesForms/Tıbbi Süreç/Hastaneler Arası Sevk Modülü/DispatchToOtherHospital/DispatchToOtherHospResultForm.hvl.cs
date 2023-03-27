
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
    public partial class DispatchToOtherHospResultForm : EpisodeActionForm
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
        protected ITTGroupBox ttgroupboxMutatDisiAracRaporBilgileri;
        protected ITTLabel ttlabelMutatDisiGerekcesi;
        protected ITTTextBox MutatDisiGerekcesi;
        protected ITTDateTimePicker RaporTarihi;
        protected ITTLabel ttlabelBitisTarihi;
        protected ITTDateTimePicker RaporBaslangicTarihi;
        protected ITTLabel ttlabelBaslangicTarihi;
        protected ITTDateTimePicker RaporBitisTarihi;
        protected ITTLabel ttlabelRaporTarihi;
        protected ITTLabel labelRequestedExternalDepartment;
        protected ITTLabel labelRequestedReferableHospital;
        protected ITTTextBox Description;
        protected ITTLabel labelRequestedReferableResource;
        protected ITTObjectListBox RequestedReferableHospital;
        protected ITTLabel labelDescription;
        protected ITTObjectListBox RequestedExternalDepartment;
        protected ITTObjectListBox RequestedReferableResource;
        protected ITTLabel labelRequestedExternalHospital;
        protected ITTLabel labelMedulaSevkNedeni;
        protected ITTLabel labelMedulaSevkVasitasi;
        protected ITTLabel labelCompanionReason;
        protected ITTObjectListBox TTListBoxMedulaSevkNedeni;
        protected ITTTextBox CompanionReason;
        protected ITTObjectListBox TTListBoxMedulaSevkVasitasi;
        protected ITTGrid ttgridSevkEdenDoktorlar;
        protected ITTListBoxColumn SevkEdenDoktor;
        protected ITTLabel lblSevkTedaviTipi;
        protected ITTObjectListBox TTListBoxSevkTedaviTipi;
        protected ITTLabel labelReasonOfDispatch;
        protected ITTObjectListBox RequestedExternalHospital;
        protected ITTCheckBox medulaRefakatciDurumu;
        protected ITTLabel labelDispatchedSpeciality;
        protected ITTObjectListBox DispatchedSpeciality;
        protected ITTLabel labelDispatchCity;
        protected ITTTextBox ReasonOfDispatch;
        protected ITTObjectListBox DispatchCity;
        protected ITTTabPage DispatchResultTabPage;
        protected ITTTextBox DispatchedDoctorName;
        protected ITTLabel labelRestingStartDate;
        protected ITTLabel labelDispatchedDoctor;
        protected ITTObjectListBox DispatchedDoctor;
        protected ITTDateTimePicker RestingStartDate;
        protected ITTLabel labelRestingEndDate;
        protected ITTLabel labelCompanionStatus;
        protected ITTTextBox CompanionStatus;
        protected ITTDateTimePicker RestingEndDate;
        protected ITTTextBox GSSOwnerUniquerefNo;
        protected ITTTextBox GSSOwnerName;
        protected ITTLabel labelGSSOwnerUniquerefNo;
        protected ITTLabel labelGSSOwnerName;
        protected ITTLabel labelRequestedSite;
        protected ITTObjectListBox RequestedSite;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        protected ITTButton ShowMessageStatus;
        override protected void InitializeControls()
        {
            DispatchTabControl = (ITTTabControl)AddControl(new Guid("2b1c4c0b-5b51-4d18-b592-8992c0bde4eb"));
            DispatchTabPage = (ITTTabPage)AddControl(new Guid("e914f61e-23d4-4671-b30b-b4eaf9391279"));
            ttgroupboxMutatDisiAracRaporBilgileri = (ITTGroupBox)AddControl(new Guid("3b9f5ed5-c2d8-4e55-ac2d-4903f73e3269"));
            ttlabelMutatDisiGerekcesi = (ITTLabel)AddControl(new Guid("569c99ef-49bb-428e-ae1c-cfd54004a5cb"));
            MutatDisiGerekcesi = (ITTTextBox)AddControl(new Guid("31a27a68-18a7-4895-98ed-ad28060fc3f8"));
            RaporTarihi = (ITTDateTimePicker)AddControl(new Guid("b28e8c3e-befd-47d4-a889-d80d47d61310"));
            ttlabelBitisTarihi = (ITTLabel)AddControl(new Guid("9b3a4a0e-4414-479c-8409-b56ef025e0c1"));
            RaporBaslangicTarihi = (ITTDateTimePicker)AddControl(new Guid("cea41662-3ae6-4df7-b9ca-b0cc735d424e"));
            ttlabelBaslangicTarihi = (ITTLabel)AddControl(new Guid("984ad9cc-245c-45b0-9862-d5cae751510d"));
            RaporBitisTarihi = (ITTDateTimePicker)AddControl(new Guid("80b435d1-1343-4280-a028-0610b94155fb"));
            ttlabelRaporTarihi = (ITTLabel)AddControl(new Guid("4a7fccd0-f5e1-44a1-972b-5dbbd8030d77"));
            labelRequestedExternalDepartment = (ITTLabel)AddControl(new Guid("e81dc5c1-12e5-4699-968d-673cbabfd0f6"));
            labelRequestedReferableHospital = (ITTLabel)AddControl(new Guid("fd53d64b-e055-4005-8bbe-0b3c7c4c2476"));
            Description = (ITTTextBox)AddControl(new Guid("9c4cfb59-6a1a-4801-aba6-3a56eca80d10"));
            labelRequestedReferableResource = (ITTLabel)AddControl(new Guid("51b3271f-945b-46dd-947e-0066fb5eabb1"));
            RequestedReferableHospital = (ITTObjectListBox)AddControl(new Guid("9b2b8d94-3d56-4def-8a6e-287223bd47ab"));
            labelDescription = (ITTLabel)AddControl(new Guid("067d7abf-30f3-4be9-bc4d-c11e5c765dac"));
            RequestedExternalDepartment = (ITTObjectListBox)AddControl(new Guid("f487378e-42a0-44c2-b618-e247d78b02df"));
            RequestedReferableResource = (ITTObjectListBox)AddControl(new Guid("a758c189-117f-4fcd-acac-3e72085f721a"));
            labelRequestedExternalHospital = (ITTLabel)AddControl(new Guid("cb5979de-2d9e-479e-9cf6-729f889bcaf5"));
            labelMedulaSevkNedeni = (ITTLabel)AddControl(new Guid("558e768b-622b-4ae5-ae4a-7bfd3f350d10"));
            labelMedulaSevkVasitasi = (ITTLabel)AddControl(new Guid("c2504501-df13-4eeb-a973-99ad3c0dd282"));
            labelCompanionReason = (ITTLabel)AddControl(new Guid("39f27452-c300-4f27-bd08-c17bc04995a2"));
            TTListBoxMedulaSevkNedeni = (ITTObjectListBox)AddControl(new Guid("82f5820f-9bb9-40ed-aa3b-42f1c4f80cb2"));
            CompanionReason = (ITTTextBox)AddControl(new Guid("f40b57fd-4fbf-4d03-972a-a5cec8b3d4b9"));
            TTListBoxMedulaSevkVasitasi = (ITTObjectListBox)AddControl(new Guid("303eb11f-7bed-421d-b9b6-55b747f8ec1a"));
            ttgridSevkEdenDoktorlar = (ITTGrid)AddControl(new Guid("5adb5319-9c78-46d8-a7ea-ed325b52bc78"));
            SevkEdenDoktor = (ITTListBoxColumn)AddControl(new Guid("ff5b0414-f703-4d83-a4a5-b2de3c5a4899"));
            lblSevkTedaviTipi = (ITTLabel)AddControl(new Guid("11cb39e2-789b-4764-9879-18dc17cfb122"));
            TTListBoxSevkTedaviTipi = (ITTObjectListBox)AddControl(new Guid("6a7dd0d0-bf85-4aaf-a5ca-a45732b03a0c"));
            labelReasonOfDispatch = (ITTLabel)AddControl(new Guid("5b984863-d723-4886-94f0-9934ff57cef4"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("9cbc0d18-6f51-4595-98e0-e90895052a26"));
            medulaRefakatciDurumu = (ITTCheckBox)AddControl(new Guid("17cee634-c45a-4ad1-8a1e-ad7816b37da7"));
            labelDispatchedSpeciality = (ITTLabel)AddControl(new Guid("e47a89e9-717d-47a1-91be-c06cef06969f"));
            DispatchedSpeciality = (ITTObjectListBox)AddControl(new Guid("b4fcfa6b-f131-46f5-bad2-05e3ec222461"));
            labelDispatchCity = (ITTLabel)AddControl(new Guid("b35a52ef-9233-49d1-b532-fa3b94872a11"));
            ReasonOfDispatch = (ITTTextBox)AddControl(new Guid("9cddf937-caf4-4ecd-a347-95574cd0c8fa"));
            DispatchCity = (ITTObjectListBox)AddControl(new Guid("180c1303-f6ed-493b-ac4f-bfb57185dd1f"));
            DispatchResultTabPage = (ITTTabPage)AddControl(new Guid("f569e706-08de-4317-87e5-026115e9b74d"));
            DispatchedDoctorName = (ITTTextBox)AddControl(new Guid("b4681541-a858-4386-b057-a2e6a717b9c7"));
            labelRestingStartDate = (ITTLabel)AddControl(new Guid("f7724414-ded2-418a-bb64-773872803be4"));
            labelDispatchedDoctor = (ITTLabel)AddControl(new Guid("5b6c8027-dfe7-4d71-8cac-d9d70e6c7010"));
            DispatchedDoctor = (ITTObjectListBox)AddControl(new Guid("c8d4c907-ca14-4620-b53f-fc7023f8a629"));
            RestingStartDate = (ITTDateTimePicker)AddControl(new Guid("bb225c31-92f4-4c34-a322-8684b57b5dbe"));
            labelRestingEndDate = (ITTLabel)AddControl(new Guid("664d645f-7cab-47d8-a578-6dbd111fb46a"));
            labelCompanionStatus = (ITTLabel)AddControl(new Guid("d05ef047-e381-41b1-80f1-f8e0f47483c5"));
            CompanionStatus = (ITTTextBox)AddControl(new Guid("6a1a992f-6d78-4898-a3d0-1ce203bd330e"));
            RestingEndDate = (ITTDateTimePicker)AddControl(new Guid("79740c3c-cbb3-41a2-afe3-d7d5aec0c540"));
            GSSOwnerUniquerefNo = (ITTTextBox)AddControl(new Guid("0c575449-e4cf-4b76-910a-e7a5fb15f959"));
            GSSOwnerName = (ITTTextBox)AddControl(new Guid("9d359e02-d5ce-4209-bd39-9b187c179b48"));
            labelGSSOwnerUniquerefNo = (ITTLabel)AddControl(new Guid("8fb8a3c5-802e-4723-af64-60eb618c63d7"));
            labelGSSOwnerName = (ITTLabel)AddControl(new Guid("1635fabb-dc75-4925-bb01-c08b297dd86d"));
            labelRequestedSite = (ITTLabel)AddControl(new Guid("f09811be-dd46-49b2-8c13-bd475188e71a"));
            RequestedSite = (ITTObjectListBox)AddControl(new Guid("eccd36a7-ce83-4d72-98aa-b09d1aa42ac5"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("e0ad9ff0-7df1-463c-971b-68bf947f124f"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("552ac59f-1c90-4360-a793-0f001411f638"));
            ShowMessageStatus = (ITTButton)AddControl(new Guid("aae4f6d6-5a17-46db-b777-d38ae2e430d0"));
            base.InitializeControls();
        }

        public DispatchToOtherHospResultForm() : base("DISPATCHTOOTHERHOSPITAL", "DispatchToOtherHospResultForm")
        {
        }

        protected DispatchToOtherHospResultForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}