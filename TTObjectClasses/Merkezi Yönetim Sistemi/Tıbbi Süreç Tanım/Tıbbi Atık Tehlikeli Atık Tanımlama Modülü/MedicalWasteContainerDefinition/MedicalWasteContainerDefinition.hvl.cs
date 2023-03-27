
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalWasteContainerDefinition")] 

    public  partial class MedicalWasteContainerDefinition : TTDefinitionSet
    {
        public class MedicalWasteContainerDefinitionList : TTObjectCollection<MedicalWasteContainerDefinition> { }
                    
        public class ChildMedicalWasteContainerDefinitionCollection : TTObject.TTChildObjectCollection<MedicalWasteContainerDefinition>
        {
            public ChildMedicalWasteContainerDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalWasteContainerDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalWasteContainerList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Capacity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPACITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].AllPropertyDefs["CAPACITY"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public GetMedicalWasteContainerList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalWasteContainerList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalWasteContainerList_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedicalWasteContainerNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Capacity
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CAPACITY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].AllPropertyDefs["CAPACITY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedicalWasteContainerNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalWasteContainerNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalWasteContainerNQL_Class() : base() { }
        }

        public static BindingList<MedicalWasteContainerDefinition.GetMedicalWasteContainerList_Class> GetMedicalWasteContainerList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].QueryDefs["GetMedicalWasteContainerList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteContainerDefinition.GetMedicalWasteContainerList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteContainerDefinition.GetMedicalWasteContainerList_Class> GetMedicalWasteContainerList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].QueryDefs["GetMedicalWasteContainerList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteContainerDefinition.GetMedicalWasteContainerList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteContainerDefinition.GetMedicalWasteContainerNQL_Class> GetMedicalWasteContainerNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].QueryDefs["GetMedicalWasteContainerNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteContainerDefinition.GetMedicalWasteContainerNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalWasteContainerDefinition.GetMedicalWasteContainerNQL_Class> GetMedicalWasteContainerNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALWASTECONTAINERDEFINITION"].QueryDefs["GetMedicalWasteContainerNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalWasteContainerDefinition.GetMedicalWasteContainerNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kapasite
    /// </summary>
        public int? Capacity
        {
            get { return (int?)this["CAPACITY"]; }
            set { this["CAPACITY"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected MedicalWasteContainerDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalWasteContainerDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalWasteContainerDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalWasteContainerDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalWasteContainerDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALWASTECONTAINERDEFINITION", dataRow) { }
        protected MedicalWasteContainerDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALWASTECONTAINERDEFINITION", dataRow, isImported) { }
        public MedicalWasteContainerDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalWasteContainerDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalWasteContainerDefinition() : base() { }

    }
}