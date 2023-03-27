
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
    public partial class CalibrationBaseForm : BaseCMRActionForm
    {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
        protected TTObjectClasses.Calibration _Calibration
        {
            get { return (TTObjectClasses.Calibration)_ttObject; }
        }

        protected ITTToolStrip tttoolstrip1;
        override protected void InitializeControls()
        {
            tttoolstrip1 = (ITTToolStrip)AddControl(new Guid("0e3c929a-daf9-48ea-80b4-be9cc751df95"));
            base.InitializeControls();
        }

        public CalibrationBaseForm() : base("CALIBRATION", "CalibrationBaseForm")
        {
        }

        protected CalibrationBaseForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}