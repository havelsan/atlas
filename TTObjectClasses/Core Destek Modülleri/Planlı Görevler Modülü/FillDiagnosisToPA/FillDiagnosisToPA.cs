
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
    public  partial class FillDiagnosisToPA : BaseScheduledTask
    {
#region Methods
        TTObjectContext context = new TTObjectContext(false);
        bool added = false;
        public override void TaskScript()
        {
            //DateTime startDate = DateTime.ParseExact("2015-08-17", "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            //DateTime endDate = ((DateTime)TTObjectClasses.Common.RecTime());
            //IBindingList PEs = PatientExamination.GetPANoDiagnose(context, startDate, endDate);
            
            //foreach (PatientExamination.GetPANoDiagnose_Class peQuery in PEs)
            //{
            //    try
            //    {
            //        if (peQuery.ObjectID != null)
            //        {
            //            Guid g = new Guid(peQuery.ObjectID.ToString());
            //            PatientExamination pe = (PatientExamination)context.GetObject( g, typeof(PatientExamination));
            //            if (pe.Episode.MainSpeciality != null )
            //            {
            //                BindingList<ExaminationInfoByBrans> examinations = ExaminationInfoByBrans.GetExaminationsBypatientAndBrans(context, pe.Episode.Patient.ObjectID, pe.Episode.MainSpeciality.ObjectID, DateTime.MinValue, DateTime.MaxValue);
                            
            //                if (examinations != null && examinations.Count > 0)
            //                {
            //                    List<DiagnosisGrid> episodeDiags = new List<DiagnosisGrid>();
            //                    episodeDiags.AddRange(examinations[0].DiagnosisGrid);

            //                    foreach (DiagnosisGrid diagnose in episodeDiags)
            //                    {
            //                        DiagnosisGrid d = new DiagnosisGrid(context);
            //                        d.Diagnose =diagnose.Diagnose;
            //                        d.AddToHistory = false;
            //                        d.IsMainDiagnose = false;
            //                        d.EpisodeAction = pe;
            //                        d.Episode = pe.Episode;
            //                        pe.Diagnosis.Add(d);
            //                        added = true;
            //                    }
            //                }
            //            }
                        
            //            if (added == false)
            //            {
            //                DiagnosisInEpisode(pe);
            //            }
                        
            //            if (added == false)
            //            {
            //                DiagnosisInSameSpecialty(pe);
            //            }
            //        }
            //        if(added)
            //            context.Save();
                    
            //        added = false;
            //        // context.Dispose();
            //    }
            //    catch (Exception ex)
            //    {
            //        AddLog(ex.Message);
            //    }
            //}
        }
        
        //public void DiagnosisInEpisode(PatientExamination pe)
        //{
        //    BindingList<Episode.GetDiagnosisByPatientExamination_Class> episodes = Episode.GetDiagnosisByPatientExamination(context, pe.ObjectID);
        //    if(episodes.Count > 0)
        //    {
        //        if(episodes[0].ObjectID != null)
        //        {
        //            Guid episodeg = new Guid(episodes[0].ObjectID.ToString());
        //            Episode episode = (Episode)context.GetObject( episodeg, typeof(Episode));
        //            List<DiagnosisGrid> episodeDiags = new List<DiagnosisGrid>();
        //            episodeDiags.AddRange(episode.Diagnosis);
                    
        //            foreach(DiagnosisGrid diagnose in episodeDiags)
        //            {
        //                DiagnosisGrid d = new DiagnosisGrid(context);
        //                d.Diagnose =diagnose.Diagnose;
        //                d.AddToHistory = false;
        //                d.IsMainDiagnose = false;
        //                d.EpisodeAction = pe;
        //                d.Episode = pe.Episode;
        //                pe.Diagnosis.Add(d);
        //                added = true;
        //            }
        //        }
        //    }
        //}
        
        //public void DiagnosisInSameSpecialty(PatientExamination pe)
        //{
        //    BindingList<PatientExamination> peList = null;
        //    if( pe.Episode.MainSpeciality != null)
        //        peList = PatientExamination.GetPEByPatientAndMainSpecialty(context, pe.Episode.Patient.ObjectID, pe.Episode.MainSpeciality.ObjectID);
        //    else if(pe.Episode.AdmissionResource != null)
        //        peList = PatientExamination.GetPEByPatientAndAdmissionResource(context, pe.Episode.Patient.ObjectID, pe.Episode.AdmissionResource);
        //    if (peList != null && peList.Count > 0)
        //    {
        //        List<DiagnosisGrid> episodeDiags = new List<DiagnosisGrid>();
        //        episodeDiags.AddRange(peList[0].Diagnosis);
        //        foreach (DiagnosisGrid diagnose in episodeDiags)
        //        {
        //            DiagnosisGrid d = new DiagnosisGrid(context);
        //            d.Diagnose =diagnose.Diagnose;
        //            d.AddToHistory = false;
        //            d.IsMainDiagnose = false;
        //            d.EpisodeAction = pe;
        //            d.Episode = pe.Episode;
        //            pe.Diagnosis.Add(d);
        //            added = true;
        //        }

        //    }
        //}
        
#endregion Methods

    }
}