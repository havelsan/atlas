
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
    public partial class CabinetDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Arşiv dosyaları için dolap tanımları
    /// </summary>
        protected TTObjectClasses.ResCabinet _ResCabinet
        {
            get { return (TTObjectClasses.ResCabinet)_ttObject; }
        }

        protected ITTGrid ResShelves;
        protected ITTListBoxColumn ResCabinetResShelf;
        protected ITTTextBoxColumn FileCapacityResShelf;
        protected ITTTextBoxColumn ShelfNameResShelf;
        protected ITTCheckBoxColumn IsActiveResShelf;
        protected ITTLabel labelResArchiveRoom;
        protected ITTObjectListBox ResArchiveRoom;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            ResShelves = (ITTGrid)AddControl(new Guid("2425ea94-c7d2-45e2-8425-03922d58f43b"));
            ResCabinetResShelf = (ITTListBoxColumn)AddControl(new Guid("d00fe14d-d281-4d10-83bd-6046394b2538"));
            FileCapacityResShelf = (ITTTextBoxColumn)AddControl(new Guid("18f070e2-ef72-4c44-836f-4f3cdb88bddc"));
            ShelfNameResShelf = (ITTTextBoxColumn)AddControl(new Guid("0eda5711-d38d-4ba7-9dcd-bca453b5b8ee"));
            IsActiveResShelf = (ITTCheckBoxColumn)AddControl(new Guid("3603b8f6-4b7c-4e1b-a665-181524659481"));
            labelResArchiveRoom = (ITTLabel)AddControl(new Guid("ea393124-41e2-4560-92a2-4496ee63ed52"));
            ResArchiveRoom = (ITTObjectListBox)AddControl(new Guid("0d7ee407-a078-44c8-9a5c-aa7199eb16fb"));
            labelName = (ITTLabel)AddControl(new Guid("b791402e-e5c5-4fe1-80a7-026ae8162331"));
            Name = (ITTTextBox)AddControl(new Guid("3f5eb7bf-5c6f-4fba-ae87-2ea7e3a8aa52"));
            IsActive = (ITTCheckBox)AddControl(new Guid("0fad15c1-b80d-4528-8008-a5c91a4d640d"));
            base.InitializeControls();
        }

        public CabinetDefinitionForm() : base("RESCABINET", "CabinetDefinitionForm")
        {
        }

        protected CabinetDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}