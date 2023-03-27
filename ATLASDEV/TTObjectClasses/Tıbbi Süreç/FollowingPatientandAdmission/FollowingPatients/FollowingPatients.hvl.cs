
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FollowingPatients")] 

    public  partial class FollowingPatients : TTObject
    {
        public class FollowingPatientsList : TTObjectCollection<FollowingPatients> { }
                    
        public class ChildFollowingPatientsCollection : TTObject.TTChildObjectCollection<FollowingPatients>
        {
            public ChildFollowingPatientsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFollowingPatientsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid OnTracking { get { return new Guid("b9cc4ac5-aa61-46f1-962c-afbece4f3e29"); } }
            public static Guid StopTracking { get { return new Guid("dfe47692-9966-4918-8e92-464722c97cd8"); } }
        }

        public static BindingList<FollowingPatients> GetTrackingPatientsByFilter(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FOLLOWINGPATIENTS"].QueryDefs["GetTrackingPatientsByFilter"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FollowingPatients>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Kabul Bazlı,Arşiv Bazlı vs.
    /// </summary>
        public PatientFollowingTypeEnum? FollowingType
        {
            get { return (PatientFollowingTypeEnum?)(int?)this["FOLLOWINGTYPE"]; }
            set { this["FOLLOWINGTYPE"] = value; }
        }

        public Guid? Paitent
        {
            get { return (Guid?)this["PAITENT"]; }
            set { this["PAITENT"] = value; }
        }

        public Guid? Subepisode
        {
            get { return (Guid?)this["SUBEPISODE"]; }
            set { this["SUBEPISODE"] = value; }
        }

        public Guid? Follower
        {
            get { return (Guid?)this["FOLLOWER"]; }
            set { this["FOLLOWER"] = value; }
        }

        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        protected FollowingPatients(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FollowingPatients(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FollowingPatients(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FollowingPatients(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FollowingPatients(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FOLLOWINGPATIENTS", dataRow) { }
        protected FollowingPatients(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FOLLOWINGPATIENTS", dataRow, isImported) { }
        public FollowingPatients(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FollowingPatients(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FollowingPatients() : base() { }

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