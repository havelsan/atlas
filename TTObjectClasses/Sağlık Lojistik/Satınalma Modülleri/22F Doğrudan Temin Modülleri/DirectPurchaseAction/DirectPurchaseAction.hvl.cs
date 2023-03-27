
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DirectPurchaseAction")] 

    /// <summary>
    /// 22F Doğrudan Temin İşlemi
    /// </summary>
    public  partial class DirectPurchaseAction : BasePurchaseAction, I22FDirectPurchaseWorkList
    {
        public class DirectPurchaseActionList : TTObjectCollection<DirectPurchaseAction> { }
                    
        public class ChildDirectPurchaseActionCollection : TTObject.TTChildObjectCollection<DirectPurchaseAction>
        {
            public ChildDirectPurchaseActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDirectPurchaseActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MaterielInspectionAndReceivingFirmInfoNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? Irsaliyetarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IRSALIYETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEFIRMPROPOSAL"].AllPropertyDefs["DELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Irsaliyeno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IRSALIYENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEFIRMPROPOSAL"].AllPropertyDefs["DELIVERYNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Firmaadresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMAADRESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEFIRMPROPOSAL"].AllPropertyDefs["FIRMADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Faturatarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATURATARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEFIRMPROPOSAL"].AllPropertyDefs["INVOICEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Faturasayisi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATURASAYISI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEFIRMPROPOSAL"].AllPropertyDefs["INVOICENUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedarikci
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDARIKCI"]);
                }
            }

            public MaterielInspectionAndReceivingFirmInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterielInspectionAndReceivingFirmInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterielInspectionAndReceivingFirmInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class DirectPurchaseApprovalFormInfotNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Sutisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Miktar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MIKTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Olcubirimi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLCUBIRIMI"]);
                }
            }

            public string Islemkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rpcmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RPCMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Codelessmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODELESSMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DirectPurchaseApprovalFormInfotNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DirectPurchaseApprovalFormInfotNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DirectPurchaseApprovalFormInfotNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class DirectPurchaseApprovalCoordinatorInfoNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Koordineamiri
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KOORDINEAMIRI"]);
                }
            }

            public UserTitleEnum? Koordineamiriunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOORDINEAMIRIUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Koordineamirirutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KOORDINEAMIRIRUTBE"]);
                }
            }

            public DirectPurchaseApprovalCoordinatorInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DirectPurchaseApprovalCoordinatorInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DirectPurchaseApprovalCoordinatorInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class DirectPurchaseApprovalFormReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Hastatcno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATCNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Patientstatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                }
            }

            public string Uzmanlik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMANLIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Maliyil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALIYIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["FINANCIALYEAR"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Hastaprotno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAPROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["PATIENTPROTOCOLNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Ihaletarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALETARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Ihaleno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["TENDERNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Saymanlik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SAYMANLIK"]);
                }
            }

            public Guid? Butceharcamakalemi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BUTCEHARCAMAKALEMI"]);
                }
            }

            public Guid? Adbilimdalibaskservissorum
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ADBILIMDALIBASKSERVISSORUM"]);
                }
            }

            public Guid? Koordineeden
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KOORDINEEDEN"]);
                }
            }

            public Guid? Koordineamiri
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KOORDINEAMIRI"]);
                }
            }

            public UserTitleEnum? Koordineamiriunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOORDINEAMIRIUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Koordineamirirutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["KOORDINEAMIRIRUTBE"]);
                }
            }

            public Guid? Harcamayetkilisi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HARCAMAYETKILISI"]);
                }
            }

            public UserTitleEnum? Harcamayetkilisiunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HARCAMAYETKILISIUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Harcamayetkilisirutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HARCAMAYETKILISIRUTBE"]);
                }
            }

            public string Harcamayetkilisiis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HARCAMAYETKILISIIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Hasta
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HASTA"]);
                }
            }

            public Guid? Gorevlipersonel
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GOREVLIPERSONEL"]);
                }
            }

            public UserTitleEnum? Gorevlipersonelunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GOREVLIPERSONELUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Gorevlipersonelrutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GOREVLIPERSONELRUTBE"]);
                }
            }

            public Guid? Ihaleyetkilisi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["IHALEYETKILISI"]);
                }
            }

            public UserTitleEnum? Ihaleyetkilisiunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALEYETKILISIUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Ihaleyetkilisirutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["IHALEYETKILISIRUTBE"]);
                }
            }

            public string Ihaleyetkilisirutbeis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALEYETKILISIRUTBEIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ProcurementEnum? Butcemidosemi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUTCEMIDOSEMI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["PROCUREMENTTYPE"].DataType;
                    return (ProcurementEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DirectPurchaseApprovalFormReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DirectPurchaseApprovalFormReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DirectPurchaseApprovalFormReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialRequestFormReportNewNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Foreign
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGN"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Hastaisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Hastaprotno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAPROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["PATIENTPROTOCOLNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClinicChief
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINICCHIEF"]);
                }
            }

            public Guid? Expenser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXPENSER"]);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public MaterialRequestFormReportNewNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialRequestFormReportNewNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialRequestFormReportNewNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterielInspectionAndReceivingPatientInfoNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Uzmanlik
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["UZMANLIK"]);
                }
            }

            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Isim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Soyisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SOYISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaterielInspectionAndReceivingPatientInfoNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterielInspectionAndReceivingPatientInfoNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterielInspectionAndReceivingPatientInfoNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPiyasaArastirmaTutanagiNQL_Class : TTReportNqlObject 
        {
            public string SUTName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTNAME"].DataType;
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

            public Currency? SUTPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["SUTPRICE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string SUTCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRODUCTSUTMATCHDEFINITION"].AllPropertyDefs["SUTCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTIONDETAIL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Islemkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISLEMKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NUCLEARMEDICINETESTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rpcmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RPCMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Codelessmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODELESSMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DPA22FCODELESSMATERIALDEF"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPiyasaArastirmaTutanagiNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPiyasaArastirmaTutanagiNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPiyasaArastirmaTutanagiNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWorkListByDateReportNQL_Class : TTReportNqlObject 
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

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? TenderNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["TENDERNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Id1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetWorkListByDateReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkListByDateReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkListByDateReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWorkListByFilterExpressionReport_Class : TTReportNqlObject 
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

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? TenderNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["TENDERNUMBER"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Masterresourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTOBJECTID"]);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Id1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public GetWorkListByFilterExpressionReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkListByFilterExpressionReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkListByFilterExpressionReport_Class() : base() { }
        }

        [Serializable] 

        public partial class MaterialRequestFormReportBackUpNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Tckimlikno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TCKIMLIKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Hastaisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyisim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYISIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Hastaprotno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAPROTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].AllPropertyDefs["PATIENTPROTOCOLNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Guid? ClinicChief
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CLINICCHIEF"]);
                }
            }

            public UserTitleEnum? Adbilimbaskaniunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADBILIMBASKANIUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Adbilimbaskanirutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ADBILIMBASKANIRUTBE"]);
                }
            }

            public string Adbilimbaskanisicil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADBILIMBASKANISICIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Expenser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EXPENSER"]);
                }
            }

            public UserTitleEnum? Harcamayetkilisiunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HARCAMAYETKILISIUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Harcamayetkilisirutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HARCAMAYETKILISIRUTBE"]);
                }
            }

            public string Harcamayetkilisisicil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HARCAMAYETKILISISICIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Harcamayetkilisiis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HARCAMAYETKILISIIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Ihaleyetkilisi
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["IHALEYETKILISI"]);
                }
            }

            public UserTitleEnum? Ihaleyetkilisiunvan
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALEYETKILISIUNVAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Ihaleyetkilisirutbe
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["IHALEYETKILISIRUTBE"]);
                }
            }

            public string Ihaleyetkilisisicil
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALEYETKILISISICIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["EMPLOYMENTRECORDID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ihaleyetkilisiis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IHALEYETKILISIIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? MasterResource
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASTERRESOURCE"]);
                }
            }

            public MaterialRequestFormReportBackUpNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaterialRequestFormReportBackUpNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaterialRequestFormReportBackUpNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Teklif Giriş/Değerlendirme
    /// </summary>
            public static Guid FirmOfferEntry { get { return new Guid("d9faba5a-504c-45ca-bb0e-122affa47755"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("51a14360-925d-4a38-b2f9-2a6d1827709d"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("1784d54d-9a0a-4875-80cb-ec3b335699b5"); } }
    /// <summary>
    /// Talep
    /// </summary>
            public static Guid Demand { get { return new Guid("0c1abb04-140e-40c2-a69e-1ddd2a1899e1"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("825b9d6d-692b-4906-8c96-459ad8faf280"); } }
        }

        public static BindingList<DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class> MaterielInspectionAndReceivingFirmInfoNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterielInspectionAndReceivingFirmInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class> MaterielInspectionAndReceivingFirmInfoNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterielInspectionAndReceivingFirmInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterielInspectionAndReceivingFirmInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class> DirectPurchaseApprovalFormInfotNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["DirectPurchaseApprovalFormInfotNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class> DirectPurchaseApprovalFormInfotNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["DirectPurchaseApprovalFormInfotNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.DirectPurchaseApprovalFormInfotNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// DirectPurchaseApprovalCoordinatorInfoNQL
    /// </summary>
        public static BindingList<DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL_Class> DirectPurchaseApprovalCoordinatorInfoNQL(string DIRECTPURCHASEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["DirectPurchaseApprovalCoordinatorInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTION", DIRECTPURCHASEACTION);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// DirectPurchaseApprovalCoordinatorInfoNQL
    /// </summary>
        public static BindingList<DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL_Class> DirectPurchaseApprovalCoordinatorInfoNQL(TTObjectContext objectContext, string DIRECTPURCHASEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["DirectPurchaseApprovalCoordinatorInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTION", DIRECTPURCHASEACTION);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.DirectPurchaseApprovalCoordinatorInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class> DirectPurchaseApprovalFormReportNQL(string DIRECTPURCHASEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["DirectPurchaseApprovalFormReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTION", DIRECTPURCHASEACTION);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class> DirectPurchaseApprovalFormReportNQL(TTObjectContext objectContext, string DIRECTPURCHASEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["DirectPurchaseApprovalFormReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTION", DIRECTPURCHASEACTION);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.DirectPurchaseApprovalFormReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class> MaterialRequestFormReportNewNQL(string DIRECTPURCHASEACTIONINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterialRequestFormReportNewNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONINFO", DIRECTPURCHASEACTIONINFO);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class> MaterialRequestFormReportNewNQL(TTObjectContext objectContext, string DIRECTPURCHASEACTIONINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterialRequestFormReportNewNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONINFO", DIRECTPURCHASEACTIONINFO);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterialRequestFormReportNewNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class> MaterielInspectionAndReceivingPatientInfoNQL(string DIRECTPURCHASEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterielInspectionAndReceivingPatientInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTION", DIRECTPURCHASEACTION);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class> MaterielInspectionAndReceivingPatientInfoNQL(TTObjectContext objectContext, string DIRECTPURCHASEACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterielInspectionAndReceivingPatientInfoNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTION", DIRECTPURCHASEACTION);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterielInspectionAndReceivingPatientInfoNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class> GetPiyasaArastirmaTutanagiNQL(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetPiyasaArastirmaTutanagiNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class> GetPiyasaArastirmaTutanagiNQL(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetPiyasaArastirmaTutanagiNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.GetPiyasaArastirmaTutanagiNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.GetWorkListByDateReportNQL_Class> GetWorkListByDateReportNQL(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetWorkListByDateReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.GetWorkListByDateReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DirectPurchaseAction.GetWorkListByDateReportNQL_Class> GetWorkListByDateReportNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetWorkListByDateReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.GetWorkListByDateReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DirectPurchaseAction.GetWorkListByFilterExpressionReport_Class> GetWorkListByFilterExpressionReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetWorkListByFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.GetWorkListByFilterExpressionReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DirectPurchaseAction.GetWorkListByFilterExpressionReport_Class> GetWorkListByFilterExpressionReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetWorkListByFilterExpressionReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.GetWorkListByFilterExpressionReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DirectPurchaseAction> GetByWorkListDateQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetByWorkListDateQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DirectPurchaseAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DirectPurchaseAction> GetByFilterExpressionQuery(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["GetByFilterExpressionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<DirectPurchaseAction>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class> MaterialRequestFormReportBackUpNQL(string DIRECTPURCHASEACTIONINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterialRequestFormReportBackUpNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONINFO", DIRECTPURCHASEACTIONINFO);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class> MaterialRequestFormReportBackUpNQL(TTObjectContext objectContext, string DIRECTPURCHASEACTIONINFO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIRECTPURCHASEACTION"].QueryDefs["MaterialRequestFormReportBackUpNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DIRECTPURCHASEACTIONINFO", DIRECTPURCHASEACTIONINFO);

            return TTReportNqlObject.QueryObjects<DirectPurchaseAction.MaterialRequestFormReportBackUpNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstemin hangi malzeme türü için isteneceği
    /// </summary>
        public DirectPurchaseActionTypeEnum? DirectPurchaseActionType
        {
            get { return (DirectPurchaseActionTypeEnum?)(int?)this["DIRECTPURCHASEACTIONTYPE"]; }
            set { this["DIRECTPURCHASEACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Mali Yıl
    /// </summary>
        public int? FinancialYear
        {
            get { return (int?)this["FINANCIALYEAR"]; }
            set { this["FINANCIALYEAR"] = value; }
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
    /// Hasta Protokol No
    /// </summary>
        public int? PatientProtocolNo
        {
            get { return (int?)this["PATIENTPROTOCOLNO"]; }
            set { this["PATIENTPROTOCOLNO"] = value; }
        }

    /// <summary>
    /// Bütçe mi DÖSE mi?
    /// </summary>
        public ProcurementEnum? ProcurementType
        {
            get { return (ProcurementEnum?)(int?)this["PROCUREMENTTYPE"]; }
            set { this["PROCUREMENTTYPE"] = value; }
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
    /// İhale No
    /// </summary>
        public TTSequence TenderNumber
        {
            get { return GetSequence("TENDERNUMBER"); }
        }

    /// <summary>
    /// Hasta
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Loj.Ş./İk.Ks Görevli Personel
    /// </summary>
        public ResUser Performer
        {
            get { return (ResUser)((ITTObject)this).GetParent("PERFORMER"); }
            set { this["PERFORMER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// AD/Bilim D.Bşk./(Servis Sorumlusu)
    /// </summary>
        public ResUser ClinicChief
        {
            get { return (ResUser)((ITTObject)this).GetParent("CLINICCHIEF"); }
            set { this["CLINICCHIEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Koordine
    /// </summary>
        public ResUser Coordinator
        {
            get { return (ResUser)((ITTObject)this).GetParent("COORDINATOR"); }
            set { this["COORDINATOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Koordine
    /// </summary>
        public ResUser CoordinatorChief
        {
            get { return (ResUser)((ITTObject)this).GetParent("COORDINATORCHIEF"); }
            set { this["COORDINATORCHIEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Onay belgesini onaylayan kişi
    /// </summary>
        public ResUser TenderOfficer
        {
            get { return (ResUser)((ITTObject)this).GetParent("TENDEROFFICER"); }
            set { this["TENDEROFFICER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bütçe Harcama Kalemi
    /// </summary>
        public BudgetDef Budget
        {
            get { return (BudgetDef)((ITTObject)this).GetParent("BUDGET"); }
            set { this["BUDGET"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Paranın ayrılacağı nakit saymanlık 
    /// </summary>
        public PaymentAccountancy PaymentAccountancy
        {
            get { return (PaymentAccountancy)((ITTObject)this).GetParent("PAYMENTACCOUNTANCY"); }
            set { this["PAYMENTACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan Doktor
    /// </summary>
        public ResUser RequesterDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTERDOCTOR"); }
            set { this["REQUESTERDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Harcama Yetklisi
    /// </summary>
        public ResUser Expenser
        {
            get { return (ResUser)((ITTObject)this).GetParent("EXPENSER"); }
            set { this["EXPENSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDirectPurchaseActionDetailsCollection()
        {
            _DirectPurchaseActionDetails = new DirectPurchaseActionDetail.ChildDirectPurchaseActionDetailCollection(this, new Guid("4167632c-95c0-4ea6-9e75-b9d6ca97eb2a"));
            ((ITTChildObjectCollection)_DirectPurchaseActionDetails).GetChildren();
        }

        protected DirectPurchaseActionDetail.ChildDirectPurchaseActionDetailCollection _DirectPurchaseActionDetails = null;
    /// <summary>
    /// Child collection for Malzeme Detayları
    /// </summary>
        public DirectPurchaseActionDetail.ChildDirectPurchaseActionDetailCollection DirectPurchaseActionDetails
        {
            get
            {
                if (_DirectPurchaseActionDetails == null)
                    CreateDirectPurchaseActionDetailsCollection();
                return _DirectPurchaseActionDetails;
            }
        }

        virtual protected void CreateCommissionMembersCollection()
        {
            _CommissionMembers = new DirectPurchaseCommisionMember.ChildDirectPurchaseCommisionMemberCollection(this, new Guid("baaac873-15d6-4545-bda2-f075816145cc"));
            ((ITTChildObjectCollection)_CommissionMembers).GetChildren();
        }

        protected DirectPurchaseCommisionMember.ChildDirectPurchaseCommisionMemberCollection _CommissionMembers = null;
    /// <summary>
    /// Child collection for Komisyon Üyeleri
    /// </summary>
        public DirectPurchaseCommisionMember.ChildDirectPurchaseCommisionMemberCollection CommissionMembers
        {
            get
            {
                if (_CommissionMembers == null)
                    CreateCommissionMembersCollection();
                return _CommissionMembers;
            }
        }

        virtual protected void CreateDirectPurchaseFirmProposalsCollection()
        {
            _DirectPurchaseFirmProposals = new DirectPurchaseFirmProposal.ChildDirectPurchaseFirmProposalCollection(this, new Guid("c5837a78-1bb2-47f9-812e-d93ba403af29"));
            ((ITTChildObjectCollection)_DirectPurchaseFirmProposals).GetChildren();
        }

        protected DirectPurchaseFirmProposal.ChildDirectPurchaseFirmProposalCollection _DirectPurchaseFirmProposals = null;
        public DirectPurchaseFirmProposal.ChildDirectPurchaseFirmProposalCollection DirectPurchaseFirmProposals
        {
            get
            {
                if (_DirectPurchaseFirmProposals == null)
                    CreateDirectPurchaseFirmProposalsCollection();
                return _DirectPurchaseFirmProposals;
            }
        }

        protected DirectPurchaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DirectPurchaseAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DirectPurchaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DirectPurchaseAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DirectPurchaseAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIRECTPURCHASEACTION", dataRow) { }
        protected DirectPurchaseAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIRECTPURCHASEACTION", dataRow, isImported) { }
        public DirectPurchaseAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DirectPurchaseAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DirectPurchaseAction() : base() { }

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