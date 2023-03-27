
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNursingDataEntry")] 

    /// <summary>
    /// Ana Hemşirelik Veri Girişi
    /// </summary>
    public  partial class BaseNursingDataEntry : TTObject
    {
        public class BaseNursingDataEntryList : TTObjectCollection<BaseNursingDataEntry> { }
                    
        public class ChildBaseNursingDataEntryCollection : TTObject.TTChildObjectCollection<BaseNursingDataEntry>
        {
            public ChildBaseNursingDataEntryCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNursingDataEntryCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<BaseNursingDataEntry> GetBaseNursingDataByType(TTObjectContext objectContext, string OBJECTDEFNAME, Guid NURSINGAPPLICATION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGDATAENTRY"].QueryDefs["GetBaseNursingDataByType"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTDEFNAME", OBJECTDEFNAME);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return ((ITTQuery)objectContext).QueryObjects<BaseNursingDataEntry>(queryDef, paramList);
        }

        public static BindingList<BaseNursingDataEntry> GetByInPatientPhysicianApplication(TTObjectContext objectContext, Guid INPATIENTPHYSICIANAPPLICATION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGDATAENTRY"].QueryDefs["GetByInPatientPhysicianApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INPATIENTPHYSICIANAPPLICATION", INPATIENTPHYSICIANAPPLICATION);

            return ((ITTQuery)objectContext).QueryObjects<BaseNursingDataEntry>(queryDef, paramList);
        }

        public DateTime? ApplicationDate
        {
            get { return (DateTime?)this["APPLICATIONDATE"]; }
            set { this["APPLICATIONDATE"] = value; }
        }

        public DateTime? EntryDate
        {
            get { return (DateTime?)this["ENTRYDATE"]; }
            set { this["ENTRYDATE"] = value; }
        }

        public ResUser ApplicationUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("APPLICATIONUSER"); }
            set { this["APPLICATIONUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public NursingApplication NursingApplication
        {
            get { return (NursingApplication)((ITTObject)this).GetParent("NURSINGAPPLICATION"); }
            set { this["NURSINGAPPLICATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseNursingDataEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNursingDataEntry(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNursingDataEntry(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNursingDataEntry(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNursingDataEntry(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENURSINGDATAENTRY", dataRow) { }
        protected BaseNursingDataEntry(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENURSINGDATAENTRY", dataRow, isImported) { }
        public BaseNursingDataEntry(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNursingDataEntry(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNursingDataEntry() : base() { }

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