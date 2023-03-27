
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeleriOku")] 

    public  partial class EtkinMaddeleriOku : BaseMedulaDefinitionAction
    {
        public class EtkinMaddeleriOkuList : TTObjectCollection<EtkinMaddeleriOku> { }
                    
        public class ChildEtkinMaddeleriOkuCollection : TTObject.TTChildObjectCollection<EtkinMaddeleriOku>
        {
            public ChildEtkinMaddeleriOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeleriOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("2f653fcf-1ee6-4723-844e-351219f21a2d"); } }
            public static Guid Completed { get { return new Guid("25608d5d-4515-45ff-b199-4732a567d727"); } }
            public static Guid New { get { return new Guid("d988526a-c5e5-4747-ad41-ee8deeda41db"); } }
            public static Guid SentMedula { get { return new Guid("6e084ed8-8a0f-4a8f-8610-44541a9ea55a"); } }
            public static Guid SentServer { get { return new Guid("1b1fc3e0-3aa5-481b-905b-2f0496a76f78"); } }
            public static Guid Successfully { get { return new Guid("06fd09cc-c98f-47f8-840d-c3a7230821f4"); } }
            public static Guid Unsuccessfully { get { return new Guid("72f72208-3fca-4ba8-be9a-51a2ba7b3730"); } }
        }

        public static BindingList<EtkinMaddeleriOku> GetEtkinMaddeleriOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDELERIOKU"].QueryDefs["GetEtkinMaddeleriOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<EtkinMaddeleriOku>(queryDef, paramList);
        }

        public static BindingList<EtkinMaddeleriOku.GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class> GetEtkinMaddeleriOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDELERIOKU"].QueryDefs["GetEtkinMaddeleriOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<EtkinMaddeleriOku.GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EtkinMaddeleriOku.GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class> GetEtkinMaddeleriOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDELERIOKU"].QueryDefs["GetEtkinMaddeleriOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<EtkinMaddeleriOku.GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public EtkinMaddeOkuGirisDVO etkinMaddeOkuGirisDVO
        {
            get { return (EtkinMaddeOkuGirisDVO)((ITTObject)this).GetParent("ETKINMADDEOKUGIRISDVO"); }
            set { this["ETKINMADDEOKUGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EtkinMaddeleriOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeleriOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeleriOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeleriOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeleriOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDELERIOKU", dataRow) { }
        protected EtkinMaddeleriOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDELERIOKU", dataRow, isImported) { }
        public EtkinMaddeleriOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeleriOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeleriOku() : base() { }

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