
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkBildir")] 

    /// <summary>
    /// Sevk Bildir
    /// </summary>
    public  partial class SevkBildir : BaseMedulaAction
    {
        public class SevkBildirList : TTObjectCollection<SevkBildir> { }
                    
        public class ChildSevkBildirCollection : TTObject.TTChildObjectCollection<SevkBildir>
        {
            public ChildSevkBildirCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkBildirCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSevkBildirWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetSevkBildirWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSevkBildirWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSevkBildirWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("56059fd1-3f53-40a5-a625-68b526bc50ce"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("c4fcdac2-270c-45f2-8b4d-53f7f42df889"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("6a7b752d-d5a5-4e2a-bf64-4ae282c5441e"); } }
            public static Guid New { get { return new Guid("f9692a56-7b8c-48da-9301-76a1ad4e75a0"); } }
            public static Guid SentMedula { get { return new Guid("d95ea301-3409-4a31-b79c-fe8b2fd91586"); } }
            public static Guid SentServer { get { return new Guid("abf9626b-69f4-45b0-96f3-6c3367f673fb"); } }
        }

        public static BindingList<SevkBildir.GetSevkBildirWillBeSentToMedulaRQ_Class> GetSevkBildirWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKBILDIR"].QueryDefs["GetSevkBildirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<SevkBildir.GetSevkBildirWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SevkBildir.GetSevkBildirWillBeSentToMedulaRQ_Class> GetSevkBildirWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKBILDIR"].QueryDefs["GetSevkBildirWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<SevkBildir.GetSevkBildirWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SevkBildir> GetSevkBildirWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKBILDIR"].QueryDefs["GetSevkBildirWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SevkBildir>(queryDef, paramList);
        }

    /// <summary>
    /// Sevk Bildir Giriş
    /// </summary>
        public SevkBildirGirisDVO sevkBildirGirisDVO
        {
            get { return (SevkBildirGirisDVO)((ITTObject)this).GetParent("SEVKBILDIRGIRISDVO"); }
            set { this["SEVKBILDIRGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SevkBildir(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkBildir(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkBildir(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkBildir(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkBildir(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKBILDIR", dataRow) { }
        protected SevkBildir(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKBILDIR", dataRow, isImported) { }
        public SevkBildir(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkBildir(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkBildir() : base() { }

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