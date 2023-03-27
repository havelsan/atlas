
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
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PrescriptionConsumptionDocumentNewForm : BasePrescriptionConsumptionDocumentForm
    {
        protected override void PreScript()
        {
#region PrescriptionConsumptionDocumentNewForm_PreScript
    base.PreScript();
            
            if(_PrescriptionConsumptionDocument.Store is IUnitStoreDefinition)
            {
                IList terms = _PrescriptionConsumptionDocument.ObjectContext.QueryObjects("ACCOUNTINGTERM", "STATUS = 1");
                if (terms.Count > 0)
                {
                    if (terms.Count == 1)
                    {
                        _PrescriptionConsumptionDocument.AccountingTerm = (AccountingTerm)terms[0];
                    }
                    else
                    {
                        throw new TTException(SystemMessage.GetMessage(1151));
                    }
                }
                else
                {
                    throw new TTException(SystemMessage.GetMessage(1152));
                }
            }
#endregion PrescriptionConsumptionDocumentNewForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region PrescriptionConsumptionDocumentNewForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (this._PrescriptionConsumptionDocument.CurrentStateDefID == PrescriptionConsumptionDocument.States.New)
            {
                PrescriptionConsumptionDocumentDateEntryForm prescriptionConsumptionDocumentDateEntryForm = new PrescriptionConsumptionDocumentDateEntryForm();
                DialogResult dialogResult = prescriptionConsumptionDocumentDateEntryForm.ShowEdit(this, this._PrescriptionConsumptionDocument, true);

                if (dialogResult == DialogResult.OK)
                {

                    StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)_PrescriptionConsumptionDocument.ObjectContext.GetObject(new Guid(_PrescriptionConsumptionDocument.ObjectDef.Attributes["STOCKCONSUMPTIONTRANSACTIONATTRIBUTE"].Parameters["stockTransactionDef"].Value.ToString()), "STOCKTRANSACTIONDEFINITION");
                    int rowCount = 0;
                    bool calcnew = false;
                    List<StockTransaction> stockTransactions = stockTransactionDefinition.CollectStockTransactions((DateTime)_PrescriptionConsumptionDocument.StartDate, (DateTime)_PrescriptionConsumptionDocument.EndDate, _PrescriptionConsumptionDocument.Store);
                    if (stockTransactions != null)
                    {

                        foreach (StockTransaction stockTransaction in stockTransactions)
                        {
                            IList existDetails = this._PrescriptionConsumptionDocument.PresConsumptionDocOutMaterials.Select("MATERIAL = " + ConnectionManager.GuidToString(stockTransaction.Stock.Material.ObjectID));
                            PrescriptionConsDocMatOut prescriptionConsumptionDocumentMaterialOut = null;
                            if (existDetails.Count > 0)
                            {
                                prescriptionConsumptionDocumentMaterialOut = (PrescriptionConsDocMatOut)existDetails[0];
                                prescriptionConsumptionDocumentMaterialOut.Amount += stockTransaction.Amount;

                                StockCollectedTrx stockCollectedTrx = prescriptionConsumptionDocumentMaterialOut.StockCollectedTrxs.AddNew();
                                stockCollectedTrx.StockTransaction = stockTransaction;

                                if (stockTransaction.StockActionDetail.StockAction is StockPrescriptionOut)
                                {
                                    StockPrescriptionOut stockPrescriptionOut = (StockPrescriptionOut)stockTransaction.StockActionDetail.StockAction;
                                    PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PrescriptionConsumptionDocument.ObjectContext);
                                    prescriptionConsumptionDetail.ActionDate = stockPrescriptionOut.Prescription.ActionDate;
                                    prescriptionConsumptionDetail.ActionDescription = stockPrescriptionOut.Prescription.ObjectDef.Description;
                                    prescriptionConsumptionDetail.ActionID = (int)stockPrescriptionOut.Prescription.ID.Value;
                                    prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                    prescriptionConsumptionDetail.DocktorFullName = stockPrescriptionOut.Prescription.ProcedureDoctor.Person.FullName;
                                    prescriptionConsumptionDetail.PatienFullName = stockPrescriptionOut.Prescription.Episode.Patient.FullName;
                                    prescriptionConsumptionDetail.PrescriptionNo = stockPrescriptionOut.PrescriptionPaper.SerialNo + " - " + stockPrescriptionOut.PrescriptionPaper.VolumeNo;
                                    prescriptionConsumptionDetail.PrescriptionConsumptionDocMat = prescriptionConsumptionDocumentMaterialOut;
                                }
                                if (stockTransaction.StockActionDetail.StockAction is ResSubStoreConsumption)
                                {
                                    ResSubStoreConsumptionDetail resSubStoreConsumptionDetail = (ResSubStoreConsumptionDetail)stockTransaction.StockActionDetail;
                                    foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in resSubStoreConsumptionDetail.PrescriptionPaperOutDetails)
                                    {
                                        ResSubStoreConsumption resSubStoreConsumption = (ResSubStoreConsumption)resSubStoreConsumptionDetail.StockAction;
                                        PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PrescriptionConsumptionDocument.ObjectContext);
                                        prescriptionConsumptionDetail.ActionDate = resSubStoreConsumption.TransactionDate;
                                        prescriptionConsumptionDetail.ActionDescription = resSubStoreConsumption.ObjectDef.Description;
                                        prescriptionConsumptionDetail.ActionID = (int)resSubStoreConsumption.StockActionID.Value;
                                        prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                        prescriptionConsumptionDetail.PrescriptionNo = prescriptionPaperOutDetail.PrescriptionPaper.SerialNo + " - " + prescriptionPaperOutDetail.PrescriptionPaper.VolumeNo;
                                        prescriptionConsumptionDetail.PrescriptionConsumptionDocMat = prescriptionConsumptionDocumentMaterialOut;
                                    }
                                }
                                
                                if (stockTransaction.StockActionDetail.StockAction is PresInfirmaryDocument)
                                {
                                    PresInfirmaryDocMatOut presInfirmaryDocMatOut = (PresInfirmaryDocMatOut)stockTransaction.StockActionDetail;
                                    foreach (PrescriptionConsumptionDetail detail in presInfirmaryDocMatOut.PrescriptionConsumptionDetails)
                                    {
                                        PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PrescriptionConsumptionDocument.ObjectContext);
                                        prescriptionConsumptionDetail.ActionDate = detail.ActionDate;
                                        prescriptionConsumptionDetail.ActionDescription = detail.ActionDescription;
                                        prescriptionConsumptionDetail.ActionID = detail.ActionID;
                                        prescriptionConsumptionDetail.Amount = detail.Amount;
                                        prescriptionConsumptionDetail.DocktorFullName = detail.DocktorFullName;
                                        prescriptionConsumptionDetail.PatienFullName = detail.PatienFullName;
                                        prescriptionConsumptionDetail.PrescriptionNo = detail.PrescriptionNo ;
                                        prescriptionConsumptionDetail.PrescriptionConsumptionDocMat = prescriptionConsumptionDocumentMaterialOut;
                                    }
                                }
                                
                            }
                            else
                            {
                                if (rowCount >= 20)
                                {
                                    calcnew = true;
                                }
                                else
                                {
                                    prescriptionConsumptionDocumentMaterialOut = this._PrescriptionConsumptionDocument.PresConsumptionDocOutMaterials.AddNew();
                                    prescriptionConsumptionDocumentMaterialOut.Amount = stockTransaction.Amount;
                                    prescriptionConsumptionDocumentMaterialOut.Material = stockTransaction.Stock.Material;
                                    prescriptionConsumptionDocumentMaterialOut.StockLevelType = stockTransaction.StockLevelType;
                                    prescriptionConsumptionDocumentMaterialOut.Material.StockCard.DistributionType = stockTransaction.Stock.Material.StockCard.DistributionType;

                                    StockCollectedTrx stockCollectedTrx = prescriptionConsumptionDocumentMaterialOut.StockCollectedTrxs.AddNew();
                                    stockCollectedTrx.StockTransaction = stockTransaction;

                                    if (stockTransaction.StockActionDetail.StockAction is StockPrescriptionOut)
                                    {
                                        StockPrescriptionOut stockPrescriptionOut = (StockPrescriptionOut)stockTransaction.StockActionDetail.StockAction;
                                        PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PrescriptionConsumptionDocument.ObjectContext);
                                        prescriptionConsumptionDetail.ActionDate = stockPrescriptionOut.Prescription.ActionDate;
                                        prescriptionConsumptionDetail.ActionDescription = stockPrescriptionOut.Prescription.ObjectDef.Description;
                                        prescriptionConsumptionDetail.ActionID = (int)stockPrescriptionOut.Prescription.ID.Value;
                                        prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                        prescriptionConsumptionDetail.DocktorFullName = stockPrescriptionOut.Prescription.ProcedureDoctor.Person.FullName;
                                        prescriptionConsumptionDetail.PatienFullName = stockPrescriptionOut.Prescription.Episode.Patient.FullName;
                                        prescriptionConsumptionDetail.PrescriptionNo = stockPrescriptionOut.PrescriptionPaper.SerialNo + " - " + stockPrescriptionOut.PrescriptionPaper.VolumeNo;
                                        prescriptionConsumptionDetail.PrescriptionConsumptionDocMat = prescriptionConsumptionDocumentMaterialOut;
                                    }
                                    if (stockTransaction.StockActionDetail.StockAction is ResSubStoreConsumption)
                                    {
                                        ResSubStoreConsumptionDetail resSubStoreConsumptionDetail = (ResSubStoreConsumptionDetail)stockTransaction.StockActionDetail;
                                        foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in resSubStoreConsumptionDetail.PrescriptionPaperOutDetails)
                                        {
                                            ResSubStoreConsumption resSubStoreConsumption = (ResSubStoreConsumption)resSubStoreConsumptionDetail.StockAction;
                                            PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PrescriptionConsumptionDocument.ObjectContext);
                                            prescriptionConsumptionDetail.ActionDate = resSubStoreConsumption.TransactionDate;
                                            prescriptionConsumptionDetail.ActionDescription = resSubStoreConsumption.ObjectDef.Description;
                                            prescriptionConsumptionDetail.ActionID = (int)resSubStoreConsumption.StockActionID.Value;
                                            prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                            prescriptionConsumptionDetail.PrescriptionNo = prescriptionPaperOutDetail.PrescriptionPaper.SerialNo + " - " + prescriptionPaperOutDetail.PrescriptionPaper.VolumeNo;
                                            prescriptionConsumptionDetail.PrescriptionConsumptionDocMat = prescriptionConsumptionDocumentMaterialOut;
                                        }
                                    }
                                    if (stockTransaction.StockActionDetail.StockAction is PresInfirmaryDocument)
                                    {
                                        PresInfirmaryDocMatOut presInfirmaryDocMatOut = (PresInfirmaryDocMatOut)stockTransaction.StockActionDetail;
                                        foreach (PrescriptionConsumptionDetail detail in presInfirmaryDocMatOut.PrescriptionConsumptionDetails)
                                        {
                                            PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PrescriptionConsumptionDocument.ObjectContext);
                                            prescriptionConsumptionDetail.ActionDate = detail.ActionDate;
                                            prescriptionConsumptionDetail.ActionDescription = detail.ActionDescription;
                                            prescriptionConsumptionDetail.ActionID = detail.ActionID;
                                            prescriptionConsumptionDetail.Amount = detail.Amount;
                                            prescriptionConsumptionDetail.DocktorFullName = detail.DocktorFullName;
                                            prescriptionConsumptionDetail.PatienFullName = detail.PatienFullName;
                                            prescriptionConsumptionDetail.PrescriptionNo = detail.PrescriptionNo ;
                                            prescriptionConsumptionDetail.PrescriptionConsumptionDocMat = prescriptionConsumptionDocumentMaterialOut;
                                        }
                                    }
                                    rowCount++;
                                }

                            }
                        }
                    }
                    if (calcnew)
                    {
                        TTVisual.InfoBox.Show(((DateTime)_PrescriptionConsumptionDocument.StartDate).ToShortDateString() + " " + ((DateTime)_PrescriptionConsumptionDocument.EndDate).ToShortDateString() + " tarihleri arasında bu işlemi bir daha çalıştırmanız gerekmektedir.", MessageIconEnum.InformationMessage);
                    }
                }


                if (_PrescriptionConsumptionDocument.StockActionSignDetails.Count == 0)
                {
                    StockActionSignDetail stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;

                    stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                    if (_PrescriptionConsumptionDocument.DestinationStore is MainStoreDefinition)
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_PrescriptionConsumptionDocument.DestinationStore).GoodsAccountant;

                    stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                    if (_PrescriptionConsumptionDocument.DestinationStore is MainStoreDefinition)
                    {
                        ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                        if (user.SelectedSecMasterResource != null && user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                            stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                    }

                    stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikMalSorumlusu;
                    if (_ProductionConsumptionDocument.DestinationStore is MainStoreDefinition)
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_PrescriptionConsumptionDocument.DestinationStore).GoodsResponsible;

                    stockActionSignDetail = _PrescriptionConsumptionDocument.StockActionSignDetails.AddNew();
                    stockActionSignDetail.SignUserType = SignUserTypeEnum.DepoSorumlusu;
                    if (_ProductionConsumptionDocument.Store is SubStoreDefinition)
                        stockActionSignDetail.SignUser = ((SubStoreDefinition)_PrescriptionConsumptionDocument.Store).StoreResponsible;
                    else if (_ProductionConsumptionDocument.Store is PharmacyStoreDefinition)
                        stockActionSignDetail.SignUser = ((PharmacyStoreDefinition)_PrescriptionConsumptionDocument.Store).StoreResponsible;
                }
            }
#endregion PrescriptionConsumptionDocumentNewForm_ClientSidePreScript

        }
    }
}