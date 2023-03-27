
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSAsset")] 

    public  partial class MPBSAsset : TTObject
    {
        public class MPBSAssetList : TTObjectCollection<MPBSAsset> { }
                    
        public class ChildMPBSAssetCollection : TTObject.TTChildObjectCollection<MPBSAsset>
        {
            public ChildMPBSAssetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSAssetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Ait Olduğu Yıl
    /// </summary>
        public DateTime? Year
        {
            get { return (DateTime?)this["YEAR"]; }
            set { this["YEAR"] = value; }
        }

    /// <summary>
    /// Mal Bildirim Tarihi
    /// </summary>
        public DateTime? DeclerationDate
        {
            get { return (DateTime?)this["DECLERATIONDATE"]; }
            set { this["DECLERATIONDATE"] = value; }
        }

    /// <summary>
    /// Subay Astsubay
    /// </summary>
        public MPBSOfficerPettyOfficer OfficerPettyOfficer
        {
            get { return (MPBSOfficerPettyOfficer)((ITTObject)this).GetParent("OFFICERPETTYOFFICER"); }
            set { this["OFFICERPETTYOFFICER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSAsset(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSAsset(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSAsset(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSAsset(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSAsset(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSASSET", dataRow) { }
        protected MPBSAsset(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSASSET", dataRow, isImported) { }
        public MPBSAsset(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSAsset(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSAsset() : base() { }

    }
}