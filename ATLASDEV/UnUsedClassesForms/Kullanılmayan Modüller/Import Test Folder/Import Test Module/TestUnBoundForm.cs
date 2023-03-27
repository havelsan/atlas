
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// New Unbound Form
    /// </summary>
    public partial class TestUnBoundForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            CreateSubEpisode.Click += new TTControlEventDelegate(CreateSubEpisode_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            CreateSubEpisode.Click -= new TTControlEventDelegate(CreateSubEpisode_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void CreateSubEpisode_Click()
        {
#region TestUnBoundForm_CreateSubEpisode_Click
   string error = "";
            int count = 0;
            if (this.dtStartDate.NullableValue == null)
                throw new Exception("Başlangış tarihi boş olamaz");
            if (this.dtEndDate.NullableValue == null)
                throw new Exception("Bitiş tarihi boş olamaz");
            
            TTObjectContext roContext = new TTObjectContext(true);
            BindingList<Episode> episodeList = Episode.GetByOpeningDate(roContext,(DateTime)this.dtStartDate.NullableValue,(DateTime)this.dtEndDate.NullableValue);
            
            foreach(Episode roepisode in episodeList)
            {
                TTObjectContext objectContext =new TTObjectContext(false);
                try
                {
                    Episode episode = (Episode)objectContext.GetObject(roepisode.ObjectID,roepisode.ObjectDef);
                    BindingList<EpisodeAction> eaList = EpisodeAction.GetByEpisodeOrderByRequestDate(objectContext,episode.ObjectID);
                    bool firstEA = true;
                    foreach (EpisodeAction ea in eaList)
                    {
                        if(!(firstEA == true && ea is PatientAdmissionCorrection))
                        {
                            ea.IgnoreEpisodeStateOnUpdate = true;
                            if(ea.CurrentStateDef.Status != StateStatusEnum.Cancelled )
                            {
                                if(ea.IsAttributeExists(typeof(CreateSubEpisodeAttribute)) || firstEA) // eğer kendisi  yeni sub episode açacaksa
                                {

                                    // CreateSubEpisodeAttribute

                                    Boolean createSubEpisode = true;
                                    
                                    // hasta kabul düzeltmede starterEpisode boş gelir yeni subepisode açılmaz
                                    if (ea != null )
                                    {
                                        if(ea.CurrentStateDef.Status == StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                                            createSubEpisode = false;
                                        if (ea.SubEpisode != null && ea.SubEpisode.CurrentStateDefID != SubEpisode.States.Cancelled)
                                        {
                                            if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
                                            {
                                                SubEpisode LastOpenSub=null;
                                                
                                                foreach (SubEpisode subOldEpisode in ea.Episode.SubEpisodes)
                                                {
                                                    if(ea.SubEpisode== null || ea.SubEpisode.ObjectID != subOldEpisode.ObjectID)
                                                    {
                                                        if (subOldEpisode.OpeningDate < ea.SubEpisode.OpeningDate && subOldEpisode.CurrentStateDefID == SubEpisode.States.Opened)
                                                        {
                                                            subOldEpisode.Close(ea.RequestDate);
                                                            LastOpenSub = subOldEpisode;
                                                        }
                                                        
                                                    }
                                                }
                                                if(ea.SubEpisode.OldSubEpisode == null)
                                                    ea.SubEpisode.OldSubEpisode= LastOpenSub;
                                            }
                                            createSubEpisode = false;// işlem geri alındı ve ilerletiliyorsa ve daha önce SubEpisodeu atandıysa tekrar atnamamsı için
                                        }
                                        
                                        if (createSubEpisode)
                                        {
                                            // Set edilme sıraları önemli
                                            SubEpisode subEpisode = new SubEpisode(objectContext);
                                            //subEpisode.AddSubEpisodeProtocol(null, true, false, true);
                                            subEpisode.OldSubEpisode = ea.GetMyProperOpenedSubEpisode();// Cancel durumları için eğer varsa bir önceki Subepisodeu set eder o yüzden subEpisodun Episodu set edilmedien önce set edilmeli
                                            SubEpisode LastOpenSub=null;
                                            if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
                                            {
                                                
                                                foreach (SubEpisode subOldEpisode in ea.Episode.SubEpisodes)
                                                {
                                                    if(ea.SubEpisode== null || ea.SubEpisode.ObjectID != subOldEpisode.ObjectID)
                                                    {
                                                        if (subOldEpisode.OpeningDate < ea.SubEpisode.OpeningDate && subOldEpisode.CurrentStateDefID == SubEpisode.States.Opened)
                                                        {
                                                            subOldEpisode.Close(ea.RequestDate);
                                                            LastOpenSub = subOldEpisode;
                                                        }
                                                    }
                                                }
                                            }
                                            subEpisode.Episode = ea.Episode;
                                            subEpisode.OpeningDate = ea.RequestDate;
                                            subEpisode.ClosingDate = null;
                                            subEpisode.CurrentStateDefID = SubEpisode.States.Opened;
                                            subEpisode.PatientStatus = SubEpisodeStatusEnum.Outpatient;
                                            subEpisode.ResSection = ea.GetSubEpisodeResSection();
                                            subEpisode.Speciality = ea.GetSubEpisodeSpeciality();
                                            subEpisode.GetAndSetNextProtocolNo();
                                            subEpisode.Episode = ea.Episode;
                                            subEpisode.StarterEpisodeAction = ea;
                                            
                                            
                                            foreach(EpisodeAction lea in ea.LinkedActions)// Kabulde başlatılan tüm  işlemleri için yada Başlatan episode actıonın alt alt işlemlerinin Subepisodeunu set eder
                                            {
                                                lea.IgnoreEpisodeStateOnUpdate = true;
                                                if(lea.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                                                    lea.SubEpisode = subEpisode;
                                            }
                                            if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
                                            {
                                                
                                                if (((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission != null && ((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission is InpatientAdmission)
                                                {
                                                    ((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission.IgnoreEpisodeStateOnUpdate=true;
                                                    if(((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission.CurrentStateDef.Status != StateStatusEnum.Cancelled) // Cancel Objelerde Property Set edilebildiğinde silisin
                                                        ((InPatientTreatmentClinicApplication)ea).BaseInpatientAdmission.SubEpisode = subEpisode;
                                                    
                                                }
                                            }
                                            if(ea != null)// başlatan işlemin subactionlarının SubEpisode'unu set  eder
                                            {
                                                ea.SubEpisode = subEpisode;
                                            }
                                            if (ea is InPatientTreatmentClinicApplication)// Aynı episodedaki diğer SubEpisodları kapatır.
                                            {
                                                if(ea.SubEpisode.OldSubEpisode == null)
                                                    ea.SubEpisode.OldSubEpisode= LastOpenSub;
                                            }
                                        }
                                    }
                                    firstEA = false;
                                    //CreateSubEpisodeAttribute
                                }
                                else if(ea.SubEpisode == null)
                                {
                                    if(ea.MasterAction != null && ea.MasterAction is EpisodeAction && ((EpisodeAction)ea.MasterAction).SubEpisode != null )
                                        ea.SubEpisode=((EpisodeAction)ea.MasterAction).SubEpisode;// eğer master actıonı varsa direk onun Subepisodunu alır
                                    else
                                        ea.SetMyProperOpenedSubEpisode(episode,false);// Episode değiştirme yapılınca yeni episodedaki subepisodu alması için false yapıldı
                                }
                            }
                        }
                    }
                    count++;
                    objectContext.Save();
                    objectContext.Dispose();
                }
                catch (Exception ex)
                {
                    error += "," + roepisode.HospitalProtocolNo;
                    StringBuilder sb = new StringBuilder(512);
                    sb.Append(roepisode.HospitalProtocolNo + ":");
                    sb.Append(ex.Message);
                    System.IO.File.AppendAllText("C:\\TEMP\\WSLOG\\SETSUBEPISODE.TXT", sb.ToString() + "\r\n");
                }
                
            }
            InfoBox.Show(count + " adet vaka alt vakaları atandı .Atanamayan Vaka Protokol Numaraları : \r\n " + error);
#endregion TestUnBoundForm_CreateSubEpisode_Click
        }

        private void ttbutton1_Click()
        {
#region TestUnBoundForm_ttbutton1_Click
   TTObjectContext context = new TTObjectContext(false);
            try
            {
                
                foreach (BaseScheduledTask baseScheduledTask in BaseScheduledTask.GetAvailableTasks(context))
                {
                    if( baseScheduledTask is CancelUnacceptedInpAdm)
                    {
                        baseScheduledTask.TaskScript();
                        context.Save();
                        break;
                    }

                }
            }
            finally
            {
                context.Dispose();
            }
#endregion TestUnBoundForm_ttbutton1_Click
        }
    }
}