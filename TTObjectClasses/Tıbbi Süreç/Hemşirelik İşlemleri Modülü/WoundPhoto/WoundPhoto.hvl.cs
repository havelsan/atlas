
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="WoundPhoto")] 

    public  partial class WoundPhoto : TTObject
    {
        public class WoundPhotoList : TTObjectCollection<WoundPhoto> { }
                    
        public class ChildWoundPhotoCollection : TTObject.TTChildObjectCollection<WoundPhoto>
        {
            public ChildWoundPhotoCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWoundPhotoCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yaraya ait Fotoğraf
    /// </summary>
        public object Photo
        {
            get { return (object)this["PHOTO"]; }
            set { this["PHOTO"] = value; }
        }

        public DateTime? PhotoDate
        {
            get { return (DateTime?)this["PHOTODATE"]; }
            set { this["PHOTODATE"] = value; }
        }

        public NursingWoundedAssesment NursingWound
        {
            get { return (NursingWoundedAssesment)((ITTObject)this).GetParent("NURSINGWOUND"); }
            set { this["NURSINGWOUND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected WoundPhoto(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected WoundPhoto(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected WoundPhoto(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected WoundPhoto(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected WoundPhoto(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WOUNDPHOTO", dataRow) { }
        protected WoundPhoto(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WOUNDPHOTO", dataRow, isImported) { }
        public WoundPhoto(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public WoundPhoto(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public WoundPhoto() : base() { }

    }
}