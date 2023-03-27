
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="APRTrx")] 

    /// <summary>
    /// Balans hareketlerini tutar (AccountPayableReceivable ın detayını içerir)
    /// </summary>
    public  partial class APRTrx : TTObject
    {
        public class APRTrxList : TTObjectCollection<APRTrx> { }
                    
        public class ChildAPRTrxCollection : TTObject.TTChildObjectCollection<APRTrx>
        {
            public ChildAPRTrxCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAPRTrxCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// AccountPayableReceivable ile relation
    /// </summary>
        public AccountPayableReceivable AccountPayableReceivable
        {
            get { return (AccountPayableReceivable)((ITTObject)this).GetParent("ACCOUNTPAYABLERECEIVABLE"); }
            set { this["ACCOUNTPAYABLERECEIVABLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// AccountDocument ile relation
    /// </summary>
        public AccountDocument AccountDocument
        {
            get { return (AccountDocument)((ITTObject)this).GetParent("ACCOUNTDOCUMENT"); }
            set { this["ACCOUNTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// APRTrxType a relation
    /// </summary>
        public APRTrxType APRTrxType
        {
            get { return (APRTrxType)((ITTObject)this).GetParent("APRTRXTYPE"); }
            set { this["APRTRXTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected APRTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected APRTrx(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected APRTrx(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected APRTrx(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected APRTrx(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "APRTRX", dataRow) { }
        protected APRTrx(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "APRTRX", dataRow, isImported) { }
        public APRTrx(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public APRTrx(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public APRTrx() : base() { }

    }
}