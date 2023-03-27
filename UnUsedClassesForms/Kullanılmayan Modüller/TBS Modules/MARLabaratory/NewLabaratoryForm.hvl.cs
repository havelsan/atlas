
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
    /// New Form
    /// </summary>
    public partial class NewLabaratoryForm : TTForm
    {
    /// <summary>
    /// Labaratuvar
    /// </summary>
        protected TTObjectClasses.MARLabaratory _MARLabaratory
        {
            get { return (TTObjectClasses.MARLabaratory)_ttObject; }
        }

        protected ITTTextBox Code;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        protected ITTLabel labelCode;
        override protected void InitializeControls()
        {
            Code = (ITTTextBox)AddControl(new Guid("2c7afac7-2b94-4a5a-90e5-022fe2175715"));
            labelName = (ITTLabel)AddControl(new Guid("b6bb997a-349f-4e2d-b556-2c7bad0be5d5"));
            Name = (ITTTextBox)AddControl(new Guid("6f054ee7-645c-4948-8dc8-4ccbd5b99957"));
            labelCode = (ITTLabel)AddControl(new Guid("9b8d2de0-895e-4977-bf87-e936be35352f"));
            base.InitializeControls();
        }

        public NewLabaratoryForm() : base("MARLABARATORY", "NewLabaratoryForm")
        {
        }

        protected NewLabaratoryForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}