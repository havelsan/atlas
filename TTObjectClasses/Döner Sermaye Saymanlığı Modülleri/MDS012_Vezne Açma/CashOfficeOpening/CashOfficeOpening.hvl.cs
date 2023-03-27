
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeOpening")] 

    /// <summary>
    /// Muh.Yet. Mutemetliği/Vezne/Fatura Servisi Açma
    /// </summary>
    public  partial class CashOfficeOpening : BaseAction, IWorkListBaseAction
    {
        public class CashOfficeOpeningList : TTObjectCollection<CashOfficeOpening> { }
                    
        public class ChildCashOfficeOpeningCollection : TTObject.TTChildObjectCollection<CashOfficeOpening>
        {
            public ChildCashOfficeOpeningCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeOpeningCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("c2195391-98a0-4c47-8555-80bab4535b3d"); } }
            public static Guid CashOfficeOpened { get { return new Guid("927bb886-1630-46bc-97cc-f517484751c4"); } }
        }

    /// <summary>
    /// Bilgisayar Adı
    /// </summary>
        public string COMPUTERNAME
        {
            get { return (string)this["COMPUTERNAME"]; }
            set { this["COMPUTERNAME"] = value; }
        }

    /// <summary>
    /// Veznenin açılış kapanış izi  ilişkisi 
    /// </summary>
        public CashierLog CashierLog
        {
            get { return (CashierLog)((ITTObject)this).GetParent("CASHIERLOG"); }
            set { this["CASHIERLOG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CashOfficeOpening(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeOpening(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeOpening(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeOpening(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeOpening(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICEOPENING", dataRow) { }
        protected CashOfficeOpening(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICEOPENING", dataRow, isImported) { }
        protected CashOfficeOpening(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeOpening(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeOpening() : base() { }

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