
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
    public partial class PostpartumFollowUpForm : TTForm
    {
    /// <summary>
    /// Lohusa İzlem
    /// </summary>
        protected TTObjectClasses.PostpartumFollowUp _PostpartumFollowUp
        {
            get { return (TTObjectClasses.PostpartumFollowUp)_ttObject; }
        }

        protected ITTGrid WomanHealthOperations;
        protected ITTListBoxColumn SKRSWomanHealthOperationsWomanHealthOperations;
        protected ITTGrid DangerSigns;
        protected ITTListBoxColumn SKRSDangerSignsPostpartumDangerSigns;
        protected ITTGrid ComplicationDiagnosis;
        protected ITTListBoxColumn SKRSICD10ComplicationDiagnosis;
        protected ITTLabel labelCongenitalAnomaliesPresence;
        protected ITTObjectListBox CongenitalAnomalies;
        protected ITTLabel labelUterusInvolution;
        protected ITTObjectListBox UterusInvolution;
        protected ITTLabel labelPostpartumDepression;
        protected ITTObjectListBox PostpartumDepression;
        protected ITTLabel labelVitaminDSupplements;
        protected ITTObjectListBox VitaminDSupplements;
        protected ITTLabel labelIronLogisticsAndSupplement;
        protected ITTObjectListBox IronLogisticsAndSupplement;
        protected ITTLabel labelWhichPostpartumFollowUp;
        protected ITTObjectListBox WhichPostpartumFollowUp;
        protected ITTLabel labelInformerPhone;
        protected ITTTextBox InformerPhone;
        protected ITTTextBox InformerName;
        protected ITTTextBox Hemoglobin;
        protected ITTLabel labelInformerName;
        protected ITTLabel labelHemoglobin;
        protected ITTLabel labelPregnancyDueDate;
        protected ITTDateTimePicker PregnancyDueDate;
        protected ITTLabel labelWomanHealth;
        protected ITTLabel ttlabel8;
        protected ITTLabel ttlabel9;
        override protected void InitializeControls()
        {
            WomanHealthOperations = (ITTGrid)AddControl(new Guid("650071b8-4447-42d3-8c4b-dff89c02f825"));
            SKRSWomanHealthOperationsWomanHealthOperations = (ITTListBoxColumn)AddControl(new Guid("8a331a17-e1d1-4dec-8388-9a6f9499ff0f"));
            DangerSigns = (ITTGrid)AddControl(new Guid("11871ae0-0f4c-4a3e-99c9-03c58959e880"));
            SKRSDangerSignsPostpartumDangerSigns = (ITTListBoxColumn)AddControl(new Guid("f26e0e2d-09a6-4267-a19f-21a50ab3006c"));
            ComplicationDiagnosis = (ITTGrid)AddControl(new Guid("fb7e4881-ce0e-42c3-9a1d-6797ce072c38"));
            SKRSICD10ComplicationDiagnosis = (ITTListBoxColumn)AddControl(new Guid("166fadb4-20ab-4c8f-bad7-ed6ceec125e4"));
            labelCongenitalAnomaliesPresence = (ITTLabel)AddControl(new Guid("7c635e87-1935-468b-8232-7cf6acccfc0b"));
            CongenitalAnomalies = (ITTObjectListBox)AddControl(new Guid("00978d15-19a2-42bd-916f-f1ca1440db73"));
            labelUterusInvolution = (ITTLabel)AddControl(new Guid("8c50ce06-15dc-4507-af17-3ab08845c859"));
            UterusInvolution = (ITTObjectListBox)AddControl(new Guid("4272da2e-3372-4cd1-a0ec-1b4bbec022f2"));
            labelPostpartumDepression = (ITTLabel)AddControl(new Guid("fe43434c-981b-4954-9874-1e2fb83d4db2"));
            PostpartumDepression = (ITTObjectListBox)AddControl(new Guid("1ef37605-bb3f-4e21-8531-f0e0a8e1e7f1"));
            labelVitaminDSupplements = (ITTLabel)AddControl(new Guid("0603e173-aec3-4819-97b4-b2c24bb285ed"));
            VitaminDSupplements = (ITTObjectListBox)AddControl(new Guid("acdf54ca-5d50-45f8-aa17-e273b4913cb7"));
            labelIronLogisticsAndSupplement = (ITTLabel)AddControl(new Guid("c94dec76-6b8f-4ab3-a777-43606959c293"));
            IronLogisticsAndSupplement = (ITTObjectListBox)AddControl(new Guid("71a6b09c-944a-49fe-a7f7-0a5ffd309625"));
            labelWhichPostpartumFollowUp = (ITTLabel)AddControl(new Guid("d2858b48-a548-4f45-b361-44885cdb2b7e"));
            WhichPostpartumFollowUp = (ITTObjectListBox)AddControl(new Guid("61619738-e888-428b-beb1-bd0eeb935dd1"));
            labelInformerPhone = (ITTLabel)AddControl(new Guid("d72fa576-cfbf-49c7-8196-708666ddee18"));
            InformerPhone = (ITTTextBox)AddControl(new Guid("ac16fd8e-09ad-49b6-889c-d807bcc56969"));
            InformerName = (ITTTextBox)AddControl(new Guid("0d4f65b8-8f6c-43c3-ad4c-ef8483ac7a33"));
            Hemoglobin = (ITTTextBox)AddControl(new Guid("bed32d01-5ba8-493a-84ef-45126af1cac7"));
            labelInformerName = (ITTLabel)AddControl(new Guid("4ff9239d-a949-42af-b45c-e36403c1406b"));
            labelHemoglobin = (ITTLabel)AddControl(new Guid("d4c42204-87d8-4ad2-9717-23c2d55b6c27"));
            labelPregnancyDueDate = (ITTLabel)AddControl(new Guid("5aef71ee-80bb-4ff0-8ad6-fa30cb9be1db"));
            PregnancyDueDate = (ITTDateTimePicker)AddControl(new Guid("ac9216d8-c86c-48a1-8e3b-dabba30dcbfc"));
            labelWomanHealth = (ITTLabel)AddControl(new Guid("df463e4c-dd33-4e3d-88b9-d84d9d69773b"));
            ttlabel8 = (ITTLabel)AddControl(new Guid("374a0693-8908-40be-8463-7350a918691a"));
            ttlabel9 = (ITTLabel)AddControl(new Guid("01e6defe-2b93-4ca7-badc-ef8245798bdd"));
            base.InitializeControls();
        }

        public PostpartumFollowUpForm() : base("POSTPARTUMFOLLOWUP", "PostpartumFollowUpForm")
        {
        }

        protected PostpartumFollowUpForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}