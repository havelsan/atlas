
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetMaterialDefinition")] 

    /// <summary>
    /// Demirbaş Bilgileri Tanımlama
    /// </summary>
    public  partial class FixedAssetMaterialDefinition : TerminologyManagerDef
    {
        public class FixedAssetMaterialDefinitionList : TTObjectCollection<FixedAssetMaterialDefinition> { }
                    
        public class ChildFixedAssetMaterialDefinitionCollection : TTObject.TTChildObjectCollection<FixedAssetMaterialDefinition>
        {
            public ChildFixedAssetMaterialDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetMaterialDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class FixedAssetMaterialListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Resourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FixedAssetStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (FixedAssetStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public FixedAssetMaterialListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FixedAssetMaterialListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FixedAssetMaterialListNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class FixedAssetMaterialDefFormNQL_Class : TTReportNqlObject 
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

            public FixedAssetStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (FixedAssetStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public FixedAssetMaterialDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FixedAssetMaterialDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FixedAssetMaterialDefFormNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialPresentationReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Fixedmaterialname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDMATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string Service
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? GuarantyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["GUARANTYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public DateTime? LastCalibrationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCALIBRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTCALIBRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMaintenanceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMAINTENANCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTMAINTENANCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Contentname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONTENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALCONTENT"].AllPropertyDefs["NAME"].DataType;
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

            public int? CalibrationPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATIONPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["CALIBRATIONPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public GetFixedAssetMaterialPresentationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialPresentationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialPresentationReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialDebitReportQuery_Class : TTReportNqlObject 
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

            public string Fixedasset
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSET"]);
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

            public string Debitperson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEBITPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Nato
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFixedAssetMaterialDebitReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialDebitReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialDebitReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialAtRepairReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string Service
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
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

            public GetFixedAssetMaterialAtRepairReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialAtRepairReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialAtRepairReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialAtMaintenanceReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string Service
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMaintenanceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMAINTENANCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTMAINTENANCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetFixedAssetMaterialAtMaintenanceReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialAtMaintenanceReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialAtMaintenanceReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialDefinitionNotUseReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
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

            public GetFixedAssetMaterialDefinitionNotUseReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialDefinitionNotUseReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialDefinitionNotUseReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialGuarantyReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public DateTime? GuarantyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["GUARANTYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public GetFixedAssetMaterialGuarantyReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialGuarantyReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialGuarantyReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialTrackingReportQuery_Class : TTReportNqlObject 
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

            public Guid? Service
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SERVICE"]);
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

            public GetFixedAssetMaterialTrackingReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialTrackingReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialTrackingReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSetMaterialDetail_Class : TTReportNqlObject 
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

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
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

            public DateTime? LastCalibrationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCALIBRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTCALIBRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public object Picture
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PICTURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["PICTURE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public FixedAssetStatusEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (FixedAssetStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMaintenanceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMAINTENANCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTMAINTENANCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string TMKNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TMKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["TMKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? GuarantyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["GUARANTYSTARTDATE"].DataType;
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

            public string GuarantyDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["GUARANTYDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsApprovalFixedAsset
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISAPPROVALFIXEDASSET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["ISAPPROVALFIXEDASSET"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string FixedAssetNO_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSETNO_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["FIXEDASSETNO_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER_SHADOW"].DataType;
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

            public string UserNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["USERNOTE"].DataType;
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

            public string Power
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POWER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["POWER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSetMaterialDetail_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSetMaterialDetail_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSetMaterialDetail_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDebitReport_Class : TTReportNqlObject 
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

            public string Fixedasset
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIXEDASSET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? LastCalibrationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCALIBRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTCALIBRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public string Debitperson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEBITPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Nato
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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

            public string Service
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDebitReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDebitReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDebitReport_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialDistBySerialReportQuery_Class : TTReportNqlObject 
        {
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

            public string Power
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POWER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["POWER"].DataType;
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

            public DateTime? GuarantyStartDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTYSTARTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["GUARANTYSTARTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public DateTime? LastCalibrationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCALIBRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTCALIBRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMaintenanceDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMAINTENANCEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTMAINTENANCEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCK"].AllPropertyDefs["INHELD"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Olcubirim
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OLCUBIRIM"]);
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

            public GetFixedAssetMaterialDistBySerialReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialDistBySerialReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialDistBySerialReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetMaterialAtCalibrationReportQuery_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string Service
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERVICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOURCE"].AllPropertyDefs["NAME"].DataType;
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

            public DateTime? LastCalibrationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTCALIBRATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["LASTCALIBRATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
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

            public int? CalibrationPeriod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATIONPERIOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["CALIBRATIONPERIOD"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public GetFixedAssetMaterialAtCalibrationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetMaterialAtCalibrationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetMaterialAtCalibrationReportQuery_Class() : base() { }
        }

        public static BindingList<FixedAssetMaterialDefinition.FixedAssetMaterialListNQL_Class> FixedAssetMaterialListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["FixedAssetMaterialListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.FixedAssetMaterialListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.FixedAssetMaterialListNQL_Class> FixedAssetMaterialListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["FixedAssetMaterialListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.FixedAssetMaterialListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition> GetFixedAssetMaterials(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FixedAssetMaterialDefinition>(queryDef, paramList);
        }

        public static BindingList<FixedAssetMaterialDefinition.FixedAssetMaterialDefFormNQL_Class> FixedAssetMaterialDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["FixedAssetMaterialDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.FixedAssetMaterialDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.FixedAssetMaterialDefFormNQL_Class> FixedAssetMaterialDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["FixedAssetMaterialDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.FixedAssetMaterialDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class> GetFixedAssetMaterialPresentationReportQuery(string OBJECTID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class> GetFixedAssetMaterialPresentationReportQuery(TTObjectContext objectContext, string OBJECTID, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialPresentationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialPresentationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialDebitReportQuery_Class> GetFixedAssetMaterialDebitReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialDebitReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialDebitReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialDebitReportQuery_Class> GetFixedAssetMaterialDebitReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialDebitReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialDebitReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtRepairReportQuery_Class> GetFixedAssetMaterialAtRepairReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialAtRepairReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtRepairReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtRepairReportQuery_Class> GetFixedAssetMaterialAtRepairReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialAtRepairReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtRepairReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtMaintenanceReportQuery_Class> GetFixedAssetMaterialAtMaintenanceReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialAtMaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtMaintenanceReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtMaintenanceReportQuery_Class> GetFixedAssetMaterialAtMaintenanceReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialAtMaintenanceReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtMaintenanceReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialDefinitionNotUseReportQuery_Class> GetFixedAssetMaterialDefinitionNotUseReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialDefinitionNotUseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialDefinitionNotUseReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialDefinitionNotUseReportQuery_Class> GetFixedAssetMaterialDefinitionNotUseReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialDefinitionNotUseReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialDefinitionNotUseReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery_Class> GetFixedAssetMaterialGuarantyReportQuery(DateTime STARTDATE, DateTime NOW, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialGuarantyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("NOW", NOW);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery_Class> GetFixedAssetMaterialGuarantyReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime NOW, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialGuarantyReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("NOW", NOW);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialGuarantyReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition> GetFixedAssetMaterialsByStore(TTObjectContext objectContext, Guid STOREID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialsByStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<FixedAssetMaterialDefinition>(queryDef, paramList);
        }

        public static BindingList<FixedAssetMaterialDefinition> GetFixedAssetMaterialsByAccountancy(TTObjectContext objectContext, Guid ACCOUNTANCYID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialsByAccountancy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACCOUNTANCYID", ACCOUNTANCYID);

            return ((ITTQuery)objectContext).QueryObjects<FixedAssetMaterialDefinition>(queryDef, paramList);
        }

        public static BindingList<FixedAssetMaterialDefinition> GetFixedAssetMaterialsByResource(TTObjectContext objectContext, Guid RESOURCEID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialsByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCEID", RESOURCEID);

            return ((ITTQuery)objectContext).QueryObjects<FixedAssetMaterialDefinition>(queryDef, paramList);
        }

        public static BindingList<FixedAssetMaterialDefinition> GetFixedAssetMaterialDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<FixedAssetMaterialDefinition>(queryDef, paramList);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery_Class> GetFixedAssetMaterialTrackingReportQuery(Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialTrackingReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery_Class> GetFixedAssetMaterialTrackingReportQuery(TTObjectContext objectContext, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialTrackingReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialTrackingReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetSetMaterialDetail_Class> GetSetMaterialDetail(Guid FIXEDASSETMATDEFDET, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetSetMaterialDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIXEDASSETMATDEFDET", FIXEDASSETMATDEFDET);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetSetMaterialDetail_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetSetMaterialDetail_Class> GetSetMaterialDetail(TTObjectContext objectContext, Guid FIXEDASSETMATDEFDET, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetSetMaterialDetail"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIXEDASSETMATDEFDET", FIXEDASSETMATDEFDET);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetSetMaterialDetail_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition> GetFixedAssetMaterialsByMaterialAndStore(TTObjectContext objectContext, Guid MATERIAL, Guid STORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialsByMaterialAndStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("STORE", STORE);

            return ((ITTQuery)objectContext).QueryObjects<FixedAssetMaterialDefinition>(queryDef, paramList);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetDebitReport_Class> GetDebitReport(Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetDebitReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetDebitReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetDebitReport_Class> GetDebitReport(TTObjectContext objectContext, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetDebitReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetDebitReport_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery_Class> GetFixedAssetMaterialDistBySerialReportQuery(Guid MATERIAL, int MATERIALFLAG, Guid STORE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialDistBySerialReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);
            paramList.Add("STORE", STORE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery_Class> GetFixedAssetMaterialDistBySerialReportQuery(TTObjectContext objectContext, Guid MATERIAL, int MATERIALFLAG, Guid STORE, int STOREFLAG, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialDistBySerialReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("MATERIALFLAG", MATERIALFLAG);
            paramList.Add("STORE", STORE);
            paramList.Add("STOREFLAG", STOREFLAG);

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialDistBySerialReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtCalibrationReportQuery_Class> GetFixedAssetMaterialAtCalibrationReportQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialAtCalibrationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtCalibrationReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtCalibrationReportQuery_Class> GetFixedAssetMaterialAtCalibrationReportQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].QueryDefs["GetFixedAssetMaterialAtCalibrationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetMaterialDefinition.GetFixedAssetMaterialAtCalibrationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Son Kalibrasyon Tarihi
    /// </summary>
        public DateTime? LastCalibrationDate
        {
            get { return (DateTime?)this["LASTCALIBRATIONDATE"]; }
            set { this["LASTCALIBRATIONDATE"] = value; }
        }

    /// <summary>
    /// Marka
    /// </summary>
        public string Mark
        {
            get { return (string)this["MARK"]; }
            set { this["MARK"] = value; }
        }

    /// <summary>
    /// Model
    /// </summary>
        public string Model
        {
            get { return (string)this["MODEL"]; }
            set { this["MODEL"] = value; }
        }

    /// <summary>
    /// Garanti Bitiş Tarihi
    /// </summary>
        public DateTime? GuarantyEndDate
        {
            get { return (DateTime?)this["GUARANTYENDDATE"]; }
            set { this["GUARANTYENDDATE"] = value; }
        }

    /// <summary>
    /// Resim
    /// </summary>
        public object Picture
        {
            get { return (object)this["PICTURE"]; }
            set { this["PICTURE"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public FixedAssetStatusEnum? Status
        {
            get { return (FixedAssetStatusEnum?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Son Bakım Tarihi
    /// </summary>
        public DateTime? LastMaintenanceDate
        {
            get { return (DateTime?)this["LASTMAINTENANCEDATE"]; }
            set { this["LASTMAINTENANCEDATE"] = value; }
        }

    /// <summary>
    /// Demirbaş Nu.
    /// </summary>
        public string FixedAssetNO
        {
            get { return (string)this["FIXEDASSETNO"]; }
            set { this["FIXEDASSETNO"] = value; }
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
    /// TMK No
    /// </summary>
        public string TMKNO
        {
            get { return (string)this["TMKNO"]; }
            set { this["TMKNO"] = value; }
        }

    /// <summary>
    /// Garanti Başlama Tarihi
    /// </summary>
        public DateTime? GuarantyStartDate
        {
            get { return (DateTime?)this["GUARANTYSTARTDATE"]; }
            set { this["GUARANTYSTARTDATE"] = value; }
        }

    /// <summary>
    /// Seri No
    /// </summary>
        public string SerialNumber
        {
            get { return (string)this["SERIALNUMBER"]; }
            set { this["SERIALNUMBER"] = value; }
        }

    /// <summary>
    /// Garanti Şartları
    /// </summary>
        public string GuarantyDescription
        {
            get { return (string)this["GUARANTYDESCRIPTION"]; }
            set { this["GUARANTYDESCRIPTION"] = value; }
        }

    /// <summary>
    /// ETKM Tarafından Onaylanmış
    /// </summary>
        public bool? IsApprovalFixedAsset
        {
            get { return (bool?)this["ISAPPROVALFIXEDASSET"]; }
            set { this["ISAPPROVALFIXEDASSET"] = value; }
        }

        public string FixedAssetNO_Shadow
        {
            get { return (string)this["FIXEDASSETNO_SHADOW"]; }
        }

        public string Mark_Shadow
        {
            get { return (string)this["MARK_SHADOW"]; }
        }

        public string Model_Shadow
        {
            get { return (string)this["MODEL_SHADOW"]; }
        }

        public string SerialNumber_Shadow
        {
            get { return (string)this["SERIALNUMBER_SHADOW"]; }
        }

    /// <summary>
    /// Anlık Bakım Onarım Durumu
    /// </summary>
        public FixedAssetCMRStatusEnum? CMRStatus
        {
            get { return (FixedAssetCMRStatusEnum?)(int?)this["CMRSTATUS"]; }
            set { this["CMRSTATUS"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string UserNote
        {
            get { return (string)this["USERNOTE"]; }
            set { this["USERNOTE"] = value; }
        }

    /// <summary>
    /// Voltaj
    /// </summary>
        public string Voltage
        {
            get { return (string)this["VOLTAGE"]; }
            set { this["VOLTAGE"] = value; }
        }

    /// <summary>
    /// Frekans
    /// </summary>
        public string Frequency
        {
            get { return (string)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// İmal Tarihi
    /// </summary>
        public DateTime? ProductionDate
        {
            get { return (DateTime?)this["PRODUCTIONDATE"]; }
            set { this["PRODUCTIONDATE"] = value; }
        }

    /// <summary>
    /// Güç
    /// </summary>
        public string Power
        {
            get { return (string)this["POWER"]; }
            set { this["POWER"] = value; }
        }

        public Stock Stock
        {
            get { return (Stock)((ITTObject)this).GetParent("STOCK"); }
            set { this["STOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition OldFixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("OLDFIXEDASSETDEFINITION"); }
            set { this["OLDFIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Personnel Personnel
        {
            get { return (Personnel)((ITTObject)this).GetParent("PERSONNEL"); }
            set { this["PERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Service Service
        {
            get { return (Service)((ITTObject)this).GetParent("SERVICE"); }
            set { this["SERVICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDefinition FixedAssetDefinition
        {
            get { return (FixedAssetDefinition)((ITTObject)this).GetParent("FIXEDASSETDEFINITION"); }
            set { this["FIXEDASSETDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Saymanlık
    /// </summary>
        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinitionDetail FixedAssetMaterialDefDetail
        {
            get { return (FixedAssetMaterialDefinitionDetail)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFDETAIL"); }
            set { this["FIXEDASSETMATERIALDEFDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateContentsCollection()
        {
            _Contents = new FixedAssetMaterialContent.ChildFixedAssetMaterialContentCollection(this, new Guid("ac9536fd-7265-4091-8159-89b17e66f947"));
            ((ITTChildObjectCollection)_Contents).GetChildren();
        }

        protected FixedAssetMaterialContent.ChildFixedAssetMaterialContentCollection _Contents = null;
        public FixedAssetMaterialContent.ChildFixedAssetMaterialContentCollection Contents
        {
            get
            {
                if (_Contents == null)
                    CreateContentsCollection();
                return _Contents;
            }
        }

        virtual protected void CreateFixedAssetTransactionsCollection()
        {
            _FixedAssetTransactions = new FixedAssetTransaction.ChildFixedAssetTransactionCollection(this, new Guid("db46430b-c5e7-4dd4-b683-a77ad3101a26"));
            ((ITTChildObjectCollection)_FixedAssetTransactions).GetChildren();
        }

        protected FixedAssetTransaction.ChildFixedAssetTransactionCollection _FixedAssetTransactions = null;
    /// <summary>
    /// Child collection for Demirbaş-Demirbaş Hareketleri
    /// </summary>
        public FixedAssetTransaction.ChildFixedAssetTransactionCollection FixedAssetTransactions
        {
            get
            {
                if (_FixedAssetTransactions == null)
                    CreateFixedAssetTransactionsCollection();
                return _FixedAssetTransactions;
            }
        }

        protected FixedAssetMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetMaterialDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetMaterialDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetMaterialDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETMATERIALDEFINITION", dataRow) { }
        protected FixedAssetMaterialDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETMATERIALDEFINITION", dataRow, isImported) { }
        public FixedAssetMaterialDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetMaterialDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetMaterialDefinition() : base() { }

    }
}