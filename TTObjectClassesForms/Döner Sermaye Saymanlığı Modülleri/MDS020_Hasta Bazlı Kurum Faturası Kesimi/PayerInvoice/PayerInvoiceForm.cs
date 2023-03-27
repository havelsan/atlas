
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
//    /// Kurum Faturası
//    /// </summary>
//    public partial class PayerInvoiceForm : TTForm
//    {
//        override protected void BindControlEvents()
//        {
//            CHECKBUTTON.Click += new TTControlEventDelegate(CHECKBUTTON_Click);
//            TOTALDISCOUNTENTRY.TextChanged += new TTControlEventDelegate(TOTALDISCOUNTENTRY_TextChanged);
//            BUTTONDISCOUNT.Click += new TTControlEventDelegate(BUTTONDISCOUNT_Click);
//            DISCOUNTTYPE.SelectedObjectChanged += new TTControlEventDelegate(DISCOUNTTYPE_SelectedObjectChanged);
//            PROTOCOLNAME.SelectedObjectChanged += new TTControlEventDelegate(PROTOCOLNAME_SelectedObjectChanged);
//            GRIDInvoiceProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDInvoiceProcedures_CellValueChanged);
//            GRIDInvoiceMaterials.CellValueChanged += new TTGridCellEventDelegate(GRIDInvoiceMaterials_CellValueChanged);
//            GRIDInvoicePackages.CellValueChanged += new TTGridCellEventDelegate(GRIDInvoicePackages_CellValueChanged);
//            PAYERNAME.SelectedObjectChanged += new TTControlEventDelegate(PAYERNAME_SelectedObjectChanged);
//            BTNLIST.Click += new TTControlEventDelegate(BTNLIST_Click);
//            PISUBEPISODE.SelectedObjectChanged += new TTControlEventDelegate(PISUBEPISODE_SelectedObjectChanged);
//            base.BindControlEvents();
//        }

//        override protected void UnBindControlEvents()
//        {
//            CHECKBUTTON.Click -= new TTControlEventDelegate(CHECKBUTTON_Click);
//            TOTALDISCOUNTENTRY.TextChanged -= new TTControlEventDelegate(TOTALDISCOUNTENTRY_TextChanged);
//            BUTTONDISCOUNT.Click -= new TTControlEventDelegate(BUTTONDISCOUNT_Click);
//            DISCOUNTTYPE.SelectedObjectChanged -= new TTControlEventDelegate(DISCOUNTTYPE_SelectedObjectChanged);
//            PROTOCOLNAME.SelectedObjectChanged -= new TTControlEventDelegate(PROTOCOLNAME_SelectedObjectChanged);
//            GRIDInvoiceProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDInvoiceProcedures_CellValueChanged);
//            GRIDInvoiceMaterials.CellValueChanged -= new TTGridCellEventDelegate(GRIDInvoiceMaterials_CellValueChanged);
//            GRIDInvoicePackages.CellValueChanged -= new TTGridCellEventDelegate(GRIDInvoicePackages_CellValueChanged);
//            PAYERNAME.SelectedObjectChanged -= new TTControlEventDelegate(PAYERNAME_SelectedObjectChanged);
//            BTNLIST.Click -= new TTControlEventDelegate(BTNLIST_Click);
//            PISUBEPISODE.SelectedObjectChanged -= new TTControlEventDelegate(PISUBEPISODE_SelectedObjectChanged);
//            base.UnBindControlEvents();
//        }

//        private void CHECKBUTTON_Click()
//        {
//            #region PayerInvoiceForm_CHECKBUTTON_Click
//            if (this.TabProcedureMaterialPackage.SelectedTab == this.TabProcedure)
//            {
//                if (this.GRIDInvoiceProcedures.Rows.Count > 0 && Convert.ToBoolean(this.GRIDInvoiceProcedures.Rows[0].Cells[7].Value) == true)
//                {
//                    for (int i = 0; i < this.GRIDInvoiceProcedures.Rows.Count; i++)
//                    {
//                        if (Convert.ToBoolean(this.GRIDInvoiceProcedures.Rows[i].Cells[7].Value) == true)
//                            this.GRIDInvoiceProcedures.Rows[i].Cells[7].Value = 0;
//                    }
//                }
//                else if (this.GRIDInvoiceProcedures.Rows.Count > 0 && Convert.ToBoolean(this.GRIDInvoiceProcedures.Rows[0].Cells[7].Value) == false)
//                {
//                    for (int i = 0; i < this.GRIDInvoiceProcedures.Rows.Count; i++)
//                    {
//                        if (Convert.ToBoolean(this.GRIDInvoiceProcedures.Rows[i].Cells[7].Value) == false)
//                            this.GRIDInvoiceProcedures.Rows[i].Cells[7].Value = 1;
//                    }
//                }
//            }
//            else if (this.TabProcedureMaterialPackage.SelectedTab == this.TabMaterial)
//            {
//                if (this.GRIDInvoiceMaterials.Rows.Count > 0 && Convert.ToBoolean(this.GRIDInvoiceMaterials.Rows[0].Cells[7].Value) == true)
//                {
//                    for (int i = 0; i < this.GRIDInvoiceMaterials.Rows.Count; i++)
//                    {
//                        if (Convert.ToBoolean(this.GRIDInvoiceMaterials.Rows[i].Cells[7].Value) == true)
//                            this.GRIDInvoiceMaterials.Rows[i].Cells[7].Value = 0;
//                    }
//                }
//                else if (this.GRIDInvoiceMaterials.Rows.Count > 0 && Convert.ToBoolean(this.GRIDInvoiceMaterials.Rows[0].Cells[7].Value) == false)
//                {
//                    for (int i = 0; i < this.GRIDInvoiceMaterials.Rows.Count; i++)
//                    {
//                        if (Convert.ToBoolean(this.GRIDInvoiceMaterials.Rows[i].Cells[7].Value) == false)
//                            this.GRIDInvoiceMaterials.Rows[i].Cells[7].Value = 1;
//                    }
//                }
//            }
//            else if (this.TabProcedureMaterialPackage.SelectedTab == this.TabPackage)
//            {
//                if (this.GRIDInvoicePackages.Rows.Count > 0 && Convert.ToBoolean(this.GRIDInvoicePackages.Rows[0].Cells[7].Value) == true)
//                {
//                    for (int i = 0; i < this.GRIDInvoicePackages.Rows.Count; i++)
//                    {
//                        if (Convert.ToBoolean(this.GRIDInvoicePackages.Rows[i].Cells[7].Value) == true)
//                            this.GRIDInvoicePackages.Rows[i].Cells[7].Value = 0;
//                    }
//                }
//                else if (this.GRIDInvoicePackages.Rows.Count > 0 && Convert.ToBoolean(this.GRIDInvoicePackages.Rows[0].Cells[7].Value) == false)
//                {
//                    for (int i = 0; i < this.GRIDInvoicePackages.Rows.Count; i++)
//                    {
//                        if (Convert.ToBoolean(this.GRIDInvoicePackages.Rows[i].Cells[7].Value) == false)
//                            this.GRIDInvoicePackages.Rows[i].Cells[7].Value = 1;
//                    }
//                }
//            }
//            #endregion PayerInvoiceForm_CHECKBUTTON_Click
//        }

