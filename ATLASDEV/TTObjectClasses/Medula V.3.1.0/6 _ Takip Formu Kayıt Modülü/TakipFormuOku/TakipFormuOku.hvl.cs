
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipFormuOku")] 

    public  partial class TakipFormuOku : BaseMedulaAction
    {
        public class TakipFormuOkuList : TTObjectCollection<TakipFormuOku> { }
                    
        public class ChildTakipFormuOkuCollection : TTObject.TTChildObjectCollection<TakipFormuOku>
        {
            public ChildTakipFormuOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipFormuOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakipFormuOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetTakipFormuOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakipFormuOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakipFormuOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("b259ddab-9159-43e3-968f-2128fd270534"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("11008645-5008-4fb7-a9d0-319b001080e8"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("9b302fdd-981a-4b24-86e9-371380053613"); } }
            public static Guid New { get { return new Guid("59854b03-77a2-4265-89dc-9f8ee223337a"); } }
            public static Guid SentMedula { get { return new Guid("d1c11e8a-dd51-4b42-bd9f-9e4f881ee319"); } }
            public static Guid SentServer { get { return new Guid("b00ff025-81b9-4a99-b6fb-e8cf139ff568"); } }
        }

        public static BindingList<TakipFormuOku.GetTakipFormuOkuWillBeSentToMedulaRQ_Class> GetTakipFormuOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUOKU"].QueryDefs["GetTakipFormuOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipFormuOku.GetTakipFormuOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipFormuOku.GetTakipFormuOkuWillBeSentToMedulaRQ_Class> GetTakipFormuOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUOKU"].QueryDefs["GetTakipFormuOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipFormuOku.GetTakipFormuOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipFormuOku> GetTakipFormuOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUOKU"].QueryDefs["GetTakipFormuOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TakipFormuOku>(queryDef, paramList);
        }

        protected TakipFormuOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipFormuOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipFormuOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipFormuOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipFormuOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPFORMUOKU", dataRow) { }
        protected TakipFormuOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPFORMUOKU", dataRow, isImported) { }
        public TakipFormuOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipFormuOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipFormuOku() : base() { }

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