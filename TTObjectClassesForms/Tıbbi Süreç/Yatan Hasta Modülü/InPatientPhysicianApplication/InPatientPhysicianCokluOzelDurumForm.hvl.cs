
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
    /// Çoklu Özel Durum
    /// </summary>
    public partial class InPatientPhysicianCokluOzelDurum : TTForm
    {
        protected TTObjectClasses.InPatientPhysicianApplication _InPatientPhysicianApplication
        {
            get { return (TTObjectClasses.InPatientPhysicianApplication)_ttObject; }
        }

        protected ITTGrid ttgrid1;
        protected ITTEnumComboBoxColumn cokluOzelDurum;
        override protected void InitializeControls()
        {
            ttgrid1 = (ITTGrid)AddControl(new Guid("848880f9-edca-4317-b048-a5ce2a9e3361"));
            cokluOzelDurum = (ITTEnumComboBoxColumn)AddControl(new Guid("44f85670-f63d-4e13-b303-304bf3c0fb7b"));
            base.InitializeControls();
        }

        public InPatientPhysicianCokluOzelDurum() : base("INPATIENTPHYSICIANAPPLICATION", "InPatientPhysicianCokluOzelDurum")
        {
        }

        protected InPatientPhysicianCokluOzelDurum(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}