
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HospitalsUnitsDefinitionGrid")] 

    /// <summary>
    /// Muayene Edecek Birimler/XXXXXXler  
    /// </summary>
    public  partial class HospitalsUnitsDefinitionGrid : TTObject
    {
        public class HospitalsUnitsDefinitionGridList : TTObjectCollection<HospitalsUnitsDefinitionGrid> { }
                    
        public class ChildHospitalsUnitsDefinitionGridCollection : TTObject.TTChildObjectCollection<HospitalsUnitsDefinitionGrid>
        {
            public ChildHospitalsUnitsDefinitionGridCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHospitalsUnitsDefinitionGridCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// HospitalsUnitsDefinitionGrid i ReasonForExaminationDefinition ın ObjectID sine göre get eder
    /// </summary>
        public static BindingList<HospitalsUnitsDefinitionGrid> GetHospitalsUnitsDefByReason(TTObjectContext objectContext, string REASONID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HOSPITALSUNITSDEFINITIONGRID"].QueryDefs["GetHospitalsUnitsDefByReason"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REASONID", REASONID);

            return ((ITTQuery)objectContext).QueryObjects<HospitalsUnitsDefinitionGrid>(queryDef, paramList);
        }

    /// <summary>
    /// Cinsiyet
    /// </summary>
        public SexEnum? Sex
        {
            get { return (SexEnum?)(int?)this["SEX"]; }
            set { this["SEX"] = value; }
        }

    /// <summary>
    /// Şablon Açıklama
    /// </summary>
        public string TemplateDescription
        {
            get { return (string)this["TEMPLATEDESCRIPTION"]; }
            set { this["TEMPLATEDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Maximum Yaş
    /// </summary>
        public int? MaxOld
        {
            get { return (int?)this["MAXOLD"]; }
            set { this["MAXOLD"] = value; }
        }

    /// <summary>
    /// Minimum Yaş
    /// </summary>
        public int? MinOld
        {
            get { return (int?)this["MINOLD"]; }
            set { this["MINOLD"] = value; }
        }

        public ActionTemplate Template
        {
            get { return (ActionTemplate)((ITTObject)this).GetParent("TEMPLATE"); }
            set { this["TEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReasonForExaminationDefinition ReasonForExaminationDef
        {
            get { return (ReasonForExaminationDefinition)((ITTObject)this).GetParent("REASONFOREXAMINATIONDEF"); }
            set { this["REASONFOREXAMINATIONDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayene Edilecek Birim
    /// </summary>
        public ResPoliclinic Policklinic
        {
            get { return (ResPoliclinic)((ITTObject)this).GetParent("POLICKLINIC"); }
            set { this["POLICKLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Muayene Edecek Doktor
    /// </summary>
        public ResUser ProcedureDoctor
        {
            get { return (ResUser)((ITTObject)this).GetParent("PROCEDUREDOCTOR"); }
            set { this["PROCEDUREDOCTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public EpisodeActionTemplate EpisodeActionTemplate
        {
            get { return (EpisodeActionTemplate)((ITTObject)this).GetParent("EPISODEACTIONTEMPLATE"); }
            set { this["EPISODEACTIONTEMPLATE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Dış XXXXXX Birimleri
    /// </summary>
        public SpecialityDefinition Speciality
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("SPECIALITY"); }
            set { this["SPECIALITY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected HospitalsUnitsDefinitionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HospitalsUnitsDefinitionGrid(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HospitalsUnitsDefinitionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HospitalsUnitsDefinitionGrid(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HospitalsUnitsDefinitionGrid(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HOSPITALSUNITSDEFINITIONGRID", dataRow) { }
        protected HospitalsUnitsDefinitionGrid(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HOSPITALSUNITSDEFINITIONGRID", dataRow, isImported) { }
        public HospitalsUnitsDefinitionGrid(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HospitalsUnitsDefinitionGrid(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HospitalsUnitsDefinitionGrid() : base() { }

    }
}