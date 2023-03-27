
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
    /// All Uncontrolled Controls
    /// </summary>
    public partial class ControlsForm : TTForm
    {
        protected TTObjectClasses.MBSPerson _MBSPerson
        {
            get { return (TTObjectClasses.MBSPerson)_ttObject; }
        }

        protected ITTLabel labelSurname;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTTextBox Surname;
        protected ITTGrid ttgrid1;
        protected ITTButton ttbutton1;
        override protected void InitializeControls()
        {
            labelSurname = (ITTLabel)AddControl(new Guid("5475ba46-b66b-4a65-98ba-160b98d29afd"));
            labelName = (ITTLabel)AddControl(new Guid("019688d6-fcee-445a-9990-1a4ab9d8b2e7"));
            Name = (ITTTextBox)AddControl(new Guid("93463569-ffd7-4c12-bc7d-c44158552bf6"));
            Surname = (ITTTextBox)AddControl(new Guid("da5289fa-d3aa-4794-bfe8-cd77fb1a6714"));
            ttgrid1 = (ITTGrid)AddControl(new Guid("31705c59-6586-4802-a17e-d4895ab1745d"));
            ttbutton1 = (ITTButton)AddControl(new Guid("9f926b2a-d855-4909-bc3f-e49e27d10f73"));
            base.InitializeControls();
        }

        public ControlsForm() : base("MBSPERSON", "ControlsForm")
        {
        }

        protected ControlsForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}