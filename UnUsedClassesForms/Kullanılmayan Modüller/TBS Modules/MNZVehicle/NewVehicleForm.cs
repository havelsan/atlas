
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
    /// Araç Giriş Formu
    /// </summary>
    public partial class NewVehicleForm : TTForm
    {
        override protected void BindControlEvents()
        {
            Mark.SelectedObjectChanged += new TTControlEventDelegate(Mark_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Mark.SelectedObjectChanged -= new TTControlEventDelegate(Mark_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void Mark_SelectedObjectChanged()
        {
#region NewVehicleForm_Mark_SelectedObjectChanged
   Console.WriteLine("Bu yeni versiyon yaw");
#endregion NewVehicleForm_Mark_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region NewVehicleForm_PreScript
    this._MNZVehicle.giveDefaultValue();
#endregion NewVehicleForm_PreScript

            }
                }
}