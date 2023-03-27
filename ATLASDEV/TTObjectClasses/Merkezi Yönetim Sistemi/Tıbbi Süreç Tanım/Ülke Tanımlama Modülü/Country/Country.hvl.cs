
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Country")] 

    /// <summary>
    /// Ülke Tanımları
    /// </summary>
    public  partial class Country : TerminologyManagerDef
    {
        public class CountryList : TTObjectCollection<Country> { }
                    
        public class ChildCountryCollection : TTObject.TTChildObjectCollection<Country>
        {
            public ChildCountryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCountryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCountryDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCountryDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountryDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountryDefinitionNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_GetCountryDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetCountryDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetCountryDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetCountryDefinition_Class() : base() { }
        }

        public static BindingList<Country> GetCountryDefinitionByExternalCode(TTObjectContext objectContext, string EXTERNALCODE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].QueryDefs["GetCountryDefinitionByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<Country>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<Country> GetCountryDefinitionByObjectID(TTObjectContext objectContext, string TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].QueryDefs["GetCountryDefinitionByObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<Country>(queryDef, paramList);
        }

        public static BindingList<Country.GetCountryDefinitionNQL_Class> GetCountryDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].QueryDefs["GetCountryDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Country.GetCountryDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Country.GetCountryDefinitionNQL_Class> GetCountryDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].QueryDefs["GetCountryDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Country.GetCountryDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Country> GetCountryByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].QueryDefs["GetCountryByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Country>(queryDef, paramList);
        }

        public static BindingList<Country.OLAP_GetCountryDefinition_Class> OLAP_GetCountryDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].QueryDefs["OLAP_GetCountryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Country.OLAP_GetCountryDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Country.OLAP_GetCountryDefinition_Class> OLAP_GetCountryDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].QueryDefs["OLAP_GetCountryDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Country.OLAP_GetCountryDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ülke Adı
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
    /// Ülke Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Mernis Kodu
    /// </summary>
        public string MernisCode
        {
            get { return (string)this["MERNISCODE"]; }
            set { this["MERNISCODE"] = value; }
        }

        virtual protected void CreateCitiesCollection()
        {
            _Cities = new City.ChildCityCollection(this, new Guid("e9e2d997-91d0-4937-a2d3-236c4d6ad969"));
            ((ITTChildObjectCollection)_Cities).GetChildren();
        }

        protected City.ChildCityCollection _Cities = null;
        public City.ChildCityCollection Cities
        {
            get
            {
                if (_Cities == null)
                    CreateCitiesCollection();
                return _Cities;
            }
        }

        protected Country(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Country(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Country(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Country(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Country(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COUNTRY", dataRow) { }
        protected Country(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COUNTRY", dataRow, isImported) { }
        public Country(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Country(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Country() : base() { }

    }
}