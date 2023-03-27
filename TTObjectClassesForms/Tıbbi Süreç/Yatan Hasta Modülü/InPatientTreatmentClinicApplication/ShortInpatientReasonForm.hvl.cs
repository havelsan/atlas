
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
    /// Kısa Yatış Nedeni
    /// </summary>
    public partial class ShortInpatientReasonForm : TTForm
    {
    /// <summary>
    /// Klinik İşlemleri
    /// </summary>
        protected TTObjectClasses.InPatientTreatmentClinicApplication _InPatientTreatmentClinicApplication
        {
            get { return (TTObjectClasses.InPatientTreatmentClinicApplication)_ttObject; }
        }

        protected ITTLabel labelShotInpatientReason;
        protected ITTTextBox ContagiousDisease;
        override protected void InitializeControls()
        {
            labelShotInpatientReason = (ITTLabel)AddControl(new Guid("9a47f791-45e8-4d3b-9e0e-3933d6d3e6f5"));
            ContagiousDisease = (ITTTextBox)AddControl(new Guid("5c75f857-8ae8-4d4a-8652-9504440f5413"));
            base.InitializeControls();
        }

        public ShortInpatientReasonForm() : base("INPATIENTTREATMENTCLINICAPPLICATION", "ShortInpatientReasonForm")
        {
        }

        protected ShortInpatientReasonForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}