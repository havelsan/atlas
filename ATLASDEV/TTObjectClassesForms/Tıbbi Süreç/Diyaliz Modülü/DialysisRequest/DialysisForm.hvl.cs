
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
    /// Diyaliz İstek
    /// </summary>
    public partial class DialysisForm : EpisodeActionForm
    {
    /// <summary>
    /// Diyaliz İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.DialysisRequest _DialysisRequest
        {
            get { return (TTObjectClasses.DialysisRequest)_ttObject; }
        }

        protected ITTLabel labelOzelDurum;
        protected ITTObjectListBox OzelDurum;
        protected ITTTextBox MedulaRaporBilgileri;
        protected ITTTextBox MedulaRaporTakipNo;
        protected ITTTextBox Note;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel lblRaporBilgileri;
        protected ITTLabel labelMedulaRaporTakipNo;
        protected ITTCheckBox chkDisXXXXXXRaporu;
        protected ITTCheckBox HomeDialysis;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelNote;
        protected ITTLabel labelProtocolNo;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage DialysisOrder;
        protected ITTGrid DialysisOrders;
        protected ITTListBoxColumn DialysisOrdersProcedureObject;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Duration;
        protected ITTTextBoxColumn OrderNote;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel labelProcedureDoctor;
        protected ITTCheckBox chkInPatientBed;
        protected ITTObjectListBox Bed;
        protected ITTObjectListBox RoomGroup;
        protected ITTLabel labelRoomGroup;
        protected ITTObjectListBox Room;
        protected ITTLabel labelRoom;
        protected ITTLabel labelBed;
        protected ITTObjectListBox PhysicalStateClinic;
        protected ITTLabel labelPhysicalStateClinic;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage tttabpage3;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage DiagnosisEntryTab;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn SecAddToHistory;
        protected ITTListBoxColumn SecDiagnose;
        protected ITTCheckBoxColumn SecIsMainDiagnose;
        protected ITTListBoxColumn SecResponsibleUser;
        protected ITTDateTimePickerColumn SecDiagnoseDate;
        protected ITTObjectListBox PackageProcedure;
        protected ITTLabel ttlabel4;
        override protected void InitializeControls()
        {
            labelOzelDurum = (ITTLabel)AddControl(new Guid("2fb29168-977c-4219-a420-0fd22709cf4c"));
            OzelDurum = (ITTObjectListBox)AddControl(new Guid("833b5007-43bc-4545-bc48-c12b733e844c"));
            MedulaRaporBilgileri = (ITTTextBox)AddControl(new Guid("b3bfd0cb-1574-45af-aabd-0da04be99f97"));
            MedulaRaporTakipNo = (ITTTextBox)AddControl(new Guid("a7eeab54-b304-40c8-b161-23fe41682b81"));
            Note = (ITTTextBox)AddControl(new Guid("a7d228a8-68be-4332-a02c-298eb5434ff7"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("0fc98529-ebf2-4da2-ba22-65f6ed600600"));
            lblRaporBilgileri = (ITTLabel)AddControl(new Guid("d4b3cda1-4dee-46e8-be54-60c47b79788a"));
            labelMedulaRaporTakipNo = (ITTLabel)AddControl(new Guid("4e6e9f3a-f318-4f36-aa68-ca5ab1e35e37"));
            chkDisXXXXXXRaporu = (ITTCheckBox)AddControl(new Guid("424edd8a-328d-4f12-ba22-8ae5dd0cb616"));
            HomeDialysis = (ITTCheckBox)AddControl(new Guid("5503ef61-81f3-4862-ab8b-37205476e06e"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("72194686-4b24-4a18-b72b-d71a1fe057e8"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("f8374445-658c-4361-a263-6292c2d32f0e"));
            labelNote = (ITTLabel)AddControl(new Guid("a9729ae5-cf2c-4271-8db5-8d25d5f16796"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("3a09eb4a-15c0-4e36-b95f-c175fb1b45bf"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("4533e3d3-082b-411d-bfc0-f3e4d395cc5d"));
            DialysisOrder = (ITTTabPage)AddControl(new Guid("d4f1c46f-995d-426c-8121-3263bfe80a50"));
            DialysisOrders = (ITTGrid)AddControl(new Guid("a3cc3442-78e9-46f2-b426-9de9757bd5d5"));
            DialysisOrdersProcedureObject = (ITTListBoxColumn)AddControl(new Guid("533bd243-59d2-407b-8665-8306c25e978c"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("5897361c-8ccd-472a-8f23-90511189abd2"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("d31fb3f0-e9e4-4e5e-b833-3342376e4883"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("24ceb182-295c-44f3-af90-fcdfd1f06b7d"));
            OrderNote = (ITTTextBoxColumn)AddControl(new Guid("4b8233aa-019e-4227-a25c-f027d355cdc4"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("930c397b-727f-413a-917e-fb5d24dee4df"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("b6127f40-7132-40fe-80ac-9dbc945de1e6"));
            chkInPatientBed = (ITTCheckBox)AddControl(new Guid("b8bfad59-2748-4c57-b6af-ad93dc91cd0c"));
            Bed = (ITTObjectListBox)AddControl(new Guid("e9791a00-22cc-47a6-86b6-1911843caf21"));
            RoomGroup = (ITTObjectListBox)AddControl(new Guid("f29d3b9f-9bc0-4fa1-8d5d-f1aec8019e9e"));
            labelRoomGroup = (ITTLabel)AddControl(new Guid("e6de8872-fa84-4d9c-814e-14e8944c947d"));
            Room = (ITTObjectListBox)AddControl(new Guid("59c608a0-cb8d-4bcc-90da-4a09bfa6bb9e"));
            labelRoom = (ITTLabel)AddControl(new Guid("1b3e3d52-32d1-4846-b372-57d6223705a5"));
            labelBed = (ITTLabel)AddControl(new Guid("8dc7547d-fc7a-4a61-996f-6ba195150e6d"));
            PhysicalStateClinic = (ITTObjectListBox)AddControl(new Guid("8aced2e9-e720-4c00-8f79-d1646f807076"));
            labelPhysicalStateClinic = (ITTLabel)AddControl(new Guid("5b1eedd4-4d36-4548-a601-8e403a85725f"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("3de9d4d7-933f-4c61-b0cb-e4421198b8b2"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("f634d90b-d5d6-459e-87b9-0d4c0848251b"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("8109e702-211c-4651-b60b-47d83e409646"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("e0089a66-018b-4e9e-ad5b-503fad621ab9"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("b656bd9a-a0f5-4356-8056-1df446a86ce3"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("441efcfc-2925-4542-a467-2588e7309aa4"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("bb92c35f-0353-402a-8013-3d8f7296d0dd"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("43fdc18b-792c-4872-be96-7c6dae802e16"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("27485d82-e157-40a4-8441-419ae3005376"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("506b574e-7d76-4042-a635-eb05dea358db"));
            DiagnosisEntryTab = (ITTTabPage)AddControl(new Guid("3db0561d-88cb-4645-8c9b-1c9f48372327"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("1a1dee1a-426e-48fd-820c-2e4b300f8e6d"));
            SecAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("be9ac65a-9088-4067-9a1d-f573f4f3fa77"));
            SecDiagnose = (ITTListBoxColumn)AddControl(new Guid("cc2d8612-de66-48ed-99eb-123e56a1186e"));
            SecIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ccbe5977-00ce-4265-818a-b3d17d1bebca"));
            SecResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("897efde8-cabe-4372-9b33-21710fb11b31"));
            SecDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d1977112-385c-42b5-b207-597f63f3e905"));
            PackageProcedure = (ITTObjectListBox)AddControl(new Guid("0ab52e99-9e7b-43f2-b5f1-a7b67c611d28"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("ccf1de07-b2f3-4f3a-8799-739070ea7cbc"));
            base.InitializeControls();
        }

        public DialysisForm() : base("DIALYSISREQUEST", "DialysisForm")
        {
        }

        protected DialysisForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}