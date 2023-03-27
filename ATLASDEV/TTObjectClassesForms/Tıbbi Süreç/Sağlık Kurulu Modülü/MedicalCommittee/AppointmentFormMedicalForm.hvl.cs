
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
    /// Randevu Formu
    /// </summary>
    public partial class AppointmentFormMedical : EpisodeActionForm
    {
    /// <summary>
    /// Tıbbi Kurul İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
        protected TTObjectClasses.MedicalCommittee _MedicalCommittee
        {
            get { return (TTObjectClasses.MedicalCommittee)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextboxDescription;
        protected ITTTextBox tttextboxProtokolNo;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("288af27e-c22b-4272-813a-24933d1109d3"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("ef61dcfc-c318-40f0-bbd5-9c454004956c"));
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("1642f43e-faf2-4afe-abe6-bd010c49994b"));
            base.InitializeControls();
        }

        public AppointmentFormMedical() : base("MEDICALCOMMITTEE", "AppointmentFormMedical")
        {
        }

        protected AppointmentFormMedical(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}