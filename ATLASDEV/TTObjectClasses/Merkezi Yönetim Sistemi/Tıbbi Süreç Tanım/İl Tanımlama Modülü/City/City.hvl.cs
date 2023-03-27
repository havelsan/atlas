
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="City")] 

    /// <summary>
    /// İl Tanımları
    /// </summary>
    public  partial class City : TerminologyManagerDef
    {
        public class CityList : TTObjectCollection<City> { }
                    
        public class ChildCityCollection : TTObject.TTChildObjectCollection<City>
        {
            public ChildCityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCityDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Countryname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COUNTRYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCityDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCityDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCityDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCityDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Countryname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COUNTRYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCityDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCityDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCityDefinition_Class() : base() { }
        }

        public static BindingList<City> GetCityDefinitionByExternalObjectId(TTObjectContext objectContext, string TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["GetCityDefinitionByExternalObjectId"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<City>(queryDef, paramList);
        }

        public static BindingList<City.GetCityDefinition_Class> GetCityDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["GetCityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<City.GetCityDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<City.GetCityDefinition_Class> GetCityDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["GetCityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<City.GetCityDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<City> GetCityDefinitionByExternalCode(TTObjectContext objectContext, string EXTERNALCODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["GetCityDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<City>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<City> GetCityDefsByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["GetCityDefsByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<City>(queryDef, paramList);
        }

        public static BindingList<City.OLAP_GetCityDefinition_Class> OLAP_GetCityDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["OLAP_GetCityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<City.OLAP_GetCityDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<City.OLAP_GetCityDefinition_Class> OLAP_GetCityDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["OLAP_GetCityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<City.OLAP_GetCityDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<City> GetCityDefinitionByCode(TTObjectContext objectContext, string CODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CITY"].QueryDefs["GetCityDefinitionByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<City>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// İl Kodu
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

    /// <summary>
    /// İl Adı
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

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public Country Country
        {
            get { return (Country)((ITTObject)this).GetParent("COUNTRY"); }
            set { this["COUNTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTownsCollection()
        {
            _Towns = new TownDefinitions.ChildTownDefinitionsCollection(this, new Guid("f8a01cc6-b18f-486a-8c88-2251bc683dfa"));
            ((ITTChildObjectCollection)_Towns).GetChildren();
        }

        protected TownDefinitions.ChildTownDefinitionsCollection _Towns = null;
        public TownDefinitions.ChildTownDefinitionsCollection Towns
        {
            get
            {
                if (_Towns == null)
                    CreateTownsCollection();
                return _Towns;
            }
        }

        protected City(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected City(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected City(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected City(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected City(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CITY", dataRow) { }
        protected City(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CITY", dataRow, isImported) { }
        public City(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public City(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public City() : base() { }

    }
}