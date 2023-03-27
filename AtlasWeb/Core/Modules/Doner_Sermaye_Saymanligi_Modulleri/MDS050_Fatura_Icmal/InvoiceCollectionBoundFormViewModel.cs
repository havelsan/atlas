//$4C44164D
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Collections.Generic;
using TTDataDictionary;
using TTVisual;
using TTUtils;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Models;
using TTDefinitionManagement;
using Core.Security;
using TTStorageManager.Security;
using Newtonsoft.Json;

namespace Core.Controllers
{
    public partial class InvoiceCollectionServiceController : Controller
    {
        partial void PreScript_InvoiceCollectionBoundForm(InvoiceCollectionBoundFormViewModel viewModel, InvoiceCollection invoiceCollection, TTObjectContext objectContext)
        {
            if (((ITTObject)invoiceCollection).IsNew == false)
            {
                ContextToViewModel(viewModel, objectContext);
                viewModel.PayerType = viewModel._InvoiceCollection.Payer.Type.PayerType;
                //viewModel.GridModel = CreateDetailGridModel(objectContext, invoiceCollection.ObjectID);
                viewModel.TermDay = invoiceCollection.TermDay;
                viewModel.LastPaymentDate = invoiceCollection.LastPaymentDate;
                viewModel.CancelledInvoices = CreateCancelDetailGridModel(objectContext, invoiceCollection.ObjectID);
                //viewModel.InvoiceCollectionDetailCount = viewModel.GridModel.Count;
            }
            else
            {
                viewModel._InvoiceCollection.PrepareNewInvoiceCollection();
                ContextToViewModel(viewModel, objectContext);
                //viewModel.GridModel = new List<InvoiceCollectionDetailGridViewModel>();
                viewModel.SEPObjectIDs = new List<Guid>();
            }
        }

        partial void PostScript_InvoiceCollectionBoundForm(InvoiceCollectionBoundFormViewModel viewModel, InvoiceCollection invoiceCollection, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (((ITTObject)invoiceCollection).IsNew)
                if (viewModel.SEPObjectIDs != null && viewModel.SEPObjectIDs.Count > 0)
                {
                    foreach (Guid sepObjId in viewModel.SEPObjectIDs)
                    {
                        SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjId, typeof(SubEpisodeProtocol));
                        invoiceCollection.AddInvoiceCollectionDetail(sep);
                    }
                }

            List<InvoiceCollectionDetail> icdList = invoiceCollection.InvoiceCollectionDetails.Where(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled).ToList();
            if (icdList != null && icdList.Count > 0)
            {
                foreach (InvoiceCollectionDetail icd in icdList)
                {
                    List<SubEpisodeProtocol> sepList = icd.SubEpisodeProtocols.Where(z => z.CurrentStateDefID != SubEpisodeProtocol.States.Cancelled).ToList();
                    foreach (var sep in sepList)
                    {
                        if (((sep.MedulaTedaviTuru.tedaviTuruKodu == "A" || sep.MedulaTedaviTuru.tedaviTuruKodu == "G") && sep.SubEpisode.Episode.OpeningDate > invoiceCollection.InvoiceTerm.EndDate) ||
                              sep.MedulaTedaviTuru.tedaviTuruKodu == "Y" && sep.SubEpisode.InpatientAdmission != null && sep.SubEpisode.InpatientAdmission.HospitalDischargeDate > invoiceCollection.InvoiceTerm.EndDate)
                        {
                            throw new TTException("İcmal içerisinde dönem ile uyumsuz detaylar bulundu lütfen vaka açılış veya taburcu tarihlerini kontrol ediniz.");
                        }
                    }
                    //SubEpisodeProtocol sep = (SubEpisodeProtocol)objectContext.GetObject(sepObjId, typeof(SubEpisodeProtocol));
                }
            }

            invoiceCollection.TermDay = viewModel.TermDay;
            invoiceCollection.LastPaymentDate = viewModel.LastPaymentDate;

        }

