
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InpatientAdmissionTakenMaterial")] 

    /// <summary>
    /// Hasta Yatış Alınan Eşyalar Sekmesi
    /// </summary>
    public  partial class InpatientAdmissionTakenMaterial : TTObject
    {
        public class InpatientAdmissionTakenMaterialList : TTObjectCollection<InpatientAdmissionTakenMaterial> { }
                    
        public class ChildInpatientAdmissionTakenMaterialCollection : TTObject.TTChildObjectCollection<InpatientAdmissionTakenMaterial>
        {
            public ChildInpatientAdmissionTakenMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInpatientAdmissionTakenMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetInpatientAdmissionTakenMaterials_Class : TTReportNqlObject 
        {
            public DateTime? ProcessDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONTAKENMATERIAL"].AllPropertyDefs["PROCESSDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONTAKENMATERIAL"].AllPropertyDefs["AMOUNT"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONTAKENMATERIAL"].AllPropertyDefs["PERSONWHOGIVEMATERIALS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONTAKENMATERIAL"].AllPropertyDefs["PERSONWHOTAKEMATERIALS"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONTAKENMATERIAL"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetInpatientAdmissionTakenMaterials_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetInpatientAdmissionTakenMaterials_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetInpatientAdmissionTakenMaterials_Class() : base() { }
        }

        public static BindingList<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class> GetInpatientAdmissionTakenMaterials(string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONTAKENMATERIAL"].QueryDefs["GetInpatientAdmissionTakenMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class>(queryDef, paramList, pi);
        }

        public static BindingList<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class> GetInpatientAdmissionTakenMaterials(TTObjectContext objectContext, string EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSIONTAKENMATERIAL"].QueryDefs["GetInpatientAdmissionTakenMaterials"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<InpatientAdmissionTakenMaterial.GetInpatientAdmissionTakenMaterials_Class>(objectContext, queryDef, paramList, pi);
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
    /// İşlem Tarihi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
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
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Alınan Eşyalar Sekmesi
    /// </summary>
        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Alınan Eşya
    /// </summary>
        public QuarantineMaterialDefinition Material
        {
            get { return (QuarantineMaterialDefinition)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InpatientAdmissionTakenMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InpatientAdmissionTakenMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InpatientAdmissionTakenMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InpatientAdmissionTakenMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InpatientAdmissionTakenMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTADMISSIONTAKENMATERIAL", dataRow) { }
        protected InpatientAdmissionTakenMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTADMISSIONTAKENMATERIAL", dataRow, isImported) { }
        public InpatientAdmissionTakenMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InpatientAdmissionTakenMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InpatientAdmissionTakenMaterial() : base() { }

    }
}