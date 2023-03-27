
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
    /// İlk Muayene
    /// </summary>
    public partial class FirstExaminationForm : RUL_BaseForm
    {
        override protected void BindControlEvents()
        {
            cmdGetHEKDetail.Click += new TTControlEventDelegate(cmdGetHEKDetail_Click);
            CommisionGrid.CellValueChanged += new TTGridCellEventDelegate(CommisionGrid_CellValueChanged);
            RULHEKReasons.CellValueChanged += new TTGridCellEventDelegate(RULHEKReasons_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdGetHEKDetail.Click -= new TTControlEventDelegate(cmdGetHEKDetail_Click);
            CommisionGrid.CellValueChanged -= new TTGridCellEventDelegate(CommisionGrid_CellValueChanged);
            RULHEKReasons.CellValueChanged -= new TTGridCellEventDelegate(RULHEKReasons_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void cmdGetHEKDetail_Click()
        {
#region FirstExaminationForm_cmdGetHEKDetail_Click
   if (_ReferToUpperLevel.RULHEKReasons.Count == 0)
            {
                IList reasons = _ReferToUpperLevel.ObjectContext.QueryObjects("COUSESOFTHEHEKDEFINITION", string.Empty);
                foreach (CousesOfTheHekDefinition cousesOfTheHekDefinition in reasons)
                {
                    RULHEKReason rULHEKReason = _ReferToUpperLevel.RULHEKReasons.AddNew();
                    rULHEKReason.CousesOfTheHekDefinition = cousesOfTheHekDefinition;
                    rULHEKReason.Check = false;
                }
            }
            if (_ReferToUpperLevel.RULHekCommisionMembers.Count == 0)
            {
                RULHekCommisionMember ktlMember = _ReferToUpperLevel.RULHekCommisionMembers.AddNew();
                ktlMember.CommisionOrderNo = 1;
                ktlMember.MemberDuty = CommisionMemberDutyEnum.Assay;

                RULHekCommisionMember sectionHeadMember = _ReferToUpperLevel.RULHekCommisionMembers.AddNew();
                sectionHeadMember.CommisionOrderNo = 2;
                sectionHeadMember.MemberDuty = CommisionMemberDutyEnum.SectionHead;

                RULHekCommisionMember technicalMember = _ReferToUpperLevel.RULHekCommisionMembers.AddNew();
                technicalMember.CommisionOrderNo = 3;
                technicalMember.MemberDuty = CommisionMemberDutyEnum.TechnicalMember;

                RULHekCommisionMember sectionChiefMember = _ReferToUpperLevel.RULHekCommisionMembers.AddNew();
                sectionChiefMember.CommisionOrderNo = 4;
                sectionChiefMember.MemberDuty = CommisionMemberDutyEnum.SectionChief;

                RULHekCommisionMember technicalHeadMember = _ReferToUpperLevel.RULHekCommisionMembers.AddNew();
                technicalHeadMember.CommisionOrderNo = 5;
                technicalHeadMember.MemberDuty = CommisionMemberDutyEnum.TechnicalHead;

                RULHekCommisionMember approvalMember = _ReferToUpperLevel.RULHekCommisionMembers.AddNew();
                approvalMember.CommisionOrderNo = 6;
                approvalMember.MemberDuty = CommisionMemberDutyEnum.Approval;
            }
#endregion FirstExaminationForm_cmdGetHEKDetail_Click
        }

        private void CommisionGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region FirstExaminationForm_CommisionGrid_CellValueChanged
   if(CommisionGrid.CurrentCell.OwningColumn == CommisionGrid.Columns[Name.Name])
            {
                if (CommisionGrid.Rows[rowIndex].Cells["Name"].Value != null)
                {
                    CommisionGrid.Rows[rowIndex].Cells["NameString"].ReadOnly = true;
                }
                else
                {
                    CommisionGrid.Rows[rowIndex].Cells["NameString"].ReadOnly = false;
                    CommisionGrid.Rows[rowIndex].Cells["NameString"].Value = null ;
                }
            }
#endregion FirstExaminationForm_CommisionGrid_CellValueChanged
        }

        private void RULHEKReasons_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region FirstExaminationForm_RULHEKReasons_CellValueChanged
   ITTGridRow rulCheckRow = RULHEKReasons.Rows[RULHEKReasons.CurrentCell.RowIndex];
            if (RULHEKReasons.CurrentCell == rulCheckRow.Cells["CheckRULHEKReason"])
            {
                foreach (RULHEKReason rulHEKReason in _ReferToUpperLevel.RULHEKReasons)
                {
                    if (rulHEKReason.ObjectID.Equals(rulCheckRow.TTObject.ObjectID) == false)
                        rulHEKReason.Check = false;
                }
               
            }
#endregion FirstExaminationForm_RULHEKReasons_CellValueChanged
        }

        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region FirstExaminationForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
            if(transDef.ToStateDefID == ReferToUpperLevel.States.InOrderProgress)
            {
                if(_ReferToUpperLevel.FirstExamStatus == FirstExamResultEnum.HEK)
                {
                    bool yazdir = false;
                    
                    if(_ReferToUpperLevel.RULHekCommisionMembers.Count >0)
                    {
                        if(_ReferToUpperLevel.RULHEKReasons.Count >0)
                        {
                            foreach(RULHEKReason reason in _ReferToUpperLevel.RULHEKReasons)
                            {
                                if((bool)reason.Check)
                                    yazdir = true;
                            }
                        }
                    }
                    if(yazdir)
                    {
                        Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                        TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
                        pc.Add("VALUE", _ReferToUpperLevel.ObjectID.ToString()); //Bu Value veya LookedUpValue olabiliyor.
                        parameters.Add("TTOBJECTID", pc);
                        TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_KayitSilmeyeEsasTeknikRaporRUL),true,1,parameters);
                    }
                    else
                        throw new TTException("Hek bilgileri doldurulmamıştır.");
                }
            }
#endregion FirstExaminationForm_ClientSidePostScript

        }

#region FirstExaminationForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(transDef != null && transDef.ToStateDefID == ReferToUpperLevel.States.InOrderProgress)
            {
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> pc = new TTReportTool.PropertyCache<object>();
                pc.Add("VALUE", _ReferToUpperLevel.ObjectID.ToString());
                parameters.Add("TTOBJECTID", pc);
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_IlkMuayeneFormu),true,1,parameters);
            }
        }
        
#endregion FirstExaminationForm_Methods
    }
}