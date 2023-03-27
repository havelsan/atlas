
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MhSAccountGroupDefinition")] 

    /// <summary>
    /// Hesap Grubu
    /// </summary>
    public  partial class MhSAccountGroupDefinition : TTDefinitionSet
    {
        public class MhSAccountGroupDefinitionList : TTObjectCollection<MhSAccountGroupDefinition> { }
                    
        public class ChildMhSAccountGroupDefinitionCollection : TTObject.TTChildObjectCollection<MhSAccountGroupDefinition>
        {
            public ChildMhSAccountGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMhSAccountGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Seviye
    /// </summary>
        public MhSAccountGroupLevelsEnum? Level
        {
            get { return (MhSAccountGroupLevelsEnum?)(int?)this["LEVEL"]; }
            set { this["LEVEL"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        protected MhSAccountGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MhSAccountGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MhSAccountGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MhSAccountGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MhSAccountGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHSACCOUNTGROUPDEFINITION", dataRow) { }
        protected MhSAccountGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHSACCOUNTGROUPDEFINITION", dataRow, isImported) { }
        public MhSAccountGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MhSAccountGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MhSAccountGroupDefinition() : base() { }

    }
}