
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OlayAfetBilgisi")] 

    public  partial class OlayAfetBilgisi : ENabiz
    {
        public class OlayAfetBilgisiList : TTObjectCollection<OlayAfetBilgisi> { }
                    
        public class ChildOlayAfetBilgisiCollection : TTObject.TTChildObjectCollection<OlayAfetBilgisi>
        {
            public ChildOlayAfetBilgisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOlayAfetBilgisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public int? GlasgowKomaSkalasi
        {
            get { return (int?)this["GLASGOWKOMASKALASI"]; }
            set { this["GLASGOWKOMASKALASI"] = value; }
        }

        public SKRSAFETOLAYVATANDASTIPI SKRSAFETOLAYVATANDASTIPI
        {
            get { return (SKRSAFETOLAYVATANDASTIPI)((ITTObject)this).GetParent("SKRSAFETOLAYVATANDASTIPI"); }
            set { this["SKRSAFETOLAYVATANDASTIPI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSOlayAfetBilgisi SKRSOlayAfetBilgisi
        {
            get { return (SKRSOlayAfetBilgisi)((ITTObject)this).GetParent("SKRSOLAYAFETBILGISI"); }
            set { this["SKRSOLAYAFETBILGISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSHayatiTehlikeDurumu SKRSHayatiTehlikeDurumu
        {
            get { return (SKRSHayatiTehlikeDurumu)((ITTObject)this).GetParent("SKRSHAYATITEHLIKEDURUMU"); }
            set { this["SKRSHAYATITEHLIKEDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OlayAfetBilgisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OlayAfetBilgisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "OLAYAFETBILGISI", dataRow) { }
        protected OlayAfetBilgisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "OLAYAFETBILGISI", dataRow, isImported) { }
        public OlayAfetBilgisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OlayAfetBilgisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OlayAfetBilgisi() : base() { }

    }
}