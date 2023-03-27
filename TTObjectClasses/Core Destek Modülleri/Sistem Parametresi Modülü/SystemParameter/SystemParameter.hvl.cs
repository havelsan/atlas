
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SystemParameter")] 

    public  partial class SystemParameter : TerminologyManagerDef
    {
        public class SystemParameterList : TTObjectCollection<SystemParameter> { }
                    
        public class ChildSystemParameterCollection : TTObject.TTChildObjectCollection<SystemParameter>
        {
            public ChildSystemParameterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSystemParameterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSystemParameterDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["VALUE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SystemParameterSubTypeEnum? SubType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["SUBTYPE"].DataType;
                    return (SystemParameterSubTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetSystemParameterDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSystemParameterDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSystemParameterDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class AllSysParams_Class : TTReportNqlObject 
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

            public string Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["VALUE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SystemParameterSubTypeEnum? SubType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["SUBTYPE"].DataType;
                    return (SystemParameterSubTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsEncrypted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISENCRYPTED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["ISENCRYPTED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? CacheDurationInMinutes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CACHEDURATIONINMINUTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["CACHEDURATIONINMINUTES"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public AllSysParams_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public AllSysParams_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected AllSysParams_Class() : base() { }
        }

        [Serializable] 

        public partial class GetApplicationParameterDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["VALUE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SystemParameterSubTypeEnum? SubType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUBTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].AllPropertyDefs["SUBTYPE"].DataType;
                    return (SystemParameterSubTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetApplicationParameterDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetApplicationParameterDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetApplicationParameterDefinition_Class() : base() { }
        }

        public static BindingList<SystemParameter.GetSystemParameterDefinition_Class> GetSystemParameterDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].QueryDefs["GetSystemParameterDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemParameter.GetSystemParameterDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SystemParameter.GetSystemParameterDefinition_Class> GetSystemParameterDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].QueryDefs["GetSystemParameterDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemParameter.GetSystemParameterDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SystemParameter.AllSysParams_Class> AllSysParams(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].QueryDefs["AllSysParams"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemParameter.AllSysParams_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SystemParameter.AllSysParams_Class> AllSysParams(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].QueryDefs["AllSysParams"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemParameter.AllSysParams_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<SystemParameter> GetSystemParameterByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].QueryDefs["GetSystemParameterByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<SystemParameter>(queryDef, paramList);
        }

        public static BindingList<SystemParameter.GetApplicationParameterDefinition_Class> GetApplicationParameterDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].QueryDefs["GetApplicationParameterDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemParameter.GetApplicationParameterDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SystemParameter.GetApplicationParameterDefinition_Class> GetApplicationParameterDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SYSTEMPARAMETER"].QueryDefs["GetApplicationParameterDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SystemParameter.GetApplicationParameterDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Değeri
    /// </summary>
        public string Value
        {
            get { return (string)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public SystemParameterSubTypeEnum? SubType
        {
            get { return (SystemParameterSubTypeEnum?)(int?)this["SUBTYPE"]; }
            set { this["SUBTYPE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
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
    /// Şifrelerin encyrpt edildiğini gösterir.
    /// </summary>
        public bool? IsEncrypted
        {
            get { return (bool?)this["ISENCRYPTED"]; }
            set { this["ISENCRYPTED"] = value; }
        }

    /// <summary>
    /// 0 verilirse hiçbir zaman tazelenmez, verilen değer aşıldığında tazelenir
    /// </summary>
        public int? CacheDurationInMinutes
        {
            get { return (int?)this["CACHEDURATIONINMINUTES"]; }
            set { this["CACHEDURATIONINMINUTES"] = value; }
        }

        protected SystemParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SystemParameter(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SystemParameter(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SystemParameter(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SystemParameter(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SYSTEMPARAMETER", dataRow) { }
        protected SystemParameter(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SYSTEMPARAMETER", dataRow, isImported) { }
        public SystemParameter(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SystemParameter(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SystemParameter() : base() { }

    }
}