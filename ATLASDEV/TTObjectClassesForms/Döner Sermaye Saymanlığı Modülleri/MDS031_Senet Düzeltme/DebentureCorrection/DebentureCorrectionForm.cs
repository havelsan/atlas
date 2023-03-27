
//using System;
//using System.Xml;
//using System.Data;
//using System.Text;
//using System.Drawing;
//using System.Reflection;
//using System.Collections;
//using System.Linq;
//using System.ComponentModel;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Collections.ObjectModel;
//using System.Runtime.InteropServices;

//using TTUtils;
//using TTObjectClasses;
//using TTDataDictionary;
//using TTCoreDefinitions;
//using TTConnectionManager;
//using TTInstanceManagement;
//using TTDefinitionManagement;
//using TTStorageManager.Security;

//using SmartCardWrapper;

//using TTStorageManager;
//using System.Runtime.Versioning;
//using System.Windows.Forms;
//using TTVisual;
//namespace TTFormClasses
//{
//    /// <summary>
//    /// Senet Düzeltme Formu
//    /// </summary>
//    public partial class DebentureCorrectionForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            GRIDNEWDEBENTURES.RowLeave += new TTGridCellEventDelegate(GRIDNEWDEBENTURES_RowLeave);
//            GRIDNEWDEBENTURES.CellContentClick += new TTGridCellEventDelegate(GRIDNEWDEBENTURES_CellContentClick);
//            GRIDNEWDEBENTURES.CellValueChanged += new TTGridCellEventDelegate(GRIDNEWDEBENTURES_CellValueChanged);
//            GRIDCANCELLABLEDEBENTURES.CellValueChanged += new TTGridCellEventDelegate(GRIDCANCELLABLEDEBENTURES_CellValueChanged);
//            GRIDCANCELLABLEDEBENTURES.CellContentClick += new TTGridCellEventDelegate(GRIDCANCELLABLEDEBENTURES_CellContentClick);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            GRIDNEWDEBENTURES.RowLeave -= new TTGridCellEventDelegate(GRIDNEWDEBENTURES_RowLeave);
//            GRIDNEWDEBENTURES.CellContentClick -= new TTGridCellEventDelegate(GRIDNEWDEBENTURES_CellContentClick);
//            GRIDNEWDEBENTURES.CellValueChanged -= new TTGridCellEventDelegate(GRIDNEWDEBENTURES_CellValueChanged);
//            GRIDCANCELLABLEDEBENTURES.CellValueChanged -= new TTGridCellEventDelegate(GRIDCANCELLABLEDEBENTURES_CellValueChanged);
//            GRIDCANCELLABLEDEBENTURES.CellContentClick -= new TTGridCellEventDelegate(GRIDCANCELLABLEDEBENTURES_CellContentClick);
//            base.UnBindControlEvents();
//        }

//        private void GRIDNEWDEBENTURES_RowLeave(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureCorrectionForm_GRIDNEWDEBENTURES_RowLeave
//   Debenture debenture = (Debenture)((ITTGridRow)GRIDNEWDEBENTURES.Rows[rowIndex]).TTObject;
//            if(debenture.Guarantor == null)
//                InfoBox.Show("Senetin  Kefil Bilgisini Oluşturmadınız!!!");
//#endregion DebentureCorrectionForm_GRIDNEWDEBENTURES_RowLeave
//        }

//        private void GRIDNEWDEBENTURES_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureCorrectionForm_GRIDNEWDEBENTURES_CellContentClick
//   //columnIndex == 3
//            if (rowIndex != -1)
//            {
//                if(this.GRIDNEWDEBENTURES.CurrentCell.OwningColumn.Name == "ENTERGUARANTORINFO" )
//                {
//                    bool hasCheck = false;
//                    for (int i = 0 ; i < this.GRIDCANCELLABLEDEBENTURES.Rows.Count ; i++)
//                    {
//                        if ((bool)this.GRIDCANCELLABLEDEBENTURES.Rows[i].Cells["CANCELLED"].Value == true)
//                        {
//                            hasCheck = true ;
//                            break;
//                        }
//                    }
//                    if (!hasCheck)
//                        InfoBox.Show("Önce İptal Edilecek Senetleri Seçmelisiniz !");
//                    else
//                    {
//                        Guid savePointGuid= this._DebentureCorrection.ObjectContext.BeginSavePoint();
//                        try
//                        {
                            
//                            Debenture debenture = (Debenture)((ITTGridRow)GRIDNEWDEBENTURES.Rows[rowIndex]).TTObject;
//                            DebentureGuarantor debentureGuarantor;
                            
