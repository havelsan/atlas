
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
    /// Sivil Memur Kabulü
    /// </summary>
    public partial class PA_MilitaryCivilOfficialForm : PatientAdmissionForm
    {
        override protected void BindControlEvents()
        {
            MilitaryUnit.SelectedObjectChanged += new TTControlEventDelegate(MilitaryUnit_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MilitaryUnit.SelectedObjectChanged -= new TTControlEventDelegate(MilitaryUnit_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void MilitaryUnit_SelectedObjectChanged()
        {
#region PA_MilitaryCivilOfficialForm_MilitaryUnit_SelectedObjectChanged
   if(this.SenderChair.SelectedObject == null)
                this.SenderChair.SelectedObject = this.MilitaryUnit.SelectedObject;
#endregion PA_MilitaryCivilOfficialForm_MilitaryUnit_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region PA_MilitaryCivilOfficialForm_PreScript
    base.PreScript();
#endregion PA_MilitaryCivilOfficialForm_PreScript

            }
                }
}