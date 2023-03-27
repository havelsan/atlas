
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
    /// Ameliyat Konsültasyon
    /// </summary>
    public partial class AnesthesiaConsultationForm : EpisodeActionForm
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
#region AnesthesiaConsultationForm_PreScript
    base.PreScript();
            //DP için kapatıldı
            /*if(_AnesthesiaConsultation.CurrentStateDefID == AnesthesiaConsultation.States.Approval)
                this.SetProcedureDoctorAsCurrentResource();*/
#endregion AnesthesiaConsultationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AnesthesiaConsultationForm_PostScript
    base.PostScript(transDef);
#endregion AnesthesiaConsultationForm_PostScript

            }
            
#region AnesthesiaConsultationForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            //if (transDef != null && transDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
            //{
            //    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            //    TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            //    objectID.Add("VALUE", _AnesthesiaConsultation.ObjectID.ToString());
            //    parameters.Add("TTOBJECTID",objectID);
            //    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_AnesthesiaReport), true, 1, parameters);
            //}
        }
        
#endregion AnesthesiaConsultationForm_Methods
    }
}