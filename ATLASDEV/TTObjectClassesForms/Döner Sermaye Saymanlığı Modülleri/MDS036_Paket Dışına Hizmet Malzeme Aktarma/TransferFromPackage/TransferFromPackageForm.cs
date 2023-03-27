
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
    /// Paket Dışına Hizmet/Malzeme Aktarma
    /// </summary>
    public partial class TransferFromPackageForm : TTForm
    {
        override protected void BindControlEvents()
        {
            GridPackages.CellContentClick += new TTGridCellEventDelegate(GridPackages_CellContentClick);
            GridSubActionProcedures.CellContentClick += new TTGridCellEventDelegate(GridSubActionProcedures_CellContentClick);
            GridSubActionMaterials.CellContentClick += new TTGridCellEventDelegate(GridSubActionMaterials_CellContentClick);
            TARGETPAYER.SelectedObjectChanged += new TTControlEventDelegate(TARGETPAYER_SelectedObjectChanged);
            SelectAllMaterialBtn.Click += new TTControlEventDelegate(SelectAllMaterialBtn_Click);
            UnSelectAllMaterialBtn.Click += new TTControlEventDelegate(UnSelectAllMaterialBtn_Click);
            FilterButton.Click += new TTControlEventDelegate(FilterButton_Click);
            UnSelectAllProcedureBtn.Click += new TTControlEventDelegate(UnSelectAllProcedureBtn_Click);
            SelectAllProcedureBtn.Click += new TTControlEventDelegate(SelectAllProcedureBtn_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridPackages.CellContentClick -= new TTGridCellEventDelegate(GridPackages_CellContentClick);
            GridSubActionProcedures.CellContentClick -= new TTGridCellEventDelegate(GridSubActionProcedures_CellContentClick);
            GridSubActionMaterials.CellContentClick -= new TTGridCellEventDelegate(GridSubActionMaterials_CellContentClick);
            TARGETPAYER.SelectedObjectChanged -= new TTControlEventDelegate(TARGETPAYER_SelectedObjectChanged);
            SelectAllMaterialBtn.Click -= new TTControlEventDelegate(SelectAllMaterialBtn_Click);
            UnSelectAllMaterialBtn.Click -= new TTControlEventDelegate(UnSelectAllMaterialBtn_Click);
            FilterButton.Click -= new TTControlEventDelegate(FilterButton_Click);
            UnSelectAllProcedureBtn.Click -= new TTControlEventDelegate(UnSelectAllProcedureBtn_Click);
            SelectAllProcedureBtn.Click -= new TTControlEventDelegate(SelectAllProcedureBtn_Click);
            base.UnBindControlEvents();
        }

        private void GridPackages_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region TransferFromPackageForm_GridPackages_CellContentClick
            if (this._TransferFromPackage.CurrentStateDefID != TransferFromPackage.States.Completed)
            {
                if (columnIndex == 4 && rowIndex != -1)
                {
                    if (rowIndex < this._TransferFromPackage.TransferFromPackSubActPacs.Count)
                    {
                        SubActionProcedure tempSubActP = null;
                        SubActionMaterial tempSubActM = null;

                        this._TransferFromPackage.TransferFromPackSubActProcs.DeleteChildren();
                        this._TransferFromPackage.TransferFromPackSubActMats.DeleteChildren();

                        // TODO:SEP EpisodeProtocol.ObjectID değil SEP.ObjectID olmalı kullanılacaksa
                        IList accTrxList = AccountTransaction.GetTransactionsBySEPAndPackageDef(_TransferFromPackage.ObjectContext, _TransferFromPackage.TransferFromPackSubActPacs[rowIndex].EpisodeProtocol.ObjectID, _TransferFromPackage.TransferFromPackSubActPacs[rowIndex].SubActionPackageProcedure.PackageDefinition.ObjectID);
                        SubActionProcedure.GetByEpisodeAndMasterPackage(_TransferFromPackage.ObjectContext, _TransferFromPackage.Episode.ObjectID.ToString(), _TransferFromPackage.TransferFromPackSubActPacs[rowIndex].SubActionPackageProcedure.ObjectID.ToString());
                        SubActionMaterial.GetByEpisodeAndMasterPackage(_TransferFromPackage.ObjectContext, _TransferFromPackage.Episode.ObjectID.ToString(), _TransferFromPackage.TransferFromPackSubActPacs[rowIndex].SubActionPackageProcedure.ObjectID.ToString());

                        foreach (AccountTransaction at in accTrxList)
                        {
                            if (at.SubActionProcedure != null)
                            {
                                if (tempSubActP != at.SubActionProcedure)
                                {
                                    if (at.SubActionProcedure.MasterPackgSubActionProcedure == _TransferFromPackage.TransferFromPackSubActPacs[rowIndex].SubActionPackageProcedure)
                                    {
                                        TransferFromPackSubActProcs mySubActProcs = new TransferFromPackSubActProcs(_TransferFromPackage.ObjectContext);
                                        mySubActProcs.SubActionProcedure = at.SubActionProcedure;
                                        if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                            mySubActProcs.Status = "İptal";
                                        else
                                            mySubActProcs.Status = "Tamam";
                                        mySubActProcs.TransferToProtocol = false;
                                        mySubActProcs.PackageInfo = at.PackageDefinition.Name.ToString();
                                        _TransferFromPackage.TransferFromPackSubActProcs.Add(mySubActProcs);
                                    }
                                }
                                tempSubActP = at.SubActionProcedure;
                            }

                            if (at.SubActionMaterial != null)
                            {
                                if (tempSubActM != at.SubActionMaterial)
                                {
                                    if (at.SubActionMaterial.MasterPackgSubActionProcedure == _TransferFromPackage.TransferFromPackSubActPacs[rowIndex].SubActionPackageProcedure)
                                    {
                                        TransferFromPackSubActMats mySubActMats = new TransferFromPackSubActMats(_TransferFromPackage.ObjectContext);
                                        mySubActMats.SubActionMaterial = at.SubActionMaterial;
                                        if (at.SubActionMaterial.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                            mySubActMats.Status = "İptal";
                                        else
                                            mySubActMats.Status = "Tamam";
                                        mySubActMats.TransferToProtocol = false;
                                        mySubActMats.PackageInfo = at.PackageDefinition.Name.ToString();
                                        _TransferFromPackage.TransferFromPackSubActMats.Add(mySubActMats);
                                    }
                                }
                                tempSubActM = at.SubActionMaterial;
                            }
                        }
                    }
                }
            }
            #endregion TransferFromPackageForm_GridPackages_CellContentClick
        }

        private void GridSubActionProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region TransferFromPackageForm_GridSubActionProcedures_CellContentClick
            if (this._TransferFromPackage.CurrentStateDefID != TransferFromPackage.States.Completed)
            {
                if (columnIndex == 5 && rowIndex != -1)
                {
                    if (rowIndex < this._TransferFromPackage.TransferFromPackSubActProcs.Count)
                    {
                        if (this._TransferFromPackage.FilterStartDate != null)
                            this._TransferFromPackage.FilterStartDate = null;

                        if (this._TransferFromPackage.FilterEndDate != null)
                            this._TransferFromPackage.FilterEndDate = null;
                    }
                }
            }
            #endregion TransferFromPackageForm_GridSubActionProcedures_CellContentClick
        }

        private void GridSubActionMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region TransferFromPackageForm_GridSubActionMaterials_CellContentClick
            if (this._TransferFromPackage.CurrentStateDefID != TransferFromPackage.States.Completed)
            {
                if (columnIndex == 5 && rowIndex != -1)
                {
                    if (rowIndex < this._TransferFromPackage.TransferFromPackSubActMats.Count)
                    {
                        if (this._TransferFromPackage.FilterStartDate != null)
                            this._TransferFromPackage.FilterStartDate = null;

                        if (this._TransferFromPackage.FilterEndDate != null)
                            this._TransferFromPackage.FilterEndDate = null;
                    }
                }
            }
            #endregion TransferFromPackageForm_GridSubActionMaterials_CellContentClick
        }

        private void TARGETPAYER_SelectedObjectChanged()
        {
            #region TransferFromPackageForm_TARGETPAYER_SelectedObjectChanged
            PayerDefinition newPayer = _TransferFromPackage.Payer;
            string protocolList = null;

            Episode myEpisode = _TransferFromPackage.Episode;
            IList EPList = null; // EpisodeProtocol.GetByEpisode(_TransferFromPackage.ObjectContext, myEpisode.ObjectID.ToString());

            _TransferFromPackage.Protocol = null;
            if (newPayer != null)
            {
                foreach (EpisodeProtocol ep in EPList)
                {
                    if (_TransferFromPackage.Payer == ep.Payer && ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
                        protocolList = protocolList + "OBJECTID = '" + ep.Protocol.ObjectID.ToString() + "' OR ";
                }
            }

            if (protocolList != null)
            {
                protocolList = protocolList.Substring(0, (protocolList.Length - 3));
                this.TARGETPROTOCOL.ListFilterExpression = protocolList;
            }
            else
                //Payer ile baglı protocol bulunamadı ise protocol listesinin bos gelmesi icin
                this.TARGETPROTOCOL.ListFilterExpression = "OBJECTID is null ";
            #endregion TransferFromPackageForm_TARGETPAYER_SelectedObjectChanged
        }

        private void SelectAllMaterialBtn_Click()
        {
            #region TransferFromPackageForm_SelectAllMaterialBtn_Click
            foreach (TransferFromPackSubActMats myMat in this._TransferFromPackage.TransferFromPackSubActMats)
                myMat.TransferToProtocol = true;

            this._TransferFromPackage.FilterStartDate = null;
            this._TransferFromPackage.FilterEndDate = null;
            this._TransferFromPackage.FilterType = false;
            this._TransferFromPackage.Material = null;
            #endregion TransferFromPackageForm_SelectAllMaterialBtn_Click
        }

        private void UnSelectAllMaterialBtn_Click()
        {
            #region TransferFromPackageForm_UnSelectAllMaterialBtn_Click
            foreach (TransferFromPackSubActMats myMat in this._TransferFromPackage.TransferFromPackSubActMats)
                myMat.TransferToProtocol = false;

            this._TransferFromPackage.FilterStartDate = null;
            this._TransferFromPackage.FilterEndDate = null;
            this._TransferFromPackage.FilterType = false;
            this._TransferFromPackage.Material = null;
            #endregion TransferFromPackageForm_UnSelectAllMaterialBtn_Click
        }

        private void FilterButton_Click()
        {
            #region TransferFromPackageForm_FilterButton_Click
            bool dateFilter;

            if (this._TransferFromPackage.CurrentStateDefID != TransferFromPackage.States.Completed)
            {
                if (_TransferFromPackage.FilterStartDate != null || _TransferFromPackage.FilterEndDate != null || _TransferFromPackage.Procedure != null || _TransferFromPackage.Material != null)
                {
                    foreach (TransferFromPackSubActProcs myProc in this._TransferFromPackage.TransferFromPackSubActProcs)
                    {
                        dateFilter = true;

                        if (_TransferFromPackage.FilterStartDate != null)
                        {
                            if (DateTime.Compare(((DateTime)_TransferFromPackage.FilterStartDate).Date, ((DateTime)myProc.SubActionProcedure.PricingDate).Date) > 0)
                                dateFilter = false;
                        }

                        if (_TransferFromPackage.FilterEndDate != null)
                        {
                            if (DateTime.Compare(((DateTime)myProc.SubActionProcedure.PricingDate).Date, ((DateTime)_TransferFromPackage.FilterEndDate).Date) > 0)
                                dateFilter = false;
                        }

                        if (_TransferFromPackage.FilterType == true) // Ters tarih filtresi
                            dateFilter = !dateFilter;

                        if (dateFilter)
                            myProc.TransferToProtocol = true;
                        else
                            myProc.TransferToProtocol = false;

                        if (_TransferFromPackage.Procedure != null)
                        {
                            if (myProc.SubActionProcedure.ProcedureObject != _TransferFromPackage.Procedure)
                                myProc.TransferToProtocol = false;
                        }
                    }

                    foreach (TransferFromPackSubActMats myMat in this._TransferFromPackage.TransferFromPackSubActMats)
                    {
                        dateFilter = true;

                        if (_TransferFromPackage.FilterStartDate != null)
                        {
                            if (DateTime.Compare(((DateTime)_TransferFromPackage.FilterStartDate).Date, ((DateTime)myMat.SubActionMaterial.PricingDate).Date) > 0)
                                dateFilter = false;
                        }

                        if (_TransferFromPackage.FilterEndDate != null)
                        {
                            if (DateTime.Compare(((DateTime)myMat.SubActionMaterial.PricingDate).Date, ((DateTime)_TransferFromPackage.FilterEndDate).Date) > 0)
                                dateFilter = false;
                        }

                        if (_TransferFromPackage.FilterType == true) // Ters tarih filtresi
                            dateFilter = !dateFilter;

                        if (dateFilter)
                            myMat.TransferToProtocol = true;
                        else
                            myMat.TransferToProtocol = false;

                        if (_TransferFromPackage.Material != null)
                        {
                            if (myMat.SubActionMaterial.Material != _TransferFromPackage.Material)
                                myMat.TransferToProtocol = false;
                        }
                    }
                }
            }
            #endregion TransferFromPackageForm_FilterButton_Click
        }

        private void UnSelectAllProcedureBtn_Click()
        {
            #region TransferFromPackageForm_UnSelectAllProcedureBtn_Click
            foreach (TransferFromPackSubActProcs myProc in this._TransferFromPackage.TransferFromPackSubActProcs)
                myProc.TransferToProtocol = false;

            this._TransferFromPackage.FilterStartDate = null;
            this._TransferFromPackage.FilterEndDate = null;
            this._TransferFromPackage.FilterType = false;
            this._TransferFromPackage.Procedure = null;
            #endregion TransferFromPackageForm_UnSelectAllProcedureBtn_Click
        }

        private void SelectAllProcedureBtn_Click()
        {
            #region TransferFromPackageForm_SelectAllProcedureBtn_Click
            foreach (TransferFromPackSubActProcs myProc in this._TransferFromPackage.TransferFromPackSubActProcs)
                myProc.TransferToProtocol = true;

            this._TransferFromPackage.FilterStartDate = null;
            this._TransferFromPackage.FilterEndDate = null;
            this._TransferFromPackage.FilterType = false;
            this._TransferFromPackage.Procedure = null;
            #endregion TransferFromPackageForm_SelectAllProcedureBtn_Click
        }

        protected override void PreScript()
        {
            #region TransferFromPackageForm_PreScript
            if (_TransferFromPackage.CurrentStateDefID == TransferFromPackage.States.New)
            {
                base.PreScript();
                this.cmdOK.Visible = false;
                _TransferFromPackage.Payer = null;
                string payerList = null;
                Episode myEpisode = _TransferFromPackage.Episode;
                IList EPList = null; // EpisodeProtocol.GetByEpisode(_TransferFromPackage.ObjectContext, _TransferFromPackage.Episode.ObjectID.ToString());
                IList packageTrxList = null;
                SubActionProcedure tempSubActP = null;

                if (EPList.Count == 0)
                    throw new TTException(SystemMessage.GetMessage(466));

                foreach (EpisodeProtocol ep in EPList)
                {
                    AccountPayableReceivable myAPR = ep.Payer.MyAPR();
                    if (myAPR == null)
                        throw new TTException(SystemMessage.GetMessage(215));
                    else
                    {
                        // TODO:SEP ep.ObjectID değil SEP.ObjectID olmalı
                        packageTrxList = AccountTransaction.GetNewAndToBeNewPackageTrxsBySEP(_TransferFromPackage.ObjectContext, ep.ObjectID, string.Empty);
                        foreach (AccountTransaction at in packageTrxList)
                        {
                            if (tempSubActP != at.SubActionProcedure)
                            {
                                TransferFromPackSubActPacs transFromSubActPacs = new TransferFromPackSubActPacs(_TransferFromPackage.ObjectContext);
                                transFromSubActPacs.SubActionPackageProcedure = (SubActionPackageProcedure)at.SubActionProcedure;

                                if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                    transFromSubActPacs.Status = "İptal";
                                else
                                    transFromSubActPacs.Status = "Tamam";

                                transFromSubActPacs.EpisodeProtocol = ep;
                                _TransferFromPackage.TransferFromPackSubActPacs.Add(transFromSubActPacs);
                            }
                            tempSubActP = at.SubActionProcedure;
                        }

                        /* ÖNCEKİ KOD
                        foreach(AccountTransaction at in ep.AccountTransactions)
                        {
                            bool sameSubActProc = false ;
                            if (at.SubActionProcedure != null)
                            {
                                if (at.CurrentStateDefID == AccountTransaction.States.New || at.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                                {
                                    if (at.SubActionProcedure.PackageDefinition != null)
                                    {
                                        foreach(TransferFromPackSubActPacs transPacs in _TransferFromPackage.TransferFromPackSubActPacs)
                                        {
                                            if(transPacs.SubActionPackageProcedure.ObjectID == at.SubActionProcedure.ObjectID)
                                                sameSubActProc = true ;
                                        }
                                        if (!sameSubActProc)
                                        {
                                            TransferFromPackSubActPacs transFromSubActPacs = new TransferFromPackSubActPacs (_TransferFromPackage.ObjectContext);
                                            transFromSubActPacs.SubActionPackageProcedure = (SubActionPackageProcedure)at.SubActionProcedure;

                                            if (at.SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                                                transFromSubActPacs.Status = "İptal";
                                            else
                                                transFromSubActPacs.Status = "Tamam";

                                            transFromSubActPacs.EpisodeProtocol = ep ;
                                            _TransferFromPackage.TransferFromPackSubActPacs.Add(transFromSubActPacs);
                                        }
                                    }
                                }
                            }
                        }
                         */
                    }
                    if (ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
                        payerList = payerList + "OBJECTID = '" + ep.Payer.ObjectID.ToString() + "' OR ";
                }

                if (payerList != null)
                {
                    payerList = payerList.Substring(0, (payerList.Length - 3));
                    this.TARGETPAYER.ListFilterExpression = payerList;
                }
                else
                    this.TARGETPAYER.ListFilterExpression = "OBJECTID is null ";

                _TransferFromPackage.FilterType = false;
            }
            else
            {
                this.FilterButton.ReadOnly = true;
                this.SelectAllProcedureBtn.ReadOnly = true;
                this.UnSelectAllProcedureBtn.ReadOnly = true;
                this.SelectAllMaterialBtn.ReadOnly = true;
                this.UnSelectAllMaterialBtn.ReadOnly = true;
            }
            #endregion TransferFromPackageForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region TransferFromPackageForm_PostScript
            base.PostScript(transDef);
            bool anyPTransfer = false;
            bool anyMTransfer = false;
            foreach (TransferFromPackSubActProcs tSubActProcs in this._TransferFromPackage.TransferFromPackSubActProcs)
            {
                if (tSubActProcs.TransferToProtocol.ToString() == "True")
                {
                    anyPTransfer = true;
                    break;
                }
            }
            foreach (TransferFromPackSubActMats tSubActMats in this._TransferFromPackage.TransferFromPackSubActMats)
            {
                if (tSubActMats.TransferToProtocol.ToString() == "True")
                {
                    anyMTransfer = true;
                    break;
                }
            }

            if (!(anyPTransfer || anyMTransfer))
                throw new TTException(SystemMessage.GetMessage(464));
            #endregion TransferFromPackageForm_PostScript

        }
    }
}