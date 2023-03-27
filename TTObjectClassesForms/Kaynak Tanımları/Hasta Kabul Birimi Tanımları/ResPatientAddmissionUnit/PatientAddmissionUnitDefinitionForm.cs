
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
    /// Kayıt Kabul Tanımı
    /// </summary>
    public partial class PatientAddmissionUnitDefinitionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientAddmissionUnitDefinitionForm_PostScript
    base.PostScript(transDef);
            if (this._ResPatientAddmissionUnit.EnabledType!= ResourceEnableType.BothInpatientAndOutPatient )
            {
                this._ResPatientAddmissionUnit.EnabledType=ResourceEnableType.BothInpatientAndOutPatient;
            }
            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)this._ResPatientAddmissionUnit.ObjectContext.GetObject(hospID, typeof(ResHospital));
            if(this._ResPatientAddmissionUnit.Hospital!=hospital)
            {
                this._ResPatientAddmissionUnit.Hospital=hospital;
            }
#endregion PatientAddmissionUnitDefinitionForm_PostScript

            }
                }
}