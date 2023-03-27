
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RequestUnitOfProcedureForm")] 

    /// <summary>
    /// Tetkik Formu İstek Birimleri
    /// </summary>
    public  partial class RequestUnitOfProcedureForm : TTObject
    {
        public class RequestUnitOfProcedureFormList : TTObjectCollection<RequestUnitOfProcedureForm> { }
                    
        public class ChildRequestUnitOfProcedureFormCollection : TTObject.TTChildObjectCollection<RequestUnitOfProcedureForm>
        {
            public ChildRequestUnitOfProcedureFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRequestUnitOfProcedureFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFormsByResourceIDs11_Class : TTReportNqlObject 
        {
            public Guid? ProcedureRequestFormDef
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREREQUESTFORMDEF"]);
                }
            }

            public GetFormsByResourceIDs11_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFormsByResourceIDs11_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFormsByResourceIDs11_Class() : base() { }
        }

        public static BindingList<RequestUnitOfProcedureForm.GetFormsByResourceIDs11_Class> GetFormsByResourceIDs11(IList<Guid> RESOURCEIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REQUESTUNITOFPROCEDUREFORM"].QueryDefs["GetFormsByResourceIDs11"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEIDS", RESOURCEIDS);

            return TTReportNqlObject.QueryObjects<RequestUnitOfProcedureForm.GetFormsByResourceIDs11_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RequestUnitOfProcedureForm.GetFormsByResourceIDs11_Class> GetFormsByResourceIDs11(TTObjectContext objectContext, IList<Guid> RESOURCEIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REQUESTUNITOFPROCEDUREFORM"].QueryDefs["GetFormsByResourceIDs11"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEIDS", RESOURCEIDS);

            return TTReportNqlObject.QueryObjects<RequestUnitOfProcedureForm.GetFormsByResourceIDs11_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RequestUnitOfProcedureForm> GetFormsByResourceIDs(TTObjectContext objectContext, IList<Guid> RESOURCEIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REQUESTUNITOFPROCEDUREFORM"].QueryDefs["GetFormsByResourceIDs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEIDS", RESOURCEIDS);

            return ((ITTQuery)objectContext).QueryObjects<RequestUnitOfProcedureForm>(queryDef, paramList);
        }

    /// <summary>
    /// Tetkik İstem Formu Yetkili Birimleri
    /// </summary>
        public ProcedureRequestFormDefinition ProcedureRequestFormDef
        {
            get { return (ProcedureRequestFormDefinition)((ITTObject)this).GetParent("PROCEDUREREQUESTFORMDEF"); }
            set { this["PROCEDUREREQUESTFORMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RequestUnitOfProcedureForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RequestUnitOfProcedureForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RequestUnitOfProcedureForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RequestUnitOfProcedureForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RequestUnitOfProcedureForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REQUESTUNITOFPROCEDUREFORM", dataRow) { }
        protected RequestUnitOfProcedureForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REQUESTUNITOFPROCEDUREFORM", dataRow, isImported) { }
        public RequestUnitOfProcedureForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RequestUnitOfProcedureForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RequestUnitOfProcedureForm() : base() { }

    }
}