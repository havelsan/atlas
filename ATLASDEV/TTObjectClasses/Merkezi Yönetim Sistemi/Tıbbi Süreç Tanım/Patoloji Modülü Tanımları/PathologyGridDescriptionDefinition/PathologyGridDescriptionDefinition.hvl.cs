
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyGridDescriptionDefinition")] 

    public  partial class PathologyGridDescriptionDefinition : TTDefinitionSet
    {
        public class PathologyGridDescriptionDefinitionList : TTObjectCollection<PathologyGridDescriptionDefinition> { }
                    
        public class ChildPathologyGridDescriptionDefinitionCollection : TTObject.TTChildObjectCollection<PathologyGridDescriptionDefinition>
        {
            public ChildPathologyGridDescriptionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyGridDescriptionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// SıraNo
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Patoloji Test Açıklama Tanımı İlişkisi
    /// </summary>
        public PathologyTestDescriptionDefinition TestDescription
        {
            get { return (PathologyTestDescriptionDefinition)((ITTObject)this).GetParent("TESTDESCRIPTION"); }
            set { this["TESTDESCRIPTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji Test Tanım İlişkisi
    /// </summary>
        public PathologyTestDefinition PathologyTest
        {
            get { return (PathologyTestDefinition)((ITTObject)this).GetParent("PATHOLOGYTEST"); }
            set { this["PATHOLOGYTEST"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PathologyGridDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyGridDescriptionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyGridDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyGridDescriptionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyGridDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYGRIDDESCRIPTIONDEFINITION", dataRow) { }
        protected PathologyGridDescriptionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYGRIDDESCRIPTIONDEFINITION", dataRow, isImported) { }
        public PathologyGridDescriptionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyGridDescriptionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyGridDescriptionDefinition() : base() { }

    }
}