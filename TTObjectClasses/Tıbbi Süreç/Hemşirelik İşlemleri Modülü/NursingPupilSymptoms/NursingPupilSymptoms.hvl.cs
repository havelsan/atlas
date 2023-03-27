
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingPupilSymptoms")] 

    /// <summary>
    /// Pupil Bulgular
    /// </summary>
    public  partial class NursingPupilSymptoms : BaseNursingDataEntry
    {
        public class NursingPupilSymptomsList : TTObjectCollection<NursingPupilSymptoms> { }
                    
        public class ChildNursingPupilSymptomsCollection : TTObject.TTChildObjectCollection<NursingPupilSymptoms>
        {
            public ChildNursingPupilSymptomsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingPupilSymptomsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

    /// <summary>
    /// Sol Pupil
    /// </summary>
        public PupilPropertiesEnum? LeftPupil
        {
            get { return (PupilPropertiesEnum?)(int?)this["LEFTPUPIL"]; }
            set { this["LEFTPUPIL"] = value; }
        }

    /// <summary>
    /// Sağ Pupil Genişliği
    /// </summary>
        public PupilWidenessEnum? RightPupilWideness
        {
            get { return (PupilWidenessEnum?)(int?)this["RIGHTPUPILWIDENESS"]; }
            set { this["RIGHTPUPILWIDENESS"] = value; }
        }

    /// <summary>
    /// Sağ Pupil
    /// </summary>
        public PupilPropertiesEnum? RightPupil
        {
            get { return (PupilPropertiesEnum?)(int?)this["RIGHTPUPIL"]; }
            set { this["RIGHTPUPIL"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? ActionDate
        {
            get { return (DateTime?)this["ACTIONDATE"]; }
            set { this["ACTIONDATE"] = value; }
        }

    /// <summary>
    /// Işık Ref Sol
    /// </summary>
        public PositiveNegativeEnum? LeftGleamRef
        {
            get { return (PositiveNegativeEnum?)(int?)this["LEFTGLEAMREF"]; }
            set { this["LEFTGLEAMREF"] = value; }
        }

    /// <summary>
    /// Işık Ref Sağ
    /// </summary>
        public PositiveNegativeEnum? RightGleamRef
        {
            get { return (PositiveNegativeEnum?)(int?)this["RIGHTGLEAMREF"]; }
            set { this["RIGHTGLEAMREF"] = value; }
        }

    /// <summary>
    /// Sol Pupil Genişliği
    /// </summary>
        public PupilWidenessEnum? LeftPupilWideness
        {
            get { return (PupilWidenessEnum?)(int?)this["LEFTPUPILWIDENESS"]; }
            set { this["LEFTPUPILWIDENESS"] = value; }
        }

        protected NursingPupilSymptoms(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingPupilSymptoms(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingPupilSymptoms(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingPupilSymptoms(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingPupilSymptoms(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGPUPILSYMPTOMS", dataRow) { }
        protected NursingPupilSymptoms(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGPUPILSYMPTOMS", dataRow, isImported) { }
        public NursingPupilSymptoms(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingPupilSymptoms(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingPupilSymptoms() : base() { }

    }
}