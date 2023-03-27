
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SohaRuleRepoUpdate")] 

    /// <summary>
    /// Repository Update Desicion Table
    /// </summary>
    public  partial class SohaRuleRepoUpdate : TTObject
    {
        public class SohaRuleRepoUpdateList : TTObjectCollection<SohaRuleRepoUpdate> { }
                    
        public class ChildSohaRuleRepoUpdateCollection : TTObject.TTChildObjectCollection<SohaRuleRepoUpdate>
        {
            public ChildSohaRuleRepoUpdateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSohaRuleRepoUpdateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DateTime? UpdateDate
        {
            get { return (DateTime?)this["UPDATEDATE"]; }
            set { this["UPDATEDATE"] = value; }
        }

        public SohaRuleRepoTypeEnum? RepositoryType
        {
            get { return (SohaRuleRepoTypeEnum?)(int?)this["REPOSITORYTYPE"]; }
            set { this["REPOSITORYTYPE"] = value; }
        }

        protected SohaRuleRepoUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SohaRuleRepoUpdate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SohaRuleRepoUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SohaRuleRepoUpdate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SohaRuleRepoUpdate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SOHARULEREPOUPDATE", dataRow) { }
        protected SohaRuleRepoUpdate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SOHARULEREPOUPDATE", dataRow, isImported) { }
        public SohaRuleRepoUpdate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SohaRuleRepoUpdate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SohaRuleRepoUpdate() : base() { }

    }
}