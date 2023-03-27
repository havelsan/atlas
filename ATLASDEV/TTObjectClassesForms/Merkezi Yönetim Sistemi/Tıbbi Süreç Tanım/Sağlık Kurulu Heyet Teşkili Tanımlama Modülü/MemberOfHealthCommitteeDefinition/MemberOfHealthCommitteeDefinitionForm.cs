
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
    /// Sağlık Kurulu Heyet Teşkili Tanımları
    /// </summary>
    public partial class MemberOfHealthCommitteeDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            Members.CellValueChanged += new TTGridCellEventDelegate(Members_CellValueChanged);
            Members.UserDeletedRow += new TTGridRowEventDelegate(Members_UserDeletedRow);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Members.CellValueChanged -= new TTGridCellEventDelegate(Members_CellValueChanged);
            Members.UserDeletedRow -= new TTGridRowEventDelegate(Members_UserDeletedRow);
            base.UnBindControlEvents();
        }

    

        private void Members_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region MemberOfHealthCommitteeDefinitionForm_Members_CellValueChanged
   if(rowIndex > -1 && columnIndex > -1 && columnIndex == 1)
            {
                ResUser pDoctor = (ResUser)this._MemberOfHealthCommitteeDefinition.ObjectContext.GetObject(((Guid)this.Members.CurrentCell.Value), typeof(ResUser));
                MultiSelectForm pForm = new MultiSelectForm();
                foreach(ResSection sect in pDoctor.SelectedResources)
                {
                    if(!pForm.IsItemExists(sect.ObjectID.ToString()))
                        pForm.AddMSItem(sect.Name, sect.ObjectID.ToString(), sect);
                }
                
                string sKey = pForm.GetMSItem(this, "Bölüm seçiniz", true);
                if(!string.IsNullOrEmpty(sKey))
                    this.Members.Rows[rowIndex].Cells[2].Value = ((ResSection)pForm.MSSelectedItemObject).ObjectID;
                else
                    this.Members.Rows[rowIndex].Cells[2].Value = null;
                this.Members.Rows[rowIndex].Cells[0].Value = this._MemberOfHealthCommitteeDefinition.Members.Count;
            }
#endregion MemberOfHealthCommitteeDefinitionForm_Members_CellValueChanged
        }

        private void Members_UserDeletedRow()
        {
#region MemberOfHealthCommitteeDefinitionForm_Members_UserDeletedRow
   int rowIndex = 0;
            while (rowIndex < this.Members.Rows.Count)
            {
                this.Members.Rows[rowIndex].Cells[0].Value = rowIndex+1;
                rowIndex++;
               
            }
#endregion MemberOfHealthCommitteeDefinitionForm_Members_UserDeletedRow
        }

        protected override void PreScript()
        {
#region MemberOfHealthCommitteeDefinitionForm_PreScript
  
           
            this.Text = "Sağlık Kurulu Heyet Teşkili Tanımları";
            
            if(this._MemberOfHealthCommitteeDefinition.GroupNo.Value != null)
                this.TempBox.Visible = false;

            bool isEditable = true;
            if (((ITTObject)this._MemberOfHealthCommitteeDefinition).IsNew)
            {
                // son heyet tanımının bilgileri, yeni tanımlanan heyete otomatik doldurulur
                IList<MemberOfHealthCommitteeDefinition> memberDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetMemberDefinitions(this._MemberOfHealthCommitteeDefinition.ObjectContext);
                foreach (MemberOfHealthCommitteeDefinition memberDef in memberDefs)
                {
                    if(memberDef.ObjectID != this._MemberOfHealthCommitteeDefinition.ObjectID)
                    {
                        this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee = memberDef.MasterOfHealthCommittee;
                        this._MemberOfHealthCommitteeDefinition.MasterOfHealthCommittee2 = memberDef.MasterOfHealthCommittee2;
                        
                        foreach(HealthCommitteMemberGrid member in memberDef.Members)
                        {
                            HealthCommitteMemberGrid newMember = new HealthCommitteMemberGrid(this._MemberOfHealthCommitteeDefinition.ObjectContext);
                            newMember.OrderNo = member.OrderNo;
                            newMember.Doctor = member.Doctor;
                            newMember.Unit = member.Unit;
                            this._MemberOfHealthCommitteeDefinition.Members.Add(newMember);
                        }    
                        
                        break;
                    }
                }
            }
            else
            {
                if(!Common.CurrentUser.IsSuperUser)
                {
                    //if(this._MemberOfHealthCommitteeDefinition.HealthCommittees.Count > 0)
                    //    isEditable = false;
                }
            }
            
            if (!isEditable)
            {                         
                this.MasterOfHealthCommittee.ReadOnly = true;
                this.MasterOfHealthCommittee2.ReadOnly = true;
                this.Members.ReadOnly = true;
            }
            else
            {
                this.MasterOfHealthCommittee.ReadOnly = false;
                this.MasterOfHealthCommittee2.ReadOnly = false;
                this.Members.ReadOnly = false;
            }
            if(this.Members.CurrentCell != null)
                this.Members.Sort(0);
#endregion MemberOfHealthCommitteeDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MemberOfHealthCommitteeDefinitionForm_PostScript
  //  DateTime selectedDate = this._MemberOfHealthCommitteeDefinition.Date.Value.Date;
            
            // Sadece XXXXXX ve HPASA da 'Profesörler Sağlık Kurulu' checki aktif halde olacak
            //Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            //if(this._MemberOfHealthCommitteeDefinition.CommitteeType == HealthCommitteeTypeEnum.ProfessorCommittee
            //   && siteIDGuid != Sites.SiteXXXXXX06XXXXXX && siteIDGuid != Sites.SiteXXXXXX04 )
            //    throw new Exception(SystemMessage.GetMessage(1254));//

            //string sCommittee = CommitteeTypeCombo.SelectedItem.Text;
            //HealthCommitteeTypeEnum selectedCommitteeType = (HealthCommitteeTypeEnum)CommitteeTypeCombo.SelectedItem.Value;
            //IList<MemberOfHealthCommitteeDefinition> pDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetTodaysMemberDefinition(new TTObjectContext(true), selectedDate, selectedCommitteeType);
            //foreach(MemberOfHealthCommitteeDefinition pDef in pDefs)
            //{
            //    if(!pDef.ObjectID.Equals(this._MemberOfHealthCommitteeDefinition.ObjectID))
            //        throw new Exception(SystemMessage.GetMessage(1255,new string[] {selectedDate.ToShortDateString(),sCommittee}));
            //}
#endregion MemberOfHealthCommitteeDefinitionForm_PostScript

            }
                }
}