
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
    /// Kademe Tanımlama
    /// </summary>
    public partial class StageDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Kademe Tanım
    /// </summary>
        protected TTObjectClasses.StageDefinition _StageDefinition
        {
            get { return (TTObjectClasses.StageDefinition)_ttObject; }
        }

        protected ITTLabel labelMilitaryUnit;
        protected ITTObjectListBox MilitaryUnit;
        protected ITTLabel labelName;
        protected ITTTextBox Name;
        override protected void InitializeControls()
        {
            labelMilitaryUnit = (ITTLabel)AddControl(new Guid("68db8ad6-88c1-4e81-962d-1c99dc160724"));
            MilitaryUnit = (ITTObjectListBox)AddControl(new Guid("292ffc93-9b5c-4d7b-93d5-734d093adf4e"));
            labelName = (ITTLabel)AddControl(new Guid("3a0483cd-b5cd-47a4-8f61-fbe0396599a1"));
            Name = (ITTTextBox)AddControl(new Guid("7c9873b9-a6ae-4a06-9810-7cf9e6b55c76"));
            base.InitializeControls();
        }

        public StageDefinitionForm() : base("STAGEDEFINITION", "StageDefinitionForm")
        {
        }

        protected StageDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}