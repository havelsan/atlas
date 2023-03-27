
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
    /// Tıbbi/Cerrahi Uygulamaları
    /// </summary>
    public partial class ManipulationCompletedForm : EpisodeActionForm
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
#region ManipulationCompletedForm_PreScript
    base.PreScript();
#endregion ManipulationCompletedForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationCompletedForm_PostScript
    base.PostScript(transDef);
            /*if (transDef != null)
            {
                //                if(transDef.ToStateDefID==Manipulation.States.TechnicianProcedure)
                //                {
                //                    TTFormClasses.StringEntryForm frm = new TTFormClasses.StringEntryForm();
                //                    this._Manipulation.ReasonToContinue=frm.ShowAndGetStringForm("İşleme Devam Etme Sebebi");
                //                }

                if (transDef.ToStateDefID == Manipulation.States.Cancelled)
                {
                    TTFormClasses.StringEntryForm frm = new TTFormClasses.StringEntryForm();
                    this._Manipulation.ReasonOfCancel = frm.ShowAndGetStringForm("İşlem İptal Sebebi");
                }
            }*/
#endregion ManipulationCompletedForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationCompletedForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == Manipulation.States.Cancelled)
                {
                    StringEntryForm frm = new StringEntryForm();
                    _Manipulation.ReasonOfCancel = frm.ShowAndGetStringForm("İşlem İptal Sebebi");

                }
                //TODO Medula!
                //if(transDef.FromStateDefID == Manipulation.States.RequestingDoctorFromTechnicianProcedure && transDef.ToStateDefID == Manipulation.States.TechnicianProcedure)
                //{
                //    // Medula Takip İşlemleri
                //    if (_Manipulation.Episode.PatientStatus == PatientStatusEnum.Outpatient && Episode.IsMedulaEpisode(this._Manipulation.Episode) == true && _Manipulation.IsMedulaProvisionNecessaryProcedureExists() == true)
                //    {
                        
                //        if(_Manipulation.IsGunubirlikTakip == true){
                //            if (_Manipulation.MedulaProvision == null)
                //            {
                //                MedulaProvision _medulaProvision = new MedulaProvision(_Manipulation.ObjectContext);
                //                _Manipulation.SetMedulaProvisionInitalProperties(_medulaProvision);
                //                _Manipulation.MedulaProvision = _medulaProvision;
                //            }
                //            _Manipulation.GetManipulationMedulaTakip();
                //        }
                //        else
                //        {
                //            string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Tamam,&Vazgeç", "T,V","Uyarı","Uyarı","Günübirlik Takip Al alanı işaretlenmediğinden takip alınmadan işleme devam edilecektir.Devam Etmek İstiyor Musunuz?");
                //            if (result == "V")
                //            {
                //                InfoBox.Show("Takip almak için Günübirlik Takip Al alanını işaretleyip gerekli alanları doldurmalısınız.", MessageIconEnum.InformationMessage );
                //                return;
                //            }
                //        }
                //    }
                //}
            }
#endregion ManipulationCompletedForm_ClientSidePostScript

        }

#region ManipulationCompletedForm_Methods
        //        protected override void OnOkClick(TTObjectStateTransitionDef transDef)
        //        {
        //            if(transDef!=null)
        //            {
        //                if(transDef.ToStateDefID==Manipulation.States.TechnicianProcedure)
        //                {
        //                    TTFormClasses.StringEntryForm frm = new TTFormClasses.StringEntryForm();
        //                    this._Manipulation.ReasonToContinue=frm.ShowAndGetStringForm("İşleme Devam Etme Sebebi");
        //                }
        //            }
        //            base.OnOkClick(transDef);
        //        }
        
#endregion ManipulationCompletedForm_Methods
    }
}