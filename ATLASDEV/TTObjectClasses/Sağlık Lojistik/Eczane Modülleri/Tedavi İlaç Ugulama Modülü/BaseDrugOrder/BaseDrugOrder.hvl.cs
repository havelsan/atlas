
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDrugOrder")] 

    public  partial class BaseDrugOrder : SubActionMaterial
    {
        public class BaseDrugOrderList : TTObjectCollection<BaseDrugOrder> { }
                    
        public class ChildBaseDrugOrderCollection : TTObject.TTChildObjectCollection<BaseDrugOrder>
        {
            public ChildBaseDrugOrderCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDrugOrderCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugPrescriptionTotalReportQuery_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Amount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["AMOUNT"]);
                }
            }

            public GetDrugPrescriptionTotalReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugPrescriptionTotalReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugPrescriptionTotalReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetDrugBasedOnDoctor_Class : TTReportNqlObject 
        {
            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public GetDrugBasedOnDoctor_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugBasedOnDoctor_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugBasedOnDoctor_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c4c3064c-5b92-4053-8e76-14723188541a"); } }
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("dd6fb9b4-ddc1-4816-a199-977e7742f624"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("4833943c-676e-470f-b651-98652395f71f"); } }
        }

        public static BindingList<BaseDrugOrder.GetDrugPrescriptionTotalReportQuery_Class> GetDrugPrescriptionTotalReportQuery(DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEDRUGORDER"].QueryDefs["GetDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseDrugOrder.GetDrugPrescriptionTotalReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseDrugOrder.GetDrugPrescriptionTotalReportQuery_Class> GetDrugPrescriptionTotalReportQuery(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEDRUGORDER"].QueryDefs["GetDrugPrescriptionTotalReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return TTReportNqlObject.QueryObjects<BaseDrugOrder.GetDrugPrescriptionTotalReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseDrugOrder.GetDrugBasedOnDoctor_Class> GetDrugBasedOnDoctor(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEDRUGORDER"].QueryDefs["GetDrugBasedOnDoctor"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseDrugOrder.GetDrugBasedOnDoctor_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseDrugOrder.GetDrugBasedOnDoctor_Class> GetDrugBasedOnDoctor(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEDRUGORDER"].QueryDefs["GetDrugBasedOnDoctor"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseDrugOrder.GetDrugBasedOnDoctor_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Uygulama Başlangıç Zamanı
    /// </summary>
        public DateTime? PlannedStartTime
        {
            get { return (DateTime?)this["PLANNEDSTARTTIME"]; }
            set { this["PLANNEDSTARTTIME"] = value; }
        }

    /// <summary>
    /// Doz Miktarı
    /// </summary>
        public double? DoseAmount
        {
            get { return (double?)this["DOSEAMOUNT"]; }
            set { this["DOSEAMOUNT"] = value; }
        }

    /// <summary>
    /// Kullanma Açıklaması
    /// </summary>
        public string UsageNote
        {
            get { return (string)this["USAGENOTE"]; }
            set { this["USAGENOTE"] = value; }
        }

    /// <summary>
    /// Gün
    /// </summary>
        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

        public ResSection SecondaryMasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("SECONDARYMASTERRESOURCE"); }
            set { this["SECONDARYMASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection FromResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("FROMRESOURCE"); }
            set { this["FROMRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Direktifi Veren Doktor
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResSection MasterResource
        {
            get { return (ResSection)((ITTObject)this).GetParent("MASTERRESOURCE"); }
            set { this["MASTERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Direktifi Veren Doktorun Uzmanlık Dalı
    /// </summary>
        public SpecialityDefinition ProcedureSpeciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("PROCEDURESPECIALITY"); }
            set { this["PROCEDURESPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public HospitalTimeSchedule HospitalTimeSchedule
        {
            get { return (HospitalTimeSchedule)((ITTObject)this).GetParent("HOSPITALTIMESCHEDULE"); }
            set { this["HOSPITALTIMESCHEDULE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected BaseDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDrugOrder(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDrugOrder(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDrugOrder(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDRUGORDER", dataRow) { }
        protected BaseDrugOrder(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDRUGORDER", dataRow, isImported) { }
        public BaseDrugOrder(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDrugOrder(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDrugOrder() : base() { }

    }
}