
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HizmetKaydiOku")] 

    /// <summary>
    /// Hizmet Kaydı Oku
    /// </summary>
    public  partial class HizmetKaydiOku : BaseMedulaAction
    {
        public class HizmetKaydiOkuList : TTObjectCollection<HizmetKaydiOku> { }
                    
        public class ChildHizmetKaydiOkuCollection : TTObject.TTChildObjectCollection<HizmetKaydiOku>
        {
            public ChildHizmetKaydiOkuCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHizmetKaydiOkuCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("c69eff87-91a8-497c-98bf-e967241757c1"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("8c922419-7c97-48cb-83c3-96bfe26b2b91"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("a4d48949-922b-434f-b139-93777f4c1f03"); } }
            public static Guid New { get { return new Guid("8ab6a488-7bcb-4b60-a1c0-f63dbb972490"); } }
            public static Guid SentMedula { get { return new Guid("39ab466d-9797-4089-9619-809882e2c1e6"); } }
            public static Guid SentServer { get { return new Guid("d54dc12f-9b6e-406b-89f9-4d0f3626300c"); } }
        }

        public static BindingList<HizmetKaydiOku> GetHizmetKaydiOkuWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYDIOKU"].QueryDefs["GetHizmetKaydiOkuWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HizmetKaydiOku>(queryDef, paramList);
        }

        public static BindingList<HizmetKaydiOku.GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class> GetHizmetKaydiOkuWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYDIOKU"].QueryDefs["GetHizmetKaydiOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HizmetKaydiOku.GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HizmetKaydiOku.GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class> GetHizmetKaydiOkuWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HIZMETKAYDIOKU"].QueryDefs["GetHizmetKaydiOkuWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HizmetKaydiOku.GetHizmetKaydiOkuWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hizmet Oku Giriş
    /// </summary>
        public HizmetOkuGirisDVO hizmetOkuGirisDVO
        {
            get { return (HizmetOkuGirisDVO)((ITTObject)this).GetParent("HIZMETOKUGIRISDVO"); }
            set { this["HIZMETOKUGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HizmetKaydiOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HizmetKaydiOku(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HizmetKaydiOku(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HizmetKaydiOku(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HizmetKaydiOku(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HIZMETKAYDIOKU", dataRow) { }
        protected HizmetKaydiOku(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HIZMETKAYDIOKU", dataRow, isImported) { }
        public HizmetKaydiOku(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HizmetKaydiOku(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HizmetKaydiOku() : base() { }

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