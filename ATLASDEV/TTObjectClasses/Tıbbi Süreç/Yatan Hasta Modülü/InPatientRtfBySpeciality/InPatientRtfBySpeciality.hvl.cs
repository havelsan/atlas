
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="InPatientRtfBySpeciality")] 

    public  partial class InPatientRtfBySpeciality : TTObject
    {
        public class InPatientRtfBySpecialityList : TTObjectCollection<InPatientRtfBySpeciality> { }
                    
        public class ChildInPatientRtfBySpecialityCollection : TTObject.TTChildObjectCollection<InPatientRtfBySpeciality>
        {
            public ChildInPatientRtfBySpecialityCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildInPatientRtfBySpecialityCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public object Rtf
        {
            get { return (object)this["RTF"]; }
            set { this["RTF"] = value; }
        }

        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

        public RTFDefinitionsBySpeciality RTFDefinitionsBySpeciality
        {
            get { return (RTFDefinitionsBySpeciality)((ITTObject)this).GetParent("RTFDEFINITIONSBYSPECIALITY"); }
            set { this["RTFDEFINITIONSBYSPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SubEpisode SubEpisode
        {
            get { return (SubEpisode)((ITTObject)this).GetParent("SUBEPISODE"); }
            set { this["SUBEPISODE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeAction EpisodeAction
        {
            get { return (EpisodeAction)((ITTObject)this).GetParent("EPISODEACTION"); }
            set { this["EPISODEACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected InPatientRtfBySpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected InPatientRtfBySpeciality(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected InPatientRtfBySpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected InPatientRtfBySpeciality(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected InPatientRtfBySpeciality(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INPATIENTRTFBYSPECIALITY", dataRow) { }
        protected InPatientRtfBySpeciality(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INPATIENTRTFBYSPECIALITY", dataRow, isImported) { }
        public InPatientRtfBySpeciality(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public InPatientRtfBySpeciality(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public InPatientRtfBySpeciality() : base() { }

    }
}