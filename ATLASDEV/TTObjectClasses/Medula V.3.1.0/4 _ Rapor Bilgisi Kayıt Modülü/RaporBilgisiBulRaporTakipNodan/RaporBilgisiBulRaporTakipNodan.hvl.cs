
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporBilgisiBulRaporTakipNodan")] 

    /// <summary>
    /// Rapor Bilgisi Bul Rapor Takip Numarasından
    /// </summary>
    public  partial class RaporBilgisiBulRaporTakipNodan : BaseMedulaAction
    {
        public class RaporBilgisiBulRaporTakipNodanList : TTObjectCollection<RaporBilgisiBulRaporTakipNodan> { }
                    
        public class ChildRaporBilgisiBulRaporTakipNodanCollection : TTObject.TTChildObjectCollection<RaporBilgisiBulRaporTakipNodan>
        {
            public ChildRaporBilgisiBulRaporTakipNodanCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporBilgisiBulRaporTakipNodanCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("a5119140-5b64-41b8-9436-eccd9dc1ca18"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("233fb496-8ff9-4536-94da-d9bb0f3e4726"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("c196f1e4-4a74-4b1e-81f3-cac00816aa39"); } }
            public static Guid New { get { return new Guid("7aa55431-f476-4e0d-8666-c5e4b2c90edc"); } }
            public static Guid SentMedula { get { return new Guid("51eb06f0-93f5-466e-8ded-59a260511887"); } }
            public static Guid SentServer { get { return new Guid("4536e59a-06e8-4001-9068-1eddbb853478"); } }
        }

        public static BindingList<RaporBilgisiBulRaporTakipNodan.GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class> GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBULRAPORTAKIPNODAN"].QueryDefs["GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiBulRaporTakipNodan.GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiBulRaporTakipNodan.GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class> GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBULRAPORTAKIPNODAN"].QueryDefs["GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporBilgisiBulRaporTakipNodan.GetRaporBilgisiBulRaporTakipNoWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporBilgisiBulRaporTakipNodan> GetRaporBilgisiBulRaporTakipNoWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORBILGISIBULRAPORTAKIPNODAN"].QueryDefs["GetRaporBilgisiBulRaporTakipNoWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RaporBilgisiBulRaporTakipNodan>(queryDef, paramList);
        }

    /// <summary>
    /// Rapor Oku Rapor Takip Numarasından
    /// </summary>
        public RaporOkuRaporTakipNodanDVO raporOkuRaporTakipNodanDVO
        {
            get { return (RaporOkuRaporTakipNodanDVO)((ITTObject)this).GetParent("RAPOROKURAPORTAKIPNODANDVO"); }
            set { this["RAPOROKURAPORTAKIPNODANDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporBilgisiBulRaporTakipNodan(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporBilgisiBulRaporTakipNodan(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporBilgisiBulRaporTakipNodan(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporBilgisiBulRaporTakipNodan(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporBilgisiBulRaporTakipNodan(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORBILGISIBULRAPORTAKIPNODAN", dataRow) { }
        protected RaporBilgisiBulRaporTakipNodan(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORBILGISIBULRAPORTAKIPNODAN", dataRow, isImported) { }
        public RaporBilgisiBulRaporTakipNodan(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporBilgisiBulRaporTakipNodan(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporBilgisiBulRaporTakipNodan() : base() { }

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