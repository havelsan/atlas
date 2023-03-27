
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrHealthCommittee")] 

    /// <summary>
    /// Sağlık Kurulu
    /// </summary>
    public  partial class ehrHealthCommittee : ehrEpisodeAction
    {
        public class ehrHealthCommitteeList : TTObjectCollection<ehrHealthCommittee> { }
                    
        public class ChildehrHealthCommitteeCollection : TTObject.TTChildObjectCollection<ehrHealthCommittee>
        {
            public ChildehrHealthCommitteeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrHealthCommitteeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

        public static BindingList<ehrHealthCommittee> GetByPatient(TTObjectContext objectContext, Guid PATIENT, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EHRHEALTHCOMMITTEE"].QueryDefs["GetByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return ((ITTQuery)objectContext).QueryObjects<ehrHealthCommittee>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Karar
    /// </summary>
        public object Decision
        {
            get { return (object)this["DECISION"]; }
            set { this["DECISION"] = value; }
        }

    /// <summary>
    /// Rapor Tarihi
    /// </summary>
        public DateTime? ReportDate
        {
            get { return (DateTime?)this["REPORTDATE"]; }
            set { this["REPORTDATE"] = value; }
        }

    /// <summary>
    /// Karar Süresi
    /// </summary>
        public int? HCDecisionTime
        {
            get { return (int?)this["HCDECISIONTIME"]; }
            set { this["HCDECISIONTIME"] = value; }
        }

    /// <summary>
    /// Karar Süresi Birimi
    /// </summary>
        public UnitOfTimeEnum? HCDecisionUnitOfTime
        {
            get { return (UnitOfTimeEnum?)(int?)this["HCDECISIONUNITOFTIME"]; }
            set { this["HCDECISIONUNITOFTIME"] = value; }
        }

    /// <summary>
    /// İlave / Diğer Karar
    /// </summary>
        public bool? AdditionalDecision
        {
            get { return (bool?)this["ADDITIONALDECISION"]; }
            set { this["ADDITIONALDECISION"] = value; }
        }

    /// <summary>
    /// Ne Maksatla Muayene Edildiği
    /// </summary>
        public ReasonForExaminationDefinition ReasonForExamination
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATION"); }
            set { this["REASONFOREXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Gönderilen Onay Makamı
    /// </summary>
        public ConfirmationUnitDefinition ChairSentTo
        {
            get { return (ConfirmationUnitDefinition)((ITTObject)this).GetParent("CHAIRSENTTO"); }
            set { this["CHAIRSENTTO"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Sağlık Kurulu Kararı
    /// </summary>
        public HealthCommitteeDecisionDefinition HCDecision
        {
            get { return (HealthCommitteeDecisionDefinition)((ITTObject)this).GetParent("HCDECISION"); }
            set { this["HCDECISION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrHealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrHealthCommittee(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrHealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrHealthCommittee(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrHealthCommittee(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRHEALTHCOMMITTEE", dataRow) { }
        protected ehrHealthCommittee(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRHEALTHCOMMITTEE", dataRow, isImported) { }
        public ehrHealthCommittee(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrHealthCommittee(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrHealthCommittee() : base() { }

    }
}