        //[HttpGet]
        //public InvoiceCollectionBoundFormViewModel InvoiceCollectionBoundForm(Guid? id)
        //{
        //    var FormDefID = Guid.Parse("084dcb0d-4d0c-4c7f-965c-9a8613889f4b");
        //    var ObjectDefID = Guid.Parse("9d6ea7fd-a5b2-40f9-81fb-06f2dc01d3ca");
        //    var viewModel = new InvoiceCollectionBoundFormViewModel();
        //    if (id.HasValue && id.Value != Guid.Empty)
        //    {
        //        using (var objectContext = new TTObjectContext(false))
        //        {
        //            objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
        //            viewModel._InvoiceCollection = objectContext.GetObject(id.Value, ObjectDefID) as InvoiceCollection;
        //            
        //            
        //            
        //            
        //            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        //            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        //            viewModel.PayerInvoiceDocuments = objectContext.LocalQuery<PayerInvoiceDocument>().ToArray();
        //            viewModel.InvoiceTerms = objectContext.LocalQuery<InvoiceTerm>().ToArray();
        //            //viewModel.ProvizyonTipis = objectContext.LocalQuery<ProvizyonTipi>().ToArray();
        //            viewModel.TedaviTurus = objectContext.LocalQuery<TedaviTuru>().ToArray();
        //            //viewModel.TedaviTipis = objectContext.LocalQuery<TedaviTipi>().ToArray();
        //            viewModel.PayerDefinitions = objectContext.LocalQuery<PayerDefinition>().ToArray();
        //            //viewModel.TakipTipis = objectContext.LocalQuery<TakipTipi>().ToArray();
        //            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        //            objectContext.FullPartialllyLoadedObjects();
        //        }
        //    }
        //    else
        //    {
        //        var entryStateID = Guid.Parse("b43f4bed-22bf-47f3-8e66-e27bf4104bba");
        //        using (var objectContext = new TTObjectContext(false))
        //        {
        //            viewModel._InvoiceCollection = new InvoiceCollection(objectContext);
        //            viewModel._InvoiceCollection.CurrentStateDefID = entryStateID;
        //            objectContext.LoadFormObjects(FormDefID, id.Value, ObjectDefID);
        //            viewModel._InvoiceCollection.PrepareNewInvoiceCollection();
        //            //viewModel.ttgrid1GridList = objectContext.LocalQuery<InvoiceCollectionDetail>().ToArray();
        //            // viewModel._InvoiceCollection.InvoiceCollectionDetails.OfType<InvoiceCollectionDetail>().ToArray();
        //            viewModel.GridModel = new List<InvoiceCollectionDetailGridViewModel>();
        //            viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
        //            viewModel.Patients = objectContext.LocalQuery<Patient>().ToArray();
        //            viewModel.PayerInvoiceDocuments = objectContext.LocalQuery<PayerInvoiceDocument>().ToArray();
        //            viewModel.InvoiceTerms = objectContext.LocalQuery<InvoiceTerm>().ToArray();
        //            //viewModel.ProvizyonTipis = objectContext.LocalQuery<ProvizyonTipi>().ToArray();
        //            viewModel.TedaviTurus = objectContext.LocalQuery<TedaviTuru>().ToArray();
        //            //viewModel.TedaviTipis = objectContext.LocalQuery<TedaviTipi>().ToArray();
        //            viewModel.PayerDefinitions = objectContext.LocalQuery<PayerDefinition>().ToArray();
        //            //viewModel.TakipTipis = objectContext.LocalQuery<TakipTipi>().ToArray();
        //            viewModel.ResUsers = objectContext.LocalQuery<ResUser>().ToArray();
        //            objectContext.FullPartialllyLoadedObjects();
        //        }
        //    }

        //    return viewModel;
        //}

