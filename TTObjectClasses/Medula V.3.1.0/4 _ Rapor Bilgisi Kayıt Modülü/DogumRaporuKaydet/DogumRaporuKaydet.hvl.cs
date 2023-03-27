
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DogumRaporuKaydet")] 

    public  partial class DogumRaporuKaydet : BaseDogumRaporuKaydet
    {
        public class DogumRaporuKaydetList : TTObjectCollection<DogumRaporuKaydet> { }
                    
        public class ChildDogumRaporuKaydetCollection : TTObject.TTChildObjectCollection<DogumRaporuKaydet>
        {
            public ChildDogumRaporuKaydetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDogumRaporuKaydetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("e85fede2-972a-4f25-9fe1-0fc9e3649b33"); } }
            public static Guid SentMedula { get { return new Guid("ce64bced-356e-49a8-9f06-0bf5a39520d3"); } }
            public static Guid SentServer { get { return new Guid("1b317431-be29-45ca-8e5e-fa4494e31117"); } }
            public static Guid Cancelled { get { return new Guid("1645e237-eb99-4f30-9147-8a279a49a7cb"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("6e9b1aa2-32c6-4212-9bd4-309086c71cf8"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("a69aded9-494d-49c6-8406-5cda5c252102"); } }
        }

        public static BindingList<DogumRaporuKaydet.GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class> GetDogumRaporuKaydetWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOGUMRAPORUKAYDET"].QueryDefs["GetDogumRaporuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DogumRaporuKaydet.GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DogumRaporuKaydet.GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class> GetDogumRaporuKaydetWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOGUMRAPORUKAYDET"].QueryDefs["GetDogumRaporuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DogumRaporuKaydet.GetDogumRaporuKaydetWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected DogumRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DogumRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DogumRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DogumRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DogumRaporuKaydet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOGUMRAPORUKAYDET", dataRow) { }
        protected DogumRaporuKaydet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOGUMRAPORUKAYDET", dataRow, isImported) { }
        public DogumRaporuKaydet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DogumRaporuKaydet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DogumRaporuKaydet() : base() { }

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