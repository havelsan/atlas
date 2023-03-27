
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
    public partial class WomanSpecialityForm : SpecialityBasedObjectForm
    {
        override protected void BindControlEvents()
        {
            MarriageDate.TextChanged += new TTControlEventDelegate(MarriageDate_TextChanged);
            HusbandBloodGroup.SelectedIndexChanged += new TTControlEventDelegate(HusbandBloodGroup_SelectedIndexChanged);
            WomanBloodGroup.SelectedIndexChanged += new TTControlEventDelegate(PatientBloodGroup__SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MarriageDate.TextChanged -= new TTControlEventDelegate(MarriageDate_TextChanged);
            HusbandBloodGroup.SelectedIndexChanged -= new TTControlEventDelegate(HusbandBloodGroup_SelectedIndexChanged);
            WomanBloodGroup.SelectedIndexChanged -= new TTControlEventDelegate(PatientBloodGroup__SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
            base.PreScript();
            this.WomanBloodGroup.SelectedValue =Convert.ToInt32(this._WomanSpecialityObject.PhysicianApplication.Episode.Patient.BloodGroupType.KODU);

            if (this._WomanSpecialityObject.PhysicianApplication.Episode.Patient.ActivePregnancy != null)
            {
                BindingList<PregnancyFollow.PregnancyCalender> pregnancyCalenderList = PregnancyFollow.FillPregnancyCalender(this._WomanSpecialityObject.ObjectContext, this._WomanSpecialityObject.PregnancyFollow.Pregnancy.LastMenstrualPeriod.Value, this._WomanSpecialityObject.PregnancyFollow.Pregnancy.PregnancyType.Value);
                this.gridPregnancyCalendar.SetDataSource(pregnancyCalenderList);
            }

            if (WomanBloodGroup.SelectedItem != null && HusbandBloodGroup.SelectedItem != null)
            {
                RhIncompatibility.SelectedIndex = (int)Enum.Parse(typeof(VarYokGarantiEnum), GetRhIncompatibility((BloodGroupEnum)WomanBloodGroup.SelectedItem.Value, (BloodGroupEnum)HusbandBloodGroup.SelectedItem.Value).ToString());
            }
            else
            {
                RhIncompatibility.SelectedValue = null;
            }

            if (MarriageDate.ControlValue.ToString().Length == 4)
            {
                MarriageDuration.Text = WomanSpecialityForm.GetMarriageDuration(Convert.ToInt32(MarriageDate.Text)).ToString();
            }
            else
            {
                MarriageDuration.Text = "";
            }

        }

        private void btnPregnancyStart_Click()
        {
            #region btnPregnancyStart_Click
            Pregnancy pregnancy = new Pregnancy(this._WomanSpecialityObject);
            #endregion btnPregnancyStart_Click
        }

        private static int GetMarriageDuration(int yearOfMarriage)
        {
            int marriageDuration = Convert.ToInt32(DateTime.Now.Year) - yearOfMarriage;
            return marriageDuration;
        }

        private void MarriageDate_TextChanged()
        {
            if (MarriageDate.ControlValue.ToString().Length == 4)
            {
                MarriageDuration.Text = WomanSpecialityForm.GetMarriageDuration(Convert.ToInt32(MarriageDate.Text)).ToString();
            }
            else
            {
                MarriageDuration.Text = "";
            }
        }

        private void HusbandBloodGroup_SelectedIndexChanged()
        {
            if (WomanBloodGroup.SelectedItem != null)
            {
                RhIncompatibility.SelectedIndex = (int)Enum.Parse(typeof(VarYokGarantiEnum), GetRhIncompatibility((BloodGroupEnum)WomanBloodGroup.SelectedItem.Value, (BloodGroupEnum)HusbandBloodGroup.SelectedItem.Value).ToString()); 
            }
        }

        private void PatientBloodGroup__SelectedIndexChanged()
        {
            if (HusbandBloodGroup.SelectedItem != null)
            {
                RhIncompatibility.SelectedIndex = (int)Enum.Parse(typeof(VarYokGarantiEnum), GetRhIncompatibility((BloodGroupEnum)WomanBloodGroup.SelectedItem.Value, (BloodGroupEnum)HusbandBloodGroup.SelectedItem.Value).ToString()); 
            }
        }


        public static VarYokGarantiEnum GetRhIncompatibility(BloodGroupEnum motherGroup, BloodGroupEnum fatherGroup)
        {
            List<BloodGroupEnum> negativeGroups = new List<BloodGroupEnum>();
            negativeGroups.Add(BloodGroupEnum.ABNEGATIVE);
            negativeGroups.Add(BloodGroupEnum.ANEGATIVE);
            negativeGroups.Add(BloodGroupEnum.BNEGATIVE);
            negativeGroups.Add(BloodGroupEnum.ONEGATIVE);


            List<BloodGroupEnum> positiveGroups = new List<BloodGroupEnum>();
            positiveGroups.Add(BloodGroupEnum.ABPOSITIVE);
            positiveGroups.Add(BloodGroupEnum.APOZITIVE);
            positiveGroups.Add(BloodGroupEnum.BPOSITIVE);
            positiveGroups.Add(BloodGroupEnum.OPOSITIVE);


            if (negativeGroups.Contains(motherGroup) && positiveGroups.Contains(fatherGroup))
            {
                return VarYokGarantiEnum.V;
            }
            else
            {
                return VarYokGarantiEnum.Y;
            }
        }
    }
}