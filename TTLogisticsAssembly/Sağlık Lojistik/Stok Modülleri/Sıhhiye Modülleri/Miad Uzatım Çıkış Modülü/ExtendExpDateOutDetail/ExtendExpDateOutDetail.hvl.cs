
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExtendExpDateOutDetail")] 

    public  partial class ExtendExpDateOutDetail : StockActionDetailOut
    {
        public class ExtendExpDateOutDetailList : TTObjectCollection<ExtendExpDateOutDetail> { }
                    
        public class ChildExtendExpDateOutDetailCollection : TTObject.TTChildObjectCollection<ExtendExpDateOutDetail>
        {
            public ChildExtendExpDateOutDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExtendExpDateOutDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Çıkış Yapılan Son Kullanma Tarihi
    /// </summary>
        public DateTime? OutExpirationDate
        {
            get { return (DateTime?)this["OUTEXPIRATIONDATE"]; }
            set { this["OUTEXPIRATIONDATE"] = value; }
        }

        protected ExtendExpDateOutDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExtendExpDateOutDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExtendExpDateOutDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExtendExpDateOutDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExtendExpDateOutDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTENDEXPDATEOUTDETAIL", dataRow) { }
        protected ExtendExpDateOutDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTENDEXPDATEOUTDETAIL", dataRow, isImported) { }
        public ExtendExpDateOutDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExtendExpDateOutDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExtendExpDateOutDetail() : base() { }

    }
}