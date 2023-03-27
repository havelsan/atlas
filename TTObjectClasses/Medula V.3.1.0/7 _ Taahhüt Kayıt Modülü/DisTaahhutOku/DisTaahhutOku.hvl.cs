
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DisTaahhutOku")] 

    public  partial class DisTaahhutOku : BaseMedulaAction
    {
        public class DisTaahhutOkuList : TTObjectCollection<DisTaahhutOku> { }
                    
        public class ChildDisTaahhutOkuCollection : TTObject.TTChildObjectCollection<DisTaahhutOku>
        {
            public ChildDisTaahhutOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDisTaahhutOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDisTaahhutOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDisTaahhutOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDisTaahhutOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDisTaahhutOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("31bf1714-87d2-4583-9451-c12b4c921200"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("30efbe30-1702-48c4-9443-75a7c057b25a"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("f449bcd3-42f5-4f27-924c-6e54143c69ac"); } }
            public static Guid New { get { return new Guid("970f4f4e-4716-47eb-964d-618069800775"); } }
            public static Guid SentMedula { get { return new Guid("353d2b82-9cee-4f83-b572-95a26f6e2007"); } }
            public static Guid SentServer { get { return new Guid("08f68a67-b214-4af8-94fd-0578e19cb29e"); } }
        }

        public static BindingList<DisTaahhutOku.GetDisTaahhutOkuWillBeSentToMedulaRQ_Class> GetDisTaahhutOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTOKU"].QueryDefs["GetDisTaahhutOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutOku.GetDisTaahhutOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DisTaahhutOku.GetDisTaahhutOkuWillBeSentToMedulaRQ_Class> GetDisTaahhutOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTAAHHUTOKU"].QueryDefs["GetDisTaahhutOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DisTaahhutOku.GetDisTaahhutOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public TaahhutOkuDVO taahhutOkuDVO
        {
            get { return (TaahhutOkuDVO)((ITTObject)this).GetParent("TAAHHUTOKUDVO"); }
            set { this["TAAHHUTOKUDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DisTaahhutOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DisTaahhutOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DisTaahhutOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DisTaahhutOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DisTaahhutOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTAAHHUTOKU", dataRow) { }
        protected DisTaahhutOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTAAHHUTOKU", dataRow, isImported) { }
        public DisTaahhutOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DisTaahhutOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DisTaahhutOku() : base() { }

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