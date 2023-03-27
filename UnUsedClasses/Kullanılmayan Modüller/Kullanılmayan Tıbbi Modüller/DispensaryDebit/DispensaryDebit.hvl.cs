
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DispensaryDebit")] 

    /// <summary>
    /// Zimmet Sekmesi
    /// </summary>
    public  partial class DispensaryDebit : TTObject
    {
        public class DispensaryDebitList : TTObjectCollection<DispensaryDebit> { }
                    
        public class ChildDispensaryDebitCollection : TTObject.TTChildObjectCollection<DispensaryDebit>
        {
            public ChildDispensaryDebitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDispensaryDebitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? DebitDateTime
        {
            get { return (DateTime?)this["DEBITDATETIME"]; }
            set { this["DEBITDATETIME"] = value; }
        }

    /// <summary>
    /// Zimmet
    /// </summary>
        public string Debit
        {
            get { return (string)this["DEBIT"]; }
            set { this["DEBIT"] = value; }
        }

    /// <summary>
    /// Zimmet
    /// </summary>
        public Dispensary Dispensary
        {
            get { return (Dispensary)((ITTObject)this).GetParent("DISPENSARY"); }
            set { this["DISPENSARY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DispensaryDebit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DispensaryDebit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DispensaryDebit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DispensaryDebit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DispensaryDebit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISPENSARYDEBIT", dataRow) { }
        protected DispensaryDebit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISPENSARYDEBIT", dataRow, isImported) { }
        public DispensaryDebit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DispensaryDebit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DispensaryDebit() : base() { }

    }
}