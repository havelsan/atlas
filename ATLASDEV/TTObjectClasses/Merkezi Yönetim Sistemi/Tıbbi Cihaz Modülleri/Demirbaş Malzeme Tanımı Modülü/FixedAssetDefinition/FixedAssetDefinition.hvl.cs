
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDefinition")] 

    /// <summary>
    /// Demirbaş Malzeme Bilgileri
    /// </summary>
    public  partial class FixedAssetDefinition : Material
    {
        public class FixedAssetDefinitionList : TTObjectCollection<FixedAssetDefinition> { }
                    
        public class ChildFixedAssetDefinitionCollection : TTObject.TTChildObjectCollection<FixedAssetDefinition>
        {
            public ChildFixedAssetDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class FixedAssetDefinitionFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
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

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public FixedAssetDefinitionFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FixedAssetDefinitionFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FixedAssetDefinitionFormNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFixedAssetDefinitionListQuery_Class : TTReportNqlObject 
        {
            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
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

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFixedAssetDefinitionListQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDefinitionListQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDefinitionListQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class FixedAssetQuerybyUpdateAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public FixedAssetQuerybyUpdateAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FixedAssetQuerybyUpdateAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FixedAssetQuerybyUpdateAction_Class() : base() { }
        }

        [Serializable] 

        public partial class FixedAssetDefinitionForCMRAction_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? AllowToGivePatient
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ALLOWTOGIVEPATIENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["ALLOWTOGIVEPATIENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string Materialtreename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTREENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIALTREEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Distributiontypename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public FixedAssetDefinitionForCMRAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FixedAssetDefinitionForCMRAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FixedAssetDefinitionForCMRAction_Class() : base() { }
        }

        public static BindingList<FixedAssetDefinition.FixedAssetDefinitionFormNQL_Class> FixedAssetDefinitionFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["FixedAssetDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.FixedAssetDefinitionFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition.FixedAssetDefinitionFormNQL_Class> FixedAssetDefinitionFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["FixedAssetDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.FixedAssetDefinitionFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition.GetFixedAssetDefinitionListQuery_Class> GetFixedAssetDefinitionListQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["GetFixedAssetDefinitionListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.GetFixedAssetDefinitionListQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition.GetFixedAssetDefinitionListQuery_Class> GetFixedAssetDefinitionListQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["GetFixedAssetDefinitionListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.GetFixedAssetDefinitionListQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition.FixedAssetQuerybyUpdateAction_Class> FixedAssetQuerybyUpdateAction(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["FixedAssetQuerybyUpdateAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.FixedAssetQuerybyUpdateAction_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition.FixedAssetQuerybyUpdateAction_Class> FixedAssetQuerybyUpdateAction(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["FixedAssetQuerybyUpdateAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.FixedAssetQuerybyUpdateAction_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition.FixedAssetDefinitionForCMRAction_Class> FixedAssetDefinitionForCMRAction(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["FixedAssetDefinitionForCMRAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.FixedAssetDefinitionForCMRAction_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition.FixedAssetDefinitionForCMRAction_Class> FixedAssetDefinitionForCMRAction(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["FixedAssetDefinitionForCMRAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FixedAssetDefinition.FixedAssetDefinitionForCMRAction_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FixedAssetDefinition> GetFixedAssetDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].QueryDefs["GetFixedAssetDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<FixedAssetDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string FA_Description
        {
            get { return (string)this["FA_DESCRIPTION"]; }
            set { this["FA_DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Gerektirir
    /// </summary>
        public bool? NeedCalibration
        {
            get { return (bool?)this["NEEDCALIBRATION"]; }
            set { this["NEEDCALIBRATION"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Süresi
    /// </summary>
        public int? CalibrationTime
        {
            get { return (int?)this["CALIBRATIONTIME"]; }
            set { this["CALIBRATIONTIME"] = value; }
        }

    /// <summary>
    /// Bakım Periyodu
    /// </summary>
        public int? MaintenancePeriod
        {
            get { return (int?)this["MAINTENANCEPERIOD"]; }
            set { this["MAINTENANCEPERIOD"] = value; }
        }

    /// <summary>
    /// Kalibratördür
    /// </summary>
        public bool? IsCalibrator
        {
            get { return (bool?)this["ISCALIBRATOR"]; }
            set { this["ISCALIBRATOR"] = value; }
        }

    /// <summary>
    /// Bakım Süresi
    /// </summary>
        public int? MaintenanceTime
        {
            get { return (int?)this["MAINTENANCETIME"]; }
            set { this["MAINTENANCETIME"] = value; }
        }

    /// <summary>
    /// Kalibrasyon Periyodu
    /// </summary>
        public int? CalibrationPeriod
        {
            get { return (int?)this["CALIBRATIONPERIOD"]; }
            set { this["CALIBRATIONPERIOD"] = value; }
        }

    /// <summary>
    /// Bakım Gerektirir
    /// </summary>
        public bool? NeedMaintenance
        {
            get { return (bool?)this["NEEDMAINTENANCE"]; }
            set { this["NEEDMAINTENANCE"] = value; }
        }

    /// <summary>
    /// Hayvandır
    /// </summary>
        public bool? IsAnimal
        {
            get { return (bool?)this["ISANIMAL"]; }
            set { this["ISANIMAL"] = value; }
        }

        virtual protected void CreateFixedAssetMaterialDefinitionsCollection()
        {
            _FixedAssetMaterialDefinitions = new FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection(this, new Guid("1bc69e49-94c1-440c-8b3d-c01baacec368"));
            ((ITTChildObjectCollection)_FixedAssetMaterialDefinitions).GetChildren();
        }

        protected FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection _FixedAssetMaterialDefinitions = null;
        public FixedAssetMaterialDefinition.ChildFixedAssetMaterialDefinitionCollection FixedAssetMaterialDefinitions
        {
            get
            {
                if (_FixedAssetMaterialDefinitions == null)
                    CreateFixedAssetMaterialDefinitionsCollection();
                return _FixedAssetMaterialDefinitions;
            }
        }

        virtual protected void CreateFixedAssetMaintenanceParametersCollection()
        {
            _FixedAssetMaintenanceParameters = new FixedAssetMaintenanceParameter.ChildFixedAssetMaintenanceParameterCollection(this, new Guid("a5045dd5-5cbf-4df3-89bf-9cf26c4f2e70"));
            ((ITTChildObjectCollection)_FixedAssetMaintenanceParameters).GetChildren();
        }

        protected FixedAssetMaintenanceParameter.ChildFixedAssetMaintenanceParameterCollection _FixedAssetMaintenanceParameters = null;
        public FixedAssetMaintenanceParameter.ChildFixedAssetMaintenanceParameterCollection FixedAssetMaintenanceParameters
        {
            get
            {
                if (_FixedAssetMaintenanceParameters == null)
                    CreateFixedAssetMaintenanceParametersCollection();
                return _FixedAssetMaintenanceParameters;
            }
        }

        virtual protected void CreateUserLevelMaintParametersCollection()
        {
            _UserLevelMaintParameters = new UserLevelMaintParameter.ChildUserLevelMaintParameterCollection(this, new Guid("b5ea3243-6899-4b4b-96a6-c57a3c9407c0"));
            ((ITTChildObjectCollection)_UserLevelMaintParameters).GetChildren();
        }

        protected UserLevelMaintParameter.ChildUserLevelMaintParameterCollection _UserLevelMaintParameters = null;
        public UserLevelMaintParameter.ChildUserLevelMaintParameterCollection UserLevelMaintParameters
        {
            get
            {
                if (_UserLevelMaintParameters == null)
                    CreateUserLevelMaintParametersCollection();
                return _UserLevelMaintParameters;
            }
        }

        virtual protected void CreateUnitLevelMaintParametersCollection()
        {
            _UnitLevelMaintParameters = new UnitLevelMaintParameter.ChildUnitLevelMaintParameterCollection(this, new Guid("40351105-db49-485e-b3e2-48685ed81465"));
            ((ITTChildObjectCollection)_UnitLevelMaintParameters).GetChildren();
        }

        protected UnitLevelMaintParameter.ChildUnitLevelMaintParameterCollection _UnitLevelMaintParameters = null;
        public UnitLevelMaintParameter.ChildUnitLevelMaintParameterCollection UnitLevelMaintParameters
        {
            get
            {
                if (_UnitLevelMaintParameters == null)
                    CreateUnitLevelMaintParametersCollection();
                return _UnitLevelMaintParameters;
            }
        }

        virtual protected void CreateCalibrationProceduresCollection()
        {
            _CalibrationProcedures = new CalibrationProcedure.ChildCalibrationProcedureCollection(this, new Guid("6cbf6235-cf52-4ae3-97ad-71943ffffad9"));
            ((ITTChildObjectCollection)_CalibrationProcedures).GetChildren();
        }

        protected CalibrationProcedure.ChildCalibrationProcedureCollection _CalibrationProcedures = null;
        public CalibrationProcedure.ChildCalibrationProcedureCollection CalibrationProcedures
        {
            get
            {
                if (_CalibrationProcedures == null)
                    CreateCalibrationProceduresCollection();
                return _CalibrationProcedures;
            }
        }

        protected FixedAssetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDEFINITION", dataRow) { }
        protected FixedAssetDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDEFINITION", dataRow, isImported) { }
        public FixedAssetDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDefinition() : base() { }

    }
}