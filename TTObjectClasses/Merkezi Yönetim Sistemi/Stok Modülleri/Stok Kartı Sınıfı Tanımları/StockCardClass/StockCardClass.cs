
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
    /// Stok Kartı Sınıfı Tanımları
    /// </summary>
    public  partial class StockCardClass : TerminologyManagerDef, ITTListObject
    {
        public partial class GetStockCardClass_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_StockCardClass_Class : TTReportNqlObject 
        {
        }

#region Methods
        public void GetSubStockCardClassObjectIDs(ref List<string> stockCardClassObjectIDs)
        {
            stockCardClassObjectIDs.Add(ConnectionManager.GuidToString(ObjectID));
            foreach (StockCardClass childStockCardClass in StockCardClasses)
                childStockCardClass.GetSubStockCardClassObjectIDs(ref stockCardClassObjectIDs);
        }

        public StockCardClass RootStockCardClass
        {
            get
            {
                StockCardClass retValue = this;
                while (true)
                {
                    if (retValue.ParentStockCardClass != null)
                        retValue = retValue.ParentStockCardClass;
                    else
                        break;
                }
                return retValue;
            }
        }

        public override string ToString()
        {
            return Code + " " + Name;
        }

        bool ITTListObject.IsSelectable
        {
            get
            {
                return true;
            }
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.StockCardClassDefinitionInfo;
        }
        
#endregion Methods

    }
}