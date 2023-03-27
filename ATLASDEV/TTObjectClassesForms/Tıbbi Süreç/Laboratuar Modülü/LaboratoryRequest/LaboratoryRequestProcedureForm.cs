
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
    /// Laboratuvar İstek İşlemde Formu
    /// </summary>
    public partial class LaboratoryRequestProcedureForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            cmdSendRequest.Click += new TTControlEventDelegate(cmdSendRequest_Click);
            GridLabProcedures.CellContentClick += new TTGridCellEventDelegate(GridLabProcedures_CellContentClick);
            ttPrintResultReport.Click += new TTControlEventDelegate(ttPrintResultReport_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSendRequest.Click -= new TTControlEventDelegate(cmdSendRequest_Click);
            GridLabProcedures.CellContentClick -= new TTGridCellEventDelegate(GridLabProcedures_CellContentClick);
            ttPrintResultReport.Click -= new TTControlEventDelegate(ttPrintResultReport_Click);
            base.UnBindControlEvents();
        }

        private void cmdSendRequest_Click()
        {
#region LaboratoryRequestProcedureForm_cmdSendRequest_Click
   if (this._LaboratoryRequest.LaboratoryProcedures.Count == 0)
            {
                String message = SystemMessage.GetMessage(198);
                TTVisual.InfoBox.Show(message);
                return;
            }

           // Cursor current = Cursor.Current;
          //  Cursor.Current = Cursors.WaitCursor;
            try
            {
                string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
                //if(this._LaboratoryRequest.IsRequestSent == true)
                //{
                //    TTVisual.InfoBox.Show("İstek zaten gönderilmiştir.");
                //    return;
                //}

                if (sysparam == "TRUE")
                {
                    Guid messageID = LaboratoryRequest.SendToLabASync(this._LaboratoryRequest); //Entegrasyon için.
                    TTObjectContext context = new TTObjectContext(false);
                    LaboratoryRequest request = (LaboratoryRequest)context.GetObject(this._LaboratoryRequest.ObjectID, "LaboratoryRequest");
                    request.MessageID = messageID.ToString();
                    request.IsRequestSent = true;
                    context.Save();
                }
            }
            catch (Exception ex)
            {
                TTVisual.InfoBox.Show(ex);
            }
            finally
            {
                //Cursor.Current = current;
            }
#endregion LaboratoryRequestProcedureForm_cmdSendRequest_Click
        }

        private void GridLabProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LaboratoryRequestProcedureForm_GridLabProcedures_CellContentClick
   if (GridLabProcedures.CurrentCell != null)
            {
                LaboratoryProcedure procedure = (LaboratoryProcedure)GridLabProcedures.CurrentCell.OwningRow.TTObject;
                // MT Çoklu özel durum düğmesi basılınca Çoklu özel durum formu açılır.

                //TODO:ShowEdit!
                //if (((ITTGridCell)GridLabProcedures.CurrentCell).OwningColumn.Name == "cokluOzelDurum")
                //{
                //    LaboratoryCokluOzelDurumForm lcodf = new LaboratoryCokluOzelDurumForm();
                //    lcodf.ShowEdit(this.FindForm(), procedure, true);
                //}

                switch (GridLabProcedures.CurrentCell.OwningColumn.Name)
                {
                    case "cokluOzelDurum":
                        //TODO:ShowEdit!
                        //if (procedure.LaboratorySubProcedures.Count > 0)
                        //{
                        //    LaboratoryCokluOzelDurumForm lcod = new LaboratoryCokluOzelDurumForm();
                        //    lcod.ShowEdit(this.FindForm(), procedure, true);
                        //}
                        break;

                    case "Detail":
                        //TODO:ShowEdit!
                        //if (procedure.LaboratorySubProcedures.Count > 0)
                        //{
                        //    LaboratoryProcedureDetailForm detailForm = new LaboratoryProcedureDetailForm();
                        //    detailForm.ShowEdit(this.FindForm(), procedure, true);
                        //}
                        break;
                    case "Cancel":

                        // Rollback'li yapılacak
                        // Son test iptal edildiğinde bütün işlemi iptal etme veya bütün işlemi tamamlama yapılacak
                        //TODO:ShowEdit!
                        //DialogResult result = MessageBox.Show("Seçmiş olduğunuz tetkik iptal edilecektir.Devam etmek istiyor musunuz?", "İstek iptal ediliyor...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        //if (result == DialogResult.Yes)
                        //{

                        //    Cursor current = Cursor.Current;
                        //    Cursor.Current = Cursors.WaitCursor;
                        //    Guid savePoint = this._LaboratoryRequest.ObjectContext.BeginSavePoint();
                        //    try
                        //    {
                        //        bool hasUncompletedTest = false;
                        //        if (procedure.CurrentStateDefID == LaboratoryProcedure.States.SampleAccept || procedure.CurrentStateDefID == LaboratoryProcedure.States.New) //this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception) //|| procedure.CurrentStateDefID == LaboratoryProcedure.States.Procedure)
                        //        {
                        //            if(this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception || this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.Procedure)
                        //            {
                        //                if (procedure.LaboratorySubProcedures.Count > 0)
                        //                {
                        //                    foreach (LaboratorySubProcedure subProcedure in procedure.LaboratorySubProcedures)
                        //                    {
                        //                        subProcedure.CurrentStateDefID = LaboratorySubProcedure.States.Cancelled;
                        //                        LaboratoryRequest.CancelLabSubProcedure(subProcedure);
                        //                    }

                        //                }
                        //                procedure.CurrentStateDefID = LaboratoryProcedure.States.Cancelled;
                        //                procedure.Update();
                        //                LaboratoryRequest.CancelLabProcedure(procedure);
                        //                //                                foreach (LaboratoryProcedure labProcedure in this._LaboratoryRequest.LaboratoryProcedures)
                        //                //                                {
                        //                //                                    if ((labProcedure.CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                        //                //                                        && (labProcedure.CurrentStateDefID != LaboratoryProcedure.States.Completed)
                        //                //                                        && (labProcedure.CurrentStateDefID != LaboratoryProcedure.States.SampleReject))
                        //                //                                    {
                        //                //                                        hasUncompletedTest = true;
                        //                //                                        break;
                        //                //                                    }
                        //                //                                }
                        //                //                                if (!hasUncompletedTest)
                        //                //                                {
                        //                //                                    this._LaboratoryRequest.CancelLab();
                        //                //                                    this._LaboratoryRequest.CurrentStateDefID = LaboratoryRequest.States.Cancelled;
                        //                //                                }
                        //                this._LaboratoryRequest.ObjectContext.Save();
                        //            }
                        //            else
                        //            {
                        //                InfoBox.Show("'İptal gerçekleştirilemez!\r\n \r\nİptal İçin Gerekli Laboratuvar Durumu : 'İstek Kabul' veya 'İşlemde' olmalıdır"
                        //                             +"\r\n Mevcut Laboratuvar Durumu : ' " + this._LaboratoryRequest.CurrentStateDef.DisplayText.Trim() + " '");
                        //            }
                        //        }
                        //        else
                        //        {
                        //            InfoBox.Show("'İptal gerçekleştirilemez!\r\n \r\nİptal İçin Gerekli Tetkik Durumu : 'Numune Kabul' veya 'İstek' olmalıdır"
                        //                         +"\r\n Mevcut Tetkik Durumu : ' " + procedure.CurrentStateDef.DisplayText.Trim() + " '");
                        //        }
                        //    }
                        //    catch
                        //    {
                        //        this._LaboratoryRequest.ObjectContext.RollbackSavePoint(savePoint);

                        //        if (procedure.LaboratorySubProcedures.Count > 0)
                        //        {
                        //            foreach (LaboratorySubProcedure subProcedure in procedure.LaboratorySubProcedures)
                        //            {
                        //                LaboratoryRequest.RollbackCancelLabSubProcedure(subProcedure);
                        //            }
                        //        }

                        //        LaboratoryRequest.RollbackCancelLabProcedure(procedure);

                        //        throw;
                        //    }
                        //    finally
                        //    {
                        //        Cursor.Current = current;
                        //    }
                        //}
                        break;
                    default:
                        break;
                }
            }
