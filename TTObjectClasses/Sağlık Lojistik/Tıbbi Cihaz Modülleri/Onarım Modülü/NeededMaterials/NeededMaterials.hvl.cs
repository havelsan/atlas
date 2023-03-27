
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NeededMaterials")] 

    public  partial class NeededMaterials : TTObject
    {
        public class NeededMaterialsList : TTObjectCollection<NeededMaterials> { }
                    
        public class ChildNeededMaterialsCollection : TTObject.TTChildObjectCollection<NeededMaterials>
        {
            public ChildNeededMaterialsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNeededMaterialsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RULNeededMaterialQuery_Class : TTReportNqlObject 
        {
            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PartNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["PARTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaterialAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialUnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALUNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALUNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALTOTALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public RULNeededMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RULNeededMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RULNeededMaterialQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class MaintenanceOrderNeededMaterialQuery_Class : TTReportNqlObject 
        {
            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PartNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["PARTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaterialAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialUnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALUNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALUNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALTOTALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public MaintenanceOrderNeededMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaintenanceOrderNeededMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaintenanceOrderNeededMaterialQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class RepairNeededMaterialQuery_Class : TTReportNqlObject 
        {
            public string MaterialName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PartNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARTNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["PARTNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MaterialAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialUnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALUNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALUNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].AllPropertyDefs["MATERIALTOTALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public RepairNeededMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RepairNeededMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RepairNeededMaterialQuery_Class() : base() { }
        }

        public static BindingList<NeededMaterials.RULNeededMaterialQuery_Class> RULNeededMaterialQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].QueryDefs["RULNeededMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NeededMaterials.RULNeededMaterialQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NeededMaterials.RULNeededMaterialQuery_Class> RULNeededMaterialQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].QueryDefs["RULNeededMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NeededMaterials.RULNeededMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NeededMaterials.MaintenanceOrderNeededMaterialQuery_Class> MaintenanceOrderNeededMaterialQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].QueryDefs["MaintenanceOrderNeededMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NeededMaterials.MaintenanceOrderNeededMaterialQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NeededMaterials.MaintenanceOrderNeededMaterialQuery_Class> MaintenanceOrderNeededMaterialQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].QueryDefs["MaintenanceOrderNeededMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NeededMaterials.MaintenanceOrderNeededMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NeededMaterials.RepairNeededMaterialQuery_Class> RepairNeededMaterialQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].QueryDefs["RepairNeededMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NeededMaterials.RepairNeededMaterialQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NeededMaterials.RepairNeededMaterialQuery_Class> RepairNeededMaterialQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEEDEDMATERIALS"].QueryDefs["RepairNeededMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NeededMaterials.RepairNeededMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Malzeme İsmi
    /// </summary>
        public string MaterialName
        {
            get { return (string)this["MATERIALNAME"]; }
            set { this["MATERIALNAME"] = value; }
        }

    /// <summary>
    /// Parça Numarası
    /// </summary>
        public string PartNumber
        {
            get { return (string)this["PARTNUMBER"]; }
            set { this["PARTNUMBER"] = value; }
        }

    /// <summary>
    /// Miktarı
    /// </summary>
        public double? MaterialAmount
        {
            get { return (double?)this["MATERIALAMOUNT"]; }
            set { this["MATERIALAMOUNT"] = value; }
        }

    /// <summary>
    /// Birim Fiyat
    /// </summary>
        public double? MaterialUnitPrice
        {
            get { return (double?)this["MATERIALUNITPRICE"]; }
            set { this["MATERIALUNITPRICE"] = value; }
        }

    /// <summary>
    /// Tutarı
    /// </summary>
        public double? MaterialTotalPrice
        {
            get { return (double?)this["MATERIALTOTALPRICE"]; }
            set { this["MATERIALTOTALPRICE"] = value; }
        }

        public UsedConsumedMaterail UsedConsumedMaterail
        {
            get { return (UsedConsumedMaterail)((ITTObject)this).GetParent("USEDCONSUMEDMATERAIL"); }
            set { this["USEDCONSUMEDMATERAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Repair Repair
        {
            get { return (Repair)((ITTObject)this).GetParent("REPAIR"); }
            set { this["REPAIR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReferToUpperLevel ReferToUpperLevel
        {
            get { return (ReferToUpperLevel)((ITTObject)this).GetParent("REFERTOUPPERLEVEL"); }
            set { this["REFERTOUPPERLEVEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MaintenanceOrder MaintenanceOrder
        {
            get { return (MaintenanceOrder)((ITTObject)this).GetParent("MAINTENANCEORDER"); }
            set { this["MAINTENANCEORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NeededMaterials(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NeededMaterials(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NeededMaterials(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NeededMaterials(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NeededMaterials(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NEEDEDMATERIALS", dataRow) { }
        protected NeededMaterials(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NEEDEDMATERIALS", dataRow, isImported) { }
        public NeededMaterials(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NeededMaterials(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NeededMaterials() : base() { }

    }
}