
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialMaintenance")] 

    /// <summary>
    /// Bakım[Stok Numaralı]
    /// </summary>
    public  partial class MaterialMaintenance : Maintenance
    {
        public class MaterialMaintenanceList : TTObjectCollection<MaterialMaintenance> { }
                    
        public class ChildMaterialMaintenanceCollection : TTObject.TTChildObjectCollection<MaterialMaintenance>
        {
            public ChildMaterialMaintenanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialMaintenanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
            public static Guid Calibration { get { return new Guid("2e704943-820d-4bfd-af4c-5b046a749db8"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("15ec1ddd-ebf7-4460-bfc4-89a8330b0c50"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("e63547a7-4a0b-4c06-b289-26773e640af2"); } }
    /// <summary>
    /// İstek Onay
    /// </summary>
            public static Guid ForkNew { get { return new Guid("a2332aad-742a-4fb4-82e4-e42318b5ff96"); } }
    /// <summary>
    /// Bakım
    /// </summary>
            public static Guid Maintenance { get { return new Guid("adc1e690-4ec9-4607-abe1-802666e3b541"); } }
    /// <summary>
    /// Onarım
    /// </summary>
            public static Guid Repair { get { return new Guid("e0143468-ac76-4453-b45c-c3588591681d"); } }
        }

    /// <summary>
    /// Malzeme Sayısı
    /// </summary>
        public double? FixedAssetMaterialAmount
        {
            get { return (double?)this["FIXEDASSETMATERIALAMOUNT"]; }
            set { this["FIXEDASSETMATERIALAMOUNT"] = value; }
        }

    /// <summary>
    /// Yapılacak İşlem
    /// </summary>
        public string FixedAssetMaterialDesc
        {
            get { return (string)this["FIXEDASSETMATERIALDESC"]; }
            set { this["FIXEDASSETMATERIALDESC"] = value; }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialMaintenance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialMaintenance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialMaintenance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialMaintenance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialMaintenance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALMAINTENANCE", dataRow) { }
        protected MaterialMaintenance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALMAINTENANCE", dataRow, isImported) { }
        public MaterialMaintenance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialMaintenance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialMaintenance() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}