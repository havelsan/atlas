
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="StoneBreakUpProcedure")] 

    /// <summary>
    /// Taş Kırma İşlemi
    /// </summary>
    public  partial class StoneBreakUpProcedure : BaseStoneBreakUpProcedure
    {
        public class StoneBreakUpProcedureList : TTObjectCollection<StoneBreakUpProcedure> { }
                    
        public class ChildStoneBreakUpProcedureCollection : TTObject.TTChildObjectCollection<StoneBreakUpProcedure>
        {
            public ChildStoneBreakUpProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildStoneBreakUpProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByEpisode_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string StoneDimension
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STONEDIMENSION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["STONEDIMENSION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ZoneOfStoneEnum? ZoneOfStone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ZONEOFSTONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["ZONEOFSTONE"].DataType;
                    return (ZoneOfStoneEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfProcedure
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFPROCEDURE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["NUMBEROFPROCEDURE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ProcedureDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["PROCEDUREDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public int? NumberOfStone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NUMBEROFSTONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].AllPropertyDefs["NUMBEROFSTONE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string PartOfStone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARTOFSTONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPARTOFSTONEDEFINITION"].AllPropertyDefs["PARTOFSTONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByEpisode_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<StoneBreakUpProcedure> GetFutureProcedureByZoneAndPart(TTObjectContext objectContext, ZoneOfStoneEnum ZONE, string PART, string PATIENT, DateTime REFDATE, string REFSTONEBREAKUPPROCEDURE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].QueryDefs["GetFutureProcedureByZoneAndPart"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ZONE", (int)ZONE);
            paramList.Add("PART", PART);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("REFDATE", REFDATE);
            paramList.Add("REFSTONEBREAKUPPROCEDURE", REFSTONEBREAKUPPROCEDURE);

            return ((ITTQuery)objectContext).QueryObjects<StoneBreakUpProcedure>(queryDef, paramList);
        }

        public static BindingList<StoneBreakUpProcedure> GetPastProcedureByZoneAndPart(TTObjectContext objectContext, ZoneOfStoneEnum ZONE, string PART, string PATIENT, DateTime REFDATE, string REFSTONEBREAKUPPROCEDURE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].QueryDefs["GetPastProcedureByZoneAndPart"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ZONE", (int)ZONE);
            paramList.Add("PART", PART);
            paramList.Add("PATIENT", PATIENT);
            paramList.Add("REFDATE", REFDATE);
            paramList.Add("REFSTONEBREAKUPPROCEDURE", REFSTONEBREAKUPPROCEDURE);

            return ((ITTQuery)objectContext).QueryObjects<StoneBreakUpProcedure>(queryDef, paramList);
        }

        public static BindingList<StoneBreakUpProcedure.GetByEpisode_Class> GetByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<StoneBreakUpProcedure.GetByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<StoneBreakUpProcedure.GetByEpisode_Class> GetByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STONEBREAKUPPROCEDURE"].QueryDefs["GetByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<StoneBreakUpProcedure.GetByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Taş Boyutu
    /// </summary>
        public string StoneDimension
        {
            get { return (string)this["STONEDIMENSION"]; }
            set { this["STONEDIMENSION"] = value; }
        }

    /// <summary>
    /// Taraf
    /// </summary>
        public ZoneOfStoneEnum? ZoneOfStone
        {
            get { return (ZoneOfStoneEnum?)(int?)this["ZONEOFSTONE"]; }
            set { this["ZONEOFSTONE"] = value; }
        }

    /// <summary>
    /// İşlem Sayısı
    /// </summary>
        public int? NumberOfProcedure
        {
            get { return (int?)this["NUMBEROFPROCEDURE"]; }
            set { this["NUMBEROFPROCEDURE"] = value; }
        }

    /// <summary>
    /// İşlem Zamanı
    /// </summary>
        public DateTime? ProcedureDate
        {
            get { return (DateTime?)this["PROCEDUREDATE"]; }
            set { this["PROCEDUREDATE"] = value; }
        }

    /// <summary>
    /// Taş Sayısı
    /// </summary>
        public int? NumberOfStone
        {
            get { return (int?)this["NUMBEROFSTONE"]; }
            set { this["NUMBEROFSTONE"] = value; }
        }

    /// <summary>
    /// Lokasyon
    /// </summary>
        public StoneBreakUpPartOfStoneDefinition PartOfStone
        {
            get { return (StoneBreakUpPartOfStoneDefinition)((ITTObject)this).GetParent("PARTOFSTONE"); }
            set { this["PARTOFSTONE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StoneBreakUpRequest StoneBreakUpRequest
        {
            get 
            {   
                if (EpisodeAction is StoneBreakUpRequest)
                    return (StoneBreakUpRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected StoneBreakUpProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected StoneBreakUpProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected StoneBreakUpProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected StoneBreakUpProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected StoneBreakUpProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STONEBREAKUPPROCEDURE", dataRow) { }
        protected StoneBreakUpProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STONEBREAKUPPROCEDURE", dataRow, isImported) { }
        public StoneBreakUpProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public StoneBreakUpProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public StoneBreakUpProcedure() : base() { }

    }
}