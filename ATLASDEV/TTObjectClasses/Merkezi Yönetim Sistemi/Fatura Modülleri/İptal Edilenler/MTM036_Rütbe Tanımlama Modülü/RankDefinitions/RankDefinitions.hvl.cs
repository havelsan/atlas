
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RankDefinitions")] 

    /// <summary>
    /// Rütbe Tanımları
    /// </summary>
    public  partial class RankDefinitions : TerminologyManagerDef
    {
        public class RankDefinitionsList : TTObjectCollection<RankDefinitions> { }
                    
        public class ChildRankDefinitionsCollection : TTObject.TTChildObjectCollection<RankDefinitions>
        {
            public ChildRankDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRankDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_Rank_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public RankTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["TYPE"].DataType;
                    return (RankTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public OLAP_Rank_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_Rank_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_Rank_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRankDefinitions_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
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

            public RankTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["TYPE"].DataType;
                    return (RankTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRankDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRankDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRankDefinitions_Class() : base() { }
        }

        public static BindingList<RankDefinitions> GetRankDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["GetRankDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RankDefinitions>(queryDef, paramList);
        }

        public static BindingList<RankDefinitions> GetRankDefinitionOrderByCode(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["GetRankDefinitionOrderByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RankDefinitions>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<RankDefinitions.OLAP_Rank_Class> OLAP_Rank(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["OLAP_Rank"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RankDefinitions.OLAP_Rank_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RankDefinitions.OLAP_Rank_Class> OLAP_Rank(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["OLAP_Rank"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RankDefinitions.OLAP_Rank_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<RankDefinitions> GetRankDefinitionsByObjectId(TTObjectContext objectContext, string TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["GetRankDefinitionsByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<RankDefinitions>(queryDef, paramList);
        }

        public static BindingList<RankDefinitions.GetRankDefinitions_Class> GetRankDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["GetRankDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RankDefinitions.GetRankDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RankDefinitions.GetRankDefinitions_Class> GetRankDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["GetRankDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RankDefinitions.GetRankDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RankDefinitions> GetRankDefinitionsByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].QueryDefs["GetRankDefinitionsByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<RankDefinitions>(queryDef, paramList);
        }

    /// <summary>
    /// ID
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
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
    /// Tipi
    /// </summary>
        public RankTypeEnum? Type
        {
            get { return (RankTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Kısa Adı
    /// </summary>
        public string ShortName
        {
            get { return (string)this["SHORTNAME"]; }
            set { this["SHORTNAME"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

        public int? OrderNO
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected RankDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RankDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RankDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RankDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RankDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RANKDEFINITIONS", dataRow) { }
        protected RankDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RANKDEFINITIONS", dataRow, isImported) { }
        protected RankDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RankDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RankDefinitions() : base() { }

    }
}