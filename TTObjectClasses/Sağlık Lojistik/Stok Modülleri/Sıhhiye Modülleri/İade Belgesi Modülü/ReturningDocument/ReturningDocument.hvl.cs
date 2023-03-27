
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReturningDocument")] 

    /// <summary>
    /// İade Belgesi için kullanılan temel sınıftır
    /// </summary>
    public  partial class ReturningDocument : StockAction, IAutoDocumentNumber, IStockTransferTransaction, IReturningDocument, ICheckStockActionOutDetail, IAutoDocumentRecordLog
    {
        public class ReturningDocumentList : TTObjectCollection<ReturningDocument> { }
                    
        public class ChildReturningDocumentCollection : TTObject.TTChildObjectCollection<ReturningDocument>
        {
            public ChildReturningDocumentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReturningDocumentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetReturningDocumentCensusReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetReturningDocumentCensusReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReturningDocumentCensusReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReturningDocumentCensusReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CensusReportNQL_ReturningDocument_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["REGISTRATIONNUMBERSEQ"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["STOCKACTIONID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["SEQUENCENUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["SEQUENCENUMBERSEQ"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ADDITIONALDOCUMENTCOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ISENTRYOLDMATERIAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["GRANDTOTAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["INVOICEPICTURE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["TOTALPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_YIL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_GELENVERI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_AYNIYATMAKBUZID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_EALIMYONTEMI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_EBUTCETUR"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_ETEDARIKTURU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_TESLIMEDEN"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_EMALZEMEGRUP"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_TESLIMALAN"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_MAKBUZTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_DEPOKAYITNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_CIKISISLEMTURU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_CIKISSTOKHAREKETTURU"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_CIKISYAPILANDEPOKAYITNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_CIKISYAPILANKISITCNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_GONDERIMTARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_GIDENVERI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_GELDIGIYER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_KARSIBIRIMKAYITNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_MAKBUZNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_MUAYENENO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYS_MUAYENETARIHI"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["MKYSCONTROL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ISEMERGENCYMATERIAL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ISPTSACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["PTSNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? FillingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FILLINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["FILLINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? RepairObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REPAIROBJECTID"]);
                }
            }

            public Guid? MaterialRepairObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALREPAIROBJECTID"]);
                }
            }

            public Guid? ReturnDepStoreObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RETURNDEPSTOREOBJECTID"]);
                }
            }

            public bool? IsChattelDocFlag
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCHATTELDOCFLAG"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["ISCHATTELDOCFLAG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BaseDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASEDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["BASEDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string BaseNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASENUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].AllPropertyDefs["BASENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CensusReportNQL_ReturningDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CensusReportNQL_ReturningDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CensusReportNQL_ReturningDocument_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDestStoreFromReturningDocument_Class : TTReportNqlObject 
        {
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

            public Guid? Id
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ID"]);
                }
            }

            public GetDestStoreFromReturningDocument_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDestStoreFromReturningDocument_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDestStoreFromReturningDocument_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("75c328fd-3c92-4f44-9381-11a924db8c80"); } }
    /// <summary>
    /// Belge Kayıt
    /// </summary>
            public static Guid New { get { return new Guid("222d9836-85ef-4b63-ac5d-1a2e2b61f599"); } }
            public static Guid Cancelled { get { return new Guid("8d488ae5-baae-4d31-b0ed-6c9a4d673ae5"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("252b3df0-3cc1-496b-805c-dcf5780f3ac8"); } }
        }

        public static BindingList<ReturningDocument.GetReturningDocumentCensusReportQuery_Class> GetReturningDocumentCensusReportQuery(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].QueryDefs["GetReturningDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ReturningDocument.GetReturningDocumentCensusReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReturningDocument.GetReturningDocumentCensusReportQuery_Class> GetReturningDocumentCensusReportQuery(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].QueryDefs["GetReturningDocumentCensusReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ReturningDocument.GetReturningDocumentCensusReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReturningDocument.CensusReportNQL_ReturningDocument_Class> CensusReportNQL_ReturningDocument(string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].QueryDefs["CensusReportNQL_ReturningDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ReturningDocument.CensusReportNQL_ReturningDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReturningDocument.CensusReportNQL_ReturningDocument_Class> CensusReportNQL_ReturningDocument(TTObjectContext objectContext, string TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].QueryDefs["CensusReportNQL_ReturningDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<ReturningDocument.CensusReportNQL_ReturningDocument_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReturningDocument.GetDestStoreFromReturningDocument_Class> GetDestStoreFromReturningDocument(Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].QueryDefs["GetDestStoreFromReturningDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<ReturningDocument.GetDestStoreFromReturningDocument_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReturningDocument.GetDestStoreFromReturningDocument_Class> GetDestStoreFromReturningDocument(TTObjectContext objectContext, Guid STOCKACTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RETURNINGDOCUMENT"].QueryDefs["GetDestStoreFromReturningDocument"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKACTIONID", STOCKACTIONID);

            return TTReportNqlObject.QueryObjects<ReturningDocument.GetDestStoreFromReturningDocument_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Doldurma Tarihi
    /// </summary>
        public DateTime? FillingDate
        {
            get { return (DateTime?)this["FILLINGDATE"]; }
            set { this["FILLINGDATE"] = value; }
        }

    /// <summary>
    /// RepairObjectID
    /// </summary>
        public Guid? RepairObjectID
        {
            get { return (Guid?)this["REPAIROBJECTID"]; }
            set { this["REPAIROBJECTID"] = value; }
        }

    /// <summary>
    /// MaterialRepairObjectID
    /// </summary>
        public Guid? MaterialRepairObjectID
        {
            get { return (Guid?)this["MATERIALREPAIROBJECTID"]; }
            set { this["MATERIALREPAIROBJECTID"] = value; }
        }

        public Guid? ReturnDepStoreObjectID
        {
            get { return (Guid?)this["RETURNDEPSTOREOBJECTID"]; }
            set { this["RETURNDEPSTOREOBJECTID"] = value; }
        }

    /// <summary>
    /// Taşınır Mal Çıkışa Getir
    /// </summary>
        public bool? IsChattelDocFlag
        {
            get { return (bool?)this["ISCHATTELDOCFLAG"]; }
            set { this["ISCHATTELDOCFLAG"] = value; }
        }

        public DateTime? BaseDateTime
        {
            get { return (DateTime?)this["BASEDATETIME"]; }
            set { this["BASEDATETIME"] = value; }
        }

        public string BaseNumber
        {
            get { return (string)this["BASENUMBER"]; }
            set { this["BASENUMBER"] = value; }
        }

        override protected void CreateStockActionDetailsCollectionViews()
        {
            base.CreateStockActionDetailsCollectionViews();
            _ReturningDocumentMaterials = new ReturningDocumentMaterial.ChildReturningDocumentMaterialCollection(_StockActionDetails, "ReturningDocumentMaterials");
        }

        private ReturningDocumentMaterial.ChildReturningDocumentMaterialCollection _ReturningDocumentMaterials = null;
    /// <summary>
    /// Alt İşlemler
    /// </summary>
        public ReturningDocumentMaterial.ChildReturningDocumentMaterialCollection ReturningDocumentMaterials
        {
            get
            {
                if (_StockActionDetails == null)
                    CreateStockActionDetailsCollection();
                return _ReturningDocumentMaterials;
            }            
        }

        protected ReturningDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReturningDocument(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReturningDocument(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReturningDocument(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReturningDocument(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RETURNINGDOCUMENT", dataRow) { }
        protected ReturningDocument(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RETURNINGDOCUMENT", dataRow, isImported) { }
        public ReturningDocument(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReturningDocument(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReturningDocument() : base() { }

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