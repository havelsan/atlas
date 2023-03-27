
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
    public partial class ProjectDetailingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            PurchaseType.SelectedObjectChanged += new TTControlEventDelegate(PurchaseType_SelectedObjectChanged);
            PurchaseMainType.SelectedIndexChanged += new TTControlEventDelegate(PurchaseMainType_SelectedIndexChanged);
            EvaluationType.SelectedIndexChanged += new TTControlEventDelegate(EvaluationType_SelectedIndexChanged);
            actionButtonsStrip.ItemClicked += new TTToolStripItemClicked(actionButtonsStrip_ItemClicked);
            PurchaseProjectDetails.CellContentClick += new TTGridCellEventDelegate(PurchaseProjectDetails_CellContentClick);
            PurchaseProjectDetails.CellValueChanged += new TTGridCellEventDelegate(PurchaseProjectDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PurchaseType.SelectedObjectChanged -= new TTControlEventDelegate(PurchaseType_SelectedObjectChanged);
            PurchaseMainType.SelectedIndexChanged -= new TTControlEventDelegate(PurchaseMainType_SelectedIndexChanged);
            EvaluationType.SelectedIndexChanged -= new TTControlEventDelegate(EvaluationType_SelectedIndexChanged);
            actionButtonsStrip.ItemClicked -= new TTToolStripItemClicked(actionButtonsStrip_ItemClicked);
            PurchaseProjectDetails.CellContentClick -= new TTGridCellEventDelegate(PurchaseProjectDetails_CellContentClick);
            PurchaseProjectDetails.CellValueChanged -= new TTGridCellEventDelegate(PurchaseProjectDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void PurchaseType_SelectedObjectChanged()
        {
#region ProjectDetailingForm_PurchaseType_SelectedObjectChanged
   if (PurchaseType.SelectedValue != null)
            {
                if ((bool)_PurchaseProject.PurchaseTypeDefinition.FirmInvite)
                {
                    this.SufficiencyDueDate.ReadOnly = false;
                    this.lblSufficiencyDueDate.ReadOnly = false;
                }
                else
                {
                    this.SufficiencyDueDate.ReadOnly = true;
                    this.lblSufficiencyDueDate.ReadOnly = true;
                }

                if ((bool)_PurchaseProject.PurchaseTypeDefinition.NeedsSufficiency)
                    this.SufficiencyDueDate.ReadOnly = false;
                else
                    this.SufficiencyDueDate.ReadOnly = true;
            }
#endregion ProjectDetailingForm_PurchaseType_SelectedObjectChanged
        }

        private void PurchaseMainType_SelectedIndexChanged()
        {
#region ProjectDetailingForm_PurchaseMainType_SelectedIndexChanged
   this.SetPurchaseTypeDefs();
#endregion ProjectDetailingForm_PurchaseMainType_SelectedIndexChanged
        }

        private void EvaluationType_SelectedIndexChanged()
        {
#region ProjectDetailingForm_EvaluationType_SelectedIndexChanged
   foreach (PurchaseProjectDetail ppd in _PurchaseProject.PurchaseProjectDetails)
            {
                if (_PurchaseProject.EvaluationType == EvaluationTypeEnum.GroupSum)
                {
                    ppd.PurchaseProjectGroup = null;
                }
                else
                {
                    foreach (PurchaseProjectGroup ppg in ppd.PurchaseProject.PurchaseProjectGroups)
                    {
                        if ((bool)ppg.GroupExcluded)
                        {
                            ppd.PurchaseProjectGroup = ppg;
                        }
                    }
                }
            }
#endregion ProjectDetailingForm_EvaluationType_SelectedIndexChanged
        }

        private void actionButtonsStrip_ItemClicked(ITTToolStripItem item)
        {
#region ProjectDetailingForm_actionButtonsStrip_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<string>> parameters = new Dictionary<string, TTReportTool.PropertyCache<string>>();
            TTReportTool.PropertyCache<string> pc = new TTReportTool.PropertyCache<string>();
            pc.Add("VALUE", _PurchaseProject.PurchaseProjectNO.Value.ToString()); //Bu Value veya LookedUpValue olabiliyor.
            parameters.Add("PURCHASEPROJECTNO", pc);

            switch (item.Name)
            {
                case "cmdMergeProjectDetails":
                    ProjectDetailEditingForm pdeform = new ProjectDetailEditingForm();
                    DialogResult dr = pdeform.ShowEdit(this.FindForm(), _PurchaseProject, true);
                    if (dr == DialogResult.OK)
                    {
                        PurchaseProjectDetails.RefreshRows();
                        this.SetButtons();
                    }
                    PurchaseProjectDetails.Sort(1);
                    PurchaseProjectDetails.Sort(PurchaseProjectDetails.Columns[OrderNO.Name].Index);
                    _PurchaseProject.TempPurchaseProjectDetMerge = null;

                    break;

                case "cmdProjectGroup":

                    if (_PurchaseProject.EvaluationType != EvaluationTypeEnum.GroupSum)
                    {
                        throw new TTUtils.TTException(SystemMessage.GetMessage(38));
                    }
                    else
                    {
                        TTObjectContext newContext = new TTObjectContext(false);
                        try
                        {
                            ProjectGroupDefiningForm pgdf = new ProjectGroupDefiningForm();
                            PurchaseProjectGroup ppg = new PurchaseProjectGroup(newContext);
                            ppg.CurrentStateDefID = PurchaseProjectGroup.States.New;
                            ppg.PurchaseProject = _PurchaseProject;
                            pgdf.ObjectUpdated += new ObjectUpdatedDelegate(pgdf.ShowEdit_ObjectUpdated);
                            pgdf.ShowEdit(this.FindForm(), ppg);

                        }
                        catch (System.Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            ((ITTListDefComboBoxColumn)((ITTGridColumn)PurchaseProjectDetails.Columns["ProjectGroup"])).RefreshItems();
                            newContext.Dispose();
                        }
                    }
                    break;

                case "OnayBelgesi":
                    TTReportTool.TTReport.PrintReport("OnayBelgesiRaporu", true, 1, parameters);
                    break;

                case "IhaleyeDavet":
                    if (_PurchaseProject.InvitedFirmsForTender.Count > 0)
                        TTReportTool.TTReport.PrintReport("IhaleyeDavet", true, 1, parameters);
                    else
                        InfoBox.Show("Davet edilecek firma seçmediniz");
                    break;
                default:
                    break;
            }
#endregion ProjectDetailingForm_actionButtonsStrip_ItemClicked
        }

        private void PurchaseProjectDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ProjectDetailingForm_PurchaseProjectDetails_CellContentClick
   if (PurchaseProjectDetails.CurrentCell.OwningColumn.Name == "Details")
            {
                PurchaseProject myProject = _PurchaseProject;
                ProjectRegistrationItemDetailsForm prid = new ProjectRegistrationItemDetailsForm();
                prid.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[PurchaseProjectDetails.CurrentCell.RowIndex]);
            }
#endregion ProjectDetailingForm_PurchaseProjectDetails_CellContentClick
        }

        private void PurchaseProjectDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ProjectDetailingForm_PurchaseProjectDetails_CellValueChanged
   PurchaseProjectDetail ppd = (PurchaseProjectDetail)PurchaseProjectDetails.CurrentCell.OwningRow.TTObject;
            
            if (PurchaseProjectDetails.CurrentCell.OwningColumn.Name == WorkStartDate.Name || PurchaseProjectDetails.CurrentCell.OwningColumn.Name == WorkTime.Name)
            {
                if (PurchaseProjectDetails.CurrentCell.OwningRow.Cells[WorkStartDate.Name].Value != null && PurchaseProjectDetails.CurrentCell.OwningRow.Cells[WorkTime.Name].Value != null)
                {
                    DateTime startDate = (DateTime)PurchaseProjectDetails.CurrentCell.OwningRow.Cells[WorkStartDate.Name].Value;
                    int dayCount = (int)PurchaseProjectDetails.CurrentCell.OwningRow.Cells[WorkTime.Name].Value;
                    ppd.WorkEndDate = Common.FindDueDate(dayCount, startDate);
                }
            }
            else if (PurchaseProjectDetails.CurrentCell.OwningColumn.Name == GuarantyStartDate.Name || PurchaseProjectDetails.CurrentCell.OwningColumn.Name == GuarantyTime.Name)
            {
                if (PurchaseProjectDetails.CurrentCell.OwningRow.Cells[GuarantyStartDate.Name].Value != null && PurchaseProjectDetails.CurrentCell.OwningRow.Cells[GuarantyTime.Name].Value != null)
                {
                    DateTime startDate = (DateTime)PurchaseProjectDetails.CurrentCell.OwningRow.Cells[GuarantyStartDate.Name].Value;
                    int dayCount = (int)PurchaseProjectDetails.CurrentCell.OwningRow.Cells[GuarantyTime.Name].Value;
                    ppd.GuarantyEndDate = Common.FindDueDate(dayCount, startDate);
                }
            }
            else if (PurchaseProjectDetails.CurrentCell.OwningColumn.Name == ContractStartDate.Name || PurchaseProjectDetails.CurrentCell.OwningColumn.Name == ContractTime.Name)
            {
                if (PurchaseProjectDetails.CurrentCell.OwningRow.Cells[ContractStartDate.Name].Value != null && PurchaseProjectDetails.CurrentCell.OwningRow.Cells[ContractTime.Name].Value != null)
                {
                    DateTime startDate = ((DateTime)PurchaseProjectDetails.CurrentCell.OwningRow.Cells[ContractStartDate.Name].Value).AddDays(1);
                    int dayCount = (int)PurchaseProjectDetails.CurrentCell.OwningRow.Cells[ContractTime.Name].Value;
                    ppd.ContractEndDate = Common.FindDueDate(dayCount, startDate);
                }
            }
