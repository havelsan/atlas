
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TreatmentMaterialShadow")] 

    /// <summary>
    /// Malzeme Sarf(Dış XXXXXX Konsültasyon)
    /// </summary>
    public  partial class TreatmentMaterialShadow : TTObject
    {
        public class TreatmentMaterialShadowList : TTObjectCollection<TreatmentMaterialShadow> { }
                    
        public class ChildTreatmentMaterialShadowCollection : TTObject.TTChildObjectCollection<TreatmentMaterialShadow>
        {
            public ChildTreatmentMaterialShadowCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTreatmentMaterialShadowCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Sarf Edilen Malzeme Adı
    /// </summary>
        public string TreatmentMaterialName
        {
            get { return (string)this["TREATMENTMATERIALNAME"]; }
            set { this["TREATMENTMATERIALNAME"] = value; }
        }

    /// <summary>
    /// Sarf Edilen Malzeme Miktarı
    /// </summary>
        public string TreatmentMaterialAmount
        {
            get { return (string)this["TREATMENTMATERIALAMOUNT"]; }
            set { this["TREATMENTMATERIALAMOUNT"] = value; }
        }

    /// <summary>
    /// Malzeme Sarf
    /// </summary>
        public ConsultationFromOtherHospital MaterialExpend
        {
            get { return (ConsultationFromOtherHospital)((ITTObject)this).GetParent("MATERIALEXPEND"); }
            set { this["MATERIALEXPEND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TreatmentMaterialShadow(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TreatmentMaterialShadow(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TreatmentMaterialShadow(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TreatmentMaterialShadow(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TreatmentMaterialShadow(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TREATMENTMATERIALSHADOW", dataRow) { }
        protected TreatmentMaterialShadow(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TREATMENTMATERIALSHADOW", dataRow, isImported) { }
        public TreatmentMaterialShadow(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TreatmentMaterialShadow(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TreatmentMaterialShadow() : base() { }

    }
}