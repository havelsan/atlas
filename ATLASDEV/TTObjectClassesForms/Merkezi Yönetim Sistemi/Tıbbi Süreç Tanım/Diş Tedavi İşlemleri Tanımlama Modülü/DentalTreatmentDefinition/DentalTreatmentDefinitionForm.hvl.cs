
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
    /// Diş Tedavi İşlemleri Tanımları
    /// </summary>
    public partial class DentalTreatmentDefinitionForm : TerminologyManagerDefForm
    {
    /// <summary>
    /// Diş Tedavi Tanımları
    /// </summary>
        protected TTObjectClasses.DentalTreatmentDefinition _DentalTreatmentDefinition
        {
            get { return (TTObjectClasses.DentalTreatmentDefinition)_ttObject; }
        }

        protected ITTLabel labelSUTAppendix;
        protected ITTEnumComboBox SUTAppendix;
        protected ITTLabel labelMedulaProcedureType;
        protected ITTEnumComboBox MedulaProcedureType;
        protected ITTLabel labelToothNumber;
        protected ITTEnumComboBox ToothNumber;
        protected ITTLabel ttlabel1;
        protected ITTObjectListBox ProcedureTree;
        protected ITTLabel ttlabel6;
        protected ITTLabel ttlabel5;
        protected ITTLabel ttlabel3;
        protected ITTLabel ttlabel2;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTTextBox EnglishName;
        protected ITTTextBox Description;
        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelEnglishName;
        protected ITTLabel labelDescription;
        protected ITTLabel labelCode;
        protected ITTGrid Departments;
        protected ITTListBoxColumn Department0;
        protected ITTLabel labelDentalRequestType;
        protected ITTObjectListBox DentalRequestType;
        protected ITTLabel labelCategory;
        protected ITTEnumComboBox Category;
        override protected void InitializeControls()
        {
            labelSUTAppendix = (ITTLabel)AddControl(new Guid("70503904-8038-45d6-a42f-2c0292bbb04c"));
            SUTAppendix = (ITTEnumComboBox)AddControl(new Guid("e62efbc9-1bcf-4900-b9b8-b22dfb4567bb"));
            labelMedulaProcedureType = (ITTLabel)AddControl(new Guid("d4695bf8-11ce-4607-8f97-4d336e0cc5ea"));
            MedulaProcedureType = (ITTEnumComboBox)AddControl(new Guid("d29ac581-6318-4b07-bc1b-ccbd4ac95cdc"));
            labelToothNumber = (ITTLabel)AddControl(new Guid("fc8e2d4e-1efe-47d2-9df7-f8cbea3e7ab4"));
            ToothNumber = (ITTEnumComboBox)AddControl(new Guid("3d0b2d68-a7d7-4405-abb9-a651da786ee7"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("6a75c22a-9dbc-4474-aae4-54360656764c"));
            ProcedureTree = (ITTObjectListBox)AddControl(new Guid("c85b3067-ad6a-4867-ab03-ad8df8969c3c"));
            ttlabel6 = (ITTLabel)AddControl(new Guid("f7eda72a-1a5c-4267-ade6-3a5943b7f056"));
            ttlabel5 = (ITTLabel)AddControl(new Guid("92edf862-8588-40b3-8aa8-31dd7f3246a6"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b09d654e-1d92-486d-8845-308e84743472"));
            ttlabel2 = (ITTLabel)AddControl(new Guid("689065a9-956f-42bb-b6ea-af47e75d5563"));
            labelQref = (ITTLabel)AddControl(new Guid("94389337-f4ab-423c-9cf9-128690391388"));
            Qref = (ITTTextBox)AddControl(new Guid("9769dde5-f8ed-447b-a40a-b17d633e430c"));
            Name = (ITTTextBox)AddControl(new Guid("8928f8d9-fd63-4196-912f-6c83fd231afd"));
            EnglishName = (ITTTextBox)AddControl(new Guid("2f95c263-2625-4408-b143-246d9550ca46"));
            Description = (ITTTextBox)AddControl(new Guid("a9504d35-57dd-49ba-89c5-e281c2f4d101"));
            Code = (ITTTextBox)AddControl(new Guid("132ffe2c-4764-40bc-a165-35992f281c94"));
            labelName = (ITTLabel)AddControl(new Guid("0c26cf4d-9d24-4aa6-a937-4e027ad04047"));
            IsActive = (ITTCheckBox)AddControl(new Guid("965f9caf-b903-4033-819f-fb5fa85a9147"));
            labelEnglishName = (ITTLabel)AddControl(new Guid("a96b540f-e383-40fd-9cc5-58bd7ef6813c"));
            labelDescription = (ITTLabel)AddControl(new Guid("cdc10b27-0369-40a2-b58e-c1b931c7de87"));
            labelCode = (ITTLabel)AddControl(new Guid("26e4a12b-9a9e-4127-84aa-e16dd1b53190"));
            Departments = (ITTGrid)AddControl(new Guid("8d99e5e8-5aa9-414b-8790-af2a64d76e8d"));
            Department0 = (ITTListBoxColumn)AddControl(new Guid("c3583a0b-1994-4329-be7b-4c08dd2c25e3"));
            labelDentalRequestType = (ITTLabel)AddControl(new Guid("7532a63b-839b-4d5f-b898-b4566f4ea48a"));
            DentalRequestType = (ITTObjectListBox)AddControl(new Guid("e02dfc2c-5fa0-4288-bf58-a20141971821"));
            labelCategory = (ITTLabel)AddControl(new Guid("b08016f8-f21a-435e-94a5-424481a2a6b5"));
            Category = (ITTEnumComboBox)AddControl(new Guid("c7601129-2dbb-4647-9fa7-aac03531251e"));
            base.InitializeControls();
        }

        public DentalTreatmentDefinitionForm() : base("DENTALTREATMENTDEFINITION", "DentalTreatmentDefinitionForm")
        {
        }

        protected DentalTreatmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}