
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KadinaYonelikSiddetTuru")] 

    /// <summary>
    /// Kadına Yönelik Şiddet Veri Seti - Şiddet Türü
    /// </summary>
    public  partial class KadinaYonelikSiddetTuru : TTObject
    {
        public class KadinaYonelikSiddetTuruList : TTObjectCollection<KadinaYonelikSiddetTuru> { }
                    
        public class ChildKadinaYonelikSiddetTuruCollection : TTObject.TTChildObjectCollection<KadinaYonelikSiddetTuru>
        {
            public ChildKadinaYonelikSiddetTuruCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKadinaYonelikSiddetTuruCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public SKRSSiddetTuru SKRSSiddetTuru
        {
            get { return (SKRSSiddetTuru)((ITTObject)this).GetParent("SKRSSIDDETTURU"); }
            set { this["SKRSSIDDETTURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KadinaYonelikSiddetVeriSet KadinaYonelikSiddetVeriSet
        {
            get { return (KadinaYonelikSiddetVeriSet)((ITTObject)this).GetParent("KADINAYONELIKSIDDETVERISET"); }
            set { this["KADINAYONELIKSIDDETVERISET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KadinaYonelikSiddetTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KadinaYonelikSiddetTuru(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KadinaYonelikSiddetTuru(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KadinaYonelikSiddetTuru(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KadinaYonelikSiddetTuru(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KADINAYONELIKSIDDETTURU", dataRow) { }
        protected KadinaYonelikSiddetTuru(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KADINAYONELIKSIDDETTURU", dataRow, isImported) { }
        public KadinaYonelikSiddetTuru(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KadinaYonelikSiddetTuru(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KadinaYonelikSiddetTuru() : base() { }

    }
}