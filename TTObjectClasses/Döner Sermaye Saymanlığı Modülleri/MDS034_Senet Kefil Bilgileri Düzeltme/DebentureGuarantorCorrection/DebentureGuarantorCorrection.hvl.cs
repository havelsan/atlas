
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureGuarantorCorrection")] 

    /// <summary>
    /// Kefil Bilgileri Düzeltme
    /// </summary>
    public  partial class DebentureGuarantorCorrection : EpisodeAction
    {
        public class DebentureGuarantorCorrectionList : TTObjectCollection<DebentureGuarantorCorrection> { }
                    
        public class ChildDebentureGuarantorCorrectionCollection : TTObject.TTChildObjectCollection<DebentureGuarantorCorrection>
        {
            public ChildDebentureGuarantorCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureGuarantorCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class DebentureDebtReportQuery_Class : TTReportNqlObject 
        {
            public DateTime? DocumentDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTDOCUMENT"].AllPropertyDefs["DOCUMENTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Department
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEPARTMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTORCORRECTION"].AllPropertyDefs["DEPARTMENT"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Debentureno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEBENTURENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTORCORRECTIONPATIENTDEBENTURES"].AllPropertyDefs["NO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? DueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTORCORRECTIONPATIENTDEBENTURES"].AllPropertyDefs["DUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Currency? Debentureprice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEBENTUREPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTORCORRECTIONPATIENTDEBENTURES"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Guarantorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorfathername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORFATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorvolumeno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORVOLUMENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["VOLUMENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorpageno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORPAGENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["PAGENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorfamilyorderno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORFAMILYORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["FAMILYORDERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Guarantorcityofregistry
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GUARANTORCITYOFREGISTRY"]);
                }
            }

            public Guid? Guarantortownofregistry
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["GUARANTORTOWNOFREGISTRY"]);
                }
            }

            public string Guarantorvillageofregistry
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORVILLAGEOFREGISTRY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["VILLAGEOFREGISTRY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorhomeaddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORHOMEADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["HOMEADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorhomephone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORHOMEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["HOMEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorworkaddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORWORKADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["WORKADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Guarantorworkphone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GUARANTORWORKPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTOR"].AllPropertyDefs["WORKPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patientname
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                }
            }

            public long? Patientuniquerefno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Patientfathername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTFATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Object Patienthomeaddress
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTHOMEADDRESS"]);
                }
            }

            public Object Patienthomephone
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTHOMEPHONE"]);
                }
            }

            public DebentureDebtReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public DebentureDebtReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected DebentureDebtReportQuery_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("a78bf0b7-82fb-4cb6-adf1-2b8405eea060"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("f1fb0edc-6eda-4bb9-ae2e-f47754a64f74"); } }
        }

        public static BindingList<DebentureGuarantorCorrection.DebentureDebtReportQuery_Class> DebentureDebtReportQuery(string PARAMDEBCORRECTIONOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTORCORRECTION"].QueryDefs["DebentureDebtReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBCORRECTIONOBJID", PARAMDEBCORRECTIONOBJID);

            return TTReportNqlObject.QueryObjects<DebentureGuarantorCorrection.DebentureDebtReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DebentureGuarantorCorrection.DebentureDebtReportQuery_Class> DebentureDebtReportQuery(TTObjectContext objectContext, string PARAMDEBCORRECTIONOBJID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTUREGUARANTORCORRECTION"].QueryDefs["DebentureDebtReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMDEBCORRECTIONOBJID", PARAMDEBCORRECTIONOBJID);

            return TTReportNqlObject.QueryObjects<DebentureGuarantorCorrection.DebentureDebtReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Bölüm
    /// </summary>
        public string Department
        {
            get { return (string)this["DEPARTMENT"]; }
            set { this["DEPARTMENT"] = value; }
        }

        virtual protected void CreatePatientDebenturesCollection()
        {
            _PatientDebentures = new DebentureGuarantorCorrectionPatientDebentures.ChildDebentureGuarantorCorrectionPatientDebenturesCollection(this, new Guid("00b25665-fd08-46c7-8b6d-ec96d15da01b"));
            ((ITTChildObjectCollection)_PatientDebentures).GetChildren();
        }

        protected DebentureGuarantorCorrectionPatientDebentures.ChildDebentureGuarantorCorrectionPatientDebenturesCollection _PatientDebentures = null;
    /// <summary>
    /// Child collection for Senet Düzeltme ile ilişki
    /// </summary>
        public DebentureGuarantorCorrectionPatientDebentures.ChildDebentureGuarantorCorrectionPatientDebenturesCollection PatientDebentures
        {
            get
            {
                if (_PatientDebentures == null)
                    CreatePatientDebenturesCollection();
                return _PatientDebentures;
            }
        }

        protected DebentureGuarantorCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureGuarantorCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureGuarantorCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureGuarantorCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureGuarantorCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTUREGUARANTORCORRECTION", dataRow) { }
        protected DebentureGuarantorCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTUREGUARANTORCORRECTION", dataRow, isImported) { }
        public DebentureGuarantorCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureGuarantorCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureGuarantorCorrection() : base() { }

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