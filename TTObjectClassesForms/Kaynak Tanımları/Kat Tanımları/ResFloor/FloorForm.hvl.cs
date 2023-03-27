
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
    public partial class FloorForm : TTDefinitionForm
    {
    /// <summary>
    /// Kat
    /// </summary>
        protected TTObjectClasses.ResFloor _ResFloor
        {
            get { return (TTObjectClasses.ResFloor)_ttObject; }
        }

        protected ITTLabel labelResBuildingWing;
        protected ITTObjectListBox ResBuildingWing;
        protected ITTLabel labelResBuilding;
        protected ITTObjectListBox ResBuilding;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Location;
        protected ITTTextBox DeskPhoneNumber;
        protected ITTTextBox FloorNumber;
        protected ITTLabel labelLocation;
        protected ITTLabel labelDeskPhoneNumber;
        protected ITTLabel labelFloorNumber;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelResBuildingWing = (ITTLabel)AddControl(new Guid("8e8a0fd4-be24-4f49-bd16-751e40bccee0"));
            ResBuildingWing = (ITTObjectListBox)AddControl(new Guid("ad764747-085a-4e74-9681-22a99f40d2ab"));
            labelResBuilding = (ITTLabel)AddControl(new Guid("c4ead870-b0c8-41f5-a1e9-b0f4a0cfb057"));
            ResBuilding = (ITTObjectListBox)AddControl(new Guid("7b802b43-b9a3-489f-bddc-f98981264424"));
            labelName = (ITTLabel)AddControl(new Guid("d7a8e25a-4061-4c8f-8b7b-b98bf6999eaf"));
            Name = (ITTTextBox)AddControl(new Guid("0ebe4265-f6a5-4239-85d6-508dca553af5"));
            Location = (ITTTextBox)AddControl(new Guid("c31b25f1-2c50-4a35-b921-62743a058f5b"));
            DeskPhoneNumber = (ITTTextBox)AddControl(new Guid("efdbfaa4-5239-4aa0-855a-aa66c73e0b4f"));
            FloorNumber = (ITTTextBox)AddControl(new Guid("65cae55d-ad38-40c1-9de0-0eca52179caa"));
            labelLocation = (ITTLabel)AddControl(new Guid("42655df5-30e3-40da-80bc-cb03e17074d6"));
            labelDeskPhoneNumber = (ITTLabel)AddControl(new Guid("e7828cfe-cd40-414c-9208-101b042f689e"));
            labelFloorNumber = (ITTLabel)AddControl(new Guid("6ff78ecf-d427-4142-881f-230d0e5e063a"));
            IsActive = (ITTCheckBox)AddControl(new Guid("d7db25da-ad8d-434e-af19-476ef1d26575"));
            base.InitializeControls();
        }

        public FloorForm() : base("RESFLOOR", "FloorForm")
        {
        }

        protected FloorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}