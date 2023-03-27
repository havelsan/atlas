
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
    public partial class LaboratoryRequestInfoForm : TTForm
    {
    /// <summary>
    /// Laboratuvar
    /// </summary>
        protected TTObjectClasses.LaboratoryRequest _LaboratoryRequest
        {
            get { return (TTObjectClasses.LaboratoryRequest)_ttObject; }
        }

        protected ITTTextBox PreDiagnosis;
        protected ITTTextBox Note;
        protected ITTCheckBox Urgent;
        protected ITTLabel labelPreInformation;
        protected ITTLabel ttlabel1;
        protected ITTEnumComboBox Gebelik;
        protected ITTLabel labelGebelik;
        protected ITTLabel labelSonAdetTarihi;
        protected ITTDateTimePicker SonAdetTarihi;
        override protected void InitializeControls()
        {
            PreDiagnosis = (ITTTextBox)AddControl(new Guid("fef8d652-f40b-4bf6-8411-7724ae96eade"));
            Note = (ITTTextBox)AddControl(new Guid("9eef4053-dfcb-4469-8df5-fdf902d03c73"));
            Urgent = (ITTCheckBox)AddControl(new Guid("3eb391aa-f3c6-43d2-aa21-3ad63a213b4a"));
            labelPreInformation = (ITTLabel)AddControl(new Guid("573ffc6d-0576-4f14-b89e-0d43dc2a3659"));
            ttlabel1 = (ITTLabel)AddControl(new Guid("fedc3de9-f153-41e3-8a36-140cf694057f"));
            Gebelik = (ITTEnumComboBox)AddControl(new Guid("dee701bd-ecee-41fc-8e87-1f5dd9871e13"));
            labelGebelik = (ITTLabel)AddControl(new Guid("7f74f888-45d4-4663-b9d5-c641d501f179"));
            labelSonAdetTarihi = (ITTLabel)AddControl(new Guid("b41e2f15-0e2f-4500-b4d8-1e6d7d1d3852"));
            SonAdetTarihi = (ITTDateTimePicker)AddControl(new Guid("7cf52edd-eda0-484a-8161-4ca2f7a985d7"));
            base.InitializeControls();
        }

        public LaboratoryRequestInfoForm() : base("LABORATORYREQUEST", "LaboratoryRequestInfoForm")
        {
        }

        protected LaboratoryRequestInfoForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}