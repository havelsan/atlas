
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyAcceptTemplateDefinition")] 

    /// <summary>
    /// Patoloji Paket Tanımları
    /// </summary>
    public  partial class PathologyAcceptTemplateDefinition : ProcedureRequestTemplateDefinition
    {
        public class PathologyAcceptTemplateDefinitionList : TTObjectCollection<PathologyAcceptTemplateDefinition> { }
                    
        public class ChildPathologyAcceptTemplateDefinitionCollection : TTObject.TTChildObjectCollection<PathologyAcceptTemplateDefinition>
        {
            public ChildPathologyAcceptTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyAcceptTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPathologyAcceptTemplateNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYACCEPTTEMPLATEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPathologyAcceptTemplateNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPathologyAcceptTemplateNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPathologyAcceptTemplateNQL_Class() : base() { }
        }

        public static BindingList<PathologyAcceptTemplateDefinition.GetPathologyAcceptTemplateNQL_Class> GetPathologyAcceptTemplateNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYACCEPTTEMPLATEDEFINITION"].QueryDefs["GetPathologyAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyAcceptTemplateDefinition.GetPathologyAcceptTemplateNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PathologyAcceptTemplateDefinition.GetPathologyAcceptTemplateNQL_Class> GetPathologyAcceptTemplateNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATHOLOGYACCEPTTEMPLATEDEFINITION"].QueryDefs["GetPathologyAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PathologyAcceptTemplateDefinition.GetPathologyAcceptTemplateNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreatePathologyAcceptTemplateDetailsCollection()
        {
            _PathologyAcceptTemplateDetails = new PathologyAcceptTemplateDetail.ChildPathologyAcceptTemplateDetailCollection(this, new Guid("1a7d2289-753b-42ce-824c-fda91e6664b7"));
            ((ITTChildObjectCollection)_PathologyAcceptTemplateDetails).GetChildren();
        }

        protected PathologyAcceptTemplateDetail.ChildPathologyAcceptTemplateDetailCollection _PathologyAcceptTemplateDetails = null;
    /// <summary>
    /// Child collection for Patoloji Paket Detay Tanımı İlişkisi
    /// </summary>
        public PathologyAcceptTemplateDetail.ChildPathologyAcceptTemplateDetailCollection PathologyAcceptTemplateDetails
        {
            get
            {
                if (_PathologyAcceptTemplateDetails == null)
                    CreatePathologyAcceptTemplateDetailsCollection();
                return _PathologyAcceptTemplateDetails;
            }
        }

        protected PathologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYACCEPTTEMPLATEDEFINITION", dataRow) { }
        protected PathologyAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYACCEPTTEMPLATEDEFINITION", dataRow, isImported) { }
        public PathologyAcceptTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyAcceptTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyAcceptTemplateDefinition() : base() { }

    }
}