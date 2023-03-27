
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GrantMaterial")] 

    /// <summary>
    /// Bağış Yardım
    /// </summary>
    public  partial class GrantMaterial : BaseChattelDocument, IGrantMaterial, IAutoDocumentRecordLog, IAutoDocumentNumber, ICheckStockActionInDetail, IStockInTransaction
    {
        public class GrantMaterialList : TTObjectCollection<GrantMaterial> { }
                    
        public class ChildGrantMaterialCollection : TTObject.TTChildObjectCollection<GrantMaterial>
        {
            public ChildGrantMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGrantMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Approved { get { return new Guid("501408a0-0330-4d29-87cc-a9acc4f4d17b"); } }
            public static Guid Cancelled { get { return new Guid("02ecd264-6cdd-4477-920b-31412e8ecca0"); } }
            public static Guid Completed { get { return new Guid("9ac96847-7b24-40dd-bf0d-5672657706ac"); } }
            public static Guid New { get { return new Guid("35638775-2a60-4c46-9faa-96e8ea55f3b6"); } }
        }

    /// <summary>
    /// Bağış Yapan TC / Kurum Vergi No
    /// </summary>
        public string GranttedByUniqNo
        {
            get { return (string)this["GRANTTEDBYUNIQNO"]; }
            set { this["GRANTTEDBYUNIQNO"] = value; }
        }

    /// <summary>
    /// Bağış Yapan Kişi / Kurum
    /// </summary>
        public string MaterialGranttedBy
        {
            get { return (string)this["MATERIALGRANTTEDBY"]; }
            set { this["MATERIALGRANTTEDBY"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _GrantMaterialDetails = new GrantMaterialDetail.ChildGrantMaterialDetailCollection(_StockActionDetails, "GrantMaterialDetails");
        }

        private GrantMaterialDetail.ChildGrantMaterialDetailCollection _GrantMaterialDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public GrantMaterialDetail.ChildGrantMaterialDetailCollection GrantMaterialDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _GrantMaterialDetails;
            }            
        }

        protected GrantMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GrantMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GrantMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GrantMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GrantMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GRANTMATERIAL", dataRow) { }
        protected GrantMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GRANTMATERIAL", dataRow, isImported) { }
        public GrantMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GrantMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GrantMaterial() : base() { }

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