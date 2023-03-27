
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPersonOnOutsideDuty")] 

    public  partial class MBSPersonOnOutsideDuty : TTObject
    {
        public class MBSPersonOnOutsideDutyList : TTObjectCollection<MBSPersonOnOutsideDuty> { }
                    
        public class ChildMBSPersonOnOutsideDutyCollection : TTObject.TTChildObjectCollection<MBSPersonOnOutsideDuty>
        {
            public ChildMBSPersonOnOutsideDutyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPersonOnOutsideDutyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Gelir vergisi matrahı
    /// </summary>
        public double? IncomeTaxAssessment
        {
            get { return (double?)this["INCOMETAXASSESSMENT"]; }
            set { this["INCOMETAXASSESSMENT"] = value; }
        }

    /// <summary>
    /// Adresi
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Ders Türü
    /// </summary>
        public string LessonType
        {
            get { return (string)this["LESSONTYPE"]; }
            set { this["LESSONTYPE"] = value; }
        }

    /// <summary>
    /// Ders Durumu
    /// </summary>
        public string LessonStatus
        {
            get { return (string)this["LESSONSTATUS"]; }
            set { this["LESSONSTATUS"] = value; }
        }

    /// <summary>
    /// Unvan
    /// </summary>
        public string Title
        {
            get { return (string)this["TITLE"]; }
            set { this["TITLE"] = value; }
        }

    /// <summary>
    /// Sosyal Güvenlik Türü
    /// </summary>
        public string SocialSecurityType
        {
            get { return (string)this["SOCIALSECURITYTYPE"]; }
            set { this["SOCIALSECURITYTYPE"] = value; }
        }

    /// <summary>
    /// Doğum Tarihi
    /// </summary>
        public DateTime? BirthDate
        {
            get { return (DateTime?)this["BIRTHDATE"]; }
            set { this["BIRTHDATE"] = value; }
        }

    /// <summary>
    /// Sosyal güvenlik sicil no
    /// </summary>
        public string SocialSecurityRegistrationNo
        {
            get { return (string)this["SOCIALSECURITYREGISTRATIONNO"]; }
            set { this["SOCIALSECURITYREGISTRATIONNO"] = value; }
        }

    /// <summary>
    /// Görev Yeri
    /// </summary>
        public string JobPlace
        {
            get { return (string)this["JOBPLACE"]; }
            set { this["JOBPLACE"] = value; }
        }

    /// <summary>
    /// Görev
    /// </summary>
        public string Job
        {
            get { return (string)this["JOB"]; }
            set { this["JOB"] = value; }
        }

        protected MBSPersonOnOutsideDuty(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPersonOnOutsideDuty(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPersonOnOutsideDuty(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPersonOnOutsideDuty(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPersonOnOutsideDuty(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPERSONONOUTSIDEDUTY", dataRow) { }
        protected MBSPersonOnOutsideDuty(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPERSONONOUTSIDEDUTY", dataRow, isImported) { }
        public MBSPersonOnOutsideDuty(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPersonOnOutsideDuty(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPersonOnOutsideDuty() : base() { }

    }
}