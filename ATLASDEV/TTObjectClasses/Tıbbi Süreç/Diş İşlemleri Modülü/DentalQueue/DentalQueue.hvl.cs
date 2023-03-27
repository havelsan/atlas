
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalQueue")] 

    /// <summary>
    /// Diş İşlemi Randevusu
    /// </summary>
    public  partial class DentalQueue : TTObject
    {
        public class DentalQueueList : TTObjectCollection<DentalQueue> { }
                    
        public class ChildDentalQueueCollection : TTObject.TTChildObjectCollection<DentalQueue>
        {
            public ChildDentalQueueCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalQueueCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid New { get { return new Guid("b7915dc0-b091-40b9-b624-eed3042ab0bd"); } }
            public static Guid Completed { get { return new Guid("0c533894-dabb-4600-87bf-0bd89cf77775"); } }
            public static Guid Cancelled { get { return new Guid("652a15bd-d165-4866-97e8-5b8fca1ed024"); } }
        }

        public static BindingList<DentalQueue> GetDentalQueueById(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALQUEUE"].QueryDefs["GetDentalQueueById"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<DentalQueue>(queryDef, paramList);
        }

        public static BindingList<DentalQueue> DentalQueueItems(TTObjectContext objectContext, Guid PATIENT, DateTime QUEUEENDDATE, DateTime QUEUESTARTDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALQUEUE"].QueryDefs["DentalQueueItems"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);

            return ((ITTQuery)objectContext).QueryObjects<DentalQueue>(queryDef, paramList);
        }

        public static BindingList<DentalQueue> DentalQueueItemsAll(TTObjectContext objectContext, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALQUEUE"].QueryDefs["DentalQueueItemsAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DentalQueue>(queryDef, paramList);
        }

        public static BindingList<DentalQueue> DentalQueueItemsByProcedure(TTObjectContext objectContext, DateTime QUEUESTARTDATE, DateTime QUEUEENDDATE, Guid PROCEDUREDEFINITION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALQUEUE"].QueryDefs["DentalQueueItemsByProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("QUEUESTARTDATE", QUEUESTARTDATE);
            paramList.Add("QUEUEENDDATE", QUEUEENDDATE);
            paramList.Add("PROCEDUREDEFINITION", PROCEDUREDEFINITION);

            return ((ITTQuery)objectContext).QueryObjects<DentalQueue>(queryDef, paramList);
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? QueueDate
        {
            get { return (DateTime?)this["QUEUEDATE"]; }
            set { this["QUEUEDATE"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
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
    /// Seçili Dişler
    /// </summary>
        public string ToothNumbers
        {
            get { return (string)this["TOOTHNUMBERS"]; }
            set { this["TOOTHNUMBERS"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalExamination DentalExamination
        {
            get { return (DentalExamination)((ITTObject)this).GetParent("DENTALEXAMINATION"); }
            set { this["DENTALEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalQueue(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalQueue(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalQueue(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalQueue(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalQueue(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALQUEUE", dataRow) { }
        protected DentalQueue(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALQUEUE", dataRow, isImported) { }
        public DentalQueue(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalQueue(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalQueue() : base() { }

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