
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
    public partial class ResSterilizationUnitForm : TTDefinitionForm
    {
    /// <summary>
    /// Sterilizasyon Birimi
    /// </summary>
        protected TTObjectClasses.ResSterilizationUnit _ResSterilizationUnit
        {
            get { return (TTObjectClasses.ResSterilizationUnit)_ttObject; }
        }

        protected ITTLabel labelBuilding;
        protected ITTObjectListBox Building;
        protected ITTLabel labelQref;
        protected ITTTextBox Qref;
        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            labelBuilding = (ITTLabel)AddControl(new Guid("69affac1-5b43-4869-822c-78c5fcf34243"));
            Building = (ITTObjectListBox)AddControl(new Guid("7fba764f-3159-4114-b9ce-88a30830788f"));
            labelQref = (ITTLabel)AddControl(new Guid("96a55097-fa55-4f0a-9a99-72790af1c602"));
            Qref = (ITTTextBox)AddControl(new Guid("f1267b19-2302-4793-b284-42fe27b53200"));
            Name = (ITTTextBox)AddControl(new Guid("f74b641d-00af-4bd0-8b12-7caca0ba0919"));
            labelName = (ITTLabel)AddControl(new Guid("7270016a-cfb0-4bc3-ad62-7ea8dd9dd55d"));
            base.InitializeControls();
        }

        public ResSterilizationUnitForm() : base("RESSTERILIZATIONUNIT", "ResSterilizationUnitForm")
        {
        }

        protected ResSterilizationUnitForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}