
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ehrConsultationFromOtherHospital")] 

    /// <summary>
    /// Dış XXXXXXlerden Konsültasyon
    /// </summary>
    public  partial class ehrConsultationFromOtherHospital : ehrEpisodeAction
    {
        public class ehrConsultationFromOtherHospitalList : TTObjectCollection<ehrConsultationFromOtherHospital> { }
                    
        public class ChildehrConsultationFromOtherHospitalCollection : TTObject.TTChildObjectCollection<ehrConsultationFromOtherHospital>
        {
            public ChildehrConsultationFromOtherHospitalCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildehrConsultationFromOtherHospitalCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Active { get { return new Guid("d82caca1-a08a-43fa-b009-be70b816c5ec"); } }
            public static Guid UnActive { get { return new Guid("8abe0000-7e19-46e0-a07f-e69109e6aa4c"); } }
        }

    /// <summary>
    /// Konsültasyon Sonucu Ve Öneriler
    /// </summary>
        public object ConsultationResultAndOffers
        {
            get { return (object)this["CONSULTATIONRESULTANDOFFERS"]; }
            set { this["CONSULTATIONRESULTANDOFFERS"] = value; }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string RequestDescription
        {
            get { return (string)this["REQUESTDESCRIPTION"]; }
            set { this["REQUESTDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Konsültasyonu Yapan Doktor Adı
    /// </summary>
        public string ConsultedDoctorName
        {
            get { return (string)this["CONSULTEDDOCTORNAME"]; }
            set { this["CONSULTEDDOCTORNAME"] = value; }
        }

        public string RequesterResourceName
        {
            get { return (string)this["REQUESTERRESOURCENAME"]; }
            set { this["REQUESTERRESOURCENAME"] = value; }
        }

    /// <summary>
    /// Konsültasyonu İsteyen Doktor Adı
    /// </summary>
        public string RequesterDoctorName
        {
            get { return (string)this["REQUESTERDOCTORNAME"]; }
            set { this["REQUESTERDOCTORNAME"] = value; }
        }

    /// <summary>
    /// Anamnez Bulgular
    /// </summary>
        public string Symptom
        {
            get { return (string)this["SYMPTOM"]; }
            set { this["SYMPTOM"] = value; }
        }

    /// <summary>
    /// İstek Yapılan XXXXXX XXXXXX
    /// </summary>
        public ReferableHospital RequestedReferableHospital
        {
            get { return (ReferableHospital)((ITTObject)this).GetParent("REQUESTEDREFERABLEHOSPITAL"); }
            set { this["REQUESTEDREFERABLEHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan XXXXXX XXXXXX Birimi
    /// </summary>
        public ReferableResource RequestedReferableResource
        {
            get { return (ReferableResource)((ITTObject)this).GetParent("REQUESTEDREFERABLERESOURCE"); }
            set { this["REQUESTEDREFERABLERESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan Dış XXXXXX Birimi
    /// </summary>
        public SpecialityDefinition RequestedExternalDepartment
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("REQUESTEDEXTERNALDEPARTMENT"); }
            set { this["REQUESTEDEXTERNALDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapılan Dış XXXXXX
    /// </summary>
        public ExternalHospitalDefinition RequestedExternalHospital
        {
            get { return (ExternalHospitalDefinition)((ITTObject)this).GetParent("REQUESTEDEXTERNALHOSPITAL"); }
            set { this["REQUESTEDEXTERNALHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// İstek Yapan XXXXXX
    /// </summary>
        public ResHospital RequesterHospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("REQUESTERHOSPITAL"); }
            set { this["REQUESTERHOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ehrConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ehrConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ehrConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ehrConsultationFromOtherHospital(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ehrConsultationFromOtherHospital(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EHRCONSULTATIONFROMOTHERHOSPITAL", dataRow) { }
        protected ehrConsultationFromOtherHospital(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EHRCONSULTATIONFROMOTHERHOSPITAL", dataRow, isImported) { }
        public ehrConsultationFromOtherHospital(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ehrConsultationFromOtherHospital(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ehrConsultationFromOtherHospital() : base() { }

    }
}