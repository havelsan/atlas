
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSFarmasotikSekil")] 

    public  partial class SOSFarmasotikSekil : TerminologyManagerDef
    {
        public class SOSFarmasotikSekilList : TTObjectCollection<SOSFarmasotikSekil> { }
                    
        public class ChildSOSFarmasotikSekilCollection : TTObject.TTChildObjectCollection<SOSFarmasotikSekil>
        {
            public ChildSOSFarmasotikSekilCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSFarmasotikSekilCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public long? SOSID
        {
            get { return (long?)this["SOSID"]; }
            set { this["SOSID"] = value; }
        }

    /// <summary>
    /// Farmasotik Şekil Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Farmasotik Grup Kodu
    /// </summary>
        public string ParentCode
        {
            get { return (string)this["PARENTCODE"]; }
            set { this["PARENTCODE"] = value; }
        }

    /// <summary>
    /// Farmasotik Şekil Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public NFC XXXXXXNfc
        {
            get { return (NFC)((ITTObject)this).GetParent("XXXXXXNFC"); }
            set { this["XXXXXXNFC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SOSFarmasotikSekil(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSFarmasotikSekil(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSFarmasotikSekil(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSFarmasotikSekil(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSFarmasotikSekil(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSFARMASOTIKSEKIL", dataRow) { }
        protected SOSFarmasotikSekil(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSFARMASOTIKSEKIL", dataRow, isImported) { }
        public SOSFarmasotikSekil(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSFarmasotikSekil(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSFarmasotikSekil() : base() { }

    }
}