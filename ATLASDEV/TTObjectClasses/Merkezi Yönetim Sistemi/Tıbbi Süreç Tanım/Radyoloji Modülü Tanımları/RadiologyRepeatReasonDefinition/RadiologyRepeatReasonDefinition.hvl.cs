
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyRepeatReasonDefinition")] 

    /// <summary>
    /// Radyoloji Tekrar Neden Tanımları
    /// </summary>
    public  partial class RadiologyRepeatReasonDefinition : TTDefinitionSet
    {
        public class RadiologyRepeatReasonDefinitionList : TTObjectCollection<RadiologyRepeatReasonDefinition> { }
                    
        public class ChildRadiologyRepeatReasonDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyRepeatReasonDefinition>
        {
            public ChildRadiologyRepeatReasonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyRepeatReasonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiologyRepeatReasonDefinition_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYREPEATREASONDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYREPEATREASONDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRadiologyRepeatReasonDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyRepeatReasonDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyRepeatReasonDefinition_Class() : base() { }
        }

        public static BindingList<RadiologyRepeatReasonDefinition> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYREPEATREASONDEFINITION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RadiologyRepeatReasonDefinition>(queryDef, paramList);
        }

        public static BindingList<RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition_Class> GetRadiologyRepeatReasonDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYREPEATREASONDEFINITION"].QueryDefs["GetRadiologyRepeatReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition_Class> GetRadiologyRepeatReasonDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYREPEATREASONDEFINITION"].QueryDefs["GetRadiologyRepeatReasonDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyRepeatReasonDefinition.GetRadiologyRepeatReasonDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        protected RadiologyRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyRepeatReasonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyRepeatReasonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYREPEATREASONDEFINITION", dataRow) { }
        protected RadiologyRepeatReasonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYREPEATREASONDEFINITION", dataRow, isImported) { }
        public RadiologyRepeatReasonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyRepeatReasonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyRepeatReasonDefinition() : base() { }

    }
}