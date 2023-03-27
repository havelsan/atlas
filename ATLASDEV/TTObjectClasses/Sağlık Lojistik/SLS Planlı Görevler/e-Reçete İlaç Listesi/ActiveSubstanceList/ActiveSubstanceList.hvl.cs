
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActiveSubstanceList")] 

    /// <summary>
    /// Etkin Madde Listesi
    /// </summary>
    public  partial class ActiveSubstanceList : BaseScheduledTask
    {
        public class ActiveSubstanceListList : TTObjectCollection<ActiveSubstanceList> { }
                    
        public class ChildActiveSubstanceListCollection : TTObject.TTChildObjectCollection<ActiveSubstanceList>
        {
            public ChildActiveSubstanceListCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActiveSubstanceListCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dosya Yolu
    /// </summary>
        public string FilePath
        {
            get { return (string)this["FILEPATH"]; }
            set { this["FILEPATH"] = value; }
        }

        protected ActiveSubstanceList(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActiveSubstanceList(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActiveSubstanceList(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActiveSubstanceList(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActiveSubstanceList(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIVESUBSTANCELIST", dataRow) { }
        protected ActiveSubstanceList(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIVESUBSTANCELIST", dataRow, isImported) { }
        public ActiveSubstanceList(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActiveSubstanceList(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActiveSubstanceList() : base() { }

    }
}