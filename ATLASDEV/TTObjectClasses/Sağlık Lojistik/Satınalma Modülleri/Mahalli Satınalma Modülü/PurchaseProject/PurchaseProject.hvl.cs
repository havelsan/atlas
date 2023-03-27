
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseProject")] 

    /// <summary>
    /// Mahalli Satınalma Ana Sınıfı
    /// </summary>
    public  partial class PurchaseProject : BasePurchaseAction, IPurchaseProjectWorkList
    {
        public class PurchaseProjectList : TTObjectCollection<PurchaseProject> { }
                    
        public class ChildPurchaseProjectCollection : TTObject.TTChildObjectCollection<PurchaseProject>
        {
            public ChildPurchaseProjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseProjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PurchaseProjectGlobalReportNQL_Class : TTReportNqlObject 
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

            public string Purchasetypedefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASETYPEDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].AllPropertyDefs["PURCHASETYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Responsibleprocurementobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEPROCUREMENTOBJECTID"]);
                }
            }

            public string Responsibleprocurementunitdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEPROCUREMENTUNITDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Expenserid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXPENSERID"]);
                }
            }

            public string Expenser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPENSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Expenserrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPENSERRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Performerid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PERFORMERID"]);
                }
            }

            public string Performer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Performerrank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMERRANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Attlistpreparername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTLISTPREPARERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Attlistconfirmername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTLISTCONFIRMERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Attlistconfirmertitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTLISTCONFIRMERTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Attlistpreparertitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ATTLISTPREPARERTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PurchaseProjectGlobalReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PurchaseProjectGlobalReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PurchaseProjectGlobalReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class PurchaseProjectReportNQL_Class : TTReportNqlObject 
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

            public PurchaseProjectReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PurchaseProjectReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PurchaseProjectReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPriceFormulationCommissionMembersQuery_Class : TTReportNqlObject 
        {
            public CommisionMemberDutyEnum? Comfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICEFORMULATIONCOMMISIONMEMBER"].AllPropertyDefs["MEMBERDUTY"].DataType;
                    return (CommisionMemberDutyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Namesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Hospfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPriceFormulationCommissionMembersQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPriceFormulationCommissionMembersQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPriceFormulationCommissionMembersQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFirmProductListReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["REQUESTEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? ProposalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROPOSALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].AllPropertyDefs["PROPOSALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetFirmProductListReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFirmProductListReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFirmProductListReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDirectPurchaseCommisionMembersQuery_Class : TTReportNqlObject 
        {
            public CommisionMemberDutyEnum? Comfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASECOMMISION"].AllPropertyDefs["MEMBERDUTY"].DataType;
                    return (CommisionMemberDutyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Namesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Hospfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDirectPurchaseCommisionMembersQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDirectPurchaseCommisionMembersQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDirectPurchaseCommisionMembersQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSupplyConditionRegistryReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? ProposalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROPOSALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].AllPropertyDefs["PROPOSALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public GetSupplyConditionRegistryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSupplyConditionRegistryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSupplyConditionRegistryReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTenderCommisionDesicionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Responsibleprocurementunitdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEPROCUREMENTUNITDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string ConclusionNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCLUSIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["CONCLUSIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetTenderCommisionDesicionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTenderCommisionDesicionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTenderCommisionDesicionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class SatinAlmaIstekIzlemeQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public Currency? RequestedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["REQUESTEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Demanddetailid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEMANDDETAILID"]);
                }
            }

            public long? RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEMAND"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public SatinAlmaIstekIzlemeQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SatinAlmaIstekIzlemeQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SatinAlmaIstekIzlemeQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetTenderCommisionMembersQuery_Class : TTReportNqlObject 
        {
            public CommisionMemberDutyEnum? Comfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENDERCOMMISION"].AllPropertyDefs["MEMBERDUTY"].DataType;
                    return (CommisionMemberDutyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Rank
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RANK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RANKDEFINITIONS"].AllPropertyDefs["SHORTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Namesurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAMESURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Hospfunc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HOSPFUNC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetTenderCommisionMembersQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTenderCommisionMembersQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTenderCommisionMembersQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSupplyAnalysisReportQuery_Class : TTReportNqlObject 
        {
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

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? ProposalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROPOSALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROPOSALDETAIL"].AllPropertyDefs["PROPOSALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public GetSupplyAnalysisReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSupplyAnalysisReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSupplyAnalysisReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFirmsWhichWinPurchaseReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFirmsWhichWinPurchaseReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFirmsWhichWinPurchaseReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFirmsWhichWinPurchaseReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetYearlyPurchaseDecisionReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? RequestedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["REQUESTEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetYearlyPurchaseDecisionReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetYearlyPurchaseDecisionReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetYearlyPurchaseDecisionReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPurchaseProcurementReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Accountancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECTDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetPurchaseProcurementReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPurchaseProcurementReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPurchaseProcurementReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Tedarik Süreci İptal Edildi
    /// </summary>
            public static Guid CancelDescription { get { return new Guid("a83f8d81-8bb9-4373-9c39-3a132346f261"); } }
    /// <summary>
    /// Firmayla sözleşme aşamasında
    /// </summary>
            public static Guid ContractEntry { get { return new Guid("ce057040-5d24-47b3-9e9f-0b20cee6d567"); } }
    /// <summary>
    /// İhale sürecinde
    /// </summary>
            public static Guid PriceFormulation { get { return new Guid("b4320d2d-5a27-4959-be0c-1f157ddb427a"); } }
    /// <summary>
    /// Bölge XXXXXXnda
    /// </summary>
            public static Guid RegionCommandLogBureau { get { return new Guid("14a88a50-29f0-41ef-b3cf-37a1a340fc29"); } }
    /// <summary>
    /// Tedarik Süreci İptal Edildi
    /// </summary>
            public static Guid Canceled { get { return new Guid("0f167b94-ef72-485f-9612-28fefa37dac7"); } }
    /// <summary>
    /// İhale sürecinde
    /// </summary>
            public static Guid ProjectCreating { get { return new Guid("47907798-7f38-42cc-a687-7383207bb639"); } }
    /// <summary>
    /// Lojistik şubede
    /// </summary>
            public static Guid ProjectDetailing { get { return new Guid("90f3b1ba-4b23-47d9-94c6-6632146c93d9"); } }
    /// <summary>
    /// İhale sürecinde
    /// </summary>
            public static Guid HeadDoctorApproval1 { get { return new Guid("74f6ebb8-b205-4b3d-b270-8c1c811487d2"); } }
    /// <summary>
    /// Tedarik Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("c938cbc6-0e75-40b6-88b0-99cce8d0e9eb"); } }
    /// <summary>
    /// Bölge XXXXXXnda
    /// </summary>
            public static Guid RegionCommandCommanderApproval { get { return new Guid("5eff8d9a-8bdf-4a87-888e-e7f728814824"); } }
    /// <summary>
    /// Lojistik daire onayında
    /// </summary>
            public static Guid LogisticBureauApproval { get { return new Guid("2d547ad1-cfea-480e-9a94-e9524a82becd"); } }
    /// <summary>
    /// Tedarik süreci başlamak üzere
    /// </summary>
            public static Guid ProjectRegistration { get { return new Guid("543bcdc0-7c01-42e0-98e3-81979d227408"); } }
    /// <summary>
    /// Avans yolu ile alınacak
    /// </summary>
            public static Guid AdvanceInfo { get { return new Guid("e9eff8a1-9b86-4d8b-913c-97b45ad77710"); } }
    /// <summary>
    /// Lojistik Şubede
    /// </summary>
            public static Guid HospitalLogBureauApproval { get { return new Guid("d6422f47-87c4-42e7-854e-ff74f3f0de61"); } }
    /// <summary>
    /// İhale Komisyonu
    /// </summary>
            public static Guid TenderCommision { get { return new Guid("cc6b0917-b853-4b51-b323-2d7497ab16e4"); } }
        }

        public static BindingList<PurchaseProject> WorkListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["WorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseProject>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<PurchaseProject.PurchaseProjectGlobalReportNQL_Class> PurchaseProjectGlobalReportNQL(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["PurchaseProjectGlobalReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.PurchaseProjectGlobalReportNQL_Class> PurchaseProjectGlobalReportNQL(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["PurchaseProjectGlobalReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.PurchaseProjectGlobalReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.PurchaseProjectReportNQL_Class> PurchaseProjectReportNQL(long PROJECTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["PurchaseProjectReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);

            return TTReportNqlObject.QueryObjects<PurchaseProject.PurchaseProjectReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.PurchaseProjectReportNQL_Class> PurchaseProjectReportNQL(TTObjectContext objectContext, long PROJECTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["PurchaseProjectReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);

            return TTReportNqlObject.QueryObjects<PurchaseProject.PurchaseProjectReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetPriceFormulationCommissionMembersQuery_Class> GetPriceFormulationCommissionMembersQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetPriceFormulationCommissionMembersQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetPriceFormulationCommissionMembersQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetPriceFormulationCommissionMembersQuery_Class> GetPriceFormulationCommissionMembersQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetPriceFormulationCommissionMembersQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetPriceFormulationCommissionMembersQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject> GetPurchaseProjectByConfirmNo(TTObjectContext objectContext, string CONFIRMNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetPurchaseProjectByConfirmNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CONFIRMNO", CONFIRMNO);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseProject>(queryDef, paramList);
        }

        public static BindingList<PurchaseProject.GetFirmProductListReportQuery_Class> GetFirmProductListReportQuery(Guid PROJECTNO, Guid SUPPLIERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetFirmProductListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetFirmProductListReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetFirmProductListReportQuery_Class> GetFirmProductListReportQuery(TTObjectContext objectContext, Guid PROJECTNO, Guid SUPPLIERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetFirmProductListReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetFirmProductListReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetDirectPurchaseCommisionMembersQuery_Class> GetDirectPurchaseCommisionMembersQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetDirectPurchaseCommisionMembersQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetDirectPurchaseCommisionMembersQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetDirectPurchaseCommisionMembersQuery_Class> GetDirectPurchaseCommisionMembersQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetDirectPurchaseCommisionMembersQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetDirectPurchaseCommisionMembersQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject> GetPurchaseProjectByProjectNo(TTObjectContext objectContext, int PURCHASEPROJECTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetPurchaseProjectByProjectNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEPROJECTNO", PURCHASEPROJECTNO);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseProject>(queryDef, paramList);
        }

        public static BindingList<PurchaseProject.GetSupplyConditionRegistryReportQuery_Class> GetSupplyConditionRegistryReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERID, Guid MATERIALID, Guid SUPPLIERID, Guid PROJECTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetSupplyConditionRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("PROJECTNO", PROJECTNO);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetSupplyConditionRegistryReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetSupplyConditionRegistryReportQuery_Class> GetSupplyConditionRegistryReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERID, Guid MATERIALID, Guid SUPPLIERID, Guid PROJECTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetSupplyConditionRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("PROJECTNO", PROJECTNO);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetSupplyConditionRegistryReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject> GetAllProjects(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetAllProjects"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PurchaseProject>(queryDef, paramList);
        }

        public static BindingList<PurchaseProject.GetTenderCommisionDesicionQuery_Class> GetTenderCommisionDesicionQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetTenderCommisionDesicionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetTenderCommisionDesicionQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetTenderCommisionDesicionQuery_Class> GetTenderCommisionDesicionQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetTenderCommisionDesicionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetTenderCommisionDesicionQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class> SatinAlmaIstekIzlemeQuery(Guid ACCOUNTANCYID, Guid PURCHASEPROJECTNO, string CONFIRMNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["SatinAlmaIstekIzlemeQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTANCYID", ACCOUNTANCYID);
            paramList.Add("PURCHASEPROJECTNO", PURCHASEPROJECTNO);
            paramList.Add("CONFIRMNO", CONFIRMNO);

            return TTReportNqlObject.QueryObjects<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class> SatinAlmaIstekIzlemeQuery(TTObjectContext objectContext, Guid ACCOUNTANCYID, Guid PURCHASEPROJECTNO, string CONFIRMNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["SatinAlmaIstekIzlemeQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTANCYID", ACCOUNTANCYID);
            paramList.Add("PURCHASEPROJECTNO", PURCHASEPROJECTNO);
            paramList.Add("CONFIRMNO", CONFIRMNO);

            return TTReportNqlObject.QueryObjects<PurchaseProject.SatinAlmaIstekIzlemeQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetTenderCommisionMembersQuery_Class> GetTenderCommisionMembersQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetTenderCommisionMembersQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetTenderCommisionMembersQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetTenderCommisionMembersQuery_Class> GetTenderCommisionMembersQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetTenderCommisionMembersQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetTenderCommisionMembersQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetSupplyAnalysisReportQuery_Class> GetSupplyAnalysisReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid MASTERID, Guid MATERIALID, Guid SUPPLIERID, PurchaseTypeEnum_Material_Procedure PURCHASETYPE, PurchaseMainTypeEnum PURCHASEMAINTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetSupplyAnalysisReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("PURCHASETYPE", (int)PURCHASETYPE);
            paramList.Add("PURCHASEMAINTYPE", (int)PURCHASEMAINTYPE);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetSupplyAnalysisReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetSupplyAnalysisReportQuery_Class> GetSupplyAnalysisReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid MASTERID, Guid MATERIALID, Guid SUPPLIERID, PurchaseTypeEnum_Material_Procedure PURCHASETYPE, PurchaseMainTypeEnum PURCHASEMAINTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetSupplyAnalysisReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("PURCHASETYPE", (int)PURCHASETYPE);
            paramList.Add("PURCHASEMAINTYPE", (int)PURCHASEMAINTYPE);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetSupplyAnalysisReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetFirmsWhichWinPurchaseReportQuery_Class> GetFirmsWhichWinPurchaseReportQuery(Guid PROJECTNO, Guid SUPPLIERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetFirmsWhichWinPurchaseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetFirmsWhichWinPurchaseReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetFirmsWhichWinPurchaseReportQuery_Class> GetFirmsWhichWinPurchaseReportQuery(TTObjectContext objectContext, Guid PROJECTNO, Guid SUPPLIERID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetFirmsWhichWinPurchaseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetFirmsWhichWinPurchaseReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetYearlyPurchaseDecisionReportQuery_Class> GetYearlyPurchaseDecisionReportQuery(Guid PROJECTNO, Guid MASTERID, Guid MATERIALID, string ACCOUNTYEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetYearlyPurchaseDecisionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("ACCOUNTYEAR", ACCOUNTYEAR);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetYearlyPurchaseDecisionReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetYearlyPurchaseDecisionReportQuery_Class> GetYearlyPurchaseDecisionReportQuery(TTObjectContext objectContext, Guid PROJECTNO, Guid MASTERID, Guid MATERIALID, string ACCOUNTYEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetYearlyPurchaseDecisionReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PROJECTNO", PROJECTNO);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("MATERIALID", MATERIALID);
            paramList.Add("ACCOUNTYEAR", ACCOUNTYEAR);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetYearlyPurchaseDecisionReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject> GetProjectsOnLBState(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetProjectsOnLBState"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PurchaseProject>(queryDef, paramList);
        }

        public static BindingList<PurchaseProject.GetPurchaseProcurementReportQuery_Class> GetPurchaseProcurementReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid ACCOUNTANCYID, Guid MASTERID, Guid SUPPLIERID, ProcurementEnum PROCUREMENTTYPE, PurchaseMainTypeEnum PURCHASEMAINTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetPurchaseProcurementReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("ACCOUNTANCYID", ACCOUNTANCYID);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("PROCUREMENTTYPE", (int)PROCUREMENTTYPE);
            paramList.Add("PURCHASEMAINTYPE", (int)PURCHASEMAINTYPE);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetPurchaseProcurementReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseProject.GetPurchaseProcurementReportQuery_Class> GetPurchaseProcurementReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid ACCOUNTANCYID, Guid MASTERID, Guid SUPPLIERID, ProcurementEnum PROCUREMENTTYPE, PurchaseMainTypeEnum PURCHASEMAINTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].QueryDefs["GetPurchaseProcurementReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("ACCOUNTANCYID", ACCOUNTANCYID);
            paramList.Add("MASTERID", MASTERID);
            paramList.Add("SUPPLIERID", SUPPLIERID);
            paramList.Add("PROCUREMENTTYPE", (int)PROCUREMENTTYPE);
            paramList.Add("PURCHASEMAINTYPE", (int)PURCHASEMAINTYPE);

            return TTReportNqlObject.QueryObjects<PurchaseProject.GetPurchaseProcurementReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Yaklaşık Maliyet Notu
    /// </summary>
        public string PriceFormulationNote
        {
            get { return (string)this["PRICEFORMULATIONNOTE"]; }
            set { this["PRICEFORMULATIONNOTE"] = value; }
        }

    /// <summary>
    /// İhale İptal Tarihi
    /// </summary>
        public DateTime? ProjectCancelDate
        {
            get { return (DateTime?)this["PROJECTCANCELDATE"]; }
            set { this["PROJECTCANCELDATE"] = value; }
        }

    /// <summary>
    /// Ulusal Gazete İlk İlan Sayısı
    /// </summary>
        public int? NationalNewsAnnounceCount
        {
            get { return (int?)this["NATIONALNEWSANNOUNCECOUNT"]; }
            set { this["NATIONALNEWSANNOUNCECOUNT"] = value; }
        }

    /// <summary>
    /// Tedarik Birimi Dosya No
    /// </summary>
        public string ProcurementCommisionRegNo
        {
            get { return (string)this["PROCUREMENTCOMMISIONREGNO"]; }
            set { this["PROCUREMENTCOMMISIONREGNO"] = value; }
        }

    /// <summary>
    /// Yerel Gazete İkinci İlan Sayısı
    /// </summary>
        public int? LocalNewspaperAnnounceCount2
        {
            get { return (int?)this["LOCALNEWSPAPERANNOUNCECOUNT2"]; }
            set { this["LOCALNEWSPAPERANNOUNCECOUNT2"] = value; }
        }

    /// <summary>
    /// İş Niteliği
    /// </summary>
        public string ActAttribute
        {
            get { return (string)this["ACTATTRIBUTE"]; }
            set { this["ACTATTRIBUTE"] = value; }
        }

    /// <summary>
    /// Fiyat Tespit Komisyonu Dosya No
    /// </summary>
        public string PriceFormulationCommRegNo
        {
            get { return (string)this["PRICEFORMULATIONCOMMREGNO"]; }
            set { this["PRICEFORMULATIONCOMMREGNO"] = value; }
        }

    /// <summary>
    /// Lojistik Daire Onay Tarihi
    /// </summary>
        public DateTime? LBConfirmDate
        {
            get { return (DateTime?)this["LBCONFIRMDATE"]; }
            set { this["LBCONFIRMDATE"] = value; }
        }

    /// <summary>
    /// Birim Fiyat Teklif Mektubu Açıklaması
    /// </summary>
        public object UnitPriceProposalLetterText
        {
            get { return (object)this["UNITPRICEPROPOSALLETTERTEXT"]; }
            set { this["UNITPRICEPROPOSALLETTERTEXT"] = value; }
        }

    /// <summary>
    /// Şartname Satış Bedeli
    /// </summary>
        public double? SpecificationPrice
        {
            get { return (double?)this["SPECIFICATIONPRICE"]; }
            set { this["SPECIFICATIONPRICE"] = value; }
        }

    /// <summary>
    /// İlan Şekli Ve Adedi
    /// </summary>
        public AnnounceTypeandCountEnum? AnnounceTypeandCount
        {
            get { return (AnnounceTypeandCountEnum?)(int?)this["ANNOUNCETYPEANDCOUNT"]; }
            set { this["ANNOUNCETYPEANDCOUNT"] = value; }
        }

    /// <summary>
    /// Sonuç Bildirim Açıklaması
    /// </summary>
        public object FinalAnnounceDescription
        {
            get { return (object)this["FINALANNOUNCEDESCRIPTION"]; }
            set { this["FINALANNOUNCEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Mutemet Adı
    /// </summary>
        public string PayMasterName
        {
            get { return (string)this["PAYMASTERNAME"]; }
            set { this["PAYMASTERNAME"] = value; }
        }

    /// <summary>
    /// Karar Açıklaması
    /// </summary>
        public object DecisionDescription
        {
            get { return (object)this["DECISIONDESCRIPTION"]; }
            set { this["DECISIONDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Doğrudan Temin/İhale
    /// </summary>
        public PurchaseMainTypeEnum? PurchaseMainType
        {
            get { return (PurchaseMainTypeEnum?)(int?)this["PURCHASEMAINTYPE"]; }
            set { this["PURCHASEMAINTYPE"] = value; }
        }

    /// <summary>
    /// Genel Bütçe / Döner Sermaye
    /// </summary>
        public ProcurementEnum? ProcurementSource
        {
            get { return (ProcurementEnum?)(int?)this["PROCUREMENTSOURCE"]; }
            set { this["PROCUREMENTSOURCE"] = value; }
        }

    /// <summary>
    /// İlan Açıklaması
    /// </summary>
        public string AnnouncementDescription
        {
            get { return (string)this["ANNOUNCEMENTDESCRIPTION"]; }
            set { this["ANNOUNCEMENTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// KİK İhale Kayıt No
    /// </summary>
        public string KIKTenderRegisterNO
        {
            get { return (string)this["KIKTENDERREGISTERNO"]; }
            set { this["KIKTENDERREGISTERNO"] = value; }
        }

    /// <summary>
    /// Değerlendirme Türü
    /// </summary>
        public EvaluationTypeEnum? EvaluationType
        {
            get { return (EvaluationTypeEnum?)(int?)this["EVALUATIONTYPE"]; }
            set { this["EVALUATIONTYPE"] = value; }
        }

    /// <summary>
    /// Yerel Gazete Adı
    /// </summary>
        public string LocalNewspaperName
        {
            get { return (string)this["LOCALNEWSPAPERNAME"]; }
            set { this["LOCALNEWSPAPERNAME"] = value; }
        }

    /// <summary>
    /// İhaleye Davet Form Açıklaması
    /// </summary>
        public object IhaleyeDavetRTF
        {
            get { return (object)this["IHALEYEDAVETRTF"]; }
            set { this["IHALEYEDAVETRTF"] = value; }
        }

    /// <summary>
    /// Bütçe Harcama Kalemi
    /// </summary>
        public string BudgetExpensePen
        {
            get { return (string)this["BUDGETEXPENSEPEN"]; }
            set { this["BUDGETEXPENSEPEN"] = value; }
        }

    /// <summary>
    /// Onay Belgesi Açıklaması
    /// </summary>
        public object ApproveFormDescription
        {
            get { return (object)this["APPROVEFORMDESCRIPTION"]; }
            set { this["APPROVEFORMDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Yatırım Proje NO
    /// </summary>
        public string InvestmentProjectNO
        {
            get { return (string)this["INVESTMENTPROJECTNO"]; }
            set { this["INVESTMENTPROJECTNO"] = value; }
        }

    /// <summary>
    /// Yerel Gazete İkinci İlan Tarihi
    /// </summary>
        public DateTime? LocalNewspaperAnnounceDate2
        {
            get { return (DateTime?)this["LOCALNEWSPAPERANNOUNCEDATE2"]; }
            set { this["LOCALNEWSPAPERANNOUNCEDATE2"] = value; }
        }

    /// <summary>
    /// Mal Alımı / Hizmet Alımı
    /// </summary>
        public PurchaseTypeEnum_Material_Procedure? PurchaseTypeMatPro
        {
            get { return (PurchaseTypeEnum_Material_Procedure?)(int?)this["PURCHASETYPEMATPRO"]; }
            set { this["PURCHASETYPEMATPRO"] = value; }
        }

    /// <summary>
    /// İlan
    /// </summary>
        public bool? Announcement
        {
            get { return (bool?)this["ANNOUNCEMENT"]; }
            set { this["ANNOUNCEMENT"] = value; }
        }

    /// <summary>
    /// Doğrudan Temin Komisyonu Dosya No
    /// </summary>
        public string DirectPurchaseCommisionRegNo
        {
            get { return (string)this["DIRECTPURCHASECOMMISIONREGNO"]; }
            set { this["DIRECTPURCHASECOMMISIONREGNO"] = value; }
        }

    /// <summary>
    /// Yerel Gazete Adı 2
    /// </summary>
        public string LocalNewspaperName2
        {
            get { return (string)this["LOCALNEWSPAPERNAME2"]; }
            set { this["LOCALNEWSPAPERNAME2"] = value; }
        }

    /// <summary>
    /// Yerel Gazete İlk İlan Sayısı
    /// </summary>
        public int? LocalNewspaperAnnounceCount
        {
            get { return (int?)this["LOCALNEWSPAPERANNOUNCECOUNT"]; }
            set { this["LOCALNEWSPAPERANNOUNCECOUNT"] = value; }
        }

    /// <summary>
    /// Kullanılabilir Ödenek Tutarı
    /// </summary>
        public double? UsableBudgetAmount
        {
            get { return (double?)this["USABLEBUDGETAMOUNT"]; }
            set { this["USABLEBUDGETAMOUNT"] = value; }
        }

    /// <summary>
    /// İdari Şartname
    /// </summary>
        public object AdministrativeSpecification
        {
            get { return (object)this["ADMINISTRATIVESPECIFICATION"]; }
            set { this["ADMINISTRATIVESPECIFICATION"] = value; }
        }

    /// <summary>
    /// Kamu İhale Bülteni İlan Sayısı
    /// </summary>
        public int? KIBAnnouncementCount
        {
            get { return (int?)this["KIBANNOUNCEMENTCOUNT"]; }
            set { this["KIBANNOUNCEMENTCOUNT"] = value; }
        }

    /// <summary>
    /// Lojistik Daire Onay No
    /// </summary>
        public string LBConfirmNO
        {
            get { return (string)this["LBCONFIRMNO"]; }
            set { this["LBCONFIRMNO"] = value; }
        }

    /// <summary>
    /// Yaklaşık Maliyet Rapora Basılsın (Check Box)
    /// </summary>
        public bool? ShowApproximatePriceOnReport
        {
            get { return (bool?)this["SHOWAPPROXIMATEPRICEONREPORT"]; }
            set { this["SHOWAPPROXIMATEPRICEONREPORT"] = value; }
        }

    /// <summary>
    /// İhale Komisyonu Dosya No
    /// </summary>
        public string TenderCommisionRegNo
        {
            get { return (string)this["TENDERCOMMISIONREGNO"]; }
            set { this["TENDERCOMMISIONREGNO"] = value; }
        }

    /// <summary>
    /// İş Miktarı
    /// </summary>
        public long? ActCount
        {
            get { return (long?)this["ACTCOUNT"]; }
            set { this["ACTCOUNT"] = value; }
        }

    /// <summary>
    /// Avans Verilir (Check Box)
    /// </summary>
        public bool? Advanced
        {
            get { return (bool?)this["ADVANCED"]; }
            set { this["ADVANCED"] = value; }
        }

    /// <summary>
    /// Kamu İhale Bülteni İlan Tarihi
    /// </summary>
        public DateTime? KIBAnnouncementDate
        {
            get { return (DateTime?)this["KIBANNOUNCEMENTDATE"]; }
            set { this["KIBANNOUNCEMENTDATE"] = value; }
        }

    /// <summary>
    /// Karar Onay Tarihi
    /// </summary>
        public DateTime? ConclusionApproveDate
        {
            get { return (DateTime?)this["CONCLUSIONAPPROVEDATE"]; }
            set { this["CONCLUSIONAPPROVEDATE"] = value; }
        }

    /// <summary>
    /// Yeterlik Karar Tarihi
    /// </summary>
        public DateTime? SufficiencyDecisionDate
        {
            get { return (DateTime?)this["SUFFICIENCYDECISIONDATE"]; }
            set { this["SUFFICIENCYDECISIONDATE"] = value; }
        }

    /// <summary>
    /// Proje No
    /// </summary>
        public TTSequence PurchaseProjectNO
        {
            get { return GetSequence("PURCHASEPROJECTNO"); }
        }

    /// <summary>
    /// Alım Heyeti Görevlendirme Raporu RTF
    /// </summary>
        public object AlimHeyetiGorevlendirmeRTF
        {
            get { return (object)this["ALIMHEYETIGOREVLENDIRMERTF"]; }
            set { this["ALIMHEYETIGOREVLENDIRMERTF"] = value; }
        }

    /// <summary>
    /// Teklif Vermeye Davet Form Açıklaması
    /// </summary>
        public object ProposalInviteFormDesc
        {
            get { return (object)this["PROPOSALINVITEFORMDESC"]; }
            set { this["PROPOSALINVITEFORMDESC"] = value; }
        }

    /// <summary>
    /// İhale Tarihi
    /// </summary>
        public DateTime? TenderDate
        {
            get { return (DateTime?)this["TENDERDATE"]; }
            set { this["TENDERDATE"] = value; }
        }

    /// <summary>
    /// Alım Tarihi (Avanslı Alımlar İçin)
    /// </summary>
        public DateTime? AdvancePurchaseDate
        {
            get { return (DateTime?)this["ADVANCEPURCHASEDATE"]; }
            set { this["ADVANCEPURCHASEDATE"] = value; }
        }

    /// <summary>
    /// İş Tanımı
    /// </summary>
        public string ActDefine
        {
            get { return (string)this["ACTDEFINE"]; }
            set { this["ACTDEFINE"] = value; }
        }

    /// <summary>
    /// Sözleşmeye Davet Form Metni
    /// </summary>
        public object ContractInviteFormDesc
        {
            get { return (object)this["CONTRACTINVITEFORMDESC"]; }
            set { this["CONTRACTINVITEFORMDESC"] = value; }
        }

    /// <summary>
    /// Ekli Liste (Check Box)
    /// </summary>
        public bool? AttachmentList
        {
            get { return (bool?)this["ATTACHMENTLIST"]; }
            set { this["ATTACHMENTLIST"] = value; }
        }

    /// <summary>
    /// Onay Tarihi
    /// </summary>
        public DateTime? ConfirmDate
        {
            get { return (DateTime?)this["CONFIRMDATE"]; }
            set { this["CONFIRMDATE"] = value; }
        }

    /// <summary>
    /// Yeterlilik Tarihi
    /// </summary>
        public DateTime? SufficiencyDueDate
        {
            get { return (DateTime?)this["SUFFICIENCYDUEDATE"]; }
            set { this["SUFFICIENCYDUEDATE"] = value; }
        }

    /// <summary>
    /// Gerçeklestime Yetkilisi Görevi
    /// </summary>
        public string PerformerDuty
        {
            get { return (string)this["PERFORMERDUTY"]; }
            set { this["PERFORMERDUTY"] = value; }
        }

    /// <summary>
    /// Ulusal Gazete İlk İlan Tarihi
    /// </summary>
        public DateTime? NationalNewspaperAnnounceDate
        {
            get { return (DateTime?)this["NATIONALNEWSPAPERANNOUNCEDATE"]; }
            set { this["NATIONALNEWSPAPERANNOUNCEDATE"] = value; }
        }

    /// <summary>
    /// Alım Türü
    /// </summary>
        public DemandTypeEnum? DemandType
        {
            get { return (DemandTypeEnum?)(int?)this["DEMANDTYPE"]; }
            set { this["DEMANDTYPE"] = value; }
        }

    /// <summary>
    /// İptal Sebebi
    /// </summary>
        public object ProjectCancelDescription
        {
            get { return (object)this["PROJECTCANCELDESCRIPTION"]; }
            set { this["PROJECTCANCELDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Harcama Yetkilisi Görevi
    /// </summary>
        public string ExpenserDuty
        {
            get { return (string)this["EXPENSERDUTY"]; }
            set { this["EXPENSERDUTY"] = value; }
        }

    /// <summary>
    /// Fiyat Farkı (Check Box)
    /// </summary>
        public bool? PriceDifference
        {
            get { return (bool?)this["PRICEDIFFERENCE"]; }
            set { this["PRICEDIFFERENCE"] = value; }
        }

    /// <summary>
    /// Sonuç Bildirim Tarihi
    /// </summary>
        public DateTime? FinalAnnounceDate
        {
            get { return (DateTime?)this["FINALANNOUNCEDATE"]; }
            set { this["FINALANNOUNCEDATE"] = value; }
        }

    /// <summary>
    /// Onay No
    /// </summary>
        public string ConfirmNO
        {
            get { return (string)this["CONFIRMNO"]; }
            set { this["CONFIRMNO"] = value; }
        }

    /// <summary>
    /// Sorumlu Saha Remote MessageID
    /// </summary>
        public Guid? ResponsibleMessageID
        {
            get { return (Guid?)this["RESPONSIBLEMESSAGEID"]; }
            set { this["RESPONSIBLEMESSAGEID"] = value; }
        }

    /// <summary>
    /// Lojistik Daire Remote Message ID
    /// </summary>
        public Guid? LBMessageID
        {
            get { return (Guid?)this["LBMESSAGEID"]; }
            set { this["LBMESSAGEID"] = value; }
        }

    /// <summary>
    /// Projeyi  Başlatan Saha
    /// </summary>
        public Guid? OwnerSiteID
        {
            get { return (Guid?)this["OWNERSITEID"]; }
            set { this["OWNERSITEID"] = value; }
        }

    /// <summary>
    /// Projeden Sorumlu SiteID
    /// </summary>
        public Guid? ResponsibleSiteID
        {
            get { return (Guid?)this["RESPONSIBLESITEID"]; }
            set { this["RESPONSIBLESITEID"] = value; }
        }

    /// <summary>
    /// Onay No DS
    /// </summary>
        public TTSequence ConfirmNO_DS
        {
            get { return GetSequence("CONFIRMNO_DS"); }
        }

    /// <summary>
    /// Onay No GB
    /// </summary>
        public TTSequence ConfirmNO_GB
        {
            get { return GetSequence("CONFIRMNO_GB"); }
        }

    /// <summary>
    /// Ekli Liste Onaylayan Görevi
    /// </summary>
        public string AttachmentListConfirmerDuty
        {
            get { return (string)this["ATTACHMENTLISTCONFIRMERDUTY"]; }
            set { this["ATTACHMENTLISTCONFIRMERDUTY"] = value; }
        }

    /// <summary>
    /// Ulusal Gazete Adı
    /// </summary>
        public string NationalNewspaperName
        {
            get { return (string)this["NATIONALNEWSPAPERNAME"]; }
            set { this["NATIONALNEWSPAPERNAME"] = value; }
        }

    /// <summary>
    /// Bölge XXXXXX Message ID
    /// </summary>
        public Guid? RegionCommandMessageID
        {
            get { return (Guid?)this["REGIONCOMMANDMESSAGEID"]; }
            set { this["REGIONCOMMANDMESSAGEID"] = value; }
        }

    /// <summary>
    /// İhale İlanı RTF
    /// </summary>
        public object TenderAnnouncementRTF
        {
            get { return (object)this["TENDERANNOUNCEMENTRTF"]; }
            set { this["TENDERANNOUNCEMENTRTF"] = value; }
        }

    /// <summary>
    /// Ön Yeterlik İlanı RTF
    /// </summary>
        public object PreSufficiencyAnnouncementRTF
        {
            get { return (object)this["PRESUFFICIENCYANNOUNCEMENTRTF"]; }
            set { this["PRESUFFICIENCYANNOUNCEMENTRTF"] = value; }
        }

    /// <summary>
    /// Ekli Liste Hazırlayan Görevi
    /// </summary>
        public string AttachmentListPreparerDuty
        {
            get { return (string)this["ATTACHMENTLISTPREPARERDUTY"]; }
            set { this["ATTACHMENTLISTPREPARERDUTY"] = value; }
        }

    /// <summary>
    /// Yerel Gazete İlk İlan Tarihi
    /// </summary>
        public DateTime? LocalNewspaperAnnounceDate
        {
            get { return (DateTime?)this["LOCALNEWSPAPERANNOUNCEDATE"]; }
            set { this["LOCALNEWSPAPERANNOUNCEDATE"] = value; }
        }

        public PurchaseTypeDefinition PurchaseTypeDefinition
        {
            get { return (PurchaseTypeDefinition)((ITTObject)this).GetParent("PURCHASETYPEDEFINITION"); }
            set { this["PURCHASETYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Harcama Yetklisi
    /// </summary>
        public ResUser Expenser
        {
            get { return (ResUser)((ITTObject)this).GetParent("EXPENSER"); }
            set { this["EXPENSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Temp Purchase Project For Detail Editing
    /// </summary>
        public PurchaseProject TempPurchaseProjectDetMerge
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("TEMPPURCHASEPROJECTDETMERGE"); }
            set { this["TEMPPURCHASEPROJECTDETMERGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProjectProposalFirm TempPurchProjectProposlFirm
        {
            get { return (PurchaseProjectProposalFirm)((ITTObject)this).GetParent("TEMPPURCHPROJECTPROPOSLFIRM"); }
            set { this["TEMPPURCHPROJECTPROPOSLFIRM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser AdminAuthorized
        {
            get { return (ResUser)((ITTObject)this).GetParent("ADMINAUTHORIZED"); }
            set { this["ADMINAUTHORIZED"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Proposal TempProposal
        {
            get { return (Proposal)((ITTObject)this).GetParent("TEMPPROPOSAL"); }
            set { this["TEMPPROPOSAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gerçekleştirme Görevlisi
    /// </summary>
        public ResUser Performer
        {
            get { return (ResUser)((ITTObject)this).GetParent("PERFORMER"); }
            set { this["PERFORMER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcurementUnitDef ResponsibleProcurementUnitDef
        {
            get { return (ProcurementUnitDef)((ITTObject)this).GetParent("RESPONSIBLEPROCUREMENTUNITDEF"); }
            set { this["RESPONSIBLEPROCUREMENTUNITDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ItemTransfer TempItemTransfer
        {
            get { return (ItemTransfer)((ITTObject)this).GetParent("TEMPITEMTRANSFER"); }
            set { this["TEMPITEMTRANSFER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PaymentAccountancy PaymentAccountancy
        {
            get { return (PaymentAccountancy)((ITTObject)this).GetParent("PAYMENTACCOUNTANCY"); }
            set { this["PAYMENTACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ekli Liste Hazırlayan
    /// </summary>
        public ResUser AttachmentListPreparer
        {
            get { return (ResUser)((ITTObject)this).GetParent("ATTACHMENTLISTPREPARER"); }
            set { this["ATTACHMENTLISTPREPARER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ekli Liste Onaylayan
    /// </summary>
        public ResUser AttachmentListConfirmer
        {
            get { return (ResUser)((ITTObject)this).GetParent("ATTACHMENTLISTCONFIRMER"); }
            set { this["ATTACHMENTLISTCONFIRMER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BudgetDef Budget
        {
            get { return (BudgetDef)((ITTObject)this).GetParent("BUDGET"); }
            set { this["BUDGET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePurchaseProjectDetailsCollection()
        {
            _PurchaseProjectDetails = new PurchaseProjectDetail.ChildPurchaseProjectDetailCollection(this, new Guid("dcd6b0af-ad21-45f8-8395-2863855ae791"));
            ((ITTChildObjectCollection)_PurchaseProjectDetails).GetChildren();
        }

        protected PurchaseProjectDetail.ChildPurchaseProjectDetailCollection _PurchaseProjectDetails = null;
        public PurchaseProjectDetail.ChildPurchaseProjectDetailCollection PurchaseProjectDetails
        {
            get
            {
                if (_PurchaseProjectDetails == null)
                    CreatePurchaseProjectDetailsCollection();
                return _PurchaseProjectDetails;
            }
        }

        virtual protected void CreateFixedProposalDetailsCollection()
        {
            _FixedProposalDetails = new FixedProposalDetail.ChildFixedProposalDetailCollection(this, new Guid("d1add89c-9aef-4b57-8851-4d92cd403d44"));
            ((ITTChildObjectCollection)_FixedProposalDetails).GetChildren();
        }

        protected FixedProposalDetail.ChildFixedProposalDetailCollection _FixedProposalDetails = null;
        public FixedProposalDetail.ChildFixedProposalDetailCollection FixedProposalDetails
        {
            get
            {
                if (_FixedProposalDetails == null)
                    CreateFixedProposalDetailsCollection();
                return _FixedProposalDetails;
            }
        }

        virtual protected void CreateNeededDocumentsCollection()
        {
            _NeededDocuments = new NeededDocument.ChildNeededDocumentCollection(this, new Guid("3c9f0d58-4043-4e04-9485-4eb6be02d9b4"));
            ((ITTChildObjectCollection)_NeededDocuments).GetChildren();
        }

        protected NeededDocument.ChildNeededDocumentCollection _NeededDocuments = null;
        public NeededDocument.ChildNeededDocumentCollection NeededDocuments
        {
            get
            {
                if (_NeededDocuments == null)
                    CreateNeededDocumentsCollection();
                return _NeededDocuments;
            }
        }

        virtual protected void CreatePurchaseOrdersCollection()
        {
            _PurchaseOrders = new PurchaseOrder.ChildPurchaseOrderCollection(this, new Guid("4875c9d0-1164-4a8c-80a6-48dd894a8a58"));
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

        virtual protected void CreatePurchaseProjPropFirmsCollection()
        {
            _PurchaseProjPropFirms = new PurchaseProjectProposalFirm.ChildPurchaseProjectProposalFirmCollection(this, new Guid("1fdf3224-77f6-4d6d-8eee-9136332b838e"));
            ((ITTChildObjectCollection)_PurchaseProjPropFirms).GetChildren();
        }

        protected PurchaseProjectProposalFirm.ChildPurchaseProjectProposalFirmCollection _PurchaseProjPropFirms = null;
        public PurchaseProjectProposalFirm.ChildPurchaseProjectProposalFirmCollection PurchaseProjPropFirms
        {
            get
            {
                if (_PurchaseProjPropFirms == null)
                    CreatePurchaseProjPropFirmsCollection();
                return _PurchaseProjPropFirms;
            }
        }

        virtual protected void CreateContractsCollection()
        {
            _Contracts = new Contract.ChildContractCollection(this, new Guid("eb62640e-8488-49a6-9930-94c0c6d3a7b9"));
            ((ITTChildObjectCollection)_Contracts).GetChildren();
        }

        protected Contract.ChildContractCollection _Contracts = null;
        public Contract.ChildContractCollection Contracts
        {
            get
            {
                if (_Contracts == null)
                    CreateContractsCollection();
                return _Contracts;
            }
        }

        virtual protected void CreateDocumentSoldFirmsCollection()
        {
            _DocumentSoldFirms = new DocumentSoldFirm.ChildDocumentSoldFirmCollection(this, new Guid("6948dad5-3e82-4df4-90cc-a9f964f9b711"));
            ((ITTChildObjectCollection)_DocumentSoldFirms).GetChildren();
        }

        protected DocumentSoldFirm.ChildDocumentSoldFirmCollection _DocumentSoldFirms = null;
        public DocumentSoldFirm.ChildDocumentSoldFirmCollection DocumentSoldFirms
        {
            get
            {
                if (_DocumentSoldFirms == null)
                    CreateDocumentSoldFirmsCollection();
                return _DocumentSoldFirms;
            }
        }

        virtual protected void CreateProposalsCollection()
        {
            _Proposals = new Proposal.ChildProposalCollection(this, new Guid("e1ead056-c25b-46f3-8b75-b7ec39724056"));
            ((ITTChildObjectCollection)_Proposals).GetChildren();
        }

        protected Proposal.ChildProposalCollection _Proposals = null;
        public Proposal.ChildProposalCollection Proposals
        {
            get
            {
                if (_Proposals == null)
                    CreateProposalsCollection();
                return _Proposals;
            }
        }

        virtual protected void CreateInvitedFirmsForTenderCollection()
        {
            _InvitedFirmsForTender = new InvitedFirmForTender.ChildInvitedFirmForTenderCollection(this, new Guid("e19ce555-e3e9-4037-b0a9-ce7ba075dfc0"));
            ((ITTChildObjectCollection)_InvitedFirmsForTender).GetChildren();
        }

        protected InvitedFirmForTender.ChildInvitedFirmForTenderCollection _InvitedFirmsForTender = null;
        public InvitedFirmForTender.ChildInvitedFirmForTenderCollection InvitedFirmsForTender
        {
            get
            {
                if (_InvitedFirmsForTender == null)
                    CreateInvitedFirmsForTenderCollection();
                return _InvitedFirmsForTender;
            }
        }

        virtual protected void CreateDirectPurchaseCommisionMembersCollection()
        {
            _DirectPurchaseCommisionMembers = new DirectPurchaseCommision.ChildDirectPurchaseCommisionCollection(this, new Guid("ada3ff65-76d0-4105-9d30-c74322f7fba7"));
            ((ITTChildObjectCollection)_DirectPurchaseCommisionMembers).GetChildren();
        }

        protected DirectPurchaseCommision.ChildDirectPurchaseCommisionCollection _DirectPurchaseCommisionMembers = null;
        public DirectPurchaseCommision.ChildDirectPurchaseCommisionCollection DirectPurchaseCommisionMembers
        {
            get
            {
                if (_DirectPurchaseCommisionMembers == null)
                    CreateDirectPurchaseCommisionMembersCollection();
                return _DirectPurchaseCommisionMembers;
            }
        }

        virtual protected void CreatePriceFormulationCommisionMembersCollection()
        {
            _PriceFormulationCommisionMembers = new PriceFormulationCommisionMember.ChildPriceFormulationCommisionMemberCollection(this, new Guid("ab545e42-00ff-4965-bb3f-904767bd42ac"));
            ((ITTChildObjectCollection)_PriceFormulationCommisionMembers).GetChildren();
        }

        protected PriceFormulationCommisionMember.ChildPriceFormulationCommisionMemberCollection _PriceFormulationCommisionMembers = null;
        public PriceFormulationCommisionMember.ChildPriceFormulationCommisionMemberCollection PriceFormulationCommisionMembers
        {
            get
            {
                if (_PriceFormulationCommisionMembers == null)
                    CreatePriceFormulationCommisionMembersCollection();
                return _PriceFormulationCommisionMembers;
            }
        }

        virtual protected void CreatePurchaseProjectGroupsCollection()
        {
            _PurchaseProjectGroups = new PurchaseProjectGroup.ChildPurchaseProjectGroupCollection(this, new Guid("33a3c0cd-cd12-468e-a4f6-ff16e54e2f48"));
            ((ITTChildObjectCollection)_PurchaseProjectGroups).GetChildren();
        }

        protected PurchaseProjectGroup.ChildPurchaseProjectGroupCollection _PurchaseProjectGroups = null;
        public PurchaseProjectGroup.ChildPurchaseProjectGroupCollection PurchaseProjectGroups
        {
            get
            {
                if (_PurchaseProjectGroups == null)
                    CreatePurchaseProjectGroupsCollection();
                return _PurchaseProjectGroups;
            }
        }

        virtual protected void CreateTenderCommisionMembersCollection()
        {
            _TenderCommisionMembers = new TenderCommision.ChildTenderCommisionCollection(this, new Guid("fa175e67-2796-4062-ba4b-f4c98680610b"));
            ((ITTChildObjectCollection)_TenderCommisionMembers).GetChildren();
        }

        protected TenderCommision.ChildTenderCommisionCollection _TenderCommisionMembers = null;
        public TenderCommision.ChildTenderCommisionCollection TenderCommisionMembers
        {
            get
            {
                if (_TenderCommisionMembers == null)
                    CreateTenderCommisionMembersCollection();
                return _TenderCommisionMembers;
            }
        }

        virtual protected void CreateEliminatedFirmsCollection()
        {
            _EliminatedFirms = new PurchaseProjectEliminatedFirm.ChildPurchaseProjectEliminatedFirmCollection(this, new Guid("6d827883-a049-4ee3-9ce5-e179d0d729dd"));
            ((ITTChildObjectCollection)_EliminatedFirms).GetChildren();
        }

        protected PurchaseProjectEliminatedFirm.ChildPurchaseProjectEliminatedFirmCollection _EliminatedFirms = null;
        public PurchaseProjectEliminatedFirm.ChildPurchaseProjectEliminatedFirmCollection EliminatedFirms
        {
            get
            {
                if (_EliminatedFirms == null)
                    CreateEliminatedFirmsCollection();
                return _EliminatedFirms;
            }
        }

        virtual protected void CreateItemTransfersCollection()
        {
            _ItemTransfers = new ItemTransfer.ChildItemTransferCollection(this, new Guid("c4999e3a-5c0f-4f8d-98a6-7478c4c59ec4"));
            ((ITTChildObjectCollection)_ItemTransfers).GetChildren();
        }

        protected ItemTransfer.ChildItemTransferCollection _ItemTransfers = null;
        public ItemTransfer.ChildItemTransferCollection ItemTransfers
        {
            get
            {
                if (_ItemTransfers == null)
                    CreateItemTransfersCollection();
                return _ItemTransfers;
            }
        }

        virtual protected void CreateProjectFirmSufficiencysCollection()
        {
            _ProjectFirmSufficiencys = new ProjectFirmSufficiency.ChildProjectFirmSufficiencyCollection(this, new Guid("222c52a8-248f-4a00-ab5c-f90666e6c27e"));
            ((ITTChildObjectCollection)_ProjectFirmSufficiencys).GetChildren();
        }

        protected ProjectFirmSufficiency.ChildProjectFirmSufficiencyCollection _ProjectFirmSufficiencys = null;
        public ProjectFirmSufficiency.ChildProjectFirmSufficiencyCollection ProjectFirmSufficiencys
        {
            get
            {
                if (_ProjectFirmSufficiencys == null)
                    CreateProjectFirmSufficiencysCollection();
                return _ProjectFirmSufficiencys;
            }
        }

        protected PurchaseProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseProject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseProject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseProject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseProject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEPROJECT", dataRow) { }
        protected PurchaseProject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEPROJECT", dataRow, isImported) { }
        public PurchaseProject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseProject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseProject() : base() { }

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