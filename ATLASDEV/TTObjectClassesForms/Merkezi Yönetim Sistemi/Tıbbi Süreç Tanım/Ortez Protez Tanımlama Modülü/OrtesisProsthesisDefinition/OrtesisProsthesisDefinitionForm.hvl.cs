
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
    /// Ortez Protez Tanımlama
    /// </summary>
    public partial class OrtesisProsthesisDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Ortez Protez Tanımlama
    /// </summary>
        protected TTObjectClasses.OrtesisProsthesisDefinition _OrtesisProsthesisDefinition
        {
            get { return (TTObjectClasses.OrtesisProsthesisDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel labelWarranty;
        protected ITTTextBox Warranty;
        protected ITTTextBox DefaultAmount;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTCheckBox SideSelect;
        protected ITTLabel labelDefaultAmount;
        protected ITTEnumComboBox HCType;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel2;
        protected ITTGrid MaterialsGrid;
        protected ITTListBoxColumn MaterialName;
        protected ITTTextBoxColumn Amount;
        protected ITTLabel ttlabel1;
        protected ITTLabel ttlabel4;
        protected ITTLabel labelQref;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("c7c3f093-31fd-4b6f-a24c-bd02e7e8f133"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("12792518-292e-4dce-a91a-b51108055762"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("2a863410-3d69-4623-93f7-b89849bc7150"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("e3d5efbc-7fb5-4bd6-9014-ef3945cfff30"));
            labelWarranty = (ITTLabel)AddControl(new Guid("cd590197-b13c-48b6-a5d7-bb72e0711dc1"));
            Warranty = (ITTTextBox)AddControl(new Guid("12f85eaa-c1bd-41f5-aff1-f6c51ba4417d"));
            DefaultAmount = (ITTTextBox)AddControl(new Guid("995c58db-f7a3-454a-8365-687bf30f9b9c"));
            Qref = (ITTTextBox)AddControl(new Guid("a55e5d22-558a-4964-a6a4-75e499181a3d"));
            Name = (ITTTextBox)AddControl(new Guid("61f2a13f-7b62-4534-89eb-c7f2966683cb"));
            EnglishName = (ITTTextBox)AddControl(new Guid("ecbdac97-b297-4dff-aaf4-6947df529bb7"));
            Description = (ITTTextBox)AddControl(new Guid("eba7e5f8-bef8-4d71-82a2-15e97a53e5c6"));
            Code = (ITTTextBox)AddControl(new Guid("b1fbc3a2-0d6f-45c8-8846-ef698847e24b"));
            SideSelect = (ITTCheckBox)AddControl(new Guid("bb8a51ab-28f1-4381-b337-cce90f2ea231"));
            labelDefaultAmount = (ITTLabel)AddControl(new Guid("a0d66477-3286-4b74-b909-11a49cbdc59e"));
            HCType = (ITTEnumComboBox)AddControl(new Guid("a476cf76-a0ae-41fb-8227-de37de08e603"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("696b3128-f1ab-4a18-8642-c819d12cf792"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("6b927464-ac5d-4f03-b2d0-352a83c2b8a3"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("6a53f6e9-fa65-4724-a29a-041901dfce7a"));
            MaterialsGrid = (ITTGrid)AddControl(new Guid("5226afc1-685a-4476-b4f8-e2e34dba2c69"));
            MaterialName = (ITTListBoxColumn)AddControl(new Guid("32a87b9d-b6cd-42e4-bdbe-33d44bfa5902"));
            Amount = (ITTTextBoxColumn)AddControl(new Guid("797fd6c7-1b48-4af5-a509-fcba3b0087f4"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("9ebb819b-8c74-4088-bb8a-639d7aea43bb"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("2579fb1c-fa58-40a0-b40a-ab771b025549"));
            labelQref = (ITTLabel)AddControl(new Guid("5ce3f1a0-b697-4cbc-ac41-be2947af66ed"));
            labelName = (ITTLabel)AddControl(new Guid("6ec32ebc-5b61-460b-be3b-4339bb88909c"));
            IsActive = (ITTCheckBox)AddControl(new Guid("f71a9d0d-0f01-4e82-9e80-48386f6bf8b2"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("e5a53948-a921-4918-b5f6-0b3a39988591"));
            labelDescription = (ITTLabel)AddControl(new Guid("7d05509e-f2e5-446f-a891-bf7a3df68ab1"));
            labelCode = (ITTLabel)AddControl(new Guid("0120f30a-0f45-4a42-b41b-aca7bb1ab2e5"));
            base.InitializeControls();
        }

        public OrtesisProsthesisDefinitionForm() : base("ORTESISPROSTHESISDEFINITION", "OrtesisProsthesisDefinitionForm")
        {
        }

        protected OrtesisProsthesisDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}