
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceInclusionNQL")] 

    /// <summary>
    /// Fatura Dahillik Sorgu Tanımları
    /// </summary>
    public  partial class InvoiceInclusionNQL : TTDefinitionSet
    {
        public class InvoiceInclusionNQLList : TTObjectCollection<InvoiceInclusionNQL> { }
                    
        public class ChildInvoiceInclusionNQLCollection : TTObject.TTChildObjectCollection<InvoiceInclusionNQL>
        {
            public ChildInvoiceInclusionNQLCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceInclusionNQLCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceInclusionNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONNQL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NQL
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NQL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONNQL"].AllPropertyDefs["NQL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONNQL"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public ProcedureMaterialEnum? ProcedureMaterialType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREMATERIALTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONNQL"].AllPropertyDefs["PROCEDUREMATERIALTYPE"].DataType;
                    return (ProcedureMaterialEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetInvoiceInclusionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceInclusionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceInclusionNQL_Class() : base() { }
        }

        public static BindingList<InvoiceInclusionNQL.GetInvoiceInclusionNQL_Class> GetInvoiceInclusionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONNQL"].QueryDefs["GetInvoiceInclusionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceInclusionNQL.GetInvoiceInclusionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceInclusionNQL.GetInvoiceInclusionNQL_Class> GetInvoiceInclusionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICEINCLUSIONNQL"].QueryDefs["GetInvoiceInclusionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceInclusionNQL.GetInvoiceInclusionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Çalıştırma Sırası
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// İşlem / Malzeme
    /// </summary>
        public ProcedureMaterialEnum? ProcedureMaterialType
        {
            get { return (ProcedureMaterialEnum?)(int?)this["PROCEDUREMATERIALTYPE"]; }
            set { this["PROCEDUREMATERIALTYPE"] = value; }
        }

    /// <summary>
    /// NQL Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateIIMNQLProcedureMaterialsCollection()
        {
            _IIMNQLProcedureMaterials = new IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection(this, new Guid("a11f3915-c91f-4024-863a-66ad18a2db9f"));
            ((ITTChildObjectCollection)_IIMNQLProcedureMaterials).GetChildren();
        }

        protected IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection _IIMNQLProcedureMaterials = null;
    /// <summary>
    /// Child collection for Kural Sonuç Grup Bilgisi
    /// </summary>
        public IIMNQLProcedureMaterial.ChildIIMNQLProcedureMaterialCollection IIMNQLProcedureMaterials
        {
            get
            {
                if (_IIMNQLProcedureMaterials == null)
                    CreateIIMNQLProcedureMaterialsCollection();
                return _IIMNQLProcedureMaterials;
            }
        }

        protected InvoiceInclusionNQL(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceInclusionNQL(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceInclusionNQL(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceInclusionNQL(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceInclusionNQL(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICEINCLUSIONNQL", dataRow) { }
        protected InvoiceInclusionNQL(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICEINCLUSIONNQL", dataRow, isImported) { }
        public InvoiceInclusionNQL(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceInclusionNQL(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceInclusionNQL() : base() { }

    }
}