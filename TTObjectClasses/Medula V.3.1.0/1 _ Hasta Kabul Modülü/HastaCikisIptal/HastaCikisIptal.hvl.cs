
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HastaCikisIptal")] 

    /// <summary>
    /// Hasta Çıkış İptal
    /// </summary>
    public  partial class HastaCikisIptal : BaseHastaCikisIptal
    {
        public class HastaCikisIptalList : TTObjectCollection<HastaCikisIptal> { }
                    
        public class ChildHastaCikisIptalCollection : TTObject.TTChildObjectCollection<HastaCikisIptal>
        {
            public ChildHastaCikisIptalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHastaCikisIptalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHastaCikisIptalWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHastaCikisIptalWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHastaCikisIptalWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHastaCikisIptalWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid CompletedSuccessfully { get { return new Guid("8eac085f-9c90-4883-983a-7bf776354edb"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("5473aecd-eb38-4a86-8653-24bf96e9ce19"); } }
            public static Guid New { get { return new Guid("b1a4c9e2-d1fd-4c61-b6a2-56486f88cb3d"); } }
            public static Guid SentMedula { get { return new Guid("6bb43e5b-a653-4b7e-80da-c76995b76e9c"); } }
            public static Guid SentServer { get { return new Guid("80ebe894-89ec-4e10-80ae-622f02f81850"); } }
            public static Guid Cancelled { get { return new Guid("2117a41f-c1fd-407a-ad65-58bf3f89ff6f"); } }
        }

        public static BindingList<HastaCikisIptal.GetHastaCikisIptalWillBeSentToMedulaRQ_Class> GetHastaCikisIptalWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISIPTAL"].QueryDefs["GetHastaCikisIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaCikisIptal.GetHastaCikisIptalWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaCikisIptal.GetHastaCikisIptalWillBeSentToMedulaRQ_Class> GetHastaCikisIptalWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISIPTAL"].QueryDefs["GetHastaCikisIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<HastaCikisIptal.GetHastaCikisIptalWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HastaCikisIptal> GetHastaCikisIptalWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HASTACIKISIPTAL"].QueryDefs["GetHastaCikisIptalWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<HastaCikisIptal>(queryDef, paramList);
        }

        protected HastaCikisIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HastaCikisIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HastaCikisIptal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HastaCikisIptal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HastaCikisIptal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HASTACIKISIPTAL", dataRow) { }
        protected HastaCikisIptal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HASTACIKISIPTAL", dataRow, isImported) { }
        public HastaCikisIptal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HastaCikisIptal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HastaCikisIptal() : base() { }

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