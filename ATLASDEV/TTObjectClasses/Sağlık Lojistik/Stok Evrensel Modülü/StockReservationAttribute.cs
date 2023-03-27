
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
    public partial class StockReservationAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
            {
                foreach (StockActionDetailOut stockActionDetailOut in Interface.GetStockActionOutDetails())
                {

                    switch (ReservationMethod)
                    {
                        case ReservationMethodEnum.CancelReservation:
                            if (stockActionDetailOut.StockReservation != null)
                                stockActionDetailOut.StockReservation.CancelReservation();
                            break;
                        case ReservationMethodEnum.CompleteReservation:
                            if (stockActionDetailOut.StockReservation != null)
                                stockActionDetailOut.StockReservation.CompletedReservation();
                            break;
                        case ReservationMethodEnum.DoReservation:
                            if (stockActionDetailOut.StockReservation != null && stockActionDetailOut.StockReservation.Amount == stockActionDetailOut.Amount)
                                break;

                            if (stockActionDetailOut.StockReservation != null && stockActionDetailOut.StockReservation.Amount != stockActionDetailOut.Amount)
                                stockActionDetailOut.StockReservation.CancelReservation();

                            IList stocks = Stock.GetStoreMaterial(ObjectContext, Interface.GetStore().ObjectID, stockActionDetailOut.Material.ObjectID);
                            Stock stock = null;
                            if (stocks.Count == 0)
                                throw new Exception(SystemMessage.GetMessage(517));

                            stock = (Stock)stocks[0];
                            stock.ToReservation(stockActionDetailOut);

                            break;
                        default:
                            break;
                    }
                }
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}