
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CountryProtocolDefinition")] 

    /// <summary>
    /// Ülke Anlaşma Eşleştirme Tanım Ekranı
    /// </summary>
    public  partial class CountryProtocolDefinition : TerminologyManagerDef
    {
        public class CountryProtocolDefinitionList : TTObjectCollection<CountryProtocolDefinition> { }
                    
        public class ChildCountryProtocolDefinitionCollection : TTObject.TTChildObjectCollection<CountryProtocolDefinition>
        {
            public ChildCountryProtocolDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCountryProtocolDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCountryProtocolDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Country
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COUNTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientPayerEnum? PatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COUNTRYPROTOCOLDEFINITION"].AllPropertyDefs["PATIENTTYPE"].DataType;
                    return (PatientPayerEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Protocol
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Protocoluniversity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLUNIVERSITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetCountryProtocolDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCountryProtocolDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCountryProtocolDefinitions_Class() : base() { }
        }

        public static BindingList<CountryProtocolDefinition> GetCountryProtocolDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRYPROTOCOLDEFINITION"].QueryDefs["GetCountryProtocolDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<CountryProtocolDefinition>(queryDef, paramList);
        }

        public static BindingList<CountryProtocolDefinition.GetCountryProtocolDefinitions_Class> GetCountryProtocolDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRYPROTOCOLDEFINITION"].QueryDefs["GetCountryProtocolDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CountryProtocolDefinition.GetCountryProtocolDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CountryProtocolDefinition.GetCountryProtocolDefinitions_Class> GetCountryProtocolDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRYPROTOCOLDEFINITION"].QueryDefs["GetCountryProtocolDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CountryProtocolDefinition.GetCountryProtocolDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CountryProtocolDefinition> GetByCountryAndPatientType(TTObjectContext objectContext, string COUNTRY, int PATIENTTYPE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COUNTRYPROTOCOLDEFINITION"].QueryDefs["GetByCountryAndPatientType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("COUNTRY", COUNTRY);
            paramList.Add("PATIENTTYPE", PATIENTTYPE);

            return ((ITTQuery)objectContext).QueryObjects<CountryProtocolDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Hasta Türü
    /// </summary>
        public PatientPayerEnum? PatientType
        {
            get { return (PatientPayerEnum?)(int?)this["PATIENTTYPE"]; }
            set { this["PATIENTTYPE"] = value; }
        }

        public Country Country
        {
            get { return (Country)((ITTObject)this).GetParent("COUNTRY"); }
            set { this["COUNTRY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProtocolDefinition ProtocolUniversity
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOLUNIVERSITY"); }
            set { this["PROTOCOLUNIVERSITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CountryProtocolDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CountryProtocolDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CountryProtocolDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CountryProtocolDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CountryProtocolDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COUNTRYPROTOCOLDEFINITION", dataRow) { }
        protected CountryProtocolDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COUNTRYPROTOCOLDEFINITION", dataRow, isImported) { }
        public CountryProtocolDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CountryProtocolDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CountryProtocolDefinition() : base() { }

    }
}