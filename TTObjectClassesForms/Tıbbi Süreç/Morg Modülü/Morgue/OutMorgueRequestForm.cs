
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
    public partial class OutMorgueRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            cmdAutopsy.Click += new TTControlEventDelegate(cmdAutopsy_Click);
            StatisticalDeathReason.SelectedIndexChanged += new TTControlEventDelegate(StatisticalDeathReason_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdAutopsy.Click -= new TTControlEventDelegate(cmdAutopsy_Click);
            StatisticalDeathReason.SelectedIndexChanged -= new TTControlEventDelegate(StatisticalDeathReason_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void cmdAutopsy_Click()
        {
            #region OutMorgueRequestForm_cmdAutopsy_Click
            //TODO:ShowEdit!
            ////Yeni Patoloji İsteği başlatır
            //PathologyRequest pathology;
            //TTObjectContext objectContext = new TTObjectContext(false);
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
#endregion OutMorgueRequestForm_cmdAutopsy_Click
        }

        private void StatisticalDeathReason_SelectedIndexChanged()
        {
#region OutMorgueRequestForm_StatisticalDeathReason_SelectedIndexChanged
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
#endregion OutMorgueRequestForm_StatisticalDeathReason_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region OutMorgueRequestForm_PreScript
    this.DropStateButton(Morgue.States.Cancelled); 
            this.PatientName.Text = this._Morgue.FullPatientName;
            if(this._Morgue.StatisticalDeathReason==TTObjectClasses.StatisticalDeathReason.DeadBirth)
                this.StatisticalDeathReason.ReadOnly=true;
#endregion OutMorgueRequestForm_PreScript

            }
                }
}