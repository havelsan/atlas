
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KadinaYonelikSiddetVeriSet")] 

    public  partial class KadinaYonelikSiddetVeriSet : ENabiz
    {
        public class KadinaYonelikSiddetVeriSetList : TTObjectCollection<KadinaYonelikSiddetVeriSet> { }
                    
        public class ChildKadinaYonelikSiddetVeriSetCollection : TTObject.TTChildObjectCollection<KadinaYonelikSiddetVeriSet>
        {
            public ChildKadinaYonelikSiddetVeriSetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKadinaYonelikSiddetVeriSetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateKadinaYonelikSiddetSonucCollection()
        {
            _KadinaYonelikSiddetSonuc = new KadinaYonelikSiddetSonuc.ChildKadinaYonelikSiddetSonucCollection(this, new Guid("f872250d-8d2c-4714-942f-d4274a043d8a"));
            ((ITTChildObjectCollection)_KadinaYonelikSiddetSonuc).GetChildren();
        }

        protected KadinaYonelikSiddetSonuc.ChildKadinaYonelikSiddetSonucCollection _KadinaYonelikSiddetSonuc = null;
        public KadinaYonelikSiddetSonuc.ChildKadinaYonelikSiddetSonucCollection KadinaYonelikSiddetSonuc
        {
            get
            {
                if (_KadinaYonelikSiddetSonuc == null)
                    CreateKadinaYonelikSiddetSonucCollection();
                return _KadinaYonelikSiddetSonuc;
            }
        }

        virtual protected void CreateKadinaYonelikSiddetTuruCollection()
        {
            _KadinaYonelikSiddetTuru = new KadinaYonelikSiddetTuru.ChildKadinaYonelikSiddetTuruCollection(this, new Guid("07801761-cfb4-4c88-b065-a5532a7f3ee7"));
            ((ITTChildObjectCollection)_KadinaYonelikSiddetTuru).GetChildren();
        }

        protected KadinaYonelikSiddetTuru.ChildKadinaYonelikSiddetTuruCollection _KadinaYonelikSiddetTuru = null;
        public KadinaYonelikSiddetTuru.ChildKadinaYonelikSiddetTuruCollection KadinaYonelikSiddetTuru
        {
            get
            {
                if (_KadinaYonelikSiddetTuru == null)
                    CreateKadinaYonelikSiddetTuruCollection();
                return _KadinaYonelikSiddetTuru;
            }
        }

        protected KadinaYonelikSiddetVeriSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KadinaYonelikSiddetVeriSet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KadinaYonelikSiddetVeriSet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KadinaYonelikSiddetVeriSet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KadinaYonelikSiddetVeriSet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KADINAYONELIKSIDDETVERISET", dataRow) { }
        protected KadinaYonelikSiddetVeriSet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KADINAYONELIKSIDDETVERISET", dataRow, isImported) { }
        public KadinaYonelikSiddetVeriSet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KadinaYonelikSiddetVeriSet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KadinaYonelikSiddetVeriSet() : base() { }

    }
}