
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CancelledInvoice")] 

    /// <summary>
    /// İptal Edilmiş Faturalar
    /// </summary>
    public  partial class CancelledInvoice : TTObject
    {
        public class CancelledInvoiceList : TTObjectCollection<CancelledInvoice> { }
                    
        public class ChildCancelledInvoiceCollection : TTObject.TTChildObjectCollection<CancelledInvoice>
        {
            public ChildCancelledInvoiceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCancelledInvoiceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByInvoiceCollection_Class : TTReportNqlObject 
        {
            public Guid? ICD
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ICD"]);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? GeneralTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERINVOICEDOCUMENT"].AllPropertyDefs["GENERALTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Typetext
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TYPETEXT"]);
                }
            }

            public DateTime? Date
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CANCELLEDINVOICE"].AllPropertyDefs["DATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CANCELLEDINVOICE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Medulatakipno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MEDULATAKIPNO"]);
                }
            }

            public GetByInvoiceCollection_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByInvoiceCollection_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByInvoiceCollection_Class() : base() { }
        }

        public static BindingList<CancelledInvoice.GetByInvoiceCollection_Class> GetByInvoiceCollection(Guid INVOICECOLLECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CANCELLEDINVOICE"].QueryDefs["GetByInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVOICECOLLECTION", INVOICECOLLECTION);

            return TTReportNqlObject.QueryObjects<CancelledInvoice.GetByInvoiceCollection_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CancelledInvoice.GetByInvoiceCollection_Class> GetByInvoiceCollection(TTObjectContext objectContext, Guid INVOICECOLLECTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CANCELLEDINVOICE"].QueryDefs["GetByInvoiceCollection"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INVOICECOLLECTION", INVOICECOLLECTION);

            return TTReportNqlObject.QueryObjects<CancelledInvoice.GetByInvoiceCollection_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Oluşturulma tarihi
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

        public CancelledInvoiceTypeEnum? Type
        {
            get { return (CancelledInvoiceTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public SubEpisodeProtocol SEP
        {
            get { return (SubEpisodeProtocol)((ITTObject)this).GetParent("SEP"); }
            set { this["SEP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public InvoiceCollectionDetail ICD
        {
            get { return (InvoiceCollectionDetail)((ITTObject)this).GetParent("ICD"); }
            set { this["ICD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PayerInvoiceDocument PID
        {
            get { return (PayerInvoiceDocument)((ITTObject)this).GetParent("PID"); }
            set { this["PID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İptal Eden Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CancelledInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CancelledInvoice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CancelledInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CancelledInvoice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CancelledInvoice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CANCELLEDINVOICE", dataRow) { }
        protected CancelledInvoice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CANCELLEDINVOICE", dataRow, isImported) { }
        public CancelledInvoice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CancelledInvoice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CancelledInvoice() : base() { }

    }
}