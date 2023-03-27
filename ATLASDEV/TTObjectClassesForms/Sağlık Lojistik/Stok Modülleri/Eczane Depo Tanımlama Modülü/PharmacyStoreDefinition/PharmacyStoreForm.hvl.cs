
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
    /// Eczane Depo Tanımları
    /// </summary>
    public partial class PharmacyStoreForm : TTDefinitionForm
    {
    /// <summary>
    /// Eczane Depo Tanımları
    /// </summary>
        protected TTObjectClasses.PharmacyStoreDefinition _PharmacyStoreDefinition
        {
            get { return (TTObjectClasses.PharmacyStoreDefinition)_ttObject; }
        }

        protected ITTLabel labelAccountancy;
        protected ITTObjectListBox Accountancy;
        protected ITTLabel labelUnitStoreDefinition;
        protected ITTObjectListBox UnitStoreDefinition;
        protected ITTLabel labelQREF;
        protected ITTLabel labelDescription;
        protected ITTLabel labelPharmacyType;
        protected ITTTextBox Description;
        protected ITTTextBox QREF;
        protected ITTTextBox Name;
        protected ITTLabel labelStatus;
        protected ITTCheckBox IsActive;
        protected ITTEnumComboBox Status;
        protected ITTEnumComboBox PharmacyType;
        protected ITTLabel labelName;
        protected ITTObjectListBox StoreResponsible;
        protected ITTLabel labelStoreResponsible;
        override protected void InitializeControls()
        {
            labelAccountancy = (ITTLabel)AddControl(new Guid("9594b3cf-9434-4507-b92f-78f6caedcf66"));
            Accountancy = (ITTObjectListBox)AddControl(new Guid("12dd8cbd-7c80-4710-9258-874324f26e1b"));
            labelUnitStoreDefinition = (ITTLabel)AddControl(new Guid("2fb8f413-18ae-484f-a05a-1cdbc7c50380"));
            UnitStoreDefinition = (ITTObjectListBox)AddControl(new Guid("5636eb85-f8a2-446b-a64a-bb4ec300bddd"));
            labelQREF = (ITTLabel)AddControl(new Guid("6a2009bb-9dcc-4af3-8166-407ddfd3c9b6"));
            labelDescription = (ITTLabel)AddControl(new Guid("b2d5cba8-1d0a-423d-b3fd-43c7764391ed"));
            labelPharmacyType = (ITTLabel)AddControl(new Guid("b76c7506-a93b-45bc-a02a-5025a1875d8d"));
            Description = (ITTTextBox)AddControl(new Guid("ed4a8f44-79be-48d2-bb37-73aee0c5eafb"));
            QREF = (ITTTextBox)AddControl(new Guid("2bd6b14f-6383-43b2-b908-78ef3743e5e5"));
            Name = (ITTTextBox)AddControl(new Guid("e038f2ae-0851-47b2-b6b4-cc2a54d57a0a"));
            labelStatus = (ITTLabel)AddControl(new Guid("c4ef7344-3f75-4516-ba3e-8ae5ef6bfdba"));
            IsActive = (ITTCheckBox)AddControl(new Guid("3b0cd52e-561e-423e-a6f9-8e35c0f82933"));
            Status = (ITTEnumComboBox)AddControl(new Guid("523737ea-f464-4232-b098-9ecbe842fe42"));
            PharmacyType = (ITTEnumComboBox)AddControl(new Guid("191ebe9a-45bf-425e-a28d-bf5c3f1fe63c"));
            labelName = (ITTLabel)AddControl(new Guid("7b21a9e3-2329-4dab-b285-c17c082789d0"));
            StoreResponsible = (ITTObjectListBox)AddControl(new Guid("02d17fcc-97c5-4465-a001-e3dd185b7e14"));
            labelStoreResponsible = (ITTLabel)AddControl(new Guid("6cb649d5-b487-42a0-876f-d7990e73c61b"));
            base.InitializeControls();
        }

        public PharmacyStoreForm() : base("PHARMACYSTOREDEFINITION", "PharmacyStoreForm")
        {
        }

        protected PharmacyStoreForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}