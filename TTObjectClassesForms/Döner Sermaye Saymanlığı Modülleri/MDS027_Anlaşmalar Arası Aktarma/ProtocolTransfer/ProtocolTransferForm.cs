
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
//    /// Anlaşmalar Arası Aktarma
//    /// </summary>
//    public partial class ProtocolTransferForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            GridEpisodeProtocols.CellContentClick += new TTGridCellEventDelegate(GridEpisodeProtocols_CellContentClick);
//            TARGETEPISODE.SelectedObjectChanged += new TTControlEventDelegate(TARGETEPISODE_SelectedObjectChanged);
//            UnSelectAllButton.Click += new TTControlEventDelegate(UnSelectAllButton_Click);
//            SelectAllButton.Click += new TTControlEventDelegate(SelectAllButton_Click);
//            ApplyButton.Click += new TTControlEventDelegate(ApplyButton_Click);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            GridEpisodeProtocols.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeProtocols_CellContentClick);
//            TARGETEPISODE.SelectedObjectChanged -= new TTControlEventDelegate(TARGETEPISODE_SelectedObjectChanged);
//            UnSelectAllButton.Click -= new TTControlEventDelegate(UnSelectAllButton_Click);
//            SelectAllButton.Click -= new TTControlEventDelegate(SelectAllButton_Click);
//            ApplyButton.Click -= new TTControlEventDelegate(ApplyButton_Click);
//            base.UnBindControlEvents();
//        }

//        private void GridEpisodeProtocols_CellContentClick(Int32 rowIndex, Int32 columnIndex)
//        {
//#region ProtocolTransferForm_GridEpisodeProtocols_CellContentClick
//   if(this._ProtocolTransfer.CurrentStateDefID != ProtocolTransfer.States.Completed)
//            {
//                if (columnIndex == 4 && rowIndex != -1)
//                {
//                    string package;
//                    bool isFound = false;
                    
//                    Episode myEpisode = _ProtocolTransfer.Episode;
//                    EpisodeProtocol myEP = null; // (EpisodeProtocol) myEpisode.EpisodeProtocols.Select("OBJECTID = '" + GridEpisodeProtocols.Rows[rowIndex].Cells["EPOBJECTID"].Value.ToString() + "'")[0];
                    
//                    _ProtocolTransfer.ProtocolTransferProtocolSubActions.DeleteChildren();
//                    /* TODO:SEP
//                    foreach(AccountTransaction at in myEP.AccountTransactions)
//                    {
//                        package = "";
//                        isFound = false;
//                        if (at.SubActionProcedure != null)
//                        {
//                            if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.ToBeNew)
//                            {
//                                for(int i=0; i<this.GridProtocolSubActions.Rows.Count; i++)
//                                {
//                                    if (this.GridProtocolSubActions.Rows[i].Cells["SUBACTIONID"].Value.ToString() == at.SubActionProcedure.ObjectID.ToString())
//                                    {
//                                        isFound = true;
//                                        break;
//                                    }
//                                }
                                
//                                if (isFound == false)
//                                {
//                                    ProtocolTransferProtocolSubActions mySubAct = new ProtocolTransferProtocolSubActions(_ProtocolTransfer.ObjectContext);
                                    
//                                    if (at.PackageDefinition != null)
//                                        package = at.PackageDefinition.Name.ToString();
                                    
//                                    mySubAct.TRXDATE = at.SubActionProcedure.ActionDate;
//                                    mySubAct.EXTERNALCODE = at.SubActionProcedure.ProcedureObject.Code;
//                                    mySubAct.DESCRIPTION = at.SubActionProcedure.ProcedureObject.Name;
//                                    mySubAct.PACKAGEINFO = package;
//                                    mySubAct.TRANSFERTARGETPROTOCOL = true;
//                                    mySubAct.SUBACTIONID = at.SubActionProcedure.ObjectID.ToString();
                                    
//                                    if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
//                                        mySubAct.STATUS = "İptal";
//                                    else
//                                        mySubAct.STATUS = "Tamam";
                                    
//                                    if (at.SubActionProcedure.PackageDefinition != null)
//                                        mySubAct.ISPACKAGEPROCEDURE = true;
//                                    else
//                                        mySubAct.ISPACKAGEPROCEDURE = false;
                                    
//                                    _ProtocolTransfer.ProtocolTransferProtocolSubActions.Add(mySubAct);
//                                }
//                            }
//                        }
//                        else if (at.SubActionMaterial != null)
//                        {
//                            if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.ToBeNew)
//                            {
//                                for(int i=0;i<this.GridProtocolSubActions.Rows.Count;i++)
//                                {
//                                    if ( this.GridProtocolSubActions.Rows[i].Cells["SUBACTIONID"].Value.ToString() == at.SubActionMaterial.ObjectID.ToString())
//                                    {
//                                        isFound = true;
//                                        break;
//                                    }
//                                }
                                
