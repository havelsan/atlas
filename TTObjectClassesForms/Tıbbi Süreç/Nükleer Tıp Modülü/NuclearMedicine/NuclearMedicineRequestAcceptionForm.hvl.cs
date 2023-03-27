
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
    /// Nükleer Tıp Yeni İstek Formu
    /// </summary>
    public partial class NuclearMedicineRequestAcceptionForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGrid NuclearMedicineTests;
        protected ITTListBoxColumn EquipmentNuclearMedicineTest;
        protected ITTListBoxColumn EpisodeNuclearMedicineTest;
        protected ITTListBoxColumn ProcedureSpecialityNuclearMedicineTest;
        protected ITTListBoxColumn EpisodeActionNuclearMedicineTest;
        protected ITTListBoxColumn PackageDefinitionNuclearMedicineTest;
        protected ITTListBoxColumn MasterSubActionProcedureNuclearMedicineTest;
        protected ITTListBoxColumn MasterPackgSubActionProcedureNuclearMedicineTest;
        protected ITTListBoxColumn MedulaHastaKabulNuclearMedicineTest;
        protected ITTListBoxColumn SubEpisodeNuclearMedicineTest;
        protected ITTListBoxColumn ProcedureObjectNuclearMedicineTest;
        protected ITTListBoxColumn ProcedureDoctorNuclearMedicineTest;
        protected ITTListBoxColumn ProcedureByUserNuclearMedicineTest;
        protected ITTListBoxColumn RequestedByUserNuclearMedicineTest;
        protected ITTTextBoxColumn AccessionNoNuclearMedicineTest;
        protected ITTCheckBoxColumn AccountOperationDoneNuclearMedicineTest;
        protected ITTCheckBoxColumn AccTrxsMultipliedByAmountNuclearMedicineTest;
        protected ITTDateTimePickerColumn ActionDateNuclearMedicineTest;
        protected ITTCheckBoxColumn ActiveNuclearMedicineTest;
        protected ITTTextBoxColumn AmountNuclearMedicineTest;
        protected ITTDateTimePickerColumn CreationDateNuclearMedicineTest;
        protected ITTTextBoxColumn DiscountPercentNuclearMedicineTest;
        protected ITTCheckBoxColumn EligibleNuclearMedicineTest;
        protected ITTCheckBoxColumn EmergencyNuclearMedicineTest;
        protected ITTTextBoxColumn ExtraDescriptionNuclearMedicineTest;
        protected ITTTextBoxColumn IDNuclearMedicineTest;
        protected ITTCheckBoxColumn IsOldActionNuclearMedicineTest;
        protected ITTTextBoxColumn MedulaReportNoNuclearMedicineTest;
        protected ITTDateTimePickerColumn OlapDateNuclearMedicineTest;
        protected ITTDateTimePickerColumn OlapLastUpdateNuclearMedicineTest;
        protected ITTCheckBoxColumn PatientPayNuclearMedicineTest;
        protected ITTDateTimePickerColumn PerformedDateNuclearMedicineTest;
        protected ITTDateTimePickerColumn PricingDateNuclearMedicineTest;
        protected ITTTextBoxColumn ReasonOfCancelNuclearMedicineTest;
        protected ITTEnumComboBoxColumn SUTRuleStatusNuclearMedicineTest;
        protected ITTDateTimePickerColumn WorkListDateNuclearMedicineTest;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel ttlabel5;
        protected ITTButton ttbutton1;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel1;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel6;
        protected ITTTextBox tttextbox2;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTCheckBox IsEmergency;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTLabel ttlabel7;
        protected ITTTextBox REQUESTDOCTORPHONE;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelPreInformation;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            NuclearMedicineTests = (ITTGrid)AddControl(new Guid("ce6290b7-d08c-4e32-bf55-b11e74240c08"));
            EquipmentNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("44da68e1-d492-4469-99a1-89f9a1ad4a5c"));
            EpisodeNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("1a3a1571-cdbb-44b0-97d8-6d57f0440f78"));
            ProcedureSpecialityNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("071c5441-1bfc-47e3-a57b-4f189c1d851b"));
            EpisodeActionNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("441ecc4d-911f-4238-85d9-0b97b6b34fc9"));
            PackageDefinitionNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("41ee403e-d806-4f4b-955a-d5e804e4e80c"));
            MasterSubActionProcedureNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("8cef095a-54d5-4440-8886-ba7c26881ce6"));
            MasterPackgSubActionProcedureNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("c6ab3ce7-3d7d-4e9c-b74c-05024acc1f8d"));
            MedulaHastaKabulNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("d8972f14-65cb-4ff0-bb67-0a3a570c0a41"));
            SubEpisodeNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("897e0d2d-3dc8-4bce-bea4-3b25e303b500"));
            ProcedureObjectNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("00d341c8-f297-4e7f-b9b2-dd4ef48b035b"));
            ProcedureDoctorNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("15467b1c-c69b-4070-a7b1-9a3279bb194b"));
            ProcedureByUserNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("766a1ce7-23ee-40b2-99ad-90e4ceadfe30"));
            RequestedByUserNuclearMedicineTest = (ITTListBoxColumn)AddControl(new Guid("31cbd923-2679-4794-b40a-de9842d4f187"));
            AccessionNoNuclearMedicineTest = (ITTTextBoxColumn)AddControl(new Guid("0f196193-78dc-4978-81ed-ca3dc96286b7"));
            AccountOperationDoneNuclearMedicineTest = (ITTCheckBoxColumn)AddControl(new Guid("21afa5ce-84b0-49ac-a842-48e2831e71db"));
            AccTrxsMultipliedByAmountNuclearMedicineTest = (ITTCheckBoxColumn)AddControl(new Guid("0779e18d-e87d-4740-8158-42cb221cbd25"));
            ActionDateNuclearMedicineTest = (ITTDateTimePickerColumn)AddControl(new Guid("0286d33f-f541-42c3-9102-ef2658ce0995"));
            ActiveNuclearMedicineTest = (ITTCheckBoxColumn)AddControl(new Guid("86211339-9d08-4a51-9cc5-8090ffd2e708"));
            AmountNuclearMedicineTest = (ITTTextBoxColumn)AddControl(new Guid("bf9f04d7-e320-4f25-9a70-0dce72b9c01a"));
            CreationDateNuclearMedicineTest = (ITTDateTimePickerColumn)AddControl(new Guid("550f1067-1151-4dc0-8b05-48716de2c74a"));
            DiscountPercentNuclearMedicineTest = (ITTTextBoxColumn)AddControl(new Guid("befec922-d084-4b42-9076-6dc85bb01516"));
            EligibleNuclearMedicineTest = (ITTCheckBoxColumn)AddControl(new Guid("301fb867-ba5d-4ad6-8eac-ff3252839eb1"));
            EmergencyNuclearMedicineTest = (ITTCheckBoxColumn)AddControl(new Guid("9a23099c-0fc0-457b-a172-55fa37df5476"));
            ExtraDescriptionNuclearMedicineTest = (ITTTextBoxColumn)AddControl(new Guid("67f60f3e-33b7-4393-a03b-f0ee6eac76d1"));
            IDNuclearMedicineTest = (ITTTextBoxColumn)AddControl(new Guid("57692735-395b-4cf6-bf34-6ca0804e29a8"));
            IsOldActionNuclearMedicineTest = (ITTCheckBoxColumn)AddControl(new Guid("eb6bbccc-02fe-41a3-8f40-b1b6a234c1dc"));
            MedulaReportNoNuclearMedicineTest = (ITTTextBoxColumn)AddControl(new Guid("944719e1-a905-4b84-be5b-3c0ccbfd8ca7"));
            OlapDateNuclearMedicineTest = (ITTDateTimePickerColumn)AddControl(new Guid("6b5325fa-9205-43af-88ea-3e73b66c986e"));
            OlapLastUpdateNuclearMedicineTest = (ITTDateTimePickerColumn)AddControl(new Guid("813f7fb4-0f2e-447c-bdf5-8882966fa0a8"));
            PatientPayNuclearMedicineTest = (ITTCheckBoxColumn)AddControl(new Guid("01d0238e-925e-409d-9543-a5786aeb4493"));
            PerformedDateNuclearMedicineTest = (ITTDateTimePickerColumn)AddControl(new Guid("7b2ad1db-5f63-48f8-a6d6-d62be7350d98"));
            PricingDateNuclearMedicineTest = (ITTDateTimePickerColumn)AddControl(new Guid("fc95cf35-ad1a-49bb-8b8e-07c35ad43b6b"));
            ReasonOfCancelNuclearMedicineTest = (ITTTextBoxColumn)AddControl(new Guid("ffd1918b-a59c-40c4-b3cd-cb9cd23ab80d"));
            SUTRuleStatusNuclearMedicineTest = (ITTEnumComboBoxColumn)AddControl(new Guid("8970bc68-9f0f-443f-9165-9ddd9f60c4ba"));
            WorkListDateNuclearMedicineTest = (ITTDateTimePickerColumn)AddControl(new Guid("98744d75-5f81-4b52-9dda-e945b2044529"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("45a63bd9-4394-4671-9dbd-7a0e5072e181"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("e687ca3b-9f07-43f4-9cb0-bde47c7e5d59"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("0257b743-0a6d-4ade-bebf-4625e52fd790"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7cfc87c7-8d90-4ab8-9232-ccefc6bbc976"));
            ttbutton1 = (ITTButton)AddControl(new Guid("23f0a42e-887b-4b46-b715-1c34170ee425"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("bc3a5a09-5521-457a-8dd7-326b09e98792"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("baee14ec-81df-4bc6-8ba0-5bdbc1cc19d2"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("fe8e0679-d861-4de2-a772-5202853fa2ce"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("e733a7f7-7fe8-40f6-b833-e5714255a574"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("6f81562e-21df-4274-a0b1-491f06675627"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("438dd43a-dd80-4939-833e-7f8e11685d00"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("ed37f6f2-e8d5-4baf-869a-c17d8a5a9cb8"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("284c4657-362e-47aa-899e-39994af42dc7"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("a0a59df9-384a-479c-9253-def04e8ba806"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("90439d2c-bc75-488c-a834-bda27557c3b7"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("520fafa8-14b4-49cf-9bb6-3c552caa73eb"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("d10f315d-d893-4400-b5a8-62e72de40b28"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("0173f276-a66d-481a-8c78-35e6cd7c8244"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("eb2adc59-1d06-4d51-af98-6974497e9c4b"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("65c9a7d0-993c-4035-8df3-8052160e2f8b"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("2c351363-4d22-468a-b6c0-d80d57eb0aec"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("ae2fbb65-a7bf-481a-8bbc-e2924d106273"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("7f3c3720-e5ec-401e-ad0a-7e321eae9d27"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("9e7c3b9f-d6e1-4935-8c35-b09970721c28"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("0b37b1d1-4750-478d-9616-2567c8b37c32"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("43f9b02f-c1b7-4a77-879f-36cb822a2bb5"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("f1f5f488-4ac6-4a17-9c2b-263bfd0f76e5"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("c82a89cc-8c67-4c76-8fcb-68ad3b0a0af5"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("262b1769-e16d-46ca-afa8-7ad10a1e91cd"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("399955f4-4b8a-406a-8899-7cc6856294c1"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e9fd4136-ffa8-4065-9fd1-072d3f6898ef"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("8825ba0c-fee1-4664-9719-23ad68d54b00"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("28005c77-e690-4be9-bc4c-3e4ac000288b"));
            base.InitializeControls();
        }

        public NuclearMedicineRequestAcceptionForm() : base("NUCLEARMEDICINE", "NuclearMedicineRequestAcceptionForm")
        {
        }

        protected NuclearMedicineRequestAcceptionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}