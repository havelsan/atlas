
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
    public partial class ProcedureRequestDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Hizmet İstek Ekranları Tanımı
    /// </summary>
        protected TTObjectClasses.ProcedureRequestFormDefinition _ProcedureRequestFormDefinition
        {
            get { return (TTObjectClasses.ProcedureRequestFormDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTGrid RequestUnitsOfProcedureForm;
        protected ITTListBoxColumn ResSectionRequestUnitOfProcedureForm;
        protected ITTLabel labelObservationUnit;
        protected ITTObjectListBox ObservationUnit;
        protected ITTGrid FormCategory;
        protected ITTTextBoxColumn CategorySiraNo;
        protected ITTTextBoxColumn CodeProcedureRequestCategoryDefinition;
        protected ITTTextBoxColumn CategoryNameProcedureRequestCategoryDefinition;
        protected ITTCheckBoxColumn CategoryDefinitionIsPassiveNow;
        protected ITTTextBoxColumn CategoryDefinitionReasonForPassive;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Code;
        protected ITTTextBox tttextbox1;
        protected ITTLabel labelCode;
        protected ITTLabel ttlabel2;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("22424ae0-e91d-4386-bf38-03370c972eef"));
            RequestUnitsOfProcedureForm = (ITTGrid)AddControl(new Guid("37f4a97b-b8c5-4665-9eb4-dbb7f0f6e13a"));
            ResSectionRequestUnitOfProcedureForm = (ITTListBoxColumn)AddControl(new Guid("4b7bc05b-ea26-4a80-b8b0-ce2851d48989"));
            labelObservationUnit = (ITTLabel)AddControl(new Guid("d976d559-0dcc-4af5-8190-7d676f978f36"));
            ObservationUnit = (ITTObjectListBox)AddControl(new Guid("57f8b6a8-6f65-4fbd-bd60-afe7da837a20"));
            FormCategory = (ITTGrid)AddControl(new Guid("356fb9f8-f701-45ea-9baa-500caa5c980e"));
            CategorySiraNo = (ITTTextBoxColumn)AddControl(new Guid("9f17b2cc-4ac1-4aa1-9937-26f85062f970"));
            CodeProcedureRequestCategoryDefinition = (ITTTextBoxColumn)AddControl(new Guid("9a692958-eb57-44f5-8038-4e7245441f8e"));
            CategoryNameProcedureRequestCategoryDefinition = (ITTTextBoxColumn)AddControl(new Guid("64aae34c-e9fd-4f82-a327-f0f1c98227ee"));
            CategoryDefinitionIsPassiveNow = (ITTCheckBoxColumn)AddControl(new Guid("297f9ea1-9941-42fb-85ac-38df2b009973"));
            CategoryDefinitionReasonForPassive = (ITTTextBoxColumn)AddControl(new Guid("4ade4a15-b17b-4ed3-ae92-075d927b2968"));
            labelName = (ITTLabel)AddControl(new Guid("ee3b8387-15ec-4891-8da1-e657ce89c825"));
            Name = (ITTTextBox)AddControl(new Guid("e59ac50b-11fd-4be8-877a-7babdcca4c1d"));
            Code = (ITTTextBox)AddControl(new Guid("e8304a06-db7f-44f0-be25-0ccf8d6e1df7"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("24791ffb-565e-440f-80ed-c0f5fa45edb2"));
            labelCode = (ITTLabel)AddControl(new Guid("e98edb58-66c9-4963-bb93-c51d42099fb0"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("87024932-d3fa-40d5-8c2d-9657d7688675"));
            base.InitializeControls();
        }

        public ProcedureRequestDefinitionForm() : base("PROCEDUREREQUESTFORMDEFINITION", "ProcedureRequestDefinitionForm")
        {
        }

        protected ProcedureRequestDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}