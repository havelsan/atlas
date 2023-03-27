
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SaglikTesisiAra")] 

    /// <summary>
    /// Sağlık Tesisi Ara
    /// </summary>
    public  partial class SaglikTesisiAra : BaseMedulaDefinitionAction
    {
        public class SaglikTesisiAraList : TTObjectCollection<SaglikTesisiAra> { }
                    
        public class ChildSaglikTesisiAraCollection : TTObject.TTChildObjectCollection<SaglikTesisiAra>
        {
            public ChildSaglikTesisiAraCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSaglikTesisiAraCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("123e68e3-4293-4c76-a6f5-5c8be4b7bab4"); } }
            public static Guid Completed { get { return new Guid("ddde62d2-bb28-4c6e-909a-bddfdae1694c"); } }
            public static Guid New { get { return new Guid("4a411ac1-9d1b-4d74-874a-440172b5e2af"); } }
            public static Guid SentMedula { get { return new Guid("1afa706c-9042-4d8c-abc2-96ed0e443b72"); } }
            public static Guid SentServer { get { return new Guid("b5d89cac-a218-4331-8a52-3a577882af3e"); } }
            public static Guid Successfully { get { return new Guid("3f9f35ed-50bc-40e5-977f-e042f34f9a76"); } }
            public static Guid Unsuccessfully { get { return new Guid("c24d12db-f357-4b86-a254-8e3554b2046a"); } }
        }

        public static BindingList<SaglikTesisiAra.GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class> GetSaglikTesisiAraWillBeSentToMedulaReportQuery(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISIARA"].QueryDefs["GetSaglikTesisiAraWillBeSentToMedulaReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<SaglikTesisiAra.GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SaglikTesisiAra.GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class> GetSaglikTesisiAraWillBeSentToMedulaReportQuery(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISIARA"].QueryDefs["GetSaglikTesisiAraWillBeSentToMedulaReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<SaglikTesisiAra.GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SaglikTesisiAra> GetSaglikTesisiAraWillBeSentToMedula(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISIARA"].QueryDefs["GetSaglikTesisiAraWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SaglikTesisiAra>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Saglik Tesisi Ara Giriş
    /// </summary>
        public SaglikTesisiAraGirisDVO saglikTesisiAraGirisDVO
        {
            get { return (SaglikTesisiAraGirisDVO)((ITTObject)this).GetParent("SAGLIKTESISIARAGIRISDVO"); }
            set { this["SAGLIKTESISIARAGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SaglikTesisiAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SaglikTesisiAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SaglikTesisiAra(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SaglikTesisiAra(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SaglikTesisiAra(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SAGLIKTESISIARA", dataRow) { }
        protected SaglikTesisiAra(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SAGLIKTESISIARA", dataRow, isImported) { }
        public SaglikTesisiAra(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SaglikTesisiAra(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SaglikTesisiAra() : base() { }

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