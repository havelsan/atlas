
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaKabulOku")] 

    /// <summary>
    /// Hasta Kabul Oku
    /// </summary>
    public  partial class HastaKabulOku : BaseHastaKabulOku
    {
        public class HastaKabulOkuList : TTObjectCollection<HastaKabulOku> { }
                    
        public class ChildHastaKabulOkuCollection : TTObject.TTChildObjectCollection<HastaKabulOku>
        {
            public ChildHastaKabulOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaKabulOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHastaKabulOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHastaKabulOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHastaKabulOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHastaKabulOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("62f8609d-9c99-43f4-87ee-9fd9d1fd5aae"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("19696870-8187-469a-bd17-e87ee92b52cb"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("a83c0c8c-70e3-4cd8-aac1-9ca3336dbea6"); } }
            public static Guid New { get { return new Guid("0420d1e0-1238-4e77-b85d-517771c17029"); } }
            public static Guid SentMedula { get { return new Guid("6524aa33-3d23-47df-a2fa-7c58a95db757"); } }
            public static Guid SentServer { get { return new Guid("4729285a-02f8-40c8-9f70-dcf50baa869a"); } }
        }

        public static BindingList<HastaKabulOku> GetHastaKabulOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULOKU"].QueryDefs["GetHastaKabulOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaKabulOku>(queryDef, paramList);
        }

        public static BindingList<HastaKabulOku.GetHastaKabulOkuWillBeSentToMedulaRQ_Class> GetHastaKabulOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULOKU"].QueryDefs["GetHastaKabulOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulOku.GetHastaKabulOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaKabulOku.GetHastaKabulOkuWillBeSentToMedulaRQ_Class> GetHastaKabulOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULOKU"].QueryDefs["GetHastaKabulOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulOku.GetHastaKabulOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected HastaKabulOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaKabulOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaKabulOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaKabulOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaKabulOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAKABULOKU", dataRow) { }
        protected HastaKabulOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAKABULOKU", dataRow, isImported) { }
        public HastaKabulOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaKabulOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaKabulOku() : base() { }

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