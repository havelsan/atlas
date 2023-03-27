
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenanceOrder")] 

    /// <summary>
    /// Şipariş İşlemi
    /// </summary>
    public  partial class MaintenanceOrder : CMRAction
    {
        public class MaintenanceOrderList : TTObjectCollection<MaintenanceOrder> { }
                    
        public class ChildMaintenanceOrderCollection : TTObject.TTChildObjectCollection<MaintenanceOrder>
        {
            public ChildMaintenanceOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MaintenanceOrderReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Maintenanceordertype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEORDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].AllPropertyDefs["TYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Materialtree
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fixedassetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Stockcardclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProductionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["PRODUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Stage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STAGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stagemilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAGEMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Workshop
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Responsibleworkshopuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEWORKSHOPUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PlannedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PLANNEDTIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Rulobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RULOBJECTID"]);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Firstcheckdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTCHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RepairObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIROBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REPAIROBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaintenanceOrderReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaintenanceOrderReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaintenanceOrderReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaintenanceOrderObjectIDQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMaintenanceOrderObjectIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceOrderObjectIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceOrderObjectIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetProcessingDeviceAndHardwareReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Workshop
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Senderaccountancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERACCOUNTANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Senderaddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? RepairWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REPAIRWORKLOAD"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public OrderStatusEnum? OrderStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERSTATUS"].DataType;
                    return (OrderStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetProcessingDeviceAndHardwareReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcessingDeviceAndHardwareReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcessingDeviceAndHardwareReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrderChaseAndRegistryReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Ownermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Responsibleuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public OrderStatusEnum? OrderStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERSTATUS"].DataType;
                    return (OrderStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetOrderChaseAndRegistryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrderChaseAndRegistryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrderChaseAndRegistryReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaintenanceAndRepairRegistryReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Personnel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONNEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public string Ownermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ReferTypeEnum? ReferType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REFERTYPE"].DataType;
                    return (ReferTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetMaintenanceAndRepairRegistryReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceAndRepairRegistryReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceAndRepairRegistryReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDirectMaterialCostsQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDCONSUMEDMATERAIL"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Materialcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALCOST"]);
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

            public GetDirectMaterialCostsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDirectMaterialCostsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDirectMaterialCostsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDirectMaterialCostsForWorkStepQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
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

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDMATERIALWORKSTEP"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USEDMATERIALWORKSTEP"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Object Materialcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MATERIALCOST"]);
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

            public GetDirectMaterialCostsForWorkStepQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDirectMaterialCostsForWorkStepQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDirectMaterialCostsForWorkStepQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetConsumedMaterialsQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public Currency? RequestAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE_CONSUMEDMATERIAL"].AllPropertyDefs["REQUESTAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? SuppliedAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIEDAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE_CONSUMEDMATERIAL"].AllPropertyDefs["SUPPLIEDAMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
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

            public string SparePartMaterialDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPAREPARTMATERIALDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCE_CONSUMEDMATERIAL"].AllPropertyDefs["SPAREPARTMATERIALDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetConsumedMaterialsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetConsumedMaterialsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetConsumedMaterialsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaintenanceOrderCostByObjectIDQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string OrderName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Manufacturingamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MANUFACTURINGAMOUNT"]);
                }
            }

            public string Workshop
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Year
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["YEAR"]);
                }
            }

            public Object Sharpdirectlabortime
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SHARPDIRECTLABORTIME"]);
                }
            }

            public Object Avaragedirectlaborcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AVARAGEDIRECTLABORCOST"]);
                }
            }

            public Object Laborcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["LABORCOST"]);
                }
            }

            public Object Directmaterialexpense
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIRECTMATERIALEXPENSE"]);
                }
            }

            public Object Averagegeneralprocessingcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AVERAGEGENERALPROCESSINGCOST"]);
                }
            }

            public Object Generalprocessingcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GENERALPROCESSINGCOST"]);
                }
            }

            public Object Averagedepreciationexpense
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AVERAGEDEPRECIATIONEXPENSE"]);
                }
            }

            public Object Depreciationexpense
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEPRECIATIONEXPENSE"]);
                }
            }

            public GetMaintenanceOrderCostByObjectIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceOrderCostByObjectIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceOrderCostByObjectIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaintenanceOrderByObjectIDQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string DescriptionPart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONPART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DESCRIPTIONPART"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Maintenanceordertype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEORDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].AllPropertyDefs["TYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrderName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Materialtree
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fixedassetname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Stockcardclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProductionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRODUCTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["PRODUCTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Ownermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STAGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stagemilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STAGEMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Workshop
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Responsibleworkshopuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEWORKSHOPUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PlannedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PLANNEDTIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Rulobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RULOBJECTID"]);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Firstcheckdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTCHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Personnel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONNEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMaintenanceOrderByObjectIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceOrderByObjectIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceOrderByObjectIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetBrokenDownMaterialChaseReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public ReferTypeEnum? ReferType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REFERTYPE"].DataType;
                    return (ReferTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ArrivalTypeEnum? ArrivalType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALTYPE"].DataType;
                    return (ArrivalTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? Firstcheckdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTCHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public FirstExamResultEnum? FirstExamStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTEXAMSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["FIRSTEXAMSTATUS"].DataType;
                    return (FirstExamResultEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? Lastcheckdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PackagingDepSendingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGINGDEPSENDINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PACKAGINGDEPSENDINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PackagingDepReturnDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGINGDEPRETURNDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PACKAGINGDEPRETURNDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeviceSendingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICESENDINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DEVICESENDINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public ArrivalTypeEnum? Sendingtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDINGTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ARRIVALTYPE"].DataType;
                    return (ArrivalTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string RepairObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIROBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REPAIROBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBrokenDownMaterialChaseReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBrokenDownMaterialChaseReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBrokenDownMaterialChaseReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMonthlyRepairReportQuery_Class : TTReportNqlObject 
        {
            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public GetMonthlyRepairReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMonthlyRepairReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMonthlyRepairReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetCompletedGraphicReportQuery_Class : TTReportNqlObject 
        {
            public Object Startmonth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STARTMONTH"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetCompletedGraphicReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCompletedGraphicReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCompletedGraphicReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHEKGraphicReportQuery_Class : TTReportNqlObject 
        {
            public Object Startmonth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STARTMONTH"]);
                }
            }

            public Object Hekamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HEKAMOUNT"]);
                }
            }

            public GetHEKGraphicReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHEKGraphicReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHEKGraphicReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWorkshopNameQuery_Class : TTReportNqlObject 
        {
            public Guid? Workshopid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["WORKSHOPID"]);
                }
            }

            public string Workshop
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetWorkshopNameQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkshopNameQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkshopNameQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrderCommandReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string TypeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDERTYPE"].AllPropertyDefs["TYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? Firstcheckdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTCHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Materialtree
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Militaryforce
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYFORCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FORCESCOMMAND"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Resdivision
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESDIVISION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Section
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Responsibleuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PlannedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PLANNEDTIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? RepairWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REPAIRWORKLOAD"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Totallaborcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALLABORCOST"]);
                }
            }

            public GetOrderCommandReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrderCommandReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrderCommandReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMonthlyMaintenanceReportFromMaintenanceQuery_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetMonthlyMaintenanceReportFromMaintenanceQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMonthlyMaintenanceReportFromMaintenanceQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMonthlyMaintenanceReportFromMaintenanceQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaintenanceAndRepairRegistryByMSReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrderName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? TotalMaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALMATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["TOTALMATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? TotalWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["TOTALWORKLOAD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Work
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["WORK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Laborcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["LABORCOST"]);
                }
            }

            public Object Directmaterialexpense
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DIRECTMATERIALEXPENSE"]);
                }
            }

            public Object Depreciationexpense
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DEPRECIATIONEXPENSE"]);
                }
            }

            public Object Generalprocessingcost
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GENERALPROCESSINGCOST"]);
                }
            }

            public double? ManufacturingAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUFACTURINGAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["MANUFACTURINGAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Materialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Personnel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONNEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public string Ownermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OWNERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ReferTypeEnum? ReferType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REFERTYPE"].DataType;
                    return (ReferTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetMaintenanceAndRepairRegistryByMSReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceAndRepairRegistryByMSReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceAndRepairRegistryByMSReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHekReportMaintanenceOrder_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Sendersection
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERSECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Faultdescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Hekreportno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Section
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESHEADERSHIP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Repairnotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? Unitecost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITECOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PRICEOFUNITECOST"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public long? Workload
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REPAIRWORKLOAD"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public double? TotalMaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALMATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["TOTALMATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHekReportMaintanenceOrder_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHekReportMaintanenceOrder_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHekReportMaintanenceOrder_Class() : base() { }
        }

        [Serializable] 

        public partial class MaintenanceReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Result
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["RESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? StartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["STARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? EndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? RequestNoSeq
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNOSEQ"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTNOSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? SeqNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEQNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["SEQNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryToFirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYTOFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DELIVERYTOFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PlannedTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLANNEDTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PLANNEDTIME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OrderName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryFromFirmDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYFROMFIRMDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DELIVERYFROMFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? TotalWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["TOTALWORKLOAD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? TotalMaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALMATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["TOTALMATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public OrderStatusEnum? OrderStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERSTATUS"].DataType;
                    return (OrderStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public ReferTypeEnum? ReferType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REFERTYPE"].DataType;
                    return (ReferTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? OrderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string OrderNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DescriptionPart
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTIONPART"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DESCRIPTIONPART"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? PackagingDepSendingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGINGDEPSENDINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PACKAGINGDEPSENDINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PackagingDepReturnDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGINGDEPRETURNDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PACKAGINGDEPRETURNDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeviceSendingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICESENDINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["DEVICESENDINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? SpecialWorkAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALWORKAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["SPECIALWORKAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string PreventiveTreatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREVENTIVETREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PREVENTIVETREATMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? PreventiveTreatmentWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREVENTIVETREATMENTWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PREVENTIVETREATMENTWORKLOAD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Agenda
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AGENDA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["AGENDA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ArrivalTypeEnum? ArrivalType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ARRIVALTYPE"].DataType;
                    return (ArrivalTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? ManufacturingAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MANUFACTURINGAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["MANUFACTURINGAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public long? RepairWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["REPAIRWORKLOAD"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string PackagingDepartmentDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PACKAGINGDEPARTMENTDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PACKAGINGDEPARTMENTDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? PackagingDepActionID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PACKAGINGDEPACTIONID"]);
                }
            }

            public string ItemDetail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMDETAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ITEMDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ErrorReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ERRORREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["ERRORREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HEKDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["HEKDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? PriceOfUniteCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICEOFUNITECOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].AllPropertyDefs["PRICEOFUNITECOST"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public MaintenanceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaintenanceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaintenanceReportQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Sipariş Kapatma
    /// </summary>
            public static Guid OrderClose { get { return new Guid("7fc55213-d0f9-45a0-acea-0dcc14dd2d4f"); } }
    /// <summary>
    /// Dış Hizmet
    /// </summary>
            public static Guid Fieldwork { get { return new Guid("0f9cd982-f3e7-448e-bcd9-49865d117ce4"); } }
    /// <summary>
    /// Kalibrasyon
    /// </summary>
            public static Guid Calibration { get { return new Guid("969efae4-8940-432e-8500-5f0fcd0c891a"); } }
    /// <summary>
    /// HEK İşlemi
    /// </summary>
            public static Guid HEK { get { return new Guid("7a5fe495-c833-43f6-bf04-0642c2f3b909"); } }
    /// <summary>
    /// Son Kontrol
    /// </summary>
            public static Guid LastControl { get { return new Guid("a5845b5c-2ec9-44d8-9d29-56e57810a338"); } }
    /// <summary>
    /// Malzeme Temin
    /// </summary>
            public static Guid SupplyOfMaterial { get { return new Guid("71f2b44b-3b60-4d2c-8ad8-a5ab612ad34e"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("30b065b7-fc3f-4270-b253-b271209d3650"); } }
    /// <summary>
    /// Onarım
    /// </summary>
            public static Guid Repair { get { return new Guid("9d1f2e28-20cc-4773-b10d-d4e9f387f24a"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("038b6ef6-bd4c-43a5-9b0e-9bafc049198a"); } }
    /// <summary>
    /// İkmal Onay
    /// </summary>
            public static Guid SupplyApproval { get { return new Guid("780f37f7-5e08-4395-a497-81621095a8a2"); } }
    /// <summary>
    /// İş Hazırlama Kısım Amiri Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("1f4966e6-e480-464a-a308-7cb31afb2ee3"); } }
    /// <summary>
    /// Özel Çalışma
    /// </summary>
            public static Guid SpecialWork { get { return new Guid("5036a915-425d-46b3-b40e-67841683bc85"); } }
    /// <summary>
    /// Gönderme Kısmı
    /// </summary>
            public static Guid Dispatch { get { return new Guid("b82bb053-338b-4b85-8ed4-44c33cb1a193"); } }
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid NewOrder { get { return new Guid("37c66a35-4db9-4acb-97f2-da2825f96424"); } }
    /// <summary>
    /// Plan Koord.ve İş Haz.Bl.A. Onay
    /// </summary>
            public static Guid OrderApproval { get { return new Guid("fbedc608-4d87-4754-887a-b72b6fa88a98"); } }
    /// <summary>
    /// Teknik Müdür Onay
    /// </summary>
            public static Guid TechnicalDirectorApproval { get { return new Guid("2187dc6c-03f3-4bea-a275-230f1e430fe4"); } }
    /// <summary>
    /// İmalat
    /// </summary>
            public static Guid Manufacturing { get { return new Guid("a6561a5a-9ef0-415b-85a3-46778fb09d79"); } }
    /// <summary>
    /// Kısım Amiri Onay
    /// </summary>
            public static Guid DivisionSectionApproval { get { return new Guid("8efe5c75-4dbc-42aa-b063-575c48759484"); } }
    /// <summary>
    /// Bölüm Amiri Onay
    /// </summary>
            public static Guid DivisionChiefApproval { get { return new Guid("d70d4612-992c-4615-a483-896782c41063"); } }
    /// <summary>
    /// Son Kontrol
    /// </summary>
            public static Guid CalibrationLastControl { get { return new Guid("593d2b37-2173-4f93-ae02-f0ed4949d593"); } }
        }

        public static BindingList<MaintenanceOrder.MaintenanceOrderReportNQL_Class> MaintenanceOrderReportNQL(string ORDERNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["MaintenanceOrderReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERNO", ORDERNO);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.MaintenanceOrderReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.MaintenanceOrderReportNQL_Class> MaintenanceOrderReportNQL(TTObjectContext objectContext, string ORDERNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["MaintenanceOrderReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERNO", ORDERNO);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.MaintenanceOrderReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceOrderObjectIDQuery_Class> GetMaintenanceOrderObjectIDQuery(string REPAIROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceOrderObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPAIROBJECTID", REPAIROBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceOrderObjectIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceOrderObjectIDQuery_Class> GetMaintenanceOrderObjectIDQuery(TTObjectContext objectContext, string REPAIROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceOrderObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPAIROBJECTID", REPAIROBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceOrderObjectIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery_Class> GetProcessingDeviceAndHardwareReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetProcessingDeviceAndHardwareReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery_Class> GetProcessingDeviceAndHardwareReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetProcessingDeviceAndHardwareReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetProcessingDeviceAndHardwareReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetOrderChaseAndRegistryReportQuery_Class> GetOrderChaseAndRegistryReportQuery(string STARTDATE, string ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetOrderChaseAndRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetOrderChaseAndRegistryReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetOrderChaseAndRegistryReportQuery_Class> GetOrderChaseAndRegistryReportQuery(TTObjectContext objectContext, string STARTDATE, string ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetOrderChaseAndRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetOrderChaseAndRegistryReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery_Class> GetMaintenanceAndRepairRegistryReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceAndRepairRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery_Class> GetMaintenanceAndRepairRegistryReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceAndRepairRegistryReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceAndRepairRegistryReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetDirectMaterialCostsQuery_Class> GetDirectMaterialCostsQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetDirectMaterialCostsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetDirectMaterialCostsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetDirectMaterialCostsQuery_Class> GetDirectMaterialCostsQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetDirectMaterialCostsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetDirectMaterialCostsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery_Class> GetDirectMaterialCostsForWorkStepQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetDirectMaterialCostsForWorkStepQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery_Class> GetDirectMaterialCostsForWorkStepQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetDirectMaterialCostsForWorkStepQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetDirectMaterialCostsForWorkStepQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetConsumedMaterialsQuery_Class> GetConsumedMaterialsQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetConsumedMaterialsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetConsumedMaterialsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetConsumedMaterialsQuery_Class> GetConsumedMaterialsQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetConsumedMaterialsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetConsumedMaterialsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class> GetMaintenanceOrderCostByObjectIDQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceOrderCostByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class> GetMaintenanceOrderCostByObjectIDQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceOrderCostByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceOrderCostByObjectIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class> GetMaintenanceOrderByObjectIDQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceOrderByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class> GetMaintenanceOrderByObjectIDQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceOrderByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceOrderByObjectIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery_Class> GetBrokenDownMaterialChaseReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetBrokenDownMaterialChaseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery_Class> GetBrokenDownMaterialChaseReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetBrokenDownMaterialChaseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetBrokenDownMaterialChaseReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMonthlyRepairReportQuery_Class> GetMonthlyRepairReportQuery(Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMonthlyRepairReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMonthlyRepairReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaintenanceOrder.GetMonthlyRepairReportQuery_Class> GetMonthlyRepairReportQuery(TTObjectContext objectContext, Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMonthlyRepairReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMonthlyRepairReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaintenanceOrder.GetCompletedGraphicReportQuery_Class> GetCompletedGraphicReportQuery(int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetCompletedGraphicReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetCompletedGraphicReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetCompletedGraphicReportQuery_Class> GetCompletedGraphicReportQuery(TTObjectContext objectContext, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetCompletedGraphicReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetCompletedGraphicReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetHEKGraphicReportQuery_Class> GetHEKGraphicReportQuery(int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetHEKGraphicReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetHEKGraphicReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetHEKGraphicReportQuery_Class> GetHEKGraphicReportQuery(TTObjectContext objectContext, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetHEKGraphicReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetHEKGraphicReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetWorkshopNameQuery_Class> GetWorkshopNameQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetWorkshopNameQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetWorkshopNameQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetWorkshopNameQuery_Class> GetWorkshopNameQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetWorkshopNameQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetWorkshopNameQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetOrderCommandReportQuery_Class> GetOrderCommandReportQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetOrderCommandReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetOrderCommandReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetOrderCommandReportQuery_Class> GetOrderCommandReportQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetOrderCommandReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetOrderCommandReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder> GetHekFromMaintenanceQuery(TTObjectContext objectContext, Guid WORKSHOPID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetHekFromMaintenanceQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return ((ITTQuery)objectContext).QueryObjects<MaintenanceOrder>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<MaintenanceOrder.GetMonthlyMaintenanceReportFromMaintenanceQuery_Class> GetMonthlyMaintenanceReportFromMaintenanceQuery(Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMonthlyMaintenanceReportFromMaintenanceQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMonthlyMaintenanceReportFromMaintenanceQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaintenanceOrder.GetMonthlyMaintenanceReportFromMaintenanceQuery_Class> GetMonthlyMaintenanceReportFromMaintenanceQuery(TTObjectContext objectContext, Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMonthlyMaintenanceReportFromMaintenanceQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMonthlyMaintenanceReportFromMaintenanceQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaintenanceOrder> MaintenanceQuery(TTObjectContext objectContext, int DATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["MaintenanceQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return ((ITTQuery)objectContext).QueryObjects<MaintenanceOrder>(queryDef, paramList);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery_Class> GetMaintenanceAndRepairRegistryByMSReportQuery(Guid ORDERST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceAndRepairRegistryByMSReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERST", ORDERST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery_Class> GetMaintenanceAndRepairRegistryByMSReportQuery(TTObjectContext objectContext, Guid ORDERST, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetMaintenanceAndRepairRegistryByMSReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ORDERST", ORDERST);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetMaintenanceAndRepairRegistryByMSReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetHekReportMaintanenceOrder_Class> GetHekReportMaintanenceOrder(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetHekReportMaintanenceOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetHekReportMaintanenceOrder_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.GetHekReportMaintanenceOrder_Class> GetHekReportMaintanenceOrder(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["GetHekReportMaintanenceOrder"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.GetHekReportMaintanenceOrder_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.MaintenanceReportQuery_Class> MaintenanceReportQuery(int DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["MaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.MaintenanceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder.MaintenanceReportQuery_Class> MaintenanceReportQuery(TTObjectContext objectContext, int DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["MaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<MaintenanceOrder.MaintenanceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MaintenanceOrder> FabrikaHEKQuery(TTObjectContext objectContext, int YEAR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEORDER"].QueryDefs["FabrikaHEKQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return ((ITTQuery)objectContext).QueryObjects<MaintenanceOrder>(queryDef, paramList);
        }

        public TTSequence SeqNo
        {
            get { return GetSequence("SEQNO"); }
        }

    /// <summary>
    /// Cihazın Arıza Açıklaması
    /// </summary>
        public string DetailDescription
        {
            get { return (string)this["DETAILDESCRIPTION"]; }
            set { this["DETAILDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Firmaya Teslim Tarihi
    /// </summary>
        public DateTime? DeliveryToFirmDate
        {
            get { return (DateTime?)this["DELIVERYTOFIRMDATE"]; }
            set { this["DELIVERYTOFIRMDATE"] = value; }
        }

    /// <summary>
    /// Planlanan Zaman
    /// </summary>
        public string PlannedTime
        {
            get { return (string)this["PLANNEDTIME"]; }
            set { this["PLANNEDTIME"] = value; }
        }

    /// <summary>
    /// Siparişin Adı
    /// </summary>
        public string OrderName
        {
            get { return (string)this["ORDERNAME"]; }
            set { this["ORDERNAME"] = value; }
        }

    /// <summary>
    /// Muayene Tarihi
    /// </summary>
        public DateTime? CheckDate
        {
            get { return (DateTime?)this["CHECKDATE"]; }
            set { this["CHECKDATE"] = value; }
        }

    /// <summary>
    /// Firmadan Teslim Alındığı Tarih
    /// </summary>
        public DateTime? DeliveryFromFirmDate
        {
            get { return (DateTime?)this["DELIVERYFROMFIRMDATE"]; }
            set { this["DELIVERYFROMFIRMDATE"] = value; }
        }

    /// <summary>
    /// Sipariş İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// Toplam İşcilik Saati
    /// </summary>
        public double? TotalWorkLoad
        {
            get { return (double?)this["TOTALWORKLOAD"]; }
            set { this["TOTALWORKLOAD"] = value; }
        }

    /// <summary>
    /// Toplam Malzeme Maliyeti
    /// </summary>
        public double? TotalMaterialPrice
        {
            get { return (double?)this["TOTALMATERIALPRICE"]; }
            set { this["TOTALMATERIALPRICE"] = value; }
        }

    /// <summary>
    /// Sipariş Durumu
    /// </summary>
        public OrderStatusEnum? OrderStatus
        {
            get { return (OrderStatusEnum?)(int?)this["ORDERSTATUS"]; }
            set { this["ORDERSTATUS"] = value; }
        }

    /// <summary>
    /// Sevk Türü
    /// </summary>
        public ReferTypeEnum? ReferType
        {
            get { return (ReferTypeEnum?)(int?)this["REFERTYPE"]; }
            set { this["REFERTYPE"] = value; }
        }

    /// <summary>
    /// Sipariş Tarihi
    /// </summary>
        public DateTime? OrderDate
        {
            get { return (DateTime?)this["ORDERDATE"]; }
            set { this["ORDERDATE"] = value; }
        }

    /// <summary>
    /// Sipariş No
    /// </summary>
        public string OrderNO
        {
            get { return (string)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Açıklama Alanı
    /// </summary>
        public string DescriptionPart
        {
            get { return (string)this["DESCRIPTIONPART"]; }
            set { this["DESCRIPTIONPART"] = value; }
        }

    /// <summary>
    /// Ambalaşlamaya Gönderilme Tarihi
    /// </summary>
        public DateTime? PackagingDepSendingDate
        {
            get { return (DateTime?)this["PACKAGINGDEPSENDINGDATE"]; }
            set { this["PACKAGINGDEPSENDINGDATE"] = value; }
        }

    /// <summary>
    /// Ambalaşmadan Geliş Tarihi
    /// </summary>
        public DateTime? PackagingDepReturnDate
        {
            get { return (DateTime?)this["PACKAGINGDEPRETURNDATE"]; }
            set { this["PACKAGINGDEPRETURNDATE"] = value; }
        }

    /// <summary>
    /// Cihazın Gidiş Tarihi
    /// </summary>
        public DateTime? DeviceSendingDate
        {
            get { return (DateTime?)this["DEVICESENDINGDATE"]; }
            set { this["DEVICESENDINGDATE"] = value; }
        }

    /// <summary>
    /// ReportNo
    /// </summary>
        public string ReportNo
        {
            get { return (string)this["REPORTNO"]; }
            set { this["REPORTNO"] = value; }
        }

    /// <summary>
    /// Özel Çalışma Miktarı
    /// </summary>
        public double? SpecialWorkAmount
        {
            get { return (double?)this["SPECIALWORKAMOUNT"]; }
            set { this["SPECIALWORKAMOUNT"] = value; }
        }

    /// <summary>
    /// Yapılan Düzeltici İşlem
    /// </summary>
        public string PreventiveTreatment
        {
            get { return (string)this["PREVENTIVETREATMENT"]; }
            set { this["PREVENTIVETREATMENT"] = value; }
        }

    /// <summary>
    /// Düzeltici İşleme Harcanan Zaman
    /// </summary>
        public double? PreventiveTreatmentWorkLoad
        {
            get { return (double?)this["PREVENTIVETREATMENTWORKLOAD"]; }
            set { this["PREVENTIVETREATMENTWORKLOAD"] = value; }
        }

    /// <summary>
    /// Yapılacak Düzeltmeler
    /// </summary>
        public string Agenda
        {
            get { return (string)this["AGENDA"]; }
            set { this["AGENDA"] = value; }
        }

    /// <summary>
    /// Cihazın Gidiş Şekli
    /// </summary>
        public ArrivalTypeEnum? ArrivalType
        {
            get { return (ArrivalTypeEnum?)(int?)this["ARRIVALTYPE"]; }
            set { this["ARRIVALTYPE"] = value; }
        }

    /// <summary>
    /// İmalat Miktarı
    /// </summary>
        public double? ManufacturingAmount
        {
            get { return (double?)this["MANUFACTURINGAMOUNT"]; }
            set { this["MANUFACTURINGAMOUNT"] = value; }
        }

    /// <summary>
    /// Onarım İş Yükü
    /// </summary>
        public long? RepairWorkLoad
        {
            get { return (long?)this["REPAIRWORKLOAD"]; }
            set { this["REPAIRWORKLOAD"] = value; }
        }

    /// <summary>
    /// Ambalajlama İş İstek Açıklama
    /// </summary>
        public string PackagingDepartmentDesc
        {
            get { return (string)this["PACKAGINGDEPARTMENTDESC"]; }
            set { this["PACKAGINGDEPARTMENTDESC"] = value; }
        }

        public Guid? PackagingDepActionID
        {
            get { return (Guid?)this["PACKAGINGDEPACTIONID"]; }
            set { this["PACKAGINGDEPACTIONID"] = value; }
        }

    /// <summary>
    /// Muhteviyat Açıklaması
    /// </summary>
        public string ItemDetail
        {
            get { return (string)this["ITEMDETAIL"]; }
            set { this["ITEMDETAIL"] = value; }
        }

    /// <summary>
    /// Muhtemel Hata Nedeni ve Öneriler
    /// </summary>
        public string ErrorReason
        {
            get { return (string)this["ERRORREASON"]; }
            set { this["ERRORREASON"] = value; }
        }

    /// <summary>
    /// HEK Raporu
    /// </summary>
        public string HEKDescription
        {
            get { return (string)this["HEKDESCRIPTION"]; }
            set { this["HEKDESCRIPTION"] = value; }
        }

    /// <summary>
    /// İşçilik Birim Maliyeti
    /// </summary>
        public Currency? PriceOfUniteCost
        {
            get { return (Currency?)this["PRICEOFUNITECOST"]; }
            set { this["PRICEOFUNITECOST"] = value; }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceOrderType MaintenanceOrderSubType
        {
            get { return (MaintenanceOrderType)((ITTObject)this).GetParent("MAINTENANCEORDERSUBTYPE"); }
            set { this["MAINTENANCEORDERSUBTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceOrderType MaintenanceOrderType
        {
            get { return (MaintenanceOrderType)((ITTObject)this).GetParent("MAINTENANCEORDERTYPE"); }
            set { this["MAINTENANCEORDERTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReferToUpperLevel RelatedReferToUpperLevel
        {
            get { return (ReferToUpperLevel)((ITTObject)this).GetParent("RELATEDREFERTOUPPERLEVEL"); }
            set { this["RELATEDREFERTOUPPERLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResDivision PackagingDepartment
        {
            get { return (ResDivision)((ITTObject)this).GetParent("PACKAGINGDEPARTMENT"); }
            set { this["PACKAGINGDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMaintenanceOrderCostsCollection()
        {
            _MaintenanceOrderCosts = new MaintenanceOrderCost.ChildMaintenanceOrderCostCollection(this, new Guid("05777990-2f2b-4617-9a7d-26ed4a722c54"));
            ((ITTChildObjectCollection)_MaintenanceOrderCosts).GetChildren();
        }

        protected MaintenanceOrderCost.ChildMaintenanceOrderCostCollection _MaintenanceOrderCosts = null;
        public MaintenanceOrderCost.ChildMaintenanceOrderCostCollection MaintenanceOrderCosts
        {
            get
            {
                if (_MaintenanceOrderCosts == null)
                    CreateMaintenanceOrderCostsCollection();
                return _MaintenanceOrderCosts;
            }
        }

        virtual protected void CreateWorkStepsCollection()
        {
            _WorkSteps = new WorkStep.ChildWorkStepCollection(this, new Guid("40e85eb0-a6f4-4a01-8b79-2a157334c9ba"));
            ((ITTChildObjectCollection)_WorkSteps).GetChildren();
        }

        protected WorkStep.ChildWorkStepCollection _WorkSteps = null;
        public WorkStep.ChildWorkStepCollection WorkSteps
        {
            get
            {
                if (_WorkSteps == null)
                    CreateWorkStepsCollection();
                return _WorkSteps;
            }
        }

        virtual protected void CreateMaintenance_ConsumedMaterialsCollection()
        {
            _Maintenance_ConsumedMaterials = new Maintenance_ConsumedMaterial.ChildMaintenance_ConsumedMaterialCollection(this, new Guid("461e0e1f-110b-48db-9dd9-6434093d16df"));
            ((ITTChildObjectCollection)_Maintenance_ConsumedMaterials).GetChildren();
        }

        protected Maintenance_ConsumedMaterial.ChildMaintenance_ConsumedMaterialCollection _Maintenance_ConsumedMaterials = null;
        public Maintenance_ConsumedMaterial.ChildMaintenance_ConsumedMaterialCollection Maintenance_ConsumedMaterials
        {
            get
            {
                if (_Maintenance_ConsumedMaterials == null)
                    CreateMaintenance_ConsumedMaterialsCollection();
                return _Maintenance_ConsumedMaterials;
            }
        }

        virtual protected void CreateHEKCommisionMembersCollection()
        {
            _HEKCommisionMembers = new MaintenanceHEKCommisionMember.ChildMaintenanceHEKCommisionMemberCollection(this, new Guid("b5105074-d688-415e-b1f2-a89df693d92c"));
            ((ITTChildObjectCollection)_HEKCommisionMembers).GetChildren();
        }

        protected MaintenanceHEKCommisionMember.ChildMaintenanceHEKCommisionMemberCollection _HEKCommisionMembers = null;
        public MaintenanceHEKCommisionMember.ChildMaintenanceHEKCommisionMemberCollection HEKCommisionMembers
        {
            get
            {
                if (_HEKCommisionMembers == null)
                    CreateHEKCommisionMembersCollection();
                return _HEKCommisionMembers;
            }
        }

        virtual protected void CreateUsedConsumedMaterailsCollection()
        {
            _UsedConsumedMaterails = new UsedConsumedMaterail.ChildUsedConsumedMaterailCollection(this, new Guid("9b3a81c8-97cf-488c-a99e-4c26ad268197"));
            ((ITTChildObjectCollection)_UsedConsumedMaterails).GetChildren();
        }

        protected UsedConsumedMaterail.ChildUsedConsumedMaterailCollection _UsedConsumedMaterails = null;
        public UsedConsumedMaterail.ChildUsedConsumedMaterailCollection UsedConsumedMaterails
        {
            get
            {
                if (_UsedConsumedMaterails == null)
                    CreateUsedConsumedMaterailsCollection();
                return _UsedConsumedMaterails;
            }
        }

        virtual protected void CreateUsedMaterialWorkStepsCollection()
        {
            _UsedMaterialWorkSteps = new UsedMaterialWorkStep.ChildUsedMaterialWorkStepCollection(this, new Guid("1251c05a-ee56-4143-a4a0-c81ad846728e"));
            ((ITTChildObjectCollection)_UsedMaterialWorkSteps).GetChildren();
        }

        protected UsedMaterialWorkStep.ChildUsedMaterialWorkStepCollection _UsedMaterialWorkSteps = null;
        public UsedMaterialWorkStep.ChildUsedMaterialWorkStepCollection UsedMaterialWorkSteps
        {
            get
            {
                if (_UsedMaterialWorkSteps == null)
                    CreateUsedMaterialWorkStepsCollection();
                return _UsedMaterialWorkSteps;
            }
        }

        virtual protected void CreateServiceProcurementSignDetailsCollection()
        {
            _ServiceProcurementSignDetails = new CMRActionSignDetail.ChildCMRActionSignDetailCollection(this, new Guid("e794e70b-ba9b-405e-a7a2-6d9378cff051"));
            ((ITTChildObjectCollection)_ServiceProcurementSignDetails).GetChildren();
        }

        protected CMRActionSignDetail.ChildCMRActionSignDetailCollection _ServiceProcurementSignDetails = null;
        public CMRActionSignDetail.ChildCMRActionSignDetailCollection ServiceProcurementSignDetails
        {
            get
            {
                if (_ServiceProcurementSignDetails == null)
                    CreateServiceProcurementSignDetailsCollection();
                return _ServiceProcurementSignDetails;
            }
        }

        virtual protected void CreateFaalMalzemeImzaCollection()
        {
            _FaalMalzemeImza = new CMRActionSignDetail.ChildCMRActionSignDetailCollection(this, new Guid("4e1dcc32-3e1f-42a1-8589-60175a83e2e2"));
            ((ITTChildObjectCollection)_FaalMalzemeImza).GetChildren();
        }

        protected CMRActionSignDetail.ChildCMRActionSignDetailCollection _FaalMalzemeImza = null;
        public CMRActionSignDetail.ChildCMRActionSignDetailCollection FaalMalzemeImza
        {
            get
            {
                if (_FaalMalzemeImza == null)
                    CreateFaalMalzemeImzaCollection();
                return _FaalMalzemeImza;
            }
        }

        virtual protected void CreateMaintanenceOrderHEKReasonsCollection()
        {
            _MaintanenceOrderHEKReasons = new MaintanenceOrderHEKReasons.ChildMaintanenceOrderHEKReasonsCollection(this, new Guid("e51e34e1-f65c-43de-ba01-e0636cc4f7cb"));
            ((ITTChildObjectCollection)_MaintanenceOrderHEKReasons).GetChildren();
        }

        protected MaintanenceOrderHEKReasons.ChildMaintanenceOrderHEKReasonsCollection _MaintanenceOrderHEKReasons = null;
    /// <summary>
    /// Child collection for MaintenanceOrder
    /// </summary>
        public MaintanenceOrderHEKReasons.ChildMaintanenceOrderHEKReasonsCollection MaintanenceOrderHEKReasons
        {
            get
            {
                if (_MaintanenceOrderHEKReasons == null)
                    CreateMaintanenceOrderHEKReasonsCollection();
                return _MaintanenceOrderHEKReasons;
            }
        }

        virtual protected void CreateNeededMaterialsCollection()
        {
            _NeededMaterials = new NeededMaterials.ChildNeededMaterialsCollection(this, new Guid("9f027e29-3f19-48e3-9916-d9e9b6c8305f"));
            ((ITTChildObjectCollection)_NeededMaterials).GetChildren();
        }

        protected NeededMaterials.ChildNeededMaterialsCollection _NeededMaterials = null;
        public NeededMaterials.ChildNeededMaterialsCollection NeededMaterials
        {
            get
            {
                if (_NeededMaterials == null)
                    CreateNeededMaterialsCollection();
                return _NeededMaterials;
            }
        }

        protected MaintenanceOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenanceOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenanceOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenanceOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenanceOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEORDER", dataRow) { }
        protected MaintenanceOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEORDER", dataRow, isImported) { }
        public MaintenanceOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenanceOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenanceOrder() : base() { }

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