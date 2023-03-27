
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FetusFollow")] 

    public  partial class FetusFollow : TTObject
    {
        public class FetusFollowList : TTObjectCollection<FetusFollow> { }
                    
        public class ChildFetusFollowCollection : TTObject.TTChildObjectCollection<FetusFollow>
        {
            public ChildFetusFollowCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFetusFollowCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Bebek Boyutu
    /// </summary>
        public string BabySize
        {
            get { return (string)this["BABYSIZE"]; }
            set { this["BABYSIZE"] = value; }
        }

    /// <summary>
    /// Bebek Kilo
    /// </summary>
        public int? BabyWeight
        {
            get { return (int?)this["BABYWEIGHT"]; }
            set { this["BABYWEIGHT"] = value; }
        }

    /// <summary>
    /// Fötal Kalp Atımı
    /// </summary>
        public int? FKA
        {
            get { return (int?)this["FKA"]; }
            set { this["FKA"] = value; }
        }

        public PregnancyFollow PregnancyFollow
        {
            get { return (PregnancyFollow)((ITTObject)this).GetParent("PREGNANCYFOLLOW"); }
            set { this["PREGNANCYFOLLOW"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FetusFollow(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FetusFollow(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FetusFollow(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FetusFollow(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FetusFollow(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FETUSFOLLOW", dataRow) { }
        protected FetusFollow(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FETUSFOLLOW", dataRow, isImported) { }
        public FetusFollow(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FetusFollow(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FetusFollow() : base() { }

    }
}