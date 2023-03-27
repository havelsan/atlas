
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="KScheduleMaterial")] 

    /// <summary>
    /// K-Çizelgesi Malzeme
    /// </summary>
    public  partial class KScheduleMaterial : StockActionDetailOut
    {
        public class KScheduleMaterialList : TTObjectCollection<KScheduleMaterial> { }
                    
        public class ChildKScheduleMaterialCollection : TTObject.TTChildObjectCollection<KScheduleMaterial>
        {
            public ChildKScheduleMaterialCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildKScheduleMaterialCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PrescriptionTypeQuery_Class : TTReportNqlObject 
        {
            public Guid? Patient
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PATIENT"]);
                }
            }

            public Guid? Material
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MATERIAL"]);
                }
            }

            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Guid? MKYS_TeslimAlanObjID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MKYS_TESLIMALANOBJID"]);
                }
            }

            public PrescriptionTypeQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PrescriptionTypeQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PrescriptionTypeQuery_Class() : base() { }
        }

        public static BindingList<KScheduleMaterial.PrescriptionTypeQuery_Class> PrescriptionTypeQuery(PrescriptionTypeEnum PRESCRIPTIONTYPE, DateTime STARTDATE, DateTime ENDDATE, Guid DOCTOR, Guid STORE, IList<string> MATERIALS, bool ALLMATERIALS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].QueryDefs["PrescriptionTypeQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("STORE", STORE);
            paramList.Add("MATERIALS", MATERIALS);
            paramList.Add("ALLMATERIALS", ALLMATERIALS);

            return TTReportNqlObject.QueryObjects<KScheduleMaterial.PrescriptionTypeQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<KScheduleMaterial.PrescriptionTypeQuery_Class> PrescriptionTypeQuery(TTObjectContext objectContext, PrescriptionTypeEnum PRESCRIPTIONTYPE, DateTime STARTDATE, DateTime ENDDATE, Guid DOCTOR, Guid STORE, IList<string> MATERIALS, bool ALLMATERIALS, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["KSCHEDULEMATERIAL"].QueryDefs["PrescriptionTypeQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PRESCRIPTIONTYPE", (int)PRESCRIPTIONTYPE);
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("DOCTOR", DOCTOR);
            paramList.Add("STORE", STORE);
            paramList.Add("MATERIALS", MATERIALS);
            paramList.Add("ALLMATERIALS", ALLMATERIALS);

            return TTReportNqlObject.QueryObjects<KScheduleMaterial.PrescriptionTypeQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public double? StoreInheld
        {
            get { return (double?)this["STOREINHELD"]; }
            set { this["STOREINHELD"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// İstenen Miktar
    /// </summary>
        public double? RequestAmount
        {
            get { return (double?)this["REQUESTAMOUNT"]; }
            set { this["REQUESTAMOUNT"] = value; }
        }

    /// <summary>
    /// Hasta Adı
    /// </summary>
        public string PatientName
        {
            get { return (string)this["PATIENTNAME"]; }
            set { this["PATIENTNAME"] = value; }
        }

    /// <summary>
    /// Karantina No
    /// </summary>
        public string QuarantinaNO
        {
            get { return (string)this["QUARANTINANO"]; }
            set { this["QUARANTINANO"] = value; }
        }

    /// <summary>
    /// ID
    /// </summary>
        public string PatientID
        {
            get { return (string)this["PATIENTID"]; }
            set { this["PATIENTID"] = value; }
        }

    /// <summary>
    /// Acil İlaç
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

    /// <summary>
    /// Barkodu Doğrulanan Miktar
    /// </summary>
        public double? BarcodeVerifyCounter
        {
            get { return (double?)this["BARCODEVERIFYCOUNTER"]; }
            set { this["BARCODEVERIFYCOUNTER"] = value; }
        }

    /// <summary>
    /// Order ilk uygulanma zamanı
    /// </summary>
        public DateTime? DrugOrderStartDate
        {
            get { return (DateTime?)this["DRUGORDERSTARTDATE"]; }
            set { this["DRUGORDERSTARTDATE"] = value; }
        }

        public int? TimesInADay
        {
            get { return (int?)this["TIMESINADAY"]; }
            set { this["TIMESINADAY"] = value; }
        }

    /// <summary>
    /// Kullanım Şekli
    /// </summary>
        public string UsageNote
        {
            get { return (string)this["USAGENOTE"]; }
            set { this["USAGENOTE"] = value; }
        }

    /// <summary>
    /// DrugOrderObjectID
    /// </summary>
        public Guid? DrugOrderObjectID
        {
            get { return (Guid?)this["DRUGORDEROBJECTID"]; }
            set { this["DRUGORDEROBJECTID"] = value; }
        }

    /// <summary>
    /// Kontravisit
    /// </summary>
        public bool? IsCV
        {
            get { return (bool?)this["ISCV"]; }
            set { this["ISCV"] = value; }
        }

    /// <summary>
    /// Reçete  No
    /// </summary>
        public string PrescriptionNO
        {
            get { return (string)this["PRESCRIPTIONNO"]; }
            set { this["PRESCRIPTIONNO"] = value; }
        }

        public KScheduleCollectedOrder KScheduleCollectedOrder
        {
            get { return (KScheduleCollectedOrder)((ITTObject)this).GetParent("KSCHEDULECOLLECTEDORDER"); }
            set { this["KSCHEDULECOLLECTEDORDER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public KSchedule KSchedule
        {
            get 
            {   
                if (StockAction is KSchedule)
                    return (KSchedule)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        public DrugDefinition DrugDefinition
        {
            get 
            {   
                if (Material is DrugDefinition)
                    return (DrugDefinition)Material; 
                return null;
            }            
            set { Material = value; }
        }

        protected KScheduleMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected KScheduleMaterial(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected KScheduleMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected KScheduleMaterial(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected KScheduleMaterial(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "KSCHEDULEMATERIAL", dataRow) { }
        protected KScheduleMaterial(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "KSCHEDULEMATERIAL", dataRow, isImported) { }
        public KScheduleMaterial(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public KScheduleMaterial(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public KScheduleMaterial() : base() { }

    }
}