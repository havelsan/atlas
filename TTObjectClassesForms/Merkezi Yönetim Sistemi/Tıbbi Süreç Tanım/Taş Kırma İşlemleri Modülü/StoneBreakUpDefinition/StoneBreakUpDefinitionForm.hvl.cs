
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
    /// Taş Kırma İşlemleri Modülü
    /// </summary>
    public partial class StoneBreakUpDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Taş Kırma işlemleri Tanımları
    /// </summary>
        protected TTObjectClasses.StoneBreakUpDefinition _StoneBreakUpDefinition
        {
            get { return (TTObjectClasses.StoneBreakUpDefinition)_ttObject; }
        }

        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTTextBox Seance;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTLabel lableSeans;
        override protected void InitializeControls()
        {
            ttlabel3 = (ITTLabel)AddControl(new Guid("ea2f1b8f-84ba-495e-9535-2f5c0e5ab2d4"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("e2e8caa5-09a5-4980-b107-ea1b78a029fa"));
            labelQref = (ITTLabel)AddControl(new Guid("a3086d91-9a64-4335-b9b5-fda650540903"));
            Qref = (ITTTextBox)AddControl(new Guid("4fe516e5-badd-47dc-9cbd-47a7a6d0eede"));
            Name = (ITTTextBox)AddControl(new Guid("8dc1c367-36c2-4132-bb2e-dc99440d6879"));
            EnglishName = (ITTTextBox)AddControl(new Guid("124f56cd-cdfe-4e70-a631-c319863fa344"));
            Description = (ITTTextBox)AddControl(new Guid("542dddcf-b0df-4110-881b-012863688296"));
            Code = (ITTTextBox)AddControl(new Guid("c1294e36-b2bd-40d1-92c2-debd1c851c98"));
            Seance = (ITTTextBox)AddControl(new Guid("eeff75fe-d69e-46c0-a0a5-5b1ad824591d"));
            labelName = (ITTLabel)AddControl(new Guid("fc755fe6-c90b-4aa6-bc5c-fb0e3e1468ad"));
            IsActive = (ITTCheckBox)AddControl(new Guid("4664ed9e-1079-4538-8482-7a8623ef1a28"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("ee8d287f-127f-4ec6-8358-6e1c5260bde3"));
            labelDescription = (ITTLabel)AddControl(new Guid("7084e671-cbb6-46a9-824b-ceb9b4c0fe85"));
            labelCode = (ITTLabel)AddControl(new Guid("03a1069d-b034-42c4-9ccc-2e4d612534bd"));
            lableSeans = (ITTLabel)AddControl(new Guid("5ad35fa6-8ad2-4684-a35e-b121d0d2a0bf"));
            base.InitializeControls();
        }

        public StoneBreakUpDefinitionForm() : base("STONEBREAKUPDEFINITION", "StoneBreakUpDefinitionForm")
        {
        }

        protected StoneBreakUpDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}