
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
    /// Ortez Protez
    /// </summary>
    public partial class OrthesisProsthesisDoctorApprovalForm : EpisodeActionForm
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
#region OrthesisProsthesisDoctorApprovalForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"], (ITTGridColumn)this.TreatmentMaterials.Columns["MMaterial"]);
#endregion OrthesisProsthesisDoctorApprovalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region OrthesisProsthesisDoctorApprovalForm_PostScript
    base.PostScript(transDef);
            if (this.ProcedureDoctor.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(669));
#endregion OrthesisProsthesisDoctorApprovalForm_PostScript

            }
                }
}