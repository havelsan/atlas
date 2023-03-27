
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PregnancyDangerSign")] 

    public  partial class PregnancyDangerSign : TTObject
    {
        public class PregnancyDangerSignList : TTObjectCollection<PregnancyDangerSign> { }
                    
        public class ChildPregnancyDangerSignCollection : TTObject.TTChildObjectCollection<PregnancyDangerSign>
        {
            public ChildPregnancyDangerSignCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnancyDangerSignCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tehlike Tanımı
    /// </summary>
        public string DangerDescription
        {
            get { return (string)this["DANGERDESCRIPTION"]; }
            set { this["DANGERDESCRIPTION"] = value; }
        }

        public PregnancyFollow PregnancyFollow
        {
            get { return (PregnancyFollow)((ITTObject)this).GetParent("PREGNANCYFOLLOW"); }
            set { this["PREGNANCYFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGebelikLohusalikSeyrindeTehlikeIsareti Danger
        {
            get { return (SKRSGebelikLohusalikSeyrindeTehlikeIsareti)((ITTObject)this).GetParent("DANGER"); }
            set { this["DANGER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PregnancyDangerSign(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PregnancyDangerSign(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PregnancyDangerSign(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PregnancyDangerSign(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PregnancyDangerSign(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANCYDANGERSIGN", dataRow) { }
        protected PregnancyDangerSign(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANCYDANGERSIGN", dataRow, isImported) { }
        public PregnancyDangerSign(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PregnancyDangerSign(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PregnancyDangerSign() : base() { }

    }
}