
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
    /// <summary>
    /// Malzeme Aktarım
    /// </summary>
    public  partial class MaterialMatchAction : BaseAction, IWorkListBaseAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            

            if (MatchMaterial.StockCard.StockMethod == StockMethodEnum.SerialNumbered || WrongMaterial.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
            {
                throw new TTException(TTUtils.CultureService.GetText("M26844", "Seri numaralı malzemeler için bu işlemi yapamazsınız!"));
            }
            
            if (MatchMaterial.Stocks.Select(string.Empty).Count == 0)
            {
                foreach (Stock wrongStock in WrongMaterial.Stocks.Select(string.Empty))
                {
                    wrongStock.Material = MatchMaterial;
                    foreach (StockTransaction transaction in wrongStock.StockTransactions.Select(string.Empty))
                    {
                        transaction.StockActionDetail.Material = MatchMaterial;
                    }
                }
            }
            else
            {
                bool err = false;
                Dictionary<Guid, Stock> zeroStock = new Dictionary<Guid, Stock>();
                foreach (Stock matchStock in MatchMaterial.Stocks.Select(string.Empty))
                {
                    if (matchStock.StockTransactions.Select(string.Empty).Count == 0)
                    {
                        zeroStock.Add(matchStock.ObjectID, matchStock);
                    }
                    else
                    {
                        err = true;
                    }
                }
                if (err)
                {
                    throw new TTException(MatchMaterial.Name + " isimli malzemenin hareketi olduğu için bu işlemi yapamazsınız!");
                }
                else
                {
                    Dictionary<Guid, StockCensusDetail> censusdetails = new Dictionary<Guid, StockCensusDetail>();
                    foreach (KeyValuePair<Guid, Stock> deletedStock in zeroStock)
                    {
                        if(deletedStock.Value.Store.ObjectID.Equals(MainStoreDefinition.ObjectID))
                        {
                            IList wrongCensusDetails = ObjectContext.QueryObjects("STOCKCENSUSDETAIL", "STOCK =" + ConnectionManager.GuidToString(deletedStock.Key));
                            foreach (StockCensusDetail detail in wrongCensusDetails)
                            {
                                censusdetails.Add(detail.ObjectID, detail);
                            }
                        }
                        TTObjectContext context = new TTObjectContext(false);
                        Stock dStock = (Stock)context.GetObject(deletedStock.Key, "STOCK");
                        ((ITTObject)dStock).Delete();
                        context.Save();
                        context.Dispose();
                    }

                    foreach (Stock wrongStock in WrongMaterial.Stocks.Select(string.Empty))
                    {
                        wrongStock.Material = MatchMaterial ;
                        foreach (StockTransaction transaction in wrongStock.StockTransactions.Select(string.Empty))
                        {
                            transaction.StockActionDetail.Material = MatchMaterial;
                        }
                    }

                    Stock nwstock = new Stock(ObjectContext, ((Store)MainStoreDefinition), WrongMaterial);
                    foreach (KeyValuePair<Guid, StockCensusDetail> newDetail in censusdetails)
                    {
                        newDetail.Value.Stock = nwstock;
                    }
                }
            }
            

#endregion PostTransition_New2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaterialMatchAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaterialMatchAction.States.New && toState == MaterialMatchAction.States.Completed)
                PostTransition_New2Completed();
        }

    }
}