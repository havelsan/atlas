
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
    /// Poliklinik Tanımı
    /// </summary>
    public partial class PoliclinicDefinitionForm : TTForm
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
#region PoliclinicDefinitionForm_PostScript
    base.PostScript(transDef);
            base.PostScript(transDef);
            if (this._ResPoliclinic.EnabledType == null)
            {
                this._ResPoliclinic.EnabledType = ResourceEnableType.OutPatient;
            }
//            if (this._ResPoliclinic.Hospital == null)
//            {
//                Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
//                ResHospital hospital = (ResHospital)this._ResPoliclinic.ObjectContext.GetObject(hospID, typeof(ResHospital));
//                this._ResPoliclinic.Hospital = hospital;
//            }

            //if (this._ResPoliclinic.PatientAdmissionDefaultProcedures.Count < 0)
            //    throw new TTUtils.TTException("En az bir tane 'Hasta Kabul Sırasında  Başlatılacak Hizmet' seçiniz ");
            #endregion PoliclinicDefinitionForm_PostScript

        }
            
#region PoliclinicDefinitionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            ResPoliclinic.SendResPoliclinicToMainGateOperation(this._ResPoliclinic);
        }
        
#endregion PoliclinicDefinitionForm_Methods
    }
}