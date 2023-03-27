
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="LineToeDefinition")] 

    public  partial class LineToeDefinition : TerminologyManagerDef, ITMK
    {
        public class LineToeDefinitionList : TTObjectCollection<LineToeDefinition> { }
                    
        public class ChildLineToeDefinitionCollection : TTObject.TTChildObjectCollection<LineToeDefinition>
        {
            public ChildLineToeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildLineToeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetLineToeMissionDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? BranchId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BRANCHID"]);
                }
            }

            public Guid? ArmedForceId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ARMEDFORCEID"]);
                }
            }

            public Guid? ClassId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLASSID"]);
                }
            }

            public Guid? HonorificId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HONORIFICID"]);
                }
            }

            public Guid? Maintoeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MAINTOEID"]);
                }
            }

            public Guid? MissionId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MISSIONID"]);
                }
            }

            public int? Mobilizationid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILIZATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Peaceid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PEACEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? Paragraphtoeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PARAGRAPHTOEID"]);
                }
            }

            public Guid? RankId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RANKID"]);
                }
            }

            public Guid? SamId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SAMID"]);
                }
            }

            public Guid? SectionId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SECTIONID"]);
                }
            }

            public string Toetype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMMONCODE"].AllPropertyDefs["CODE_NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? GENERALSTAFF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALSTAFF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].AllPropertyDefs["GENERALSTAFF"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string LINETOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LINETOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].AllPropertyDefs["LINETOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public OLAP_GetLineToeMissionDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetLineToeMissionDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetLineToeMissionDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetLineToeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string LINETOECODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LINETOECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].AllPropertyDefs["LINETOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? GENERALSTAFF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALSTAFF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].AllPropertyDefs["GENERALSTAFF"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Object Maintmkdescr
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MAINTMKDESCR"]);
                }
            }

            public string Missionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MISSIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MISSIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Paragtmkdescr
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARAGTMKDESCR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].AllPropertyDefs["PARAGRAPHTOECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Officename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["OFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SECTIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPARTMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Unitenclosurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITENCLOSURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITENCLOSUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetLineToeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetLineToeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetLineToeDefinitionList_Class() : base() { }
        }

        public static BindingList<LineToeDefinition.OLAP_GetLineToeMissionDefinition_Class> OLAP_GetLineToeMissionDefinition(Guid GENERALAMIRALSAMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].QueryDefs["OLAP_GetLineToeMissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GENERALAMIRALSAMID", GENERALAMIRALSAMID);

            return TTReportNqlObject.QueryObjects<LineToeDefinition.OLAP_GetLineToeMissionDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<LineToeDefinition.OLAP_GetLineToeMissionDefinition_Class> OLAP_GetLineToeMissionDefinition(TTObjectContext objectContext, Guid GENERALAMIRALSAMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].QueryDefs["OLAP_GetLineToeMissionDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GENERALAMIRALSAMID", GENERALAMIRALSAMID);

            return TTReportNqlObject.QueryObjects<LineToeDefinition.OLAP_GetLineToeMissionDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<LineToeDefinition.GetLineToeDefinitionList_Class> GetLineToeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].QueryDefs["GetLineToeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LineToeDefinition.GetLineToeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<LineToeDefinition.GetLineToeDefinitionList_Class> GetLineToeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["LINETOEDEFINITION"].QueryDefs["GetLineToeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<LineToeDefinition.GetLineToeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string LINETOECODE
        {
            get { return (string)this["LINETOECODE"]; }
            set { this["LINETOECODE"] = value; }
        }

        public bool? GENERALSTAFF
        {
            get { return (bool?)this["GENERALSTAFF"]; }
            set { this["GENERALSTAFF"] = value; }
        }

        public string DESCRIPTION
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// ToeTypeCommonDefinition
    /// </summary>
        public CommonCode ToeTypeId
        {
            get { return (CommonCode)((ITTObject)this).GetParent("TOETYPEID"); }
            set { this["TOETYPEID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// PeaceCommonCode
    /// </summary>
        public CommonCode PeaceId
        {
            get { return (CommonCode)((ITTObject)this).GetParent("PEACEID"); }
            set { this["PEACEID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MobilizationCommonCode
    /// </summary>
        public CommonCode MobilizationId
        {
            get { return (CommonCode)((ITTObject)this).GetParent("MOBILIZATIONID"); }
            set { this["MOBILIZATIONID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ClassDefinition
    /// </summary>
        public MilitaryClassDefinitions ClassId
        {
            get { return (MilitaryClassDefinitions)((ITTObject)this).GetParent("CLASSID"); }
            set { this["CLASSID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// RankDefinition
    /// </summary>
        public RankDefinitions RankId
        {
            get { return (RankDefinitions)((ITTObject)this).GetParent("RANKID"); }
            set { this["RANKID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// SectionDefinition
    /// </summary>
        public SectionDefinition SectionId
        {
            get { return (SectionDefinition)((ITTObject)this).GetParent("SECTIONID"); }
            set { this["SECTIONID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MissionDefinition
    /// </summary>
        public MissionDefinition MissionId
        {
            get { return (MissionDefinition)((ITTObject)this).GetParent("MISSIONID"); }
            set { this["MISSIONID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// BranchDefinition
    /// </summary>
        public BranchDefinition BranchId
        {
            get { return (BranchDefinition)((ITTObject)this).GetParent("BRANCHID"); }
            set { this["BRANCHID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// TitleDefinition
    /// </summary>
        public TitleDefinition HonorificId
        {
            get { return (TitleDefinition)((ITTObject)this).GetParent("HONORIFICID"); }
            set { this["HONORIFICID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// CommonCodeSam
    /// </summary>
        public CommonCode SamId
        {
            get { return (CommonCode)((ITTObject)this).GetParent("SAMID"); }
            set { this["SAMID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// ArmedForce
    /// </summary>
        public ForcesCommand ArmedForceId
        {
            get { return (ForcesCommand)((ITTObject)this).GetParent("ARMEDFORCEID"); }
            set { this["ARMEDFORCEID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected LineToeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected LineToeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected LineToeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected LineToeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected LineToeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "LINETOEDEFINITION", dataRow) { }
        protected LineToeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "LINETOEDEFINITION", dataRow, isImported) { }
        public LineToeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public LineToeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public LineToeDefinition() : base() { }

    }
}