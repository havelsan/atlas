
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
    /// Bakım / Kalibrasyon Planlama
    /// </summary>
    public partial class MaintenancePlanForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            PlannedWorksGrid.SelectionChanged += new TTControlEventDelegate(PlannedWorksGrid_SelectionChanged);
            MaintenancePlanType.SelectedIndexChanged += new TTControlEventDelegate(MaintenancePlanType_SelectedIndexChanged);
            PlanStrategy.SelectedIndexChanged += new TTControlEventDelegate(PlanStrategy_SelectedIndexChanged);
            cmdPlan.Click += new TTControlEventDelegate(cmdPlan_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            PlannedWorksGrid.SelectionChanged -= new TTControlEventDelegate(PlannedWorksGrid_SelectionChanged);
            MaintenancePlanType.SelectedIndexChanged -= new TTControlEventDelegate(MaintenancePlanType_SelectedIndexChanged);
            PlanStrategy.SelectedIndexChanged -= new TTControlEventDelegate(PlanStrategy_SelectedIndexChanged);
            cmdPlan.Click -= new TTControlEventDelegate(cmdPlan_Click);
            base.UnBindControlEvents();
        }

        private void cmdList_Click()
        {
#region MaintenancePlanForm_cmdList_Click
   BindingList<MaintenancePlan> plans = MaintenancePlan.GetMaintenancePlanByYear(_MaintenancePlan.ObjectContext,((int) _MaintenancePlan.Year));
            bool avaPlan = true;
            if (plans.Count > 0)
            {
                foreach (MaintenancePlan plan in plans)
                {
                    if (plan.ObjectID != _MaintenancePlan.ObjectID)
                    {
                        if (plan.MaintenancePlanType != MaintenancePlanTypeEnum.MaintenanceWithCalibration)
                        {
                            if (_MaintenancePlan.MaintenancePlanType != null)
                            {
                                if (plan.MaintenancePlanType == _MaintenancePlan.MaintenancePlanType)
                                {
                                    avaPlan = false;
                                    break;
                                }
                                else
                                {
                                    avaPlan = true;
                                }
                            }
                            else
                            {
                                string message = SystemMessage.GetMessage(99);
                                throw new TTException(message);
                            }
                        }
                        else
                        {
                            avaPlan = false;
                        }
                    }
                }
            }
            
            if (avaPlan == false)
            {
                throw new TTException(SystemMessage.GetMessageV3(968, new string[]{ _MaintenancePlan.Year.ToString(), _MaintenancePlan.MaintenancePlanType.ToString()})); 
            }

            if( _MaintenancePlan.MaintenancePlanStrategyType !=null && _MaintenancePlan.MaintenancePlanType !=null)
            {
                if(_MaintenancePlan.SenderAccountancy != null)
                {
                    if(_MaintenancePlan.MaintenancePlanStrategyType == MaintenancePlanStrategyEnum.PlanByFixedAsset)
                    {
                        _MaintenancePlan.FillDevices();
                    }
                    if(_MaintenancePlan.MaintenancePlanStrategyType == MaintenancePlanStrategyEnum.PlanByServise)
                    {
                        _MaintenancePlan.FillServices();
                    }
                }
                else
                {
                    string message = SystemMessage.GetMessage(100);
                    TTVisual.InfoBox.Show(message,MessageIconEnum.ErrorMessage);
                }
            }
            else
            {
                string message = SystemMessage.GetMessage(101);
                TTVisual.InfoBox.Show(message ,MessageIconEnum.ErrorMessage);
            }
#endregion MaintenancePlanForm_cmdList_Click
        }

        private void PlannedWorksGrid_SelectionChanged()
        {
#region MaintenancePlanForm_PlannedWorksGrid_SelectionChanged
   if (PlannedWorksGrid.Rows.Count > 0)
            {
                if (PlannedWorksGrid.CurrentCell != null)
                    _MaintenancePlan.MaintenancePlan_PlannedWork = _MaintenancePlan.MaintenancePlan_PlannedWorks[PlannedWorksGrid.CurrentCell.RowIndex];
            }
#endregion MaintenancePlanForm_PlannedWorksGrid_SelectionChanged
        }

        private void MaintenancePlanType_SelectedIndexChanged()
        {
#region MaintenancePlanForm_MaintenancePlanType_SelectedIndexChanged
   //this._MaintenancePlan.FillDevices();
           // _MaintenancePlan.CalculateTotalServiceWorkloads((MaintenancePlanTypeEnum)_MaintenancePlan.MaintenancePlanType);
#endregion MaintenancePlanForm_MaintenancePlanType_SelectedIndexChanged
        }

        private void PlanStrategy_SelectedIndexChanged()
        {
#region MaintenancePlanForm_PlanStrategy_SelectedIndexChanged
   if(_MaintenancePlan.MaintenancePlanStrategyType != null)
            {
                if (_MaintenancePlan.MaintenancePlanStrategyType.Value == MaintenancePlanStrategyEnum.PlanByFixedAsset) //PlanByFixedAsset
                {
                    if (tttabcontrol1.TabPages.Contains(byDeviceTab) == false)
                        tttabcontrol1.TabPages.Add(byDeviceTab);
                    tttabcontrol1.TabPages.Remove(byServiceTab);
                    //                tttabcontrol1.TabPages.RemoveAt(1);
                }
                else if (_MaintenancePlan.MaintenancePlanStrategyType.Value == MaintenancePlanStrategyEnum.PlanByServise) //PlanByService
                {
                    if (tttabcontrol1.TabPages.Contains(byServiceTab) == false)
                        tttabcontrol1.TabPages.Add(byServiceTab);
                    tttabcontrol1.TabPages.Remove(byDeviceTab);
                    //                tttabcontrol1.TabPages.RemoveAt(0);
                }
                else
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(98));
                }
            }
