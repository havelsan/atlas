
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicalResarch")] 

    public  partial class MedicalResarch : TTObject
    {
        public class MedicalResarchList : TTObjectCollection<MedicalResarch> { }
                    
        public class ChildMedicalResarchCollection : TTObject.TTChildObjectCollection<MedicalResarch>
        {
            public ChildMedicalResarchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicalResarchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MedicalResarchRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? BudgetTotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUDGETTOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].AllPropertyDefs["BUDGETTOTALPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public int? PatientCount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTCOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].AllPropertyDefs["PATIENTCOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public String DisplayText
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public string TermName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TERMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCHTERMDEF"].AllPropertyDefs["TERMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MedicalResarchRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MedicalResarchRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MedicalResarchRQ_Class() : base() { }
        }

        [Serializable] 

        public partial class MedicalResarhCalcBudget_Class : TTReportNqlObject 
        {
            public Object Totalspent
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALSPENT"]);
                }
            }

            public MedicalResarhCalcBudget_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MedicalResarhCalcBudget_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MedicalResarhCalcBudget_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("00096c54-16c8-4239-8fef-963eb3bbe3e7"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Complete { get { return new Guid("ce1d6a64-acab-42c8-83aa-a22ecc488ee3"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancel { get { return new Guid("295752eb-c20f-4546-bab5-d6ce024d4342"); } }
        }

        public static BindingList<MedicalResarch.MedicalResarchRQ_Class> MedicalResarchRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].QueryDefs["MedicalResarchRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalResarch.MedicalResarchRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalResarch.MedicalResarchRQ_Class> MedicalResarchRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].QueryDefs["MedicalResarchRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicalResarch.MedicalResarchRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicalResarch.MedicalResarhCalcBudget_Class> MedicalResarhCalcBudget(Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].QueryDefs["MedicalResarhCalcBudget"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<MedicalResarch.MedicalResarhCalcBudget_Class>(queryDef, paramList, pi);
        }

        public static BindingList<MedicalResarch.MedicalResarhCalcBudget_Class> MedicalResarhCalcBudget(TTObjectContext objectContext, Guid TERMID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICALRESARCH"].QueryDefs["MedicalResarhCalcBudget"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TERMID", TERMID);

            return TTReportNqlObject.QueryObjects<MedicalResarch.MedicalResarhCalcBudget_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Araştıma Kodu
    /// </summary>
        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Hasta Sayısı
    /// </summary>
        public int? PatientCount
        {
            get { return (int?)this["PATIENTCOUNT"]; }
            set { this["PATIENTCOUNT"] = value; }
        }

        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
        }

        public BigCurrency? BudgetTotalPrice
        {
            get { return (BigCurrency?)this["BUDGETTOTALPRICE"]; }
            set { this["BUDGETTOTALPRICE"] = value; }
        }

    /// <summary>
    /// Araştırma Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public MedicalResarchTermDef MedicalResarchTermDef
        {
            get { return (MedicalResarchTermDef)((ITTObject)this).GetParent("MEDICALRESARCHTERMDEF"); }
            set { this["MEDICALRESARCHTERMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMedicalResarchProcedursCollection()
        {
            _MedicalResarchProcedurs = new MedicalResarchProcedur.ChildMedicalResarchProcedurCollection(this, new Guid("9d9bb99b-b773-4268-bd84-47b4b5e82642"));
            ((ITTChildObjectCollection)_MedicalResarchProcedurs).GetChildren();
        }

        protected MedicalResarchProcedur.ChildMedicalResarchProcedurCollection _MedicalResarchProcedurs = null;
        public MedicalResarchProcedur.ChildMedicalResarchProcedurCollection MedicalResarchProcedurs
        {
            get
            {
                if (_MedicalResarchProcedurs == null)
                    CreateMedicalResarchProcedursCollection();
                return _MedicalResarchProcedurs;
            }
        }

        virtual protected void CreateMedicalResarchDoctorsCollection()
        {
            _MedicalResarchDoctors = new MedicalResarchDoctor.ChildMedicalResarchDoctorCollection(this, new Guid("89e51103-4f54-49c4-8c44-2c0d6288e65a"));
            ((ITTChildObjectCollection)_MedicalResarchDoctors).GetChildren();
        }

        protected MedicalResarchDoctor.ChildMedicalResarchDoctorCollection _MedicalResarchDoctors = null;
        public MedicalResarchDoctor.ChildMedicalResarchDoctorCollection MedicalResarchDoctors
        {
            get
            {
                if (_MedicalResarchDoctors == null)
                    CreateMedicalResarchDoctorsCollection();
                return _MedicalResarchDoctors;
            }
        }

        protected MedicalResarch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicalResarch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicalResarch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicalResarch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicalResarch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICALRESARCH", dataRow) { }
        protected MedicalResarch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICALRESARCH", dataRow, isImported) { }
        public MedicalResarch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicalResarch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicalResarch() : base() { }

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