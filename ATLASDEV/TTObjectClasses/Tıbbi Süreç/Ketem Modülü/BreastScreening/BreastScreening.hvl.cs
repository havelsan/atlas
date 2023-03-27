
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BreastScreening")] 

    public  partial class BreastScreening : KetemWoman
    {
        public class BreastScreeningList : TTObjectCollection<BreastScreening> { }
                    
        public class ChildBreastScreeningCollection : TTObject.TTChildObjectCollection<BreastScreening>
        {
            public ChildBreastScreeningCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBreastScreeningCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBreastScreeningBySubepisodeID_Class : TTReportNqlObject 
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

            public string MenstrualCycle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MENSTRUALCYCLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["MENSTRUALCYCLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? MenarcheAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MENARCHEAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["MENARCHEAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MenopauseAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MENOPAUSEAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["MENOPAUSEAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? LastMenstruationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTMENSTRUATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["LASTMENSTRUATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? FirstMarriageAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTMARRIAGEAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["FIRSTMARRIAGEAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? FirstGestationalAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRSTGESTATIONALAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["FIRSTGESTATIONALAGE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? GestationalNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GESTATIONALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["GESTATIONALNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? LiveBirthNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LIVEBIRTHNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["LIVEBIRTHNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? FamilyBreastCA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYBREASTCA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["FAMILYBREASTCA"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public PersonalBreastCAEnum? PersonalBreastCA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONALBREASTCA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["PERSONALBREASTCA"].DataType;
                    return (PersonalBreastCAEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public YesNoEnum? Mastectomy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTECTOMY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["MASTECTOMY"].DataType;
                    return (YesNoEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string MastectomyText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTECTOMYTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["MASTECTOMYTEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? Lactation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LACTATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["LACTATION"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string LactationText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LACTATIONTEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["LACTATIONTEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? BreastExamination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREASTEXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["BREASTEXAMINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Bening
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BENING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["BENING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PossibleBening
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POSSIBLEBENING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["POSSIBLEBENING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Mammography
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAMMOGRAPHY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["MAMMOGRAPHY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? BiopsySuggestion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIOPSYSUGGESTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["BIOPSYSUGGESTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Malignite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MALIGNITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["MALIGNITE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AssessmentCompleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASSESSMENTCOMPLETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["ASSESSMENTCOMPLETED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Informed
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INFORMED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["INFORMED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? InsufficientResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INSUFFICIENTRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["INSUFFICIENTRESULT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? SuspiciousAnomaly
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUSPICIOUSANOMALY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["SUSPICIOUSANOMALY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBreastScreeningBySubepisodeID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBreastScreeningBySubepisodeID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBreastScreeningBySubepisodeID_Class() : base() { }
        }

        public static BindingList<BreastScreening.GetBreastScreeningBySubepisodeID_Class> GetBreastScreeningBySubepisodeID(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].QueryDefs["GetBreastScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<BreastScreening.GetBreastScreeningBySubepisodeID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BreastScreening.GetBreastScreeningBySubepisodeID_Class> GetBreastScreeningBySubepisodeID(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BREASTSCREENING"].QueryDefs["GetBreastScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<BreastScreening.GetBreastScreeningBySubepisodeID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ailede Meme CA Öyküsü
    /// </summary>
        public VarYokGarantiEnum? FamilyBreastCA
        {
            get { return (VarYokGarantiEnum?)(int?)this["FAMILYBREASTCA"]; }
            set { this["FAMILYBREASTCA"] = value; }
        }

    /// <summary>
    /// Kişisel Meme CA Öyküsü
    /// </summary>
        public PersonalBreastCAEnum? PersonalBreastCA
        {
            get { return (PersonalBreastCAEnum?)(int?)this["PERSONALBREASTCA"]; }
            set { this["PERSONALBREASTCA"] = value; }
        }

    /// <summary>
    /// Mastektomi Yapılmış Mı?
    /// </summary>
        public YesNoEnum? Mastectomy
        {
            get { return (YesNoEnum?)(int?)this["MASTECTOMY"]; }
            set { this["MASTECTOMY"] = value; }
        }

        public string MastectomyText
        {
            get { return (string)this["MASTECTOMYTEXT"]; }
            set { this["MASTECTOMYTEXT"] = value; }
        }

    /// <summary>
    /// Laktasyon Öyküsü
    /// </summary>
        public VarYokGarantiEnum? Lactation
        {
            get { return (VarYokGarantiEnum?)(int?)this["LACTATION"]; }
            set { this["LACTATION"] = value; }
        }

        public string LactationText
        {
            get { return (string)this["LACTATIONTEXT"]; }
            set { this["LACTATIONTEXT"] = value; }
        }

    /// <summary>
    /// Normal Meme Muayenesi Yapıldı
    /// </summary>
        public bool? BreastExamination
        {
            get { return (bool?)this["BREASTEXAMINATION"]; }
            set { this["BREASTEXAMINATION"] = value; }
        }

    /// <summary>
    /// Bening Bulgulara Rastlandı
    /// </summary>
        public bool? Bening
        {
            get { return (bool?)this["BENING"]; }
            set { this["BENING"] = value; }
        }

    /// <summary>
    /// Muhtemelen Bening (Kısa Fönemde Takip) Olağan Dışı Takip
    /// </summary>
        public bool? PossibleBening
        {
            get { return (bool?)this["POSSIBLEBENING"]; }
            set { this["POSSIBLEBENING"] = value; }
        }

    /// <summary>
    /// Mamografi Çekildi
    /// </summary>
        public bool? Mammography
        {
            get { return (bool?)this["MAMMOGRAPHY"]; }
            set { this["MAMMOGRAPHY"] = value; }
        }

    /// <summary>
    /// Biyopsi Önerisi Yapıldı
    /// </summary>
        public bool? BiopsySuggestion
        {
            get { return (bool?)this["BIOPSYSUGGESTION"]; }
            set { this["BIOPSYSUGGESTION"] = value; }
        }

    /// <summary>
    /// Malignite İçin büyük Oranda Fikir Verici
    /// </summary>
        public bool? Malignite
        {
            get { return (bool?)this["MALIGNITE"]; }
            set { this["MALIGNITE"] = value; }
        }

    /// <summary>
    /// Değerlendirme Tamamlandı
    /// </summary>
        public bool? AssessmentCompleted
        {
            get { return (bool?)this["ASSESSMENTCOMPLETED"]; }
            set { this["ASSESSMENTCOMPLETED"] = value; }
        }

    /// <summary>
    /// Bilgilendirildi ve Evine Gönderildi
    /// </summary>
        public bool? Informed
        {
            get { return (bool?)this["INFORMED"]; }
            set { this["INFORMED"] = value; }
        }

    /// <summary>
    /// Yetersiz Sonuç (Yorumlanamıyor)
    /// </summary>
        public bool? InsufficientResult
        {
            get { return (bool?)this["INSUFFICIENTRESULT"]; }
            set { this["INSUFFICIENTRESULT"] = value; }
        }

    /// <summary>
    /// Şüpheli Anomali
    /// </summary>
        public bool? SuspiciousAnomaly
        {
            get { return (bool?)this["SUSPICIOUSANOMALY"]; }
            set { this["SUSPICIOUSANOMALY"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public AnamnesisInfo AnamnesisInfo
        {
            get { return (AnamnesisInfo)((ITTObject)this).GetParent("ANAMNESISINFO"); }
            set { this["ANAMNESISINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BreastScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BreastScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BreastScreening(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BreastScreening(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BreastScreening(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BREASTSCREENING", dataRow) { }
        protected BreastScreening(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BREASTSCREENING", dataRow, isImported) { }
        public BreastScreening(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BreastScreening(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BreastScreening() : base() { }

    }
}