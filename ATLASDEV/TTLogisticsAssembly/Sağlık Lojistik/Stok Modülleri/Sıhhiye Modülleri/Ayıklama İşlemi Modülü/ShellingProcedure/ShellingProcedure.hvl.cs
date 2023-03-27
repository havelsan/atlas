
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ShellingProcedure")] 

    /// <summary>
    /// Ayıklama İşlemi için kullanılan temel sınıftır
    /// </summary>
    public  partial class ShellingProcedure : StockAction, IStockInTransaction, IStockOutTransaction
    {
        public class ShellingProcedureList : TTObjectCollection<ShellingProcedure> { }
                    
        public class ChildShellingProcedureCollection : TTObject.TTChildObjectCollection<ShellingProcedure>
        {
            public ChildShellingProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildShellingProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("6d32422c-0fb1-4d80-a57c-487936dc7c1b"); } }
            public static Guid Completed { get { return new Guid("6ac7599c-6837-499d-8097-87df606a7000"); } }
            public static Guid SortingClassification { get { return new Guid("79035086-1371-4c8c-bee1-9cc4b93ef475"); } }
            public static Guid New { get { return new Guid("e163527e-65e1-479b-9033-32328614a8c5"); } }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ShellingProcedureOutMaterials = new ShellingProcedureMaterialOut.ChildShellingProcedureMaterialOutCollection(_StockActionDetails, "ShellingProcedureOutMaterials");
            _ShellingProcedureInMaterials = new ShellingProcedureMaterialIn.ChildShellingProcedureMaterialInCollection(_StockActionDetails, "ShellingProcedureInMaterials");
        }

        private ShellingProcedureMaterialOut.ChildShellingProcedureMaterialOutCollection _ShellingProcedureOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ShellingProcedureMaterialOut.ChildShellingProcedureMaterialOutCollection ShellingProcedureOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ShellingProcedureOutMaterials;
            }            
        }

        private ShellingProcedureMaterialIn.ChildShellingProcedureMaterialInCollection _ShellingProcedureInMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ShellingProcedureMaterialIn.ChildShellingProcedureMaterialInCollection ShellingProcedureInMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ShellingProcedureInMaterials;
            }            
        }

        protected ShellingProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ShellingProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ShellingProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ShellingProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ShellingProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SHELLINGPROCEDURE", dataRow) { }
        protected ShellingProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SHELLINGPROCEDURE", dataRow, isImported) { }
        public ShellingProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ShellingProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ShellingProcedure() : base() { }

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