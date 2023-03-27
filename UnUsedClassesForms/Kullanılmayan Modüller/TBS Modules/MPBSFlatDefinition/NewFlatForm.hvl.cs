
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
    /// Daire Tanımlama
    /// </summary>
    public partial class NewFlatForm : TTForm
    {
    /// <summary>
    /// Daire Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSFlatDefinition _MPBSFlatDefinition
        {
            get { return (TTObjectClasses.MPBSFlatDefinition)_ttObject; }
        }

        protected ITTTextBox DoorNo;
        protected ITTEnumComboBox Type;
        protected ITTLabel labelApartmentArea;
        protected ITTTextBox NumberOfRooms;
        protected ITTLabel labelDoorNo;
        protected ITTTextBox NumberOfBalcony;
        protected ITTTextBox Name;
        protected ITTLabel labelNumberOfRooms;
        protected ITTLabel labelApartment;
        protected ITTLabel labelSquareRoot;
        protected ITTListDefComboBox Apartment;
        protected ITTListDefComboBox ttlistdefcombobox2;
        protected ITTLabel labelName;
        protected ITTTextBox SquareRoot;
        protected ITTLabel labelType;
        protected ITTLabel labelNumberOfBalcony;
        override protected void InitializeControls()
        {
            DoorNo = (ITTTextBox)AddControl(new Guid("a8e873a2-0618-4c3b-a46f-0bda3474f396"));
            Type = (ITTEnumComboBox)AddControl(new Guid("2ed7f398-9352-45b6-bfb2-03517830448d"));
            labelApartmentArea = (ITTLabel)AddControl(new Guid("b61a3a07-36c0-4cf6-84f9-1a60a6ee1fe9"));
            NumberOfRooms = (ITTTextBox)AddControl(new Guid("b78ddf97-01e2-452a-b559-255e3dcac5f9"));
            labelDoorNo = (ITTLabel)AddControl(new Guid("f866e06d-2154-4bc2-8438-6427d7cfc277"));
            NumberOfBalcony = (ITTTextBox)AddControl(new Guid("9976f75f-208c-4d55-b7c7-33532dade2e8"));
            Name = (ITTTextBox)AddControl(new Guid("08979002-6aaf-4005-bafe-594acd5fa623"));
            labelNumberOfRooms = (ITTLabel)AddControl(new Guid("d2a1d21d-795b-41ad-8e4e-4a267dba23b4"));
            labelApartment = (ITTLabel)AddControl(new Guid("5560d292-4261-4abb-8535-6d79dee7ff4f"));
            labelSquareRoot = (ITTLabel)AddControl(new Guid("5abbebce-e3e3-42f0-8e75-5981277496a6"));
            Apartment = (ITTListDefComboBox)AddControl(new Guid("c6a4a527-141c-4990-9dc2-79ce2ab64c2d"));
            ttlistdefcombobox2 = (ITTListDefComboBox)AddControl(new Guid("a5a16133-5bf9-4a58-b93a-95c23606b299"));
            labelName = (ITTLabel)AddControl(new Guid("e904d989-69c0-43a3-8fef-a0f9428f3f51"));
            SquareRoot = (ITTTextBox)AddControl(new Guid("132dcee5-7c88-412b-a23a-a096772585b4"));
            labelType = (ITTLabel)AddControl(new Guid("2336b028-4d2a-40eb-ba9e-ed1c780bef7f"));
            labelNumberOfBalcony = (ITTLabel)AddControl(new Guid("54d0b6cc-db2a-4eae-98a1-fae3960aa8e1"));
            base.InitializeControls();
        }

        public NewFlatForm() : base("MPBSFLATDEFINITION", "NewFlatForm")
        {
        }

        protected NewFlatForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}