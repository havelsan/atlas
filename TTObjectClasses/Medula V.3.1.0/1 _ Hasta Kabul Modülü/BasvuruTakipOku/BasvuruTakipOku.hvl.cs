
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BasvuruTakipOku")] 

    /// <summary>
    /// Başvuru Takip Oku
    /// </summary>
    public  partial class BasvuruTakipOku : BaseMedulaAction
    {
        public class BasvuruTakipOkuList : TTObjectCollection<BasvuruTakipOku> { }
                    
        public class ChildBasvuruTakipOkuCollection : TTObject.TTChildObjectCollection<BasvuruTakipOku>
        {
            public ChildBasvuruTakipOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBasvuruTakipOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("ec23605b-4381-40ee-9073-ba8c94a0d458"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("72c955bc-e826-4637-86aa-5b7504588beb"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("aeb482ff-a5fd-4960-ad21-fdfd9467d79a"); } }
            public static Guid New { get { return new Guid("b436b256-0786-4b6d-b443-22dae91095c6"); } }
            public static Guid SentMedula { get { return new Guid("056d4c74-5d3a-4a1b-9fc3-129a9b89c0b5"); } }
            public static Guid SentServer { get { return new Guid("87cdf493-16d6-4c24-8560-84c84f77ea37"); } }
        }

        public static BindingList<BasvuruTakipOku> GetBasvuruTakipOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASVURUTAKIPOKU"].QueryDefs["GetBasvuruTakipOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BasvuruTakipOku>(queryDef, paramList);
        }

        public static BindingList<BasvuruTakipOku.GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class> GetBasvuruTakipOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASVURUTAKIPOKU"].QueryDefs["GetBasvuruTakipOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<BasvuruTakipOku.GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BasvuruTakipOku.GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class> GetBasvuruTakipOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASVURUTAKIPOKU"].QueryDefs["GetBasvuruTakipOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<BasvuruTakipOku.GetBasvuruTakipOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Başvuru Takip Oku
    /// </summary>
        public BasvuruTakipOkuDVO basvuruTakipOkuDVO
        {
            get { return (BasvuruTakipOkuDVO)((ITTObject)this).GetParent("BASVURUTAKIPOKUDVO"); }
            set { this["BASVURUTAKIPOKUDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BasvuruTakipOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BasvuruTakipOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BasvuruTakipOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BasvuruTakipOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BasvuruTakipOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASVURUTAKIPOKU", dataRow) { }
        protected BasvuruTakipOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASVURUTAKIPOKU", dataRow, isImported) { }
        public BasvuruTakipOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BasvuruTakipOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BasvuruTakipOku() : base() { }

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