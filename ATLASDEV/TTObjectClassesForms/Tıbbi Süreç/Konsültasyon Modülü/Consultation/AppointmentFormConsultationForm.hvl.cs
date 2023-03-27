
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
    public partial class AppointmentFormConsultation : AppointmentFormBase
    {
        protected TTObjectClasses.Consultation _Consultation
        {
            get { return (TTObjectClasses.Consultation)_ttObject; }
        }

        protected ITTTextBox ProtocolNo;
        protected ITTLabel labelProtocolNo;
        override protected void InitializeControls()
        {
            ProtocolNo = (ITTTextBox)AddControl(new Guid("ed14d248-0371-4480-8a10-b051735cbab5"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("4ad3053b-cbb3-42eb-8aa3-50d6d20800e5"));
            base.InitializeControls();
        }

        public AppointmentFormConsultation() : base("CONSULTATION", "AppointmentFormConsultation")
        {
        }

        protected AppointmentFormConsultation(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}