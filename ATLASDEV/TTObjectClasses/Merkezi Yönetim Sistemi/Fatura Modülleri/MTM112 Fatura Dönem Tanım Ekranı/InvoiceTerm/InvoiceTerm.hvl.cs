
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InvoiceTerm")] 

    public  partial class InvoiceTerm : TTDefinitionSet
    {
        public class InvoiceTermList : TTObjectCollection<InvoiceTerm> { }
                    
        public class ChildInvoiceTermCollection : TTObject.TTChildObjectCollection<InvoiceTerm>
        {
            public ChildInvoiceTermCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInvoiceTermCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInvoiceTerms_Class : TTReportNqlObject 
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

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? GSSDocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GSSDOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["GSSDOCUMENTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? Approved
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["APPROVED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["APPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? TempProtDocumentNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPPROTDOCUMENTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].AllPropertyDefs["TEMPPROTDOCUMENTNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetInvoiceTerms_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInvoiceTerms_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInvoiceTerms_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Açık
    /// </summary>
            public static Guid Open { get { return new Guid("a47459c7-a3ee-4c4d-bf8c-c4ae7effd2a5"); } }
    /// <summary>
    /// Kilitli
    /// </summary>
            public static Guid Locked { get { return new Guid("fa8dc95d-a75e-4cb6-bd6c-31e4eb59ff11"); } }
    /// <summary>
    /// Kapalı
    /// </summary>
            public static Guid Closed { get { return new Guid("895da38d-5cfe-4966-822a-19f6f3b5d584"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("5b95566c-1e3a-49a5-b8fd-95f9443628cb"); } }
        }

        public static BindingList<InvoiceTerm> GetInvoiceTermByDate(TTObjectContext objectContext, DateTime QUERYDATE, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].QueryDefs["GetInvoiceTermByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUERYDATE", QUERYDATE);
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<InvoiceTerm>(queryDef, paramList);
        }

        public static BindingList<InvoiceTerm> GetAllTerms(TTObjectContext objectContext, IList<Guid> STATES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].QueryDefs["GetAllTerms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATES", STATES);

            return ((ITTQuery)objectContext).QueryObjects<InvoiceTerm>(queryDef, paramList);
        }

        public static BindingList<InvoiceTerm.GetInvoiceTerms_Class> GetInvoiceTerms(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].QueryDefs["GetInvoiceTerms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceTerm.GetInvoiceTerms_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<InvoiceTerm.GetInvoiceTerms_Class> GetInvoiceTerms(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INVOICETERM"].QueryDefs["GetInvoiceTerms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<InvoiceTerm.GetInvoiceTerms_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? GSSDocumentNo
        {
            get { return (int?)this["GSSDOCUMENTNO"]; }
            set { this["GSSDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Medula Tutarı Onaylandı
    /// </summary>
        public bool? Approved
        {
            get { return (bool?)this["APPROVED"]; }
            set { this["APPROVED"] = value; }
        }

    /// <summary>
    /// Medula Tutarı Onay Tarihi
    /// </summary>
        public DateTime? ApproveDate
        {
            get { return (DateTime?)this["APPROVEDATE"]; }
            set { this["APPROVEDATE"] = value; }
        }

        public int? TempProtDocumentNo
        {
            get { return (int?)this["TEMPPROTDOCUMENTNO"]; }
            set { this["TEMPPROTDOCUMENTNO"] = value; }
        }

    /// <summary>
    /// Son state geçişini yapan kullanıcı
    /// </summary>
        public ResUser LastStateUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("LASTSTATEUSER"); }
            set { this["LASTSTATEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Medula Tutarını Onaylayan Kullanıcı
    /// </summary>
        public ResUser ApproveUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPROVEUSER"); }
            set { this["APPROVEUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateInvoiceCollectionsCollection()
        {
            _InvoiceCollections = new InvoiceCollection.ChildInvoiceCollectionCollection(this, new Guid("3687cc92-23b3-4f65-8770-477598abad24"));
            ((ITTChildObjectCollection)_InvoiceCollections).GetChildren();
        }

        protected InvoiceCollection.ChildInvoiceCollectionCollection _InvoiceCollections = null;
    /// <summary>
    /// Child collection for Icmalin hangi döneme bağlı olduğu bilgisi
    /// </summary>
        public InvoiceCollection.ChildInvoiceCollectionCollection InvoiceCollections
        {
            get
            {
                if (_InvoiceCollections == null)
                    CreateInvoiceCollectionsCollection();
                return _InvoiceCollections;
            }
        }

        virtual protected void CreateMedulaTakipBilgileriCollection()
        {
            _MedulaTakipBilgileri = new MedulaTakipBilgisi.ChildMedulaTakipBilgisiCollection(this, new Guid("1628ce91-b210-450a-872b-04340f2b61f6"));
            ((ITTChildObjectCollection)_MedulaTakipBilgileri).GetChildren();
        }

        protected MedulaTakipBilgisi.ChildMedulaTakipBilgisiCollection _MedulaTakipBilgileri = null;
    /// <summary>
    /// Child collection for Dönem Evrak No ile okunan medula takip bilgileri
    /// </summary>
        public MedulaTakipBilgisi.ChildMedulaTakipBilgisiCollection MedulaTakipBilgileri
        {
            get
            {
                if (_MedulaTakipBilgileri == null)
                    CreateMedulaTakipBilgileriCollection();
                return _MedulaTakipBilgileri;
            }
        }

        virtual protected void CreateMIFsCollection()
        {
            _MIFs = new MIF.ChildMIFCollection(this, new Guid("a6c4ece3-dbb3-4df6-a2ed-7ffb25003e1d"));
            ((ITTChildObjectCollection)_MIFs).GetChildren();
        }

        protected MIF.ChildMIFCollection _MIFs = null;
        public MIF.ChildMIFCollection MIFs
        {
            get
            {
                if (_MIFs == null)
                    CreateMIFsCollection();
                return _MIFs;
            }
        }

        protected InvoiceTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InvoiceTerm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InvoiceTerm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InvoiceTerm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InvoiceTerm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INVOICETERM", dataRow) { }
        protected InvoiceTerm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INVOICETERM", dataRow, isImported) { }
        public InvoiceTerm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InvoiceTerm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InvoiceTerm() : base() { }

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