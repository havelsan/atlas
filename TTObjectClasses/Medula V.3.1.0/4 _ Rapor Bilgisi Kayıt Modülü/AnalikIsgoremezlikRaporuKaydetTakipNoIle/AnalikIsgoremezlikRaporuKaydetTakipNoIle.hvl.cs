
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnalikIsgoremezlikRaporuKaydetTakipNoIle")] 

    public  partial class AnalikIsgoremezlikRaporuKaydetTakipNoIle : BaseAnalikIsgoremezlikRaporuKaydet
    {
        public class AnalikIsgoremezlikRaporuKaydetTakipNoIleList : TTObjectCollection<AnalikIsgoremezlikRaporuKaydetTakipNoIle> { }
                    
        public class ChildAnalikIsgoremezlikRaporuKaydetTakipNoIleCollection : TTObject.TTChildObjectCollection<AnalikIsgoremezlikRaporuKaydetTakipNoIle>
        {
            public ChildAnalikIsgoremezlikRaporuKaydetTakipNoIleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnalikIsgoremezlikRaporuKaydetTakipNoIleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("07f6c8fd-fc9d-4300-9ab2-af823e62d09a"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("97735b82-7df5-4a02-ab7d-04b25d86d72e"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("3d753fd0-8b2c-47a5-a458-ca8a1532348a"); } }
            public static Guid New { get { return new Guid("c1fcd3c0-67d8-462e-a6e5-b860d2492283"); } }
            public static Guid SentMedula { get { return new Guid("d0bdaa84-3b78-4d4a-9bab-3741072246bb"); } }
            public static Guid SentServer { get { return new Guid("d0bb5793-ec74-41b6-9110-ba913099e1e0"); } }
        }

        public static BindingList<AnalikIsgoremezlikRaporuKaydetTakipNoIle.GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANALIKISGOREMEZLIKRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<AnalikIsgoremezlikRaporuKaydetTakipNoIle.GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnalikIsgoremezlikRaporuKaydetTakipNoIle.GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANALIKISGOREMEZLIKRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<AnalikIsgoremezlikRaporuKaydetTakipNoIle.GetAIGRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected AnalikIsgoremezlikRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnalikIsgoremezlikRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnalikIsgoremezlikRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnalikIsgoremezlikRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnalikIsgoremezlikRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANALIKISGOREMEZLIKRAPORUKAYDETTAKIPNOILE", dataRow) { }
        protected AnalikIsgoremezlikRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANALIKISGOREMEZLIKRAPORUKAYDETTAKIPNOILE", dataRow, isImported) { }
        public AnalikIsgoremezlikRaporuKaydetTakipNoIle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnalikIsgoremezlikRaporuKaydetTakipNoIle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnalikIsgoremezlikRaporuKaydetTakipNoIle() : base() { }

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