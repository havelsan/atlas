
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExplanationOfRejectionGrid")] 

    /// <summary>
    /// Şerh
    /// </summary>
    public  partial class ExplanationOfRejectionGrid : TTObject
    {
        public class ExplanationOfRejectionGridList : TTObjectCollection<ExplanationOfRejectionGrid> { }
                    
        public class ChildExplanationOfRejectionGridCollection : TTObject.TTChildObjectCollection<ExplanationOfRejectionGrid>
        {
            public ChildExplanationOfRejectionGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExplanationOfRejectionGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Şerh
    /// </summary>
        public object ExplanationOfRejection
        {
            get { return (object)this["EXPLANATIONOFREJECTION"]; }
            set { this["EXPLANATIONOFREJECTION"] = value; }
        }

    /// <summary>
    /// Şerh Yazan Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExplanationOfRejectionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExplanationOfRejectionGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXPLANATIONOFREJECTIONGRID", dataRow) { }
        protected ExplanationOfRejectionGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXPLANATIONOFREJECTIONGRID", dataRow, isImported) { }
        public ExplanationOfRejectionGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExplanationOfRejectionGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExplanationOfRejectionGrid() : base() { }

    }
}