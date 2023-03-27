
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Fiyat")] 

    public  partial class Fiyat : TTObject
    {
        public class FiyatList : TTObjectCollection<Fiyat> { }
                    
        public class ChildFiyatCollection : TTObject.TTChildObjectCollection<Fiyat>
        {
            public ChildFiyatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFiyatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlaç fiyat bilgisi
    /// </summary>
        public double? fiyat
        {
            get { return (double?)this["FIYAT"]; }
            set { this["FIYAT"] = value; }
        }

    /// <summary>
    /// İlaç geçerlilik tarihi
    /// </summary>
        public string gecerlilikTarihi
        {
            get { return (string)this["GECERLILIKTARIHI"]; }
            set { this["GECERLILIKTARIHI"] = value; }
        }

        public DateTime? ValidityDate
        {
            get { return (DateTime?)this["VALIDITYDATE"]; }
            set { this["VALIDITYDATE"] = value; }
        }

    /// <summary>
    /// İlaç-İlaç fiyat bilgisi
    /// </summary>
        public Ilac ilac
        {
            get { return (Ilac)((ITTObject)this).GetParent("ILAC"); }
            set { this["ILAC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Fiyat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Fiyat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Fiyat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Fiyat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Fiyat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIYAT", dataRow) { }
        protected Fiyat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIYAT", dataRow, isImported) { }
        public Fiyat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Fiyat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Fiyat() : base() { }

    }
}