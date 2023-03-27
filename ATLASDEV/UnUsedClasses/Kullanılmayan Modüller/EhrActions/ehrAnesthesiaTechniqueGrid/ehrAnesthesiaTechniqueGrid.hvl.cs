
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrAnesthesiaTechniqueGrid")] 

    public  partial class ehrAnesthesiaTechniqueGrid : BaseEhr
    {
        public class ehrAnesthesiaTechniqueGridList : TTObjectCollection<ehrAnesthesiaTechniqueGrid> { }
                    
        public class ChildehrAnesthesiaTechniqueGridCollection : TTObject.TTChildObjectCollection<ehrAnesthesiaTechniqueGrid>
        {
            public ChildehrAnesthesiaTechniqueGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrAnesthesiaTechniqueGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("b86c3e17-bf34-414c-b60c-182925abc911"); } }
            public static Guid Inactive { get { return new Guid("749387be-ff99-45ed-b18a-fb2b6a7a1190"); } }
        }

    /// <summary>
    /// Anestezi Tekniği
    /// </summary>
        public AnesthesiaTechniqueEnum? AnesthesiaTechnique
        {
            get { return (AnesthesiaTechniqueEnum?)(int?)this["ANESTHESIATECHNIQUE"]; }
            set { this["ANESTHESIATECHNIQUE"] = value; }
        }

        public ehrAnesthesiaConsultation ehrAnesthesiaConsultation
        {
            get { return (ehrAnesthesiaConsultation)((ITTObject)this).GetParent("EHRANESTHESIACONSULTATION"); }
            set { this["EHRANESTHESIACONSULTATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrAnesthesiaTechniqueGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRANESTHESIATECHNIQUEGRID", dataRow) { }
        protected ehrAnesthesiaTechniqueGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRANESTHESIATECHNIQUEGRID", dataRow, isImported) { }
        public ehrAnesthesiaTechniqueGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrAnesthesiaTechniqueGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrAnesthesiaTechniqueGrid() : base() { }

    }
}