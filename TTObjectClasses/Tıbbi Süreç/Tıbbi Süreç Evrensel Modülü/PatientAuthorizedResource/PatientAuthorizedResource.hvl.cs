
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientAuthorizedResource")] 

    public  partial class PatientAuthorizedResource : TTObject
    {
        public class PatientAuthorizedResourceList : TTObjectCollection<PatientAuthorizedResource> { }
                    
        public class ChildPatientAuthorizedResourceCollection : TTObject.TTChildObjectCollection<PatientAuthorizedResource>
        {
            public ChildPatientAuthorizedResourceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientAuthorizedResourceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PatientAuthorizedResource> GetPatientAuthorizedResourcesByEpisodes(TTObjectContext objectContext, IList<Guid> EPISODEOBJECTIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTAUTHORIZEDRESOURCE"].QueryDefs["GetPatientAuthorizedResourcesByEpisodes"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODEOBJECTIDS", EPISODEOBJECTIDS);

            return ((ITTQuery)objectContext).QueryObjects<PatientAuthorizedResource>(queryDef, paramList);
        }

        public Resource Resource
        {
            get { return (Resource)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Episode Episode
        {
            get { return (Episode)((ITTObject)this).GetParent("EPISODE"); }
            set { this["EPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientAuthorizedResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientAuthorizedResource(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientAuthorizedResource(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientAuthorizedResource(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientAuthorizedResource(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTAUTHORIZEDRESOURCE", dataRow) { }
        protected PatientAuthorizedResource(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTAUTHORIZEDRESOURCE", dataRow, isImported) { }
        public PatientAuthorizedResource(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientAuthorizedResource(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientAuthorizedResource() : base() { }

    }
}