
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceCollectionDocument")] 

    /// <summary>
    /// Toplu Fatura Dökümanı
    /// </summary>
    public  partial class InvoiceCollectionDocument : AccountDocument
    {
        public class InvoiceCollectionDocumentList : TTObjectCollection<InvoiceCollectionDocument> { }
                    
        public class ChildInvoiceCollectionDocumentCollection : TTObject.TTChildObjectCollection<InvoiceCollectionDocument>
        {
            public ChildInvoiceCollectionDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceCollectionDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class InvoiceCollectionReportInfoQuery_Class : TTReportNqlObject 
        {
            public Guid? Icdobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ICDOBJECTID"]);
                }
            }

            public Guid? Payer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PAYER"]);
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

            public long? Payerid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Payercitycode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Payercityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERCITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CITY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payeraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxoffice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXOFFICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXOFFICE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Payertaxnumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYERTAXNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["TAXNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENT"].AllPropertyDefs["DOCUMENTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Drugtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DRUGTOTAL"]);
                }
            }

            public Object Materialtotal
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALTOTAL"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Cashier
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHIER"]);
                }
            }

            public InvoiceCollectionReportInfoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoiceCollectionReportInfoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoiceCollectionReportInfoQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class InvoiceCollectionReportQuery_Class : TTReportNqlObject 
        {
            public string Pricinggroupdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGGROUPDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENTGROUP"].AllPropertyDefs["GROUPDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENTDETAIL"].AllPropertyDefs["EXTERNALCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENTDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENTDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public InvoiceCollectionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public InvoiceCollectionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected InvoiceCollectionReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Faturalandı
    /// </summary>
            public static Guid Invoiced { get { return new Guid("74ee420f-32f4-4050-ab14-0960b7008359"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("17638e23-6880-4727-be71-2318df34a3b4"); } }
        }

        public static BindingList<InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class> InvoiceCollectionReportInfoQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENT"].QueryDefs["InvoiceCollectionReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class> InvoiceCollectionReportInfoQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENT"].QueryDefs["InvoiceCollectionReportInfoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDocument.InvoiceCollectionReportInfoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class> InvoiceCollectionReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENT"].QueryDefs["InvoiceCollectionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class> InvoiceCollectionReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICECOLLECTIONDOCUMENT"].QueryDefs["InvoiceCollectionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<InvoiceCollectionDocument.InvoiceCollectionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İlaç Toplamı
    /// </summary>
        public Currency? DrugTotal
        {
            get { return (Currency?)this["DRUGTOTAL"]; }
            set { this["DRUGTOTAL"] = value; }
        }

    /// <summary>
    /// Malzeme Toplamı
    /// </summary>
        public Currency? MaterialTotal
        {
            get { return (Currency?)this["MATERIALTOTAL"]; }
            set { this["MATERIALTOTAL"] = value; }
        }

    /// <summary>
    /// Kurumla İlişki
    /// </summary>
        public PayerDefinition Payer
        {
            get { return (PayerDefinition)((ITTObject)this).GetParent("PAYER"); }
            set { this["PAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInvoiceCollectionCollection()
        {
            _InvoiceCollection = new InvoiceCollection.ChildInvoiceCollectionCollection(this, new Guid("ac10ca9b-2754-436a-9701-376150f52f5a"));
            ((ITTChildObjectCollection)_InvoiceCollection).GetChildren();
        }

        protected InvoiceCollection.ChildInvoiceCollectionCollection _InvoiceCollection = null;
        public InvoiceCollection.ChildInvoiceCollectionCollection InvoiceCollection
        {
            get
            {
                if (_InvoiceCollection == null)
                    CreateInvoiceCollectionCollection();
                return _InvoiceCollection;
            }
        }

        override protected void CreateAccountDocumentGroupsCollectionViews()
        {
            base.CreateAccountDocumentGroupsCollectionViews();
            _InvoiceCollectionDocumentGroups = new InvoiceCollectionDocumentGroup.ChildInvoiceCollectionDocumentGroupCollection(_AccountDocumentGroups, "InvoiceCollectionDocumentGroups");
        }

        private InvoiceCollectionDocumentGroup.ChildInvoiceCollectionDocumentGroupCollection _InvoiceCollectionDocumentGroups = null;
        public InvoiceCollectionDocumentGroup.ChildInvoiceCollectionDocumentGroupCollection InvoiceCollectionDocumentGroups
        {
            get
            {
                if (_AccountDocumentGroups == null)
                    CreateAccountDocumentGroupsCollection();
                return _InvoiceCollectionDocumentGroups;
            }            
        }

        protected InvoiceCollectionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceCollectionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceCollectionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceCollectionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceCollectionDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICECOLLECTIONDOCUMENT", dataRow) { }
        protected InvoiceCollectionDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICECOLLECTIONDOCUMENT", dataRow, isImported) { }
        public InvoiceCollectionDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceCollectionDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceCollectionDocument() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}