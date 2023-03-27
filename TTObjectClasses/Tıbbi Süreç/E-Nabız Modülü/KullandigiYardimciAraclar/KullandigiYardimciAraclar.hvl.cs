
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KullandigiYardimciAraclar")] 

    /// <summary>
    /// Kullandığı Yardımcı araçlar Bilgisi
    /// </summary>
    public  partial class KullandigiYardimciAraclar : TTObject
    {
        public class KullandigiYardimciAraclarList : TTObjectCollection<KullandigiYardimciAraclar> { }
                    
        public class ChildKullandigiYardimciAraclarCollection : TTObject.TTChildObjectCollection<KullandigiYardimciAraclar>
        {
            public ChildKullandigiYardimciAraclarCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKullandigiYardimciAraclarCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public EvdeSaglikIlkIzlemVeriSeti EvdeSaglikIlkIzlemVeriSeti
        {
            get { return (EvdeSaglikIlkIzlemVeriSeti)((ITTObject)this).GetParent("EVDESAGLIKILKIZLEMVERISETI"); }
            set { this["EVDESAGLIKILKIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKullandigiYardimciAraclar SKRSKullandigiYardimciAraclar
        {
            get { return (SKRSKullandigiYardimciAraclar)((ITTObject)this).GetParent("SKRSKULLANDIGIYARDIMCIARACLAR"); }
            set { this["SKRSKULLANDIGIYARDIMCIARACLAR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KullandigiYardimciAraclar(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KullandigiYardimciAraclar(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KULLANDIGIYARDIMCIARACLAR", dataRow) { }
        protected KullandigiYardimciAraclar(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KULLANDIGIYARDIMCIARACLAR", dataRow, isImported) { }
        public KullandigiYardimciAraclar(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KullandigiYardimciAraclar(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KullandigiYardimciAraclar() : base() { }

    }
}