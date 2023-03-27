
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PersonnelConsignment")] 

    /// <summary>
    /// Personel Sevk Muhtırası
    /// </summary>
    public  partial class PersonnelConsignment : EpisodeAction
    {
        public class PersonnelConsignmentList : TTObjectCollection<PersonnelConsignment> { }
                    
        public class ChildPersonnelConsignmentCollection : TTObject.TTChildObjectCollection<PersonnelConsignment>
        {
            public ChildPersonnelConsignmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPersonnelConsignmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPersonnelConsignmentInfo_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Gidecegiyer
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GIDECEGIYER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].AllPropertyDefs["ARRIVALREAGON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Refakatci
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFAKATCI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].AllPropertyDefs["COMPANIONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? Refakatcsevk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFAKATCSEVK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].AllPropertyDefs["ONLYCOMPANION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Refakatciilesevk
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFAKATCIILESEVK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].AllPropertyDefs["WITHCOMPANION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string FatherName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FATHERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["FATHERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Patientbirthdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTBIRTHDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["BIRTHDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Patientcityofbirth
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["PATIENTCITYOFBIRTH"]);
                }
            }

            public string Patienttownofbirth
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTTOWNOFBIRTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TOWNDEFINITIONS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? Treatmentclinic
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TREATMENTCLINIC"]);
                }
            }

            public long? QuarantineProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QUARANTINEPROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["INPATIENTADMISSION"].AllPropertyDefs["QUARANTINEPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episode
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODE"]);
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

            public GetPersonnelConsignmentInfo_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPersonnelConsignmentInfo_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPersonnelConsignmentInfo_Class() : base() { }
        }

        public static class States
        {
            public static Guid Cancelled { get { return new Guid("23655503-8962-4bf9-ba69-efd5f4b20bd7"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("5fa40ba3-6650-40f1-96aa-6a9efef90d9d"); } }
    /// <summary>
    /// Yeni 
    /// </summary>
            public static Guid New { get { return new Guid("3b9ddd69-9070-4c5d-81e4-fbe10dabec77"); } }
        }

        public static BindingList<PersonnelConsignment.GetPersonnelConsignmentInfo_Class> GetPersonnelConsignmentInfo(string PERSONNELCONSIGNMENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].QueryDefs["GetPersonnelConsignmentInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PERSONNELCONSIGNMENT", PERSONNELCONSIGNMENT);

            return TTReportNqlObject.QueryObjects<PersonnelConsignment.GetPersonnelConsignmentInfo_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PersonnelConsignment.GetPersonnelConsignmentInfo_Class> GetPersonnelConsignmentInfo(TTObjectContext objectContext, string PERSONNELCONSIGNMENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PERSONNELCONSIGNMENT"].QueryDefs["GetPersonnelConsignmentInfo"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PERSONNELCONSIGNMENT", PERSONNELCONSIGNMENT);

            return TTReportNqlObject.QueryObjects<PersonnelConsignment.GetPersonnelConsignmentInfo_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Birlikte Sevk
    /// </summary>
        public bool? WithCompanion
        {
            get { return (bool?)this["WITHCOMPANION"]; }
            set { this["WITHCOMPANION"] = value; }
        }

    /// <summary>
    /// Gideceği Yer
    /// </summary>
        public string ArrivalReagon
        {
            get { return (string)this["ARRIVALREAGON"]; }
            set { this["ARRIVALREAGON"] = value; }
        }

    /// <summary>
    /// Refakatçi Sevk
    /// </summary>
        public bool? OnlyCompanion
        {
            get { return (bool?)this["ONLYCOMPANION"]; }
            set { this["ONLYCOMPANION"] = value; }
        }

    /// <summary>
    /// Refakatçi Adı Soyadı
    /// </summary>
        public string CompanionName
        {
            get { return (string)this["COMPANIONNAME"]; }
            set { this["COMPANIONNAME"] = value; }
        }

        protected PersonnelConsignment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PersonnelConsignment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PersonnelConsignment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PersonnelConsignment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PersonnelConsignment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PERSONNELCONSIGNMENT", dataRow) { }
        protected PersonnelConsignment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PERSONNELCONSIGNMENT", dataRow, isImported) { }
        public PersonnelConsignment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PersonnelConsignment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PersonnelConsignment() : base() { }

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