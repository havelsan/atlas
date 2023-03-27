
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
    /// Randevu
    /// </summary>
    public partial class RadiologyTestAppointmentForm : SubactionProcedureAppointmentForm
    {
    /// <summary>
    /// Radyoloji Tetkik
    /// </summary>
        protected TTObjectClasses.RadiologyTest _RadiologyTest
        {
            get { return (TTObjectClasses.RadiologyTest)_ttObject; }
        }

        protected ITTTextBox AppointmentInformation;
        protected ITTLabel labelAppointmentInformation;
        override protected void InitializeControls()
        {
            AppointmentInformation = (ITTTextBox)AddControl(new Guid("e7a242e2-5613-4b90-bd6a-269a0cc9ed05"));
            labelAppointmentInformation = (ITTLabel)AddControl(new Guid("de7c034e-5305-48e5-a4ca-d110081439c8"));
            base.InitializeControls();
        }

        public RadiologyTestAppointmentForm() : base("RADIOLOGYTEST", "RadiologyTestAppointmentForm")
        {
        }

        protected RadiologyTestAppointmentForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}