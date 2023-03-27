
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipFormuSil")] 

    public  partial class TakipFormuSil : BaseMedulaAction
    {
        public class TakipFormuSilList : TTObjectCollection<TakipFormuSil> { }
                    
        public class ChildTakipFormuSilCollection : TTObject.TTChildObjectCollection<TakipFormuSil>
        {
            public ChildTakipFormuSilCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipFormuSilCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakipFormuSilWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetTakipFormuSilWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakipFormuSilWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakipFormuSilWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid CompletedSuccessfully { get { return new Guid("db1acc32-6a91-447c-b16f-ba89da1923d8"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("9764dfd7-682f-4103-866b-feaaaadcb3b5"); } }
            public static Guid New { get { return new Guid("bafea0e6-ac62-4ea2-b0f0-061527913e92"); } }
            public static Guid SentMedula { get { return new Guid("a9682461-aa3c-4302-9efb-216980d55e2d"); } }
            public static Guid SentServer { get { return new Guid("42cdb80f-539c-40ce-8e9d-51f863563e5d"); } }
            public static Guid Cancelled { get { return new Guid("479cafbc-d8f1-4007-ba58-e806f787265e"); } }
        }

        public static BindingList<TakipFormuSil.GetTakipFormuSilWillBeSentToMedulaRQ_Class> GetTakipFormuSilWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUSIL"].QueryDefs["GetTakipFormuSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipFormuSil.GetTakipFormuSilWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipFormuSil.GetTakipFormuSilWillBeSentToMedulaRQ_Class> GetTakipFormuSilWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUSIL"].QueryDefs["GetTakipFormuSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipFormuSil.GetTakipFormuSilWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipFormuSil> GetTakipFormuSilWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUSIL"].QueryDefs["GetTakipFormuSilWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TakipFormuSil>(queryDef, paramList);
        }

        protected TakipFormuSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipFormuSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipFormuSil(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipFormuSil(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipFormuSil(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPFORMUSIL", dataRow) { }
        protected TakipFormuSil(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPFORMUSIL", dataRow, isImported) { }
        public TakipFormuSil(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipFormuSil(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipFormuSil() : base() { }

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