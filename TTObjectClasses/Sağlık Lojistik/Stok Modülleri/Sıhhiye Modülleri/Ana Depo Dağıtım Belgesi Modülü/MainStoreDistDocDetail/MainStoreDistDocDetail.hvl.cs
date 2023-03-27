
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MainStoreDistDocDetail")] 

    public  partial class MainStoreDistDocDetail : StockActionDetailOut
    {
        public class MainStoreDistDocDetailList : TTObjectCollection<MainStoreDistDocDetail> { }
                    
        public class ChildMainStoreDistDocDetailCollection : TTObject.TTChildObjectCollection<MainStoreDistDocDetail>
        {
            public ChildMainStoreDistDocDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMainStoreDistDocDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gönderilen Miktar
    /// </summary>
        public Currency? SendedAmount
        {
            get { return (Currency?)this["SENDEDAMOUNT"]; }
            set { this["SENDEDAMOUNT"] = value; }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public MainStoreDistributionDoc MainStoreDistributionDoc
        {
            get 
            {   
                if (StockAction is MainStoreDistributionDoc)
                    return (MainStoreDistributionDoc)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        public DrugDefinition DrugDefinition
        {
            get 
            {   
                if (Material is DrugDefinition)
                    return (DrugDefinition)Material; 
                return null;
            }            
            set { Material = value; }
        }

        protected MainStoreDistDocDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MainStoreDistDocDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MainStoreDistDocDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MainStoreDistDocDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MainStoreDistDocDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINSTOREDISTDOCDETAIL", dataRow) { }
        protected MainStoreDistDocDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINSTOREDISTDOCDETAIL", dataRow, isImported) { }
        public MainStoreDistDocDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MainStoreDistDocDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MainStoreDistDocDetail() : base() { }

    }
}