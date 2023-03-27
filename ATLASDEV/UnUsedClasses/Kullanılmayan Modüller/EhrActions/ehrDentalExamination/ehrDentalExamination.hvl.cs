
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrDentalExamination")] 

    /// <summary>
    /// Diş Muayenesi 
    /// </summary>
    public  partial class ehrDentalExamination : ehrEpisodeAction
    {
        public class ehrDentalExaminationList : TTObjectCollection<ehrDentalExamination> { }
                    
        public class ChildehrDentalExaminationCollection : TTObject.TTChildObjectCollection<ehrDentalExamination>
        {
            public ChildehrDentalExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrDentalExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Diş Tedavi Dosyası
    /// </summary>
        public object DentalExaminationFile
        {
            get { return (object)this["DENTALEXAMINATIONFILE"]; }
            set { this["DENTALEXAMINATIONFILE"] = value; }
        }

        protected ehrDentalExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrDentalExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrDentalExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrDentalExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrDentalExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRDENTALEXAMINATION", dataRow) { }
        protected ehrDentalExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRDENTALEXAMINATION", dataRow, isImported) { }
        public ehrDentalExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrDentalExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrDentalExamination() : base() { }

    }
}