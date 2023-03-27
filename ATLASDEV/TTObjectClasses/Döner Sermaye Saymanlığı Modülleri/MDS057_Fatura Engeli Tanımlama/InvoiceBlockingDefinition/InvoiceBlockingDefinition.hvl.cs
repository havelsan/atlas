
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceBlockingDefinition")] 

    /// <summary>
    /// Fatura Engeli Tanımlama
    /// </summary>
    public  partial class InvoiceBlockingDefinition : TTDefinitionSet
    {
        public class InvoiceBlockingDefinitionList : TTObjectCollection<InvoiceBlockingDefinition> { }
                    
        public class ChildInvoiceBlockingDefinitionCollection : TTObject.TTChildObjectCollection<InvoiceBlockingDefinition>
        {
            public ChildInvoiceBlockingDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceBlockingDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceBlockingDefinition_Class : TTReportNqlObject 
        {
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

            public Guid? StateDefId
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STATEDEFID"]);
                }
            }

            public EAorSPEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKINGDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (EAorSPEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ObjectName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKINGDEFINITION"].AllPropertyDefs["OBJECTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string StateName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKINGDEFINITION"].AllPropertyDefs["STATENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? InvoiceBlock
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEBLOCK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKINGDEFINITION"].AllPropertyDefs["INVOICEBLOCK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CashOfficeBlock
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICEBLOCK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKINGDEFINITION"].AllPropertyDefs["CASHOFFICEBLOCK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetInvoiceBlockingDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceBlockingDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceBlockingDefinition_Class() : base() { }
        }

        public static BindingList<InvoiceBlockingDefinition.GetInvoiceBlockingDefinition_Class> GetInvoiceBlockingDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKINGDEFINITION"].QueryDefs["GetInvoiceBlockingDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceBlockingDefinition.GetInvoiceBlockingDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceBlockingDefinition.GetInvoiceBlockingDefinition_Class> GetInvoiceBlockingDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEBLOCKINGDEFINITION"].QueryDefs["GetInvoiceBlockingDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceBlockingDefinition.GetInvoiceBlockingDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public Guid? StateDefId
        {
            get { return (Guid?)this["STATEDEFID"]; }
            set { this["STATEDEFID"] = value; }
        }

    /// <summary>
    /// Nesne Adı
    /// </summary>
        public string ObjectName
        {
            get { return (string)this["OBJECTNAME"]; }
            set { this["OBJECTNAME"] = value; }
        }

    /// <summary>
    /// Nesne Türü
    /// </summary>
        public EAorSPEnum? Type
        {
            get { return (EAorSPEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Durum Adı
    /// </summary>
        public string StateName
        {
            get { return (string)this["STATENAME"]; }
            set { this["STATENAME"] = value; }
        }

        public bool? InvoiceBlock
        {
            get { return (bool?)this["INVOICEBLOCK"]; }
            set { this["INVOICEBLOCK"] = value; }
        }

        public bool? CashOfficeBlock
        {
            get { return (bool?)this["CASHOFFICEBLOCK"]; }
            set { this["CASHOFFICEBLOCK"] = value; }
        }

        protected InvoiceBlockingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceBlockingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceBlockingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceBlockingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceBlockingDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEBLOCKINGDEFINITION", dataRow) { }
        protected InvoiceBlockingDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEBLOCKINGDEFINITION", dataRow, isImported) { }
        public InvoiceBlockingDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceBlockingDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceBlockingDefinition() : base() { }

    }
}