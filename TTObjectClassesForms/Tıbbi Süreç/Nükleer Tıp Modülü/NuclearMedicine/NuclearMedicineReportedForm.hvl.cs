
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
    /// Nükleer Tıp Rapor Edildi Formu
    /// </summary>
    public partial class NuclearMedicineReportedForm : EpisodeActionForm
    {
    /// <summary>
    /// Nükleer Tıp
    /// </summary>
        protected TTObjectClasses.NuclearMedicine _NuclearMedicine
        {
            get { return (TTObjectClasses.NuclearMedicine)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox PREDIAGNOSIS;
        protected ITTTabPage tttabpage3;
        protected ITTRichTextBoxControl ttrichtextboxcontrol1;
        protected ITTGroupBox ttgroupbox1;
        protected ITTLabel labelProcedureDoctor;
        protected ITTLabel ttlabel5;
        protected ITTObjectListBox ResponsibleDoctor;
        protected ITTTextBox nucMedSelectedTesttxt;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel ttlabel1;
        protected ITTButton cmdReport;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTCheckBox IsEmergency;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTObjectListBox REQUESTDOCTOR;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel8;
        protected ITTDateTimePicker ActionDate;
        protected ITTTextBox REQUESTDOCTORPHONE;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("83e973ba-0208-4896-b5ef-5f02150dc761"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("68423ab3-700c-4979-ad65-60432356a85d"));
            PREDIAGNOSIS = (ITTTextBox)AddControl(new Guid("229e2d9b-246a-4485-b39c-8740659af4c8"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("8d2ac426-c1d4-4314-86c2-7f61422cbf6e"));
            ttrichtextboxcontrol1 = (ITTRichTextBoxControl)AddControl(new Guid("2149756b-040d-4d5f-9812-b398332823a4"));
            ttgroupbox1 = (ITTGroupBox)AddControl(new Guid("30dfa5b0-83e6-4df1-b2fe-f28a2c85b4c1"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("9a8644ca-7965-45c4-af52-a73aea4ac4ff"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("ebaa8e25-3fb6-427f-8369-f73b7bb3b67f"));
            ResponsibleDoctor = (ITTObjectListBox)AddControl(new Guid("77316749-1070-474c-bd42-38141e8eb9bf"));
            nucMedSelectedTesttxt = (ITTTextBox)AddControl(new Guid("a98d137c-dc0f-4238-af29-36d939d5b6ca"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("591a88f8-2b4f-459c-bf17-51a1ae258a5e"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("68b8d69d-30c8-48cf-b488-2bb7563ee187"));
            cmdReport = (ITTButton)AddControl(new Guid("117a8ee1-0670-4c19-918b-00cb53afcf6b"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("ced0629a-deb3-4fc6-8fe4-ba4495040426"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("80a73023-3278-45fd-a9e7-61be913f65c4"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("3119f7eb-587f-4e9c-8846-7c3ecf29c053"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("0373ddba-c827-4b7f-8813-4e4786808e36"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("43b9a2ad-3e4f-42a3-b180-e96ad24e96f8"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("ad62abc8-2df3-4111-8344-0f3c00cdf468"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("e0981e56-acfb-4276-9461-0b331265acd4"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("4f9b028c-f1c3-47fb-b7dc-f30f89256ae1"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("40b5c92a-f9f4-4a14-ad74-8418e67f86bc"));
            IsEmergency = (ITTCheckBox)AddControl(new Guid("3f1404c3-0d74-450b-af18-f5d6db0942d6"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("813507d3-2e56-45c3-bdc5-dda7c411e0c9"));
            REQUESTDOCTOR = (ITTObjectListBox)AddControl(new Guid("3dfa5505-81e2-4ce0-81b8-a7a9f4faea43"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("e2277bf9-d7d9-4ebc-87f2-ae485b02a866"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("47af7e41-7007-4143-ab88-95cd40f46d62"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("8fc016d7-61ad-4cd4-980b-8ca68e35240a"));
            REQUESTDOCTORPHONE = (ITTTextBox)AddControl(new Guid("9d354fa7-0964-4133-9679-1d3cc351d5db"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("1e9739b9-6484-4a28-8204-b50a1042a1d7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("d8653522-1373-4d75-8e5e-d5134ae4ad46"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("086d8ca4-d45f-4d0d-8917-614566b1272f"));
            base.InitializeControls();
        }

        public NuclearMedicineReportedForm() : base("NUCLEARMEDICINE", "NuclearMedicineReportedForm")
        {
        }

        protected NuclearMedicineReportedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}