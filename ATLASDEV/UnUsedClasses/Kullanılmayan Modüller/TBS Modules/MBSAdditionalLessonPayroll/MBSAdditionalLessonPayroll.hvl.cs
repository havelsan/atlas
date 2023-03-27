
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSAdditionalLessonPayroll")] 

    /// <summary>
    /// Ek Ders Bordro
    /// </summary>
    public  partial class MBSAdditionalLessonPayroll : MBSPayroll
    {
        public class MBSAdditionalLessonPayrollList : TTObjectCollection<MBSAdditionalLessonPayroll> { }
                    
        public class ChildMBSAdditionalLessonPayrollCollection : TTObject.TTChildObjectCollection<MBSAdditionalLessonPayroll>
        {
            public ChildMBSAdditionalLessonPayrollCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSAdditionalLessonPayrollCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Damga pulu
    /// </summary>
        public double? StampTax
        {
            get { return (double?)this["STAMPTAX"]; }
            set { this["STAMPTAX"] = value; }
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
    /// Ders türü
    /// </summary>
        public string LessonType
        {
            get { return (string)this["LESSONTYPE"]; }
            set { this["LESSONTYPE"] = value; }
        }

    /// <summary>
    /// Gelir vergisi
    /// </summary>
        public double? IncomeTax
        {
            get { return (double?)this["INCOMETAX"]; }
            set { this["INCOMETAX"] = value; }
        }

    /// <summary>
    /// Sınav ücreti
    /// </summary>
        public double? ExamPrice
        {
            get { return (double?)this["EXAMPRICE"]; }
            set { this["EXAMPRICE"] = value; }
        }

    /// <summary>
    /// Kişi Türü
    /// </summary>
        public int? PersonType
        {
            get { return (int?)this["PERSONTYPE"]; }
            set { this["PERSONTYPE"] = value; }
        }

    /// <summary>
    /// Sınav gösterge
    /// </summary>
        public int? ExamIndicator
        {
            get { return (int?)this["EXAMINDICATOR"]; }
            set { this["EXAMINDICATOR"] = value; }
        }

        public MBSPeriod Period
        {
            get { return (MBSPeriod)((ITTObject)this).GetParent("PERIOD"); }
            set { this["PERIOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MBSPerson Person
        {
            get { return (MBSPerson)((ITTObject)this).GetParent("PERSON"); }
            set { this["PERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MBSAdditionalLessonPayroll(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSAdditionalLessonPayroll(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSAdditionalLessonPayroll(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSAdditionalLessonPayroll(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSAdditionalLessonPayroll(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSADDITIONALLESSONPAYROLL", dataRow) { }
        protected MBSAdditionalLessonPayroll(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSADDITIONALLESSONPAYROLL", dataRow, isImported) { }
        public MBSAdditionalLessonPayroll(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSAdditionalLessonPayroll(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSAdditionalLessonPayroll() : base() { }

    }
}