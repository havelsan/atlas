
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
    /// Malzeme Temin
    /// </summary>
    public partial class WorkStepSuppMatForm : TTForm
    {
    /// <summary>
    /// Yardımcı Atölye İş İstek
    /// </summary>
        protected TTObjectClasses.WorkStep _WorkStep
        {
            get { return (TTObjectClasses.WorkStep)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        protected ITTGrid WorkStepConsumedMaterials;
        protected ITTListBoxColumn RequestMaterial;
        protected ITTListBoxColumn RequestDistType;
        protected ITTTextBoxColumn RequestAmount;
        protected ITTTextBoxColumn SuppAmount;
        protected ITTTextBoxColumn SparePartMaterialDescription;
        protected ITTLabel labelResponsibleUser;
        protected ITTObjectListBox ResponsibleUser;
        protected ITTLabel labelWorkShop;
        protected ITTObjectListBox WorkShop;
        protected ITTLabel labelFixedAssetMaterialDefinition;
        protected ITTObjectListBox FixedAssetMaterialDefinition;
        protected ITTLabel labelSection;
        protected ITTObjectListBox Section;
        protected ITTLabel labelSenderSection;
        protected ITTObjectListBox SenderSection1;
        protected ITTLabel labelDescription;
        protected ITTTextBox Description;
        protected ITTLabel ttlabel1;
        protected ITTTextBox RequestNo;
        protected ITTLabel labelRequestNo;
        protected ITTGrid SectionRequirements;
        protected ITTTextBoxColumn StockActionID;
        protected ITTStateComboBoxColumn State;
        protected ITTLabel ttlabel4;
        protected ITTButton cmdSectionRequirement;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("25e7e217-9687-43b2-be18-9dd3416191ff"));
            WorkStepConsumedMaterials = (ITTGrid)AddControl(new Guid("fc4f7c50-cca2-4178-a72e-6042257d22cb"));
            RequestMaterial = (ITTListBoxColumn)AddControl(new Guid("6f84d7e1-9a85-4402-8386-ff6f77b8a865"));
            RequestDistType = (ITTListBoxColumn)AddControl(new Guid("5483ef35-1022-4420-ab17-0a22537d41ce"));
            RequestAmount = (ITTTextBoxColumn)AddControl(new Guid("abd1beec-fb3d-4fa0-af9a-939dbf643a53"));
            SuppAmount = (ITTTextBoxColumn)AddControl(new Guid("63327937-8c4b-4dc1-a717-3663ad374672"));
            SparePartMaterialDescription = (ITTTextBoxColumn)AddControl(new Guid("0840526f-54bd-49c3-ac18-f899bfdf2248"));
            labelResponsibleUser = (ITTLabel)AddControl(new Guid("5dfd4d89-cfe1-4431-80ed-5bb2dc10bb6a"));
            ResponsibleUser = (ITTObjectListBox)AddControl(new Guid("a05e3b44-8afe-40d8-a721-f1ae775ba2c5"));
            labelWorkShop = (ITTLabel)AddControl(new Guid("058e3db3-b0a8-4889-8db1-d4972a97fa05"));
            WorkShop = (ITTObjectListBox)AddControl(new Guid("c90a6ad5-bcb6-44a2-b345-288587b1858f"));
            labelFixedAssetMaterialDefinition = (ITTLabel)AddControl(new Guid("2cdae169-6673-4aa0-b4f3-f39569befa43"));
            FixedAssetMaterialDefinition = (ITTObjectListBox)AddControl(new Guid("21da9b4c-3095-4501-9989-065618a80c87"));
            labelSection = (ITTLabel)AddControl(new Guid("320dc986-677c-410c-ab4f-320e6aa16702"));
            Section = (ITTObjectListBox)AddControl(new Guid("c3c2a4a4-4eee-40cd-aed1-98197bc0603e"));
            labelSenderSection = (ITTLabel)AddControl(new Guid("69f2b0aa-2625-4d63-9522-2985f137846d"));
            SenderSection1 = (ITTObjectListBox)AddControl(new Guid("1183de46-47cf-426d-bf02-9ae969547112"));
            labelDescription = (ITTLabel)AddControl(new Guid("aecde049-75eb-44a9-acfe-f093d5a0bf0c"));
            Description = (ITTTextBox)AddControl(new Guid("67910fc2-44fb-4f2f-9705-1521c613007a"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("f0bae692-07ac-4fb8-888a-ba1e5aa2deea"));
            RequestNo = (ITTTextBox)AddControl(new Guid("36a8c5cb-a178-4893-8982-b3ab05554aab"));
            labelRequestNo = (ITTLabel)AddControl(new Guid("a775ab99-06c4-40f1-b781-aba2263a4a7b"));
            SectionRequirements = (ITTGrid)AddControl(new Guid("eabf4eec-3579-4ea0-9b4f-131c8e0a9128"));
            StockActionID = (ITTTextBoxColumn)AddControl(new Guid("2c073c26-4660-467b-8769-cee2a0aa808c"));
            State = (ITTStateComboBoxColumn)AddControl(new Guid("fd44f16d-acd5-4828-8aec-e7fbee265736"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("00ac0178-eed8-4b43-92e0-59f409da6ad6"));
            cmdSectionRequirement = (ITTButton)AddControl(new Guid("63ffb39c-7d1a-47dd-942c-465a1ee791c7"));
            base.InitializeControls();
        }

        public WorkStepSuppMatForm() : base("WORKSTEP", "WorkStepSuppMatForm")
        {
        }

        protected WorkStepSuppMatForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}