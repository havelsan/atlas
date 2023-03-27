
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LBD_SpareIn")] 

    /// <summary>
    /// Lojistik İkmal Faaliyetleri Detay kalemi - Yedek parça malzemeleri için kullanılan sınıftır. (Lojistik İkmal Faaliyetleri listesi dahili)
    /// </summary>
    public  partial class LBD_SpareIn : LBPurchaseProjectDetailInList
    {
        public class LBD_SpareInList : TTObjectCollection<LBD_SpareIn> { }
                    
        public class ChildLBD_SpareInCollection : TTObject.TTChildObjectCollection<LBD_SpareIn>
        {
            public ChildLBD_SpareInCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLBD_SpareInCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("222ab4a0-5000-455c-9023-3630b0c02766"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fcfa3d5d-5780-4b74-8f6e-7b3188e52e8a"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("cccf7119-49f4-4a37-9b44-de0b674ac4ff"); } }
        }

    /// <summary>
    /// Yedek Parça
    /// </summary>
        public string DependentSpare
        {
            get { return (string)this["DEPENDENTSPARE"]; }
            set { this["DEPENDENTSPARE"] = value; }
        }

    /// <summary>
    /// Tedarik Amacı
    /// </summary>
        public string Purpose
        {
            get { return (string)this["PURPOSE"]; }
            set { this["PURPOSE"] = value; }
        }

        protected LBD_SpareIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LBD_SpareIn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LBD_SpareIn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LBD_SpareIn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LBD_SpareIn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LBD_SPAREIN", dataRow) { }
        protected LBD_SpareIn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LBD_SPAREIN", dataRow, isImported) { }
        public LBD_SpareIn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LBD_SpareIn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LBD_SpareIn() : base() { }

    }
}