
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialStabilityAction")] 

    /// <summary>
    /// Malzeme Muvazene İstek
    /// </summary>
    public  partial class MaterialStabilityAction : BaseCentralAction
    {
        public class MaterialStabilityActionList : TTObjectCollection<MaterialStabilityAction> { }
                    
        public class ChildMaterialStabilityActionCollection : TTObject.TTChildObjectCollection<MaterialStabilityAction>
        {
            public ChildMaterialStabilityActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialStabilityActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMaterialStabilityAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMaterialStabilityAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaterialStabilityAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaterialStabilityAction_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Muvazene Oluştur
    /// </summary>
            public static Guid CreateStability { get { return new Guid("dc1ca5e7-e0e7-4ffc-8ef6-571125f2ede4"); } }
    /// <summary>
    /// Muvazene İstek
    /// </summary>
            public static Guid RequestStability { get { return new Guid("6c28396d-b7e3-46c7-912e-f568df56781a"); } }
    /// <summary>
    /// Muvazene İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ae5980a1-281f-44f1-a1d7-79f5ef4f305b"); } }
    /// <summary>
    /// Muvazene Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("e9320c71-7762-4922-922b-91f772603eb8"); } }
    /// <summary>
    /// Merkez İstek
    /// </summary>
            public static Guid Request { get { return new Guid("f9bedefa-7b48-4be8-bef6-5090c00236c9"); } }
        }

        public static BindingList<MaterialStabilityAction.GetMaterialStabilityAction_Class> GetMaterialStabilityAction(DateTime ENDDATE, DateTime STARTDATE, Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALSTABILITYACTION"].QueryDefs["GetMaterialStabilityAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<MaterialStabilityAction.GetMaterialStabilityAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaterialStabilityAction.GetMaterialStabilityAction_Class> GetMaterialStabilityAction(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid MATERIAL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALSTABILITYACTION"].QueryDefs["GetMaterialStabilityAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("MATERIAL", MATERIAL);

            return TTReportNqlObject.QueryObjects<MaterialStabilityAction.GetMaterialStabilityAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public Guid? MainStoreID
        {
            get { return (Guid?)this["MAINSTOREID"]; }
            set { this["MAINSTOREID"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy SendingAccountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("SENDINGACCOUNTANCY"); }
            set { this["SENDINGACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy ReceiveAccountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("RECEIVEACCOUNTANCY"); }
            set { this["RECEIVEACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialStabilityAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialStabilityAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialStabilityAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialStabilityAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialStabilityAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALSTABILITYACTION", dataRow) { }
        protected MaterialStabilityAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALSTABILITYACTION", dataRow, isImported) { }
        public MaterialStabilityAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialStabilityAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialStabilityAction() : base() { }

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