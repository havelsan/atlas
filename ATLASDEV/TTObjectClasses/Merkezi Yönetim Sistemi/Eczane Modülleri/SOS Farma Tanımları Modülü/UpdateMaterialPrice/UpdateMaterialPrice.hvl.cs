
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UpdateMaterialPrice")] 

    public  partial class UpdateMaterialPrice : TTObject
    {
        public class UpdateMaterialPriceList : TTObjectCollection<UpdateMaterialPrice> { }
                    
        public class ChildUpdateMaterialPriceCollection : TTObject.TTChildObjectCollection<UpdateMaterialPrice>
        {
            public ChildUpdateMaterialPriceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUpdateMaterialPriceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class UpdateMaterialPriceRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPDATEMATERIALPRICE"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPDATEMATERIALPRICE"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Desciption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPDATEMATERIALPRICE"].AllPropertyDefs["DESCIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UPDATEMATERIALPRICE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public UpdateMaterialPriceRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public UpdateMaterialPriceRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected UpdateMaterialPriceRQ_Class() : base() { }
        }

        public static BindingList<UpdateMaterialPrice.UpdateMaterialPriceRQ_Class> UpdateMaterialPriceRQ(MaterialTypeEnum MaterialType, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPDATEMATERIALPRICE"].QueryDefs["UpdateMaterialPriceRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALTYPE", (int)MaterialType);

            return TTReportNqlObject.QueryObjects<UpdateMaterialPrice.UpdateMaterialPriceRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<UpdateMaterialPrice.UpdateMaterialPriceRQ_Class> UpdateMaterialPriceRQ(TTObjectContext objectContext, MaterialTypeEnum MaterialType, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UPDATEMATERIALPRICE"].QueryDefs["UpdateMaterialPriceRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIALTYPE", (int)MaterialType);

            return TTReportNqlObject.QueryObjects<UpdateMaterialPrice.UpdateMaterialPriceRQ_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Barkod Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public MaterialTypeEnum? MaterialType
        {
            get { return (MaterialTypeEnum?)(int?)this["MATERIALTYPE"]; }
            set { this["MATERIALTYPE"] = value; }
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

    /// <summary>
    /// Fiyat geçerlilik başlama zamanı
    /// </summary>
        public DateTime? DateStart
        {
            get { return (DateTime?)this["DATESTART"]; }
            set { this["DATESTART"] = value; }
        }

    /// <summary>
    /// İndirim Oranı
    /// </summary>
        public double? DiscountPercent
        {
            get { return (double?)this["DISCOUNTPERCENT"]; }
            set { this["DISCOUNTPERCENT"] = value; }
        }

    /// <summary>
    /// Updated
    /// </summary>
        public bool? Updated
        {
            get { return (bool?)this["UPDATED"]; }
            set { this["UPDATED"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected UpdateMaterialPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UpdateMaterialPrice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UpdateMaterialPrice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UpdateMaterialPrice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UpdateMaterialPrice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UPDATEMATERIALPRICE", dataRow) { }
        protected UpdateMaterialPrice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UPDATEMATERIALPRICE", dataRow, isImported) { }
        public UpdateMaterialPrice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UpdateMaterialPrice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UpdateMaterialPrice() : base() { }

    }
}