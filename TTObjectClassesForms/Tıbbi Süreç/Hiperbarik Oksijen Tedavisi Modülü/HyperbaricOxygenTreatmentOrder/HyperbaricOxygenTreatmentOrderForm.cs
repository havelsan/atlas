
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
    /// Hiperbarik Oksijen Tedavi Emiri
    /// </summary>
    public partial class HyperbaricOxygenTreatmentOrderForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            OrderDetails.CellValueChanged += new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            OrderDetails.CellContentClick += new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OrderDetails.CellValueChanged -= new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            OrderDetails.CellContentClick -= new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void OrderDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region HyperbaricOxygenTreatmentOrderForm_OrderDetails_CellValueChanged
   ITTGridCell changedCell = OrderDetails.Rows[rowIndex].Cells[columnIndex];
            if (changedCell.OwningColumn.Name == DrAnesteziTescilNo.Name)
            {
                if(changedCell.Value != null)
                {
                    HyperbarikOxygenTreatmentOrderDetail obj=(HyperbarikOxygenTreatmentOrderDetail)changedCell.OwningRow.TTObject;
                    TTObjectContext context = _HyperbaricOxygenTreatmentOrder.ObjectContext;
                    ResUser user = (ResUser)context.GetObject(new Guid(changedCell.Value.ToString()), typeof(ResUser));
                    obj.DrAnesteziTescilNo = user.DiplomaRegisterNo;
                }
                
                
            }
#endregion HyperbaricOxygenTreatmentOrderForm_OrderDetails_CellValueChanged
        }

        private void OrderDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region HyperbaricOxygenTreatmentOrderForm_OrderDetails_CellContentClick
            //TODO:Showedit!
            //if (((ITTGridCell)OrderDetails.CurrentCell).OwningColumn.Name == "CokluOzelDurum")
            //         {
            //             HyperbarikOxygenTreatmentOrderDetail_CokluOzelDurumForm codf = new HyperbarikOxygenTreatmentOrderDetail_CokluOzelDurumForm();
            //             HyperbarikOxygenTreatmentOrderDetail inp = (HyperbarikOxygenTreatmentOrderDetail)OrderDetails.CurrentCell.OwningRow.TTObject;
            //             codf.ShowEdit(this.FindForm(), inp);
            //         }
            var a = 1;
            #endregion HyperbaricOxygenTreatmentOrderForm_OrderDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region HyperbaricOxygenTreatmentOrderForm_PreScript
    base.PreScript();
            if(this._HyperbaricOxygenTreatmentOrder.CurrentStateDefID != HyperbaricOxygenTreatmentOrder.States.Aborted)
            {
                this.labelReasonOfAbort.Visible = false;
                this.ReasonOfAbort.Visible = false;
            }
            bool found=false;
            foreach (HyperbarikOxygenTreatmentOrderDetail hOrderDetail in this._HyperbaricOxygenTreatmentOrder.OrderDetails)
            {
                if (hOrderDetail.CurrentStateDefID == HyperbarikOxygenTreatmentOrderDetail.States.Execution)
                {
                    found=true;
                }
            }
            if (found)
            {
                this.DropStateButton(HyperbaricOxygenTreatmentOrder.States.Completed);
            }
            else
            {
                this.DropStateButton(HyperbaricOxygenTreatmentOrder.States.Aborted);
            }
#endregion HyperbaricOxygenTreatmentOrderForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HyperbaricOxygenTreatmentOrderForm_PostScript
    base.PostScript(transDef);
#endregion HyperbaricOxygenTreatmentOrderForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region HyperbaricOxygenTreatmentOrderForm_ClientSidePostScript
    if (transDef != null)
            {
                if (transDef.ToStateDefID == HyperbaricOxygenTreatmentOrder.States.Aborted)
                {
                    if(PlannedAction.HasOrderDetailOnGivenState(HyperbarikOxygenTreatmentOrderDetail.States.Execution, _HyperbaricOxygenTreatmentOrder))
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","Tedaviyi sonlandırırsanız, tamamlanmamış Hiperbarik Oksijen Tedavisi uygulamaları iptal edilir. Devam etmek istediğinize emin misiniz?", 1);
                        if (result == "H")
                            throw new Exception("Tedaviyi sonlandırmaktan vazgeçildi.");
                    }
                }
                
                if (transDef.FromStateDefID == HyperbaricOxygenTreatmentOrder.States.Therapy &&  transDef.ToStateDefID == HyperbaricOxygenTreatmentOrder.States.Completed)
                {
                    Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    TTReportTool.PropertyCache<object> reportNoParam = new TTReportTool.PropertyCache<object>();
                    reportNoParam.Add("VALUE", this._HyperbaricOxygenTreatmentOrder.ObjectID);
                    parameter.Add("TTOBJECTID", reportNoParam);
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_HyperbaricOxygenResultReport), true, 1, parameter);
                }
            }
            
            base.ClientSidePostScript(transDef);
#endregion HyperbaricOxygenTreatmentOrderForm_ClientSidePostScript

        }

#region HyperbaricOxygenTreatmentOrderForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            
        }
        //        void ShowAction_ObjectUpdated(TTObject ttObject)
        //        {
        //            OnObjectUpdated(ttObject);
        //        }
        
#endregion HyperbaricOxygenTreatmentOrderForm_Methods
    }
}