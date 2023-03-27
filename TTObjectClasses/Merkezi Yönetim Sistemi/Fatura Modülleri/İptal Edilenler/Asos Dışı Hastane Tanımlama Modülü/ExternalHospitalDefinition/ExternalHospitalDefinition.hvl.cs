
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalHospitalDefinition")] 

    /// <summary>
    /// Dış XXXXXX Tanımlama
    /// </summary>
    public  partial class ExternalHospitalDefinition : ResSection
    {
        public class ExternalHospitalDefinitionList : TTObjectCollection<ExternalHospitalDefinition> { }
                    
        public class ChildExternalHospitalDefinitionCollection : TTObject.TTChildObjectCollection<ExternalHospitalDefinition>
        {
            public ChildExternalHospitalDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalHospitalDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExternalHospitalDefinitionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetExternalHospitalDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExternalHospitalDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExternalHospitalDefinitionNQL_Class() : base() { }
        }

        public static BindingList<ExternalHospitalDefinition.GetExternalHospitalDefinitionNQL_Class> GetExternalHospitalDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].QueryDefs["GetExternalHospitalDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalHospitalDefinition.GetExternalHospitalDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExternalHospitalDefinition.GetExternalHospitalDefinitionNQL_Class> GetExternalHospitalDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].QueryDefs["GetExternalHospitalDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalHospitalDefinition.GetExternalHospitalDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExternalHospitalDefinition> GetExternalHospitalDefinitionFormByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALHOSPITALDEFINITION"].QueryDefs["GetExternalHospitalDefinitionFormByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ExternalHospitalDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// XXXXXX Kodu
    /// </summary>
        public long? HospitalID
        {
            get { return (long?)this["HOSPITALID"]; }
            set { this["HOSPITALID"] = value; }
        }

    /// <summary>
    /// Medula Tesis Kodu
    /// </summary>
        public int? MedulaSiteCode
        {
            get { return (int?)this["MEDULASITECODE"]; }
            set { this["MEDULASITECODE"] = value; }
        }

    /// <summary>
    /// Bağlı Olduğu İl
    /// </summary>
        public SKRSILKodlari LinkedCity
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("LINKEDCITY"); }
            set { this["LINKEDCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExternalHospitalDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalHospitalDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalHospitalDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalHospitalDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalHospitalDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALHOSPITALDEFINITION", dataRow) { }
        protected ExternalHospitalDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALHOSPITALDEFINITION", dataRow, isImported) { }
        public ExternalHospitalDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalHospitalDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalHospitalDefinition() : base() { }

    }
}