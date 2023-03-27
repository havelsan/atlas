
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacRaporuKaydetTakipNoIle")] 

    public  partial class IlacRaporuKaydetTakipNoIle : BaseIlacRaporuKaydet
    {
        public class IlacRaporuKaydetTakipNoIleList : TTObjectCollection<IlacRaporuKaydetTakipNoIle> { }
                    
        public class ChildIlacRaporuKaydetTakipNoIleCollection : TTObject.TTChildObjectCollection<IlacRaporuKaydetTakipNoIle>
        {
            public ChildIlacRaporuKaydetTakipNoIleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacRaporuKaydetTakipNoIleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("4f42c2d6-1a82-4c0a-882f-d0518406ec8b"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("efc6f64f-3aed-4e6b-80cd-64fba0e56609"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("158a7a97-72d9-4b44-93b9-6c738df87b15"); } }
            public static Guid New { get { return new Guid("a89136cc-f55f-47ff-9768-7ddfc2be621c"); } }
            public static Guid SentMedula { get { return new Guid("d7713ca5-28d6-40f5-9c7b-c73231d48117"); } }
            public static Guid SentServer { get { return new Guid("ab9ee9a1-3fb4-4289-9dce-cee901984e03"); } }
        }

        public static BindingList<IlacRaporuKaydetTakipNoIle.GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacRaporuKaydetTakipNoIle.GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IlacRaporuKaydetTakipNoIle.GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacRaporuKaydetTakipNoIle.GetIlacRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected IlacRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACRAPORUKAYDETTAKIPNOILE", dataRow) { }
        protected IlacRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACRAPORUKAYDETTAKIPNOILE", dataRow, isImported) { }
        public IlacRaporuKaydetTakipNoIle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacRaporuKaydetTakipNoIle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacRaporuKaydetTakipNoIle() : base() { }

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