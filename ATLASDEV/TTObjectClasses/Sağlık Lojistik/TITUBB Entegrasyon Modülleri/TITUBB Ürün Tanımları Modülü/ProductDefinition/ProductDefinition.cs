
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
    /// TITUBB Ãœrün Tanımı
    /// </summary>
    public  partial class ProductDefinition : TerminologyManagerDef
    {
        public partial class GetProductDefinitionList_Class : TTReportNqlObject 
        {
        }

        
                    
#region Methods
        [Serializable]
        public class NewFirmDefinition
        {
            public long IdentityNumber;
            public string Name;
            public DateTime Since;
            public string TITUBBFirmID;
        }
        
        [Serializable]
        public class NewProductDefinition
        {
            public string Name;
            public string ProductNumber;
            public string ProductNumberType;
            public string TITUBBProductID;
            public DateTime RegistrationDate;
            public ProductDefinition.NewFirmDefinition Firm;
            public List<ProductDefinition.NewProductSUTMatchDefinition> NewProductSUTMatchDefinitions;
        }
        
        [Serializable]
        public class NewSUTAppendixDefinition
        {
            public string Name;
            public string TITUBBSUTAppendixID;
        }
        
        [Serializable]
        public class NewProductSUTMatchDefinition
        {
            public string SUTCode;
            public string SUTName;
            public Currency SUTPrice;
            public string TITUBBProductSUTMatchID;
            public ProductDefinition.NewProductDefinition Product ;
            public ProductDefinition.NewSUTAppendixDefinition SUTAppendix;
        }
        
        public ProductSUTMatchDefinition GetProperSUTMatch()
        {
            ProductSUTMatchDefinition productSUTMatchDefinition = null;
            BindingList<ProductSUTMatchDefinition> useXXXXXXList =ProductSUTMatchs.Select("ISUSEXXXXXX = 1");
            if(useXXXXXXList.Count > 0)
                productSUTMatchDefinition = useXXXXXXList[0];
            else
                productSUTMatchDefinition = ProductSUTMatchs[0];
            
            return  productSUTMatchDefinition;
        }
        
#endregion Methods

    }
}