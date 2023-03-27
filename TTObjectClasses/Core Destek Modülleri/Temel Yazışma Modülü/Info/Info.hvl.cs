
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Info")] 

    /// <summary>
    /// Bilgi
    /// </summary>
    public  partial class Info : TTObject
    {
        public class InfoList : TTObjectCollection<Info> { }
                    
        public class ChildInfoCollection : TTObject.TTChildObjectCollection<Info>
        {
            public ChildInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bilgi Satırı
    /// </summary>
        public string InfoLine
        {
            get { return (string)this["INFOLINE"]; }
            set { this["INFOLINE"] = value; }
        }

        public BaseCorrespondence BaseCorrespondence
        {
            get { return (BaseCorrespondence)((ITTObject)this).GetParent("BASECORRESPONDENCE"); }
            set { this["BASECORRESPONDENCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Info(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Info(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Info(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Info(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Info(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INFO", dataRow) { }
        protected Info(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INFO", dataRow, isImported) { }
        public Info(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Info(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Info() : base() { }

    }
}