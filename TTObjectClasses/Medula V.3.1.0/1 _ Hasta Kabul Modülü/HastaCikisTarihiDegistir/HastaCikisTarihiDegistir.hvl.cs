
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaCikisTarihiDegistir")] 

    /// <summary>
    /// Hasta Çıkış Tarihi Değiştir
    /// </summary>
    public  partial class HastaCikisTarihiDegistir : BaseHastaCikisIptal
    {
        public class HastaCikisTarihiDegistirList : TTObjectCollection<HastaCikisTarihiDegistir> { }
                    
        public class ChildHastaCikisTarihiDegistirCollection : TTObject.TTChildObjectCollection<HastaCikisTarihiDegistir>
        {
            public ChildHastaCikisTarihiDegistirCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaCikisTarihiDegistirCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("4c9620a8-b0db-4c83-9056-717bde6b72f3"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("8959568c-1d74-46b9-8d0c-57644e1f71b9"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("2d4b9942-c1da-418f-936f-02e8916dc66e"); } }
            public static Guid New { get { return new Guid("b786818a-0038-4b3b-b60e-b5894e52112e"); } }
            public static Guid SentMedula { get { return new Guid("5f521b5d-5e9c-4d49-925f-2ccf6b4644ac"); } }
            public static Guid SentServer { get { return new Guid("cf0f151b-c646-4d81-93bd-dba94df093ac"); } }
        }

        public static BindingList<HastaCikisTarihiDegistir> GetHastaCikisTarihiDegistirWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISTARIHIDEGISTIR"].QueryDefs["GetHastaCikisTarihiDegistirWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaCikisTarihiDegistir>(queryDef, paramList);
        }

        public static BindingList<HastaCikisTarihiDegistir.GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class> GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISTARIHIDEGISTIR"].QueryDefs["GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaCikisTarihiDegistir.GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaCikisTarihiDegistir.GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class> GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISTARIHIDEGISTIR"].QueryDefs["GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaCikisTarihiDegistir.GetHastaCikisTarihiDegistirWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected HastaCikisTarihiDegistir(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaCikisTarihiDegistir(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaCikisTarihiDegistir(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaCikisTarihiDegistir(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaCikisTarihiDegistir(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTACIKISTARIHIDEGISTIR", dataRow) { }
        protected HastaCikisTarihiDegistir(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTACIKISTARIHIDEGISTIR", dataRow, isImported) { }
        public HastaCikisTarihiDegistir(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaCikisTarihiDegistir(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaCikisTarihiDegistir() : base() { }

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