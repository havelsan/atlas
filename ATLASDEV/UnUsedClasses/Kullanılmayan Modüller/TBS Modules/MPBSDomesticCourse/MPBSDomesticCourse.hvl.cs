
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSDomesticCourse")] 

    /// <summary>
    /// Yurtiçi Kurs
    /// </summary>
    public  partial class MPBSDomesticCourse : MPBSActivity
    {
        public class MPBSDomesticCourseList : TTObjectCollection<MPBSDomesticCourse> { }
                    
        public class ChildMPBSDomesticCourseCollection : TTObject.TTChildObjectCollection<MPBSDomesticCourse>
        {
            public ChildMPBSDomesticCourseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSDomesticCourseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Dönem
    /// </summary>
        public string Term
        {
            get { return (string)this["TERM"]; }
            set { this["TERM"] = value; }
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Kurs Kodu
    /// </summary>
        public string CourseCode
        {
            get { return (string)this["COURSECODE"]; }
            set { this["COURSECODE"] = value; }
        }

    /// <summary>
    /// Sorumlu XXXXXXlık/Başkanlık
    /// </summary>
        public string ChairmanshipIncharge
        {
            get { return (string)this["CHAIRMANSHIPINCHARGE"]; }
            set { this["CHAIRMANSHIPINCHARGE"] = value; }
        }

        protected MPBSDomesticCourse(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSDomesticCourse(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSDomesticCourse(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSDomesticCourse(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSDomesticCourse(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSDOMESTICCOURSE", dataRow) { }
        protected MPBSDomesticCourse(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSDOMESTICCOURSE", dataRow, isImported) { }
        public MPBSDomesticCourse(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSDomesticCourse(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSDomesticCourse() : base() { }

    }
}