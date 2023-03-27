
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="QRCodeDetail")] 

    public  partial class QRCodeDetail : TTObject
    {
        public class QRCodeDetailList : TTObjectCollection<QRCodeDetail> { }
                    
        public class ChildQRCodeDetailCollection : TTObject.TTChildObjectCollection<QRCodeDetail>
        {
            public ChildQRCodeDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildQRCodeDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public StockActionDetail StockActionDetail
        {
            get { return (StockActionDetail)((ITTObject)this).GetParent("STOCKACTIONDETAIL"); }
            set { this["STOCKACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected QRCodeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected QRCodeDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected QRCodeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected QRCodeDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected QRCodeDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "QRCODEDETAIL", dataRow) { }
        protected QRCodeDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "QRCODEDETAIL", dataRow, isImported) { }
        public QRCodeDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public QRCodeDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public QRCodeDetail() : base() { }

    }
}