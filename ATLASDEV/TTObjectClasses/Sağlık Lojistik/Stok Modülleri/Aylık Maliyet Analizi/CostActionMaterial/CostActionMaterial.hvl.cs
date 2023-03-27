
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CostActionMaterial")] 

    /// <summary>
    /// Aylık Maliyet Analizi Detay
    /// </summary>
    public  partial class CostActionMaterial : TTObject
    {
        public class CostActionMaterialList : TTObjectCollection<CostActionMaterial> { }
                    
        public class ChildCostActionMaterialCollection : TTObject.TTChildObjectCollection<CostActionMaterial>
        {
            public ChildCostActionMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCostActionMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPreviousCostAction_Class : TTReportNqlObject 
        {
            public BigCurrency? DifAvarageUnitePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIFAVARAGEUNITEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COSTACTIONMATERIAL"].AllPropertyDefs["DIFAVARAGEUNITEPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? TransferredAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSFERREDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COSTACTIONMATERIAL"].AllPropertyDefs["TRANSFERREDAMOUNT"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public GetPreviousCostAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPreviousCostAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPreviousCostAction_Class() : base() { }
        }

        public static BindingList<CostActionMaterial.GetPreviousCostAction_Class> GetPreviousCostAction(Guid MATERIALOBJECTID, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COSTACTIONMATERIAL"].QueryDefs["GetPreviousCostAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<CostActionMaterial.GetPreviousCostAction_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CostActionMaterial.GetPreviousCostAction_Class> GetPreviousCostAction(TTObjectContext objectContext, Guid MATERIALOBJECTID, DateTime ENDDATE, Guid STOREID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COSTACTIONMATERIAL"].QueryDefs["GetPreviousCostAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALOBJECTID", MATERIALOBJECTID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREID", STOREID);

            return TTReportNqlObject.QueryObjects<CostActionMaterial.GetPreviousCostAction_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kullanılmış
    /// </summary>
        public Currency? Used
        {
            get { return (Currency?)this["USED"]; }
            set { this["USED"] = value; }
        }

    /// <summary>
    /// Malzeme  Satıs Fiyatı
    /// </summary>
        public BigCurrency? MaterialPrice
        {
            get { return (BigCurrency?)this["MATERIALPRICE"]; }
            set { this["MATERIALPRICE"] = value; }
        }

    /// <summary>
    /// Bu Ay Toplam Çıkan
    /// </summary>
        public BigCurrency? TotalOutAmunt
        {
            get { return (BigCurrency?)this["TOTALOUTAMUNT"]; }
            set { this["TOTALOUTAMUNT"] = value; }
        }

    /// <summary>
    /// Önceki Aydan Toplam Maliyeti
    /// </summary>
        public BigCurrency? PreviousMonthPrice
        {
            get { return (BigCurrency?)this["PREVIOUSMONTHPRICE"]; }
            set { this["PREVIOUSMONTHPRICE"] = value; }
        }

    /// <summary>
    /// Önceki Dönem Arasındaki Maliyet Farkı
    /// </summary>
        public BigCurrency? DifAvarageUnitePrice
        {
            get { return (BigCurrency?)this["DIFAVARAGEUNITEPRICE"]; }
            set { this["DIFAVARAGEUNITEPRICE"] = value; }
        }

    /// <summary>
    /// Geçen Ayın Mevcudu
    /// </summary>
        public Currency? PreviousMothInheld
        {
            get { return (Currency?)this["PREVIOUSMOTHINHELD"]; }
            set { this["PREVIOUSMOTHINHELD"] = value; }
        }

    /// <summary>
    /// Bir Sonraki Aya Devreden Miktar
    /// </summary>
        public BigCurrency? TransferredAmount
        {
            get { return (BigCurrency?)this["TRANSFERREDAMOUNT"]; }
            set { this["TRANSFERREDAMOUNT"] = value; }
        }

    /// <summary>
    /// Kar / Zarar
    /// </summary>
        public BigCurrency? ProfitAndLoss
        {
            get { return (BigCurrency?)this["PROFITANDLOSS"]; }
            set { this["PROFITANDLOSS"] = value; }
        }

    /// <summary>
    /// Bu Ay Giren Toplam
    /// </summary>
        public Currency? TotalAmount
        {
            get { return (Currency?)this["TOTALAMOUNT"]; }
            set { this["TOTALAMOUNT"] = value; }
        }

    /// <summary>
    /// Bu Ay Toplam Tutar
    /// </summary>
        public BigCurrency? TotalPrice
        {
            get { return (BigCurrency?)this["TOTALPRICE"]; }
            set { this["TOTALPRICE"] = value; }
        }

    /// <summary>
    /// Bu Ay Birim Maliyet
    /// </summary>
        public BigCurrency? AvarageUnitePrice
        {
            get { return (BigCurrency?)this["AVARAGEUNITEPRICE"]; }
            set { this["AVARAGEUNITEPRICE"] = value; }
        }

    /// <summary>
    /// Material
    /// </summary>
        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Maliyet Analizi Detayları
    /// </summary>
        public CostAction CostAction
        {
            get { return (CostAction)((ITTObject)this).GetParent("COSTACTION"); }
            set { this["COSTACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCostActionLevelCollection()
        {
            _CostActionLevel = new CostActionLevel.ChildCostActionLevelCollection(this, new Guid("c8aac104-1cd5-4cc4-afb6-c2ac3cb403f8"));
            ((ITTChildObjectCollection)_CostActionLevel).GetChildren();
        }

        protected CostActionLevel.ChildCostActionLevelCollection _CostActionLevel = null;
        public CostActionLevel.ChildCostActionLevelCollection CostActionLevel
        {
            get
            {
                if (_CostActionLevel == null)
                    CreateCostActionLevelCollection();
                return _CostActionLevel;
            }
        }

        protected CostActionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CostActionMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CostActionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CostActionMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CostActionMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COSTACTIONMATERIAL", dataRow) { }
        protected CostActionMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COSTACTIONMATERIAL", dataRow, isImported) { }
        public CostActionMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CostActionMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CostActionMaterial() : base() { }

    }
}