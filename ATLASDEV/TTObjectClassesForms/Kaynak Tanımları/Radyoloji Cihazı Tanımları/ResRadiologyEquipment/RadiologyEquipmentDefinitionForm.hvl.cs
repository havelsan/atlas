
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
    /// Radyoloji Cihaz Tanımları
    /// </summary>
    public partial class RadiologyEquipmentDefinitionForm : TTDefinitionForm
    {
    /// <summary>
    /// Radyoloji Cihazı
    /// </summary>
        protected TTObjectClasses.ResRadiologyEquipment _ResRadiologyEquipment
        {
            get { return (TTObjectClasses.ResRadiologyEquipment)_ttObject; }
        }

        protected ITTLabel ttlabel1;
        protected ITTTextBox tttextbox1;
        protected ITTCheckBox IsActive;
        override protected void InitializeControls()
        {
            ttlabel1 = (ITTLabel)AddControl(new Guid("4f00685e-b0e5-4c1f-868f-1c8970eb69ee"));
            tttextbox1 = (ITTTextBox)AddControl(new Guid("f3f2d5d1-5165-47f1-b179-7e4e2500eecd"));
            IsActive = (ITTCheckBox)AddControl(new Guid("af2c1b25-6dde-4a6d-a683-33b42d6d6b32"));
            base.InitializeControls();
        }

        public RadiologyEquipmentDefinitionForm() : base("RESRADIOLOGYEQUIPMENT", "RadiologyEquipmentDefinitionForm")
        {
        }

        protected RadiologyEquipmentDefinitionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}