        //[HttpPost]
        //public void InvoiceCollectionBoundForm(InvoiceCollectionBoundFormViewModel viewModel)
        //{
        //    using (var objectContext = new TTObjectContext(false))
        //    {
        //        InvoiceCollection invoiceCollection = (InvoiceCollection)objectContext.AddObject(viewModel._InvoiceCollection);
        //        objectContext.Save();
        //    }
        //}

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Birlestirme)]
        public OperationStatus MergeInvoiceCollections(InvoiceCollectionMergeModel invoiceCollectionMergeModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                try
                {
                    string filterExpression = string.Empty;
                    foreach (Guid childGuid in invoiceCollectionMergeModel.ChildInvoiceCollectionsIDs)
                    {
                        filterExpression += "'" + childGuid + "',";
                    }

                    filterExpression = filterExpression.Remove(filterExpression.Length - 1, 1);
                    InvoiceCollection parentInvoiceCollection = objectContext.GetObject<InvoiceCollection>(invoiceCollectionMergeModel.ParentInvoiceCollectionID);
                    List<InvoiceCollection> chlidInvoiceCollections = objectContext.QueryObjects<InvoiceCollection>("OBJECTID IN (" + filterExpression + ")").ToList();
                    if (parentInvoiceCollection.Capacity <= chlidInvoiceCollections.SelectMany(x => x.InvoiceCollectionDetails).Count(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled))
                        parentInvoiceCollection.Capacity = null;
                    if (chlidInvoiceCollections.Count(x => x.ObjectID == parentInvoiceCollection.ObjectID) > 0)
                        chlidInvoiceCollections = chlidInvoiceCollections.Where(x => x.ObjectID != parentInvoiceCollection.ObjectID).ToList();
                    if (chlidInvoiceCollections.SelectMany(x => x.InvoiceCollectionDetails).Where(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled).Count() > 0)
                        foreach (InvoiceCollectionDetail invCollectionDetail in chlidInvoiceCollections.SelectMany(x => x.InvoiceCollectionDetails).Where(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled))
                        {
                            invCollectionDetail.ChangeInvoiceCollection(parentInvoiceCollection);
                        }
                    else
                    {
                        if (chlidInvoiceCollections.SelectMany(x => x.InvoiceCollectionDetails).Count() == 0)
                            throw new TTException(TTUtils.CultureService.GetText("M25421", "Detayı olmayan icmal için İcmal Birleştirme yapılamaz!"));

                        throw new TTException("Açık durumdan olmayan icmaller için İcmal Birleştirme yapılamaz!");
                    }

                    foreach (InvoiceCollection invCollection in chlidInvoiceCollections)
                    {
                        invCollection.ParentInvoiceCollection = parentInvoiceCollection;
                        invCollection.CurrentStateDefID = InvoiceCollection.States.Cancelled;
                    }

                    objectContext.Save();
                    return new OperationStatus()
                    { Status = true };
                }
                catch (TTException ex)
                {
                    return new OperationStatus()
                    { Status = false, ErrorMessage = ex.Message };
                }
            }
        }

        [HttpGet]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri)]
        public List<Infrastructure.Models.ComboListItem> GetEligibleInvoiceCollectionsForChange(Guid InvoiceCollectionID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                List<Infrastructure.Models.ComboListItem> comboListItems = new List<Infrastructure.Models.ComboListItem>();
                InvoiceCollection invoiceCollection = objectContext.GetObject<InvoiceCollection>(InvoiceCollectionID);
                string filterExpression = string.Empty;
                filterExpression = "PAYER = '" + invoiceCollection.Payer.ObjectID + "' AND CURRENTSTATE = STATES.OPEN AND INVOICETERM = '" + invoiceCollection.InvoiceTerm.ObjectID + "' AND OBJECTID <> '" + invoiceCollection.ObjectID + "' AND ISAUTOGENERATED <> 1 ";
                if (invoiceCollection.TedaviTuru != null)
                    filterExpression += "AND TEDAVITURU = '" + invoiceCollection.TedaviTuru.ObjectID + "'";
                foreach (InvoiceCollection invCollection in objectContext.QueryObjects<InvoiceCollection>(filterExpression))
                {
                    comboListItems.Add(new Infrastructure.Models.ComboListItem(invCollection.ObjectID, invCollection.Name)
                    { });
                }

                return comboListItems;
            }
        }

        public void HasRole(int operationID)
        {
            switch (operationID)
            {
                case 0:
                    if (!TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Kayit))
                        throw new TTException(TTUtils.CultureService.GetText("M25314", "Bu işlem için yetkiniz yoktur."));
                    break;
                case 1:
                    if (!TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Iptal))
                        throw new TTException(TTUtils.CultureService.GetText("M25314", "Bu işlem için yetkiniz yoktur."));
                    break;
                case 2:
                    if (!TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Icmalden_Cikar))
                        throw new TTException(TTUtils.CultureService.GetText("M25314", "Bu işlem için yetkiniz yoktur."));
                    break;
                case 3:
                    if (!TTUser.CurrentUser.HasRole(TTRoleNames.Fatura_Icmale_Tasi))
                        throw new TTException(TTUtils.CultureService.GetText("M25314", "Bu işlem için yetkiniz yoktur."));
                    break;
                default:
                    throw new TTException(TTUtils.CultureService.GetText("M25268", "Beklenenin dışında bir işlem tipi. Bu işlem için yetkiniz yoktur."));
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri)]
        public InvoiceCollectionDetailBatchProcessResultModel InvoiceCollectionDetailOperations(InvoiceCollectionDetailBatchProcessModel invoiceCollectionDetails)
        {
            InvoiceCollectionDetailBatchProcessResultModel batchViewModel = new InvoiceCollectionDetailBatchProcessResultModel();
            if (invoiceCollectionDetails.ObjectIDs.Count > 0 && invoiceCollectionDetails.InvoiceCollectionId.HasValue)
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    try
                    {
                        List<InvoiceCollectionDetail> invoiceCollectionDetailList = objectContext.QueryObjects<InvoiceCollectionDetail>("INVOICECOLLECTION = '" + invoiceCollectionDetails.InvoiceCollectionId + "' AND CURRENTSTATE IN (STATES.NEW,STATES.INVOICED)").Where(x => invoiceCollectionDetails.ObjectIDs.Contains(x.ObjectID)).ToList();
                        batchViewModel._OperationStatus = new OperationStatus();
                        //batchViewModel.GridModel = new List<InvoiceCollectionDetailGridViewModel>();
                        batchViewModel.CancelledInvoices = new List<InvoiceCollectionCancelGridViewModel>();

                        HasRole(invoiceCollectionDetails.OperationID);

                        switch (invoiceCollectionDetails.OperationID)
                        {
                            //Faturalandır
                            case 0:
                                {
                                    foreach (InvoiceCollectionDetail invColDetail in invoiceCollectionDetailList)
                                    {
                                        if (invColDetail.CurrentStateDefID == InvoiceCollectionDetail.States.New)
                                            invColDetail.CreatePayerInvoice(invColDetail.InvoiceCollection.Date.Value, string.Empty);
                                        else
                                            batchViewModel._OperationStatus.CustomMessage = TTUtils.CultureService.GetText("M26810", "Seçilen Detaylardan Faturalandı durumunda olanlar için Faturalama İşlemi yapılmadı.");
                                    }
                                }

                                break;
                            //Fatura iptal
                            case 1:
                                {
                                    foreach (InvoiceCollectionDetail invColDetail in invoiceCollectionDetailList)
                                    {
                                        if (invColDetail.CurrentStateDefID == InvoiceCollectionDetail.States.Invoiced)
                                            invColDetail.PayerInvoiceDocument.Cancel();
                                        else
                                            batchViewModel._OperationStatus.CustomMessage = TTUtils.CultureService.GetText("M26811", "Seçilen Detaylardan Yeni durumunda olanlar için Fatura İptal İşlemi yapılmadı.");
                                    }
                                }

                                break;
                            //İcmalden çıkar
                            case 2:
                                {
                                    foreach (InvoiceCollectionDetail invColDetail in invoiceCollectionDetailList)
                                    {
                                        if (invColDetail.CurrentStateDefID == InvoiceCollectionDetail.States.New)
                                            invColDetail.InvoiceCollection.RemoveInvoiceCollectionDetail(invColDetail, CancelledInvoiceTypeEnum.OutOfInvoiceCollection);
                                        else
                                            batchViewModel._OperationStatus.CustomMessage = TTUtils.CultureService.GetText("M27236", "Yeni durumunda olan Detaylar için İcmalden Çıkarma İşlemi yapılmadı.");
                                    }
                                }

                                break;
                            //İcmale Taşı
                            case 3:
                                if (invoiceCollectionDetails.NewInvoiceCollection.HasValue)
                                {
                                    InvoiceCollection newInvoiceCollection = objectContext.GetObject<InvoiceCollection>(invoiceCollectionDetails.NewInvoiceCollection.Value);
                                    //InvoiceCollection currentInvoiceCollection = objectContext.GetObject<InvoiceCollection>(batchProcess.InvoiceCollectionId);
                                    if (newInvoiceCollection.Capacity.HasValue)
                                    {
                                        int remainingCapacity = (newInvoiceCollection.Capacity.Value - newInvoiceCollection.InvoiceCollectionDetails.Count(x => x.CurrentStateDefID != InvoiceCollectionDetail.States.Cancelled));
                                        if (remainingCapacity < invoiceCollectionDetailList.Count)
                                            throw new TTException("Seçilen İcmalin kapasitesi yetersiz! Bu icmale en fazla " + remainingCapacity + " adet Detay taşıyabilirsiniz. ");
                                    }

                                    foreach (InvoiceCollectionDetail invColDetail in invoiceCollectionDetailList)
                                    {
                                        invColDetail.ChangeInvoiceCollection(newInvoiceCollection);
                                    }
                                }

                                break;
                        }

                        objectContext.Save();
                        //batchViewModel.GridModel = CreateDetailGridModel(objectContext, invoiceCollectionDetails.InvoiceCollectionId);
                        batchViewModel.CancelledInvoices = CreateCancelDetailGridModel(objectContext, invoiceCollectionDetails.InvoiceCollectionId);
                        batchViewModel._OperationStatus.Status = true;
                        return batchViewModel;
                    }
                    catch (TTException ex)
                    {
                        batchViewModel._OperationStatus.Status = false;
                        batchViewModel._OperationStatus.ErrorMessage = ex.Message;
                        //batchViewModel.GridModel = null;
                        batchViewModel.CancelledInvoices = null;
                        return batchViewModel;
                    }
                }
            else
                throw new TTException(TTUtils.CultureService.GetText("M25420", "Detay seçilmedi!"));
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri)]
        public List<PriceDetailResultModel> GetPricesForInvoiceCollectionDetails(PriceDetailParameterModel invoiceCollectionDetails)
        {
            if (invoiceCollectionDetails.SelectedObjectIDs.Count <= 0)
                throw new TTException(TTUtils.CultureService.GetText("M26000", "İcmal Detayı seçilmedi!"));
            string filterExpression = string.Empty;
            filterExpression = " AND SUBEPISODEPROTOCOL.INVOICECOLLECTIONDETAIL IN (";
            foreach (Guid id in invoiceCollectionDetails.SelectedObjectIDs)
            {
                filterExpression += "'" + id + "',";
            }

            filterExpression = filterExpression.Remove(filterExpression.Length - 1, 1);
            filterExpression += ")";
            filterExpression += " AND AccountPayableReceivable.Type = ";
            filterExpression += "1";
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                return AccountTransaction.GetPricesForInvoiceCollectionDetail(objectContext, filterExpression).GroupBy(x => x.InvoiceCollectionDetail.Value).Select(g => new PriceDetailResultModel { ObjectID = g.First().InvoiceCollectionDetail.Value, DrugTotal = g.Sum(d => (decimal)d.Drugtotal), MaterialTotal = g.Sum(m => (decimal)m.Materialtotal), ProcedureTotal = g.Sum(p => (decimal)p.Proceduretotal), }).ToList();
            }
        }

        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri)]
        public LoadResult CreateDetailGridModel(DataSourceLoadOptions loadOptions)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                LoadResult result = null;
                Guid invoiceCollectionID = new Guid(loadOptions.Params.invoiceCollectionID.ToString());
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["InvoiceCollectionDetail"].QueryDefs["GetByInvoiceCollection"];
                Dictionary<string, object> paramList = new Dictionary<string, object>();
                paramList.Add("INVOICECOLLECTION", invoiceCollectionID);

                result = DevexpressLoader.Load(objectContext, queryDef, loadOptions, paramList, "", "OBJECTID");

                foreach (InvoiceCollectionDetail.GetByInvoiceCollection_Class invCollectionDetail in result.GetData<InvoiceCollectionDetail.GetByInvoiceCollection_Class>())
                {
                    InvoiceCollectionDetailGridViewModel icdgvm = new InvoiceCollectionDetailGridViewModel
                    {
                        Episodeid = invCollectionDetail.Episodeid.Value,
                        OpeningDate = invCollectionDetail.OpeningDate,
                        Invoicedate = invCollectionDetail.Invoicedate,
                        Invoiceno = invCollectionDetail.Invoiceno,
                        Patientfullname = invCollectionDetail.Patientfullname.ToString(),
                        Invoiceprice = invCollectionDetail.Invoiceprice != null ? Currency.Parse(invCollectionDetail.Invoiceprice.ToString()) : new Currency(),
                        Paymentprice = invCollectionDetail.Paymentprice != null ? Currency.Parse(invCollectionDetail.Paymentprice.ToString()) : new Currency(),
                        Deduction = invCollectionDetail.Deduction != null ? Currency.Parse(invCollectionDetail.Deduction.ToString()) : new Currency(),
                        UniqueRefNo = invCollectionDetail.UniqueRefNo.HasValue ? invCollectionDetail.UniqueRefNo.Value.ToString() : string.Empty,
                        Status = invCollectionDetail.Status != null ? invCollectionDetail.Status.ToString() : string.Empty,
                        Medulatakipno = invCollectionDetail.Medulatakipno != null ? invCollectionDetail.Medulatakipno.ToString() : string.Empty,
                        Maxsepobjectid = invCollectionDetail.Maxsepobjectid != null ? Guid.Parse(invCollectionDetail.Maxsepobjectid.ToString()) : Guid.Empty,
                        ObjectID = invCollectionDetail.ObjectID
                    };

                }

                return result;
            }
        }


        [HttpPost]
        [AtlasRequiredRoles(TTRoleNames.Fatura_Icmal_Islemleri)]
        public bool UnInvoicedExistControl(Guid invoiceCollectionID)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var count = InvoiceCollectionDetail.UnInvoicedExistQuery(invoiceCollectionID);
                if (count != null && Convert.ToInt32(count[0].Counter) > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<InvoiceCollectionCancelGridViewModel> CreateCancelDetailGridModel(TTObjectContext objectContext, Guid? invoiceCollectionID)
        {
            //TODO: Mustafa Kızılkaya - Paging için grid modeli değiştirildi. O sebeple iptal grid ini gözden geçirmek gerekiyor.
            List<InvoiceCollectionCancelGridViewModel> cancelGridModel = new List<InvoiceCollectionCancelGridViewModel>();
            foreach (CancelledInvoice.GetByInvoiceCollection_Class cancelledInvoice in CancelledInvoice.GetByInvoiceCollection(objectContext, invoiceCollectionID.Value))
            {
                InvoiceCollectionCancelGridViewModel iccgvm = new InvoiceCollectionCancelGridViewModel
                {
                    Episodeid = cancelledInvoice.Episodeid,
                    OpeningDate = cancelledInvoice.OpeningDate,
                    UniqueRefNo = cancelledInvoice.UniqueRefNo.ToString(),
                    Patientfullname = cancelledInvoice.Name + " " + cancelledInvoice.Surname,
                    Invoiceprice = cancelledInvoice.GeneralTotalPrice,
                    Status = cancelledInvoice.Typetext.ToString(),
                    Invoicedate = cancelledInvoice.DocumentDate,
                    Invoiceno = cancelledInvoice.DocumentNo,
                    Date = cancelledInvoice.Date.Value,
                    User = cancelledInvoice.Username,
                    Description = cancelledInvoice.Description,
                    Medulatakipno = cancelledInvoice.Medulatakipno != null ? cancelledInvoice.Medulatakipno.ToString() : string.Empty,
                };
                cancelGridModel.Add(iccgvm);
            }

            return cancelGridModel;
        }
    }
}

