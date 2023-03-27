
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalWasteTypeDefinition")] 

    /// <summary>
    /// Tıbbi Atık Tehlikeli Atık İşlem Türü tanımı
    /// </summary>
    public  partial class MedicalWasteTypeDefinition : TTDefinitionSet
    {
        public class MedicalWasteTypeDefinitionList : TTObjectCollection<MedicalWasteTypeDefinition> { }
                    
        public class ChildMedicalWasteTypeDefinitionCollection : TTObject.TTChildObjectCollection<MedicalWasteTypeDefinition>
        {
            public ChildMedicalWasteTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalWasteTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalWasteTypeNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedicalWasteTypeNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalWasteTypeNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalWasteTypeNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedicalWasteTypeList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
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

            public GetMedicalWasteTypeList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalWasteTypeList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalWasteTypeList_Class() : base() { }
        }

        public static BindingList<MedicalWasteTypeDefinition.GetMedicalWasteTypeNQL_Class> GetMedicalWasteTypeNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].QueryDefs["GetMedicalWasteTypeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteTypeDefinition.GetMedicalWasteTypeNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteTypeDefinition.GetMedicalWasteTypeNQL_Class> GetMedicalWasteTypeNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].QueryDefs["GetMedicalWasteTypeNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteTypeDefinition.GetMedicalWasteTypeNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteTypeDefinition.GetMedicalWasteTypeList_Class> GetMedicalWasteTypeList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].QueryDefs["GetMedicalWasteTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteTypeDefinition.GetMedicalWasteTypeList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteTypeDefinition.GetMedicalWasteTypeList_Class> GetMedicalWasteTypeList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTETYPEDEFINITION"].QueryDefs["GetMedicalWasteTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteTypeDefinition.GetMedicalWasteTypeList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected MedicalWasteTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalWasteTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalWasteTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalWasteTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalWasteTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALWASTETYPEDEFINITION", dataRow) { }
        protected MedicalWasteTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALWASTETYPEDEFINITION", dataRow, isImported) { }
        public MedicalWasteTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalWasteTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalWasteTypeDefinition() : base() { }

    }
}