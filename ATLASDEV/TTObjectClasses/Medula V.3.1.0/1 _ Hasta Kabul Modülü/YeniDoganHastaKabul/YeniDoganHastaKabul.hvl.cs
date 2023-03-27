
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="YeniDoganHastaKabul")] 

    /// <summary>
    /// Yeni Doğan Hasta Kabul
    /// </summary>
    public  partial class YeniDoganHastaKabul : BaseHastaKabul
    {
        public class YeniDoganHastaKabulList : TTObjectCollection<YeniDoganHastaKabul> { }
                    
        public class ChildYeniDoganHastaKabulCollection : TTObject.TTChildObjectCollection<YeniDoganHastaKabul>
        {
            public ChildYeniDoganHastaKabulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildYeniDoganHastaKabulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetYeniDoganHKWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetYeniDoganHKWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetYeniDoganHKWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetYeniDoganHKWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("d85920bd-f8f2-40c6-b33f-a27b3a068b0c"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("8f0cab18-a358-4c21-92fb-b1edf1f50e26"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("736ee77e-1d43-46b1-97f3-1f976faa88fb"); } }
            public static Guid New { get { return new Guid("f3cbad07-78b9-4283-9eb7-d0ab975807f5"); } }
            public static Guid SentMedula { get { return new Guid("1e474b4b-e161-4616-8ac7-6da14a9c143e"); } }
            public static Guid SentServer { get { return new Guid("87288072-ca44-4bc5-9119-b7eac9303db9"); } }
        }

        public static BindingList<YeniDoganHastaKabul.GetYeniDoganHKWillBeSentToMedulaRQ_Class> GetYeniDoganHKWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIDOGANHASTAKABUL"].QueryDefs["GetYeniDoganHKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<YeniDoganHastaKabul.GetYeniDoganHKWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<YeniDoganHastaKabul.GetYeniDoganHKWillBeSentToMedulaRQ_Class> GetYeniDoganHKWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIDOGANHASTAKABUL"].QueryDefs["GetYeniDoganHKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<YeniDoganHastaKabul.GetYeniDoganHKWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<YeniDoganHastaKabul> GetYeniDoganHastaKabulWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIDOGANHASTAKABUL"].QueryDefs["GetYeniDoganHastaKabulWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<YeniDoganHastaKabul>(queryDef, paramList);
        }

        protected YeniDoganHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected YeniDoganHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected YeniDoganHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected YeniDoganHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected YeniDoganHastaKabul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "YENIDOGANHASTAKABUL", dataRow) { }
        protected YeniDoganHastaKabul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "YENIDOGANHASTAKABUL", dataRow, isImported) { }
        public YeniDoganHastaKabul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public YeniDoganHastaKabul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public YeniDoganHastaKabul() : base() { }

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