
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CommonCode")] 

    public  partial class CommonCode : TerminologyManagerDef
    {
        public class CommonCodeList : TTObjectCollection<CommonCode> { }
                    
        public class ChildCommonCodeCollection : TTObject.TTChildObjectCollection<CommonCode>
        {
            public ChildCommonCodeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCommonCodeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCommonCodeList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DEFINITION
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string GROUP_DESCR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_DESCR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_DESCR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GROUP_CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCommonCodeList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCommonCodeList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCommonCodeList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetStatusDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetStatusDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetStatusDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetStatusDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetResourceDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetResourceDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetResourceDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetResourceDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetEyeColorDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetEyeColorDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEyeColorDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEyeColorDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHairColorDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetHairColorDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHairColorDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHairColorDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetSkinColorDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetSkinColorDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetSkinColorDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetSkinColorDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetEducationLevelDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetEducationLevelDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetEducationLevelDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetEducationLevelDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetOccupationDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetOccupationDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetOccupationDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetOccupationDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetDisabilityDegreeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetDisabilityDegreeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDisabilityDegreeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDisabilityDegreeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHighSchoolTypeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetHighSchoolTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHighSchoolTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHighSchoolTypeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetUniversityDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetUniversityDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetUniversityDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetUniversityDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetUniversityDepartmentDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetUniversityDepartmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetUniversityDepartmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetUniversityDepartmentDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetHighSchoolDepartmentDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetHighSchoolDepartmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetHighSchoolDepartmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetHighSchoolDepartmentDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetAppreciationAndPunishmentTypeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetAppreciationAndPunishmentTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetAppreciationAndPunishmentTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetAppreciationAndPunishmentTypeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetChairOfCeritificateDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetChairOfCeritificateDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetChairOfCeritificateDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetChairOfCeritificateDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCommonCodePeaceMobilizationList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DEFINITION
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string GROUP_DESCR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_DESCR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_DESCR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GROUP_CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCommonCodePeaceMobilizationList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCommonCodePeaceMobilizationList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCommonCodePeaceMobilizationList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCommonCodeSAMList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DEFINITION
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string GROUP_DESCR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_DESCR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_DESCR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GROUP_CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCommonCodeSAMList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCommonCodeSAMList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCommonCodeSAMList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCommonCodeToeTypeList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DEFINITION
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string GROUP_DESCR
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_DESCR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_DESCR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GROUP_CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GROUP_CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODEGROUP"].AllPropertyDefs["GROUP_CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCommonCodeToeTypeList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCommonCodeToeTypeList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCommonCodeToeTypeList_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ReservedOfficerTermDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public OLAP_ReservedOfficerTermDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ReservedOfficerTermDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ReservedOfficerTermDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetAppreciationSubjectDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetAppreciationSubjectDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetAppreciationSubjectDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetAppreciationSubjectDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetMobilizationAndPeaceDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetMobilizationAndPeaceDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMobilizationAndPeaceDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMobilizationAndPeaceDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetToeTypeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? VALUE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetToeTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetToeTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetToeTypeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetMaritalStatusDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetMaritalStatusDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMaritalStatusDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMaritalStatusDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLanguageDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetLanguageDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLanguageDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLanguageDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetLanguageExamDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE_NAME
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetLanguageExamDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLanguageExamDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLanguageExamDefinition_Class() : base() { }
        }

        public static BindingList<CommonCode.GetCommonCodeList_Class> GetCommonCodeList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodeList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.GetCommonCodeList_Class> GetCommonCodeList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodeList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.OLAP_GetStatusDefinitions_Class> OLAP_GetStatusDefinitions(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetStatusDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetStatusDefinitions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetStatusDefinitions_Class> OLAP_GetStatusDefinitions(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetStatusDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetStatusDefinitions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetResourceDefinitions_Class> OLAP_GetResourceDefinitions(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetResourceDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetResourceDefinitions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetResourceDefinitions_Class> OLAP_GetResourceDefinitions(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetResourceDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetResourceDefinitions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetEyeColorDefinition_Class> OLAP_GetEyeColorDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetEyeColorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetEyeColorDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetEyeColorDefinition_Class> OLAP_GetEyeColorDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetEyeColorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetEyeColorDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetHairColorDefinition_Class> OLAP_GetHairColorDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetHairColorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetHairColorDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetHairColorDefinition_Class> OLAP_GetHairColorDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetHairColorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetHairColorDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetSkinColorDefinition_Class> OLAP_GetSkinColorDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetSkinColorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetSkinColorDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetSkinColorDefinition_Class> OLAP_GetSkinColorDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetSkinColorDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetSkinColorDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetEducationLevelDefinition_Class> OLAP_GetEducationLevelDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetEducationLevelDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetEducationLevelDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetEducationLevelDefinition_Class> OLAP_GetEducationLevelDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetEducationLevelDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetEducationLevelDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetOccupationDefinition_Class> OLAP_GetOccupationDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetOccupationDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetOccupationDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetOccupationDefinition_Class> OLAP_GetOccupationDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetOccupationDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetOccupationDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetDisabilityDegreeDefinition_Class> OLAP_GetDisabilityDegreeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetDisabilityDegreeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetDisabilityDegreeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetDisabilityDegreeDefinition_Class> OLAP_GetDisabilityDegreeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetDisabilityDegreeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetDisabilityDegreeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetHighSchoolTypeDefinition_Class> OLAP_GetHighSchoolTypeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetHighSchoolTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetHighSchoolTypeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetHighSchoolTypeDefinition_Class> OLAP_GetHighSchoolTypeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetHighSchoolTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetHighSchoolTypeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetUniversityDefinition_Class> OLAP_GetUniversityDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetUniversityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetUniversityDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetUniversityDefinition_Class> OLAP_GetUniversityDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetUniversityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetUniversityDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetUniversityDepartmentDefinition_Class> OLAP_GetUniversityDepartmentDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetUniversityDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetUniversityDepartmentDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetUniversityDepartmentDefinition_Class> OLAP_GetUniversityDepartmentDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetUniversityDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetUniversityDepartmentDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetHighSchoolDepartmentDefinition_Class> OLAP_GetHighSchoolDepartmentDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetHighSchoolDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetHighSchoolDepartmentDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetHighSchoolDepartmentDefinition_Class> OLAP_GetHighSchoolDepartmentDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetHighSchoolDepartmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetHighSchoolDepartmentDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetAppreciationAndPunishmentTypeDefinition_Class> OLAP_GetAppreciationAndPunishmentTypeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetAppreciationAndPunishmentTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetAppreciationAndPunishmentTypeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetAppreciationAndPunishmentTypeDefinition_Class> OLAP_GetAppreciationAndPunishmentTypeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetAppreciationAndPunishmentTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetAppreciationAndPunishmentTypeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetChairOfCeritificateDefinition_Class> OLAP_GetChairOfCeritificateDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetChairOfCeritificateDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetChairOfCeritificateDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetChairOfCeritificateDefinition_Class> OLAP_GetChairOfCeritificateDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetChairOfCeritificateDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetChairOfCeritificateDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.GetCommonCodePeaceMobilizationList_Class> GetCommonCodePeaceMobilizationList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodePeaceMobilizationList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodePeaceMobilizationList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.GetCommonCodePeaceMobilizationList_Class> GetCommonCodePeaceMobilizationList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodePeaceMobilizationList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodePeaceMobilizationList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.GetCommonCodeSAMList_Class> GetCommonCodeSAMList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodeSAMList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodeSAMList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.GetCommonCodeSAMList_Class> GetCommonCodeSAMList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodeSAMList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodeSAMList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.GetCommonCodeToeTypeList_Class> GetCommonCodeToeTypeList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodeToeTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodeToeTypeList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.GetCommonCodeToeTypeList_Class> GetCommonCodeToeTypeList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["GetCommonCodeToeTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.GetCommonCodeToeTypeList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CommonCode.OLAP_ReservedOfficerTermDefinition_Class> OLAP_ReservedOfficerTermDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_ReservedOfficerTermDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_ReservedOfficerTermDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_ReservedOfficerTermDefinition_Class> OLAP_ReservedOfficerTermDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_ReservedOfficerTermDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_ReservedOfficerTermDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetAppreciationSubjectDefinition_Class> OLAP_GetAppreciationSubjectDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetAppreciationSubjectDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetAppreciationSubjectDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetAppreciationSubjectDefinition_Class> OLAP_GetAppreciationSubjectDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetAppreciationSubjectDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetAppreciationSubjectDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetMobilizationAndPeaceDefinitions_Class> OLAP_GetMobilizationAndPeaceDefinitions(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetMobilizationAndPeaceDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetMobilizationAndPeaceDefinitions_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetMobilizationAndPeaceDefinitions_Class> OLAP_GetMobilizationAndPeaceDefinitions(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetMobilizationAndPeaceDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetMobilizationAndPeaceDefinitions_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetToeTypeDefinition_Class> OLAP_GetToeTypeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetToeTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetToeTypeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetToeTypeDefinition_Class> OLAP_GetToeTypeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetToeTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetToeTypeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetMaritalStatusDefinition_Class> OLAP_GetMaritalStatusDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetMaritalStatusDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetMaritalStatusDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetMaritalStatusDefinition_Class> OLAP_GetMaritalStatusDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetMaritalStatusDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetMaritalStatusDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetLanguageDefinition_Class> OLAP_GetLanguageDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetLanguageDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetLanguageDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetLanguageDefinition_Class> OLAP_GetLanguageDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetLanguageDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetLanguageDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetLanguageExamDefinition_Class> OLAP_GetLanguageExamDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetLanguageExamDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetLanguageExamDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CommonCode.OLAP_GetLanguageExamDefinition_Class> OLAP_GetLanguageExamDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].QueryDefs["OLAP_GetLanguageExamDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CommonCode.OLAP_GetLanguageExamDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public string DEFINITION
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

        public string CODE
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public int? VALUE
        {
            get { return (int?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        public string CODE_NAME
        {
            get { return (string)this["CODE_NAME"]; }
            set { this["CODE_NAME"] = value; }
        }

    /// <summary>
    /// CODEGROUPID
    /// </summary>
        public CommonCodeGroup CodeGroupId
        {
            get { return (CommonCodeGroup)((ITTObject)this).GetParent("CODEGROUPID"); }
            set { this["CODEGROUPID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CommonCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CommonCode(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CommonCode(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CommonCode(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CommonCode(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMMONCODE", dataRow) { }
        protected CommonCode(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMMONCODE", dataRow, isImported) { }
        public CommonCode(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CommonCode(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CommonCode() : base() { }

    }
}