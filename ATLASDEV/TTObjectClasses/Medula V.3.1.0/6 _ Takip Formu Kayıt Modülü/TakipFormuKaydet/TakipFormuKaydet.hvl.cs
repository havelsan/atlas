
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipFormuKaydet")] 

    public  partial class TakipFormuKaydet : BaseMedulaAction
    {
        public class TakipFormuKaydetList : TTObjectCollection<TakipFormuKaydet> { }
                    
        public class ChildTakipFormuKaydetCollection : TTObject.TTChildObjectCollection<TakipFormuKaydet>
        {
            public ChildTakipFormuKaydetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipFormuKaydetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakipFormuKaydetWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetTakipFormuKaydetWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakipFormuKaydetWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakipFormuKaydetWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("0bad4d01-a835-4791-9bf7-b33c29c2cd65"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("09c27b22-592a-4cca-af3b-db541ddea4c5"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("691a5189-98ca-4ef0-8a5b-d77336234438"); } }
            public static Guid New { get { return new Guid("4110dbe8-75a6-4239-8468-d85191e1b6d4"); } }
            public static Guid SentMedula { get { return new Guid("062777ca-9776-48fb-8e8b-2a3ce75ff5d4"); } }
            public static Guid SentServer { get { return new Guid("94d5da5b-8ab2-46ba-bc38-2301ca4316f2"); } }
        }

        public static BindingList<TakipFormuKaydet.GetTakipFormuKaydetWillBeSentToMedulaRQ_Class> GetTakipFormuKaydetWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUKAYDET"].QueryDefs["GetTakipFormuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipFormuKaydet.GetTakipFormuKaydetWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipFormuKaydet.GetTakipFormuKaydetWillBeSentToMedulaRQ_Class> GetTakipFormuKaydetWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUKAYDET"].QueryDefs["GetTakipFormuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipFormuKaydet.GetTakipFormuKaydetWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipFormuKaydet> GetTakipFormuKaydetWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPFORMUKAYDET"].QueryDefs["GetTakipFormuKaydetWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TakipFormuKaydet>(queryDef, paramList);
        }

        protected TakipFormuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipFormuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipFormuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipFormuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipFormuKaydet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPFORMUKAYDET", dataRow) { }
        protected TakipFormuKaydet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPFORMUKAYDET", dataRow, isImported) { }
        public TakipFormuKaydet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipFormuKaydet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipFormuKaydet() : base() { }

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