//                            bool isNew = false ;
//                            if (this.GRIDNEWDEBENTURES.Rows[rowIndex].Cells["CREATENEWGUARANTOR"].Value != null)
//                            {
//                                isNew = (bool)this.GRIDNEWDEBENTURES.Rows[rowIndex].Cells["CREATENEWGUARANTOR"].Value;
//                            }
                            
//                            if(debenture.Guarantor == null )
                                
//                            {
//                                if (isNew)
//                                    debentureGuarantor = new DebentureGuarantor (this._DebentureCorrection.ObjectContext);
//                                else
                                    
//                                {
//                                    if (rowIndex == 0)
//                                    {
//                                        string firstCancelledDebObjID = "" ;
//                                        for (int i = 0 ; i < this.GRIDCANCELLABLEDEBENTURES.Rows.Count ; i++)
//                                        {
//                                            if ((bool)this.GRIDCANCELLABLEDEBENTURES.Rows[i].Cells["CANCELLED"].Value == true)
//                                            {
//                                                firstCancelledDebObjID = Convert.ToString(this.GRIDCANCELLABLEDEBENTURES.Rows[0].Cells["DEBENTUREOBJECTID"].Value);
//                                                break;
//                                            }
//                                        }
                                        
//                                        IList MyDebList = Debenture.GetByObjectID(this._DebentureCorrection.ObjectContext,firstCancelledDebObjID.ToString());
//                                        Debenture cancelledDeb = (Debenture)MyDebList[0];
//                                        debentureGuarantor = (DebentureGuarantor)cancelledDeb.Guarantor ;
//                                    }
//                                    else
//                                        debentureGuarantor = (DebentureGuarantor)((Debenture)((ITTGridRow)GRIDNEWDEBENTURES.Rows[0]).TTObject).Guarantor;
                                    
//                                }
//                            }
//                            else
//                                if (isNew)
//                            {
//                                debenture.Guarantor = null;
//                                debentureGuarantor = new DebentureGuarantor (this._DebentureCorrection.ObjectContext);
//                            }
//                            else
//                                debentureGuarantor = (DebentureGuarantor)((Debenture)((ITTGridRow)GRIDNEWDEBENTURES.Rows[rowIndex]).TTObject).Guarantor;
                            
//                            DebentureGuarantorForm frm = new DebentureGuarantorForm();
//                            DialogResult dialogResult;
//                            if (this._DebentureCorrection.CurrentStateDefID == DebentureCorrection.States.New)
//                                dialogResult  = frm.ShowEdit(this.FindForm(),debentureGuarantor);
//                            else
//                                dialogResult = frm.ShowReadOnly(this.FindForm(),debentureGuarantor);
                            
//                            if(dialogResult == DialogResult.OK)
//                                debenture.Guarantor = debentureGuarantor;
//                            else
//                                this._DebentureCorrection.ObjectContext.RollbackSavePoint(savePointGuid);
                            
//                        }
//                        catch(System.Exception ex)
//                        {
//                            InfoBox.Show(ex);
//                        }
//                    }
//                }
//            }
//#endregion DebentureCorrectionForm_GRIDNEWDEBENTURES_CellContentClick
//        }

//        private void GRIDNEWDEBENTURES_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureCorrectionForm_GRIDNEWDEBENTURES_CellValueChanged
//   //columnIndex == 2
//            if (rowIndex != -1)
//            {
//                if(this.GRIDNEWDEBENTURES.CurrentCell.OwningColumn.Name == "NDEBENTUREPRICE")
//                {
//                    double totalNewDebenture = 0;
//                    if (this._DebentureCorrection.Debentures.Count != 0)
//                    {
                        
//                        foreach(Debenture db in this._DebentureCorrection.Debentures)
//                        {
                            
//                            if (db.Price != null)
//                            {
//                                totalNewDebenture  = (double)totalNewDebenture + (double)db.Price ;
//                            }
//                        }
                        
//                    }
//                    _DebentureCorrection.NewCreatedTotalPrice = (double)totalNewDebenture;
//                }
//            }
//#endregion DebentureCorrectionForm_GRIDNEWDEBENTURES_CellValueChanged
//        }

//        private void GRIDCANCELLABLEDEBENTURES_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureCorrectionForm_GRIDCANCELLABLEDEBENTURES_CellValueChanged
//   if (columnIndex == 5 && rowIndex != -1)
                
//            {
//                if (!(bool)GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells[columnIndex].Value)
//                {
//                    _DebentureCorrection.CancelledTotalPrice   = _DebentureCorrection.CancelledTotalPrice - Convert.ToDouble(GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells[2].Value);
                    
