
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="YeniHastaKabul")] 

    /// <summary>
    /// Yeni Hasta Kabul
    /// </summary>
    public  partial class YeniHastaKabul : BaseHastaKabul
    {
        public class YeniHastaKabulList : TTObjectCollection<YeniHastaKabul> { }
                    
        public class ChildYeniHastaKabulCollection : TTObject.TTChildObjectCollection<YeniHastaKabul>
        {
            public ChildYeniHastaKabulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildYeniHastaKabulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetYeniHastaKabulWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetYeniHastaKabulWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetYeniHastaKabulWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetYeniHastaKabulWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("5cef2082-af2c-4a96-bc4a-0785bb04800d"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("94e8f760-eae0-4343-8cb6-a39fa41b7283"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("fe015986-fe9d-4b31-b195-770522eb1c6d"); } }
            public static Guid SentServer { get { return new Guid("b3ef14f8-20b5-4beb-b332-1826529e1ab9"); } }
            public static Guid New { get { return new Guid("57e5a56f-8c43-4a79-89c6-19c0d438f620"); } }
            public static Guid SentMedula { get { return new Guid("a3c1d7ef-5abd-4884-b75d-b27a2c4cd88d"); } }
        }

        public static BindingList<YeniHastaKabul> GetYeniHastaKabulWillBeSentToMedula(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIHASTAKABUL"].QueryDefs["GetYeniHastaKabulWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<YeniHastaKabul>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<YeniHastaKabul.GetYeniHastaKabulWillBeSentToMedulaRQ_Class> GetYeniHastaKabulWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIHASTAKABUL"].QueryDefs["GetYeniHastaKabulWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<YeniHastaKabul.GetYeniHastaKabulWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<YeniHastaKabul.GetYeniHastaKabulWillBeSentToMedulaRQ_Class> GetYeniHastaKabulWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIHASTAKABUL"].QueryDefs["GetYeniHastaKabulWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<YeniHastaKabul.GetYeniHastaKabulWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected YeniHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected YeniHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected YeniHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected YeniHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected YeniHastaKabul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "YENIHASTAKABUL", dataRow) { }
        protected YeniHastaKabul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "YENIHASTAKABUL", dataRow, isImported) { }
        public YeniHastaKabul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public YeniHastaKabul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public YeniHastaKabul() : base() { }

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