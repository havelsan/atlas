
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SOSFarmaXXXXXX")] 

    public  partial class SOSFarmaXXXXXX : TTObject
    {
        public class SOSFarmaXXXXXXList : TTObjectCollection<SOSFarmaXXXXXX> { }
                    
        public class ChildSOSFarmaXXXXXXCollection : TTObject.TTChildObjectCollection<SOSFarmaXXXXXX>
        {
            public ChildSOSFarmaXXXXXXCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSOSFarmaXXXXXXCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public Guid? LastUpdateGuid
        {
            get { return (Guid?)this["LASTUPDATEGUID"]; }
            set { this["LASTUPDATEGUID"] = value; }
        }

        public DateTime? LastUpdateDate
        {
            get { return (DateTime?)this["LASTUPDATEDATE"]; }
            set { this["LASTUPDATEDATE"] = value; }
        }

        protected SOSFarmaXXXXXX(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SOSFarmaXXXXXX(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SOSFarmaXXXXXX(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SOSFarmaXXXXXX(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SOSFarmaXXXXXX(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOSFARMAXXXXXX", dataRow) { }
        protected SOSFarmaXXXXXX(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOSFARMAXXXXXX", dataRow, isImported) { }
        public SOSFarmaXXXXXX(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SOSFarmaXXXXXX(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SOSFarmaXXXXXX() : base() { }

    }
}