
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PayerTypeDefinition")] 

    /// <summary>
    /// Kurum tipi
    /// </summary>
    public  partial class PayerTypeDefinition : TerminologyManagerDef
    {
        public class PayerTypeDefinitionList : TTObjectCollection<PayerTypeDefinition> { }
                    
        public class ChildPayerTypeDefinitionCollection : TTObject.TTChildObjectCollection<PayerTypeDefinition>
        {
            public ChildPayerTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPayerTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_PayerTypeDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public OLAP_PayerTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_PayerTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_PayerTypeDefinition_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPayerTypeDefinitions_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PayerTypeEnum? PayerType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].AllPropertyDefs["PAYERTYPE"].DataType;
                    return (PayerTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPayerTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPayerTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPayerTypeDefinitions_Class() : base() { }
        }

        public static BindingList<PayerTypeDefinition.OLAP_PayerTypeDefinition_Class> OLAP_PayerTypeDefinition(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].QueryDefs["OLAP_PayerTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerTypeDefinition.OLAP_PayerTypeDefinition_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PayerTypeDefinition.OLAP_PayerTypeDefinition_Class> OLAP_PayerTypeDefinition(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].QueryDefs["OLAP_PayerTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerTypeDefinition.OLAP_PayerTypeDefinition_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PayerTypeDefinition.GetPayerTypeDefinitions_Class> GetPayerTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].QueryDefs["GetPayerTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerTypeDefinition.GetPayerTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerTypeDefinition.GetPayerTypeDefinitions_Class> GetPayerTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].QueryDefs["GetPayerTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PayerTypeDefinition.GetPayerTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PayerTypeDefinition> GetPayerTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAYERTYPEDEFINITION"].QueryDefs["GetPayerTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PayerTypeDefinition>(queryDef, paramList);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public PayerTypeEnum? PayerType
        {
            get { return (PayerTypeEnum?)(int?)this["PAYERTYPE"]; }
            set { this["PAYERTYPE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public SKRSSosyalGuvenceDurumu SKRSSosyalGuvenceDurumu
        {
            get { return (SKRSSosyalGuvenceDurumu)((ITTObject)this).GetParent("SKRSSOSYALGUVENCEDURUMU"); }
            set { this["SKRSSOSYALGUVENCEDURUMU"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PayerTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PayerTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PayerTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PayerTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PayerTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAYERTYPEDEFINITION", dataRow) { }
        protected PayerTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAYERTYPEDEFINITION", dataRow, isImported) { }
        protected PayerTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PayerTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PayerTypeDefinition() : base() { }

    }
}