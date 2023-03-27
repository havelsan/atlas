
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BreastBiopsy")] 

    /// <summary>
    /// Meme Biyopsi
    /// </summary>
    public  partial class BreastBiopsy : TTObject
    {
        public class BreastBiopsyList : TTObjectCollection<BreastBiopsy> { }
                    
        public class ChildBreastBiopsyCollection : TTObject.TTChildObjectCollection<BreastBiopsy>
        {
            public ChildBreastBiopsyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBreastBiopsyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public CancerScreening CancerScreening
        {
            get { return (CancerScreening)((ITTObject)this).GetParent("CANCERSCREENING"); }
            set { this["CANCERSCREENING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMemeBiyopsiSonucu SKRSMemeBiyopsiSonucu
        {
            get { return (SKRSMemeBiyopsiSonucu)((ITTObject)this).GetParent("SKRSMEMEBIYOPSISONUCU"); }
            set { this["SKRSMEMEBIYOPSISONUCU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSMemedenBiyopsiAlimi SKRSMemedenBiyopsiAlimi
        {
            get { return (SKRSMemedenBiyopsiAlimi)((ITTObject)this).GetParent("SKRSMEMEDENBIYOPSIALIMI"); }
            set { this["SKRSMEMEDENBIYOPSIALIMI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BreastBiopsy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BreastBiopsy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BreastBiopsy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BreastBiopsy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BreastBiopsy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BREASTBIOPSY", dataRow) { }
        protected BreastBiopsy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BREASTBIOPSY", dataRow, isImported) { }
        public BreastBiopsy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BreastBiopsy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BreastBiopsy() : base() { }

    }
}