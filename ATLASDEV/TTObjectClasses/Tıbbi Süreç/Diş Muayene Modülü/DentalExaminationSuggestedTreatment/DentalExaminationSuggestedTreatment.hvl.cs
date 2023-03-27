
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalExaminationSuggestedTreatment")] 

    /// <summary>
    /// Önerilen Diş Tedavi
    /// </summary>
    public  partial class DentalExaminationSuggestedTreatment : DentalTreatmentRequestSuggestedTreatment
    {
        public class DentalExaminationSuggestedTreatmentList : TTObjectCollection<DentalExaminationSuggestedTreatment> { }
                    
        public class ChildDentalExaminationSuggestedTreatmentCollection : TTObject.TTChildObjectCollection<DentalExaminationSuggestedTreatment>
        {
            public ChildDentalExaminationSuggestedTreatmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalExaminationSuggestedTreatmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("c919300e-a96f-4dc4-a4bb-5d1cf76a5506"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("82f8840c-ede6-4d62-bf65-0a66dcdecf2b"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("7d0854ef-67f5-4682-8eed-79e599b5f291"); } }
        }

    /// <summary>
    /// Önerilen Diş Tedavi
    /// </summary>
        public DentalExamination DentalExamination
        {
            get { return (DentalExamination)((ITTObject)this).GetParent("DENTALEXAMINATION"); }
            set { this["DENTALEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalExaminationSuggestedTreatment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalExaminationSuggestedTreatment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalExaminationSuggestedTreatment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalExaminationSuggestedTreatment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalExaminationSuggestedTreatment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALEXAMINATIONSUGGESTEDTREATMENT", dataRow) { }
        protected DentalExaminationSuggestedTreatment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALEXAMINATIONSUGGESTEDTREATMENT", dataRow, isImported) { }
        public DentalExaminationSuggestedTreatment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalExaminationSuggestedTreatment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalExaminationSuggestedTreatment() : base() { }

    }
}