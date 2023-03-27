
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
    /// Tıbbi Genetik Onayda Formu
    /// </summary>
    public partial class GeneticApprovementForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            grdGeneticTests.CellValueChanged += new TTGridCellEventDelegate(grdGeneticTests_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            grdGeneticTests.CellValueChanged -= new TTGridCellEventDelegate(grdGeneticTests_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void grdGeneticTests_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region GeneticApprovementForm_grdGeneticTests_CellValueChanged
   //            ITTGridCell changedCell = grdGeneticTests.Rows[rowIndex].Cells[columnIndex];
//            
//            if (changedCell.OwningColumn.Name == this.drAnesteziTescilNo.Name)
//            {
//                if(changedCell.Value != null)
//                {
//                    GeneticTest obj=(GeneticTest)changedCell.OwningRow.TTObject;
//                    TTObjectContext context = this._Genetic.ObjectContext;
//                    ResUser user = (ResUser)context.GetObject(new Guid(changedCell.Value.ToString()), typeof(ResUser));
//                    obj.drAnesteziTescilNo = user.DiplomaRegisterNo;
//                }
//                
//            }
#endregion GeneticApprovementForm_grdGeneticTests_CellValueChanged
        }

        protected override void PreScript()
        {
#region GeneticApprovementForm_PreScript
    base.PreScript();
            this.DropStateButton(Genetic.States.Rejected);
            
         /*   if(this._Genetic.CurrentStateDefID == Genetic.States.Approvement)
                this.pictGenealogialTree.ReadOnly = false;*/
            
            if( this._Genetic.GeneticTests.Count > 0 )
                this.TestToStudyTTListBox.SelectedObject  = (GeneticTestDefinition)((GeneticTest)this._Genetic.GeneticTests[0]).ProcedureObject;

            if (SubEpisode.IsSGKSubEpisode(_Genetic.SubEpisode) && this.grdGeneticTests.Rows.Count > 0)
            {
                for (int i = 0; i < this.grdGeneticTests.Rows.Count; i++)
                {
                    this.grdGeneticTests.Rows[i].Cells[2].Required = true;
                    this.grdGeneticTests.Rows[i].Cells[1].Required = true;
                    this.grdGeneticTests.Rows[i].Cells[7].Required = true;
                }
            }
            
            
             this.SetProcedureDoctorAsCurrentResource();
            
            //nneee
#endregion GeneticApprovementForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region GeneticApprovementForm_PostScript
    base.PostScript(transDef);
#endregion GeneticApprovementForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region GeneticApprovementForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
             if(transDef != null)
            {
                if (transDef.ToStateDefID == Genetic.States.Procedure || transDef.ToStateDefID == Genetic.States.Request || transDef.ToStateDefID == Genetic.States.RequestAcception)
                    DisplayRepeatReason();
            }
#endregion GeneticApprovementForm_ClientSidePostScript

        }

#region GeneticApprovementForm_ClientSideMethods
        public void DisplayRepeatReason()
        {
            IList repeatList = GeneticRepeatReasonDef.GetAll(_Genetic.ObjectContext);
            MultiSelectForm repeatFrm = new MultiSelectForm();
            int i = 1;
            foreach(GeneticRepeatReasonDef reason in repeatList)
            {
                repeatFrm.AddMSItem(reason.Reason.ToString(),"K-" + i.ToString(), reason);
                i = i+1;
            }
            string key = repeatFrm.GetMSItem(null, "Tekrar Nedeni Seçiniz",false,false,false,false,false,true);
            _Genetic.RepetitionReason = (GeneticRepeatReasonDef)repeatFrm.MSSelectedItemObject;
        }
        
#endregion GeneticApprovementForm_ClientSideMethods
    }
}