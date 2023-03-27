
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
    /// Ek Ameliyat
    /// </summary>
    public partial class SubSurgeryForm : EpisodeActionForm
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
#region SubSurgeryForm_PreScript
    base.PreScript();
            if( this._SubSurgery.SurgeryReportDate==null)
                this._SubSurgery.SurgeryReportDate=Common.RecTime();
            
            if(this.Owner is SurgeryPricingForm)
                this.SetFormReadOnly();
            
            //this.SetDiagnosisListFilter((ITTGridColumn)this.GridDiagnosis.Columns["SecDiagnose"]);
            if (this._SubSurgery.CurrentStateDefID==SubSurgery.States.SubSurgeryReport)
                this.SetProcedureDoctorAsCurrentResource();
#endregion SubSurgeryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SubSurgeryForm_PostScript
    base.PostScript(transDef);
            this._SubSurgery.SubSurgeryProceduresIsResquired();
            this._SubSurgery.SurgeryPersonnelIsResquired();
#endregion SubSurgeryForm_PostScript

            }
                }
}