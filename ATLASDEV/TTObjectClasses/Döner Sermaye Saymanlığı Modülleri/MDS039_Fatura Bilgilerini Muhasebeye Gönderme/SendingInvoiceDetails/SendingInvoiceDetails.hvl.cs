
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendingInvoiceDetails")] 

    /// <summary>
    /// Fatura Bilgilerini Muhasebeye Gönderme İşlemi Fatura Detayları
    /// </summary>
    public  partial class SendingInvoiceDetails : TTObject
    {
        public class SendingInvoiceDetailsList : TTObjectCollection<SendingInvoiceDetails> { }
                    
        public class ChildSendingInvoiceDetailsCollection : TTObject.TTChildObjectCollection<SendingInvoiceDetails>
        {
            public ChildSendingInvoiceDetailsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendingInvoiceDetailsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBySITAObjectID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

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

            public long? Patientid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? HospitalProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPITALPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? InvoiceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDINGINVOICEDETAILS"].AllPropertyDefs["INVOICEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string InvoiceNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDINGINVOICEDETAILS"].AllPropertyDefs["INVOICENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? InvoicePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDINGINVOICEDETAILS"].AllPropertyDefs["INVOICEPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetBySITAObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySITAObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySITAObjectID_Class() : base() { }
        }

        public static BindingList<SendingInvoiceDetails.GetBySITAObjectID_Class> GetBySITAObjectID(string SITAOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDINGINVOICEDETAILS"].QueryDefs["GetBySITAObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SITAOBJECTID", SITAOBJECTID);

            return TTReportNqlObject.QueryObjects<SendingInvoiceDetails.GetBySITAObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SendingInvoiceDetails.GetBySITAObjectID_Class> GetBySITAObjectID(TTObjectContext objectContext, string SITAOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDINGINVOICEDETAILS"].QueryDefs["GetBySITAObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SITAOBJECTID", SITAOBJECTID);

            return TTReportNqlObject.QueryObjects<SendingInvoiceDetails.GetBySITAObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Fatura Tarihi
    /// </summary>
        public DateTime? InvoiceDate
        {
            get { return (DateTime?)this["INVOICEDATE"]; }
            set { this["INVOICEDATE"] = value; }
        }

    /// <summary>
    /// Fatura No
    /// </summary>
        public string InvoiceNo
        {
            get { return (string)this["INVOICENO"]; }
            set { this["INVOICENO"] = value; }
        }

    /// <summary>
    /// Fatura Tutarı
    /// </summary>
        public Currency? InvoicePrice
        {
            get { return (Currency?)this["INVOICEPRICE"]; }
            set { this["INVOICEPRICE"] = value; }
        }

    /// <summary>
    /// Gönder
    /// </summary>
        public bool? Send
        {
            get { return (bool?)this["SEND"]; }
            set { this["SEND"] = value; }
        }

    /// <summary>
    /// Hasta epizotu ile ilişki
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Toplu Fatura dökümanı ile ilişki
    /// </summary>
        public CollectedInvoiceDocument CollectedInvoiceDocument
        {
            get { return (CollectedInvoiceDocument)((ITTObject)this).GetParent("COLLECTEDINVOICEDOCUMENT"); }
            set { this["COLLECTEDINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Fatura bilgilerini muhasebeye gönderme işlemi ile ilişki
    /// </summary>
        public SendingInvoiceToAccounting SendingInvoiceToAccounting
        {
            get { return (SendingInvoiceToAccounting)((ITTObject)this).GetParent("SENDINGINVOICETOACCOUNTING"); }
            set { this["SENDINGINVOICETOACCOUNTING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum ile ilişki
    /// </summary>
        public PayerDefinition PayerDefinition
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYERDEFINITION"); }
            set { this["PAYERDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kurum faturası dökümanı ile ilişki
    /// </summary>
        public PayerInvoiceDocument PayerInvoiceDocument
        {
            get { return (PayerInvoiceDocument)((ITTObject)this).GetParent("PAYERINVOICEDOCUMENT"); }
            set { this["PAYERINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hizmet Karşılığı Kurum Faturası dökümanı ile ilişki
    /// </summary>
        public GeneralInvoiceDocument GeneralInvoiceDocument
        {
            get { return (GeneralInvoiceDocument)((ITTObject)this).GetParent("GENERALINVOICEDOCUMENT"); }
            set { this["GENERALINVOICEDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SendingInvoiceDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendingInvoiceDetails(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendingInvoiceDetails(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendingInvoiceDetails(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendingInvoiceDetails(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDINGINVOICEDETAILS", dataRow) { }
        protected SendingInvoiceDetails(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDINGINVOICEDETAILS", dataRow, isImported) { }
        public SendingInvoiceDetails(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendingInvoiceDetails(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendingInvoiceDetails() : base() { }

    }
}