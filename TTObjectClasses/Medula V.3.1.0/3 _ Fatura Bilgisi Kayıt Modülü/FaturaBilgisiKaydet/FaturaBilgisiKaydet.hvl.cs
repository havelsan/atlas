
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaBilgisiKaydet")] 

    /// <summary>
    /// Fatura Bilgisi Kaydet
    /// </summary>
    public  partial class FaturaBilgisiKaydet : BaseMedulaAction
    {
        public class FaturaBilgisiKaydetList : TTObjectCollection<FaturaBilgisiKaydet> { }
                    
        public class ChildFaturaBilgisiKaydetCollection : TTObject.TTChildObjectCollection<FaturaBilgisiKaydet>
        {
            public ChildFaturaBilgisiKaydetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaBilgisiKaydetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid CompletedSuccessfully { get { return new Guid("f3579a89-55a4-48ed-804b-493b06b97015"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("237b5ab5-6ca5-4019-b011-9fba6d0432b3"); } }
            public static Guid New { get { return new Guid("368f4b6d-69fc-47cd-a947-5352b84d5402"); } }
            public static Guid SentMedula { get { return new Guid("6e7ec26d-cf85-4da9-b829-0063c8920133"); } }
            public static Guid SentServer { get { return new Guid("6a49566b-dcdf-4a56-81d3-a6eeb75aacdd"); } }
            public static Guid Cancelled { get { return new Guid("87b59990-4d3c-4a62-b901-d26edbf005fc"); } }
        }

        public static BindingList<FaturaBilgisiKaydet.GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class> GetFaturaBilgisiKaydetWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURABILGISIKAYDET"].QueryDefs["GetFaturaBilgisiKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<FaturaBilgisiKaydet.GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FaturaBilgisiKaydet.GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class> GetFaturaBilgisiKaydetWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURABILGISIKAYDET"].QueryDefs["GetFaturaBilgisiKaydetWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<FaturaBilgisiKaydet.GetFaturaBilgisiKaydetWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FaturaBilgisiKaydet> GetFaturaBilgisiKaydetWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURABILGISIKAYDET"].QueryDefs["GetFaturaBilgisiKaydetWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FaturaBilgisiKaydet>(queryDef, paramList);
        }

    /// <summary>
    /// Fatura Giriş
    /// </summary>
        public FaturaGirisDVO faturaGirisDVO
        {
            get { return (FaturaGirisDVO)((ITTObject)this).GetParent("FATURAGIRISDVO"); }
            set { this["FATURAGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FaturaBilgisiKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaBilgisiKaydet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaBilgisiKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaBilgisiKaydet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaBilgisiKaydet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURABILGISIKAYDET", dataRow) { }
        protected FaturaBilgisiKaydet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURABILGISIKAYDET", dataRow, isImported) { }
        public FaturaBilgisiKaydet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaBilgisiKaydet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaBilgisiKaydet() : base() { }

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