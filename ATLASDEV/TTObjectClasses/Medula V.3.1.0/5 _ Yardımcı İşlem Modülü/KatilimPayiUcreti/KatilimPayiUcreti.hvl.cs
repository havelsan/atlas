
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KatilimPayiUcreti")] 

    public  partial class KatilimPayiUcreti : BaseMedulaAction
    {
        public class KatilimPayiUcretiList : TTObjectCollection<KatilimPayiUcreti> { }
                    
        public class ChildKatilimPayiUcretiCollection : TTObject.TTChildObjectCollection<KatilimPayiUcreti>
        {
            public ChildKatilimPayiUcretiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKatilimPayiUcretiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("091bb04f-eae2-4fe7-b956-896cd94bf83d"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("fb63729b-1dc6-44aa-9c6e-f2b4e5c243a7"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("1f16afdc-c262-4383-b288-a3c58e4d088e"); } }
            public static Guid New { get { return new Guid("734c6b2a-5dfb-40c5-a0dc-b87fc88fcbbb"); } }
            public static Guid SentMedula { get { return new Guid("862e539e-7618-4ae3-9179-acfb4f0dd6d4"); } }
            public static Guid SentServer { get { return new Guid("a7e3d44f-abb9-4e94-8964-66d6ad866726"); } }
        }

        public static BindingList<KatilimPayiUcreti.GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class> GetKatilimPayiUcretiWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KATILIMPAYIUCRETI"].QueryDefs["GetKatilimPayiUcretiWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<KatilimPayiUcreti.GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KatilimPayiUcreti.GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class> GetKatilimPayiUcretiWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KATILIMPAYIUCRETI"].QueryDefs["GetKatilimPayiUcretiWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<KatilimPayiUcreti.GetKatilimPayiUcretiWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public KatilimPayiGirisDVO katilimPayiGirisDVO
        {
            get { return (KatilimPayiGirisDVO)((ITTObject)this).GetParent("KATILIMPAYIGIRISDVO"); }
            set { this["KATILIMPAYIGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KatilimPayiUcreti(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KatilimPayiUcreti(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KatilimPayiUcreti(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KatilimPayiUcreti(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KatilimPayiUcreti(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KATILIMPAYIUCRETI", dataRow) { }
        protected KatilimPayiUcreti(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KATILIMPAYIUCRETI", dataRow, isImported) { }
        public KatilimPayiUcreti(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KatilimPayiUcreti(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KatilimPayiUcreti() : base() { }

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