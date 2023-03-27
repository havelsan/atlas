
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaOku")] 

    /// <summary>
    /// Fatura Oku
    /// </summary>
    public  partial class FaturaOku : BaseMedulaAction
    {
        public class FaturaOkuList : TTObjectCollection<FaturaOku> { }
                    
        public class ChildFaturaOkuCollection : TTObject.TTChildObjectCollection<FaturaOku>
        {
            public ChildFaturaOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFaturaOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetFaturaOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFaturaOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFaturaOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("ad36a3ef-e1fd-44d0-97f2-e2b74219a445"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("339d9ac5-6520-48a8-bdd0-494d88216df2"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("d6a99af6-3f2f-4570-a23f-11921d7ff601"); } }
            public static Guid New { get { return new Guid("ab6c5bba-1666-4fe9-bb74-3b8007f8b0c4"); } }
            public static Guid SentMedula { get { return new Guid("1bfadb66-7bb3-4375-853d-c620c91301c2"); } }
            public static Guid SentServer { get { return new Guid("517d1890-56d7-4a3f-b3c9-eece7fbdf0d5"); } }
        }

        public static BindingList<FaturaOku.GetFaturaOkuWillBeSentToMedulaRQ_Class> GetFaturaOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURAOKU"].QueryDefs["GetFaturaOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<FaturaOku.GetFaturaOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FaturaOku.GetFaturaOkuWillBeSentToMedulaRQ_Class> GetFaturaOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURAOKU"].QueryDefs["GetFaturaOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<FaturaOku.GetFaturaOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FaturaOku> GetFaturaOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURAOKU"].QueryDefs["GetFaturaOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FaturaOku>(queryDef, paramList);
        }

    /// <summary>
    /// Fatura Oku Giriş
    /// </summary>
        public FaturaOkuGirisDVO faturaOkuGirisDVO
        {
            get { return (FaturaOkuGirisDVO)((ITTObject)this).GetParent("FATURAOKUGIRISDVO"); }
            set { this["FATURAOKUGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FaturaOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAOKU", dataRow) { }
        protected FaturaOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAOKU", dataRow, isImported) { }
        public FaturaOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaOku() : base() { }

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