
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
    /// Diş Tedavi Prosedürleri Tamamlanmayanlar 
    /// </summary>
    public partial class ExcludesDentalProceduresAreCompletedTask : BaseScheduledTask
    {
        #region Methods
        public override void TaskScript()
        {
            //int counterCompleted = 0;
            //int counterPatientNoShown = 0;
            //int counterCancelled = 0;
            //int counterCancelledProvisions = 0;
            //TTObjectContext context = new TTObjectContext(false);

            //bool deleteProvision = false;

            //TTObjectContext ctx = new TTObjectContext(false);
            //List<Guid> states = new List<Guid>();
            //states.Add(DentalExamination.States.New);
            //states.Add(DentalExamination.States.Examination);

            //BindingList<DentalExamination> lst = DentalExamination.GetExcludesDentalProceduresAreCompleted(ctx, states, DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-10));
            //foreach (DentalExamination ex in lst)
            //{
            //    try
            //    {
            //        if(ex.Episode.PatientStatus == PatientStatusEnum.Inpatient)
            //            continue;

            //        if(ex is DentalConsultation)
            //        {
            //            if(ex.CurrentStateDefID == DentalConsultation.States.Examination)
            //            {
            //                if (ex.Diagnosis.Count == 0)
            //                {
            //                    ex.CurrentStateDefID = DentalConsultation.States.PatientNoShown;
            //                    counterPatientNoShown++;
            //                    deleteProvision = true;
            //                }
            //                else
            //                {
            //                    if(ex.ProcedureDoctor != null)
            //                    {
            //                        ex.CurrentStateDefID = DentalConsultation.States.Completed;
            //                        counterCompleted++;
            //                    }
            //                }
            //                if(ex.Episode.InpatientAdmissions.Count == 0)
            //                    ex.Episode.CurrentStateDefID = Episode.States.ClosedToNew;
            //            }
            //            else if(ex.CurrentStateDefID == DentalConsultation.States.New)
            //            {
            //                ex.CurrentStateDefID = DentalConsultation.States.Cancelled;
            //                counterCancelled++;
            //                deleteProvision = true;
            //            }
            //        }
            //        else
            //        {
            //            if(ex.CurrentStateDefID == DentalExamination.States.Examination)
            //            {
            //                if (ex.Diagnosis.Count == 0)
            //                {
            //                    ex.CurrentStateDefID = DentalExamination.States.PatientNoShown;
            //                    counterPatientNoShown++;
            //                    deleteProvision = true;
            //                }
            //                else
            //                {
            //                    if(ex.ProcedureDoctor != null)
            //                    {
            //                        ex.CurrentStateDefID = DentalExamination.States.Completed;
            //                        counterCompleted++;
            //                    }
            //                }
            //                if(ex.Episode.InpatientAdmissions.Count == 0)
            //                    ex.Episode.CurrentStateDefID = Episode.States.ClosedToNew;
            //            }
            //            else if(ex.CurrentStateDefID == DentalExamination.States.New)
            //            {
            //                ex.CurrentStateDefID = DentalExamination.States.Cancelled;
            //                counterCancelled++;
            //                deleteProvision = true;
            //            }
            //        }

            //if (deleteProvision && ex.Episode.IsMedulaEpisode())
            //{
            //    ex.SubEpisode.CancelSubEpisodeProtocols();
            //    counterCancelledProvisions++;
            //}
            //}
            //    catch(Exception exp)
            //    {
            //        AddLog(exp.Message);
            //    }
            //}

            //AddLog(counterCancelledProvisions.ToString() + " adet provizyon iptal edildi, " + counterCompleted.ToString() + " adet işlem tamamlandı, " + counterCancelled.ToString() + " adet işlem iptal edildi," + counterPatientNoShown.ToString() + " adet işlem hasta gelmedi olarak kapatıldı.");

            //ctx.Save();
        }

        #endregion Methods

    }
}