//                }
//                else if ((bool)GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells[columnIndex].Value)
//                {
//                    _DebentureCorrection.CancelledTotalPrice  = (double)_DebentureCorrection.CancelledTotalPrice + Convert.ToDouble(GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells[2].Value);
//                }
//            }
//#endregion DebentureCorrectionForm_GRIDCANCELLABLEDEBENTURES_CellValueChanged
//        }

//        private void GRIDCANCELLABLEDEBENTURES_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region DebentureCorrectionForm_GRIDCANCELLABLEDEBENTURES_CellContentClick
//   if (rowIndex != -1)
//            {
//                if(GRIDCANCELLABLEDEBENTURES.CurrentCell.OwningColumn.Name == "GUARANTORINFO" )
//                {
//                    if (rowIndex < this.GRIDCANCELLABLEDEBENTURES.Rows.Count  && rowIndex > -1 )
//                    {
//                        string debentureObjectID = _DebentureCorrection.CancellableDebentures[rowIndex].DebentureObjectID.ToString();
//                        IList MyDebentureList = Debenture.GetByObjectID(_DebentureCorrection.ObjectContext,debentureObjectID);
                        
//                        if (MyDebentureList.Count == 0)
//                            throw new Exception("Kefil Bulunamadı");
//                        else
//                        {
//                            DebentureGuarantor debentureGuarantor;
//                            Debenture debenture ;
//                            foreach (Debenture db in MyDebentureList)
//                            {
//                                debenture = db ;
//                                debentureGuarantor = debenture.Guarantor ;
//                                DebentureGuarantorForm frm = new DebentureGuarantorForm();
//                                frm.ShowReadOnly(this.FindForm(),debentureGuarantor);
//                            }
//                        }
//                    }
//                }
//                // columnIndex == 4
//                if (GRIDCANCELLABLEDEBENTURES.CurrentCell.OwningColumn.Name == "CANCEL" && this._DebentureCorrection.CurrentStateDefID == DebentureCorrection.States.New && rowIndex != -1 )
//                {

//                    if (_DebentureCorrection.CancelledDebDocObjectId == null || _DebentureCorrection.CancelledDebDocObjectId == Convert.ToString(GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["RECEIPTDOCUMENTOBJECTID"].Value) || _DebentureCorrection.CancelledDebDocObjectId == Convert.ToString(GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["ADVANCEDOCUMENTOBJECTID"].Value))
//                    {
//                        if (!(bool)GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["CANCELLED"].Value)
//                        {
                            
//                            GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["CANCELLED"].Value = true;
                            
//                            if (GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["RECEIPTDOCUMENTOBJECTID"].Value != null && _DebentureCorrection.CancelledDebDocObjectId == null)
//                                _DebentureCorrection.CancelledDebDocObjectId = GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["RECEIPTDOCUMENTOBJECTID"].Value.ToString();
//                            else if (GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["ADVANCEDOCUMENTOBJECTID"].Value != null && _DebentureCorrection.CancelledDebDocObjectId == null)
//                                _DebentureCorrection.CancelledDebDocObjectId = GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["ADVANCEDOCUMENTOBJECTID"].Value.ToString();
//                        }
//                        else if ((bool)GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["CANCELLED"].Value)
//                        {
                            
//                            GRIDCANCELLABLEDEBENTURES.Rows[rowIndex].Cells["CANCELLED"].Value = false;
                            
//                            bool checkFound = false;
//                            for(int i = 0;i< this.GRIDCANCELLABLEDEBENTURES.Rows.Count ;i++)
//                            {
//                                if ((bool)this.GRIDCANCELLABLEDEBENTURES.Rows[i].Cells["CANCELLED"].Value == true)
//                                {
//                                    checkFound = true;
//                                    break;
//                                }
//                            }
//                            if (!checkFound)
//                                _DebentureCorrection.CancelledDebDocObjectId = null ;
//                        }
//                    }
//                    else
//                    {
//                        InfoBox.Show("Senet Düzeltme İşleminde aynı Muhasebe Yetkilisi Mutemedi Alındısı ya da Avans işlemine ait senetler iptal edilebilir!");
//                    }
//                }
//            }
//#endregion DebentureCorrectionForm_GRIDCANCELLABLEDEBENTURES_CellContentClick
//        }

//        protected override void PreScript()
//        {
//#region DebentureCorrectionForm_PreScript
//    if (this._DebentureCorrection.CurrentStateDefID == DebentureCorrection.States.New && this._DebentureCorrection.CancellableDebentures.Count == 0)
//            {
//                this.CASHIERNAME.Text = Common.CurrentResource.Name.ToString();
                
