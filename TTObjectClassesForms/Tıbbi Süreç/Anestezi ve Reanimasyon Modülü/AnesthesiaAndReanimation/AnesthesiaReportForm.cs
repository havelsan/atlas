
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
    /// Anestezi ve Reanimasyon
    /// </summary>
    public partial class AnesthesiaReportForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            
            GridAnesthesiaExpends.CellValueChanged += new TTGridCellEventDelegate(GridAnesthesiaExpends_CellValueChanged);
            GridSurgeryProcedures.CellContentClick += new TTGridCellEventDelegate(GridSurgeryProcedures_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {

            GridAnesthesiaExpends.CellValueChanged -= new TTGridCellEventDelegate(GridAnesthesiaExpends_CellValueChanged);
            GridSurgeryProcedures.CellContentClick -= new TTGridCellEventDelegate(GridSurgeryProcedures_CellContentClick);
            base.UnBindControlEvents();
        }



        private void GridAnesthesiaExpends_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region AnesthesiaReportForm_GridAnesthesiaExpends_CellValueChanged
   if (GridAnesthesiaExpends.CurrentCell.OwningColumn.Name == "SMStore")
            {
                BaseTreatmentMaterial treatmentMaterial = (BaseTreatmentMaterial)((ITTGridRow)this.GridAnesthesiaExpends.Rows[rowIndex]).TTObject;
                if(treatmentMaterial != null)
                {
                    SMMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(treatmentMaterial.Store.ObjectID);
                }
            }
#endregion AnesthesiaReportForm_GridAnesthesiaExpends_CellValueChanged
        }

        private void GridSurgeryProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region AnesthesiaReportForm_GridSurgeryProcedures_CellContentClick
   //            if (((ITTGridCell)GridSurgeryProcedure.CurrentCell).OwningColumn.Name == "ameliyatCokluOzelDurum")
//            {
//                AnesthesiaCokluOzelDurum acod = new AnesthesiaCokluOzelDurum();
//                acod.ShowEdit(this.FindForm(), this._AnesthesiaAndReanimation);
//            }
#endregion AnesthesiaReportForm_GridSurgeryProcedures_CellContentClick
        }



        protected override void PreScript()
        {
#region AnesthesiaReportForm_PreScript
    base.PreScript();
            if(this.Owner is SurgeryPricingForm)
                this.SetFormReadOnly();
            if(this._AnesthesiaAndReanimation.CurrentStateDefID!=AnesthesiaAndReanimation.States.Completed)
            {
                this.DropStateButton(AnesthesiaAndReanimation.States.Cancelled);
            }
            int removedTabCount=0;
            if(this._AnesthesiaAndReanimation.MainSurgery!=null)
            {
                //this.GridAnesthesiaProcedures.ReadOnly=true;
                
                if (this.TabSubaction.TabPages.Contains(this.AnesthesiaProcedure))
                {
                    this.TabSubaction.TabPages.RemoveAt(this.AnesthesiaProcedure.DisplayIndex-removedTabCount);
                    removedTabCount++;
                }

                if (_AnesthesiaAndReanimation.MainSurgery.CurrentStateDefID == Surgery.States.Rejected)
                {
                    string[] hataParamList = new string[] { _AnesthesiaAndReanimation.MainSurgery.ReasonOfReject.ToString() };
                    String message = SystemMessage.GetMessageV3(209, hataParamList);
                    InfoBox.Show(message);
                    //InfoBox.Show("Ameliyat Yapılamaz. Sebebi :\n\r " + _AnesthesiaAndReanimation.MainSurgery.ReasonOfReject.ToString());
                }
            
            }
            else
            {
                this.GridAnesthesiaProcedures.ReadOnly=false;
                if (this.TabSubaction.TabPages.Contains(this.SurgeryInfo))
                {
                    this.TabSubaction.TabPages.RemoveAt(this.SurgeryInfo.DisplayIndex-removedTabCount);
                    removedTabCount++;
                    
                }

                //ProcedureDoctor2.Visible = false;  // 2 Doktor yalnız Ameliyatla bir olur
                //labelProcedureDoctor2.Visible = false;
            }
            if (this._AnesthesiaAndReanimation.CurrentStateDefID==AnesthesiaAndReanimation.States.AnesthesiaReport)
            {
                if(this._AnesthesiaAndReanimation.AnesthesiaReportDate==null)
                {
                    this._AnesthesiaAndReanimation.AnesthesiaReportDate=Common.RecTime();
                }
                this.SetProcedureDoctorAsCurrentResource();
            }
            

               this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["AnesthesiaAndReanimationTreatmentMaterial"], (ITTGridColumn)this.GridAnesthesiaExpends.Columns["SMMaterial"]);
#endregion AnesthesiaReportForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AnesthesiaReportForm_PostScript
    base.PostScript(transDef);
            if(transDef!=null)
            {
                if(transDef.FromStateDef.StateDefID==AnesthesiaAndReanimation.States.AnesthesiaReport)
                {
                    this._AnesthesiaAndReanimation.CheckAnesthesiaTime();
                    if (this._AnesthesiaAndReanimation.AnesthesiaTechnique == null)
                    {
                        string[] hataParamList = new string[] { "'Gerçekleşen Anestezi Tekniği'" };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                        //throw new Exception("'Gerçekleşen Anestezi Tekniği' girilmeden işlem tamamlanamaz.");
                    }

                    if (this._AnesthesiaAndReanimation.AnesthesiaPersonnels.Count < 1)
                    {
                        string[] hataParamList = new string[] { "'Anestezi Ekibi'" };
                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                        //throw new Exception("'Anestezi Ekibi' girilmeden işlem tamamlanamaz.");
                    }
                }
                
                if(transDef.ToStateDef.StateDefID==AnesthesiaAndReanimation.States.Completed)
                {
                    this._AnesthesiaAndReanimation.CheckAnesthesiaTime();
                    if(this._AnesthesiaAndReanimation.IsTreatmentMaterialEmpty!=true)
                    {
                        if (this._AnesthesiaAndReanimation.TreatmentMaterials.Count < 1)
                        {
                            throw new TTUtils.TTException(SystemMessage.GetMessage(207));
                           // throw new Exception("Sarf Girişi yapılmadan işlem tamamlanamaz.");
                        }
                    }
                }
            }
#endregion AnesthesiaReportForm_PostScript

            }
                }
}