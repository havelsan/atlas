
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSWatch")] 

    public  partial class MBSWatch : TTObject
    {
        public class MBSWatchList : TTObjectCollection<MBSWatch> { }
                    
        public class ChildMBSWatchCollection : TTObject.TTChildObjectCollection<MBSWatch>
        {
            public ChildMBSWatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSWatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Damga vergisi
    /// </summary>
        public double? StampTax
        {
            get { return (double?)this["STAMPTAX"]; }
            set { this["STAMPTAX"] = value; }
        }

    /// <summary>
    /// Nöbet göstergesi
    /// </summary>
        public string WatchIndicator
        {
            get { return (string)this["WATCHINDICATOR"]; }
            set { this["WATCHINDICATOR"] = value; }
        }

    /// <summary>
    /// Yan ödeme kodu
    /// </summary>
        public string AuxiliaryPaymentCode
        {
            get { return (string)this["AUXILIARYPAYMENTCODE"]; }
            set { this["AUXILIARYPAYMENTCODE"] = value; }
        }

        protected MBSWatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSWatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSWatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSWatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSWatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSWATCH", dataRow) { }
        protected MBSWatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSWATCH", dataRow, isImported) { }
        public MBSWatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSWatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSWatch() : base() { }

    }
}