
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FaturaIptal")] 

    /// <summary>
    /// Fatura İptal
    /// </summary>
    public  partial class FaturaIptal : BaseMedulaAction
    {
        public class FaturaIptalList : TTObjectCollection<FaturaIptal> { }
                    
        public class ChildFaturaIptalCollection : TTObject.TTChildObjectCollection<FaturaIptal>
        {
            public ChildFaturaIptalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFaturaIptalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFaturaIptalWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetFaturaIptalWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFaturaIptalWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFaturaIptalWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("feaa00d2-b4b7-4ed7-97cf-2fe40129fbca"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("66d753d8-ddeb-41de-9787-4d5cabe76f0a"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("c8fed13f-fa02-4513-8d55-0633a4185c24"); } }
            public static Guid New { get { return new Guid("826b8c71-ea8c-4d82-b247-d156632d9e01"); } }
            public static Guid SentMedula { get { return new Guid("01b3a673-49a9-49fd-b3d8-57e302d27eb8"); } }
            public static Guid SentServer { get { return new Guid("d0d259bf-5345-4ff8-adb3-098d07ea07a7"); } }
        }

        public static BindingList<FaturaIptal.GetFaturaIptalWillBeSentToMedulaRQ_Class> GetFaturaIptalWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURAIPTAL"].QueryDefs["GetFaturaIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<FaturaIptal.GetFaturaIptalWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FaturaIptal.GetFaturaIptalWillBeSentToMedulaRQ_Class> GetFaturaIptalWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURAIPTAL"].QueryDefs["GetFaturaIptalWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<FaturaIptal.GetFaturaIptalWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FaturaIptal> GetFaturaIptalWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FATURAIPTAL"].QueryDefs["GetFaturaIptalWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FaturaIptal>(queryDef, paramList);
        }

    /// <summary>
    /// Fatura İptal Giriş
    /// </summary>
        public FaturaIptalGirisDVO faturaIptalGirisDVO
        {
            get { return (FaturaIptalGirisDVO)((ITTObject)this).GetParent("FATURAIPTALGIRISDVO"); }
            set { this["FATURAIPTALGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FaturaIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FaturaIptal(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FaturaIptal(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FaturaIptal(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FaturaIptal(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FATURAIPTAL", dataRow) { }
        protected FaturaIptal(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FATURAIPTAL", dataRow, isImported) { }
        public FaturaIptal(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FaturaIptal(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FaturaIptal() : base() { }

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