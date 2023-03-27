
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
    /// Sivil Ücretli Kabul 
    /// </summary>
    public partial class PA_PaidCivilianForm : PatientAdmissionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region PA_PaidCivilianForm_PreScript
    base.PreScript();
//            if(this._PatientAdmission.Patient.IsRelativeOfSoldier.HasValue == true && this._PatientAdmission.Patient.IsRelativeOfSoldier.Value == true)
//                this._PA_PaidCivilian.IsRelativeOfSoldier=true;
//            else
//                this._PA_PaidCivilian.IsRelativeOfSoldier=false;
#endregion PA_PaidCivilianForm_PreScript

            }
                }
}