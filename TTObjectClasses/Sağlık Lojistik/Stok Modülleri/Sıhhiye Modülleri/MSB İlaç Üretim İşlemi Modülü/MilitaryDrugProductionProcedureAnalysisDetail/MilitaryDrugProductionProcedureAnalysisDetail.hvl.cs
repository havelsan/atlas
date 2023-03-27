
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MilitaryDrugProductionProcedureAnalysisDetail")] 

    /// <summary>
    /// Test işlemi Analiz Detaylarını tutan sınıftır
    /// </summary>
    public  partial class MilitaryDrugProductionProcedureAnalysisDetail : TTObject
    {
        public class MilitaryDrugProductionProcedureAnalysisDetailList : TTObjectCollection<MilitaryDrugProductionProcedureAnalysisDetail> { }
                    
        public class ChildMilitaryDrugProductionProcedureAnalysisDetailCollection : TTObject.TTChildObjectCollection<MilitaryDrugProductionProcedureAnalysisDetail>
        {
            public ChildMilitaryDrugProductionProcedureAnalysisDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMilitaryDrugProductionProcedureAnalysisDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Test Sonucu
    /// </summary>
        public string TestResult
        {
            get { return (string)this["TESTRESULT"]; }
            set { this["TESTRESULT"] = value; }
        }

    /// <summary>
    /// Girilen Aşama
    /// </summary>
        public Guid? EnteredStateDefID
        {
            get { return (Guid?)this["ENTEREDSTATEDEFID"]; }
            set { this["ENTEREDSTATEDEFID"] = value; }
        }

    /// <summary>
    /// MSB İlaç Üretim İşlemi-Ürün Analiz Testleri
    /// </summary>
        public MilitaryDrugProductionProcedure MilitaryDrugProdProcedure
        {
            get { return (MilitaryDrugProductionProcedure)((ITTObject)this).GetParent("MILITARYDRUGPRODPROCEDURE"); }
            set { this["MILITARYDRUGPRODPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Testi Yapan Personel
    /// </summary>
        public ResUser TestPersonnel
        {
            get { return (ResUser)((ITTObject)this).GetParent("TESTPERSONNEL"); }
            set { this["TESTPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ürün Analiz Testi
    /// </summary>
        public ProductAnalysisTestDefinition ProductAnalysisTestDefinition
        {
            get { return (ProductAnalysisTestDefinition)((ITTObject)this).GetParent("PRODUCTANALYSISTESTDEFINITION"); }
            set { this["PRODUCTANALYSISTESTDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MilitaryDrugProductionProcedureAnalysisDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MilitaryDrugProductionProcedureAnalysisDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MilitaryDrugProductionProcedureAnalysisDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MilitaryDrugProductionProcedureAnalysisDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MilitaryDrugProductionProcedureAnalysisDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MILITARYDRUGPRODUCTIONPROCEDUREANALYSISDETAIL", dataRow) { }
        protected MilitaryDrugProductionProcedureAnalysisDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MILITARYDRUGPRODUCTIONPROCEDUREANALYSISDETAIL", dataRow, isImported) { }
        public MilitaryDrugProductionProcedureAnalysisDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MilitaryDrugProductionProcedureAnalysisDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MilitaryDrugProductionProcedureAnalysisDetail() : base() { }

    }
}