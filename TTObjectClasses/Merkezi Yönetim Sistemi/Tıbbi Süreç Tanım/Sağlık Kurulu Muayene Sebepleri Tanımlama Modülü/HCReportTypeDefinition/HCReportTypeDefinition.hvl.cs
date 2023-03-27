
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HCReportTypeDefinition")] 

    /// <summary>
    /// Sağlık Kurulu Rapor Grubu Tanımlama
    /// </summary>
    public  partial class HCReportTypeDefinition : TerminologyManagerDef
    {
        public class HCReportTypeDefinitionList : TTObjectCollection<HCReportTypeDefinition> { }
                    
        public class ChildHCReportTypeDefinitionCollection : TTObject.TTChildObjectCollection<HCReportTypeDefinition>
        {
            public ChildHCReportTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHCReportTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHCReportTypeDefinition_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string ReportGroupName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTYPEDEFINITION"].AllPropertyDefs["REPORTGROUPNAME"].DataType;
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

            public Guid? SKRSRaporTuru
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SKRSRAPORTURU"]);
                }
            }

            public GetHCReportTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHCReportTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHCReportTypeDefinition_Class() : base() { }
        }

        public static BindingList<HCReportTypeDefinition.GetHCReportTypeDefinition_Class> GetHCReportTypeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTYPEDEFINITION"].QueryDefs["GetHCReportTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCReportTypeDefinition.GetHCReportTypeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HCReportTypeDefinition.GetHCReportTypeDefinition_Class> GetHCReportTypeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HCREPORTTYPEDEFINITION"].QueryDefs["GetHCReportTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HCReportTypeDefinition.GetHCReportTypeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Rapor Grubu Adı
    /// </summary>
        public string ReportGroupName
        {
            get { return (string)this["REPORTGROUPNAME"]; }
            set { this["REPORTGROUPNAME"] = value; }
        }

    /// <summary>
    /// Engelli Raporu
    /// </summary>
        public bool? IsDisabled
        {
            get { return (bool?)this["ISDISABLED"]; }
            set { this["ISDISABLED"] = value; }
        }

    /// <summary>
    /// Durum Bildirir Raporu
    /// </summary>
        public bool? IsStatusNotification
        {
            get { return (bool?)this["ISSTATUSNOTIFICATION"]; }
            set { this["ISSTATUSNOTIFICATION"] = value; }
        }

    /// <summary>
    /// Tek Hekim Raporu
    /// </summary>
        public bool? SinglePhysicianReport
        {
            get { return (bool?)this["SINGLEPHYSICIANREPORT"]; }
            set { this["SINGLEPHYSICIANREPORT"] = value; }
        }

        public SKRSRaporTuru SKRSRaporTuru
        {
            get { return (SKRSRaporTuru)((ITTObject)this).GetParent("SKRSRAPORTURU"); }
            set { this["SKRSRAPORTURU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HCReportTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HCReportTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HCReportTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HCReportTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HCReportTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HCREPORTTYPEDEFINITION", dataRow) { }
        protected HCReportTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HCREPORTTYPEDEFINITION", dataRow, isImported) { }
        public HCReportTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HCReportTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HCReportTypeDefinition() : base() { }

    }
}