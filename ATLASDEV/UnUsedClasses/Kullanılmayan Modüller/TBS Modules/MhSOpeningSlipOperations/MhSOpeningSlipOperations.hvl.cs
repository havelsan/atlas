
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSOpeningSlipOperations")] 

    /// <summary>
    /// Açılış Fişi Girişi
    /// </summary>
    public  partial class MhSOpeningSlipOperations : MhSSlip
    {
        public class MhSOpeningSlipOperationsList : TTObjectCollection<MhSOpeningSlipOperations> { }
                    
        public class ChildMhSOpeningSlipOperationsCollection : TTObject.TTChildObjectCollection<MhSOpeningSlipOperations>
        {
            public ChildMhSOpeningSlipOperationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSOpeningSlipOperationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid OpeningSlipEdit { get { return new Guid("b5cc8dba-59ec-4b61-b563-14ebc87d8bc3"); } }
    /// <summary>
    /// Açılış Fişi Girişi
    /// </summary>
            public static Guid New { get { return new Guid("7d964ba3-941b-4b5d-bfb6-8cf914f900f6"); } }
    /// <summary>
    /// Açılış Fişi Kaydedildi
    /// </summary>
            public static Guid Completed { get { return new Guid("4032beab-7966-444d-a31d-50760738d682"); } }
        }

        protected MhSOpeningSlipOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSOpeningSlipOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSOpeningSlipOperations(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSOpeningSlipOperations(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSOpeningSlipOperations(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSOPENINGSLIPOPERATIONS", dataRow) { }
        protected MhSOpeningSlipOperations(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSOPENINGSLIPOPERATIONS", dataRow, isImported) { }
        public MhSOpeningSlipOperations(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSOpeningSlipOperations(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSOpeningSlipOperations() : base() { }

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