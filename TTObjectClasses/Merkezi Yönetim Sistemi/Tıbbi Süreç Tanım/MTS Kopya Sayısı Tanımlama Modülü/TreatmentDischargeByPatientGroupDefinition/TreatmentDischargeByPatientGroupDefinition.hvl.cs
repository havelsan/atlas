
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TreatmentDischargeByPatientGroupDefinition")] 

    /// <summary>
    /// Muayene Tedavi Sonuç Kopya Sayısı Tanımlama Modülü
    /// </summary>
    public  partial class TreatmentDischargeByPatientGroupDefinition : TerminologyManagerDef
    {
        public class TreatmentDischargeByPatientGroupDefinitionList : TTObjectCollection<TreatmentDischargeByPatientGroupDefinition> { }
                    
        public class ChildTreatmentDischargeByPatientGroupDefinitionCollection : TTObject.TTChildObjectCollection<TreatmentDischargeByPatientGroupDefinition>
        {
            public ChildTreatmentDischargeByPatientGroupDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTreatmentDischargeByPatientGroupDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTreatmentDischargeByPatientGroupDefinition_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public PatientGroupEnum? PatientGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TREATMENTDISCHARGEBYPATIENTGROUPDEFINITION"].AllPropertyDefs["PATIENTGROUP"].DataType;
                    return (PatientGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetTreatmentDischargeByPatientGroupDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTreatmentDischargeByPatientGroupDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTreatmentDischargeByPatientGroupDefinition_Class() : base() { }
        }

        public static BindingList<TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition_Class> GetTreatmentDischargeByPatientGroupDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TREATMENTDISCHARGEBYPATIENTGROUPDEFINITION"].QueryDefs["GetTreatmentDischargeByPatientGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition_Class> GetTreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TREATMENTDISCHARGEBYPATIENTGROUPDEFINITION"].QueryDefs["GetTreatmentDischargeByPatientGroupDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TreatmentDischargeByPatientGroupDefinition.GetTreatmentDischargeByPatientGroupDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TreatmentDischargeByPatientGroupDefinition> GetTreatmntDischByPatGrpDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TREATMENTDISCHARGEBYPATIENTGROUPDEFINITION"].QueryDefs["GetTreatmntDischByPatGrpDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<TreatmentDischargeByPatientGroupDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Yatan Hasta Onay Türü
    /// </summary>
        public TreatmentDischargeApprovementEnum? InpatientApprovement
        {
            get { return (TreatmentDischargeApprovementEnum?)(int?)this["INPATIENTAPPROVEMENT"]; }
            set { this["INPATIENTAPPROVEMENT"] = value; }
        }

    /// <summary>
    /// Hasta Grubu
    /// </summary>
        public PatientGroupEnum? PatientGroup
        {
            get { return (PatientGroupEnum?)(int?)this["PATIENTGROUP"]; }
            set { this["PATIENTGROUP"] = value; }
        }

    /// <summary>
    /// Ayaktan Hasta Onay Türü
    /// </summary>
        public TreatmentDischargeApprovementEnum? OutpatientApprovement
        {
            get { return (TreatmentDischargeApprovementEnum?)(int?)this["OUTPATIENTAPPROVEMENT"]; }
            set { this["OUTPATIENTAPPROVEMENT"] = value; }
        }

    /// <summary>
    /// Aktif
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

        virtual protected void CreateNumberOfCopiesCollectionViews()
        {
            _OutpatientNumberOfCopies = new OutpatientNumberOfCopiesGrid.ChildOutpatientNumberOfCopiesGridCollection(_NumberOfCopies, "OutpatientNumberOfCopies");
            _InpatientNumberOfCopies = new InpatientNumberOfCopiesGrid.ChildInpatientNumberOfCopiesGridCollection(_NumberOfCopies, "InpatientNumberOfCopies");
        }

        virtual protected void CreateNumberOfCopiesCollection()
        {
            _NumberOfCopies = new NumberOfCopiesGrid.ChildNumberOfCopiesGridCollection(this, new Guid("28f0ec94-ad1d-4e22-a8cd-abcc8edfdc9c"));
            CreateNumberOfCopiesCollectionViews();
            ((ITTChildObjectCollection)_NumberOfCopies).GetChildren();
        }

        protected NumberOfCopiesGrid.ChildNumberOfCopiesGridCollection _NumberOfCopies = null;
    /// <summary>
    /// Child collection for TreatmentDischargeNumberOfCopiesOutpatientNumberOfCopies
    /// </summary>
        public NumberOfCopiesGrid.ChildNumberOfCopiesGridCollection NumberOfCopies
        {
            get
            {
                if (_NumberOfCopies == null)
                    CreateNumberOfCopiesCollection();
                return _NumberOfCopies;
            }
        }

        private OutpatientNumberOfCopiesGrid.ChildOutpatientNumberOfCopiesGridCollection _OutpatientNumberOfCopies = null;
        public OutpatientNumberOfCopiesGrid.ChildOutpatientNumberOfCopiesGridCollection OutpatientNumberOfCopies
        {
            get
            {
                if (_NumberOfCopies == null)
                    CreateNumberOfCopiesCollection();
                return _OutpatientNumberOfCopies;
            }            
        }

        private InpatientNumberOfCopiesGrid.ChildInpatientNumberOfCopiesGridCollection _InpatientNumberOfCopies = null;
        public InpatientNumberOfCopiesGrid.ChildInpatientNumberOfCopiesGridCollection InpatientNumberOfCopies
        {
            get
            {
                if (_NumberOfCopies == null)
                    CreateNumberOfCopiesCollection();
                return _InpatientNumberOfCopies;
            }            
        }

        protected TreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TREATMENTDISCHARGEBYPATIENTGROUPDEFINITION", dataRow) { }
        protected TreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TREATMENTDISCHARGEBYPATIENTGROUPDEFINITION", dataRow, isImported) { }
        protected TreatmentDischargeByPatientGroupDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TreatmentDischargeByPatientGroupDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TreatmentDischargeByPatientGroupDefinition() : base() { }

    }
}