
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Contract")] 

    /// <summary>
    /// İhalede Sözleşme Yapılan Her Firma İçin Sözleşme Bilgilerinin Tutulduğu Sınıftır.
    /// </summary>
    public  partial class Contract : TTObject
    {
        public class ContractList : TTObjectCollection<Contract> { }
                    
        public class ChildContractCollection : TTObject.TTChildObjectCollection<Contract>
        {
            public ChildContractCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildContractCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class KararBelgesiNQL_Class : TTReportNqlObject 
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

            public string ContractNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public AssuranceTypeEnum? AssuranceType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSURANCETYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["ASSURANCETYPE"].DataType;
                    return (AssuranceTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string ContractText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTTEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? TotalContractValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALCONTRACTVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["TOTALCONTRACTVALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Currency? KIKWageRate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKWAGERATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["KIKWAGERATE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AssuranceEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSURANCEENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["ASSURANCEENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? ContractStampAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTSTAMPAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTSTAMPAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? JobStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOBSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["JOBSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ContractStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? ContractBondAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTBONDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTBONDAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string PaymentCondition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMENTCONDITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["PAYMENTCONDITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? AssuranceValue
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSURANCEVALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["ASSURANCEVALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ContractEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ContractDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONTRACTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PurchaseInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["PURCHASEINFO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? DecisionStampAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISIONSTAMPAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["DECISIONSTAMPAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? KIKWage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKWAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["KIKWAGE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AssuranceStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSURANCESTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["ASSURANCESTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ConclusionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCLUSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["CONCLUSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? JobEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["JOBENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["JOBENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? DeliveryTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["DELIVERYTIME"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? WarningTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WARNINGTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["WARNINGTIME"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AssuranceEnvelopeNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSURANCEENVELOPENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].AllPropertyDefs["ASSURANCEENVELOPENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectdefid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID1"]);
                }
            }

            public Guid? Currentstatedefid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID1"]);
                }
            }

            public DateTime? Lastupdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE1"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object ReasonOfReject
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFREJECT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["REASONOFREJECT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClonedObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLONEDOBJECTID"]);
                }
            }

            public string WorkListDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PriceFormulationNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEFORMULATIONNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PRICEFORMULATIONNOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProjectCancelDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROJECTCANCELDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PROJECTCANCELDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? NationalNewsAnnounceCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATIONALNEWSANNOUNCECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["NATIONALNEWSANNOUNCECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ProcurementCommisionRegNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCUREMENTCOMMISIONREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PROCUREMENTCOMMISIONREGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? LocalNewspaperAnnounceCount2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALNEWSPAPERANNOUNCECOUNT2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LOCALNEWSPAPERANNOUNCECOUNT2"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ActAttribute
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTATTRIBUTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTATTRIBUTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PriceFormulationCommRegNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEFORMULATIONCOMMREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PRICEFORMULATIONCOMMREGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LBConfirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LBCONFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LBCONFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public object UnitPriceProposalLetterText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICEPROPOSALLETTERTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["UNITPRICEPROPOSALLETTERTEXT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public double? SpecificationPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIFICATIONPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SPECIFICATIONPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public AnnounceTypeandCountEnum? AnnounceTypeandCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNOUNCETYPEANDCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ANNOUNCETYPEANDCOUNT"].DataType;
                    return (AnnounceTypeandCountEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object FinalAnnounceDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINALANNOUNCEDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["FINALANNOUNCEDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string PayMasterName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYMASTERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PAYMASTERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object DecisionDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DECISIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["DECISIONDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public PurchaseMainTypeEnum? PurchaseMainType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEMAINTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PURCHASEMAINTYPE"].DataType;
                    return (PurchaseMainTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ProcurementEnum? ProcurementSource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCUREMENTSOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PROCUREMENTSOURCE"].DataType;
                    return (ProcurementEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string AnnouncementDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNOUNCEMENTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ANNOUNCEMENTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public EvaluationTypeEnum? EvaluationType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EVALUATIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["EVALUATIONTYPE"].DataType;
                    return (EvaluationTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LocalNewspaperName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALNEWSPAPERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LOCALNEWSPAPERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object IhaleyeDavetRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALEYEDAVETRTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["IHALEYEDAVETRTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string BudgetExpensePen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETEXPENSEPEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["BUDGETEXPENSEPEN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ApproveFormDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPROVEFORMDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["APPROVEFORMDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string InvestmentProjectNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVESTMENTPROJECTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["INVESTMENTPROJECTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LocalNewspaperAnnounceDate2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALNEWSPAPERANNOUNCEDATE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LOCALNEWSPAPERANNOUNCEDATE2"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public PurchaseTypeEnum_Material_Procedure? PurchaseTypeMatPro
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASETYPEMATPRO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PURCHASETYPEMATPRO"].DataType;
                    return (PurchaseTypeEnum_Material_Procedure?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? Announcement
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNOUNCEMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ANNOUNCEMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DirectPurchaseCommisionRegNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DIRECTPURCHASECOMMISIONREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["DIRECTPURCHASECOMMISIONREGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string LocalNewspaperName2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALNEWSPAPERNAME2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LOCALNEWSPAPERNAME2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? LocalNewspaperAnnounceCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALNEWSPAPERANNOUNCECOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LOCALNEWSPAPERANNOUNCECOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? UsableBudgetAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USABLEBUDGETAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["USABLEBUDGETAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public object AdministrativeSpecification
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADMINISTRATIVESPECIFICATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ADMINISTRATIVESPECIFICATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public int? KIBAnnouncementCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIBANNOUNCEMENTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIBANNOUNCEMENTCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string LBConfirmNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LBCONFIRMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LBCONFIRMNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ShowApproximatePriceOnReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SHOWAPPROXIMATEPRICEONREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SHOWAPPROXIMATEPRICEONREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string TenderCommisionRegNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERCOMMISIONREGNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERCOMMISIONREGNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ActCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTCOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Advanced
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADVANCED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ADVANCED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? KIBAnnouncementDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIBANNOUNCEMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIBANNOUNCEMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ConclusionApproveDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCLUSIONAPPROVEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONCLUSIONAPPROVEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SufficiencyDecisionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENCYDECISIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SUFFICIENCYDECISIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? PurchaseProjectNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEPROJECTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PURCHASEPROJECTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public object AlimHeyetiGorevlendirmeRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALIMHEYETIGOREVLENDIRMERTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ALIMHEYETIGOREVLENDIRMERTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ProposalInviteFormDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROPOSALINVITEFORMDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PROPOSALINVITEFORMDESC"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? AdvancePurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADVANCEPURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ADVANCEPURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ActDefine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDEFINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTDEFINE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public object ContractInviteFormDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTRACTINVITEFORMDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONTRACTINVITEFORMDESC"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public bool? AttachmentList
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHMENTLIST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ATTACHMENTLIST"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ConfirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SufficiencyDueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENCYDUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SUFFICIENCYDUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PerformerDuty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMERDUTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PERFORMERDUTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? NationalNewspaperAnnounceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATIONALNEWSPAPERANNOUNCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["NATIONALNEWSPAPERANNOUNCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DemandTypeEnum? DemandType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEMANDTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["DEMANDTYPE"].DataType;
                    return (DemandTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public object ProjectCancelDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROJECTCANCELDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PROJECTCANCELDESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string ExpenserDuty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPENSERDUTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["EXPENSERDUTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? PriceDifference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEDIFFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PRICEDIFFERENCE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? FinalAnnounceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINALANNOUNCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["FINALANNOUNCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ConfirmNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONFIRMNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ResponsibleMessageID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEMESSAGEID"]);
                }
            }

            public Guid? LBMessageID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["LBMESSAGEID"]);
                }
            }

            public Guid? OwnerSiteID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OWNERSITEID"]);
                }
            }

            public Guid? ResponsibleSiteID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLESITEID"]);
                }
            }

            public long? ConfirmNO_DS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMNO_DS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONFIRMNO_DS"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? ConfirmNO_GB
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONFIRMNO_GB"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["CONFIRMNO_GB"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string AttachmentListConfirmerDuty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHMENTLISTCONFIRMERDUTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ATTACHMENTLISTCONFIRMERDUTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NationalNewspaperName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATIONALNEWSPAPERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["NATIONALNEWSPAPERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? RegionCommandMessageID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REGIONCOMMANDMESSAGEID"]);
                }
            }

            public object TenderAnnouncementRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERANNOUNCEMENTRTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERANNOUNCEMENTRTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object PreSufficiencyAnnouncementRTF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESUFFICIENCYANNOUNCEMENTRTF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["PRESUFFICIENCYANNOUNCEMENTRTF"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string AttachmentListPreparerDuty
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTACHMENTLISTPREPARERDUTY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ATTACHMENTLISTPREPARERDUTY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LocalNewspaperAnnounceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LOCALNEWSPAPERANNOUNCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["LOCALNEWSPAPERANNOUNCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PurchaseTypeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASETYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].AllPropertyDefs["PURCHASETYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountancymilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public KararBelgesiNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public KararBelgesiNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected KararBelgesiNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Aktif
    /// </summary>
            public static Guid Active { get { return new Guid("8aacd3c0-444c-41b7-a31f-0c7e5ed114c1"); } }
    /// <summary>
    /// Kapat
    /// </summary>
            public static Guid Closed { get { return new Guid("78212bc5-9fb9-4d16-a3b9-9d500034a6b8"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("1025b72f-ed9d-4cd5-a790-6bfe8a321a95"); } }
        }

        public static BindingList<Contract> GetContractByNo(TTObjectContext objectContext, string CONTRACTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].QueryDefs["GetContractByNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONTRACTNO", CONTRACTNO);

            return ((ITTQuery)objectContext).QueryObjects<Contract>(queryDef, paramList);
        }

        public static BindingList<Contract> GetActiveContracts(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].QueryDefs["GetActiveContracts"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Contract>(queryDef, paramList);
        }

        public static BindingList<Contract.KararBelgesiNQL_Class> KararBelgesiNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].QueryDefs["KararBelgesiNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Contract.KararBelgesiNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Contract.KararBelgesiNQL_Class> KararBelgesiNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CONTRACT"].QueryDefs["KararBelgesiNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<Contract.KararBelgesiNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sözleşme No
    /// </summary>
        public string ContractNo
        {
            get { return (string)this["CONTRACTNO"]; }
            set { this["CONTRACTNO"] = value; }
        }

    /// <summary>
    /// Teminat Cinsi
    /// </summary>
        public AssuranceTypeEnum? AssuranceType
        {
            get { return (AssuranceTypeEnum?)(int?)this["ASSURANCETYPE"]; }
            set { this["ASSURANCETYPE"] = value; }
        }

    /// <summary>
    /// Sözleşme Metni
    /// </summary>
        public string ContractText
        {
            get { return (string)this["CONTRACTTEXT"]; }
            set { this["CONTRACTTEXT"] = value; }
        }

    /// <summary>
    /// Toplam Bedel
    /// </summary>
        public double? TotalContractValue
        {
            get { return (double?)this["TOTALCONTRACTVALUE"]; }
            set { this["TOTALCONTRACTVALUE"] = value; }
        }

    /// <summary>
    /// KİK Payı Oranı
    /// </summary>
        public Currency? KIKWageRate
        {
            get { return (Currency?)this["KIKWAGERATE"]; }
            set { this["KIKWAGERATE"] = value; }
        }

    /// <summary>
    /// Teminat Bitiş Tarihi
    /// </summary>
        public DateTime? AssuranceEndDate
        {
            get { return (DateTime?)this["ASSURANCEENDDATE"]; }
            set { this["ASSURANCEENDDATE"] = value; }
        }

    /// <summary>
    /// Sözleşme Pulu Miktarı
    /// </summary>
        public double? ContractStampAmount
        {
            get { return (double?)this["CONTRACTSTAMPAMOUNT"]; }
            set { this["CONTRACTSTAMPAMOUNT"] = value; }
        }

    /// <summary>
    /// İş Başlangıç Tarihi
    /// </summary>
        public DateTime? JobStartDate
        {
            get { return (DateTime?)this["JOBSTARTDATE"]; }
            set { this["JOBSTARTDATE"] = value; }
        }

    /// <summary>
    /// Sözleşme Başlangıç Tarihi
    /// </summary>
        public DateTime? ContractStartDate
        {
            get { return (DateTime?)this["CONTRACTSTARTDATE"]; }
            set { this["CONTRACTSTARTDATE"] = value; }
        }

    /// <summary>
    /// Kati Teminat Miktarı
    /// </summary>
        public double? ContractBondAmount
        {
            get { return (double?)this["CONTRACTBONDAMOUNT"]; }
            set { this["CONTRACTBONDAMOUNT"] = value; }
        }

    /// <summary>
    /// Ödeme Koşulları
    /// </summary>
        public string PaymentCondition
        {
            get { return (string)this["PAYMENTCONDITION"]; }
            set { this["PAYMENTCONDITION"] = value; }
        }

    /// <summary>
    /// Teminat Miktarı
    /// </summary>
        public double? AssuranceValue
        {
            get { return (double?)this["ASSURANCEVALUE"]; }
            set { this["ASSURANCEVALUE"] = value; }
        }

    /// <summary>
    /// Sözleşme Bitiş Tarihi
    /// </summary>
        public DateTime? ContractEndDate
        {
            get { return (DateTime?)this["CONTRACTENDDATE"]; }
            set { this["CONTRACTENDDATE"] = value; }
        }

    /// <summary>
    /// Sözleşme Tarihi
    /// </summary>
        public DateTime? ContractDate
        {
            get { return (DateTime?)this["CONTRACTDATE"]; }
            set { this["CONTRACTDATE"] = value; }
        }

    /// <summary>
    /// Sözleşme Bilgileri
    /// </summary>
        public string PurchaseInfo
        {
            get { return (string)this["PURCHASEINFO"]; }
            set { this["PURCHASEINFO"] = value; }
        }

    /// <summary>
    /// Karar Pulu Miktarı
    /// </summary>
        public double? DecisionStampAmount
        {
            get { return (double?)this["DECISIONSTAMPAMOUNT"]; }
            set { this["DECISIONSTAMPAMOUNT"] = value; }
        }

    /// <summary>
    /// KİK Payı
    /// </summary>
        public double? KIKWage
        {
            get { return (double?)this["KIKWAGE"]; }
            set { this["KIKWAGE"] = value; }
        }

    /// <summary>
    /// Teminat Başlangıç Tarihi
    /// </summary>
        public DateTime? AssuranceStartDate
        {
            get { return (DateTime?)this["ASSURANCESTARTDATE"]; }
            set { this["ASSURANCESTARTDATE"] = value; }
        }

    /// <summary>
    /// Karar No
    /// </summary>
        public string ConclusionNo
        {
            get { return (string)this["CONCLUSIONNO"]; }
            set { this["CONCLUSIONNO"] = value; }
        }

    /// <summary>
    /// İş Bitiş Tarihi
    /// </summary>
        public DateTime? JobEndDate
        {
            get { return (DateTime?)this["JOBENDDATE"]; }
            set { this["JOBENDDATE"] = value; }
        }

    /// <summary>
    /// Teslimat Süresi
    /// </summary>
        public long? DeliveryTime
        {
            get { return (long?)this["DELIVERYTIME"]; }
            set { this["DELIVERYTIME"] = value; }
        }

    /// <summary>
    /// İhbar Süresi
    /// </summary>
        public long? WarningTime
        {
            get { return (long?)this["WARNINGTIME"]; }
            set { this["WARNINGTIME"] = value; }
        }

    /// <summary>
    /// Teminat Mektubu No
    /// </summary>
        public string AssuranceEnvelopeNo
        {
            get { return (string)this["ASSURANCEENVELOPENO"]; }
            set { this["ASSURANCEENVELOPENO"] = value; }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseOrder tmpSelectedOrder
        {
            get { return (PurchaseOrder)((ITTObject)this).GetParent("TMPSELECTEDORDER"); }
            set { this["TMPSELECTEDORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseOrder TmpPurchaseOrder
        {
            get { return (PurchaseOrder)((ITTObject)this).GetParent("TMPPURCHASEORDER"); }
            set { this["TMPPURCHASEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PaymentAccountancy PaymentAccountancy
        {
            get { return (PaymentAccountancy)((ITTObject)this).GetParent("PAYMENTACCOUNTANCY"); }
            set { this["PAYMENTACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProcedureWorksAcceptNoticesCollection()
        {
            _ProcedureWorksAcceptNotices = new ProcedureWorksAcceptNotice.ChildProcedureWorksAcceptNoticeCollection(this, new Guid("2b859852-7f3a-43d4-b082-0316c9b9721c"));
            ((ITTChildObjectCollection)_ProcedureWorksAcceptNotices).GetChildren();
        }

        protected ProcedureWorksAcceptNotice.ChildProcedureWorksAcceptNoticeCollection _ProcedureWorksAcceptNotices = null;
        public ProcedureWorksAcceptNotice.ChildProcedureWorksAcceptNoticeCollection ProcedureWorksAcceptNotices
        {
            get
            {
                if (_ProcedureWorksAcceptNotices == null)
                    CreateProcedureWorksAcceptNoticesCollection();
                return _ProcedureWorksAcceptNotices;
            }
        }

        virtual protected void CreatePurchaseExaminationsCollection()
        {
            _PurchaseExaminations = new PurchaseExamination.ChildPurchaseExaminationCollection(this, new Guid("7b532b2e-c34d-47db-8a89-40753634e12b"));
            ((ITTChildObjectCollection)_PurchaseExaminations).GetChildren();
        }

        protected PurchaseExamination.ChildPurchaseExaminationCollection _PurchaseExaminations = null;
        public PurchaseExamination.ChildPurchaseExaminationCollection PurchaseExaminations
        {
            get
            {
                if (_PurchaseExaminations == null)
                    CreatePurchaseExaminationsCollection();
                return _PurchaseExaminations;
            }
        }

        virtual protected void CreatePurchaseOrdersCollection()
        {
            _PurchaseOrders = new PurchaseOrder.ChildPurchaseOrderCollection(this, new Guid("64bce513-6f38-4c6a-8b3f-ce771867ae06"));
            ((ITTChildObjectCollection)_PurchaseOrders).GetChildren();
        }

        protected PurchaseOrder.ChildPurchaseOrderCollection _PurchaseOrders = null;
        public PurchaseOrder.ChildPurchaseOrderCollection PurchaseOrders
        {
            get
            {
                if (_PurchaseOrders == null)
                    CreatePurchaseOrdersCollection();
                return _PurchaseOrders;
            }
        }

        virtual protected void CreateContractDetailsCollection()
        {
            _ContractDetails = new ContractDetail.ChildContractDetailCollection(this, new Guid("0c58cf0c-ba80-4f23-9f11-df03643e137c"));
            ((ITTChildObjectCollection)_ContractDetails).GetChildren();
        }

        protected ContractDetail.ChildContractDetailCollection _ContractDetails = null;
        public ContractDetail.ChildContractDetailCollection ContractDetails
        {
            get
            {
                if (_ContractDetails == null)
                    CreateContractDetailsCollection();
                return _ContractDetails;
            }
        }

        protected Contract(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Contract(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Contract(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Contract(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Contract(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CONTRACT", dataRow) { }
        protected Contract(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CONTRACT", dataRow, isImported) { }
        public Contract(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Contract(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Contract() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}