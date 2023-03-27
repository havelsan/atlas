
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TownDefinitions")] 

    /// <summary>
    /// İl/İlçe Tanımlama
    /// </summary>
    public  partial class TownDefinitions : TerminologyManagerDef
    {
        public class TownDefinitionsList : TTObjectCollection<TownDefinitions> { }
                    
        public class ChildTownDefinitionsCollection : TTObject.TTChildObjectCollection<TownDefinitions>
        {
            public ChildTownDefinitionsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTownDefinitionsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTownDefinitions_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
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

            public string Cityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTownDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTownDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTownDefinitions_Class() : base() { }
        }

        public static BindingList<TownDefinitions> GetTownDefinitionByObjectId(TTObjectContext objectContext, string TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].QueryDefs["GetTownDefinitionByObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<TownDefinitions>(queryDef, paramList);
        }

        public static BindingList<TownDefinitions.GetTownDefinitions_Class> GetTownDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].QueryDefs["GetTownDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TownDefinitions.GetTownDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TownDefinitions.GetTownDefinitions_Class> GetTownDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].QueryDefs["GetTownDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TownDefinitions.GetTownDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TownDefinitions> GetTownDefinitionByExternalCode(TTObjectContext objectContext, string EXTERNALCODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].QueryDefs["GetTownDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<TownDefinitions>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<TownDefinitions> GetTownDefsByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].QueryDefs["GetTownDefsByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<TownDefinitions>(queryDef, paramList);
        }

        public static BindingList<TownDefinitions> GetTownDefinitionsByMernisCode(TTObjectContext objectContext, string MERNISCODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].QueryDefs["GetTownDefinitionsByMernisCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MERNISCODE", MERNISCODE);

            return ((ITTQuery)objectContext).QueryObjects<TownDefinitions>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// İlçe Kodu
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

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// İlçe Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Mernis Kodu
    /// </summary>
        public int? MernisCode
        {
            get { return (int?)this["MERNISCODE"]; }
            set { this["MERNISCODE"] = value; }
        }

        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TownDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TownDefinitions(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TownDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TownDefinitions(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TownDefinitions(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TOWNDEFINITIONS", dataRow) { }
        protected TownDefinitions(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TOWNDEFINITIONS", dataRow, isImported) { }
        public TownDefinitions(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TownDefinitions(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TownDefinitions() : base() { }

    }
}