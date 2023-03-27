
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
    public partial class PatientExaminationCokluOzelDurum : TTForm
    {
    /// <summary>
    /// Hasta Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.PatientExamination _PatientExamination
        {
            get { return (TTObjectClasses.PatientExamination)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTEnumComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("f0835e51-09ec-4658-9acd-57cad836348d"));
            cokluOzelDurum = (ITTEnumComboBoxColumn)AddControl(new Guid("dc159eb8-92ce-4523-81fa-e8dd2225059f"));
            base.InitializeControls();
        }

        public PatientExaminationCokluOzelDurum() : base("PATIENTEXAMINATION", "PatientExaminationCokluOzelDurum")
        {
        }

        protected PatientExaminationCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}