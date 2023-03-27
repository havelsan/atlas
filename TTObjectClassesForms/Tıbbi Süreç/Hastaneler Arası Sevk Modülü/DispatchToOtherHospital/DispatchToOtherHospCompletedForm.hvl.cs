
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
    public partial class DispatchToOtherHospCompletedForm : EpisodeActionForm
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
        protected ITTLabel ttlabelRaporTarihi;
        protected ITTDateTimePicker RaporTarihi;
        protected ITTLabel ttlabelBitisTarihi;
        protected ITTDateTimePicker RaporBitisTarihi;
        protected ITTDateTimePicker RaporBaslangicTarihi;
        protected ITTLabel ttlabelBaslangicTarihi;
        protected ITTLabel labelRequestedReferableResource;
        protected ITTTextBox DispatcherDoctorName;
        protected ITTTextBox Description;
        protected ITTObjectListBox RequestedReferableResource;
        protected ITTLabel labelReasonOfDispatch;
        protected ITTLabel labelDescription;
        protected ITTLabel labelRequestedReferableHospital;
        protected ITTTextBox CompanionReason;
        protected ITTObjectListBox RequestedReferableHospital;
        protected ITTLabel labelCompanionReason;
        protected ITTLabel labelDispatchedSpeciality;
        protected ITTTextBox DispatchVehicle;
        protected ITTObjectListBox DispatchedSpeciality;
        protected ITTObjectListBox TTListBoxMedulaSevkVasitasi;
        protected ITTCheckBox medulaRefakatciDurumu;
        protected ITTLabel labelMedulaSevkNedeni;
        protected ITTLabel labelRequestedExternalDepartment;
        protected ITTLabel labelMedulaSevkVasitasi;
        protected ITTObjectListBox TTListBoxMedulaSevkNedeni;
        protected ITTLabel labelDispatchVehicle;
        protected ITTObjectListBox RequestedExternalDepartment;
        protected ITTLabel labelDispatchCity;
        protected ITTLabel labelRequestedExternalHospital;
        protected ITTObjectListBox RequestedExternalHospital;
        protected ITTTextBox ReasonOfDispatch;
        protected ITTObjectListBox DispatchCity;
        protected ITTLabel labelDispatcherDoctor;
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
        protected ITTLabel labelGSSOwnerUniquerefNo;
        protected ITTLabel labelGSSOwnerName;
        protected ITTLabel labelRequestedSite;
        protected ITTObjectListBox RequestedSite;
        protected ITTLabel labelRequestDate;
        protected ITTDateTimePicker RequestDate;
        override protected void InitializeControls()
        {
            DispatchTabControl = (ITTTabControl)AddControl(new Guid("90913c1e-7b40-4c6b-ab19-dd321a3d976a"));
            DispatchTabPage = (ITTTabPage)AddControl(new Guid("f9a6ae6f-d924-474e-91f9-65d411a1b7fe"));
            ttgroupboxMutatDisiAracRaporBilgileri = (ITTGroupBox)AddControl(new Guid("e4741393-85a2-4b23-aed6-21818bac7ed4"));
            ttlabelMutatDisiGerekcesi = (ITTLabel)AddControl(new Guid("66441697-1573-41f7-a9ad-c76dba5d2aa3"));
            MutatDisiGerekcesi = (ITTTextBox)AddControl(new Guid("d445dc53-4a92-4a6a-85c5-a3ff9c38e3d0"));
            ttlabelRaporTarihi = (ITTLabel)AddControl(new Guid("3512123a-bd3a-4c99-ae4f-e265b2612128"));
            RaporTarihi = (ITTDateTimePicker)AddControl(new Guid("71d571ce-ff23-4f93-9412-b6ec147eb2b9"));
            ttlabelBitisTarihi = (ITTLabel)AddControl(new Guid("fe836e1d-5e98-4007-badf-ffeab0702794"));
            RaporBitisTarihi = (ITTDateTimePicker)AddControl(new Guid("df61cde4-67fd-4a2b-89fb-1860d49e0827"));
            RaporBaslangicTarihi = (ITTDateTimePicker)AddControl(new Guid("9c0295d8-85e4-4a57-9dc9-434b4424f3ed"));
            ttlabelBaslangicTarihi = (ITTLabel)AddControl(new Guid("6defafb6-ba4c-4832-9dfc-608865c05765"));
            labelRequestedReferableResource = (ITTLabel)AddControl(new Guid("5080e651-0ea4-4927-8d20-e55891bfe0e2"));
            DispatcherDoctorName = (ITTTextBox)AddControl(new Guid("5f50c5c5-1cf4-43d2-b31e-9398f27a558a"));
            Description = (ITTTextBox)AddControl(new Guid("b60312f3-86d5-4689-a6b9-67d19d738fbb"));
            RequestedReferableResource = (ITTObjectListBox)AddControl(new Guid("96f97a14-ca2a-40fc-9899-0f214fb0daf4"));
            labelReasonOfDispatch = (ITTLabel)AddControl(new Guid("2cadb34d-3088-4ca6-9274-95a6e3f6531a"));
            labelDescription = (ITTLabel)AddControl(new Guid("ddb1c35b-e979-4d27-a036-d02c8edfd815"));
            labelRequestedReferableHospital = (ITTLabel)AddControl(new Guid("23d92e89-520b-43d3-8fcd-88b75d550027"));
            CompanionReason = (ITTTextBox)AddControl(new Guid("c6d60575-5e46-4618-a64b-e4ce3ff3b5e2"));
            RequestedReferableHospital = (ITTObjectListBox)AddControl(new Guid("028b671c-477e-4766-8fad-904e7c613106"));
            labelCompanionReason = (ITTLabel)AddControl(new Guid("4e06b04f-9025-4571-9e59-7a58f7124885"));
            labelDispatchedSpeciality = (ITTLabel)AddControl(new Guid("80add82a-1817-4190-898c-78c4ba594f17"));
            DispatchVehicle = (ITTTextBox)AddControl(new Guid("4f555384-af4a-4963-8f10-183d8aa808d1"));
            DispatchedSpeciality = (ITTObjectListBox)AddControl(new Guid("f66f9595-3109-4ec4-8a25-0bba02ec0b3b"));
            TTListBoxMedulaSevkVasitasi = (ITTObjectListBox)AddControl(new Guid("51ceb730-6196-4c82-81db-2eb1008a1da2"));
            medulaRefakatciDurumu = (ITTCheckBox)AddControl(new Guid("05966452-18de-4ab9-9f85-5b6531042375"));
            labelMedulaSevkNedeni = (ITTLabel)AddControl(new Guid("7251f0ef-ed72-487d-bddf-a192d26fbdc0"));
            labelRequestedExternalDepartment = (ITTLabel)AddControl(new Guid("8c4af29d-6900-46a5-ab9e-017c9baa23bd"));
            labelMedulaSevkVasitasi = (ITTLabel)AddControl(new Guid("64da3b0b-621e-436c-89c6-d9c8fcc114f8"));
            TTListBoxMedulaSevkNedeni = (ITTObjectListBox)AddControl(new Guid("57a72944-cbf9-4de3-9cb7-26d0c3e77e2d"));
            labelDispatchVehicle = (ITTLabel)AddControl(new Guid("d565efd6-bf8f-4733-adf1-ca46a6013711"));
            RequestedExternalDepartment = (ITTObjectListBox)AddControl(new Guid("12e7e57e-ee0d-40f3-a22a-3e2a4bdc9d8d"));
            labelDispatchCity = (ITTLabel)AddControl(new Guid("b7daa1b3-4c2b-4ada-afae-8b4b1dab0e5a"));
            labelRequestedExternalHospital = (ITTLabel)AddControl(new Guid("d2345c7f-16ed-46aa-95c9-5bbee52c9028"));
            RequestedExternalHospital = (ITTObjectListBox)AddControl(new Guid("a038af99-4bf1-43c4-bffb-3e16191e1a83"));
            ReasonOfDispatch = (ITTTextBox)AddControl(new Guid("42af7b40-dbfc-44f6-8ea1-bee20f74c50a"));
            DispatchCity = (ITTObjectListBox)AddControl(new Guid("add69a22-1b36-41ff-93e0-156f902d5bcb"));
            labelDispatcherDoctor = (ITTLabel)AddControl(new Guid("c75da9c2-dfdf-47dc-b572-a74d9c781080"));
            DispatchResultTabPage = (ITTTabPage)AddControl(new Guid("679c49e0-a3c7-4f83-b878-bf7b20b33e1b"));
            DispatchedDoctorName = (ITTTextBox)AddControl(new Guid("7db7302b-ceed-4f17-9b22-29ae2777f856"));
            labelRestingStartDate = (ITTLabel)AddControl(new Guid("1bb03b61-f849-4e04-9183-cc6675bc4b15"));
            labelDispatchedDoctor = (ITTLabel)AddControl(new Guid("f758368f-3d9e-4092-90b8-9a175a49cdf0"));
            RestingStartDate = (ITTDateTimePicker)AddControl(new Guid("c0f766d8-e392-4f23-bf14-600997f71d63"));
            labelRestingEndDate = (ITTLabel)AddControl(new Guid("6c21eb49-6ee6-4a6d-a5ba-206ba4497b34"));
            labelCompanionStatus = (ITTLabel)AddControl(new Guid("b3b58844-b701-4dc8-8b61-4fcc25e7cdb9"));
            CompanionStatus = (ITTTextBox)AddControl(new Guid("f68b55e8-dd03-4559-9d80-49b2b1cfc984"));
            RestingEndDate = (ITTDateTimePicker)AddControl(new Guid("bfffb1d9-f845-45c7-a79e-761d65f0cf46"));
            GSSOwnerUniquerefNo = (ITTTextBox)AddControl(new Guid("ee65d420-f363-4fc3-a6dd-de3366682d9b"));
            GSSOwnerName = (ITTTextBox)AddControl(new Guid("88ba7977-65ae-40a4-956c-9ee9a4d76b6d"));
            labelGSSOwnerUniquerefNo = (ITTLabel)AddControl(new Guid("106a7c58-9fe5-41c3-8f1e-c154d734d614"));
            labelGSSOwnerName = (ITTLabel)AddControl(new Guid("6c6a8d5d-885d-485e-b145-26e020981242"));
            labelRequestedSite = (ITTLabel)AddControl(new Guid("ab24b6bc-edca-4809-bf9f-959af1c050f2"));
            RequestedSite = (ITTObjectListBox)AddControl(new Guid("fa8eb315-703c-4432-bb32-af0c0f593548"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("d200b0a3-ea0b-4328-b333-a91155e01b4e"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("bb9531e3-de03-4366-9ed7-4fef7536d1ac"));
            base.InitializeControls();
        }

        public DispatchToOtherHospCompletedForm() : base("DISPATCHTOOTHERHOSPITAL", "DispatchToOtherHospCompletedForm")
        {
        }

        protected DispatchToOtherHospCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}