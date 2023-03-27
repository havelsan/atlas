
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
    /// Görev Tanımlama
    /// </summary>
    public partial class NewOccupationForm : TTForm
    {
    /// <summary>
    /// Görev Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSOccupationDefinition _MPBSOccupationDefinition
        {
            get { return (TTObjectClasses.MPBSOccupationDefinition)_ttObject; }
        }

        protected ITTCheckBox Active;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            Active = (ITTCheckBox)AddControl(new Guid("da87c4d0-3c34-43e6-af05-11982457b556"));
            labelName = (ITTLabel)AddControl(new Guid("e009df89-b22a-4d37-b1d8-4013d81ff126"));
            Name = (ITTTextBox)AddControl(new Guid("b5e07d61-b271-45a8-b70e-9353936c01d2"));
            base.InitializeControls();
        }

        public NewOccupationForm() : base("MPBSOCCUPATIONDEFINITION", "NewOccupationForm")
        {
        }

        protected NewOccupationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}