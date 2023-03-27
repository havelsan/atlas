
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SalaryPayMasterDefinition")] 

    /// <summary>
    /// Maaş Mutemetliği Tanımları
    /// </summary>
    public  partial class SalaryPayMasterDefinition : TTDefinitionSet
    {
        public class SalaryPayMasterDefinitionList : TTObjectCollection<SalaryPayMasterDefinition> { }
                    
        public class ChildSalaryPayMasterDefinitionCollection : TTObject.TTChildObjectCollection<SalaryPayMasterDefinition>
        {
            public ChildSalaryPayMasterDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSalaryPayMasterDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSalaryPayMasterDefinitionRNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SALARYPAYMASTERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SALARYPAYMASTERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SALARYPAYMASTERDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SALARYPAYMASTERDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSalaryPayMasterDefinitionRNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSalaryPayMasterDefinitionRNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSalaryPayMasterDefinitionRNQL_Class() : base() { }
        }

        public static BindingList<SalaryPayMasterDefinition.GetSalaryPayMasterDefinitionRNQL_Class> GetSalaryPayMasterDefinitionRNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SALARYPAYMASTERDEFINITION"].QueryDefs["GetSalaryPayMasterDefinitionRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SalaryPayMasterDefinition.GetSalaryPayMasterDefinitionRNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SalaryPayMasterDefinition.GetSalaryPayMasterDefinitionRNQL_Class> GetSalaryPayMasterDefinitionRNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SALARYPAYMASTERDEFINITION"].QueryDefs["GetSalaryPayMasterDefinitionRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SalaryPayMasterDefinition.GetSalaryPayMasterDefinitionRNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected SalaryPayMasterDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SalaryPayMasterDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SalaryPayMasterDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SalaryPayMasterDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SalaryPayMasterDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SALARYPAYMASTERDEFINITION", dataRow) { }
        protected SalaryPayMasterDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SALARYPAYMASTERDEFINITION", dataRow, isImported) { }
        public SalaryPayMasterDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SalaryPayMasterDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SalaryPayMasterDefinition() : base() { }

    }
}