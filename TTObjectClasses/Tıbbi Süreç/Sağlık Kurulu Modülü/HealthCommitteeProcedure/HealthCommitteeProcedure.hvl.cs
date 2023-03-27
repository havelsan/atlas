
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HealthCommitteeProcedure")] 

    /// <summary>
    /// Sağlık Kurulu Prosedürü
    /// </summary>
    public  partial class HealthCommitteeProcedure : SubActionProcedure
    {
        public class HealthCommitteeProcedureList : TTObjectCollection<HealthCommitteeProcedure> { }
                    
        public class ChildHealthCommitteeProcedureCollection : TTObject.TTChildObjectCollection<HealthCommitteeProcedure>
        {
            public ChildHealthCommitteeProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHealthCommitteeProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HealthCommittee HealthCommittee
        {
            get 
            {   
                if (EpisodeAction is HealthCommittee)
                    return (HealthCommittee)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        public HealthCommitteeWithThreeSpecialist HealthCommitteeWithThreeSpecialist
        {
            get 
            {   
                if (EpisodeAction is HealthCommitteeWithThreeSpecialist)
                    return (HealthCommitteeWithThreeSpecialist)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        public ParticipatnFreeDrugReport ParticipationFreeDrugReport
        {
            get 
            {   
                if (EpisodeAction is ParticipatnFreeDrugReport)
                    return (ParticipatnFreeDrugReport)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        public StatusNotificationReport StatusNotificationReport
        {
            get 
            {   
                if (EpisodeAction is StatusNotificationReport)
                    return (StatusNotificationReport)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected HealthCommitteeProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HealthCommitteeProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HealthCommitteeProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HealthCommitteeProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HealthCommitteeProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEALTHCOMMITTEEPROCEDURE", dataRow) { }
        protected HealthCommitteeProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEALTHCOMMITTEEPROCEDURE", dataRow, isImported) { }
        public HealthCommitteeProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HealthCommitteeProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HealthCommitteeProcedure() : base() { }

    }
}