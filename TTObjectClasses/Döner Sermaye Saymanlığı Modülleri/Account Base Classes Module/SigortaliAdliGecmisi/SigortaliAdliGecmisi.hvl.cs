
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SigortaliAdliGecmisi")] 

    /// <summary>
    /// Sigortalı Adli Geçmişi
    /// </summary>
    public  partial class SigortaliAdliGecmisi : TTObject
    {
        public class SigortaliAdliGecmisiList : TTObjectCollection<SigortaliAdliGecmisi> { }
                    
        public class ChildSigortaliAdliGecmisiCollection : TTObject.TTChildObjectCollection<SigortaliAdliGecmisi>
        {
            public ChildSigortaliAdliGecmisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSigortaliAdliGecmisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Hasta TC Kimlik No
    /// </summary>
        public string tckNo
        {
            get { return (string)this["TCKNO"]; }
            set { this["TCKNO"] = value; }
        }

    /// <summary>
    /// Provizyon Tipi
    /// </summary>
        public string provTipi
        {
            get { return (string)this["PROVTIPI"]; }
            set { this["PROVTIPI"] = value; }
        }

    /// <summary>
    /// Provizyon Tarihi
    /// </summary>
        public string provTarihi
        {
            get { return (string)this["PROVTARIHI"]; }
            set { this["PROVTARIHI"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SigortaliAdliGecmisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SigortaliAdliGecmisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SigortaliAdliGecmisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SigortaliAdliGecmisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SigortaliAdliGecmisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SIGORTALIADLIGECMISI", dataRow) { }
        protected SigortaliAdliGecmisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SIGORTALIADLIGECMISI", dataRow, isImported) { }
        public SigortaliAdliGecmisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SigortaliAdliGecmisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SigortaliAdliGecmisi() : base() { }

    }
}