//        private void TOTALDISCOUNTENTRY_TextChanged()
//        {
//            #region PayerInvoiceForm_TOTALDISCOUNTENTRY_TextChanged
//            if (_PayerInvoice.TotalDiscountEntry == null || _PayerInvoice.TotalDiscountEntry == 0)
//            {

//                foreach (PayerInvoiceProcedure pProc in _PayerInvoice.PayerInvoiceProcedures)
//                {
//                    pProc.TotalDiscountPrice = 0;
//                    pProc.TotalDiscountedPrice = pProc.TotalPrice;
//                }

//                foreach (PayerInvoiceMaterial pMat in _PayerInvoice.PayerInvoiceMaterials)
//                {
//                    pMat.TotalDiscountPrice = 0;
//                    pMat.TotalDiscountedPrice = pMat.TotalPrice;
//                }

//                foreach (PayerInvoicePackage pPac in _PayerInvoice.PayerInvoicePackages)
//                {
//                    pPac.TotalDiscountPrice = 0;
//                    pPac.TotalDiscountedPrice = pPac.TotalPrice;
//                }

//                _PayerInvoice.TotalDiscountPrice = 0;
//                _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice;
//                this.DISCOUNTTYPE.ReadOnly = false;
//                _PayerInvoice.DiscountTypeDefinition = null;

//            }
//            else
//            {
//                this.DISCOUNTTYPE.ReadOnly = true;
//                _PayerInvoice.DiscountTypeDefinition = null;

//            }
//            #endregion PayerInvoiceForm_TOTALDISCOUNTENTRY_TextChanged
//        }

//        private void BUTTONDISCOUNT_Click()
//        {
//            #region PayerInvoiceForm_BUTTONDISCOUNT_Click
//            double discountPercent;
//            bool notFound;
//            double discountPrice = 0;
//            double totalDiscountPrice = 0;
//            double discountAmountEntry = 0;
//            ProcedureTreeDefinition pTree = null;
//            MaterialTreeDefinition mTree = null;
//            ProcedureTreeDefinition pacTree = null;


//            // Onceki secilen indirim tipinden kalan degerleri resetle
//            foreach (PayerInvoiceProcedure pProc in _PayerInvoice.PayerInvoiceProcedures)
//            {
//                pProc.TotalDiscountPrice = 0;
//                pProc.TotalDiscountedPrice = pProc.TotalPrice;
//            }

//            foreach (PayerInvoiceMaterial pMat in _PayerInvoice.PayerInvoiceMaterials)
//            {
//                pMat.TotalDiscountPrice = 0;
//                pMat.TotalDiscountedPrice = pMat.TotalPrice;
//            }

//            foreach (PayerInvoicePackage pPac in _PayerInvoice.PayerInvoicePackages)
//            {
//                pPac.TotalDiscountPrice = 0;
//                pPac.TotalDiscountedPrice = pPac.TotalPrice;
//            }

//            _PayerInvoice.TotalDiscountPrice = 0;
//            _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice;


//            discountAmountEntry = (double)_PayerInvoice.TotalDiscountEntry;

//            DiscountTypeDefinition selectedDiscountType = _PayerInvoice.DiscountTypeDefinition;

//            if (discountAmountEntry > 0)
//            {
//                PayerInvoiceProcedure lastProc = null;
//                PayerInvoiceMaterial lastMat = null;
//                PayerInvoicePackage lastPac = null;

//                discountPercent = (double)(discountAmountEntry / (double)_PayerInvoice.TotalPrice) * 100;

//                foreach (PayerInvoiceProcedure pProc in _PayerInvoice.PayerInvoiceProcedures)
//                {
//                    if (pProc.Paid == true)
//                    {
//                        discountPrice = Math.Round((double)(pProc.TotalPrice * discountPercent) / 100, 2);
//                        pProc.TotalDiscountPrice = discountPrice;
//                        pProc.TotalDiscountedPrice = Math.Round((double)(pProc.TotalPrice - discountPrice), 2);
//                        lastProc = pProc;
//                        totalDiscountPrice = totalDiscountPrice + discountPrice;
//                    }
//                }

//                foreach (PayerInvoiceMaterial pMat in _PayerInvoice.PayerInvoiceMaterials)
//                {
//                    if (pMat.Paid == true)
//                    {
//                        discountPrice = Math.Round((double)(pMat.TotalPrice * discountPercent) / 100, 2);
//                        pMat.TotalDiscountPrice = discountPrice;
//                        pMat.TotalDiscountedPrice = Math.Round((double)(pMat.TotalPrice - discountPrice), 2);
//                        lastMat = pMat;
//                        totalDiscountPrice = totalDiscountPrice + discountPrice;
//                    }
//                }

//                foreach (PayerInvoicePackage pPac in _PayerInvoice.PayerInvoicePackages)
//                {
//                    if (pPac.Paid == true)
//                    {
//                        discountPrice = Math.Round((double)(pPac.TotalPrice * discountPercent) / 100, 2);
//                        pPac.TotalDiscountPrice = discountPrice;
//                        pPac.TotalDiscountedPrice = Math.Round((double)(pPac.TotalPrice - discountPrice), 2);
//                        lastPac = pPac;
//                        totalDiscountPrice = totalDiscountPrice + discountPrice;
//                    }
//                }

//                if (totalDiscountPrice != discountAmountEntry)
//                {
//                    if (lastMat != null)
//                    {
//                        lastMat.TotalDiscountPrice = Math.Round((double)(lastMat.TotalDiscountPrice + (discountAmountEntry - totalDiscountPrice)), 2);
//                        lastMat.TotalDiscountedPrice = Math.Round((double)(lastMat.TotalPrice - lastMat.TotalDiscountPrice), 2);
//                    }
//                    else
//                    {
//                        if (lastProc != null)
//                        {
//                            lastProc.TotalDiscountPrice = Math.Round((double)(lastProc.TotalDiscountPrice + (discountAmountEntry - totalDiscountPrice)), 2);
//                            lastProc.TotalDiscountedPrice = Math.Round((double)(lastProc.TotalPrice - lastProc.TotalDiscountPrice), 2);
//                        }
//                        else if (lastPac != null)
//                        {
//                            lastPac.TotalDiscountPrice = Math.Round((double)(lastPac.TotalDiscountPrice + (discountAmountEntry - totalDiscountPrice)), 2);
//                            lastPac.TotalDiscountedPrice = Math.Round((double)(lastPac.TotalPrice - lastPac.TotalDiscountPrice), 2);
//                        }
//                    }
//                    totalDiscountPrice = discountAmountEntry;
//                }
//            }
//            else
//            {
//                if (selectedDiscountType != null)
//                {
//                    foreach (PayerInvoiceProcedure pProc in _PayerInvoice.PayerInvoiceProcedures)
//                    {
//                        discountPercent = 0;
//                        notFound = true;

