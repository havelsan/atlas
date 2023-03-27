
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
    /// Ölüm Sebebi
    /// </summary>
    public partial class ReasonForDeathDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Ölüm Sebebi Tanımları
    /// </summary>
        protected TTObjectClasses.ReasonForDeathDefinition _ReasonForDeathDefinition
        {
            get { return (TTObjectClasses.ReasonForDeathDefinition)_ttObject; }
        }

        protected ITTLabel labelReasonForDeath;
        protected ITTTextBox ReasonForDeath;
        override protected void InitializeControls()
        {
            labelReasonForDeath = (ITTLabel)AddControl(new Guid("5be4b2e0-3143-4696-9d53-8a0f5851e358"));
            ReasonForDeath = (ITTTextBox)AddControl(new Guid("d01621fa-56ed-411c-99c7-72eb6ba499e6"));
            base.InitializeControls();
        }

        public ReasonForDeathDefinitionForm() : base("REASONFORDEATHDEFINITION", "ReasonForDeathDefinitionForm")
        {
        }

        protected ReasonForDeathDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}