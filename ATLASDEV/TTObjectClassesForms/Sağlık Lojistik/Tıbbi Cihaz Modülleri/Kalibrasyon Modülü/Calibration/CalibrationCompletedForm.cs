
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Tamamlanmış Kalibrasyon
    /// </summary>
    public partial class CalibrationCompletedForm : CalibrationBaseForm
    {
        override protected void BindControlEvents()
        {
            NotCalibration.CheckedChanged += new TTControlEventDelegate(NotCalibration_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            NotCalibration.CheckedChanged -= new TTControlEventDelegate(NotCalibration_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void NotCalibration_CheckedChanged()
        {
#region CalibrationCompletedForm_NotCalibration_CheckedChanged
   if ((bool)this.NotCalibration.Value)
            {
                this.CalibrationTests.Required = false;
            }
#endregion CalibrationCompletedForm_NotCalibration_CheckedChanged
        }
    }
}