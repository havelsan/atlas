
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
    public partial class EmergencyInterventionClinicalDecisionDetailFormType2 : TTForm
    {
        protected TTObjectClasses.EmergencyInterventionClinicalDecision _EmergencyInterventionClinicalDecision
        {
            get { return (TTObjectClasses.EmergencyInterventionClinicalDecision)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTLabel ClinicDecisionQuideDetailName;
        protected ITTTextBox ClinicDecisionDetailValue;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("8dc43ad9-df34-4b6e-9870-600e9153858e"));
            ClinicDecisionQuideDetailName = (ITTLabel)AddControl(new Guid("59b884ca-9e36-4c31-aa6d-d0685da0713e"));
            ClinicDecisionDetailValue = (ITTTextBox)AddControl(new Guid("c7e0d488-4ca3-41a7-9e92-d212e024538a"));
            base.InitializeControls();
        }

        public EmergencyInterventionClinicalDecisionDetailFormType2() : base("EMERGENCYINTERVENTIONCLINICALDECISION", "EmergencyInterventionClinicalDecisionDetailFormType2")
        {
        }

        protected EmergencyInterventionClinicalDecisionDetailFormType2(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}