//                        if (pProc.Paid == true)
//                        {
//                            discountPercent = selectedDiscountType.GetExceptionDiscountPercent(pProc.AccountTransaction[0].SubActionProcedure.ProcedureObject);
//                            if (discountPercent > 0)
//                            {
//                                discountPrice = Math.Round((double)(pProc.TotalPrice * discountPercent) / 100, 2);
//                                pProc.TotalDiscountPrice = discountPrice;
//                                pProc.TotalDiscountedPrice = Math.Round((double)(pProc.TotalPrice - discountPrice), 2);
//                                totalDiscountPrice = totalDiscountPrice + discountPrice;
//                            }
//                            else
//                            {
//                                pTree = pProc.AccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree;
//                                while (notFound && pTree != null)
//                                {
//                                    discountPercent = selectedDiscountType.GetGroupDiscountPercent(pTree);
//                                    if (discountPercent > 0)
//                                    {
//                                        notFound = false;
//                                        discountPrice = Math.Round((double)(pProc.TotalPrice * discountPercent) / 100, 2);
//                                        pProc.TotalDiscountPrice = discountPrice;
//                                        pProc.TotalDiscountedPrice = Math.Round((double)(pProc.TotalPrice - discountPrice), 2);
//                                        totalDiscountPrice = totalDiscountPrice + discountPrice;
//                                    }
//                                    else
//                                        pTree = pTree.ParentID;
//                                }
//                            }
//                        }
//                    }

//                    foreach (PayerInvoiceMaterial pMat in _PayerInvoice.PayerInvoiceMaterials)
//                    {
//                        discountPercent = 0;
//                        notFound = true;

//                        if (pMat.Paid == true)
//                        {
//                            discountPercent = selectedDiscountType.GetExceptionDiscountPercent(pMat.AccountTransaction[0].SubActionMaterial.Material);
//                            if (discountPercent > 0)
//                            {
//                                discountPrice = Math.Round((double)(pMat.TotalPrice * discountPercent) / 100, 2);
//                                pMat.TotalDiscountPrice = discountPrice;
//                                pMat.TotalDiscountedPrice = Math.Round((double)(pMat.TotalPrice - discountPrice), 2);
//                                totalDiscountPrice = totalDiscountPrice + discountPrice;
//                            }
//                            else
//                            {
//                                mTree = pMat.AccountTransaction[0].SubActionMaterial.Material.MaterialTree;
//                                while (notFound && mTree != null)
//                                {
//                                    discountPercent = selectedDiscountType.GetGroupDiscountPercent(mTree);
//                                    if (discountPercent > 0)
//                                    {
//                                        notFound = false;
//                                        discountPrice = Math.Round((double)(pMat.TotalPrice * discountPercent) / 100, 2);
//                                        pMat.TotalDiscountPrice = discountPrice;
//                                        pMat.TotalDiscountedPrice = Math.Round((double)(pMat.TotalPrice - discountPrice), 2);
//                                        totalDiscountPrice = totalDiscountPrice + discountPrice;
//                                    }
//                                    else
//                                        mTree = mTree.ParentMaterialTree;

//                                }
//                            }
//                        }
//                    }

//                    foreach (PayerInvoicePackage pPac in _PayerInvoice.PayerInvoicePackages)
//                    {
//                        discountPercent = 0;
//                        notFound = true;

//                        if (pPac.Paid == true)
//                        {
//                            discountPercent = selectedDiscountType.GetExceptionDiscountPercent(pPac.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject);
//                            if (discountPercent > 0)
//                            {
//                                discountPrice = Math.Round((double)(pPac.TotalPrice * discountPercent) / 100, 2);
//                                pPac.TotalDiscountPrice = discountPrice;
//                                pPac.TotalDiscountedPrice = Math.Round((double)(pPac.TotalPrice - discountPrice), 2);
//                                totalDiscountPrice = totalDiscountPrice + discountPrice;
//                            }
//                            else
//                            {
//                                pacTree = pPac.PackageAccountTransaction[0].SubActionProcedure.ProcedureObject.ProcedureTree;

//                                while (notFound && pacTree != null)
//                                {
//                                    discountPercent = selectedDiscountType.GetGroupDiscountPercent(pacTree);
//                                    if (discountPercent > 0)
//                                    {
//                                        notFound = false;
//                                        discountPrice = Math.Round((double)(pPac.TotalPrice * discountPercent) / 100, 2);
//                                        pPac.TotalDiscountPrice = discountPrice;
//                                        pPac.TotalDiscountedPrice = Math.Round((double)(pPac.TotalPrice - discountPrice), 2);
//                                        totalDiscountPrice = totalDiscountPrice + discountPrice;
//                                    }
//                                    else
//                                        pacTree = pacTree.ParentID;
//                                }
//                            }
//                        }
//                    }
//                }
//            }

//            _PayerInvoice.TotalDiscountPrice = totalDiscountPrice;
//            _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice - _PayerInvoice.TotalDiscountPrice;
//            #endregion PayerInvoiceForm_BUTTONDISCOUNT_Click
//        }

//        private void DISCOUNTTYPE_SelectedObjectChanged()
//        {
//            #region PayerInvoiceForm_DISCOUNTTYPE_SelectedObjectChanged
//            if (_PayerInvoice.DiscountTypeDefinition == null)
//            {
//                foreach (PayerInvoiceProcedure pProc in _PayerInvoice.PayerInvoiceProcedures)
//                {
//                    pProc.TotalDiscountPrice = 0;
//                    pProc.TotalDiscountedPrice = pProc.TotalPrice;
//                }

//                foreach (PayerInvoiceMaterial pMat in _PayerInvoice.PayerInvoiceMaterials)
//                {
//                    pMat.TotalDiscountPrice = 0;
//                    pMat.TotalDiscountedPrice = pMat.TotalPrice;
//                }

