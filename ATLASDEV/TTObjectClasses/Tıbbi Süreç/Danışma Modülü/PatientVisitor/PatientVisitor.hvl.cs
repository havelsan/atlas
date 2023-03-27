
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientVisitor")] 

    public  partial class PatientVisitor : TTObject
    {
        public class PatientVisitorList : TTObjectCollection<PatientVisitor> { }
                    
        public class ChildPatientVisitorCollection : TTObject.TTChildObjectCollection<PatientVisitor>
        {
            public ChildPatientVisitorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientVisitorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<PatientVisitor> GetByDate(TTObjectContext objectContext, DateTime FIRSTDATE, DateTime SECONDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTVISITOR"].QueryDefs["GetByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("FIRSTDATE", FIRSTDATE);
            paramList.Add("SECONDDATE", SECONDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientVisitor>(queryDef, paramList);
        }

        public string VisitorUnicRefId
        {
            get { return (string)this["VISITORUNICREFID"]; }
            set { this["VISITORUNICREFID"] = value; }
        }

        public string VisitorRelationState
        {
            get { return (string)this["VISITORRELATIONSTATE"]; }
            set { this["VISITORRELATIONSTATE"] = value; }
        }

        public string VisitorName
        {
            get { return (string)this["VISITORNAME"]; }
            set { this["VISITORNAME"] = value; }
        }

        public string VisitorSurname
        {
            get { return (string)this["VISITORSURNAME"]; }
            set { this["VISITORSURNAME"] = value; }
        }

        public string VisitorFatherName
        {
            get { return (string)this["VISITORFATHERNAME"]; }
            set { this["VISITORFATHERNAME"] = value; }
        }

        public string VisitorMotherName
        {
            get { return (string)this["VISITORMOTHERNAME"]; }
            set { this["VISITORMOTHERNAME"] = value; }
        }

        public DateTime? VisitorBirthDate
        {
            get { return (DateTime?)this["VISITORBIRTHDATE"]; }
            set { this["VISITORBIRTHDATE"] = value; }
        }

        public string VisitorNote
        {
            get { return (string)this["VISITORNOTE"]; }
            set { this["VISITORNOTE"] = value; }
        }

        public DateTime? VisitorEnterDate
        {
            get { return (DateTime?)this["VISITORENTERDATE"]; }
            set { this["VISITORENTERDATE"] = value; }
        }

        public DateTime? VisitorExitDate
        {
            get { return (DateTime?)this["VISITOREXITDATE"]; }
            set { this["VISITOREXITDATE"] = value; }
        }

        public string VisitorPhoneNumber
        {
            get { return (string)this["VISITORPHONENUMBER"]; }
            set { this["VISITORPHONENUMBER"] = value; }
        }

        public Patient Patient
        {
            get { return (Patient)((ITTObject)this).GetParent("PATIENT"); }
            set { this["PATIENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Doğum ili
    /// </summary>
        public SKRSILKodlari VisitorBirthCity
        {
            get { return (SKRSILKodlari)((ITTObject)this).GetParent("VISITORBIRTHCITY"); }
            set { this["VISITORBIRTHCITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sex
    /// </summary>
        public SKRSCinsiyet VisitorSex
        {
            get { return (SKRSCinsiyet)((ITTObject)this).GetParent("VISITORSEX"); }
            set { this["VISITORSEX"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PatientVisitor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientVisitor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientVisitor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientVisitor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientVisitor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTVISITOR", dataRow) { }
        protected PatientVisitor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTVISITOR", dataRow, isImported) { }
        public PatientVisitor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientVisitor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientVisitor() : base() { }

    }
}