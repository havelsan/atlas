
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingBodilyFluidIntakeOutput")] 

    public  partial class NursingBodilyFluidIntakeOutput : BaseNursingDataEntry
    {
        public class NursingBodilyFluidIntakeOutputList : TTObjectCollection<NursingBodilyFluidIntakeOutput> { }
                    
        public class ChildNursingBodilyFluidIntakeOutputCollection : TTObject.TTChildObjectCollection<NursingBodilyFluidIntakeOutput>
        {
            public ChildNursingBodilyFluidIntakeOutputCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingBodilyFluidIntakeOutputCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFluidIntakeOutputGrid_Class : TTReportNqlObject 
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

            public DateTime? ApplicationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? EntryDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENTRYDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["ENTRYDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Note
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["NOTE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? OralIntake
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORALINTAKE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["ORALINTAKE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? NasogastricTube
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NASOGASTRICTUBE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["NASOGASTRICTUBE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? VenousFluid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VENOUSFLUID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["VENOUSFLUID"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Medicine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDICINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["MEDICINE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? SuppliedBlood
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIEDBLOOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["SUPPLIEDBLOOD"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Irrigation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IRRIGATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["IRRIGATION"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MilkType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILKTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["MILKTYPE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MilkAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILKAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["MILKAMOUNT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Sludge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SLUDGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["SLUDGE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? PAC
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["PAC"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? OtherFluidIntake
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERFLUIDINTAKE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["OTHERFLUIDINTAKE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string FluidIntakeFurtherExplanation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FLUIDINTAKEFURTHEREXPLANATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["FLUIDINTAKEFURTHEREXPLANATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string FluidOutputFurtherExplanation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FLUIDOUTPUTFURTHEREXPLANATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["FLUIDOUTPUTFURTHEREXPLANATION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? Urine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["URINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["URINE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Aspiration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ASPIRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["ASPIRATION"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Vomit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VOMIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["VOMIT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Drainage1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRAINAGE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["DRAINAGE1"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Drainage2
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRAINAGE2"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["DRAINAGE2"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Drainage3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRAINAGE3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["DRAINAGE3"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Drainage4
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRAINAGE4"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["DRAINAGE4"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? Stool
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOOL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["STOOL"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? BloodLoss
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BLOODLOSS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["BLOODLOSS"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? OtherFluidOutput
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERFLUIDOUTPUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["OTHERFLUIDOUTPUT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetFluidIntakeOutputGrid_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFluidIntakeOutputGrid_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFluidIntakeOutputGrid_Class() : base() { }
        }

        [Serializable] 

        public partial class GetApplicationDatesForNDaysInfo_Class : TTReportNqlObject 
        {
            public DateTime? ApplicationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["APPLICATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetApplicationDatesForNDaysInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetApplicationDatesForNDaysInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetApplicationDatesForNDaysInfo_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<NursingBodilyFluidIntakeOutput.GetFluidIntakeOutputGrid_Class> GetFluidIntakeOutputGrid(Guid FluidAnalysisID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].QueryDefs["GetFluidIntakeOutputGrid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FLUIDANALYSISID", FluidAnalysisID);

            return TTReportNqlObject.QueryObjects<NursingBodilyFluidIntakeOutput.GetFluidIntakeOutputGrid_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingBodilyFluidIntakeOutput.GetFluidIntakeOutputGrid_Class> GetFluidIntakeOutputGrid(TTObjectContext objectContext, Guid FluidAnalysisID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].QueryDefs["GetFluidIntakeOutputGrid"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FLUIDANALYSISID", FluidAnalysisID);

            return TTReportNqlObject.QueryObjects<NursingBodilyFluidIntakeOutput.GetFluidIntakeOutputGrid_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingBodilyFluidIntakeOutput> GetFluidIntakeOutputGrids(TTObjectContext objectContext, Guid FluidAnalysisID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].QueryDefs["GetFluidIntakeOutputGrids"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FLUIDANALYSISID", FluidAnalysisID);

            return ((ITTQuery)objectContext).QueryObjects<NursingBodilyFluidIntakeOutput>(queryDef, paramList);
        }

        public static BindingList<NursingBodilyFluidIntakeOutput> GetInfoByStartDateEndDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, string NURSINGAPPLICATION)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].QueryDefs["GetInfoByStartDateEndDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);

            return ((ITTQuery)objectContext).QueryObjects<NursingBodilyFluidIntakeOutput>(queryDef, paramList);
        }

        public static BindingList<NursingBodilyFluidIntakeOutput.GetApplicationDatesForNDaysInfo_Class> GetApplicationDatesForNDaysInfo(DateTime LASTDATE, string NURSINGAPPLICATION, int NDays, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].QueryDefs["GetApplicationDatesForNDaysInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTDATE", LASTDATE);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("NDAYS", NDays);

            return TTReportNqlObject.QueryObjects<NursingBodilyFluidIntakeOutput.GetApplicationDatesForNDaysInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingBodilyFluidIntakeOutput.GetApplicationDatesForNDaysInfo_Class> GetApplicationDatesForNDaysInfo(TTObjectContext objectContext, DateTime LASTDATE, string NURSINGAPPLICATION, int NDays, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGBODILYFLUIDINTAKEOUTPUT"].QueryDefs["GetApplicationDatesForNDaysInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("LASTDATE", LASTDATE);
            paramList.Add("NURSINGAPPLICATION", NURSINGAPPLICATION);
            paramList.Add("NDAYS", NDays);

            return TTReportNqlObject.QueryObjects<NursingBodilyFluidIntakeOutput.GetApplicationDatesForNDaysInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Oral
    /// </summary>
        public double? OralIntake
        {
            get { return (double?)this["ORALINTAKE"]; }
            set { this["ORALINTAKE"] = value; }
        }

    /// <summary>
    /// Nasogastrik Sonda
    /// </summary>
        public double? NasogastricTube
        {
            get { return (double?)this["NASOGASTRICTUBE"]; }
            set { this["NASOGASTRICTUBE"] = value; }
        }

    /// <summary>
    /// Damar İçi Sıvılar
    /// </summary>
        public double? VenousFluid
        {
            get { return (double?)this["VENOUSFLUID"]; }
            set { this["VENOUSFLUID"] = value; }
        }

    /// <summary>
    /// İlaçlar
    /// </summary>
        public double? Medicine
        {
            get { return (double?)this["MEDICINE"]; }
            set { this["MEDICINE"] = value; }
        }

    /// <summary>
    /// Verilen Kan
    /// </summary>
        public double? SuppliedBlood
        {
            get { return (double?)this["SUPPLIEDBLOOD"]; }
            set { this["SUPPLIEDBLOOD"] = value; }
        }

    /// <summary>
    /// İrigasyon
    /// </summary>
        public double? Irrigation
        {
            get { return (double?)this["IRRIGATION"]; }
            set { this["IRRIGATION"] = value; }
        }

    /// <summary>
    /// Süt Tipi
    /// </summary>
        public double? MilkType
        {
            get { return (double?)this["MILKTYPE"]; }
            set { this["MILKTYPE"] = value; }
        }

    /// <summary>
    /// Süt Miktarı
    /// </summary>
        public double? MilkAmount
        {
            get { return (double?)this["MILKAMOUNT"]; }
            set { this["MILKAMOUNT"] = value; }
        }

    /// <summary>
    /// Tortu
    /// </summary>
        public double? Sludge
        {
            get { return (double?)this["SLUDGE"]; }
            set { this["SLUDGE"] = value; }
        }

    /// <summary>
    /// PAC
    /// </summary>
        public double? PAC
        {
            get { return (double?)this["PAC"]; }
            set { this["PAC"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public double? OtherFluidIntake
        {
            get { return (double?)this["OTHERFLUIDINTAKE"]; }
            set { this["OTHERFLUIDINTAKE"] = value; }
        }

    /// <summary>
    /// Diğer Açıklamalar
    /// </summary>
        public string FluidIntakeFurtherExplanation
        {
            get { return (string)this["FLUIDINTAKEFURTHEREXPLANATION"]; }
            set { this["FLUIDINTAKEFURTHEREXPLANATION"] = value; }
        }

    /// <summary>
    /// Diğer Açıklamalar
    /// </summary>
        public string FluidOutputFurtherExplanation
        {
            get { return (string)this["FLUIDOUTPUTFURTHEREXPLANATION"]; }
            set { this["FLUIDOUTPUTFURTHEREXPLANATION"] = value; }
        }

    /// <summary>
    /// İdrar
    /// </summary>
        public double? Urine
        {
            get { return (double?)this["URINE"]; }
            set { this["URINE"] = value; }
        }

    /// <summary>
    /// Aspirasyon
    /// </summary>
        public double? Aspiration
        {
            get { return (double?)this["ASPIRATION"]; }
            set { this["ASPIRATION"] = value; }
        }

    /// <summary>
    /// Kusma
    /// </summary>
        public double? Vomit
        {
            get { return (double?)this["VOMIT"]; }
            set { this["VOMIT"] = value; }
        }

    /// <summary>
    /// Drenaj (1)
    /// </summary>
        public double? Drainage1
        {
            get { return (double?)this["DRAINAGE1"]; }
            set { this["DRAINAGE1"] = value; }
        }

    /// <summary>
    /// Drenaj (2)
    /// </summary>
        public double? Drainage2
        {
            get { return (double?)this["DRAINAGE2"]; }
            set { this["DRAINAGE2"] = value; }
        }

    /// <summary>
    /// Drenaj (3)
    /// </summary>
        public double? Drainage3
        {
            get { return (double?)this["DRAINAGE3"]; }
            set { this["DRAINAGE3"] = value; }
        }

    /// <summary>
    /// Drenaj (4)
    /// </summary>
        public double? Drainage4
        {
            get { return (double?)this["DRAINAGE4"]; }
            set { this["DRAINAGE4"] = value; }
        }

    /// <summary>
    /// Dışkı
    /// </summary>
        public double? Stool
        {
            get { return (double?)this["STOOL"]; }
            set { this["STOOL"] = value; }
        }

    /// <summary>
    /// Kaybedilen Kan
    /// </summary>
        public double? BloodLoss
        {
            get { return (double?)this["BLOODLOSS"]; }
            set { this["BLOODLOSS"] = value; }
        }

    /// <summary>
    /// Diğer
    /// </summary>
        public double? OtherFluidOutput
        {
            get { return (double?)this["OTHERFLUIDOUTPUT"]; }
            set { this["OTHERFLUIDOUTPUT"] = value; }
        }

        public NursingBodyFluidAnalysis NursingBodyFluidAnalysis
        {
            get { return (NursingBodyFluidAnalysis)((ITTObject)this).GetParent("NURSINGBODYFLUIDANALYSIS"); }
            set { this["NURSINGBODYFLUIDANALYSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected NursingBodilyFluidIntakeOutput(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingBodilyFluidIntakeOutput(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingBodilyFluidIntakeOutput(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingBodilyFluidIntakeOutput(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingBodilyFluidIntakeOutput(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGBODILYFLUIDINTAKEOUTPUT", dataRow) { }
        protected NursingBodilyFluidIntakeOutput(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGBODILYFLUIDINTAKEOUTPUT", dataRow, isImported) { }
        public NursingBodilyFluidIntakeOutput(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingBodilyFluidIntakeOutput(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingBodilyFluidIntakeOutput() : base() { }

    }
}