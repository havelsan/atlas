
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
    public partial class DentalConsultationForm : DentalExaminationForm
    {
    /// <summary>
    /// DentalConsultation
    /// </summary>
        protected TTObjectClasses.DentalConsultation _DentalConsultation
        {
            get { return (TTObjectClasses.DentalConsultation)_ttObject; }
        }

        protected ITTTextBox txtSelectedToothNumbers;
        protected ITTLabel lblSelectedToothNumbers;
        override protected void InitializeControls()
        {
            txtSelectedToothNumbers = (ITTTextBox)AddControl(new Guid("74bd029b-6bb5-4a9c-a746-f7c9e0b4382a"));
            lblSelectedToothNumbers = (ITTLabel)AddControl(new Guid("b2fa9022-1b5d-4071-91e0-a76fce329804"));
            base.InitializeControls();
        }

        public DentalConsultationForm() : base("DENTALCONSULTATION", "DentalConsultationForm")
        {
        }

        protected DentalConsultationForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}