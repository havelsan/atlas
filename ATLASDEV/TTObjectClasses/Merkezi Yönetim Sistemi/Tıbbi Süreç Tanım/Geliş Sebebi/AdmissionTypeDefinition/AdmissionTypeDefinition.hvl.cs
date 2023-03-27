
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdmissionTypeDefinition")] 

    /// <summary>
    /// Geliş Sebebi Tanımları
    /// </summary>
    public  partial class AdmissionTypeDefinition : TerminologyManagerDef
    {
        public class AdmissionTypeDefinitionList : TTObjectCollection<AdmissionTypeDefinition> { }
                    
        public class ChildAdmissionTypeDefinitionCollection : TTObject.TTChildObjectCollection<AdmissionTypeDefinition>
        {
            public ChildAdmissionTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdmissionTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAdmissionType_Class : TTReportNqlObject 
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

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONTYPEDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONTYPEDEFINITION"].AllPropertyDefs["ACTIVE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAdmissionType_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAdmissionType_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAdmissionType_Class() : base() { }
        }

        public static BindingList<AdmissionTypeDefinition.GetAdmissionType_Class> GetAdmissionType(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONTYPEDEFINITION"].QueryDefs["GetAdmissionType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AdmissionTypeDefinition.GetAdmissionType_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AdmissionTypeDefinition.GetAdmissionType_Class> GetAdmissionType(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONTYPEDEFINITION"].QueryDefs["GetAdmissionType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<AdmissionTypeDefinition.GetAdmissionType_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<AdmissionTypeDefinition> GetActiveAdmissionTypes(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADMISSIONTYPEDEFINITION"].QueryDefs["GetActiveAdmissionTypes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<AdmissionTypeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public ReasonForAdmission ReasonForAdmission
        {
            get { return (ReasonForAdmission)((ITTObject)this).GetParent("REASONFORADMISSION"); }
            set { this["REASONFORADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AdmissionTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdmissionTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdmissionTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdmissionTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdmissionTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADMISSIONTYPEDEFINITION", dataRow) { }
        protected AdmissionTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADMISSIONTYPEDEFINITION", dataRow, isImported) { }
        protected AdmissionTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdmissionTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdmissionTypeDefinition() : base() { }

    }
}