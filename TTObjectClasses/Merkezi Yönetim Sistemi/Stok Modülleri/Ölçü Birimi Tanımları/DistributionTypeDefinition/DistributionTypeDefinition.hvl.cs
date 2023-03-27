
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributionTypeDefinition")] 

    /// <summary>
    /// Ölçü Birimi Tanımları
    /// </summary>
    public  partial class DistributionTypeDefinition : TerminologyManagerDef
    {
        public class DistributionTypeDefinitionList : TTObjectCollection<DistributionTypeDefinition> { }
                    
        public class ChildDistributionTypeDefinitionCollection : TTObject.TTChildObjectCollection<DistributionTypeDefinition>
        {
            public ChildDistributionTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributionTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDistributionTypeDefinition_Class : TTReportNqlObject 
        {
            public string QRef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
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

            public GetDistributionTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistributionTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistributionTypeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_DistributionType_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_DistributionType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_DistributionType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_DistributionType_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDistributionDefinitionRQ_Class : TTReportNqlObject 
        {
            public string QRef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
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

            public int? MKYSDistributionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSDISTRIBUTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["MKYSDISTRIBUTIONID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetDistributionDefinitionRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistributionDefinitionRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistributionDefinitionRQ_Class() : base() { }
        }

        public static BindingList<DistributionTypeDefinition.GetDistributionTypeDefinition_Class> GetDistributionTypeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].QueryDefs["GetDistributionTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DistributionTypeDefinition.GetDistributionTypeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DistributionTypeDefinition.GetDistributionTypeDefinition_Class> GetDistributionTypeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].QueryDefs["GetDistributionTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DistributionTypeDefinition.GetDistributionTypeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DistributionTypeDefinition.OLAP_DistributionType_Class> OLAP_DistributionType(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].QueryDefs["OLAP_DistributionType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DistributionTypeDefinition.OLAP_DistributionType_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionTypeDefinition.OLAP_DistributionType_Class> OLAP_DistributionType(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].QueryDefs["OLAP_DistributionType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DistributionTypeDefinition.OLAP_DistributionType_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionTypeDefinition> GetDistTypeDefbyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].QueryDefs["GetDistTypeDefbyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DistributionTypeDefinition>(queryDef, paramList);
        }

        public static BindingList<DistributionTypeDefinition.GetDistributionDefinitionRQ_Class> GetDistributionDefinitionRQ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].QueryDefs["GetDistributionDefinitionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DistributionTypeDefinition.GetDistributionDefinitionRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionTypeDefinition.GetDistributionDefinitionRQ_Class> GetDistributionDefinitionRQ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].QueryDefs["GetDistributionDefinitionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DistributionTypeDefinition.GetDistributionDefinitionRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public string DistributionType
        {
            get { return (string)this["DISTRIBUTIONTYPE"]; }
            set { this["DISTRIBUTIONTYPE"] = value; }
        }

        public string QRef
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

        public string DistributionType_Shadow
        {
            get { return (string)this["DISTRIBUTIONTYPE_SHADOW"]; }
        }

        public string QRef_Shadow
        {
            get { return (string)this["QREF_SHADOW"]; }
        }

    /// <summary>
    /// MKYS_ÖlcüBirimi
    /// </summary>
        public MKYS_EOlcuBirimEnum? MKYS_DistType
        {
            get { return (MKYS_EOlcuBirimEnum?)(int?)this["MKYS_DISTTYPE"]; }
            set { this["MKYS_DISTTYPE"] = value; }
        }

    /// <summary>
    /// MKYS Sisteminde Enum Değeri
    /// </summary>
        public int? MKYSDistributionID
        {
            get { return (int?)this["MKYSDISTRIBUTIONID"]; }
            set { this["MKYSDISTRIBUTIONID"] = value; }
        }

        protected DistributionTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributionTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributionTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributionTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributionTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTIONTYPEDEFINITION", dataRow) { }
        protected DistributionTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTIONTYPEDEFINITION", dataRow, isImported) { }
        public DistributionTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributionTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributionTypeDefinition() : base() { }

    }
}