
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
    /// Bulaşıcı/Bildirimi Zorunlu Hastalık Bilgileri 
    /// </summary>
    public partial class InfectiousIllnesesInformationForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            NotAlive.CheckedChanged += new TTControlEventDelegate(NotAlive_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            NotAlive.CheckedChanged -= new TTControlEventDelegate(NotAlive_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void NotAlive_CheckedChanged()
        {
#region InfectiousIllnesesInformationForm_NotAlive_CheckedChanged
   if (this.NotAlive.Value == true)
            {
                this.DeathTime.ReadOnly = false;
            }
            else
            {
                this.DeathTime.Text = null;
                this.DeathTime.ReadOnly = true;
            }
#endregion InfectiousIllnesesInformationForm_NotAlive_CheckedChanged
        }

        protected override void PreScript()
        {
#region InfectiousIllnesesInformationForm_PreScript
    base.PreScript();
            SetProcedureDoctorAsCurrentResource();
            if (this._InfectiousIllnesesInformation.InfectiousIllnesesDiagnosis != null)
                this.InfectiousIllnesesDiagnosis.ReadOnly = true;
            else
                this.DropStateButton(InfectiousIllnesesInformation.States.Cancelled);
#endregion InfectiousIllnesesInformationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region InfectiousIllnesesInformationForm_PostScript
    if (transDef != null)
            {
                if (transDef.ToStateDefID == InfectiousIllnesesInformation.States.Cancelled)
                {
                    if (this._InfectiousIllnesesInformation.InfectiousIllnesesDiagnosis != null)
                    {
                        foreach (DiagnosisGrid diagnosis in this._InfectiousIllnesesInformation.Episode.Diagnosis)
                        {
                            
                            if (diagnosis.Diagnose.ObjectID == this._InfectiousIllnesesInformation.InfectiousIllnesesDiagnosis.ObjectID)
                            {
                                if (diagnosis.EpisodeAction != null)
                                {
                                    //InfoBox.Show(diagnosis.EpisodeAction.ActionDate + " tarihli " + diagnosis.EpisodeAction.ObjectDef.Description + " işleminde '" + diagnosis.Diagnose.Code + " " + diagnosis.Diagnose.Name + "' tanısı girilmiştir. \r\nBu tanı kaldırılmadan işlem iptal edilemez.");
                                    throw new Exception(diagnosis.EpisodeAction.ActionDate + " tarihli " + diagnosis.EpisodeAction.ObjectDef.Description + " işleminde " + diagnosis.Diagnose.Code + " " + diagnosis.Diagnose.Name + " tanısı girilmiş. Bu tanı kaldırılmadan işlem iptal edilemez.");
                                }
                                else if (diagnosis.SubactionProcedure != null)
                                {
                                    //InfoBox.Show(diagnosis.SubactionProcedure.ActionDate + " tarihli " + diagnosis.SubactionProcedure.ObjectDef.Description + " işleminde '" + diagnosis.Diagnose.Code + " " + diagnosis.Diagnose.Name + "' tanısı girilmiştir. \r\nBu tanı kaldırılmadan işlem iptal edilemez.");
                                    throw new Exception(diagnosis.SubactionProcedure.ActionDate + " tarihli " + diagnosis.SubactionProcedure.ObjectDef.Description + " işleminde " + diagnosis.Diagnose.Code + " " + diagnosis.Diagnose.Name + " tanısı girilmiş. Bu tanı kaldırılmadan işlem iptal edilemez.");
                                }
                            }
                        }
                    }
                }
                else if(transDef.ToStateDefID == InfectiousIllnesesInformation.States.Completed)
                {
                    if(String.IsNullOrEmpty(this.IllnesesName.Text) == true)
                        throw new Exception("Hastalığın Adı boş geçilemez.");
                    
                    if(this.SKRSVakaTipi.SelectedValue == null)
                        throw new Exception("Teşhis durumu boş geçilemez.");
                    
                    if(this.ProcedureDoctor.SelectedValue == null)
                        throw new Exception("Tabip boş geçilemez.");
                }
            }
            base.PostScript(transDef);
#endregion InfectiousIllnesesInformationForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region InfectiousIllnesesInformationForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion InfectiousIllnesesInformationForm_ClientSidePostScript

        }
    }
}