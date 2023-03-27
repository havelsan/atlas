
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureTreeDefinition")] 

    public  partial class ProcedureTreeDefinition : TerminologyManagerDef
    {
        public class ProcedureTreeDefinitionList : TTObjectCollection<ProcedureTreeDefinition> { }
                    
        public class ChildProcedureTreeDefinitionCollection : TTObject.TTChildObjectCollection<ProcedureTreeDefinition>
        {
            public ChildProcedureTreeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureTreeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProcedureTreeDefinitions_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Revenuesubaccount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REVENUESUBACCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REVENUESUBACCOUNTCODEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public GetProcedureTreeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureTreeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureTreeDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ProcedureTreeDef_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_ProcedureTreeDef_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ProcedureTreeDef_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ProcedureTreeDef_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetRadProcedureTree_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetRadProcedureTree_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetRadProcedureTree_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetRadProcedureTree_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLabProcedureTree_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetLabProcedureTree_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLabProcedureTree_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLabProcedureTree_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgeryProcedureTree_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetSurgeryProcedureTree_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryProcedureTree_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryProcedureTree_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSurgeryProcedureTree_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetSurgeryProcedureTree_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSurgeryProcedureTree_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSurgeryProcedureTree_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetRadProcedureTree_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetRadProcedureTree_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetRadProcedureTree_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetRadProcedureTree_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLabProcedureTree_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetLabProcedureTree_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLabProcedureTree_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLabProcedureTree_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetManipulationProcedureTree_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetManipulationProcedureTree_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetManipulationProcedureTree_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetManipulationProcedureTree_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetPatProcedureTree_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetPatProcedureTree_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPatProcedureTree_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPatProcedureTree_WithDate_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetPatProcedureTree_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetPatProcedureTree_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetPatProcedureTree_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetPatProcedureTree_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetGeneticProcedureTree_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetGeneticProcedureTree_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetGeneticProcedureTree_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetGeneticProcedureTree_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ProcedureTreeDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_ProcedureTreeDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ProcedureTreeDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ProcedureTreeDef_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetGeneticProcedureTree_WithDate_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ParentID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARENTID"]);
                }
            }

            public OLAP_GetGeneticProcedureTree_WithDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetGeneticProcedureTree_WithDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetGeneticProcedureTree_WithDate_Class() : base() { }
        }

        public static BindingList<ProcedureTreeDefinition> OLAP_ProcedureTree(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_ProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ProcedureTreeDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureTreeDefinition.GetProcedureTreeDefinitions_Class> GetProcedureTreeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["GetProcedureTreeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.GetProcedureTreeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureTreeDefinition.GetProcedureTreeDefinitions_Class> GetProcedureTreeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["GetProcedureTreeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.GetProcedureTreeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_WithDate_Class> OLAP_ProcedureTreeDef_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_ProcedureTreeDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_WithDate_Class> OLAP_ProcedureTreeDef_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_ProcedureTreeDef_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition> GetProcedureTreeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["GetProcedureTreeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ProcedureTreeDefinition>(queryDef, paramList);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_Class> OLAP_GetRadProcedureTree(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetRadProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_Class> OLAP_GetRadProcedureTree(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetRadProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_Class> OLAP_GetLabProcedureTree(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetLabProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_Class> OLAP_GetLabProcedureTree(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetLabProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_Class> OLAP_GetSurgeryProcedureTree(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetSurgeryProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_Class> OLAP_GetSurgeryProcedureTree(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetSurgeryProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_WithDate_Class> OLAP_GetSurgeryProcedureTree_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetSurgeryProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_WithDate_Class> OLAP_GetSurgeryProcedureTree_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetSurgeryProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetSurgeryProcedureTree_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_WithDate_Class> OLAP_GetRadProcedureTree_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetRadProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_WithDate_Class> OLAP_GetRadProcedureTree_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetRadProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetRadProcedureTree_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_WithDate_Class> OLAP_GetLabProcedureTree_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetLabProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_WithDate_Class> OLAP_GetLabProcedureTree_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetLabProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetLabProcedureTree_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetManipulationProcedureTree_WithDate_Class> OLAP_GetManipulationProcedureTree_WithDate(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetManipulationProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetManipulationProcedureTree_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetManipulationProcedureTree_WithDate_Class> OLAP_GetManipulationProcedureTree_WithDate(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetManipulationProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetManipulationProcedureTree_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_WithDate_Class> OLAP_GetPatProcedureTree_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetPatProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_WithDate_Class> OLAP_GetPatProcedureTree_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetPatProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_Class> OLAP_GetPatProcedureTree(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetPatProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_Class> OLAP_GetPatProcedureTree(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetPatProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetPatProcedureTree_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_Class> OLAP_GetGeneticProcedureTree(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetGeneticProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_Class> OLAP_GetGeneticProcedureTree(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetGeneticProcedureTree"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_Class> OLAP_ProcedureTreeDef(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_ProcedureTreeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_Class> OLAP_ProcedureTreeDef(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_ProcedureTreeDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_ProcedureTreeDef_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_WithDate_Class> OLAP_GetGeneticProcedureTree_WithDate(DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetGeneticProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_WithDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_WithDate_Class> OLAP_GetGeneticProcedureTree_WithDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime LASTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDURETREEDEFINITION"].QueryDefs["OLAP_GetGeneticProcedureTree_WithDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("LASTDATE", LASTDATE);

            return TTReportNqlObject.QueryObjects<ProcedureTreeDefinition.OLAP_GetGeneticProcedureTree_WithDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public ProcedureTreeDefinition ParentID
        {
            get { return (ProcedureTreeDefinition)((ITTObject)this).GetParent("PARENTID"); }
            set { this["PARENTID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RevenueSubAccountCodeDefinition RevenueSubAccountCode
        {
            get { return (RevenueSubAccountCodeDefinition)((ITTObject)this).GetParent("REVENUESUBACCOUNTCODE"); }
            set { this["REVENUESUBACCOUNTCODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProcedureGroupsCollection()
        {
            _ProcedureGroups = new DiscountTypeProcedureGroupDefinition.ChildDiscountTypeProcedureGroupDefinitionCollection(this, new Guid("0870e918-b4d4-44b1-a09e-6d6e9e8f10d8"));
            ((ITTChildObjectCollection)_ProcedureGroups).GetChildren();
        }

        protected DiscountTypeProcedureGroupDefinition.ChildDiscountTypeProcedureGroupDefinitionCollection _ProcedureGroups = null;
    /// <summary>
    /// Child collection for ProcedureTree ile DiscountType ilişkisi
    /// </summary>
        public DiscountTypeProcedureGroupDefinition.ChildDiscountTypeProcedureGroupDefinitionCollection ProcedureGroups
        {
            get
            {
                if (_ProcedureGroups == null)
                    CreateProcedureGroupsCollection();
                return _ProcedureGroups;
            }
        }

        virtual protected void CreateProceduresCollection()
        {
            _Procedures = new ProcedureDefinition.ChildProcedureDefinitionCollection(this, new Guid("ed7ac547-56e3-42ff-8b9d-9e060586472d"));
            ((ITTChildObjectCollection)_Procedures).GetChildren();
        }

        protected ProcedureDefinition.ChildProcedureDefinitionCollection _Procedures = null;
    /// <summary>
    /// Child collection for Bağlı olduğu hizmet grubu ile ilişki
    /// </summary>
        public ProcedureDefinition.ChildProcedureDefinitionCollection Procedures
        {
            get
            {
                if (_Procedures == null)
                    CreateProceduresCollection();
                return _Procedures;
            }
        }

        protected ProcedureTreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureTreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureTreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureTreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureTreeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDURETREEDEFINITION", dataRow) { }
        protected ProcedureTreeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDURETREEDEFINITION", dataRow, isImported) { }
        protected ProcedureTreeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureTreeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureTreeDefinition() : base() { }

    }
}