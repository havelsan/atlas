
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MilitaryOffice")] 

    /// <summary>
    /// XXXXXXlik Şubesi Tanımları
    /// </summary>
    public  partial class MilitaryOffice : TerminologyManagerDef
    {
        public class MilitaryOfficeList : TTObjectCollection<MilitaryOffice> { }
                    
        public class ChildMilitaryOfficeCollection : TTObject.TTChildObjectCollection<MilitaryOffice>
        {
            public ChildMilitaryOfficeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMilitaryOfficeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMilitaryOfficeNQL_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYOFFICE"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYOFFICE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string City
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CITY"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYOFFICE"].AllPropertyDefs["EXTERNALCODE"].DataType;
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

            public GetMilitaryOfficeNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMilitaryOfficeNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMilitaryOfficeNQL_Class() : base() { }
        }

        public static BindingList<MilitaryOffice.GetMilitaryOfficeNQL_Class> GetMilitaryOfficeNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYOFFICE"].QueryDefs["GetMilitaryOfficeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryOffice.GetMilitaryOfficeNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MilitaryOffice.GetMilitaryOfficeNQL_Class> GetMilitaryOfficeNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYOFFICE"].QueryDefs["GetMilitaryOfficeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MilitaryOffice.GetMilitaryOfficeNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MilitaryOffice> GetMilitaryOfficeByExternalCode(TTObjectContext objectContext, string EXTERNALCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYOFFICE"].QueryDefs["GetMilitaryOfficeByExternalCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EXTERNALCODE", EXTERNALCODE);

            return ((ITTQuery)objectContext).QueryObjects<MilitaryOffice>(queryDef, paramList);
        }

        public static BindingList<MilitaryOffice> GetMilitaryOfficeByUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYOFFICE"].QueryDefs["GetMilitaryOfficeByUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MilitaryOffice>(queryDef, paramList);
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
    /// Harici Kodu
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public long? Code
        {
            get { return (long?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Bağlı Olduğu İl
    /// </summary>
        public City RelatedCity
        {
            get { return (City)((ITTObject)this).GetParent("RELATEDCITY"); }
            set { this["RELATEDCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bulunduğu İl
    /// </summary>
        public City City
        {
            get { return (City)((ITTObject)this).GetParent("CITY"); }
            set { this["CITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MilitaryOffice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MilitaryOffice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MilitaryOffice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MilitaryOffice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MilitaryOffice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MILITARYOFFICE", dataRow) { }
        protected MilitaryOffice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MILITARYOFFICE", dataRow, isImported) { }
        protected MilitaryOffice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MilitaryOffice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MilitaryOffice() : base() { }

    }
}