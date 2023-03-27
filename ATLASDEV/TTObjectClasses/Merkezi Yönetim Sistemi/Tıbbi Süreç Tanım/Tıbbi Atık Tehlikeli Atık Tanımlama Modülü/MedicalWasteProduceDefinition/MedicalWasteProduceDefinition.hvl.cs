
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalWasteProduceDefinition")] 

    /// <summary>
    /// Tıbbi Atık Tehlikeli Atık Ürün Tanımlama
    /// </summary>
    public  partial class MedicalWasteProduceDefinition : TTDefinitionSet
    {
        public class MedicalWasteProduceDefinitionList : TTObjectCollection<MedicalWasteProduceDefinition> { }
                    
        public class ChildMedicalWasteProduceDefinitionCollection : TTObject.TTChildObjectCollection<MedicalWasteProduceDefinition>
        {
            public ChildMedicalWasteProduceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalWasteProduceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalWasteProduceNQL_Class : TTReportNqlObject 
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

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedicalWasteProduceNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalWasteProduceNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalWasteProduceNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedicalWasteProcedureList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Typeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TYPEOBJECTID"]);
                }
            }

            public GetMedicalWasteProcedureList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalWasteProcedureList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalWasteProcedureList_Class() : base() { }
        }

        public static BindingList<MedicalWasteProduceDefinition.GetMedicalWasteProduceNQL_Class> GetMedicalWasteProduceNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].QueryDefs["GetMedicalWasteProduceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteProduceDefinition.GetMedicalWasteProduceNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteProduceDefinition.GetMedicalWasteProduceNQL_Class> GetMedicalWasteProduceNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].QueryDefs["GetMedicalWasteProduceNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteProduceDefinition.GetMedicalWasteProduceNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteProduceDefinition.GetMedicalWasteProcedureList_Class> GetMedicalWasteProcedureList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].QueryDefs["GetMedicalWasteProcedureList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteProduceDefinition.GetMedicalWasteProcedureList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteProduceDefinition.GetMedicalWasteProcedureList_Class> GetMedicalWasteProcedureList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTEPRODUCEDEFINITION"].QueryDefs["GetMedicalWasteProcedureList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteProduceDefinition.GetMedicalWasteProcedureList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public MedicalWasteTypeDefinition MedicalWasteType
        {
            get { return (MedicalWasteTypeDefinition)((ITTObject)this).GetParent("MEDICALWASTETYPE"); }
            set { this["MEDICALWASTETYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MedicalWasteProduceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalWasteProduceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalWasteProduceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalWasteProduceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalWasteProduceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALWASTEPRODUCEDEFINITION", dataRow) { }
        protected MedicalWasteProduceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALWASTEPRODUCEDEFINITION", dataRow, isImported) { }
        public MedicalWasteProduceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalWasteProduceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalWasteProduceDefinition() : base() { }

    }
}