//                                if (isFound == false)
//                                {
//                                    ProtocolTransferProtocolSubActions mySubAct = new ProtocolTransferProtocolSubActions(_ProtocolTransfer.ObjectContext);
                                    
//                                    if (at.PackageDefinition != null)
//                                        package = at.PackageDefinition.Name.ToString();
                                    
//                                    mySubAct.TRXDATE = at.SubActionMaterial.ActionDate;
//                                    mySubAct.EXTERNALCODE = at.SubActionMaterial.Material.Code;
//                                    mySubAct.DESCRIPTION = at.SubActionMaterial.Material.Name;
//                                    mySubAct.PACKAGEINFO = package;
//                                    mySubAct.TRANSFERTARGETPROTOCOL = true;
//                                    mySubAct.SUBACTIONID = at.SubActionMaterial.ObjectID.ToString();
                                    
//                                    if (at.SubActionMaterial.CurrentStateDef.Status == StateStatusEnum.Cancelled)
//                                        mySubAct.STATUS = "İptal";
//                                    else
//                                        mySubAct.STATUS = "Tamam";
                                    
//                                    mySubAct.ISPACKAGEPROCEDURE = false;

//                                    _ProtocolTransfer.ProtocolTransferProtocolSubActions.Add(mySubAct);
//                                }
//                            }
//                        }
//                    }
//                    */
//                }
//            }
//#endregion ProtocolTransferForm_GridEpisodeProtocols_CellContentClick
//        }

//        private void TARGETEPISODE_SelectedObjectChanged()
//        {
//#region ProtocolTransferForm_TARGETEPISODE_SelectedObjectChanged
//   IList EPList = null;
//            IList SEList = null;
            
//            _ProtocolTransfer.TargetEpisodeProtocol = null;
//            _ProtocolTransfer.TargetSubEpisode = null;
            
//            this.TARGETEPISODEPROTOCOL.ListFilterExpression = "OBJECTID is null ";
//            this.TARGETSUBEPISODE.ListFilterExpression = "OBJECTID is null ";
            
//            if (_ProtocolTransfer.TargetEpisode != null)
//            {
//                //EPList = EpisodeProtocol.GetByEpisode(_ProtocolTransfer.ObjectContext, _ProtocolTransfer.TargetEpisode.ObjectID.ToString());
//                if (EPList.Count > 0)
//                    this.TARGETEPISODEPROTOCOL.ListFilterExpression = "EPISODE = '" + _ProtocolTransfer.TargetEpisode.ObjectID.ToString() + "'";
                
//                if(_ProtocolTransfer.Episode.ObjectID == _ProtocolTransfer.TargetEpisode.ObjectID)
//                {
//                    this.TARGETSUBEPISODE.ReadOnly = true;
//                    this.TARGETSUBEPISODE.Required = false;
//                }
//                else
//                {
//                    this.TARGETSUBEPISODE.ReadOnly = false;
//                    this.TARGETSUBEPISODE.Required = true;
//                    SEList = SubEpisode.GetByEpisode(_ProtocolTransfer.ObjectContext, _ProtocolTransfer.TargetEpisode.ObjectID.ToString());
//                    if (SEList.Count > 0)
//                        this.TARGETSUBEPISODE.ListFilterExpression = "EPISODE = '" + _ProtocolTransfer.TargetEpisode.ObjectID.ToString() + "'";
//                }
//            }
//#endregion ProtocolTransferForm_TARGETEPISODE_SelectedObjectChanged
//        }

//        private void UnSelectAllButton_Click()
//        {
//#region ProtocolTransferForm_UnSelectAllButton_Click
//   if(this._ProtocolTransfer.CurrentStateDefID != ProtocolTransfer.States.Completed)
//            {
//                foreach (ProtocolTransferProtocolSubActions proc in this._ProtocolTransfer.ProtocolTransferProtocolSubActions)
//                    proc.TRANSFERTARGETPROTOCOL = false;
//            }
//#endregion ProtocolTransferForm_UnSelectAllButton_Click
//        }

//        private void SelectAllButton_Click()
//        {
//#region ProtocolTransferForm_SelectAllButton_Click
//   if(this._ProtocolTransfer.CurrentStateDefID != ProtocolTransfer.States.Completed)
//            {
//                foreach (ProtocolTransferProtocolSubActions proc in this._ProtocolTransfer.ProtocolTransferProtocolSubActions)
//                    proc.TRANSFERTARGETPROTOCOL = true; 
//            }
//#endregion ProtocolTransferForm_SelectAllButton_Click
//        }

