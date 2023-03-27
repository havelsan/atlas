
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
    public partial class FollowUpExaminationApprovalForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridTreatmentMaterials.CellContentClick += new TTGridCellEventDelegate(GridTreatmentMaterials_CellContentClick);
            GridEpisodeDiagnosis.CellContentClick += new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridTreatmentMaterials.CellContentClick -= new TTGridCellEventDelegate(GridTreatmentMaterials_CellContentClick);
            GridEpisodeDiagnosis.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeDiagnosis_CellContentClick);
            base.UnBindControlEvents();
        }

        private void GridTreatmentMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region FollowUpExaminationApprovalForm_GridTreatmentMaterials_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)GridTreatmentMaterials.CurrentCell).OwningColumn.Name == "malzemeCokluOzelDurum")
            //{
            //    TreatmentMaterials_MedulaMalzemeForm codf = new TreatmentMaterials_MedulaMalzemeForm();
            //    BaseTreatmentMaterial inp = (BaseTreatmentMaterial)GridTreatmentMaterials.CurrentCell.OwningRow.TTObject;
            //    codf.ShowEdit(this.FindForm(), inp);



            //}
            var a = 1;
            #endregion FollowUpExaminationApprovalForm_GridTreatmentMaterials_CellContentClick
        }

        private void GridEpisodeDiagnosis_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region FollowUpExaminationApprovalForm_GridEpisodeDiagnosis_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)GridEpisodeDiagnosis.CurrentCell).OwningColumn.Name == "taniCokluOzelDurum")
            //{

            //    FollowUpExaminationCokluOzelDurum codf = new FollowUpExaminationCokluOzelDurum();
            //    codf.ShowEdit(this.FindForm(), this._FollowUpExamination);
            //}
            var a = 1;
            #endregion FollowUpExaminationApprovalForm_GridEpisodeDiagnosis_CellContentClick
        }

        protected override void PreScript()
        {
#region FollowUpExaminationApprovalForm_PreScript
    base.PreScript();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridTreatmentMaterials.Columns["Material"]);
         
#endregion FollowUpExaminationApprovalForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region FollowUpExaminationApprovalForm_PostScript
    base.PostScript(transDef);
#endregion FollowUpExaminationApprovalForm_PostScript

            }
                }
}