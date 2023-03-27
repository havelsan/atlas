
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacRaporDuzelt")] 

    /// <summary>
    /// Ilaç Raporu Düzelt
    /// </summary>
    public  partial class IlacRaporDuzelt : BaseMedulaAction
    {
        public class IlacRaporDuzeltList : TTObjectCollection<IlacRaporDuzelt> { }
                    
        public class ChildIlacRaporDuzeltCollection : TTObject.TTChildObjectCollection<IlacRaporDuzelt>
        {
            public ChildIlacRaporDuzeltCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacRaporDuzeltCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("5325c487-9b58-4188-9b9e-59962575a93c"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("c100283b-cf3a-49f2-9507-7551989c172c"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("cbf807d6-106a-483d-9201-751cb2abb6aa"); } }
            public static Guid New { get { return new Guid("0d2a12e5-d1e1-4dc5-a2fe-e10fba1d7235"); } }
            public static Guid SentMedula { get { return new Guid("63c1345c-873f-4bc8-957d-863637d7328b"); } }
            public static Guid SentServer { get { return new Guid("bb124778-ff68-4f54-9eca-81db05855529"); } }
        }

        public static BindingList<IlacRaporDuzelt.GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class> GetIlacRaporDuzeltWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACRAPORDUZELT"].QueryDefs["GetIlacRaporDuzeltWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacRaporDuzelt.GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IlacRaporDuzelt.GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class> GetIlacRaporDuzeltWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACRAPORDUZELT"].QueryDefs["GetIlacRaporDuzeltWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacRaporDuzelt.GetIlacRaporDuzeltWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IlacRaporDuzelt> GetIlacRaporDuzeltWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACRAPORDUZELT"].QueryDefs["GetIlacRaporDuzeltWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<IlacRaporDuzelt>(queryDef, paramList);
        }

    /// <summary>
    /// İlaç Rapor Düzelt
    /// </summary>
        public IlacRaporDuzeltDVO ilacRaporDuzeltDVO
        {
            get { return (IlacRaporDuzeltDVO)((ITTObject)this).GetParent("ILACRAPORDUZELTDVO"); }
            set { this["ILACRAPORDUZELTDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IlacRaporDuzelt(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacRaporDuzelt(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacRaporDuzelt(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacRaporDuzelt(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacRaporDuzelt(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACRAPORDUZELT", dataRow) { }
        protected IlacRaporDuzelt(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACRAPORDUZELT", dataRow, isImported) { }
        public IlacRaporDuzelt(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacRaporDuzelt(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacRaporDuzelt() : base() { }

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