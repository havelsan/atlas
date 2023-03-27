
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientExamParticipationDefinition")] 

    /// <summary>
    /// Katılım Payı Alınmayacak Hal, Sağlık Hizmeti ve Kişi Tanımları
    /// </summary>
    public  partial class PatientExamParticipationDefinition : TerminologyManagerDef
    {
        public class PatientExamParticipationDefinitionList : TTObjectCollection<PatientExamParticipationDefinition> { }
                    
        public class ChildPatientExamParticipationDefinitionCollection : TTObject.TTChildObjectCollection<PatientExamParticipationDefinition>
        {
            public ChildPatientExamParticipationDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientExamParticipationDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientParticipationDefs_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ExternalCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTERNALCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMPARTICIPATIONDEFINITION"].AllPropertyDefs["EXTERNALCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMPARTICIPATIONDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ExcludeParticipationTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMPARTICIPATIONDEFINITION"].AllPropertyDefs["TYPE"].DataType;
                    return (ExcludeParticipationTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetPatientParticipationDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientParticipationDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientParticipationDefs_Class() : base() { }
        }

        public static BindingList<PatientExamParticipationDefinition> GetPatientExamParticipationDefinitionByLastUpdate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMPARTICIPATIONDEFINITION"].QueryDefs["GetPatientExamParticipationDefinitionByLastUpdate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientExamParticipationDefinition>(queryDef, paramList);
        }

        public static BindingList<PatientExamParticipationDefinition.GetPatientParticipationDefs_Class> GetPatientParticipationDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMPARTICIPATIONDEFINITION"].QueryDefs["GetPatientParticipationDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientExamParticipationDefinition.GetPatientParticipationDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamParticipationDefinition.GetPatientParticipationDefs_Class> GetPatientParticipationDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMPARTICIPATIONDEFINITION"].QueryDefs["GetPatientParticipationDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientExamParticipationDefinition.GetPatientParticipationDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientExamParticipationDefinition> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTEXAMPARTICIPATIONDEFINITION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PatientExamParticipationDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Sadece tanımlı birimler için geçerlidir
    /// </summary>
        public bool? OnlyForDefinedUnits
        {
            get { return (bool?)this["ONLYFORDEFINEDUNITS"]; }
            set { this["ONLYFORDEFINEDUNITS"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string ExternalCode
        {
            get { return (string)this["EXTERNALCODE"]; }
            set { this["EXTERNALCODE"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public ExcludeParticipationTypeEnum? Type
        {
            get { return (ExcludeParticipationTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        virtual protected void CreateUnitsCollection()
        {
            _Units = new PatientExamParticipUnit.ChildPatientExamParticipUnitCollection(this, new Guid("f4e5dec0-df4b-450b-aa3f-ca27fb0beb83"));
            ((ITTChildObjectCollection)_Units).GetChildren();
        }

        protected PatientExamParticipUnit.ChildPatientExamParticipUnitCollection _Units = null;
    /// <summary>
    /// Child collection for Hasta Yakınlık Dereceleri Tanım Ekranı ile ilişki
    /// </summary>
        public PatientExamParticipUnit.ChildPatientExamParticipUnitCollection Units
        {
            get
            {
                if (_Units == null)
                    CreateUnitsCollection();
                return _Units;
            }
        }

        virtual protected void CreateRelationshipsCollection()
        {
            _Relationships = new PatientExamParticipDetail.ChildPatientExamParticipDetailCollection(this, new Guid("e589af97-ca32-4d75-ba47-0182c3cb9e1b"));
            ((ITTChildObjectCollection)_Relationships).GetChildren();
        }

        protected PatientExamParticipDetail.ChildPatientExamParticipDetailCollection _Relationships = null;
    /// <summary>
    /// Child collection for Hasta Yakınlık Dereceleri Tanım Ekranı ile ilişki
    /// </summary>
        public PatientExamParticipDetail.ChildPatientExamParticipDetailCollection Relationships
        {
            get
            {
                if (_Relationships == null)
                    CreateRelationshipsCollection();
                return _Relationships;
            }
        }

        protected PatientExamParticipationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientExamParticipationDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientExamParticipationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientExamParticipationDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientExamParticipationDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTEXAMPARTICIPATIONDEFINITION", dataRow) { }
        protected PatientExamParticipationDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTEXAMPARTICIPATIONDEFINITION", dataRow, isImported) { }
        public PatientExamParticipationDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientExamParticipationDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientExamParticipationDefinition() : base() { }

    }
}