
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrFollowUpExamination")] 

    /// <summary>
    /// Hasta Kontrol Muayenesi
    /// </summary>
    public  partial class ehrFollowUpExamination : ehrEpisodeAction
    {
        public class ehrFollowUpExaminationList : TTObjectCollection<ehrFollowUpExamination> { }
                    
        public class ChildehrFollowUpExaminationCollection : TTObject.TTChildObjectCollection<ehrFollowUpExamination>
        {
            public ChildehrFollowUpExaminationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrFollowUpExaminationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Karar ve İşlem
    /// </summary>
        public object DecisionAndAction
        {
            get { return (object)this["DECISIONANDACTION"]; }
            set { this["DECISIONANDACTION"] = value; }
        }

    /// <summary>
    /// Muayene Özeti
    /// </summary>
        public object ExaminationSummary
        {
            get { return (object)this["EXAMINATIONSUMMARY"]; }
            set { this["EXAMINATIONSUMMARY"] = value; }
        }

    /// <summary>
    /// Alışkanlıklar
    /// </summary>
        public object Habits
        {
            get { return (object)this["HABITS"]; }
            set { this["HABITS"] = value; }
        }

    /// <summary>
    /// Soygeçmiş
    /// </summary>
        public object PatientFamilyHistory
        {
            get { return (object)this["PATIENTFAMILYHISTORY"]; }
            set { this["PATIENTFAMILYHISTORY"] = value; }
        }

    /// <summary>
    /// Özgeçmiş / Soygeçmiş
    /// </summary>
        public object PatientHistory
        {
            get { return (object)this["PATIENTHISTORY"]; }
            set { this["PATIENTHISTORY"] = value; }
        }

    /// <summary>
    /// Hasta Dosyası
    /// </summary>
        public object PatientFolder
        {
            get { return (object)this["PATIENTFOLDER"]; }
            set { this["PATIENTFOLDER"] = value; }
        }

    /// <summary>
    /// Şikayeti
    /// </summary>
        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Fizik Muayene
    /// </summary>
        public object PhysicalExamination
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

    /// <summary>
    /// Devamlı İlaçlar
    /// </summary>
        public object ContinuousDrugs
        {
            get { return (object)this["CONTINUOUSDRUGS"]; }
            set { this["CONTINUOUSDRUGS"] = value; }
        }

        protected ehrFollowUpExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrFollowUpExamination(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrFollowUpExamination(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrFollowUpExamination(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrFollowUpExamination(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRFOLLOWUPEXAMINATION", dataRow) { }
        protected ehrFollowUpExamination(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRFOLLOWUPEXAMINATION", dataRow, isImported) { }
        public ehrFollowUpExamination(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrFollowUpExamination(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrFollowUpExamination() : base() { }

    }
}