
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
    /// Derece Tanımlama
    /// </summary>
    public partial class NewDegreeForm : TTForm
    {
    /// <summary>
    /// Derece Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSDegreeDefinition _MPBSDegreeDefinition
        {
            get { return (TTObjectClasses.MPBSDegreeDefinition)_ttObject; }
        }

        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelName = (ITTLabel)AddControl(new Guid("b87e0a57-6c19-4de1-b47f-5f837677d718"));
            Name = (ITTTextBox)AddControl(new Guid("c47a531f-f5d1-4c8a-90d5-f225b2858c81"));
            base.InitializeControls();
        }

        public NewDegreeForm() : base("MPBSDEGREEDEFINITION", "NewDegreeForm")
        {
        }

        protected NewDegreeForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}