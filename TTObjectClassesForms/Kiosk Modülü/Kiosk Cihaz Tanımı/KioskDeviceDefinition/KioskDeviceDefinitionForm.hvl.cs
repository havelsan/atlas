
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
    public partial class KioskDeviceDefinitionForm : TTForm
    {
    /// <summary>
    /// Kiosk Cihaz Tanımı
    /// </summary>
        protected TTObjectClasses.KioskDeviceDefinition _KioskDeviceDefinition
        {
            get { return (TTObjectClasses.KioskDeviceDefinition)_ttObject; }
        }

        protected ITTCheckBox HasPatientResult;
        protected ITTCheckBox HasMernisVerification;
        protected ITTCheckBox HasPatientAdmission;
        protected ITTLabel labelDeviceName;
        protected ITTTextBox DeviceName;
        override protected void InitializeControls()
        {
            HasPatientResult = (ITTCheckBox)AddControl(new Guid("b64b89d4-c9ed-4f13-9448-6411d28708e7"));
            HasMernisVerification = (ITTCheckBox)AddControl(new Guid("3969510a-e008-42df-b712-d74b1d161659"));
            HasPatientAdmission = (ITTCheckBox)AddControl(new Guid("ddcbaddf-e1cd-42ff-a41a-fff18880e39f"));
            labelDeviceName = (ITTLabel)AddControl(new Guid("d5661680-3e6e-4619-a01c-65bbca5ff618"));
            DeviceName = (ITTTextBox)AddControl(new Guid("274d9d45-fef3-4fbb-b15e-15ea2247c68d"));
            base.InitializeControls();
        }

        public KioskDeviceDefinitionForm() : base("KIOSKDEVICEDEFINITION", "KioskDeviceDefinitionForm")
        {
        }

        protected KioskDeviceDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}