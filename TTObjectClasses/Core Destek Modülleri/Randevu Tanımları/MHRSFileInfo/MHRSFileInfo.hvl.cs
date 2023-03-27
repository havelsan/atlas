
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSFileInfo")] 

    public  partial class MHRSFileInfo : TTObject
    {
        public class MHRSFileInfoList : TTObjectCollection<MHRSFileInfo> { }
                    
        public class ChildMHRSFileInfoCollection : TTObject.TTChildObjectCollection<MHRSFileInfo>
        {
            public ChildMHRSFileInfoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSFileInfoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Döküman
    /// </summary>
        public object Document
        {
            get { return (object)this["DOCUMENT"]; }
            set { this["DOCUMENT"] = value; }
        }

        protected MHRSFileInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSFileInfo(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSFileInfo(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSFileInfo(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSFileInfo(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSFILEINFO", dataRow) { }
        protected MHRSFileInfo(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSFILEINFO", dataRow, isImported) { }
        public MHRSFileInfo(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSFileInfo(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSFileInfo() : base() { }

    }
}