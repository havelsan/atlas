
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSSpendingSlip")] 

    /// <summary>
    /// Tediye Fişi Girişi
    /// </summary>
    public  partial class MhSSpendingSlip : MhSSlip
    {
        public class MhSSpendingSlipList : TTObjectCollection<MhSSpendingSlip> { }
                    
        public class ChildMhSSpendingSlipCollection : TTObject.TTChildObjectCollection<MhSSpendingSlip>
        {
            public ChildMhSSpendingSlipCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSSpendingSlipCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Completed { get { return new Guid("b2ad77b8-6ba0-4bf7-b551-4d2dbe5845b3"); } }
            public static Guid New { get { return new Guid("c83226fa-660a-431e-a3f9-f4080409d2a6"); } }
        }

    /// <summary>
    /// Kasa Hesabı
    /// </summary>
        public MhSAccount SelectedCase
        {
            get { return (MhSAccount)((ITTObject)this).GetParent("SELECTEDCASE"); }
            set { this["SELECTEDCASE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MhSSpendingSlip(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSSpendingSlip(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSSpendingSlip(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSSpendingSlip(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSSpendingSlip(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSSPENDINGSLIP", dataRow) { }
        protected MhSSpendingSlip(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSSPENDINGSLIP", dataRow, isImported) { }
        public MhSSpendingSlip(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSSpendingSlip(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSSpendingSlip() : base() { }

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