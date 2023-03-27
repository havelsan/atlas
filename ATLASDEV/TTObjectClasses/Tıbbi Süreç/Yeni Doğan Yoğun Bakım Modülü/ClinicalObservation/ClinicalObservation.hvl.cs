
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ClinicalObservation")] 

    public  partial class ClinicalObservation : TTObject
    {
        public class ClinicalObservationList : TTObjectCollection<ClinicalObservation> { }
                    
        public class ChildClinicalObservationCollection : TTObject.TTChildObjectCollection<ClinicalObservation>
        {
            public ChildClinicalObservationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildClinicalObservationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Klinik İzlemin Girildiği Tarih Bilgisi
    /// </summary>
        public DateTime? ProcessDate
        {
            get { return (DateTime?)this["PROCESSDATE"]; }
            set { this["PROCESSDATE"] = value; }
        }

    /// <summary>
    /// Doktorun Klinik Not Bilgisi
    /// </summary>
        public string ClinicalNote
        {
            get { return (string)this["CLINICALNOTE"]; }
            set { this["CLINICALNOTE"] = value; }
        }

        public ResUser RequesterPerson
        {
            get { return (ResUser)((ITTObject)this).GetParent("REQUESTERPERSON"); }
            set { this["REQUESTERPERSON"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ClinicalObservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ClinicalObservation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ClinicalObservation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ClinicalObservation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ClinicalObservation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CLINICALOBSERVATION", dataRow) { }
        protected ClinicalObservation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CLINICALOBSERVATION", dataRow, isImported) { }
        public ClinicalObservation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ClinicalObservation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ClinicalObservation() : base() { }

    }
}