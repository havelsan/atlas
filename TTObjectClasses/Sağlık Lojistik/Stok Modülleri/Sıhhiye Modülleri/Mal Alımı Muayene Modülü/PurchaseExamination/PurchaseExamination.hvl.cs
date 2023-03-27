
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseExamination")] 

    /// <summary>
    /// Geçici Kabul ve Mal Alım Muayene için kullanılan temel sınıftır
    /// </summary>
    public  partial class PurchaseExamination : StockAction, IStockOutTransaction, IStockInTransaction
    {
        public class PurchaseExaminationList : TTObjectCollection<PurchaseExamination> { }
                    
        public class ChildPurchaseExaminationCollection : TTObject.TTChildObjectCollection<PurchaseExamination>
        {
            public ChildPurchaseExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByObjcetID_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? RegistrationNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["REGISTRATIONNUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string SequenceNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? SequenceNumberSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQUENCENUMBERSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["SEQUENCENUMBERSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public int? AdditionalDocumentCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDITIONALDOCUMENTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ADDITIONALDOCUMENTCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsEntryOldMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISENTRYOLDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISENTRYOLDMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? GrandTotal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRANDTOTAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["GRANDTOTAL"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public object InvoicePicture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INVOICEPICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INVOICEPICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_Yil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_YIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_YIL"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GelenVeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GELENVERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GELENVERI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_AyniyatMakbuzID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_AYNIYATMAKBUZID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_AYNIYATMAKBUZID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYS_EAlimYontemiEnum? MKYS_EAlimYontemi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EALIMYONTEMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_EALIMYONTEMI"].DataType;
                    return (MKYS_EAlimYontemiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_EButceTurEnum? MKYS_EButceTur
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EBUTCETUR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_EBUTCETUR"].DataType;
                    return (MKYS_EButceTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_ETedarikTurEnum? MKYS_ETedarikTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_ETEDARIKTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_ETEDARIKTURU"].DataType;
                    return (MKYS_ETedarikTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MKYS_TeslimEden
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_TESLIMEDEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_TESLIMEDEN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MKYS_EMalzemeGrupEnum? MKYS_EMalzemeGrup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_EMALZEMEGRUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_EMALZEMEGRUP"].DataType;
                    return (MKYS_EMalzemeGrupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MKYS_TeslimAlan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_TESLIMALAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_MakbuzTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MAKBUZTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MAKBUZTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_DepoKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_DEPOKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_DEPOKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public MKYS_ECikisIslemTuruEnum? MKYS_CikisIslemTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISISLEMTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISISLEMTURU"].DataType;
                    return (MKYS_ECikisIslemTuruEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public MKYS_ECikisStokHareketTurEnum? MKYS_CikisStokHareketTuru
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISSTOKHAREKETTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISSTOKHAREKETTURU"].DataType;
                    return (MKYS_ECikisStokHareketTurEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_CikisYapilanDepoKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISYAPILANDEPOKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISYAPILANDEPOKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_CikisYapilanKisiTCNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_CIKISYAPILANKISITCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_CIKISYAPILANKISITCNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_GonderimTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GONDERIMTARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GONDERIMTARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GidenVeri
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GIDENVERI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GIDENVERI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MKYS_GeldigiYer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_GELDIGIYER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_GELDIGIYER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_KarsiBirimKayitNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_KARSIBIRIMKAYITNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_KARSIBIRIMKAYITNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MKYS_MakbuzNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MAKBUZNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MAKBUZNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MKYS_MuayeneNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MUAYENENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MUAYENENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? MKYS_MuayeneTarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYS_MUAYENETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYS_MUAYENETARIHI"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? MKYSControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MKYSCONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MKYSCONTROL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? MKYS_TeslimAlanObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MKYS_TESLIMALANOBJID"]);
                }
            }

            public Guid? MKYS_TeslimEdenObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MKYS_TESLIMEDENOBJID"]);
                }
            }

            public bool? IsEmergencyMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISEMERGENCYMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISEMERGENCYMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPTSAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPTSACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["ISPTSACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PTSNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PTSNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["PTSNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GeneralInspectionFinalReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENERALINSPECTIONFINALREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["GENERALINSPECTIONFINALREPORT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationFinishDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONFINISHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["EXAMINATIONFINISHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string FunctionInspectionFinalReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FUNCTIONINSPECTIONFINALREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FUNCTIONINSPECTIONFINALREPORT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FileNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FILENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhysicalInspectionNoticeText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALINSPECTIONNOTICETEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["PHYSICALINSPECTIONNOTICETEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TemporaryDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPORARYDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TEMPORARYDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? ManuelEntry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUELENTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["MANUELENTRY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public PurchaseExaminationStatusEnum? InspectionStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSPECTIONSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INSPECTIONSTATUS"].DataType;
                    return (PurchaseExaminationStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FunctionTestReportHeaderTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FUNCTIONTESTREPORTHEADERTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FUNCTIONTESTREPORTHEADERTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PhysicalInspectionFinalReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PHYSICALINSPECTIONFINALREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["PHYSICALINSPECTIONFINALREPORT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? InspectionMemoCollacationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSPECTIONMEMOCOLLACATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INSPECTIONMEMOCOLLACATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public TemporaryReceivingProcessStatusEnum? TempReceivingProcessStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPRECEIVINGPROCESSSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["TEMPRECEIVINGPROCESSSTATUS"].DataType;
                    return (TemporaryReceivingProcessStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FunctionInspectionRequestTxt
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FUNCTIONINSPECTIONREQUESTTXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["FUNCTIONINSPECTIONREQUESTTXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExaminationStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATIONSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["EXAMINATIONSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string InspectionPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSPECTIONPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].AllPropertyDefs["INSPECTIONPLACE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountancyname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Storename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Suppliername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetByObjcetID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByObjcetID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByObjcetID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPurchaseExaminationRegistryReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Store
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ExpirationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXPIRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATIONDETAIL"].AllPropertyDefs["EXPIRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetPurchaseExaminationRegistryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPurchaseExaminationRegistryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPurchaseExaminationRegistryReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("97df5952-e3da-45d9-9cac-11b28bcabd3d"); } }
    /// <summary>
    /// Geçici Kabul Kayıt
    /// </summary>
            public static Guid TemporaryAdmissionRegistry { get { return new Guid("b470265f-7b10-49a5-b30f-75447b028b7a"); } }
    /// <summary>
    /// Red Tebliğ
    /// </summary>
            public static Guid RejectNotice { get { return new Guid("744b3fa7-292e-4fc6-9b71-40913032afcf"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("e5b2512a-264f-4895-b32c-a0a7993d4413"); } }
    /// <summary>
    /// Fonksiyon,Kimya, Laboratuvar Muayenesi   
    /// </summary>
            public static Guid FunctionalExamination { get { return new Guid("60803fb4-13e9-42a7-bd60-823eb353d679"); } }
    /// <summary>
    /// Muayene Muhtırası Tanzimi
    /// </summary>
            public static Guid InspectionMemorandumPreparing { get { return new Guid("68de605a-0478-4b2d-b136-b87a738acf65"); } }
    /// <summary>
    /// Fiziksel Muayene ve Numune Alma  
    /// </summary>
            public static Guid PhysicalExamination { get { return new Guid("40279fe9-fb26-4150-93cc-aaceca7e6c19"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid AccountancyApprove { get { return new Guid("c3b4fba9-79b1-4c5d-935b-34c6f25d2f6a"); } }
        }

        public static BindingList<PurchaseExamination> GetTemporaryReceiving(TTObjectContext objectContext, string SUPPLIER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].QueryDefs["GetTemporaryReceiving"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUPPLIER", SUPPLIER);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseExamination>(queryDef, paramList);
        }

        public static BindingList<PurchaseExamination.GetByObjcetID_Class> GetByObjcetID(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].QueryDefs["GetByObjcetID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseExamination.GetByObjcetID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseExamination.GetByObjcetID_Class> GetByObjcetID(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].QueryDefs["GetByObjcetID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<PurchaseExamination.GetByObjcetID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PurchaseExamination.GetPurchaseExaminationRegistryReportQuery_Class> GetPurchaseExaminationRegistryReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].QueryDefs["GetPurchaseExaminationRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PurchaseExamination.GetPurchaseExaminationRegistryReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PurchaseExamination.GetPurchaseExaminationRegistryReportQuery_Class> GetPurchaseExaminationRegistryReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEEXAMINATION"].QueryDefs["GetPurchaseExaminationRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<PurchaseExamination.GetPurchaseExaminationRegistryReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Genel Muayene Sonuç Raporu
    /// </summary>
        public string GeneralInspectionFinalReport
        {
            get { return (string)this["GENERALINSPECTIONFINALREPORT"]; }
            set { this["GENERALINSPECTIONFINALREPORT"] = value; }
        }

    /// <summary>
    /// Muayene Bitiş Tarihi
    /// </summary>
        public DateTime? ExaminationFinishDate
        {
            get { return (DateTime?)this["EXAMINATIONFINISHDATE"]; }
            set { this["EXAMINATIONFINISHDATE"] = value; }
        }

    /// <summary>
    /// Fonksiyon Muayene Sonuç Raporu
    /// </summary>
        public string FunctionInspectionFinalReport
        {
            get { return (string)this["FUNCTIONINSPECTIONFINALREPORT"]; }
            set { this["FUNCTIONINSPECTIONFINALREPORT"] = value; }
        }

    /// <summary>
    /// Dosya No
    /// </summary>
        public string FileNO
        {
            get { return (string)this["FILENO"]; }
            set { this["FILENO"] = value; }
        }

    /// <summary>
    /// Fiziksel Muayene Tebligat Paragrafı
    /// </summary>
        public string PhysicalInspectionNoticeText
        {
            get { return (string)this["PHYSICALINSPECTIONNOTICETEXT"]; }
            set { this["PHYSICALINSPECTIONNOTICETEXT"] = value; }
        }

    /// <summary>
    /// Muvakkat Teslim Tarihi
    /// </summary>
        public DateTime? TemporaryDeliveryDate
        {
            get { return (DateTime?)this["TEMPORARYDELIVERYDATE"]; }
            set { this["TEMPORARYDELIVERYDATE"] = value; }
        }

    /// <summary>
    /// İşlem Fire mı edilmiş manuel mi başlatılmış?
    /// </summary>
        public bool? ManuelEntry
        {
            get { return (bool?)this["MANUELENTRY"]; }
            set { this["MANUELENTRY"] = value; }
        }

    /// <summary>
    /// Muayene Durumu
    /// </summary>
        public PurchaseExaminationStatusEnum? InspectionStatus
        {
            get { return (PurchaseExaminationStatusEnum?)(int?)this["INSPECTIONSTATUS"]; }
            set { this["INSPECTIONSTATUS"] = value; }
        }

    /// <summary>
    /// Fonksiyon Muayenesi Test Raporu Başlık Metni
    /// </summary>
        public string FunctionTestReportHeaderTxt
        {
            get { return (string)this["FUNCTIONTESTREPORTHEADERTXT"]; }
            set { this["FUNCTIONTESTREPORTHEADERTXT"] = value; }
        }

    /// <summary>
    /// Fiziksel Muayene Sonuç Raporu
    /// </summary>
        public string PhysicalInspectionFinalReport
        {
            get { return (string)this["PHYSICALINSPECTIONFINALREPORT"]; }
            set { this["PHYSICALINSPECTIONFINALREPORT"] = value; }
        }

    /// <summary>
    /// Muayene Muhtırası Tanzim Tarihi
    /// </summary>
        public DateTime? InspectionMemoCollacationDate
        {
            get { return (DateTime?)this["INSPECTIONMEMOCOLLACATIONDATE"]; }
            set { this["INSPECTIONMEMOCOLLACATIONDATE"] = value; }
        }

    /// <summary>
    /// Geçici Kabul İşlem Durumu
    /// </summary>
        public TemporaryReceivingProcessStatusEnum? TempReceivingProcessStatus
        {
            get { return (TemporaryReceivingProcessStatusEnum?)(int?)this["TEMPRECEIVINGPROCESSSTATUS"]; }
            set { this["TEMPRECEIVINGPROCESSSTATUS"] = value; }
        }

    /// <summary>
    /// Fonksiyon Muayenesi Paragrafı
    /// </summary>
        public string FunctionInspectionRequestTxt
        {
            get { return (string)this["FUNCTIONINSPECTIONREQUESTTXT"]; }
            set { this["FUNCTIONINSPECTIONREQUESTTXT"] = value; }
        }

    /// <summary>
    /// Muayene Başlangıç Tarihi
    /// </summary>
        public DateTime? ExaminationStartDate
        {
            get { return (DateTime?)this["EXAMINATIONSTARTDATE"]; }
            set { this["EXAMINATIONSTARTDATE"] = value; }
        }

    /// <summary>
    /// Muayene Yeri
    /// </summary>
        public string InspectionPlace
        {
            get { return (string)this["INSPECTIONPLACE"]; }
            set { this["INSPECTIONPLACE"] = value; }
        }

        public Supplier TmpSupplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("TMPSUPPLIER"); }
            set { this["TMPSUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Contract Contract
        {
            get { return (Contract)((ITTObject)this).GetParent("CONTRACT"); }
            set { this["CONTRACT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateExaminationCommisionMembersCollection()
        {
            _ExaminationCommisionMembers = new ExaminationCommisionMember.ChildExaminationCommisionMemberCollection(this, new Guid("10f2e52f-cfdf-4e7d-a1e3-42431a7abb8a"));
            ((ITTChildObjectCollection)_ExaminationCommisionMembers).GetChildren();
        }

        protected ExaminationCommisionMember.ChildExaminationCommisionMemberCollection _ExaminationCommisionMembers = null;
        public ExaminationCommisionMember.ChildExaminationCommisionMemberCollection ExaminationCommisionMembers
        {
            get
            {
                if (_ExaminationCommisionMembers == null)
                    CreateExaminationCommisionMembersCollection();
                return _ExaminationCommisionMembers;
            }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _PurchaseExaminationDetails = new PurchaseExaminationDetail.ChildPurchaseExaminationDetailCollection(_StockActionDetails, "PurchaseExaminationDetails");
            _PurchaseExaminationOutDetails = new PurchaseExaminationDetailOut.ChildPurchaseExaminationDetailOutCollection(_StockActionDetails, "PurchaseExaminationOutDetails");
        }

        private PurchaseExaminationDetail.ChildPurchaseExaminationDetailCollection _PurchaseExaminationDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PurchaseExaminationDetail.ChildPurchaseExaminationDetailCollection PurchaseExaminationDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PurchaseExaminationDetails;
            }            
        }

        private PurchaseExaminationDetailOut.ChildPurchaseExaminationDetailOutCollection _PurchaseExaminationOutDetails = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public PurchaseExaminationDetailOut.ChildPurchaseExaminationDetailOutCollection PurchaseExaminationOutDetails
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _PurchaseExaminationOutDetails;
            }            
        }

        protected PurchaseExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEEXAMINATION", dataRow) { }
        protected PurchaseExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEEXAMINATION", dataRow, isImported) { }
        public PurchaseExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseExamination() : base() { }

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