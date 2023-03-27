
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialityBasedObject")] 

    public  partial class SpecialityBasedObject : TTObject
    {
        public class SpecialityBasedObjectList : TTObjectCollection<SpecialityBasedObject> { }
                    
        public class ChildSpecialityBasedObjectCollection : TTObject.TTChildObjectCollection<SpecialityBasedObject>
        {
            public ChildSpecialityBasedObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialityBasedObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOldInfoForSpeciality_Class : TTReportNqlObject 
        {
            public String Objectdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEF"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Doctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANAPPLICATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetOldInfoForSpeciality_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldInfoForSpeciality_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldInfoForSpeciality_Class() : base() { }
        }

        public static BindingList<SpecialityBasedObject.GetOldInfoForSpeciality_Class> GetOldInfoForSpeciality(Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYBASEDOBJECT"].QueryDefs["GetOldInfoForSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SpecialityBasedObject.GetOldInfoForSpeciality_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SpecialityBasedObject.GetOldInfoForSpeciality_Class> GetOldInfoForSpeciality(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYBASEDOBJECT"].QueryDefs["GetOldInfoForSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<SpecialityBasedObject.GetOldInfoForSpeciality_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public PhysicianApplication PhysicianApplication
        {
            get { return (PhysicianApplication)((ITTObject)this).GetParent("PHYSICIANAPPLICATION"); }
            set { this["PHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PhysicianApplication OldPhysicianApplication
        {
            get { return (PhysicianApplication)((ITTObject)this).GetParent("OLDPHYSICIANAPPLICATION"); }
            set { this["OLDPHYSICIANAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected SpecialityBasedObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialityBasedObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialityBasedObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialityBasedObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialityBasedObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALITYBASEDOBJECT", dataRow) { }
        protected SpecialityBasedObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALITYBASEDOBJECT", dataRow, isImported) { }
        public SpecialityBasedObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialityBasedObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialityBasedObject() : base() { }

    }
}