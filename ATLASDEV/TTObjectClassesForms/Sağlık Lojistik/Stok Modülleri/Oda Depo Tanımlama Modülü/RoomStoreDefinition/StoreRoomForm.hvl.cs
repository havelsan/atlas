
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
    /// Oda Depo Tanımları
    /// </summary>
    public partial class StoreRoomForm : TTDefinitionForm
    {
    /// <summary>
    /// Oda Depo Tanımları
    /// </summary>
        protected TTObjectClasses.RoomStoreDefinition _RoomStoreDefinition
        {
            get { return (TTObjectClasses.RoomStoreDefinition)_ttObject; }
        }

        protected ITTLabel labelStoreResponsible;
        protected ITTObjectListBox StoreResponsible;
        protected ITTLabel labelParentStore;
        protected ITTObjectListBox ParentStore;
        protected ITTEnumComboBox Status;
        protected ITTTextBox Description;
        protected ITTTextBox Name;
        protected ITTTextBox QREF;
        protected ITTLabel labelStatus;
        protected ITTLabel labelQREF;
        protected ITTLabel labelName;
        protected ITTLabel labelDescription;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelStoreResponsible = (ITTLabel)AddControl(new Guid("4f0f209f-1157-4e16-9793-6235922f594c"));
            StoreResponsible = (ITTObjectListBox)AddControl(new Guid("6775681e-975d-44a1-84c1-e892e78007de"));
            labelParentStore = (ITTLabel)AddControl(new Guid("4959d67c-92ae-4129-b157-c983e21c4364"));
            ParentStore = (ITTObjectListBox)AddControl(new Guid("844e877e-803f-4338-ae04-24d8616f670d"));
            Status = (ITTEnumComboBox)AddControl(new Guid("dbecd7e2-2b45-43ea-9e51-5935a70ad6dc"));
            Description = (ITTTextBox)AddControl(new Guid("290eca75-0388-4624-89bd-5a6662cd7368"));
            Name = (ITTTextBox)AddControl(new Guid("c5f0fa23-8d56-4f86-9386-9ce510d6f7e6"));
            QREF = (ITTTextBox)AddControl(new Guid("7fe410f2-4790-4fd4-944f-cf3eff5ffb42"));
            labelStatus = (ITTLabel)AddControl(new Guid("20f79578-183c-4601-85ed-6ad5d9e7276a"));
            labelQREF = (ITTLabel)AddControl(new Guid("b143e5ec-6907-4acf-9daa-7bcc18133e37"));
            labelName = (ITTLabel)AddControl(new Guid("4df5713f-9093-41d3-839f-bf0d68790f1d"));
            labelDescription = (ITTLabel)AddControl(new Guid("404f4922-74b4-4ed4-9716-bfa91ef65cf7"));
            IsActive = (ITTCheckBox)AddControl(new Guid("ff35dd9c-017c-4529-8abf-e04d4d60924d"));
            base.InitializeControls();
        }

        public StoreRoomForm() : base("ROOMSTOREDEFINITION", "StoreRoomForm")
        {
        }

        protected StoreRoomForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}