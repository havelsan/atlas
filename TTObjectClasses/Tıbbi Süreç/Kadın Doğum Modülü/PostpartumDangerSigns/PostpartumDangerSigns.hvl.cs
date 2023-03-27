
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PostpartumDangerSigns")] 

    /// <summary>
    /// Lohusalık Seyrinde Tehlike İşaretleri
    /// </summary>
    public  partial class PostpartumDangerSigns : TTObject
    {
        public class PostpartumDangerSignsList : TTObjectCollection<PostpartumDangerSigns> { }
                    
        public class ChildPostpartumDangerSignsCollection : TTObject.TTChildObjectCollection<PostpartumDangerSigns>
        {
            public ChildPostpartumDangerSignsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPostpartumDangerSignsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Lohusalık Seyrinde Tehlike İşareti
    /// </summary>
        public SKRSGebelikLohusalikSeyrindeTehlikeIsareti SKRSDangerSigns
        {
            get { return (SKRSGebelikLohusalikSeyrindeTehlikeIsareti)((ITTObject)this).GetParent("SKRSDANGERSIGNS"); }
            set { this["SKRSDANGERSIGNS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PostpartumFollowUp PostpartumFollowUp
        {
            get { return (PostpartumFollowUp)((ITTObject)this).GetParent("POSTPARTUMFOLLOWUP"); }
            set { this["POSTPARTUMFOLLOWUP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PostpartumDangerSigns(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PostpartumDangerSigns(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PostpartumDangerSigns(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PostpartumDangerSigns(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PostpartumDangerSigns(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "POSTPARTUMDANGERSIGNS", dataRow) { }
        protected PostpartumDangerSigns(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "POSTPARTUMDANGERSIGNS", dataRow, isImported) { }
        public PostpartumDangerSigns(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PostpartumDangerSigns(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PostpartumDangerSigns() : base() { }

    }
}