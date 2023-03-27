
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
    public partial class DoctorQuotaDefForm : TTDefinitionForm
    {
        protected TTObjectClasses.DoctorQuotaDefinition _DoctorQuotaDefinition
        {
            get { return (TTObjectClasses.DoctorQuotaDefinition)_ttObject; }
        }

        protected ITTLabel labelResultEndtTime;
        protected ITTDateTimePicker ResultEndtTime;
        protected ITTLabel labelResultStartTime;
        protected ITTDateTimePicker ResultStartTime;
        protected ITTCheckBox AutomaticReception;
        protected ITTLabel lblQuota;
        protected ITTTextBox txtQuota;
        protected ITTCheckBox IsActive;
        protected ITTLabel labelPoliclinic;
        protected ITTObjectListBox Policlinic;
        protected ITTLabel labelResource;
        protected ITTObjectListBox ProcedureDoctor;
        protected ITTLabel labelWorkDate;
        protected ITTDateTimePicker WorkDate;
        override protected void InitializeControls()
        {
            labelResultEndtTime = (ITTLabel)AddControl(new Guid("90c8fb60-d820-407a-a80b-da6e11b427a4"));
            ResultEndtTime = (ITTDateTimePicker)AddControl(new Guid("6be3b143-4148-4829-b181-f2f380f05da5"));
            labelResultStartTime = (ITTLabel)AddControl(new Guid("a6e4a751-da8d-4da9-a06c-0b62c61bcb5c"));
            ResultStartTime = (ITTDateTimePicker)AddControl(new Guid("2e34b97d-b439-4c11-a61d-f06baecd5b94"));
            AutomaticReception = (ITTCheckBox)AddControl(new Guid("cd1b899c-a109-4d1f-8f46-9f08c3e3079e"));
            lblQuota = (ITTLabel)AddControl(new Guid("fb9436bc-368b-42be-bbf4-89c2513dccc7"));
            txtQuota = (ITTTextBox)AddControl(new Guid("c6edd313-3fea-4146-bd25-74481c1bfaf5"));
            IsActive = (ITTCheckBox)AddControl(new Guid("14d3d976-51ff-4a01-9425-97727a7960a5"));
            labelPoliclinic = (ITTLabel)AddControl(new Guid("28f7e367-bfec-4d85-a031-eb68b6198f2e"));
            Policlinic = (ITTObjectListBox)AddControl(new Guid("82253b05-0b95-4808-9e1e-513deca9cdd1"));
            labelResource = (ITTLabel)AddControl(new Guid("b4b4bc5a-9b4d-4a4c-a9db-1f73f6b4fcbb"));
            ProcedureDoctor = (ITTObjectListBox)AddControl(new Guid("b02d749d-2cbd-4f18-bdde-5d6d1631e6a4"));
            labelWorkDate = (ITTLabel)AddControl(new Guid("947269ea-ea7b-4b4b-bd61-185b089a8fc3"));
            WorkDate = (ITTDateTimePicker)AddControl(new Guid("709bdd2c-522e-4030-bdc7-cdbe8e5f4aa9"));
            base.InitializeControls();
        }

        public DoctorQuotaDefForm() : base("DOCTORQUOTADEFINITION", "DoctorQuotaDefForm")
        {
        }

        protected DoctorQuotaDefForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}