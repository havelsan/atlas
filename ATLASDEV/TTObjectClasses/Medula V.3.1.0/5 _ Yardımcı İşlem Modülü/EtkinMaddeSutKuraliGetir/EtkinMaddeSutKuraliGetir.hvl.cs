
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EtkinMaddeSutKuraliGetir")] 

    public  partial class EtkinMaddeSutKuraliGetir : BaseMedulaDefinitionAction
    {
        public class EtkinMaddeSutKuraliGetirList : TTObjectCollection<EtkinMaddeSutKuraliGetir> { }
                    
        public class ChildEtkinMaddeSutKuraliGetirCollection : TTObject.TTChildObjectCollection<EtkinMaddeSutKuraliGetir>
        {
            public ChildEtkinMaddeSutKuraliGetirCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEtkinMaddeSutKuraliGetirCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Unsuccessfully { get { return new Guid("3c817127-dd73-4273-b257-f1596b2cedfd"); } }
            public static Guid Cancelled { get { return new Guid("12bd321e-82d7-4c52-8022-90a10cda138c"); } }
            public static Guid Completed { get { return new Guid("0986d3ff-9297-4197-ae8a-14364b26bd37"); } }
            public static Guid New { get { return new Guid("b81f6342-fe9b-49d7-a801-c69cad447409"); } }
            public static Guid SentMedula { get { return new Guid("79a57888-51c7-41c2-b5fb-3f2959c503ec"); } }
            public static Guid SentServer { get { return new Guid("cac6c252-cb70-4112-9f54-df84005f4363"); } }
            public static Guid Successfully { get { return new Guid("fb9e6fcc-5863-47be-8268-be5231ffca82"); } }
        }

        public static BindingList<EtkinMaddeSutKuraliGetir> GetEtkinMaddeSutKuraliGetirWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDESUTKURALIGETIR"].QueryDefs["GetEtkinMaddeSutKuraliGetirWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<EtkinMaddeSutKuraliGetir>(queryDef, paramList);
        }

        public static BindingList<EtkinMaddeSutKuraliGetir.GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class> GetEMSutKuraliGetirWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDESUTKURALIGETIR"].QueryDefs["GetEMSutKuraliGetirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<EtkinMaddeSutKuraliGetir.GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EtkinMaddeSutKuraliGetir.GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class> GetEMSutKuraliGetirWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDESUTKURALIGETIR"].QueryDefs["GetEMSutKuraliGetirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<EtkinMaddeSutKuraliGetir.GetEMSutKuraliGetirWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public EtkinMaddeSUTGirisDVO etkinMaddeSUTGirisDVO
        {
            get { return (EtkinMaddeSUTGirisDVO)((ITTObject)this).GetParent("ETKINMADDESUTGIRISDVO"); }
            set { this["ETKINMADDESUTGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EtkinMaddeSutKuraliGetir(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EtkinMaddeSutKuraliGetir(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EtkinMaddeSutKuraliGetir(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EtkinMaddeSutKuraliGetir(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EtkinMaddeSutKuraliGetir(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ETKINMADDESUTKURALIGETIR", dataRow) { }
        protected EtkinMaddeSutKuraliGetir(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ETKINMADDESUTKURALIGETIR", dataRow, isImported) { }
        public EtkinMaddeSutKuraliGetir(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EtkinMaddeSutKuraliGetir(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EtkinMaddeSutKuraliGetir() : base() { }

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