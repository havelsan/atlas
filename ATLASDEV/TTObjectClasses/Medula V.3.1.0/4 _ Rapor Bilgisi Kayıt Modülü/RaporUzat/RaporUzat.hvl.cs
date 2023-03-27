
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RaporUzat")] 

    /// <summary>
    /// Rapor Uzat
    /// </summary>
    public  partial class RaporUzat : BaseMedulaAction
    {
        public class RaporUzatList : TTObjectCollection<RaporUzat> { }
                    
        public class ChildRaporUzatCollection : TTObject.TTChildObjectCollection<RaporUzat>
        {
            public ChildRaporUzatCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRaporUzatCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRaporUzatWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRaporUzatWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRaporUzatWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRaporUzatWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("ba16f77b-c1b1-46ac-b8a9-5302820cbc25"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("03b14847-af20-443d-945a-c807681eb815"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("4ed77f28-d88d-48f5-99a7-b72a8cedc692"); } }
            public static Guid New { get { return new Guid("99d38329-bc44-4eef-9550-b0bf77504838"); } }
            public static Guid SentMedula { get { return new Guid("4f4ccd44-8c8e-4c10-9a25-c5429887a96a"); } }
            public static Guid SentServer { get { return new Guid("a986c4ce-9546-4987-9967-ebc82e89357b"); } }
        }

        public static BindingList<RaporUzat> GetRaporUzatWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORUZAT"].QueryDefs["GetRaporUzatWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RaporUzat>(queryDef, paramList);
        }

        public static BindingList<RaporUzat.GetRaporUzatWillBeSentToMedulaRQ_Class> GetRaporUzatWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORUZAT"].QueryDefs["GetRaporUzatWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporUzat.GetRaporUzatWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RaporUzat.GetRaporUzatWillBeSentToMedulaRQ_Class> GetRaporUzatWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RAPORUZAT"].QueryDefs["GetRaporUzatWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<RaporUzat.GetRaporUzatWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İş Göremezlik Rapor Ek
    /// </summary>
        public IsgoremezlikRaporEkDVO isgoremezlikRaporEkDVO
        {
            get { return (IsgoremezlikRaporEkDVO)((ITTObject)this).GetParent("ISGOREMEZLIKRAPOREKDVO"); }
            set { this["ISGOREMEZLIKRAPOREKDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RaporUzat(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RaporUzat(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RaporUzat(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RaporUzat(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RaporUzat(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RAPORUZAT", dataRow) { }
        protected RaporUzat(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RAPORUZAT", dataRow, isImported) { }
        public RaporUzat(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RaporUzat(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RaporUzat() : base() { }

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