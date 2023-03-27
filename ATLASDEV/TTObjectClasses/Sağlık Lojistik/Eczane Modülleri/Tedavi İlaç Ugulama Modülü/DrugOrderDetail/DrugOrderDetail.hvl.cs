
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugOrderDetail")] 

    /// <summary>
    /// İlaç Uygulama
    /// </summary>
    public  partial class DrugOrderDetail : BaseDrugOrder, IDrugOrderWorkList, IDrugOrderDetailApply
    {
        public class DrugOrderDetailList : TTObjectCollection<DrugOrderDetail> { }
                    
        public class ChildDrugOrderDetailCollection : TTObject.TTChildObjectCollection<DrugOrderDetail>
        {
            public ChildDrugOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DrugOrderDetailListReportNQL_Class : TTReportNqlObject 
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

            public Guid? DrugOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDER"]);
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

            public Guid? Room
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ROOM"]);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DrugOrderDetailListReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DrugOrderDetailListReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DrugOrderDetailListReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderDetailsByDrugOrder_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderDetailsByDrugOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderDetailsByDrugOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderDetailsByDrugOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveDrugOrderDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string State
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["STAGE"].DataType;
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

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveDrugOrderDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveDrugOrderDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveDrugOrderDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllDrugOrderDetail_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string State
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["STAGE"].DataType;
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

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllDrugOrderDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDrugOrderDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDrugOrderDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderDetailByNursingApp_Class : TTReportNqlObject 
        {
            public Guid? Orderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public bool? Orderturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["PATIENTOWNDRUG"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Uygulama_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UYGULAMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Tedavi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Tedavi_objectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TEDAVI_OBJECTID"]);
                }
            }

            public String Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Doz_araligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_ARALIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Doz_miktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_MIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Olusturma_tarihi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLUSTURMA_TARIHI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderDetailByNursingApp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderDetailByNursingApp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderDetailByNursingApp_Class() : base() { }
        }

        [Serializable] 

        public partial class DrugOrderDetailReportNQL_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Patientfullname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTFULLNAME"]);
                }
            }

            public Guid? DrugOrder
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDER"]);
                }
            }

            public string Tedavigorduguservis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVIGORDUGUSERVIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Yattigiservis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YATTIGISERVIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESWARD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Birim
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRIM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DrugOrderDetailReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DrugOrderDetailReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DrugOrderDetailReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveDrugOrderDetailByMaterial_Class : TTReportNqlObject 
        {
            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetActiveDrugOrderDetailByMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveDrugOrderDetailByMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveDrugOrderDetailByMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderDetailsByMasterResNotComp_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public string State
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["STAGE"].DataType;
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

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Masterresource_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderDetailsByMasterResNotComp_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderDetailsByMasterResNotComp_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderDetailsByMasterResNotComp_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderDetailsByMasterResource_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Object Statusname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATUSNAME"]);
                }
            }

            public string State
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["STAGE"].DataType;
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

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
                }
            }

            public string Masterresource_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patient_surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENT_SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Patientid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENTID"]);
                }
            }

            public string Responsiblenurse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLENURSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Bed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBED"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Room
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROOM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? HasFallingRisk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASFALLINGRISK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASFALLINGRISK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasAirborneContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASAIRBORNECONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASAIRBORNECONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasDropletIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASDROPLETISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASDROPLETISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? HasTightContactIsolation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTIGHTCONTACTISOLATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEINPATIENTADMISSION"].AllPropertyDefs["HASTIGHTCONTACTISOLATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kurum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Comingreason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMINGREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROVIZYONTIPI"].AllPropertyDefs["PROVIZYONTIPIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PatientClassTypeEnum? Hastaturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTATURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["PATIENTCLASSGROUP"].DataType;
                    return (PatientClassTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ApplicationReasonEnum? Basvuruturu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BASVURUTURU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTADMISSION"].AllPropertyDefs["APPLICATIONREASON"].DataType;
                    return (ApplicationReasonEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRIORITYSTATUSDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTIDENTITYANDADDRESS"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public int? YUPASSNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YUPASSNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["YUPASSNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public string Procedurebyuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREBYUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderDetailsByMasterResource_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderDetailsByMasterResource_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderDetailsByMasterResource_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugOrderDetailNursingAppNQL_Class : TTReportNqlObject 
        {
            public Guid? Orderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ORDEROBJECTID"]);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Tedavi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEDAVI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Durumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DURUMU"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Aciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doz_araligi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_ARALIGI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HOSPITALTIMESCHEDULE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Doz_miktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOZ_MIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetDrugOrderDetailNursingAppNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugOrderDetailNursingAppNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugOrderDetailNursingAppNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveDrugOrdersByEpisode_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDER"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? Drugorderobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUGORDEROBJECTID"]);
                }
            }

            public GetActiveDrugOrdersByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveDrugOrdersByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveDrugOrdersByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCovidInpatientList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? Drug
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DRUG"]);
                }
            }

            public GetCovidInpatientList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCovidInpatientList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCovidInpatientList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHalfDoseDrugOrderDetail_Class : TTReportNqlObject 
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

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string DonorID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DONORID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DONORID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? UseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["USEAMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string UBBCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UBBCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["UBBCODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? PlannedStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["PLANNEDSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? DoseAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSEAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DOSEAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string UsageNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGENOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["USAGENOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? PackageQuantity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGEQUANTITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["PACKAGEQUANTITY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? DrugDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DRUGDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Stage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["STAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? DetailNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["DETAILNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string CRCCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CRCCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["CRCCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHalfDoseDrugOrderDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHalfDoseDrugOrderDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHalfDoseDrugOrderDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNewAllDrugOrderDetailRQ_Class : TTReportNqlObject 
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

            public string State
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["STAGE"].DataType;
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

            public DateTime? OrderPlannedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERPLANNEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["ORDERPLANNEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String Statename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATENAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetNewAllDrugOrderDetailRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNewAllDrugOrderDetailRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNewAllDrugOrderDetailRQ_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancel { get { return new Guid("add6e452-c007-4849-b477-17d30400abe8"); } }
    /// <summary>
    /// İstendi
    /// </summary>
            public static Guid Request { get { return new Guid("da01e671-efb9-4d84-8122-4bae07e08c20"); } }
    /// <summary>
    /// Durduruldu
    /// </summary>
            public static Guid Stop { get { return new Guid("f1b24e44-ecb3-4b44-9b23-1d77e9901721"); } }
    /// <summary>
    /// Uygulandı
    /// </summary>
            public static Guid Apply { get { return new Guid("d39a37a6-610e-4143-aca2-691ce5818915"); } }
    /// <summary>
    /// Hastanın Üzerinde
    /// </summary>
            public static Guid UseRestDose { get { return new Guid("94c4b7eb-b764-4ca5-add6-76e2217f7dd4"); } }
    /// <summary>
    /// Planlandı
    /// </summary>
            public static Guid Planned { get { return new Guid("cb22e74b-a2be-456f-8680-660d0b21dc24"); } }
    /// <summary>
    /// Karşılandı
    /// </summary>
            public static Guid Supply { get { return new Guid("d4f85132-8d05-4dc7-b9b2-fc04bae622b0"); } }
    /// <summary>
    /// Hastaya Teslim Edildi
    /// </summary>
            public static Guid PatientDelivery { get { return new Guid("14ea4626-5b27-4663-82f9-64968cb4eb63"); } }
    /// <summary>
    /// Dış Eczane Tarafından Karşılandı
    /// </summary>
            public static Guid ExPharmacySupply { get { return new Guid("0586979d-523c-4800-995c-750ac3984606"); } }
    /// <summary>
    /// Eczaneye İade
    /// </summary>
            public static Guid ReturnPharmacy { get { return new Guid("4223ab9b-1b9f-4f59-845f-b903adcda8a0"); } }
    /// <summary>
    /// Eczacılık Brm. İstendi
    /// </summary>
            public static Guid PharmacologyRequest { get { return new Guid("ad54f2c0-8ebe-4fbb-a57a-b7c870fd1fb3"); } }
        }

        public static BindingList<DrugOrderDetail> GetDrugOrderDetails(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetails"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderDetail>(queryDef, paramList);
        }

        public static BindingList<DrugOrderDetail> GetSequenceOrderPlanedDates(TTObjectContext objectContext, string DRUGORDER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetSequenceOrderPlanedDates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDER", DRUGORDER);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderDetail>(queryDef, paramList);
        }

        public static BindingList<DrugOrderDetail> GetDrugOrderDetailsByDrug(TTObjectContext objectContext, Guid DRUGID, Guid EPISODEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsByDrug"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGID", DRUGID);
            paramList.Add("EPISODEID", EPISODEID);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderDetail>(queryDef, paramList);
        }

        public static BindingList<DrugOrderDetail> GetOrderPlannedDates(TTObjectContext objectContext, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetOrderPlannedDates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderDetail>(queryDef, paramList);
        }

        public static BindingList<DrugOrderDetail> DrugOrderDetailListNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["DrugOrderDetailListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderDetail>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<DrugOrderDetail> GetDrugOrderDetailsForDaily(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsForDaily"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderDetail>(queryDef, paramList);
        }

        public static BindingList<DrugOrderDetail.DrugOrderDetailListReportNQL_Class> DrugOrderDetailListReportNQL(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["DrugOrderDetailListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.DrugOrderDetailListReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.DrugOrderDetailListReportNQL_Class> DrugOrderDetailListReportNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["DrugOrderDetailListReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.DrugOrderDetailListReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class> GetDrugOrderDetailsByDrugOrder(Guid DRUGORDER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsByDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDER", DRUGORDER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class> GetDrugOrderDetailsByDrugOrder(TTObjectContext objectContext, Guid DRUGORDER, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsByDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDER", DRUGORDER);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailsByDrugOrder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetActiveDrugOrderDetail_Class> GetActiveDrugOrderDetail(DateTime STARTDATE, DateTime ENDDATE, Guid NURSINGAPPLICATION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetActiveDrugOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetActiveDrugOrderDetail_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetActiveDrugOrderDetail_Class> GetActiveDrugOrderDetail(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid NURSINGAPPLICATION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetActiveDrugOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetActiveDrugOrderDetail_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetAllDrugOrderDetail_Class> GetAllDrugOrderDetail(DateTime ENDDATE, Guid NURSINGAPPLICATION, DateTime STARTDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetAllDrugOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetAllDrugOrderDetail_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetAllDrugOrderDetail_Class> GetAllDrugOrderDetail(TTObjectContext objectContext, DateTime ENDDATE, Guid NURSINGAPPLICATION, DateTime STARTDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetAllDrugOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetAllDrugOrderDetail_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailByNursingApp_Class> GetDrugOrderDetailByNursingApp(string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailByNursingApp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailByNursingApp_Class> GetDrugOrderDetailByNursingApp(TTObjectContext objectContext, string NURSINGAPP, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailByNursingApp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailByNursingApp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.DrugOrderDetailReportNQL_Class> DrugOrderDetailReportNQL(DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["DrugOrderDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.DrugOrderDetailReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.DrugOrderDetailReportNQL_Class> DrugOrderDetailReportNQL(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["DrugOrderDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.DrugOrderDetailReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetActiveDrugOrderDetailByMaterial_Class> GetActiveDrugOrderDetailByMaterial(Guid EPISODEID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetActiveDrugOrderDetailByMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetActiveDrugOrderDetailByMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetActiveDrugOrderDetailByMaterial_Class> GetActiveDrugOrderDetailByMaterial(TTObjectContext objectContext, Guid EPISODEID, Guid MATERIALID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetActiveDrugOrderDetailByMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEID", EPISODEID);
            paramList.Add("MATERIALID", MATERIALID);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetActiveDrugOrderDetailByMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailsByMasterResNotComp_Class> GetDrugOrderDetailsByMasterResNotComp(DateTime ENDDATE, IList<Guid> MASTERRESOURCES, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsByMasterResNotComp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailsByMasterResNotComp_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailsByMasterResNotComp_Class> GetDrugOrderDetailsByMasterResNotComp(TTObjectContext objectContext, DateTime ENDDATE, IList<Guid> MASTERRESOURCES, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsByMasterResNotComp"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailsByMasterResNotComp_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class> GetDrugOrderDetailsByMasterResource(DateTime STARTDATE, DateTime ENDDATE, IList<Guid> MASTERRESOURCES, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class> GetDrugOrderDetailsByMasterResource(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, IList<Guid> MASTERRESOURCES, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailsByMasterResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("MASTERRESOURCES", MASTERRESOURCES);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailsByMasterResource_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailNursingAppNQL_Class> GetDrugOrderDetailNursingAppNQL(DateTime ENDDATE, string NURSINGAPP, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailNursingAppNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailNursingAppNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetDrugOrderDetailNursingAppNQL_Class> GetDrugOrderDetailNursingAppNQL(TTObjectContext objectContext, DateTime ENDDATE, string NURSINGAPP, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailNursingAppNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPP", NURSINGAPP);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetDrugOrderDetailNursingAppNQL_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Doz aşımı uyarısı için
    /// </summary>
        public static BindingList<DrugOrderDetail.GetActiveDrugOrdersByEpisode_Class> GetActiveDrugOrdersByEpisode(Guid EPISODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetActiveDrugOrdersByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetActiveDrugOrdersByEpisode_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Doz aşımı uyarısı için
    /// </summary>
        public static BindingList<DrugOrderDetail.GetActiveDrugOrdersByEpisode_Class> GetActiveDrugOrdersByEpisode(TTObjectContext objectContext, Guid EPISODE, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetActiveDrugOrdersByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetActiveDrugOrdersByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail> GetDrugOrderDetailByDrugOrder(TTObjectContext objectContext, string DrugOrder)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetDrugOrderDetailByDrugOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DRUGORDER", DrugOrder);

            return ((ITTQuery)objectContext).QueryObjects<DrugOrderDetail>(queryDef, paramList);
        }

        public static BindingList<DrugOrderDetail.GetCovidInpatientList_Class> GetCovidInpatientList(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetCovidInpatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetCovidInpatientList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetCovidInpatientList_Class> GetCovidInpatientList(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetCovidInpatientList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetCovidInpatientList_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class> GetHalfDoseDrugOrderDetail(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetHalfDoseDrugOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class> GetHalfDoseDrugOrderDetail(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetHalfDoseDrugOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetHalfDoseDrugOrderDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DrugOrderDetail.GetNewAllDrugOrderDetailRQ_Class> GetNewAllDrugOrderDetailRQ(Guid NURSINGAPPLICATION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetNewAllDrugOrderDetailRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetNewAllDrugOrderDetailRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugOrderDetail.GetNewAllDrugOrderDetailRQ_Class> GetNewAllDrugOrderDetailRQ(TTObjectContext objectContext, Guid NURSINGAPPLICATION, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGORDERDETAIL"].QueryDefs["GetNewAllDrugOrderDetailRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return TTReportNqlObject.QueryObjects<DrugOrderDetail.GetNewAllDrugOrderDetailRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kutu Adedi
    /// </summary>
        public double? PackageQuantity
        {
            get { return (double?)this["PACKAGEQUANTITY"]; }
            set { this["PACKAGEQUANTITY"] = value; }
        }

    /// <summary>
    /// Planlanan Tarih
    /// </summary>
        public DateTime? OrderPlannedDate
        {
            get { return (DateTime?)this["ORDERPLANNEDDATE"]; }
            set { this["ORDERPLANNEDDATE"] = value; }
        }

    /// <summary>
    /// İlaç Bitti
    /// </summary>
        public bool? DrugDone
        {
            get { return (bool?)this["DRUGDONE"]; }
            set { this["DRUGDONE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public string Stage
        {
            get { return (string)this["STAGE"]; }
            set { this["STAGE"] = value; }
        }

    /// <summary>
    /// Uygulama Notu
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Sıra no
    /// </summary>
        public int? DetailNo
        {
            get { return (int?)this["DETAILNO"]; }
            set { this["DETAILNO"] = value; }
        }

    /// <summary>
    /// CRCCode
    /// </summary>
        public string CRCCode
        {
            get { return (string)this["CRCCODE"]; }
            set { this["CRCCODE"] = value; }
        }

        public NursingApplication NursingApplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KScheduleCollectedOrder KScheduleCollectedOrder
        {
            get { return (KScheduleCollectedOrder)((ITTObject)this).GetParent("KSCHEDULECOLLECTEDORDER"); }
            set { this["KSCHEDULECOLLECTEDORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugOrder DrugOrder
        {
            get { return (DrugOrder)((ITTObject)this).GetParent("DRUGORDER"); }
            set { this["DRUGORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugDeliveryActionDetail DrugDeliveryActionDetail
        {
            get { return (DrugDeliveryActionDetail)((ITTObject)this).GetParent("DRUGDELIVERYACTIONDETAIL"); }
            set { this["DRUGDELIVERYACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugReturnActionDetail DrugReturnActionDetail
        {
            get { return (DrugReturnActionDetail)((ITTObject)this).GetParent("DRUGRETURNACTIONDETAIL"); }
            set { this["DRUGRETURNACTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KScheduleUnListMaterial KScheduleUnListMaterial
        {
            get { return (KScheduleUnListMaterial)((ITTObject)this).GetParent("KSCHEDULEUNLISTMATERIAL"); }
            set { this["KSCHEDULEUNLISTMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public KSchedulePatienOwnDrug KSchedulePatienOwnDrug
        {
            get { return (KSchedulePatienOwnDrug)((ITTObject)this).GetParent("KSCHEDULEPATIENOWNDRUG"); }
            set { this["KSCHEDULEPATIENOWNDRUG"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HalfDoseDestructionDetail HalfDoseDestructionDetail
        {
            get { return (HalfDoseDestructionDetail)((ITTObject)this).GetParent("HALFDOSEDESTRUCTIONDETAIL"); }
            set { this["HALFDOSEDESTRUCTIONDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDailyDrugPatientOrderDetsCollection()
        {
            _DailyDrugPatientOrderDets = new DailyDrugPatientOrderDet.ChildDailyDrugPatientOrderDetCollection(this, new Guid("a02177eb-5d73-4149-bcd0-87e8da72dd7e"));
            ((ITTChildObjectCollection)_DailyDrugPatientOrderDets).GetChildren();
        }

        protected DailyDrugPatientOrderDet.ChildDailyDrugPatientOrderDetCollection _DailyDrugPatientOrderDets = null;
        public DailyDrugPatientOrderDet.ChildDailyDrugPatientOrderDetCollection DailyDrugPatientOrderDets
        {
            get
            {
                if (_DailyDrugPatientOrderDets == null)
                    CreateDailyDrugPatientOrderDetsCollection();
                return _DailyDrugPatientOrderDets;
            }
        }

        virtual protected void CreateDailyDrugSchOrderDetailsCollection()
        {
            _DailyDrugSchOrderDetails = new DailyDrugSchOrderDetail.ChildDailyDrugSchOrderDetailCollection(this, new Guid("dec129ba-71c4-42f0-a457-12a3c2f4348a"));
            ((ITTChildObjectCollection)_DailyDrugSchOrderDetails).GetChildren();
        }

        protected DailyDrugSchOrderDetail.ChildDailyDrugSchOrderDetailCollection _DailyDrugSchOrderDetails = null;
        public DailyDrugSchOrderDetail.ChildDailyDrugSchOrderDetailCollection DailyDrugSchOrderDetails
        {
            get
            {
                if (_DailyDrugSchOrderDetails == null)
                    CreateDailyDrugSchOrderDetailsCollection();
                return _DailyDrugSchOrderDetails;
            }
        }

        virtual protected void CreateDailyDrugUnDrugDetsCollection()
        {
            _DailyDrugUnDrugDets = new DailyDrugUnDrugDet.ChildDailyDrugUnDrugDetCollection(this, new Guid("c8416d77-0fa6-4198-8b85-9763cabad6e5"));
            ((ITTChildObjectCollection)_DailyDrugUnDrugDets).GetChildren();
        }

        protected DailyDrugUnDrugDet.ChildDailyDrugUnDrugDetCollection _DailyDrugUnDrugDets = null;
        public DailyDrugUnDrugDet.ChildDailyDrugUnDrugDetCollection DailyDrugUnDrugDets
        {
            get
            {
                if (_DailyDrugUnDrugDets == null)
                    CreateDailyDrugUnDrugDetsCollection();
                return _DailyDrugUnDrugDets;
            }
        }

        override protected void CreateAccountTransactionsCollectionViews()
        {
            base.CreateAccountTransactionsCollectionViews();
        }

        protected DrugOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGORDERDETAIL", dataRow) { }
        protected DrugOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGORDERDETAIL", dataRow, isImported) { }
        public DrugOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugOrderDetail() : base() { }

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