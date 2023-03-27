
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KesintiYapilmisIslemler")] 

    public  partial class KesintiYapilmisIslemler : BaseMedulaAction
    {
        public class KesintiYapilmisIslemlerList : TTObjectCollection<KesintiYapilmisIslemler> { }
                    
        public class ChildKesintiYapilmisIslemlerCollection : TTObject.TTChildObjectCollection<KesintiYapilmisIslemler>
        {
            public ChildKesintiYapilmisIslemlerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKesintiYapilmisIslemlerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetKYIslemlerWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetKYIslemlerWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetKYIslemlerWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetKYIslemlerWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("2c2e5894-140a-4d9f-b1cd-4e85e822ec1c"); } }
            public static Guid CompletedSuccessfully { get { return new Guid("b0c94b6d-1716-4aa3-a417-49919fc72abf"); } }
            public static Guid CompletedUnsuccessfully { get { return new Guid("1f79ee5c-4e43-4283-86d9-b8064917805a"); } }
            public static Guid New { get { return new Guid("63db8c85-c0a0-4fff-a16e-c46559204f2f"); } }
            public static Guid SentMedula { get { return new Guid("ddb7e7ac-7b81-43b5-960c-1bb12bda09e8"); } }
            public static Guid SentServer { get { return new Guid("1f006772-6da8-437c-95dd-4bc8f415350a"); } }
        }

        public static BindingList<KesintiYapilmisIslemler> GetKesintiYapilmisIslemlerWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KESINTIYAPILMISISLEMLER"].QueryDefs["GetKesintiYapilmisIslemlerWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<KesintiYapilmisIslemler>(queryDef, paramList);
        }

        public static BindingList<KesintiYapilmisIslemler.GetKYIslemlerWillBeSentToMedulaRQ_Class> GetKYIslemlerWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KESINTIYAPILMISISLEMLER"].QueryDefs["GetKYIslemlerWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<KesintiYapilmisIslemler.GetKYIslemlerWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<KesintiYapilmisIslemler.GetKYIslemlerWillBeSentToMedulaRQ_Class> GetKYIslemlerWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KESINTIYAPILMISISLEMLER"].QueryDefs["GetKYIslemlerWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<KesintiYapilmisIslemler.GetKYIslemlerWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public EvrakKesintiGirisDVO evrakKesintiGirisDVO
        {
            get { return (EvrakKesintiGirisDVO)((ITTObject)this).GetParent("EVRAKKESINTIGIRISDVO"); }
            set { this["EVRAKKESINTIGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected KesintiYapilmisIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KesintiYapilmisIslemler(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KesintiYapilmisIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KesintiYapilmisIslemler(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KesintiYapilmisIslemler(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KESINTIYAPILMISISLEMLER", dataRow) { }
        protected KesintiYapilmisIslemler(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KESINTIYAPILMISISLEMLER", dataRow, isImported) { }
        public KesintiYapilmisIslemler(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KesintiYapilmisIslemler(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KesintiYapilmisIslemler() : base() { }

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