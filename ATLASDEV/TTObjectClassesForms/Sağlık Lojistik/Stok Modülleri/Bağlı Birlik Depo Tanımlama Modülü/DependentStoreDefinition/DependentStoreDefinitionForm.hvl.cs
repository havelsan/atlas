
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
    /// Bağlı Birlik Depo Tanımları
    /// </summary>
    public partial class DependentStoreDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Bağlı Birlik Depo Tanımları
    /// </summary>
        protected TTObjectClasses.DependentStoreDefinition _DependentStoreDefinition
        {
            get { return (TTObjectClasses.DependentStoreDefinition)_ttObject; }
        }

        protected ITTObjectListBox StoreResponsible;
        protected ITTLabel labelSite;
        protected ITTObjectListBox Site;
        protected ITTTextBox QREF;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTLabel labelDescription;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelGoodsResponsible;
        protected ITTLabel labelName;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelStatus;
        protected ITTLabel labelQREF;
        override protected void InitializeControls()
        {
            StoreResponsible = (ITTObjectListBox)AddControl(new Guid("97f2682f-2051-47e0-b3ff-1410ec22676b"));
            labelSite = (ITTLabel)AddControl(new Guid("48bf2b41-766c-49e4-96ef-64084cba2c55"));
            Site = (ITTObjectListBox)AddControl(new Guid("631e445c-11b2-40e7-b417-be9a7f78c2bb"));
            QREF = (ITTTextBox)AddControl(new Guid("2848d25d-ebff-459a-851a-11217723efca"));
            Description = (ITTTextBox)AddControl(new Guid("5d94ff61-f861-4376-8f9c-7bc9b8e52512"));
            Name = (ITTTextBox)AddControl(new Guid("f4bbe7ea-ddd0-4639-b186-9687100c770b"));
            labelDescription = (ITTLabel)AddControl(new Guid("9f980ae2-80ca-4b23-a1cd-6833a9ba00b4"));
            Status = (ITTEnumComboBox)AddControl(new Guid("56c0c310-7dd7-4f2d-9eda-786d4d224336"));
            labelGoodsResponsible = (ITTLabel)AddControl(new Guid("b241974d-94fb-49b6-91b7-82d3796fea5e"));
            labelName = (ITTLabel)AddControl(new Guid("8f77340c-a984-48da-b043-939f1a6cc277"));
            IsActive = (ITTCheckBox)AddControl(new Guid("ff442981-345a-472a-a475-a2ebbafb3e71"));
            labelStatus = (ITTLabel)AddControl(new Guid("11bf80b6-241d-4057-b799-abf39f0075f7"));
            labelQREF = (ITTLabel)AddControl(new Guid("54894a7d-c716-4419-a0ec-d56e32c36645"));
            base.InitializeControls();
        }

        public DependentStoreDefinitionForm() : base("DEPENDENTSTOREDEFINITION", "DependentStoreDefinitionForm")
        {
        }

        protected DependentStoreDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}