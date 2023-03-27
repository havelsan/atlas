
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacRaporuKaydet")] 

    public  partial class IlacRaporuKaydet : BaseIlacRaporuKaydet
    {
        public class IlacRaporuKaydetList : TTObjectCollection<IlacRaporuKaydet> { }
                    
        public class ChildIlacRaporuKaydetCollection : TTObject.TTChildObjectCollection<IlacRaporuKaydet>
        {
            public ChildIlacRaporuKaydetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacRaporuKaydetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("e46374e2-efe5-4d4f-a9e1-7dc5740791b7"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("0bc6b64c-7c1d-41ac-8e1b-5f1fbc461c16"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("842a0304-12c6-4f14-9d42-377548bdf1fd"); } }
            public static Guid New { get { return new Guid("0486875e-29e3-4614-8a92-a0436100da54"); } }
            public static Guid SentMedula { get { return new Guid("8bdbb8b7-2edd-4e4d-92a6-a7e7c264320f"); } }
            public static Guid SentServer { get { return new Guid("be2849b5-8506-4b48-9421-555ba8cd8fa5"); } }
        }

        public static BindingList<IlacRaporuKaydet.GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class> GetIlacRaporuKaydetWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACRAPORUKAYDET"].QueryDefs["GetIlacRaporuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacRaporuKaydet.GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IlacRaporuKaydet.GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class> GetIlacRaporuKaydetWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACRAPORUKAYDET"].QueryDefs["GetIlacRaporuKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacRaporuKaydet.GetIlacRaporuKaydetWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected IlacRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacRaporuKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacRaporuKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacRaporuKaydet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACRAPORUKAYDET", dataRow) { }
        protected IlacRaporuKaydet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACRAPORUKAYDET", dataRow, isImported) { }
        public IlacRaporuKaydet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacRaporuKaydet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacRaporuKaydet() : base() { }

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