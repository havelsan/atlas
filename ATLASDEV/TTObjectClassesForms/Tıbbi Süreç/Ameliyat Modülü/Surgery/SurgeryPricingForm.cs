
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
    /// Ameliyat Ücretlendirme 
    /// </summary>
    public partial class SurgeryPricingForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridSurgeryProcedures.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryProcedures_CellValueChanged);
            GridSurgeryProcedures.CellContentClick += new TTGridCellEventDelegate(GridSurgeryProcedures_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridSurgeryProcedures.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryProcedures_CellValueChanged);
            GridSurgeryProcedures.CellContentClick -= new TTGridCellEventDelegate(GridSurgeryProcedures_CellContentClick);
            base.UnBindControlEvents();
        }

        private void GridSurgeryProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryPricingForm_GridSurgeryProcedures_CellValueChanged
   //            ITTGridCell changedCell = GridSurgeryProcedures.Rows[rowIndex].Cells[columnIndex];
            //            if (changedCell.OwningColumn.Name == DrAnesteziTescilNo.Name)
            //            {
            //                if(changedCell.Value != null)
            //                {
            //                    BaseSurgeryProcedure obj=(BaseSurgeryProcedure)changedCell.OwningRow.TTObject;
            //                    TTObjectContext context = _Surgery.ObjectContext;
            //                    ResUser user = (ResUser)context.GetObject(new Guid(changedCell.Value.ToString()), typeof(ResUser));
            //                    obj.DrAnesteziTescilNo = user.DiplomaRegisterNo;
            //                }
            //
            //            }
#endregion SurgeryPricingForm_GridSurgeryProcedures_CellValueChanged
        }

        private void GridSurgeryProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region SurgeryPricingForm_GridSurgeryProcedures_CellContentClick
            //TODO:ShowEdit!
            //if ((((ITTGridCell)GridSurgeryProcedures.CurrentCell).OwningColumn != null) && (((ITTGridCell)GridSurgeryProcedures.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //         {
            //             BaseSurAndManProcedure_CokluOzelDurumForm codf = new BaseSurAndManProcedure_CokluOzelDurumForm();
            //             BaseSurgeryAndManipulationProcedure inp = (BaseSurgeryAndManipulationProcedure)GridSurgeryProcedures.CurrentCell.OwningRow.TTObject;

            //             codf.ShowEdit(this.FindForm(), inp);
            //         }

            //         if(rowIndex < this.GridSurgeryProcedures.Rows.Count && rowIndex > -1 && columnIndex == 16)
            //         {
            //             try
            //             {
            //                 SurgeryProcedure surgeryProcedure = (SurgeryProcedure)((ITTGridRow)this.GridSurgeryProcedures.Rows[rowIndex]).TTObject;
            //                 if (surgeryProcedure != null)
            //                 {
            //                     if(surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
            //                     {
            //                         BaseSurgeryProcedureToothSchema frm = new BaseSurgeryProcedureToothSchema();
            //                         frm.ShowEdit(this.FindForm(), surgeryProcedure, true);

            //                         this.GridSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = string.Empty;
            //                         if(!string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
            //                         {
            //                             string toothNumberNames = string.Empty;
            //                             string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
            //                             foreach (string toothNumber in toothNumbers)
            //                             {
            //                                 TTDataDictionary.EnumValueDef enumValueDef = Common.GetEnumValueDefOfEnumValue("ToothNumberEnum", Int32.Parse(toothNumber));
            //                                 toothNumberNames += enumValueDef.DisplayText + ",";
            //                             }

            //                             if (!string.IsNullOrEmpty(toothNumberNames))
            //                                 this.GridSurgeryProcedures.Rows[rowIndex].Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
            //                         }
            //                     }
            //                     else
            //                         InfoBox.Show("Sadece diş ameliyatları için diş şeması açılabilir.", MessageIconEnum.InformationMessage);
            //                 }
            //             }
            //             catch (System.Exception ex)
            //             {
            //                 InfoBox.Show(ex);
            //             }
            //         }
            var a = 1;
