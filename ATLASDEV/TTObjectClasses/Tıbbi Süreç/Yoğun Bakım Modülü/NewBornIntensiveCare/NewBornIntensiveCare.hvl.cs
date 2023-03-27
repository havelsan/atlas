
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NewBornIntensiveCare")] 

    public  partial class NewBornIntensiveCare : TTObject
    {
        public class NewBornIntensiveCareList : TTObjectCollection<NewBornIntensiveCare> { }
                    
        public class ChildNewBornIntensiveCareCollection : TTObject.TTChildObjectCollection<NewBornIntensiveCare>
        {
            public ChildNewBornIntensiveCareCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNewBornIntensiveCareCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNewBornIntensiveCare_Class : TTReportNqlObject 
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

            public int? HeadCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["HEADCIRCUMFERENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Length
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["LENGTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? GestationalWeek
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GESTATIONALWEEK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["GESTATIONALWEEK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? GestationalDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GESTATIONALDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["GESTATIONALDAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string CorrectedAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CORRECTEDAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["CORRECTEDAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? IntensiveCareDay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTENSIVECAREDAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["INTENSIVECAREDAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ChronicalAge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHRONICALAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["CHRONICALAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ChestCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHESTCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["CHESTCIRCUMFERENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? BirthWeight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHWEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["BIRTHWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? BirthTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].AllPropertyDefs["BIRTHTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetNewBornIntensiveCare_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNewBornIntensiveCare_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNewBornIntensiveCare_Class() : base() { }
        }

        public static BindingList<NewBornIntensiveCare.GetNewBornIntensiveCare_Class> GetNewBornIntensiveCare(Guid INTENSIVECARESPECIALITYOBJ, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].QueryDefs["GetNewBornIntensiveCare"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTENSIVECARESPECIALITYOBJ", INTENSIVECARESPECIALITYOBJ);

            return TTReportNqlObject.QueryObjects<NewBornIntensiveCare.GetNewBornIntensiveCare_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NewBornIntensiveCare.GetNewBornIntensiveCare_Class> GetNewBornIntensiveCare(TTObjectContext objectContext, Guid INTENSIVECARESPECIALITYOBJ, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NEWBORNINTENSIVECARE"].QueryDefs["GetNewBornIntensiveCare"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("INTENSIVECARESPECIALITYOBJ", INTENSIVECARESPECIALITYOBJ);

            return TTReportNqlObject.QueryObjects<NewBornIntensiveCare.GetNewBornIntensiveCare_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Baş Çevresi (cm)
    /// </summary>
        public int? HeadCircumference
        {
            get { return (int?)this["HEADCIRCUMFERENCE"]; }
            set { this["HEADCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Boy (cm)
    /// </summary>
        public int? Length
        {
            get { return (int?)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

    /// <summary>
    /// Gestasyon Haftası
    /// </summary>
        public int? GestationalWeek
        {
            get { return (int?)this["GESTATIONALWEEK"]; }
            set { this["GESTATIONALWEEK"] = value; }
        }

    /// <summary>
    /// Gestasyon Günü
    /// </summary>
        public int? GestationalDay
        {
            get { return (int?)this["GESTATIONALDAY"]; }
            set { this["GESTATIONALDAY"] = value; }
        }

    /// <summary>
    /// Düzeltilmiş Yaş
    /// </summary>
        public string CorrectedAge
        {
            get { return (string)this["CORRECTEDAGE"]; }
            set { this["CORRECTEDAGE"] = value; }
        }

    /// <summary>
    /// Yoğun Bakım Günü
    /// </summary>
        public int? IntensiveCareDay
        {
            get { return (int?)this["INTENSIVECAREDAY"]; }
            set { this["INTENSIVECAREDAY"] = value; }
        }

    /// <summary>
    /// Kronolojik Yaş
    /// </summary>
        public string ChronicalAge
        {
            get { return (string)this["CHRONICALAGE"]; }
            set { this["CHRONICALAGE"] = value; }
        }

    /// <summary>
    /// Göğüs Çevresi (cm)
    /// </summary>
        public int? ChestCircumference
        {
            get { return (int?)this["CHESTCIRCUMFERENCE"]; }
            set { this["CHESTCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Doğum Ağırlığı (gr)
    /// </summary>
        public int? BirthWeight
        {
            get { return (int?)this["BIRTHWEIGHT"]; }
            set { this["BIRTHWEIGHT"] = value; }
        }

    /// <summary>
    /// Doğum Saati
    /// </summary>
        public DateTime? BirthTime
        {
            get { return (DateTime?)this["BIRTHTIME"]; }
            set { this["BIRTHTIME"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public IntensiveCareSpecialityObj IntensiveCareSpecialityObj
        {
            get { return (IntensiveCareSpecialityObj)((ITTObject)this).GetParent("INTENSIVECARESPECIALITYOBJ"); }
            set { this["INTENSIVECARESPECIALITYOBJ"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NewBornIntensiveCare(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NewBornIntensiveCare(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NewBornIntensiveCare(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NewBornIntensiveCare(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NewBornIntensiveCare(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NEWBORNINTENSIVECARE", dataRow) { }
        protected NewBornIntensiveCare(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NEWBORNINTENSIVECARE", dataRow, isImported) { }
        public NewBornIntensiveCare(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NewBornIntensiveCare(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NewBornIntensiveCare() : base() { }

    }
}