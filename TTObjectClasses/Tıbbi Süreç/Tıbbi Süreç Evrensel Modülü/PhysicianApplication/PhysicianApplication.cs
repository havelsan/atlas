
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
    /// Muayene,Kontrol Muayenesi,Konsültasyon, Klinik Doktor İşlemleri gibi doktor işlemlerinin ana objesi
    /// </summary>
    public  partial class PhysicianApplication : EpisodeActionWithDiagnosis, IDiagnosisOzelDurum
    {
        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            
//            SetRequestAcceptionStateToNewConsultations();

#endregion PostUpdate
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            CreateSpecialityBasedObject();
            #endregion PreInsert
        }



        #region Methods
        //        public void SetRequestAcceptionStateToNewConsultations()
        //        {
        //            foreach(Consultation consultation in Consultations)
        //            {
        //                if(consultation.CurrentStateDefID == Consultation.States.Request)
        //                    consultation.CurrentStateDefID = Consultation.States.RequestAcception;
        //            }
        //        }

        #region IDiagnosisOzelDurum Members
        public OzelDurum GetOzelDurum()
        {
            return OzelDurum;
        }

        public void SetOzelDurum(OzelDurum value)
        {
            OzelDurum = value;
        }

        public DiagnosisGrid.ChildDiagnosisGridCollection GetDiagnosis()
        {
            return Diagnosis;
        }
        #endregion

        public virtual void CreateSpecialityBasedObject() // Uzmanlık için  Ayaktan da ve Default olarak
        {
            if(ProcedureSpeciality!= null)
            {
                if(ProcedureSpeciality.SpecialityBasedObjectType!= null)
                {
                    SpecialityBasedObject specialityBasedObject = null;
                    switch ((SpecialityBasedObjectEnum)ProcedureSpeciality.SpecialityBasedObjectType)
                    {
                        case SpecialityBasedObjectEnum.WomanSpecialityObject:
                            specialityBasedObject =  new WomanSpecialityObject(this);
                            break;
                        case SpecialityBasedObjectEnum.EyeExamination:
                            specialityBasedObject = new EyeExamination(this);
                            break;
                        case SpecialityBasedObjectEnum.ChildGrowth:
                            specialityBasedObject = new ChildGrowthStandards(this);
                            break;
                        case SpecialityBasedObjectEnum.EmergencySpecialityObject:
                            specialityBasedObject = new EmergencySpecialityObject(this);
                            //((InPatientPhysicianApplication)this).EmergencyIntervention != null
                            break;
                        case SpecialityBasedObjectEnum.Getat:
                            specialityBasedObject = new TraditionalMedicine(this);
                            break;
                        case SpecialityBasedObjectEnum.MedicalOncology:
                            specialityBasedObject = new MedicalOncology(this);
                            break;

                    }
                    if(specialityBasedObject!= null)
                    {
                        specialityBasedObject.PhysicianApplication = this;
                    }

                }
            }

        }


        /// <summary>
        /// Kullanıcı Doktor ise İşlemi Yapan Doktor Olarak Atar
        /// </summary>
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if (Common.CurrentUser.IsSuperUser == false && Diagnosis.Count == 0)
            {
                if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    if (Common.CurrentResource.TakesPerformanceScore == true)
                    {
                        IList userResources = UserResource.GetByUserAndResource(ObjectContext, Common.CurrentResource.ObjectID, MasterResource.ObjectID);
                        if (userResources.Count > 0)
                            ProcedureDoctor = Common.CurrentResource;
                    }
                }
            }
        }

        public IntensiveCareSpecialityObj GetMyIntensiveCareSpecialityObj()
        {
            foreach(var specialityBasedObject in SpecialityBasedObject)
            {
                if (specialityBasedObject is IntensiveCareSpecialityObj)
                    return (IntensiveCareSpecialityObj)specialityBasedObject;
            }
            return null;
        }

        #endregion Methods

    }
}