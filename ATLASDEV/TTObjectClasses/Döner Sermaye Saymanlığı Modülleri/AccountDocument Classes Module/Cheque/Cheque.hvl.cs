
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Cheque")] 

    /// <summary>
    /// Çek ile Ödeme Türü
    /// </summary>
    public  partial class Cheque : Payment
    {
        public class ChequeList : TTObjectCollection<Cheque> { }
                    
        public class ChildChequeCollection : TTObject.TTChildObjectCollection<Cheque>
        {
            public ChildChequeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChequeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Numara
    /// </summary>
        public string No
        {
            get { return (string)this["NO"]; }
            set { this["NO"] = value; }
        }

    /// <summary>
    /// Banka ile ilişki
    /// </summary>
        public BankDefinition BankName
        {
            get { return (BankDefinition)((ITTObject)this).GetParent("BANKNAME"); }
            set { this["BANKNAME"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Cheque(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Cheque(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Cheque(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Cheque(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Cheque(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHEQUE", dataRow) { }
        protected Cheque(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHEQUE", dataRow, isImported) { }
        public Cheque(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Cheque(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Cheque() : base() { }

    }
}