//$84C912B2
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class DrugOrderTransactionServiceController : Controller
    {
        public class GetRestDose_Input
        {
            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }
        }

        [HttpPost]
        public double GetRestDose(GetRestDose_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                var ret = DrugOrderTransaction.GetRestDose(input.drugOrder);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetRestTransaction_Input
        {
            public TTObjectClasses.Material material
            {
                get;
                set;
            }

            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.List<TTObjectClasses.DrugOrderTransaction> GetRestTransaction(GetRestTransaction_Input input)
        {
            using (var context = new TTObjectContext(false))
            {
                if (input.material != null)
                    input.material = (TTObjectClasses.Material)context.AddObject(input.material);
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)context.AddObject(input.episode);
                var ret = DrugOrderTransaction.GetRestTransaction(context, input.material, input.episode);
                context.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetEmployableRestDose_Input
        {
            public TTObjectClasses.DrugOrder drugOrder
            {
                get;
                set;
            }
        }

        [HttpPost]
        public double GetEmployableRestDose(GetEmployableRestDose_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.drugOrder != null)
                    input.drugOrder = (TTObjectClasses.DrugOrder)objectContext.AddObject(input.drugOrder);
                var ret = DrugOrderTransaction.GetEmployableRestDose(input.drugOrder);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetPatientRestDose_Input
        {
            public TTObjectClasses.Material material
            {
                get;
                set;
            }

            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.Dictionary<object, double> GetPatientRestDose(GetPatientRestDose_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.material != null)
                    input.material = (TTObjectClasses.Material)objectContext.AddObject(input.material);
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = DrugOrderTransaction.GetPatientRestDose(input.material, input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetDrugOrderTransactions_Input
        {
            public TTObjectClasses.Material material
            {
                get;
                set;
            }

            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.Dictionary<object, double> GetDrugOrderTransactions(GetDrugOrderTransactions_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.material != null)
                    input.material = (TTObjectClasses.Material)objectContext.AddObject(input.material);
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = DrugOrderTransaction.GetDrugOrderTransactions(input.material, input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetReturnableDrugOrderTransactions_Input
        {
            public TTObjectClasses.Episode episode
            {
                get;
                set;
            }
        }

        [HttpPost]
        public System.Collections.Generic.Dictionary<TTObjectClasses.DrugOrderTransaction, double> GetReturnableDrugOrderTransactions(GetReturnableDrugOrderTransactions_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                if (input.episode != null)
                    input.episode = (TTObjectClasses.Episode)objectContext.AddObject(input.episode);
                var ret = DrugOrderTransaction.GetReturnableDrugOrderTransactions(input.episode);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        /*public class GetDrugOrderTransactions_Input
        {
            public string DRUGORDEREPISODE { get; set; }
            public string DRUGORDERMATERIAL { get; set; }
        }
        [HttpPost]
        public BindingList<DrugOrderTransaction> GetDrugOrderTransactions([ModelBinder(typeof(NebulaModelBinder))]GetDrugOrderTransactions_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderTransaction.GetDrugOrderTransactions(objectContext, input.DRUGORDEREPISODE, input.DRUGORDERMATERIAL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }*/
        public class GetDrugOrderTransactionByEpisode_Input
        {
            public Guid DRUGORDEREPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderTransaction> GetDrugOrderTransactionByEpisode(GetDrugOrderTransactionByEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderTransaction.GetDrugOrderTransactionByEpisode(objectContext, input.DRUGORDEREPISODE);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOuttableDrugOrderTransactions_Input
        {
            public string DRUGORDEREPISODE
            {
                get;
                set;
            }

            public string DRUGORDERMATERIAL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> GetOuttableDrugOrderTransactions(GetOuttableDrugOrderTransactions_Input input)
        {
            var ret = DrugOrderTransaction.GetOuttableDrugOrderTransactions(input.DRUGORDEREPISODE, input.DRUGORDERMATERIAL);
            return ret;
        }

        public class GetDrugOrderTransactionByEpisodeRQ_Input
        {
            public Guid DRUGORDEREPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> GetDrugOrderTransactionByEpisodeRQ(GetDrugOrderTransactionByEpisodeRQ_Input input)
        {
            var ret = DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ(input.DRUGORDEREPISODE);
            return ret;
        }

        public class GetUsableTransactions_Input
        {
            public string DRUGORDEREPISODE
            {
                get;
                set;
            }

            public string DRUGORDERMATERIAL
            {
                get;
                set;
            }
        }

        [HttpPost]
        public BindingList<DrugOrderTransaction> GetUsableTransactions(GetUsableTransactions_Input input)
        {
            using (var objectContext = new TTObjectContext(true))
            {
                var ret = DrugOrderTransaction.GetUsableTransactions(objectContext, input.DRUGORDEREPISODE, input.DRUGORDERMATERIAL);
                objectContext.FullPartialllyLoadedObjects();
                return ret;
            }
        }

        public class GetOuttableDrugOrderTrxEpisode_Input
        {
            public string DRUGORDEREPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.NoAccess)]
        public BindingList<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class> GetOuttableDrugOrderTrxEpisode(GetOuttableDrugOrderTrxEpisode_Input input)
        {
            var ret = DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode(input.DRUGORDEREPISODE);
            return ret;
        }

        public class GetOuttableDrugReturnActionDetail_Input
        {
            public string DRUGORDEREPISODE
            {
                get;
                set;
            }
        }

        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Eczane_Ilac_Iade_Yeni)]
        public List<DrugReturnActionDetail> GetOuttableDrugReturnActionDetail(GetOuttableDrugOrderTrxEpisode_Input input)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<DrugReturnActionDetail> drugReturnActionDetails = new List<DrugReturnActionDetail>();
                BindingList<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> allDrugOrderTransaction = DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ(new Guid(input.DRUGORDEREPISODE));
                foreach (DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class drugOrderTransaction in allDrugOrderTransaction)
                {
                    DrugDefinition drugDefinition = (DrugDefinition)objectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
                    DrugOrderTransaction trx = (DrugOrderTransaction)objectContext.GetObject((Guid)drugOrderTransaction.ObjectID, "DRUGORDERTRANSACTION");
                    DrugReturnActionDetail drugReturnActionDetail = new DrugReturnActionDetail(objectContext);
                    DrugOrder order = (DrugOrder)objectContext.GetObject((Guid)drugOrderTransaction.Drugorder, "DRUGORDER");
                    bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                    if (drugType)
                    {
                        drugReturnActionDetail.DrugOrderTransaction = trx;
                        drugReturnActionDetail.Amount = DrugOrderTransaction.GetRestDose(order);
                        drugReturnActionDetail.SendAmount = DrugOrderTransaction.GetRestDose(order);
                        drugReturnActionDetails.Add(drugReturnActionDetail);

                    }
                    else
                    {
                        double resVolume = DrugOrderTransaction.GetRestDose(order);
                        double resAmount = 0;
                        if (resVolume > 0)
                        {
                            resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                            if (resAmount > 0)
                            {
                                drugReturnActionDetail.DrugOrderTransaction = trx;
                                drugReturnActionDetail.Amount = resAmount;
                                drugReturnActionDetail.SendAmount = resAmount;
                                drugReturnActionDetails.Add(drugReturnActionDetail);
                            }

                        }

                    }
                }

                /* BindingList<DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class> restTrxs = DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode(input.DRUGORDEREPISODE);
                 foreach (DrugOrderTransaction.GetOuttableDrugOrderTrxEpisode_Class trx in restTrxs)
                 {
                     DrugDefinition drug = (DrugDefinition)objectContext.GetObject((Guid)trx.Material, typeof (DrugDefinition));
                     bool drugType = DrugOrder.GetDrugUsedType(drug);
                     if (drugType)
                     {
                         DrugOrderTransaction inTrx = (DrugOrderTransaction)objectContext.GetObject((Guid)trx.ObjectID, typeof (DrugOrderTransaction));
                         DrugReturnActionDetail drugReturnActionDetail = new DrugReturnActionDetail(objectContext);
                         drugReturnActionDetail.DrugOrderTransaction = inTrx;
                         drugReturnActionDetail.Amount = Convert.ToDouble(trx.Restamount);
                         drugReturnActionDetail.SendAmount = Convert.ToDouble(trx.Restamount);
                         drugReturnActionDetails.Add(drugReturnActionDetail);
                     }
                     else
                     {
                         if (Convert.ToDouble(trx.Restamount) > drug.Volume)
                         {

                             DrugOrderTransaction inTrx = (DrugOrderTransaction)objectContext.GetObject((Guid)trx.ObjectID, typeof (DrugOrderTransaction));
                             DrugReturnActionDetail drugReturnActionDetail = new DrugReturnActionDetail(objectContext);
                             drugReturnActionDetail.DrugOrderTransaction = inTrx;
                             drugReturnActionDetail.Amount = 1;
                             drugReturnActionDetail.SendAmount = 1;
                             drugReturnActionDetails.Add(drugReturnActionDetail);
                         }
                     }
                 }*/

                objectContext.FullPartialllyLoadedObjects();
                return drugReturnActionDetails;
            }
        }
    }
}