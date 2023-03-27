
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LaboratoryEnvironmentDefinition")] 

    /// <summary>
    /// Laboratuvar Örnek Ortam Tanımları
    /// </summary>
    public  partial class LaboratoryEnvironmentDefinition : TTDefinitionSet
    {
        public class LaboratoryEnvironmentDefinitionList : TTObjectCollection<LaboratoryEnvironmentDefinition> { }
                    
        public class ChildLaboratoryEnvironmentDefinitionCollection : TTObject.TTChildObjectCollection<LaboratoryEnvironmentDefinition>
        {
            public ChildLaboratoryEnvironmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLaboratoryEnvironmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetLabEnvironmentDefListNQL_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYENVIRONMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LABORATORYENVIRONMENTDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetLabEnvironmentDefListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLabEnvironmentDefListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLabEnvironmentDefListNQL_Class() : base() { }
        }

        public static BindingList<LaboratoryEnvironmentDefinition.GetLabEnvironmentDefListNQL_Class> GetLabEnvironmentDefListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYENVIRONMENTDEFINITION"].QueryDefs["GetLabEnvironmentDefListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryEnvironmentDefinition.GetLabEnvironmentDefListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LaboratoryEnvironmentDefinition.GetLabEnvironmentDefListNQL_Class> GetLabEnvironmentDefListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LABORATORYENVIRONMENTDEFINITION"].QueryDefs["GetLabEnvironmentDefListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LaboratoryEnvironmentDefinition.GetLabEnvironmentDefListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected LaboratoryEnvironmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LaboratoryEnvironmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LaboratoryEnvironmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LaboratoryEnvironmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LaboratoryEnvironmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LABORATORYENVIRONMENTDEFINITION", dataRow) { }
        protected LaboratoryEnvironmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LABORATORYENVIRONMENTDEFINITION", dataRow, isImported) { }
        public LaboratoryEnvironmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LaboratoryEnvironmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LaboratoryEnvironmentDefinition() : base() { }

    }
}