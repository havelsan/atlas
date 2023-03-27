
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationQueueDefinition")] 

    /// <summary>
    /// Randevu Kuyruğu Tanımlama
    /// </summary>
    public  partial class ExaminationQueueDefinition : TTDefinitionSet
    {
        public class ExaminationQueueDefinitionList : TTObjectCollection<ExaminationQueueDefinition> { }
                    
        public class ChildExaminationQueueDefinitionCollection : TTObject.TTChildObjectCollection<ExaminationQueueDefinition>
        {
            public ChildExaminationQueueDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationQueueDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetExaminationQueues_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Sectionname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetExaminationQueues_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetExaminationQueues_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetExaminationQueues_Class() : base() { }
        }

        [Serializable] 

        public partial class GetActiveEmergencyQueues_Class : TTReportNqlObject 
        {
            public Guid? Ressectionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESSECTIONID"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetActiveEmergencyQueues_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveEmergencyQueues_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveEmergencyQueues_Class() : base() { }
        }

        public static BindingList<ExaminationQueueDefinition> GetExaminationQueueDefs(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetExaminationQueueDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<ExaminationQueueDefinition> GetQueueByResource(TTObjectContext objectContext, string RESOURCE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetQueueByResource"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCE", RESOURCE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueDefinition>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueDefinition.GetExaminationQueues_Class> GetExaminationQueues(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetExaminationQueues"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExaminationQueueDefinition.GetExaminationQueues_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExaminationQueueDefinition.GetExaminationQueues_Class> GetExaminationQueues(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetExaminationQueues"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExaminationQueueDefinition.GetExaminationQueues_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExaminationQueueDefinition> GetEmergencyQueues(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetEmergencyQueues"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueDefinition>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueDefinition> GetQueuesByResources(TTObjectContext objectContext, IList<Guid> RESOURCES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetQueuesByResources"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESOURCES", RESOURCES);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationQueueDefinition>(queryDef, paramList);
        }

        public static BindingList<ExaminationQueueDefinition.GetActiveEmergencyQueues_Class> GetActiveEmergencyQueues(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetActiveEmergencyQueues"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExaminationQueueDefinition.GetActiveEmergencyQueues_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ExaminationQueueDefinition.GetActiveEmergencyQueues_Class> GetActiveEmergencyQueues(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONQUEUEDEFINITION"].QueryDefs["GetActiveEmergencyQueues"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExaminationQueueDefinition.GetActiveEmergencyQueues_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Sıradan düşürmeden önce kaç defa çağrılabilsin?

    /// </summary>
        public int? RecallCount
        {
            get { return (int?)this["RECALLCOUNT"]; }
            set { this["RECALLCOUNT"] = value; }
        }

    /// <summary>
    /// Acil Kuyruğu mu?
    /// </summary>
        public bool? IsEmergencyQueue
        {
            get { return (bool?)this["ISEMERGENCYQUEUE"]; }
            set { this["ISEMERGENCYQUEUE"] = value; }
        }

        public bool? NotAllowToSelectDoctor
        {
            get { return (bool?)this["NOTALLOWTOSELECTDOCTOR"]; }
            set { this["NOTALLOWTOSELECTDOCTOR"] = value; }
        }

    /// <summary>
    /// Aktif mi?
    /// </summary>
        public bool? IsActiveQueue
        {
            get { return (bool?)this["ISACTIVEQUEUE"]; }
            set { this["ISACTIVEQUEUE"] = value; }
        }

        public bool? IgnorePriority
        {
            get { return (bool?)this["IGNOREPRIORITY"]; }
            set { this["IGNOREPRIORITY"] = value; }
        }

    /// <summary>
    /// Görüntüleme Periyodu
    /// </summary>
        public int? DisplayPeriod
        {
            get { return (int?)this["DISPLAYPERIOD"]; }
            set { this["DISPLAYPERIOD"] = value; }
        }

    /// <summary>
    /// Kuyruk Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Öteleme Zamanı
    /// </summary>
        public int? DivertTime
        {
            get { return (int?)this["DIVERTTIME"]; }
            set { this["DIVERTTIME"] = value; }
        }

        public QueuePriorityTemplateDef QueuePriorityTemplateDef
        {
            get { return (QueuePriorityTemplateDef)((ITTObject)this).GetParent("QUEUEPRIORITYTEMPLATEDEF"); }
            set { this["QUEUEPRIORITYTEMPLATEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection ResSection
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESSECTION"); }
            set { this["RESSECTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateQueueResourceDefCollection()
        {
            _QueueResourceDef = new QueueResourceWorkPlanDefinition.ChildQueueResourceWorkPlanDefinitionCollection(this, new Guid("23c72b1c-025e-41e3-aed1-bf6a162a9811"));
            ((ITTChildObjectCollection)_QueueResourceDef).GetChildren();
        }

        protected QueueResourceWorkPlanDefinition.ChildQueueResourceWorkPlanDefinitionCollection _QueueResourceDef = null;
        public QueueResourceWorkPlanDefinition.ChildQueueResourceWorkPlanDefinitionCollection QueueResourceDef
        {
            get
            {
                if (_QueueResourceDef == null)
                    CreateQueueResourceDefCollection();
                return _QueueResourceDef;
            }
        }

        protected ExaminationQueueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationQueueDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationQueueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationQueueDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationQueueDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONQUEUEDEFINITION", dataRow) { }
        protected ExaminationQueueDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONQUEUEDEFINITION", dataRow, isImported) { }
        public ExaminationQueueDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationQueueDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationQueueDefinition() : base() { }

    }
}