
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CalibratorFixedAssetMaterial")] 

    /// <summary>
    /// Kalibratör Sekmesi
    /// </summary>
    public  partial class CalibratorFixedAssetMaterial : TTObject
    {
        public class CalibratorFixedAssetMaterialList : TTObjectCollection<CalibratorFixedAssetMaterial> { }
                    
        public class ChildCalibratorFixedAssetMaterialCollection : TTObject.TTChildObjectCollection<CalibratorFixedAssetMaterial>
        {
            public ChildCalibratorFixedAssetMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCalibratorFixedAssetMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CalibratorCertificationReportQuery_Class : TTReportNqlObject 
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

            public string Traceability
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRACEABILITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATORFIXEDASSETMATERIAL"].AllPropertyDefs["TRACEABILITY"].DataType;
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

            public CalibratorCertificationReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CalibratorCertificationReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CalibratorCertificationReportQuery_Class() : base() { }
        }

    /// <summary>
    /// Kalibrasyon Yapımında Kullanılan Malzemeler
    /// </summary>
        public static BindingList<CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery_Class> CalibratorCertificationReportQuery(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATORFIXEDASSETMATERIAL"].QueryDefs["CalibratorCertificationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Kalibrasyon Yapımında Kullanılan Malzemeler
    /// </summary>
        public static BindingList<CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery_Class> CalibratorCertificationReportQuery(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATORFIXEDASSETMATERIAL"].QueryDefs["CalibratorCertificationReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<CalibratorFixedAssetMaterial.CalibratorCertificationReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İzlenebilirlik
    /// </summary>
        public string Traceability
        {
            get { return (string)this["TRACEABILITY"]; }
            set { this["TRACEABILITY"] = value; }
        }

        public Calibration Calibration
        {
            get { return (Calibration)((ITTObject)this).GetParent("CALIBRATION"); }
            set { this["CALIBRATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CalibratorFixedAssetMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CalibratorFixedAssetMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CalibratorFixedAssetMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CalibratorFixedAssetMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CalibratorFixedAssetMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CALIBRATORFIXEDASSETMATERIAL", dataRow) { }
        protected CalibratorFixedAssetMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CALIBRATORFIXEDASSETMATERIAL", dataRow, isImported) { }
        public CalibratorFixedAssetMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CalibratorFixedAssetMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CalibratorFixedAssetMaterial() : base() { }

    }
}