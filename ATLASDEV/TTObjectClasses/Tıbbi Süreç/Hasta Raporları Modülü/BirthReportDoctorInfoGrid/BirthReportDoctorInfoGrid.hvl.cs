
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BirthReportDoctorInfoGrid")] 

    /// <summary>
    /// Doğum Raporu Doktor Bilgisi
    /// </summary>
    public  partial class BirthReportDoctorInfoGrid : TTObject
    {
        public class BirthReportDoctorInfoGridList : TTObjectCollection<BirthReportDoctorInfoGrid> { }
                    
        public class ChildBirthReportDoctorInfoGridCollection : TTObject.TTChildObjectCollection<BirthReportDoctorInfoGrid>
        {
            public ChildBirthReportDoctorInfoGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBirthReportDoctorInfoGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tescil No
    /// </summary>
        public string RegistrationNo
        {
            get { return (string)this["REGISTRATIONNO"]; }
            set { this["REGISTRATIONNO"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public BirthReportDoctorTypeEnum? Type
        {
            get { return (BirthReportDoctorTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Doğum Raporu Doktor Bilgisi
    /// </summary>
        public BirthReport BirthReport
        {
            get { return (BirthReport)((ITTObject)this).GetParent("BIRTHREPORT"); }
            set { this["BIRTHREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Branş Kodu
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doktor Adı
    /// </summary>
        public ResUser Doctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("DOCTOR"); }
            set { this["DOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BirthReportDoctorInfoGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BirthReportDoctorInfoGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BirthReportDoctorInfoGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BirthReportDoctorInfoGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BirthReportDoctorInfoGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BIRTHREPORTDOCTORINFOGRID", dataRow) { }
        protected BirthReportDoctorInfoGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BIRTHREPORTDOCTORINFOGRID", dataRow, isImported) { }
        public BirthReportDoctorInfoGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BirthReportDoctorInfoGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BirthReportDoctorInfoGrid() : base() { }

    }
}