
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporBilgisiBul")] 

    /// <summary>
    /// Rapor Bilgisi Bul
    /// </summary>
    public  partial class RaporBilgisiBul : BaseRaporBilgisiBulSil
    {
        public class RaporBilgisiBulList : TTObjectCollection<RaporBilgisiBul> { }
                    
        public class ChildRaporBilgisiBulCollection : TTObject.TTChildObjectCollection<RaporBilgisiBul>
        {
            public ChildRaporBilgisiBulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporBilgisiBulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporBilgisiBulWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRaporBilgisiBulWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporBilgisiBulWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporBilgisiBulWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("cc5b3faa-9c8c-403b-9dcc-6ae9bd5280cc"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("91d95872-d3e4-444a-bbde-f50ddde2b051"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("ede4954d-85a4-4a6b-8766-1d26fc782bf6"); } }
            public static Guid New { get { return new Guid("af58b5ae-cd99-4e11-88e3-d87f822e6cb7"); } }
            public static Guid SentMedula { get { return new Guid("94686f68-9785-4a38-9877-e00c9eb93431"); } }
            public static Guid SentServer { get { return new Guid("91437fba-8960-42fb-be86-6c3961aef2d6"); } }
        }

        public static BindingList<RaporBilgisiBul.GetRaporBilgisiBulWillBeSentToMedulaRQ_Class> GetRaporBilgisiBulWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBUL"].QueryDefs["GetRaporBilgisiBulWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiBul.GetRaporBilgisiBulWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiBul.GetRaporBilgisiBulWillBeSentToMedulaRQ_Class> GetRaporBilgisiBulWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBUL"].QueryDefs["GetRaporBilgisiBulWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiBul.GetRaporBilgisiBulWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiBul> GetRaporBilgisiBulWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBUL"].QueryDefs["GetRaporBilgisiBulWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RaporBilgisiBul>(queryDef, paramList);
        }

        protected RaporBilgisiBul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporBilgisiBul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporBilgisiBul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporBilgisiBul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporBilgisiBul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORBILGISIBUL", dataRow) { }
        protected RaporBilgisiBul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORBILGISIBUL", dataRow, isImported) { }
        public RaporBilgisiBul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporBilgisiBul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporBilgisiBul() : base() { }

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