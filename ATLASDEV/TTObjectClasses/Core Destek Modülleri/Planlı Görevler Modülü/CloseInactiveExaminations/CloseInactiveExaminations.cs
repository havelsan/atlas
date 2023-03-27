
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
    /// Hasta Gelmeyen Muayeneleri Kapatma
    /// </summary>
    public  partial class CloseInactiveExaminations : BaseScheduledTask
    {
#region Methods
        public override void TaskScript()
        {
            TTObjectContext ctx = new TTObjectContext(false);
            //BindingList<PatientExamination> lst = PatientExamination.InactiveExaminationsNQL(ctx, DateTime.Now.AddDays(-10),PatientExamination.States.New);
            BindingList<PatientExamination> lst = PatientExamination.InactiveExaminationsNQL(ctx, DateTime.Now.AddDays(-10), PatientExamination.States.Examination);
            foreach (PatientExamination pex in lst)
            {
                try
                {
                    ctx = new TTObjectContext(false);
                    //if (pex.CurrentStateDefID.Value == PatientExamination.States.New)
                    if (pex.CurrentStateDefID.Value == PatientExamination.States.Examination)
                        pex.CurrentStateDefID = PatientExamination.States.PatientNoShown;
                    ctx.Save();
                    ctx.Dispose();
                }
                catch(Exception ex)
                {
                    AddLog(ex.Message);
                }
            }
            
            
        }
        
#endregion Methods

    }
}