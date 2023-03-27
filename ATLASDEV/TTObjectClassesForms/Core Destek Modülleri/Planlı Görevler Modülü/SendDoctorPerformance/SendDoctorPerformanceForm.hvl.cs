
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
    public partial class SendDoctorPerformanceForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Doktor Performans Gönder
    /// </summary>
        protected TTObjectClasses.SendDoctorPerformance _SendDoctorPerformance
        {
            get { return (TTObjectClasses.SendDoctorPerformance)_ttObject; }
        }

        protected ITTButton btnRunWithParams;
        protected ITTLabel lblDPStartDate;
        protected ITTDateTimePicker dtPickerDpEndDate;
        protected ITTDateTimePicker dtPickerDpStartDate;
        protected ITTLabel lblDPEndDate;
        override protected void InitializeControls()
        {
            btnRunWithParams = (ITTButton)AddControl(new Guid("e51b8fad-9e8c-4546-bff6-a0ff5fa84359"));
            lblDPStartDate = (ITTLabel)AddControl(new Guid("92fd5c0d-8ca6-4c31-9edc-c9506ce97bed"));
            dtPickerDpEndDate = (ITTDateTimePicker)AddControl(new Guid("3812233a-3208-466b-9d29-c6455518e541"));
            dtPickerDpStartDate = (ITTDateTimePicker)AddControl(new Guid("0b7dfabc-0d3f-4354-96a9-b4d6cfa1cd05"));
            lblDPEndDate = (ITTLabel)AddControl(new Guid("79be3cb8-c887-4ab8-972c-5feca20d3b6c"));
            base.InitializeControls();
        }

        public SendDoctorPerformanceForm() : base("SENDDOCTORPERFORMANCE", "SendDoctorPerformanceForm")
        {
        }

        protected SendDoctorPerformanceForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}