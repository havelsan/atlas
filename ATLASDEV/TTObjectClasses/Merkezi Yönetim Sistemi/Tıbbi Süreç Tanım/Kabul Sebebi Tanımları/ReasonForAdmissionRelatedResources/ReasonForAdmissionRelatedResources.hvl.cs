
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReasonForAdmissionRelatedResources")] 

    public  partial class ReasonForAdmissionRelatedResources : TTObject
    {
        public class ReasonForAdmissionRelatedResourcesList : TTObjectCollection<ReasonForAdmissionRelatedResources> { }
                    
        public class ChildReasonForAdmissionRelatedResourcesCollection : TTObject.TTChildObjectCollection<ReasonForAdmissionRelatedResources>
        {
            public ChildReasonForAdmissionRelatedResourcesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReasonForAdmissionRelatedResourcesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static BindingList<ReasonForAdmissionRelatedResources> GetByReasonForAdmissionAndSpeciality(TTObjectContext objectContext, Guid REASONFORADMISSION, IList<Guid> SPECIALITIES)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REASONFORADMISSIONRELATEDRESOURCES"].QueryDefs["GetByReasonForAdmissionAndSpeciality"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REASONFORADMISSION", REASONFORADMISSION);
            paramList.Add("SPECIALITIES", SPECIALITIES);

            return ((ITTQuery)objectContext).QueryObjects<ReasonForAdmissionRelatedResources>(queryDef, paramList);
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
    /// Kaynağa Göre Başlatılacak İşlem
    /// </summary>
        public ActionTypeEnum? ActionType
        {
            get { return (ActionTypeEnum?)(int?)this["ACTIONTYPE"]; }
            set { this["ACTIONTYPE"] = value; }
        }

    /// <summary>
    /// Minimum Yaş
    /// </summary>
        public int? MinOld
        {
            get { return (int?)this["MINOLD"]; }
            set { this["MINOLD"] = value; }
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
    /// Hasta kabulde doktor atamanın çıkıp çıkmayacağını belirler. True ise çıkar.
    /// </summary>
        public bool? GetAuthorizeUserList
        {
            get { return (bool?)this["GETAUTHORIZEUSERLIST"]; }
            set { this["GETAUTHORIZEUSERLIST"] = value; }
        }

    /// <summary>
    /// Kabul Sebebi - İlgili Kaynaklar
    /// </summary>
        public ReasonForAdmission ReasonForAdmission
        {
            get { return (ReasonForAdmission)((ITTObject)this).GetParent("REASONFORADMISSION"); }
            set { this["REASONFORADMISSION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kaynak
    /// </summary>
        public ResSection Resource
        {
            get { return (ResSection)((ITTObject)this).GetParent("RESOURCE"); }
            set { this["RESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateProcedureDefinitionsCollection()
        {
            _ProcedureDefinitions = new ReasonForAdmissionProcedureDefinitions.ChildReasonForAdmissionProcedureDefinitionsCollection(this, new Guid("a516131f-f5b2-4bb5-8915-c1c47b07887b"));
            ((ITTChildObjectCollection)_ProcedureDefinitions).GetChildren();
        }

        protected ReasonForAdmissionProcedureDefinitions.ChildReasonForAdmissionProcedureDefinitionsCollection _ProcedureDefinitions = null;
    /// <summary>
    /// Child collection for Başlatılacak Prosedure
    /// </summary>
        public ReasonForAdmissionProcedureDefinitions.ChildReasonForAdmissionProcedureDefinitionsCollection ProcedureDefinitions
        {
            get
            {
                if (_ProcedureDefinitions == null)
                    CreateProcedureDefinitionsCollection();
                return _ProcedureDefinitions;
            }
        }

        protected ReasonForAdmissionRelatedResources(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReasonForAdmissionRelatedResources(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReasonForAdmissionRelatedResources(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReasonForAdmissionRelatedResources(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReasonForAdmissionRelatedResources(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REASONFORADMISSIONRELATEDRESOURCES", dataRow) { }
        protected ReasonForAdmissionRelatedResources(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REASONFORADMISSIONRELATEDRESOURCES", dataRow, isImported) { }
        public ReasonForAdmissionRelatedResources(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReasonForAdmissionRelatedResources(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReasonForAdmissionRelatedResources() : base() { }

    }
}