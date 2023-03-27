
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
    public partial class PsychologicExaminationForm : TTForm
    {
        protected TTObjectClasses.PsychologicExamination _PsychologicExamination
        {
            get { return (TTObjectClasses.PsychologicExamination)_ttObject; }
        }

        protected ITTGrid PsychologyTests;
        protected ITTListBoxColumn ProcedureObjectPsychologyTest;
        protected ITTListBoxColumn ProcedureDoctorPsychologyTest;
        protected ITTListBoxColumn RequestedByUserPsychologyTest;
        protected ITTDateTimePickerColumn ActionDatePsychologyTest;
        protected ITTListBoxColumn ProcedureByUser;
        override protected void InitializeControls()
        {
            PsychologyTests = (ITTGrid)AddControl(new Guid("09997b9e-7b2d-497e-83e6-998f3ebf2112"));
            ProcedureObjectPsychologyTest = (ITTListBoxColumn)AddControl(new Guid("0569c373-80ae-47ed-9dd9-04be7bbe86de"));
            ProcedureDoctorPsychologyTest = (ITTListBoxColumn)AddControl(new Guid("1fa57d14-e0fb-46bc-b9d6-b64520730fe4"));
            RequestedByUserPsychologyTest = (ITTListBoxColumn)AddControl(new Guid("94643d35-5c99-4d45-a7f9-396a0ad1d785"));
            ActionDatePsychologyTest = (ITTDateTimePickerColumn)AddControl(new Guid("aa158557-3212-43e2-94ef-547a60ffc50d"));
            ProcedureByUser = (ITTListBoxColumn)AddControl(new Guid("3bcfbb0f-3c0e-40b9-90ab-86b600feb5f1"));
            base.InitializeControls();
        }

        public PsychologicExaminationForm() : base("PSYCHOLOGICEXAMINATION", "PsychologicExaminationForm")
        {
        }

        protected PsychologicExaminationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}