
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DisTaahhutOkuKisi")] 

    public  partial class DisTaahhutOkuKisi : BaseMedulaAction
    {
        public class DisTaahhutOkuKisiList : TTObjectCollection<DisTaahhutOkuKisi> { }
                    
        public class ChildDisTaahhutOkuKisiCollection : TTObject.TTChildObjectCollection<DisTaahhutOkuKisi>
        {
            public ChildDisTaahhutOkuKisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDisTaahhutOkuKisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("d3cfe69a-723c-4617-ba1e-edfc0e1a1de1"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("6dacd3cc-49ae-4e64-bbaa-57d7feb2c942"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("11b96fc0-b8a6-4afe-853a-4b3d65d0f34f"); } }
            public static Guid New { get { return new Guid("bb382170-f2d5-4452-aa8a-290a8395f1e5"); } }
            public static Guid SentMedula { get { return new Guid("99574a97-7dca-4fa6-8327-f436e7be4d06"); } }
            public static Guid SentServer { get { return new Guid("8af8b3eb-98ed-4190-9cf1-7477afa31335"); } }
        }

        public static BindingList<DisTaahhutOkuKisi.GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class> GetDisTaahhutOkuKisiWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTOKUKISI"].QueryDefs["GetDisTaahhutOkuKisiWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutOkuKisi.GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DisTaahhutOkuKisi.GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class> GetDisTaahhutOkuKisiWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTOKUKISI"].QueryDefs["GetDisTaahhutOkuKisiWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutOkuKisi.GetDisTaahhutOkuKisiWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public TaahhutKisiOkuDVO taahhutKisiOkuDVO
        {
            get { return (TaahhutKisiOkuDVO)((ITTObject)this).GetParent("TAAHHUTKISIOKUDVO"); }
            set { this["TAAHHUTKISIOKUDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DisTaahhutOkuKisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DisTaahhutOkuKisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DisTaahhutOkuKisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DisTaahhutOkuKisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DisTaahhutOkuKisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTAAHHUTOKUKISI", dataRow) { }
        protected DisTaahhutOkuKisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTAAHHUTOKUKISI", dataRow, isImported) { }
        public DisTaahhutOkuKisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DisTaahhutOkuKisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DisTaahhutOkuKisi() : base() { }

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