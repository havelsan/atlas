
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class DrugOrderTransaction : TTObject
    {
        public partial class GetDrugOrderTransactionByEpisodeRQ_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static double GetRestDose(DrugOrder drugOrder)
        {
            double totalUsedDose = 0;
            double totalUsedAmount = 0;
            double totalOrderAmount = 0;
            double totalOrderDose = 0;
            double restDose = 0;
            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);

            BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> outtableTransactions = DrugOrderTransaction.GetOuttableDrugOrderTransactions(drugOrder.Episode.ObjectID.ToString(), drugOrder.Material.ObjectID.ToString());

            foreach(DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class drugOrderTransaction in outtableTransactions)
                restDose = restDose + Convert.ToDouble(drugOrderTransaction.Restamount);

           /* foreach (DrugOrderTransaction drugOrderTransaction in drugOrder.DrugOrderTransactions)
            {
                if(drugOrderTransaction.InOut == 2)
                {
                    if (drugOrderTransaction.Volume == null)
                    {
                        totalUsedDose += 0;
                        totalUsedAmount += (double)drugOrderTransaction.Amount;
                    }
                    else
                    {
                        totalUsedDose += (double)drugOrderTransaction.Volume;
                        totalUsedAmount += (double)drugOrderTransaction.Amount;
                    }
                }
                else
                {
                    if (drugOrderTransaction.Volume == null)
                    {
                        totalUsedDose += 0;
                        totalUsedAmount += (double)drugOrderTransaction.Amount;
                    }
                    else
                    {
                        totalOrderAmount += (double)drugOrderTransaction.Amount;
                        totalOrderDose += (double)drugOrderTransaction.Volume;
                    }
                }
                
                if (drugType)
                {
                    restDose = totalOrderAmount - totalUsedAmount ;
                }
                else
                {
                    restDose = totalOrderDose - totalUsedDose ;
                }
            }*/
            return restDose;
        }

        public static List<DrugOrderTransaction> GetRestTransaction(TTObjectContext context, Material material, Episode episode)
        {
            List<DrugOrderTransaction> usableTrx = new List<TTObjectClasses.DrugOrderTransaction>();
            BindingList<DrugOrderTransaction> intrx = DrugOrderTransaction.GetUsableTransactions(context, episode.ObjectID.ToString(), material.ObjectID.ToString());


            return usableTrx;
        }
        public static double GetEmployableRestDose(DrugOrder drugOrder)
        {
            double totalUsedDose = 0;
            double totalUsedAmount = 0;
            double totalOrderAmount = 0;
            double totalOrderDose = 0;
            double restDose = 0;
            double employableDose = 0;
            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)drugOrder.Material);

            BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> outtableTransactions = DrugOrderTransaction.GetOuttableDrugOrderTransactions(drugOrder.Episode.ObjectID.ToString(), drugOrder.Material.ObjectID.ToString());

            foreach (DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class drugOrderTransaction in outtableTransactions)
                restDose = restDose + Convert.ToDouble(drugOrderTransaction.Restamount);

            /*foreach (DrugOrderTransaction drugOrderTransaction in drugOrder.DrugOrderTransactions)
            {
                if (drugOrderTransaction.InOut == 2)
                {
                    if (drugOrderTransaction.Volume == null)
                    {
                        totalUsedDose += 0;
                        totalUsedAmount += (double)drugOrderTransaction.Amount;
                    }
                    else
                    {
                        totalUsedDose += (double)drugOrderTransaction.Volume;
                        totalUsedAmount += (double)drugOrderTransaction.Amount;
                    }
                }
                else
                {
                    if (drugOrderTransaction.Volume == null)
                    {
                        totalUsedDose += 0;
                        totalUsedAmount += (double)drugOrderTransaction.Amount;
                    }
                    else
                    {
                        totalOrderAmount += (double)drugOrderTransaction.Amount;
                        totalOrderDose += (double)drugOrderTransaction.Volume;
                    }
                }

                if (drugType)
                {
                    restDose = totalOrderAmount - totalUsedAmount;
                }
                else
                {
                    restDose = totalOrderDose - totalUsedDose;
                }
            }*/

            employableDose = restDose;
            foreach (DrugOrderDetail drugOrderDetail in drugOrder.DrugOrderDetails)
            {
                if (drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.Supply || drugOrderDetail.CurrentStateDefID == DrugOrderDetail.States.ExPharmacySupply)
                {
                    if (drugType)
                    {
                        employableDose -= (double)drugOrderDetail.Amount;
                    }
                    else
                    {
                        employableDose -= (double)drugOrderDetail.DoseAmount;
                    }
                }
            }

            return employableDose;
        }
        
        public static Dictionary<object,double> GetPatientRestDose(Material material, Episode episode)
        {
            double rest = 0;
            TTObjectContext objectContext = new TTObjectContext(false);
            Dictionary<object, double> restDictionary = new Dictionary<object, double>();
            bool drugType = DrugOrder.GetDrugUsedType((DrugDefinition)material);

            if (drugType == false)
            {
                //BindingList<DrugOrderTransaction>  myDrugOrderTransactions = DrugOrderTransaction.GetDrugOrderTransactions(objectContext,episode.ObjectID.ToString(), material.ObjectID.ToString());
                BindingList<DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class> outtableTransactions = DrugOrderTransaction.GetOuttableDrugOrderTransactions(episode.ObjectID.ToString(), material.ObjectID.ToString());

                foreach (DrugOrderTransaction.GetOuttableDrugOrderTransactions_Class trx in outtableTransactions)
                {
                    DrugOrderTransaction drugOrderTransaction = (DrugOrderTransaction)objectContext.GetObject((Guid)trx.ObjectID, typeof(DrugOrderTransaction));
                    if (drugOrderTransaction.DrugOrder.Material.ObjectID.Equals(material.ObjectID) & drugOrderTransaction.DrugOrder.Episode.ObjectID.Equals(episode.ObjectID))
                    {
                        if (DrugOrderTransaction.GetEmployableRestDose((DrugOrder)drugOrderTransaction.DrugOrder) > 0)
                        {
                            if (restDictionary.ContainsKey(drugOrderTransaction.DrugOrder))
                            {
                                rest = 0;
                                rest = restDictionary[drugOrderTransaction.DrugOrder];
                                rest += DrugOrderTransaction.GetRestDose((DrugOrder)drugOrderTransaction.DrugOrder);
                                restDictionary[drugOrderTransaction.DrugOrder] = rest;
                            }
                            else
                            {
                                restDictionary.Add(drugOrderTransaction.DrugOrder, DrugOrderTransaction.GetRestDose((DrugOrder)drugOrderTransaction.DrugOrder));
                            }
                        }
                    }
                }
            }
            return restDictionary ;
        }

        
        public static Dictionary<object,double> GetDrugOrderTransactions(Material material, Episode episode)
        {
            double rest = 0;
            //IList myDrugOrderTransactions = material.ObjectContext.QueryObjects("DRUGORDERTRANSACTION", "INOUT=1");
            TTObjectContext objectContext = new TTObjectContext(false);
            BindingList<DrugOrderTransaction>  myDrugOrderTransactions = DrugOrderTransaction.GetDrugOrderTransactions(objectContext,episode.ObjectID.ToString(), material.ObjectID.ToString());
            
            Dictionary <object , double> transactionDictionary = new Dictionary<object,double>() ;
            foreach (DrugOrderTransaction drugOrderTransaction in myDrugOrderTransactions)
            {
                if(drugOrderTransaction.DrugOrder.Material == material & drugOrderTransaction.DrugOrder.Episode == episode)
                {
                    if (DrugOrderTransaction.GetRestDose((DrugOrder)drugOrderTransaction.DrugOrder) > 0)
                    {
                        if (transactionDictionary.ContainsKey (drugOrderTransaction))
                        {
                            rest = 0 ;
                            rest  = transactionDictionary [drugOrderTransaction] ;
                            rest += DrugOrderTransaction.GetRestDose((DrugOrder)drugOrderTransaction.DrugOrder);
                            transactionDictionary [drugOrderTransaction] = rest ;
                        }
                        else
                        {
                            transactionDictionary.Add(drugOrderTransaction,DrugOrderTransaction.GetRestDose((DrugOrder)drugOrderTransaction.DrugOrder));
                        }
                    }
                }
            }
            return transactionDictionary ;
        }

        public static Dictionary<DrugOrderTransaction, double> GetReturnableDrugOrderTransactions(Episode episode)
        {
            TTObjectContext objectContext = new TTObjectContext(true);
            IList allDrugOrderTransaction = DrugOrderTransaction.GetDrugOrderTransactionByEpisode(objectContext, episode.ObjectID);
            Dictionary<DrugOrderTransaction, double> transactionDictionary = new Dictionary<DrugOrderTransaction, double>();
            Dictionary<Guid, DrugOrder> drugOrderDictionary = new Dictionary<Guid, DrugOrder>();
            foreach (DrugOrderTransaction drugOrderTransaction in allDrugOrderTransaction)
            {
                if (drugOrderDictionary.ContainsKey(drugOrderTransaction.DrugOrder.ObjectID) == false)
                {
                    drugOrderDictionary.Add(drugOrderTransaction.DrugOrder.ObjectID, drugOrderTransaction.DrugOrder);
                    if (drugOrderTransaction.DrugOrder.Type == TTUtils.CultureService.GetText("M26287", "K-Çizelgesi"))
                    {
                        DrugDefinition drugDefinition = (DrugDefinition)drugOrderTransaction.DrugOrder.Material;
                        bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                        if (drugType)
                        {
                            if (DrugOrderTransaction.GetRestDose(drugOrderTransaction.DrugOrder) > 0)
                            {
                                transactionDictionary.Add(drugOrderTransaction, DrugOrderTransaction.GetRestDose(drugOrderTransaction.DrugOrder));
                            }
                        }
                        else
                        {
                            double resVolume = DrugOrderTransaction.GetRestDose(drugOrderTransaction.DrugOrder);
                            double resAmount = 0;
                            if (resVolume > 0)
                            {
                                resAmount = Math.Truncate(resVolume / (double)drugDefinition.Volume);
                                if (resAmount > 0)
                                {
                                    transactionDictionary.Add(drugOrderTransaction, resAmount);
                                }
                            }
                        }
                    }
                }
            }
            return transactionDictionary ;
        }
        
#endregion Methods

    }
}