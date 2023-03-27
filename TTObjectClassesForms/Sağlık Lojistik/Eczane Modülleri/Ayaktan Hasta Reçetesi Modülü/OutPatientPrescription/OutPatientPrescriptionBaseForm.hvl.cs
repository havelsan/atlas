
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
    /// OutPatientPrescriptionBaseForm
    /// </summary>
    public partial class OutPatientPrescriptionBaseForm : PrescriptionBaseForm
    {
    /// <summary>
    /// Ayaktan Hasta Reçetesi
    /// </summary>
        protected TTObjectClasses.OutPatientPrescription _OutPatientPrescription
        {
            get { return (TTObjectClasses.OutPatientPrescription)_ttObject; }
        }

        protected ITTButton DigitalSignatureButton;
        override protected void InitializeControls()
        {
            DigitalSignatureButton = (ITTButton)AddControl(new Guid("efc67e83-5ec9-486b-a00e-a01ed3a36259"));
            base.InitializeControls();
        }

        public OutPatientPrescriptionBaseForm() : base("OUTPATIENTPRESCRIPTION", "OutPatientPrescriptionBaseForm")
        {
        }

        protected OutPatientPrescriptionBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}