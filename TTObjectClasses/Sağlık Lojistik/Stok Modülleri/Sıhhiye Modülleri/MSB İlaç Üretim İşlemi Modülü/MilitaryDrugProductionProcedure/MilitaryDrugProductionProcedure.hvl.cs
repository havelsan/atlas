
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MilitaryDrugProductionProcedure")] 

    /// <summary>
    /// MSB İlaç Üretim İşlemi için kullanılan temel sınıftır
    /// </summary>
    public  partial class MilitaryDrugProductionProcedure : StockAction, ICheckStockActionOutDetail, IStockOutTransaction
    {
        public class MilitaryDrugProductionProcedureList : TTObjectCollection<MilitaryDrugProductionProcedure> { }
                    
        public class ChildMilitaryDrugProductionProcedureCollection : TTObject.TTChildObjectCollection<MilitaryDrugProductionProcedure>
        {
            public ChildMilitaryDrugProductionProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMilitaryDrugProductionProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMilitaryDrugProductionProcedureAnalysisDetails_Class : TTReportNqlObject 
        {
            public string Testname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTANALYSISTESTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TestResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYDRUGPRODUCTIONPROCEDUREANALYSISDETAIL"].AllPropertyDefs["TESTRESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Testpersonnelname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESTPERSONNELNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMilitaryDrugProductionProcedureAnalysisDetails_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMilitaryDrugProductionProcedureAnalysisDetails_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMilitaryDrugProductionProcedureAnalysisDetails_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("e7f4c70d-5563-4def-9716-4d9ada149251"); } }
            public static Guid Released { get { return new Guid("7535bc1c-e928-47b2-82d3-4478d7067180"); } }
            public static Guid Completed { get { return new Guid("4875b064-df7a-424c-8f5e-7941d33ea1dd"); } }
            public static Guid Processed { get { return new Guid("8d618aec-bf29-4128-974e-fc0e8c8e94e2"); } }
            public static Guid New { get { return new Guid("3c9ac163-99e7-48ef-ae83-dca51960beca"); } }
        }

        public static BindingList<MilitaryDrugProductionProcedure.GetMilitaryDrugProductionProcedureAnalysisDetails_Class> GetMilitaryDrugProductionProcedureAnalysisDetails(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYDRUGPRODUCTIONPROCEDURE"].QueryDefs["GetMilitaryDrugProductionProcedureAnalysisDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MilitaryDrugProductionProcedure.GetMilitaryDrugProductionProcedureAnalysisDetails_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MilitaryDrugProductionProcedure.GetMilitaryDrugProductionProcedureAnalysisDetails_Class> GetMilitaryDrugProductionProcedureAnalysisDetails(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYDRUGPRODUCTIONPROCEDURE"].QueryDefs["GetMilitaryDrugProductionProcedureAnalysisDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MilitaryDrugProductionProcedure.GetMilitaryDrugProductionProcedureAnalysisDetails_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MilitaryDrugProductionProcedure> GetProcedureBySerialNumber(TTObjectContext objectContext, string SERIALNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MILITARYDRUGPRODUCTIONPROCEDURE"].QueryDefs["GetProcedureBySerialNumber"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SERIALNO", SERIALNO);

            return ((ITTQuery)objectContext).QueryObjects<MilitaryDrugProductionProcedure>(queryDef, paramList);
        }

    /// <summary>
    /// Seri No Ana Depo Kodu
    /// </summary>
        public long? SerialNoYearMainstoreCode
        {
            get { return (long?)this["SERIALNOYEARMAINSTORECODE"]; }
            set { this["SERIALNOYEARMAINSTORECODE"] = value; }
        }

    /// <summary>
    /// Seri No Yılı
    /// </summary>
        public long? SerialNoYear
        {
            get { return (long?)this["SERIALNOYEAR"]; }
            set { this["SERIALNOYEAR"] = value; }
        }

    /// <summary>
    /// Seri No Miad
    /// </summary>
        public long? SerialNoExpiration
        {
            get { return (long?)this["SERIALNOEXPIRATION"]; }
            set { this["SERIALNOEXPIRATION"] = value; }
        }

    /// <summary>
    /// Üretim Açıklaması
    /// </summary>
        public string ProductDescription
        {
            get { return (string)this["PRODUCTDESCRIPTION"]; }
            set { this["PRODUCTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Ürün Adı
    /// </summary>
        public string ProductName
        {
            get { return (string)this["PRODUCTNAME"]; }
            set { this["PRODUCTNAME"] = value; }
        }

    /// <summary>
    /// Seri No Ayı
    /// </summary>
        public long? SerialNoMonth
        {
            get { return (long?)this["SERIALNOMONTH"]; }
            set { this["SERIALNOMONTH"] = value; }
        }

    /// <summary>
    /// Seri Nu.
    /// </summary>
        public string SerialNO
        {
            get { return (string)this["SERIALNO"]; }
            set { this["SERIALNO"] = value; }
        }

    /// <summary>
    /// Üretilen Malzeme Miktarı
    /// </summary>
        public double? ProducedMaterialAmount
        {
            get { return (double?)this["PRODUCEDMATERIALAMOUNT"]; }
            set { this["PRODUCEDMATERIALAMOUNT"] = value; }
        }

    /// <summary>
    /// Seri No servis Kodu
    /// </summary>
        public long? SerialNoServiceCode
        {
            get { return (long?)this["SERIALNOSERVICECODE"]; }
            set { this["SERIALNOSERVICECODE"] = value; }
        }

    /// <summary>
    /// Son Kullanma Tarihi
    /// </summary>
        public DateTime? ExpirationDateOfProduction
        {
            get { return (DateTime?)this["EXPIRATIONDATEOFPRODUCTION"]; }
            set { this["EXPIRATIONDATEOFPRODUCTION"] = value; }
        }

    /// <summary>
    /// IBF Yılı
    /// </summary>
        public string IBFYear
        {
            get { return (string)this["IBFYEAR"]; }
            set { this["IBFYEAR"] = value; }
        }

    /// <summary>
    /// İBY Yılı
    /// </summary>
        public ProductAnnualReqDet ProductAnnualReqDet
        {
            get { return (ProductAnnualReqDet)((ITTObject)this).GetParent("PRODUCTANNUALREQDET"); }
            set { this["PRODUCTANNUALREQDET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Üretilen Malzeme
    /// </summary>
        public ProductTreeDefinition ProducedMaterial
        {
            get { return (ProductTreeDefinition)((ITTObject)this).GetParent("PRODUCEDMATERIAL"); }
            set { this["PRODUCEDMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMilitaryDrugProductionProcedureAnalysisDetailsCollection()
        {
            _MilitaryDrugProductionProcedureAnalysisDetails = new MilitaryDrugProductionProcedureAnalysisDetail.ChildMilitaryDrugProductionProcedureAnalysisDetailCollection(this, new Guid("b38c6a9a-d7b8-4ece-bb8d-1aec448d9afa"));
            ((ITTChildObjectCollection)_MilitaryDrugProductionProcedureAnalysisDetails).GetChildren();
        }

        protected MilitaryDrugProductionProcedureAnalysisDetail.ChildMilitaryDrugProductionProcedureAnalysisDetailCollection _MilitaryDrugProductionProcedureAnalysisDetails = null;
    /// <summary>
    /// Child collection for MSB İlaç Üretim İşlemi-Ürün Analiz Testleri
    /// </summary>
        public MilitaryDrugProductionProcedureAnalysisDetail.ChildMilitaryDrugProductionProcedureAnalysisDetailCollection MilitaryDrugProductionProcedureAnalysisDetails
        {
            get
            {
                if (_MilitaryDrugProductionProcedureAnalysisDetails == null)
                    CreateMilitaryDrugProductionProcedureAnalysisDetailsCollection();
                return _MilitaryDrugProductionProcedureAnalysisDetails;
            }
        }

        virtual protected void CreateDrugProductionTestsCollection()
        {
            _DrugProductionTests = new DrugProductionTest.ChildDrugProductionTestCollection(this, new Guid("3a566972-4ca4-42ef-90f5-9180a4fb9ec0"));
            ((ITTChildObjectCollection)_DrugProductionTests).GetChildren();
        }

        protected DrugProductionTest.ChildDrugProductionTestCollection _DrugProductionTests = null;
        public DrugProductionTest.ChildDrugProductionTestCollection DrugProductionTests
        {
            get
            {
                if (_DrugProductionTests == null)
                    CreateDrugProductionTestsCollection();
                return _DrugProductionTests;
            }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _MilitaryDrugProductionProcedureOutMaterials = new MilitaryDrugProductionProcedureMaterialOut.ChildMilitaryDrugProductionProcedureMaterialOutCollection(_StockActionDetails, "MilitaryDrugProductionProcedureOutMaterials");
        }

        private MilitaryDrugProductionProcedureMaterialOut.ChildMilitaryDrugProductionProcedureMaterialOutCollection _MilitaryDrugProductionProcedureOutMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public MilitaryDrugProductionProcedureMaterialOut.ChildMilitaryDrugProductionProcedureMaterialOutCollection MilitaryDrugProductionProcedureOutMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _MilitaryDrugProductionProcedureOutMaterials;
            }            
        }

        protected MilitaryDrugProductionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MilitaryDrugProductionProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MilitaryDrugProductionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MilitaryDrugProductionProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MilitaryDrugProductionProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MILITARYDRUGPRODUCTIONPROCEDURE", dataRow) { }
        protected MilitaryDrugProductionProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MILITARYDRUGPRODUCTIONPROCEDURE", dataRow, isImported) { }
        public MilitaryDrugProductionProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MilitaryDrugProductionProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MilitaryDrugProductionProcedure() : base() { }

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