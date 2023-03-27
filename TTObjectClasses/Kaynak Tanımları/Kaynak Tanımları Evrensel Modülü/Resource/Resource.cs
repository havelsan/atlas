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
    /// <summary>
    /// BaseResourceClass
    /// </summary>
    public abstract partial class Resource : TTDefinitionSet
    {
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            if (IsActive == null)
                IsActive = true;
#endregion PreInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            if (this is ResPoliclinic)
            {
                ResPoliclinic pol = (ResPoliclinic)this;
                pol.CreateOrUpdateBoundReferableResource();
            }
#endregion PostUpdate
        }

        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();
            ResourceSpecialities.DeleteChildren();
#endregion PreDelete
        }

#region Methods
        public override string ToString()
        {
            return Name ?? base.ToString();
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = this as ITTObject;
            if (theObject.IsNew)
            {
                ID.GetNextValue();
            }
        }

        public void SetAsPatientAuthorizedResource(Episode episode)
        {
            if (episode != null)
            {
                bool found = false;
                foreach (PatientAuthorizedResource oldPatientAuthRes in episode.PatientAuthorizedResources)
                {
                    if (oldPatientAuthRes.Resource != null & oldPatientAuthRes.Resource.ObjectID == ObjectID)
                    {
                        found = true;
                        if (episode.CurrentStateDefID == Episode.States.Open)
                            oldPatientAuthRes.Patient = episode.Patient;
                        else
                            oldPatientAuthRes.Patient = null;
                        break;
                    }
                }

                if (!found)
                {
                    PatientAuthorizedResource patientAuthRes = new PatientAuthorizedResource(ObjectContext);
                    patientAuthRes.Resource = this;
                    patientAuthRes.Episode = episode;
                    if (episode.CurrentStateDefID == Episode.States.Open)
                        patientAuthRes.Patient = episode.Patient;
                    else
                        patientAuthRes.Patient = null;
                }
            }
        }

        public void DeleteFromPatientAuthorizedResource(Episode episode)
        {
            if (episode != null)
            {
                bool found = false;
                foreach (PatientAuthorizedResource oldPatientAuthRes in episode.PatientAuthorizedResources)
                {
                    if (oldPatientAuthRes.Resource != null & oldPatientAuthRes.Resource.ObjectID == ObjectID)
                    {
                        ((ITTObject)oldPatientAuthRes).Delete();
                        break;
                    }
                }
            }
        }

        public bool IsSpecialityExistsInResourceSpecialities(SpecialityDefinition speciality)
        {
            if (speciality != null)
            {
                foreach (ResourceSpecialityGrid rsg in ResourceSpecialities)
                {
                    if (rsg.Speciality != null && rsg.Speciality.ObjectID == speciality.ObjectID)
                        return true;
                }
            }

            return false;
        }

        public SpecialityDefinition Brans
        {
            get
            {
                if (ResourceSpecialities.Count > 0)
                    return ResourceSpecialities[0].Speciality;
                return null;
            }

            set
            {
            }
        }

        private string _resourceColor;
        [TTStorageManager.Attributes.TTSerializeProperty]
        public string ResourceColor
        {
            get
            {
                return _resourceColor;
            }

            set
            {
                _resourceColor = value;
            }
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Hasta_Muayenesi_Hasta_Gelmedi, TTRoleNames.Hasta_Muayenesi_Muayene_R, TTRoleNames.Hasta_Muayenesi_Muayene, TTRoleNames.Hasta_Muayenesi_Tamamlandi, TTRoleNames.Hasta_Muayenesi_Muayene_w, TTRoleNames.Hasta_Muayenesi_Tamamlandi_R, TTRoleNames.Hasta_Muayenesi_Tamamlandi_W, TTRoleNames.Hasta_Muayenesi_Hemsirelik_Uygulamalari, TTRoleNames.Hasta_Muayenesi_Iptal_Etme, TTRoleNames.SorumluDoktorTamamlanmisIslemGorme, TTRoleNames.Hasta_Muayenesi_Geri_Alma, TTRoleNames.Hasta_Muayenesi_Iptal_Edildi, TTRoleNames.Hasta_Muayenesi_Randevu, TTRoleNames.Hasta_Muayenesi_Yeni)]
        public static Store GetStore(Resource resource)
        {
            return resource.Store;
        }
#endregion Methods
    }
}