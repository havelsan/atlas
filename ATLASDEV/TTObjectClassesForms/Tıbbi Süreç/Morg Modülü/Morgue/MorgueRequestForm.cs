
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
    /// Morg İşlemleri
    /// </summary>
    public partial class MorgueRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            cmdAutopsy.Click += new TTControlEventDelegate(cmdAutopsy_Click);
            StatisticalDeathReason.SelectedIndexChanged += new TTControlEventDelegate(StatisticalDeathReason_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            cmdAutopsy.Click -= new TTControlEventDelegate(cmdAutopsy_Click);
            StatisticalDeathReason.SelectedIndexChanged -= new TTControlEventDelegate(StatisticalDeathReason_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region MorgueRequestForm_ttbutton1_Click
   if (this._Morgue.MorgueTransplant == null || this._Morgue.MorgueTransplant.Count == 0) {
                Transplant transplant = new Transplant(this._Morgue.ObjectContext);
                transplant.DateTimeOfDeath = this._Morgue.DateTimeOfDeath;
                transplant.DoctorFixed = this._Morgue.DoctorFixed;
                transplant.SenderDoctor = this._Morgue.SenderDoctor;
                transplant.Nurse = this._Morgue.Nurse;
                transplant.MernisDeathReasons = this._Morgue.MernisDeathReasons;
                transplant.StatisticalDeathReason = this._Morgue.StatisticalDeathReason;
                transplant.ObjectsFromPatient = this._Morgue.ObjectsFromPatient;
                transplant.CurrentStateDefID = Transplant.States.Request;
                this._Morgue.MorgueTransplant.Add(transplant);
                this._Morgue.ObjectContext.Save();
                InfoBox.Show("Yeni nakil işlemi başarıyla oluşturuldu.");
            }
            else {
                if(TTVisual.ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Kayıtlı nakil bilgisi yeni bilgilerle güncellenecek. \nDevam etmek istediğinize emin misiniz?") == "E") {
                    Transplant transplant = this._Morgue.MorgueTransplant[0];
                    transplant.DateTimeOfDeath = this._Morgue.DateTimeOfDeath;
                    transplant.DoctorFixed = this._Morgue.DoctorFixed;
                    transplant.SenderDoctor = this._Morgue.SenderDoctor;
                    transplant.Nurse = this._Morgue.Nurse;
                    transplant.MernisDeathReasons = this._Morgue.MernisDeathReasons;
                    transplant.StatisticalDeathReason = this._Morgue.StatisticalDeathReason;
                    transplant.ObjectsFromPatient = this._Morgue.ObjectsFromPatient;
                    this._Morgue.ObjectContext.Save();
                    InfoBox.Show("Nakil işlemi başarıyla güncellendi.");
                }
            }
#endregion MorgueRequestForm_ttbutton1_Click
        }

        private void cmdAutopsy_Click()
        {
            #region MorgueRequestForm_cmdAutopsy_Click

            // TODO ShowEdit!
            //Yeni Patoloji İsteği başlatır
            //PathologyRequest pathology;
            //TTObjectContext objectContext = this._Morgue.ObjectContext;
            //Guid savePointGuid = objectContext.BeginSavePoint();
            //try
            //{
            //    pathology = new PathologyRequest(objectContext,this._EpisodeAction);
            //    pathology.MasterResource = this._Morgue.MasterResource;
            //    TTForm frm = TTForm.GetEditForm(pathology);
            //    if(frm.ShowEdit(this.FindForm(), pathology) == DialogResult.OK)
            //        objectContext.Save();
            //}
            //catch (Exception ex)
            //{
            //    objectContext.RollbackSavePoint(savePointGuid);
            //    InfoBox.Show(ex);
            //}
            //finally
            //{
            //    objectContext.Dispose();
            //}
            var a = 1;
            #endregion MorgueRequestForm_cmdAutopsy_Click
        }

        private void StatisticalDeathReason_SelectedIndexChanged()
        {
#region MorgueRequestForm_StatisticalDeathReason_SelectedIndexChanged
   if(this._Morgue.StatisticalDeathReason==TTObjectClasses.StatisticalDeathReason.DeadBirth)
            {                    
                bool deadBirth = false;
                foreach(EpisodeAction ea in this._Morgue.Episode.EpisodeActions)
                {
                    if(ea is BirthReport)
                    {
                        deadBirth= true;
                        break;
                    }
                }
                if(!deadBirth)
                {
                    this.StatisticalDeathReason.SelectedItem=null;
                    InfoBox.Show("Bu ölüm sebebini yanlızca ölü doğan bebekler için seçebilirsiniz.");
                }
            }
#endregion MorgueRequestForm_StatisticalDeathReason_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region MorgueRequestForm_PreScript
    this.DropStateButton(Morgue.States.Cancelled);
            base.PreScript();
            
     
            if(this._Morgue.StatisticalDeathReason==TTObjectClasses.StatisticalDeathReason.DeadBirth)
                this.StatisticalDeathReason.ReadOnly=true;
#endregion MorgueRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MorgueRequestForm_PostScript
    base.PostScript(transDef);
#endregion MorgueRequestForm_PostScript

            }
                }
}