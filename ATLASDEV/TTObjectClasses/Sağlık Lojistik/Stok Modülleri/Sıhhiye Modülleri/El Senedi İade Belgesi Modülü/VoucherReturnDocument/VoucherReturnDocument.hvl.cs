
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VoucherReturnDocument")] 

    /// <summary>
    /// El Senedi İade Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class VoucherReturnDocument : StockAction, IVoucherReturnDocument, IStockTransferTransaction
    {
        public class VoucherReturnDocumentList : TTObjectCollection<VoucherReturnDocument> { }
                    
        public class ChildVoucherReturnDocumentCollection : TTObject.TTChildObjectCollection<VoucherReturnDocument>
        {
            public ChildVoucherReturnDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVoucherReturnDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetVoucherReturnDocumentCensusReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VOUCHERRETURNDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetVoucherReturnDocumentCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVoucherReturnDocumentCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVoucherReturnDocumentCensusReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("aeeec628-5002-4261-9a1f-54ecd3d10d11"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("2b1b26b6-f8c7-4820-b9fd-6335d665dc79"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("fb2084ce-3ec7-4764-8f2b-854ae0554792"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("bfc41c06-8e3d-476e-85e0-95a560a0f901"); } }
        }

        public static BindingList<VoucherReturnDocument.GetVoucherReturnDocumentCensusReportQuery_Class> GetVoucherReturnDocumentCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERRETURNDOCUMENT"].QueryDefs["GetVoucherReturnDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<VoucherReturnDocument.GetVoucherReturnDocumentCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<VoucherReturnDocument.GetVoucherReturnDocumentCensusReportQuery_Class> GetVoucherReturnDocumentCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VOUCHERRETURNDOCUMENT"].QueryDefs["GetVoucherReturnDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<VoucherReturnDocument.GetVoucherReturnDocumentCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _VoucherReturnDocumentMaterials = new VoucherReturnDocumentMaterial.ChildVoucherReturnDocumentMaterialCollection(_StockActionDetails, "VoucherReturnDocumentMaterials");
            _PresVoucherReturnDocumentMaterials = new PresVoucherReturnDocMat.ChildPresVoucherReturnDocMatCollection(_StockActionDetails, "PresVoucherReturnDocumentMaterials");
        }

        private VoucherReturnDocumentMaterial.ChildVoucherReturnDocumentMaterialCollection _VoucherReturnDocumentMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public VoucherReturnDocumentMaterial.ChildVoucherReturnDocumentMaterialCollection VoucherReturnDocumentMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _VoucherReturnDocumentMaterials;
            }            
        }

        private PresVoucherReturnDocMat.ChildPresVoucherReturnDocMatCollection _PresVoucherReturnDocumentMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PresVoucherReturnDocMat.ChildPresVoucherReturnDocMatCollection PresVoucherReturnDocumentMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresVoucherReturnDocumentMaterials;
            }            
        }

        protected VoucherReturnDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VoucherReturnDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VoucherReturnDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VoucherReturnDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VoucherReturnDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VOUCHERRETURNDOCUMENT", dataRow) { }
        protected VoucherReturnDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VOUCHERRETURNDOCUMENT", dataRow, isImported) { }
        public VoucherReturnDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VoucherReturnDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VoucherReturnDocument() : base() { }

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