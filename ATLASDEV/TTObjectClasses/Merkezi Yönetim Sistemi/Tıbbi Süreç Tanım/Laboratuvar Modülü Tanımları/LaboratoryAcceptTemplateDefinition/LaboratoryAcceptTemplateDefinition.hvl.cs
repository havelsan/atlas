
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryAcceptTemplateDefinition")] 

    /// <summary>
    /// Laboratuvar Kabul Panel Tanımı
    /// </summary>
    public  partial class LaboratoryAcceptTemplateDefinition : ProcedureRequestTemplateDefinition
    {
        public class LaboratoryAcceptTemplateDefinitionList : TTObjectCollection<LaboratoryAcceptTemplateDefinition> { }
                    
        public class ChildLaboratoryAcceptTemplateDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryAcceptTemplateDefinition>
        {
            public ChildLaboratoryAcceptTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryAcceptTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLaboratoryAcceptTemplateNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYACCEPTTEMPLATEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public string Tname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYTESTTUBEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetLaboratoryAcceptTemplateNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLaboratoryAcceptTemplateNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLaboratoryAcceptTemplateNQL_Class() : base() { }
        }

        public static BindingList<LaboratoryAcceptTemplateDefinition.GetLaboratoryAcceptTemplateNQL_Class> GetLaboratoryAcceptTemplateNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYACCEPTTEMPLATEDEFINITION"].QueryDefs["GetLaboratoryAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryAcceptTemplateDefinition.GetLaboratoryAcceptTemplateNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryAcceptTemplateDefinition.GetLaboratoryAcceptTemplateNQL_Class> GetLaboratoryAcceptTemplateNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYACCEPTTEMPLATEDEFINITION"].QueryDefs["GetLaboratoryAcceptTemplateNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryAcceptTemplateDefinition.GetLaboratoryAcceptTemplateNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Laboratuvar Test Tüp Tanım İlişkisi
    /// </summary>
        public LaboratoryTestTubeDefinition LaboratoryTestTubeDefinition
        {
            get { return (LaboratoryTestTubeDefinition)((ITTObject)this).GetParent("LABORATORYTESTTUBEDEFINITION"); }
            set { this["LABORATORYTESTTUBEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Laboratuvar Bölümü İlişkisi
    /// </summary>
        public ResLaboratoryDepartment Department
        {
            get { return (ResLaboratoryDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateLaboratoryAcceptTemplateDetailsCollection()
        {
            _LaboratoryAcceptTemplateDetails = new LaboratoryAcceptTemplateDetail.ChildLaboratoryAcceptTemplateDetailCollection(this, new Guid("8526e19f-07e7-405d-995d-65d78d929882"));
            ((ITTChildObjectCollection)_LaboratoryAcceptTemplateDetails).GetChildren();
        }

        protected LaboratoryAcceptTemplateDetail.ChildLaboratoryAcceptTemplateDetailCollection _LaboratoryAcceptTemplateDetails = null;
    /// <summary>
    /// Child collection for Laboratuvar Kabul Panel Detay Tanımı İlişkisi
    /// </summary>
        public LaboratoryAcceptTemplateDetail.ChildLaboratoryAcceptTemplateDetailCollection LaboratoryAcceptTemplateDetails
        {
            get
            {
                if (_LaboratoryAcceptTemplateDetails == null)
                    CreateLaboratoryAcceptTemplateDetailsCollection();
                return _LaboratoryAcceptTemplateDetails;
            }
        }

        protected LaboratoryAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryAcceptTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYACCEPTTEMPLATEDEFINITION", dataRow) { }
        protected LaboratoryAcceptTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYACCEPTTEMPLATEDEFINITION", dataRow, isImported) { }
        public LaboratoryAcceptTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryAcceptTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryAcceptTemplateDefinition() : base() { }

    }
}