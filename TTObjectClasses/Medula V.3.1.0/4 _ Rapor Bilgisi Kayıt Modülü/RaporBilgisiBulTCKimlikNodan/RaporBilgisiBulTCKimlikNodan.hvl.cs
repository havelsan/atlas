
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporBilgisiBulTCKimlikNodan")] 

    /// <summary>
    /// Rapor Bilgisi Bul TC Kimlik Numarasından
    /// </summary>
    public  partial class RaporBilgisiBulTCKimlikNodan : BaseMedulaAction
    {
        public class RaporBilgisiBulTCKimlikNodanList : TTObjectCollection<RaporBilgisiBulTCKimlikNodan> { }
                    
        public class ChildRaporBilgisiBulTCKimlikNodanCollection : TTObject.TTChildObjectCollection<RaporBilgisiBulTCKimlikNodan>
        {
            public ChildRaporBilgisiBulTCKimlikNodanCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporBilgisiBulTCKimlikNodanCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("c0ef18c0-1e24-44bd-b978-a1c5121cbb7e"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("b3f4b60a-af54-4504-8eee-7bc4922a3f9c"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("6da8b746-5b46-4bd7-a525-24a5e1aef98a"); } }
            public static Guid New { get { return new Guid("4bc74ca3-6f7d-449d-9e58-31dbe3b6ebbd"); } }
            public static Guid SentMedula { get { return new Guid("e75cd4df-bb1e-4d5b-b77d-9e087a6dd0c1"); } }
            public static Guid SentServer { get { return new Guid("44f34abb-fc19-43a5-847f-44af87e7482f"); } }
        }

        public static BindingList<RaporBilgisiBulTCKimlikNodan.GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class> GetRaporBilgisiBulTCKWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBULTCKIMLIKNODAN"].QueryDefs["GetRaporBilgisiBulTCKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiBulTCKimlikNodan.GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiBulTCKimlikNodan.GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class> GetRaporBilgisiBulTCKWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBULTCKIMLIKNODAN"].QueryDefs["GetRaporBilgisiBulTCKWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiBulTCKimlikNodan.GetRaporBilgisiBulTCKWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiBulTCKimlikNodan> GetRaporBilgisiBulTCKimlikNodanWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBULTCKIMLIKNODAN"].QueryDefs["GetRaporBilgisiBulTCKimlikNodanWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RaporBilgisiBulTCKimlikNodan>(queryDef, paramList);
        }

    /// <summary>
    /// Rapor Oku TC Kimlik Numarasından
    /// </summary>
        public RaporOkuTCKimlikNodanDVO raporOkuTCKimlikNodanDVO
        {
            get { return (RaporOkuTCKimlikNodanDVO)((ITTObject)this).GetParent("RAPOROKUTCKIMLIKNODANDVO"); }
            set { this["RAPOROKUTCKIMLIKNODANDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporBilgisiBulTCKimlikNodan(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporBilgisiBulTCKimlikNodan(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporBilgisiBulTCKimlikNodan(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporBilgisiBulTCKimlikNodan(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporBilgisiBulTCKimlikNodan(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORBILGISIBULTCKIMLIKNODAN", dataRow) { }
        protected RaporBilgisiBulTCKimlikNodan(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORBILGISIBULTCKIMLIKNODAN", dataRow, isImported) { }
        public RaporBilgisiBulTCKimlikNodan(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporBilgisiBulTCKimlikNodan(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporBilgisiBulTCKimlikNodan() : base() { }

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