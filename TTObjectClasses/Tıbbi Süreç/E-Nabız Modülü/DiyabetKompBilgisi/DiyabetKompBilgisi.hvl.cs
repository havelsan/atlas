
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiyabetKompBilgisi")] 

    public  partial class DiyabetKompBilgisi : TTObject
    {
        public class DiyabetKompBilgisiList : TTObjectCollection<DiyabetKompBilgisi> { }
                    
        public class ChildDiyabetKompBilgisiCollection : TTObject.TTChildObjectCollection<DiyabetKompBilgisi>
        {
            public ChildDiyabetKompBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiyabetKompBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DiyabetVeriSeti DiyabetVeriSeti
        {
            get { return (DiyabetVeriSeti)((ITTObject)this).GetParent("DIYABETVERISETI"); }
            set { this["DIYABETVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSDiyabetKomplikasyonlari SKRSDiyabetKomplikasyonlari
        {
            get { return (SKRSDiyabetKomplikasyonlari)((ITTObject)this).GetParent("SKRSDIYABETKOMPLIKASYONLARI"); }
            set { this["SKRSDIYABETKOMPLIKASYONLARI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiyabetKompBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiyabetKompBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiyabetKompBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiyabetKompBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiyabetKompBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIYABETKOMPBILGISI", dataRow) { }
        protected DiyabetKompBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIYABETKOMPBILGISI", dataRow, isImported) { }
        public DiyabetKompBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiyabetKompBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiyabetKompBilgisi() : base() { }

    }
}