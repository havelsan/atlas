
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
    public  partial class FixedAssetInDetail : FixedAssetDetail
    {
#region Methods
        public void SetNewFixedAssetSerialNumber()
        {
            Description = StockActionDetail.Material.Name;
            MainStoreDefinition mainStore = StockActionDetail.StockAction.Store as MainStoreDefinition;
            if (mainStore != null)
            {
                IList accountancies = StockActionDetail.ObjectContext.QueryObjects(typeof(ResAccountancy).Name, "ACCOUNTANCY = " + ConnectionManager.GuidToString(mainStore.Accountancy.ObjectID));
                if (accountancies.Count == 1)
                    Resource = (Resource)accountancies[0];

                int year = TTObjectDefManager.ServerTime.Year;
                TTObjectContext objectContext = new TTObjectContext(false);
                FixedAssetSEQObject fixedAssetSEQObject = new FixedAssetSEQObject(objectContext);
                fixedAssetSEQObject.FixedAssetNO.GetNextValue(year);
                objectContext.Save();
                string fixedAssetNOValue = "00000" + fixedAssetSEQObject.FixedAssetNO.Value.ToString();
                FixedAssetNO = year.ToString() + "-" + mainStore.Accountancy.AccountancyNO + "-" + fixedAssetNOValue.Substring(fixedAssetNOValue.Length - 5);
            }
            else
            {
                Accountancy accountancy = StockActionDetail.StockAction.AccountingTerm.Accountancy;

                int year = TTObjectDefManager.ServerTime.Year;
                TTObjectContext objectContext = new TTObjectContext(false);
                FixedAssetSEQObject fixedAssetSEQObject = new FixedAssetSEQObject(objectContext);
                fixedAssetSEQObject.FixedAssetNO.GetNextValue(year);
                objectContext.Save();
                string fixedAssetNOValue = "00000" + fixedAssetSEQObject.FixedAssetNO.Value.ToString();
                FixedAssetNO = year.ToString() + "-" + accountancy.AccountancyNO + "-" + fixedAssetNOValue.Substring(fixedAssetNOValue.Length - 5);

            }

        }
        
#endregion Methods

    }
}