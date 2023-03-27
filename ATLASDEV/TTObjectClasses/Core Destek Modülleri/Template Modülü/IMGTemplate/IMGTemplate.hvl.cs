
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IMGTemplate")] 

    public  partial class IMGTemplate : BaseTemplate
    {
        public class IMGTemplateList : TTObjectCollection<IMGTemplate> { }
                    
        public class ChildIMGTemplateCollection : TTObject.TTChildObjectCollection<IMGTemplate>
        {
            public ChildIMGTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIMGTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<IMGTemplate> GetIMGTemplateForEmergInjuryLocation(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IMGTEMPLATE"].QueryDefs["GetIMGTemplateForEmergInjuryLocation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<IMGTemplate>(queryDef, paramList);
        }

        protected IMGTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IMGTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IMGTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IMGTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IMGTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IMGTEMPLATE", dataRow) { }
        protected IMGTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IMGTEMPLATE", dataRow, isImported) { }
        public IMGTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IMGTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IMGTemplate() : base() { }

    }
}