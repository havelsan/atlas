
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaKabulProvizyonDegistir")] 

    /// <summary>
    /// Hasta Kabul Provizyon Degiştir
    /// </summary>
    public  partial class HastaKabulProvizyonDegistir : BaseMedulaAction
    {
        public class HastaKabulProvizyonDegistirList : TTObjectCollection<HastaKabulProvizyonDegistir> { }
                    
        public class ChildHastaKabulProvizyonDegistirCollection : TTObject.TTChildObjectCollection<HastaKabulProvizyonDegistir>
        {
            public ChildHastaKabulProvizyonDegistirCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaKabulProvizyonDegistirCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("903dc270-9311-49a0-bb9b-cba6c604895f"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("73f83884-c8c4-418b-a3f7-96beb742ead8"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("f606eea0-ca4c-4e1e-99eb-e0ff3553ee63"); } }
            public static Guid New { get { return new Guid("f6a788aa-f3e6-49af-8c7a-16923d00d3bc"); } }
            public static Guid SentMedula { get { return new Guid("690794e9-f299-46d6-8de4-ede35939466e"); } }
            public static Guid SentServer { get { return new Guid("24b4a58a-5cec-4c60-a868-8a60bc653087"); } }
        }

        public static BindingList<HastaKabulProvizyonDegistir> GetHastaKabulProvizyonDegistirWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULPROVIZYONDEGISTIR"].QueryDefs["GetHastaKabulProvizyonDegistirWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaKabulProvizyonDegistir>(queryDef, paramList);
        }

        public static BindingList<HastaKabulProvizyonDegistir.GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class> GetHKProvizyonDegistirWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULPROVIZYONDEGISTIR"].QueryDefs["GetHKProvizyonDegistirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulProvizyonDegistir.GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaKabulProvizyonDegistir.GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class> GetHKProvizyonDegistirWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULPROVIZYONDEGISTIR"].QueryDefs["GetHKProvizyonDegistirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulProvizyonDegistir.GetHKProvizyonDegistirWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Provizyon Degiştir Giriş
    /// </summary>
        public ProvizyonDegistirGirisDVO provizyonDegistirGirisDVO
        {
            get { return (ProvizyonDegistirGirisDVO)((ITTObject)this).GetParent("PROVIZYONDEGISTIRGIRISDVO"); }
            set { this["PROVIZYONDEGISTIRGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HastaKabulProvizyonDegistir(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaKabulProvizyonDegistir(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaKabulProvizyonDegistir(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaKabulProvizyonDegistir(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaKabulProvizyonDegistir(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAKABULPROVIZYONDEGISTIR", dataRow) { }
        protected HastaKabulProvizyonDegistir(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAKABULPROVIZYONDEGISTIR", dataRow, isImported) { }
        public HastaKabulProvizyonDegistir(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaKabulProvizyonDegistir(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaKabulProvizyonDegistir() : base() { }

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