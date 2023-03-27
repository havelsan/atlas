
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DistributionDocument")] 

    /// <summary>
    /// Dağıtım Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class DistributionDocument : StockAction, IDistributionDocument, ICheckStockActionOutDetail, IStockReservation, IAutoDocumentNumber, IStockTransferTransaction, IAutoDocumentRecordLog
    {
        public class DistributionDocumentList : TTObjectCollection<DistributionDocument> { }
                    
        public class ChildDistributionDocumentCollection : TTObject.TTChildObjectCollection<DistributionDocument>
        {
            public ChildDistributionDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDistributionDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDistributionDocumentCensusReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RegistrationNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REGISTRATIONNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDistributionDocumentCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDistributionDocumentCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDistributionDocumentCensusReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_DistributionDocument_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBERSEQ"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["STOCKACTIONID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["SEQUENCENUMBERSEQ"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ADDITIONALDOCUMENTCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ISENTRYOLDMATERIAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["GRANDTOTAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["INVOICEPICTURE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_YIL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_GELENVERI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_AYNIYATMAKBUZID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_EALIMYONTEMI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_EBUTCETUR"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_ETEDARIKTURU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_TESLIMEDEN"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_EMALZEMEGRUP"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_MAKBUZTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_DEPOKAYITNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_CIKISISLEMTURU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_CIKISSTOKHAREKETTURU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_CIKISYAPILANDEPOKAYITNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_CIKISYAPILANKISITCNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_GONDERIMTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_GIDENVERI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_GELDIGIYER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_KARSIBIRIMKAYITNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_MAKBUZNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_MUAYENENO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYS_MUAYENETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["MKYSCONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ISEMERGENCYMATERIAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ISPTSACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["PTSNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? DistributionDepStoreObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONDEPSTOREOBJECTID"]);
                }
            }

            public bool? IsAutoDistribution
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAUTODISTRIBUTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["ISAUTODISTRIBUTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_DistributionDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_DistributionDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_DistributionDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnsuccessfulDistributionDocument_Class : TTReportNqlObject 
        {
            public long? StockActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["STOCKACTIONID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetUnsuccessfulDistributionDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnsuccessfulDistributionDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnsuccessfulDistributionDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDestinationStore_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Id
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ID"]);
                }
            }

            public GetDestinationStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDestinationStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDestinationStore_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWaitingDistributionDocument_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Destinationstore
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESTINATIONSTORE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STORE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetWaitingDistributionDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWaitingDistributionDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWaitingDistributionDocument_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("c5073e82-017d-48d7-9a57-3573af2bf181"); } }
    /// <summary>
    /// Saymanlık Onayı
    /// </summary>
            public static Guid Approval { get { return new Guid("c4133a03-ac61-4905-a278-dc2f8b4d9ea9"); } }
            public static Guid Cancelled { get { return new Guid("260288ba-6d25-4c0f-a10f-930c4704739d"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("ffe9600f-a99e-47b3-bfd7-e0982076a75d"); } }
    /// <summary>
    /// Depo Onay
    /// </summary>
            public static Guid StoreApproval { get { return new Guid("0b2a1ba3-a934-453c-bc0d-ee7894f8bbf4"); } }
        }

        public static BindingList<DistributionDocument.GetDistributionDocumentCensusReportQuery_Class> GetDistributionDocumentCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetDistributionDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetDistributionDocumentCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.GetDistributionDocumentCensusReportQuery_Class> GetDistributionDocumentCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetDistributionDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetDistributionDocumentCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.CensusReportNQL_DistributionDocument_Class> CensusReportNQL_DistributionDocument(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["CensusReportNQL_DistributionDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DistributionDocument.CensusReportNQL_DistributionDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.CensusReportNQL_DistributionDocument_Class> CensusReportNQL_DistributionDocument(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["CensusReportNQL_DistributionDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<DistributionDocument.CensusReportNQL_DistributionDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.GetUnsuccessfulDistributionDocument_Class> GetUnsuccessfulDistributionDocument(Guid StoreIdD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetUnsuccessfulDistributionDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREIDD", StoreIdD);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetUnsuccessfulDistributionDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.GetUnsuccessfulDistributionDocument_Class> GetUnsuccessfulDistributionDocument(TTObjectContext objectContext, Guid StoreIdD, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetUnsuccessfulDistributionDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREIDD", StoreIdD);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetUnsuccessfulDistributionDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.GetDestinationStore_Class> GetDestinationStore(Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetDestinationStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetDestinationStore_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.GetDestinationStore_Class> GetDestinationStore(TTObjectContext objectContext, Guid StockActionID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetDestinationStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", StockActionID);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetDestinationStore_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.GetWaitingDistributionDocument_Class> GetWaitingDistributionDocument(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetWaitingDistributionDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetWaitingDistributionDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DistributionDocument.GetWaitingDistributionDocument_Class> GetWaitingDistributionDocument(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONDOCUMENT"].QueryDefs["GetWaitingDistributionDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DistributionDocument.GetWaitingDistributionDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public Guid? DistributionDepStoreObjectID
        {
            get { return (Guid?)this["DISTRIBUTIONDEPSTOREOBJECTID"]; }
            set { this["DISTRIBUTIONDEPSTOREOBJECTID"] = value; }
        }

    /// <summary>
    /// Otomatik Dağıtım Belgesi mi?
    /// </summary>
        public bool? IsAutoDistribution
        {
            get { return (bool?)this["ISAUTODISTRIBUTION"]; }
            set { this["ISAUTODISTRIBUTION"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _DistributionDocumentMaterials = new DistributionDocumentMaterial.ChildDistributionDocumentMaterialCollection(_StockActionDetails, "DistributionDocumentMaterials");
        }

        private DistributionDocumentMaterial.ChildDistributionDocumentMaterialCollection _DistributionDocumentMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public DistributionDocumentMaterial.ChildDistributionDocumentMaterialCollection DistributionDocumentMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _DistributionDocumentMaterials;
            }            
        }

        protected DistributionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DistributionDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DistributionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DistributionDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DistributionDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISTRIBUTIONDOCUMENT", dataRow) { }
        protected DistributionDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISTRIBUTIONDOCUMENT", dataRow, isImported) { }
        public DistributionDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DistributionDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DistributionDocument() : base() { }

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