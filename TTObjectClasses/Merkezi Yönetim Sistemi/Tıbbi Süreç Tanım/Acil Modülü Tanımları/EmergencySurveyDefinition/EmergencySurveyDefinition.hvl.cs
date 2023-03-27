
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EmergencySurveyDefinition")] 

    public  partial class EmergencySurveyDefinition : TTDefinitionSet
    {
        public class EmergencySurveyDefinitionList : TTObjectCollection<EmergencySurveyDefinition> { }
                    
        public class ChildEmergencySurveyDefinitionCollection : TTObject.TTChildObjectCollection<EmergencySurveyDefinition>
        {
            public ChildEmergencySurveyDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEmergencySurveyDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetEmergencySurveyDefinitionList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSURVEYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public EmergencySurveyEnum? ActivityGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVITYGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSURVEYDEFINITION"].AllPropertyDefs["ACTIVITYGROUP"].DataType;
                    return (EmergencySurveyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Object Groupname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["GROUPNAME"]);
                }
            }

            public Object Text
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TEXT"]);
                }
            }

            public GetEmergencySurveyDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetEmergencySurveyDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetEmergencySurveyDefinitionList_Class() : base() { }
        }

        public static BindingList<EmergencySurveyDefinition.GetEmergencySurveyDefinitionList_Class> GetEmergencySurveyDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSURVEYDEFINITION"].QueryDefs["GetEmergencySurveyDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EmergencySurveyDefinition.GetEmergencySurveyDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EmergencySurveyDefinition.GetEmergencySurveyDefinitionList_Class> GetEmergencySurveyDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSURVEYDEFINITION"].QueryDefs["GetEmergencySurveyDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<EmergencySurveyDefinition.GetEmergencySurveyDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<EmergencySurveyDefinition> GetAllEmergencySurveyDefList(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EMERGENCYSURVEYDEFINITION"].QueryDefs["GetAllEmergencySurveyDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<EmergencySurveyDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Grup
    /// </summary>
        public EmergencySurveyEnum? ActivityGroup
        {
            get { return (EmergencySurveyEnum?)(int?)this["ACTIVITYGROUP"]; }
            set { this["ACTIVITYGROUP"] = value; }
        }

    /// <summary>
    /// Adı
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

        virtual protected void CreateEmergencySurveyObjectsCollection()
        {
            _EmergencySurveyObjects = new EmergencySurveyObject.ChildEmergencySurveyObjectCollection(this, new Guid("bf3e8415-4a89-476f-99d1-ea0284fed4df"));
            ((ITTChildObjectCollection)_EmergencySurveyObjects).GetChildren();
        }

        protected EmergencySurveyObject.ChildEmergencySurveyObjectCollection _EmergencySurveyObjects = null;
        public EmergencySurveyObject.ChildEmergencySurveyObjectCollection EmergencySurveyObjects
        {
            get
            {
                if (_EmergencySurveyObjects == null)
                    CreateEmergencySurveyObjectsCollection();
                return _EmergencySurveyObjects;
            }
        }

        protected EmergencySurveyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EmergencySurveyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EmergencySurveyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EmergencySurveyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EmergencySurveyDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EMERGENCYSURVEYDEFINITION", dataRow) { }
        protected EmergencySurveyDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EMERGENCYSURVEYDEFINITION", dataRow, isImported) { }
        public EmergencySurveyDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EmergencySurveyDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EmergencySurveyDefinition() : base() { }

    }
}