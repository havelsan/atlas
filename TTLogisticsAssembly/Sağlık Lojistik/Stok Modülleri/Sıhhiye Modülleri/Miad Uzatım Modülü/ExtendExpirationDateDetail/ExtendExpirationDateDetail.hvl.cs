
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExtendExpirationDateDetail")] 

    public  partial class ExtendExpirationDateDetail : StockActionDetailOut, IExtendExpirationDateDetail
    {
        public class ExtendExpirationDateDetailList : TTObjectCollection<ExtendExpirationDateDetail> { }
                    
        public class ChildExtendExpirationDateDetailCollection : TTObject.TTChildObjectCollection<ExtendExpirationDateDetail>
        {
            public ChildExtendExpirationDateDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExtendExpirationDateDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yeni Son Kullanma Tarihi
    /// </summary>
        public DateTime? NewDateForExpiration
        {
            get { return (DateTime?)this["NEWDATEFOREXPIRATION"]; }
            set { this["NEWDATEFOREXPIRATION"] = value; }
        }

    /// <summary>
    /// Güncelleme Öncesi Son Kullanma Tarihi
    /// </summary>
        public DateTime? CurrentExpirationDate
        {
            get { return (DateTime?)this["CURRENTEXPIRATIONDATE"]; }
            set { this["CURRENTEXPIRATIONDATE"] = value; }
        }

    /// <summary>
    /// Güncelleme Öncesi Lot Miktarı
    /// </summary>
        public Currency? SelectedLotRestAmount
        {
            get { return (Currency?)this["SELECTEDLOTRESTAMOUNT"]; }
            set { this["SELECTEDLOTRESTAMOUNT"] = value; }
        }

        protected ExtendExpirationDateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExtendExpirationDateDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExtendExpirationDateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExtendExpirationDateDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExtendExpirationDateDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTENDEXPIRATIONDATEDETAIL", dataRow) { }
        protected ExtendExpirationDateDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTENDEXPIRATIONDATEDETAIL", dataRow, isImported) { }
        public ExtendExpirationDateDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExtendExpirationDateDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExtendExpirationDateDetail() : base() { }

    }
}