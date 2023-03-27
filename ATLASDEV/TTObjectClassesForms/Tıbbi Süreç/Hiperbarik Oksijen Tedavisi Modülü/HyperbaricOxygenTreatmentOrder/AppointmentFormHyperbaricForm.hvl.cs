
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
    /// Hiperbarik Oksijen Tedavi Randevu Bilgileri
    /// </summary>
    public partial class AppointmentFormHyperbaric : TTForm
    {
    /// <summary>
    /// Hiperbarik Oksijen Tedavi Emirinin Verildiği Nesnedir
    /// </summary>
        protected TTObjectClasses.HyperbaricOxygenTreatmentOrder _HyperbaricOxygenTreatmentOrder
        {
            get { return (TTObjectClasses.HyperbaricOxygenTreatmentOrder)_ttObject; }
        }

        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox tttextboxProtokolNo;
        protected ITTLabel ttlabel1;
        override protected void InitializeControls()
        {
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("d2d6afa0-2ffc-47f5-827d-0aeec4fec9ec"));
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("46fa55e3-6a6f-4f6a-821f-8e4516c74f85"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("5330b609-6585-4c86-a23d-fbb965811630"));
            base.InitializeControls();
        }

        public AppointmentFormHyperbaric() : base("HYPERBARICOXYGENTREATMENTORDER", "AppointmentFormHyperbaric")
        {
        }

        protected AppointmentFormHyperbaric(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}