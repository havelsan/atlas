
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GuideBookDefinition")] 

    /// <summary>
    /// Telefon Numaraları Tanımları
    /// </summary>
    public  partial class GuideBookDefinition : TTDefinitionSet
    {
        public class GuideBookDefinitionList : TTObjectCollection<GuideBookDefinition> { }
                    
        public class ChildGuideBookDefinitionCollection : TTObject.TTChildObjectCollection<GuideBookDefinition>
        {
            public ChildGuideBookDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGuideBookDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Telefon Numarası
    /// </summary>
        public string PhoneNumber
        {
            get { return (string)this["PHONENUMBER"]; }
            set { this["PHONENUMBER"] = value; }
        }

        protected GuideBookDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GuideBookDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GuideBookDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GuideBookDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GuideBookDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GUIDEBOOKDEFINITION", dataRow) { }
        protected GuideBookDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GUIDEBOOKDEFINITION", dataRow, isImported) { }
        protected GuideBookDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GuideBookDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GuideBookDefinition() : base() { }

    }
}