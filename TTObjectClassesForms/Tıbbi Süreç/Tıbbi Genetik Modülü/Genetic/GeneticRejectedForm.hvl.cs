
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
    /// Tıbbi Genetik Red Edildi Formu
    /// </summary>
    public partial class GeneticRejectedForm : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Genetik İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.Genetic _Genetic
        {
            get { return (TTObjectClasses.Genetic)_ttObject; }
        }

        protected ITTObjectListBox RepeatReason;
        protected ITTCheckBox ttcheckbox1;
        protected ITTRichTextBoxControl ReportRTF;
        protected ITTLabel ttlabel12;
        protected ITTObjectListBox TestToStudyTTListBox;
        protected ITTLabel ttlabel6;
        protected ITTTabControl TabTextInfos;
        protected ITTTabPage TabPageRequestDesc;
        protected ITTTextBox RequestDescription;
        protected ITTTabPage TabPagePrediagnosis;
        protected ITTTextBox PreDiagnosis;
        protected ITTTabPage TabPageDescription;
        protected ITTTextBox Description;
        protected ITTTextBox MaterialResponsible;
        protected ITTTextBox SendenMaterial;
        protected ITTTextBox tttextbox2;
        protected ITTTextBox PatientAge;
        protected ITTTextBox tttextbox3;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox RejectReason;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel7;
        protected ITTCheckBox EmergencyCheckBox;
        protected ITTGrid GridDiagnosis;
        protected ITTCheckBoxColumn EpisodeAddToHistory;
        protected ITTListBoxColumn EpisodeDiagnose;
        protected ITTEnumComboBoxColumn EpisodeDiagnoseType;
        protected ITTCheckBoxColumn EpisodeIsMainDiagnose;
        protected ITTListBoxColumn EpisodeResponsibleUser;
        protected ITTDateTimePickerColumn EpisodeDiagnoseDate;
        protected ITTTextBoxColumn EntryActionType;
        protected ITTObjectListBox RequestDoctor;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTDateTimePicker ActionDate;
        protected ITTLabel ttlabel15;
        protected ITTObjectListBox PatientRoom;
        protected ITTLabel ttlabel10;
        protected ITTLabel ttlabel9;
        protected ITTObjectListBox PatientClinic;
        protected ITTEnumComboBox PatientSexEnum;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel13;
        protected ITTTabControl TabTests;
        protected ITTTabPage TabPageTests;
        protected ITTGrid grdGeneticTests;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTTextBoxColumn TestAmount;
        protected ITTTabPage TabPageMaterial;
        protected ITTGrid GridGeneticMaterials;
        protected ITTDateTimePickerColumn MACTIONDATE;
        protected ITTListBoxColumn MATERIAL;
        protected ITTTextBoxColumn Barcode;
        protected ITTTextBoxColumn AMOUNT;
        protected ITTTextBoxColumn UBBCODE;
        protected ITTTabPage TabPageEquipments;
        protected ITTGrid GridEquipments;
        protected ITTListBoxColumn Equipment;
        override protected void InitializeControls()
        {
            RepeatReason = (ITTObjectListBox)AddControl(new Guid("da70687b-501d-4bbf-93aa-32bb9f965c7e"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("9fc078bb-4f65-4116-a2ef-15aa13279bee"));
            ReportRTF = (ITTRichTextBoxControl)AddControl(new Guid("ca476050-0b9a-4e8e-98d8-372a203fce2a"));
            ttlabel12 = (ITTLabel)AddControl(new Guid("194c7e8a-505f-4f89-b591-52428542fcd2"));
            TestToStudyTTListBox = (ITTObjectListBox)AddControl(new Guid("f2c55f2f-eef9-4713-9951-3c06eb00b92f"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f0e7ac8d-fdda-46cc-a90b-70b0fe0633d5"));
            TabTextInfos = (ITTTabControl)AddControl(new Guid("15bd21c4-7cbb-4501-98fe-d5453d8a8662"));
            TabPageRequestDesc = (ITTTabPage)AddControl(new Guid("3f12caac-70a1-4aad-909a-01bb33f05570"));
            RequestDescription = (ITTTextBox)AddControl(new Guid("369f984b-946a-4970-9ffe-964fcce4680e"));
            TabPagePrediagnosis = (ITTTabPage)AddControl(new Guid("a6b6e5c1-07c9-44b5-b5cd-37d9c6dec8a9"));
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("a2241665-3d3f-42ed-bc27-0412ce49b27f"));
            TabPageDescription = (ITTTabPage)AddControl(new Guid("028f1c70-20d7-48c4-84b6-a426bbc12d56"));
            Description = (ITTTextBox)AddControl(new Guid("4570ffeb-5e57-4158-ba08-f7438474f531"));
            MaterialResponsible = (ITTTextBox)AddControl(new Guid("1fae9b6b-187d-4f71-a37c-ab6df99dcfa6"));
            SendenMaterial = (ITTTextBox)AddControl(new Guid("1dabb44c-290a-4cf8-8b28-8a5cd0d20884"));
            tttextbox2 = (ITTTextBox)AddControl(new Guid("05c174bd-fafb-442e-a703-d8e32f56629e"));
            PatientAge = (ITTTextBox)AddControl(new Guid("56696f5a-67bf-426f-9f3b-4f0bb88f3845"));
            tttextbox3 = (ITTTextBox)AddControl(new Guid("d8648300-dce0-427c-be3b-c7cc5113a075"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("210f6cae-908f-4f5e-b50f-c6837997e03f"));
            RejectReason = (ITTObjectListBox)AddControl(new Guid("c94cf280-311b-4ce6-b21f-997836d8cb41"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("3a6702ec-c461-46d8-b582-793826b2c75a"));
            ttlabel7 = (ITTLabel)AddControl(new Guid("15fbc3f0-6168-4616-8e39-13226182003d"));
            EmergencyCheckBox = (ITTCheckBox)AddControl(new Guid("8affc9f3-2644-4d63-a423-1cbaaa0ca13e"));
            GridDiagnosis = (ITTGrid)AddControl(new Guid("beca663f-376f-4738-87ce-2e6d40b5ae5b"));
            EpisodeAddToHistory = (ITTCheckBoxColumn)AddControl(new Guid("1d05e1cf-5334-47d5-b988-3c2f3021729c"));
            EpisodeDiagnose = (ITTListBoxColumn)AddControl(new Guid("0577b309-6ec9-4247-b845-8119bee0444d"));
            EpisodeDiagnoseType = (ITTEnumComboBoxColumn)AddControl(new Guid("c1f6f7c2-4ffd-40c1-afbb-7bbdbb070df8"));
            EpisodeIsMainDiagnose = (ITTCheckBoxColumn)AddControl(new Guid("a784d379-e600-4741-8ca5-783c4c5da49e"));
            EpisodeResponsibleUser = (ITTListBoxColumn)AddControl(new Guid("9a6ee548-e0ae-4c8b-98e9-2b52e3d66c1d"));
            EpisodeDiagnoseDate = (ITTDateTimePickerColumn)AddControl(new Guid("3c05a351-be17-471e-a8e7-474a87d90d14"));
            EntryActionType = (ITTTextBoxColumn)AddControl(new Guid("37417c93-03bc-45e3-9060-156be5b68035"));
            RequestDoctor = (ITTObjectListBox)AddControl(new Guid("c190a334-29c6-4b70-9a35-808ec94dd277"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ae705a47-b807-4109-94e3-9b2bdf35828b"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("d7cb5215-8edd-414f-a2d7-62d2d573a98a"));
            ActionDate = (ITTDateTimePicker)AddControl(new Guid("406ab16a-4fa9-421a-a346-e2d1e7ca296a"));
            ttlabel15 = (ITTLabel)AddControl(new Guid("06087f5a-2857-40ff-bd3e-62a26735a5bf"));
            PatientRoom = (ITTObjectListBox)AddControl(new Guid("745a38b3-1262-43fe-b1ba-579b70790da8"));
            ttlabel10 = (ITTLabel)AddControl(new Guid("cc4751ec-a602-4198-9bf4-5ef535c31214"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("9a0fda04-278d-41eb-acd3-ecc7d500a520"));
            PatientClinic = (ITTObjectListBox)AddControl(new Guid("95130ee3-b878-4a3a-928c-9c8a164bedef"));
            PatientSexEnum = (ITTEnumComboBox)AddControl(new Guid("e6cdc5b5-f216-4df5-bebb-bf8f56ea7b02"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("7be6c5df-535f-4b0b-944f-466b2a11bf0d"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("81e02fe6-0df3-4767-b1af-c69dd95cd568"));
            ttlabel13 = (ITTLabel)AddControl(new Guid("7816603e-7328-46df-829f-6187f9d9b8cf"));
            TabTests = (ITTTabControl)AddControl(new Guid("5b54bef4-5c16-41ad-9955-f10fd51f3b08"));
            TabPageTests = (ITTTabPage)AddControl(new Guid("ddc802d8-fcc2-4c67-a216-8a117a4ff66d"));
            grdGeneticTests = (ITTGrid)AddControl(new Guid("60ade993-c58d-47bd-9b6e-3599bea65ed3"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("897fcc13-cc19-4982-90a2-d53e9b9fe536"));
            TestAmount = (ITTTextBoxColumn)AddControl(new Guid("df8813ea-a8a0-4861-9664-54490500db75"));
            TabPageMaterial = (ITTTabPage)AddControl(new Guid("7dec1614-06aa-4142-bf0a-dcfd42b3c5bf"));
            GridGeneticMaterials = (ITTGrid)AddControl(new Guid("5f1066d2-46a4-47da-930a-88e4b2f2a333"));
            MACTIONDATE = (ITTDateTimePickerColumn)AddControl(new Guid("a05e7672-ff6d-434b-88f6-c8460ebf79a8"));
            MATERIAL = (ITTListBoxColumn)AddControl(new Guid("a7d90812-bf2a-49fd-85ff-1f301b16baa5"));
            Barcode = (ITTTextBoxColumn)AddControl(new Guid("975ff6ca-1925-451d-9e0b-b0815ed38d77"));
            AMOUNT = (ITTTextBoxColumn)AddControl(new Guid("3adf02a8-d142-471a-863b-3ad165436541"));
            UBBCODE = (ITTTextBoxColumn)AddControl(new Guid("0cfa5568-2185-48f8-94bc-b1b682ace9f0"));
            TabPageEquipments = (ITTTabPage)AddControl(new Guid("629d75b8-8d0e-410f-91c9-ddf3b9885fd2"));
            GridEquipments = (ITTGrid)AddControl(new Guid("756a83ce-5623-4f68-ad8e-30deced37d71"));
            Equipment = (ITTListBoxColumn)AddControl(new Guid("a08d891c-54ae-40e0-8749-d932b91725db"));
            base.InitializeControls();
        }

        public GeneticRejectedForm() : base("GENETIC", "GeneticRejectedForm")
        {
        }

        protected GeneticRejectedForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}