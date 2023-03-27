
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceControlNQLDef")] 

    /// <summary>
    /// Fatura Kontrol NQL Tanımları
    /// </summary>
    public  partial class InvoiceControlNQLDef : TTDefinitionSet
    {
        public class InvoiceControlNQLDefList : TTObjectCollection<InvoiceControlNQLDef> { }
                    
        public class ChildInvoiceControlNQLDefCollection : TTObject.TTChildObjectCollection<InvoiceControlNQLDef>
        {
            public ChildInvoiceControlNQLDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceControlNQLDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceControlNQLDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string NQL
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NQL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECONTROLNQLDEF"].AllPropertyDefs["NQL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECONTROLNQLDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECONTROLNQLDEF"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetInvoiceControlNQLDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceControlNQLDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceControlNQLDef_Class() : base() { }
        }

        public static BindingList<InvoiceControlNQLDef.GetInvoiceControlNQLDef_Class> GetInvoiceControlNQLDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECONTROLNQLDEF"].QueryDefs["GetInvoiceControlNQLDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceControlNQLDef.GetInvoiceControlNQLDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceControlNQLDef.GetInvoiceControlNQLDef_Class> GetInvoiceControlNQLDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECONTROLNQLDEF"].QueryDefs["GetInvoiceControlNQLDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceControlNQLDef.GetInvoiceControlNQLDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// NQL Filtresi
    /// </summary>
        public string NQL
        {
            get { return (string)this["NQL"]; }
            set { this["NQL"] = value; }
        }

    /// <summary>
    /// NQL Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        protected InvoiceControlNQLDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceControlNQLDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceControlNQLDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceControlNQLDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceControlNQLDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICECONTROLNQLDEF", dataRow) { }
        protected InvoiceControlNQLDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICECONTROLNQLDEF", dataRow, isImported) { }
        public InvoiceControlNQLDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceControlNQLDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceControlNQLDef() : base() { }

    }
}