
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MPBSAcademicCareer")] 

    /// <summary>
    /// Akademik Kariyer
    /// </summary>
    public  partial class MPBSAcademicCareer : TTObject
    {
        public class MPBSAcademicCareerList : TTObjectCollection<MPBSAcademicCareer> { }
                    
        public class ChildMPBSAcademicCareerCollection : TTObject.TTChildObjectCollection<MPBSAcademicCareer>
        {
            public ChildMPBSAcademicCareerCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMPBSAcademicCareerCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yükselme Tarihi
    /// </summary>
        public DateTime? PromotionDate
        {
            get { return (DateTime?)this["PROMOTIONDATE"]; }
            set { this["PROMOTIONDATE"] = value; }
        }

    /// <summary>
    /// Bitiş Tarihi
    /// </summary>
        public DateTime? EndDate
        {
            get { return (DateTime?)this["ENDDATE"]; }
            set { this["ENDDATE"] = value; }
        }

    /// <summary>
    /// Uzmanlık
    /// </summary>
        public string Internship
        {
            get { return (string)this["INTERNSHIP"]; }
            set { this["INTERNSHIP"] = value; }
        }

    /// <summary>
    /// Süre
    /// </summary>
        public int? Duration
        {
            get { return (int?)this["DURATION"]; }
            set { this["DURATION"] = value; }
        }

    /// <summary>
    /// Başlama Tarihi
    /// </summary>
        public DateTime? StartDate
        {
            get { return (DateTime?)this["STARTDATE"]; }
            set { this["STARTDATE"] = value; }
        }

    /// <summary>
    /// Bilim Dalı
    /// </summary>
        public string ScienceBranch
        {
            get { return (string)this["SCIENCEBRANCH"]; }
            set { this["SCIENCEBRANCH"] = value; }
        }

    /// <summary>
    /// Personel
    /// </summary>
        public MPBSPermanentTurkishPersonnel PermanentTurkishPersonnel
        {
            get { return (MPBSPermanentTurkishPersonnel)((ITTObject)this).GetParent("PERMANENTTURKISHPERSONNEL"); }
            set { this["PERMANENTTURKISHPERSONNEL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MPBSAcademicCareer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MPBSAcademicCareer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MPBSAcademicCareer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MPBSAcademicCareer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MPBSAcademicCareer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MPBSACADEMICCAREER", dataRow) { }
        protected MPBSAcademicCareer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MPBSACADEMICCAREER", dataRow, isImported) { }
        public MPBSAcademicCareer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MPBSAcademicCareer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MPBSAcademicCareer() : base() { }

    }
}