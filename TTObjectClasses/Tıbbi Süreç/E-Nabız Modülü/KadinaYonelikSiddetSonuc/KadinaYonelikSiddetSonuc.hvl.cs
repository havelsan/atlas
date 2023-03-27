
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KadinaYonelikSiddetSonuc")] 

    /// <summary>
    /// Kadına Yönelik Şiddet veri seti - şiddet sonucu yönlendirme ve değerlendirme
    /// </summary>
    public  partial class KadinaYonelikSiddetSonuc : TTObject
    {
        public class KadinaYonelikSiddetSonucList : TTObjectCollection<KadinaYonelikSiddetSonuc> { }
                    
        public class ChildKadinaYonelikSiddetSonucCollection : TTObject.TTChildObjectCollection<KadinaYonelikSiddetSonuc>
        {
            public ChildKadinaYonelikSiddetSonucCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKadinaYonelikSiddetSonucCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public KadinaYonelikSiddetVeriSet KadinaYonelikSiddetVeriSet
        {
            get { return (KadinaYonelikSiddetVeriSet)((ITTObject)this).GetParent("KADINAYONELIKSIDDETVERISET"); }
            set { this["KADINAYONELIKSIDDETVERISET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme SKRSYonlendirmeDegerlendirme
        {
            get { return (SKRSKadinaYonelikSiddetSonucuYonlendirmeveDegerlendirme)((ITTObject)this).GetParent("SKRSYONLENDIRMEDEGERLENDIRME"); }
            set { this["SKRSYONLENDIRMEDEGERLENDIRME"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KadinaYonelikSiddetSonuc(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KadinaYonelikSiddetSonuc(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KadinaYonelikSiddetSonuc(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KadinaYonelikSiddetSonuc(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KadinaYonelikSiddetSonuc(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KADINAYONELIKSIDDETSONUC", dataRow) { }
        protected KadinaYonelikSiddetSonuc(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KADINAYONELIKSIDDETSONUC", dataRow, isImported) { }
        public KadinaYonelikSiddetSonuc(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KadinaYonelikSiddetSonuc(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KadinaYonelikSiddetSonuc() : base() { }

    }
}