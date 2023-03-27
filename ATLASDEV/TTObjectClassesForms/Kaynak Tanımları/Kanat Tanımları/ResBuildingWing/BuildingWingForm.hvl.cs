
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
    public partial class BuildingWingForm : TTDefinitionForm
    {
    /// <summary>
    /// Kanat
    /// </summary>
        protected TTObjectClasses.ResBuildingWing _ResBuildingWing
        {
            get { return (TTObjectClasses.ResBuildingWing)_ttObject; }
        }

        protected ITTLabel labelResBuilding;
        protected ITTObjectListBox ResBuilding;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Location;
        protected ITTTextBox ContactPhone;
        protected ITTLabel labelLocation;
        protected ITTLabel labelContactPhone;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            labelResBuilding = (ITTLabel)AddControl(new Guid("7c31dc50-9c1a-410c-897a-7ff4e927f1a6"));
            ResBuilding = (ITTObjectListBox)AddControl(new Guid("64aeda58-261e-4699-ad74-15509a2f7a2b"));
            labelName = (ITTLabel)AddControl(new Guid("042853bb-d9a2-4c37-a074-3f62baae70ff"));
            Name = (ITTTextBox)AddControl(new Guid("b7d22f7f-fe03-423d-8a32-94c279a71ca4"));
            Location = (ITTTextBox)AddControl(new Guid("63c3441d-ad1d-4a43-9e63-530aac39a7f1"));
            ContactPhone = (ITTTextBox)AddControl(new Guid("0b7e4bcf-72d3-4375-9e85-42da3f764bf5"));
            labelLocation = (ITTLabel)AddControl(new Guid("6b23ebf8-eace-4b57-8b62-590de221d3d6"));
            labelContactPhone = (ITTLabel)AddControl(new Guid("58845557-515f-42dc-916e-67a6d60299c2"));
            IsActive = (ITTCheckBox)AddControl(new Guid("c707394d-2517-43bf-819e-2bfef7829f5c"));
            base.InitializeControls();
        }

        public BuildingWingForm() : base("RESBUILDINGWING", "BuildingWingForm")
        {
        }

        protected BuildingWingForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}