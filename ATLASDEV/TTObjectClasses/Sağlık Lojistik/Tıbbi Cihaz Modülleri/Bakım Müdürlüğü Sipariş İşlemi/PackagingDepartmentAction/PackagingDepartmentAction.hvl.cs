
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackagingDepartmentAction")] 

    /// <summary>
    /// Ambalajlama İş İstek
    /// </summary>
    public  partial class PackagingDepartmentAction : CMRAction
    {
        public class PackagingDepartmentActionList : TTObjectCollection<PackagingDepartmentAction> { }
                    
        public class ChildPackagingDepartmentActionCollection : TTObject.TTChildObjectCollection<PackagingDepartmentAction>
        {
            public ChildPackagingDepartmentActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackagingDepartmentActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("a08294e3-7a16-420d-beaf-fdb9b27819ce"); } }
    /// <summary>
    /// Marangozhane
    /// </summary>
            public static Guid Carpenter { get { return new Guid("8a32ed94-3d38-40fc-b0f9-91b47d15b9e9"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("df7c642a-d6ae-48e1-8be1-cbaced5c6d7a"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("92ed5462-28ef-43a3-bac5-0dec47bb6b7b"); } }
        }

        public static BindingList<PackagingDepartmentAction> GetPackagingDepartmentAction(TTObjectContext objectContext, Guid MAINTENANCEORDERID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGINGDEPARTMENTACTION"].QueryDefs["GetPackagingDepartmentAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MAINTENANCEORDERID", MAINTENANCEORDERID);

            return ((ITTQuery)objectContext).QueryObjects<PackagingDepartmentAction>(queryDef, paramList);
        }

        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePackagingDepConsMaterialsCollection()
        {
            _PackagingDepConsMaterials = new PackagingDepConsMaterial.ChildPackagingDepConsMaterialCollection(this, new Guid("5a729058-b90d-47e2-b680-297052209e67"));
            ((ITTChildObjectCollection)_PackagingDepConsMaterials).GetChildren();
        }

        protected PackagingDepConsMaterial.ChildPackagingDepConsMaterialCollection _PackagingDepConsMaterials = null;
        public PackagingDepConsMaterial.ChildPackagingDepConsMaterialCollection PackagingDepConsMaterials
        {
            get
            {
                if (_PackagingDepConsMaterials == null)
                    CreatePackagingDepConsMaterialsCollection();
                return _PackagingDepConsMaterials;
            }
        }

        virtual protected void CreateUsedConsumedMaterailsCollection()
        {
            _UsedConsumedMaterails = new UsedConsumedMaterail.ChildUsedConsumedMaterailCollection(this, new Guid("d6675143-22f4-4ca5-89d0-a4062246cfa2"));
            ((ITTChildObjectCollection)_UsedConsumedMaterails).GetChildren();
        }

        protected UsedConsumedMaterail.ChildUsedConsumedMaterailCollection _UsedConsumedMaterails = null;
        public UsedConsumedMaterail.ChildUsedConsumedMaterailCollection UsedConsumedMaterails
        {
            get
            {
                if (_UsedConsumedMaterails == null)
                    CreateUsedConsumedMaterailsCollection();
                return _UsedConsumedMaterails;
            }
        }

        protected PackagingDepartmentAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackagingDepartmentAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackagingDepartmentAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackagingDepartmentAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackagingDepartmentAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGINGDEPARTMENTACTION", dataRow) { }
        protected PackagingDepartmentAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGINGDEPARTMENTACTION", dataRow, isImported) { }
        public PackagingDepartmentAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackagingDepartmentAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackagingDepartmentAction() : base() { }

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