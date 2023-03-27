
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ParticipationFreeDrgGrid")] 

    public  partial class ParticipationFreeDrgGrid : TTObject
    {
        public class ParticipationFreeDrgGridList : TTObjectCollection<ParticipationFreeDrgGrid> { }
                    
        public class ChildParticipationFreeDrgGridCollection : TTObject.TTChildObjectCollection<ParticipationFreeDrgGrid>
        {
            public ChildParticipationFreeDrgGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildParticipationFreeDrgGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetParticipantFreeDrugRepRNQL_Class : TTReportNqlObject 
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

            public string DrugName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["DRUGNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PeriodUnitTypeEnum? PeriodUnitType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODUNITTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["PERIODUNITTYPE"].DataType;
                    return (PeriodUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? MedulaDose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["MEDULADOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public UsageDoseUnitTypeEnum? UsageDoseUnitType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGEDOSEUNITTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["USAGEDOSEUNITTYPE"].DataType;
                    return (UsageDoseUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["DOSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Count
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["COUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MedulaDoseInteger
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADOSEINTEGER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["MEDULADOSEINTEGER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MedulaUsageDose2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAUSAGEDOSE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["MEDULAUSAGEDOSE2"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string etkinMaddeAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string icerikMiktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICERIKMIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ICERIKMIKTARI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetParticipantFreeDrugRepRNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetParticipantFreeDrugRepRNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetParticipantFreeDrugRepRNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetParticipantFreeDrugRepRNQL_NotMedula_Class : TTReportNqlObject 
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

            public string DrugName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRUGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["DRUGNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PeriodUnitTypeEnum? PeriodUnitType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERIODUNITTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["PERIODUNITTYPE"].DataType;
                    return (PeriodUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public FrequencyEnum? Frequency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["FREQUENCY"].DataType;
                    return (FrequencyEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public double? MedulaDose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["MEDULADOSE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public UsageDoseUnitTypeEnum? UsageDoseUnitType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USAGEDOSEUNITTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["USAGEDOSEUNITTYPE"].DataType;
                    return (UsageDoseUnitTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Dose
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOSE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["DOSE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Count
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["COUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string MedulaDoseInteger
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULADOSEINTEGER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["MEDULADOSEINTEGER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? MedulaUsageDose2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAUSAGEDOSE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].AllPropertyDefs["MEDULAUSAGEDOSE2"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string etkinMaddeAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string icerikMiktari
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICERIKMIKTARI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ICERIKMIKTARI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetParticipantFreeDrugRepRNQL_NotMedula_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetParticipantFreeDrugRepRNQL_NotMedula_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetParticipantFreeDrugRepRNQL_NotMedula_Class() : base() { }
        }

        public static BindingList<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_Class> GetParticipantFreeDrugRepRNQL(Guid PARTICIPATNFREEDRUGREPORT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].QueryDefs["GetParticipantFreeDrugRepRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARTICIPATNFREEDRUGREPORT", PARTICIPATNFREEDRUGREPORT);

            return TTReportNqlObject.QueryObjects<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_Class> GetParticipantFreeDrugRepRNQL(TTObjectContext objectContext, Guid PARTICIPATNFREEDRUGREPORT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].QueryDefs["GetParticipantFreeDrugRepRNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARTICIPATNFREEDRUGREPORT", PARTICIPATNFREEDRUGREPORT);

            return TTReportNqlObject.QueryObjects<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula_Class> GetParticipantFreeDrugRepRNQL_NotMedula(Guid PARTICIPATNFREEDRUGREPORT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].QueryDefs["GetParticipantFreeDrugRepRNQL_NotMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARTICIPATNFREEDRUGREPORT", PARTICIPATNFREEDRUGREPORT);

            return TTReportNqlObject.QueryObjects<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula_Class> GetParticipantFreeDrugRepRNQL_NotMedula(TTObjectContext objectContext, Guid PARTICIPATNFREEDRUGREPORT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PARTICIPATIONFREEDRGGRID"].QueryDefs["GetParticipantFreeDrugRepRNQL_NotMedula"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARTICIPATNFREEDRUGREPORT", PARTICIPATNFREEDRUGREPORT);

            return TTReportNqlObject.QueryObjects<ParticipationFreeDrgGrid.GetParticipantFreeDrugRepRNQL_NotMedula_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İlaç İsmi
    /// </summary>
        public string DrugName
        {
            get { return (string)this["DRUGNAME"]; }
            set { this["DRUGNAME"] = value; }
        }

    /// <summary>
    /// Kullanım Periyot Birimi
    /// </summary>
        public PeriodUnitTypeEnum? PeriodUnitType
        {
            get { return (PeriodUnitTypeEnum?)(int?)this["PERIODUNITTYPE"]; }
            set { this["PERIODUNITTYPE"] = value; }
        }

    /// <summary>
    /// Kullanım Periyodu
    /// </summary>
        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

    /// <summary>
    /// Doz Aralığı
    /// </summary>
        public FrequencyEnum? Frequency
        {
            get { return (FrequencyEnum?)(int?)this["FREQUENCY"]; }
            set { this["FREQUENCY"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public double? MedulaDose
        {
            get { return (double?)this["MEDULADOSE"]; }
            set { this["MEDULADOSE"] = value; }
        }

    /// <summary>
    /// Kullanım Doz Birimi
    /// </summary>
        public UsageDoseUnitTypeEnum? UsageDoseUnitType
        {
            get { return (UsageDoseUnitTypeEnum?)(int?)this["USAGEDOSEUNITTYPE"]; }
            set { this["USAGEDOSEUNITTYPE"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public string Dose
        {
            get { return (string)this["DOSE"]; }
            set { this["DOSE"] = value; }
        }

    /// <summary>
    /// Adet
    /// </summary>
        public int? Count
        {
            get { return (int?)this["COUNT"]; }
            set { this["COUNT"] = value; }
        }

    /// <summary>
    /// Doz
    /// </summary>
        public string MedulaDoseInteger
        {
            get { return (string)this["MEDULADOSEINTEGER"]; }
            set { this["MEDULADOSEINTEGER"] = value; }
        }

    /// <summary>
    /// Medula Kullanım Doz 2
    /// </summary>
        public double? MedulaUsageDose2
        {
            get { return (double?)this["MEDULAUSAGEDOSE2"]; }
            set { this["MEDULAUSAGEDOSE2"] = value; }
        }

        public ParticipatnFreeDrugReport ParticipatnFreeDrugReport
        {
            get { return (ParticipatnFreeDrugReport)((ITTObject)this).GetParent("PARTICIPATNFREEDRUGREPORT"); }
            set { this["PARTICIPATNFREEDRUGREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EtkinMadde EtkinMadde
        {
            get { return (EtkinMadde)((ITTObject)this).GetParent("ETKINMADDE"); }
            set { this["ETKINMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ParticipationFreeDrgGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ParticipationFreeDrgGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ParticipationFreeDrgGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ParticipationFreeDrgGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ParticipationFreeDrgGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PARTICIPATIONFREEDRGGRID", dataRow) { }
        protected ParticipationFreeDrgGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PARTICIPATIONFREEDRGGRID", dataRow, isImported) { }
        public ParticipationFreeDrgGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ParticipationFreeDrgGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ParticipationFreeDrgGrid() : base() { }

    }
}