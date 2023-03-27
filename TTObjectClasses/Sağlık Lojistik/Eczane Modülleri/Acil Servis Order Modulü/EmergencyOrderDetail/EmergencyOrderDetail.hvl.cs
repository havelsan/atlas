
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencyOrderDetail")] 

    /// <summary>
    /// Acil Servis Order Detayları
    /// </summary>
    public  partial class EmergencyOrderDetail : TTObject
    {
        public class EmergencyOrderDetailList : TTObjectCollection<EmergencyOrderDetail> { }
                    
        public class ChildEmergencyOrderDetailCollection : TTObject.TTChildObjectCollection<EmergencyOrderDetail>
        {
            public ChildEmergencyOrderDetailCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencyOrderDetailCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEmergencyOrderDetail_Class : TTReportNqlObject 
        {
            public DateTime? TransactionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYORDER"].AllPropertyDefs["TRANSACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public Guid? Materialobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIALOBJECTID"]);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYORDERDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public Guid? Detailid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DETAILID"]);
                }
            }

            public string Desciption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYORDER"].AllPropertyDefs["DESCIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public StockActionDetailStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYORDERDETAIL"].AllPropertyDefs["STATUS"].DataType;
                    return (StockActionDetailStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetEmergencyOrderDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencyOrderDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencyOrderDetail_Class() : base() { }
        }

        public static BindingList<EmergencyOrderDetail.GetEmergencyOrderDetail_Class> GetEmergencyOrderDetail(Guid SUBEPISODEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYORDERDETAIL"].QueryDefs["GetEmergencyOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<EmergencyOrderDetail.GetEmergencyOrderDetail_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EmergencyOrderDetail.GetEmergencyOrderDetail_Class> GetEmergencyOrderDetail(TTObjectContext objectContext, Guid SUBEPISODEID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYORDERDETAIL"].QueryDefs["GetEmergencyOrderDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<EmergencyOrderDetail.GetEmergencyOrderDetail_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Miktarı
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public StockActionDetailStatusEnum? Status
        {
            get { return (StockActionDetailStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

        public EmergencyOrder EmergencyOrder
        {
            get { return (EmergencyOrder)((ITTObject)this).GetParent("EMERGENCYORDER"); }
            set { this["EMERGENCYORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Hasta Muayene Objesi
    /// </summary>
        public SubActionMaterial SubActionMaterial
        {
            get { return (SubActionMaterial)((ITTObject)this).GetParent("SUBACTIONMATERIAL"); }
            set { this["SUBACTIONMATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Depo
    /// </summary>
        public Store Store
        {
            get { return (Store)((ITTObject)this).GetParent("STORE"); }
            set { this["STORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EmergencyOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencyOrderDetail(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencyOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencyOrderDetail(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencyOrderDetail(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYORDERDETAIL", dataRow) { }
        protected EmergencyOrderDetail(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYORDERDETAIL", dataRow, isImported) { }
        public EmergencyOrderDetail(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencyOrderDetail(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencyOrderDetail() : base() { }

    }
}