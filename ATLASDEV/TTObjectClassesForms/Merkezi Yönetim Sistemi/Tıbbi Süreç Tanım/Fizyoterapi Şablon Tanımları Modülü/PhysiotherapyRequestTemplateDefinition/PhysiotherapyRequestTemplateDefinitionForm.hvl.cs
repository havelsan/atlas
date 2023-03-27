
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
    /// Fizyoterapi Şablonları
    /// </summary>
    public partial class PhysiotherapyRequestTemplateDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Fizyoterapi Şablon Tanımları
    /// </summary>
        protected TTObjectClasses.PhysiotherapyRequestTemplateDefinition _PhysiotherapyRequestTemplateDefinition
        {
            get { return (TTObjectClasses.PhysiotherapyRequestTemplateDefinition)_ttObject; }
        }

        protected ITTLabel labelResUser;
        protected ITTObjectListBox ResUser;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel ttlabel4;
        protected ITTGrid Physiotherapies;
        protected ITTListBoxColumn ProcedureObject;
        protected ITTListBoxColumn TreatmentDiagnosisUnit;
        protected ITTTextBoxColumn ApplicationArea;
        protected ITTTextBoxColumn Amount;
        protected ITTTextBoxColumn Duration;
        override protected void InitializeControls()
        {
            labelResUser = (ITTLabel)AddControl(new Guid("55593a8d-52dd-4076-aa09-0be439f20aac"));
            ResUser = (ITTObjectListBox)AddControl(new Guid("c39df719-d278-4a18-a28e-87cae6199768"));
            labelName = (ITTLabel)AddControl(new Guid("df0a6b8a-2a97-472a-9864-0490c3015ec0"));
            Name = (ITTTextBox)AddControl(new Guid("21f363a3-7d91-466b-b868-e44e46b408c7"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("265e4c09-409a-41a3-a7c8-4b66a15817fc"));
            Physiotherapies = (ITTGrid)AddControl(new Guid("70591d6f-f9e8-4890-bb9d-60943de91e96"));
            ProcedureObject = (ITTListBoxColumn)AddControl(new Guid("6b5ab5a9-21c3-4113-a0f0-630b931c0954"));
            TreatmentDiagnosisUnit = (ITTListBoxColumn)AddControl(new Guid("bb3de6ab-c347-4077-be6e-fd37d209817e"));
            ApplicationArea = (ITTTextBoxColumn)AddControl(new Guid("c5b4eaf0-6a26-4996-a136-4c270ad39600"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("b498abd5-a3b4-4430-bf7c-870a7dd079e6"));
            Duration = (ITTTextBoxColumn)AddControl(new Guid("4f7999f6-2802-419b-9777-15ce6f0f8cbb"));
            base.InitializeControls();
        }

        public PhysiotherapyRequestTemplateDefinitionForm() : base("PHYSIOTHERAPYREQUESTTEMPLATEDEFINITION", "PhysiotherapyRequestTemplateDefinitionForm")
        {
        }

        protected PhysiotherapyRequestTemplateDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}