
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IBFDet_SparePartOut")] 

    /// <summary>
    /// İBF Detay kalemi - Yedek parça malzemeleri için kullanılan sınıftır. (İBF listesi harici)
    /// </summary>
    public  partial class IBFDet_SparePartOut : IBFDetDetailOut
    {
        public class IBFDet_SparePartOutList : TTObjectCollection<IBFDet_SparePartOut> { }
                    
        public class ChildIBFDet_SparePartOutCollection : TTObject.TTChildObjectCollection<IBFDet_SparePartOut>
        {
            public ChildIBFDet_SparePartOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIBFDet_SparePartOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("28662ca0-6fd6-4a8f-8cd9-3dc69151b79f"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("bae6c84c-c920-41b2-9136-221e13a8b558"); } }
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

        protected IBFDet_SparePartOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IBFDet_SparePartOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IBFDet_SparePartOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IBFDet_SparePartOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IBFDet_SparePartOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IBFDET_SPAREPARTOUT", dataRow) { }
        protected IBFDet_SparePartOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IBFDET_SPAREPARTOUT", dataRow, isImported) { }
        public IBFDet_SparePartOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IBFDet_SparePartOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IBFDet_SparePartOut() : base() { }

    }
}