
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSChargingSlipOperations")] 

    /// <summary>
    /// Mahsup Fişi Girişi
    /// </summary>
    public  partial class MhSChargingSlipOperations : MhSSlip
    {
        public class MhSChargingSlipOperationsList : TTObjectCollection<MhSChargingSlipOperations> { }
                    
        public class ChildMhSChargingSlipOperationsCollection : TTObject.TTChildObjectCollection<MhSChargingSlipOperations>
        {
            public ChildMhSChargingSlipOperationsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSChargingSlipOperationsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Complete { get { return new Guid("fa97bd43-04ef-4dd4-995f-9a43fc862ed1"); } }
            public static Guid New { get { return new Guid("3de55b8c-0c63-49a9-bd98-962d5f741708"); } }
        }

        protected MhSChargingSlipOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSChargingSlipOperations(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSChargingSlipOperations(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSChargingSlipOperations(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSChargingSlipOperations(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSCHARGINGSLIPOPERATIONS", dataRow) { }
        protected MhSChargingSlipOperations(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSCHARGINGSLIPOPERATIONS", dataRow, isImported) { }
        public MhSChargingSlipOperations(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSChargingSlipOperations(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSChargingSlipOperations() : base() { }

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