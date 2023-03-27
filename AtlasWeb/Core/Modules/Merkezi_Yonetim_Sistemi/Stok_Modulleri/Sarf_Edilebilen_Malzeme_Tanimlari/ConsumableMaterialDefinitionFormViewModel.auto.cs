//$D77605A0
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Helpers;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TTDefinitionManagement;
using Core.Models.DataSourceOptionsParser;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class ConsumableMaterialDefinitionServiceController : Controller
    {




        [HttpPost]
        public LoadResult GetGMDNCodes([FromBody] DataSourceLoadOptions loadOptions)
        {
            LoadResult result = null;
            using (var objectContext = new TTObjectContext(false))
            {
                TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].QueryDefs["GetGMDNDefinitionsReportQuery"];

                var paramList = new Dictionary<string, object>();
                var multipleQuery = new List<MultipleQueryDto>
                {
                    new MultipleQueryDto() { QueryDef = queryDef, ParamList = paramList, Injection = string.Empty }
                };
                result = DevexpressLoader.Load(objectContext, multipleQuery, loadOptions);
            }
            return result;
        }


        [HttpGet]
        public ConsumableMaterialDefinitionFormViewModel ConsumableMaterialDefinitionForm(Guid? id)
        {
            var formDefID = Guid.Parse("16164c1a-4a25-4006-b0b5-22416975c4b5");
            var objectDefID = Guid.Parse("58d34696-808e-47de-87e0-1f001d0928a7");
            var viewModel = new ConsumableMaterialDefinitionFormViewModel();
            if (id.HasValue && id.Value != Guid.Empty)
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ConsumableMaterialDefinition = objectContext.GetObject(id.Value, objectDefID) as ConsumableMaterialDefinition;
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ConsumableMaterialDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ConsumableMaterialDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel?._ConsumableMaterialDefinition);
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel?._ConsumableMaterialDefinition);
                    objectContext.LoadFormObjects(formDefID, id.Value, objectDefID);
                    ContextToViewModel(viewModel, objectContext);

                    PricingDetailDefinition pricingDetailDefinition = GetMaterialPriceDetails(viewModel._ConsumableMaterialDefinition);
                    MaterialPriceDetail materialPriceDetail = new MaterialPriceDetail();
                    if (pricingDetailDefinition != null)
                    {
                        if (pricingDetailDefinition.Price != null)
                        {
                            materialPriceDetail.MaterialPrice = pricingDetailDefinition.Price.Value;
                        }
                        else
                            materialPriceDetail.MaterialPrice = 0;
                    }
                    else
                        materialPriceDetail.MaterialPrice = 0;

                    viewModel.MaterialPriceDetail = materialPriceDetail;


                    var materialDocumentations = GetMaterialDocumentationDetails(viewModel._ConsumableMaterialDefinition);
                    if (materialDocumentations.Count > 0)
                    {
                        viewModel.MaterialDocumentations = materialDocumentations;
                    }

                    viewModel.RevenueSubAccountCodeDef = viewModel._ConsumableMaterialDefinition.RevenueSubAccountCode;
                    viewModel.MaterialTreeDefList = GetMaterialTree();
                    PreScript_ConsumableMaterialDefinitionForm(viewModel, viewModel._ConsumableMaterialDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            else
            {
                using (var objectContext = new TTObjectContext(false))
                {
                    viewModel._ConsumableMaterialDefinition = new ConsumableMaterialDefinition(objectContext);
                    viewModel.MaterialSpecialtysGridList = new TTObjectClasses.MaterialSpecialty[] { };
                    viewModel.MaterialVatRatesGridList = new TTObjectClasses.MaterialVatRate[] { };
                    viewModel.MaterialProductLevelsGridList = new TTObjectClasses.MaterialProductLevel[] { };
                    viewModel.ReadOnly = TTDefinitionManagement.TTFormDef.CheckFormSecurity(viewModel._ConsumableMaterialDefinition, formDefID);
                    viewModel.ReadOnlyFields = TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ConsumableMaterialDefinition, formDefID);
                    viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(viewModel._ConsumableMaterialDefinition);
                    viewModel.grdConsumableMaterialProceduresGridList = new TTObjectClasses.MaterialProcedures[] { };
                    viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(viewModel._ConsumableMaterialDefinition);
                    PreScript_ConsumableMaterialDefinitionForm(viewModel, viewModel._ConsumableMaterialDefinition, objectContext);
                    objectContext.FullPartialllyLoadedObjects();
                }
            }
            return viewModel;
        }

        [HttpPost]
        public BaseViewModel ConsumableMaterialDefinitionForm(ConsumableMaterialDefinitionFormViewModel viewModel)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                return ConsumableMaterialDefinitionFormInternal(viewModel, objectContext);
            }
        }

        internal BaseViewModel ConsumableMaterialDefinitionFormInternal(ConsumableMaterialDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            var retViewModel = new BaseViewModel();
            var formDefID = Guid.Parse("16164c1a-4a25-4006-b0b5-22416975c4b5");
            objectContext.AddToRawObjectList(viewModel.MaterialSpecialtyDefs);
            objectContext.AddToRawObjectList(viewModel.MaterialPurposeDefinitions);
            objectContext.AddToRawObjectList(viewModel.MaterialPlaceOfUseDefs);
            objectContext.AddToRawObjectList(viewModel.SpecialityDefinitions);
            objectContext.AddToRawObjectList(viewModel.Producers);
            objectContext.AddToRawObjectList(viewModel.GMDNDefinitions);
            objectContext.AddToRawObjectList(viewModel.ProductDefinitions);
            objectContext.AddToRawObjectList(viewModel.StockCards);
            objectContext.AddToRawObjectList(viewModel.DistributionTypeDefinitions);
            objectContext.AddToRawObjectList(viewModel.MaterialTreeDefinitions);
            objectContext.AddToRawObjectList(viewModel.MaterialSpecialtysGridList);
            //objectContext.AddToRawObjectList(viewModel.MaterialVatRatesGridList);
            objectContext.AddToRawObjectList(viewModel.MaterialProductLevelsGridList);
            objectContext.AddToRawObjectList(viewModel._ConsumableMaterialDefinition);
            objectContext.AddToRawObjectList(viewModel.grdConsumableMaterialProceduresGridList);
            objectContext.AddToRawObjectList(viewModel.ProcedureDefinitions);
            objectContext.ProcessRawObjects();

            var consumableMaterialDefinition = (ConsumableMaterialDefinition)objectContext.GetLoadedObject(viewModel._ConsumableMaterialDefinition.ObjectID);
            TTDefinitionManagement.TTFormDef.CheckFormSecurity(consumableMaterialDefinition, formDefID, true);
            TTDefinitionManagement.TTFormDef.CheckFieldSecurity(viewModel._ConsumableMaterialDefinition, formDefID);

            if (viewModel.MaterialSpecialtysGridList != null)
            {
                foreach (var item in viewModel.MaterialSpecialtysGridList)
                {
                    var materialSpecialtysImported = (MaterialSpecialty)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)materialSpecialtysImported).IsDeleted)
                        continue;
                    materialSpecialtysImported.Material = consumableMaterialDefinition;
                }
            }

            //if (viewModel.MaterialVatRatesGridList != null)
            //{
            //    foreach (var item in viewModel.MaterialVatRatesGridList)
            //    {
            //        var materialVatRatesImported = (MaterialVatRate)objectContext.GetLoadedObject(item.ObjectID);
            //        if (((ITTObject)materialVatRatesImported).IsDeleted)
            //            continue;
            //        materialVatRatesImported.Material = consumableMaterialDefinition;
            //    }
            //}

            if (viewModel.MaterialProductLevelsGridList != null)
            {
                foreach (var item in viewModel.MaterialProductLevelsGridList)
                {
                    var materialProductLevelsImported = (MaterialProductLevel)objectContext.GetLoadedObject(item.ObjectID);
                    if (((ITTObject)materialProductLevelsImported).IsDeleted)
                        continue;
                    materialProductLevelsImported.Material = consumableMaterialDefinition;
                }
            }
            if (viewModel.grdConsumableMaterialProceduresGridList != null)
            {
                foreach (var item in viewModel.grdConsumableMaterialProceduresGridList)
                {
                    var materialProceduresImported = (MaterialProcedures)objectContext.GetLoadedObject(item.ObjectID);
                    if (materialProceduresImported == null || ((ITTObject)materialProceduresImported).IsDeleted)
                        continue;
                    materialProceduresImported.Material = consumableMaterialDefinition;
                }
            }

            if (viewModel._ConsumableMaterialDefinition.MaxPatientAge != null)
            {
                consumableMaterialDefinition.MaxPatientAge = viewModel._ConsumableMaterialDefinition.MaxPatientAge;
            }

            if (viewModel._ConsumableMaterialDefinition.MinPatientAge != null)
            {
                consumableMaterialDefinition.MinPatientAge = viewModel._ConsumableMaterialDefinition.MinPatientAge;
            }

            if (viewModel._ConsumableMaterialDefinition.MaterialPatientType != null)
            {
                consumableMaterialDefinition.MaterialPatientType = viewModel._ConsumableMaterialDefinition.MaterialPatientType;
            }

            if (viewModel._ConsumableMaterialDefinition.SEX != null)
            {
                consumableMaterialDefinition.SEX = viewModel._ConsumableMaterialDefinition.SEX;
            }

            if (viewModel._ConsumableMaterialDefinition.OrderRPTDay != null)
            {
                consumableMaterialDefinition.OrderRPTDay = viewModel._ConsumableMaterialDefinition.OrderRPTDay;
            }


            if (viewModel._ConsumableMaterialDefinition.PatientMaxDayOut != null)
            {
                consumableMaterialDefinition.PatientMaxDayOut = viewModel._ConsumableMaterialDefinition.PatientMaxDayOut;
            }

            if (viewModel._ConsumableMaterialDefinition.OperatingShare != null)
            {
                consumableMaterialDefinition.OperatingShare = viewModel._ConsumableMaterialDefinition.OperatingShare;
            }
            if (viewModel._ConsumableMaterialDefinition.TresuryShare != null)
            {
                consumableMaterialDefinition.TresuryShare = viewModel._ConsumableMaterialDefinition.TresuryShare;
            }
            if (viewModel._ConsumableMaterialDefinition.ShcekShare != null)
            {
                consumableMaterialDefinition.ShcekShare = viewModel._ConsumableMaterialDefinition.ShcekShare;
            }
            if (viewModel._ConsumableMaterialDefinition.IsmId != null)
            {
                consumableMaterialDefinition.IsmId = viewModel._ConsumableMaterialDefinition.IsmId;
            }

            if (viewModel._ConsumableMaterialDefinition.EstimatedTimeOfCheck != null)
            {
                consumableMaterialDefinition.EstimatedTimeOfCheck = viewModel._ConsumableMaterialDefinition.EstimatedTimeOfCheck;
            }
            if (viewModel._ConsumableMaterialDefinition.MaximumEstimatedTimeOfCheck != null)
            {
                consumableMaterialDefinition.MaximumEstimatedTimeOfCheck = viewModel._ConsumableMaterialDefinition.MaximumEstimatedTimeOfCheck;
            }


            List<MaterialSpecialty> consumableMaterialSpList = objectContext.QueryObjects<MaterialSpecialty>("MATERIAL = " + TTConnectionManager.ConnectionManager.GuidToString(consumableMaterialDefinition.ObjectID)).ToList();
            foreach (MaterialSpecialty item in consumableMaterialSpList)
            {
                ((ITTObject)item).Delete();
            }


            if (viewModel.MaterialSpecialtysList.Length > 0)
            {
                foreach (var item in viewModel.MaterialSpecialtysList)
                {
                    MaterialSpecialty materialSpecialty = new MaterialSpecialty(objectContext);
                    materialSpecialty.Material = objectContext.GetObject<ConsumableMaterialDefinition>(viewModel._ConsumableMaterialDefinition.ObjectID);
                    materialSpecialty.MaterialSpecialtyDefinition = objectContext.GetObject<MaterialSpecialtyDef>(item);
                }
            }

            IBindingList equvalentMats = objectContext.QueryObjects(typeof(EquivalentConsMaterial).Name, "CONSUMABLEMATERIALDEFINITION =" + TTConnectionManager.ConnectionManager.GuidToString(consumableMaterialDefinition.ObjectID));
            foreach (EquivalentConsMaterial item in equvalentMats)
            {
                ((ITTObject)item).Delete();
            }

            if (viewModel.ConsMaterialEquvalentList.Length > 0)
            {
                foreach (var item in viewModel.ConsMaterialEquvalentList)
                {
                    EquivalentConsMaterial equivalent = new EquivalentConsMaterial(objectContext);
                    equivalent.ConsumableMaterialDefinition = objectContext.GetObject<ConsumableMaterialDefinition>(viewModel._ConsumableMaterialDefinition.ObjectID);
                    equivalent.EquivalentMaterial = objectContext.GetObject<ConsumableMaterialDefinition>(item);
                }
            }

            //foreach (MaterialVatRate vatRate in viewModel._ConsumableMaterialDefinition.MaterialVatRates.Select(""))
            //{
            //    DateTime st = (DateTime)vatRate.StartDate;
            //    DateTime end = (DateTime)vatRate.EndDate;
            //    if (st < DateTime.Now && end > DateTime.Now)
            //    {
            //        if (vatRate.VatRate != (long)viewModel.MaterialVatRateIn)
            //        {
            //            MaterialVatRate newMaterialVat = new MaterialVatRate(objectContext);
            //            newMaterialVat.StartDate = DateTime.Now;
            //            newMaterialVat.VatRate = (long)viewModel.MaterialVatRateIn;
            //            newMaterialVat.EndDate = DateTime.Parse("13/03/2050");
            //            vatRate.EndDate = DateTime.Now.AddDays(-1);
            //        }
            //    }
            //}

            if (viewModel.MaterialVatRatesGridList.Length == 1)
            {
                foreach (var item in viewModel.MaterialVatRatesGridList)
                {
                    List<MaterialVatRate> materialVatRates = consumableMaterialDefinition.MaterialVatRates.Select(string.Empty, "ENDDATE").ToList();
                    if (materialVatRates.Count > 0)
                    {
                        MaterialVatRate materialVatRate = objectContext.GetObject<MaterialVatRate>(materialVatRates[0].ObjectID);
                        if (materialVatRate.VatRate != item.VatRate)
                        {
                            materialVatRate.EndDate = Common.RecTime().AddDays(-1);

                            MaterialVatRate newMaterialVatRate = new MaterialVatRate(objectContext);
                            newMaterialVatRate.StartDate = Common.RecTime();
                            newMaterialVatRate.EndDate = Common.RecTime().AddYears(100);
                            newMaterialVatRate.VatRate = item.VatRate;
                            consumableMaterialDefinition.MaterialVatRates.Add(materialVatRate);
                        }

                    }
                    else
                    {
                        MaterialVatRate materialVatRate = new MaterialVatRate(objectContext);
                        materialVatRate.StartDate = Common.RecTime();
                        materialVatRate.EndDate = Common.RecTime().AddYears(100);
                        materialVatRate.VatRate = item.VatRate;
                        consumableMaterialDefinition.MaterialVatRates.Add(materialVatRate);
                    }
                }
            }

            List<MaterialProcedures> consumableMaterialProdureList = objectContext.QueryObjects<MaterialProcedures>("MATERIAL = " + TTConnectionManager.ConnectionManager.GuidToString(consumableMaterialDefinition.ObjectID)).ToList();
            foreach (MaterialProcedures item in consumableMaterialProdureList)
            {
                ((ITTObject)item).Delete();
            }

            if (viewModel.ProdureDefs.Length > 0)
            {
                foreach (var item in viewModel.ProdureDefs)
                {
                    MaterialProcedures materialProcedures = new MaterialProcedures(objectContext);
                    materialProcedures.Material = objectContext.GetObject<ConsumableMaterialDefinition>(viewModel._ConsumableMaterialDefinition.ObjectID);
                    materialProcedures.ProcedureDefinition = objectContext.GetObject<ProcedureDefinition>(item);
                }
            }


            if (viewModel.MaterialNewPrice != 0 && viewModel._ConsumableMaterialDefinition.SUTAppendix != null)
            {
                DateTime nowTime = Common.RecTime();
                IBindingList pricingDetailDefinition = objectContext.QueryObjects("PRICINGDETAILDEFINITION", "PRICINGLIST = 'bfe21eaf-3f71-4bbc-990b-066c5dfbd259' AND EXTERNALCODE='" + viewModel._ConsumableMaterialDefinition.SUTAppendix
                                      + "' AND DATESTART < " + TTUtils.Globals.CreateNQLToDateParameter(nowTime) + " AND DATEEND > " + TTUtils.Globals.CreateNQLToDateParameter(nowTime));

                if (pricingDetailDefinition.Count == 0)
                {
                    PricingDetailDefinition pdd = new PricingDetailDefinition(objectContext);
                    pdd.DateStart = nowTime.AddMonths(-3);//TAsk 65888 buna göre yapýldý....
                    pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                    pdd.Description = viewModel._ConsumableMaterialDefinition.Name;
                    pdd.CurrencyType = (CurrencyTypeDefinition)objectContext.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                    pdd.PricingList = (PricingListDefinition)objectContext.GetObject(new Guid("bfe21eaf-3f71-4bbc-990b-066c5dfbd259"), typeof(PricingListDefinition).Name);
                    pdd.PricingListGroup = (PricingListGroupDefinition)objectContext.GetObject(new Guid("39d65056-3d97-4b85-94d7-0280c806391c"), typeof(PricingListGroupDefinition).Name);
                    pdd.Price = viewModel.MaterialNewPrice;
                    pdd.ExternalCode = viewModel._ConsumableMaterialDefinition.SUTAppendix.ToString();


                    MaterialPrice materialPrice = new MaterialPrice(objectContext);
                    materialPrice.Material = viewModel._ConsumableMaterialDefinition;
                    materialPrice.PricingDetail = pdd;
                }
                else
                {
                    foreach (PricingDetailDefinition pDet in pricingDetailDefinition)
                    {
                        if (pDet.Price != viewModel.MaterialNewPrice)
                        {
                            PricingDetailDefinition pdd = new PricingDetailDefinition(objectContext);
                            pdd.DateStart = nowTime;
                            pdd.DateEnd = new DateTime(2100, 1, 1, 0, 0, 0);
                            pdd.Description = viewModel._ConsumableMaterialDefinition.Name;
                            pdd.CurrencyType = (CurrencyTypeDefinition)objectContext.GetObject(new Guid("e3a4f2d5-4f74-406c-8258-37316ea8e9d1"), typeof(CurrencyTypeDefinition).Name);
                            pdd.PricingList = (PricingListDefinition)objectContext.GetObject(new Guid("bfe21eaf-3f71-4bbc-990b-066c5dfbd259"), typeof(PricingListDefinition).Name);
                            pdd.PricingListGroup = (PricingListGroupDefinition)objectContext.GetObject(new Guid("39d65056-3d97-4b85-94d7-0280c806391c"), typeof(PricingListGroupDefinition).Name);
                            pdd.Price = viewModel.MaterialNewPrice;
                            pdd.ExternalCode = viewModel._ConsumableMaterialDefinition.SUTAppendix.ToString();

                            DateTime nD = ((DateTime)pdd.DateStart).AddDays(-1);
                            pDet.DateEnd = new DateTime(nD.Year, nD.Month, nD.Day, 23, 59, 59);

                            MaterialPrice materialPrice = new MaterialPrice(objectContext);
                            materialPrice.Material = viewModel._ConsumableMaterialDefinition;
                            materialPrice.PricingDetail = pdd;
                        }
                    }
                }
            }





            var transDef = consumableMaterialDefinition.TransDef;
            PostScript_ConsumableMaterialDefinitionForm(viewModel, consumableMaterialDefinition, transDef, objectContext);
            retViewModel.UpdatedObjects = objectContext.GetDirtyObjects();
            objectContext.Save();
            viewModel.OutgoingTransitions = TTDefinitionManagement.TTFormDef.GetOutgouingTransitions(consumableMaterialDefinition);
            viewModel.CurrentStateReports = TTDefinitionManagement.TTFormDef.GetStateReports(consumableMaterialDefinition);
            AfterContextSaveScript_ConsumableMaterialDefinitionForm(viewModel, consumableMaterialDefinition, transDef, objectContext);
            retViewModel.OutgoingTransitions = viewModel.OutgoingTransitions;
            retViewModel.CurrentStateReports = viewModel.CurrentStateReports;
            objectContext.FullPartialllyLoadedObjects();
            return retViewModel;
        }


        partial void PreScript_ConsumableMaterialDefinitionForm(ConsumableMaterialDefinitionFormViewModel viewModel, ConsumableMaterialDefinition consumableMaterialDefinition, TTObjectContext objectContext);
        partial void PostScript_ConsumableMaterialDefinitionForm(ConsumableMaterialDefinitionFormViewModel viewModel, ConsumableMaterialDefinition consumableMaterialDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);
        partial void AfterContextSaveScript_ConsumableMaterialDefinitionForm(ConsumableMaterialDefinitionFormViewModel viewModel, ConsumableMaterialDefinition consumableMaterialDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext);

        void ContextToViewModel(ConsumableMaterialDefinitionFormViewModel viewModel, TTObjectContext objectContext)
        {
            viewModel.MaterialSpecialtysGridList = viewModel._ConsumableMaterialDefinition.MaterialSpecialtys.OfType<MaterialSpecialty>().ToArray();
            viewModel.MaterialVatRatesGridList = viewModel._ConsumableMaterialDefinition.MaterialVatRates.OfType<MaterialVatRate>().ToArray();
            viewModel.MaterialProductLevelsGridList = viewModel._ConsumableMaterialDefinition.MaterialProductLevels.OfType<MaterialProductLevel>().ToArray();
            viewModel.MaterialSpecialtyDefs = objectContext.LocalQuery<MaterialSpecialtyDef>().ToArray();
            viewModel.MaterialPurposeDefinitions = objectContext.LocalQuery<MaterialPurposeDefinition>().ToArray();
            viewModel.MaterialPlaceOfUseDefs = objectContext.LocalQuery<MaterialPlaceOfUseDef>().ToArray();
            viewModel.ConsumableMaterialDefinitions = objectContext.LocalQuery<ConsumableMaterialDefinition>().ToArray();
            viewModel.SpecialityDefinitions = objectContext.LocalQuery<SpecialityDefinition>().ToArray();
            viewModel.Producers = objectContext.LocalQuery<Producer>().ToArray();
            viewModel.GMDNDefinitions = objectContext.LocalQuery<GMDNDefinition>().ToArray();
            viewModel.ProductDefinitions = objectContext.LocalQuery<ProductDefinition>().ToArray();
            viewModel.StockCards = objectContext.LocalQuery<StockCard>().ToArray();
            viewModel.grdConsumableMaterialProceduresGridList = viewModel._ConsumableMaterialDefinition.MaterialProcedures.OfType<MaterialProcedures>().ToArray();
            viewModel.DistributionTypeDefinitions = objectContext.LocalQuery<DistributionTypeDefinition>().ToArray();
            viewModel.MaterialTreeDefinitions = objectContext.LocalQuery<MaterialTreeDefinition>().ToArray();
            viewModel.ProcedureDefinitions = objectContext.LocalQuery<ProcedureDefinition>().ToArray();
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialSpecialtyList", viewModel.MaterialSpecialtyDefs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialPurposeList", viewModel.MaterialPurposeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialPlaceOfUseList", viewModel.MaterialPlaceOfUseDefs);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "SpecialityListDefinition", viewModel.SpecialityDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProducerListDefinition", viewModel.Producers);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "GMDNCodeListDefinition", viewModel.GMDNDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProductList", viewModel.ProductDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "StockCardList", viewModel.StockCards);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "DistributionTypeList", viewModel.DistributionTypeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "MaterialTreeList", viewModel.MaterialTreeDefinitions);
            ListDefDisplayExpressionsHelper.AddToListDefDisplayExpressions(objectContext, viewModel.ListDefDisplayExpressions, "ProcedureListDefinition", viewModel.ProcedureDefinitions);
        }
    }
}


