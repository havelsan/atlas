
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
    public partial class TreatmentDischargeDataCorrectionForm : BaseEpisodeActionDataCorrectionForm
    {
    /// <summary>
    /// Muayene Tedavi Sonuç Veri Düzeltme
    /// </summary>
        protected TTObjectClasses.TreatmentDischargeDataCorrection _TreatmentDischargeDataCorrection
        {
            get { return (TTObjectClasses.TreatmentDischargeDataCorrection)_ttObject; }
        }

        protected ITTLabel labelOldDischargeDate;
        protected ITTDateTimePicker OldDischargeDate;
        protected ITTLabel labelNewDischargeDate;
        protected ITTDateTimePicker NewDischargeDate;
        override protected void InitializeControls()
        {
            labelOldDischargeDate = (ITTLabel)AddControl(new Guid("6a45377e-0430-45d8-ba54-903f470e24dd"));
            OldDischargeDate = (ITTDateTimePicker)AddControl(new Guid("6805d111-0473-4de2-9740-aebaed47abd7"));
            labelNewDischargeDate = (ITTLabel)AddControl(new Guid("d6728a7b-a128-472f-9c6e-1fe6dcdc8483"));
            NewDischargeDate = (ITTDateTimePicker)AddControl(new Guid("8e74d7ca-6b30-4a36-a1a4-ba116b03969b"));
            base.InitializeControls();
        }

        public TreatmentDischargeDataCorrectionForm() : base("TREATMENTDISCHARGEDATACORRECTION", "TreatmentDischargeDataCorrectionForm")
        {
        }

        protected TreatmentDischargeDataCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}