//        private void ApplyButton_Click()
//        {
//#region ProtocolTransferForm_ApplyButton_Click
//   if (this._ProtocolTransfer.CurrentStateDefID != ProtocolTransfer.States.Completed)
//            {
//                if (this.EndDate.NullableValue == null && this.StartDate.NullableValue == null)
//                    TTVisual.InfoBox.Show("Lütfen Tarih Aralığı Seçiniz!");
//                else if (this.EndDate.NullableValue != null && this.StartDate.NullableValue != null && DateTime.Compare(((DateTime)this.EndDate.NullableValue).Date, ((DateTime)this.StartDate.NullableValue).Date) < 0)
//                    TTVisual.InfoBox.Show("Bitiş Tarihi Başlangıç Tarihinden küçük olamaz.");
//                else
//                {
//                    foreach (ProtocolTransferProtocolSubActions proc in this._ProtocolTransfer.ProtocolTransferProtocolSubActions)
//                    {
//                        if (this.EndDate.NullableValue != null && this.StartDate.NullableValue != null)
//                        {
//                            if (DateTime.Compare(((DateTime)this.StartDate.NullableValue).Date, ((DateTime)proc.TRXDATE).Date) <= 0 && DateTime.Compare(((DateTime)proc.TRXDATE).Date, ((DateTime)this.EndDate.NullableValue).Date) <= 0)
//                                proc.TRANSFERTARGETPROTOCOL = true;
//                            else
//                                proc.TRANSFERTARGETPROTOCOL = false;
//                        }

//                        if (this.EndDate.NullableValue == null && this.StartDate.NullableValue != null)
//                        {
//                            if (DateTime.Compare(((DateTime)this.StartDate.NullableValue).Date, ((DateTime)proc.TRXDATE).Date) <= 0)
//                                proc.TRANSFERTARGETPROTOCOL = true;
//                            else
//                                proc.TRANSFERTARGETPROTOCOL = false;
//                        }

//                        if (this.EndDate.NullableValue != null && this.StartDate.NullableValue == null)
//                        {
//                            if (DateTime.Compare(((DateTime)proc.TRXDATE).Date, ((DateTime)this.EndDate.NullableValue).Date) <= 0)
//                                proc.TRANSFERTARGETPROTOCOL = true;
//                            else
//                                proc.TRANSFERTARGETPROTOCOL = false;
//                        }
//                    }
//                }
//            }
//#endregion ProtocolTransferForm_ApplyButton_Click
//        }

//        protected override void PreScript()
//        {
//#region ProtocolTransferForm_PreScript
//    IList EPList = null;
//            bool EPExists = false;
            
//            this.cmdOK.Visible = false;
            

            
//            if (_ProtocolTransfer.CurrentStateDefID == ProtocolTransfer.States.New)
//            {
//                _ProtocolTransfer.TargetEpisode = _ProtocolTransfer.Episode;
//                this.TARGETEPISODE.ListFilterExpression = "PATIENT = '" + _ProtocolTransfer.Episode.Patient.ObjectID.ToString() + "'";
                
//                //EPList = EpisodeProtocol.GetByEpisode(_ProtocolTransfer.ObjectContext, _ProtocolTransfer.Episode.ObjectID.ToString());
//                _ProtocolTransfer.ProtocolTransferProtocolDetails.Clear();
                
//                foreach (EpisodeProtocol ep in EPList)
//                {
//                    ProtocolTransferProtocolDetail prtDetail = new ProtocolTransferProtocolDetail(_ProtocolTransfer.ObjectContext);
//                    prtDetail.PAYERNAME = ep.Payer.Name.ToString();
//                    prtDetail.PROTOCOLNAME= ep.Protocol.Name.ToString();
//                    prtDetail.PROTOCOLSTATUS = ep.CurrentStateDef.DisplayText.ToString();
//                    prtDetail.EPOBJECTID = ep.ObjectID.ToString();
//                    prtDetail.OPENINGDATE = ep.OpeningDate;
//                    _ProtocolTransfer.ProtocolTransferProtocolDetails.Add(prtDetail);
//                    EPExists = true;
//                }
                
//                if (EPExists)
//                    this.TARGETEPISODEPROTOCOL.ListFilterExpression = "EPISODE = '" + _ProtocolTransfer.Episode.ObjectID.ToString() + "'";
//                else
//                    this.TARGETEPISODEPROTOCOL.ListFilterExpression = "OBJECTID is null ";
                
//            }
//#endregion ProtocolTransferForm_PreScript

//            }
            
//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//#region ProtocolTransferForm_PostScript
//    base.PostScript(transDef);
//#endregion ProtocolTransferForm_PostScript

//            }
//                }
//}