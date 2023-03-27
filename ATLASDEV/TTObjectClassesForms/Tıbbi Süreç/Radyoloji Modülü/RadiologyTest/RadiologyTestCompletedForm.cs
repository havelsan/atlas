
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
    /// Radyoloji Test Sonuç Formu
    /// </summary>
    public partial class RadiologyTestCompletedForm : RadiologyTestBaseForm
    {
        override protected void BindControlEvents()
        {
            cmdImage.Click += new TTControlEventDelegate(cmdImage_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdImage.Click -= new TTControlEventDelegate(cmdImage_Click);
            base.UnBindControlEvents();
        }

        private void cmdImage_Click()
        {
#region RadiologyTestCompletedForm_cmdImage_Click
   string accessionNoStr = this._RadiologyTest.AccessionNo.ToString();
            string patientIdStr = this._RadiologyTest.EpisodeAction.Episode.Patient.ID.ToString();
            TTFormClasses.CommonForm.ShowPacsViewer(patientIdStr, accessionNoStr);
#endregion RadiologyTestCompletedForm_cmdImage_Click
        }

        protected override void PreScript()
        {
#region RadiologyTestCompletedForm_PreScript
    //            if(this._RadiologyTest.CurrentStateDefID == RadiologyTest.States.Completed && !(TTUser.CurrentUser.IsSuperUser || TTUser.CurrentUser.IsPowerUser))
            //            {               
            //                bool hcFound  = false;
            //                foreach (TTUserRole role in TTUser.CurrentUser.Roles)
            //                {
            //                    if (role.Name == "Sağlık Kurulu Başkanı" || role.Name == "Sağlık Kurulu Yazıcısı")
            //                    {
            //                        foreach(EpisodeAction ea in this._RadiologyTest.Episode.EpisodeActions)
            //                        {
            //                            if(ea is HealthCommittee)
            //                            {
            //                                hcFound = true;
            //                                break;
            //                            }
            //                        }
            //                        if(!hcFound)
            //                            throw new Exception("Sağlık Kurulu işlemi olmayan bir vakada \"Radyoloji Test Sonuç Formu\"na erişim yetkiniz bulunmamaktadır.");
            //                        break;
            //                    }
            //                }                
            // 

            ((TTTabControl)TabPageInfo).TabPages[0].BackColor = System.Drawing.Color.FromArgb(239, 235, 222);
            ((TTTabControl)TabPageInfo).TabPages[1].BackColor = System.Drawing.Color.FromArgb(239, 235, 222);

            foreach (ITTTabPage tabPage in TabPageInfo.TabPages)
            {
                if (tabPage.Visible == false)
                    TabPageInfo.HideTabPage(tabPage);
            }
#endregion RadiologyTestCompletedForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region RadiologyTestCompletedForm_PostScript
    //            foreach( RadiologyMaterial rm in this._RadiologyTest.Materials)
            //            {
            //                if(rm.Episode != null )
            //                { rm.Episode = this._RadiologyTest.Episode;}
            //                
            //                
            //            }
#endregion RadiologyTestCompletedForm_PostScript

            }
            
#region RadiologyTestCompletedForm_Methods
        public Dictionary<Guid, TTObjectStateTransitionDef> nextTransitions;
        public TTForm parentform;
        public TTUnboundForm Uparentform;

        //unbound form için
        public TTGrid OwnerTestGrid;
        public Int32 tgSelectedRowIndex;
        public string OwnerTypeX;




        public RadiologyTestCompletedForm(TTObject ttObject, TTForm ParentForm)
            : this()
        {
            //   RadiologyTestCompletedForm();

            //this.Dock = DockStyle.Fill;
            this.TopLevel = false;
            this.Visible = true;
            this.FormBorderStyle = FormBorderStyle.None;

            DoBindings(ttObject);
        }



        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);

            OwnerTypeX = _RadiologyTest.OwnerType;
            this.OwnerType.Visible = false;


            if (OwnerTypeX == "TTUnboundForm")
            {

                OwnerTestGrid = ((TTGrid)((TTGroupBox)Owner.Controls["ttgroupbox2"]).Controls["TestGrid"]);
                tgSelectedRowIndex = Convert.ToInt32(((TTTextBox)Owner.Controls["tgSelectedRow"]).Text);

            }
        }

        protected override void OnCancelClick()
        {
            this.Close();
        }

        private void stepBtn_ClickOnPanel(object sender, EventArgs e)
        {
            TTObjectStateTransitionDef transDef = (TTObjectStateTransitionDef)((Button)sender).Tag;
            //  _RadiologyTest.CurrentStateDef = transDef.ToStateDef;
            OnOkClick(transDef);
        }

        private void FillNextTransitionsOnPanel()
        {
            nextTransitions = new Dictionary<Guid, TTObjectStateTransitionDef>();
            if (_RadiologyTest.CurrentStateDef == null)
                return;

            foreach (TTObjectStateTransitionDef transDef in _RadiologyTest.CurrentStateDef.OutgoingTransitions)
            {
                if (TTUser.CurrentUser.HasRight(transDef, _RadiologyTest, (int)TTSecurityAuthority.RightsEnum.Transition))
                { nextTransitions.Add(transDef.StateTransitionDefID, transDef); }
            }
        }
        
#endregion RadiologyTestCompletedForm_Methods
    }
}