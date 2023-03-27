
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
    /// Aşı Takip Modülü
    /// </summary>
    public partial class VaccineFollowUpForm : EpisodeActionForm
    {
    /// <summary>
    /// Nabız 207 Aşı Veri Seti
    /// </summary>
        protected TTObjectClasses.VaccineFollowUp _VaccineFollowUp
        {
            get { return (TTObjectClasses.VaccineFollowUp)_ttObject; }
        }

        protected ITTGrid VaccineDetails;
        protected ITTTextBoxColumn VaccineNameVaccineDetails;
        protected ITTTextBoxColumn PeriodNameVaccineDetails;
        protected ITTTextBoxColumn PeriodRangeVaccineDetails;
        protected ITTEnumComboBoxColumn PeriodUnitVaccineDetails;
        protected ITTDateTimePickerColumn AppointmentDateVaccineDetails;
        protected ITTDateTimePickerColumn ApplicationDateVaccineDetails;
        protected ITTTextBoxColumn NotesVaccineDetails;
        override protected void InitializeControls()
        {
            VaccineDetails = (ITTGrid)AddControl(new Guid("a3fe3427-1fbb-4470-adb3-37dc41c2026f"));
            VaccineNameVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("8e30c71a-d240-4e49-a6c2-3c991b752f61"));
            PeriodNameVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("a49dceb8-f019-4215-bdba-10f528ac11e3"));
            PeriodRangeVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("6c14d1db-803f-4ef9-ab59-6d9fbc29ce34"));
            PeriodUnitVaccineDetails = (ITTEnumComboBoxColumn)AddControl(new Guid("e64999d7-188d-492a-9e32-acb9848ef1c9"));
            AppointmentDateVaccineDetails = (ITTDateTimePickerColumn)AddControl(new Guid("12d76d9c-3e28-4dc8-bdfd-e69d7a9a14d0"));
            ApplicationDateVaccineDetails = (ITTDateTimePickerColumn)AddControl(new Guid("32cbe415-4d28-47b1-8799-33e3d640e8d1"));
            NotesVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("e01b2bb8-0af4-4f70-8056-a74f44282ce1"));
            base.InitializeControls();
        }

        public VaccineFollowUpForm() : base("VACCINEFOLLOWUP", "VaccineFollowUpForm")
        {
        }

        protected VaccineFollowUpForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}