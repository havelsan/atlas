
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMRActionRequest")] 

    /// <summary>
    /// Kalibrasyon/Bakım/Onarım İstek
    /// </summary>
    public  partial class CMRActionRequest : CMRAction
    {
        public class CMRActionRequestList : TTObjectCollection<CMRActionRequest> { }
                    
        public class ChildCMRActionRequestCollection : TTObject.TTChildObjectCollection<CMRActionRequest>
        {
            public ChildCMRActionRequestCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMRActionRequestCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetWorkOrdersStateReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public RequestTypeEnum? RequestType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTTYPE"].DataType;
                    return (RequestTypeEnum?)(int)dataType.ConvertValue(val);
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

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
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

            public GetWorkOrdersStateReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetWorkOrdersStateReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetWorkOrdersStateReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class CMRActionHospitalReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Stockno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? FirmDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["FIRMDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Workshopname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? Deliverydate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ACTUALDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public CMRActionHospitalReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CMRActionHospitalReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CMRActionHospitalReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUserMaintenanceReportQuery_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["USERMAINTENANCE"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetUserMaintenanceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUserMaintenanceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUserMaintenanceReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNotCompletedFaultReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public RequestTypeEnum? RequestType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTTYPE"].DataType;
                    return (RequestTypeEnum?)(int)dataType.ConvertValue(val);
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

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNotCompletedFaultReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNotCompletedFaultReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNotCompletedFaultReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFaultCountsAndDetailsReportQuery_Class : TTReportNqlObject 
        {
            public RequestTypeEnum? RequestType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTTYPE"].DataType;
                    return (RequestTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FixedAssetNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["FIXEDASSETNO"].DataType;
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

            public string FaultDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAULTDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["FAULTDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Serialno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNO"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetFaultCountsAndDetailsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFaultCountsAndDetailsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFaultCountsAndDetailsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetStatusOfChiefMaterial_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
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

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? NeedCalibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDCALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NEEDCALIBRATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NeedMaintenance
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDMAINTENANCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NEEDMAINTENANCE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Currency? Inheld
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INHELD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetStatusOfChiefMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetStatusOfChiefMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetStatusOfChiefMaterial_Class() : base() { }
        }

        [Serializable] 

        public partial class GetUnitMaintenanceReportQueryNew_Class : TTReportNqlObject 
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

            public GetUnitMaintenanceReportQueryNew_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnitMaintenanceReportQueryNew_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnitMaintenanceReportQueryNew_Class() : base() { }
        }

        [Serializable] 

        public partial class CMRActionHospitalReportQueryByRepair_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Stockno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? FirmDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["FIRMDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Workshopname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? Deliverydate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ACTUALDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public CMRActionHospitalReportQueryByRepair_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CMRActionHospitalReportQueryByRepair_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CMRActionHospitalReportQueryByRepair_Class() : base() { }
        }

        [Serializable] 

        public partial class CMRActionHospitalReportQueryByCalibration_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Stockno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ENDDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? FirmDeliveryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMDELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["FIRMDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Workshopname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKSHOPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESDIVISIONSUBSECTION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? Deliverydate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DELIVERYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["ACTUALDELIVERYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public CMRActionHospitalReportQueryByCalibration_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CMRActionHospitalReportQueryByCalibration_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CMRActionHospitalReportQueryByCalibration_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPerformanceOfPersonnelReportQuery_Class : TTReportNqlObject 
        {
            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Name1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetPerformanceOfPersonnelReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPerformanceOfPersonnelReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPerformanceOfPersonnelReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOnarimiDevamEdenCihazlar_Class : TTReportNqlObject 
        {
            public string FixedAssetNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["FIXEDASSETNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string Service
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
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

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOnarimiDevamEdenCihazlar_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOnarimiDevamEdenCihazlar_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOnarimiDevamEdenCihazlar_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPersonnelPerformanceCompareReportQuery_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public GetPersonnelPerformanceCompareReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPersonnelPerformanceCompareReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPersonnelPerformanceCompareReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPersonnelPerformanceCompareRQ2_Class : TTReportNqlObject 
        {
            public Object Count
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["COUNT"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
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

            public GetPersonnelPerformanceCompareRQ2_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPersonnelPerformanceCompareRQ2_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPersonnelPerformanceCompareRQ2_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Klinik Onay
    /// </summary>
            public static Guid ClinicApproval { get { return new Guid("d7fc8d54-478b-4a66-9e49-a2fe79785a93"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid Request { get { return new Guid("85c973ba-e080-4e10-ab8e-9d428c8eaaac"); } }
    /// <summary>
    /// İşlem Durumu
    /// </summary>
            public static Guid Status { get { return new Guid("4bb4ebd3-8ec3-492f-99f3-9d634efff518"); } }
    /// <summary>
    /// Kademe Onayı
    /// </summary>
            public static Guid StageApproval { get { return new Guid("5a5b3a97-8a24-4f97-977f-7a37d8ea39f8"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("db61b329-9165-4dbe-9022-96f927c28acf"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Comleted { get { return new Guid("0c4337ea-6376-41a1-a2b3-e1d832c6646a"); } }
    /// <summary>
    /// Garanti Onarımı
    /// </summary>
            public static Guid GuarantyRepair { get { return new Guid("538c1823-e5d0-4fc0-adfc-6823b3efddb3"); } }
    /// <summary>
    /// Ön Kontrol
    /// </summary>
            public static Guid PreControl { get { return new Guid("4c9e8440-dd6e-4e8a-826d-df5d3df920e1"); } }
    /// <summary>
    /// Garanti Onarım Onay
    /// </summary>
            public static Guid GuarantyRepairApproval { get { return new Guid("fd41ee56-9485-412c-be1b-6a150ff429cd"); } }
        }

        public static BindingList<CMRActionRequest.GetWorkOrdersStateReportQuery_Class> GetWorkOrdersStateReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetWorkOrdersStateReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetWorkOrdersStateReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetWorkOrdersStateReportQuery_Class> GetWorkOrdersStateReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetWorkOrdersStateReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetWorkOrdersStateReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.CMRActionHospitalReportQuery_Class> CMRActionHospitalReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["CMRActionHospitalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.CMRActionHospitalReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.CMRActionHospitalReportQuery_Class> CMRActionHospitalReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["CMRActionHospitalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.CMRActionHospitalReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetUserMaintenanceReportQuery_Class> GetUserMaintenanceReportQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetUserMaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetUserMaintenanceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetUserMaintenanceReportQuery_Class> GetUserMaintenanceReportQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetUserMaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetUserMaintenanceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetNotCompletedFaultReportQuery_Class> GetNotCompletedFaultReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid STORE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetNotCompletedFaultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetNotCompletedFaultReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetNotCompletedFaultReportQuery_Class> GetNotCompletedFaultReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STORE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetNotCompletedFaultReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetNotCompletedFaultReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class> GetFaultCountsAndDetailsReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid STORE, Guid MATERIAL, int STOREFLAG, int MATERIALFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetFaultCountsAndDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STOREFLAG", STOREFLAG);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class> GetFaultCountsAndDetailsReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STORE, Guid MATERIAL, int STOREFLAG, int MATERIALFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetFaultCountsAndDetailsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STOREFLAG", STOREFLAG);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetFaultCountsAndDetailsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetStatusOfChiefMaterial_Class> GetStatusOfChiefMaterial(Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetStatusOfChiefMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetStatusOfChiefMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetStatusOfChiefMaterial_Class> GetStatusOfChiefMaterial(TTObjectContext objectContext, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetStatusOfChiefMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetStatusOfChiefMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstek Numarasasına Göre Kalibrasyon/Bakım/Onarım
    /// </summary>
        public static BindingList<CMRActionRequest> GetCMRActionRequestByRequestNo(TTObjectContext objectContext, string REQUESTNO)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetCMRActionRequestByRequestNo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return ((ITTQuery)objectContext).QueryObjects<CMRActionRequest>(queryDef, paramList);
        }

        public static BindingList<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class> GetUnitMaintenanceReportQueryNew(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetUnitMaintenanceReportQueryNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class> GetUnitMaintenanceReportQueryNew(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetUnitMaintenanceReportQueryNew"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetUnitMaintenanceReportQueryNew_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.CMRActionHospitalReportQueryByRepair_Class> CMRActionHospitalReportQueryByRepair(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["CMRActionHospitalReportQueryByRepair"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.CMRActionHospitalReportQueryByRepair_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.CMRActionHospitalReportQueryByRepair_Class> CMRActionHospitalReportQueryByRepair(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["CMRActionHospitalReportQueryByRepair"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.CMRActionHospitalReportQueryByRepair_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.CMRActionHospitalReportQueryByCalibration_Class> CMRActionHospitalReportQueryByCalibration(DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["CMRActionHospitalReportQueryByCalibration"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.CMRActionHospitalReportQueryByCalibration_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.CMRActionHospitalReportQueryByCalibration_Class> CMRActionHospitalReportQueryByCalibration(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["CMRActionHospitalReportQueryByCalibration"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.CMRActionHospitalReportQueryByCalibration_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Personelin Performans Rapor Query
    /// </summary>
        public static BindingList<CMRActionRequest.GetPerformanceOfPersonnelReportQuery_Class> GetPerformanceOfPersonnelReportQuery(Guid PERSONNEL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetPerformanceOfPersonnelReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PERSONNEL", PERSONNEL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetPerformanceOfPersonnelReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Personelin Performans Rapor Query
    /// </summary>
        public static BindingList<CMRActionRequest.GetPerformanceOfPersonnelReportQuery_Class> GetPerformanceOfPersonnelReportQuery(TTObjectContext objectContext, Guid PERSONNEL, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetPerformanceOfPersonnelReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PERSONNEL", PERSONNEL);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetPerformanceOfPersonnelReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetOnarimiDevamEdenCihazlar_Class> GetOnarimiDevamEdenCihazlar(DateTime ENDDATE, DateTime STARTDATE, Guid STORE, Guid PERSON, int STOREFLAG, int PERSONFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetOnarimiDevamEdenCihazlar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("PERSON", PERSON);
            paramList.Add("STOREFLAG", STOREFLAG);
            paramList.Add("PERSONFLAG", PERSONFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetOnarimiDevamEdenCihazlar_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetOnarimiDevamEdenCihazlar_Class> GetOnarimiDevamEdenCihazlar(TTObjectContext objectContext, DateTime ENDDATE, DateTime STARTDATE, Guid STORE, Guid PERSON, int STOREFLAG, int PERSONFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetOnarimiDevamEdenCihazlar"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("STORE", STORE);
            paramList.Add("PERSON", PERSON);
            paramList.Add("STOREFLAG", STOREFLAG);
            paramList.Add("PERSONFLAG", PERSONFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetOnarimiDevamEdenCihazlar_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Personel Karşılaştırma Query
    /// </summary>
        public static BindingList<CMRActionRequest.GetPersonnelPerformanceCompareReportQuery_Class> GetPersonnelPerformanceCompareReportQuery(DateTime STARTDATE, DateTime ENDDATE, Guid WORKSHOP, int WORKSHOPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetPersonnelPerformanceCompareReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("WORKSHOP", WORKSHOP);
            paramList.Add("WORKSHOPFLAG", WORKSHOPFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetPersonnelPerformanceCompareReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Personel Karşılaştırma Query
    /// </summary>
        public static BindingList<CMRActionRequest.GetPersonnelPerformanceCompareReportQuery_Class> GetPersonnelPerformanceCompareReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid WORKSHOP, int WORKSHOPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetPersonnelPerformanceCompareReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("WORKSHOP", WORKSHOP);
            paramList.Add("WORKSHOPFLAG", WORKSHOPFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetPersonnelPerformanceCompareReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetPersonnelPerformanceCompareRQ2_Class> GetPersonnelPerformanceCompareRQ2(Guid OBJECTID, DateTime ENDDATE, DateTime STARTDATE, Guid WORKSHOP, int WORKSHOPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetPersonnelPerformanceCompareRQ2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("WORKSHOP", WORKSHOP);
            paramList.Add("WORKSHOPFLAG", WORKSHOPFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetPersonnelPerformanceCompareRQ2_Class>(queryDef, paramList, pi);
        }

        public static BindingList<CMRActionRequest.GetPersonnelPerformanceCompareRQ2_Class> GetPersonnelPerformanceCompareRQ2(TTObjectContext objectContext, Guid OBJECTID, DateTime ENDDATE, DateTime STARTDATE, Guid WORKSHOP, int WORKSHOPFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRACTIONREQUEST"].QueryDefs["GetPersonnelPerformanceCompareRQ2"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("WORKSHOP", WORKSHOP);
            paramList.Add("WORKSHOPFLAG", WORKSHOPFLAG);

            return TTReportNqlObject.QueryObjects<CMRActionRequest.GetPersonnelPerformanceCompareRQ2_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İstek Türü
    /// </summary>
        public RequestTypeEnum? RequestType
        {
            get { return (RequestTypeEnum?)(int?)this["REQUESTTYPE"]; }
            set { this["REQUESTTYPE"] = value; }
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
    /// Personel Tel No
    /// </summary>
        public string UserTel
        {
            get { return (string)this["USERTEL"]; }
            set { this["USERTEL"] = value; }
        }

    /// <summary>
    /// Firmaya Bildirim Tarihi
    /// </summary>
        public DateTime? FirmNotificationDate
        {
            get { return (DateTime?)this["FIRMNOTIFICATIONDATE"]; }
            set { this["FIRMNOTIFICATIONDATE"] = value; }
        }

    /// <summary>
    /// Firmaya Teslim Tarihi
    /// </summary>
        public DateTime? FirmDeliveryDate
        {
            get { return (DateTime?)this["FIRMDELIVERYDATE"]; }
            set { this["FIRMDELIVERYDATE"] = value; }
        }

    /// <summary>
    /// Firmadan Teslim Alma Tarihi
    /// </summary>
        public DateTime? FirmSubmissionDate
        {
            get { return (DateTime?)this["FIRMSUBMISSIONDATE"]; }
            set { this["FIRMSUBMISSIONDATE"] = value; }
        }

    /// <summary>
    /// Yerinde Onarım
    /// </summary>
        public bool? OnSiteRepair
        {
            get { return (bool?)this["ONSITEREPAIR"]; }
            set { this["ONSITEREPAIR"] = value; }
        }

    /// <summary>
    /// Garanti Ceza Süresi
    /// </summary>
        public long? GuarantyPenalTime
        {
            get { return (long?)this["GUARANTYPENALTIME"]; }
            set { this["GUARANTYPENALTIME"] = value; }
        }

    /// <summary>
    /// İş İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

    /// <summary>
    /// Cihazın Arızası Açıklaması
    /// </summary>
        public string FaultDescription
        {
            get { return (string)this["FAULTDESCRIPTION"]; }
            set { this["FAULTDESCRIPTION"] = value; }
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
    /// Güncelleme
    /// </summary>
        public bool? CMRActionRequestUpdate
        {
            get { return (bool?)this["CMRACTIONREQUESTUPDATE"]; }
            set { this["CMRACTIONREQUESTUPDATE"] = value; }
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
    /// Malzeme Sayısı
    /// </summary>
        public double? FixedAssetMaterialAmount
        {
            get { return (double?)this["FIXEDASSETMATERIALAMOUNT"]; }
            set { this["FIXEDASSETMATERIALAMOUNT"] = value; }
        }

    /// <summary>
    /// Yapılacak İşlem
    /// </summary>
        public string FixedAssetMaterialDesc
        {
            get { return (string)this["FIXEDASSETMATERIALDESC"]; }
            set { this["FIXEDASSETMATERIALDESC"] = value; }
        }

    /// <summary>
    /// Demirbaş Tipi
    /// </summary>
        public FixedAssetTypeEnum? FixedAssetType
        {
            get { return (FixedAssetTypeEnum?)(int?)this["FIXEDASSETTYPE"]; }
            set { this["FIXEDASSETTYPE"] = value; }
        }

    /// <summary>
    /// Üst Kademesi
    /// </summary>
        public StageDefinition UpperStage
        {
            get { return (StageDefinition)((ITTObject)this).GetParent("UPPERSTAGE"); }
            set { this["UPPERSTAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Firma
    /// </summary>
        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCMR_ItemEquipmentsCollection()
        {
            _CMR_ItemEquipments = new CMR_ItemEquipment.ChildCMR_ItemEquipmentCollection(this, new Guid("3b25ff72-6891-4121-acd7-903c9fb78322"));
            ((ITTChildObjectCollection)_CMR_ItemEquipments).GetChildren();
        }

        protected CMR_ItemEquipment.ChildCMR_ItemEquipmentCollection _CMR_ItemEquipments = null;
        public CMR_ItemEquipment.ChildCMR_ItemEquipmentCollection CMR_ItemEquipments
        {
            get
            {
                if (_CMR_ItemEquipments == null)
                    CreateCMR_ItemEquipmentsCollection();
                return _CMR_ItemEquipments;
            }
        }

        protected CMRActionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMRActionRequest(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMRActionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMRActionRequest(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMRActionRequest(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMRACTIONREQUEST", dataRow) { }
        protected CMRActionRequest(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMRACTIONREQUEST", dataRow, isImported) { }
        public CMRActionRequest(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMRActionRequest(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMRActionRequest() : base() { }

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