#endregion MaintenancePlanForm_PlanStrategy_SelectedIndexChanged
        }

        private void cmdPlan_Click()
        {
#region MaintenancePlanForm_cmdPlan_Click
   if (_MaintenancePlan.Year < 2008 || _MaintenancePlan.Year > 2050)
            {
                TTVisual.InfoBox.Show("Geçersiz Planlama Yılı.", MessageIconEnum.ErrorMessage);
            }
            else
            {
                this.Year.ReadOnly  = true ;
                this.SenderAccountancy.ReadOnly = true;
                this.MaintenancePlanType.ReadOnly = true;
                this.PlanStrategy.ReadOnly = true;
                this.cmdList.Enabled = false ;
                if (_MaintenancePlan.MaintenancePlan_Personnels.Count == 0)
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(97));
                }
                System.Threading.Thread newThread = new System.Threading.Thread(ProgressFormControl.Show);
                newThread.Start(this.Year.Text.ToString() + " yılı için planlama yapılıyor....");
                System.Threading.Thread.Sleep(0);
                ProgressFormControl.FormText = "Planlama İşlemi Yapılmaktadır.Lütfen Bekleyiniz..";
                if (newThread.IsAlive == false)
                    throw new Exception(SystemMessage.GetMessage(969));
                _MaintenancePlan.DistributeWorks();
                newThread.Abort();
            }
#endregion MaintenancePlanForm_cmdPlan_Click
        }

        protected override void ClientSidePreScript()
        {
#region MaintenancePlanForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            if (_MaintenancePlan.CurrentStateDefID.Equals(MaintenancePlan.States.New))
            {
                _MaintenancePlan.MaintenancePlanStrategyType = null;
                int recYear = Common.RecTime().Year + 1;
                _MaintenancePlan.Year = (long)recYear;
            }
            else
                this.Year.ReadOnly = true;
            
            ResHospital hospital = Common.GetCurrentHospital(_MaintenancePlan.ObjectContext);
            if(hospital.Site.ObjectID != Sites.SiteSihhiIkmal)
            {
                BindingList<ResAccountancy> accountancies = hospital.Accountancies ;
                if(accountancies.Count == 1)
                {
                    _MaintenancePlan.SenderAccountancy = (Accountancy)accountancies[0].Accountancy;
                }
                else
                {
                    MultiSelectForm mSelectForm = new MultiSelectForm();
                    foreach (ResAccountancy accountancy in accountancies)
                    {
                        mSelectForm.AddMSItem(accountancy.Name, accountancy.ObjectID.ToString(), accountancy);
                    }
                    string mkey = mSelectForm.GetMSItem(this , "İlgili Saymanlığı Seçiniz", true);
                    if (string.IsNullOrEmpty(mkey))
                    {
                        throw new TTException(SystemMessage.GetMessage(371));
                    }
                    _MaintenancePlan.SenderAccountancy = mSelectForm.MSSelectedItemObject as Accountancy ;
                }
                this.SenderAccountancy.ReadOnly = true;
            }

            string filiterEx = string.Empty;
            IList resDivisionSubSections = _MaintenancePlan.ObjectContext.QueryObjects("RESDIVISIONSUBSECTION");
            foreach (ResDivisionSubSection subSection in resDivisionSubSections)
            {
                filiterEx = filiterEx + "'" + subSection.ObjectID.ToString() + "',";
            }
            filiterEx = filiterEx.Substring(0, filiterEx.Length - 1);
            string nfe = "RESOURCE in (" + filiterEx + ")";

            WorkShopUser.ListFilterExpression = " USERRESOURCES(" + nfe + ").EXISTS";
#endregion MaintenancePlanForm_ClientSidePreScript

        }
    }
}