
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalConsultationProcedure")] 

    public  partial class DentalConsultationProcedure : SubActionProcedure
    {
        public class DentalConsultationProcedureList : TTObjectCollection<DentalConsultationProcedure> { }
                    
        public class ChildDentalConsultationProcedureCollection : TTObject.TTChildObjectCollection<DentalConsultationProcedure>
        {
            public ChildDentalConsultationProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalConsultationProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<DentalConsultationProcedure> GetCompletedBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALCONSULTATIONPROCEDURE"].QueryDefs["GetCompletedBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return ((ITTQuery)objectContext).QueryObjects<DentalConsultationProcedure>(queryDef, paramList);
        }

        public DentalExamination DentalExamination
        {
            get 
            {   
                if (EpisodeAction is DentalExamination)
                    return (DentalExamination)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected DentalConsultationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalConsultationProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalConsultationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalConsultationProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalConsultationProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALCONSULTATIONPROCEDURE", dataRow) { }
        protected DentalConsultationProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALCONSULTATIONPROCEDURE", dataRow, isImported) { }
        public DentalConsultationProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalConsultationProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalConsultationProcedure() : base() { }

    }
}