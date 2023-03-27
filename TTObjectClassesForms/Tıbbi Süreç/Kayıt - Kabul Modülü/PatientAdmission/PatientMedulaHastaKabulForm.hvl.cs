
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
    /// Medula Hasta Kabulleri
    /// </summary>
    public partial class PatientMedulaHastaKabulForm : TTForm
    {
        protected TTObjectClasses.PatientAdmission _PatientAdmission
        {
            get { return (TTObjectClasses.PatientAdmission)_ttObject; }
        }

        protected ITTListView listviewPatientMedulaHastaKabul;
        override protected void InitializeControls()
        {
            listviewPatientMedulaHastaKabul = (ITTListView)AddControl(new Guid("e038f455-015e-46bb-9b1c-402573185d8b"));
            base.InitializeControls();
        }

        public PatientMedulaHastaKabulForm() : base("PATIENTADMISSION", "PatientMedulaHastaKabulForm")
        {
        }

        protected PatientMedulaHastaKabulForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}