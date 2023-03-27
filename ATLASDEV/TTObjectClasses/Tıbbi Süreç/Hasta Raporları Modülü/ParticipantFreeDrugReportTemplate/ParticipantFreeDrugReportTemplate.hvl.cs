
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ParticipantFreeDrugReportTemplate")] 

    public  partial class ParticipantFreeDrugReportTemplate : TTObject
    {
        public class ParticipantFreeDrugReportTemplateList : TTObjectCollection<ParticipantFreeDrugReportTemplate> { }
                    
        public class ChildParticipantFreeDrugReportTemplateCollection : TTObject.TTChildObjectCollection<ParticipantFreeDrugReportTemplate>
        {
            public ChildParticipantFreeDrugReportTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParticipantFreeDrugReportTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Şablon Adı
    /// </summary>
        public string TemplateName
        {
            get { return (string)this["TEMPLATENAME"]; }
            set { this["TEMPLATENAME"] = value; }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SpecialityDefinition SpecialityDefinition
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITYDEFINITION"); }
            set { this["SPECIALITYDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ParticipantFreeDrugReportTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ParticipantFreeDrugReportTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ParticipantFreeDrugReportTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ParticipantFreeDrugReportTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ParticipantFreeDrugReportTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARTICIPANTFREEDRUGREPORTTEMPLATE", dataRow) { }
        protected ParticipantFreeDrugReportTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARTICIPANTFREEDRUGREPORTTEMPLATE", dataRow, isImported) { }
        public ParticipantFreeDrugReportTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ParticipantFreeDrugReportTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ParticipantFreeDrugReportTemplate() : base() { }

    }
}