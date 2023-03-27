
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdvanceBackAdvanceDetail")] 

    /// <summary>
    /// Avans İade Detayı
    /// </summary>
    public  partial class AdvanceBackAdvanceDetail : TTObject
    {
        public class AdvanceBackAdvanceDetailList : TTObjectCollection<AdvanceBackAdvanceDetail> { }
                    
        public class ChildAdvanceBackAdvanceDetailCollection : TTObject.TTChildObjectCollection<AdvanceBackAdvanceDetail>
        {
            public ChildAdvanceBackAdvanceDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdvanceBackAdvanceDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kredi Kartı Alındı Numarası
    /// </summary>
        public string AdvanceCrCardDocumentNo
        {
            get { return (string)this["ADVANCECRCARDDOCUMENTNO"]; }
            set { this["ADVANCECRCARDDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Kredi Kartı Alındı Tarihi
    /// </summary>
        public DateTime? AdvanceDate
        {
            get { return (DateTime?)this["ADVANCEDATE"]; }
            set { this["ADVANCEDATE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public string Status
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Kredi Kartı Alındı Numarası
    /// </summary>
        public string AdvanceDocumentNo
        {
            get { return (string)this["ADVANCEDOCUMENTNO"]; }
            set { this["ADVANCEDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Kredi Kartı Alındı Tutarı
    /// </summary>
        public Currency? TotalPrice
        {
            get { return (Currency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Avans İade İşlemiyle İlişkisi
    /// </summary>
        public AdvanceBack AdvanceBack
        {
            get { return (AdvanceBack)((ITTObject)this).GetParent("ADVANCEBACK"); }
            set { this["ADVANCEBACK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AdvanceBackAdvanceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdvanceBackAdvanceDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdvanceBackAdvanceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdvanceBackAdvanceDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdvanceBackAdvanceDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADVANCEBACKADVANCEDETAIL", dataRow) { }
        protected AdvanceBackAdvanceDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADVANCEBACKADVANCEDETAIL", dataRow, isImported) { }
        public AdvanceBackAdvanceDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdvanceBackAdvanceDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdvanceBackAdvanceDetail() : base() { }

    }
}