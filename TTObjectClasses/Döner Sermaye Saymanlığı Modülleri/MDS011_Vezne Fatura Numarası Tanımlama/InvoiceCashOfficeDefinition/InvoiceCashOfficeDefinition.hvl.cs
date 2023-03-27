
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceCashOfficeDefinition")] 

    /// <summary>
    /// Sayman Mutemetliği / Fatura Servisi Fatura Numarası Tanımlama
    /// </summary>
    public  partial class InvoiceCashOfficeDefinition : TTDefinitionSet
    {
        public class InvoiceCashOfficeDefinitionList : TTObjectCollection<InvoiceCashOfficeDefinition> { }
                    
        public class ChildInvoiceCashOfficeDefinitionCollection : TTObject.TTChildObjectCollection<InvoiceCashOfficeDefinition>
        {
            public ChildInvoiceCashOfficeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceCashOfficeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceCashOfficeDefinitions_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? CurrentInvoiceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTINVOICENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECASHOFFICEDEFINITION"].AllPropertyDefs["CURRENTINVOICENUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? InvoiceEndNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEENDNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECASHOFFICEDEFINITION"].AllPropertyDefs["INVOICEENDNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string InvoiceSeriesNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICESERIESNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECASHOFFICEDEFINITION"].AllPropertyDefs["INVOICESERIESNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? InvoiceStartNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICESTARTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECASHOFFICEDEFINITION"].AllPropertyDefs["INVOICESTARTNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
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

            public GetInvoiceCashOfficeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceCashOfficeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceCashOfficeDefinitions_Class() : base() { }
        }

        public static BindingList<InvoiceCashOfficeDefinition.GetInvoiceCashOfficeDefinitions_Class> GetInvoiceCashOfficeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECASHOFFICEDEFINITION"].QueryDefs["GetInvoiceCashOfficeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceCashOfficeDefinition.GetInvoiceCashOfficeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceCashOfficeDefinition.GetInvoiceCashOfficeDefinitions_Class> GetInvoiceCashOfficeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECASHOFFICEDEFINITION"].QueryDefs["GetInvoiceCashOfficeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceCashOfficeDefinition.GetInvoiceCashOfficeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceCashOfficeDefinition> GetByCashOffice(TTObjectContext objectContext, string PARAMCASHOFFICE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECASHOFFICEDEFINITION"].QueryDefs["GetByCashOffice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMCASHOFFICE", PARAMCASHOFFICE);

            return ((ITTQuery)objectContext).QueryObjects<InvoiceCashOfficeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Fatura bitiş numarası
    /// </summary>
        public long? InvoiceEndNumber
        {
            get { return (long?)this["INVOICEENDNUMBER"]; }
            set { this["INVOICEENDNUMBER"] = value; }
        }

    /// <summary>
    /// Fatura seri numarası
    /// </summary>
        public string InvoiceSeriesNo
        {
            get { return (string)this["INVOICESERIESNO"]; }
            set { this["INVOICESERIESNO"] = value; }
        }

    /// <summary>
    /// Sıradaki fatura numarası
    /// </summary>
        public long? CurrentInvoiceNumber
        {
            get { return (long?)this["CURRENTINVOICENUMBER"]; }
            set { this["CURRENTINVOICENUMBER"] = value; }
        }

    /// <summary>
    /// Fatura başlangıç numarası
    /// </summary>
        public long? InvoiceStartNumber
        {
            get { return (long?)this["INVOICESTARTNUMBER"]; }
            set { this["INVOICESTARTNUMBER"] = value; }
        }

    /// <summary>
    /// Vezne ile ilişki
    /// </summary>
        public CashOfficeDefinition CashOffice
        {
            get { return (CashOfficeDefinition)((ITTObject)this).GetParent("CASHOFFICE"); }
            set { this["CASHOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InvoiceCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceCashOfficeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceCashOfficeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICECASHOFFICEDEFINITION", dataRow) { }
        protected InvoiceCashOfficeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICECASHOFFICEDEFINITION", dataRow, isImported) { }
        protected InvoiceCashOfficeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceCashOfficeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceCashOfficeDefinition() : base() { }

    }
}