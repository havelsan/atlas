
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
    /// Donör Kabulü
    /// </summary>
    public partial class PA_DonorForm : PA_CivilianConsignmentForm
    {
    /// <summary>
    /// Donöri Kabulü
    /// </summary>
        protected TTObjectClasses.PA_Donor _PA_Donor
        {
            get { return (TTObjectClasses.PA_Donor)_ttObject; }
        }

        protected ITTCheckBox IsNotSGK;
        protected ITTLabel labelSurnamePerson;
        protected ITTLabel labelNamePerson;
        protected ITTLabel labelUniqueRefNoPerson;
        protected ITTTextBox txtNakilYapılacakHastaTC;
        protected ITTTextBox txtSurname;
        protected ITTTextBox txtName;
        protected ITTButton cmdSearchPatient;
        override protected void InitializeControls()
        {
            IsNotSGK = (ITTCheckBox)AddControl(new Guid("820b2d01-e45f-412f-af26-fae0fe6741df"));
            labelSurnamePerson = (ITTLabel)AddControl(new Guid("24250ac2-3a19-4399-a02f-568821d0b6af"));
            labelNamePerson = (ITTLabel)AddControl(new Guid("fa6a738c-43ba-4cb3-bdfc-780212339a0a"));
            labelUniqueRefNoPerson = (ITTLabel)AddControl(new Guid("b9c422af-485b-492a-96b8-ba041df7c9d4"));
            txtNakilYapılacakHastaTC = (ITTTextBox)AddControl(new Guid("e2443ac5-5c9b-4e12-8474-ac5f555ddd5b"));
            txtSurname = (ITTTextBox)AddControl(new Guid("59482b33-ef76-436d-b22a-dd8573df0f80"));
            txtName = (ITTTextBox)AddControl(new Guid("a03fecbe-07a3-49d9-a3f8-952a21350cfa"));
            cmdSearchPatient = (ITTButton)AddControl(new Guid("5c03309d-8380-4ae9-8ce5-b70a6cbd789e"));
            base.InitializeControls();
        }

        public PA_DonorForm() : base("PA_DONOR", "PA_DonorForm")
        {
        }

        protected PA_DonorForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}