
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaConsultationAnesthesiaTechniqueGrid")] 

    /// <summary>
    /// Ansetezi Konsültasyonunda Anestezi Tekniklerini İçeren Grid
    /// </summary>
    public  partial class AnesthesiaConsultationAnesthesiaTechniqueGrid : AnesthesiaTechniqueGrid
    {
        public class AnesthesiaConsultationAnesthesiaTechniqueGridList : TTObjectCollection<AnesthesiaConsultationAnesthesiaTechniqueGrid> { }
                    
        public class ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection : TTObject.TTChildObjectCollection<AnesthesiaConsultationAnesthesiaTechniqueGrid>
        {
            public ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public AnesthesiaConsultation AnesthesiaConsultation
        {
            get { return (AnesthesiaConsultation)((ITTObject)this).GetParent("ANESTHESIACONSULTATION"); }
            set { this["ANESTHESIACONSULTATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AnesthesiaSpecialityObject AnesthesiaSpecialityObject
        {
            get { return (AnesthesiaSpecialityObject)((ITTObject)this).GetParent("ANESTHESIASPECIALITYOBJECT"); }
            set { this["ANESTHESIASPECIALITYOBJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnesthesiaConsultationAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaConsultationAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaConsultationAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaConsultationAnesthesiaTechniqueGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaConsultationAnesthesiaTechniqueGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIACONSULTATIONANESTHESIATECHNIQUEGRID", dataRow) { }
        protected AnesthesiaConsultationAnesthesiaTechniqueGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIACONSULTATIONANESTHESIATECHNIQUEGRID", dataRow, isImported) { }
        public AnesthesiaConsultationAnesthesiaTechniqueGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaConsultationAnesthesiaTechniqueGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaConsultationAnesthesiaTechniqueGrid() : base() { }

    }
}