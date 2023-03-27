
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialVatRate")] 

    /// <summary>
    /// Malzemenin KDV bilgilerini tutan sınıftır
    /// </summary>
    public  partial class MaterialVatRate : TerminologyManagerDef
    {
        public class MaterialVatRateList : TTObjectCollection<MaterialVatRate> { }
                    
        public class ChildMaterialVatRateCollection : TTObject.TTChildObjectCollection<MaterialVatRate>
        {
            public ChildMaterialVatRateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialVatRateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// KDV Oranı
    /// </summary>
        public long? VatRate
        {
            get { return (long?)this["VATRATE"]; }
            set { this["VATRATE"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialVatRate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialVatRate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialVatRate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialVatRate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialVatRate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALVATRATE", dataRow) { }
        protected MaterialVatRate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALVATRATE", dataRow, isImported) { }
        public MaterialVatRate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialVatRate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialVatRate() : base() { }

    }
}