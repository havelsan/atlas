
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerProtocolDefinition")] 

    /// <summary>
    /// Kurum anlasma eslestirme
    /// </summary>
    public  partial class PayerProtocolDefinition : TerminologyManagerDef
    {
        public class PayerProtocolDefinitionList : TTObjectCollection<PayerProtocolDefinition> { }
                    
        public class ChildPayerProtocolDefinitionCollection : TTObject.TTChildObjectCollection<PayerProtocolDefinition>
        {
            public ChildPayerProtocolDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerProtocolDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPayerProtocolDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Protocolname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProtocolStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].AllPropertyDefs["PROTOCOLSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProtocolEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].AllPropertyDefs["PROTOCOLENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetPayerProtocolDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerProtocolDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerProtocolDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEffectivePayerProtocolDefsByEndDate_Class : TTReportNqlObject 
        {
            public long? Payercode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Protocolname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProtocolEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].AllPropertyDefs["PROTOCOLENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProtocolStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].AllPropertyDefs["PROTOCOLSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetEffectivePayerProtocolDefsByEndDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEffectivePayerProtocolDefsByEndDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEffectivePayerProtocolDefsByEndDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByPayer_Class : TTReportNqlObject 
        {
            public Guid? Protocolobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROTOCOLOBJECTID"]);
                }
            }

            public string Protocolcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Protocolname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROTOCOLDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByPayer_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByPayer_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByPayer_Class() : base() { }
        }

        public static BindingList<PayerProtocolDefinition.GetPayerProtocolDefinitions_Class> GetPayerProtocolDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].QueryDefs["GetPayerProtocolDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerProtocolDefinition.GetPayerProtocolDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerProtocolDefinition.GetPayerProtocolDefinitions_Class> GetPayerProtocolDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].QueryDefs["GetPayerProtocolDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerProtocolDefinition.GetPayerProtocolDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate_Class> GetEffectivePayerProtocolDefsByEndDate(DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].QueryDefs["GetEffectivePayerProtocolDefsByEndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate_Class> GetEffectivePayerProtocolDefsByEndDate(TTObjectContext objectContext, DateTime PARAMENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].QueryDefs["GetEffectivePayerProtocolDefsByEndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMENDDATE", PARAMENDDATE);

            return TTReportNqlObject.QueryObjects<PayerProtocolDefinition.GetEffectivePayerProtocolDefsByEndDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerProtocolDefinition> GetPayerProtocolDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].QueryDefs["GetPayerProtocolDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PayerProtocolDefinition>(queryDef, paramList);
        }

        public static BindingList<PayerProtocolDefinition.GetByPayer_Class> GetByPayer(Guid PAYEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].QueryDefs["GetByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PAYEROBJECTID", PAYEROBJECTID);

            return TTReportNqlObject.QueryObjects<PayerProtocolDefinition.GetByPayer_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerProtocolDefinition.GetByPayer_Class> GetByPayer(TTObjectContext objectContext, Guid PAYEROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERPROTOCOLDEFINITION"].QueryDefs["GetByPayer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PAYEROBJECTID", PAYEROBJECTID);

            return TTReportNqlObject.QueryObjects<PayerProtocolDefinition.GetByPayer_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Anlaşma Geçerlilik Başlangıç Tarihi
    /// </summary>
        public DateTime? ProtocolStartDate
        {
            get { return (DateTime?)this["PROTOCOLSTARTDATE"]; }
            set { this["PROTOCOLSTARTDATE"] = value; }
        }

    /// <summary>
    /// Anlaşma Geçerlilik Bitiş Tarihi
    /// </summary>
        public DateTime? ProtocolEndDate
        {
            get { return (DateTime?)this["PROTOCOLENDDATE"]; }
            set { this["PROTOCOLENDDATE"] = value; }
        }

    /// <summary>
    /// Payer ile Payerprotocol iliskisi
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Protocol ile PayerProtocol iliskisi
    /// </summary>
        public ProtocolDefinition Protocol
        {
            get { return (ProtocolDefinition)((ITTObject)this).GetParent("PROTOCOL"); }
            set { this["PROTOCOL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PayerProtocolDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerProtocolDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerProtocolDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerProtocolDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerProtocolDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERPROTOCOLDEFINITION", dataRow) { }
        protected PayerProtocolDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERPROTOCOLDEFINITION", dataRow, isImported) { }
        protected PayerProtocolDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerProtocolDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerProtocolDefinition() : base() { }

    }
}