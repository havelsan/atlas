
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RTFDefinitionsBySpeciality")] 

    public  partial class RTFDefinitionsBySpeciality : TerminologyManagerDef
    {
        public class RTFDefinitionsBySpecialityList : TTObjectCollection<RTFDefinitionsBySpeciality> { }
                    
        public class ChildRTFDefinitionsBySpecialityCollection : TTObject.TTChildObjectCollection<RTFDefinitionsBySpeciality>
        {
            public ChildRTFDefinitionsBySpecialityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRTFDefinitionsBySpecialityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRTFDefinitionsBySpecialityDefinition_Class : TTReportNqlObject 
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

            public string Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RTFDEFINITIONSBYSPECIALITY"].AllPropertyDefs["TITLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsNeedForEpicrisis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNEEDFOREPICRISIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RTFDEFINITIONSBYSPECIALITY"].AllPropertyDefs["ISNEEDFOREPICRISIS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRTFDefinitionsBySpecialityDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRTFDefinitionsBySpecialityDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRTFDefinitionsBySpecialityDefinition_Class() : base() { }
        }

        public static BindingList<RTFDefinitionsBySpeciality> GetBySpeciality(TTObjectContext objectContext, Guid SPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RTFDEFINITIONSBYSPECIALITY"].QueryDefs["GetBySpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALITY", SPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<RTFDefinitionsBySpeciality>(queryDef, paramList);
        }

        public static BindingList<RTFDefinitionsBySpeciality.GetRTFDefinitionsBySpecialityDefinition_Class> GetRTFDefinitionsBySpecialityDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RTFDEFINITIONSBYSPECIALITY"].QueryDefs["GetRTFDefinitionsBySpecialityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RTFDefinitionsBySpeciality.GetRTFDefinitionsBySpecialityDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RTFDefinitionsBySpeciality.GetRTFDefinitionsBySpecialityDefinition_Class> GetRTFDefinitionsBySpecialityDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RTFDEFINITIONSBYSPECIALITY"].QueryDefs["GetRTFDefinitionsBySpecialityDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RTFDefinitionsBySpeciality.GetRTFDefinitionsBySpecialityDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

        public bool? IsNeedForEpicrisis
        {
            get { return (bool?)this["ISNEEDFOREPICRISIS"]; }
            set { this["ISNEEDFOREPICRISIS"] = value; }
        }

    /// <summary>
    /// Uzmanlık
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RTFDefinitionsBySpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RTFDefinitionsBySpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RTFDefinitionsBySpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RTFDefinitionsBySpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RTFDefinitionsBySpeciality(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RTFDEFINITIONSBYSPECIALITY", dataRow) { }
        protected RTFDefinitionsBySpeciality(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RTFDEFINITIONSBYSPECIALITY", dataRow, isImported) { }
        public RTFDefinitionsBySpeciality(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RTFDefinitionsBySpeciality(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RTFDefinitionsBySpeciality() : base() { }

    }
}