
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
    /// Yoğun Bakım Tanımı
    /// </summary>
    public partial class IntensiveCareDefinitionForm : TTForm
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
#region IntensiveCareDefinitionForm_PostScript
    base.PostScript(transDef);
            if (this._ResIntensiveCare.EnabledType==null)
            {
                this._ResIntensiveCare.EnabledType=ResourceEnableType.InPatient;
            }
            if(this._ResIntensiveCare.Hospital==null)
            {
                Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
                ResHospital hospital = (ResHospital)this._ResIntensiveCare.ObjectContext.GetObject(hospID, typeof(ResHospital));
                this._ResIntensiveCare.Hospital=hospital;
            }
#endregion IntensiveCareDefinitionForm_PostScript

            }
            
#region IntensiveCareDefinitionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            ResWard.SendResWardToDietRationSystem(this._ResIntensiveCare);
        }
        
#endregion IntensiveCareDefinitionForm_Methods
    }
}