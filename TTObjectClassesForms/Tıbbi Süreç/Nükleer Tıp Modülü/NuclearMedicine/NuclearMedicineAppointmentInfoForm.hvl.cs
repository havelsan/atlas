
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
    /// Randevu Bilgileri
    /// </summary>
    public partial class NuclearMedicineAppointmentInfoForm : AppointmentFormBase
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel5;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTCheckBox IsEmergency;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel15;
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
        protected ITTTabControl TABNuclearMedicine;
        protected ITTTabPage TabPageAppointmentInfo;
        protected ITTTextBox pDescriptionBox;
        protected ITTTabPage RadPharmMatTab;
        protected ITTGrid GridRadPharmMaterials;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn2;
        protected ITTListBoxColumn PharmMaterial;
        protected ITTCheckBoxColumn IsInjection;
        protected ITTTextBoxColumn tttextboxcolumn3;
        protected ITTTextBoxColumn tttextboxcolumn4;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("949a8609-fb44-40f5-9224-fb3931c1965e"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("79bb62e8-2fbc-448e-9114-db7dba69cf93"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("ba6e073f-3e61-4bbe-a2c2-2c61ea87d890"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("3afb3b96-463e-40ba-8e4b-7f23b513f0fd"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("858f2c98-e95f-4840-b900-1ab5942c76da"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("91ba6106-051f-47c9-a0c9-ab20dcf37be7"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("281000e0-0461-415f-aece-150e17eec5e8"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("97d68b31-411d-4bad-8d3a-3b961182e015"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("5f8dd8a3-6791-4803-b9ef-55c2e8d6812b"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("506f3783-2678-4316-9120-28e6bd6c3598"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("124e5b9e-7f28-40e8-bb96-af3477c392fb"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("f00a756b-1d8c-4c32-8ff1-d289792f2275"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("2d775576-c9d2-410a-a788-628bcbdc74f4"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("8d83f7fd-ae59-492c-befd-53fb3527668a"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("8bb6d5af-80d7-4cbf-bfc6-bcc450ef29a3"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("f0b06573-a257-4907-a391-01fafdb50025"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("5895c368-feca-42fb-a090-e86725211a7a"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4f0b720c-f394-47e6-acdc-08339cf54f41"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("fe15929a-6d72-4c34-b98e-abc7c59f9b71"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("282e5946-cbbe-4421-bbde-22f2dff6506a"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("fb9780dd-77c3-4585-a537-bc0d94f5898c"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("6526420b-81d4-42c7-9914-02fa2bb6b190"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("384d43ea-e22f-44e4-bc4b-37e2c5aa48a0"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("03905d35-8f6a-48eb-8e0c-c2fcc6101081"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("75317fe1-e3b3-4574-8639-2010656e0a49"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("c00213c5-2ed4-41c1-b056-2daba0f230b6"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("aa0ddf48-f57f-44df-b37d-f022900c1d36"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("7778627b-665a-4152-bafc-60b86343dd0d"));
            TABNuclearMedicine = (ITTTabControl)AddControl(new Guid("80a7ca8c-e2bd-486e-8595-2cff4b0d7ff3"));
            TabPageAppointmentInfo = (ITTTabPage)AddControl(new Guid("0a145549-5fac-42e1-91b8-76ec90bea0ea"));
            pDescriptionBox = (ITTTextBox)AddControl(new Guid("9880f1ca-cced-45c5-961b-ba2110975c04"));
            RadPharmMatTab = (ITTTabPage)AddControl(new Guid("3f6ab548-7f49-401d-86d3-4a22b29a981e"));
            GridRadPharmMaterials = (ITTGrid)AddControl(new Guid("3813cea2-a606-4a33-beaa-6ac63131ca53"));
            ttdatetimepickercolumn2 = (ITTDateTimePickerColumn)AddControl(new Guid("37f82e92-41b6-42c9-9edb-2015c1e98c76"));
            PharmMaterial = (ITTListBoxColumn)AddControl(new Guid("e4e16a49-d06e-4e89-9aea-fcd95b8ad82b"));
            IsInjection = (ITTCheckBoxColumn)AddControl(new Guid("472c1146-260c-4eed-ae9e-5a27db719c98"));
            tttextboxcolumn3 = (ITTTextBoxColumn)AddControl(new Guid("ef7ec00c-fe25-4f65-8b46-7502a9eb7eb3"));
            tttextboxcolumn4 = (ITTTextBoxColumn)AddControl(new Guid("c4946fca-8c68-4a74-9504-6d20ec701f98"));
            base.InitializeControls();
        }

        public NuclearMedicineAppointmentInfoForm() : base("NUCLEARMEDICINE", "NuclearMedicineAppointmentInfoForm")
        {
        }

        protected NuclearMedicineAppointmentInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}