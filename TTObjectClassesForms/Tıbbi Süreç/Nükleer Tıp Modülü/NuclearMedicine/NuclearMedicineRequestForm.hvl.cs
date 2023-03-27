
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
    /// Tetkik İstek
    /// </summary>
    public partial class NuclearMedicineRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel lblRequestCorrectionReason;
        protected ITTTextBox txtRequestCorrectionReason;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTObjectListBox RequestedDoctor;
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
        protected ITTLabel ttlabel5;
        protected ITTTabControl tabTetkik;
        override protected void InitializeControls()
        {
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("cade7a2e-fcb8-465d-a71e-76c35e69a879"));
            lblRequestCorrectionReason = (ITTLabel)AddControl(new Guid("4bd38831-383d-436b-861d-60e6b85d5a81"));
            txtRequestCorrectionReason = (ITTTextBox)AddControl(new Guid("bdee69cf-7d1b-450a-b047-2b2908bfd9f2"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("d404ce9e-a451-4a2c-a1bc-4c7169c4759b"));
            RequestedDoctor = (ITTObjectListBox)AddControl(new Guid("204c0f01-bb5b-4d5f-b02b-26b0d20a9701"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("fc61170f-a4d9-45bc-93e2-5f2b18fc3346"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("6c577ff0-f203-4da6-b996-27225119ffe3"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("32ce6302-22c9-4a84-ab11-bc2c759ffb28"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("a678f2d9-c045-424b-ae19-da9fa018db8c"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("6b01c708-1816-41eb-9714-2e8d943c3dfe"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("27a420d7-74d9-4154-9911-65beff5eabc1"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("641c2d2f-55c7-4f8c-8122-c95b5f987b78"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("2a101ed5-022a-4f48-b4b9-ad8f9da16762"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("499b1629-6a86-4233-8bd7-fd7719fb2da6"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("53d2e2c6-9426-47a0-99c6-63857f950ba7"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("85fb6896-b3f4-4f6b-bc3c-f0e2fadeace3"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("66a934a5-da97-48dd-8849-7d3e65a14ab4"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("79543ea1-4055-4a8c-a524-95601e3862d7"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("ff72e437-1bc9-42f7-a4a8-7e502b8e6334"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("6ef4d722-8943-4780-948f-17e67247d783"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("39a83bdd-208f-41c7-85e4-621b4bf9e750"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("26fe8b27-be69-474f-9153-e71ff8c5679b"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("8a93fe83-073f-49da-ac76-0f53700fdd49"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("1a6d913c-7eca-4027-abe7-89ba7cf40425"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("bd7d7c37-fd33-4c55-b89d-f2b1c408eb35"));
            tabTetkik = (ITTTabControl)AddControl(new Guid("a6d7389e-201b-446a-bb4d-8c3709c14f7f"));
            base.InitializeControls();
        }

        public NuclearMedicineRequestForm() : base("NUCLEARMEDICINE", "NuclearMedicineRequestForm")
        {
        }

        protected NuclearMedicineRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}