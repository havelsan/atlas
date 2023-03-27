
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="EpisodeActionProcedureObjectTemplate")] 

    /// <summary>
    /// Vaka İşlemleri Hizmet Tanım Şablonu
    /// </summary>
    public  partial class EpisodeActionProcedureObjectTemplate : TTDefinitionSet
    {
        public class EpisodeActionProcedureObjectTemplateList : TTObjectCollection<EpisodeActionProcedureObjectTemplate> { }
                    
        public class ChildEpisodeActionProcedureObjectTemplateCollection : TTObject.TTChildObjectCollection<EpisodeActionProcedureObjectTemplate>
        {
            public ChildEpisodeActionProcedureObjectTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildEpisodeActionProcedureObjectTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeActionTemplate EpisodeActionTemplate
        {
            get { return (EpisodeActionTemplate)((ITTObject)this).GetParent("EPISODEACTIONTEMPLATE"); }
            set { this["EPISODEACTIONTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected EpisodeActionProcedureObjectTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected EpisodeActionProcedureObjectTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected EpisodeActionProcedureObjectTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected EpisodeActionProcedureObjectTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected EpisodeActionProcedureObjectTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EPISODEACTIONPROCEDUREOBJECTTEMPLATE", dataRow) { }
        protected EpisodeActionProcedureObjectTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EPISODEACTIONPROCEDUREOBJECTTEMPLATE", dataRow, isImported) { }
        public EpisodeActionProcedureObjectTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public EpisodeActionProcedureObjectTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public EpisodeActionProcedureObjectTemplate() : base() { }

    }
}