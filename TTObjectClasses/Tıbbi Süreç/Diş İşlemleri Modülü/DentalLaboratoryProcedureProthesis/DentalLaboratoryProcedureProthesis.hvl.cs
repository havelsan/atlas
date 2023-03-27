
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalLaboratoryProcedureProthesis")] 

    public  partial class DentalLaboratoryProcedureProthesis : BaseDentalProsthesis
    {
        public class DentalLaboratoryProcedureProthesisList : TTObjectCollection<DentalLaboratoryProcedureProthesis> { }
                    
        public class ChildDentalLaboratoryProcedureProthesisCollection : TTObject.TTChildObjectCollection<DentalLaboratoryProcedureProthesis>
        {
            public ChildDentalLaboratoryProcedureProthesisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalLaboratoryProcedureProthesisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

    /// <summary>
    /// Diş Taahhüt Numarası
    /// </summary>
        public int? DisTaahhutNo
        {
            get { return (int?)this["DISTAAHHUTNO"]; }
            set { this["DISTAAHHUTNO"] = value; }
        }

    /// <summary>
    /// Diş No
    /// </summary>
        public ToothNumberEnum? ToothNumber
        {
            get { return (ToothNumberEnum?)(int?)this["TOOTHNUMBER"]; }
            set { this["TOOTHNUMBER"] = value; }
        }

    /// <summary>
    /// Pozisyon
    /// </summary>
        public DentalPositionEnum? DentalPosition
        {
            get { return (DentalPositionEnum?)(int?)this["DENTALPOSITION"]; }
            set { this["DENTALPOSITION"] = value; }
        }

    /// <summary>
    /// Anomali
    /// </summary>
        public bool? Anomali
        {
            get { return (bool?)this["ANOMALI"]; }
            set { this["ANOMALI"] = value; }
        }

    /// <summary>
    /// Diş Rengi
    /// </summary>
        public string ToothColor
        {
            get { return (string)this["TOOTHCOLOR"]; }
            set { this["TOOTHCOLOR"] = value; }
        }

        public DentalExaminationSuggestedProsthesis SuggestedProsthesis
        {
            get { return (DentalExaminationSuggestedProsthesis)((ITTObject)this).GetParent("SUGGESTEDPROSTHESIS"); }
            set { this["SUGGESTEDPROSTHESIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Technician Technician
        {
            get { return (Technician)((ITTObject)this).GetParent("TECHNICIAN"); }
            set { this["TECHNICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DentalLaboratoryProcedure DentalLaboratoryProcedure
        {
            get 
            {   
                if (EpisodeAction is DentalLaboratoryProcedure)
                    return (DentalLaboratoryProcedure)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

        protected DentalLaboratoryProcedureProthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalLaboratoryProcedureProthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalLaboratoryProcedureProthesis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalLaboratoryProcedureProthesis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalLaboratoryProcedureProthesis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALLABORATORYPROCEDUREPROTHESIS", dataRow) { }
        protected DentalLaboratoryProcedureProthesis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALLABORATORYPROCEDUREPROTHESIS", dataRow, isImported) { }
        public DentalLaboratoryProcedureProthesis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalLaboratoryProcedureProthesis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalLaboratoryProcedureProthesis() : base() { }

    }
}