//                if  (this._DebentureCorrection.CurrentStateDefID == DebentureCorrection.States.New)
//                {
//                    foreach (EpisodeAction ea in this._DebentureCorrection.Episode.EpisodeActions)
//                    {
//                        if (ea.Cancelled == false)
//                        {
//                            Receipt myReceipt = ea as Receipt ;
//                            if (myReceipt != null)
//                            {
//                                if (myReceipt.CurrentStateDefID == Receipt.States.Paid)
//                                {
//                                    foreach (Debenture db in myReceipt.ReceiptDocument.DebenturePayments)
//                                    {
//                                        if (db.CurrentStateDefID == Debenture.States.New)
//                                        {
//                                            DebentureCorrectionCancellableDebentures cDebs = new DebentureCorrectionCancellableDebentures(_DebentureCorrection.ObjectContext);
//                                            cDebs.No = db.No.Value.ToString();
//                                            cDebs.DueDate = db.DueDate;
//                                            cDebs.Status = db.CurrentStateDef.DisplayText.ToString();
//                                            cDebs.Price = db.Price;
//                                            cDebs.Cancelled = false;
//                                            cDebs.DebentureObjectID = db.ObjectID.ToString();
//                                            cDebs.ReceiptDocumentObjectID = myReceipt.ReceiptDocument.ObjectID.ToString();
//                                            cDebs.AdvanceDocumentObjectID = null ;
//                                            _DebentureCorrection.CancellableDebentures.Add(cDebs);
//                                        }
//                                    }
                                    
//                                }
//                            }
//                        }
//                    }  
//                   foreach (EpisodeAction ea in this._DebentureCorrection.Episode.EpisodeActions)
//                    {
//                        if (ea.Cancelled == false)
//                        {
//                            Advance myAdvance = ea as Advance;
//                            if (myAdvance != null)
//                            {
//                                if (myAdvance.CurrentStateDefID == Advance.States.Paid)
//                                {
//                                    foreach (Debenture db in myAdvance.AdvanceDocument.DebenturePayments)
//                                    {
//                                        if (db.CurrentStateDefID == Debenture.States.New)
//                                        {
//                                            DebentureCorrectionCancellableDebentures cDebsAdv = new DebentureCorrectionCancellableDebentures(_DebentureCorrection.ObjectContext);
//                                            cDebsAdv.No = db.No.Value.ToString();
//                                            cDebsAdv.DueDate = db.DueDate;
//                                            cDebsAdv.Status = db.CurrentStateDef.DisplayText.ToString();
//                                            cDebsAdv.Price = db.Price;
//                                            cDebsAdv.Cancelled = false;
//                                            cDebsAdv.DebentureObjectID = db.ObjectID.ToString();
//                                            cDebsAdv.ReceiptDocumentObjectID = null;
//                                            cDebsAdv.AdvanceDocumentObjectID = myAdvance.AdvanceDocument.ObjectID.ToString();
//                                            _DebentureCorrection.CancellableDebentures.Add(cDebsAdv);
//                                        }
//                                    }
                                    
//                                }
//                            }
//                        }
//                    }
//                    this._DebentureCorrection.CancelledTotalPrice = 0;
//                    this._DebentureCorrection.NewCreatedTotalPrice = 0 ;
//                }
//            }
//#endregion DebentureCorrectionForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region DebentureCorrectionForm_PostScript
//    base.PostScript(transDef);
            
//            bool cancelFound = false;
//            foreach (DebentureCorrectionCancellableDebentures cancelList in this._DebentureCorrection.CancellableDebentures)
//            {
//                if (cancelList.Cancelled  == true)
//                {  cancelFound = true;
//                    break;
//                }
//            }
//            if (cancelFound == false)
//                throw new TTException(SystemMessage.GetMessage(375));
            
//            if ((double)_DebentureCorrection.NewCreatedTotalPrice != (double)_DebentureCorrection.CancelledTotalPrice && (double)_DebentureCorrection.CancelledTotalPrice != 0)
//                throw new TTException(SystemMessage.GetMessage(376));
//#endregion DebentureCorrectionForm_PostScript

//            }
            
//#region DebentureCorrectionForm_Methods
//        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
//        {
//            base.AfterContextSavedScript(transDef);
//            if(transDef != null && transDef.ToStateDefID ==  DebentureCorrection.States.Completed)
//            {
//                if (_DebentureCorrection.Debentures.Count > 0 )
//                {
//                    Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                    
//                    TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
//                    cache.Add("VALUE", _DebentureCorrection.ObjectID.ToString());
                    
//                    parameters.Add("TTOBJECTID",cache);
//                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_CorrectedDebentureReport), true, 1, parameters);
//                }
//            }
//        }
        
//#endregion DebentureCorrectionForm_Methods
//    }
//}