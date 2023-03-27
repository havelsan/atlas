
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTestDescriptionDefinition")] 

    /// <summary>
    /// Radyoloji Tetkik Açıklama Tanımları
    /// </summary>
    public  partial class RadiologyTestDescriptionDefinition : TTDefinitionSet
    {
        public class RadiologyTestDescriptionDefinitionList : TTObjectCollection<RadiologyTestDescriptionDefinition> { }
                    
        public class ChildRadiologyTestDescriptionDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyTestDescriptionDefinition>
        {
            public ChildRadiologyTestDescriptionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTestDescriptionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiologyTestDescriptionDefinitionNQL_Class : TTReportNqlObject 
        {
            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDESCRIPTIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDESCRIPTIONDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetRadiologyTestDescriptionDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTestDescriptionDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTestDescriptionDefinitionNQL_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("344e2236-1e05-4934-a428-8dc6fa7c01dc"); } }
            public static Guid Completed { get { return new Guid("62d49f58-b408-48a8-afe0-8e953e57fabd"); } }
        }

        public static BindingList<RadiologyTestDescriptionDefinition.GetRadiologyTestDescriptionDefinitionNQL_Class> GetRadiologyTestDescriptionDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDESCRIPTIONDEFINITION"].QueryDefs["GetRadiologyTestDescriptionDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestDescriptionDefinition.GetRadiologyTestDescriptionDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTestDescriptionDefinition.GetRadiologyTestDescriptionDefinitionNQL_Class> GetRadiologyTestDescriptionDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTDESCRIPTIONDEFINITION"].QueryDefs["GetRadiologyTestDescriptionDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestDescriptionDefinition.GetRadiologyTestDescriptionDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kısa Açıklama
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
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
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Kalın
    /// </summary>
        public bool? Bold
        {
            get { return (bool?)this["BOLD"]; }
            set { this["BOLD"] = value; }
        }

        protected RadiologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTestDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTestDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTESTDESCRIPTIONDEFINITION", dataRow) { }
        protected RadiologyTestDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTESTDESCRIPTIONDEFINITION", dataRow, isImported) { }
        public RadiologyTestDescriptionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTestDescriptionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTestDescriptionDefinition() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}