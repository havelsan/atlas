
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MKYSKod")] 

    /// <summary>
    /// MKYS Kod Listesi
    /// </summary>
    public  partial class MKYSKod : TerminologyManagerDef
    {
        public class MKYSKodList : TTObjectCollection<MKYSKod> { }
                    
        public class ChildMKYSKodCollection : TTObject.TTChildObjectCollection<MKYSKod>
        {
            public ChildMKYSKodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMKYSKodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kod Adı
    /// </summary>
        public string KodAdi
        {
            get { return (string)this["KODADI"]; }
            set { this["KODADI"] = value; }
        }

    /// <summary>
    /// Kod Değeri
    /// </summary>
        public string Degeri
        {
            get { return (string)this["DEGERI"]; }
            set { this["DEGERI"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

    /// <summary>
    /// Enum Numarası
    /// </summary>
        public int? EnumNo
        {
            get { return (int?)this["ENUMNO"]; }
            set { this["ENUMNO"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Aktif
        {
            get { return (bool?)this["AKTIF"]; }
            set { this["AKTIF"] = value; }
        }

        protected MKYSKod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MKYSKod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MKYSKod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MKYSKod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MKYSKod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MKYSKOD", dataRow) { }
        protected MKYSKod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MKYSKOD", dataRow, isImported) { }
        public MKYSKod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MKYSKod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MKYSKod() : base() { }

    }
}