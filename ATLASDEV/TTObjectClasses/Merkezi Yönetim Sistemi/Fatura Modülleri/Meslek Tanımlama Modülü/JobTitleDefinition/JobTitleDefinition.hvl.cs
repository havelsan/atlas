
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="JobTitleDefinition")] 

    /// <summary>
    /// Meslek Tanımları
    /// </summary>
    public  partial class JobTitleDefinition : TerminologyManagerDef
    {
        public class JobTitleDefinitionList : TTObjectCollection<JobTitleDefinition> { }
                    
        public class ChildJobTitleDefinitionCollection : TTObject.TTChildObjectCollection<JobTitleDefinition>
        {
            public ChildJobTitleDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildJobTitleDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetJobTitle_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string CODE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTypeEnum? USERTYPE
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].AllPropertyDefs["USERTYPE"].DataType;
                    return (UserTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetJobTitle_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetJobTitle_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetJobTitle_Class() : base() { }
        }

        public static BindingList<JobTitleDefinition> GetJobTitleByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].QueryDefs["GetJobTitleByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<JobTitleDefinition>(queryDef, paramList);
        }

        public static BindingList<JobTitleDefinition.GetJobTitle_Class> GetJobTitle(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].QueryDefs["GetJobTitle"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<JobTitleDefinition.GetJobTitle_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<JobTitleDefinition.GetJobTitle_Class> GetJobTitle(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].QueryDefs["GetJobTitle"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<JobTitleDefinition.GetJobTitle_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<JobTitleDefinition> GetJobTitleByObjectID(TTObjectContext objectContext, string TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["JOBTITLEDEFINITION"].QueryDefs["GetJobTitleByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<JobTitleDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string CODE
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// ID
    /// </summary>
        public TTSequence ID
        {
            get { return GetSequence("ID"); }
        }

    /// <summary>
    /// Meslek
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Meslek Tipi
    /// </summary>
        public UserTypeEnum? USERTYPE
        {
            get { return (UserTypeEnum?)(int?)this["USERTYPE"]; }
            set { this["USERTYPE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected JobTitleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected JobTitleDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected JobTitleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected JobTitleDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected JobTitleDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "JOBTITLEDEFINITION", dataRow) { }
        protected JobTitleDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "JOBTITLEDEFINITION", dataRow, isImported) { }
        public JobTitleDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public JobTitleDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public JobTitleDefinition() : base() { }

    }
}