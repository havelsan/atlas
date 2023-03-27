
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
    /// Diğer Birim(ler)den Sağlık Kurulu Muayenesi 
    /// </summary>
    public partial class HCEOCancelledForm : EpisodeActionForm
    {
    /// <summary>
    /// Diğer Birimlerden Sağlık Kurulu Muayenesi
    /// </summary>
        protected TTObjectClasses.HealthCommitteeExaminationFromOtherDepartments _HealthCommitteeExaminationFromOtherDepartments
        {
            get { return (TTObjectClasses.HealthCommitteeExaminationFromOtherDepartments)_ttObject; }
        }

        protected ITTTextBox ExplanationOfRejection;
        protected ITTTextBox ProtocolNo;
        protected ITTObjectListBox ReasonForExamination;
        protected ITTEnumComboBox PatientGroup;
        protected ITTLabel labelReasonForAdmission;
        protected ITTLabel labelRequestDate;
        protected ITTLabel labelProtocolNo;
        protected ITTDateTimePicker RequestDate;
        protected ITTLabel ttlabel4;
        protected ITTLabel ttlabel3;
        protected ITTObjectListBox ReasonForAdmission;
        protected ITTLabel labelReasonForExamination;
        override protected void InitializeControls()
        {
            ExplanationOfRejection = (ITTTextBox)AddControl(new Guid("990381ad-dffa-4103-b924-a4361e8d1389"));
            ProtocolNo = (ITTTextBox)AddControl(new Guid("b4c3319d-15ff-4033-91e3-c3022429067e"));
            ReasonForExamination = (ITTObjectListBox)AddControl(new Guid("b9a35c12-3cf7-43df-99c5-2fca3419722a"));
            PatientGroup = (ITTEnumComboBox)AddControl(new Guid("1177454a-d88b-4405-943c-3d3a217967c9"));
            labelReasonForAdmission = (ITTLabel)AddControl(new Guid("18ef5708-a3ae-485b-9d15-a21ffdd4b28a"));
            labelRequestDate = (ITTLabel)AddControl(new Guid("7ef52deb-6ccb-4094-9fda-e109a578b033"));
            labelProtocolNo = (ITTLabel)AddControl(new Guid("420406b9-793d-4415-8b6e-a1b8e78c26fc"));
            RequestDate = (ITTDateTimePicker)AddControl(new Guid("d3261dfc-999b-483f-ae37-e04f620b1e62"));
            ttlabel4 = (ITTLabel)AddControl(new Guid("abbe8d09-6657-4811-b8fc-de7e3e5bdbae"));
            ttlabel3 = (ITTLabel)AddControl(new Guid("b7491def-1f64-4496-a878-1d2e29509166"));
            ReasonForAdmission = (ITTObjectListBox)AddControl(new Guid("964477f4-e2b1-41c0-b867-85346e6102b6"));
            labelReasonForExamination = (ITTLabel)AddControl(new Guid("aab7296c-6cb4-4fb2-8175-5dd711415269"));
            base.InitializeControls();
        }

        public HCEOCancelledForm() : base("HEALTHCOMMITTEEEXAMINATIONFROMOTHERDEPARTMENTS", "HCEOCancelledForm")
        {
        }

        protected HCEOCancelledForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}