//                foreach (PayerInvoicePackage pPac in _PayerInvoice.PayerInvoicePackages)
//                {
//                    pPac.TotalDiscountPrice = 0;
//                    pPac.TotalDiscountedPrice = pPac.TotalPrice;
//                }

//                _PayerInvoice.TotalDiscountPrice = 0;
//                _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice;
//                _PayerInvoice.TotalDiscountEntry = 0;
//                this.TOTALDISCOUNTENTRY.ReadOnly = false;
//            }
//            else
//            {
//                _PayerInvoice.TotalDiscountEntry = 0;
//                this.TOTALDISCOUNTENTRY.ReadOnly = true;
//            }
//            #endregion PayerInvoiceForm_DISCOUNTTYPE_SelectedObjectChanged
//        }

//        private void PROTOCOLNAME_SelectedObjectChanged()
//        {
//            #region PayerInvoiceForm_PROTOCOLNAME_SelectedObjectChanged
//            foreach (PayerInvoiceProcedure invproc in _PayerInvoice.PayerInvoiceProcedures)
//            {
//                invproc.AccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoiceProcedures.DeleteChildren();

//            foreach (PayerInvoiceMaterial invmat in _PayerInvoice.PayerInvoiceMaterials)
//            {
//                invmat.AccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoiceMaterials.DeleteChildren();

//            foreach (PayerInvoicePackage invpack in _PayerInvoice.PayerInvoicePackages)
//            {
//                invpack.PackageAccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoicePackages.DeleteChildren();

//            _PayerInvoice.TotalPrice = 0;
//            _PayerInvoice.TotalDiscountPrice = 0;
//            _PayerInvoice.GeneralTotalPrice = 0;
//            #endregion PayerInvoiceForm_PROTOCOLNAME_SelectedObjectChanged
//        }

//        private void GRIDInvoiceProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//            #region PayerInvoiceForm_GRIDInvoiceProcedures_CellValueChanged
//            if (columnIndex == 7 && rowIndex != -1)
//            {
//                if (GRIDInvoiceProcedures.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False")
//                {
//                    _PayerInvoice.TotalPrice = _PayerInvoice.TotalPrice - Convert.ToDouble(GRIDInvoiceProcedures.Rows[rowIndex].Cells[5].Value);
//                    _PayerInvoice.TotalDiscountPrice = _PayerInvoice.TotalDiscountPrice - Convert.ToDouble(GRIDInvoiceProcedures.Rows[rowIndex].Cells[8].Value);
//                }
//                else if (GRIDInvoiceProcedures.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")
//                {
//                    _PayerInvoice.TotalPrice = _PayerInvoice.TotalPrice + Convert.ToDouble(GRIDInvoiceProcedures.Rows[rowIndex].Cells[5].Value);
//                    _PayerInvoice.TotalDiscountPrice = _PayerInvoice.TotalDiscountPrice + Convert.ToDouble(GRIDInvoiceProcedures.Rows[rowIndex].Cells[8].Value);
//                }
//                _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice - _PayerInvoice.TotalDiscountPrice;
//            }
//            #endregion PayerInvoiceForm_GRIDInvoiceProcedures_CellValueChanged
//        }

//        private void GRIDInvoiceMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//            #region PayerInvoiceForm_GRIDInvoiceMaterials_CellValueChanged
//            if (columnIndex == 7 && rowIndex != -1)
//            {
//                if (GRIDInvoiceMaterials.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False")
//                {
//                    _PayerInvoice.TotalPrice = _PayerInvoice.TotalPrice - Convert.ToDouble(GRIDInvoiceMaterials.Rows[rowIndex].Cells[5].Value);
//                    _PayerInvoice.TotalDiscountPrice = _PayerInvoice.TotalDiscountPrice - Convert.ToDouble(GRIDInvoiceMaterials.Rows[rowIndex].Cells[8].Value);
//                }
//                else if (GRIDInvoiceMaterials.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")
//                {
//                    _PayerInvoice.TotalPrice = _PayerInvoice.TotalPrice + Convert.ToDouble(GRIDInvoiceMaterials.Rows[rowIndex].Cells[5].Value);
//                    _PayerInvoice.TotalDiscountPrice = _PayerInvoice.TotalDiscountPrice + Convert.ToDouble(GRIDInvoiceMaterials.Rows[rowIndex].Cells[8].Value);
//                }
//                _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice - _PayerInvoice.TotalDiscountPrice;
//            }
//            #endregion PayerInvoiceForm_GRIDInvoiceMaterials_CellValueChanged
//        }

//        private void GRIDInvoicePackages_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
//        {
//            #region PayerInvoiceForm_GRIDInvoicePackages_CellValueChanged
//            if (columnIndex == 7 && rowIndex != -1)
//            {
//                if (GRIDInvoicePackages.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False")
//                {
//                    _PayerInvoice.TotalPrice = _PayerInvoice.TotalPrice - Convert.ToDouble(GRIDInvoicePackages.Rows[rowIndex].Cells[5].Value);
//                    _PayerInvoice.TotalDiscountPrice = _PayerInvoice.TotalDiscountPrice - Convert.ToDouble(GRIDInvoicePackages.Rows[rowIndex].Cells[8].Value);
//                }
//                else if (GRIDInvoicePackages.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True")
//                {
//                    _PayerInvoice.TotalPrice = _PayerInvoice.TotalPrice + Convert.ToDouble(GRIDInvoicePackages.Rows[rowIndex].Cells[5].Value);
//                    _PayerInvoice.TotalDiscountPrice = _PayerInvoice.TotalDiscountPrice + Convert.ToDouble(GRIDInvoicePackages.Rows[rowIndex].Cells[8].Value);
//                }
//                _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice - _PayerInvoice.TotalDiscountPrice;
//            }
//            #endregion PayerInvoiceForm_GRIDInvoicePackages_CellValueChanged
//        }

//        private void PAYERNAME_SelectedObjectChanged()
//        {
//            #region PayerInvoiceForm_PAYERNAME_SelectedObjectChanged
//            PayerDefinition newPayer = _PayerInvoice.Payer;
//            string protocolList = null;

//            Episode myEpisode = _PayerInvoice.Episode;
//            IList EPList = null; // EpisodeProtocol.GetByEpisode(_PayerInvoice.ObjectContext, myEpisode.ObjectID.ToString());

//            _PayerInvoice.Protocol = null;
//            if (newPayer != null)
//            {
//                foreach (EpisodeProtocol ep in EPList)
//                {
//                    if (newPayer == ep.Payer && ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
//                        protocolList = protocolList + "OBJECTID = '" + ep.Protocol.ObjectID.ToString() + "' OR ";
//                }
//            }

