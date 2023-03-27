
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyAcceptTemplateDefinition")] 

    /// <summary>
    /// Radyoloji Şablon Tanımı
    /// </summary>
    public  partial class RadiologyAcceptTemplateDefinition : ProcedureRequestTemplateDefinition
    {
        public class RadiologyAcceptTemplateDefinitionList : TTObjectCollection<RadiologyAcceptTemplateDefinition> { }
                    
        public class ChildRadiologyAcceptTemplateDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyAcceptTemplateDefinition>
        {
            public ChildRadiologyAcceptTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyAcceptTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiologyAcceptTemplateNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYACCEPTTEMPLATEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Uname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyAcceptTemplateNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyAcceptTemplateNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyAcceptTemplateNQL_Class() : base() { }
        }

        public static BindingList<RadiologyAcceptTemplateDefinition.GetRadiologyAcceptTemplateNQL_Class> GetRadiologyAcceptTemplateNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYACCEPTTEMPLATEDEFINITION"].QueryDefs["GetRadiologyAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyAcceptTemplateDefinition.GetRadiologyAcceptTemplateNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyAcceptTemplateDefinition.GetRadiologyAcceptTemplateNQL_Class> GetRadiologyAcceptTemplateNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYACCEPTTEMPLATEDEFINITION"].QueryDefs["GetRadiologyAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyAcceptTemplateDefinition.GetRadiologyAcceptTemplateNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateRadiologyAcceptTemplateDetailsCollection()
        {
            _RadiologyAcceptTemplateDetails = new RadiologyAcceptTemplateDetail.ChildRadiologyAcceptTemplateDetailCollection(this, new Guid("658848bc-c1eb-41e0-a691-3f179d2f1e59"));
            ((ITTChildObjectCollection)_RadiologyAcceptTemplateDetails).GetChildren();
        }

        protected RadiologyAcceptTemplateDetail.ChildRadiologyAcceptTemplateDetailCollection _RadiologyAcceptTemplateDetails = null;
    /// <summary>
    /// Child collection for Radyoloji Şablon Detayı
    /// </summary>
        public RadiologyAcceptTemplateDetail.ChildRadiologyAcceptTemplateDetailCollection RadiologyAcceptTemplateDetails
        {
            get
            {
                if (_RadiologyAcceptTemplateDetails == null)
                    CreateRadiologyAcceptTemplateDetailsCollection();
                return _RadiologyAcceptTemplateDetails;
            }
        }

        protected RadiologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYACCEPTTEMPLATEDEFINITION", dataRow) { }
        protected RadiologyAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYACCEPTTEMPLATEDEFINITION", dataRow, isImported) { }
        public RadiologyAcceptTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyAcceptTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyAcceptTemplateDefinition() : base() { }

    }
}