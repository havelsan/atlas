
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BabyObstetricInformation")] 

    /// <summary>
    /// Bebek Bilgileri
    /// </summary>
    public  partial class BabyObstetricInformation : BaseMultipleDataEntry
    {
        public class BabyObstetricInformationList : TTObjectCollection<BabyObstetricInformation> { }
                    
        public class ChildBabyObstetricInformationCollection : TTObject.TTChildObjectCollection<BabyObstetricInformation>
        {
            public ChildBabyObstetricInformationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBabyObstetricInformationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class BirthInfoReportNQL_Class : TTReportNqlObject 
        {
            public string Mothername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mothersurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Motheruniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Masterresource
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MASTERRESOURCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Birthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].AllPropertyDefs["BIRTHDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? HeadCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].AllPropertyDefs["HEADCIRCUMFERENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public string Sex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Weigth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].AllPropertyDefs["WEIGTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public BirthInfoReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public BirthInfoReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected BirthInfoReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAliveNewBornInfoByDate_Class : TTReportNqlObject 
        {
            public string Mothername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mothersurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOTHERSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthDateTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATETIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].AllPropertyDefs["BIRTHDATETIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Gender
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENDER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["ADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Genderkodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GENDERKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCINSIYET"].AllPropertyDefs["KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Weigth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].AllPropertyDefs["WEIGTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Resourcename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESOURCENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAliveNewBornInfoByDate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAliveNewBornInfoByDate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAliveNewBornInfoByDate_Class() : base() { }
        }

        public static BindingList<BabyObstetricInformation.BirthInfoReportNQL_Class> BirthInfoReportNQL(DateTime STARTTIME, DateTime ENDTIME, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].QueryDefs["BirthInfoReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);

            return TTReportNqlObject.QueryObjects<BabyObstetricInformation.BirthInfoReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BabyObstetricInformation.BirthInfoReportNQL_Class> BirthInfoReportNQL(TTObjectContext objectContext, DateTime STARTTIME, DateTime ENDTIME, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].QueryDefs["BirthInfoReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTTIME", STARTTIME);
            paramList.Add("ENDTIME", ENDTIME);

            return TTReportNqlObject.QueryObjects<BabyObstetricInformation.BirthInfoReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Bebek LCD için yenidoğan bilgileri
    /// </summary>
        public static BindingList<BabyObstetricInformation.GetAliveNewBornInfoByDate_Class> GetAliveNewBornInfoByDate(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].QueryDefs["GetAliveNewBornInfoByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BabyObstetricInformation.GetAliveNewBornInfoByDate_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// Bebek LCD için yenidoğan bilgileri
    /// </summary>
        public static BindingList<BabyObstetricInformation.GetAliveNewBornInfoByDate_Class> GetAliveNewBornInfoByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BABYOBSTETRICINFORMATION"].QueryDefs["GetAliveNewBornInfoByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BabyObstetricInformation.GetAliveNewBornInfoByDate_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Baba Adı
    /// </summary>
        public string FatherName
        {
            get { return (string)this["FATHERNAME"]; }
            set { this["FATHERNAME"] = value; }
        }

    /// <summary>
    /// Bebeğin Soyadı
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Boy
    /// </summary>
        public int? Height
        {
            get { return (int?)this["HEIGHT"]; }
            set { this["HEIGHT"] = value; }
        }

    /// <summary>
    /// Bebekte Yaşanan Sorun/Tespit Edilen Riskler
    /// </summary>
        public string BabyProblems
        {
            get { return (string)this["BABYPROBLEMS"]; }
            set { this["BABYPROBLEMS"] = value; }
        }

    /// <summary>
    /// Kol Bandı Numarası
    /// </summary>
        public int? WristbandNumber
        {
            get { return (int?)this["WRISTBANDNUMBER"]; }
            set { this["WRISTBANDNUMBER"] = value; }
        }

    /// <summary>
    /// Fenilketonüri İçin Kan Alındı
    /// </summary>
        public bool? PhenylketonuriaBlood
        {
            get { return (bool?)this["PHENYLKETONURIABLOOD"]; }
            set { this["PHENYLKETONURIABLOOD"] = value; }
        }

    /// <summary>
    /// Hepatit B Yapıldı
    /// </summary>
        public bool? HepatitisB
        {
            get { return (bool?)this["HEPATITISB"]; }
            set { this["HEPATITISB"] = value; }
        }

    /// <summary>
    /// Hepatit İmmunoglobülin Yapıldı
    /// </summary>
        public bool? HepatitisImmunoglobulin
        {
            get { return (bool?)this["HEPATITISIMMUNOGLOBULIN"]; }
            set { this["HEPATITISIMMUNOGLOBULIN"] = value; }
        }

    /// <summary>
    /// Anne Emzirme Danışmanlığı Aldı
    /// </summary>
        public bool? LactationInfo
        {
            get { return (bool?)this["LACTATIONINFO"]; }
            set { this["LACTATIONINFO"] = value; }
        }

    /// <summary>
    /// Anne Sütü Almayan Bebek
    /// </summary>
        public bool? WithoutBreastMilk
        {
            get { return (bool?)this["WITHOUTBREASTMILK"]; }
            set { this["WITHOUTBREASTMILK"] = value; }
        }

    /// <summary>
    /// İlk Yarım Saatte Emdi
    /// </summary>
        public bool? SuckledTheFirstHalfHour
        {
            get { return (bool?)this["SUCKLEDTHEFIRSTHALFHOUR"]; }
            set { this["SUCKLEDTHEFIRSTHALFHOUR"] = value; }
        }

    /// <summary>
    /// K Vitamini Uygulandı
    /// </summary>
        public bool? VitaminKApplied
        {
            get { return (bool?)this["VITAMINKAPPLIED"]; }
            set { this["VITAMINKAPPLIED"] = value; }
        }

    /// <summary>
    /// Anormal Doğan Bebek
    /// </summary>
        public bool? AbnormalBaby
        {
            get { return (bool?)this["ABNORMALBABY"]; }
            set { this["ABNORMALBABY"] = value; }
        }

    /// <summary>
    /// Prematüre Doğan Bebek
    /// </summary>
        public bool? PrematureBaby
        {
            get { return (bool?)this["PREMATUREBABY"]; }
            set { this["PREMATUREBABY"] = value; }
        }

    /// <summary>
    /// Asfiktik Doğan Bebek
    /// </summary>
        public bool? Asphyxia
        {
            get { return (bool?)this["ASPHYXIA"]; }
            set { this["ASPHYXIA"] = value; }
        }

    /// <summary>
    /// Hipotiroidi İçin Kan Alındı
    /// </summary>
        public bool? HypothyroidisBlood
        {
            get { return (bool?)this["HYPOTHYROIDISBLOOD"]; }
            set { this["HYPOTHYROIDISBLOOD"] = value; }
        }

    /// <summary>
    /// İşitme Taraması Yapıldı
    /// </summary>
        public bool? HearingScreening
        {
            get { return (bool?)this["HEARINGSCREENING"]; }
            set { this["HEARINGSCREENING"] = value; }
        }

    /// <summary>
    /// Görme Taraması Yapıldı
    /// </summary>
        public bool? VisionScreening
        {
            get { return (bool?)this["VISIONSCREENING"]; }
            set { this["VISIONSCREENING"] = value; }
        }

    /// <summary>
    /// D Vitamini Takviyesi
    /// </summary>
        public bool? VitaminDSupplement
        {
            get { return (bool?)this["VITAMINDSUPPLEMENT"]; }
            set { this["VITAMINDSUPPLEMENT"] = value; }
        }

    /// <summary>
    /// Demir Takviyesi
    /// </summary>
        public bool? IronSupplement
        {
            get { return (bool?)this["IRONSUPPLEMENT"]; }
            set { this["IRONSUPPLEMENT"] = value; }
        }

    /// <summary>
    /// Testis Muayenesi
    /// </summary>
        public bool? TesticleExamination
        {
            get { return (bool?)this["TESTICLEEXAMINATION"]; }
            set { this["TESTICLEEXAMINATION"] = value; }
        }

    /// <summary>
    /// Fontanel Muayenesi
    /// </summary>
        public bool? FontanelExamination
        {
            get { return (bool?)this["FONTANELEXAMINATION"]; }
            set { this["FONTANELEXAMINATION"] = value; }
        }

    /// <summary>
    /// LCD ekranda gösterme durumu
    /// </summary>
        public bool? ShowLCD
        {
            get { return (bool?)this["SHOWLCD"]; }
            set { this["SHOWLCD"] = value; }
        }

    /// <summary>
    /// Bebeğin Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Ölüm Tarihi ve Saati
    /// </summary>
        public DateTime? DatetimeOfDeath
        {
            get { return (DateTime?)this["DATETIMEOFDEATH"]; }
            set { this["DATETIMEOFDEATH"] = value; }
        }

    /// <summary>
    /// Yaşam Durumu
    /// </summary>
        public BirthReportBabyStatus? BabyStatus
        {
            get { return (BirthReportBabyStatus?)(int?)this["BABYSTATUS"]; }
            set { this["BABYSTATUS"] = value; }
        }

    /// <summary>
    /// Doğum Tarihi ve Saati
    /// </summary>
        public DateTime? BirthDateTime
        {
            get { return (DateTime?)this["BIRTHDATETIME"]; }
            set { this["BIRTHDATETIME"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public int? Weigth
        {
            get { return (int?)this["WEIGTH"]; }
            set { this["WEIGTH"] = value; }
        }

    /// <summary>
    /// Baş Çevresi
    /// </summary>
        public int? HeadCircumference
        {
            get { return (int?)this["HEADCIRCUMFERENCE"]; }
            set { this["HEADCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Gebelik Süresi Haftası
    /// </summary>
        public int? PregnancyWeek
        {
            get { return (int?)this["PREGNANCYWEEK"]; }
            set { this["PREGNANCYWEEK"] = value; }
        }

    /// <summary>
    /// Geliş Şekli
    /// </summary>
        public PresentationTypeEnum? PresentationType
        {
            get { return (PresentationTypeEnum?)(int?)this["PRESENTATIONTYPE"]; }
            set { this["PRESENTATIONTYPE"] = value; }
        }

    /// <summary>
    /// Anestezi
    /// </summary>
        public AnesthesiaTechniqueEnum? AnesthesiaTechnique
        {
            get { return (AnesthesiaTechniqueEnum?)(int?)this["ANESTHESIATECHNIQUE"]; }
            set { this["ANESTHESIATECHNIQUE"] = value; }
        }

    /// <summary>
    /// Plasenta Ayrılış Şekli
    /// </summary>
        public PlacentaDecollementTypeEnum? PlacentaDecollementType
        {
            get { return (PlacentaDecollementTypeEnum?)(int?)this["PLACENTADECOLLEMENTTYPE"]; }
            set { this["PLACENTADECOLLEMENTTYPE"] = value; }
        }

    /// <summary>
    /// Fetal Anomaliler
    /// </summary>
        public FetalAnomaliesTypeEnum? FetalAnomalies
        {
            get { return (FetalAnomaliesTypeEnum?)(int?)this["FETALANOMALIES"]; }
            set { this["FETALANOMALIES"] = value; }
        }

        public object Photo
        {
            get { return (object)this["PHOTO"]; }
            set { this["PHOTO"] = value; }
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SKRSCinsiyet Gender
        {
            get { return (SKRSCinsiyet)((ITTObject)this).GetParent("GENDER"); }
            set { this["GENDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Apgar Apgar1
        {
            get { return (Apgar)((ITTObject)this).GetParent("APGAR1"); }
            set { this["APGAR1"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Apgar Apgar5
        {
            get { return (Apgar)((ITTObject)this).GetParent("APGAR5"); }
            set { this["APGAR5"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bebek Arşiv Bilgileri
    /// </summary>
        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Bebeğin Annesinin Kim Olduğu Bilgisi
    /// </summary>
        public Patient MotherPatient
        {
            get { return (Patient)((ITTObject)this).GetParent("MOTHERPATIENT"); }
            set { this["MOTHERPATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// bebek bilgisinin hangi doğuma ait olduğu bilgisi
    /// </summary>
        public RegularObstetric RegularObstetric
        {
            get { return (RegularObstetric)((ITTObject)this).GetParent("REGULAROBSTETRIC"); }
            set { this["REGULAROBSTETRIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ölüm Nedeni
    /// </summary>
        public SKRSBebekOlumNedenleri CauseOfDeath
        {
            get { return (SKRSBebekOlumNedenleri)((ITTObject)this).GetParent("CAUSEOFDEATH"); }
            set { this["CAUSEOFDEATH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğumun Gerçekleştiği Yer
    /// </summary>
        public SKRSDogumunGerceklestigiYer BirthLocation
        {
            get { return (SKRSDogumunGerceklestigiYer)((ITTObject)this).GetParent("BIRTHLOCATION"); }
            set { this["BIRTHLOCATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum Sırası
    /// </summary>
        public SKRSDogumSirasi BirthOrder
        {
            get { return (SKRSDogumSirasi)((ITTObject)this).GetParent("BIRTHORDER"); }
            set { this["BIRTHORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum Yöntemi
    /// </summary>
        public SKRSDogumYontemi BirthType
        {
            get { return (SKRSDogumYontemi)((ITTObject)this).GetParent("BIRTHTYPE"); }
            set { this["BIRTHTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BabyObstetricInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BabyObstetricInformation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BabyObstetricInformation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BabyObstetricInformation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BabyObstetricInformation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BABYOBSTETRICINFORMATION", dataRow) { }
        protected BabyObstetricInformation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BABYOBSTETRICINFORMATION", dataRow, isImported) { }
        public BabyObstetricInformation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BabyObstetricInformation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BabyObstetricInformation() : base() { }

    }
}