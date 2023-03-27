
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetInDetail")] 

    public  partial class FixedAssetInDetail : FixedAssetDetail
    {
        public class FixedAssetInDetailList : TTObjectCollection<FixedAssetInDetail> { }
                    
        public class ChildFixedAssetInDetailCollection : TTObject.TTChildObjectCollection<FixedAssetInDetail>
        {
            public ChildFixedAssetInDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetInDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Demirbaş Nu.
    /// </summary>
        public string FixedAssetNO
        {
            get { return (string)this["FIXEDASSETNO"]; }
            set { this["FIXEDASSETNO"] = value; }
        }

    /// <summary>
    /// Model
    /// </summary>
        public string Model
        {
            get { return (string)this["MODEL"]; }
            set { this["MODEL"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public FixedAssetStatusEnum? Status
        {
            get { return (FixedAssetStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Seri No
    /// </summary>
        public string SerialNumber
        {
            get { return (string)this["SERIALNUMBER"]; }
            set { this["SERIALNUMBER"] = value; }
        }

    /// <summary>
    /// Marka
    /// </summary>
        public string Mark
        {
            get { return (string)this["MARK"]; }
            set { this["MARK"] = value; }
        }

    /// <summary>
    /// Garanti Bitiş Tarihi
    /// </summary>
        public DateTime? GuarantyEndDate
        {
            get { return (DateTime?)this["GUARANTYENDDATE"]; }
            set { this["GUARANTYENDDATE"] = value; }
        }

    /// <summary>
    /// Garanti Başlama Tarihi
    /// </summary>
        public DateTime? GuarantyStartDate
        {
            get { return (DateTime?)this["GUARANTYSTARTDATE"]; }
            set { this["GUARANTYSTARTDATE"] = value; }
        }

    /// <summary>
    /// Diğer Gövde Yapısı
    /// </summary>
        public bool? OtherBody
        {
            get { return (bool?)this["OTHERBODY"]; }
            set { this["OTHERBODY"] = value; }
        }

    /// <summary>
    /// Diğer Uç Yapısı
    /// </summary>
        public bool? OtherEdge
        {
            get { return (bool?)this["OTHEREDGE"]; }
            set { this["OTHEREDGE"] = value; }
        }

    /// <summary>
    /// Diğer Uzunluk
    /// </summary>
        public bool? OtherLenght
        {
            get { return (bool?)this["OTHERLENGHT"]; }
            set { this["OTHERLENGHT"] = value; }
        }

    /// <summary>
    /// Diğer Ana Malzeme Adı
    /// </summary>
        public bool? OtherMainClass
        {
            get { return (bool?)this["OTHERMAINCLASS"]; }
            set { this["OTHERMAINCLASS"] = value; }
        }

    /// <summary>
    /// Diğer Marka
    /// </summary>
        public bool? OtherMark
        {
            get { return (bool?)this["OTHERMARK"]; }
            set { this["OTHERMARK"] = value; }
        }

    /// <summary>
    /// Diğer Model
    /// </summary>
        public bool? OtherModel
        {
            get { return (bool?)this["OTHERMODEL"]; }
            set { this["OTHERMODEL"] = value; }
        }

    /// <summary>
    /// İmal Tarihi
    /// </summary>
        public DateTime? ProductionDate
        {
            get { return (DateTime?)this["PRODUCTIONDATE"]; }
            set { this["PRODUCTIONDATE"] = value; }
        }

    /// <summary>
    /// Voltaj
    /// </summary>
        public string Voltage
        {
            get { return (string)this["VOLTAGE"]; }
            set { this["VOLTAGE"] = value; }
        }

    /// <summary>
    /// Frekans
    /// </summary>
        public string Frequency
        {
            get { return (string)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Güç
    /// </summary>
        public string Power
        {
            get { return (string)this["POWER"]; }
            set { this["POWER"] = value; }
        }

    /// <summary>
    /// XXXXXX Sahasından transfer edilmiş
    /// </summary>
        public bool? TransferredFromXXXXXXSite
        {
            get { return (bool?)this["TRANSFERREDFROMXXXXXXSITE"]; }
            set { this["TRANSFERREDFROMXXXXXXSITE"] = value; }
        }

    /// <summary>
    /// Bulunduğu Kaynak
    /// </summary>
        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinition TransferedFixedAssetMaterial
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("TRANSFEREDFIXEDASSETMATERIAL"); }
            set { this["TRANSFEREDFIXEDASSETMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinitionDetail FixedAssetMaterialDefDetail
        {
            get { return (FixedAssetMaterialDefinitionDetail)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFDETAIL"); }
            set { this["FIXEDASSETMATERIALDEFDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetInDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetInDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetInDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETINDETAIL", dataRow) { }
        protected FixedAssetInDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETINDETAIL", dataRow, isImported) { }
        public FixedAssetInDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetInDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetInDetail() : base() { }

    }
}