
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PregnancyResult")] 

    public  partial class PregnancyResult : TTObject
    {
        public class PregnancyResultList : TTObjectCollection<PregnancyResult> { }
                    
        public class ChildPregnancyResultCollection : TTObject.TTChildObjectCollection<PregnancyResult>
        {
            public ChildPregnancyResultCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPregnancyResultCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPregnancyResultByPregnancy_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? BirthTerminationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTERMINATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCY"].AllPropertyDefs["BIRTHTERMINATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? BirthWeight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHWEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].AllPropertyDefs["BIRTHWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public SexEnum? Gendertype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENDERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].AllPropertyDefs["GENDER"].DataType;
                    return (SexEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public BirthReportBabyStatus? Babystatustext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABYSTATUSTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].AllPropertyDefs["BABYSTATUS"].DataType;
                    return (BirthReportBabyStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public string Birthtype
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSDOGUMYONTEMI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Birthresult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSGEBELIKSONUCU"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Congenitalanomalies
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONGENITALANOMALIES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSKONJENITALANOMALILIDOGUMVARLIGI"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BirthDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].AllPropertyDefs["BIRTHDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CesareanReason
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CESAREANREASON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].AllPropertyDefs["CESAREANREASON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AfterBirthStory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AFTERBIRTHSTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].AllPropertyDefs["AFTERBIRTHSTORY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPregnancyResultByPregnancy_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPregnancyResultByPregnancy_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPregnancyResultByPregnancy_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllPregnancyResultsByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public BirthReportBabyStatus? BabyStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BABYSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].AllPropertyDefs["BABYSTATUS"].DataType;
                    return (BirthReportBabyStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public GetAllPregnancyResultsByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllPregnancyResultsByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllPregnancyResultsByPatient_Class() : base() { }
        }

    /// <summary>
    /// Gebelik Sonucu
    /// </summary>
        public static BindingList<PregnancyResult.GetPregnancyResultByPregnancy_Class> GetPregnancyResultByPregnancy(Guid PREGNANCY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].QueryDefs["GetPregnancyResultByPregnancy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PREGNANCY", PREGNANCY);

            return TTReportNqlObject.QueryObjects<PregnancyResult.GetPregnancyResultByPregnancy_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Gebelik Sonucu
    /// </summary>
        public static BindingList<PregnancyResult.GetPregnancyResultByPregnancy_Class> GetPregnancyResultByPregnancy(TTObjectContext objectContext, Guid PREGNANCY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].QueryDefs["GetPregnancyResultByPregnancy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PREGNANCY", PREGNANCY);

            return TTReportNqlObject.QueryObjects<PregnancyResult.GetPregnancyResultByPregnancy_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<PregnancyResult.GetAllPregnancyResultsByPatient_Class> GetAllPregnancyResultsByPatient(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].QueryDefs["GetAllPregnancyResultsByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PregnancyResult.GetAllPregnancyResultsByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PregnancyResult.GetAllPregnancyResultsByPatient_Class> GetAllPregnancyResultsByPatient(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREGNANCYRESULT"].QueryDefs["GetAllPregnancyResultsByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<PregnancyResult.GetAllPregnancyResultsByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Doğum Ağırlığı(gr)
    /// </summary>
        public int? BirthWeight
        {
            get { return (int?)this["BIRTHWEIGHT"]; }
            set { this["BIRTHWEIGHT"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Gender
        {
            get { return (SexEnum?)(int?)this["GENDER"]; }
            set { this["GENDER"] = value; }
        }

    /// <summary>
    /// Doğum Açıklaması
    /// </summary>
        public string BirthDescription
        {
            get { return (string)this["BIRTHDESCRIPTION"]; }
            set { this["BIRTHDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Sezaryen Nedeni
    /// </summary>
        public string CesareanReason
        {
            get { return (string)this["CESAREANREASON"]; }
            set { this["CESAREANREASON"] = value; }
        }

    /// <summary>
    /// Doğum Sonrası Öyküsü
    /// </summary>
        public string AfterBirthStory
        {
            get { return (string)this["AFTERBIRTHSTORY"]; }
            set { this["AFTERBIRTHSTORY"] = value; }
        }

    /// <summary>
    /// Bebeğin Durumu
    /// </summary>
        public BirthReportBabyStatus? BabyStatus
        {
            get { return (BirthReportBabyStatus?)(int?)this["BABYSTATUS"]; }
            set { this["BABYSTATUS"] = value; }
        }

    /// <summary>
    /// Doğum Yöntemi
    /// </summary>
        public SKRSDogumYontemi BirthType
        {
            get { return (SKRSDogumYontemi)((ITTObject)this).GetParent("BIRTHTYPE"); }
            set { this["BIRTHTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSKonjenitalAnomaliliDogumVarligi CongenitalAnomalies
        {
            get { return (SKRSKonjenitalAnomaliliDogumVarligi)((ITTObject)this).GetParent("CONGENITALANOMALIES"); }
            set { this["CONGENITALANOMALIES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SKRSGebelikSonucu BirthResult
        {
            get { return (SKRSGebelikSonucu)((ITTObject)this).GetParent("BIRTHRESULT"); }
            set { this["BIRTHRESULT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Pregnancy Pregnancy
        {
            get { return (Pregnancy)((ITTObject)this).GetParent("PREGNANCY"); }
            set { this["PREGNANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PregnancyResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PregnancyResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PregnancyResult(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PregnancyResult(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PregnancyResult(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREGNANCYRESULT", dataRow) { }
        protected PregnancyResult(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREGNANCYRESULT", dataRow, isImported) { }
        public PregnancyResult(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PregnancyResult(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PregnancyResult() : base() { }

    }
}