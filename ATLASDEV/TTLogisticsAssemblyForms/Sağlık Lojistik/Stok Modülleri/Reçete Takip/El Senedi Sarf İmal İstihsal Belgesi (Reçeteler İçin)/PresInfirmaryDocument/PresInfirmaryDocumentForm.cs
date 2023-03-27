
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
    /// El Senedei Sarf İmal İhtishal Belgesi (Reçeteler İçin)
    /// </summary>
    public partial class PresInfirmaryDocumentForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region PresInfirmaryDocumentForm_PreScript
    base.PreScript();
#endregion PresInfirmaryDocumentForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region PresInfirmaryDocumentForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            PresInfirmaryDocumentDateForm presInfirmaryDocumentDateForm = new PresInfirmaryDocumentDateForm();
            DialogResult dialogResult = presInfirmaryDocumentDateForm.ShowEdit(this, this._PresInfirmaryDocument, true);

            if (dialogResult == DialogResult.OK)
            {

                StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)_PresInfirmaryDocument.ObjectContext.GetObject(new Guid(_PresInfirmaryDocument.ObjectDef.Attributes["STOCKCONSUMPTIONTRANSACTIONATTRIBUTE"].Parameters["stockTransactionDef"].Value.ToString()), "STOCKTRANSACTIONDEFINITION");
                int rowCount = 0;
                bool calcnew = false;
                List<StockTransaction> stockTransactions = stockTransactionDefinition.CollectStockTransactions((DateTime)_PresInfirmaryDocument.StartDate, (DateTime)_PresInfirmaryDocument.EndDate, _PresInfirmaryDocument.Store);
                if (stockTransactions != null)
                {

                    foreach (StockTransaction stockTransaction in stockTransactions)
                    {
                        IList existDetails = this._PresInfirmaryDocument.PresInfirmaryDocumentOutMaterials.Select("MATERIAL = " + ConnectionManager.GuidToString(stockTransaction.Stock.Material.ObjectID));
                        PresInfirmaryDocMatOut presInfirmaryDocMatOut = null;
                        if (existDetails.Count > 0)
                        {
                            presInfirmaryDocMatOut = (PresInfirmaryDocMatOut)existDetails[0];
                            presInfirmaryDocMatOut.Amount += stockTransaction.Amount;

                            StockCollectedTrx stockCollectedTrx = presInfirmaryDocMatOut.StockCollectedTrxs.AddNew();
                            stockCollectedTrx.StockTransaction = stockTransaction;

                            if (stockTransaction.StockActionDetail.StockAction is StockPrescriptionOut)
                            {
                                StockPrescriptionOut stockPrescriptionOut = (StockPrescriptionOut)stockTransaction.StockActionDetail.StockAction;
                                PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PresInfirmaryDocument.ObjectContext);
                                prescriptionConsumptionDetail.ActionDate = stockPrescriptionOut.Prescription.ActionDate;
                                prescriptionConsumptionDetail.ActionDescription = stockPrescriptionOut.Prescription.ObjectDef.Description;
                                prescriptionConsumptionDetail.ActionID = (int)stockPrescriptionOut.Prescription.ID.Value;
                                prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                prescriptionConsumptionDetail.DocktorFullName = stockPrescriptionOut.Prescription.ProcedureDoctor.Person.FullName;
                                prescriptionConsumptionDetail.PatienFullName = stockPrescriptionOut.Prescription.Episode.Patient.FullName;
                                prescriptionConsumptionDetail.PrescriptionNo = stockPrescriptionOut.PrescriptionPaper.SerialNo + " - " + stockPrescriptionOut.PrescriptionPaper.VolumeNo;
                                prescriptionConsumptionDetail.PresInfirmaryDocMatOut = presInfirmaryDocMatOut;
                            }
                            if (stockTransaction.StockActionDetail.StockAction is ResSubStoreConsumption)
                            {
                                ResSubStoreConsumptionDetail resSubStoreConsumptionDetail = (ResSubStoreConsumptionDetail)stockTransaction.StockActionDetail;
                                foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in resSubStoreConsumptionDetail.PrescriptionPaperOutDetails)
                                {
                                    ResSubStoreConsumption resSubStoreConsumption = (ResSubStoreConsumption)resSubStoreConsumptionDetail.StockAction;
                                    PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PresInfirmaryDocument.ObjectContext);
                                    prescriptionConsumptionDetail.ActionDate = resSubStoreConsumption.TransactionDate;
                                    prescriptionConsumptionDetail.ActionDescription = resSubStoreConsumption.ObjectDef.Description;
                                    prescriptionConsumptionDetail.ActionID = (int)resSubStoreConsumption.StockActionID.Value;
                                    prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                    prescriptionConsumptionDetail.PrescriptionNo = prescriptionPaperOutDetail.PrescriptionPaper.SerialNo + " - " + prescriptionPaperOutDetail.PrescriptionPaper.VolumeNo;
                                    prescriptionConsumptionDetail.PresInfirmaryDocMatOut = presInfirmaryDocMatOut;
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
                                presInfirmaryDocMatOut = this._PresInfirmaryDocument.PresInfirmaryDocumentOutMaterials.AddNew();
                                presInfirmaryDocMatOut.Amount = stockTransaction.Amount;
                                presInfirmaryDocMatOut.Material = stockTransaction.Stock.Material;
                                presInfirmaryDocMatOut.StockLevelType = stockTransaction.StockLevelType;
                                presInfirmaryDocMatOut.Material.StockCard.DistributionType = stockTransaction.Stock.Material.StockCard.DistributionType;

                                StockCollectedTrx stockCollectedTrx = presInfirmaryDocMatOut.StockCollectedTrxs.AddNew();
                                stockCollectedTrx.StockTransaction = stockTransaction;

                                if (stockTransaction.StockActionDetail.StockAction is StockPrescriptionOut)
                                {
                                    StockPrescriptionOut stockPrescriptionOut = (StockPrescriptionOut)stockTransaction.StockActionDetail.StockAction;
                                    PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PresInfirmaryDocument.ObjectContext);
                                    prescriptionConsumptionDetail.ActionDate = stockPrescriptionOut.Prescription.ActionDate;
                                    prescriptionConsumptionDetail.ActionDescription = stockPrescriptionOut.Prescription.ObjectDef.Description;
                                    prescriptionConsumptionDetail.ActionID = (int)stockPrescriptionOut.Prescription.ID.Value;
                                    prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                    prescriptionConsumptionDetail.DocktorFullName = stockPrescriptionOut.Prescription.ProcedureDoctor.Person.FullName;
                                    prescriptionConsumptionDetail.PatienFullName = stockPrescriptionOut.Prescription.Episode.Patient.FullName;
                                    prescriptionConsumptionDetail.PrescriptionNo = stockPrescriptionOut.PrescriptionPaper.SerialNo + " - " + stockPrescriptionOut.PrescriptionPaper.VolumeNo;
                                    prescriptionConsumptionDetail.PresInfirmaryDocMatOut = presInfirmaryDocMatOut;
                                }
                                if (stockTransaction.StockActionDetail.StockAction is ResSubStoreConsumption)
                                {
                                    ResSubStoreConsumptionDetail resSubStoreConsumptionDetail = (ResSubStoreConsumptionDetail)stockTransaction.StockActionDetail;
                                    foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in resSubStoreConsumptionDetail.PrescriptionPaperOutDetails)
                                    {
                                        ResSubStoreConsumption resSubStoreConsumption = (ResSubStoreConsumption)resSubStoreConsumptionDetail.StockAction;
                                        PrescriptionConsumptionDetail prescriptionConsumptionDetail = new PrescriptionConsumptionDetail(_PresInfirmaryDocument.ObjectContext);
                                        prescriptionConsumptionDetail.ActionDate = resSubStoreConsumption.TransactionDate;
                                        prescriptionConsumptionDetail.ActionDescription = resSubStoreConsumption.ObjectDef.Description;
                                        prescriptionConsumptionDetail.ActionID = (int)resSubStoreConsumption.StockActionID.Value;
                                        prescriptionConsumptionDetail.Amount = stockTransaction.Amount;
                                        prescriptionConsumptionDetail.PrescriptionNo = prescriptionPaperOutDetail.PrescriptionPaper.SerialNo + " - " + prescriptionPaperOutDetail.PrescriptionPaper.VolumeNo;
                                        prescriptionConsumptionDetail.PresInfirmaryDocMatOut = presInfirmaryDocMatOut;
                                    }
                                }
                                rowCount++;
                            }

                        }
                    }
                }
                if (calcnew)
                {
                    TTVisual.InfoBox.Show(((DateTime)_PresInfirmaryDocument.StartDate).ToShortDateString() + " " + ((DateTime)_PresInfirmaryDocument.EndDate).ToShortDateString() + " tarihleri arasında bu işlemi bir daha çalıştırmanız gerekmektedir.", MessageIconEnum.InformationMessage);
                }
            }
#endregion PresInfirmaryDocumentForm_ClientSidePreScript

        }
    }
}