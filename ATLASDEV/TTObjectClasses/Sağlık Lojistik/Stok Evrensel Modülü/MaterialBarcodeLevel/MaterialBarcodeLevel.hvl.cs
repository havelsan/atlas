
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaterialBarcodeLevel")] 

    /// <summary>
    /// Malzemenin barkod seviyesi bilgilerini tutan sınıftır
    /// </summary>
    public  partial class MaterialBarcodeLevel : TerminologyManagerDef
    {
        public class MaterialBarcodeLevelList : TTObjectCollection<MaterialBarcodeLevel> { }
                    
        public class ChildMaterialBarcodeLevelCollection : TTObject.TTChildObjectCollection<MaterialBarcodeLevel>
        {
            public ChildMaterialBarcodeLevelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaterialBarcodeLevelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<MaterialBarcodeLevel> GetMaterialBarcodeLevelBySPTSID(TTObjectContext objectContext, int SPTSID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].QueryDefs["GetMaterialBarcodeLevelBySPTSID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPTSID", SPTSID);

            return ((ITTQuery)objectContext).QueryObjects<MaterialBarcodeLevel>(queryDef, paramList);
        }

        public string LicenceNO
        {
            get { return (string)this["LICENCENO"]; }
            set { this["LICENCENO"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Barcode
        {
            get { return (string)this["BARCODE"]; }
            set { this["BARCODE"] = value; }
        }

        public double? PackageAmount
        {
            get { return (double?)this["PACKAGEAMOUNT"]; }
            set { this["PACKAGEAMOUNT"] = value; }
        }

        public long? SPTSDrugID
        {
            get { return (long?)this["SPTSDRUGID"]; }
            set { this["SPTSDRUGID"] = value; }
        }

        public LicencingOrganizationEnum? LicencingOrganization
        {
            get { return (LicencingOrganizationEnum?)(int?)this["LICENCINGORGANIZATION"]; }
            set { this["LICENCINGORGANIZATION"] = value; }
        }

        public DateTime? LicenceDate
        {
            get { return (DateTime?)this["LICENCEDATE"]; }
            set { this["LICENCEDATE"] = value; }
        }

        public double? CurrentPrice
        {
            get { return (double?)this["CURRENTPRICE"]; }
            set { this["CURRENTPRICE"] = value; }
        }

        public double? Discount
        {
            get { return (double?)this["DISCOUNT"]; }
            set { this["DISCOUNT"] = value; }
        }

        public int? SPTSLicencingOrganizationID
        {
            get { return (int?)this["SPTSLICENCINGORGANIZATIONID"]; }
            set { this["SPTSLICENCINGORGANIZATIONID"] = value; }
        }

        public long? ProductNumber
        {
            get { return (long?)this["PRODUCTNUMBER"]; }
            set { this["PRODUCTNUMBER"] = value; }
        }

        public Producer Producer
        {
            get { return (Producer)((ITTObject)this).GetParent("PRODUCER"); }
            set { this["PRODUCER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public GMDNDefinition GMDNDefinition
        {
            get { return (GMDNDefinition)((ITTObject)this).GetParent("GMDNDEFINITION"); }
            set { this["GMDNDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MaterialBarcodeLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaterialBarcodeLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaterialBarcodeLevel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaterialBarcodeLevel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaterialBarcodeLevel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MATERIALBARCODELEVEL", dataRow) { }
        protected MaterialBarcodeLevel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MATERIALBARCODELEVEL", dataRow, isImported) { }
        public MaterialBarcodeLevel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaterialBarcodeLevel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaterialBarcodeLevel() : base() { }

    }
}