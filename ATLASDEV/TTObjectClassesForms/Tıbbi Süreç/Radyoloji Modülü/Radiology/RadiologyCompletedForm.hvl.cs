
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
    /// Tamam
    /// </summary>
    public partial class RadiologyCompletedForm : EpisodeActionForm
    {
    /// <summary>
    /// Radyoloji
    /// </summary>
        protected TTObjectClasses.Radiology _Radiology
        {
            get { return (TTObjectClasses.Radiology)_ttObject; }
        }

        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tttabpage4;
        protected ITTGrid ttgrid1;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTEnumComboBoxColumn BodySite;
        protected ITTEnumComboBoxColumn BodyPosition;
        protected ITTTextBoxColumn Description;
        protected ITTRichTextBoxControlColumn Report;
        protected ITTTabPage tttabpage5;
        protected ITTGrid GridRadiologyTests;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn UBCODE;
        protected ITTTextBoxColumn Notes;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTabControl tttabcontrol2;
        protected ITTTabPage tttabpage2;
        protected ITTTextBox tttextbox2;
        protected ITTTabPage tttabpage1;
        protected ITTTextBox tttextbox1;
        protected ITTTabPage tttabpage3;
        protected ITTTextBox tttextbox3;
        protected ITTValueListBox ttvaluelistbox1;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelProcessTime;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel8;
        protected ITTEnumComboBox PATIENTGROUPENUM;
        protected ITTLabel ttlabel9;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTObjectListBox ReasonForAdmission;
        override protected void InitializeControls()
        {
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("b187d10f-3b3d-4ff5-a59b-4458f44c17fa"));
            tttabpage4 = (ITTTabPage)AddControl(new Guid("6319cadb-df59-4d05-a022-b8e129fd37aa"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("f465acd6-2f6f-454f-a193-8d1de6fe56ca"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("376672f8-4183-4271-930d-8931524f5fc5"));
            BodySite = (ITTEnumComboBoxColumn)AddControl(new Guid("15e3af90-7306-428e-9ba9-d0db29a22bc2"));
            BodyPosition = (ITTEnumComboBoxColumn)AddControl(new Guid("dc808f93-9c2d-473a-9584-668f616503cb"));
            Description = (ITTTextBoxColumn)AddControl(new Guid("f7fea4fc-d745-4752-83cf-3f2b8026bb86"));
            Report = (ITTRichTextBoxControlColumn)AddControl(new Guid("3a8c9fda-4bfa-42fd-ab22-4236a36ffe9d"));
            tttabpage5 = (ITTTabPage)AddControl(new Guid("a094ac7b-3b87-4167-a86f-e3b49353d8c9"));
            GridRadiologyTests = (ITTGrid)AddControl(new Guid("a1362831-5bd1-4065-a702-526ed7b8667c"));
            Material = (ITTListBoxColumn)AddControl(new Guid("6aa6bd9a-89be-4f4f-aee0-54481e338c69"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("dc4b4019-de72-43ec-861d-d917724b7aad"));
            UBCODE = (ITTTextBoxColumn)AddControl(new Guid("2168d926-8de8-40de-9867-dd02690544c6"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("48d64431-a5ce-44c7-a32d-7f6f55afa0c2"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("099569e3-cd44-43c2-8d72-b79b512f4222"));
            tttabcontrol2 = (ITTTabControl)AddControl(new Guid("abec223b-750b-4b1e-a92c-64aceda50225"));
            tttabpage2 = (ITTTabPage)AddControl(new Guid("df219e19-a9d2-41f9-8a8b-5fffd991c39c"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("1e8377b8-febc-4e2c-926b-1b0a444f1618"));
            tttabpage1 = (ITTTabPage)AddControl(new Guid("68fe9ab6-a5ea-4eee-90e3-482acb1f55fc"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("c711ecd5-adb2-4d27-ad78-a95c1811d41f"));
            tttabpage3 = (ITTTabPage)AddControl(new Guid("8414fba6-e2d5-44aa-aa49-99c35cdf15ac"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("276bed66-b1a2-4e1b-9df2-dff34ffe7d01"));
            ttvaluelistbox1 = (ITTValueListBox)AddControl(new Guid("b493bc3f-fcc9-4cbf-8046-86580c1e9187"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("a27215fd-7564-4e88-9321-87a453d2e6ab"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("a8a20f26-6ee1-43a0-84d5-272dd5a19ead"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("0fe92358-cfc1-4bf1-bcf1-f4bbf5114839"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("7174ffea-1ab9-40c8-8ea7-6d5a8bab6080"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("8df154f0-5aff-4dea-b1d8-ea0f65c0bc2e"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("08eb615d-1cfc-48ac-8586-cb3ad8c49725"));
            PATIENTGROUPENUM = (ITTEnumComboBox)AddControl(new Guid("dd0739d4-b4d4-4101-aa7f-c72a35217d07"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("aa9ab2bd-808c-4fee-96f8-63a068a8a65d"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("96f1fcc9-cbbf-488c-9e9c-75d6b8ec2e85"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("9bed4e4f-3910-4093-aa17-6a561b7fa76a"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("ce9dfce2-57ec-436a-8dc8-46202a3e3f6e"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("0ccd2e46-3026-4334-b091-fec026be5264"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("da819113-8cb3-42a7-a33e-5a7d2b323f81"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("f9654f02-332d-4b0c-96e0-431dd3892954"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("72671895-8118-4da4-9ee2-b2c4dc7f733e"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("bd5a936d-7791-4926-b450-0fbeab89f4ca"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("9e47a9c7-a567-4936-80c1-02dff34e40d4"));
            base.InitializeControls();
        }

        public RadiologyCompletedForm() : base("RADIOLOGY", "RadiologyCompletedForm")
        {
        }

        protected RadiologyCompletedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}