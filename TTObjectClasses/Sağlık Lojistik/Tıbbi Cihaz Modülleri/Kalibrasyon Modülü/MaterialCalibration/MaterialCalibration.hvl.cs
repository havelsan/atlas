
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialCalibration")] 

    /// <summary>
    /// Kalibrasyon [Stok Numaralı]
    /// </summary>
    public  partial class MaterialCalibration : Calibration
    {
        public class MaterialCalibrationList : TTObjectCollection<MaterialCalibration> { }
                    
        public class ChildMaterialCalibrationCollection : TTObject.TTChildObjectCollection<MaterialCalibration>
        {
            public ChildMaterialCalibrationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialCalibrationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Kalibrasyon
    /// </summary>
            public static Guid Calibration { get { return new Guid("73d3d15a-c9f2-4296-80b8-50feae3da3fc"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f2457a01-16d9-43fe-99a5-a955a862d571"); } }
    /// <summary>
    /// Amir Onayı
    /// </summary>
            public static Guid ChiefApproval { get { return new Guid("ac6e5642-9ea0-4fa5-a32e-75dedc2edf8d"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("eecb1d7d-9636-4777-bf71-dd08824e05a8"); } }
    /// <summary>
    /// Hizmet Alımı
    /// </summary>
            public static Guid FirmCalibration { get { return new Guid("821eebb5-735d-49f8-a5d4-9850a44506c1"); } }
    /// <summary>
    /// İstek Onay
    /// </summary>
            public static Guid ForkNew { get { return new Guid("c16c2681-e446-4de9-be7c-743baf78aef6"); } }
    /// <summary>
    /// Malzeme Temin
    /// </summary>
            public static Guid SupplyOfMaterials { get { return new Guid("27197d24-4405-4d5d-8149-f6c3fb5f1ac7"); } }
    /// <summary>
    /// Onarıma Gönderildi
    /// </summary>
            public static Guid ToRepair { get { return new Guid("1e951cda-bf35-4cf6-9bc0-f0d6b41c06cb"); } }
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

        protected MaterialCalibration(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialCalibration(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialCalibration(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialCalibration(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialCalibration(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALCALIBRATION", dataRow) { }
        protected MaterialCalibration(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALCALIBRATION", dataRow, isImported) { }
        public MaterialCalibration(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialCalibration(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialCalibration() : base() { }

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