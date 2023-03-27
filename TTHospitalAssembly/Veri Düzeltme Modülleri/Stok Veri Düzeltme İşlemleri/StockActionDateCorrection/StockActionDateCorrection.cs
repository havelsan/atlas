﻿
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
    /// Belge Tarihi Güncelleme (Devir için)
    /// </summary>
    public  partial class StockActionDateCorrection : BaseDataCorrection, IWorkListBaseAction
    {
#region Methods
        public void ChangeDate (StockTransaction stockTransaction,DateTime changeDate)
        {
            TTObjectContext context = new TTObjectContext(false);
            StockAction stockAction = stockTransaction.StockActionDetail.StockAction;
            foreach (StockActionDetail stockActionDetail in stockAction.StockActionDetails)
            {
                foreach (StockTransaction changeTransaction in stockActionDetail.StockTransactions.Select(string.Empty))
                {
                    StockTransaction updateTransaction = (StockTransaction)context.GetObject(changeTransaction.ObjectID, "STOCKTRANSACTION");
                    updateTransaction.TransactionDate = changeDate;
                }
            }
            context.Save();
            context.Dispose();
        }
        
#endregion Methods

    }
}