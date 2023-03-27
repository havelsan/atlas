
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GeneralTestTypeGrid")] 

    /// <summary>
    /// Genel Tetkik Tipleri
    /// </summary>
    public  partial class GeneralTestTypeGrid : TTObject
    {
        public class GeneralTestTypeGridList : TTObjectCollection<GeneralTestTypeGrid> { }
                    
        public class ChildGeneralTestTypeGridCollection : TTObject.TTChildObjectCollection<GeneralTestTypeGrid>
        {
            public ChildGeneralTestTypeGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGeneralTestTypeGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// ProcedureGeneralTestType
    /// </summary>
        public ProcedureDefinition ProcedureObject
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREOBJECT"); }
            set { this["PROCEDUREOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GeneralTestTypeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GeneralTestTypeGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GeneralTestTypeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GeneralTestTypeGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GeneralTestTypeGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GENERALTESTTYPEGRID", dataRow) { }
        protected GeneralTestTypeGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GENERALTESTTYPEGRID", dataRow, isImported) { }
        protected GeneralTestTypeGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GeneralTestTypeGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GeneralTestTypeGrid() : base() { }

    }
}