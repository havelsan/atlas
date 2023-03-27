
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
    /// Normal Doğum İşlemleri
    /// </summary>
    public partial class RegularObstetricCesareanReqForm : EpisodeActionForm
    {
    /// <summary>
    /// Normal Doğum
    /// </summary>
        protected TTObjectClasses.RegularObstetric _RegularObstetric
        {
            get { return (TTObjectClasses.RegularObstetric)_ttObject; }
        }

        protected ITTRichTextBoxControl NoteRTF;
        protected ITTLabel labelProcessTime;
        protected ITTDateTimePicker ActionDate;
        protected ITTGrid GridEpisodeDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnosisType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTEnumComboBoxColumn EntryActionType;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage ManipulationTab;
        protected ITTGrid GridManipulations;
        protected ITTDateTimePickerColumn RegularObstetricActionDate;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn RegularObstetricDoctor;
        protected ITTTabPage PersonnelTab;
        protected ITTGrid GridPersonnel;
        protected ITTListBoxColumn Personnel;
        protected ITTTabPage TreatmentMaterial;
        protected ITTGrid GridTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn StockOutAmount;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        override protected void InitializeControls()
        {
            NoteRTF = (ITTRichTextBoxControl)AddControl(new Guid("5cb06e14-9499-4ea5-99cc-e944a5a807e3"));
            labelProcessTime = (ITTLabel)AddControl(new Guid("5a7d6113-c4cc-42ea-a080-8b88ee71785c"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("d237e068-a938-4a9d-9a37-4e05a536af1a"));
            GridEpisodeDiagnosis = (ITTGrid)AddControl(new Guid("b8c68477-1ea8-4cd7-85b2-88db54dc3e81"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("be22f044-b316-47e5-9fba-fbbf2d1e281c"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("3d3b8490-d4b9-4e3a-a0ea-f0ea8572a8c1"));
            EpisodeDiagnosisType = (ITTEnumComboBoxColumn)AddControl(new Guid("1dc5de7c-37c5-4554-b9e0-e8ca3e0d3c9d"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("5eb25e23-96ef-4705-9d54-ac9f9710e868"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("039978fe-071c-45ff-a252-ad675ebaffef"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("738c7466-7178-457e-91c6-070ec19d45c1"));
            EntryActionType = (ITTEnumComboBoxColumn)AddControl(new Guid("05542480-ad17-445f-b141-3c74180fe7ee"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("6aa5d9d2-5c27-4fca-87ad-75fdb9b4bafe"));
            ManipulationTab = (ITTTabPage)AddControl(new Guid("ca5e43e8-ff60-425b-9703-e781f73d8712"));
            GridManipulations = (ITTGrid)AddControl(new Guid("efb8376a-5f42-4a4c-b0f9-aa87a6e67ea8"));
            RegularObstetricActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("29f22657-ac5e-49c9-bc91-10bbfbeb3ade"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("31c71db9-f71f-4520-9547-ce286812ce6a"));
            RegularObstetricDoctor = (ITTListBoxColumn)AddControl(new Guid("f5e01885-27e5-4943-972b-d37584506cf5"));
            PersonnelTab = (ITTTabPage)AddControl(new Guid("6a045290-7dda-46dc-ac90-9d1ccb691ec7"));
            GridPersonnel = (ITTGrid)AddControl(new Guid("4832f5ec-fb7b-4d15-9665-05666333eead"));
            Personnel = (ITTListBoxColumn)AddControl(new Guid("4781bd86-2824-466d-a7b4-c71bb4805cfb"));
            TreatmentMaterial = (ITTTabPage)AddControl(new Guid("1b57e979-5a8f-41ed-b532-774387053895"));
            GridTreatmentMaterials = (ITTGrid)AddControl(new Guid("0733f345-ae96-444a-967f-59f059c35f14"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("9b7124e2-c53c-45fe-af10-f533e5e7a77d"));
            Material = (ITTListBoxColumn)AddControl(new Guid("b616c0f6-699e-4dcc-a972-b35bb8860617"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("7bb6c128-17bc-474d-a58e-7dc0a8e34055"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("d968a714-feea-4cac-ab4a-af9a4bd68d7d"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("16e013d5-3def-4f68-9cfc-73c05f4d1fe2"));
            StockOutAmount = (ITTTextBoxColumn)AddControl(new Guid("aa69278b-e9d5-4855-965c-0d7398ff75c2"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("0d6ac221-1018-4f2b-9f59-a31d69f457a6"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("c5b77230-78f1-4d19-85f9-e315c24d0e46"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("cc1f5869-8577-4115-b07e-74249f89b0ca"));
            base.InitializeControls();
        }

        public RegularObstetricCesareanReqForm() : base("REGULAROBSTETRIC", "RegularObstetricCesareanReqForm")
        {
        }

        protected RegularObstetricCesareanReqForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}