
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DoctorQuotaDefinition")] 

    public  partial class DoctorQuotaDefinition : TTDefinitionSet
    {
        public class DoctorQuotaDefinitionList : TTObjectCollection<DoctorQuotaDefinition> { }
                    
        public class ChildDoctorQuotaDefinitionCollection : TTObject.TTChildObjectCollection<DoctorQuotaDefinition>
        {
            public ChildDoctorQuotaDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoctorQuotaDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDoctorOwnQuota_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Quota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["QUOTA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AutomaticReception
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUTOMATICRECEPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["AUTOMATICRECEPTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? ResultQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["RESULTQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["RESULTSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultEndtTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTENDTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["RESULTENDTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetDoctorOwnQuota_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoctorOwnQuota_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoctorOwnQuota_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllDoctorQuota_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
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

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Quota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["QUOTA"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? AutomaticReception
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AUTOMATICRECEPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["AUTOMATICRECEPTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public int? ResultQuota
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTQUOTA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["RESULTQUOTA"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultStartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTSTARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["RESULTSTARTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ResultEndtTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTENDTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].AllPropertyDefs["RESULTENDTTIME"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetAllDoctorQuota_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllDoctorQuota_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllDoctorQuota_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("f142cc41-17d9-4b8c-896a-50f6fb00417e"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("960ae7c1-e800-40e1-bf7a-34477deac49c"); } }
        }

        public static BindingList<DoctorQuotaDefinition> GetDoctorQuotaByPoliclinic(TTObjectContext objectContext, Guid POLICLINIC, Guid USER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].QueryDefs["GetDoctorQuotaByPoliclinic"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINIC", POLICLINIC);
            paramList.Add("USER", USER);

            return ((ITTQuery)objectContext).QueryObjects<DoctorQuotaDefinition>(queryDef, paramList);
        }

        public static BindingList<DoctorQuotaDefinition.GetDoctorOwnQuota_Class> GetDoctorOwnQuota(Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].QueryDefs["GetDoctorOwnQuota"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<DoctorQuotaDefinition.GetDoctorOwnQuota_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DoctorQuotaDefinition.GetDoctorOwnQuota_Class> GetDoctorOwnQuota(TTObjectContext objectContext, Guid USER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].QueryDefs["GetDoctorOwnQuota"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<DoctorQuotaDefinition.GetDoctorOwnQuota_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DoctorQuotaDefinition.GetAllDoctorQuota_Class> GetAllDoctorQuota(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].QueryDefs["GetAllDoctorQuota"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DoctorQuotaDefinition.GetAllDoctorQuota_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DoctorQuotaDefinition.GetAllDoctorQuota_Class> GetAllDoctorQuota(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].QueryDefs["GetAllDoctorQuota"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DoctorQuotaDefinition.GetAllDoctorQuota_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<DoctorQuotaDefinition> GetDoctorQuotaByPoliclinicList(TTObjectContext objectContext, IList<Guid> POLICLINICLIST, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCTORQUOTADEFINITION"].QueryDefs["GetDoctorQuotaByPoliclinicList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("POLICLINICLIST", POLICLINICLIST);

            return ((ITTQuery)objectContext).QueryObjects<DoctorQuotaDefinition>(queryDef, paramList, injectionSQL);
        }

        public DateTime? WorkDate
        {
            get { return (DateTime?)this["WORKDATE"]; }
            set { this["WORKDATE"] = value; }
        }

        public string Quota
        {
            get { return (string)this["QUOTA"]; }
            set { this["QUOTA"] = value; }
        }

    /// <summary>
    /// Aktif/Pasif durumunu belirler
    /// </summary>
        public bool? Active
        {
            get { return (bool?)this["ACTIVE"]; }
            set { this["ACTIVE"] = value; }
        }

    /// <summary>
    /// Sonuç Sırası Alma Başlangıç
    /// </summary>
        public DateTime? ResultStartTime
        {
            get { return (DateTime?)this["RESULTSTARTTIME"]; }
            set { this["RESULTSTARTTIME"] = value; }
        }

    /// <summary>
    /// Sonuç Sırası Alma Bitiş
    /// </summary>
        public DateTime? ResultEndtTime
        {
            get { return (DateTime?)this["RESULTENDTTIME"]; }
            set { this["RESULTENDTTIME"] = value; }
        }

    /// <summary>
    /// Sonuç Kotası
    /// </summary>
        public int? ResultQuota
        {
            get { return (int?)this["RESULTQUOTA"]; }
            set { this["RESULTQUOTA"] = value; }
        }

    /// <summary>
    /// Branş Seçiminde Otomatik KAbul alınır
    /// </summary>
        public bool? AutomaticReception
        {
            get { return (bool?)this["AUTOMATICRECEPTION"]; }
            set { this["AUTOMATICRECEPTION"] = value; }
        }

    /// <summary>
    /// Kabul alınan birim
    /// </summary>
        public ResPoliclinic Policlinic
        {
            get { return (ResPoliclinic)((ITTObject)this).GetParent("POLICLINIC"); }
            set { this["POLICLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İşlemi Gerçekleştiren Doktor Nesnesini Taşıyan Alandır
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DoctorQuotaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DoctorQuotaDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DoctorQuotaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DoctorQuotaDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DoctorQuotaDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCTORQUOTADEFINITION", dataRow) { }
        protected DoctorQuotaDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCTORQUOTADEFINITION", dataRow, isImported) { }
        public DoctorQuotaDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DoctorQuotaDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DoctorQuotaDefinition() : base() { }

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