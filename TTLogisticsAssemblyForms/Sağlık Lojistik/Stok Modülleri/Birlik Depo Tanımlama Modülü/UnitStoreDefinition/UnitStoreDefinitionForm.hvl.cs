
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
    /// Birlik Depo Tanımlama
    /// </summary>
    public partial class UnitStoreDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Birlik Depo Tanımları
    /// </summary>
        protected TTObjectClasses.UnitStoreDefinition _UnitStoreDefinition
        {
            get { return (TTObjectClasses.UnitStoreDefinition)_ttObject; }
        }

        protected ITTLabel labelStoreResponsible;
        protected ITTObjectListBox StoreResponsible;
        protected ITTLabel labelStatus;
        protected ITTEnumComboBox Status;
        protected ITTLabel labelQREF;
        protected ITTTextBox QREF;
        protected ITTTextBox Name;
        protected ITTTextBox Description;
        protected ITTLabel labelName;
        protected ITTLabel labelDescription;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelStoreResponsible = (ITTLabel)AddControl(new Guid("35c3f0d8-f8b8-41c2-829f-8245370cb638"));
            StoreResponsible = (ITTObjectListBox)AddControl(new Guid("a9a59e85-d52d-4899-a06c-23957320cf12"));
            labelStatus = (ITTLabel)AddControl(new Guid("360fc183-571e-4b7a-a0c6-3cfc04aa026a"));
            Status = (ITTEnumComboBox)AddControl(new Guid("6c4b1169-46bd-496f-95db-1da00a45c78b"));
            labelQREF = (ITTLabel)AddControl(new Guid("dbe6c0c9-dd93-4bb8-af77-e6285968012f"));
            QREF = (ITTTextBox)AddControl(new Guid("11e64f6b-a433-4c08-b6e1-2ddf40232b62"));
            Name = (ITTTextBox)AddControl(new Guid("5891f786-5e49-491a-9b0a-0b7a3cb7ae5e"));
            Description = (ITTTextBox)AddControl(new Guid("58217e0e-9fcd-4674-946e-82bae0773373"));
            labelName = (ITTLabel)AddControl(new Guid("b9bfb1fc-7703-4472-8e47-e9d5f1da0ccc"));
            labelDescription = (ITTLabel)AddControl(new Guid("c142e336-b95e-4bbc-9ec5-f7db284c3f75"));
            IsActive = (ITTCheckBox)AddControl(new Guid("d1a203e4-7e8d-4919-b61f-c475a28c2c4e"));
            base.InitializeControls();
        }

        public UnitStoreDefinitionForm() : base("UNITSTOREDEFINITION", "UnitStoreDefinitionForm")
        {
        }

        protected UnitStoreDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}