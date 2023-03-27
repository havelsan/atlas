
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
    /// Depo tanımları için kullanılan ana sınıftır. Her türlü depo tanımı için kullanılan sınıflar bu sınıftan türer
    /// </summary>
    public  partial class Store : TTDefinitionSet, IStore
    {
        public partial class StoreListBySubTypeNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetStoreNamesReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetAllStoreReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_DEPO_Class : TTReportNqlObject 
        {
        }

        #region Methods
        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        #region ITTCoreDefinitionObject Members
        public DateTime? GetLastUpdate()
        {
            return LastUpdate;
        }

        public bool? GetIsActive()
        {
            return IsActive;
        }
        #endregion
        public Stock GetStock(Material material)
        {
            Stock stock = null;
           
            IList stocks = null;       
            string filterExpression = " STORE = " + ConnectionManager.GuidToString(ObjectID) + " AND MATERIAL = " + ConnectionManager.GuidToString(material.ObjectID);
            stocks = ObjectContext.LocalQuery(typeof(Stock).Name, filterExpression);
            if (stocks.Count > 0)
            {
                stock = (Stock)stocks[0];
            }
            else
            {
                stocks = ObjectContext.QueryObjects(typeof(Stock).Name, filterExpression);
                if (stocks.Count > 0)
                    stock = (Stock)stocks[0];
                else
                    stock = new Stock(ObjectContext, this, material);
            }          

            return stock;

        }

        public static Store GetPharmacyStore(TTObjectContext context)
        {
            Store pharmacyStore = null;

            string parameterValue = SystemParameter.GetParameterValue("USEPHARMACYSUBSTORE", "FALSE");
            if(parameterValue == "TRUE")
            {
                BindingList<PharmacySubStoreDefinition> pharmacys = PharmacySubStoreDefinition.GetPharmacySubStore(context);
                if (pharmacys.Count > 0)
                    pharmacyStore = (Store)pharmacys[0];
            }
            else
            {
                BindingList<PharmacyStoreDefinition> pharmacys = PharmacyStoreDefinition.GetInpatientPharmacyStore(context);
                if (pharmacys.Count > 0)
                    pharmacyStore = (Store)pharmacys[0];
            }
            return pharmacyStore;
        }
        #region IStore Members
        public string GetName()
        {
            return Name;
        }

        public string GetQREF()
        {
            return QREF;
        }
        #endregion
        #endregion Methods

    }
}