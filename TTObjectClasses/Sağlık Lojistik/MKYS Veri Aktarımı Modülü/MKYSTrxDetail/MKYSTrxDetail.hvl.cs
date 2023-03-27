
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MKYSTrxDetail")] 

    public  partial class MKYSTrxDetail : TTObject
    {
        public class MKYSTrxDetailList : TTObjectCollection<MKYSTrxDetail> { }
                    
        public class ChildMKYSTrxDetailCollection : TTObject.TTChildObjectCollection<MKYSTrxDetail>
        {
            public ChildMKYSTrxDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMKYSTrxDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public MKYSTrx InMKYSTrx
        {
            get { return (MKYSTrx)((ITTObject)this).GetParent("INMKYSTRX"); }
            set { this["INMKYSTRX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MKYSTrx OutMKYSTrx
        {
            get { return (MKYSTrx)((ITTObject)this).GetParent("OUTMKYSTRX"); }
            set { this["OUTMKYSTRX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MKYSTrxDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MKYSTrxDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MKYSTrxDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MKYSTrxDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MKYSTrxDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MKYSTRXDETAIL", dataRow) { }
        protected MKYSTrxDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MKYSTRXDETAIL", dataRow, isImported) { }
        public MKYSTrxDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MKYSTrxDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MKYSTrxDetail() : base() { }

    }
}