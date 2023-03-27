
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
    /// Nükleer Tıp Red Formu
    /// </summary>
    public partial class NuclearMedicineRejectedForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ttdatetimepicker1;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel9;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTLabel ttlabel1;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox REPEATATIONREASON;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTTextBox tttextbox1;
        protected ITTLabel ttlabel15;
        protected ITTTextBox REQUESTDOCTOR;
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
        protected ITTTextBox PatientPhone;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTTextBox PATIENTWEIGHT;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel2;
        protected ITTTabControl TABNuclearMedicine;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridNuclearMedicineMaterial;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Note;
        protected ITTTabPage RadPharmMatTab;
        protected ITTGrid ttgrid2;
        protected ITTDateTimePickerColumn ttdatetimepickercolumn1;
        protected ITTListBoxColumn ttlistboxcolumn1;
        protected ITTCheckBoxColumn IsInjection;
        protected ITTTextBoxColumn tttextboxcolumn1;
        protected ITTTextBoxColumn tttextboxcolumn2;
        protected ITTListBoxColumn Unit;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("5cf8e3c6-ed9e-4604-b4bb-c5cb9cd048c5"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("48bfa002-c690-4cb0-89a4-eeb2c9edde2d"));
            ttdatetimepicker1 = (ITTDateTimePicker)AddControl(new Guid("d732d746-8b6b-4d5e-9919-cddb32df6791"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("5702e6d6-1110-40e5-83a1-e17fdc7065ce"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("1fc350a4-f787-4478-9fd6-ad76e27bdf00"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("4f6f678e-dc2b-49a7-b5bf-ad5cdc886cc3"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("e3a34148-caff-436c-8358-1189496eb92c"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("48dd4ce4-7117-47f0-9a4e-72ddc70422d2"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("2e3ddf17-7bf7-4eb8-9b3e-52fb384d091a"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("a2971a2b-e474-48fe-996f-f6838ad7d71b"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("7980870a-e4f0-4b54-932a-863265e3f942"));
            REPEATATIONREASON = (ITTTextBox)AddControl(new Guid("2b2e52a6-08db-4b8d-a24f-635982e0156e"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("8f7e04b7-04ea-41c0-bc92-4f6b28994d3a"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("141edf7f-e6e5-4419-a187-c8e949d4874e"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("631ea47d-ef12-429e-8a26-05c5fa59acca"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("214828c3-c012-4c97-bd03-7853c5f66d20"));
            REQUESTDOCTOR = (ITTTextBox)AddControl(new Guid("d942cd13-ed90-471d-9f8c-4a94c9e23744"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("ad9b9fcf-649a-4e54-9839-11d040f551ed"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3653f356-c1d3-48fb-bad6-5e7b8b8a4492"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("18ad8f1d-df50-4a4f-bb0e-11c57fc1879d"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("72f62c11-55d1-48ad-8461-5bd1eea946ce"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("8064a26b-d4dc-4c3b-954f-d177b0ce45a1"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("bead6b12-0fe9-44d7-8c9b-13355fd4d8a4"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("88516d04-a8b4-487b-9acc-2d0cced73054"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("6be60e12-aeff-4f54-963e-d17951e53756"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("94c92203-4266-4f28-b0b6-d5841d68f852"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("a1b64591-0214-45fa-81a6-1381a3696172"));
            PatientPhone = (ITTTextBox)AddControl(new Guid("85d37c3a-8a80-4d6c-9a81-ebe6f45aa919"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("038ce8a3-4019-4289-a154-d5770d78d998"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("8d701636-300a-4bb0-a451-6b9afd9b0e54"));
            PATIENTWEIGHT = (ITTTextBox)AddControl(new Guid("23614fdd-6148-40f7-8383-e7078614b915"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("a335b79a-77f0-4145-96fe-8b8476bbc65c"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("1f30a945-3f00-4658-b236-02ebb6b1ff0d"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("cb5b29cf-545c-47b0-9880-2b387eb09314"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("504de6c6-94d1-4c17-aa6d-89812483796b"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b67311d5-c46d-4edc-8c3f-9ed58deff1ec"));
            TABNuclearMedicine = (ITTTabControl)AddControl(new Guid("66bec9eb-4d73-4643-9f54-6447c17a3f12"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("2c5a706e-0d20-4cb4-ab6f-bab811907a1d"));
            GridNuclearMedicineMaterial = (ITTGrid)AddControl(new Guid("29023898-eb7b-4f16-b0ad-63fa8b028999"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("850a8720-4a9f-4d4c-8bfa-1fd934ed252b"));
            Material = (ITTListBoxColumn)AddControl(new Guid("9d2a5973-cd3b-4f79-bc54-398bdcd50291"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("c4d5b757-f843-4705-b2eb-8b39c849a377"));
            Note = (ITTTextBoxColumn)AddControl(new Guid("f7bcd7ff-30c7-4e4b-bfa3-31b48a952a80"));
            RadPharmMatTab = (ITTTabPage)AddControl(new Guid("68a8e238-18dd-4dff-98d8-8636cb9a01d8"));
            ttgrid2 = (ITTGrid)AddControl(new Guid("17ab1c15-2239-4a0d-9b1e-1eb57cea197a"));
            ttdatetimepickercolumn1 = (ITTDateTimePickerColumn)AddControl(new Guid("29f154ba-332d-4da2-9102-0f4dc31c2c6f"));
            ttlistboxcolumn1 = (ITTListBoxColumn)AddControl(new Guid("11ad24ab-43e9-4606-8401-d5d4c06b1f43"));
            IsInjection = (ITTCheckBoxColumn)AddControl(new Guid("41d99b19-575a-4c0f-b9be-c1fb90421e28"));
            tttextboxcolumn1 = (ITTTextBoxColumn)AddControl(new Guid("abead6b0-31e7-42a2-a7a6-a4f2e60204e1"));
            tttextboxcolumn2 = (ITTTextBoxColumn)AddControl(new Guid("f90553fa-c69b-4272-8562-62aafbda0023"));
            Unit = (ITTListBoxColumn)AddControl(new Guid("c7bc4490-f30f-45ab-b64c-f6dd08f42a63"));
            base.InitializeControls();
        }

        public NuclearMedicineRejectedForm() : base("NUCLEARMEDICINE", "NuclearMedicineRejectedForm")
        {
        }

        protected NuclearMedicineRejectedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}