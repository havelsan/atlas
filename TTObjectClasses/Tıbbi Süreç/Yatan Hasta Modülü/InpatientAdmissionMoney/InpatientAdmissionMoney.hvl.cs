
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientAdmissionMoney")] 

    /// <summary>
    /// Para Sekmesi
    /// </summary>
    public  partial class InpatientAdmissionMoney : BaseQuarantineValuableMaterial
    {
        public class InpatientAdmissionMoneyList : TTObjectCollection<InpatientAdmissionMoney> { }
                    
        public class ChildInpatientAdmissionMoneyCollection : TTObject.TTChildObjectCollection<InpatientAdmissionMoney>
        {
            public ChildInpatientAdmissionMoneyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientAdmissionMoneyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientAdmissionMoney_Class : TTReportNqlObject 
        {
            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public QuarantineProcessTypeEnum? QuarantineProcessType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROCESSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].AllPropertyDefs["QUARANTINEPROCESSTYPE"].DataType;
                    return (QuarantineProcessTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string PersonWhoGiveMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONWHOGIVEMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].AllPropertyDefs["PERSONWHOGIVEMATERIALS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PersonWhoTakeMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONWHOTAKEMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].AllPropertyDefs["PERSONWHOTAKEMATERIALS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MonetaryUnit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MONETARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MONETARYUNITDEFINITION"].AllPropertyDefs["MONETARYUNIT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReceiptNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].AllPropertyDefs["RECEIPTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientAdmissionMoney_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAdmissionMoney_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAdmissionMoney_Class() : base() { }
        }

        public static BindingList<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class> GetInpatientAdmissionMoney(string EPIOSDE, QuarantineProcessTypeEnum PROCESSTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].QueryDefs["GetInpatientAdmissionMoney"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPIOSDE", EPIOSDE);
            paramList.Add("PROCESSTYPE", (int)PROCESSTYPE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class> GetInpatientAdmissionMoney(TTObjectContext objectContext, string EPIOSDE, QuarantineProcessTypeEnum PROCESSTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONMONEY"].QueryDefs["GetInpatientAdmissionMoney"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPIOSDE", EPIOSDE);
            paramList.Add("PROCESSTYPE", (int)PROCESSTYPE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionMoney.GetInpatientAdmissionMoney_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Makbuz No
    /// </summary>
        public string ReceiptNo
        {
            get { return (string)this["RECEIPTNO"]; }
            set { this["RECEIPTNO"] = value; }
        }

    /// <summary>
    /// Para Birirmi
    /// </summary>
        public MonetaryUnitDefinition MonetaryUnit
        {
            get { return (MonetaryUnitDefinition)((ITTObject)this).GetParent("MONETARYUNIT"); }
            set { this["MONETARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientAdmissionMoney(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientAdmissionMoney(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientAdmissionMoney(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientAdmissionMoney(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientAdmissionMoney(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTADMISSIONMONEY", dataRow) { }
        protected InpatientAdmissionMoney(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTADMISSIONMONEY", dataRow, isImported) { }
        public InpatientAdmissionMoney(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientAdmissionMoney(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientAdmissionMoney() : base() { }

    }
}