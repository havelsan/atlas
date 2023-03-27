
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
    /// Hasta Yatış
    /// </summary>
    public partial class InpatientAdmissionQuarantineForm : InPatientAdmissionBaseForm
    {
    /// <summary>
    /// Hasta Yatış  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.InpatientAdmission _InpatientAdmission
        {
            get { return (TTObjectClasses.InpatientAdmission)_ttObject; }
        }

        protected ITTTextBox DischargeNumber;
        protected ITTLabel lblDischargeNumber;
        protected ITTLabel labelHospitalDischargeDate;
        protected ITTDateTimePicker HospitalDischargeDate;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TratmentClinicTab;
        protected ITTGrid TratmentClinicsGrid;
        protected ITTListBoxColumn TreatmentClinic;
        protected ITTDateTimePickerColumn ClinicInpatientDate;
        protected ITTDateTimePickerColumn ClinicDischargeDate;
        protected ITTListBoxColumn ResponsibleDoctor;
        protected ITTTabPage DiagnosisTab;
        protected ITTGrid EpisodeDiagnosis;
        protected ITTCheckBoxColumn AddToHistory;
        protected ITTListBoxColumn Diagnose;
        protected ITTEnumComboBoxColumn DiagnosisType;
        protected ITTCheckBoxColumn IsMainDiagnose;
        protected ITTListBoxColumn ResponsibleUser;
        protected ITTDateTimePickerColumn DiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabPage BedsTab;
        protected ITTGrid BedsGrid;
        protected ITTDateTimePickerColumn BedInPatientDate;
        protected ITTDateTimePickerColumn BedDischargeDate;
        protected ITTListBoxColumn RoomGroup;
        protected ITTListBoxColumn Room;
        protected ITTListBoxColumn Bed;
        protected ITTTextBoxColumn BedAmount;
        protected ITTEnumComboBoxColumn UsedStatus;
        protected ITTTabPage DischargedConclusionTab;
        protected ITTRichTextBoxControl DischargedConclusion;
        protected ITTTabPage MedulaSevkliHastaSevkBilgileri;
        protected ITTGroupBox ttgroupboxMutatDisiAracRaporBilgileri;
        protected ITTLabel lblRefakatciGerekcesi;
        protected ITTTextBox txtboxRefakatciGerekcesi;
        protected ITTLabel ttlabelMutatDisiGerekcesi;
        protected ITTGrid ttgridSevkEdenDoktorlar;
        protected ITTListBoxColumn SevkEdenDoktor;
        protected ITTCheckBox medulaRefakatciDurumu;
        protected ITTTextBox MutatDisiGerekcesi;
        protected ITTLabel ttlabelRaporTarihi;
        protected ITTDateTimePicker RaporTarihi;
        protected ITTLabel ttlabelBitisTarihi;
        protected ITTDateTimePicker RaporBitisTarihi;
        protected ITTDateTimePicker RaporBaslangicTarihi;
        protected ITTLabel ttlabelBaslangicTarihi;
        protected ITTLabel labelMedulaSevkDonusVasitasi;
        protected ITTObjectListBox TTListBoxMedulaSevkVasitasi;
        protected ITTTextBox QuarantineProtocolNo;
        protected ITTDateTimePicker HospitalInpatientDate;
        protected ITTLabel labelHospitalInpatientDate;
        protected ITTLabel labelQuarantineProtocolNo;
        protected ITTRichTextBoxControl ReturnToQuarantineReason;
        protected ITTRichTextBoxControl templateRTF;
        override protected void InitializeControls()
        {
            DischargeNumber = (ITTTextBox)AddControl(new Guid("2ef022c7-bfd1-47a0-b128-496d4ab2a1f2"));
            lblDischargeNumber = (ITTLabel)AddControl(new Guid("f01fea5b-7078-410d-9435-064c11f5b543"));
            labelHospitalDischargeDate = (ITTLabel)AddControl(new Guid("0f93ea82-32a6-45e4-9b4d-9fcacbf9c2b9"));
            HospitalDischargeDate = (ITTDateTimePicker)AddControl(new Guid("fe6e4e81-e006-4cf0-9f65-f172ff7ea3bc"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("65fcd9c9-7103-40ea-9e3d-1c7d9d3bee67"));
            TratmentClinicTab = (ITTTabPage)AddControl(new Guid("818a6d36-2cc5-40b9-a917-f9446925e550"));
            TratmentClinicsGrid = (ITTGrid)AddControl(new Guid("54d9c4d6-72ce-4a6b-b2f4-81d31c4fcafa"));
            TreatmentClinic = (ITTListBoxColumn)AddControl(new Guid("927215d3-6e5e-4db4-bb42-6877efdbfd8d"));
            ClinicInpatientDate = (ITTDateTimePickerColumn)AddControl(new Guid("afd15c2c-60e3-41e6-a00f-e397cebbb82b"));
            ClinicDischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("5acb7b9d-5a58-47eb-8d53-0865c30daa3e"));
            ResponsibleDoctor = (ITTListBoxColumn)AddControl(new Guid("a9d43f84-9585-4c57-baf1-6088c7e34369"));
            DiagnosisTab = (ITTTabPage)AddControl(new Guid("a416d577-bae1-45ed-ae48-de380e7403e9"));
            EpisodeDiagnosis = (ITTGrid)AddControl(new Guid("6d100220-32b0-46d7-a35e-cc07f46bab1d"));
            AddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("c52191a8-a952-4c60-a0d7-de4a8248dfa7"));
            Diagnose = (ITTListBoxColumn)AddControl(new Guid("7460dc9e-7f01-4599-b163-8f431cdfe8fa"));
            DiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("90776d6a-a0ba-44d0-bdf6-9759a4bd191e"));
            IsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("53617b78-f14e-4327-b2c8-8af2dbcfd27c"));
            ResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("d8f75549-dc34-43ed-9a07-9629d8c4b441"));
            DiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("d3475642-e552-468b-b1fc-973cbecabdab"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("48868252-b91f-47cd-aeb4-1514e5f65f90"));
            BedsTab = (ITTTabPage)AddControl(new Guid("ad358208-88fe-4f29-ab84-add7c72d6002"));
            BedsGrid = (ITTGrid)AddControl(new Guid("1a9dda92-1152-41c1-9846-a368f29f1de6"));
            BedInPatientDate = (ITTDateTimePickerColumn)AddControl(new Guid("e08c8ed3-d497-43a4-9bb3-15ea3eb8c9b4"));
            BedDischargeDate = (ITTDateTimePickerColumn)AddControl(new Guid("b8cddc79-604b-4e7f-9bdc-07f1c00710b5"));
            RoomGroup = (ITTListBoxColumn)AddControl(new Guid("d61366d3-cd62-4c8d-a8a8-f501f3039ecd"));
            Room = (ITTListBoxColumn)AddControl(new Guid("0486fa9f-e6fc-4c8c-ac73-bdad6dadbac4"));
            Bed = (ITTListBoxColumn)AddControl(new Guid("3f9f7db0-6c0b-4aa8-b131-fce896f511a5"));
            BedAmount = (ITTTextBoxColumn)AddControl(new Guid("ad7af3d0-477d-4f97-952b-ee475b6154b4"));
            UsedStatus = (ITTEnumComboBoxColumn)AddControl(new Guid("36c6e9cc-723d-4d3b-8dc4-2e17a53b4bab"));
            DischargedConclusionTab = (ITTTabPage)AddControl(new Guid("4bbee325-9159-48af-b49c-b6174c169cdf"));
            DischargedConclusion = (ITTRichTextBoxControl)AddControl(new Guid("846152ab-2d9d-446a-8883-24d4f528c833"));
            MedulaSevkliHastaSevkBilgileri = (ITTTabPage)AddControl(new Guid("546fb1f6-4dc8-4290-ac63-bbcd2025ce05"));
            ttgroupboxMutatDisiAracRaporBilgileri = (ITTGroupBox)AddControl(new Guid("ca0703ee-2de7-4098-ae3f-d63fb0ec9c3a"));
            lblRefakatciGerekcesi = (ITTLabel)AddControl(new Guid("26177d2e-1738-46c0-a034-28d8176ae234"));
            txtboxRefakatciGerekcesi = (ITTTextBox)AddControl(new Guid("35ee6c83-b4d9-422c-95a3-7ae6579bc015"));
            ttlabelMutatDisiGerekcesi = (ITTLabel)AddControl(new Guid("e1679e90-ed42-4dc8-a1fa-969f22b8dce6"));
            ttgridSevkEdenDoktorlar = (ITTGrid)AddControl(new Guid("0a153ccb-d8cf-4a05-8f65-c4d6e4aac246"));
            SevkEdenDoktor = (ITTListBoxColumn)AddControl(new Guid("fed7bec9-eb2b-4865-a57e-fb23331aa0b4"));
            medulaRefakatciDurumu = (ITTCheckBox)AddControl(new Guid("c57cafa6-cb1b-45cf-a92a-b7ddabe4df76"));
            MutatDisiGerekcesi = (ITTTextBox)AddControl(new Guid("9ac4e64b-618f-46d8-a88f-67649bd228d8"));
            ttlabelRaporTarihi = (ITTLabel)AddControl(new Guid("bd644f76-b4f4-45d8-9628-1fa61a365a4f"));
            RaporTarihi = (ITTDateTimePicker)AddControl(new Guid("a55a85f4-56d6-4bd0-8491-d3ae04595908"));
            ttlabelBitisTarihi = (ITTLabel)AddControl(new Guid("ff267060-e5a5-4e78-8eaf-d5fb68b84f87"));
            RaporBitisTarihi = (ITTDateTimePicker)AddControl(new Guid("71f569cf-cd2b-431c-be11-8293727516da"));
            RaporBaslangicTarihi = (ITTDateTimePicker)AddControl(new Guid("305cf778-46d0-43db-91aa-cfd2b3d58c07"));
            ttlabelBaslangicTarihi = (ITTLabel)AddControl(new Guid("e0d96691-f88f-47a5-a56c-12ff694aceaf"));
            labelMedulaSevkDonusVasitasi = (ITTLabel)AddControl(new Guid("6abfd6dd-3bef-4762-9f26-d8f7682dc905"));
            TTListBoxMedulaSevkVasitasi = (ITTObjectListBox)AddControl(new Guid("32ad9594-c6b2-4966-a2eb-2424d77fa244"));
            QuarantineProtocolNo = (ITTTextBox)AddControl(new Guid("f06ca3c6-21a4-4901-ba04-ecce2976dd82"));
            HospitalInpatientDate = (ITTDateTimePicker)AddControl(new Guid("4d5e4878-edff-40cf-9aef-d6993a670639"));
            labelHospitalInpatientDate = (ITTLabel)AddControl(new Guid("ad81271f-3710-419d-a28e-03f9860419c2"));
            labelQuarantineProtocolNo = (ITTLabel)AddControl(new Guid("d6dfffc4-48ca-4487-8e88-7a07e29e150c"));
            ReturnToQuarantineReason = (ITTRichTextBoxControl)AddControl(new Guid("10013e6b-41e7-4b75-93d3-2da363a8cb16"));
            templateRTF = (ITTRichTextBoxControl)AddControl(new Guid("f041839b-10fc-464b-8822-4a706f83acd2"));
            base.InitializeControls();
        }

        public InpatientAdmissionQuarantineForm() : base("INPATIENTADMISSION", "InpatientAdmissionQuarantineForm")
        {
        }

        protected InpatientAdmissionQuarantineForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}