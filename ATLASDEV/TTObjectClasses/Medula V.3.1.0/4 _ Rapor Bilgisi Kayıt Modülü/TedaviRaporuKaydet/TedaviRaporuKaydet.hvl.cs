
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviRaporuKaydet")] 

    public  partial class TedaviRaporuKaydet : BaseTedaviRaporuKaydet
    {
        public class TedaviRaporuKaydetList : TTObjectCollection<TedaviRaporuKaydet> { }
                    
        public class ChildTedaviRaporuKaydetCollection : TTObject.TTChildObjectCollection<TedaviRaporuKaydet>
        {
            public ChildTedaviRaporuKaydetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviRaporuKaydetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("a8039d42-1795-4d62-91c1-a75b482e925f"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("924fc367-bb45-4f7d-8d33-a6d8e5f4ce8c"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("2c553afd-6c63-4b7d-8be6-2b8b17703c0c"); } }
            public static Guid New { get { return new Guid("848b2109-75b3-436f-9e7e-3dc7daf96581"); } }
            public static Guid SentMedula { get { return new Guid("aa61d9a0-c1e2-4364-88e3-034bb97fb987"); } }
            public static Guid SentServer { get { return new Guid("5547f28a-4044-42fe-b871-06266abf3171"); } }
        }

        public static BindingList<TedaviRaporuKaydet.GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class> GetTedaviRaporuKaydetWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORUKAYDET"].QueryDefs["GetTedaviRaporuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TedaviRaporuKaydet.GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TedaviRaporuKaydet.GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class> GetTedaviRaporuKaydetWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORUKAYDET"].QueryDefs["GetTedaviRaporuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TedaviRaporuKaydet.GetTedaviRaporuKaydetWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected TedaviRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviRaporuKaydet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVIRAPORUKAYDET", dataRow) { }
        protected TedaviRaporuKaydet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVIRAPORUKAYDET", dataRow, isImported) { }
        public TedaviRaporuKaydet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviRaporuKaydet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviRaporuKaydet() : base() { }

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