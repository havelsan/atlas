
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KronikHastaliklarVeriSeti")] 

    /// <summary>
    /// Kronik Hastalıklar Veri Seti
    /// </summary>
    public  partial class KronikHastaliklarVeriSeti : ENabiz
    {
        public class KronikHastaliklarVeriSetiList : TTObjectCollection<KronikHastaliklarVeriSeti> { }
                    
        public class ChildKronikHastaliklarVeriSetiCollection : TTObject.TTChildObjectCollection<KronikHastaliklarVeriSeti>
        {
            public ChildKronikHastaliklarVeriSetiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKronikHastaliklarVeriSetiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// İlk Tanı Tarihi
    /// </summary>
        public DateTime? IlkTaniTarihi
        {
            get { return (DateTime?)this["ILKTANITARIHI"]; }
            set { this["ILKTANITARIHI"] = value; }
        }

    /// <summary>
    /// Pakete Ait İşlem Zamanı
    /// </summary>
        public DateTime? PaketeAitIslemZamani
        {
            get { return (DateTime?)this["PAKETEAITISLEMZAMANI"]; }
            set { this["PAKETEAITISLEMZAMANI"] = value; }
        }

        public SKRSSpirometri SKRSSpirometri
        {
            get { return (SKRSSpirometri)((ITTObject)this).GetParent("SKRSSPIROMETRI"); }
            set { this["SKRSSPIROMETRI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KronikHastaliklarVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KronikHastaliklarVeriSeti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KronikHastaliklarVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KronikHastaliklarVeriSeti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KronikHastaliklarVeriSeti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KRONIKHASTALIKLARVERISETI", dataRow) { }
        protected KronikHastaliklarVeriSeti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KRONIKHASTALIKLARVERISETI", dataRow, isImported) { }
        public KronikHastaliklarVeriSeti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KronikHastaliklarVeriSeti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KronikHastaliklarVeriSeti() : base() { }

    }
}