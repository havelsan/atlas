
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDeleteRecordDocumentDetail")] 

    public  abstract  partial class BaseDeleteRecordDocumentDetail : StockActionDetailOut
    {
        public class BaseDeleteRecordDocumentDetailList : TTObjectCollection<BaseDeleteRecordDocumentDetail> { }
                    
        public class ChildBaseDeleteRecordDocumentDetailCollection : TTObject.TTChildObjectCollection<BaseDeleteRecordDocumentDetail>
        {
            public ChildBaseDeleteRecordDocumentDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDeleteRecordDocumentDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yetki Sembolü
    /// </summary>
        public AuthorityClassStatusEnum? AuthorityClass
        {
            get { return (AuthorityClassStatusEnum?)(int?)this["AUTHORITYCLASS"]; }
            set { this["AUTHORITYCLASS"] = value; }
        }

    /// <summary>
    /// Kayıt Silme Sebebi
    /// </summary>
        public DeleteRecordReasonEnum? DeleteRecordReason
        {
            get { return (DeleteRecordReasonEnum?)(int?)this["DELETERECORDREASON"]; }
            set { this["DELETERECORDREASON"] = value; }
        }

    /// <summary>
    /// Düşünceler
    /// </summary>
        public string Opinions
        {
            get { return (string)this["OPINIONS"]; }
            set { this["OPINIONS"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        protected BaseDeleteRecordDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDeleteRecordDocumentDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDeleteRecordDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDeleteRecordDocumentDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDeleteRecordDocumentDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDELETERECORDDOCUMENTDETAIL", dataRow) { }
        protected BaseDeleteRecordDocumentDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDELETERECORDDOCUMENTDETAIL", dataRow, isImported) { }
        public BaseDeleteRecordDocumentDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDeleteRecordDocumentDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDeleteRecordDocumentDetail() : base() { }

    }
}