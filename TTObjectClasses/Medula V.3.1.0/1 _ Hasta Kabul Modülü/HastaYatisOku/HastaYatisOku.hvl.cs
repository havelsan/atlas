
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaYatisOku")] 

    /// <summary>
    /// Hasta Yatış Oku
    /// </summary>
    public  partial class HastaYatisOku : BaseMedulaAction
    {
        public class HastaYatisOkuList : TTObjectCollection<HastaYatisOku> { }
                    
        public class ChildHastaYatisOkuCollection : TTObject.TTChildObjectCollection<HastaYatisOku>
        {
            public ChildHastaYatisOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaYatisOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHastaYatisOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHastaYatisOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHastaYatisOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHastaYatisOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid SentServer { get { return new Guid("cef96b58-75fc-4c43-8a93-86537dd6df5c"); } }
            public static Guid Cancelled { get { return new Guid("fed4dd43-3f17-46fb-b93a-afc6b2eaecc4"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("71832c5c-6449-4d21-b1fd-70e708b2001a"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("12e67d6e-74bf-4b4c-b009-98c8f7bbc5bf"); } }
            public static Guid New { get { return new Guid("711e68d3-fe60-4a14-8a4a-01731e173597"); } }
            public static Guid SentMedula { get { return new Guid("202415bc-ede6-46d3-a566-8af025519cce"); } }
        }

        public static BindingList<HastaYatisOku> GetHastaYatisOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAYATISOKU"].QueryDefs["GetHastaYatisOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaYatisOku>(queryDef, paramList);
        }

        public static BindingList<HastaYatisOku.GetHastaYatisOkuWillBeSentToMedulaRQ_Class> GetHastaYatisOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAYATISOKU"].QueryDefs["GetHastaYatisOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaYatisOku.GetHastaYatisOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaYatisOku.GetHastaYatisOkuWillBeSentToMedulaRQ_Class> GetHastaYatisOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAYATISOKU"].QueryDefs["GetHastaYatisOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaYatisOku.GetHastaYatisOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Yatış Oku
    /// </summary>
        public HastaYatisOkuDVO hastaYatisOkuDVO
        {
            get { return (HastaYatisOkuDVO)((ITTObject)this).GetParent("HASTAYATISOKUDVO"); }
            set { this["HASTAYATISOKUDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaYatisOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaYatisOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaYatisOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaYatisOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaYatisOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAYATISOKU", dataRow) { }
        protected HastaYatisOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAYATISOKU", dataRow, isImported) { }
        public HastaYatisOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaYatisOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaYatisOku() : base() { }

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