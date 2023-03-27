
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
    /// Ameliyat Ekibi
    /// </summary>
    public  partial class SurgeryPersonnel 
    {
        public partial class OLAP_GetSurgeryPersonnel_Class : TTReportNqlObject 
        {
        }

        public partial class VEM_AMELIYAT_EKIP_Class : TTReportNqlObject 
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                // Ekrandanki gridde Surgery - AllSergeryPersonels relationı oluyor Entry Episodeactionları vievmodelın postunda  set edilyor
                //case "ENTRYEPISODEACTION":
                //    {
                //        EpisodeAction value = (EpisodeAction)newValue;
                //        #region EpisodeAction_SetParentScript
                //        if (value != null)
                //        {
                //            if(value is SubSurgery)
                //            {
                //                this.Surgery = ((SubSurgery)value).Surgery;
                //            }
                //            if (value is Surgery)
                //            {
                //                this.Surgery = (Surgery)value;
                //            }
                //            // yeni bir Personel Eklendiğinde SurgeryProcedureun HasChangedAtChildObjects değeri değişsin ve DoktorPerformansa data gönderimi gerçekleşsin diye eklendi
                //            // SetHasChangedAtChildObjects(value);
                //        }
                //        else
                //        {
                //            this.Surgery = null;
                //        }
                //        #endregion SURGERYPROCEDURE_SetParentScript
                //    }
                //    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }



        public ResSection IfNeedNewSubSurgeryGetMasterResource()
        {
            if (Personnel.TakesPerformanceScore == true)
            {
                //Anestezi uzmanlığı için ek ameliyat oluşturmasın
                SpecialityDefinition anesteziSpeciality = SpecialityDefinition.GetSpecialityByCode(ObjectContext, SystemParameter.GetParameterValue("ANESTEZIUZMANLIKKODU", "XXXXXX")).FirstOrDefault();
                if (anesteziSpeciality != null && Personnel.IsSpecialityExistsInResourceSpecialities(anesteziSpeciality))
                    return null;

                ResSection newMasterResource = null;
                foreach (var userresource in Personnel.UserResources)
                {
                    if (Surgery.SubEpisode.PatientStatus == SubEpisodeStatusEnum.Outpatient  )
                    {
                        if (userresource.Resource is ResPoliclinic)
                        {
                            newMasterResource = userresource.Resource;
                            break;
                        }
                    }
                    else
                    {
                        if (userresource.Resource is ResClinic)
                        {
                            newMasterResource = userresource.Resource;
                            break;
                        }
                    }
                }
                if(newMasterResource!= null)
                {
                    if (Surgery.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    {
                        if (Surgery.FromResource.ObjectID == newMasterResource.ObjectID)
                            return null;
                        // İstek yapan  bölümün  yada kullanıcıya ait  bölümün bağlı olduğu branş yoksa yeni SunSurgery Başlatmasın 
                        if (Surgery.FromResource.ResourceSpecialities.Count == 0 || newMasterResource.ResourceSpecialities.Count == 0 ||
                          Surgery.FromResource.ResourceSpecialities[0].Speciality.ObjectID == newMasterResource.ResourceSpecialities[0].Speciality.ObjectID)
                            return null;
                    }
                    foreach (var subSurgery in Surgery.SubSurgeries)
                    {
                        if (subSurgery.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        {
                            if (subSurgery.FromResource.ObjectID == newMasterResource.ObjectID)
                                return null;
                            if (subSurgery.FromResource.ResourceSpecialities.Count == 0 || newMasterResource.ResourceSpecialities.Count == 0 ||
                              subSurgery.FromResource.ResourceSpecialities[0].Speciality.ObjectID == newMasterResource.ResourceSpecialities[0].Speciality.ObjectID)
                                return null;
                        }
                    }
                    //Anestezi uzmanlığı için ek ameliyat oluşturmasın
                    if(newMasterResource != null)
                    {
                        if (anesteziSpeciality != null && newMasterResource.IsSpecialityExistsInResourceSpecialities(anesteziSpeciality))
                            return null;
                    }
                    return newMasterResource;
                }
            }
            return null;
        }

        public void IfNeedFireSubSurgery()
        {
            if (Surgery.IsOldAction != true)
            {
                var newSubSurgeryMasterResource = IfNeedNewSubSurgeryGetMasterResource();
                if (newSubSurgeryMasterResource != null)
                {
                    if (Surgery.CurrentStateDefID == Surgery.States.Completed)
                    {
                        throw new Exception(TTUtils.CultureService.GetText("M27027", "Tamamlanan Ameliyata yeni Ek ameliyat oluşturacak kullanıcı eklendi . Lütfen ekranı Önce 'Kaydet' daha sonra 'Kaydet/Tamamla' butonuna basınız"));
                    }
                    SubSurgery subSurgery = new SubSurgery(Surgery, newSubSurgeryMasterResource, Personnel);
                }
            }
        }
        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            IfNeedFireSubSurgery();
            #endregion PostInsert
        }

        protected override void PostDelete()
        {
            #region PostDelete
            base.PostDelete();
            // Subsurgery silecek kod yaz
            #endregion PostDelete
        }
        #region Methods
        //public void SetHasChangedAtChildObjects(EpisodeAction myEntrySurgery)
        //{
        //    if (myEntrySurgery != null && ((ITTObject)myEntrySurgery).IsNew == false)
        //    {
        //        EpisodeAction originalMyEntrySurgery = ((ITTObject)myEntrySurgery).Original as EpisodeAction;
        //        if (originalMyEntrySurgery != null) // Henüz Insret edilmemiş EpisodeAction'ün originali null olur ki o durumda değişiklik yapıldı diye işaretlenmesine gerek yok
        //        {
        //            if (originalMyEntrySurgery.HasChangedAtChildObjects != null)
        //                myEntrySurgery.HasChangedAtChildObjects = !originalEntrySurgery.HasChangedAtChildObjects; // bu kod surgerprpcedureün personeline aitti ordan açlındı
        //            else
        //                myEntrySurgery.HasChangedAtChildObjects = true;
        //        }
        //    }


        //}

        #endregion Methods

    }
}