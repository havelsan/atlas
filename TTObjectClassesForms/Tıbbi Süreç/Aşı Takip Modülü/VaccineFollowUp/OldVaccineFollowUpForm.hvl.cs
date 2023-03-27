
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
    public partial class OldVaccineFollowUpForm : TTForm
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
            VaccineDetails = (ITTGrid)AddControl(new Guid("3e8edeb3-eb25-423f-9cd7-5bf68e7f4ec9"));
            VaccineNameVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("401dc30b-642c-4cba-ad18-ef78ecf92e94"));
            PeriodNameVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("4c9ac797-8045-446e-a7e1-add2f710c86e"));
            PeriodRangeVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("35703431-47b3-4844-b5c3-1c099fed136d"));
            PeriodUnitVaccineDetails = (ITTEnumComboBoxColumn)AddControl(new Guid("520acd05-ba59-458e-b889-873939c369b8"));
            AppointmentDateVaccineDetails = (ITTDateTimePickerColumn)AddControl(new Guid("630719ab-558e-40ca-9212-c278ce126cdb"));
            ApplicationDateVaccineDetails = (ITTDateTimePickerColumn)AddControl(new Guid("4967384b-e1d4-4e0d-8a5f-811c6ce77bd3"));
            NotesVaccineDetails = (ITTTextBoxColumn)AddControl(new Guid("7399fd59-6a2a-4636-9df4-af8fe8e162f1"));
            base.InitializeControls();
        }

        public OldVaccineFollowUpForm() : base("VACCINEFOLLOWUP", "OldVaccineFollowUpForm")
        {
        }

        protected OldVaccineFollowUpForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}