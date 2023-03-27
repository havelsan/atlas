
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaCikisKayit")] 

    /// <summary>
    /// Hasta Çıkış Kayıt
    /// </summary>
    public  partial class HastaCikisKayit : BaseMedulaAction
    {
        public class HastaCikisKayitList : TTObjectCollection<HastaCikisKayit> { }
                    
        public class ChildHastaCikisKayitCollection : TTObject.TTChildObjectCollection<HastaCikisKayit>
        {
            public ChildHastaCikisKayitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaCikisKayitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHastaCikisKayitWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHastaCikisKayitWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHastaCikisKayitWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHastaCikisKayitWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("81ac6e3e-1bfd-47ab-acc2-b0eb6dc90a25"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("43bfff92-fc86-4e1d-b261-1b2645ee650b"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("8f4ff7d7-7257-490c-9b56-d2f8fd719c69"); } }
            public static Guid New { get { return new Guid("2db7978c-45da-43b6-8153-036efe182ce4"); } }
            public static Guid SentMedula { get { return new Guid("d16d2cda-dd84-43fb-993c-3143ba234447"); } }
            public static Guid SentServer { get { return new Guid("d8fbcf75-df92-412e-b01d-ef30d08cffa6"); } }
        }

        public static BindingList<HastaCikisKayit.GetHastaCikisKayitWillBeSentToMedulaRQ_Class> GetHastaCikisKayitWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISKAYIT"].QueryDefs["GetHastaCikisKayitWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaCikisKayit.GetHastaCikisKayitWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaCikisKayit.GetHastaCikisKayitWillBeSentToMedulaRQ_Class> GetHastaCikisKayitWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISKAYIT"].QueryDefs["GetHastaCikisKayitWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaCikisKayit.GetHastaCikisKayitWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaCikisKayit> GetHastaCikisKayitWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISKAYIT"].QueryDefs["GetHastaCikisKayitWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaCikisKayit>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta Çıkış
    /// </summary>
        public HastaCikisDVO hastaCikisDVO
        {
            get { return (HastaCikisDVO)((ITTObject)this).GetParent("HASTACIKISDVO"); }
            set { this["HASTACIKISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaCikisKayit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaCikisKayit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaCikisKayit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaCikisKayit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaCikisKayit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTACIKISKAYIT", dataRow) { }
        protected HastaCikisKayit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTACIKISKAYIT", dataRow, isImported) { }
        public HastaCikisKayit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaCikisKayit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaCikisKayit() : base() { }

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