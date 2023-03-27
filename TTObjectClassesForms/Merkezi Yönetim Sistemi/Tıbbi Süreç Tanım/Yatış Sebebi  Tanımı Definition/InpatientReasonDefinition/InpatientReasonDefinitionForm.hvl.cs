
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
    /// Yatış Sebebi Tanımları
    /// </summary>
    public partial class InpatientReasonDefinitionForm : TerminologyManagerDefForm
    {
        protected TTObjectClasses.InpatientReasonDefinition _InpatientReasonDefinition
        {
            get { return (TTObjectClasses.InpatientReasonDefinition)_ttObject; }
        }

        protected ITTLabel labelReason;
        protected ITTTextBox Reason;
        override protected void InitializeControls()
        {
            labelReason = (ITTLabel)AddControl(new Guid("90ff90e4-cab2-4309-84c5-c208f3517ada"));
            Reason = (ITTTextBox)AddControl(new Guid("b2099fc6-8ae0-4104-8ac0-48743da098dd"));
            base.InitializeControls();
        }

        public InpatientReasonDefinitionForm() : base("INPATIENTREASONDEFINITION", "InpatientReasonDefinitionForm")
        {
        }

        protected InpatientReasonDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}