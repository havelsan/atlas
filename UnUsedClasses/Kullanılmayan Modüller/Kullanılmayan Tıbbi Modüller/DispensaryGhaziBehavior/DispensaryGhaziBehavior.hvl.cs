
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DispensaryGhaziBehavior")] 

    /// <summary>
    /// Gazi Durum Sekmesi
    /// </summary>
    public  partial class DispensaryGhaziBehavior : TTObject
    {
        public class DispensaryGhaziBehaviorList : TTObjectCollection<DispensaryGhaziBehavior> { }
                    
        public class ChildDispensaryGhaziBehaviorCollection : TTObject.TTChildObjectCollection<DispensaryGhaziBehavior>
        {
            public ChildDispensaryGhaziBehaviorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDispensaryGhaziBehaviorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Olay Açıklaması
    /// </summary>
        public string Explanation
        {
            get { return (string)this["EXPLANATION"]; }
            set { this["EXPLANATION"] = value; }
        }

    /// <summary>
    /// Olay Yeri
    /// </summary>
        public string Place
        {
            get { return (string)this["PLACE"]; }
            set { this["PLACE"] = value; }
        }

    /// <summary>
    /// Gazi Durum
    /// </summary>
        public Dispensary Dispensary
        {
            get { return (Dispensary)((ITTObject)this).GetParent("DISPENSARY"); }
            set { this["DISPENSARY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DispensaryGhaziBehavior(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DispensaryGhaziBehavior(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DispensaryGhaziBehavior(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DispensaryGhaziBehavior(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DispensaryGhaziBehavior(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISPENSARYGHAZIBEHAVIOR", dataRow) { }
        protected DispensaryGhaziBehavior(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISPENSARYGHAZIBEHAVIOR", dataRow, isImported) { }
        public DispensaryGhaziBehavior(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DispensaryGhaziBehavior(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DispensaryGhaziBehavior() : base() { }

    }
}