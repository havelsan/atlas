
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TakipAra")] 

    /// <summary>
    /// Takip Ara
    /// </summary>
    public  partial class TakipAra : BaseMedulaAction
    {
        public class TakipAraList : TTObjectCollection<TakipAra> { }
                    
        public class ChildTakipAraCollection : TTObject.TTChildObjectCollection<TakipAra>
        {
            public ChildTakipAraCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTakipAraCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTakipAraWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetTakipAraWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTakipAraWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTakipAraWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("e14092a0-8edd-46a5-b827-9557e9217146"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("8d66025c-84a9-4cf1-9835-3ceb2577e0e9"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("cad8b21f-f858-49fd-a6b3-e6b36eaa546e"); } }
            public static Guid New { get { return new Guid("d0913767-af8c-4f03-9c85-be00e29382b7"); } }
            public static Guid SentMedula { get { return new Guid("a12db036-9b8f-47e4-a89c-b6cd1bf24a25"); } }
            public static Guid SentServer { get { return new Guid("1acdde3a-7d0f-440f-b13f-5e0eec2f6b12"); } }
        }

        public static BindingList<TakipAra.GetTakipAraWillBeSentToMedulaRQ_Class> GetTakipAraWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPARA"].QueryDefs["GetTakipAraWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipAra.GetTakipAraWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipAra.GetTakipAraWillBeSentToMedulaRQ_Class> GetTakipAraWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPARA"].QueryDefs["GetTakipAraWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<TakipAra.GetTakipAraWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TakipAra> GetTakipAraWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TAKIPARA"].QueryDefs["GetTakipAraWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TakipAra>(queryDef, paramList);
        }

    /// <summary>
    /// Takip Ara Giriş
    /// </summary>
        public TakipAraGirisDVO takipAraGirisDVO
        {
            get { return (TakipAraGirisDVO)((ITTObject)this).GetParent("TAKIPARAGIRISDVO"); }
            set { this["TAKIPARAGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TakipAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TakipAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TakipAra(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TakipAra(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TakipAra(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TAKIPARA", dataRow) { }
        protected TakipAra(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TAKIPARA", dataRow, isImported) { }
        public TakipAra(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TakipAra(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TakipAra() : base() { }

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