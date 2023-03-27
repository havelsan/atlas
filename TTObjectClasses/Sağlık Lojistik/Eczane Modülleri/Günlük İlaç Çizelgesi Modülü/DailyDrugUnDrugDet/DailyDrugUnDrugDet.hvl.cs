
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DailyDrugUnDrugDet")] 

    public  partial class DailyDrugUnDrugDet : TTObject
    {
        public class DailyDrugUnDrugDetList : TTObjectCollection<DailyDrugUnDrugDet> { }
                    
        public class ChildDailyDrugUnDrugDetCollection : TTObject.TTChildObjectCollection<DailyDrugUnDrugDet>
        {
            public ChildDailyDrugUnDrugDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDailyDrugUnDrugDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DailyDrugUnDrug DailyDrugUnDrug
        {
            get { return (DailyDrugUnDrug)((ITTObject)this).GetParent("DAILYDRUGUNDRUG"); }
            set { this["DAILYDRUGUNDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrderDetail DrugOrderDetail
        {
            get { return (DrugOrderDetail)((ITTObject)this).GetParent("DRUGORDERDETAIL"); }
            set { this["DRUGORDERDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DailyDrugUnDrugDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DailyDrugUnDrugDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DailyDrugUnDrugDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DailyDrugUnDrugDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DailyDrugUnDrugDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DAILYDRUGUNDRUGDET", dataRow) { }
        protected DailyDrugUnDrugDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DAILYDRUGUNDRUGDET", dataRow, isImported) { }
        public DailyDrugUnDrugDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DailyDrugUnDrugDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DailyDrugUnDrugDet() : base() { }

    }
}