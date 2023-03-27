
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FinancialPatientReturn")] 

    /// <summary>
    /// Döner Sermaye Hasta İade
    /// </summary>
    public  partial class FinancialPatientReturn : EpisodeAction
    {
        public class FinancialPatientReturnList : TTObjectCollection<FinancialPatientReturn> { }
                    
        public class ChildFinancialPatientReturnCollection : TTObject.TTChildObjectCollection<FinancialPatientReturn>
        {
            public ChildFinancialPatientReturnCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFinancialPatientReturnCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("5a98fd22-9f59-41e6-a1d9-cbfcb48f9983"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("3c124010-612e-46b5-aead-2736be808d7e"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("5bb2eb87-4653-47ac-9241-5731e1f6ba12"); } }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// İade Nedeni
    /// </summary>
        public FinancialReturnReasonDefinition ReturnReason
        {
            get { return (FinancialReturnReasonDefinition)((ITTObject)this).GetParent("RETURNREASON"); }
            set { this["RETURNREASON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FinancialPatientReturn(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FinancialPatientReturn(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FinancialPatientReturn(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FinancialPatientReturn(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FinancialPatientReturn(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FINANCIALPATIENTRETURN", dataRow) { }
        protected FinancialPatientReturn(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FINANCIALPATIENTRETURN", dataRow, isImported) { }
        public FinancialPatientReturn(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FinancialPatientReturn(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FinancialPatientReturn() : base() { }

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