
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IlacAra")] 

    /// <summary>
    /// İlaç Ara
    /// </summary>
    public  partial class IlacAra : BaseMedulaDefinitionAction
    {
        public class IlacAraList : TTObjectCollection<IlacAra> { }
                    
        public class ChildIlacAraCollection : TTObject.TTChildObjectCollection<IlacAra>
        {
            public ChildIlacAraCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlacAraCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIlacAraWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetIlacAraWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIlacAraWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIlacAraWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Successfully { get { return new Guid("49bd6419-9310-401c-ada5-da1f1cc79624"); } }
            public static Guid Unsuccessfully { get { return new Guid("b6176f8c-d7fe-4a93-aae7-d1320bcb0703"); } }
            public static Guid Cancelled { get { return new Guid("e830f413-92a0-4705-adc1-1393d579650a"); } }
            public static Guid Completed { get { return new Guid("34eb676f-1bc7-466c-bb7e-f60fc3d61a73"); } }
            public static Guid New { get { return new Guid("a687c81e-9604-4402-a858-38f2e70dc5c3"); } }
            public static Guid SentMedula { get { return new Guid("33a86513-8454-4bba-ae6d-9996cace0e98"); } }
            public static Guid SentServer { get { return new Guid("f1b9246d-78b0-4345-93c8-99bcc34de8d5"); } }
        }

        public static BindingList<IlacAra.GetIlacAraWillBeSentToMedulaRQ_Class> GetIlacAraWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACARA"].QueryDefs["GetIlacAraWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacAra.GetIlacAraWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IlacAra.GetIlacAraWillBeSentToMedulaRQ_Class> GetIlacAraWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACARA"].QueryDefs["GetIlacAraWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<IlacAra.GetIlacAraWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<IlacAra> GetIlacAraWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILACARA"].QueryDefs["GetIlacAraWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<IlacAra>(queryDef, paramList);
        }

    /// <summary>
    /// Ilaç Ara Giriş
    /// </summary>
        public IlacAraGirisDVO ilacAraGirisDVO
        {
            get { return (IlacAraGirisDVO)((ITTObject)this).GetParent("ILACARAGIRISDVO"); }
            set { this["ILACARAGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected IlacAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IlacAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IlacAra(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IlacAra(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IlacAra(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILACARA", dataRow) { }
        protected IlacAra(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILACARA", dataRow, isImported) { }
        public IlacAra(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IlacAra(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IlacAra() : base() { }

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