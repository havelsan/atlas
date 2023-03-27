
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
    /// Geleneksel Alternatif Tamamlayıcı Uygulamalar
    /// </summary>
    public partial class TraditionalAlternativeRequestForm : EpisodeActionForm
    {
    /// <summary>
    /// Geleneksel Alternatif Tamamlayıcı Uygulama İşlemleri
    /// </summary>
        protected TTObjectClasses.TraditionalAlternative _TraditionalAlternative
        {
            get { return (TTObjectClasses.TraditionalAlternative)_ttObject; }
        }

        protected ITTObjectListBox MasterResource;
        protected ITTTabControl TabSubaction;
        protected ITTTabPage tttabUygulama;
        protected ITTGrid TraditionalAlternativeProcedures;
        protected ITTDateTimePickerColumn ActionDateTraditionalAlternativeProcedure;
        protected ITTListBoxColumn ProcedureObjectTraditionalAlternativeProcedure;
        protected ITTListBoxColumn ProcedureDoctor;
        protected ITTCheckBoxColumn EmergencyTraditionalAlternativeProcedure;
        protected ITTListBoxColumn ProcedureDepartmentTraditionalAlternativeProcedure;
        protected ITTTextBoxColumn DescriptionTraditionalAlternativeProcedure;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTGrid DiagnosisDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistoryDiagnosisGrid;
        protected ITTListBoxColumn DiagnoseDiagnosisGrid;
        protected ITTEnumComboBoxColumn DiagnosisTypeDiagnosisGrid;
        protected ITTCheckBoxColumn IsMainDiagnoseDiagnosisGrid;
        protected ITTListBoxColumn ResponsibleUserDiagnosisGrid;
        protected ITTDateTimePickerColumn DiagnoseDateDiagnosisGrid;
        protected ITTEnumComboBoxColumn EntryActionTypeDiagnosisGrid;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTRichTextBoxControl PreInformation;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("f33e9f62-9da5-4877-8d6f-8ca57d2ed8bc"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("cdbbaad8-adae-405d-84df-c8e77f0dd886"));
            tttabUygulama = (ITTTabPage)AddControl(new Guid("1f5027ac-d4bc-4f39-93e0-11d0ae2c5b06"));
            TraditionalAlternativeProcedures = (ITTGrid)AddControl(new Guid("d67865d8-2417-4f67-8da9-a26084119224"));
            ActionDateTraditionalAlternativeProcedure = (ITTDateTimePickerColumn)AddControl(new Guid("259e3d42-fc36-49bb-8a7e-860c39f266bd"));
            ProcedureObjectTraditionalAlternativeProcedure = (ITTListBoxColumn)AddControl(new Guid("eff8856f-9b79-4c95-b427-581091f4aca8"));
            ProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("acb420d8-ebc2-4179-b854-92972f477fc5"));
            EmergencyTraditionalAlternativeProcedure = (ITTCheckBoxColumn)AddControl(new Guid("fd167ffb-d495-426a-8163-9f2d278aba4f"));
            ProcedureDepartmentTraditionalAlternativeProcedure = (ITTListBoxColumn)AddControl(new Guid("048b091b-9b6e-43fd-9896-962f2570c6aa"));
            DescriptionTraditionalAlternativeProcedure = (ITTTextBoxColumn)AddControl(new Guid("392bd5e8-203e-4330-8326-a5a796013b52"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("6903f676-36e6-45b4-9a42-b93f0ac699e7"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("227a14a8-6ca6-4fd8-84d2-653d0ad22ed5"));
            DiagnosisDiagnosisGrid = (ITTGrid)AddControl(new Guid("f737f0b8-4cb7-4dd0-8a4f-d90d7e95b4ab"));
            AddToHistoryDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("ab87a206-7543-44b6-b140-f37ddddee9a2"));
            DiagnoseDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("44925e08-b2b7-4a0d-a640-5e0f7aa46056"));
            DiagnosisTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("c811e6db-4483-45cd-829d-fa8afb8844d4"));
            IsMainDiagnoseDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("8d1ff09f-db98-4939-99ec-bc3732f79370"));
            ResponsibleUserDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("d3180d86-c434-489a-8b8b-1bed87793105"));
            DiagnoseDateDiagnosisGrid = (ITTDateTimePickerColumn)AddControl(new Guid("cc6ecf1d-0c69-4362-a5a1-ce7adc94f339"));
            EntryActionTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("e32d1b35-7cf6-4c2f-a705-554d33cc6d8f"));
            labelActionDate = (ITTLabel)AddControl(new Guid("fd6ffa7a-3243-4d1a-bd73-d033647f0e84"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("e8035e69-d7ff-48e9-a54f-2365b1792e9c"));
            PreInformation = (ITTRichTextBoxControl)AddControl(new Guid("e502fd38-ed8b-455b-a0ad-493b2b81d7b4"));
            base.InitializeControls();
        }

        public TraditionalAlternativeRequestForm() : base("TRADITIONALALTERNATIVE", "TraditionalAlternativeRequestForm")
        {
        }

        protected TraditionalAlternativeRequestForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}