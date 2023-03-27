
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductTreeDefinition")] 

    /// <summary>
    /// Ürün Ağacı Tanımları
    /// </summary>
    public  partial class ProductTreeDefinition : TTDefinitionSet
    {
        public class ProductTreeDefinitionList : TTObjectCollection<ProductTreeDefinition> { }
                    
        public class ChildProductTreeDefinitionCollection : TTObject.TTChildObjectCollection<ProductTreeDefinition>
        {
            public ChildProductTreeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductTreeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProductTreeDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProductTreeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProductTreeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProductTreeDefinition_Class() : base() { }
        }

        public static BindingList<ProductTreeDefinition> GetProductTotalItem(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDEFINITION"].QueryDefs["GetProductTotalItem"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ProductTreeDefinition>(queryDef, paramList);
        }

        public static BindingList<ProductTreeDefinition.GetProductTreeDefinition_Class> GetProductTreeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDEFINITION"].QueryDefs["GetProductTreeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductTreeDefinition.GetProductTreeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProductTreeDefinition.GetProductTreeDefinition_Class> GetProductTreeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTTREEDEFINITION"].QueryDefs["GetProductTreeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductTreeDefinition.GetProductTreeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Referans Miktar
    /// </summary>
        public int? SampleAmount
        {
            get { return (int?)this["SAMPLEAMOUNT"]; }
            set { this["SAMPLEAMOUNT"] = value; }
        }

    /// <summary>
    /// Üretim Servisi-Ürünler
    /// </summary>
        public ResProductionService ProductionService
        {
            get { return (ResProductionService)((ITTObject)this).GetParent("PRODUCTIONSERVICE"); }
            set { this["PRODUCTIONSERVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ürün
    /// </summary>
        public DrugDefinition OldDrugDefinition
        {
            get { return (DrugDefinition)((ITTObject)this).GetParent("OLDDRUGDEFINITION"); }
            set { this["OLDDRUGDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ürün
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProductTreeAnalyseTestsCollection()
        {
            _ProductTreeAnalyseTests = new ProductTreeAnalyseTest.ChildProductTreeAnalyseTestCollection(this, new Guid("95adc869-f1ea-435d-95e5-d1fff4425e32"));
            ((ITTChildObjectCollection)_ProductTreeAnalyseTests).GetChildren();
        }

        protected ProductTreeAnalyseTest.ChildProductTreeAnalyseTestCollection _ProductTreeAnalyseTests = null;
        public ProductTreeAnalyseTest.ChildProductTreeAnalyseTestCollection ProductTreeAnalyseTests
        {
            get
            {
                if (_ProductTreeAnalyseTests == null)
                    CreateProductTreeAnalyseTestsCollection();
                return _ProductTreeAnalyseTests;
            }
        }

        virtual protected void CreateProductAnnualReqDetsCollection()
        {
            _ProductAnnualReqDets = new ProductAnnualReqDet.ChildProductAnnualReqDetCollection(this, new Guid("12dd9234-d452-4e90-84c4-34970e10f142"));
            ((ITTChildObjectCollection)_ProductAnnualReqDets).GetChildren();
        }

        protected ProductAnnualReqDet.ChildProductAnnualReqDetCollection _ProductAnnualReqDets = null;
    /// <summary>
    /// Child collection for Ürün Ağacı-İBF İhtiyaçları
    /// </summary>
        public ProductAnnualReqDet.ChildProductAnnualReqDetCollection ProductAnnualReqDets
        {
            get
            {
                if (_ProductAnnualReqDets == null)
                    CreateProductAnnualReqDetsCollection();
                return _ProductAnnualReqDets;
            }
        }

        virtual protected void CreateProductTreeDetailsCollection()
        {
            _ProductTreeDetails = new ProductTreeDetail.ChildProductTreeDetailCollection(this, new Guid("f31c62b0-be5d-4e8e-9829-63913f3bb355"));
            ((ITTChildObjectCollection)_ProductTreeDetails).GetChildren();
        }

        protected ProductTreeDetail.ChildProductTreeDetailCollection _ProductTreeDetails = null;
    /// <summary>
    /// Child collection for Ürün Ağacı Detayları
    /// </summary>
        public ProductTreeDetail.ChildProductTreeDetailCollection ProductTreeDetails
        {
            get
            {
                if (_ProductTreeDetails == null)
                    CreateProductTreeDetailsCollection();
                return _ProductTreeDetails;
            }
        }

        protected ProductTreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductTreeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductTreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductTreeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductTreeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTTREEDEFINITION", dataRow) { }
        protected ProductTreeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTTREEDEFINITION", dataRow, isImported) { }
        public ProductTreeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductTreeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductTreeDefinition() : base() { }

    }
}