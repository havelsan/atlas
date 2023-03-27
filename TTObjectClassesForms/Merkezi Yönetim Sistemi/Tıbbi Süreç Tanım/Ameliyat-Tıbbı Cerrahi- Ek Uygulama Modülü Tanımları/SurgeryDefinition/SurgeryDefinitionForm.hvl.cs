
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
    /// Ameliyat-Tıbbı Cerrahi- Ek Uygulama Tanımlama
    /// </summary>
    public partial class SurgeryDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ameliyat-Tıbbı Cerrahi- Ek Uygulama Tanımlama
    /// </summary>
        protected TTObjectClasses.SurgeryDefinition _SurgeryDefinition
        {
            get { return (TTObjectClasses.SurgeryDefinition)_ttObject; }
        }

        protected ITTLabel labelSurgeryDuration;
        protected ITTTextBox SurgeryDuration;
        protected ITTCheckBox IsNeedKvcScore;
        protected ITTCheckBox IsAdditionalApplication;
        protected ITTCheckBox IsManipulation;
        protected ITTCheckBox IsSurgery;
        protected ITTLabel labelManipulationStartState;
        protected ITTEnumComboBox ManipulationStartState;
        protected ITTLabel labelManipulationFormName;
        protected ITTEnumComboBox ManipulationFormName;
        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTCheckBox IsDescriptionNeeded;
        protected ITTLabel labelPhysiotherapyFormName;
        protected ITTEnumComboBox PhysiotherapyFormName;
        protected ITTLabel labelResource;
        protected ITTObjectListBox Resource;
        protected ITTCheckBox IsNeedEuroScore;
        protected ITTLabel lblSUTGroup;
        protected ITTEnumComboBox SUTGroup;
        protected ITTTabControl tttabcontrol1;
        protected ITTTabPage tabConcepts;
        protected ITTGrid DefinitionConcepts;
        protected ITTTextBoxColumn ConceptDefinitionConcept;
        protected ITTTabPage tabCodelessMaterials;
        protected ITTGrid CodelessMaterialsGrid;
        protected ITTListBoxColumn SurgeryCodelessMaterial;
        protected ITTTabPage tabBranches;
        protected ITTGrid Branches;
        protected ITTListBoxColumn SpecialityDefinitionSurgeryBranchDefinition;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTCheckBox InVitroFertilizationProcess;
        protected ITTCheckBox MedulaProvisionNecessity;
        protected ITTCheckBox ReportIsRequired;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTCheckBox ttcheckbox1;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox SurgeryPointGroup;
        protected ITTLabel labelSurgeyProcedureType;
        protected ITTEnumComboBox SurgeyProcedureType;
        protected ITTCheckBox OnamFormuIste;
        protected ITTEnumComboBox GILGroup;
        protected ITTLabel lblGILGroup;
        override protected void InitializeControls()
        {
            labelSurgeryDuration = (ITTLabel)AddControl(new Guid("3b13f51d-a701-41a4-9e50-75e1cecb0cff"));
            SurgeryDuration = (ITTTextBox)AddControl(new Guid("60031c20-d5c4-45f6-9e14-04ed158cebf4"));
            IsNeedKvcScore = (ITTCheckBox)AddControl(new Guid("9bc22b13-018f-4733-ba52-4db122c3c884"));
            IsAdditionalApplication = (ITTCheckBox)AddControl(new Guid("6b0945ca-6bba-4609-9d98-38483013ce66"));
            IsManipulation = (ITTCheckBox)AddControl(new Guid("a6cb213d-c96c-459e-91c4-82b18cde6ec0"));
            IsSurgery = (ITTCheckBox)AddControl(new Guid("f186b7e8-64a8-4ca2-ac99-1b68b1b607eb"));
            labelManipulationStartState = (ITTLabel)AddControl(new Guid("81a9ec95-74cf-4666-adfc-bb55db35e66c"));
            ManipulationStartState = (ITTEnumComboBox)AddControl(new Guid("2b2a8268-a3bc-4a8b-9a41-5de8115467e0"));
            labelManipulationFormName = (ITTLabel)AddControl(new Guid("a149b995-9cff-4bba-a446-b143c2d0981d"));
            ManipulationFormName = (ITTEnumComboBox)AddControl(new Guid("76d62135-d507-4499-8b28-5ea7a3511622"));
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("ee41c205-a099-4953-a04e-0f6394dd0d92"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("b07067df-7394-4a2d-a042-bb5e2e378027"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("c842327e-d028-4162-9ead-f3f5c0bfd4cd"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("8e0109dd-f42d-43d0-a2fb-caa7536152e1"));
            IsDescriptionNeeded = (ITTCheckBox)AddControl(new Guid("9e4c212c-dec9-4cef-8479-9080fc03230f"));
            labelPhysiotherapyFormName = (ITTLabel)AddControl(new Guid("5c6c6ce0-90d0-4125-8cf2-ffebe1f3318f"));
            PhysiotherapyFormName = (ITTEnumComboBox)AddControl(new Guid("ef257404-ff5f-4f35-9a9d-3de63fff5e2e"));
            labelResource = (ITTLabel)AddControl(new Guid("fe3e37fb-db9d-4d3a-8172-04fbbf636db7"));
            Resource = (ITTObjectListBox)AddControl(new Guid("e2730290-38cb-460a-9fb2-328d26d9fd9e"));
            IsNeedEuroScore = (ITTCheckBox)AddControl(new Guid("25a479f8-340e-450f-94ce-7357f4f65dcb"));
            lblSUTGroup = (ITTLabel)AddControl(new Guid("dd5b7b21-4e73-428e-b9b2-1d8b769b2212"));
            SUTGroup = (ITTEnumComboBox)AddControl(new Guid("e8f557ea-7d5b-4627-9f6e-4bc8bb9946df"));
            tttabcontrol1 = (ITTTabControl)AddControl(new Guid("e5fa6c70-e34a-489f-88ee-6ce642975cb5"));
            tabConcepts = (ITTTabPage)AddControl(new Guid("19b9c28f-d7e4-4b81-984f-9b0ea89ccab1"));
            DefinitionConcepts = (ITTGrid)AddControl(new Guid("7422e133-2c1d-4790-8345-78d700c03119"));
            ConceptDefinitionConcept = (ITTTextBoxColumn)AddControl(new Guid("14498e3f-f5e6-403a-b5df-edcb629d3a9d"));
            tabCodelessMaterials = (ITTTabPage)AddControl(new Guid("0a781839-1969-47f9-bbcd-0bf5345b0683"));
            CodelessMaterialsGrid = (ITTGrid)AddControl(new Guid("79ed4919-71cb-4dcc-8035-af7fa07cd350"));
            SurgeryCodelessMaterial = (ITTListBoxColumn)AddControl(new Guid("2093fd78-df59-4498-82f7-fe82f3b9f67d"));
            tabBranches = (ITTTabPage)AddControl(new Guid("dfb23eb7-5ec2-4ac5-bca0-3f814258ae90"));
            Branches = (ITTGrid)AddControl(new Guid("c5e63fc7-5704-4103-8f93-16e4e289efed"));
            SpecialityDefinitionSurgeryBranchDefinition = (ITTListBoxColumn)AddControl(new Guid("9b5f010c-ddcc-4189-96f1-73fe7a7d7a3f"));
            Qref = (ITTTextBox)AddControl(new Guid("989121e1-f1de-40ef-9967-e83fc09b4d36"));
            Name = (ITTTextBox)AddControl(new Guid("33cd7621-85e5-40d8-a48e-404dc4f02290"));
            EnglishName = (ITTTextBox)AddControl(new Guid("75ae7697-6b94-470d-8566-52e74e8518da"));
            Description = (ITTTextBox)AddControl(new Guid("8475eecd-9591-4a24-80b3-77feb6aec95f"));
            Code = (ITTTextBox)AddControl(new Guid("f72a8ecd-3479-41df-9d4a-5d7329503359"));
            InVitroFertilizationProcess = (ITTCheckBox)AddControl(new Guid("7832b301-ce6f-4924-85a0-60a988205524"));
            MedulaProvisionNecessity = (ITTCheckBox)AddControl(new Guid("0647e4bc-697d-438d-8cb7-bbb5120a7abb"));
            ReportIsRequired = (ITTCheckBox)AddControl(new Guid("c8a4bb73-fc10-4733-9713-474f90247647"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("25972810-27cc-4f83-8ce3-c2121e8e9097"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("a3e17ca5-9f4b-4198-9d22-abacacc87d23"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("b3eb0c25-cb91-42d0-bdef-8187eae6f7a6"));
            labelQref = (ITTLabel)AddControl(new Guid("30c4b1e0-5c26-401a-8cdf-b98ab45a3d01"));
            labelName = (ITTLabel)AddControl(new Guid("6db90dd0-4df9-43f3-b3b1-6c1d4a6f0a3f"));
            IsActive = (ITTCheckBox)AddControl(new Guid("3ef3ef84-c602-44ac-8b76-b349a115d976"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("7651fd55-5fa0-45f7-a485-7d50fe1756fd"));
            labelDescription = (ITTLabel)AddControl(new Guid("2d97950b-7afc-4bc8-924a-dfac56d2c844"));
            labelCode = (ITTLabel)AddControl(new Guid("2a670423-8828-42b0-9557-c619807013e2"));
            ttcheckbox1 = (ITTCheckBox)AddControl(new Guid("4e1c5db6-d84c-4914-80aa-477c8976c3cf"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("a60cae2f-667e-4326-8e7e-03214b590d22"));
            SurgeryPointGroup = (ITTEnumComboBox)AddControl(new Guid("107db0a9-f7c3-4d31-a81a-dc359a14d0b3"));
            labelSurgeyProcedureType = (ITTLabel)AddControl(new Guid("dca1842d-d3c3-4e43-a6fa-67a16fdaaa8f"));
            SurgeyProcedureType = (ITTEnumComboBox)AddControl(new Guid("20bd4956-a3a4-4369-881f-d7e8586694be"));
            OnamFormuIste = (ITTCheckBox)AddControl(new Guid("124fa7b6-a53a-4d92-8174-47912f681e71"));
            GILGroup = (ITTEnumComboBox)AddControl(new Guid("2986dba9-f69d-430c-85fc-0a044b204030"));
            lblGILGroup = (ITTLabel)AddControl(new Guid("02e37fc4-fb0e-497a-a8d6-ebd0a37181d5"));
            base.InitializeControls();
        }

        public SurgeryDefinitionForm() : base("SURGERYDEFINITION", "SurgeryDefinitionForm")
        {
        }

        protected SurgeryDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}