#endregion LaboratoryRequestProcedureForm_GridLabProcedures_CellContentClick
        }

        private void ttPrintResultReport_Click()
        {
#region LaboratoryRequestProcedureForm_ttPrintResultReport_Click
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            
            TTReportTool.PropertyCache<object> cache1 = new TTReportTool.PropertyCache<object>();
            cache1.Add("VALUE", this._LaboratoryRequest.ObjectID.ToString());
            parameters.Add("TTOBJECTID",cache1);
            
            if(this._LaboratoryRequest.BarcodeID.HasValue)
            {
                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", this._LaboratoryRequest.BarcodeID.Value.ToString());
                parameters.Add("BARCODEID", cache);
            }
           
            
            try
            {
                //TODO:Cursor!
                //this.Cursor = Cursors.WaitCursor;
                
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_LaboratoryBarcodeResultReport), true, 1, parameters);
                
            }
            catch(Exception ex)
            {
                //TODO:Cursor!
                //this.Cursor = Cursors.Default;
                InfoBox.Show(ex.ToString(),MessageIconEnum.ErrorMessage);
            }
            finally
            {
                //TODO:Cursor!
                //this.Cursor = Cursors.Default;
            }
#endregion LaboratoryRequestProcedureForm_ttPrintResultReport_Click
        }

        protected override void PreScript()
        {
#region LaboratoryRequestProcedureForm_PreScript
    base.PreScript();
            
            if(this._LaboratoryRequest.BarcodeID != null)
            {
                this.labelBarcode.Visible = true;
                this.textBarcode.Visible = true;
                this.textBarcode.Text = this._LaboratoryRequest.BarcodeID.ToString();
            }
            
            if(this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.Procedure)
            {
                this.DropStateButton(LaboratoryRequest.States.Rejected);
                this.DropStateButton(LaboratoryRequest.States.Cancelled);
                this.cmdSendRequest.Visible = false;
            }
            
            
            Guid labManualResultEntry = new Guid("08c98bd6-2e6d-4b8e-96ce-e09b69936b4a");
            
            if(this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception && Common.CurrentUser.IsSuperUser == false)
            {
                if(!Common.CurrentUser.HasRole(labManualResultEntry))
                {
                    this.DropStateButton(LaboratoryRequest.States.Procedure);
                }
            }
            
            if(this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception && Common.CurrentUser.IsSuperUser == false)
                this.DropStateButton(LaboratoryRequest.States.Completed);
            
            if(this._LaboratoryRequest.CurrentStateDefID == LaboratoryRequest.States.Procedure && Common.CurrentUser.IsSuperUser == false)
            {
                if(!Common.CurrentUser.HasRole(labManualResultEntry))
                {
                    this.DropStateButton(LaboratoryRequest.States.Completed);
                }
            }
            
            
            TabForInformations.HideTabPage(TabPageFutureRequest);
#endregion LaboratoryRequestProcedureForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region LaboratoryRequestProcedureForm_PostScript
    base.PostScript(transDef);
            /*
            foreach(ITTGridRow row in GridLabProcedures)
            {
                if(row.Cells["Result"].Value != null)
                {
                    
                }
            }
            */
#endregion LaboratoryRequestProcedureForm_PostScript

            }
            
#region LaboratoryRequestProcedureForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            if(transDef != null && transDef.ToStateDefID ==  LaboratoryRequest.States.Completed)
            {
                foreach(LaboratoryProcedure labProc in this._LaboratoryRequest.LaboratoryProcedures)
                {
                    if(labProc.CurrentStateDefID != LaboratoryProcedure.States.Cancelled 
                       && labProc.CurrentStateDefID != LaboratoryProcedure.States.SampleReject
                       && labProc.CurrentStateDefID != LaboratoryProcedure.States.Completed
                       && labProc.CurrentStateDefID != LaboratoryProcedure.States.PendingCancel)
                    {
                        labProc.CurrentStateDefID = LaboratoryProcedure.States.Cancelled;
                        this._LaboratoryRequest.ObjectContext.Save();
                    }
                }
                
            }
        }
        
#endregion LaboratoryRequestProcedureForm_Methods
    }
}