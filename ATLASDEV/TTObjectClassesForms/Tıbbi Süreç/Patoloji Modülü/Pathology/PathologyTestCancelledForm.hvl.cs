
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
    public partial class PathologyTestCancelledForm : TTForm
    {
    /// <summary>
    /// Patoloji
    /// </summary>
        protected TTObjectClasses.Pathology _Pathology
        {
            get { return (TTObjectClasses.Pathology)_ttObject; }
        }

        protected ITTLabel ttlabel20;
        protected ITTTextBox MaterialProtocolNo;
        protected ITTLabel ttlabel9;
        protected ITTLabel ttlabel10;
        protected ITTTabControl TabPathologyProcedure;
        protected ITTTabPage TabPageProcedure;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridPathologyMaterials;
        protected ITTDateTimePickerColumn MActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn MAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabControl TABExtraInformations;
        protected ITTTabPage TabPagePreDiagnosis;
        protected ITTTabPage TabPageAcceptionNote;
        protected ITTTabPage TabPageDescription;
        protected ITTTextBox Description;
        protected ITTTabPage TabPageAdditionalInfo;
        protected ITTTextBox AdditionalInfo;
        protected ITTTabPage TabPageReasonForRepetation;
        protected ITTTextBox ReasonForRepetation;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage TabPageSnomedDiagnose;
        protected ITTGrid GridSnomedDiagnosis;
        protected ITTListBoxColumn SnomedDiagnose;
        protected ITTTabPage EpisodeDiagnosisTab;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTextBox RESPONSIBLEDOCTORPHONENO;
        protected ITTGrid GridConsultantDoctor;
        protected ITTListBoxColumn ConsultantDoctor;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox SpecialDoctor;
        protected ITTCheckBox INTRAOPERATIVECONSULTATION;
        protected ITTLabel ttlabel13;
        protected ITTLabel ttlabel14;
        protected ITTObjectListBox ResposibleDoctor;
        protected ITTTabControl TabReports;
        protected ITTTabPage TabPageMacroscopi;
        protected ITTTabPage TabPageMicroskopi;
        protected ITTTabPage TabPageTissueProcedure;
        protected ITTTabPage TabPageAdditional;
        protected ITTTabPage TabPageDiagnosis;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTDateTimePicker RESULTENTRYDATE;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel2;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelActionDate;
        override protected void InitializeControls()
        {
            ttlabel20 = (ITTLabel)AddControl(new Guid("a5c5c129-8329-4a16-b08c-75cbc55fe772"));
            MaterialProtocolNo = (ITTTextBox)AddControl(new Guid("1460b7af-88cb-4631-819a-fa69db55433d"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("aea3d9a7-f8c9-43e0-ba53-defb2977c2d2"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("3c47ade1-2f59-4e05-9070-97d39ae0a3b5"));
            TabPathologyProcedure = (ITTTabControl)AddControl(new Guid("b74512dc-2719-4c41-8096-b044acf39b5e"));
            TabPageProcedure = (ITTTabPage)AddControl(new Guid("14f64154-3287-41de-ba00-54afa2783f93"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("f4c49a55-4d3d-49af-8431-d2a3ff5f6393"));
            GridPathologyMaterials = (ITTGrid)AddControl(new Guid("9416e499-a943-4393-8cff-fc4d4dd2472a"));
            MActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9897832b-1254-4d79-bb01-c9b942551055"));
            Material = (ITTListBoxColumn)AddControl(new Guid("b089ee0e-e030-42d8-8dd5-98bb622f100d"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("843f3f45-113a-46b1-bf23-22d23c303d91"));
            MAmount = (ITTTextBoxColumn)AddControl(new Guid("bf6d659e-a9a6-4a49-b4b4-dde398caa167"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("78adeb3b-37a7-4e82-b894-7ce61830f63a"));
            TABExtraInformations = (ITTTabControl)AddControl(new Guid("c7010f01-9429-4280-a48f-100334c8fac5"));
            TabPagePreDiagnosis = (ITTTabPage)AddControl(new Guid("93f46de2-6797-4097-938c-2bae18011537"));
            TabPageAcceptionNote = (ITTTabPage)AddControl(new Guid("d3735e4a-c2de-497d-8a81-aebff361d4f7"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("22d97371-7432-468c-b705-e496cef660da"));
            Description = (ITTTextBox)AddControl(new Guid("547a284a-cb4b-4dc7-aa8e-651ce0fc7c94"));
            TabPageAdditionalInfo = (ITTTabPage)AddControl(new Guid("1453662b-9271-40fb-8f65-4e9b02e6dd02"));
            AdditionalInfo = (ITTTextBox)AddControl(new Guid("8239cefe-c50e-4ccb-a86a-7eabd2b5529d"));
            TabPageReasonForRepetation = (ITTTabPage)AddControl(new Guid("b6d50845-4e4a-4e69-96e1-ecda1b91068d"));
            ReasonForRepetation = (ITTTextBox)AddControl(new Guid("0acce3d5-730f-4502-be12-4cc7cc39bd34"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("6339ebdc-a673-42ca-8067-f9edef44cc06"));
            TabPageSnomedDiagnose = (ITTTabPage)AddControl(new Guid("a6210a10-12a7-4712-94b0-3c8892746aeb"));
            GridSnomedDiagnosis = (ITTGrid)AddControl(new Guid("7b5a2015-61ec-45ca-b615-0b03e7fb2871"));
            SnomedDiagnose = (ITTListBoxColumn)AddControl(new Guid("306b5dae-4e73-4dc3-ac70-0aa3a023645c"));
            EpisodeDiagnosisTab = (ITTTabPage)AddControl(new Guid("f1bcb9b6-71d1-492d-aa1d-8b477a1cb728"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("e3f6566e-6314-46b4-aab1-5663421b7958"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("dae80676-8344-4a2a-9b55-b28f2a1f25bf"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("1269c32c-c286-40ad-b63a-70ec4d6bd8ca"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("b7e7e9a5-af44-4e65-9fdd-68ac08913b3b"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("5e65e891-7aba-4245-8b2c-5ed85aaeea3a"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("76162b8d-e446-4d0a-83a5-9c004b680106"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("fc141964-353a-4b93-b44b-df8064a3af07"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("c6e58681-0de6-4349-bbf4-8a26cb381f1d"));
            RESPONSIBLEDOCTORPHONENO = (ITTTextBox)AddControl(new Guid("602d2aad-3be2-4224-946d-db7474c2c11a"));
            GridConsultantDoctor = (ITTGrid)AddControl(new Guid("7f34207f-fdf0-4561-95a7-01f7566afe10"));
            ConsultantDoctor = (ITTListBoxColumn)AddControl(new Guid("d1f1f154-e18d-49a2-a120-7bb9da3d06f3"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("d905fa5c-8892-407e-bbac-587505318f42"));
            SpecialDoctor = (ITTObjectListBox)AddControl(new Guid("446522d4-f6ec-41df-a716-244a9f291e5c"));
            INTRAOPERATIVECONSULTATION = (ITTCheckBox)AddControl(new Guid("ad113f77-6b80-4986-899a-877586e41935"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("ef416ff5-0765-411c-ab14-5f9f373e4236"));
            ttlabel14 = (ITTLabel)AddControl(new Guid("354a4b71-fe2e-463c-a5f8-a5317dadc63b"));
            ResposibleDoctor = (ITTObjectListBox)AddControl(new Guid("faa1ebf5-369c-4923-b3b7-a726d08c1187"));
            TabReports = (ITTTabControl)AddControl(new Guid("b2037786-cc92-440e-b217-c877f50cc3c8"));
            TabPageMacroscopi = (ITTTabPage)AddControl(new Guid("7a669ff9-54d6-422f-93f9-4ac8bab75408"));
            TabPageMicroskopi = (ITTTabPage)AddControl(new Guid("26285071-d99b-4c68-8297-19663dda5373"));
            TabPageTissueProcedure = (ITTTabPage)AddControl(new Guid("3cfccb91-addd-4082-a46b-4a9d7ab6955c"));
            TabPageAdditional = (ITTTabPage)AddControl(new Guid("6e0269fb-a2e9-4bca-b614-1698c1a4422d"));
            TabPageDiagnosis = (ITTTabPage)AddControl(new Guid("7aebb332-03b1-4921-b37e-3e72347346a1"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("1992964b-77ba-4ce0-a9e8-d3bf54b4b0c7"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("7b65f112-7f28-42df-8ae1-ab48c7a9ed66"));
            RESULTENTRYDATE = (ITTDateTimePicker)AddControl(new Guid("9a95bfb9-0956-4399-a8a4-8c1538692915"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("1473d664-0819-4714-acab-11a4fb6a31e7"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("51ca7282-fd83-43fd-8c2d-b5e089a1284a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("98a59676-a76e-43db-a36d-a4b4e849440a"));
            labelActionDate = (ITTLabel)AddControl(new Guid("584da45e-33f7-44f1-83bf-c93ad7cdf310"));
            base.InitializeControls();
        }

        public PathologyTestCancelledForm() : base("PATHOLOGY", "PathologyTestCancelledForm")
        {
        }

        protected PathologyTestCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}