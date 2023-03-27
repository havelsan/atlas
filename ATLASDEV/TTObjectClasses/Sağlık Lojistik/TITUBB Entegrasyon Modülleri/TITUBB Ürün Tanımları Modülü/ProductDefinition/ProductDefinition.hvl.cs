
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProductDefinition")] 

    /// <summary>
    /// TITUBB Ürün Tanımı
    /// </summary>
    public  partial class ProductDefinition : TerminologyManagerDef
    {
        public class ProductDefinitionList : TTObjectCollection<ProductDefinition> { }
                    
        public class ChildProductDefinitionCollection : TTObject.TTChildObjectCollection<ProductDefinition>
        {
            public ChildProductDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProductDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProductDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Firmname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIRMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProductDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProductDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProductDefinitionList_Class() : base() { }
        }

        public static BindingList<ProductDefinition.GetProductDefinitionList_Class> GetProductDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].QueryDefs["GetProductDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductDefinition.GetProductDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProductDefinition.GetProductDefinitionList_Class> GetProductDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRODUCTDEFINITION"].QueryDefs["GetProductDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProductDefinition.GetProductDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Küresel Ürün Numarası
    /// </summary>
        public string ProductNumber
        {
            get { return (string)this["PRODUCTNUMBER"]; }
            set { this["PRODUCTNUMBER"] = value; }
        }

    /// <summary>
    /// Etiket Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Küresel Ürün Numarası Türü
    /// </summary>
        public string ProductNumberType
        {
            get { return (string)this["PRODUCTNUMBERTYPE"]; }
            set { this["PRODUCTNUMBERTYPE"] = value; }
        }

    /// <summary>
    /// TITUBID
    /// </summary>
        public string TITUBBProductID
        {
            get { return (string)this["TITUBBPRODUCTID"]; }
            set { this["TITUBBPRODUCTID"] = value; }
        }

    /// <summary>
    /// Onay Tarihi
    /// </summary>
        public DateTime? RegistrationDate
        {
            get { return (DateTime?)this["REGISTRATIONDATE"]; }
            set { this["REGISTRATIONDATE"] = value; }
        }

        public FirmDefinition Firm
        {
            get { return (FirmDefinition)((ITTObject)this).GetParent("FIRM"); }
            set { this["FIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProductSUTMatchsCollection()
        {
            _ProductSUTMatchs = new ProductSUTMatchDefinition.ChildProductSUTMatchDefinitionCollection(this, new Guid("e3d90f59-110c-459b-ac68-7f465f942e08"));
            ((ITTChildObjectCollection)_ProductSUTMatchs).GetChildren();
        }

        protected ProductSUTMatchDefinition.ChildProductSUTMatchDefinitionCollection _ProductSUTMatchs = null;
        public ProductSUTMatchDefinition.ChildProductSUTMatchDefinitionCollection ProductSUTMatchs
        {
            get
            {
                if (_ProductSUTMatchs == null)
                    CreateProductSUTMatchsCollection();
                return _ProductSUTMatchs;
            }
        }

        protected ProductDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProductDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProductDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProductDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProductDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRODUCTDEFINITION", dataRow) { }
        protected ProductDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRODUCTDEFINITION", dataRow, isImported) { }
        public ProductDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProductDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProductDefinition() : base() { }

    }
}