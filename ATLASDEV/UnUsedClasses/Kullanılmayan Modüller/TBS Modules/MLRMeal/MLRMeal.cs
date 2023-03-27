
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
    /// DLR004_Yemek
    /// </summary>
    public  partial class MLRMeal : TTObject
    {
#region Methods
        public static MLRMeal getMealUsingID(Guid g, TTObjectContext objectContext)
        {
            return (MLRMeal)objectContext.GetObject(g,"MLRMeal");
        }
        
        public  void  evaluateTotaCalorie()
        {    
             ObjectContext.QueryObjects("MNZVEHICLE");
        }
        public MLRSupply getSupply(Guid objectDefID)
        {
            IList myList;
            Console.WriteLine("iste geldim");
            myList = ObjectContext.QueryObjects("MLRSUPPLY","OBJECTID = '"+objectDefID.ToString()+"'");
            Console.WriteLine("burdayim");
            if(myList.Count != 0)
            {
                return (MLRSupply)((myList)[0]);
            }
            return null;
        }
        
#endregion Methods

    }
}