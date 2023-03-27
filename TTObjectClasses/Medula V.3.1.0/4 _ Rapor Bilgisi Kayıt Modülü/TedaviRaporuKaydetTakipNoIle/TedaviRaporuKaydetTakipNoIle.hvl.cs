
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TedaviRaporuKaydetTakipNoIle")] 

    public  partial class TedaviRaporuKaydetTakipNoIle : BaseTedaviRaporuKaydet
    {
        public class TedaviRaporuKaydetTakipNoIleList : TTObjectCollection<TedaviRaporuKaydetTakipNoIle> { }
                    
        public class ChildTedaviRaporuKaydetTakipNoIleCollection : TTObject.TTChildObjectCollection<TedaviRaporuKaydetTakipNoIle>
        {
            public ChildTedaviRaporuKaydetTakipNoIleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTedaviRaporuKaydetTakipNoIleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("11f615e7-6434-4fcb-ad84-b515e99adf12"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("1840248e-b4c3-46ff-b845-4e954f9e8c58"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("311579d1-1365-459e-8757-4798357f3b49"); } }
            public static Guid New { get { return new Guid("63277726-495e-4fc6-a39a-fc90a428cd3c"); } }
            public static Guid SentMedula { get { return new Guid("041505ab-e64b-47c6-b418-cee98e370430"); } }
            public static Guid SentServer { get { return new Guid("ea1394bd-ee09-4cec-9540-06180776bde9"); } }
        }

        public static BindingList<TedaviRaporuKaydetTakipNoIle> GetTedaviRaporuKaydetTakipNoIleWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetTedaviRaporuKaydetTakipNoIleWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TedaviRaporuKaydetTakipNoIle>(queryDef, paramList);
        }

        public static BindingList<TedaviRaporuKaydetTakipNoIle.GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TedaviRaporuKaydetTakipNoIle.GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TedaviRaporuKaydetTakipNoIle.GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TEDAVIRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TedaviRaporuKaydetTakipNoIle.GetTRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected TedaviRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TedaviRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TedaviRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TedaviRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TedaviRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TEDAVIRAPORUKAYDETTAKIPNOILE", dataRow) { }
        protected TedaviRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TEDAVIRAPORUKAYDETTAKIPNOILE", dataRow, isImported) { }
        public TedaviRaporuKaydetTakipNoIle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TedaviRaporuKaydetTakipNoIle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TedaviRaporuKaydetTakipNoIle() : base() { }

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