//            if (protocolList != null)
//                this.PROTOCOLNAME.ListFilterExpression = protocolList.Substring(0, (protocolList.Length - 3));
//            else
//                //Payer ile baglı protocol bulunamadı ise protocol listesinin bos gelmesi icin
//                this.PROTOCOLNAME.ListFilterExpression = "OBJECTID is null ";

//            foreach (PayerInvoiceProcedure invproc in _PayerInvoice.PayerInvoiceProcedures)
//            {
//                invproc.AccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoiceProcedures.DeleteChildren();

//            foreach (PayerInvoiceMaterial invmat in _PayerInvoice.PayerInvoiceMaterials)
//            {
//                invmat.AccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoiceMaterials.DeleteChildren();

//            foreach (PayerInvoicePackage invpack in _PayerInvoice.PayerInvoicePackages)
//            {
//                invpack.PackageAccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoicePackages.DeleteChildren();

//            _PayerInvoice.TotalPrice = 0;
//            _PayerInvoice.TotalDiscountPrice = 0;
//            _PayerInvoice.GeneralTotalPrice = 0;
//            #endregion PayerInvoiceForm_PAYERNAME_SelectedObjectChanged
//        }

//        private void BTNLIST_Click()
//        {
//            #region PayerInvoiceForm_BTNLIST_Click
//            //Formdaki Payer ve Patient ile ilgili alanlari set et
//            bool isPackage = false;
//            double totalPrice = 0;
//            EpisodeProtocol myEpisodeProtocol = null;
//            Episode myEpisode = _PayerInvoice.Episode;

//            /*
//            foreach (EpisodeProtocol ep in _PayerInvoice.Episode.EpisodeProtocols)
//            {
//                if (ep.Payer == _PayerInvoice.Payer && ep.Protocol == _PayerInvoice.Protocol && ep.CurrentStateDefID == EpisodeProtocol.States.OPEN)
//                {
//                    myEpisodeProtocol = ep;
//                    break;
//                }
//            }
//            */

//            if (_PayerInvoice.Payer == null)
//                TTVisual.InfoBox.Show("Kurum Seçilmedi!", MessageIconEnum.ErrorMessage);
//            else if (_PayerInvoice.Protocol == null)
//                TTVisual.InfoBox.Show("Anlaşma Seçilmedi!", MessageIconEnum.ErrorMessage);
//            else
//            {
//                _PayerInvoice.PayerInvoiceDocument.Payer = myEpisodeProtocol.Payer;
//                //Gridlerdeki verilerin doldurulmasi

//                AccountPayableReceivable myAPR = myEpisodeProtocol.Payer.MyAPR();
//                if (myAPR == null)
//                    throw new TTException(SystemMessage.GetMessage(215));
//                else
//                {
//                    foreach (PayerInvoiceProcedure invproc in _PayerInvoice.PayerInvoiceProcedures)
//                        invproc.AccountTransaction.Clear();

//                    _PayerInvoice.PayerInvoiceProcedures.DeleteChildren();

//                    foreach (PayerInvoiceMaterial invmat in _PayerInvoice.PayerInvoiceMaterials)
//                        invmat.AccountTransaction.Clear();

//                    _PayerInvoice.PayerInvoiceMaterials.DeleteChildren();

//                    foreach (PayerInvoicePackage invpack in _PayerInvoice.PayerInvoicePackages)
//                        invpack.PackageAccountTransaction.Clear();

//                    _PayerInvoice.PayerInvoicePackages.DeleteChildren();

//                    // TODO:SEP myEpisodeProtocol.ObjectID ler SEP.ObjectId yapılamlı kullanılacaksa bu işlem
//                    IList procedureTrxList = null; // AccountTransaction.GetProcedureTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
//                    IList orthesisProsthesisTrxList = null; // AccountTransaction.GetOrthesisProsthesisTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.MedulaDontSend, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
//                    IList packageTrxList = null; // AccountTransaction.GetPackageTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
//                    IList materialTrxList = null; // AccountTransaction.GetMaterialTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);

//                    // Hizmetler
//                    foreach (AccountTransaction accTrx in procedureTrxList)
//                    {
//                        if (_PayerInvoice.PISubEpisode == null || (_PayerInvoice.PISubEpisode != null && _PayerInvoice.PISubEpisode == accTrx.SubEpisodeProtocol.SubEpisode))
//                        {
//                            PayerInvoiceProcedure invproc = new PayerInvoiceProcedure(_PayerInvoice.ObjectContext);
//                            invproc.ActionDate = accTrx.TransactionDate.Value;
//                            invproc.ExternalCode = accTrx.ExternalCode;
//                            invproc.Description = accTrx.Description;
//                            invproc.Amount = (int)accTrx.Amount;
//                            invproc.UnitPrice = accTrx.UnitPrice;
//                            invproc.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                            invproc.Paid = true;
//                            invproc.AccountTransaction.Add(accTrx);

//                            _PayerInvoice.PayerInvoiceProcedures.Add(invproc);
//                            totalPrice = totalPrice + (double)invproc.TotalPrice;
//                        }
//                    }

//                    // Ortez-Protez ler
//                    foreach (AccountTransaction accTrx in orthesisProsthesisTrxList)
//                    {
//                        PayerInvoiceProcedure invproc = new PayerInvoiceProcedure(_PayerInvoice.ObjectContext);
//                        invproc.ActionDate = accTrx.TransactionDate.Value;
//                        invproc.ExternalCode = accTrx.ExternalCode;
//                        invproc.Description = accTrx.Description;
//                        invproc.Amount = (int)accTrx.Amount;
//                        invproc.UnitPrice = accTrx.UnitPrice;
//                        invproc.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                        invproc.Paid = true;
//                        invproc.AccountTransaction.Add(accTrx);

//                        _PayerInvoice.PayerInvoiceProcedures.Add(invproc);
//                        totalPrice = totalPrice + (double)invproc.TotalPrice;
//                    }

//                    // Paketler
//                    foreach (AccountTransaction accTrx in packageTrxList)
//                    {
//                        if (_PayerInvoice.PISubEpisode == null || (_PayerInvoice.PISubEpisode != null && _PayerInvoice.PISubEpisode == accTrx.SubEpisodeProtocol.SubEpisode))
//                        {
//                            PayerInvoicePackage invpack = new PayerInvoicePackage(_PayerInvoice.ObjectContext);
//                            invpack.ActionDate = accTrx.TransactionDate.Value;
//                            invpack.PackageCode = accTrx.ExternalCode;
//                            invpack.PackageName = accTrx.Description;
//                            invpack.Amount = (int)accTrx.Amount;
//                            invpack.PackagePrice = accTrx.UnitPrice;
//                            invpack.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                            invpack.Paid = true;
//                            invpack.PackageAccountTransaction.Add(accTrx);

