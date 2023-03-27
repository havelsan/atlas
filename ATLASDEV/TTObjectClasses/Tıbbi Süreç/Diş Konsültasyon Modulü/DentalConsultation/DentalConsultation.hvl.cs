
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalConsultation")] 

    /// <summary>
    /// DentalConsultation
    /// </summary>
    public  partial class DentalConsultation : DentalExamination, ICreateSubEpisode
    {
        public class DentalConsultationList : TTObjectCollection<DentalConsultation> { }
                    
        public class ChildDentalConsultationCollection : TTObject.TTChildObjectCollection<DentalConsultation>
        {
            public ChildDentalConsultationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalConsultationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_GetDentalConsultation_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALCONSULTATION"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DENTALCONSULTATION"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Masres
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["MASRES"]);
                }
            }

            public Guid? Prodoc
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PRODOC"]);
                }
            }

            public Guid? ProcedureSpeciality
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDURESPECIALITY"]);
                }
            }

            public PatientStatusEnum? PatientStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["PATIENTSTATUS"].DataType;
                    return (PatientStatusEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Sex
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["SEX"]);
                }
            }

            public DateTime? BirthDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Statestatus
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["STATESTATUS"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public double? ForeignUniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FOREIGNUNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FOREIGNUNIQUEREFNO"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OLAP_GetDentalConsultation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_GetDentalConsultation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_GetDentalConsultation_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Appointment { get { return new Guid("0ed7bda4-c894-4824-bfc6-65a0b1f0d67a"); } }
            public static Guid Cancelled { get { return new Guid("92047ab5-38e4-463b-a3ee-654ed45f28e2"); } }
            public static Guid Completed { get { return new Guid("0db4067e-1f4b-43af-9ed2-136d1433bee1"); } }
            public static Guid Examination { get { return new Guid("bb66e14a-b754-4589-8bbf-7a5b3bd845f3"); } }
            public static Guid New { get { return new Guid("2cebfe7c-5a7c-4676-a962-1ba9b7114af3"); } }
    /// <summary>
    /// Hasta Gelmedi
    /// </summary>
            public static Guid PatientNoShown { get { return new Guid("f92b159c-3aa2-47e9-9ad6-f9bb1bbd355c"); } }
        }

        public static BindingList<DentalConsultation.OLAP_GetDentalConsultation_Class> OLAP_GetDentalConsultation(DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALCONSULTATION"].QueryDefs["OLAP_GetDentalConsultation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<DentalConsultation.OLAP_GetDentalConsultation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DentalConsultation.OLAP_GetDentalConsultation_Class> OLAP_GetDentalConsultation(TTObjectContext objectContext, DateTime DATE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DENTALCONSULTATION"].QueryDefs["OLAP_GetDentalConsultation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DATE", DATE);

            return TTReportNqlObject.QueryObjects<DentalConsultation.OLAP_GetDentalConsultation_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Dişler
    /// </summary>
        public string SelectedToothNumbers
        {
            get { return (string)this["SELECTEDTOOTHNUMBERS"]; }
            set { this["SELECTEDTOOTHNUMBERS"] = value; }
        }

        public DentalExamination DentalExamination_Cons
        {
            get { return (DentalExamination)((ITTObject)this).GetParent("DENTALEXAMINATION_CONS"); }
            set { this["DENTALEXAMINATION_CONS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DentalConsultation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalConsultation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalConsultation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalConsultation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalConsultation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALCONSULTATION", dataRow) { }
        protected DentalConsultation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALCONSULTATION", dataRow, isImported) { }
        public DentalConsultation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalConsultation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalConsultation() : base() { }

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