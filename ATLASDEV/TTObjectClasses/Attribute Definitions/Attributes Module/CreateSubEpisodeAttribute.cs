
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
    public partial class CreateSubEpisodeAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            //            Boolean createSubEpisode = true;
//            EpisodeAction starterEpisodeAction = Interface.SubEpisodeStarterEpisodeAction;
//            
//            // hasta kabul düzeltmede CreateSubEpisode false gelir yeni subepisode açılmaz
//            if(starterEpisodeAction != null && Interface.CreateSubEpisode != false)
//            {
//                SubEpisode properSubEpisode = starterEpisodeAction.GetMyProperOpenedSubEpisode();
//                
//                if(starterEpisodeAction.CurrentStateDef.Status == StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
//                    createSubEpisode = false;
//                else if (starterEpisodeAction.SubEpisode != null && starterEpisodeAction.SubEpisode.CurrentStateDefID != SubEpisode.States.Cancelled && starterEpisodeAction.SubEpisode.StarterEpisodeAction!= null && starterEpisodeAction.SubEpisode.StarterEpisodeAction.ObjectID == starterEpisodeAction.ObjectID)
//                {
//                    createSubEpisode = false;// işlem geri alındı ve ilerletiliyorsa ve daha önce SubEpisodeu atandıysa tekrar atnamamsı için
//                }
//                if(Interface.SubEpisodeCreatedByEpisode == null)// Hasta Kabul Harici durumlarda uzmanlık dalına göre Sub episode başlatııp başlatılmayacağına bakılır
//                {
//                    if (starterEpisodeAction.Episode != null && Interface.SubEpisodeSpeciality != null) {
//                        String[] brans = null;
//                        String tedaviTipi = null;
//                        String tedaviTuru = "Y";
//
//                        
//                        if ("4300".Equals(Interface.SubEpisodeSpeciality.Code)) {
//                            brans = new String[]{ "4300" };
//                            tedaviTipi = "7";
//                        }
//                        else if ("1062".Equals(Interface.SubEpisodeSpeciality.Code)) {
//                            brans = new String[]{ "1062" };
//                            tedaviTipi = "1";
//                        }
//                        else if ("1800".Equals(Interface.SubEpisodeSpeciality.Code) || "4000".Equals(Interface.SubEpisodeSpeciality.Code) || "600".Equals(Interface.SubEpisodeSpeciality.Code)) {
//                            brans = new String[]{ "1800", "4000", "600" };
//                            tedaviTipi = "2";
//                        }
//                        if (brans != null)
//                        {
//                            if (!Common.IsSubEpisodeNeeded(starterEpisodeAction.Episode, brans , tedaviTipi, tedaviTuru))
//                                createSubEpisode = false;
//                            if (!Common.IsSubEpisodeNeeded(starterEpisodeAction.Episode, brans , tedaviTipi, "G"))
//                                createSubEpisode = false;
//                        }
//                    }
//                }
//                
//                
//                /* Medula geliştirmelerinde kapatıldı, gerekirse tekrar açılacak )
//                else if(Interface.DontCreateNewSubEpisodeUseOld(properSubEpisode) == true)// başlatılan işlemin niteliğine göre subepisode yaratılıp yaratılmayacağını bulur...
//                {
//                    createSubEpisode = false;
//                    if(starterEpisodeAction.SubEpisode == null ) // kendisi
//                        starterEpisodeAction.SubEpisode = properSubEpisode;
//                }
//                 */
//                if (createSubEpisode)
//                {
//                    // Set edilme sıraları önemli
//                    SubEpisode subEpisode = null;
//                    // Set edilme sıraları önemli
//                    if (Interface.SubEpisodeCreatedByEpisode == null)
//                    {
//                        subEpisode = new SubEpisode(this.ObjectContext);
//                    }
//                    else
//                    {
//                        subEpisode = Interface.SubEpisodeCreatedByEpisode;// Created SubEpisode'un dolu olma durumu yanlızca Hasta kabulde Episode Create edilirken mümkün o durmdada OlsSubEpisode olmamalı
//                    }
//                    
//                    if( subEpisode.ObjectID != properSubEpisode.ObjectID)//SubEpisodeCreatedByEpisode dolu olduğu durumlarda ikisi aynı olabilir
//                        subEpisode.OldSubEpisode = properSubEpisode;// Cancel durumları için eğer varsa bir önceki Subepisodeu set eder o yüzden subEpisodun Episodu set edilmedien önce set edilmeli
//                    if(this.CloseOtherSubEpisodes == true)// Aynı episodedaki diğer SubEpisodları kapatır.
//                    {
//                        foreach (SubEpisode subOldEpisode in Interface.Episode.SubEpisodes)
//                        {
//                            if (subEpisode.ObjectID != subOldEpisode.ObjectID)// Hasta Kabulde Yaratılmış ve SubEpisodeCreatedByEpisode olarak gelen Episode Kapatılmasın diye
//                            {
//                                if (subOldEpisode.CurrentStateDefID == SubEpisode.States.Opened)
//                                {
//                                    subOldEpisode.Close(Common.RecTime());
//                                }
//                            }
//                        }
//                    }
//                    subEpisode.Episode = Interface.Episode;
//                    subEpisode.OpeningDate = Common.RecTime();
//                    subEpisode.ClosingDate = null;
//                    //subEpisode.CurrentStateDefID = SubEpisode.States.Opened;
//                    subEpisode.PatientStatus = Interface.SubEpisodePatientStatus;
//                    subEpisode.ResSection = Interface.SubEpisodeResSection;
//                    
//                    /* 
//                     * Spor hekimliği yada hidroklimatoloji den FTR ye kayıt açılıyorsa branş ı FTR yapma, ilk takip ne ise öyle kalsın.
//                     */
//                    if (Interface.SubEpisodeSpeciality != null && "1800".Equals(Interface.SubEpisodeSpeciality.Code) && starterEpisodeAction.Episode != null && starterEpisodeAction.Episode.MainSpeciality != null && ("4000".Equals(starterEpisodeAction.Episode.MainSpeciality.Code) || "600".Equals(starterEpisodeAction.Episode.MainSpeciality.Code))) {
//                        subEpisode.Speciality = starterEpisodeAction.Episode.MainSpeciality;
//                    }
//                    else
//                        subEpisode.Speciality = Interface.SubEpisodeSpeciality;
//                    
//                    subEpisode.GetAndSetNextProtocolNo();
//                    subEpisode.Episode = Interface.Episode;
//                    subEpisode.StarterEpisodeAction = starterEpisodeAction;
//                    
//                    
//                    foreach(EpisodeAction ea in Interface.LinkedEpisodeActionsForSubEpisode)// Kabulde başlatılan tüm  işlemleri için yada Başlatan episode actıonın alt alt işlemlerinin Subepisodeunu set eder
//                    {
//                        if(ea.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
//                            ea.SubEpisode = subEpisode;
//                    }
//                    if(starterEpisodeAction != null)// başlatan işlemin subactionlarının SubEpisode'unu set  eder
//                    {
//                        starterEpisodeAction.SubEpisode = subEpisode;
//                    }
//                    
//                    // MedulaProvision ın SubEpisode u set edilir
//                    MedulaProvision medulaProvision = Interface.MedulaProvision;
//                    if(medulaProvision != null)
//                        medulaProvision.SubEpisode = subEpisode;
//                    
//
//                    
//                }
//            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}