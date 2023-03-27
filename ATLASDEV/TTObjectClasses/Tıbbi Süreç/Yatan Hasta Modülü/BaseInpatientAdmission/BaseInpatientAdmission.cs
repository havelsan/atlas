
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
    public partial class BaseInpatientAdmission : EpisodeActionWithDiagnosis
    {
        public partial class OLAP_GetDailyInpatientTreatmentClinic_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetTreatmentClinicProcedure_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetTreatmentClinicForHistory_Class : TTReportNqlObject
        {
        }

        public partial class GetPhysicalStateClinic_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                //case "PHYSICALSTATECLINIC": Post Insert ve Post Update taşındı
                //    {
                //        ResWard value = (ResWard)newValue;
                //        #region PHYSICALSTATECLINIC_SetParentScript
                //        if (this is InpatientAdmission && ((InpatientAdmission)this).ActiveInPatientTrtmentClcApp != null)
                //        {
                //            ((InpatientAdmission)this).ActiveInPatientTrtmentClcApp.SecondaryMasterResource = value;
                //        }
                //        #endregion PHYSICALSTATECLINIC_SetParentScript
                //    }
                //    break;
                //case "ROOMGROUP":
                //    {
                //        ResRoomGroup value = (ResRoomGroup)newValue;
                //        #region ROOMGROUP_SetParentScript
                //        foreach (InPatientTreatmentClinicApplication InpatientTCA in this.InPatientTreatmentClinicApplications)
                //        {
                //            foreach (NursingApplication nursingApplication in InpatientTCA.NursingApplications)
                //            {
                //                nursingApplication.SecondaryMasterResource = value;
                //            }
                //        }
                //        #endregion ROOMGROUP_SetParentScript
                //    }
                //    break;
                //case "TREATMENTCLINIC":
                //    {
                //        ResClinic value = (ResClinic)newValue;
                //        #region TREATMENTCLINIC_SetParentScript
                //        //   bool hasQuota = value.CheckInpatientQuota(this.Episode);
                //        //if(!hasQuota) 
                //        //{
                //        //    this.TreatmentClinic = null;
                //        //    throw new Exception(SystemMessage.GetMessageV2(920,value.Name.ToString()));
                //        //}
                //        #endregion TREATMENTCLINIC_SetParentScript
                //    }
                //    break;
                //case "CUPBOARD":// Artık kullanılmıyor
                //    {
                //        CupboardDefinition value = (CupboardDefinition)newValue;
                //        #region CUPBOARD_SetParentScript
                //        if (this.Cupboard != value)
                //        {
                //            if (this.Cupboard != null)
                //            {
                //                this.Cupboard.UsedByAction = null;
                //            }
                //            if (value != null)
                //            {
                //                value.UsedByAction = (BaseAction)this;
                //            }
                //        }
                //        #endregion CUPBOARD_SetParentScript
                //    }
                //    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }


        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();
            SetSecondaryMasterResourceOfLinkedActions();
            #endregion PostInsert
        }
        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            SetSecondaryMasterResourceOfLinkedActions();
            #endregion PostUpdate
        }

        #region Methods
        /// <summary>
        /// Son BaseBedProcedure objesinin ait olduğu yatağı deallocate edip BedDischargeDate'ini set etmek için
        /// </summary>
        public void DeallocateLastBed()
        {
            //IList myUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this.ObjectContext, this.ObjectID.ToString(), UsedStatusEnum.Used);
            var myUsedBedList = BedProcedures.Where(dr => dr.UsedStatus == UsedStatusEnum.Used && dr.CurrentStateDef.Status != StateStatusEnum.Cancelled);
            foreach (BaseBedProcedure myUsedBed in myUsedBedList)
            {
                myUsedBed.UsedStatus = UsedStatusEnum.NotUsed;
            }

            //IList myResevedToUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this.ObjectContext, this.ObjectID.ToString(), UsedStatusEnum.ReservedToUse);
            var myResevedToUsedBedList = BedProcedures.Where(dr => dr.UsedStatus == UsedStatusEnum.ReservedToUse && dr.CurrentStateDef.Status != StateStatusEnum.Cancelled);
            foreach (BaseBedProcedure myResevedToUsedBed in myResevedToUsedBedList)
            {
                myResevedToUsedBed.UsedStatus = UsedStatusEnum.WasReserved;
            }
        }

        protected void CreateNewBedProcedure(bool allocateAsReservedToUse)
        {
            if (Bed != null)
            {
                if (Bed.UsedByBedProcedure == null)
                {
                    BaseBedProcedure baseBedProcedure = new BaseBedProcedure(ObjectContext);
                    BedProcedures.Add(baseBedProcedure);
                    baseBedProcedure.EpisodeAction = GetEpisodeActionForBedProcedure();
                    baseBedProcedure.Bed = Bed;
                    baseBedProcedure.Room = Room;
                    baseBedProcedure.RoomGroup = RoomGroup;
                    baseBedProcedure.IsNewPricingType = true;

                    if (allocateAsReservedToUse)
                    {
                        baseBedProcedure.UsedStatus = UsedStatusEnum.ReservedToUse;
                    }
                    else
                    {
                        baseBedProcedure.UsedStatus = UsedStatusEnum.Used;
                        Send501ToENabiz(baseBedProcedure.Bed);// Yeni yatak yoğun bakım yatağı ise 
                    }
                }
                else
                {
                    var RoomBed = Bed.Room.Name + Bed.Name;
                    var PatientInBed = Bed.UsedByBedProcedure.Episode.Patient;
                    var NameofePatientInBed = PatientInBed.Name + " " + PatientInBed.Surname;

                    throw new TTException(TTUtils.CultureService.GetText("M30110", "Hastanın yatırılacağı '{0}' yatağında yatan '{1}' isimli hasta başka yatağa yatırılmadan işlem gerçekleştirilemez. ", RoomBed, NameofePatientInBed));
                }
            }
        }


        protected EpisodeAction GetEpisodeActionForBedProcedure()
        {
            EpisodeAction episodeAction = null;
            if (this is InpatientAdmission)
                episodeAction = ((InpatientAdmission)this).ActiveInPatientTrtmentClcApp;
            if (episodeAction == null)
                episodeAction = this;
            return episodeAction;
        }

        /// <summary>
        /// Yatak alanı değişdikçe BaseBedProcedure objesine Yeni Satır eklemek e ilgili yatağı allocate etmek için
        /// </summary>
        public void AllocateNewBed(bool setUsedBedAsReservedToUse, bool allocateAsReservedToUse)
        {
            //setLastBedAsReservedToUse ise Patientın Used 'larında
            //yatağıma eşit olmayanları kapat Rezerve olarak aynısından aç.
            //Sonra kendini Used olarak ekle.
            //Yeni Bed null ise ;
            //kendisine ait Used yada ReservedToUsed varmı bakar
            //varsa  bulduğun kapatır  diyer actıonlarla oynamaz.
            //yoksa hiç bir şey yapmaz.
            //Yeni Bed Null değil ise
            //Önce kendisine ait Used varmı bakar varsa ve farklı ise  kapatıp yenisini açar
            //Kendisine ait Used yoksa Patiente ait Used varsa kendisini rezerve yapar.
            //Kendisine ait Used yoksa Patiente ait Used yoksa  kendine Rezerve varsa ve rezerveyi kadırıp yeni ekler yoksa direk yeni ekler

            //ARTIK 'Kendisine ait Used yoksa Patiente ait Used' OLMA İHTİMALİ YOK O YÃœZDEN AŞAĞIDAKİ kod COMMENTLENDİ 
            //EpisodeAction episodeAction = GetEpisodeActionForBedProcedure();
            if (IsOldAction != true) // Aktarımla gelen işlemlerde allocate edilmesi gerekmiyor
            {

                // ARTIK AMELİYAT SONRASI YOĞUN BAKIM İŞLEMİ YOK O YÃœZDEN AŞAĞIDAKİ kod COMMENTLENDİ tekrar ihtiyaç olursa  GetByPatientAndUseStatus METHODU YANLIZ VERİ TABANINDAKİLERİ ÇEKTĞİ KONTEKSTEKİNİ ALMADIĞI İÇİN DÃœZENLENMELİ
                //if (setUsedBedAsReservedToUse)//Ameliyat sonrası yoğun bakımda Yatak allocationı için kullanılacak
                //{
                //    if (this.Bed != null)
                //    {
                //        IList AllUsedBedList = BaseBedProcedure.GetByPatientAndUseStatus(this.ObjectContext, this.Episode.Patient.ObjectID.ToString(), UsedStatusEnum.Used);
                //        bool sameBed = false;
                //        foreach (BaseBedProcedure usedBed in AllUsedBedList)
                //        {
                //            if (usedBed.Bed.ObjectID != this.Bed.ObjectID || allocateAsReservedToUse)
                //            {
                //                usedBed.UsedStatus = UsedStatusEnum.NotUsed;
                //                BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this.ObjectContext);
                //                baseBedProcedure.BaseInpatientAdmission = usedBed.BaseInpatientAdmission;
                //                baseBedProcedure.EpisodeAction = episodeAction;
                //                baseBedProcedure.Bed = usedBed.Bed;
                //                baseBedProcedure.Room = usedBed.Room;
                //                baseBedProcedure.RoomGroup = usedBed.RoomGroup;
                //                baseBedProcedure.UsedStatus = UsedStatusEnum.ReservedToUse;

                //            }
                //            else
                //            {
                //                sameBed = true;
                //            }

                //        }
                //        if (sameBed == false)
                //        {
                //            CreateNewBedProcedure(allocateAsReservedToUse);
                //        }
                //    }
                //}
                //else
                //{
                if (Bed == null)///Yatak null olark set edilirse ilgili işlemin Used ve Rezervasyonları boşalır(Yatışda Rezervasyonlu yatakların rezervasyonu  sadece yatak boşaltılarak kalkabilir)
                {
                    //IList nMyUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this.ObjectContext, this.ObjectID.ToString(), UsedStatusEnum.Used);
                    var nMyUsedBedList = BedProcedures.Where(dr => dr.UsedStatus == UsedStatusEnum.Used);
                    foreach (BaseBedProcedure nMyUsedBed in nMyUsedBedList)
                    {
                        nMyUsedBed.UsedStatus = UsedStatusEnum.NotUsed;
                    }

                    //IList nMyResevedToUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this.ObjectContext, this.ObjectID.ToString(), UsedStatusEnum.ReservedToUse);
                    var nMyResevedToUsedBedList = BedProcedures.Where(dr => dr.UsedStatus == UsedStatusEnum.ReservedToUse);
                    foreach (BaseBedProcedure nMyResevedToUsedBed in nMyResevedToUsedBedList)
                    {
                        nMyResevedToUsedBed.UsedStatus = UsedStatusEnum.WasReserved;
                    }
                }
                else
                {
                    //Önce kendisine ait Used varmı bakar varsa ve farklı ise yada yeni açılacak olan yatağın reserve olması istendi ise  kapatıp yenisini açar aynı ise bir şey yapmaz
                    // IList myUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this.ObjectContext, this.ObjectID.ToString(), UsedStatusEnum.Used);
                    var myUsedBedList = BedProcedures.Where(dr => dr.UsedStatus == UsedStatusEnum.Used);
                    if (myUsedBedList.Count() > 0)
                    {
                        bool sameBed = false;
                        foreach (BaseBedProcedure myUsedBed in myUsedBedList)
                        {

                            if (myUsedBed.Bed.ObjectID != Bed.ObjectID || allocateAsReservedToUse)
                            {
                                if (!myUsedBed.IsCancelled)
                                {
                                    myUsedBed.UsedStatus = UsedStatusEnum.NotUsed;
                                }
                            }
                            else
                            {
                                sameBed = true;
                            }

                        }
                        if (sameBed == false)
                        {
                            CreateNewBedProcedure(allocateAsReservedToUse);
                        }
                    }
                    else
                    {

                        // ARTIK 'Kendisine ait Used yoksa Patiente ait Used' OLMA İHTİMALİ YOK O YÃœZDEN AŞAĞIDAKİ kod COMMENTLENDİ tekrar ihtiyaç olursa  GetByPatientAndUseStatus METHODU YANLIZ VERİ TABANINDAKİLERİ ÇEKTĞİ KONTEKSTEKİNİ ALMADIĞI İÇİN DÃœZENLENMELİ
                        //Kendisine ait Used yoksa Patiente ait Used varsa kendisini rezerve yapar.
                        //IList allUsedBedList = BaseBedProcedure.GetByPatientAndUseStatus(this.ObjectContext, this.Episode.Patient.ObjectID.ToString(), UsedStatusEnum.Used);
                        //    if (allUsedBedList.Count > 0)
                        //    {
                        //        BaseBedProcedure baseBedProcedure = new BaseBedProcedure(this.ObjectContext);
                        //        this.BedProcedures.Add(baseBedProcedure);
                        //        baseBedProcedure.EpisodeAction = episodeAction;
                        //        baseBedProcedure.Bed = this.Bed;
                        //        baseBedProcedure.Room = this.Room;
                        //        baseBedProcedure.RoomGroup = this.RoomGroup;
                        //        baseBedProcedure.UsedStatus = UsedStatusEnum.ReservedToUse;

                        //    }
                        //    else
                        //    {
                        //Kendisine ait Used yoksa Patiente ait Used yoksa
                        //kendine Rezerve varsa şimdiki yatağından farklı ise yada  yeni eklencek olan used isteniyorsa  yeni ekler yoksa bişey yapmaz.
                        //IList myResevedToUsedBedList = BaseBedProcedure.GetByBaseInpatientAdmissionAndUseStatus(this.ObjectContext, this.ObjectID.ToString(), UsedStatusEnum.ReservedToUse);
                        var myResevedToUsedBedList = BedProcedures.Where(dr => dr.UsedStatus == UsedStatusEnum.ReservedToUse);
                        bool sameBed = false;
                        foreach (BaseBedProcedure myResevedToUsedBed in myResevedToUsedBedList)
                        {
                            if (myResevedToUsedBed.Bed.ObjectID != Bed.ObjectID || allocateAsReservedToUse == false)
                            {
                                myResevedToUsedBed.UsedStatus = UsedStatusEnum.WasReserved;
                            }
                            else
                            {
                                sameBed = true;
                            }
                        }
                        if (sameBed == false)
                        {
                            CreateNewBedProcedure(allocateAsReservedToUse);
                        }

                        //}
                    }
                }
                //}
            }

        }

        public void SetSecondaryMasterResourceOfLinkedActions()
        {

            if (this is InpatientAdmission)// PhysicalStateClinic değiştikçe  ActiveInPatientTrtmentClcApp SecMasterResourceü değişsin diye
            {
                var activeInPatientTrtmentClcApp = ((InpatientAdmission)this).ActiveInPatientTrtmentClcApp;

                if (activeInPatientTrtmentClcApp != null)
                {
                    activeInPatientTrtmentClcApp.SecondaryMasterResource = PhysicalStateClinic;
                    foreach (NursingApplication nursingApplication in activeInPatientTrtmentClcApp.NursingApplications)// RoomGroup değiştikçe NursingApplicationın ve Ph SecMasterResourceü değişsin diye
                    {
                        nursingApplication.SecondaryMasterResource = RoomGroup;
                    }
                    foreach (InPatientPhysicianApplication inPatientPhysicianApplication in activeInPatientTrtmentClcApp.InPatientPhysicianApplication)
                    {
                        inPatientPhysicianApplication.SecondaryMasterResource = RoomGroup;
                    }
                }

            }


        }

        public void Send501ToENabiz(ResBed newBed)
        {
            if (newBed.IsIntensiveCareBedProcedure() == true) // Yanlızca 1.2.3. Basamak Yoğun bakım hizmeti ile ilişkilendirilmiş yataklar için 
            {
                if (this is InpatientAdmission)
                {
                    var activeInPatientTrtmentClcApp = ((InpatientAdmission)this).ActiveInPatientTrtmentClcApp;
                    if (activeInPatientTrtmentClcApp != null)
                    {
                        if (activeInPatientTrtmentClcApp.InPatientPhysicianApplication.Count > 0)
                        {
                            var myIntensiveCareSpecialityObj = activeInPatientTrtmentClcApp.InPatientPhysicianApplication[0].GetMyIntensiveCareSpecialityObj();
                            if (myIntensiveCareSpecialityObj != null)
                                myIntensiveCareSpecialityObj.Send501ToENabiz();
                        }
                    }
                }
            }
        }
        #endregion Methods

    }
}