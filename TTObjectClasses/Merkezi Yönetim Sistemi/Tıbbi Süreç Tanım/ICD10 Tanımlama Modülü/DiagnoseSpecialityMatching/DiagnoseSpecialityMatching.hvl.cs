
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiagnoseSpecialityMatching")] 

    /// <summary>
    /// Tanı-Uzmanlık Dalı Eşleştirme Tanımları
    /// </summary>
    public  partial class DiagnoseSpecialityMatching : TerminologyManagerDef
    {
        public class DiagnoseSpecialityMatchingList : TTObjectCollection<DiagnoseSpecialityMatching> { }
                    
        public class ChildDiagnoseSpecialityMatchingCollection : TTObject.TTChildObjectCollection<DiagnoseSpecialityMatching>
        {
            public ChildDiagnoseSpecialityMatchingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiagnoseSpecialityMatchingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDiagnoseSpecialityMatching_Class : TTReportNqlObject 
        {
            public string Specialityname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SPECIALITYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SPECIALITYDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDiagnoseSpecialityMatching_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiagnoseSpecialityMatching_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiagnoseSpecialityMatching_Class() : base() { }
        }

        public static BindingList<DiagnoseSpecialityMatching> GetBySpeciality(TTObjectContext objectContext, string SPECIALITY)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSESPECIALITYMATCHING"].QueryDefs["GetBySpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SPECIALITY", SPECIALITY);

            return ((ITTQuery)objectContext).QueryObjects<DiagnoseSpecialityMatching>(queryDef, paramList);
        }

        public static BindingList<DiagnoseSpecialityMatching.GetDiagnoseSpecialityMatching_Class> GetDiagnoseSpecialityMatching(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSESPECIALITYMATCHING"].QueryDefs["GetDiagnoseSpecialityMatching"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnoseSpecialityMatching.GetDiagnoseSpecialityMatching_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnoseSpecialityMatching.GetDiagnoseSpecialityMatching_Class> GetDiagnoseSpecialityMatching(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSESPECIALITYMATCHING"].QueryDefs["GetDiagnoseSpecialityMatching"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiagnoseSpecialityMatching.GetDiagnoseSpecialityMatching_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiagnoseSpecialityMatching> GetDiagnoseSpeciltyMatchByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DIAGNOSESPECIALITYMATCHING"].QueryDefs["GetDiagnoseSpeciltyMatchByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DiagnoseSpecialityMatching>(queryDef, paramList);
        }

        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDiagnosisCollection()
        {
            _Diagnosis = new DiagnosisGridForMatching.ChildDiagnosisGridForMatchingCollection(this, new Guid("07362c5d-4351-4992-ac0e-ded5b351f15c"));
            ((ITTChildObjectCollection)_Diagnosis).GetChildren();
        }

        protected DiagnosisGridForMatching.ChildDiagnosisGridForMatchingCollection _Diagnosis = null;
        public DiagnosisGridForMatching.ChildDiagnosisGridForMatchingCollection Diagnosis
        {
            get
            {
                if (_Diagnosis == null)
                    CreateDiagnosisCollection();
                return _Diagnosis;
            }
        }

        protected DiagnoseSpecialityMatching(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiagnoseSpecialityMatching(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiagnoseSpecialityMatching(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiagnoseSpecialityMatching(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiagnoseSpecialityMatching(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DIAGNOSESPECIALITYMATCHING", dataRow) { }
        protected DiagnoseSpecialityMatching(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DIAGNOSESPECIALITYMATCHING", dataRow, isImported) { }
        public DiagnoseSpecialityMatching(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiagnoseSpecialityMatching(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiagnoseSpecialityMatching() : base() { }

    }
}