//                            _PayerInvoice.PayerInvoicePackages.Add(invpack);
//                            totalPrice = totalPrice + (double)invpack.TotalPrice;
//                        }
//                    }

//                    // Malzeme ve İlaçlar
//                    foreach (AccountTransaction accTrx in materialTrxList)
//                    {
//                        if (_PayerInvoice.PISubEpisode == null || (_PayerInvoice.PISubEpisode != null && _PayerInvoice.PISubEpisode == accTrx.SubEpisodeProtocol.SubEpisode))
//                        {
//                            PayerInvoiceMaterial invmat = new PayerInvoiceMaterial(_PayerInvoice.ObjectContext);
//                            invmat.ActionDate = (DateTime)accTrx.TransactionDate;
//                            invmat.ExternalCode = accTrx.ExternalCode;
//                            invmat.Description = accTrx.Description;
//                            invmat.Amount = accTrx.Amount;
//                            invmat.UnitPrice = accTrx.UnitPrice;
//                            invmat.TotalPrice = (double)(accTrx.Amount * accTrx.UnitPrice);
//                            invmat.Paid = true;
//                            invmat.AccountTransaction.Add(accTrx);

//                            _PayerInvoice.PayerInvoiceMaterials.Add(invmat);
//                            totalPrice = totalPrice + (double)invmat.TotalPrice;
//                        }
//                    }
//                }
//            }

//            _PayerInvoice.TotalDiscountEntry = 0;
//            _PayerInvoice.DiscountTypeDefinition = null;
//            _PayerInvoice.TotalPrice = totalPrice;
//            _PayerInvoice.TotalDiscountPrice = 0;
//            _PayerInvoice.GeneralTotalPrice = _PayerInvoice.TotalPrice - _PayerInvoice.TotalDiscountPrice;
//            _PayerInvoice.PayerInvoiceDocument.TotalPrice = _PayerInvoice.TotalPrice;
//            _PayerInvoice.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.New;
//            #endregion PayerInvoiceForm_BTNLIST_Click
//        }

//        private void PISUBEPISODE_SelectedObjectChanged()
//        {
//            #region PayerInvoiceForm_PISUBEPISODE_SelectedObjectChanged
//            foreach (PayerInvoiceProcedure invproc in _PayerInvoice.PayerInvoiceProcedures)
//            {
//                invproc.AccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoiceProcedures.DeleteChildren();

//            foreach (PayerInvoiceMaterial invmat in _PayerInvoice.PayerInvoiceMaterials)
//            {
//                invmat.AccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoiceMaterials.DeleteChildren();

//            foreach (PayerInvoicePackage invpack in _PayerInvoice.PayerInvoicePackages)
//            {
//                invpack.PackageAccountTransaction.Clear();
//            }
//            _PayerInvoice.PayerInvoicePackages.DeleteChildren();

//            _PayerInvoice.TotalPrice = 0;
//            _PayerInvoice.TotalDiscountPrice = 0;
//            _PayerInvoice.GeneralTotalPrice = 0;
//            #endregion PayerInvoiceForm_PISUBEPISODE_SelectedObjectChanged
//        }

//        protected override void PreScript()
//        {
//            #region PayerInvoiceForm_PreScript
//            if (_PayerInvoice.CurrentStateDefID == PayerInvoice.States.New)
//            {
//                CashierLog _myCashierLog;
//                bool isPackage = false;
//                string payerList = "";
//                string protocolList = "";

//                ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
//                _myCashierLog = (CashierLog)_myResUser.GetOpenCashCashierLog();

//                if (_myCashierLog == null)
//                    throw new TTUtils.TTException(SystemMessage.GetMessage(210));
//                else
//                {
//                    this.cmdOK.Visible = false;
//                    Episode myEpisode = _PayerInvoice.Episode;
//                    //EpisodeProtocol myEpisodeProtocol = myEpisode.MyEpisodeProtocol();

//                    //Aktif Yatış Kontrol İşlemi
//                    foreach (InpatientAdmission trtClnc in _PayerInvoice.Episode.InpatientAdmissions)
//                    {
//                        if (trtClnc.CurrentStateDefID == InpatientAdmission.States.ClinicProcedure)
//                            throw new TTUtils.TTException(SystemMessage.GetMessage(513));
//                    }

//                    //Payer ve Protocol Filtreleme
//                    IList openEPList = null; // EpisodeProtocol.GetByEpisodeAndState(_PayerInvoice.ObjectContext, myEpisode.ObjectID.ToString(), EpisodeProtocol.States.OPEN.ToString());
//                    foreach (EpisodeProtocol ep in openEPList)
//                        payerList = payerList + "OBJECTID = '" + ep.Payer.ObjectID.ToString() + "' OR ";

//                    if (payerList != null && payerList != "")
//                        this.PAYERNAME.ListFilterExpression = payerList.Substring(0, (payerList.Length - 3));
//                    else
//                        this.PAYERNAME.ListFilterExpression = "OBJECTID is null "; // Payer listesinin bos gelmesi icin

//                    // Alt Vaka Filtresi
//                    this.PISUBEPISODE.ListFilterExpression = "EPISODE.OBJECTID = '" + myEpisode.ObjectID.ToString() + "'";

//                    if (TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
//                    {
//                        this.PISUBEPISODE.ReadOnly = false;
//                        this.PatientStatus.Visible = false;
//                        this.LblHastaDurumu.Visible = false;
//                    }
//                    else
//                    {
//                        this.PISUBEPISODE.ReadOnly = true;
//                        this.PatientStatus.Visible = true;
//                        this.LblHastaDurumu.Visible = true;

//                        if (this._PayerInvoice.Episode.PatientStatus == PatientStatusEnum.Outpatient)
//                        {
//                            this._PayerInvoice.PATIENTSTATUS = PayerInvoicePatientStatusEnum.OutPatient;
//                            this.PatientStatus.ReadOnly = true;
//                        }
//                        else
//                            this.PatientStatus.ReadOnly = false;
//                    }

//                    _PayerInvoice.CashOfficeName = _myCashierLog.CashOffice.Name;

//                    if (_PayerInvoice.PayerInvoiceDocument == null)
//                    {
//                        _PayerInvoice.PayerInvoiceDocument = new PayerInvoiceDocument(_PayerInvoice.ObjectContext);
//                        _PayerInvoice.PayerInvoiceDocument.CashierLog = _myCashierLog;
//                        _PayerInvoice.PayerInvoiceDocument.DocumentDate = DateTime.Now.Date;

