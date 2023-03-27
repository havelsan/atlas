
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugDefinition")] 

    /// <summary>
    /// İlaç Tanımı
    /// </summary>
    public  partial class DrugDefinition : Material
    {
        public class DrugDefinitionList : TTObjectCollection<DrugDefinition> { }
                    
        public class ChildDrugDefinitionCollection : TTObject.TTChildObjectCollection<DrugDefinition>
        {
            public ChildDrugDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugsHavingEquivalentReportQuery_Class : TTReportNqlObject 
        {
            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetDrugsHavingEquivalentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsHavingEquivalentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsHavingEquivalentReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugNonDependBarcodeReportQuery_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugNonDependBarcodeReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugNonDependBarcodeReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugNonDependBarcodeReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPharmacyStoreInheldReportQuery_Class : TTReportNqlObject 
        {
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Inheld
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELD"]);
                }
            }

            public GetPharmacyStoreInheldReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPharmacyStoreInheldReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPharmacyStoreInheldReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugsHavingNoEquivalentReportQuery_Class : TTReportNqlObject 
        {
            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALBARCODELEVEL"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetDrugsHavingNoEquivalentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugsHavingNoEquivalentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugsHavingNoEquivalentReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugListVademecumReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDrugListVademecumReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugListVademecumReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugListVademecumReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefinitions_Class : TTReportNqlObject 
        {
            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public PrescriptionTypeEnum? PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDrugDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefinitions_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllVademecumDrugs_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAllVademecumDrugs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllVademecumDrugs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllVademecumDrugs_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugByVademecumProductID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public object MaterialPicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DividePriceToVolume
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEPRICETOVOLUME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDEPRICETOVOLUME"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AuctionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["AUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RegistrationAuctionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONAUCTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["REGISTRATIONAUCTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SetMedulaInfoByMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SETMEDULAINFOBYMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SETMEDULAINFOBYMULTIPLIER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ETKMDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKMDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ETKMDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? MedulaMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MEDULAMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsArmyDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISARMYDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISARMYDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CreateInMedulaDontSendState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEINMEDULADONTSENDSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsRestrictedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESTRICTEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISRESTRICTEDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? AccTrxAmountMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXAMOUNTMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ACCTRXAMOUNTMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? AccTrxUnitPriceDivider
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXUNITPRICEDIVIDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ACCTRXUNITPRICEDIVIDER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsExpendableMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEXPENDABLEMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISEXPENDABLEMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LicenceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["LICENCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? CurrentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CURRENTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Discount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DISCOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string LicenceNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["LICENCENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LicencingOrganizationEnum? LicencingOrganization
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCINGORGANIZATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["LICENCINGORGANIZATION"].DataType;
                    return (LicencingOrganizationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string BarcodeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? SPTSDrugID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSDRUGID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSDRUGID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? SPTSLicencingOrganizationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSLICENCINGORGANIZATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSLICENCINGORGANIZATIONID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPricingTypeEnum? MaterialPricingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALPRICINGTYPE"].DataType;
                    return (MaterialPricingTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISOLDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MkysMalzemeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSMALZEMEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MaterialTypeForInvoiceEnum? MaterialTypeForInvoice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTYPEFORINVOICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALTYPEFORINVOICE"].DataType;
                    return (MaterialTypeForInvoiceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SUTMalzemeEKEnum? SUTAppendix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTAPPENDIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SUTAPPENDIX"].DataType;
                    return (SUTMalzemeEKEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? ShowZeroOnDistributionInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWZEROONDISTRIBUTIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SHOWZEROONDISTRIBUTIONINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPackageExclusive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPACKAGEEXCLUSIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISPACKAGEEXCLUSIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string StorageConditions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORAGECONDITIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["STORAGECONDITIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? EstimatedTimeOfCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDTIMEOFCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ESTIMATEDTIMEOFCHECK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTagNoRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTAGNOREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISTAGNOREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public MaterialDescriptionShowTypeEnum? MaterialDescriptionShowType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALDESCRIPTIONSHOWTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALDESCRIPTIONSHOWTYPE"].DataType;
                    return (MaterialDescriptionShowTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? DivideAmountToPatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEAMOUNTTOPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDEAMOUNTTOPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? DivideUnitAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEUNITAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDEUNITAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? DivideTotalAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDETOTALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDETOTALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? PatientMaxDayOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTMAXDAYOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PATIENTMAXDAYOUT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? OperatingShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATINGSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OPERATINGSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TresuryShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRESURYSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["TRESURYSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ShcekShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHCEKSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SHCEKSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string IsmId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISMID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPatientTypeEnum? MaterialPatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALPATIENTTYPE"].DataType;
                    return (MaterialPatientTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? NotShownOnEpicrisisForm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTSHOWNONEPICRISISFORM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NOTSHOWNONEPICRISISFORM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DailyStay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYSTAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DAILYSTAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? SendSMS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDSMS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SENDSMS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MaximumEstimatedTimeOfCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMESTIMATEDTIMEOFCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXIMUMESTIMATEDTIMEOFCHECK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? WarningDayDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNINGDAYDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["WARNINGDAYDURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SPTSGroupName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSGROUPNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? RoutineDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROUTINEDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ROUTINEDAY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? SPTSGroupID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSGROUPID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSGROUPID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PrescriptionTypeEnum? PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string EquivalentCRC
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EQUIVALENTCRC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["EQUIVALENTCRC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaxDoseDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXDOSEDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXDOSEDAY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? NoDoseCounting
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NODOSECOUNTING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NODOSECOUNTING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? MaxDose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXDOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXDOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Volume
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOLUME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["VOLUME"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Dose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? OldIsArmyDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDISARMYDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OLDISARMYDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? RoutineDose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROUTINEDOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ROUTINEDOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientSafetyFrom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSAFETYFROM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PATIENTSAFETYFROM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WithOutStockInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WITHOUTSTOCKINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["WITHOUTSTOCKINHELD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InfectionApproval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFECTIONAPPROVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INFECTIONAPPROVAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReimbursementUnder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REIMBURSEMENTUNDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["REIMBURSEMENTUNDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ShowZeroOnDrugOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWZEROONDRUGORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SHOWZEROONDRUGORDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MaxPatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXPATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXPATIENTAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MinPatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINPATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MINPATIENTAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DrugShapeTypeEnum? DrugShapeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGSHAPETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DRUGSHAPETYPE"].DataType;
                    return (DrugShapeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsPsychotropic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPSYCHOTROPIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISPSYCHOTROPIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNarcotic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNARCOTIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISNARCOTIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SgkReturnPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SGKRETURNPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SGKRETURNPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ColorEnum? Color
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COLOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["COLOR"].DataType;
                    return (ColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DrugNutrientInteraction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNUTRIENTINTERACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DRUGNUTRIENTINTERACTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? VademecumProductID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VADEMECUMPRODUCTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["VADEMECUMPRODUCTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Exportation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPORTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["EXPORTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AbroadProduct
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABROADPRODUCT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ABROADPRODUCT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? FactoryPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FACTORYPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["FACTORYPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? StoragePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORAGEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["STORAGEPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DrugReportType? InpatientReportType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTREPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INPATIENTREPORTTYPE"].DataType;
                    return (DrugReportType?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugReportType? OutpatientReportType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTREPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OUTPATIENTREPORTTYPE"].DataType;
                    return (DrugReportType?)(int)dataType.ConvertValue(val);
                }
            }

            public double? OrderRPTDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERRPTDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ORDERRPTDAY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? SEX
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public AntibioticTypeEnum? AntibioticType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANTIBIOTICTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ANTIBIOTICTYPE"].DataType;
                    return (AntibioticTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? InstitutionDiscountRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSTITUTIONDISCOUNTRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INSTITUTIONDISCOUNTRATE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? PharmacistDiscountRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACISTDISCOUNTRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PHARMACISTDISCOUNTRATE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public bool? IsITSDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISITSDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISITSDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DivisibleDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVISIBLEDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVISIBLEDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DoNotLeaveTheBarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONOTLEAVETHEBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DONOTLEAVETHEBARCODE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotAppearInEpicrisis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTAPPEARINEPICRISIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NOTAPPEARINEPICRISIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PaidPayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAIDPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PAIDPAYMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object SpecificationFile
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONFILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPECIFICATIONFILE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string SpecificationFileName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONFILENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPECIFICATIONFILENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SpecificationUploadDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONUPLOADDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPECIFICATIONUPLOADDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? InpatientMaxDoseOne
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTMAXDOSEONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INPATIENTMAXDOSEONE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? InpatientMaxDoseTwo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTMAXDOSETWO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INPATIENTMAXDOSETWO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? OutpatientMaxDoseOne
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTMAXDOSEONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OUTPATIENTMAXDOSEONE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? OutpatientMaxDoseTwo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTMAXDOSETWO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OUTPATIENTMAXDOSETWO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDrugByVademecumProductID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugByVademecumProductID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugByVademecumProductID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefinitionByEquivalentReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugDefinitionByEquivalentReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefinitionByEquivalentReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefinitionByEquivalentReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefByEtkinMaddeKodu_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public object MaterialPicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DividePriceToVolume
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEPRICETOVOLUME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDEPRICETOVOLUME"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AuctionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["AUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RegistrationAuctionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONAUCTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["REGISTRATIONAUCTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? SetMedulaInfoByMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SETMEDULAINFOBYMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SETMEDULAINFOBYMULTIPLIER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ETKMDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKMDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ETKMDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? MedulaMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MEDULAMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsArmyDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISARMYDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISARMYDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? CreateInMedulaDontSendState
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATEINMEDULADONTSENDSTATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsRestrictedMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISRESTRICTEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISRESTRICTEDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? AccTrxAmountMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXAMOUNTMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ACCTRXAMOUNTMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? AccTrxUnitPriceDivider
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXUNITPRICEDIVIDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ACCTRXUNITPRICEDIVIDER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IsExpendableMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEXPENDABLEMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISEXPENDABLEMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LicenceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["LICENCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? CurrentPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CURRENTPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Discount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DISCOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string LicenceNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["LICENCENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public LicencingOrganizationEnum? LicencingOrganization
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LICENCINGORGANIZATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["LICENCINGORGANIZATION"].DataType;
                    return (LicencingOrganizationEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string BarcodeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? PackageAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? ProductNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? SPTSDrugID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSDRUGID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSDRUGID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? SPTSLicencingOrganizationID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSLICENCINGORGANIZATIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSLICENCINGORGANIZATIONID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPricingTypeEnum? MaterialPricingType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALPRICINGTYPE"].DataType;
                    return (MaterialPricingTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISOLDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MkysMalzemeKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSMALZEMEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MaterialTypeForInvoiceEnum? MaterialTypeForInvoice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTYPEFORINVOICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALTYPEFORINVOICE"].DataType;
                    return (MaterialTypeForInvoiceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SUTMalzemeEKEnum? SUTAppendix
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTAPPENDIX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SUTAPPENDIX"].DataType;
                    return (SUTMalzemeEKEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? ShowZeroOnDistributionInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWZEROONDISTRIBUTIONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SHOWZEROONDISTRIBUTIONINFO"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPackageExclusive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPACKAGEEXCLUSIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISPACKAGEEXCLUSIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string StorageConditions
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORAGECONDITIONS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["STORAGECONDITIONS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? EstimatedTimeOfCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDTIMEOFCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ESTIMATEDTIMEOFCHECK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsTagNoRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISTAGNOREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISTAGNOREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public MaterialDescriptionShowTypeEnum? MaterialDescriptionShowType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALDESCRIPTIONSHOWTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALDESCRIPTIONSHOWTYPE"].DataType;
                    return (MaterialDescriptionShowTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? DivideAmountToPatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEAMOUNTTOPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDEAMOUNTTOPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? DivideUnitAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDEUNITAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDEUNITAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? DivideTotalAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVIDETOTALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVIDETOTALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? PatientMaxDayOut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTMAXDAYOUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PATIENTMAXDAYOUT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? OperatingShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPERATINGSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OPERATINGSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? TresuryShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRESURYSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["TRESURYSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? ShcekShare
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHCEKSHARE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SHCEKSHARE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string IsmId
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISMID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterialPatientTypeEnum? MaterialPatientType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPATIENTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALPATIENTTYPE"].DataType;
                    return (MaterialPatientTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? NotShownOnEpicrisisForm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTSHOWNONEPICRISISFORM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NOTSHOWNONEPICRISISFORM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DailyStay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAILYSTAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DAILYSTAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? SendSMS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDSMS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SENDSMS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MaximumEstimatedTimeOfCheck
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXIMUMESTIMATEDTIMEOFCHECK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXIMUMESTIMATEDTIMEOFCHECK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? WarningDayDuration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNINGDAYDURATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["WARNINGDAYDURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string SPTSGroupName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSGROUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSGROUPNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? RoutineDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROUTINEDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ROUTINEDAY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? SPTSGroupID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPTSGROUPID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPTSGROUPID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PrescriptionTypeEnum? PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string EquivalentCRC
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EQUIVALENTCRC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["EQUIVALENTCRC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaxDoseDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXDOSEDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXDOSEDAY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? NoDoseCounting
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NODOSECOUNTING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NODOSECOUNTING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? MaxDose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXDOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXDOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Volume
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOLUME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["VOLUME"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Dose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? OldIsArmyDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDISARMYDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OLDISARMYDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? RoutineDose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROUTINEDOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ROUTINEDOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientSafetyFrom
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSAFETYFROM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PATIENTSAFETYFROM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? WithOutStockInheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WITHOUTSTOCKINHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["WITHOUTSTOCKINHELD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InfectionApproval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFECTIONAPPROVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INFECTIONAPPROVAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ReimbursementUnder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REIMBURSEMENTUNDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["REIMBURSEMENTUNDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? ShowZeroOnDrugOrder
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWZEROONDRUGORDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SHOWZEROONDRUGORDER"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? MaxPatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXPATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MAXPATIENTAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MinPatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINPATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MINPATIENTAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DrugShapeTypeEnum? DrugShapeType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGSHAPETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DRUGSHAPETYPE"].DataType;
                    return (DrugShapeTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsPsychotropic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPSYCHOTROPIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISPSYCHOTROPIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNarcotic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNARCOTIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISNARCOTIC"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SgkReturnPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SGKRETURNPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SGKRETURNPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public ColorEnum? Color
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COLOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["COLOR"].DataType;
                    return (ColorEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DrugNutrientInteraction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNUTRIENTINTERACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DRUGNUTRIENTINTERACTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? VademecumProductID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VADEMECUMPRODUCTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["VADEMECUMPRODUCTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Exportation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPORTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["EXPORTATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AbroadProduct
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABROADPRODUCT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ABROADPRODUCT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? FactoryPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FACTORYPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["FACTORYPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? StoragePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORAGEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["STORAGEPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DrugReportType? InpatientReportType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTREPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INPATIENTREPORTTYPE"].DataType;
                    return (DrugReportType?)(int)dataType.ConvertValue(val);
                }
            }

            public DrugReportType? OutpatientReportType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTREPORTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OUTPATIENTREPORTTYPE"].DataType;
                    return (DrugReportType?)(int)dataType.ConvertValue(val);
                }
            }

            public double? OrderRPTDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERRPTDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ORDERRPTDAY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? SEX
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public AntibioticTypeEnum? AntibioticType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANTIBIOTICTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ANTIBIOTICTYPE"].DataType;
                    return (AntibioticTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? InstitutionDiscountRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSTITUTIONDISCOUNTRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INSTITUTIONDISCOUNTRATE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? PharmacistDiscountRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHARMACISTDISCOUNTRATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PHARMACISTDISCOUNTRATE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public bool? IsITSDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISITSDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISITSDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DivisibleDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIVISIBLEDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DIVISIBLEDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? DoNotLeaveTheBarcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONOTLEAVETHEBARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DONOTLEAVETHEBARCODE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NotAppearInEpicrisis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTAPPEARINEPICRISIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NOTAPPEARINEPICRISIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PaidPayment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAIDPAYMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["PAIDPAYMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public object SpecificationFile
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONFILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPECIFICATIONFILE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string SpecificationFileName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONFILENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPECIFICATIONFILENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SpecificationUploadDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONUPLOADDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["SPECIFICATIONUPLOADDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? InpatientMaxDoseOne
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTMAXDOSEONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INPATIENTMAXDOSEONE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? InpatientMaxDoseTwo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INPATIENTMAXDOSETWO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INPATIENTMAXDOSETWO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? OutpatientMaxDoseOne
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTMAXDOSEONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OUTPATIENTMAXDOSEONE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? OutpatientMaxDoseTwo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OUTPATIENTMAXDOSETWO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["OUTPATIENTMAXDOSETWO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDrugDefByEtkinMaddeKodu_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefByEtkinMaddeKodu_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefByEtkinMaddeKodu_Class() : base() { }
        }

        [Serializable] 

        public partial class GetEHUDrugID_Class : TTReportNqlObject 
        {
            public Guid? Materialid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALID"]);
                }
            }

            public bool? InfectionApproval
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFECTIONAPPROVAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["INFECTIONAPPROVAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetEHUDrugID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEHUDrugID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEHUDrugID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefinitionForReport_Class : TTReportNqlObject 
        {
            public Guid? Materialobjeid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJEID"]);
                }
            }

            public GetDrugDefinitionForReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefinitionForReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefinitionForReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetITSDrugList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetITSDrugList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetITSDrugList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetITSDrugList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Inheldamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["INHELDAMOUNT"]);
                }
            }

            public GetDrugDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefinitionList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetVademecumIDByDrugObjectID_Class : TTReportNqlObject 
        {
            public long? VademecumProductID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VADEMECUMPRODUCTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["VADEMECUMPRODUCTID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetVademecumIDByDrugObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetVademecumIDByDrugObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetVademecumIDByDrugObjectID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefinitionGrid_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetDrugDefinitionGrid_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefinitionGrid_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefinitionGrid_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsITSDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISITSDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISITSDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetDrugListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInteractionRQ_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Interactiondrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERACTIONDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InteractionLevelTypeEnum? Drugdruglevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGDRUGLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDRUGINTERACTION"].AllPropertyDefs["INTERACTIONLEVELTYPE"].DataType;
                    return (InteractionLevelTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Drugdrugmessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGDRUGMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDRUGINTERACTION"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Interactionfood
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERACTIONFOOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIETMATERIALDEFINITION"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public InteractionLevelTypeEnum? Drugfoodlevel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGFOODLEVEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGFOODINTERACTION"].AllPropertyDefs["INTERACTIONLEVELTYPE"].DataType;
                    return (InteractionLevelTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Drugfoodmessage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGFOODMESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGFOODINTERACTION"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInteractionRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInteractionRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInteractionRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNewDrugInListQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Chargable
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHARGABLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["CHARGABLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? MaterialCodeSequence
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALCODESEQUENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public string Stockcardname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardengname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDENGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["ENGLISHNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsIndividualTrackingRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISINDIVIDUALTRACKINGREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsITSDrug
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISITSDRUG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["ISITSDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetNewDrugInListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNewDrugInListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNewDrugInListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugDefListByATC_Class : TTReportNqlObject 
        {
            public string Atcname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATCNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ATC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Atcobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ATCOBJECTID"]);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetDrugDefListByATC_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugDefListByATC_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugDefListByATC_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugNotExistStock_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugNotExistStock_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugNotExistStock_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugNotExistStock_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugGenericRQ_Class : TTReportNqlObject 
        {
            public string Genericdrugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERICDRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GENERICDRUG"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Drugname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Genericdrugobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GENERICDRUGOBJECTID"]);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetDrugGenericRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugGenericRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugGenericRQ_Class() : base() { }
        }

        public static BindingList<DrugDefinition.GetDrugsHavingEquivalentReportQuery_Class> GetDrugsHavingEquivalentReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugsHavingEquivalentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugsHavingEquivalentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugsHavingEquivalentReportQuery_Class> GetDrugsHavingEquivalentReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugsHavingEquivalentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugsHavingEquivalentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition> GetDrugDefinitionBySPTSGroupID(TTObjectContext objectContext, long GROUPID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionBySPTSGroupID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GROUPID", GROUPID);

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList);
        }

        public static BindingList<DrugDefinition.GetDrugNonDependBarcodeReportQuery_Class> GetDrugNonDependBarcodeReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugNonDependBarcodeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugNonDependBarcodeReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugNonDependBarcodeReportQuery_Class> GetDrugNonDependBarcodeReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugNonDependBarcodeReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugNonDependBarcodeReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetPharmacyStoreInheldReportQuery_Class> GetPharmacyStoreInheldReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetPharmacyStoreInheldReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetPharmacyStoreInheldReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetPharmacyStoreInheldReportQuery_Class> GetPharmacyStoreInheldReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetPharmacyStoreInheldReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetPharmacyStoreInheldReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition> GetDrugDefinitionByEquivalentCRC(TTObjectContext objectContext, string EQUIVALENTCRC)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionByEquivalentCRC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EQUIVALENTCRC", EQUIVALENTCRC);

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList);
        }

        public static BindingList<DrugDefinition.GetDrugsHavingNoEquivalentReportQuery_Class> GetDrugsHavingNoEquivalentReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugsHavingNoEquivalentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugsHavingNoEquivalentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugsHavingNoEquivalentReportQuery_Class> GetDrugsHavingNoEquivalentReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugsHavingNoEquivalentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugsHavingNoEquivalentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugListVademecumReportQuery_Class> GetDrugListVademecumReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugListVademecumReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugListVademecumReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugListVademecumReportQuery_Class> GetDrugListVademecumReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugListVademecumReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugListVademecumReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitions_Class> GetDrugDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitions_Class> GetDrugDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetAllVademecumDrugs_Class> GetAllVademecumDrugs(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetAllVademecumDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetAllVademecumDrugs_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetAllVademecumDrugs_Class> GetAllVademecumDrugs(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetAllVademecumDrugs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetAllVademecumDrugs_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition> GetDrugDefinitionbyLastupdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionbyLastupdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList);
        }

        public static BindingList<DrugDefinition.GetDrugByVademecumProductID_Class> GetDrugByVademecumProductID(long PRODUCTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugByVademecumProductID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRODUCTID", PRODUCTID);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugByVademecumProductID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugByVademecumProductID_Class> GetDrugByVademecumProductID(TTObjectContext objectContext, long PRODUCTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugByVademecumProductID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRODUCTID", PRODUCTID);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugByVademecumProductID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition> GetDrugDefinitionHasSPTSGroupID(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionHasSPTSGroupID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class> GetDrugDefinitionByEquivalentReportQuery(string EQUIVALENTCRC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionByEquivalentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EQUIVALENTCRC", EQUIVALENTCRC);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class> GetDrugDefinitionByEquivalentReportQuery(TTObjectContext objectContext, string EQUIVALENTCRC, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionByEquivalentReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EQUIVALENTCRC", EQUIVALENTCRC);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition> GetDrugDefinitionHasSPTSDRUGID(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionHasSPTSDRUGID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DrugDefinition> GetDrugDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class> GetDrugDefByEtkinMaddeKodu(string ETKINMADDEKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefByEtkinMaddeKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ETKINMADDEKODU", ETKINMADDEKODU);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class> GetDrugDefByEtkinMaddeKodu(TTObjectContext objectContext, string ETKINMADDEKODU, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefByEtkinMaddeKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ETKINMADDEKODU", ETKINMADDEKODU);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition> GetDrugDefinitionByEtkinMaddeKodu(TTObjectContext objectContext, string ETKINMADDEKODU)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionByEtkinMaddeKodu"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ETKINMADDEKODU", ETKINMADDEKODU);

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList);
        }

        public static BindingList<DrugDefinition> GetDrugDefInheldBiggerThanZero(TTObjectContext objectContext, Guid STOREOBJECTID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefInheldBiggerThanZero"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<DrugDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DrugDefinition.GetEHUDrugID_Class> GetEHUDrugID(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetEHUDrugID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetEHUDrugID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetEHUDrugID_Class> GetEHUDrugID(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetEHUDrugID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetEHUDrugID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionForReport_Class> GetDrugDefinitionForReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionForReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionForReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionForReport_Class> GetDrugDefinitionForReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionForReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionForReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetITSDrugList_Class> GetITSDrugList(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetITSDrugList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetITSDrugList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetITSDrugList_Class> GetITSDrugList(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetITSDrugList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetITSDrugList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionList_Class> GetDrugDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionList_Class> GetDrugDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Vademecum ID çeker
    /// </summary>
        public static BindingList<DrugDefinition.GetVademecumIDByDrugObjectID_Class> GetVademecumIDByDrugObjectID(IList<Guid> DrugObjectIDs, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetVademecumIDByDrugObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGOBJECTIDS", DrugObjectIDs);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetVademecumIDByDrugObjectID_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Vademecum ID çeker
    /// </summary>
        public static BindingList<DrugDefinition.GetVademecumIDByDrugObjectID_Class> GetVademecumIDByDrugObjectID(TTObjectContext objectContext, IList<Guid> DrugObjectIDs, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetVademecumIDByDrugObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGOBJECTIDS", DrugObjectIDs);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetVademecumIDByDrugObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionGrid_Class> GetDrugDefinitionGrid(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionGrid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionGrid_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefinitionGrid_Class> GetDrugDefinitionGrid(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefinitionGrid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefinitionGrid_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugListQuery_Class> GetDrugListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugListQuery_Class> GetDrugListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetInteractionRQ_Class> GetInteractionRQ(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetInteractionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetInteractionRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetInteractionRQ_Class> GetInteractionRQ(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetInteractionRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetInteractionRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetNewDrugInListQuery_Class> GetNewDrugInListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetNewDrugInListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetNewDrugInListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetNewDrugInListQuery_Class> GetNewDrugInListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetNewDrugInListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetNewDrugInListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefListByATC_Class> GetDrugDefListByATC(string STOREOBJECTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefListByATC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefListByATC_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugDefListByATC_Class> GetDrugDefListByATC(TTObjectContext objectContext, string STOREOBJECTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugDefListByATC"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugDefListByATC_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugNotExistStock_Class> GetDrugNotExistStock(Guid STOREID, IList<int> IDS, bool ALLSPEC, bool ALLSHAPE, IList<int> SHAPE, bool ALLINGREDIENT, IList<Guid> INGRENDIENTID, bool ALLDRUG, IList<Guid> DRUGIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugNotExistStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("IDS", IDS);
            paramList.Add("ALLSPEC", ALLSPEC);
            paramList.Add("ALLSHAPE", ALLSHAPE);
            paramList.Add("SHAPE", SHAPE);
            paramList.Add("ALLINGREDIENT", ALLINGREDIENT);
            paramList.Add("INGRENDIENTID", INGRENDIENTID);
            paramList.Add("ALLDRUG", ALLDRUG);
            paramList.Add("DRUGIDS", DRUGIDS);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugNotExistStock_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugNotExistStock_Class> GetDrugNotExistStock(TTObjectContext objectContext, Guid STOREID, IList<int> IDS, bool ALLSPEC, bool ALLSHAPE, IList<int> SHAPE, bool ALLINGREDIENT, IList<Guid> INGRENDIENTID, bool ALLDRUG, IList<Guid> DRUGIDS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugNotExistStock"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);
            paramList.Add("IDS", IDS);
            paramList.Add("ALLSPEC", ALLSPEC);
            paramList.Add("ALLSHAPE", ALLSHAPE);
            paramList.Add("SHAPE", SHAPE);
            paramList.Add("ALLINGREDIENT", ALLINGREDIENT);
            paramList.Add("INGRENDIENTID", INGRENDIENTID);
            paramList.Add("ALLDRUG", ALLDRUG);
            paramList.Add("DRUGIDS", DRUGIDS);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugNotExistStock_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugDefinition.GetDrugGenericRQ_Class> GetDrugGenericRQ(string STOREOBJECTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugGenericRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugGenericRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugDefinition.GetDrugGenericRQ_Class> GetDrugGenericRQ(TTObjectContext objectContext, string STOREOBJECTID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGDEFINITION"].QueryDefs["GetDrugGenericRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREOBJECTID", STOREOBJECTID);

            return TTReportNqlObject.QueryObjects<DrugDefinition.GetDrugGenericRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string SPTSGroupName
        {
            get { return (string)this["SPTSGROUPNAME"]; }
            set { this["SPTSGROUPNAME"] = value; }
        }

    /// <summary>
    /// Rutin Gün
    /// </summary>
        public double? RoutineDay
        {
            get { return (double?)this["ROUTINEDAY"]; }
            set { this["ROUTINEDAY"] = value; }
        }

        public long? SPTSGroupID
        {
            get { return (long?)this["SPTSGROUPID"]; }
            set { this["SPTSGROUPID"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Reçete Türü
    /// </summary>
        public PrescriptionTypeEnum? PrescriptionType
        {
            get { return (PrescriptionTypeEnum?)(int?)this["PRESCRIPTIONTYPE"]; }
            set { this["PRESCRIPTIONTYPE"] = value; }
        }

        public string EquivalentCRC
        {
            get { return (string)this["EQUIVALENTCRC"]; }
            set { this["EQUIVALENTCRC"] = value; }
        }

    /// <summary>
    /// Maksimum Gün
    /// </summary>
        public double? MaxDoseDay
        {
            get { return (double?)this["MAXDOSEDAY"]; }
            set { this["MAXDOSEDAY"] = value; }
        }

    /// <summary>
    /// Hesapsız Doz
    /// </summary>
        public bool? NoDoseCounting
        {
            get { return (bool?)this["NODOSECOUNTING"]; }
            set { this["NODOSECOUNTING"] = value; }
        }

    /// <summary>
    /// Maksimum Doz
    /// </summary>
        public double? MaxDose
        {
            get { return (double?)this["MAXDOSE"]; }
            set { this["MAXDOSE"] = value; }
        }

    /// <summary>
    /// Hacim
    /// </summary>
        public double? Volume
        {
            get { return (double?)this["VOLUME"]; }
            set { this["VOLUME"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public double? Dose
        {
            get { return (double?)this["DOSE"]; }
            set { this["DOSE"] = value; }
        }

        public bool? OldIsArmyDrug
        {
            get { return (bool?)this["OLDISARMYDRUG"]; }
            set { this["OLDISARMYDRUG"] = value; }
        }

    /// <summary>
    /// Rutin Doz
    /// </summary>
        public double? RoutineDose
        {
            get { return (double?)this["ROUTINEDOSE"]; }
            set { this["ROUTINEDOSE"] = value; }
        }

    /// <summary>
    /// Hasta Güvenlik ve İzleme Formu
    /// </summary>
        public bool? PatientSafetyFrom
        {
            get { return (bool?)this["PATIENTSAFETYFROM"]; }
            set { this["PATIENTSAFETYFROM"] = value; }
        }

    /// <summary>
    /// Var / Yok
    /// </summary>
        public bool? WithOutStockInheld
        {
            get { return (bool?)this["WITHOUTSTOCKINHELD"]; }
            set { this["WITHOUTSTOCKINHELD"] = value; }
        }

    /// <summary>
    /// Uzman Onayı
    /// </summary>
        public bool? InfectionApproval
        {
            get { return (bool?)this["INFECTIONAPPROVAL"]; }
            set { this["INFECTIONAPPROVAL"] = value; }
        }

    /// <summary>
    /// Geri Ödeme Kapsamında
    /// </summary>
        public bool? ReimbursementUnder
        {
            get { return (bool?)this["REIMBURSEMENTUNDER"]; }
            set { this["REIMBURSEMENTUNDER"] = value; }
        }

    /// <summary>
    /// İlaç Order ekranında göster
    /// </summary>
        public bool? ShowZeroOnDrugOrder
        {
            get { return (bool?)this["SHOWZEROONDRUGORDER"]; }
            set { this["SHOWZEROONDRUGORDER"] = value; }
        }

    /// <summary>
    /// Uygulanabilir Maximum Hasta Yaşı
    /// </summary>
        public int? MaxPatientAge
        {
            get { return (int?)this["MAXPATIENTAGE"]; }
            set { this["MAXPATIENTAGE"] = value; }
        }

    /// <summary>
    /// Uygulanabilir en küçük yaş
    /// </summary>
        public int? MinPatientAge
        {
            get { return (int?)this["MINPATIENTAGE"]; }
            set { this["MINPATIENTAGE"] = value; }
        }

    /// <summary>
    /// İlaçın Şekli ve Formu hap/ iğne/ sprey /  jel
    /// </summary>
        public DrugShapeTypeEnum? DrugShapeType
        {
            get { return (DrugShapeTypeEnum?)(int?)this["DRUGSHAPETYPE"]; }
            set { this["DRUGSHAPETYPE"] = value; }
        }

    /// <summary>
    /// Psikotrop Madde
    /// </summary>
        public bool? IsPsychotropic
        {
            get { return (bool?)this["ISPSYCHOTROPIC"]; }
            set { this["ISPSYCHOTROPIC"] = value; }
        }

    /// <summary>
    /// Narkotik Madde
    /// </summary>
        public bool? IsNarcotic
        {
            get { return (bool?)this["ISNARCOTIC"]; }
            set { this["ISNARCOTIC"] = value; }
        }

        public bool? SgkReturnPay
        {
            get { return (bool?)this["SGKRETURNPAY"]; }
            set { this["SGKRETURNPAY"] = value; }
        }

    /// <summary>
    /// Order Listesi Background Color
    /// </summary>
        public ColorEnum? Color
        {
            get { return (ColorEnum?)(int?)this["COLOR"]; }
            set { this["COLOR"] = value; }
        }

    /// <summary>
    /// ilaç besin etkileşimi açıklaması
    /// </summary>
        public string DrugNutrientInteraction
        {
            get { return (string)this["DRUGNUTRIENTINTERACTION"]; }
            set { this["DRUGNUTRIENTINTERACTION"] = value; }
        }

        public long? VademecumProductID
        {
            get { return (long?)this["VADEMECUMPRODUCTID"]; }
            set { this["VADEMECUMPRODUCTID"] = value; }
        }

        public bool? Exportation
        {
            get { return (bool?)this["EXPORTATION"]; }
            set { this["EXPORTATION"] = value; }
        }

        public bool? AbroadProduct
        {
            get { return (bool?)this["ABROADPRODUCT"]; }
            set { this["ABROADPRODUCT"] = value; }
        }

    /// <summary>
    /// Fabrika Fiyatı
    /// </summary>
        public Currency? FactoryPrice
        {
            get { return (Currency?)this["FACTORYPRICE"]; }
            set { this["FACTORYPRICE"] = value; }
        }

    /// <summary>
    /// Depo Fiyatı
    /// </summary>
        public Currency? StoragePrice
        {
            get { return (Currency?)this["STORAGEPRICE"]; }
            set { this["STORAGEPRICE"] = value; }
        }

    /// <summary>
    /// Yatan Ödeme Durumu
    /// </summary>
        public DrugReportType? InpatientReportType
        {
            get { return (DrugReportType?)(int?)this["INPATIENTREPORTTYPE"]; }
            set { this["INPATIENTREPORTTYPE"] = value; }
        }

    /// <summary>
    /// Ayaktan Ödeme Durumu
    /// </summary>
        public DrugReportType? OutpatientReportType
        {
            get { return (DrugReportType?)(int?)this["OUTPATIENTREPORTTYPE"]; }
            set { this["OUTPATIENTREPORTTYPE"] = value; }
        }

    /// <summary>
    /// Tekrar Gün
    /// </summary>
        public double? OrderRPTDay
        {
            get { return (double?)this["ORDERRPTDAY"]; }
            set { this["ORDERRPTDAY"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? SEX
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

        public AntibioticTypeEnum? AntibioticType
        {
            get { return (AntibioticTypeEnum?)(int?)this["ANTIBIOTICTYPE"]; }
            set { this["ANTIBIOTICTYPE"] = value; }
        }

    /// <summary>
    /// Kurum İndirim Oranı
    /// </summary>
        public Currency? InstitutionDiscountRate
        {
            get { return (Currency?)this["INSTITUTIONDISCOUNTRATE"]; }
            set { this["INSTITUTIONDISCOUNTRATE"] = value; }
        }

    /// <summary>
    /// Eczacı İndirim Oranı
    /// </summary>
        public Currency? PharmacistDiscountRate
        {
            get { return (Currency?)this["PHARMACISTDISCOUNTRATE"]; }
            set { this["PHARMACISTDISCOUNTRATE"] = value; }
        }

    /// <summary>
    /// ITS Malzemesi
    /// </summary>
        public bool? IsITSDrug
        {
            get { return (bool?)this["ISITSDRUG"]; }
            set { this["ISITSDRUG"] = value; }
        }

        public bool? DivisibleDrug
        {
            get { return (bool?)this["DIVISIBLEDRUG"]; }
            set { this["DIVISIBLEDRUG"] = value; }
        }

        public bool? DoNotLeaveTheBarcode
        {
            get { return (bool?)this["DONOTLEAVETHEBARCODE"]; }
            set { this["DONOTLEAVETHEBARCODE"] = value; }
        }

        public bool? NotAppearInEpicrisis
        {
            get { return (bool?)this["NOTAPPEARINEPICRISIS"]; }
            set { this["NOTAPPEARINEPICRISIS"] = value; }
        }

        public bool? PaidPayment
        {
            get { return (bool?)this["PAIDPAYMENT"]; }
            set { this["PAIDPAYMENT"] = value; }
        }

        public object SpecificationFile
        {
            get { return (object)this["SPECIFICATIONFILE"]; }
            set { this["SPECIFICATIONFILE"] = value; }
        }

        public string SpecificationFileName
        {
            get { return (string)this["SPECIFICATIONFILENAME"]; }
            set { this["SPECIFICATIONFILENAME"] = value; }
        }

        public DateTime? SpecificationUploadDate
        {
            get { return (DateTime?)this["SPECIFICATIONUPLOADDATE"]; }
            set { this["SPECIFICATIONUPLOADDATE"] = value; }
        }

    /// <summary>
    /// Yatan Maksimum Kullanım Doz 1
    /// </summary>
        public double? InpatientMaxDoseOne
        {
            get { return (double?)this["INPATIENTMAXDOSEONE"]; }
            set { this["INPATIENTMAXDOSEONE"] = value; }
        }

    /// <summary>
    /// Yatan Maksimum Kullanım Doz 2
    /// </summary>
        public double? InpatientMaxDoseTwo
        {
            get { return (double?)this["INPATIENTMAXDOSETWO"]; }
            set { this["INPATIENTMAXDOSETWO"] = value; }
        }

    /// <summary>
    /// Ayaktan Maksimum Kullanım Doz 1
    /// </summary>
        public double? OutpatientMaxDoseOne
        {
            get { return (double?)this["OUTPATIENTMAXDOSEONE"]; }
            set { this["OUTPATIENTMAXDOSEONE"] = value; }
        }

    /// <summary>
    /// Ayaktan Maksimum Kullanım Doz 2
    /// </summary>
        public double? OutpatientMaxDoseTwo
        {
            get { return (double?)this["OUTPATIENTMAXDOSETWO"]; }
            set { this["OUTPATIENTMAXDOSETWO"] = value; }
        }

        public GenericDrug GenericDrug
        {
            get { return (GenericDrug)((ITTObject)this).GetParent("GENERICDRUG"); }
            set { this["GENERICDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public UnitDefinition Unit
        {
            get { return (UnitDefinition)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NFC NFC
        {
            get { return (NFC)((ITTObject)this).GetParent("NFC"); }
            set { this["NFC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public RouteOfAdmin RouteOfAdmin
        {
            get { return (RouteOfAdmin)((ITTObject)this).GetParent("ROUTEOFADMIN"); }
            set { this["ROUTEOFADMIN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugType DrugType
        {
            get { return (DrugType)((ITTObject)this).GetParent("DRUGTYPE"); }
            set { this["DRUGTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PharmaceuticalFormDef PharmaceuticalFormDef
        {
            get { return (PharmaceuticalFormDef)((ITTObject)this).GetParent("PHARMACEUTICALFORMDEF"); }
            set { this["PHARMACEUTICALFORMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EtkinMadde EtkinMadde
        {
            get { return (EtkinMadde)((ITTObject)this).GetParent("ETKINMADDE"); }
            set { this["ETKINMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BaseDrug BaseDrug
        {
            get { return (BaseDrug)((ITTObject)this).GetParent("BASEDRUG"); }
            set { this["BASEDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDrugATCsCollection()
        {
            _DrugATCs = new DrugATC.ChildDrugATCCollection(this, new Guid("e77020c6-be29-44ee-aff4-3785836a64c1"));
            ((ITTChildObjectCollection)_DrugATCs).GetChildren();
        }

        protected DrugATC.ChildDrugATCCollection _DrugATCs = null;
        public DrugATC.ChildDrugATCCollection DrugATCs
        {
            get
            {
                if (_DrugATCs == null)
                    CreateDrugATCsCollection();
                return _DrugATCs;
            }
        }

        virtual protected void CreateDrugActiveIngredientsCollection()
        {
            _DrugActiveIngredients = new DrugActiveIngredient.ChildDrugActiveIngredientCollection(this, new Guid("623886b1-6c06-4ff2-bc79-549a232f7ace"));
            ((ITTChildObjectCollection)_DrugActiveIngredients).GetChildren();
        }

        protected DrugActiveIngredient.ChildDrugActiveIngredientCollection _DrugActiveIngredients = null;
        public DrugActiveIngredient.ChildDrugActiveIngredientCollection DrugActiveIngredients
        {
            get
            {
                if (_DrugActiveIngredients == null)
                    CreateDrugActiveIngredientsCollection();
                return _DrugActiveIngredients;
            }
        }

        virtual protected void CreateSymptomsCollection()
        {
            _Symptoms = new DrugSymptomRelationDef.ChildDrugSymptomRelationDefCollection(this, new Guid("b7b7b896-c5be-4dc2-bc72-ffc17a1c1954"));
            ((ITTChildObjectCollection)_Symptoms).GetChildren();
        }

        protected DrugSymptomRelationDef.ChildDrugSymptomRelationDefCollection _Symptoms = null;
        public DrugSymptomRelationDef.ChildDrugSymptomRelationDefCollection Symptoms
        {
            get
            {
                if (_Symptoms == null)
                    CreateSymptomsCollection();
                return _Symptoms;
            }
        }

        virtual protected void CreateDrugSpecificationsCollection()
        {
            _DrugSpecifications = new DrugSpecifications.ChildDrugSpecificationsCollection(this, new Guid("92001458-e035-420d-a8b4-03ff2ffa0ea0"));
            ((ITTChildObjectCollection)_DrugSpecifications).GetChildren();
        }

        protected DrugSpecifications.ChildDrugSpecificationsCollection _DrugSpecifications = null;
        public DrugSpecifications.ChildDrugSpecificationsCollection DrugSpecifications
        {
            get
            {
                if (_DrugSpecifications == null)
                    CreateDrugSpecificationsCollection();
                return _DrugSpecifications;
            }
        }

        virtual protected void CreateDrugRelationsCollection()
        {
            _DrugRelations = new DrugRelation.ChildDrugRelationCollection(this, new Guid("ae1d0f97-3cdd-4da0-b49d-169bab4576c1"));
            ((ITTChildObjectCollection)_DrugRelations).GetChildren();
        }

        protected DrugRelation.ChildDrugRelationCollection _DrugRelations = null;
        public DrugRelation.ChildDrugRelationCollection DrugRelations
        {
            get
            {
                if (_DrugRelations == null)
                    CreateDrugRelationsCollection();
                return _DrugRelations;
            }
        }

        virtual protected void CreateDrugLabProcInteractionsCollection()
        {
            _DrugLabProcInteractions = new DrugLabProcInteraction.ChildDrugLabProcInteractionCollection(this, new Guid("f8a36264-5280-47d0-9c15-a9eb26aea130"));
            ((ITTChildObjectCollection)_DrugLabProcInteractions).GetChildren();
        }

        protected DrugLabProcInteraction.ChildDrugLabProcInteractionCollection _DrugLabProcInteractions = null;
        public DrugLabProcInteraction.ChildDrugLabProcInteractionCollection DrugLabProcInteractions
        {
            get
            {
                if (_DrugLabProcInteractions == null)
                    CreateDrugLabProcInteractionsCollection();
                return _DrugLabProcInteractions;
            }
        }

        virtual protected void CreateManuelEquivalentDrugsCollection()
        {
            _ManuelEquivalentDrugs = new ManuelEquivalentDrug.ChildManuelEquivalentDrugCollection(this, new Guid("d56af4c6-cb4d-43ce-ac1e-f9fc30c0c3e2"));
            ((ITTChildObjectCollection)_ManuelEquivalentDrugs).GetChildren();
        }

        protected ManuelEquivalentDrug.ChildManuelEquivalentDrugCollection _ManuelEquivalentDrugs = null;
        public ManuelEquivalentDrug.ChildManuelEquivalentDrugCollection ManuelEquivalentDrugs
        {
            get
            {
                if (_ManuelEquivalentDrugs == null)
                    CreateManuelEquivalentDrugsCollection();
                return _ManuelEquivalentDrugs;
            }
        }

        virtual protected void CreateDrugOtherFormsCollection()
        {
            _DrugOtherForms = new DrugOtherForm.ChildDrugOtherFormCollection(this, new Guid("52f1ffd6-0c4e-46a6-ba9d-e7651794fe38"));
            ((ITTChildObjectCollection)_DrugOtherForms).GetChildren();
        }

        protected DrugOtherForm.ChildDrugOtherFormCollection _DrugOtherForms = null;
        public DrugOtherForm.ChildDrugOtherFormCollection DrugOtherForms
        {
            get
            {
                if (_DrugOtherForms == null)
                    CreateDrugOtherFormsCollection();
                return _DrugOtherForms;
            }
        }

        virtual protected void CreateDrugDrugInteractionsCollection()
        {
            _DrugDrugInteractions = new DrugDrugInteraction.ChildDrugDrugInteractionCollection(this, new Guid("6de45ba0-31cc-4054-a594-3d3acd8d3197"));
            ((ITTChildObjectCollection)_DrugDrugInteractions).GetChildren();
        }

        protected DrugDrugInteraction.ChildDrugDrugInteractionCollection _DrugDrugInteractions = null;
        public DrugDrugInteraction.ChildDrugDrugInteractionCollection DrugDrugInteractions
        {
            get
            {
                if (_DrugDrugInteractions == null)
                    CreateDrugDrugInteractionsCollection();
                return _DrugDrugInteractions;
            }
        }

        virtual protected void CreateDrugFoodInteractionsCollection()
        {
            _DrugFoodInteractions = new DrugFoodInteraction.ChildDrugFoodInteractionCollection(this, new Guid("a37a654a-245e-4451-b494-179896f9932d"));
            ((ITTChildObjectCollection)_DrugFoodInteractions).GetChildren();
        }

        protected DrugFoodInteraction.ChildDrugFoodInteractionCollection _DrugFoodInteractions = null;
        public DrugFoodInteraction.ChildDrugFoodInteractionCollection DrugFoodInteractions
        {
            get
            {
                if (_DrugFoodInteractions == null)
                    CreateDrugFoodInteractionsCollection();
                return _DrugFoodInteractions;
            }
        }

        protected DrugDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGDEFINITION", dataRow) { }
        protected DrugDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGDEFINITION", dataRow, isImported) { }
        public DrugDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugDefinition() : base() { }

    }
}