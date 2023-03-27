
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
    /// Paket İçine Hizmet/Malzeme Aktarma
    /// </summary>
    public partial class PackageTransferForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GridEpisodeProtocols.CellContentClick += new TTGridCellEventDelegate(GridEpisodeProtocols_CellContentClick);
            GridProtocolSubActionPackages.CellValueChanged += new TTGridCellEventDelegate(GridProtocolSubActionPackages_CellValueChanged);
            UnSelectAllMaterialBtn.Click += new TTControlEventDelegate(UnSelectAllMaterialBtn_Click);
            SelectAllMaterialBtn.Click += new TTControlEventDelegate(SelectAllMaterialBtn_Click);
            FilterButton.Click += new TTControlEventDelegate(FilterButton_Click);
            UnSelectAllProcedureBtn.Click += new TTControlEventDelegate(UnSelectAllProcedureBtn_Click);
            SelectAllProcedureBtn.Click += new TTControlEventDelegate(SelectAllProcedureBtn_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridEpisodeProtocols.CellContentClick -= new TTGridCellEventDelegate(GridEpisodeProtocols_CellContentClick);
            GridProtocolSubActionPackages.CellValueChanged -= new TTGridCellEventDelegate(GridProtocolSubActionPackages_CellValueChanged);
            UnSelectAllMaterialBtn.Click -= new TTControlEventDelegate(UnSelectAllMaterialBtn_Click);
            SelectAllMaterialBtn.Click -= new TTControlEventDelegate(SelectAllMaterialBtn_Click);
            FilterButton.Click -= new TTControlEventDelegate(FilterButton_Click);
            UnSelectAllProcedureBtn.Click -= new TTControlEventDelegate(UnSelectAllProcedureBtn_Click);
            SelectAllProcedureBtn.Click -= new TTControlEventDelegate(SelectAllProcedureBtn_Click);
            base.UnBindControlEvents();
        }

        private void GridEpisodeProtocols_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PackageTransferForm_GridEpisodeProtocols_CellContentClick
   if (columnIndex == 3 && rowIndex != -1)
            {
                if(this._PackageTransfer.CurrentStateDefID != PackageTransfer.States.Completed)
                {
                    SubActionProcedure tempSubActP = null;
                    SubActionMaterial tempSubActM = null;

                    Episode myEpisode = _PackageTransfer.Episode;
                    EpisodeProtocol myEP = (EpisodeProtocol)this._PackageTransfer.PackageTransferProtocolDetails[rowIndex].EpisodeProtocol;
                    
                    foreach(PackageTransferProtocolDetail packTransProtDet in this._PackageTransfer.PackageTransferProtocolDetails)
                        packTransProtDet.TargetEpisodeProtocol = false ;

                    this._PackageTransfer.PackageTransferProtocolDetails[rowIndex].TargetEpisodeProtocol = true ;
                    
                    this._PackageTransfer.PackageTransferProtocolSubActionMaterials.DeleteChildren();
                    this._PackageTransfer.PackageTransferProtocolSubActionPackages.DeleteChildren();
                    this._PackageTransfer.PackageTransferProtocolSubActionProcedures.DeleteChildren();
                    
                    //TODO:SEP e çevrilecek , myEP mySEP e çevrilmeli
                    //IList myPAccountTransactions = myEP.GetSubActionProcedureTrxs();
                    //IList myMAccountTransactions = myEP.GetSubActionMaterialTrxs();
                    IList myPAccountTransactions = null;
                    IList myMAccountTransactions = null;
                    SubActionProcedure.GetByEpisodeAndSEP(_PackageTransfer.ObjectContext, _PackageTransfer.Episode.ObjectID, myEP.ObjectID, string.Empty);
                    SubActionMaterial.GetByEpisodeAndSEP(_PackageTransfer.ObjectContext, _PackageTransfer.Episode.ObjectID, myEP.ObjectID, string.Empty);

                    foreach (AccountTransaction at in myPAccountTransactions)
                    {
                        if (tempSubActP != at.SubActionProcedure)
                        {
                            if (at.SubActionProcedure.PackageDefinition == null)
                            {
                                PackageTransferProtocolSubActionProcedures mySubAct = new PackageTransferProtocolSubActionProcedures(_PackageTransfer.ObjectContext);
                                
                                mySubAct.SubActionProcedure = at.SubActionProcedure ;
                                if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                    mySubAct.STATUS = "İptal";
                                else
                                    mySubAct.STATUS = "Tamam";
                                
                                if (at.PackageDefinition != null)
                                    mySubAct.PACKAGEINFO = at.PackageDefinition.Name.ToString();
                                
                                mySubAct.TRANSFERTARGETPACKAGE = false;
                                _PackageTransfer.PackageTransferProtocolSubActionProcedures.Add(mySubAct);
                            }
                            else if (at.SubActionProcedure.PackageDefinition != null) //paket hizmet ise paket gridine eklenecek
                            {
                                PackageTransferProtocolSubActionPackages pSubAct = new PackageTransferProtocolSubActionPackages(_PackageTransfer.ObjectContext);
                                pSubAct.SubActionProcedure = at.SubActionProcedure ;
                                if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                    pSubAct.STATUS = "İptal";
                                else
                                    pSubAct.STATUS = "Tamam";
                                pSubAct.TARGETPACKAGE = false;
                                _PackageTransfer.PackageTransferProtocolSubActionPackages.Add(pSubAct);
                            }
                        }
                        tempSubActP = at.SubActionProcedure;
                    }

                    foreach (AccountTransaction at in myMAccountTransactions)
                    {
                        if (tempSubActM != at.SubActionMaterial)
                        {
                            PackageTransferProtocolSubActionMaterials mySubAct = new PackageTransferProtocolSubActionMaterials(_PackageTransfer.ObjectContext);
                            mySubAct.SubActionMaterial = at.SubActionMaterial;
                            if (at.SubActionMaterial.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                mySubAct.STATUS = "İptal";
                            else
                                mySubAct.STATUS = "Tamam";
                            
                            if (at.PackageDefinition != null)
                                mySubAct.PACKAGEINFO = at.PackageDefinition.Name.ToString();
                            
                            mySubAct.TRANSFERTARGETPACKAGE = false;
                            _PackageTransfer.PackageTransferProtocolSubActionMaterials.Add(mySubAct);
                        }
                        tempSubActM = at.SubActionMaterial;
                    }
                    
                    
                    
                    /* ÖNCEKİ KOD
                    bool isFound = false;
                    foreach(AccountTransaction at in myEP.AccountTransactions)
                    {
                        isFound = false;
                        if (at.SubActionProcedure != null)
                        {
                            if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                            {
                                for(int i = 0;i< this.GridProtocolSubActionProcedures.Rows.Count;i++)
                                {
                                    // if (this.GridProtocolSubActionProcedures.Rows[i].Cells["PSUBACTIONID"].Value.ToString() == at.SubActionProcedure.ObjectID.ToString())
                                    if(this._PackageTransfer.PackageTransferProtocolSubActionProcedures[i].SubActionProcedure == at.SubActionProcedure)
                                    {
                                        isFound = true;
                                        break;
                                    }
                                }
                                if (isFound == false)
                                {
                                    if (at.SubActionProcedure.PackageDefinition == null)
                                    {
                                        PackageTransferProtocolSubActionProcedures mySubAct = new PackageTransferProtocolSubActionProcedures(_PackageTransfer.ObjectContext);
                                        
                                        mySubAct.SubActionProcedure = at.SubActionProcedure ;
                                        if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                            mySubAct.STATUS = "İptal";
                                        else
                                            mySubAct.STATUS = "Tamam";
                                        
                                        if (at.PackageDefinition != null)
                                            mySubAct.PACKAGEINFO = at.PackageDefinition.Name.ToString();
                                        
                                        mySubAct.TRANSFERTARGETPACKAGE = false;
                                        _PackageTransfer.PackageTransferProtocolSubActionProcedures.Add(mySubAct);
                                    }
                                    else if (at.SubActionProcedure.PackageDefinition != null) //paket hizmet ise paket gridine eklenecek
                                    {
                                        PackageTransferProtocolSubActionPackages pSubAct = new PackageTransferProtocolSubActionPackages(_PackageTransfer.ObjectContext);
                                        pSubAct.SubActionProcedure = at.SubActionProcedure ;
                                        if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                            pSubAct.STATUS = "İptal";
                                        else
                                            pSubAct.STATUS = "Tamam";
                                        pSubAct.TARGETPACKAGE = false;
                                        _PackageTransfer.PackageTransferProtocolSubActionPackages.Add(pSubAct);
                                    }
                                }
                            }
                        }
                        else if (at.SubActionMaterial != null)
                        {
                            if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                            {
                                for(int i = 0;i< this.GridProtocolSubActionMaterials.Rows.Count;i++)
                                {
                                    //  if ( this.GridProtocolSubActionMaterials.Rows[i].Cells["MSUBACTIONID"].Value.ToString() == at.SubActionMaterial.ObjectID.ToString())
                                    if(this._PackageTransfer.PackageTransferProtocolSubActionMaterials[i].SubActionMaterial == at.SubActionMaterial)
                                    {
                                        isFound = true;
                                        break;
                                    }
                                }
                                if (isFound == false)
                                {
                                    PackageTransferProtocolSubActionMaterials mySubAct = new PackageTransferProtocolSubActionMaterials(_PackageTransfer.ObjectContext);
                                    mySubAct.SubActionMaterial = at.SubActionMaterial;
                                    if (at.SubActionMaterial.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                        mySubAct.STATUS = "İptal";
                                    else
                                        mySubAct.STATUS = "Tamam";
                                    
                                    if (at.PackageDefinition != null)
                                        mySubAct.PACKAGEINFO = at.PackageDefinition.Name.ToString();
                                    
                                    mySubAct.TRANSFERTARGETPACKAGE = false;
                                    _PackageTransfer.PackageTransferProtocolSubActionMaterials.Add(mySubAct);
                                }
                            }
                        }
                    }
                     */
                }
            }
#endregion PackageTransferForm_GridEpisodeProtocols_CellContentClick
        }

        private void GridProtocolSubActionPackages_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PackageTransferForm_GridProtocolSubActionPackages_CellValueChanged
   if (columnIndex == 4 && rowIndex != -1)
            {
                if (this.GridProtocolSubActionPackages.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                {
                    for (int i=0; i < this.GridProtocolSubActionPackages.Rows.Count - 1; i++ )
                    {
                        if (i != (int) rowIndex)
                            this.GridProtocolSubActionPackages.Rows[i].Cells[columnIndex].Value = false;
                    }
                    //foreach (PackageTransferProtocolSubActionPackages sp in _PackageTransfer.PackageTransferProtocolSubActionPackages)
                    //    sp.TARGETPACKAGE = false;
                }
            }
#endregion PackageTransferForm_GridProtocolSubActionPackages_CellValueChanged
        }

        private void UnSelectAllMaterialBtn_Click()
        {
#region PackageTransferForm_UnSelectAllMaterialBtn_Click
   foreach (PackageTransferProtocolSubActionMaterials  myMat in this._PackageTransfer.PackageTransferProtocolSubActionMaterials)
                myMat.TRANSFERTARGETPACKAGE = false;
            
            this._PackageTransfer.FilterStartDate = null;
            this._PackageTransfer.FilterEndDate = null;
            this._PackageTransfer.Material = null;
#endregion PackageTransferForm_UnSelectAllMaterialBtn_Click
        }

        private void SelectAllMaterialBtn_Click()
        {
#region PackageTransferForm_SelectAllMaterialBtn_Click
   foreach (PackageTransferProtocolSubActionMaterials  myMat in this._PackageTransfer.PackageTransferProtocolSubActionMaterials)
                myMat.TRANSFERTARGETPACKAGE = true;
            
            this._PackageTransfer.FilterStartDate = null;
            this._PackageTransfer.FilterEndDate = null;
            this._PackageTransfer.Material = null;
#endregion PackageTransferForm_SelectAllMaterialBtn_Click
        }

        private void FilterButton_Click()
        {
#region PackageTransferForm_FilterButton_Click
   bool dateFilter;
            
            if(this._PackageTransfer.CurrentStateDefID != PackageTransfer.States.Completed)
            {
                if (_PackageTransfer.FilterStartDate != null || _PackageTransfer.FilterEndDate != null || _PackageTransfer.Procedure != null || _PackageTransfer.Material != null)
                {
                    foreach (PackageTransferProtocolSubActionProcedures myProc in this._PackageTransfer.PackageTransferProtocolSubActionProcedures)
                    {
                        dateFilter = true;
                        
                        if (_PackageTransfer.FilterStartDate != null)
                        {
                            if (DateTime.Compare(((DateTime)_PackageTransfer.FilterStartDate).Date, ((DateTime)myProc.SubActionProcedure.PricingDate).Date) > 0)
                                dateFilter = false;
                        }

                        if (_PackageTransfer.FilterEndDate != null)
                        {
                            if (DateTime.Compare(((DateTime)myProc.SubActionProcedure.PricingDate).Date, ((DateTime)_PackageTransfer.FilterEndDate).Date) > 0)
                                dateFilter = false;
                        }
                        
                        if (dateFilter)
                            myProc.TRANSFERTARGETPACKAGE = true;
                        else
                            myProc.TRANSFERTARGETPACKAGE = false;
                        
                        if(_PackageTransfer.Procedure != null)
                        {
                            if(myProc.SubActionProcedure.ProcedureObject != _PackageTransfer.Procedure)
                                myProc.TRANSFERTARGETPACKAGE = false;
                        }
                    }
                    
                    foreach (PackageTransferProtocolSubActionMaterials myMat in this._PackageTransfer.PackageTransferProtocolSubActionMaterials)
                    {
                        dateFilter = true;
                        
                        if (_PackageTransfer.FilterStartDate != null)
                        {
                            if (DateTime.Compare(((DateTime)_PackageTransfer.FilterStartDate).Date, ((DateTime)myMat.SubActionMaterial.PricingDate).Date) > 0)
                                dateFilter = false;
                        }

                        if (_PackageTransfer.FilterEndDate != null)
                        {
                            if (DateTime.Compare(((DateTime)myMat.SubActionMaterial.PricingDate).Date, ((DateTime)_PackageTransfer.FilterEndDate).Date) > 0)
                                dateFilter = false;
                        }
                        
                        if (dateFilter)
                            myMat.TRANSFERTARGETPACKAGE = true;
                        else
                            myMat.TRANSFERTARGETPACKAGE = false;
                        
                        if(_PackageTransfer.Material != null)
                        {
                            if(myMat.SubActionMaterial.Material != _PackageTransfer.Material)
                                myMat.TRANSFERTARGETPACKAGE = false;
                        }
                    }
                }
            }
#endregion PackageTransferForm_FilterButton_Click
        }

        private void UnSelectAllProcedureBtn_Click()
        {
#region PackageTransferForm_UnSelectAllProcedureBtn_Click
   foreach (PackageTransferProtocolSubActionProcedures myProc in this._PackageTransfer.PackageTransferProtocolSubActionProcedures)
                myProc.TRANSFERTARGETPACKAGE = false;
            
            this._PackageTransfer.FilterStartDate = null;
            this._PackageTransfer.FilterEndDate = null;
            this._PackageTransfer.Procedure = null;
#endregion PackageTransferForm_UnSelectAllProcedureBtn_Click
        }

        private void SelectAllProcedureBtn_Click()
        {
#region PackageTransferForm_SelectAllProcedureBtn_Click
   foreach (PackageTransferProtocolSubActionProcedures myProc in this._PackageTransfer.PackageTransferProtocolSubActionProcedures)
                myProc.TRANSFERTARGETPACKAGE = true;
            
            this._PackageTransfer.FilterStartDate = null;
            this._PackageTransfer.FilterEndDate = null;
            this._PackageTransfer.Procedure = null;
#endregion PackageTransferForm_SelectAllProcedureBtn_Click
        }

        protected override void PreScript()
        {
#region PackageTransferForm_PreScript
    IList EPList = null;
            this.cmdOK.Visible = false;
            
            if (_PackageTransfer.CurrentStateDefID == PackageTransfer.States.New)
            {
       
                
                //EPList = EpisodeProtocol.GetByEpisode(_PackageTransfer.ObjectContext, _PackageTransfer.Episode.ObjectID.ToString());
                _PackageTransfer.PackageTransferProtocolDetails.Clear();
                foreach (EpisodeProtocol ep in EPList)
                {
                    PackageTransferProtocolDetail prtDetail = new PackageTransferProtocolDetail(_PackageTransfer.ObjectContext);
                    prtDetail.EpisodeProtocol = ep ;
                    prtDetail.PROTOCOLSTATUS = ep.CurrentStateDef.DisplayText.ToString();
                    prtDetail.TargetEpisodeProtocol = false;

                    _PackageTransfer.PackageTransferProtocolDetails.Add(prtDetail);
                }
            }
            else
            {
                this.FilterButton.ReadOnly = true;
                this.SelectAllProcedureBtn.ReadOnly = true;
                this.UnSelectAllProcedureBtn.ReadOnly = true;
                this.SelectAllMaterialBtn.ReadOnly = true;
                this.UnSelectAllMaterialBtn.ReadOnly = true;
            }
#endregion PackageTransferForm_PreScript

            }
                }
}