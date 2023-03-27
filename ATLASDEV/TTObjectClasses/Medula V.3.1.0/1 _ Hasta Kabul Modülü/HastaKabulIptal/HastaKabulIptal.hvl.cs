
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaKabulIptal")] 

    /// <summary>
    /// Hasta Kabul İptal
    /// </summary>
    public  partial class HastaKabulIptal : BaseMedulaAction
    {
        public class HastaKabulIptalList : TTObjectCollection<HastaKabulIptal> { }
                    
        public class ChildHastaKabulIptalCollection : TTObject.TTChildObjectCollection<HastaKabulIptal>
        {
            public ChildHastaKabulIptalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaKabulIptalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHastaKabulIptalWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHastaKabulIptalWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHastaKabulIptalWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHastaKabulIptalWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("b8c16cf6-f85a-4342-9380-bb8d38c3e4bc"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("ea5af58f-7cc0-4783-9853-adc1de3528c9"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("3ffe27b5-ab82-4808-9ea8-13f4c4677a22"); } }
            public static Guid New { get { return new Guid("d1f0af83-6b03-416e-a90c-2e307252603d"); } }
            public static Guid SentMedula { get { return new Guid("c242d23b-a3a2-4516-b790-e757601dca04"); } }
            public static Guid SentServer { get { return new Guid("12c1c673-6a91-4fb5-ba59-2ad385d433da"); } }
        }

        public static BindingList<HastaKabulIptal> GetHastaKabulIptalWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULIPTAL"].QueryDefs["GetHastaKabulIptalWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaKabulIptal>(queryDef, paramList);
        }

        public static BindingList<HastaKabulIptal.GetHastaKabulIptalWillBeSentToMedulaRQ_Class> GetHastaKabulIptalWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULIPTAL"].QueryDefs["GetHastaKabulIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulIptal.GetHastaKabulIptalWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaKabulIptal.GetHastaKabulIptalWillBeSentToMedulaRQ_Class> GetHastaKabulIptalWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULIPTAL"].QueryDefs["GetHastaKabulIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulIptal.GetHastaKabulIptalWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Takip Sil Giriş
    /// </summary>
        public TakipSilGirisDVO takipSilGirisDVO
        {
            get { return (TakipSilGirisDVO)((ITTObject)this).GetParent("TAKIPSILGIRISDVO"); }
            set { this["TAKIPSILGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaKabulIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaKabulIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaKabulIptal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaKabulIptal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaKabulIptal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAKABULIPTAL", dataRow) { }
        protected HastaKabulIptal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAKABULIPTAL", dataRow, isImported) { }
        public HastaKabulIptal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaKabulIptal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaKabulIptal() : base() { }

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