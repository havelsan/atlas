
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReceiptBack")] 

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade işlemi
    /// </summary>
    public  partial class ReceiptBack : EpisodeAccountAction
    {
        public class ReceiptBackList : TTObjectCollection<ReceiptBack> { }
                    
        public class ChildReceiptBackCollection : TTObject.TTChildObjectCollection<ReceiptBack>
        {
            public ChildReceiptBackCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReceiptBackCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ReceiptBackReportQuery_Class : TTReportNqlObject 
        {
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

            public string CashOfficeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACK"].AllPropertyDefs["CASHOFFICENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? CashOffice
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CASHOFFICE"]);
                }
            }

            public string ReceiptNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACK"].AllPropertyDefs["RECEIPTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACKDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfReturn
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFRETURN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACK"].AllPropertyDefs["REASONOFRETURN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? ReceiptTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIPTTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACK"].AllPropertyDefs["RECEIPTTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ReturnTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETURNTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACK"].AllPropertyDefs["RETURNTOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public ReceiptBackReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ReceiptBackReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ReceiptBackReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("45bf6d1d-191a-440b-9c6f-99b6782c75df"); } }
            public static Guid New { get { return new Guid("1c3e4ccf-3546-407e-8b1e-a910eeba8188"); } }
            public static Guid ReturnBack { get { return new Guid("51697237-09eb-4374-af21-84a9920920c2"); } }
        }

        public static BindingList<ReceiptBack.ReceiptBackReportQuery_Class> ReceiptBackReportQuery(string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACK"].QueryDefs["ReceiptBackReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptBack.ReceiptBackReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReceiptBack.ReceiptBackReportQuery_Class> ReceiptBackReportQuery(TTObjectContext objectContext, string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RECEIPTBACK"].QueryDefs["ReceiptBackReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<ReceiptBack.ReceiptBackReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındı Numarası
    /// </summary>
        public string ReceiptNo
        {
            get { return (string)this["RECEIPTNO"]; }
            set { this["RECEIPTNO"] = value; }
        }

    /// <summary>
    /// İade Edilecek Tutar
    /// </summary>
        public Currency? ReturnTotalPrice
        {
            get { return (Currency?)this["RETURNTOTALPRICE"]; }
            set { this["RETURNTOTALPRICE"] = value; }
        }

    /// <summary>
    /// İade Sebebi
    /// </summary>
        public string ReasonOfReturn
        {
            get { return (string)this["REASONOFRETURN"]; }
            set { this["REASONOFRETURN"] = value; }
        }

    /// <summary>
    /// Toplam Tutar
    /// </summary>
        public Currency? ReceiptTotalPrice
        {
            get { return (Currency?)this["RECEIPTTOTALPRICE"]; }
            set { this["RECEIPTTOTALPRICE"] = value; }
        }

    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade Dökümanıyla ilişki
    /// </summary>
        public ReceiptBackDocument ReceiptBackDocument
        {
            get { return (ReceiptBackDocument)((ITTObject)this).GetParent("RECEIPTBACKDOCUMENT"); }
            set { this["RECEIPTBACKDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Receipt Receipt
        {
            get { return (Receipt)((ITTObject)this).GetParent("RECEIPT"); }
            set { this["RECEIPT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("5905197e-e5d2-4142-a9f4-78ea8cf55aa7"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreateReceiptBackDetailsCollection()
        {
            _ReceiptBackDetails = new ReceiptBackDetail.ChildReceiptBackDetailCollection(this, new Guid("6f13f730-3fbe-4bbd-82b4-98c5b806ce45"));
            ((ITTChildObjectCollection)_ReceiptBackDetails).GetChildren();
        }

        protected ReceiptBackDetail.ChildReceiptBackDetailCollection _ReceiptBackDetails = null;
    /// <summary>
    /// Child collection for Muhasebe Yetkilisi Mutemedi Alındısı İade İşlemiyle İlişki
    /// </summary>
        public ReceiptBackDetail.ChildReceiptBackDetailCollection ReceiptBackDetails
        {
            get
            {
                if (_ReceiptBackDetails == null)
                    CreateReceiptBackDetailsCollection();
                return _ReceiptBackDetails;
            }
        }

        protected ReceiptBack(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReceiptBack(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReceiptBack(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReceiptBack(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReceiptBack(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RECEIPTBACK", dataRow) { }
        protected ReceiptBack(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RECEIPTBACK", dataRow, isImported) { }
        public ReceiptBack(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReceiptBack(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReceiptBack() : base() { }

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