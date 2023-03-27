
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SmearScreening")] 

    public  partial class SmearScreening : KetemWoman
    {
        public class SmearScreeningList : TTObjectCollection<SmearScreening> { }
                    
        public class ChildSmearScreeningCollection : TTObject.TTChildObjectCollection<SmearScreening>
        {
            public ChildSmearScreeningCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSmearScreeningCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSmearScreeningBySubepisodeID_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["MENSTRUALCYCLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["MENARCHEAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["MENOPAUSEAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["LASTMENSTRUATIONDATE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["FIRSTMARRIAGEAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["FIRSTGESTATIONALAGE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["GESTATIONALNUMBER"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["LIVEBIRTHNUMBER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? PainDuringIntercourse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAINDURINGINTERCOURSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["PAINDURINGINTERCOURSE"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? BleedingAfterIntercourse
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLEEDINGAFTERINTERCOURSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["BLEEDINGAFTERINTERCOURSE"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string PainDuringIntercourseText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAINDURINGINTERCOURSETEXT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["PAINDURINGINTERCOURSETEXT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? FamilyCancerHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYCANCERHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["FAMILYCANCERHISTORY"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? PersonalCancerHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONALCANCERHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["PERSONALCANCERHISTORY"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? GynecologicCancerHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GYNECOLOGICCANCERHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["GYNECOLOGICCANCERHISTORY"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string FamilyCancerHistoryDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYCANCERHISTORYDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["FAMILYCANCERHISTORYDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PersonalCancerHistoryDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERSONALCANCERHISTORYDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["PERSONALCANCERHISTORYDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string GynecologicCancerHistoryDesc
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GYNECOLOGICCANCERHISTORYDESC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["GYNECOLOGICCANCERHISTORYDESC"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SmearResultEnum? SmearResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SMEARRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["SMEARRESULT"].DataType;
                    return (SmearResultEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public HPVEnum? HPVResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HPVRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["HPVRESULT"].DataType;
                    return (HPVEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSmearScreeningBySubepisodeID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSmearScreeningBySubepisodeID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSmearScreeningBySubepisodeID_Class() : base() { }
        }

        public static BindingList<SmearScreening.GetSmearScreeningBySubepisodeID_Class> GetSmearScreeningBySubepisodeID(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].QueryDefs["GetSmearScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<SmearScreening.GetSmearScreeningBySubepisodeID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<SmearScreening.GetSmearScreeningBySubepisodeID_Class> GetSmearScreeningBySubepisodeID(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SMEARSCREENING"].QueryDefs["GetSmearScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<SmearScreening.GetSmearScreeningBySubepisodeID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Cinsel İlişkide Ağrı
    /// </summary>
        public VarYokGarantiEnum? PainDuringIntercourse
        {
            get { return (VarYokGarantiEnum?)(int?)this["PAINDURINGINTERCOURSE"]; }
            set { this["PAINDURINGINTERCOURSE"] = value; }
        }

    /// <summary>
    /// Cinsel İlişki Sonrası Kanama
    /// </summary>
        public VarYokGarantiEnum? BleedingAfterIntercourse
        {
            get { return (VarYokGarantiEnum?)(int?)this["BLEEDINGAFTERINTERCOURSE"]; }
            set { this["BLEEDINGAFTERINTERCOURSE"] = value; }
        }

        public string PainDuringIntercourseText
        {
            get { return (string)this["PAINDURINGINTERCOURSETEXT"]; }
            set { this["PAINDURINGINTERCOURSETEXT"] = value; }
        }

    /// <summary>
    /// Ailede Kanser Öyküsü
    /// </summary>
        public VarYokGarantiEnum? FamilyCancerHistory
        {
            get { return (VarYokGarantiEnum?)(int?)this["FAMILYCANCERHISTORY"]; }
            set { this["FAMILYCANCERHISTORY"] = value; }
        }

    /// <summary>
    /// Kişisel Kanser Öyküsü
    /// </summary>
        public VarYokGarantiEnum? PersonalCancerHistory
        {
            get { return (VarYokGarantiEnum?)(int?)this["PERSONALCANCERHISTORY"]; }
            set { this["PERSONALCANCERHISTORY"] = value; }
        }

    /// <summary>
    /// Jinekolojik Kanser Öyküsü
    /// </summary>
        public VarYokGarantiEnum? GynecologicCancerHistory
        {
            get { return (VarYokGarantiEnum?)(int?)this["GYNECOLOGICCANCERHISTORY"]; }
            set { this["GYNECOLOGICCANCERHISTORY"] = value; }
        }

        public string FamilyCancerHistoryDesc
        {
            get { return (string)this["FAMILYCANCERHISTORYDESC"]; }
            set { this["FAMILYCANCERHISTORYDESC"] = value; }
        }

        public string PersonalCancerHistoryDesc
        {
            get { return (string)this["PERSONALCANCERHISTORYDESC"]; }
            set { this["PERSONALCANCERHISTORYDESC"] = value; }
        }

        public string GynecologicCancerHistoryDesc
        {
            get { return (string)this["GYNECOLOGICCANCERHISTORYDESC"]; }
            set { this["GYNECOLOGICCANCERHISTORYDESC"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public SmearResultEnum? SmearResult
        {
            get { return (SmearResultEnum?)(int?)this["SMEARRESULT"]; }
            set { this["SMEARRESULT"] = value; }
        }

    /// <summary>
    /// HPV
    /// </summary>
        public HPVEnum? HPVResult
        {
            get { return (HPVEnum?)(int?)this["HPVRESULT"]; }
            set { this["HPVRESULT"] = value; }
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

        protected SmearScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SmearScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SmearScreening(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SmearScreening(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SmearScreening(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SMEARSCREENING", dataRow) { }
        protected SmearScreening(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SMEARSCREENING", dataRow, isImported) { }
        public SmearScreening(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SmearScreening(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SmearScreening() : base() { }

    }
}