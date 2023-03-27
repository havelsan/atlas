
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="YeniDonorHastaKabul")] 

    /// <summary>
    /// Yeni Donör Hasta Kabul
    /// </summary>
    public  partial class YeniDonorHastaKabul : BaseHastaKabul
    {
        public class YeniDonorHastaKabulList : TTObjectCollection<YeniDonorHastaKabul> { }
                    
        public class ChildYeniDonorHastaKabulCollection : TTObject.TTChildObjectCollection<YeniDonorHastaKabul>
        {
            public ChildYeniDonorHastaKabulCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildYeniDonorHastaKabulCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetYeniDonorHKWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetYeniDonorHKWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetYeniDonorHKWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetYeniDonorHKWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("d449d538-33d1-4bfb-a2c0-c37ef8cedf39"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("fdef599c-56d2-48f3-afee-6353798a0069"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("d97ee8e7-079f-44e8-81c1-8c1b861c8125"); } }
            public static Guid New { get { return new Guid("cfb21a20-21d7-42f2-8bc2-ee578c822376"); } }
            public static Guid SentMedula { get { return new Guid("d09ffc97-7765-4c6a-9dd2-0eb23c9935f1"); } }
            public static Guid SentServer { get { return new Guid("45a57101-0183-434e-89f7-2c7427a67e90"); } }
        }

        public static BindingList<YeniDonorHastaKabul.GetYeniDonorHKWillBeSentToMedulaRQ_Class> GetYeniDonorHKWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIDONORHASTAKABUL"].QueryDefs["GetYeniDonorHKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<YeniDonorHastaKabul.GetYeniDonorHKWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<YeniDonorHastaKabul.GetYeniDonorHKWillBeSentToMedulaRQ_Class> GetYeniDonorHKWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIDONORHASTAKABUL"].QueryDefs["GetYeniDonorHKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<YeniDonorHastaKabul.GetYeniDonorHKWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<YeniDonorHastaKabul> GetYeniDonorHastaKabulWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["YENIDONORHASTAKABUL"].QueryDefs["GetYeniDonorHastaKabulWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<YeniDonorHastaKabul>(queryDef, paramList);
        }

        protected YeniDonorHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected YeniDonorHastaKabul(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected YeniDonorHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected YeniDonorHastaKabul(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected YeniDonorHastaKabul(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "YENIDONORHASTAKABUL", dataRow) { }
        protected YeniDonorHastaKabul(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "YENIDONORHASTAKABUL", dataRow, isImported) { }
        public YeniDonorHastaKabul(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public YeniDonorHastaKabul(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public YeniDonorHastaKabul() : base() { }

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