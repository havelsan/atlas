
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExaminationInfoByBrans")] 

    /// <summary>
    /// İlgili Branşın Muayene Bilgileri
    /// </summary>
    public  partial class ExaminationInfoByBrans : TTObject
    {
        public class ExaminationInfoByBransList : TTObjectCollection<ExaminationInfoByBrans> { }
                    
        public class ChildExaminationInfoByBransCollection : TTObject.TTChildObjectCollection<ExaminationInfoByBrans>
        {
            public ChildExaminationInfoByBransCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExaminationInfoByBransCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ExaminationInfoByBrans> GetExaminationsBypatientAndBrans(TTObjectContext objectContext, Guid PATIENT, Guid MAINSPECIALITY, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONINFOBYBRANS"].QueryDefs["GetExaminationsBypatientAndBrans"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("MAINSPECIALITY", MAINSPECIALITY);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationInfoByBrans>(queryDef, paramList);
        }

        public static BindingList<ExaminationInfoByBrans> GetExaminationsByPatientExamination(TTObjectContext objectContext, Guid PATIENTEXAMINATIONOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXAMINATIONINFOBYBRANS"].QueryDefs["GetExaminationsByPatientExamination"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTEXAMINATIONOBJECTID", PATIENTEXAMINATIONOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<ExaminationInfoByBrans>(queryDef, paramList);
        }

    /// <summary>
    /// Şikayet
    /// </summary>
        public object Complaint
        {
            get { return (object)this["COMPLAINT"]; }
            set { this["COMPLAINT"] = value; }
        }

    /// <summary>
    /// Hikayesi
    /// </summary>
        public object PatientStory
        {
            get { return (object)this["PATIENTSTORY"]; }
            set { this["PATIENTSTORY"] = value; }
        }

    /// <summary>
    /// Fizik Muayene
    /// </summary>
        public object PhysicalExamination
        {
            get { return (object)this["PHYSICALEXAMINATION"]; }
            set { this["PHYSICALEXAMINATION"] = value; }
        }

        public PhysicianApplication PatientExamination
        {
            get { return (PhysicianApplication)((ITTObject)this).GetParent("PATIENTEXAMINATION"); }
            set { this["PATIENTEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDiagnosisGridCollection()
        {
            _DiagnosisGrid = new DiagnosisGrid.ChildDiagnosisGridCollection(this, new Guid("5e0d7197-4118-4a4f-a316-c2f9ba161fe8"));
            ((ITTChildObjectCollection)_DiagnosisGrid).GetChildren();
        }

        protected DiagnosisGrid.ChildDiagnosisGridCollection _DiagnosisGrid = null;
        public DiagnosisGrid.ChildDiagnosisGridCollection DiagnosisGrid
        {
            get
            {
                if (_DiagnosisGrid == null)
                    CreateDiagnosisGridCollection();
                return _DiagnosisGrid;
            }
        }

        protected ExaminationInfoByBrans(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExaminationInfoByBrans(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExaminationInfoByBrans(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExaminationInfoByBrans(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExaminationInfoByBrans(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXAMINATIONINFOBYBRANS", dataRow) { }
        protected ExaminationInfoByBrans(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXAMINATIONINFOBYBRANS", dataRow, isImported) { }
        public ExaminationInfoByBrans(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExaminationInfoByBrans(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExaminationInfoByBrans() : base() { }

    }
}