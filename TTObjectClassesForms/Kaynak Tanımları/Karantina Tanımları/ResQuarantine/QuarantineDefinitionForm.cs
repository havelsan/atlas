
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
    /// Karantina Tanımı
    /// </summary>
    public partial class QuarantineDefinitionForm : TTForm
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
#region QuarantineDefinitionForm_PostScript
    base.PostScript(transDef);
            if (this._ResQuarantine.EnabledType!=ResourceEnableType.BothInpatientAndOutPatient)
            {
                this._ResQuarantine.EnabledType=ResourceEnableType.BothInpatientAndOutPatient;
            }
            Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
            ResHospital hospital = (ResHospital)this._ResQuarantine.ObjectContext.GetObject(hospID, typeof(ResHospital));
            if(this._ResQuarantine.Hospital!= hospital)
            {
                this._ResQuarantine.Hospital=hospital;
            }
#endregion QuarantineDefinitionForm_PostScript

            }
                }
}