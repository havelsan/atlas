
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
    public partial class DepartmentPoliclinicDefinitionForm : TTForm
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
#region DepartmentPoliclinicDefinitionForm_PreScript
    base.PreScript();
            if(_ResPoliclinic.IsToBeConsultation != false)
                _ResPoliclinic.IsToBeConsultation = true;
#endregion DepartmentPoliclinicDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DepartmentPoliclinicDefinitionForm_PostScript
    base.PostScript(transDef);
            if (this._ResPoliclinic.EnabledType == null)
            {
                this._ResPoliclinic.EnabledType = ResourceEnableType.OutPatient;
            }
            //string clearedData = " :";
            //string startTime = this.txtResourceStartTime.Text.Trim();
            //startTime = startTime.Trim(clearedData.ToCharArray());

            //if (String.IsNullOrEmpty(startTime) == false)
            //{
            //    try
            //    {
            //        Convert.ToDateTime(this.txtResourceStartTime.Text).TimeOfDay.ToString();
            //        this._ResPoliclinic.ResourceStartTime = this.txtResourceStartTime.Text;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception("Girilen Başlama Saati uygun saat formatında değil." + ex.ToString());
            //    }
            //}
            //else
            //    this._ResPoliclinic.ResourceStartTime = string.Empty;
//            if (this._ResPoliclinic.Hospital == null)
//            {
//                Guid hospID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("HOSPITAL", Guid.Empty.ToString()));
//                ResHospital hospital = (ResHospital)this._ResPoliclinic.ObjectContext.GetObject(hospID, typeof(ResHospital));
//                this._ResPoliclinic.Hospital = hospital;
//            }

                //if(this._ResPoliclinic.PatientAdmissionDefaultProcedures.Count<0)
                //    throw new TTUtils.TTException("En az bir tane 'Hasta Kabul Sırasında  Başlatılacak Hizmet' seçiniz ");

                #endregion DepartmentPoliclinicDefinitionForm_PostScript

        }
            
#region DepartmentPoliclinicDefinitionForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            ResPoliclinic.SendResPoliclinicToMainGateOperation(this._ResPoliclinic);
        }
        
#endregion DepartmentPoliclinicDefinitionForm_Methods
    }
}