
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Repair")] 

    /// <summary>
    /// Onarım
    /// </summary>
    public  partial class Repair : CMRAction
    {
        public class RepairList : TTObjectCollection<Repair> { }
                    
        public class ChildRepairCollection : TTObject.TTChildObjectCollection<Repair>
        {
            public ChildRepairCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRepairCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RepairReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Famname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMNAME"]);
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

            public string Deviceuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICEUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MaintenancePeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["MAINTENANCEPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Repairmilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
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

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RepairReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RepairReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RepairReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class RepairDetailReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Famname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMNAME"]);
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

            public int? MaintenancePeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["MAINTENANCEPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string Deviceuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICEUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Repairmilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public RepairDetailReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RepairDetailReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RepairDetailReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRepairForUsedMaterial_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Famname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMNAME"]);
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

            public FixedAssetCMRStatusEnum? CMRStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CMRSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["CMRSTATUS"].DataType;
                    return (FixedAssetCMRStatusEnum?)(int)dataType.ConvertValue(val);
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

            public int? MaintenancePeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["MAINTENANCEPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string Deviceuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICEUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Repairmilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Requestno1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? SenderSection
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SENDERSECTION"]);
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

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Usedmaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDMATERIAL"]);
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

            public Guid? Responsibleuserid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESPONSIBLEUSERID"]);
                }
            }

            public GetRepairForUsedMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRepairForUsedMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRepairForUsedMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnitMaintenanceReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public int? MaintenancePeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAINTENANCEPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["MAINTENANCEPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string Parameter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARAMETER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEPARAMETERDEFINITION"].AllPropertyDefs["PARAMETER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Deviceuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICEUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public GetUnitMaintenanceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnitMaintenanceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnitMaintenanceReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHEKListFromRepairQuery_Class : TTReportNqlObject 
        {
            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Hekamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["HEKAMOUNT"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetHEKListFromRepairQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHEKListFromRepairQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHEKListFromRepairQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRepairItemEquipmentsQuery_Class : TTReportNqlObject 
        {
            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNormal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNORMAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISNORMAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsDamaged
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDAMAGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISDAMAGED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsChanged
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCHANGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISCHANGED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMissing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMISSING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR_ITEMEQUIPMENT"].AllPropertyDefs["ISMISSING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetRepairItemEquipmentsQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRepairItemEquipmentsQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRepairItemEquipmentsQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class : TTReportNqlObject 
        {
            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVERYDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Usedmaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMonthlyRepairReportFromRepairQuery_Class : TTReportNqlObject 
        {
            public Object Total
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTAL"]);
                }
            }

            public GetMonthlyRepairReportFromRepairQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMonthlyRepairReportFromRepairQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMonthlyRepairReportFromRepairQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMaintenanceAndRepairRegistryCardReportQuery_Class : TTReportNqlObject 
        {
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

            public string Famname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMNAME"]);
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

            public string Voltage
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOLTAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["VOLTAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? GuarantyEndDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYENDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["GUARANTYENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVERYDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ENDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Usedmaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
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

            public GetMaintenanceAndRepairRegistryCardReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMaintenanceAndRepairRegistryCardReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMaintenanceAndRepairRegistryCardReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActualDeliveryDate_Class : TTReportNqlObject 
        {
            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActualDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTUALDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ACTUALDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetActualDeliveryDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActualDeliveryDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActualDeliveryDate_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRepairForUsedMaterialCount_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public GetRepairForUsedMaterialCount_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRepairForUsedMaterialCount_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRepairForUsedMaterialCount_Class() : base() { }
        }

        [Serializable] 

        public partial class RepairHEKReportQuery_Class : TTReportNqlObject 
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

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["MATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? LaborTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABORTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["LABORTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? RepairTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
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

            public string HEKReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RepairNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRNOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HEKReportRepairDetail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTREPAIRDETAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTREPAIRDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RepairHEKReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RepairHEKReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RepairHEKReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHEKReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string HEKReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Famname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMNAME"]);
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

            public string Deviceuser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEVICEUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RULObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["RULOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHEKReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHEKReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHEKReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetHEKCountRQ_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["RESULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNOSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeliveredPerson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVEREDPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVEREDPERSON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RULObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["RULOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RepairNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRNOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVERYTOFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string UserTel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["USERTEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string StateIDBeforeLastControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEIDBEFORELASTCONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["STATEIDBEFORELASTCONTROL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActualDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTUALDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ACTUALDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReceiveDateFromFirm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVEDATEFROMFIRM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["RECEIVEDATEFROMFIRM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public RepairPlaceEnum? RepairPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRPLACE"].DataType;
                    return (RepairPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? TotalWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["TOTALWORKLOAD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitWorkLoadPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITWORKLOADPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["UNITWORKLOADPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? RepairTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["MATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? LaborTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABORTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["LABORTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportRepairDetail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTREPAIRDETAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTREPAIRDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPurchasePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPURCHASEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["MATERIALPURCHASEPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string LastControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["LASTCONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetHEKCountRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHEKCountRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHEKCountRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class ConsumableReversePartReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Famname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMNAME"]);
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

            public Guid? Store
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["STORE"]);
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

            public ConsumableReversePartReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsumableReversePartReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsumableReversePartReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class ConsumableReversePartReportQueryNew_Class : TTReportNqlObject 
        {
            public string Usedmaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDMATERIAL"]);
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

            public ConsumableReversePartReportQueryNew_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ConsumableReversePartReportQueryNew_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ConsumableReversePartReportQueryNew_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNormalListFromRepairQuery_Class : TTReportNqlObject 
        {
            public Object Month
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["MONTH"]);
                }
            }

            public Object Normalamount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NORMALAMOUNT"]);
                }
            }

            public GetNormalListFromRepairQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNormalListFromRepairQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNormalListFromRepairQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetWorkshopNameFromRepairQuery_Class : TTReportNqlObject 
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

            public GetWorkshopNameFromRepairQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkshopNameFromRepairQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkshopNameFromRepairQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class HekRepairQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ACTIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REASONOFCANCEL"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["WORKLISTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REASONOFREJECT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["OLAPDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["WORKLISTDESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ISOLDACTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["RESULT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["STARTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTNOSEQ"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DeliveredPerson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVEREDPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVEREDPERSON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RULObjectID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RULOBJECTID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["RULOBJECTID"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RepairNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRNOTES"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVERYTOFIRMDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string UserTel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERTEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["USERTEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string StateIDBeforeLastControl
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATEIDBEFORELASTCONTROL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["STATEIDBEFORELASTCONTROL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string DetailDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DETAILDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["DETAILDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActualDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTUALDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["ACTUALDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PreControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRECONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["PRECONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ReceiveDateFromFirm
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECEIVEDATEFROMFIRM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["RECEIVEDATEFROMFIRM"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public RepairPlaceEnum? RepairPlace
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRPLACE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRPLACE"].DataType;
                    return (RepairPlaceEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? TotalWorkLoad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALWORKLOAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["TOTALWORKLOAD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UnitWorkLoadPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITWORKLOADPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["UNITWORKLOADPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? RepairTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIRTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["REPAIRTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["MATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? LaborTotalCost
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LABORTOTALCOST"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["LABORTOTALCOST"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string HEKReportRepairDetail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKREPORTREPAIRDETAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["HEKREPORTREPAIRDETAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPurchasePrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPURCHASEPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["MATERIALPURCHASEPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string LastControlNotes
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCONTROLNOTES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].AllPropertyDefs["LASTCONTROLNOTES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public HekRepairQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HekRepairQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HekRepairQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Comleted { get { return new Guid("7e31be81-0c29-401a-90ba-4957a2eb845b"); } }
    /// <summary>
    /// Teslim Tesellüm
    /// </summary>
            public static Guid Delivery { get { return new Guid("67392f87-218b-4e03-98c9-5a53bc8594e1"); } }
    /// <summary>
    /// Onarım
    /// </summary>
            public static Guid Repair { get { return new Guid("3c0dbf63-c1d4-42ed-8edc-3d80c73facec"); } }
    /// <summary>
    /// Ön Kontrol
    /// </summary>
            public static Guid PreControl { get { return new Guid("41262719-0387-4a18-86ea-b2e0a5acc3da"); } }
    /// <summary>
    /// Malzeme Temin
    /// </summary>
            public static Guid Supply_Of_Materials { get { return new Guid("5d56dd7c-ad00-40a1-bd90-7b9c92f373a2"); } }
    /// <summary>
    /// Firma Onarımı
    /// </summary>
            public static Guid FirmRepair { get { return new Guid("783357cf-70e8-4c3b-91e4-7bcd14ccdf54"); } }
    /// <summary>
    /// HEK'e Ayırma
    /// </summary>
            public static Guid HEK { get { return new Guid("3afb41ab-805b-4277-83dc-e5793b6407f4"); } }
    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
            public static Guid UpperStage { get { return new Guid("7a8f47cd-3d4c-4d0e-b8b2-d48aa3d2baec"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("f121a366-4e43-4c89-adac-b7966dc0e5f4"); } }
    /// <summary>
    /// Garanti Onarımı
    /// </summary>
            public static Guid GuarantyRepair { get { return new Guid("b3f598c9-16b7-432a-bd8b-926eb20fc6c2"); } }
    /// <summary>
    /// Seyyar Ekip
    /// </summary>
            public static Guid MobileTeam { get { return new Guid("e4eb2762-c686-4f8f-a6e1-c21eb9573495"); } }
    /// <summary>
    /// Son Kontrol
    /// </summary>
            public static Guid LastControl { get { return new Guid("8c772aaf-0817-4f10-876d-d87f24ab609e"); } }
        }

        public static BindingList<Repair.RepairReportNQL_Class> RepairReportNQL(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["RepairReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.RepairReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.RepairReportNQL_Class> RepairReportNQL(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["RepairReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.RepairReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.RepairDetailReportNQL_Class> RepairDetailReportNQL(string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["RepairDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<Repair.RepairDetailReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.RepairDetailReportNQL_Class> RepairDetailReportNQL(TTObjectContext objectContext, string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["RepairDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<Repair.RepairDetailReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetRepairForUsedMaterial_Class> GetRepairForUsedMaterial(DateTime STARTDATE, DateTime ENDDATE, Guid RESPONSIBLEUSERID, Guid SENDERSECTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetRepairForUsedMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESPONSIBLEUSERID", RESPONSIBLEUSERID);
            paramList.Add("SENDERSECTIONID", SENDERSECTIONID);

            return TTReportNqlObject.QueryObjects<Repair.GetRepairForUsedMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetRepairForUsedMaterial_Class> GetRepairForUsedMaterial(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid RESPONSIBLEUSERID, Guid SENDERSECTIONID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetRepairForUsedMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESPONSIBLEUSERID", RESPONSIBLEUSERID);
            paramList.Add("SENDERSECTIONID", SENDERSECTIONID);

            return TTReportNqlObject.QueryObjects<Repair.GetRepairForUsedMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetUnitMaintenanceReportQuery_Class> GetUnitMaintenanceReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetUnitMaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.GetUnitMaintenanceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetUnitMaintenanceReportQuery_Class> GetUnitMaintenanceReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetUnitMaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.GetUnitMaintenanceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetHEKListFromRepairQuery_Class> GetHEKListFromRepairQuery(int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHEKListFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<Repair.GetHEKListFromRepairQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetHEKListFromRepairQuery_Class> GetHEKListFromRepairQuery(TTObjectContext objectContext, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHEKListFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<Repair.GetHEKListFromRepairQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetRepairItemEquipmentsQuery_Class> GetRepairItemEquipmentsQuery(string REPAIROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetRepairItemEquipmentsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPAIROBJECTID", REPAIROBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.GetRepairItemEquipmentsQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetRepairItemEquipmentsQuery_Class> GetRepairItemEquipmentsQuery(TTObjectContext objectContext, string REPAIROBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetRepairItemEquipmentsQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPAIROBJECTID", REPAIROBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.GetRepairItemEquipmentsQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class> GetMaintenanceAndRepairRegistryCardReportQueryNEW(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetMaintenanceAndRepairRegistryCardReportQueryNEW"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class> GetMaintenanceAndRepairRegistryCardReportQueryNEW(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetMaintenanceAndRepairRegistryCardReportQueryNEW"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.GetMaintenanceAndRepairRegistryCardReportQueryNEW_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetMonthlyRepairReportFromRepairQuery_Class> GetMonthlyRepairReportFromRepairQuery(Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetMonthlyRepairReportFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<Repair.GetMonthlyRepairReportFromRepairQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Repair.GetMonthlyRepairReportFromRepairQuery_Class> GetMonthlyRepairReportFromRepairQuery(TTObjectContext objectContext, Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetMonthlyRepairReportFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<Repair.GetMonthlyRepairReportFromRepairQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Bakım Onlarım Sicil Kartı Query
    /// </summary>
        public static BindingList<Repair.GetMaintenanceAndRepairRegistryCardReportQuery_Class> GetMaintenanceAndRepairRegistryCardReportQuery(Guid TTOBJECTID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetMaintenanceAndRepairRegistryCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<Repair.GetMaintenanceAndRepairRegistryCardReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Bakım Onlarım Sicil Kartı Query
    /// </summary>
        public static BindingList<Repair.GetMaintenanceAndRepairRegistryCardReportQuery_Class> GetMaintenanceAndRepairRegistryCardReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetMaintenanceAndRepairRegistryCardReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<Repair.GetMaintenanceAndRepairRegistryCardReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair> GetHEKListQuery(TTObjectContext objectContext, int YEAR)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHEKListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return ((ITTQuery)objectContext).QueryObjects<Repair>(queryDef, paramList);
        }

        public static BindingList<Repair.GetActualDeliveryDate_Class> GetActualDeliveryDate(string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetActualDeliveryDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<Repair.GetActualDeliveryDate_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetActualDeliveryDate_Class> GetActualDeliveryDate(TTObjectContext objectContext, string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetActualDeliveryDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<Repair.GetActualDeliveryDate_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetRepairForUsedMaterialCount_Class> GetRepairForUsedMaterialCount(DateTime ENDDATE, Guid RESPONSIBLEUSERID, Guid SENDERSECTIONID, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetRepairForUsedMaterialCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESPONSIBLEUSERID", RESPONSIBLEUSERID);
            paramList.Add("SENDERSECTIONID", SENDERSECTIONID);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<Repair.GetRepairForUsedMaterialCount_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetRepairForUsedMaterialCount_Class> GetRepairForUsedMaterialCount(TTObjectContext objectContext, DateTime ENDDATE, Guid RESPONSIBLEUSERID, Guid SENDERSECTIONID, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetRepairForUsedMaterialCount"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("RESPONSIBLEUSERID", RESPONSIBLEUSERID);
            paramList.Add("SENDERSECTIONID", SENDERSECTIONID);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<Repair.GetRepairForUsedMaterialCount_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.RepairHEKReportQuery_Class> RepairHEKReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["RepairHEKReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.RepairHEKReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.RepairHEKReportQuery_Class> RepairHEKReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["RepairHEKReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<Repair.RepairHEKReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetHEKReportQuery_Class> GetHEKReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid SENDERSECTION, Guid PERSONNEL, int PERSONFLAG, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHEKReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SENDERSECTION", SENDERSECTION);
            paramList.Add("PERSONNEL", PERSONNEL);
            paramList.Add("PERSONFLAG", PERSONFLAG);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<Repair.GetHEKReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetHEKReportQuery_Class> GetHEKReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid SENDERSECTION, Guid PERSONNEL, int PERSONFLAG, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHEKReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("SENDERSECTION", SENDERSECTION);
            paramList.Add("PERSONNEL", PERSONNEL);
            paramList.Add("PERSONFLAG", PERSONFLAG);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<Repair.GetHEKReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetHEKCountRQ_Class> GetHEKCountRQ(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHEKCountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Repair.GetHEKCountRQ_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetHEKCountRQ_Class> GetHEKCountRQ(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHEKCountRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<Repair.GetHEKCountRQ_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.ConsumableReversePartReportQuery_Class> ConsumableReversePartReportQuery(Guid STORE, DateTime STARTDATE, DateTime ENDDATE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["ConsumableReversePartReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<Repair.ConsumableReversePartReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.ConsumableReversePartReportQuery_Class> ConsumableReversePartReportQuery(TTObjectContext objectContext, Guid STORE, DateTime STARTDATE, DateTime ENDDATE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["ConsumableReversePartReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<Repair.ConsumableReversePartReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.ConsumableReversePartReportQueryNew_Class> ConsumableReversePartReportQueryNew(string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["ConsumableReversePartReportQueryNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<Repair.ConsumableReversePartReportQueryNew_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.ConsumableReversePartReportQueryNew_Class> ConsumableReversePartReportQueryNew(TTObjectContext objectContext, string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["ConsumableReversePartReportQueryNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<Repair.ConsumableReversePartReportQueryNew_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetNormalListFromRepairQuery_Class> GetNormalListFromRepairQuery(int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetNormalListFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<Repair.GetNormalListFromRepairQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetNormalListFromRepairQuery_Class> GetNormalListFromRepairQuery(TTObjectContext objectContext, int YEAR, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetNormalListFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("YEAR", YEAR);

            return TTReportNqlObject.QueryObjects<Repair.GetNormalListFromRepairQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetWorkshopNameFromRepairQuery_Class> GetWorkshopNameFromRepairQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetWorkshopNameFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Repair.GetWorkshopNameFromRepairQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Repair.GetWorkshopNameFromRepairQuery_Class> GetWorkshopNameFromRepairQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetWorkshopNameFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Repair.GetWorkshopNameFromRepairQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Repair.HekRepairQuery_Class> HekRepairQuery(Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["HekRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<Repair.HekRepairQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Repair.HekRepairQuery_Class> HekRepairQuery(TTObjectContext objectContext, Guid WORKSHOPID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["HekRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return TTReportNqlObject.QueryObjects<Repair.HekRepairQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Repair> GetHekFromRepairQuery(TTObjectContext objectContext, Guid WORKSHOPID, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REPAIR"].QueryDefs["GetHekFromRepairQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("WORKSHOPID", WORKSHOPID);

            return ((ITTQuery)objectContext).QueryObjects<Repair>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// HEK Raporu Açıklaması
    /// </summary>
        public string HEKReportDescription
        {
            get { return (string)this["HEKREPORTDESCRIPTION"]; }
            set { this["HEKREPORTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Teslim Alan
    /// </summary>
        public string DeliveredPerson
        {
            get { return (string)this["DELIVEREDPERSON"]; }
            set { this["DELIVEREDPERSON"] = value; }
        }

        public string RULObjectID
        {
            get { return (string)this["RULOBJECTID"]; }
            set { this["RULOBJECTID"] = value; }
        }

    /// <summary>
    /// Onarım Notları
    /// </summary>
        public string RepairNotes
        {
            get { return (string)this["REPAIRNOTES"]; }
            set { this["REPAIRNOTES"] = value; }
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
    /// Personel Tel No
    /// </summary>
        public string UserTel
        {
            get { return (string)this["USERTEL"]; }
            set { this["USERTEL"] = value; }
        }

    /// <summary>
    /// Teslim Tarihi
    /// </summary>
        public DateTime? DeliveryDate
        {
            get { return (DateTime?)this["DELIVERYDATE"]; }
            set { this["DELIVERYDATE"] = value; }
        }

    /// <summary>
    /// Son Kontrolden Önceki State ID
    /// </summary>
        public string StateIDBeforeLastControl
        {
            get { return (string)this["STATEIDBEFORELASTCONTROL"]; }
            set { this["STATEIDBEFORELASTCONTROL"] = value; }
        }

    /// <summary>
    /// Hizmet Alım Açıklaması
    /// </summary>
        public string DetailDescription
        {
            get { return (string)this["DETAILDESCRIPTION"]; }
            set { this["DETAILDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Gerçekleşen Teslim Tarihi
    /// </summary>
        public DateTime? ActualDeliveryDate
        {
            get { return (DateTime?)this["ACTUALDELIVERYDATE"]; }
            set { this["ACTUALDELIVERYDATE"] = value; }
        }

    /// <summary>
    /// Ön Kontrol Notları
    /// </summary>
        public string PreControlNotes
        {
            get { return (string)this["PRECONTROLNOTES"]; }
            set { this["PRECONTROLNOTES"] = value; }
        }

    /// <summary>
    /// Firmadan Tesellüm Tarihi
    /// </summary>
        public DateTime? ReceiveDateFromFirm
        {
            get { return (DateTime?)this["RECEIVEDATEFROMFIRM"]; }
            set { this["RECEIVEDATEFROMFIRM"] = value; }
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// Onarım Yeri
    /// </summary>
        public RepairPlaceEnum? RepairPlace
        {
            get { return (RepairPlaceEnum?)(int?)this["REPAIRPLACE"]; }
            set { this["REPAIRPLACE"] = value; }
        }

    /// <summary>
    /// Cihazın Arızası
    /// </summary>
        public string FaultDescription
        {
            get { return (string)this["FAULTDESCRIPTION"]; }
            set { this["FAULTDESCRIPTION"] = value; }
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
    /// İşcilik Saat Ücreti
    /// </summary>
        public double? UnitWorkLoadPrice
        {
            get { return (double?)this["UNITWORKLOADPRICE"]; }
            set { this["UNITWORKLOADPRICE"] = value; }
        }

    /// <summary>
    /// Onarım Toplam Maliyeti
    /// </summary>
        public double? RepairTotalCost
        {
            get { return (double?)this["REPAIRTOTALCOST"]; }
            set { this["REPAIRTOTALCOST"] = value; }
        }

    /// <summary>
    /// Malzemenin Rapor Tarihindeki Değeri
    /// </summary>
        public double? MaterialPrice
        {
            get { return (double?)this["MATERIALPRICE"]; }
            set { this["MATERIALPRICE"] = value; }
        }

    /// <summary>
    /// Rapor Numarası
    /// </summary>
        public string HEKReportNo
        {
            get { return (string)this["HEKREPORTNO"]; }
            set { this["HEKREPORTNO"] = value; }
        }

    /// <summary>
    /// İşcilik Maliyeti
    /// </summary>
        public double? LaborTotalCost
        {
            get { return (double?)this["LABORTOTALCOST"]; }
            set { this["LABORTOTALCOST"] = value; }
        }

    /// <summary>
    /// Hek Raporu Onarım Açıklaması
    /// </summary>
        public string HEKReportRepairDetail
        {
            get { return (string)this["HEKREPORTREPAIRDETAIL"]; }
            set { this["HEKREPORTREPAIRDETAIL"] = value; }
        }

    /// <summary>
    /// Malzemenin Satınlama Fiyatı 
    /// </summary>
        public double? MaterialPurchasePrice
        {
            get { return (double?)this["MATERIALPURCHASEPRICE"]; }
            set { this["MATERIALPURCHASEPRICE"] = value; }
        }

    /// <summary>
    /// Son Kontrol Notları
    /// </summary>
        public string LastControlNotes
        {
            get { return (string)this["LASTCONTROLNOTES"]; }
            set { this["LASTCONTROLNOTES"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StageDefinition UpperStage
        {
            get { return (StageDefinition)((ITTObject)this).GetParent("UPPERSTAGE"); }
            set { this["UPPERSTAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRepair_ItemEquipmentsCollection()
        {
            _Repair_ItemEquipments = new Repair_ItemEquipment.ChildRepair_ItemEquipmentCollection(this, new Guid("62b5473f-5b69-482c-be96-c1d9b247e4d1"));
            ((ITTChildObjectCollection)_Repair_ItemEquipments).GetChildren();
        }

        protected Repair_ItemEquipment.ChildRepair_ItemEquipmentCollection _Repair_ItemEquipments = null;
        public Repair_ItemEquipment.ChildRepair_ItemEquipmentCollection Repair_ItemEquipments
        {
            get
            {
                if (_Repair_ItemEquipments == null)
                    CreateRepair_ItemEquipmentsCollection();
                return _Repair_ItemEquipments;
            }
        }

        virtual protected void CreateRepairConsumedMaterialsCollection()
        {
            _RepairConsumedMaterials = new RepairConsumedMaterial.ChildRepairConsumedMaterialCollection(this, new Guid("1cea1691-1895-460f-b54c-b07400baf639"));
            ((ITTChildObjectCollection)_RepairConsumedMaterials).GetChildren();
        }

        protected RepairConsumedMaterial.ChildRepairConsumedMaterialCollection _RepairConsumedMaterials = null;
        public RepairConsumedMaterial.ChildRepairConsumedMaterialCollection RepairConsumedMaterials
        {
            get
            {
                if (_RepairConsumedMaterials == null)
                    CreateRepairConsumedMaterialsCollection();
                return _RepairConsumedMaterials;
            }
        }

        virtual protected void CreateRepairHEKCommisionMembersCollection()
        {
            _RepairHEKCommisionMembers = new RepairHEKCommisionMember.ChildRepairHEKCommisionMemberCollection(this, new Guid("42bb1ffb-9824-4f34-b9e4-b602bb1fd271"));
            ((ITTChildObjectCollection)_RepairHEKCommisionMembers).GetChildren();
        }

        protected RepairHEKCommisionMember.ChildRepairHEKCommisionMemberCollection _RepairHEKCommisionMembers = null;
        public RepairHEKCommisionMember.ChildRepairHEKCommisionMemberCollection RepairHEKCommisionMembers
        {
            get
            {
                if (_RepairHEKCommisionMembers == null)
                    CreateRepairHEKCommisionMembersCollection();
                return _RepairHEKCommisionMembers;
            }
        }

        virtual protected void CreateUsedConsumedMaterailsCollection()
        {
            _UsedConsumedMaterails = new UsedConsumedMaterail.ChildUsedConsumedMaterailCollection(this, new Guid("1b0c10a9-5388-4603-82dd-18eb02bfc2e0"));
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

        virtual protected void CreateNeededMaterialsCollection()
        {
            _NeededMaterials = new NeededMaterials.ChildNeededMaterialsCollection(this, new Guid("69a7a18c-dcdc-4d8b-b967-6f5ce0593b1f"));
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

        virtual protected void CreateRULHEKReasonsCollection()
        {
            _RULHEKReasons = new RULHEKReason.ChildRULHEKReasonCollection(this, new Guid("f135375e-b9de-4ba1-85a7-3e0d7551ed13"));
            ((ITTChildObjectCollection)_RULHEKReasons).GetChildren();
        }

        protected RULHEKReason.ChildRULHEKReasonCollection _RULHEKReasons = null;
        public RULHEKReason.ChildRULHEKReasonCollection RULHEKReasons
        {
            get
            {
                if (_RULHEKReasons == null)
                    CreateRULHEKReasonsCollection();
                return _RULHEKReasons;
            }
        }

        protected Repair(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Repair(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Repair(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Repair(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Repair(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REPAIR", dataRow) { }
        protected Repair(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REPAIR", dataRow, isImported) { }
        public Repair(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Repair(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Repair() : base() { }

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