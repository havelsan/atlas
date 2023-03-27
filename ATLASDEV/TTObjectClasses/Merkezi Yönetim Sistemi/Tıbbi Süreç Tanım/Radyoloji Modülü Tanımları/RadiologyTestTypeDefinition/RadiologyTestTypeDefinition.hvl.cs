
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTestTypeDefinition")] 

    /// <summary>
    /// Radyoloji Tetkik Tür Tanımları
    /// </summary>
    public  partial class RadiologyTestTypeDefinition : TTDefinitionSet
    {
        public class RadiologyTestTypeDefinitionList : TTObjectCollection<RadiologyTestTypeDefinition> { }
                    
        public class ChildRadiologyTestTypeDefinitionCollection : TTObject.TTChildObjectCollection<RadiologyTestTypeDefinition>
        {
            public ChildRadiologyTestTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTestTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiologyTestTypeDefinitionNQL_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Id
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["NAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? EstimatedAppointmentTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDAPPOINTMENTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["ESTIMATEDAPPOINTMENTTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? EstimatedCompletionTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ESTIMATEDCOMPLETIONTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].AllPropertyDefs["ESTIMATEDCOMPLETIONTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyTestTypeDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTestTypeDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTestTypeDefinitionNQL_Class() : base() { }
        }

        public static class States
        {
            public static Guid New { get { return new Guid("ef0f030e-f06b-4697-8a97-1cf3e1e04794"); } }
            public static Guid Completed { get { return new Guid("5f0703bc-4031-4989-86e5-e2127b97822f"); } }
        }

        public static BindingList<RadiologyTestTypeDefinition.GetRadiologyTestTypeDefinitionNQL_Class> GetRadiologyTestTypeDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].QueryDefs["GetRadiologyTestTypeDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestTypeDefinition.GetRadiologyTestTypeDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadiologyTestTypeDefinition.GetRadiologyTestTypeDefinitionNQL_Class> GetRadiologyTestTypeDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTESTTYPEDEFINITION"].QueryDefs["GetRadiologyTestTypeDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTestTypeDefinition.GetRadiologyTestTypeDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Id
    /// </summary>
        public long? Id
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Tahmini Randevu Verme Süresi
    /// </summary>
        public int? EstimatedAppointmentTime
        {
            get { return (int?)this["ESTIMATEDAPPOINTMENTTIME"]; }
            set { this["ESTIMATEDAPPOINTMENTTIME"] = value; }
        }

    /// <summary>
    /// Tahmini Sonuçlanma Süresi (Gün)
    /// </summary>
        public int? EstimatedCompletionTime
        {
            get { return (int?)this["ESTIMATEDCOMPLETIONTIME"]; }
            set { this["ESTIMATEDCOMPLETIONTIME"] = value; }
        }

        protected RadiologyTestTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTestTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTestTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTestTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTestTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTESTTYPEDEFINITION", dataRow) { }
        protected RadiologyTestTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTESTTYPEDEFINITION", dataRow, isImported) { }
        public RadiologyTestTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTestTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTestTypeDefinition() : base() { }

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