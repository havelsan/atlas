
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSOldOccupationUnit")] 

    /// <summary>
    /// Önceki Görev Yeri
    /// </summary>
    public  partial class MPBSOldOccupationUnit : TTObject
    {
        public class MPBSOldOccupationUnitList : TTObjectCollection<MPBSOldOccupationUnit> { }
                    
        public class ChildMPBSOldOccupationUnitCollection : TTObject.TTChildObjectCollection<MPBSOldOccupationUnit>
        {
            public ChildMPBSOldOccupationUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSOldOccupationUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Konuta Başvuru Tarihi
    /// </summary>
        public DateTime? ApplyToFlatDate
        {
            get { return (DateTime?)this["APPLYTOFLATDATE"]; }
            set { this["APPLYTOFLATDATE"] = value; }
        }

    /// <summary>
    /// Konuta Giriş Tarihi
    /// </summary>
        public DateTime? EntranceDate
        {
            get { return (DateTime?)this["ENTRANCEDATE"]; }
            set { this["ENTRANCEDATE"] = value; }
        }

    /// <summary>
    /// Katılış Tarihi
    /// </summary>
        public DateTime? RegistrationDate
        {
            get { return (DateTime?)this["REGISTRATIONDATE"]; }
            set { this["REGISTRATIONDATE"] = value; }
        }

    /// <summary>
    /// Konutta Oturma Süresi
    /// </summary>
        public int? StayAtFlatDuration
        {
            get { return (int?)this["STAYATFLATDURATION"]; }
            set { this["STAYATFLATDURATION"] = value; }
        }

    /// <summary>
    /// Konuttan Çıkış Tarihi
    /// </summary>
        public DateTime? LeaveDate
        {
            get { return (DateTime?)this["LEAVEDATE"]; }
            set { this["LEAVEDATE"] = value; }
        }

    /// <summary>
    /// Ayrılış Tarihi
    /// </summary>
        public DateTime? DepartureDate
        {
            get { return (DateTime?)this["DEPARTUREDATE"]; }
            set { this["DEPARTUREDATE"] = value; }
        }

    /// <summary>
    /// Taşıyacağı Puan
    /// </summary>
        public int? Point
        {
            get { return (int?)this["POINT"]; }
            set { this["POINT"] = value; }
        }

        protected MPBSOldOccupationUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSOldOccupationUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSOldOccupationUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSOldOccupationUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSOldOccupationUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSOLDOCCUPATIONUNIT", dataRow) { }
        protected MPBSOldOccupationUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSOLDOCCUPATIONUNIT", dataRow, isImported) { }
        public MPBSOldOccupationUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSOldOccupationUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSOldOccupationUnit() : base() { }

    }
}