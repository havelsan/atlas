
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaKabulTedaviTipiDegistir")] 

    /// <summary>
    /// Hasta Kabul Tedavi Tipi Değiştir
    /// </summary>
    public  partial class HastaKabulTedaviTipiDegistir : BaseHastaKabulOku
    {
        public class HastaKabulTedaviTipiDegistirList : TTObjectCollection<HastaKabulTedaviTipiDegistir> { }
                    
        public class ChildHastaKabulTedaviTipiDegistirCollection : TTObject.TTChildObjectCollection<HastaKabulTedaviTipiDegistir>
        {
            public ChildHastaKabulTedaviTipiDegistirCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaKabulTedaviTipiDegistirCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("a384f43b-538b-4b2e-9846-3e823000acd0"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("e7516451-b4c8-4448-86b5-63d53284f4b3"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("ddf944a7-2f36-404d-adb7-41d6ae447faf"); } }
            public static Guid New { get { return new Guid("7e6463c7-b9ae-44d4-ac4b-c2ad6fd2046b"); } }
            public static Guid SentMedula { get { return new Guid("8525de9d-4269-4563-9fb7-4552be234a28"); } }
            public static Guid SentServer { get { return new Guid("a7e2f38d-4e11-4ec9-9539-b8852375580b"); } }
        }

        public static BindingList<HastaKabulTedaviTipiDegistir> GetHastaKabulTedaviTipiDegistirWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULTEDAVITIPIDEGISTIR"].QueryDefs["GetHastaKabulTedaviTipiDegistirWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaKabulTedaviTipiDegistir>(queryDef, paramList);
        }

        public static BindingList<HastaKabulTedaviTipiDegistir.GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class> GetHKTedaviTipiDegistirWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULTEDAVITIPIDEGISTIR"].QueryDefs["GetHKTedaviTipiDegistirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulTedaviTipiDegistir.GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaKabulTedaviTipiDegistir.GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class> GetHKTedaviTipiDegistirWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTAKABULTEDAVITIPIDEGISTIR"].QueryDefs["GetHKTedaviTipiDegistirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaKabulTedaviTipiDegistir.GetHKTedaviTipiDegistirWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected HastaKabulTedaviTipiDegistir(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaKabulTedaviTipiDegistir(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaKabulTedaviTipiDegistir(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaKabulTedaviTipiDegistir(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaKabulTedaviTipiDegistir(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTAKABULTEDAVITIPIDEGISTIR", dataRow) { }
        protected HastaKabulTedaviTipiDegistir(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTAKABULTEDAVITIPIDEGISTIR", dataRow, isImported) { }
        public HastaKabulTedaviTipiDegistir(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaKabulTedaviTipiDegistir(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaKabulTedaviTipiDegistir() : base() { }

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