namespace Core.Models
{
    public partial class ConsumableMaterialDefinitionFormViewModel
    {
        public Guid[] ProdureDefs { get; set; }
        public TTObjectClasses.ConsumableMaterialDefinition _ConsumableMaterialDefinition
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialSpecialty[] MaterialSpecialtysGridList
        {
            get;
            set;
        }
        public TTObjectClasses.MaterialProcedures[] grdConsumableMaterialProceduresGridList
        {
            get;
            set;
        }
        public TTObjectClasses.MaterialVatRate[] MaterialVatRatesGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialProductLevel[] MaterialProductLevelsGridList
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialSpecialtyDef[] MaterialSpecialtyDefs
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialPurposeDefinition[] MaterialPurposeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialPlaceOfUseDef[] MaterialPlaceOfUseDefs
        {
            get;
            set;
        }

        public TTObjectClasses.ConsumableMaterialDefinition[] ConsumableMaterialDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.SpecialityDefinition[] SpecialityDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.Producer[] Producers
        {
            get;
            set;
        }

        public TTObjectClasses.GMDNDefinition[] GMDNDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.ProductDefinition[] ProductDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.StockCard[] StockCards
        {
            get;
            set;
        }

        public TTObjectClasses.DistributionTypeDefinition[] DistributionTypeDefinitions
        {
            get;
            set;
        }

        public TTObjectClasses.MaterialTreeDefinition[] MaterialTreeDefinitions
        {
            get;
            set;
        }
        public TTObjectClasses.ProcedureDefinition[] ProcedureDefinitions
        {
            get;
            set;
        }

        public Guid[] MaterialSpecialtysList { get; set; }

        public Guid[] ConsMaterialEquvalentList { get; set; }

        public double MaterialVatRateIn { get; set; }

        public double MaterialNewPrice { get; set; }

    }
}
