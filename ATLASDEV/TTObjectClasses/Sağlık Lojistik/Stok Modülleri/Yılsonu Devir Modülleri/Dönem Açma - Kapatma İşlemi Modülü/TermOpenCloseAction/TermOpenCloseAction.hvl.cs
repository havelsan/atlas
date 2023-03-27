
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TermOpenCloseAction")] 

    /// <summary>
    /// Dönem Açma / Kapatma İşlemi
    /// </summary>
    public  partial class TermOpenCloseAction : BaseAction, IWorkListBaseAction
    {
        public class TermOpenCloseActionList : TTObjectCollection<TermOpenCloseAction> { }
                    
        public class ChildTermOpenCloseActionCollection : TTObject.TTChildObjectCollection<TermOpenCloseAction>
        {
            public ChildTermOpenCloseActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTermOpenCloseActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("61098b40-ca22-4afb-b4ff-13c53e12cbb4"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("55b6836d-ed0f-4bfc-9b6f-d94a715c0bb9"); } }
        }

        public AccountingTerm OpenTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("OPENTERM"); }
            set { this["OPENTERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AccountingTerm CloseTerm
        {
            get { return (AccountingTerm)((ITTObject)this).GetParent("CLOSETERM"); }
            set { this["CLOSETERM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TermOpenCloseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TermOpenCloseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TermOpenCloseAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TermOpenCloseAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TermOpenCloseAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TERMOPENCLOSEACTION", dataRow) { }
        protected TermOpenCloseAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TERMOPENCLOSEACTION", dataRow, isImported) { }
        public TermOpenCloseAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TermOpenCloseAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TermOpenCloseAction() : base() { }

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