//                        IList myList = InvoiceCashOfficeDefinition.GetByCashOffice(_PayerInvoice.ObjectContext, _myCashierLog.CashOffice.ObjectID.ToString());
//                        if (myList.Count == 0)
//                            throw new TTUtils.TTException(SystemMessage.GetMessage(213, new string[] { _PayerInvoice.CashOfficeName }));
//                        else
//                        {
//                            InvoiceCashOfficeDefinition _myInvoiceCashOfficeDefinition = (InvoiceCashOfficeDefinition)myList[0];
//                            _PayerInvoice.PayerInvoiceDocument.DocumentNo = InvoiceCashOfficeDefinition.GetCurrentInvoiceNumber(_myInvoiceCashOfficeDefinition);
//                        }
//                    }

//                    //if (myEpisodeProtocol == null)
//                    //    throw new TTUtils.TTException(SystemMessage.GetMessage(214));
//                    //else
//                    //{
//                    //Formdaki Payer ve Patient ile ilgili alanlari set et
//                    //_PayerInvoice.Payer = myEpisodeProtocol.Payer;
//                    //_PayerInvoice.Protocol = myEpisodeProtocol.Protocol;
//                    //_PayerInvoice.PayerInvoiceDocument.Payer = myEpisodeProtocol.Payer;

//                    //Gridlerdeki verilerin doldurulmasi
//                    double totalPrice = 0;
//                    //AccountPayableReceivable myAPR = myEpisodeProtocol.Payer.MyAPR();
//                    //if (myAPR == null)
//                    //    throw new TTUtils.TTException(SystemMessage.GetMessage(215));
//                    //else
//                    //{   // TODO:SEP myEpisodeProtocol.ObjectID ler SEP.ObjectId yapılamlı kullanılacaksa bu işlem
//                    IList procedureTrxList = null; // AccountTransaction.GetProcedureTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
//                    IList orthesisProsthesisTrxList = null; // AccountTransaction.GetOrthesisProsthesisTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.MedulaDontSend, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
//                    IList packageTrxList = null; // AccountTransaction.GetPackageTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
//                    IList materialTrxList = null; // AccountTransaction.GetMaterialTrxsForInvoice(_PayerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);

//                    // Hizmetler
//                    foreach (AccountTransaction accTrx in procedureTrxList)
//                    {
//                        PayerInvoiceProcedure invproc = new PayerInvoiceProcedure(_PayerInvoice.ObjectContext);
//                        invproc.ActionDate = accTrx.TransactionDate.Value;
//                        invproc.ExternalCode = accTrx.ExternalCode;
//                        invproc.Description = accTrx.Description;
//                        invproc.Amount = (int)accTrx.Amount;
//                        invproc.UnitPrice = accTrx.UnitPrice;
//                        invproc.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                        invproc.Paid = true;
//                        invproc.AccountTransaction.Add(accTrx);

//                        _PayerInvoice.PayerInvoiceProcedures.Add(invproc);
//                        totalPrice = totalPrice + (double)invproc.TotalPrice;
//                    }

//                    // Ortez-Protez ler
//                    foreach (AccountTransaction accTrx in orthesisProsthesisTrxList)
//                    {
//                        PayerInvoiceProcedure invproc = new PayerInvoiceProcedure(_PayerInvoice.ObjectContext);
//                        invproc.ActionDate = accTrx.TransactionDate.Value;
//                        invproc.ExternalCode = accTrx.ExternalCode;
//                        invproc.Description = accTrx.Description;
//                        invproc.Amount = (int)accTrx.Amount;
//                        invproc.UnitPrice = accTrx.UnitPrice;
//                        invproc.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                        invproc.Paid = true;
//                        invproc.AccountTransaction.Add(accTrx);

//                        _PayerInvoice.PayerInvoiceProcedures.Add(invproc);
//                        totalPrice = totalPrice + (double)invproc.TotalPrice;
//                    }

//                    // Paketler
//                    foreach (AccountTransaction accTrx in packageTrxList)
//                    {
//                        PayerInvoicePackage invpack = new PayerInvoicePackage(_PayerInvoice.ObjectContext);
//                        invpack.ActionDate = accTrx.TransactionDate.Value;
//                        invpack.PackageCode = accTrx.ExternalCode;
//                        invpack.PackageName = accTrx.Description;
//                        invpack.Amount = (int)accTrx.Amount;
//                        invpack.PackagePrice = accTrx.UnitPrice;
//                        invpack.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
//                        invpack.Paid = true;
//                        invpack.PackageAccountTransaction.Add(accTrx);

//                        _PayerInvoice.PayerInvoicePackages.Add(invpack);
//                        totalPrice = totalPrice + (double)invpack.TotalPrice;
//                    }

//                    // Malzeme ve İlaçlar
//                    foreach (AccountTransaction accTrx in materialTrxList)
//                    {
//                        PayerInvoiceMaterial invmat = new PayerInvoiceMaterial(_PayerInvoice.ObjectContext);
//                        invmat.ActionDate = (DateTime)accTrx.TransactionDate;
//                        invmat.ExternalCode = accTrx.ExternalCode;
//                        invmat.Description = accTrx.Description;
//                        invmat.Amount = accTrx.Amount;
//                        invmat.UnitPrice = accTrx.UnitPrice;
//                        invmat.TotalPrice = (double)(accTrx.Amount * accTrx.UnitPrice);
//                        invmat.Paid = true;
//                        invmat.AccountTransaction.Add(accTrx);

//                        _PayerInvoice.PayerInvoiceMaterials.Add(invmat);
//                        totalPrice = totalPrice + (double)invmat.TotalPrice;
//                    }
//                    //}

//                    _PayerInvoice.TotalPrice = totalPrice;
//                    _PayerInvoice.TotalDiscountEntry = 0;
//                    _PayerInvoice.TotalDiscountPrice = 0;
//                    _PayerInvoice.PayerInvoiceDocument.TotalDiscountPrice = 0;
//                    _PayerInvoice.PayerInvoiceDocument.TotalPrice = _PayerInvoice.TotalPrice;
//                    _PayerInvoice.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.New;

