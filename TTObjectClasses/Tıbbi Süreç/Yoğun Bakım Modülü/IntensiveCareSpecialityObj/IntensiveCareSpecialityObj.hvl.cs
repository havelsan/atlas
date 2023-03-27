
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="IntensiveCareSpecialityObj")] 

    public  partial class IntensiveCareSpecialityObj : SpecialityBasedObject
    {
        public class IntensiveCareSpecialityObjList : TTObjectCollection<IntensiveCareSpecialityObj> { }
                    
        public class ChildIntensiveCareSpecialityObjCollection : TTObject.TTChildObjectCollection<IntensiveCareSpecialityObj>
        {
            public ChildIntensiveCareSpecialityObjCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIntensiveCareSpecialityObjCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Basamak Bilgisi
    /// </summary>
        public IntensiveCareStepEnum? IntensiveCareStep
        {
            get { return (IntensiveCareStepEnum?)(int?)this["INTENSIVECARESTEP"]; }
            set { this["INTENSIVECARESTEP"] = value; }
        }

    /// <summary>
    /// Yoğun Bakım Tipi(Yetişkin/Çocuk/Yenidoğan)
    /// </summary>
        public IntensiveCareTypeEnum? IntensiveCareType
        {
            get { return (IntensiveCareTypeEnum?)(int?)this["INTENSIVECARETYPE"]; }
            set { this["INTENSIVECARETYPE"] = value; }
        }

    /// <summary>
    /// Sepsis Durumu
    /// </summary>
        public SKRSDurum SepsisStatus
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("SEPSISSTATUS"); }
            set { this["SEPSISSTATUS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Septik Şok
    /// </summary>
        public SKRSDurum SepticShock
        {
            get { return (SKRSDurum)((ITTObject)this).GetParent("SEPTICSHOCK"); }
            set { this["SEPTICSHOCK"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateNewBornCollection()
        {
            _NewBorn = new NewBornIntensiveCare.ChildNewBornIntensiveCareCollection(this, new Guid("434d8b70-9400-4651-9872-865613ae2aec"));
            ((ITTChildObjectCollection)_NewBorn).GetChildren();
        }

        protected NewBornIntensiveCare.ChildNewBornIntensiveCareCollection _NewBorn = null;
        public NewBornIntensiveCare.ChildNewBornIntensiveCareCollection NewBorn
        {
            get
            {
                if (_NewBorn == null)
                    CreateNewBornCollection();
                return _NewBorn;
            }
        }

        protected IntensiveCareSpecialityObj(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected IntensiveCareSpecialityObj(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected IntensiveCareSpecialityObj(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected IntensiveCareSpecialityObj(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected IntensiveCareSpecialityObj(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "INTENSIVECARESPECIALITYOBJ", dataRow) { }
        protected IntensiveCareSpecialityObj(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "INTENSIVECARESPECIALITYOBJ", dataRow, isImported) { }
        public IntensiveCareSpecialityObj(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public IntensiveCareSpecialityObj(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public IntensiveCareSpecialityObj() : base() { }

    }
}