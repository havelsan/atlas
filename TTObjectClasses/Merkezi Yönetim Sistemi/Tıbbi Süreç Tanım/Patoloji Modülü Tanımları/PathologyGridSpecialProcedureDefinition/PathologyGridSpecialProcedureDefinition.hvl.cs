
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyGridSpecialProcedureDefinition")] 

    public  partial class PathologyGridSpecialProcedureDefinition : TTDefinitionSet
    {
        public class PathologyGridSpecialProcedureDefinitionList : TTObjectCollection<PathologyGridSpecialProcedureDefinition> { }
                    
        public class ChildPathologyGridSpecialProcedureDefinitionCollection : TTObject.TTChildObjectCollection<PathologyGridSpecialProcedureDefinition>
        {
            public ChildPathologyGridSpecialProcedureDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyGridSpecialProcedureDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Patoloji Özel İşlem Tanım İlişkisi
    /// </summary>
        public PathologySpecialProcedureDefinition PathologySpecialProcedure
        {
            get { return (PathologySpecialProcedureDefinition)((ITTObject)this).GetParent("PATHOLOGYSPECIALPROCEDURE"); }
            set { this["PATHOLOGYSPECIALPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji Özel İşlem Tip Tanımı İlişkisi
    /// </summary>
        public PathologySpecialProcedureTypeDefinition TypeDefinition
        {
            get { return (PathologySpecialProcedureTypeDefinition)((ITTObject)this).GetParent("TYPEDEFINITION"); }
            set { this["TYPEDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PathologyGridSpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyGridSpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyGridSpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyGridSpecialProcedureDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyGridSpecialProcedureDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYGRIDSPECIALPROCEDUREDEFINITION", dataRow) { }
        protected PathologyGridSpecialProcedureDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYGRIDSPECIALPROCEDUREDEFINITION", dataRow, isImported) { }
        public PathologyGridSpecialProcedureDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyGridSpecialProcedureDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyGridSpecialProcedureDefinition() : base() { }

    }
}