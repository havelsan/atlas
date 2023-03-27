
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalStuffPrescription")] 

    /// <summary>
    /// Tıbbi Malzeme Reçetesi
    /// </summary>
    public  partial class MedicalStuffPrescription : EpisodeActionWithDiagnosis
    {
        public class MedicalStuffPrescriptionList : TTObjectCollection<MedicalStuffPrescription> { }
                    
        public class ChildMedicalStuffPrescriptionCollection : TTObject.TTChildObjectCollection<MedicalStuffPrescription>
        {
            public ChildMedicalStuffPrescriptionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalStuffPrescriptionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicalStuffPrescriptionListByID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMedicalStuffPrescriptionListByID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffPrescriptionListByID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffPrescriptionListByID_Class() : base() { }
        }

        [Serializable] 

        public partial class GetMedicalStuffPrescriptionsByReport_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ReceteTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECETETAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPRESCRIPTION"].AllPropertyDefs["RECETETAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["REPORTNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string RaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFREPORT"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPRESCRIPTION"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsSendedMedula
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISSENDEDMEDULA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPRESCRIPTION"].AllPropertyDefs["ISSENDEDMEDULA"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetMedicalStuffPrescriptionsByReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicalStuffPrescriptionsByReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicalStuffPrescriptionsByReport_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("1e976c8e-1412-4898-b3a3-5403c7ab27b6"); } }
    /// <summary>
    /// Reçete Kaydedildi
    /// </summary>
            public static Guid PrescriptionCompleted { get { return new Guid("20524861-8983-4837-9067-54813270c4fe"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("ed42bf01-46cf-456c-b082-dc061897f1b9"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("968f283c-eb91-4d04-a73a-88d28de10477"); } }
        }

        public static BindingList<MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class> GetMedicalStuffPrescriptionListByID(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPRESCRIPTION"].QueryDefs["GetMedicalStuffPrescriptionListByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class> GetMedicalStuffPrescriptionListByID(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPRESCRIPTION"].QueryDefs["GetMedicalStuffPrescriptionListByID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<MedicalStuffPrescription.GetMedicalStuffPrescriptionListByID_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport_Class> GetMedicalStuffPrescriptionsByReport(Guid ReportID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPRESCRIPTION"].QueryDefs["GetMedicalStuffPrescriptionsByReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTID", ReportID);

            return TTReportNqlObject.QueryObjects<MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport_Class> GetMedicalStuffPrescriptionsByReport(TTObjectContext objectContext, Guid ReportID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALSTUFFPRESCRIPTION"].QueryDefs["GetMedicalStuffPrescriptionsByReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REPORTID", ReportID);

            return TTReportNqlObject.QueryObjects<MedicalStuffPrescription.GetMedicalStuffPrescriptionsByReport_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İmzalanmış Veri
    /// </summary>
        public object SignedData
        {
            get { return (object)this["SIGNEDDATA"]; }
            set { this["SIGNEDDATA"] = value; }
        }

    /// <summary>
    /// Medula Açıklama
    /// </summary>
        public string MedulaDescription
        {
            get { return (string)this["MEDULADESCRIPTION"]; }
            set { this["MEDULADESCRIPTION"] = value; }
        }

    /// <summary>
    /// Medulaya Gönderildi
    /// </summary>
        public bool? IsSendedMedula
        {
            get { return (bool?)this["ISSENDEDMEDULA"]; }
            set { this["ISSENDEDMEDULA"] = value; }
        }

    /// <summary>
    /// Gelen Rapor Bilgileri
    /// </summary>
        public string ReceteGelenXML
        {
            get { return (string)this["RECETEGELENXML"]; }
            set { this["RECETEGELENXML"] = value; }
        }

    /// <summary>
    /// Giden Reçete Bilgileri
    /// </summary>
        public string ReceteGidenXML
        {
            get { return (string)this["RECETEGIDENXML"]; }
            set { this["RECETEGIDENXML"] = value; }
        }

    /// <summary>
    /// Reçete Gönderim Tarihi
    /// </summary>
        public DateTime? ReceteGonderimTarihi
        {
            get { return (DateTime?)this["RECETEGONDERIMTARIHI"]; }
            set { this["RECETEGONDERIMTARIHI"] = value; }
        }

    /// <summary>
    /// Medula Reçete Takip No
    /// </summary>
        public string ReceteTakipNo
        {
            get { return (string)this["RECETETAKIPNO"]; }
            set { this["RECETETAKIPNO"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public object Description
        {
            get { return (object)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Reçete Açk. Türü
    /// </summary>
        public DescriptionTypeEnum? DescriptionType
        {
            get { return (DescriptionTypeEnum?)(int?)this["DESCRIPTIONTYPE"]; }
            set { this["DESCRIPTIONTYPE"] = value; }
        }

    /// <summary>
    /// Başlangıç Tarihi
    /// </summary>
        public DateTime? PrescriptionDate
        {
            get { return (DateTime?)this["PRESCRIPTIONDATE"]; }
            set { this["PRESCRIPTIONDATE"] = value; }
        }

        public MedicalStuffReport MedicalStuffReport
        {
            get { return (MedicalStuffReport)((ITTObject)this).GetParent("MEDICALSTUFFREPORT"); }
            set { this["MEDICALSTUFFREPORT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedicalStuffCollection()
        {
            _MedicalStuff = new MedicalStuff.ChildMedicalStuffCollection(this, new Guid("5fe27bda-981a-48ad-8a04-0952865fab97"));
            ((ITTChildObjectCollection)_MedicalStuff).GetChildren();
        }

        protected MedicalStuff.ChildMedicalStuffCollection _MedicalStuff = null;
        public MedicalStuff.ChildMedicalStuffCollection MedicalStuff
        {
            get
            {
                if (_MedicalStuff == null)
                    CreateMedicalStuffCollection();
                return _MedicalStuff;
            }
        }

        protected MedicalStuffPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalStuffPrescription(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalStuffPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalStuffPrescription(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalStuffPrescription(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALSTUFFPRESCRIPTION", dataRow) { }
        protected MedicalStuffPrescription(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALSTUFFPRESCRIPTION", dataRow, isImported) { }
        public MedicalStuffPrescription(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalStuffPrescription(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalStuffPrescription() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}