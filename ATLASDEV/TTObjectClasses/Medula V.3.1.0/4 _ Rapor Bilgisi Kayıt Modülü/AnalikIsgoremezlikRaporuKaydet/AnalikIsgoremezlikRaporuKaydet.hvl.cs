
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnalikIsgoremezlikRaporuKaydet")] 

    public  partial class AnalikIsgoremezlikRaporuKaydet : BaseAnalikIsgoremezlikRaporuKaydet
    {
        public class AnalikIsgoremezlikRaporuKaydetList : TTObjectCollection<AnalikIsgoremezlikRaporuKaydet> { }
                    
        public class ChildAnalikIsgoremezlikRaporuKaydetCollection : TTObject.TTChildObjectCollection<AnalikIsgoremezlikRaporuKaydet>
        {
            public ChildAnalikIsgoremezlikRaporuKaydetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnalikIsgoremezlikRaporuKaydetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("e49389f6-8ef5-4120-a6cb-b7c56a24cf1e"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("193b1cbb-a5e0-49a9-930e-3841fc2ad5d6"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("9638c603-5986-4261-90aa-f1583e851899"); } }
            public static Guid New { get { return new Guid("4bcb243a-d1e7-404f-a74b-175f5f191d3c"); } }
            public static Guid SentMedula { get { return new Guid("48626df9-77d9-4c70-97ce-0af69337cdb1"); } }
            public static Guid SentServer { get { return new Guid("971b5a91-6c47-4a43-b977-36a2cdb1b27e"); } }
        }

        public static BindingList<AnalikIsgoremezlikRaporuKaydet.GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class> GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANALIKISGOREMEZLIKRAPORUKAYDET"].QueryDefs["GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<AnalikIsgoremezlikRaporuKaydet.GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AnalikIsgoremezlikRaporuKaydet.GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class> GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANALIKISGOREMEZLIKRAPORUKAYDET"].QueryDefs["GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<AnalikIsgoremezlikRaporuKaydet.GetAnalikIsgoremezlikRaporuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected AnalikIsgoremezlikRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnalikIsgoremezlikRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnalikIsgoremezlikRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnalikIsgoremezlikRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnalikIsgoremezlikRaporuKaydet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANALIKISGOREMEZLIKRAPORUKAYDET", dataRow) { }
        protected AnalikIsgoremezlikRaporuKaydet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANALIKISGOREMEZLIKRAPORUKAYDET", dataRow, isImported) { }
        public AnalikIsgoremezlikRaporuKaydet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnalikIsgoremezlikRaporuKaydet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnalikIsgoremezlikRaporuKaydet() : base() { }

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