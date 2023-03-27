
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalOncology")] 

    public  partial class MedicalOncology : SpecialityBasedObject
    {
        public class MedicalOncologyList : TTObjectCollection<MedicalOncology> { }
                    
        public class ChildMedicalOncologyCollection : TTObject.TTChildObjectCollection<MedicalOncology>
        {
            public ChildMedicalOncologyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalOncologyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAllPatientBasedOncologyForms_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public object PreTreatmentStaging
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRETREATMENTSTAGING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["PRETREATMENTSTAGING"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object InterimEvaluation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERIMEVALUATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["INTERIMEVALUATION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object FirstLineTreatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTLINETREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["FIRSTLINETREATMENT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object SecondLineTreatment
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SECONDLINETREATMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["SECONDLINETREATMENT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Story
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["STORY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Pathology
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATHOLOGY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["PATHOLOGY"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string PS
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["PS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["TA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string NB
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NB"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["NB"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string M2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["M2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["M2"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Height
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["HEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetAllPatientBasedOncologyForms_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPatientBasedOncologyForms_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPatientBasedOncologyForms_Class() : base() { }
        }

        public static BindingList<MedicalOncology.GetAllPatientBasedOncologyForms_Class> GetAllPatientBasedOncologyForms(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].QueryDefs["GetAllPatientBasedOncologyForms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedicalOncology.GetAllPatientBasedOncologyForms_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalOncology.GetAllPatientBasedOncologyForms_Class> GetAllPatientBasedOncologyForms(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].QueryDefs["GetAllPatientBasedOncologyForms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<MedicalOncology.GetAllPatientBasedOncologyForms_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedicalOncology> GetAllPatientBasedOncologyForm(TTObjectContext objectContext, Guid PATIENT)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALONCOLOGY"].QueryDefs["GetAllPatientBasedOncologyForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<MedicalOncology>(queryDef, paramList);
        }

    /// <summary>
    /// Tedavi Öncesi Evreleme
    /// </summary>
        public object PreTreatmentStaging
        {
            get { return (object)this["PRETREATMENTSTAGING"]; }
            set { this["PRETREATMENTSTAGING"] = value; }
        }

    /// <summary>
    /// Ara Değerlendirme
    /// </summary>
        public object InterimEvaluation
        {
            get { return (object)this["INTERIMEVALUATION"]; }
            set { this["INTERIMEVALUATION"] = value; }
        }

    /// <summary>
    /// İlk Basamak Tedavi
    /// </summary>
        public object FirstLineTreatment
        {
            get { return (object)this["FIRSTLINETREATMENT"]; }
            set { this["FIRSTLINETREATMENT"] = value; }
        }

    /// <summary>
    /// İkinci Basamak Tedavi
    /// </summary>
        public object SecondLineTreatment
        {
            get { return (object)this["SECONDLINETREATMENT"]; }
            set { this["SECONDLINETREATMENT"] = value; }
        }

    /// <summary>
    /// Öykü
    /// </summary>
        public object Story
        {
            get { return (object)this["STORY"]; }
            set { this["STORY"] = value; }
        }

    /// <summary>
    /// Patoloji
    /// </summary>
        public object Pathology
        {
            get { return (object)this["PATHOLOGY"]; }
            set { this["PATHOLOGY"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Performance Status
    /// </summary>
        public string PS
        {
            get { return (string)this["PS"]; }
            set { this["PS"] = value; }
        }

    /// <summary>
    /// Therapeutic Area
    /// </summary>
        public string TA
        {
            get { return (string)this["TA"]; }
            set { this["TA"] = value; }
        }

        public string NB
        {
            get { return (string)this["NB"]; }
            set { this["NB"] = value; }
        }

        public string M2
        {
            get { return (string)this["M2"]; }
            set { this["M2"] = value; }
        }

        public double? Height
        {
            get { return (double?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

        protected MedicalOncology(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalOncology(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalOncology(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalOncology(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalOncology(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALONCOLOGY", dataRow) { }
        protected MedicalOncology(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALONCOLOGY", dataRow, isImported) { }
        public MedicalOncology(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalOncology(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalOncology() : base() { }

    }
}