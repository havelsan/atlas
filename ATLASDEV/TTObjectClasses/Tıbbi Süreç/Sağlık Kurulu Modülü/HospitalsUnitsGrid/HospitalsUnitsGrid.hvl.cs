
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HospitalsUnitsGrid")] 

    /// <summary>
    /// XXXXXXler/Birimler
    /// </summary>
    public  partial class HospitalsUnitsGrid : TTObject
    {
        public class HospitalsUnitsGridList : TTObjectCollection<HospitalsUnitsGrid> { }
                    
        public class ChildHospitalsUnitsGridCollection : TTObject.TTChildObjectCollection<HospitalsUnitsGrid>
        {
            public ChildHospitalsUnitsGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHospitalsUnitsGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Açıklama
    /// </summary>
        public string Explanation
        {
            get { return (string)this["EXPLANATION"]; }
            set { this["EXPLANATION"] = value; }
        }

    /// <summary>
    /// Onay
    /// </summary>
        public bool? Approve
        {
            get { return (bool?)this["APPROVE"]; }
            set { this["APPROVE"] = value; }
        }

    /// <summary>
    /// Red
    /// </summary>
        public bool? Reject
        {
            get { return (bool?)this["REJECT"]; }
            set { this["REJECT"] = value; }
        }

    /// <summary>
    /// Muayeneni State bilgisi
    /// </summary>
        public string ExaminationState
        {
            get { return (string)this["EXAMINATIONSTATE"]; }
            set { this["EXAMINATIONSTATE"] = value; }
        }

    /// <summary>
    /// Muayene Engel Oranı
    /// </summary>
        public string DisableRatio
        {
            get { return (string)this["DISABLERATIO"]; }
            set { this["DISABLERATIO"] = value; }
        }

    /// <summary>
    /// İşlemi Yapan Doktor
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birim(ler)
    /// </summary>
        public ResSection Unit
        {
            get { return (ResSection)((ITTObject)this).GetParent("UNIT"); }
            set { this["UNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dış XXXXXX Birimleri
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HospitalsUnitsGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOSPITALSUNITSGRID", dataRow) { }
        protected HospitalsUnitsGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOSPITALSUNITSGRID", dataRow, isImported) { }
        public HospitalsUnitsGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HospitalsUnitsGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HospitalsUnitsGrid() : base() { }

    }
}