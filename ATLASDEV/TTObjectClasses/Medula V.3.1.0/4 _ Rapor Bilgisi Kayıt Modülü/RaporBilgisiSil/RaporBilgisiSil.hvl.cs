
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporBilgisiSil")] 

    /// <summary>
    /// Rapor Bilgisi Sil
    /// </summary>
    public  partial class RaporBilgisiSil : BaseRaporBilgisiBulSil
    {
        public class RaporBilgisiSilList : TTObjectCollection<RaporBilgisiSil> { }
                    
        public class ChildRaporBilgisiSilCollection : TTObject.TTChildObjectCollection<RaporBilgisiSil>
        {
            public ChildRaporBilgisiSilCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporBilgisiSilCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporBilgisiSilWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRaporBilgisiSilWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporBilgisiSilWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporBilgisiSilWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("7c53f6e6-79f2-470a-99b7-bfc0df58c9f1"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("72be5905-db73-4835-9108-9abb70f59e07"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("dd5b1f64-f87f-4b28-9317-c9b07a1ad85a"); } }
            public static Guid New { get { return new Guid("edd2222e-0df8-4e99-b6f6-59e50f81cd3b"); } }
            public static Guid SentMedula { get { return new Guid("ca5ffbf5-7390-4f48-ad43-a1f57d2d9eb1"); } }
            public static Guid SentServer { get { return new Guid("ccb0fb9b-7056-4644-9378-4208e473aca3"); } }
        }

        public static BindingList<RaporBilgisiSil.GetRaporBilgisiSilWillBeSentToMedulaRQ_Class> GetRaporBilgisiSilWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISISIL"].QueryDefs["GetRaporBilgisiSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiSil.GetRaporBilgisiSilWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiSil.GetRaporBilgisiSilWillBeSentToMedulaRQ_Class> GetRaporBilgisiSilWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISISIL"].QueryDefs["GetRaporBilgisiSilWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiSil.GetRaporBilgisiSilWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiSil> GetRaporBilgisiSilWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISISIL"].QueryDefs["GetRaporBilgisiSilWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RaporBilgisiSil>(queryDef, paramList);
        }

        protected RaporBilgisiSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporBilgisiSil(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporBilgisiSil(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporBilgisiSil(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporBilgisiSil(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORBILGISISIL", dataRow) { }
        protected RaporBilgisiSil(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORBILGISISIL", dataRow, isImported) { }
        public RaporBilgisiSil(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporBilgisiSil(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporBilgisiSil() : base() { }

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