
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
    /// Menü Tanımlama
    /// </summary>
    public partial class MenuForm : TTForm
    {
        protected TTObjectClasses.MenuDefinition _MenuDefinition
        {
            get { return (TTObjectClasses.MenuDefinition)_ttObject; }
        }

        protected ITTLabel labelMenuDefNo;
        protected ITTTextBox textboxMenuDefNo;
        protected ITTTextBox OrderNo;
        protected ITTTextBox Caption;
        protected ITTTextBox UnboundFormName;
        protected ITTTextBox EntryState;
        protected ITTTextBox ObjectDefinitionName;
        protected ITTCheckBox IsDisabled;
        protected ITTObjectListBox ParentMenu;
        protected ITTLabel labelOrderNo;
        protected ITTLabel labelMenuGroup;
        protected ITTEnumComboBox MenuGroup;
        protected ITTLabel labelCaption;
        protected ITTLabel labelParentMenu;
        protected ITTLabel labelObjectDefinitionName;
        protected ITTLabel labelUnboundFormName;
        protected ITTLabel labelEntryState;
        protected ITTGrid NotIncludeSites;
        protected ITTListBoxColumn Site;
        override protected void InitializeControls()
        {
            labelMenuDefNo = (ITTLabel)AddControl(new Guid("a218b559-566c-4ece-aa20-32bfe4072153"));
            textboxMenuDefNo = (ITTTextBox)AddControl(new Guid("ce530d67-b774-4f62-8edd-206cfeecc116"));
            OrderNo = (ITTTextBox)AddControl(new Guid("d883176f-417b-4621-85f4-eb19ba2e155b"));
            Caption = (ITTTextBox)AddControl(new Guid("515e3e03-27ad-4b7d-877f-e20c01654b94"));
            UnboundFormName = (ITTTextBox)AddControl(new Guid("a99d0ab3-34fb-4f17-85fe-f4c1bcb096ea"));
            EntryState = (ITTTextBox)AddControl(new Guid("9342767d-10c6-4303-ba0b-a97526ec3b43"));
            ObjectDefinitionName = (ITTTextBox)AddControl(new Guid("a6a0794d-f6e4-4209-aa85-658d69ceec0a"));
            IsDisabled = (ITTCheckBox)AddControl(new Guid("f36d379e-625d-4856-a063-5fe79399eff1"));
            ParentMenu = (ITTObjectListBox)AddControl(new Guid("c3b28dd9-c1dc-4ef5-9dde-ee53a0481c99"));
            labelOrderNo = (ITTLabel)AddControl(new Guid("71058b2b-71ab-4657-a2db-7c1d116ad989"));
            labelMenuGroup = (ITTLabel)AddControl(new Guid("066c122a-6bcb-4d61-9e35-1771a9c95659"));
            MenuGroup = (ITTEnumComboBox)AddControl(new Guid("6cded755-036e-4d59-9977-e159c8c3301f"));
            labelCaption = (ITTLabel)AddControl(new Guid("f0e09b01-8569-485e-833c-e846b39adbc1"));
            labelParentMenu = (ITTLabel)AddControl(new Guid("2b4941ee-9d95-4262-816f-214bfaf1b748"));
            labelObjectDefinitionName = (ITTLabel)AddControl(new Guid("34958aca-a3c7-4d45-9981-9ee40b304ed8"));
            labelUnboundFormName = (ITTLabel)AddControl(new Guid("ba157563-eef4-4633-b7da-13baa29653e5"));
            labelEntryState = (ITTLabel)AddControl(new Guid("282c126c-1e0b-40f4-a173-bc9dddad36e7"));
            NotIncludeSites = (ITTGrid)AddControl(new Guid("7bc3e5e7-776c-481c-a6dd-84a4c9c10083"));
            Site = (ITTListBoxColumn)AddControl(new Guid("058ed247-0d53-49c6-8dc5-1366a2ff7926"));
            base.InitializeControls();
        }

        public MenuForm() : base("MENUDEFINITION", "MenuForm")
        {
        }

        protected MenuForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}