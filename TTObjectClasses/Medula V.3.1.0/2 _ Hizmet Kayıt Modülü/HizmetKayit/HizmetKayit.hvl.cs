
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetKayit")] 

    /// <summary>
    /// Hizmet Kayıt
    /// </summary>
    public  partial class HizmetKayit : BaseMedulaAction
    {
        public class HizmetKayitList : TTObjectCollection<HizmetKayit> { }
                    
        public class ChildHizmetKayitCollection : TTObject.TTChildObjectCollection<HizmetKayit>
        {
            public ChildHizmetKayitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetKayitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHizmetKayitWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHizmetKayitWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHizmetKayitWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHizmetKayitWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid CompletedUnsuccessfully { get { return new Guid("e9b4440f-8b33-497f-b8a0-24f0069382c2"); } }
            public static Guid New { get { return new Guid("4fc75bf2-0c17-4803-856a-b55d30cb2205"); } }
            public static Guid SentMedula { get { return new Guid("e886e9a9-f8f2-4bbc-85ff-03bff107dfd2"); } }
            public static Guid SentServer { get { return new Guid("bd8bbb7e-3eec-4dfc-a3f6-04ce7d33e45f"); } }
            public static Guid Cancelled { get { return new Guid("39212c59-6402-4807-a2a0-e7a4206f739b"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("af442cd3-e902-4b29-9752-53072e390062"); } }
        }

        public static BindingList<HizmetKayit> GetHizmetKayitWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYIT"].QueryDefs["GetHizmetKayitWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HizmetKayit>(queryDef, paramList);
        }

        public static BindingList<HizmetKayit.GetHizmetKayitWillBeSentToMedulaRQ_Class> GetHizmetKayitWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYIT"].QueryDefs["GetHizmetKayitWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HizmetKayit.GetHizmetKayitWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HizmetKayit.GetHizmetKayitWillBeSentToMedulaRQ_Class> GetHizmetKayitWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYIT"].QueryDefs["GetHizmetKayitWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HizmetKayit.GetHizmetKayitWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hizmet Kayıt Giriş
    /// </summary>
        public HizmetKayitGirisDVO hizmetKayitGirisDVO
        {
            get { return (HizmetKayitGirisDVO)((ITTObject)this).GetParent("HIZMETKAYITGIRISDVO"); }
            set { this["HIZMETKAYITGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HizmetKayit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetKayit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetKayit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetKayit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetKayit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETKAYIT", dataRow) { }
        protected HizmetKayit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETKAYIT", dataRow, isImported) { }
        public HizmetKayit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetKayit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetKayit() : base() { }

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