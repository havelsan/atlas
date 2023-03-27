
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrneklenmisTakipler")] 

    /// <summary>
    /// Örneklenmiş Takipler
    /// </summary>
    public  partial class OrneklenmisTakipler : BaseMedulaAction
    {
        public class OrneklenmisTakiplerList : TTObjectCollection<OrneklenmisTakipler> { }
                    
        public class ChildOrneklenmisTakiplerCollection : TTObject.TTChildObjectCollection<OrneklenmisTakipler>
        {
            public ChildOrneklenmisTakiplerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrneklenmisTakiplerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOTakiplerWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetOTakiplerWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOTakiplerWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOTakiplerWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("09a857a3-4fdc-42a3-8f1d-b599c8edf910"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("f87caaa1-fe3d-4a19-82c3-5f241be4926f"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("785df7c0-ae0e-486f-a6e8-ebd4f3c90265"); } }
            public static Guid New { get { return new Guid("c3870aff-db41-497f-b075-f3839340af7d"); } }
            public static Guid SentMedula { get { return new Guid("e147ede9-f3a2-4ca5-82a4-c40a08844450"); } }
            public static Guid SentServer { get { return new Guid("2a557731-85c2-4775-8d26-8cd589438755"); } }
        }

        public static BindingList<OrneklenmisTakipler.GetOTakiplerWillBeSentToMedulaRQ_Class> GetOTakiplerWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORNEKLENMISTAKIPLER"].QueryDefs["GetOTakiplerWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<OrneklenmisTakipler.GetOTakiplerWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrneklenmisTakipler.GetOTakiplerWillBeSentToMedulaRQ_Class> GetOTakiplerWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORNEKLENMISTAKIPLER"].QueryDefs["GetOTakiplerWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<OrneklenmisTakipler.GetOTakiplerWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrneklenmisTakipler> GetOrneklenmisTakiplerWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORNEKLENMISTAKIPLER"].QueryDefs["GetOrneklenmisTakiplerWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<OrneklenmisTakipler>(queryDef, paramList);
        }

    /// <summary>
    /// Örneklenmiş Takipler Giriş
    /// </summary>
        public OrneklenmisTakiplerGirisDVO orneklenmisTakiplerGirisDVO
        {
            get { return (OrneklenmisTakiplerGirisDVO)((ITTObject)this).GetParent("ORNEKLENMISTAKIPLERGIRISDVO"); }
            set { this["ORNEKLENMISTAKIPLERGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected OrneklenmisTakipler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrneklenmisTakipler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrneklenmisTakipler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrneklenmisTakipler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrneklenmisTakipler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORNEKLENMISTAKIPLER", dataRow) { }
        protected OrneklenmisTakipler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORNEKLENMISTAKIPLER", dataRow, isImported) { }
        public OrneklenmisTakipler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrneklenmisTakipler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrneklenmisTakipler() : base() { }

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