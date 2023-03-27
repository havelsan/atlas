
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
    public partial class BasePatientDataCorrectionForm : BaseDataCorrectionForm
    {
        protected TTObjectClasses.BasePatientDataCorrection _BasePatientDataCorrection
        {
            get { return (TTObjectClasses.BasePatientDataCorrection)_ttObject; }
        }

        protected ITTLabel labelPatient;
        protected ITTObjectListBox Patient;
        override protected void InitializeControls()
        {
            labelPatient = (ITTLabel)AddControl(new Guid("adec6cc5-6c3a-4aac-80f9-cfee759c5afe"));
            Patient = (ITTObjectListBox)AddControl(new Guid("7d043f24-c5aa-4c05-b4e1-4cb65fefb96d"));
            base.InitializeControls();
        }

        public BasePatientDataCorrectionForm() : base("BASEPATIENTDATACORRECTION", "BasePatientDataCorrectionForm")
        {
        }

        protected BasePatientDataCorrectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}