#endregion SurgeryPricingForm_GridSurgeryProcedures_CellContentClick
        }

        protected override void PreScript()
        {
#region SurgeryPricingForm_PreScript
    base.PreScript();

            
            this.DropStateButton(Surgery.States.Cancelled);
            
            // Ameliyatlar gridindeki Alt Vaka alanının listesi filtrelenir
            ((ITTListBoxColumn)((ITTGridColumn)this.GridSurgeryProcedures.Columns["PackageSubEpisode"])).ListFilterExpression = "EPISODE.OBJECTID = '" +  _Surgery.Episode.ObjectID.ToString() + "'";
            
            ArrangeToothColumnsOfSurgeryGrid();
#endregion SurgeryPricingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryPricingForm_PostScript
    base.PostScript(transDef);
            if (transDef != null)
            {
                
                if (transDef.ToStateDefID == Surgery.States.Completed || transDef.ToStateDefID == Surgery.States.SurgeryRequest)
                {
                    if (this.ProcedureDoctor == null || this.ProcedureDoctor.SelectedObject == null)
                        throw new TTUtils.TTException("Sorumlu cerrah bilgisini giriniz!");
                }
            }
#endregion SurgeryPricingForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryPricingForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
                 if (transDef != null)
            {
                //if (transDef.ToStateDefID == Surgery.States.ControlSubSurgeries)
                //{
                //    StringEntryForm frm = new StringEntryForm();
                //    this._Surgery.ReturnToDoctorReason = this._Surgery.ReturnToDoctorReason + "\r\n\r\n" + Common.RecTime().ToString() + "\r\n" + frm.ShowAndGetStringForm("Doktora İade Sebebi");
                //}
            }
#endregion SurgeryPricingForm_ClientSidePostScript

        }

#region SurgeryPricingForm_Methods
        // Diş ameliyatı için gerekli diş bilgisi alanları enable/disable edilir, Diş ameliyatı ise Diş Numarası doldurulur
        public void ArrangeToothColumnsOfSurgeryGrid()
        {
            foreach (ITTGridRow row in GridSurgeryProcedures.Rows)
            {
                SurgeryProcedure surgeryProcedure = (SurgeryProcedure)row.TTObject;
                if (surgeryProcedure != null && surgeryProcedure.ProcedureObject != null && surgeryProcedure.ProcedureObject.MedulaProcedureType == MedulaSUTGroupEnum.disBilgileri)
                {
                    row.Cells["ToothSchema"].ReadOnly = false;
                    row.Cells["ToothNumber"].ReadOnly = true;
                    row.Cells["ToothAnomaly"].ReadOnly = false;
                    row.Cells["ToothCommitmentNumber"].ReadOnly = false;
                    
                    if(!string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
                    {
                        string toothNumberNames = string.Empty;
                        string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
                        foreach (string toothNumber in toothNumbers)
                        {
                            TTDataDictionary.EnumValueDef enumValueDef = Common.GetEnumValueDefOfEnumValueV2("ToothNumberEnum", Int32.Parse(toothNumber));
                            toothNumberNames += enumValueDef.DisplayText + ",";
                        }

                        if (!string.IsNullOrEmpty(toothNumberNames))
                            row.Cells["ToothNumber"].Value = toothNumberNames.Substring(0, toothNumberNames.Length - 1);
                    }
                }
                else
                {
                    row.Cells["ToothSchema"].ReadOnly = true;
                    row.Cells["ToothNumber"].ReadOnly = true;
                    row.Cells["ToothAnomaly"].ReadOnly = true;
                    row.Cells["ToothCommitmentNumber"].ReadOnly = true;
                }
            }
        }
        
#endregion SurgeryPricingForm_Methods
    }
}