
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MuayeneBilgisiSil")] 

    public  partial class MuayeneBilgisiSil : BaseMedulaAction
    {
        public class MuayeneBilgisiSilList : TTObjectCollection<MuayeneBilgisiSil> { }
                    
        public class ChildMuayeneBilgisiSilCollection : TTObject.TTChildObjectCollection<MuayeneBilgisiSil>
        {
            public ChildMuayeneBilgisiSilCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMuayeneBilgisiSilCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("4e4b7aaa-ea43-409f-a504-f6e336b968c9"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("596606f0-75f8-4cf4-8eb3-2e9bb3292852"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("dad9c15c-ffac-44fa-b6c4-fa69addcfa6c"); } }
            public static Guid New { get { return new Guid("63182a9f-4d9c-4031-b15d-6f1fcb540a93"); } }
            public static Guid SentMedula { get { return new Guid("1c810ee2-fb4e-4246-b22c-86c3a0b354f5"); } }
            public static Guid SentServer { get { return new Guid("46b95856-a5c1-4046-bc80-291448198cf3"); } }
        }

        public static BindingList<MuayeneBilgisiSil.GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class> GetMuayeneBilgisiSilWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEBILGISISIL"].QueryDefs["GetMuayeneBilgisiSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<MuayeneBilgisiSil.GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MuayeneBilgisiSil.GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class> GetMuayeneBilgisiSilWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEBILGISISIL"].QueryDefs["GetMuayeneBilgisiSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<MuayeneBilgisiSil.GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MuayeneBilgisiSil> GetMuayeneBilgisiSilForMuayeneDurum(TTObjectContext objectContext, int HEALTHFACILITYID, long REFERANSNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MUAYENEBILGISISIL"].QueryDefs["GetMuayeneBilgisiSilForMuayeneDurum"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);
            paramList.Add("REFERANSNO", REFERANSNO);

            return ((ITTQuery)objectContext).QueryObjects<MuayeneBilgisiSil>(queryDef, paramList);
        }

        public MuayeneSilGirisDVO muayeneSilGirisDVO
        {
            get { return (MuayeneSilGirisDVO)((ITTObject)this).GetParent("MUAYENESILGIRISDVO"); }
            set { this["MUAYENESILGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MuayeneGiris muayeneGiris
        {
            get { return (MuayeneGiris)((ITTObject)this).GetParent("MUAYENEGIRIS"); }
            set { this["MUAYENEGIRIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MuayeneBilgisiSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MuayeneBilgisiSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MuayeneBilgisiSil(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MuayeneBilgisiSil(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MuayeneBilgisiSil(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MUAYENEBILGISISIL", dataRow) { }
        protected MuayeneBilgisiSil(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MUAYENEBILGISISIL", dataRow, isImported) { }
        public MuayeneBilgisiSil(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MuayeneBilgisiSil(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MuayeneBilgisiSil() : base() { }

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