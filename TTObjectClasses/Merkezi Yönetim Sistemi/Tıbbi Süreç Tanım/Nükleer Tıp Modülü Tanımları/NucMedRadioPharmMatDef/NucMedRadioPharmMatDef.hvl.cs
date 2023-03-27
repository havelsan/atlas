
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NucMedRadioPharmMatDef")] 

    public  partial class NucMedRadioPharmMatDef : ConsumableMaterialDefinition
    {
        public class NucMedRadioPharmMatDefList : TTObjectCollection<NucMedRadioPharmMatDef> { }
                    
        public class ChildNucMedRadioPharmMatDefCollection : TTObject.TTChildObjectCollection<NucMedRadioPharmMatDef>
        {
            public ChildNucMedRadioPharmMatDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNucMedRadioPharmMatDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNucMEdPharmMatRNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MATERIALPICTURE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ORIGINALNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["CHARGABLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["DIVIDEPRICETOVOLUME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["AUCTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["REGISTRATIONAUCTIONNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SETMEDULAINFOBYMULTIPLIER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ETKMDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["CREATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MEDULAMULTIPLIER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISARMYDRUG"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["CREATEINMEDULADONTSENDSTATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISRESTRICTEDMATERIAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ACCTRXAMOUNTMULTIPLIER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ACCTRXUNITPRICEDIVIDER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISEXPENDABLEMATERIAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["BARCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["LICENCEDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["CURRENTPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["DISCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["LICENCENO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["LICENCINGORGANIZATION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["BARCODENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["PACKAGEAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["PRODUCTNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SPTSDRUGID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SPTSLICENCINGORGANIZATIONID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MATERIALPRICINGTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["PURCHASEDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISOLDMATERIAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MKYSMALZEMEKODU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MATERIALTYPEFORINVOICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SUTAPPENDIX"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SHOWZEROONDISTRIBUTIONINFO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISINDIVIDUALTRACKINGREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISPACKAGEEXCLUSIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["STORAGECONDITIONS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ESTIMATEDTIMEOFCHECK"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISTAGNOREQUIRED"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MATERIALDESCRIPTIONSHOWTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["DIVIDEAMOUNTTOPATIENT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["DIVIDEUNITAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["DIVIDETOTALAMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["PATIENTMAXDAYOUT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["OPERATINGSHARE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["TRESURYSHARE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SHCEKSHARE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISMID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MATERIALPATIENTTYPE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["NOTSHOWNONEPICRISISFORM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["DAILYSTAY"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MATERIALCODESEQUENCE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SENDSMS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MAXIMUMESTIMATEDTIMEOFCHECK"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["WARNINGDAYDURATION"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAllogreft
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISALLOGREFT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ISALLOGREFT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? SEX
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SEX"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MaxPatientAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXPATIENTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MAXPATIENTAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["MINPATIENTAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? OrderRPTDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERRPTDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["ORDERRPTDAY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public object SpecificationFile
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONFILE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SPECIFICATIONFILE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SPECIFICATIONFILENAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["SPECIFICATIONUPLOADDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? NotAppearInEpicrisis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTAPPEARINEPICRISIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["NOTAPPEARINEPICRISIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasEstimatedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASESTIMATEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].AllPropertyDefs["HASESTIMATEDTIME"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetNucMEdPharmMatRNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNucMEdPharmMatRNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNucMEdPharmMatRNQL_Class() : base() { }
        }

        public static BindingList<NucMedRadioPharmMatDef.GetNucMEdPharmMatRNQL_Class> GetNucMEdPharmMatRNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].QueryDefs["GetNucMEdPharmMatRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NucMedRadioPharmMatDef.GetNucMEdPharmMatRNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<NucMedRadioPharmMatDef.GetNucMEdPharmMatRNQL_Class> GetNucMEdPharmMatRNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NUCMEDRADIOPHARMMATDEF"].QueryDefs["GetNucMEdPharmMatRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<NucMedRadioPharmMatDef.GetNucMEdPharmMatRNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected NucMedRadioPharmMatDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NucMedRadioPharmMatDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NucMedRadioPharmMatDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NucMedRadioPharmMatDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NucMedRadioPharmMatDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NUCMEDRADIOPHARMMATDEF", dataRow) { }
        protected NucMedRadioPharmMatDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NUCMEDRADIOPHARMMATDEF", dataRow, isImported) { }
        public NucMedRadioPharmMatDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NucMedRadioPharmMatDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NucMedRadioPharmMatDef() : base() { }

    }
}