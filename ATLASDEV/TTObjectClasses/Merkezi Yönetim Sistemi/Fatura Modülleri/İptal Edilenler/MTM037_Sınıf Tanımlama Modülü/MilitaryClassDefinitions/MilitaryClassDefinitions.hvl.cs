
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MilitaryClassDefinitions")] 

    /// <summary>
    /// XXXXXX Sınıf Tanımlama
    /// </summary>
    public  partial class MilitaryClassDefinitions : TerminologyManagerDef
    {
        public class MilitaryClassDefinitionsList : TTObjectCollection<MilitaryClassDefinitions> { }
                    
        public class ChildMilitaryClassDefinitionsCollection : TTObject.TTChildObjectCollection<MilitaryClassDefinitions>
        {
            public ChildMilitaryClassDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMilitaryClassDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMilitaryClassDefinitions_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMilitaryClassDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMilitaryClassDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMilitaryClassDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetMilitaryClass_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ShortName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHORTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetMilitaryClass_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetMilitaryClass_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetMilitaryClass_Class() : base() { }
        }

        public static BindingList<MilitaryClassDefinitions.GetMilitaryClassDefinitions_Class> GetMilitaryClassDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].QueryDefs["GetMilitaryClassDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryClassDefinitions.GetMilitaryClassDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MilitaryClassDefinitions.GetMilitaryClassDefinitions_Class> GetMilitaryClassDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].QueryDefs["GetMilitaryClassDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryClassDefinitions.GetMilitaryClassDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MilitaryClassDefinitions> GetMilitaryClassByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].QueryDefs["GetMilitaryClassByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MilitaryClassDefinitions>(queryDef, paramList);
        }

        public static BindingList<MilitaryClassDefinitions.OLAP_GetMilitaryClass_Class> OLAP_GetMilitaryClass(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].QueryDefs["OLAP_GetMilitaryClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryClassDefinitions.OLAP_GetMilitaryClass_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MilitaryClassDefinitions.OLAP_GetMilitaryClass_Class> OLAP_GetMilitaryClass(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].QueryDefs["OLAP_GetMilitaryClass"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryClassDefinitions.OLAP_GetMilitaryClass_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MilitaryClassDefinitions> GetMilitaryClassByObjectID(TTObjectContext objectContext, string TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYCLASSDEFINITIONS"].QueryDefs["GetMilitaryClassByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<MilitaryClassDefinitions>(queryDef, paramList);
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public MilitaryClassTypeEnum? Type
        {
            get { return (MilitaryClassTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Sınıf Adı
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

    /// <summary>
    /// Kısa Adı
    /// </summary>
        public string ShortName
        {
            get { return (string)this["SHORTNAME"]; }
            set { this["SHORTNAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// TownDefinitionMilitaryClassDefinition
    /// </summary>
        public City Town
        {
            get { return (City)((ITTObject)this).GetParent("TOWN"); }
            set { this["TOWN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MilitaryClassDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MilitaryClassDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MilitaryClassDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MilitaryClassDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MilitaryClassDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MILITARYCLASSDEFINITIONS", dataRow) { }
        protected MilitaryClassDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MILITARYCLASSDEFINITIONS", dataRow, isImported) { }
        protected MilitaryClassDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MilitaryClassDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MilitaryClassDefinitions() : base() { }

    }
}