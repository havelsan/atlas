
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
    public partial class EmergencyInterventionClinicalDecisionDetailFormType1 : TTForm
    {
        protected TTObjectClasses.EmergencyInterventionClinicalDecision _EmergencyInterventionClinicalDecision
        {
            get { return (TTObjectClasses.EmergencyInterventionClinicalDecision)_ttObject; }
        }

        protected ITTCheckBox ClinicDecisionQuideDetailName;
        override protected void InitializeControls()
        {
            ClinicDecisionQuideDetailName = (ITTCheckBox)AddControl(new Guid("6a96ce6c-72c0-4188-818c-1c22eea0c036"));
            base.InitializeControls();
        }

        public EmergencyInterventionClinicalDecisionDetailFormType1() : base("EMERGENCYINTERVENTIONCLINICALDECISION", "EmergencyInterventionClinicalDecisionDetailFormType1")
        {
        }

        protected EmergencyInterventionClinicalDecisionDetailFormType1(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}