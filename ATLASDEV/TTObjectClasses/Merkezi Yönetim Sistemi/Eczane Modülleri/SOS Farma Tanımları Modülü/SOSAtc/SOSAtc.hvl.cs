
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSAtc")] 

    /// <summary>
    /// SOS Atc
    /// </summary>
    public  partial class SOSAtc : TerminologyManagerDef
    {
        public class SOSAtcList : TTObjectCollection<SOSAtc> { }
                    
        public class ChildSOSAtcCollection : TTObject.TTChildObjectCollection<SOSAtc>
        {
            public ChildSOSAtcCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSAtcCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

    /// <summary>
    /// ATC Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// ATC Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Bağlı ATC Kodu
    /// </summary>
        public string ParentCode
        {
            get { return (string)this["PARENTCODE"]; }
            set { this["PARENTCODE"] = value; }
        }

        public ATC XXXXXXAtc
        {
            get { return (ATC)((ITTObject)this).GetParent("XXXXXXATC"); }
            set { this["XXXXXXATC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSAtc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSAtc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSAtc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSAtc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSAtc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSATC", dataRow) { }
        protected SOSAtc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSATC", dataRow, isImported) { }
        public SOSAtc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSAtc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSAtc() : base() { }

    }
}