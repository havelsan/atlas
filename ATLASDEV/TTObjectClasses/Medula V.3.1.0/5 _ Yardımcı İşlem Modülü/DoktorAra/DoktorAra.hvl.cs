
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoktorAra")] 

    /// <summary>
    /// Doktor Ara
    /// </summary>
    public  partial class DoktorAra : BaseMedulaDefinitionAction
    {
        public class DoktorAraList : TTObjectCollection<DoktorAra> { }
                    
        public class ChildDoktorAraCollection : TTObject.TTChildObjectCollection<DoktorAra>
        {
            public ChildDoktorAraCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoktorAraCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDoktorAraWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDoktorAraWillBeSentToMedulaRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoktorAraWillBeSentToMedulaRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoktorAraWillBeSentToMedulaRQ_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("383d5251-7232-433a-b155-41088622ebcd"); } }
            public static Guid Completed { get { return new Guid("20c56831-9a34-466c-87d2-496cb4fbbb81"); } }
            public static Guid New { get { return new Guid("5a051a3d-731c-4fa5-99b8-d7b1df257cda"); } }
            public static Guid SentMedula { get { return new Guid("b9b27097-3e5e-4677-a1e2-a1675d1332d7"); } }
            public static Guid SentServer { get { return new Guid("534fb988-680d-4344-82a8-2d4d7e1c0300"); } }
            public static Guid Successfully { get { return new Guid("3d99577a-8f36-4a76-b99b-29c576eb5488"); } }
            public static Guid Unsuccessfully { get { return new Guid("cf047dc9-0108-4511-8c9e-40586ac28a06"); } }
        }

        public static BindingList<DoktorAra> GetDoktorAraWillBeSentToMedula(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOKTORARA"].QueryDefs["GetDoktorAraWillBeSentToMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DoktorAra>(queryDef, paramList);
        }

        public static BindingList<DoktorAra.GetDoktorAraWillBeSentToMedulaRQ_Class> GetDoktorAraWillBeSentToMedulaRQ(int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOKTORARA"].QueryDefs["GetDoktorAraWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DoktorAra.GetDoktorAraWillBeSentToMedulaRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DoktorAra.GetDoktorAraWillBeSentToMedulaRQ_Class> GetDoktorAraWillBeSentToMedulaRQ(TTObjectContext objectContext, int HEALTHFACILITYID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOKTORARA"].QueryDefs["GetDoktorAraWillBeSentToMedulaRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("HEALTHFACILITYID", HEALTHFACILITYID);

            return TTReportNqlObject.QueryObjects<DoktorAra.GetDoktorAraWillBeSentToMedulaRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Doktor Ara Giriş
    /// </summary>
        public DoktorAraGirisDVO doktorAraGirisDVO
        {
            get { return (DoktorAraGirisDVO)((ITTObject)this).GetParent("DOKTORARAGIRISDVO"); }
            set { this["DOKTORARAGIRISDVO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DoktorAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoktorAra(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoktorAra(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoktorAra(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoktorAra(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOKTORARA", dataRow) { }
        protected DoktorAra(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOKTORARA", dataRow, isImported) { }
        public DoktorAra(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoktorAra(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoktorAra() : base() { }

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