#endregion ProjectDetailingForm_PurchaseProjectDetails_CellValueChanged
        }

        protected override void PreScript()
        {
#region ProjectDetailingForm_PreScript
    this.DropStateButton(PurchaseProject.States.PriceFormulation);

            this.SetButtons();
            this.SetPurchaseTypeDefs();

            if (_PurchaseProject.ProcurementSource == ProcurementEnum.GeneralBudget)
                _PurchaseProject.ConfirmNO = _PurchaseProject.ConfirmNO_GB.ToString() + "/" + ((DateTime)Common.RecTime()).Year.ToString();
            else
                _PurchaseProject.ConfirmNO = _PurchaseProject.ConfirmNO_DS.ToString() + "/" + ((DateTime)Common.RecTime()).Year.ToString();

            if (PurchaseType.SelectedValue != null)
            {
                if ((bool)_PurchaseProject.PurchaseTypeDefinition.FirmInvite)
                {
                    this.SufficiencyDueDate.ReadOnly = false;
                    this.lblSufficiencyDueDate.ReadOnly = false;
                }
                else
                {
                    this.SufficiencyDueDate.ReadOnly = true;
                    this.lblSufficiencyDueDate.ReadOnly = true;
                }
            }


            if (String.IsNullOrEmpty(AdministrativeSpecificationRTF.Text))
            {
                string rtfValue = AdministrativeSpecificationRTF.Rtf;
                foreach (PurchaseProjectDetail ppd in _PurchaseProject.PurchaseProjectDetails)
                {
                    if (ppd.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                    {
                        rtfValue = Common.MergeRTFs(rtfValue, ppd.Isayf);
                    }
                }
                AdministrativeSpecificationRTF.Rtf = rtfValue;
            }

            //Avanssa Tüm Detaylara otomatik onay
            if (_PurchaseProject.PurchaseMainType == PurchaseMainTypeEnum.Advance)
            {
                foreach (PurchaseProjectDetail ppd in _PurchaseProject.PurchaseProjectDetails)
                {
                    if (ppd.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                    {
                        ppd.Amount = ppd.RequestedAmount;
                    }
                }
            }

            _PurchaseProject.SetActCount();
#endregion ProjectDetailingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProjectDetailingForm_PostScript
    base.PostScript(transDef);
#endregion ProjectDetailingForm_PostScript

            }
            
#region ProjectDetailingForm_Methods
        public void SetButtons()
        {
            this.DropStateButton(PurchaseProject.States.Canceled);

            bool cancelProject = true;
            foreach (PurchaseProjectDetail pPro in _PurchaseProject.PurchaseProjectDetails)
            {
                if (pPro.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                    cancelProject = false;
            }

            if (cancelProject)
                this.AddStateButton(PurchaseProject.States.Canceled);

            if ((int)this.PurchaseMainType.SelectedItem.Value == 2) //Avans
            {
                this.PurchaseMainType.ReadOnly = true;
                this.PurchaseType.ReadOnly = true;
            }
        }


        public void SetPurchaseTypeDefs()
        {
            if (this.PurchaseMainType.SelectedItem.Value != null)
            {
                if ((int)this.PurchaseMainType.SelectedItem.Value == 0) //Doğrudan Temin
                {
                    this.AnnounceTypeandCount.SelectedIndex = 0;
                    this.AnnounceTypeandCount.Enabled = false;
                    this.AnnouncementDesc.Enabled = false;
                    this.InvestmentProjectNO.Enabled = false;
                    this.Advanced.Enabled = false;
                    this.PriceDifference.Enabled = false;
                    this.PurchaseType.Enabled = true;
                    this.ActCount.Enabled = true;
                    this.ActAttribute.Enabled = true;
                    this.EvaluationType.Enabled = true;
                    this.AttachmentList.Enabled = true;
                    this.SpecificationPrice.Enabled = false;
                    _PurchaseProject.AnnounceTypeandCount = AnnounceTypeandCountEnum.NoAnnounce;
                    PurchaseType.SelectedValue = null;
                    PurchaseType.ListFilterExpression = "PURCHASEMAINTYPE = " + Convert.ToInt16(PurchaseMainTypeEnum.DirectPurchase);
                }
                else if ((int)this.PurchaseMainType.SelectedItem.Value == 1) //İhale
                {
                    this.AnnounceTypeandCount.Enabled = true;
                    this.AnnouncementDesc.Enabled = true;
                    this.InvestmentProjectNO.Enabled = true;
                    this.Advanced.Enabled = true;
                    this.PurchaseType.Enabled = true;
                    this.PriceDifference.Enabled = true;
                    this.EvaluationType.Enabled = true;
                    this.ActCount.Enabled = true;
                    this.ActAttribute.Enabled = true;
                    this.AttachmentList.Enabled = true;
                    this.SpecificationPrice.Enabled = true;
                    PurchaseType.SelectedValue = null;
                    PurchaseType.ListFilterExpression = "PURCHASEMAINTYPE = " + Convert.ToInt16(PurchaseMainTypeEnum.Tender);
                }
                else //Avans
                {
                    this.InvestmentProjectNO.Enabled = false;
                    this.AnnounceTypeandCount.Enabled = false;
                    this.AnnouncementDesc.Enabled = false;
                    this.Advanced.Enabled = false;
                    this.SpecificationPrice.Enabled = false;
                    this.ActCount.Enabled = false;
                    this.PurchaseType.Enabled = false;
                    this.ActAttribute.Enabled = false;
                    this.EvaluationType.Enabled = false;
                    this.PriceDifference.Enabled = false;
                    this.AttachmentList.Enabled = false;
                }
            }
        }
        
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {

            Dictionary<string, TTReportTool.PropertyCache<object>> parameter = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _PurchaseProject.ObjectID.ToString());
            parameter.Add("TTOBJECTID", objectID);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OnayBelgesiRaporuIhale), true, 1, parameter);
            if(_PurchaseProject.AttachmentList != null)
            {
                if((bool)_PurchaseProject.AttachmentList)
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_OnayBelgesiEkliListe), true, 1, parameter);
            }
        }
        
#endregion ProjectDetailingForm_Methods
    }
}