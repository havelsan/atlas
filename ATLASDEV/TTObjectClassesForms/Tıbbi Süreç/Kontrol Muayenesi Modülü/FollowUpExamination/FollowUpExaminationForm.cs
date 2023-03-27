
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
    /// Kontrol Muayenesi
    /// </summary>
    public partial class FollowUpExaminationForm : EpisodeActionForm
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
#region FollowUpExaminationForm_PreScript
    base.PreScript();
            if (this._FollowUpExamination.ProcedureDoctor == null)
            {
                foreach (AuthorizedUser authorizedUser in this._FollowUpExamination.AuthorizedUsers)
                {
                    this._FollowUpExamination.ProcedureDoctor = (ResUser)authorizedUser.User;
                    return;
                }
            }
            this.SetProcedureDoctorAsCurrentResource();
            if (this._FollowUpExamination.ProcessDate == null)
                this.ProcessDate.ControlValue = Common.RecTime();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);
         
#endregion FollowUpExaminationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FollowUpExaminationForm_PostScript
    base.PostScript(transDef);
            
            if (this.ProcedureDoctor.SelectedObject == null)
                throw new Exception(SystemMessage.GetMessage(669));
#endregion FollowUpExaminationForm_PostScript

            }
                }
}