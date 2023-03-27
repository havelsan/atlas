
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDataCorrection")] 

    /// <summary>
    /// Demirbaş Durumu Değiştirme
    /// </summary>
    public  partial class FixedAssetDataCorrection : BaseDataCorrection, IWorkListBaseAction
    {
        public class FixedAssetDataCorrectionList : TTObjectCollection<FixedAssetDataCorrection> { }
                    
        public class ChildFixedAssetDataCorrectionCollection : TTObject.TTChildObjectCollection<FixedAssetDataCorrection>
        {
            public ChildFixedAssetDataCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDataCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("0b680345-4262-411e-8d2b-57bedce4914e"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("75605ba2-a40e-476a-880c-d4f7694fa6aa"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("fe8bf84d-2a64-45a1-bd2f-5b30361525e2"); } }
        }

    /// <summary>
    /// Yeni Anlık Bakım Onarım Durumu
    /// </summary>
        public FixedAssetCMRStatusEnum? NewCMRStatus
        {
            get { return (FixedAssetCMRStatusEnum?)(int?)this["NEWCMRSTATUS"]; }
            set { this["NEWCMRSTATUS"] = value; }
        }

    /// <summary>
    /// Eski Anlık Bakım Onarım Durumu
    /// </summary>
        public FixedAssetCMRStatusEnum? OldCMRStatus
        {
            get { return (FixedAssetCMRStatusEnum?)(int?)this["OLDCMRSTATUS"]; }
            set { this["OLDCMRSTATUS"] = value; }
        }

        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDataCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDataCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDataCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDATACORRECTION", dataRow) { }
        protected FixedAssetDataCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDATACORRECTION", dataRow, isImported) { }
        public FixedAssetDataCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDataCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDataCorrection() : base() { }

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