namespace Core.Models
{
    public partial class InvoiceCollectionBoundFormViewModel
    {
        //public IList<InvoiceCollectionDetailGridViewModel> GridModel;
        public IList<InvoiceCollectionCancelGridViewModel> CancelledInvoices;
        public int InvoiceCollectionDetailCount
        {
            get;
            set;
        }

        public PayerTypeEnum? PayerType
        {
            get;
            set;
        }
        public List<Guid> SEPObjectIDs { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public int? TermDay { get; set; }
    }

    public class InvoiceCollectionDetailGridViewModel
    {
        public string UniqueRefNo
        {
            get;
            set;
        }

        public DateTime? OpeningDate
        {
            get;
            set;
        }

        public string Patientfullname
        {
            get;
            set;
        }

        public long? Episodeid
        {
            get;
            set;
        }

        public Currency? Invoiceprice
        {
            get;
            set;
        }

        public Currency? Paymentprice
        {
            get;
            set;
        }

        public Currency? Deduction
        {
            get;
            set;
        }

        public DateTime? Invoicedate
        {
            get;
            set;
        }

        public string Invoiceno
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public Guid? ObjectID
        {
            get;
            set;
        }

        public string Medulatakipno;
        public Guid Maxsepobjectid
        {
            get;
            set;
        }

