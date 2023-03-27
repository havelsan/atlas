
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VerilenEgitimler")] 

    /// <summary>
    /// Verilen Eğitimler Bilgisi
    /// </summary>
    public  partial class VerilenEgitimler : TTObject
    {
        public class VerilenEgitimlerList : TTObjectCollection<VerilenEgitimler> { }
                    
        public class ChildVerilenEgitimlerCollection : TTObject.TTChildObjectCollection<VerilenEgitimler>
        {
            public ChildVerilenEgitimlerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVerilenEgitimlerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public EvdeSaglikIzlemVeriSeti EvdeSaglikIzlemVeriSeti
        {
            get { return (EvdeSaglikIzlemVeriSeti)((ITTObject)this).GetParent("EVDESAGLIKIZLEMVERISETI"); }
            set { this["EVDESAGLIKIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EvdeSaglikIlkIzlemVeriSeti EvdeSaglikIlkIzlemVeriSeti
        {
            get { return (EvdeSaglikIlkIzlemVeriSeti)((ITTObject)this).GetParent("EVDESAGLIKILKIZLEMVERISETI"); }
            set { this["EVDESAGLIKILKIZLEMVERISETI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSVerilenEgitimler SKRSVerilenEgitimler
        {
            get { return (SKRSVerilenEgitimler)((ITTObject)this).GetParent("SKRSVERILENEGITIMLER"); }
            set { this["SKRSVERILENEGITIMLER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected VerilenEgitimler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VerilenEgitimler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VerilenEgitimler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VerilenEgitimler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VerilenEgitimler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VERILENEGITIMLER", dataRow) { }
        protected VerilenEgitimler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VERILENEGITIMLER", dataRow, isImported) { }
        public VerilenEgitimler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VerilenEgitimler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VerilenEgitimler() : base() { }

    }
}