
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
    /// Staj Birimi Tanımlama
    /// </summary>
    public partial class NewTrainingUnitForm : TTForm
    {
    /// <summary>
    /// Staj Birimi Tanımlama
    /// </summary>
        protected TTObjectClasses.MPBSTrainingUnitDefinition _MPBSTrainingUnitDefinition
        {
            get { return (TTObjectClasses.MPBSTrainingUnitDefinition)_ttObject; }
        }

        protected ITTTextBox Name;
        protected ITTLabel labelName;
        override protected void InitializeControls()
        {
            Name = (ITTTextBox)AddControl(new Guid("d58e16da-e432-4c74-8bd5-0c797225bad4"));
            labelName = (ITTLabel)AddControl(new Guid("7422e50a-82c4-40b1-8cc6-cdf92dfc205e"));
            base.InitializeControls();
        }

        public NewTrainingUnitForm() : base("MPBSTRAININGUNITDEFINITION", "NewTrainingUnitForm")
        {
        }

        protected NewTrainingUnitForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}