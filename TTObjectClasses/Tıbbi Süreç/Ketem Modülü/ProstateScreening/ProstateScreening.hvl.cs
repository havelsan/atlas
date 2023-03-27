
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProstateScreening")] 

    public  partial class ProstateScreening : Ketem
    {
        public class ProstateScreeningList : TTObjectCollection<ProstateScreening> { }
                    
        public class ChildProstateScreeningCollection : TTObject.TTChildObjectCollection<ProstateScreening>
        {
            public ChildProstateScreeningCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProstateScreeningCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProstateScreeningBySubepisodeID_Class : TTReportNqlObject 
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

            public string ChronicDiseases
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHRONICDISEASES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["CHRONICDISEASES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? FrequentUrination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREQUENTURINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["FREQUENTURINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PainfulUrination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAINFULURINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["PAINFULURINATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public VarYokGarantiEnum? FamilyCancerHistory
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAMILYCANCERHISTORY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["FAMILYCANCERHISTORY"].DataType;
                    return (VarYokGarantiEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string UsedMedicines
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USEDMEDICINES"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["USEDMEDICINES"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? ReductionInUrineFlow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REDUCTIONINURINEFLOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["REDUCTIONINURINEFLOW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string PSA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PSA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["PSA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Examination
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXAMINATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["EXAMINATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TotalPSA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPSA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["TOTALPSA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FreePSA
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FREEPSA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["FREEPSA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ScreeningResult
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SCREENINGRESULT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["SCREENINGRESULT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? RetentionOfUrine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RETENTIONOFURINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].AllPropertyDefs["RETENTIONOFURINE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetProstateScreeningBySubepisodeID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProstateScreeningBySubepisodeID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProstateScreeningBySubepisodeID_Class() : base() { }
        }

        public static BindingList<ProstateScreening.GetProstateScreeningBySubepisodeID_Class> GetProstateScreeningBySubepisodeID(Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].QueryDefs["GetProstateScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<ProstateScreening.GetProstateScreeningBySubepisodeID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ProstateScreening.GetProstateScreeningBySubepisodeID_Class> GetProstateScreeningBySubepisodeID(TTObjectContext objectContext, Guid SUBEPISODEID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROSTATESCREENING"].QueryDefs["GetProstateScreeningBySubepisodeID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODEID", SUBEPISODEID);

            return TTReportNqlObject.QueryObjects<ProstateScreening.GetProstateScreeningBySubepisodeID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Kronik Hastalıklar
    /// </summary>
        public string ChronicDiseases
        {
            get { return (string)this["CHRONICDISEASES"]; }
            set { this["CHRONICDISEASES"] = value; }
        }

    /// <summary>
    /// Sık İdrara Çıkma
    /// </summary>
        public bool? FrequentUrination
        {
            get { return (bool?)this["FREQUENTURINATION"]; }
            set { this["FREQUENTURINATION"] = value; }
        }

    /// <summary>
    /// Kesik, Ağrılı İdrar Yapma
    /// </summary>
        public bool? PainfulUrination
        {
            get { return (bool?)this["PAINFULURINATION"]; }
            set { this["PAINFULURINATION"] = value; }
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
    /// Sürekli Kullandığı İlaçlar
    /// </summary>
        public string UsedMedicines
        {
            get { return (string)this["USEDMEDICINES"]; }
            set { this["USEDMEDICINES"] = value; }
        }

    /// <summary>
    /// İdrar Akışında Azamla
    /// </summary>
        public bool? ReductionInUrineFlow
        {
            get { return (bool?)this["REDUCTIONINURINEFLOW"]; }
            set { this["REDUCTIONINURINEFLOW"] = value; }
        }

    /// <summary>
    /// PSA
    /// </summary>
        public string PSA
        {
            get { return (string)this["PSA"]; }
            set { this["PSA"] = value; }
        }

    /// <summary>
    /// Muayene
    /// </summary>
        public string Examination
        {
            get { return (string)this["EXAMINATION"]; }
            set { this["EXAMINATION"] = value; }
        }

    /// <summary>
    /// Total PSA
    /// </summary>
        public string TotalPSA
        {
            get { return (string)this["TOTALPSA"]; }
            set { this["TOTALPSA"] = value; }
        }

    /// <summary>
    /// Serbest PSA
    /// </summary>
        public string FreePSA
        {
            get { return (string)this["FREEPSA"]; }
            set { this["FREEPSA"] = value; }
        }

    /// <summary>
    /// Tarama Sonu Muayene Bulguları
    /// </summary>
        public string ScreeningResult
        {
            get { return (string)this["SCREENINGRESULT"]; }
            set { this["SCREENINGRESULT"] = value; }
        }

    /// <summary>
    /// İdrarı Tam Boşaltamama Hissi
    /// </summary>
        public bool? RetentionOfUrine
        {
            get { return (bool?)this["RETENTIONOFURINE"]; }
            set { this["RETENTIONOFURINE"] = value; }
        }

        public AnamnesisInfo AnamnesisInfo
        {
            get { return (AnamnesisInfo)((ITTObject)this).GetParent("ANAMNESISINFO"); }
            set { this["ANAMNESISINFO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ProstateScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProstateScreening(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProstateScreening(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProstateScreening(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProstateScreening(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROSTATESCREENING", dataRow) { }
        protected ProstateScreening(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROSTATESCREENING", dataRow, isImported) { }
        public ProstateScreening(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProstateScreening(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProstateScreening() : base() { }

    }
}