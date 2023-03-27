
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Allocation")] 

    public  partial class Allocation : TTObject
    {
        public class AllocationList : TTObjectCollection<Allocation> { }
                    
        public class ChildAllocationCollection : TTObject.TTChildObjectCollection<Allocation>
        {
            public ChildAllocationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAllocationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
            public static Guid Deallocated { get { return new Guid("46a5c35e-a0e1-4ab7-9072-8d35be421063"); } }
            public static Guid Allocated { get { return new Guid("f95bdda4-c853-484f-8476-f85922b66946"); } }
        }

        public static BindingList<Allocation> GetByAllocatePropertiesExceptSubActionProcedure(TTObjectContext objectContext, string STATE, string EPISODE, string EPISODEACTION, string SPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ALLOCATION"].QueryDefs["GetByAllocatePropertiesExceptSubActionProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("EPISODEACTION", EPISODEACTION);
            paramList.Add("SPECIALITY", SPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<Allocation>(queryDef, paramList);
        }

        public static BindingList<Allocation> GetByStateEpisodeActionAndNullSpeciality(TTObjectContext objectContext, string STATE, string EPISODE, string EPISODEACTION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ALLOCATION"].QueryDefs["GetByStateEpisodeActionAndNullSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("EPISODEACTION", EPISODEACTION);

            return ((ITTQuery)objectContext).QueryObjects<Allocation>(queryDef, paramList);
        }

        public static BindingList<Allocation> GetByAllocatePropertiesWithNullSpeciality(TTObjectContext objectContext, string STATE, string EPISODE, string EPISODEACTION, string SUBACTIONPROCEDURE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ALLOCATION"].QueryDefs["GetByAllocatePropertiesWithNullSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("EPISODEACTION", EPISODEACTION);
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return ((ITTQuery)objectContext).QueryObjects<Allocation>(queryDef, paramList);
        }

        public static BindingList<Allocation> GetByStateEpisodeAndSpeciality(TTObjectContext objectContext, string STATE, string EPISODE, string SPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ALLOCATION"].QueryDefs["GetByStateEpisodeAndSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("SPECIALITY", SPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<Allocation>(queryDef, paramList);
        }

        public static BindingList<Allocation> GetByAllocateProperties(TTObjectContext objectContext, string STATE, string EPISODE, string EPISODEACTION, string SPECIALITY, string SUBACTIONPROCEDURE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ALLOCATION"].QueryDefs["GetByAllocateProperties"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATE", STATE);
            paramList.Add("EPISODE", EPISODE);
            paramList.Add("EPISODEACTION", EPISODEACTION);
            paramList.Add("SPECIALITY", SPECIALITY);
            paramList.Add("SUBACTIONPROCEDURE", SUBACTIONPROCEDURE);

            return ((ITTQuery)objectContext).QueryObjects<Allocation>(queryDef, paramList);
        }

        public DateTime? AllocateDate
        {
            get { return (DateTime?)this["ALLOCATEDATE"]; }
            set { this["ALLOCATEDATE"] = value; }
        }

        public DateTime? DeallocateDate
        {
            get { return (DateTime?)this["DEALLOCATEDATE"]; }
            set { this["DEALLOCATEDATE"] = value; }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubActionProcedure SubActionProcedure
        {
            get { return (SubActionProcedure)((ITTObject)this).GetParent("SUBACTIONPROCEDURE"); }
            set { this["SUBACTIONPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Allocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Allocation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Allocation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Allocation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Allocation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ALLOCATION", dataRow) { }
        protected Allocation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ALLOCATION", dataRow, isImported) { }
        public Allocation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Allocation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Allocation() : base() { }

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