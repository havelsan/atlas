
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SpecialTemplateDefinition")] 

    /// <summary>
    /// Özel Şablon Tanımları
    /// </summary>
    public  partial class SpecialTemplateDefinition : TTDefinitionSet
    {
        public class SpecialTemplateDefinitionList : TTObjectCollection<SpecialTemplateDefinition> { }
                    
        public class ChildSpecialTemplateDefinitionCollection : TTObject.TTChildObjectCollection<SpecialTemplateDefinition>
        {
            public ChildSpecialTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSpecialTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Şablon
    /// </summary>
        public string Template
        {
            get { return (string)this["TEMPLATE"]; }
            set { this["TEMPLATE"] = value; }
        }

    /// <summary>
    /// Kullanıcı ID
    /// </summary>
        public long? UserID
        {
            get { return (long?)this["USERID"]; }
            set { this["USERID"] = value; }
        }

    /// <summary>
    /// No
    /// </summary>
        public long? ID
        {
            get { return (long?)this["ID"]; }
            set { this["ID"] = value; }
        }

        protected SpecialTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SpecialTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SpecialTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SpecialTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SpecialTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SPECIALTEMPLATEDEFINITION", dataRow) { }
        protected SpecialTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SPECIALTEMPLATEDEFINITION", dataRow, isImported) { }
        public SpecialTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SpecialTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SpecialTemplateDefinition() : base() { }

    }
}