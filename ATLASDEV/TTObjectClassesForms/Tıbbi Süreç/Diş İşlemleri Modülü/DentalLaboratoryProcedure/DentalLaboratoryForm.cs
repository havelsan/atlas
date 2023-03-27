
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
    /// Diş Laboratuar İşlemleri
    /// </summary>
    public partial class DentalLaboratoryForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttcheckbox1.CheckedChanged += new TTControlEventDelegate(ttcheckbox1_CheckedChanged);
            enumTechType.SelectedIndexChanged += new TTControlEventDelegate(enumTechType_SelectedIndexChanged);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttcheckbox1.CheckedChanged -= new TTControlEventDelegate(ttcheckbox1_CheckedChanged);
            enumTechType.SelectedIndexChanged -= new TTControlEventDelegate(enumTechType_SelectedIndexChanged);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            base.UnBindControlEvents();
        }

        private void ttcheckbox1_CheckedChanged()
        {
#region DentalLaboratoryForm_ttcheckbox1_CheckedChanged
   fillTechnicians();
#endregion DentalLaboratoryForm_ttcheckbox1_CheckedChanged
        }

        private void enumTechType_SelectedIndexChanged()
        {
#region DentalLaboratoryForm_enumTechType_SelectedIndexChanged
   if (enumTechType.SelectedItem.Value != null) {
                   fillTechnicians();
                int tempEnum = (int)enumTechType.SelectedItem.Value;
                DentalTechnicianTypeEnum tempEnumVal  = DentalTechnicianTypeEnum.Dynamic;
                if (tempEnum == 1)
                    tempEnumVal = DentalTechnicianTypeEnum.Dynamic;
                else  if (tempEnum == 2)
                    tempEnumVal = DentalTechnicianTypeEnum.Stable;
                else if (tempEnum == 3)
                    tempEnumVal = DentalTechnicianTypeEnum.DynamicAndStable;
                List<ITTGridRow> list = new List<ITTGridRow>();
                foreach(ITTGridRow row in gridTechnician.Rows) {
                    if (row.Cells[2].Value != null && (DentalTechnicianTypeEnum)row.Cells[2].Value == tempEnumVal)
                        list.Add(row);
                }
                if (list != null && list.Count >0)
                    gridTechnician.Rows.Clear();
                foreach(ITTGridRow newRow in list) {
                    ITTGridRow rowx = gridTechnician.Rows.Add();
                    rowx.Cells[1].Value = newRow.Cells[1].Value;
                    rowx.Cells[2].Value = newRow.Cells[2].Value;
                    rowx.Cells[3].Value = newRow.Cells[3].Value;
                    rowx.Cells[4].Value = newRow.Cells[4].Value;
                    rowx.Cells[5].Value = newRow.Cells[5].Value;
                }
            }
            else {
                fillTechnicians();
            }
#endregion DentalLaboratoryForm_enumTechType_SelectedIndexChanged
        }

        private void ttbutton1_Click()
        {
#region DentalLaboratoryForm_ttbutton1_Click
   Technician teknisyen = null;
            int i = 0;
            TTObjectContext context = new TTObjectContext(false);
            foreach(ITTGridRow row in gridTechnician.Rows) {
                if (row.Cells[0] != null && row.Cells[0].Value != null && (System.Boolean)row.Cells[0].Value) {
                    BindingList<Technician> teknisyenList =  Technician.GetTechnicianById(context, new Guid(row.Cells[5].Value.ToString()));
                    teknisyen = teknisyenList[0];
                    break;
                }
            }
            bool procedureFound = false;
            if (teknisyen != null) {
                foreach(ITTGridRow row in gridProcedures.Rows) {
                    if (row.Cells[0] != null && row.Cells[0].Value != null && (System.Boolean)row.Cells[0].Value) {
                        //row.Cells[4].Value = teknisyen.ResUser.ToString();
                        ((DentalProsthesisRequestSuggestedProsthesis)row.TTObject).Technician = teknisyen;
                        procedureFound = true;
                    }
                }
                if (!procedureFound)
                    InfoBox.Show("Teknisyen ataması için en az bir işlem seçmelisiniz!");
            }
            else
                InfoBox.Show("Teknisyen ataması için teknisyen seçiniz!");
#endregion DentalLaboratoryForm_ttbutton1_Click
        }

        private void ttbutton2_Click()
        {
#region DentalLaboratoryForm_ttbutton2_Click
   String outerLab = "";
            if (this.TTListBoxExternalLab.SelectedObject != null)
                outerLab = ((ToothProthesisLabDefinition)this.TTListBoxExternalLab.SelectedObject).Name;
            bool procedureFound = false;
            if (!"".Equals(outerLab)) {
                foreach(ITTGridRow row in gridProcedures.Rows) {
                    if (row.Cells[0] != null && row.Cells[0].Value != null && (System.Boolean)row.Cells[0].Value) {
                        row.Cells[7].Value = outerLab;
                        ((DentalProsthesisRequestSuggestedProsthesis)row.TTObject).ExternalLab = outerLab;
                        procedureFound = true;
                    }
                }
                if (!procedureFound)
                    InfoBox.Show("Dış Lab İsteği için en az bir işlem seçmelisiniz!");
            }
            else
                InfoBox.Show("Dış Lab İsteği için dış laboratuar seçmelisiniz!");
#endregion DentalLaboratoryForm_ttbutton2_Click
        }

        protected override void PreScript()
        {
#region DentalLaboratoryForm_PreScript
    base.PreScript();
            fillTechnicians();
            this.SetTreatmentMaterialListFilter(this._DentalLaboratoryProcedure.ObjectDef, (ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
            
            /* this.SetProcedureDoctorAsCurrentResource();
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.TreatmentMaterials.Columns["Material"]);
             */
#endregion DentalLaboratoryForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DentalLaboratoryForm_PostScript
    base.PostScript(transDef);
            TTObjectContext context = new TTObjectContext(false);
            foreach(ITTGridRow row in gridTechnician.Rows) {
                BindingList<Technician> techTemp = Technician.GetTechnicianById(context, (Guid)row.Cells[5].Value);
                if (row.Cells[2].Value != null)
                    techTemp[0].TechnicianType =  (DentalTechnicianTypeEnum)row.Cells[2].Value;
            }
            context.Save();
            
            if(transDef == null || (transDef != null && transDef.ToStateDefID == DentalLaboratoryProcedure.States.Completed))
            {
                // Kaydet ve Tamamla yapıldığında Sarf Malzemelerin ücretlenmesi için
                foreach(BaseTreatmentMaterial treatmentMaterial in _DentalLaboratoryProcedure.TreatmentMaterials)
                    treatmentMaterial.AccountOperation(AccountOperationTimeEnum.PREPOST);
            }
#endregion DentalLaboratoryForm_PostScript

            }
            
#region DentalLaboratoryForm_Methods
        public void fillTechnicians() {
            gridTechnician.Rows.Clear();
            TTObjectContext context = new TTObjectContext(false);
            BindingList<Technician> userList = Technician.GetAllTechnicians(context);
            BindingList<ResUser> tempUserList  = ResUser.GetResUserByUserType(context, UserTypeEnum.DentalTechnician);
            if (userList == null || userList.Count == 0) {
                foreach(ResUser user in  tempUserList) {
                    Technician technician = new Technician(context);
                    technician.ResUser = user;
                    userList.Add(technician);
                }
                context.Save();
            }
            else {
                bool isUpdate = false;
                foreach(ResUser user in  tempUserList) {
                    bool found = false;
                    foreach(Technician tech in  userList) {
                        if (tech.ResUser.Equals(user)) {
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        Technician technician = new Technician(context);
                        technician.ResUser = user;
                        userList.Add(technician);
                        isUpdate = true;
                    }
                }
                if (isUpdate)
                    context.Save();
            }
            
            List<Technician> prevList = new List<Technician>();
            foreach(Technician user in userList) {
                if (user.ResUser.UserType == UserTypeEnum.DentalTechnician && !prevList.Contains(user))
                {
                    ITTGridRow row =  gridTechnician.Rows.Add();
                    row.Cells[1].Value = user.ResUser.ToString();
                    BindingList<DentalProsthesisRequestSuggestedProsthesis> prosthesisList = DentalProsthesisRequestSuggestedProsthesis.GetAllProsthesisByTechnician(context, user.ObjectID);
                    row.Cells[2].Value = user.TechnicianType;
                    row.Cells[3].Value = prosthesisList.Count;
                    int unfinishedWorks = 0;
                    foreach(DentalProsthesisRequestSuggestedProsthesis item in prosthesisList) {
                        DentalLaboratoryProcedure labTemp = ((DentalExaminationSuggestedProsthesis)item).DentalLaboratoryProcedure;
                        if(labTemp != null && labTemp.CurrentStateDefID != DentalLaboratoryProcedure.States.Completed)
                            unfinishedWorks++;
                    }
                    row.Cells[4].Value = unfinishedWorks;
                    row.Cells[5].Value = user.ObjectID;
                    prevList.Add(user);
                }
            }
            context.Save();
        }
        
#endregion DentalLaboratoryForm_Methods
    }
}