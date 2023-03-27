
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
    public partial class DentalConsultationForm : DentalExaminationForm
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
#region DentalConsultationForm_PreScript
    base.PreScript();
#endregion DentalConsultationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalConsultationForm_PostScript
    bool iptalMi = false;
            if(transDef != null && transDef.ToStateDefID == TTObjectClasses.DentalConsultation.States.Cancelled)
                iptalMi = true;
            
            if(iptalMi == false)
            {
                if (transDef == null || ((transDef != null) && (transDef.ToStateDefID == TTObjectClasses.DentalConsultation.States.Completed)))
                {
//                    foreach(DentalConsultationProcedure dentalConsultationProcedure in this._DentalConsultation.DentalConsultationProcedures)
//                    {
//                        dentalConsultationProcedure.SetPerformedDate();
//                    }
                }
                
                if(String.IsNullOrEmpty(this._DentalConsultation.SelectedToothNumbers))
                {
                    StringBuilder selectedToothNumbers = new StringBuilder();
                    addSelectedToothNumbers(this.Controls, selectedToothNumbers);
                    if(selectedToothNumbers == null || String.IsNullOrEmpty(selectedToothNumbers.ToString()))
                    {
                        throw new Exception(this._DentalConsultation.ID.ToString() + " numaralı Diş Konsültasyonu için diş seçimi zorunludur. Lütfen diş seçiniz!");
                        //return;
                    }
                    else
                    {
                        this._DentalConsultation.SelectedToothNumbers = selectedToothNumbers.ToString().Substring(0,selectedToothNumbers.ToString().Length-1);
                        this._DentalConsultation.DescriptionForWorkList = this._DentalConsultation.SelectedToothNumbers + " numaralı dişler " + this._DentalConsultation.MasterResource.Name + " birimine " + this._DentalConsultation.ActionDate + " tarihinde yönlendirilmiştir. " + this._DentalConsultation.DescriptionForWorkList;
                    }
                }
                
                
                base.PostScript(transDef);
            }
#endregion DentalConsultationForm_PostScript

            }
            
#region DentalConsultationForm_Methods
        private void addSelectedToothNumbers(Control.ControlCollection controls, StringBuilder selectedToothNumbers)
        {
            foreach (Control currControl in controls)
            {
                if (currControl.GetType().Equals(typeof(TTCheckBox)) && currControl.Name.StartsWith("ch") && ((TTCheckBox)currControl).Checked)
                {
                    TTCheckBox currChkbox = (TTCheckBox)currControl;
                    selectedToothNumbers.Append(Int32.Parse(currChkbox.Name.Substring(2, currChkbox.Name.Length - 2)) + ",");
                }
                if (currControl.HasChildren)
                {
                    addSelectedToothNumbers(currControl.Controls, selectedToothNumbers);
                }
            }
        }
        
#endregion DentalConsultationForm_Methods
    }
}