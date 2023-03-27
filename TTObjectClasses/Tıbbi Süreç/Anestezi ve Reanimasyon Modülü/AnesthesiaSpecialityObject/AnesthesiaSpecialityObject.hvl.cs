
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaSpecialityObject")] 

    public  partial class AnesthesiaSpecialityObject : SpecialityBasedObject
    {
        public class AnesthesiaSpecialityObjectList : TTObjectCollection<AnesthesiaSpecialityObject> { }
                    
        public class ChildAnesthesiaSpecialityObjectCollection : TTObject.TTChildObjectCollection<AnesthesiaSpecialityObject>
        {
            public ChildAnesthesiaSpecialityObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaSpecialityObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// ASA
    /// </summary>
        public AnesthesiaASATypeEnum? ASAType
        {
            get { return (AnesthesiaASATypeEnum?)(int?)this["ASATYPE"]; }
            set { this["ASATYPE"] = value; }
        }

        virtual protected void CreateAnesthesiaTechniquesCollection()
        {
            _AnesthesiaTechniques = new AnesthesiaConsultationAnesthesiaTechniqueGrid.ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection(this, new Guid("e0ef6e8b-1a98-42ec-abed-893e5a2b28ef"));
            ((ITTChildObjectCollection)_AnesthesiaTechniques).GetChildren();
        }

        protected AnesthesiaConsultationAnesthesiaTechniqueGrid.ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection _AnesthesiaTechniques = null;
        public AnesthesiaConsultationAnesthesiaTechniqueGrid.ChildAnesthesiaConsultationAnesthesiaTechniqueGridCollection AnesthesiaTechniques
        {
            get
            {
                if (_AnesthesiaTechniques == null)
                    CreateAnesthesiaTechniquesCollection();
                return _AnesthesiaTechniques;
            }
        }

        protected AnesthesiaSpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaSpecialityObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaSpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaSpecialityObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaSpecialityObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIASPECIALITYOBJECT", dataRow) { }
        protected AnesthesiaSpecialityObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIASPECIALITYOBJECT", dataRow, isImported) { }
        public AnesthesiaSpecialityObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaSpecialityObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaSpecialityObject() : base() { }

    }
}