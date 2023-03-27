
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionConsumptionDocument")] 

    /// <summary>
    /// Tüketim, Üretim ve Elde Edilenler Belgesi (Reçeteler İçin)
    /// </summary>
    public  partial class PrescriptionConsumptionDocument : ProductionConsumptionDocument, IAutoDocumentNumber, IAutoDocumentRecordLog, IProductionConsumptionDocument, IStockConsumptionTransaction, IStockProductionTransaction, IBasePrescriptionTransaction
    {
        public class PrescriptionConsumptionDocumentList : TTObjectCollection<PrescriptionConsumptionDocument> { }
                    
        public class ChildPrescriptionConsumptionDocumentCollection : TTObject.TTChildObjectCollection<PrescriptionConsumptionDocument>
        {
            public ChildPrescriptionConsumptionDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionConsumptionDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPrescriptionConsumptionDetails_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ActionDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["ACTIONDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["ACTIONID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string DocktorFullName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCKTORFULLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["DOCKTORFULLNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatienFullName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENFULLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["PATIENFULLNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrescriptionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["PRESCRIPTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPrescriptionConsumptionDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPrescriptionConsumptionDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPrescriptionConsumptionDetails_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("ec43b29f-cbd1-47e3-804f-89455e67b3b0"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("5b68b766-926c-4808-b1fc-38e3db454636"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("a8d7a5a5-3946-48c7-99e8-e547fd6e5e3f"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("c2d21715-662f-46e2-aed5-9e6f994fa2f5"); } }
    /// <summary>
    /// Stok Kart Kayıt
    /// </summary>
            public static Guid StockCardRegistry { get { return new Guid("92d60bfe-18be-45e0-9f69-8ee0bd4c4c61"); } }
        }

        public static BindingList<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class> GetPrescriptionConsumptionDetails(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDOCUMENT"].QueryDefs["GetPrescriptionConsumptionDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class> GetPrescriptionConsumptionDetails(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDOCUMENT"].QueryDefs["GetPrescriptionConsumptionDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PrescriptionConsumptionDocument.GetPrescriptionConsumptionDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PresConsumptionDocOutMaterials = new PrescriptionConsDocMatOut.ChildPrescriptionConsDocMatOutCollection(_StockActionDetails, "PresConsumptionDocOutMaterials");
        }

        private PrescriptionConsDocMatOut.ChildPrescriptionConsDocMatOutCollection _PresConsumptionDocOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PrescriptionConsDocMatOut.ChildPrescriptionConsDocMatOutCollection PresConsumptionDocOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PresConsumptionDocOutMaterials;
            }            
        }

        protected PrescriptionConsumptionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionConsumptionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionConsumptionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionConsumptionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionConsumptionDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONCONSUMPTIONDOCUMENT", dataRow) { }
        protected PrescriptionConsumptionDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONCONSUMPTIONDOCUMENT", dataRow, isImported) { }
        public PrescriptionConsumptionDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionConsumptionDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionConsumptionDocument() : base() { }

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