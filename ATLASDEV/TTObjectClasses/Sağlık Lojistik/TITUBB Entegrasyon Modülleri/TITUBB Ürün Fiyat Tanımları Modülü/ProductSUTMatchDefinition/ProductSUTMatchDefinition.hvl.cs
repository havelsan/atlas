
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductSUTMatchDefinition")] 

    /// <summary>
    /// TITUBB Ürün SGK Detayları Tanımı
    /// </summary>
    public  partial class ProductSUTMatchDefinition : TerminologyManagerDef
    {
        public class ProductSUTMatchDefinitionList : TTObjectCollection<ProductSUTMatchDefinition> { }
                    
        public class ChildProductSUTMatchDefinitionCollection : TTObject.TTChildObjectCollection<ProductSUTMatchDefinition>
        {
            public ChildProductSUTMatchDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductSUTMatchDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProductSUTMatch_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string SUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTSUTMATCHDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SUTName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTSUTMATCHDEFINITION"].AllPropertyDefs["SUTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Productname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProductSUTMatch_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProductSUTMatch_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProductSUTMatch_Class() : base() { }
        }

        public static BindingList<ProductSUTMatchDefinition.GetProductSUTMatch_Class> GetProductSUTMatch(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTSUTMATCHDEFINITION"].QueryDefs["GetProductSUTMatch"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductSUTMatchDefinition.GetProductSUTMatch_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProductSUTMatchDefinition.GetProductSUTMatch_Class> GetProductSUTMatch(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTSUTMATCHDEFINITION"].QueryDefs["GetProductSUTMatch"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductSUTMatchDefinition.GetProductSUTMatch_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// XXXXXX'da Kullan
    /// </summary>
        public bool? IsUseXXXXXX
        {
            get { return (bool?)this["ISUSEXXXXXX"]; }
            set { this["ISUSEXXXXXX"] = value; }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public string SUTCode
        {
            get { return (string)this["SUTCODE"]; }
            set { this["SUTCODE"] = value; }
        }

    /// <summary>
    /// SUT Adı
    /// </summary>
        public string SUTName
        {
            get { return (string)this["SUTNAME"]; }
            set { this["SUTNAME"] = value; }
        }

    /// <summary>
    /// SUT Fiyatı
    /// </summary>
        public Currency? SUTPrice
        {
            get { return (Currency?)this["SUTPRICE"]; }
            set { this["SUTPRICE"] = value; }
        }

    /// <summary>
    /// TITUBBProductSUTMatchID
    /// </summary>
        public string TITUBBProductSUTMatchID
        {
            get { return (string)this["TITUBBPRODUCTSUTMATCHID"]; }
            set { this["TITUBBPRODUCTSUTMATCHID"] = value; }
        }

        public SUTAppendixDefinition SUTAppendix
        {
            get { return (SUTAppendixDefinition)((ITTObject)this).GetParent("SUTAPPENDIX"); }
            set { this["SUTAPPENDIX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProductDefinition Product
        {
            get { return (ProductDefinition)((ITTObject)this).GetParent("PRODUCT"); }
            set { this["PRODUCT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProductSUTMatchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductSUTMatchDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductSUTMatchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductSUTMatchDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductSUTMatchDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTSUTMATCHDEFINITION", dataRow) { }
        protected ProductSUTMatchDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTSUTMATCHDEFINITION", dataRow, isImported) { }
        public ProductSUTMatchDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductSUTMatchDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductSUTMatchDefinition() : base() { }

    }
}