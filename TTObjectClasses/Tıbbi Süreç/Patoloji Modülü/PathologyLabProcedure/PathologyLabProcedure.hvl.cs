
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PathologyLabProcedure")] 

    public  partial class PathologyLabProcedure : TTObject
    {
        public class PathologyLabProcedureList : TTObjectCollection<PathologyLabProcedure> { }
                    
        public class ChildPathologyLabProcedureCollection : TTObject.TTChildObjectCollection<PathologyLabProcedure>
        {
            public ChildPathologyLabProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPathologyLabProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Lab İşlem Miktarı
    /// </summary>
        public int? LabProcedureAmount
        {
            get { return (int?)this["LABPROCEDUREAMOUNT"]; }
            set { this["LABPROCEDUREAMOUNT"] = value; }
        }

    /// <summary>
    /// Patoloji Lab Hizmet Tanım İlişkisi
    /// </summary>
        public PathologyLabProcedureDef PathologyLabProcDefinition
        {
            get { return (PathologyLabProcedureDef)((ITTObject)this).GetParent("PATHOLOGYLABPROCDEFINITION"); }
            set { this["PATHOLOGYLABPROCDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Patoloji Ana İlişki
    /// </summary>
        public PathologyRequest Pathology
        {
            get { return (PathologyRequest)((ITTObject)this).GetParent("PATHOLOGY"); }
            set { this["PATHOLOGY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PathologyLabProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PathologyLabProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PathologyLabProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PathologyLabProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PathologyLabProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATHOLOGYLABPROCEDURE", dataRow) { }
        protected PathologyLabProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATHOLOGYLABPROCEDURE", dataRow, isImported) { }
        public PathologyLabProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PathologyLabProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PathologyLabProcedure() : base() { }

    }
}