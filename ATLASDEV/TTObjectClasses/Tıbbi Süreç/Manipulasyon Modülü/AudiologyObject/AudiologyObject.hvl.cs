
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AudiologyObject")] 

    /// <summary>
    /// Odyoloji Türünde Manipulasyonların Ortak Objesi
    /// </summary>
    public  partial class AudiologyObject : ManipulationFormBaseObject
    {
        public class AudiologyObjectList : TTObjectCollection<AudiologyObject> { }
                    
        public class ChildAudiologyObjectCollection : TTObject.TTChildObjectCollection<AudiologyObject>
        {
            public ChildAudiologyObjectCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAudiologyObjectCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public object AudiologyReport
        {
            get { return (object)this["AUDIOLOGYREPORT"]; }
            set { this["AUDIOLOGYREPORT"] = value; }
        }

        public string ResultNote
        {
            get { return (string)this["RESULTNOTE"]; }
            set { this["RESULTNOTE"] = value; }
        }

        public string TherapyNote
        {
            get { return (string)this["THERAPYNOTE"]; }
            set { this["THERAPYNOTE"] = value; }
        }

        virtual protected void CreateAudiologyDiagnosisCollection()
        {
            _AudiologyDiagnosis = new AudiologyDiagnosis.ChildAudiologyDiagnosisCollection(this, new Guid("24ea2d89-7932-4aa0-b66e-3d53aa470652"));
            ((ITTChildObjectCollection)_AudiologyDiagnosis).GetChildren();
        }

        protected AudiologyDiagnosis.ChildAudiologyDiagnosisCollection _AudiologyDiagnosis = null;
        public AudiologyDiagnosis.ChildAudiologyDiagnosisCollection AudiologyDiagnosis
        {
            get
            {
                if (_AudiologyDiagnosis == null)
                    CreateAudiologyDiagnosisCollection();
                return _AudiologyDiagnosis;
            }
        }

        protected AudiologyObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AudiologyObject(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AudiologyObject(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AudiologyObject(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AudiologyObject(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "AUDIOLOGYOBJECT", dataRow) { }
        protected AudiologyObject(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "AUDIOLOGYOBJECT", dataRow, isImported) { }
        public AudiologyObject(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AudiologyObject(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AudiologyObject() : base() { }

    }
}