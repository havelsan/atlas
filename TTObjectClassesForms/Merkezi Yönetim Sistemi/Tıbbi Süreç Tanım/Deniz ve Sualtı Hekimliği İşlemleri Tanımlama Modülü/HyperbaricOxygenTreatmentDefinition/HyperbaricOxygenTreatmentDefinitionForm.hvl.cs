
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
    /// Deniz ve Sualtı Hekimliği İşlemleri Tanımlama
    /// </summary>
    public partial class HyperbaricOxygenTreatmentDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavi Tanımlama
    /// </summary>
        protected TTObjectClasses.HyperbaricOxygenTreatmentDefinition _HyperbaricOxygenTreatmentDefinition
        {
            get { return (TTObjectClasses.HyperbaricOxygenTreatmentDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel2;
        protected ITTLabel ttlabel1;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTTextBox ID;
        protected ITTTextBox Qref;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTGrid TreatmentUnits;
        protected ITTListBoxColumn HyperbaricOxygenTreatmentUnit0;
        protected ITTCheckBox Chargable;
        protected ITTLabel labelID;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel6;
        protected ITTGrid HyperbaricTreatmentEquipments;
        protected ITTListBoxColumn HyperbaricEquipment;
        protected ITTLabel labelQref;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("1a2b029e-5afe-43cb-a6ee-6438eadde339"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("78ec5dba-ab4d-479d-b91d-a94e14a6ef19"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("60b203f9-e47e-4fc3-8f70-5e0d1a4b6233"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("721f03d4-b6b6-40b1-ac1b-702fc55c6941"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("9e28a7bf-993c-4306-85a5-184174aeea35"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("6dae3316-f5e6-4329-b743-6bc4d1b445f8"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("108495de-b248-419a-bc0f-c5f8feae3193"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("ff24c4e1-2989-4ca6-a0cf-7d73659d6a21"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6aadf817-1e92-497b-866e-6d47fdc94b7f"));
            labelName = (ITTLabel)AddControl(new Guid("02394ed7-e907-41ef-86ee-1d4e3c84f62b"));
            Name = (ITTTextBox)AddControl(new Guid("46227e34-8d07-4cd6-8810-bdc7c7e018f1"));
            EnglishName = (ITTTextBox)AddControl(new Guid("f8f40167-3cb6-4a4f-b177-54e05a09a161"));
            Description = (ITTTextBox)AddControl(new Guid("4cdad1b3-0aba-43f1-b8a8-993854246803"));
            Code = (ITTTextBox)AddControl(new Guid("a122efbf-3c36-4c2a-ad85-bbf41a48ff9c"));
            ID = (ITTTextBox)AddControl(new Guid("5b4c038f-065c-4528-95ff-9199feda652b"));
            Qref = (ITTTextBox)AddControl(new Guid("963ef589-63f9-44e0-9f52-ed9a3aaa64e3"));
            IsActive = (ITTCheckBox)AddControl(new Guid("9d9f701d-fba5-4521-8f53-4f290152c0ac"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("e586dc34-406a-43aa-ae2a-b0aa8a776901"));
            labelDescription = (ITTLabel)AddControl(new Guid("c1124968-d153-4309-a73a-662771d8e7c4"));
            labelCode = (ITTLabel)AddControl(new Guid("eb399ad4-a77e-4f97-ad68-03e48287d3d8"));
            TreatmentUnits = (ITTGrid)AddControl(new Guid("efdc9a84-b699-4bbd-bb59-d5849bb48eaf"));
            HyperbaricOxygenTreatmentUnit0 = (ITTListBoxColumn)AddControl(new Guid("71757b02-e7a3-494b-95f2-df23bc9a2ad9"));
            Chargable = (ITTCheckBox)AddControl(new Guid("d6d76d66-e634-41a6-a18b-2964e423f21d"));
            labelID = (ITTLabel)AddControl(new Guid("5900cfb5-1a49-4c9a-9b1e-3adb76014a4e"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("88e7b306-28a2-48be-b051-db8cf43b7898"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("de4d1c60-31b9-4b7a-81a5-24946863b3c7"));
            HyperbaricTreatmentEquipments = (ITTGrid)AddControl(new Guid("e5351c57-bad2-44df-8c30-5ed88b8321a0"));
            HyperbaricEquipment = (ITTListBoxColumn)AddControl(new Guid("d2bad53e-9476-474f-981f-5db36c3e4556"));
            labelQref = (ITTLabel)AddControl(new Guid("11bb3522-1291-4d2b-a3dd-12af25a9ed7a"));
            base.InitializeControls();
        }

        public HyperbaricOxygenTreatmentDefinitionForm() : base("HYPERBARICOXYGENTREATMENTDEFINITION", "HyperbaricOxygenTreatmentDefinitionForm")
        {
        }

        protected HyperbaricOxygenTreatmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}