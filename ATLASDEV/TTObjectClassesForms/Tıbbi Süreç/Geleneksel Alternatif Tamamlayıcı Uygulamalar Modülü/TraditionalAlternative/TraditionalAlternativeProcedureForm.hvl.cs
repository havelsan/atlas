
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
    public partial class TraditionalAlternativeProcedureForm : EpisodeActionForm
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
        protected ITTTabPage ttAlternatifUygulama;
        protected ITTGrid TraditionalAlternativeProcedures;
        protected ITTDateTimePickerColumn ActionDateTraditionalAlternativeProcedure;
        protected ITTListBoxColumn ProcedureObjectTraditionalAlternativeProcedure;
        protected ITTListBoxColumn ProcedureDoctor;
        protected ITTCheckBoxColumn EmergencyTraditionalAlternativeProcedure;
        protected ITTListBoxColumn ProcedureDepartmentTraditionalAlternativeProcedure;
        protected ITTTextBoxColumn DescriptionTraditionalAlternativeProcedure;
        protected ITTTabPage ttSarfGiris;
        protected ITTGrid TraditionalAlternativeTreatmentMaterials;
        protected ITTDateTimePickerColumn MaterialActionDate;
        protected ITTListBoxColumn Material;
        protected ITTTextBoxColumn UseAmount;
        protected ITTTextBoxColumn UnitType;
        protected ITTTextBoxColumn UBBCode;
        protected ITTTextBoxColumn DistributionType;
        protected ITTTextBoxColumn Notes;
        protected ITTTabControl DiagnosisTab;
        protected ITTTabPage ttVakaTanilari;
        protected ITTGrid DiagnosisDiagnosisGrid;
        protected ITTCheckBoxColumn AddToHistoryDiagnosisGrid;
        protected ITTListBoxColumn DiagnoseDiagnosisGrid;
        protected ITTEnumComboBoxColumn DiagnosisTypeDiagnosisGrid;
        protected ITTCheckBoxColumn IsMainDiagnoseDiagnosisGrid;
        protected ITTListBoxColumn ResponsibleUserDiagnosisGrid;
        protected ITTDateTimePickerColumn DiagnoseDateDiagnosisGrid;
        protected ITTEnumComboBoxColumn EntryActionTypeDiagnosisGrid;
        protected ITTTabPage ttTaniGiris;
        protected ITTGrid SecDiagnosis;
        protected ITTCheckBoxColumn AddToHistorySecDiagnosisGrid;
        protected ITTListBoxColumn DiagnoseSecDiagnosisGrid;
        protected ITTCheckBoxColumn IsMainDiagnoseSecDiagnosisGrid;
        protected ITTListBoxColumn ResponsibleUserSecDiagnosisGrid;
        protected ITTDateTimePickerColumn DiagnoseDateSecDiagnosisGrid;
        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProcedureDoctor;
        protected ITTObjectListBox ttobjectlistbox1;
        protected ITTLabel labelActionDate;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel labelReport;
        protected ITTRichTextBoxControl Report;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            MasterResource = (ITTObjectListBox)AddControl(new Guid("38dd574d-dbaa-4fca-a3f0-ec2c970ff565"));
            TabSubaction = (ITTTabControl)AddControl(new Guid("d82998de-fc8d-4d41-98f4-e6e0fdb81e7d"));
            ttAlternatifUygulama = (ITTTabPage)AddControl(new Guid("baceec99-0e23-4fc4-8f6e-157312b829b5"));
            TraditionalAlternativeProcedures = (ITTGrid)AddControl(new Guid("c61c7edf-282e-4277-a1be-b775817a1a8d"));
            ActionDateTraditionalAlternativeProcedure = (ITTDateTimePickerColumn)AddControl(new Guid("dfd749b9-a68d-41a7-8202-451811fa5a52"));
            ProcedureObjectTraditionalAlternativeProcedure = (ITTListBoxColumn)AddControl(new Guid("536a9809-b609-44bc-ade8-9801223fafa4"));
            ProcedureDoctor = (ITTListBoxColumn)AddControl(new Guid("36a0b45f-56b0-42a8-90de-5fb481a2676d"));
            EmergencyTraditionalAlternativeProcedure = (ITTCheckBoxColumn)AddControl(new Guid("40be2232-4781-4232-b1ef-4acf37c7244d"));
            ProcedureDepartmentTraditionalAlternativeProcedure = (ITTListBoxColumn)AddControl(new Guid("f48b8c08-90e3-4a58-aa47-8608c555307b"));
            DescriptionTraditionalAlternativeProcedure = (ITTTextBoxColumn)AddControl(new Guid("6c1a6ca6-0a8b-4fef-846b-3f19fb7fc9fb"));
            ttSarfGiris = (ITTTabPage)AddControl(new Guid("a8dac69b-79b8-4982-92ea-b53a4ff6838c"));
            TraditionalAlternativeTreatmentMaterials = (ITTGrid)AddControl(new Guid("818d8ff7-fb00-4dcd-8835-671cc53f10d2"));
            MaterialActionDate = (ITTDateTimePickerColumn)AddControl(new Guid("b0b868b1-fea6-4ef8-a77c-bdcbfd922f5d"));
            Material = (ITTListBoxColumn)AddControl(new Guid("a375ddcb-947a-4197-b644-781e83141719"));
            UseAmount = (ITTTextBoxColumn)AddControl(new Guid("0aa84fc6-7955-4d32-b30d-e81fe725a897"));
            UnitType = (ITTTextBoxColumn)AddControl(new Guid("768a5c31-ffc3-4735-bc1b-2687079c6ea9"));
            UBBCode = (ITTTextBoxColumn)AddControl(new Guid("e796fe06-238b-427c-ab49-107b49121c67"));
            DistributionType = (ITTTextBoxColumn)AddControl(new Guid("55622dcd-d6a4-449f-ac9b-e342f3569220"));
            Notes = (ITTTextBoxColumn)AddControl(new Guid("097baa21-8ebf-4fb6-9c18-3c08534a9a45"));
            DiagnosisTab = (ITTTabControl)AddControl(new Guid("0bc381c5-f84f-4f68-90f9-8de5999cce2e"));
            ttVakaTanilari = (ITTTabPage)AddControl(new Guid("8aaf999c-c25c-420c-b1fc-a6eac0c04917"));
            DiagnosisDiagnosisGrid = (ITTGrid)AddControl(new Guid("d3f803a7-c52e-4413-ae68-479f3f5efed0"));
            AddToHistoryDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("08275957-eae5-45f1-a2cc-e659a869b0b6"));
            DiagnoseDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("c32db9f4-a2c9-468a-9160-a56e64c05433"));
            DiagnosisTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("c8e048a0-2d27-4e11-b11b-cf4a50cbc92a"));
            IsMainDiagnoseDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("1613820f-eca8-4dc0-b742-566ff5d3a18f"));
            ResponsibleUserDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("d5a0a139-4165-4a79-add8-2fe2869079ad"));
            DiagnoseDateDiagnosisGrid = (ITTDateTimePickerColumn)AddControl(new Guid("81e63d2c-b4a1-4895-b85a-b57f4381578e"));
            EntryActionTypeDiagnosisGrid = (ITTEnumComboBoxColumn)AddControl(new Guid("88636892-a329-4543-9498-e0173d2f2144"));
            ttTaniGiris = (ITTTabPage)AddControl(new Guid("c7768a34-cf69-45fc-a21e-3b86ab79ace9"));
            SecDiagnosis = (ITTGrid)AddControl(new Guid("9406f9c4-6359-4fab-8489-0e3c24eda042"));
            AddToHistorySecDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("1a1eb5ef-d7ab-4515-befc-ccb5eb8ee04c"));
            DiagnoseSecDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("02b32e60-dd66-4dcf-9883-8a0fd6b5f92d"));
            IsMainDiagnoseSecDiagnosisGrid = (ITTCheckBoxColumn)AddControl(new Guid("6f9aa077-26e7-4472-a874-a9f4e8ec991f"));
            ResponsibleUserSecDiagnosisGrid = (ITTListBoxColumn)AddControl(new Guid("e86ec4c9-006b-4565-b062-7c351654f8d7"));
            DiagnoseDateSecDiagnosisGrid = (ITTDateTimePickerColumn)AddControl(new Guid("4a1cf895-6062-4d02-bb3c-7d61ccdc2f83"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("fbcd1826-6229-43ae-b90a-2d2992476c48"));
            labelProcedureDoctor = (ITTLabel)AddControl(new Guid("ca26823c-2876-43b8-8c24-c6aad65c22bc"));
            ttobjectlistbox1 = (ITTObjectListBox)AddControl(new Guid("6c402a82-43c7-4f94-a9b7-970da29d6a65"));
            labelActionDate = (ITTLabel)AddControl(new Guid("676e7954-9291-47b3-b4b0-bc15f3663ee3"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("73f10450-2854-4f5c-a8cb-0a0f5006d7ac"));
            labelReport = (ITTLabel)AddControl(new Guid("c5874327-faf6-4cb4-943e-7af873819d2c"));
            Report = (ITTRichTextBoxControl)AddControl(new Guid("a6674919-1551-4d58-b4f7-b74e6a79e761"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("61efa832-f05b-45b8-a781-a97be4387202"));
            base.InitializeControls();
        }

        public TraditionalAlternativeProcedureForm() : base("TRADITIONALALTERNATIVE", "TraditionalAlternativeProcedureForm")
        {
        }

        protected TraditionalAlternativeProcedureForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}