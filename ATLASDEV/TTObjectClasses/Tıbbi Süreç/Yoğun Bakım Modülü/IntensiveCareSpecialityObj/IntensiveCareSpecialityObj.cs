
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
    public partial class IntensiveCareSpecialityObj : SpecialityBasedObject
    {

        public IntensiveCareSpecialityObj(PhysicianApplication physicianApplication) : this(physicianApplication.ObjectContext)
        {
            PhysicianApplication = physicianApplication;
        }

        public void Send501ToENabiz()
        {
            if (PhysicianApplication != null && PhysicianApplication.SubEpisode != null && PhysicianApplication.SendToENabiz())
            {
                if (PhysicianApplication is InPatientPhysicianApplication)
                {
                    var inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)PhysicianApplication).InPatientTreatmentClinicApp;
                    if (inPatientTreatmentClinicApp != null)
                    {
                        if (inPatientTreatmentClinicApp.BaseInpatientAdmission.Bed != null && inPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.IsIntensiveCareBedProcedure() == true)  // Yanlızca yoğun bakım yatağı procedurelkerine bağlı yataklar için E nabıza gönderim yapılır
                        {
                            new SendToENabiz(ObjectContext, PhysicianApplication.SubEpisode, ObjectID, ObjectDef.Name, "501", Common.RecTime());
                        }
                    }
                }

            }
        }
        //public void Send502ToENabiz()
        //{
        //    if (this.PhysicianApplication != null && this.PhysicianApplication.SubEpisode != null && this.PhysicianApplication.SendToENabiz())
        //    {
        //        if (this.PhysicianApplication is InPatientPhysicianApplication)
        //        {
        //            var inPatientTreatmentClinicApp = ((InPatientPhysicianApplication)this.PhysicianApplication).InPatientTreatmentClinicApp;
        //            if (inPatientTreatmentClinicApp != null)
        //            {
        //                if (inPatientTreatmentClinicApp.BaseInpatientAdmission.Bed != null && inPatientTreatmentClinicApp.BaseInpatientAdmission.Bed.IsIntensiveCareBedProcedure() == true)  // Yanlızca yoğun bakım yatağı procedurelkerine bağlı yataklar için E nabıza gönderim yapılır
        //                {
        //                    new SendToENabiz(this.ObjectContext, this.PhysicianApplication.SubEpisode, this.ObjectID, this.ObjectDef.Name, "502", Common.RecTime());
        //                }
        //            }
        //        }

        //    }
        //}

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = this as ITTObject;
            if (theObject.IsNew)
            {
                if (SepsisStatus == null)//SepsisStatus default hayır olarak set edilecek
                {
                    SepsisStatus = SKRSDurum.GetSkrsDurumObj(ObjectContext, "Where KODU=2").FirstOrDefault();
                }
                if (SepticShock == null)//SepsisStatus default hayır olarak set edilecek
                {
                    SepticShock = SKRSDurum.GetSkrsDurumObj(ObjectContext, "Where KODU=2").FirstOrDefault();
                }
                //if (VentilatorStatus == null)//SepsisStatus default hayır olarak set edilecek
                //{
                //    VentilatorStatus = SKRSDurum.GetSkrsDurumObj(ObjectContext, "Where KODU=2").FirstOrDefault();
                //}

                if (IntensiveCareType == null)//Yoğun bakım tipi atanıyor.
                {
                    SetIntensiveCareType();
                }
            }
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            Send501ToENabiz();

            if (SepsisStatus == null)//SepsisStatus default hayır olarak set edilecek
            {
                SepsisStatus = SKRSDurum.GetSkrsDurumObj(ObjectContext, "Where KODU=2").FirstOrDefault();
            }
            if (SepticShock == null)//SepsisStatus default hayır olarak set edilecek
            {
                SepticShock = SKRSDurum.GetSkrsDurumObj(ObjectContext, "Where KODU=2").FirstOrDefault();
            }
            //if (VentilatorStatus == null)//SepsisStatus default hayır olarak set edilecek
            //{
            //    VentilatorStatus = SKRSDurum.GetSkrsDurumObj(ObjectContext, "Where KODU=2").FirstOrDefault();
            //}

            if (IntensiveCareType == null)//Yoğun bakım tipi atanıyor.
            {
                SetIntensiveCareType();
            }
            //this.Send502ToENabiz();
            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            Send501ToENabiz();// şimdilik kendina ait propertyleri olmadığı için pek update görmüyor dolayısı ile burası biraz atıl bir kod
            #endregion PostUpdate
        }

        public void SetIntensiveCareType()
        {
            if (PhysicianApplication != null && PhysicianApplication.Episode != null && PhysicianApplication.Episode.Patient != null && PhysicianApplication.Episode.Patient.BirthDate != null)
            {
                Common.Age commonAge = Common.CalculateAge(PhysicianApplication.Episode.Patient.BirthDate.Value);
                if (commonAge.Years > 16)
                {
                    IntensiveCareType = IntensiveCareTypeEnum.AdultIntensiveCare;
                }
                else
                {
                    if (commonAge.Years < 1 && commonAge.Months < 1 && commonAge.Days <= 30)
                    {
                        IntensiveCareType = IntensiveCareTypeEnum.NewBornIntensiveCare;
                    }
                    else
                    {
                        IntensiveCareType = IntensiveCareTypeEnum.ChildIntensiveCare;
                    }
                }

            }
        }

        public IntensiveCareTypeEnum SetIntensiveCareType(Patient _Patient)
        {
            IntensiveCareTypeEnum IntensiveCareType = IntensiveCareTypeEnum.ChildIntensiveCare;
            if (_Patient != null && _Patient.BirthDate != null)
            {
                Common.Age commonAge = Common.CalculateAge(_Patient.BirthDate.Value);
                if (commonAge.Years > 16)
                {
                    IntensiveCareType = IntensiveCareTypeEnum.AdultIntensiveCare;
                }
                else
                {
                    if (commonAge.Years < 1 && commonAge.Months < 1 && commonAge.Days <= 30)
                    {
                        IntensiveCareType = IntensiveCareTypeEnum.NewBornIntensiveCare;
                    }
                    else
                    {
                        IntensiveCareType = IntensiveCareTypeEnum.ChildIntensiveCare;
                    }
                }

            }
            return IntensiveCareType;
        }
    }
}