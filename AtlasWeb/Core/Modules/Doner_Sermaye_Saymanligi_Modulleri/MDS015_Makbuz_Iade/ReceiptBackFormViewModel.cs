//$F8C4E026
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Infrastructure.Helpers;
using System.Collections.Generic;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    public partial class ReceiptBackServiceController
    {
        partial void PreScript_ReceiptBackForm(ReceiptBackFormViewModel viewModel, ReceiptBack receiptBack, TTObjectContext objectContext)
        {
            if (((ITTObject)receiptBack).IsNew)
            {
                Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeObjectID.HasValue)
                {
                    Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                    viewModel._ReceiptBack.Episode = episode;
                }

                ComputerNameHelper computerNameHelper = new Infrastructure.Helpers.ComputerNameHelper();
                viewModel._ReceiptBack.PrepareNewReceiptBack(/*computerNameHelper.GetClientComputerName(this.ControllerContext.HttpContext.GetRemoteIpAddress())*/);
                ContextToViewModel(viewModel, objectContext);
                viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                viewModel.ReceiptDocuments = objectContext.LocalQuery<ReceiptDocument>().ToArray();
                viewModel.AccountTransactions = objectContext.LocalQuery<AccountTransaction>().ToArray();
            }
            else
            {
                ContextToViewModel(viewModel, objectContext);
                viewModel.ReceiptDocuments = objectContext.LocalQuery<ReceiptDocument>().ToArray();
                viewModel.AccountTransactions = objectContext.LocalQuery<AccountTransaction>().ToArray();
                viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                objectContext.FullPartialllyLoadedObjects();
            }
        }

        partial void PostScript_ReceiptBackForm(ReceiptBackFormViewModel viewModel, ReceiptBack receiptBack, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            receiptBack.Receipt = viewModel.Receipts[0];
            receiptBack.ReceiptBackDocument = viewModel.ReceiptBackDocuments[0];
            foreach (AccountTransaction accTrx in viewModel.AccountTransactions)
            {
                objectContext.AddObject(accTrx);
            }
        }

        //[HttpPost]
        //public void ReceiptBackForm([ModelBinder(typeof(NebulaModelBinder))]ReceiptBackFormViewModel viewModel)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        Guid entryStateID = Guid.Parse("1c3e4ccf-3546-407e-8b1e-a910eeba8188");
        //        var receiptBack = (ReceiptBack)objectContext.AddObject(viewModel._ReceiptBack, entryStateID);
        //        var receiptBackDoc = (ReceiptBackDocument)objectContext.AddObject(viewModel.ReceiptBackDocuments[0]);
        //        receiptBack.ReceiptBackDocument = receiptBackDoc;
        //        foreach (ReceiptBackDetail receiptBackDet in viewModel.GRIDReceiptBackDetailsGridList)
        //        {
        //            objectContext.AddObject(receiptBackDet);
        //        }
        //        foreach (AccountTransaction accTrx in viewModel.AccountTransactions)
        //        {
        //            objectContext.AddObject(accTrx);
        //        }
        //        //Receipt receipt = (Receipt)objectContext.AddObject(viewModel.Receipts[0]);
        //        receiptBack.Receipt = (Receipt)objectContext.GetObject(viewModel.Receipts[0].ObjectID, typeof(Receipt));
        //        if (viewModel.GRIDReceiptBackDetailsGridList != null)
        //        {
        //            foreach (var item in viewModel.GRIDReceiptBackDetailsGridList)
        //            {
        //                var receiptBackDetailsImported = (ReceiptBackDetail)objectContext.AddObject(item);
        //                receiptBackDetailsImported.ReceiptBack = receiptBack;
        //            }
        //        }
        //        objectContext.Save();
        //    }
        //}
        [HttpGet]
        public ReceiptBackDetailViewModel GetReceiptsForReceiptBack(Guid receiptObjID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                var receipt = (Receipt)objectContext.GetObject(receiptObjID, typeof (Receipt)); /*(Receipt)objectContext.AddObject(viewModel.Receipts[0]);*/
                ReceiptBackDetailViewModel rbdvm = new ReceiptBackDetailViewModel();
                if (receipt != null)
                {
                    rbdvm.receipt = receipt;
                    //Receipt receipt = (Receipt)objectContext.GetObject(viewModel.Receipts[0].ObjectID, typeof(Receipt));
                    foreach (ReceiptDocumentGroup receiptDocGroup in receipt.ReceiptDocument.ReceiptDocumentGroups)
                    {
                        foreach (ReceiptDocumentDetail receiptDocDetail in receiptDocGroup.ReceiptDocumentDetails)
                        {
                            ReceiptBackDetail _receiptBackDetail = new ReceiptBackDetail(objectContext);
                            PatientPaymentDetail ppDetail = ReceiptDocument.GetPatientPaymentDetail(receiptDocDetail.AccountTrxDocument[0].AccountTransaction.ObjectID, receipt.ReceiptDocument);
                            if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID != AccountTransaction.States.Cancelled)
                            {
                                _receiptBackDetail.AccountTransaction.Add(receiptDocDetail.AccountTrxDocument[0].AccountTransaction);
                            }

                            _receiptBackDetail.ReceiptDocumentDetail = receiptDocDetail;
                            _receiptBackDetail.ActionDate = (DateTime)receiptDocDetail.AccountTrxDocument[0].AccountTransaction.TransactionDate.Value;
                            _receiptBackDetail.Amount = receiptDocDetail.Amount;
                            _receiptBackDetail.ExternalCode = receiptDocDetail.ExternalCode;
                            _receiptBackDetail.Description = receiptDocDetail.Description;
                            _receiptBackDetail.UnitPrice = receiptDocDetail.UnitPrice;
                            //_receiptBackDetail.TotalDiscountedPrice = receiptDocDetail.TotalDiscountedPrice;
                            _receiptBackDetail.TotalPrice = (double)receiptDocDetail.Amount * (double)receiptDocDetail.UnitPrice;
                            _receiptBackDetail.PaymentPrice = ppDetail.PaymentPrice;
                            //ReadOnlyFlag cell'in edit'ini kapatmak için web componenetlerine eklenen EnabledBindingPath özelliği için tersine çevrildi.
                            if ((receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure) != null)
                            {
                                if ((receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure).ObjectDef.ToString() == "LABORATORYPROCEDURE")
                                {
                                    if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID == LaboratoryProcedure.States.PendingCancel)
                                    {
                                        _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.ToString();
                                        //_receiptBackDetail.ReadOnlyFlag = false;
                                        _receiptBackDetail.Editable = true;
                                    }
                                    else if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID == LaboratoryProcedure.States.Completed)
                                    {
                                        _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.ToString();
                                        //_receiptBackDetail.ReadOnlyFlag = true;
                                        _receiptBackDetail.Editable = false;
                                    }
                                    else
                                    {
                                        _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.ToString();
                                        //_receiptBackDetail.ReadOnlyFlag = true;
                                        _receiptBackDetail.Editable = false;
                                    }
                                }
                                else
                                {
                                    if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDefID == SubActionProcedure.States.Completed)
                                    {
                                        _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.CurrentStateDef.DisplayText.ToString();
                                        //_receiptBackDetail.ReadOnlyFlag = true;
                                        _receiptBackDetail.Editable = false;
                                    }
                                    else
                                    {
                                        _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.ToString();
                                        if (receiptDocDetail.CurrentStateDefID == ReceiptDocumentDetail.States.ReturnBack)
                                            //_receiptBackDetail.ReadOnlyFlag = true;
                                            _receiptBackDetail.Editable = false;
                                        else
                                            //_receiptBackDetail.ReadOnlyFlag = false;
                                            _receiptBackDetail.Editable = true;
                                    }
                                }
                            }
                            else
                            {
                                if (receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionMaterial.CurrentStateDefID == SubActionMaterial.States.Completed)
                                {
                                    _receiptBackDetail.State = receiptDocDetail.AccountTrxDocument[0].AccountTransaction.SubActionMaterial.CurrentStateDef.DisplayText.ToString();
                                    //_receiptBackDetail.ReadOnlyFlag = true;
                                    _receiptBackDetail.Editable = false;
                                }
                                else
                                {
                                    _receiptBackDetail.State = receiptDocDetail.CurrentStateDef.DisplayText.ToString();
                                    if (receiptDocDetail.CurrentStateDefID == ReceiptDocumentDetail.States.ReturnBack)
                                        //_receiptBackDetail.ReadOnlyFlag = true;
                                        _receiptBackDetail.Editable = false;
                                    else
                                        //_receiptBackDetail.ReadOnlyFlag = false;
                                        _receiptBackDetail.Editable = true;
                                }
                            }

                            _receiptBackDetail.Return = false;
                            rbdvm.ReceiptBackDetails.Add(_receiptBackDetail);
                            rbdvm.AccountTransactions.Add(receiptDocDetail.AccountTrxDocument[0].AccountTransaction);
                        }
                    }

                    return rbdvm;
                }
                else
                    return rbdvm;
            }
        }
    }
}

namespace Core.Models
{
    public partial class ReceiptBackFormViewModel
    {
        public Episode[] Episodes
        {
            get;
            set;
        }

        public ReceiptDocument[] ReceiptDocuments
        {
            get;
            set;
        }

        public AccountTransaction[] AccountTransactions
        {
            get;
            set;
        }
    }

    public class ReceiptBackDetailViewModel
    {
        public Receipt receipt
        {
            get;
            set;
        }

        public List<ReceiptBackDetail> ReceiptBackDetails = new List<ReceiptBackDetail>();
        public List<AccountTransaction> AccountTransactions = new List<AccountTransaction>();
    }
}