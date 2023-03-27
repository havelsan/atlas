
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
    /// ICD10 Tanımlama
    /// </summary>
    public partial class DiagnosisDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Tanı
    /// </summary>
        protected TTObjectClasses.DiagnosisDefinition _DiagnosisDefinition
        {
            get { return (TTObjectClasses.DiagnosisDefinition)_ttObject; }
        }

        protected ITTLabel labelAdmissionType;
        protected ITTObjectListBox AdmissionType;
        protected ITTCheckBox SendSms;
        protected ITTCheckBox PregnancyDiagnos;
        protected ITTCheckBox HighRiskPregnancy;
        protected ITTCheckBox IsInfluenzaDiagnos;
        protected ITTLabel labelInfectiousIllnesesInfoGroup;
        protected ITTEnumComboBox InfectiousIllnesesInfoGroup;
        protected ITTLabel labelTeshis;
        protected ITTObjectListBox Teshis;
        protected ITTLabel labelFtrDiagnoseGroup;
        protected ITTEnumComboBox FtrDiagnoseGroup;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage SPTSTanilari;
        protected ITTGrid SPTSMatchICDs;
        protected ITTListBoxColumn SPTSDiagnosisInfo;
        protected ITTTabPage Kavramlar;
        protected ITTGrid DefinitionConcepts;
        protected ITTTextBoxColumn ConceptDefinitionConcept;
        protected ITTTabPage MedulaKurallari;
        protected ITTCheckBox DialysisReportNotMust;
        protected ITTGrid OzelDurumlar;
        protected ITTListBoxColumn OzelDurum;
        protected ITTTabPage Teshisler;
        protected ITTGrid DiagnosisDefTeshis;
        protected ITTListBoxColumn TeshisDiagnosisDefTeshis;
        protected ITTTabPage SMSMetni;
        protected ITTTextBox SMSText;
        protected ITTTextBox Type;
        protected ITTTextBox Precision;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTLabel labelMainGrup;
        protected ITTObjectListBox ParentGroup;
        protected ITTLabel labelType;
        protected ITTLabel labelPrecision;
        protected ITTLabel labelName;
        protected ITTCheckBox DeclerationMust;
        protected ITTLabel labelCode;
        protected ITTCheckBox Active;
        override protected void InitializeControls()
        {
            labelAdmissionType = (ITTLabel)AddControl(new Guid("28fdf373-746e-4e76-98c6-786caf6e8157"));
            AdmissionType = (ITTObjectListBox)AddControl(new Guid("ced23e59-29f3-43f6-80d7-4210d75e92dc"));
            SendSms = (ITTCheckBox)AddControl(new Guid("d61d3f11-8e82-4302-bc8b-982d6e37742d"));
            PregnancyDiagnos = (ITTCheckBox)AddControl(new Guid("ed59121b-6cde-4032-af06-a09b7f682a67"));
            HighRiskPregnancy = (ITTCheckBox)AddControl(new Guid("bfed645f-522e-44ed-8885-4ab02e270727"));
            IsInfluenzaDiagnos = (ITTCheckBox)AddControl(new Guid("2f88b59e-f163-4aee-89b0-b6f368f90f71"));
            labelInfectiousIllnesesInfoGroup = (ITTLabel)AddControl(new Guid("a256e37d-a6ea-4a4b-beda-6078aed29e0c"));
            InfectiousIllnesesInfoGroup = (ITTEnumComboBox)AddControl(new Guid("4f7b7d3c-943d-409c-8944-4593d1645c4a"));
            labelTeshis = (ITTLabel)AddControl(new Guid("2095db51-9c57-42e5-848a-fce5a12cf2f7"));
            Teshis = (ITTObjectListBox)AddControl(new Guid("29833b38-1e5d-4a87-be58-d372b69d2404"));
            labelFtrDiagnoseGroup = (ITTLabel)AddControl(new Guid("6959d4ff-a94a-4315-89f7-c63ae62f7594"));
            FtrDiagnoseGroup = (ITTEnumComboBox)AddControl(new Guid("68731241-654b-458c-889d-a2fd402caddb"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("20404d3c-c180-417c-bda8-43fc6e977855"));
            SPTSTanilari = (ITTTabPage)AddControl(new Guid("4b8e6067-06e5-4e4f-bbaa-47cd0e85d806"));
            SPTSMatchICDs = (ITTGrid)AddControl(new Guid("5ce4721c-3003-4aad-8962-aa077da6454a"));
            SPTSDiagnosisInfo = (ITTListBoxColumn)AddControl(new Guid("a03fcea7-746a-4a9f-8ced-2ed006b93b0f"));
            Kavramlar = (ITTTabPage)AddControl(new Guid("9cca3ba4-82bc-4ba6-a2bd-add0726d3b65"));
            DefinitionConcepts = (ITTGrid)AddControl(new Guid("7a45d09c-529e-4287-b661-f520d2e3c1f5"));
            ConceptDefinitionConcept = (ITTTextBoxColumn)AddControl(new Guid("08ec1063-8033-4877-ae50-bb8c32daa133"));
            MedulaKurallari = (ITTTabPage)AddControl(new Guid("1eb281f0-2204-41c1-9802-6d233ad96418"));
            DialysisReportNotMust = (ITTCheckBox)AddControl(new Guid("4ce47f1e-37bd-4667-b35a-a190b491ff2e"));
            OzelDurumlar = (ITTGrid)AddControl(new Guid("d0f6a22c-fa0c-44df-a7cd-a486f659b100"));
            OzelDurum = (ITTListBoxColumn)AddControl(new Guid("31ac9f54-3efc-47f7-96d4-05c7d807b7d5"));
            Teshisler = (ITTTabPage)AddControl(new Guid("c65aef38-1f3b-4e53-a049-3f9811a0d2e4"));
            DiagnosisDefTeshis = (ITTGrid)AddControl(new Guid("85be0f40-d11e-4e89-bb33-bfbf022ecd57"));
            TeshisDiagnosisDefTeshis = (ITTListBoxColumn)AddControl(new Guid("389e419a-2924-445d-b769-3e7d575ebf3f"));
            SMSMetni = (ITTTabPage)AddControl(new Guid("dfda4f4a-5bc6-4e20-b66e-da4e957bf3c6"));
            SMSText = (ITTTextBox)AddControl(new Guid("7a429e1d-2c41-467f-9d06-8424870f2907"));
            Type = (ITTTextBox)AddControl(new Guid("2566f12f-d7a5-4a71-b9e5-6b83ab00a117"));
            Precision = (ITTTextBox)AddControl(new Guid("29a80f8b-0cb3-4248-b76a-0dde1d35a823"));
            Name = (ITTTextBox)AddControl(new Guid("16be5925-a194-4037-851d-f7f0a361b656"));
            Code = (ITTTextBox)AddControl(new Guid("34f73aa5-703e-4c5b-aeaf-949773bbe075"));
            labelMainGrup = (ITTLabel)AddControl(new Guid("64b3a77c-77da-4f19-8101-3103fc3b9b94"));
            ParentGroup = (ITTObjectListBox)AddControl(new Guid("c462b960-3b76-4cf7-9db1-4bae964a38a5"));
            labelType = (ITTLabel)AddControl(new Guid("98ec9f92-12e1-458d-a2da-679abaaf4943"));
            labelPrecision = (ITTLabel)AddControl(new Guid("58ce0d09-4ff5-4072-a571-42d915f19531"));
            labelName = (ITTLabel)AddControl(new Guid("89392e2b-42dd-4570-9980-726735ccf9f4"));
            DeclerationMust = (ITTCheckBox)AddControl(new Guid("ae5e2f16-d27f-449d-aba3-1a3167336866"));
            labelCode = (ITTLabel)AddControl(new Guid("db96005c-0eee-44db-bdae-06e3fb7736c3"));
            Active = (ITTCheckBox)AddControl(new Guid("2fb79b3f-c0fa-4d21-9b8a-225dfef16f51"));
            base.InitializeControls();
        }

        public DiagnosisDefinitionForm() : base("DIAGNOSISDEFINITION", "DiagnosisDefinitionForm")
        {
        }

        protected DiagnosisDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}