
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiabetesMellitusPursuitDisease")] 

    /// <summary>
    /// Diabet Hastalıklar
    /// </summary>
    public  partial class DiabetesMellitusPursuitDisease : TTObject
    {
        public class DiabetesMellitusPursuitDiseaseList : TTObjectCollection<DiabetesMellitusPursuitDisease> { }
                    
        public class ChildDiabetesMellitusPursuitDiseaseCollection : TTObject.TTChildObjectCollection<DiabetesMellitusPursuitDisease>
        {
            public ChildDiabetesMellitusPursuitDiseaseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiabetesMellitusPursuitDiseaseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Diğer Hastalık Tanı Kodu
    /// </summary>
        public string digerHastalikTaniKodu
        {
            get { return (string)this["DIGERHASTALIKTANIKODU"]; }
            set { this["DIGERHASTALIKTANIKODU"] = value; }
        }

    /// <summary>
    /// Hastalık Kodu
    /// </summary>
        public HastalikKoduEnum? hastalikKodu
        {
            get { return (HastalikKoduEnum?)(int?)this["HASTALIKKODU"]; }
            set { this["HASTALIKKODU"] = value; }
        }

        public DiabetesMellitusPursuit DiabetesMellitusPursuit
        {
            get { return (DiabetesMellitusPursuit)((ITTObject)this).GetParent("DIABETESMELLITUSPURSUIT"); }
            set { this["DIABETESMELLITUSPURSUIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DiabetesMellitusPursuitDisease(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiabetesMellitusPursuitDisease(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiabetesMellitusPursuitDisease(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiabetesMellitusPursuitDisease(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiabetesMellitusPursuitDisease(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIABETESMELLITUSPURSUITDISEASE", dataRow) { }
        protected DiabetesMellitusPursuitDisease(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIABETESMELLITUSPURSUITDISEASE", dataRow, isImported) { }
        public DiabetesMellitusPursuitDisease(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiabetesMellitusPursuitDisease(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiabetesMellitusPursuitDisease() : base() { }

    }
}