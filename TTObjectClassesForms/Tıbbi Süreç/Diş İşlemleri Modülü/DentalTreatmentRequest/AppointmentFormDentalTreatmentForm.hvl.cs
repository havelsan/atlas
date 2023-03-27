
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
    public partial class AppointmentFormDentalTreatment : EpisodeActionForm
    {
    /// <summary>
    /// Diş Tedavi İstek
    /// </summary>
        protected TTObjectClasses.DentalTreatmentRequest _DentalTreatmentRequest
        {
            get { return (TTObjectClasses.DentalTreatmentRequest)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextboxProtokolNo;
        protected ITTTextBox tttextboxDescription;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("69123f8b-442e-49c9-b77c-08666ad20b6e"));
            tttextboxProtokolNo = (ITTTextBox)AddControl(new Guid("8cf161eb-1b19-4ad8-8917-56957844988f"));
            tttextboxDescription = (ITTTextBox)AddControl(new Guid("78bb1231-320d-4e5a-9ffd-b4a941bd280c"));
            base.InitializeControls();
        }

        public AppointmentFormDentalTreatment() : base("DENTALTREATMENTREQUEST", "AppointmentFormDentalTreatment")
        {
        }

        protected AppointmentFormDentalTreatment(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}