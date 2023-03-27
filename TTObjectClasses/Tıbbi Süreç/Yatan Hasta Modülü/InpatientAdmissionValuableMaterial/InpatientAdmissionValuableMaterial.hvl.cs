
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientAdmissionValuableMaterial")] 

    /// <summary>
    /// Geri Verilmesi Zorunlu  Eşyalar 
    /// </summary>
    public  partial class InpatientAdmissionValuableMaterial : BaseQuarantineValuableMaterial
    {
        public class InpatientAdmissionValuableMaterialList : TTObjectCollection<InpatientAdmissionValuableMaterial> { }
                    
        public class ChildInpatientAdmissionValuableMaterialCollection : TTObject.TTChildObjectCollection<InpatientAdmissionValuableMaterial>
        {
            public ChildInpatientAdmissionValuableMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientAdmissionValuableMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientAdmissionValuableMaterialsNQL_Class : TTReportNqlObject 
        {
            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public QuarantineProcessTypeEnum? QuarantineProcessType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROCESSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["QUARANTINEPROCESSTYPE"].DataType;
                    return (QuarantineProcessTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string PersonWhoGiveMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONWHOGIVEMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["PERSONWHOGIVEMATERIALS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PersonWhoTakeMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONWHOTAKEMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["PERSONWHOTAKEMATERIALS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUARANTINEMATERIALDEFINITION"].AllPropertyDefs["MATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientAdmissionValuableMaterialsNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAdmissionValuableMaterialsNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAdmissionValuableMaterialsNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetInpatientAdmissionValuableMaterial_Class : TTReportNqlObject 
        {
            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["PROCESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public QuarantineProcessTypeEnum? QuarantineProcessType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROCESSTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["QUARANTINEPROCESSTYPE"].DataType;
                    return (QuarantineProcessTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string PersonWhoGiveMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONWHOGIVEMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["PERSONWHOGIVEMATERIALS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PersonWhoTakeMaterials
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONWHOTAKEMATERIALS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["PERSONWHOTAKEMATERIALS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUARANTINEMATERIALDEFINITION"].AllPropertyDefs["MATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientAdmissionValuableMaterial_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAdmissionValuableMaterial_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAdmissionValuableMaterial_Class() : base() { }
        }

        public static BindingList<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class> GetInpatientAdmissionValuableMaterialsNQL(string EPISODE, QuarantineProcessTypeEnum PROCESSTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].QueryDefs["GetInpatientAdmissionValuableMaterialsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PROCESSTYPE", (int)PROCESSTYPE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class> GetInpatientAdmissionValuableMaterialsNQL(TTObjectContext objectContext, string EPISODE, QuarantineProcessTypeEnum PROCESSTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].QueryDefs["GetInpatientAdmissionValuableMaterialsNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PROCESSTYPE", (int)PROCESSTYPE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterialsNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterial_Class> GetInpatientAdmissionValuableMaterial(string EPISODE, QuarantineProcessTypeEnum PROCESSTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].QueryDefs["GetInpatientAdmissionValuableMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PROCESSTYPE", (int)PROCESSTYPE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterial_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterial_Class> GetInpatientAdmissionValuableMaterial(TTObjectContext objectContext, string EPISODE, QuarantineProcessTypeEnum PROCESSTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONVALUABLEMATERIAL"].QueryDefs["GetInpatientAdmissionValuableMaterial"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("PROCESSTYPE", (int)PROCESSTYPE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionValuableMaterial.GetInpatientAdmissionValuableMaterial_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Değerli Eşya
    /// </summary>
        public QuarantineMaterialDefinition Material
        {
            get { return (QuarantineMaterialDefinition)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientAdmissionValuableMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientAdmissionValuableMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientAdmissionValuableMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientAdmissionValuableMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientAdmissionValuableMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTADMISSIONVALUABLEMATERIAL", dataRow) { }
        protected InpatientAdmissionValuableMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTADMISSIONVALUABLEMATERIAL", dataRow, isImported) { }
        public InpatientAdmissionValuableMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientAdmissionValuableMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientAdmissionValuableMaterial() : base() { }

    }
}