        public Currency ProcedureTotal
        {
            get;
            set;
        }

        public Currency MaterialTotal
        {
            get;
            set;
        }

        public Currency DrugTotal
        {
            get;
            set;
        }
    }

    public class PriceDetailParameterModel
    {
        public List<Guid> SelectedObjectIDs
        {
            get;
            set;
        }
    }

    public class PriceDetailResultModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public Currency ProcedureTotal
        {
            get;
            set;
        }

        public Currency MaterialTotal
        {
            get;
            set;
        }

        public Currency DrugTotal
        {
            get;
            set;
        }
    }

    public class InvoiceCollectionCancelGridViewModel : InvoiceCollectionDetailGridViewModel
    {
        public DateTime Date
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }

    public class InvoiceCollectionDetailBatchProcessModel
    {
        //InvoiceCollectionDetailIDs
        public List<Guid?> ObjectIDs
        {
            get;
            set;
        }

        public Guid? InvoiceCollectionId
        {
            get;
            set;
        }

        public int OperationID
        {
            get;
            set;
        }

        public Guid? NewInvoiceCollection
        {
            get;
            set;
        }
    }

    public class InvoiceCollectionDetailBatchProcessResultModel
    {
        public OperationStatus _OperationStatus;
        //public IList<InvoiceCollectionDetailGridViewModel> GridModel;
        public IList<InvoiceCollectionCancelGridViewModel> CancelledInvoices;
    }

    public class InvoiceCollectionMergeModel
    {
        public Guid ParentInvoiceCollectionID
        {
            get;
            set;
        }

        public List<Guid> ChildInvoiceCollectionsIDs
        {
            get;
            set;
        }
    }
}