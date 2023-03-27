
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyImage")] 

    /// <summary>
    /// PathologyImage
    /// </summary>
    public  partial class PathologyImage : TTObject
    {
        public class PathologyImageList : TTObjectCollection<PathologyImage> { }
                    
        public class ChildPathologyImageCollection : TTObject.TTChildObjectCollection<PathologyImage>
        {
            public ChildPathologyImageCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyImageCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Description
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Image
    /// </summary>
        public object Image
        {
            get { return (object)this["IMAGE"]; }
            set { this["IMAGE"] = value; }
        }

    /// <summary>
    /// Patoloji Testi İlişkisi
    /// </summary>
        public Pathology PathologyTest
        {
            get { return (Pathology)((ITTObject)this).GetParent("PATHOLOGYTEST"); }
            set { this["PATHOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PathologyImage(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyImage(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyImage(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyImage(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyImage(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYIMAGE", dataRow) { }
        protected PathologyImage(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYIMAGE", dataRow, isImported) { }
        public PathologyImage(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyImage(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyImage() : base() { }

    }
}