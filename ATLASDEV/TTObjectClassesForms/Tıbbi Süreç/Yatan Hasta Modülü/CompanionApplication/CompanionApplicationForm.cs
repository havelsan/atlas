
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
    /// Refakatçi İşlemleri
    /// </summary>
    public partial class CompanionApplicationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region CompanionApplicationForm_PreScript
    base.PreScript();
  
            // Hasta Yatış işlemi kontrol edilir ve refakatçi işlemi ile relation ı yapılır
            //if(this._CompanionApplication.CurrentStateDefID == CompanionApplication.States.Request)
            //{
            //    if(this._CompanionApplication.Episode.PatientStatus == PatientStatusEnum.Outpatient)
            //        throw new Exception("Ayaktan hastaya Refakatçi işlemi başlatılamaz.");
                
            //    foreach (InpatientAdmission ia in this._CompanionApplication.Episode.InpatientAdmissions)
            //    {
            //        if(ia.CurrentStateDef.Status != StateStatusEnum.Cancelled)
            //        {
            //            this._CompanionApplication.InpatientAdmission = ia;
            //            break;
            //        }
            //    }
                
            //   // this.ttdatetimepicker4.ReadOnly = true;
                
            //    if(this._CompanionApplication.InpatientAdmission == null)
            //        throw new Exception("Vakada aktif Hasta Yatış işlemi bulunamadı.");
            //}
            //else if(this._CompanionApplication.CurrentStateDefID == CompanionApplication.States.Active)
            //    this.DropStateButton(CompanionApplication.States.ExCompanion);
            //if(this._CompanionApplication.CurrentStateDefID == CompanionApplication.States.SendToDoctor)
            //    this.ttdatetimepicker4.ReadOnly = true;
#endregion CompanionApplicationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CompanionApplicationForm_PostScript
    base.PostScript(transDef);
            
            if(this._CompanionApplication.TransDef != null && this._CompanionApplication.TransDef.ToStateDefID == CompanionApplication.States.Active)
            {

                if(this._CompanionApplication.RequestDate == null)
                    throw new Exception("Kalma Başlangıç Tarihi boş olamaz!");
                //if (this._CompanionApplication.Episode.QuarantineInPatientDate.Value.Date > this._CompanionApplication.RequestDate.Value.Date)
                //    throw new Exception("Kalma Başlangıç Tarihi, hasta yatış tarihinden önce olamaz!");

                if (this._CompanionApplication.RequestDate.Value.Date >= this._CompanionApplication.EndDate.Value.Date)
                    throw new Exception("Kalma Bitiş Tarihi, Kalma Başlangıç Tarihi Tarihinden büyük olmalıdır!");            
                
            }
            
            
            
            
            // Request -> SendDoctor adımına geçerken bu tarih kontrolü yapılacak!
            //            if(this._CompanionApplication.CurrentStateDef.StateDefID == CompanionApplication.States.Request && this._CompanionApplication.TransDef.ToStateDefID == CompanionApplication.States.SendToDoctor)
            //            {
            //                if(_CompanionApplication.Episode.HasAnyCompanionApplicationWithSameDateInterval(this._CompanionApplication.RequestDate.Value.Date,this._CompanionApplication.EndDate.Value.Date) == true)
            //                    throw new Exception("Aynı tarih aralığında olan Refakatçi işlemi bulunmaktadır. Tarihleri kontrol ediniz!");
            //            }
#endregion CompanionApplicationForm_PostScript

            }
            
#region CompanionApplicationForm_Methods

        
#endregion CompanionApplicationForm_Methods
    }
}