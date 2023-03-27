
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientAdmissionGivenMaterial")] 

    /// <summary>
    /// Verilen Eşyalar Sekmesi
    /// </summary>
    public  partial class InpatientAdmissionGivenMaterial : TTObject
    {
        public class InpatientAdmissionGivenMaterialList : TTObjectCollection<InpatientAdmissionGivenMaterial> { }
                    
        public class ChildInpatientAdmissionGivenMaterialCollection : TTObject.TTChildObjectCollection<InpatientAdmissionGivenMaterial>
        {
            public ChildInpatientAdmissionGivenMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientAdmissionGivenMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientAdmissionGivenMaterials_Class : TTReportNqlObject 
        {
            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONGIVENMATERIAL"].AllPropertyDefs["PROCESSDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["QUARANTINEMATERIALDEFINITION"].AllPropertyDefs["MATERIAL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONGIVENMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONGIVENMATERIAL"].AllPropertyDefs["PERSONWHOGIVEMATERIALS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONGIVENMATERIAL"].AllPropertyDefs["PERSONWHOTAKEMATERIALS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONGIVENMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientAdmissionGivenMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAdmissionGivenMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAdmissionGivenMaterials_Class() : base() { }
        }

        public static BindingList<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class> GetInpatientAdmissionGivenMaterials(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONGIVENMATERIAL"].QueryDefs["GetInpatientAdmissionGivenMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class> GetInpatientAdmissionGivenMaterials(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONGIVENMATERIAL"].QueryDefs["GetInpatientAdmissionGivenMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionGivenMaterial.GetInpatientAdmissionGivenMaterials_Class>(objectContext, queryDef, paramList, pi);
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
    /// Teslim Alan
    /// </summary>
        public string PersonWhoTakeMaterials
        {
            get { return (string)this["PERSONWHOTAKEMATERIALS"]; }
            set { this["PERSONWHOTAKEMATERIALS"] = value; }
        }

    /// <summary>
    /// İşlem Zamanı
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Teslim Eden
    /// </summary>
        public string PersonWhoGiveMaterials
        {
            get { return (string)this["PERSONWHOGIVEMATERIALS"]; }
            set { this["PERSONWHOGIVEMATERIALS"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public double? Amount
        {
            get { return (double?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// Durum
    /// </summary>
        public string Status
        {
            get { return (string)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Verilen Eşyalar Sekmesi
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Verilen Eşyalar
    /// </summary>
        public QuarantineMaterialDefinition Material
        {
            get { return (QuarantineMaterialDefinition)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientAdmissionGivenMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientAdmissionGivenMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientAdmissionGivenMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientAdmissionGivenMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientAdmissionGivenMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTADMISSIONGIVENMATERIAL", dataRow) { }
        protected InpatientAdmissionGivenMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTADMISSIONGIVENMATERIAL", dataRow, isImported) { }
        public InpatientAdmissionGivenMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientAdmissionGivenMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientAdmissionGivenMaterial() : base() { }

    }
}