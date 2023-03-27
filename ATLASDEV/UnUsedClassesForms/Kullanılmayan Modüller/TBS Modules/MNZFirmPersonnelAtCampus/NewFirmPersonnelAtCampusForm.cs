
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
    /// Giriş-Çıkış Yapan Firma Personeli
    /// </summary>
    public partial class NewFirmPersonnelAtCampus : TTForm
    {
        override protected void BindControlEvents()
        {
            firmPersonnelListBox.SelectedObjectChanged += new TTControlEventDelegate(firmPersonnelListBox_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            firmPersonnelListBox.SelectedObjectChanged -= new TTControlEventDelegate(firmPersonnelListBox_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void firmPersonnelListBox_SelectedObjectChanged()
        {
#region NewFirmPersonnelAtCampus_firmPersonnelListBox_SelectedObjectChanged
   Guid? guid;
            MNZFirmPersonnel fp;
            
            this._MNZFirmPersonnelAtCampus.checkForFirmPersonnelsAuthorizationStatus();
            guid = (Guid?)this.firmPersonnelListBox.SelectedValue;
            fp = this._MNZFirmPersonnelAtCampus.getSelectedFirmPersonnel(guid);
            this.fillInformationAreasOnForm(fp);
            this.fillAllowedPeriodsForFirmPersonnelGrid(fp.PersonnelVisit);
#endregion NewFirmPersonnelAtCampus_firmPersonnelListBox_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region NewFirmPersonnelAtCampus_PreScript
    Guid? CurrentState;
            Guid? SelectedPersonel;
            
            CurrentState = this._MNZFirmPersonnelAtCampus.getCurrentState();
            SelectedPersonel = (Guid?)this.firmPersonnelListBox.SelectedValue;
            
            if(CurrentState.HasValue == false)
            {
                Console.WriteLine("No Guid Value Returned... ");
            }
            else
            {
                if(SelectedPersonel.HasValue)
                {
                    Console.WriteLine("Grid Dolduruluyor. Update formu açılıyor olmalı");
                    fillAllowedPeriodsForFirmPersonnelGrid(this._MNZFirmPersonnelAtCampus.FirmPersonnel.PersonnelVisit);
                    this.fillInformationAreasOnForm(this._MNZFirmPersonnelAtCampus.FirmPersonnel);
                }
                if(CurrentState.Value.Equals(MNZFirmPersonnelAtCampus.States.New))
                {
                    this.ExitTimeDatePicker.Enabled = false;
                }
                else if(CurrentState.Value.Equals(MNZFirmPersonnelAtCampus.States.Exit))
                {
                    this.EntranceTimeDatePicker.Enabled = false;
                    this.VisitDateDatePicker.Enabled = false;
                    this.ExitTimeDatePicker.Enabled = true;
                }
            }
#endregion NewFirmPersonnelAtCampus_PreScript

            }
            
#region NewFirmPersonnelAtCampus_Methods
        public void fillAllowedPeriodsForFirmPersonnelGrid(IList personnelVisitList)
        {
            string ALLOWEDWISITDATE = "AllowedVisitDate", ALLOWEDENTRANCETIME = "AllowedEntranceTime";
            string ALLOWEDEXITTIME = "AllowedExitTime";
            int ROWINDEX = 0;
            
            if(this.AllowedVisitTimeGrid.Rows.Count >= 1)
            {
                this.AllowedVisitTimeGrid.Rows.Clear();
            }
            foreach(MNZPersonnelVisit pv in personnelVisitList)
            {
                this.AllowedVisitTimeGrid.Rows.Add();
                this.AllowedVisitTimeGrid.Rows[ROWINDEX].Cells[ALLOWEDWISITDATE].Value = this._MNZFirmPersonnelAtCampus.OrganizeDateTimeValue('D',pv.VisitDate);
                this.AllowedVisitTimeGrid.Rows[ROWINDEX].Cells[ALLOWEDENTRANCETIME].Value = this._MNZFirmPersonnelAtCampus.OrganizeDateTimeValue('T',pv.EntranceTime);
                this.AllowedVisitTimeGrid.Rows[ROWINDEX].Cells[ALLOWEDEXITTIME].Value = this._MNZFirmPersonnelAtCampus.OrganizeDateTimeValue('T',pv.ExitTime);
                
                ROWINDEX++;
            }
            
        }
        
        public void fillInformationAreasOnForm(MNZFirmPersonnel fp)
        {
            Console.WriteLine("Inside fillınformationareasonform :)");
            this.nameTextBox.Text = fp.Name;
            this.surnameTextBox.Text = fp.Surname;
            this.nationalIdentityTextBox.Text = fp.NationalIdentity;
            this.workingUnitTextBox.Text = fp.WorkingUnit.Name;
            this.firmNameTextBox.Text = fp.Firm.Name;
        }
        
#endregion NewFirmPersonnelAtCampus_Methods
    }
}