
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DogumRaporuKaydetTakipNoIle")] 

    public  partial class DogumRaporuKaydetTakipNoIle : BaseDogumRaporuKaydet
    {
        public class DogumRaporuKaydetTakipNoIleList : TTObjectCollection<DogumRaporuKaydetTakipNoIle> { }
                    
        public class ChildDogumRaporuKaydetTakipNoIleCollection : TTObject.TTChildObjectCollection<DogumRaporuKaydetTakipNoIle>
        {
            public ChildDogumRaporuKaydetTakipNoIleCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDogumRaporuKaydetTakipNoIleCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("0bbfd44a-0ff3-4625-9445-3378f11349d3"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("764356d8-debb-46ef-b124-3e0b18dd6b91"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("93682eaa-bbc9-43c5-bd53-807bb2765dc8"); } }
            public static Guid New { get { return new Guid("ffce2e7e-b325-4c0d-9621-48b90b0af21f"); } }
            public static Guid SentMedula { get { return new Guid("d21d38da-c211-4e4e-8fc9-90da13e79ce4"); } }
            public static Guid SentServer { get { return new Guid("2ddd4037-fb1b-4244-ab91-1d7d5b2367e6"); } }
        }

        public static BindingList<DogumRaporuKaydetTakipNoIle.GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOGUMRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DogumRaporuKaydetTakipNoIle.GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DogumRaporuKaydetTakipNoIle.GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class> GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOGUMRAPORUKAYDETTAKIPNOILE"].QueryDefs["GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DogumRaporuKaydetTakipNoIle.GetDogumRaporuKaydetTakipNoIleWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected DogumRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DogumRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DogumRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DogumRaporuKaydetTakipNoIle(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DogumRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOGUMRAPORUKAYDETTAKIPNOILE", dataRow) { }
        protected DogumRaporuKaydetTakipNoIle(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOGUMRAPORUKAYDETTAKIPNOILE", dataRow, isImported) { }
        public DogumRaporuKaydetTakipNoIle(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DogumRaporuKaydetTakipNoIle(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DogumRaporuKaydetTakipNoIle() : base() { }

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