//                    // Sadece Fatura İndirim rolüne sahip kullanıcılara indirim alanları açılır
//                    Guid InvoiceDiscountRole = new Guid("F8F3C082-9045-4DDC-873C-12E5D22188F1"); // Fatura İndirim rolü
//                    if (Common.CurrentUser.HasRole(InvoiceDiscountRole))
//                    {
//                        this.DISCOUNTTYPE.ReadOnly = false;
//                        this.TOTALDISCOUNTENTRY.ReadOnly = false;
//                        this.BUTTONDISCOUNT.ReadOnly = false;
//                    }
//                    else
//                    {
//                        this.DISCOUNTTYPE.ReadOnly = true;
//                        this.TOTALDISCOUNTENTRY.ReadOnly = true;
//                        this.BUTTONDISCOUNT.ReadOnly = true;
//                    }
//                    //}
//                }
//                this.BTNLIST.ReadOnly = false;
//            }
//            else
//            {
//                this.PROCEDUREGROUPENUM.ReadOnly = true;
//                this.PAYERNAME.ReadOnly = true;
//                this.PROTOCOLNAME.ReadOnly = true;
//                this.PISUBEPISODE.ReadOnly = true;
//                this.BUTTONDISCOUNT.ReadOnly = true;
//                this.BTNLIST.ReadOnly = true;
//                this.DISCOUNTTYPE.ReadOnly = true;
//                this.TOTALDISCOUNTENTRY.ReadOnly = true;
//                this.Description.ReadOnly = true;
//                this.GRIDInvoiceProcedures.ReadOnly = true;
//                this.GRIDInvoiceMaterials.ReadOnly = true;
//                this.GRIDInvoicePackages.ReadOnly = true;
//                this.PatientStatus.ReadOnly = true;
//                this.CHECKBUTTON.ReadOnly = true;

//                if (TTObjectClasses.SystemParameter.GetParameterValue("INVOICEBYSUBEPISODE", "FALSE") == "TRUE")
//                {
//                    this.PatientStatus.Visible = false;
//                    this.LblHastaDurumu.Visible = false;
//                }
//            }

//            if (_PayerInvoice.CurrentStateDefID == PayerInvoice.States.ReadyToCollectedInvoice)
//                this.DropStateButton(PayerInvoice.States.CollectedInvoiced);
//            else if (_PayerInvoice.CurrentStateDefID == PayerInvoice.States.CollectedInvoiced)
//            {
//                this.DropStateButton(PayerInvoice.States.ReadyToCollectedInvoice);

//                /*
//                if(_PayerInvoice.PISubEpisode == null)
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_PayerInvoiceProcedureDetailReport_SE));
//                else
//                    this.DropCurrentStateReport(typeof(TTReportClasses.I_PayerInvoiceProcedureDetailReport));
//                    */

//                foreach (CollectedPatientList cpl in _PayerInvoice.CollectedPatientList)
//                {
//                    if (cpl.CollectedInvoice.CurrentStateDefID == CollectedInvoice.States.CollectedInvoiced)
//                    {
//                        this.DOCUMENTNO.Text = cpl.CollectedInvoice.CollectedInvoiceDocument.DocumentNo;
//                        break;
//                    }
//                }
//            }

//            if (_PayerInvoice.CurrentStateDefID == PayerInvoice.States.Invoiced || _PayerInvoice.CurrentStateDefID == PayerInvoice.States.Cancelled)
//            {
//                this.CancelReasonLabel.Visible = true;
//                this.CancelReasonText.Visible = true;

//                if (_PayerInvoice.CurrentStateDefID == PayerInvoice.States.Cancelled)
//                    this.CancelReasonLabel.ReadOnly = true;
//                else
//                {
//                    this.CancelReasonLabel.ReadOnly = false;
//                    this.CancelReasonLabel.Required = true;
//                }
//            }
//            #endregion PayerInvoiceForm_PreScript

//        }

//        protected override void PostScript(TTObjectStateTransitionDef transDef)
//        {
//            #region PayerInvoiceForm_PostScript
//            base.PostScript(transDef);
//            #endregion PayerInvoiceForm_PostScript

//        }

//        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
//        {
//            #region PayerInvoiceForm_ClientSidePostScript
//            base.ClientSidePostScript(transDef);

//            // Episode da hiç tanı girilmemişse kullanıcıdan onay alınır
//            if (transDef != null && transDef.FromStateDefID == PayerInvoice.States.New && transDef.ToStateDefID == PayerInvoice.States.Invoiced)
//            {
//                if (_PayerInvoice.Episode.Diagnosis.Count == 0)
//                {
//                    if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Kurum Faturası kesmek istediğiniz vakaya tanı girilmemiştir. \nDevam etmek istediğinize emin misiniz?") == "H")
//                        throw new TTUtils.TTException("Kurum Faturası kesme işleminden vazgeçildi.");
//                }
//            }

//            if (transDef != null && transDef.FromStateDefID == PayerInvoice.States.New && transDef.ToStateDefID == PayerInvoice.States.ReadyToCollectedInvoice)
//            {
//                // Episode da hiç tanı girilmemişse kullanıcıdan onay alınır
//                if (_PayerInvoice.Episode.Diagnosis.Count == 0)
//                {
//                    if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Toplu Faturaya Hazır'a getirmek istediğiniz vakaya tanı girilmemiştir. Bu yüzden Toplu Fatura işleminde listeleme yapıldığında gelmeyecektir.\nDevam etmek istediğinize emin misiniz?") == "H")
//                        throw new TTUtils.TTException(SystemMessage.GetMessage(631));
//                }

//                // Portör Muayenesi ve Periyodik Muayene için kullanıcıdan onay alınır
//                if (_PayerInvoice.SubEpisode.PatientAdmission.AdmissionType != null)
//                {
//                    if (_PayerInvoice.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.PortorExamination)
//                    {
//                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Toplu Faturaya Hazır'a getirmek istediğiniz vakanın hasta kabul sebebi Portör Muayenesidir.\nDevam etmek istediğinize emin misiniz?") == "H")
//                            throw new TTUtils.TTException(SystemMessage.GetMessage(631));
//                    }
//                    else if (_PayerInvoice.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.PeriodicExamination)
//                    {
//                        if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Toplu Faturaya Hazır'a getirmek istediğiniz vakanın hasta kabul sebebi Periyodik Muayenedir.\nDevam etmek istediğinize emin misiniz?") == "H")
//                            throw new TTUtils.TTException(SystemMessage.GetMessage(631));
//                    }
//                }

//                // SUT 4.2.14'üncü maddeye istinaden eklenen uyarı (Issue: 6595 , 7092)
//                HealthCommittee hc = _PayerInvoice.Episode.GetNotCollectedInvoicableHealthCommittee();
//                if (hc != null)
//                {
//                    if (TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Toplu Faturaya Hazır'a getirmek istediğiniz vakada bulunan " + hc.ID + " numaralı Sağlık Kurulu işleminin muayene nedeni (" + hc.HCRequestReason.ReasonForExamination.Reason + "), 'XXXXXX Çalışan ve Aileleri İçin Toplu Fatura Harici Tutulur' şeklinde tanımlıdır.\nDevam etmek istediğinize emin misiniz?") == "H")
//                        throw new TTUtils.TTException(SystemMessage.GetMessage(631));
//                }
//            }
//            #endregion PayerInvoiceForm_ClientSidePostScript

//        }
//    }
//}