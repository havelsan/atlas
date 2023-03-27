
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Bakım ve Kalibrasyon Planlama
    /// </summary>
    public  partial class MaintenancePlan : CMRAction
    {
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
             CreateAllWorks();

#endregion PostTransition_Approval2Completed
        }

        protected void PreTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PreTransition_Completed2Cancelled
            

            bool error = false;
            string errorMessage = string.Empty ;
            foreach (MaintenancePlan_PlannedWork plannedWork in MaintenancePlan_PlannedWorks)
            {
                if(plannedWork.Calibration != null)
                {
                    if (plannedWork.Calibration.CurrentStateDefID != Calibration.States.ForkNew && plannedWork.Calibration.CurrentStateDefID != Calibration.States.Cancelled)
                    {
                        error = true;
                        string msgCal = string.Empty;
                        if(plannedWork.Calibration.FixedAssetMaterialDefinition.Description !=  null)
                        {
                            msgCal = plannedWork.Calibration.FixedAssetMaterialDefinition.Description + " cihazın kalibrasyon işlemi başlatılmış.\r\n";
                        }
                        else
                        {
                            if(plannedWork.Calibration.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                                msgCal = plannedWork.Calibration.FixedAssetMaterialDefinition.FixedAssetDefinition + " cihazın kalibrasyon işlemi başlatılmış.\r\n";
                            else
                                msgCal = TTUtils.CultureService.GetText("M26691", "Planlama içerisinde işlemi başlatılmış ve demirbaş malzemesi bulunanamış kalibrasyon işlemi bulunmaktadır.\r\n");

                        }
                        errorMessage = errorMessage + msgCal;
                    }
                }
                
                if(plannedWork.Maintenance != null)
                {
                    if (plannedWork.Maintenance.CurrentStateDefID != Maintenance.States.ForkNew && plannedWork.Maintenance.CurrentStateDefID != Maintenance.States.Cancelled)
                    {
                        error = true;
                        string msgMain = string.Empty;
                        if (plannedWork.Maintenance.FixedAssetMaterialDefinition.Description != null)
                        {
                            msgMain = plannedWork.Maintenance.FixedAssetMaterialDefinition.Description + " cihazın bakım işlemi başlatılmış.\r\n";
                        }
                        else
                        {
                            if (plannedWork.Maintenance.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                                msgMain = plannedWork.Maintenance.FixedAssetMaterialDefinition.FixedAssetDefinition + " cihazın bakım işlemi başlatılmış.\r\n";
                            else
                                msgMain = TTUtils.CultureService.GetText("M26690", "Planlama içerisinde işlemi başlatılmış ve demirbaş malzemesi bulunanamış bakım işlemi bulunmaktadır.\r\n");

                        }
                        errorMessage = errorMessage + msgMain;
                    }
                }
            }

            if (error)
            {
                throw new TTException(errorMessage);
            }
            else
            {
                foreach (MaintenancePlan_PlannedWork plannedWork in MaintenancePlan_PlannedWorks)
                {
                    if(plannedWork.Calibration != null)
                    {
                        if(plannedWork.Calibration.CurrentStateDefID == Calibration.States.ForkNew)
                            plannedWork.Calibration.CurrentStateDefID = Calibration.States.Cancelled;
                    }
                    
                    if(plannedWork.Maintenance != null)
                    {
                        if(plannedWork.Maintenance.CurrentStateDefID == Maintenance.States.ForkNew)
                            plannedWork.Maintenance.CurrentStateDefID = Maintenance.States.Cancelled;
                    }
                }
            }
            

#endregion PreTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
#region UndoTransition_Completed2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Completed2Cancelled
        }

        protected void PreTransition_New2Approval()
        {
            // From State : New   To State : Approval
#region PreTransition_New2Approval
            
            if(_MaintenancePlan_PlannedWorks.Count == 0)
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M26692", "Planlama Yapmadan İşlem ilerletilemez!"));
            }
#endregion PreTransition_New2Approval
        }

#region Methods
        override protected void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew && RequestNo == null)
            {
                RequestNo = "0";
            }
        }
        /// <summary>
        /// Tatil günü dışında planlama yapılabilecek günleri liste halinde dönderir.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="lastTime"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public ArrayList AvailableDates ( double  period, DateTime lastTime, int year)
        {
            DateTime planedtime;
            ArrayList dateList = new ArrayList();
            TTObjectContext context = new TTObjectContext(true);
            //WorkDayExceptionDef wde = null ;
            WorkDayExceptionDef wde = new WorkDayExceptionDef (context);

            for (int i = 0; i < 12 ; i++)
            {
                planedtime = lastTime.AddMonths((int)period);
                if (planedtime.Year == year)
                {
                    if(wde.IsWorkDay (planedtime.Date))
                    {
                        dateList.Add(planedtime);
                        lastTime = planedtime ;
                    }
                    else
                    {
                        for (int k = 1 ; k < 7; k++)
                        {
                            planedtime = planedtime.AddDays(1);
                            if(wde.IsWorkDay(planedtime.Date))
                            {
                                dateList.Add(planedtime);
                                lastTime=planedtime ;
                                break;
                            }
                        }
                    }
                    
                }
                else
                {
                    if (planedtime.Year > year)
                    {
                        break;
                    }
                    else
                    {
                        lastTime = planedtime;
                    }
                }
            }
            return dateList;
        }
        
        /// <summary>
        /// Uygun Cihazları doldurur.
        /// </summary>
        public void FillDevices()
        {
            MaintenancePlan_Devices.Clear();
            Dictionary<Guid, string> missingCalibrationTimes = new Dictionary<Guid, string>();
            switch (MaintenancePlanType.Value)
            {
                case MaintenancePlanTypeEnum.Calibration:
                    IList calibrationFixedassetMaterial = ObjectContext.QueryObjects("FIXEDASSETMATERIALDEFINITION", "FIXEDASSETDEFINITION.NEEDCALIBRATION = 1 AND STOCK IS NOT NULL");
                    foreach (FixedAssetMaterialDefinition fixedAssetMaterialDefinition in calibrationFixedassetMaterial)
                    {
                        if(fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime != null && fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationPeriod != null)
                        {
                            if (fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime > 0 && fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationPeriod > 0)
                            {
                                MaintenancePlan_Device maintenancePlanDevice = MaintenancePlan_Devices.AddNew();
                                maintenancePlanDevice.FixedAssetMaterialDefinition = fixedAssetMaterialDefinition;
                            }
                            else
                            {
                                if (missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID) == false)
                                    missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                            }

                        }
                        else
                        {
                            if (missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID) == false)
                                missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                        }
                    }
                    break;
                case MaintenancePlanTypeEnum.Maintenance:
                    IList maintenanceFixedassetMaterial = ObjectContext.QueryObjects("FIXEDASSETMATERIALDEFINITION", "FIXEDASSETDEFINITION.NEEDMAINTENANCE = 1 AND STOCK IS NOT NULL");
                    foreach (FixedAssetMaterialDefinition fixedAssetMaterialDefinition in maintenanceFixedassetMaterial)
                    {
                        if (fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime != null && fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenancePeriod  != null)
                        {
                            if (fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime > 0 && fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenancePeriod > 0)
                            {
                                MaintenancePlan_Device maintenancePlanDevice = MaintenancePlan_Devices.AddNew();
                                maintenancePlanDevice.FixedAssetMaterialDefinition = fixedAssetMaterialDefinition;
                            }
                            else
                            {
                                if (missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID) == false)
                                    missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                            }
                        }
                        else
                        {
                            if (missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID) == false)
                                missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                        }
                    }
                    break;
                case MaintenancePlanTypeEnum.MaintenanceWithCalibration:
                    IList fixedassetMaterialDefinitions = ObjectContext.QueryObjects("FIXEDASSETMATERIALDEFINITION", "FIXEDASSETDEFINITION IS NOT NULL AND STOCK IS NOT NULL");
                    foreach (FixedAssetMaterialDefinition fixedAssetMaterialDefinition in fixedassetMaterialDefinitions)
                    {
                        bool added = false;
                        if ((bool)fixedAssetMaterialDefinition.FixedAssetDefinition.NeedCalibration)
                        {
                            if (fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime != null && fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationPeriod != null)
                            {
                                if (fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime > 0 && fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationPeriod > 0)
                                {
                                    MaintenancePlan_Device maintenancePlanDevice = MaintenancePlan_Devices.AddNew();
                                    maintenancePlanDevice.FixedAssetMaterialDefinition = fixedAssetMaterialDefinition;
                                }
                            }
                        }
                        if ((bool)fixedAssetMaterialDefinition.FixedAssetDefinition.NeedMaintenance)
                        {
                            if (added == false)
                            {
                                if (fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime != null && fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenancePeriod != null)
                                {
                                    if (fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime > 0 && fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenancePeriod > 0)
                                    {
                                        MaintenancePlan_Device maintenancePlanDevice = MaintenancePlan_Devices.AddNew();
                                        maintenancePlanDevice.FixedAssetMaterialDefinition = fixedAssetMaterialDefinition;
                                        added = true;
                                    }
                                }
                            }
                        }
                        if (added == false)
                        {
                            if (missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID) == false)
                                missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                        }
                    }
                    break;
            }
            
            string errStr = TTUtils.CultureService.GetText("M25195", "Aşağıdaki cihazların bakım ve(veya) kalibrasyon süreleri tanımlanmadığı planlama işlemine dahil edilmedi.\r\n");
            foreach (KeyValuePair<Guid, string> kp in missingCalibrationTimes)
            {
                errStr += "\n" + kp.Value.ToString();
            }
            if (missingCalibrationTimes.Count > 0)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(errStr);
            }
        }
        
        /// <summary>
        /// Uygun Servisleri Doldurur.
        /// </summary>
        public void FillServices()
        {
            _MaintenancePlan_Services.Clear();
            Dictionary<Guid, double> services = new Dictionary<Guid, double>();
            Dictionary<Guid, string> missingCalibrationTimes = new Dictionary<Guid, string>();
            bool needCal = true;
            foreach(FixedAssetMaterialDefinition fixedAssetMaterialDefinition in FixedAssetMaterialDefinition.GetFixedAssetMaterialsByAccountancy(ObjectContext,SenderAccountancy.ObjectID))
            {
                switch (MaintenancePlanType.Value)
                {
                    case MaintenancePlanTypeEnum.Calibration:
                        needCal = (bool)fixedAssetMaterialDefinition.FixedAssetDefinition.NeedCalibration;
                        if (needCal)
                        {
                            if (fixedAssetMaterialDefinition.FixedAssetDefinition != null)
                            {
                                if (fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime != null)
                                {
                                    double workLoad = 0;
                                    if(fixedAssetMaterialDefinition.Resource != null)
                                    {
                                        if (services.ContainsKey(fixedAssetMaterialDefinition.Resource.ObjectID))
                                        {
                                            workLoad = (double)fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime;
                                            workLoad = workLoad + services[fixedAssetMaterialDefinition.Resource.ObjectID];
                                            services.Remove(fixedAssetMaterialDefinition.Resource.ObjectID);
                                            services.Add(fixedAssetMaterialDefinition.Resource.ObjectID, workLoad);
                                        }
                                        else
                                        {
                                            workLoad = (double)fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime;
                                            services.Add(fixedAssetMaterialDefinition.Resource.ObjectID, workLoad);
                                        }
                                    }
                                }
                                else
                                {
                                    if (!missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID))
                                    {
                                        missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                                    }
                                }
                            }
                        }
                        break;
                    case MaintenancePlanTypeEnum.Maintenance :
                        if (fixedAssetMaterialDefinition.FixedAssetDefinition != null)
                        {
                            if (fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime != null)
                            {
                                double workLoad = 0;
                                if(fixedAssetMaterialDefinition.Resource != null)
                                {
                                    if (services.ContainsKey(fixedAssetMaterialDefinition.Resource.ObjectID))
                                    {
                                        workLoad = (double)fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime ;
                                        workLoad = workLoad + services[fixedAssetMaterialDefinition.Resource.ObjectID];
                                        services.Remove(fixedAssetMaterialDefinition.Resource.ObjectID);
                                        services.Add(fixedAssetMaterialDefinition.Resource.ObjectID, workLoad);
                                    }
                                    else
                                    {
                                        workLoad = (double)fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime;
                                        services.Add(fixedAssetMaterialDefinition.Resource.ObjectID, workLoad);
                                    }
                                }
                            }
                            else
                            {
                                if (!missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID))
                                {
                                    missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                                }
                            }
                        }
                        break;
                    case MaintenancePlanTypeEnum.MaintenanceWithCalibration :
                        if (fixedAssetMaterialDefinition.FixedAssetDefinition != null)
                        {
                            if (fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime != null && fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime != null)
                            {
                                double workLoad = 0;
                                if(fixedAssetMaterialDefinition.Resource != null)
                                {
                                    if (services.ContainsKey(fixedAssetMaterialDefinition.Resource.ObjectID))
                                    {
                                        workLoad = (double)fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime + (double)fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime;
                                        workLoad = workLoad + services[fixedAssetMaterialDefinition.Resource.ObjectID];
                                        services.Remove(fixedAssetMaterialDefinition.Resource.ObjectID);
                                        services.Add(fixedAssetMaterialDefinition.Resource.ObjectID, workLoad);
                                    }
                                    else
                                    {
                                        workLoad = (double)fixedAssetMaterialDefinition.FixedAssetDefinition.MaintenanceTime + (double)fixedAssetMaterialDefinition.FixedAssetDefinition.CalibrationTime;
                                        services.Add(fixedAssetMaterialDefinition.Resource.ObjectID, workLoad);
                                    }
                                }
                            }
                            else
                            {
                                if (!missingCalibrationTimes.ContainsKey(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID))
                                {
                                    missingCalibrationTimes.Add(fixedAssetMaterialDefinition.FixedAssetDefinition.ObjectID, fixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString());
                                }
                            }
                        }
                        break;
                    default:
                        throw new TTUtils.TTException(SystemMessage.GetMessage(967));
                        //break;
                }
            }
            foreach (KeyValuePair<Guid, double> res in services)
            {
                MaintenancePlan_Service maintenancePlanService = MaintenancePlan_Services.AddNew();
                Resource resource = (Resource)ObjectContext.GetObject(res.Key,"RESOURCE");
                maintenancePlanService.Resource = resource ;
                maintenancePlanService.Workload = (int)res.Value;
            }
            string errStr = TTUtils.CultureService.GetText("M25194", "Aşağıdaki cihazların bakım ve kalibrasyon süreleri tanımlanmadığı için işlem ilerletilemez.\n");
            foreach (KeyValuePair<Guid, string> kp in missingCalibrationTimes)
            {
                errStr += "\n" + kp.Value.ToString();
            }
            if (missingCalibrationTimes.Count > 0)
                TTUtils.InfoMessageService.Instance.ShowMessage(errStr);
        }

        /// <summary>
        /// İşlem dağıtımlarını yapar.
        /// </summary>
        public void DistributeWorks()
        {
            MaintenancePlan_PlannedWorks.Clear();
            foreach(MaintenancePlan_Personnel mpp in MaintenancePlan_Personnels)
            {
                mpp.Workload = 0;
            }
            
            if (_MaintenancePlan_Personnels.Count == 0)
            {
                string message = SystemMessage.GetMessage(97);
                throw new TTUtils.TTException(message);
            }

            if (MaintenancePlanStrategyType.Value == MaintenancePlanStrategyEnum.PlanByFixedAsset)
            {   // CİHAZ BAZINDA
                foreach(MaintenancePlan_Device mpd in _MaintenancePlan_Devices)
                {
                    CreateMaintenancePlan_PlannedWork(mpd.FixedAssetMaterialDefinition, null);
                }
            }
            else if (MaintenancePlanStrategyType.Value == MaintenancePlanStrategyEnum.PlanByServise)
            { //SERVİS BAZINDA
                ResUser resp;
                foreach(MaintenancePlan_Service maintenancePlanService in MaintenancePlan_Services)
                {
                    resp = SelectAvailableUser();
                    maintenancePlanService.WorkShopUser = resp;
                    foreach (FixedAssetMaterialDefinition fam in FixedAssetMaterialDefinition.GetFixedAssetMaterialsByResource(ObjectContext,maintenancePlanService.Resource.ObjectID))
                    {
                        CreateMaintenancePlan_PlannedWork(fam, resp);
                    }
                    resp = null;
                }
            }
            else
            {
                string message = SystemMessage.GetMessage(98);
                throw new TTUtils.TTException(message);
            }
        }
        
        /// <summary>
        /// Planlar Sekmesini doldurur.
        /// </summary>
        /// <param name="fmd"></param>
        /// <param name="wsu"></param>
        public void CreateMaintenancePlan_PlannedWork(FixedAssetMaterialDefinition fmd, ResUser wsu)
        {
            bool cal = (bool)fmd.FixedAssetDefinition.NeedCalibration;
            int MaintenanceWorkload = (int)fmd.FixedAssetDefinition.MaintenanceTime;
            int CalibrationWorkload = 0;
            
            if (fmd.FixedAssetDefinition.CalibrationTime != null)
            {
                if (fmd.FixedAssetDefinition.CalibrationTime > 0)
                    CalibrationWorkload = (int)fmd.FixedAssetDefinition.CalibrationTime;
            }
            
            switch (MaintenancePlanType.Value)
            {
                case MaintenancePlanTypeEnum.Calibration :
                    if(cal)
                    {
                        ArrayList availableDatesOnlyCalibration = AvailableDates((double)fmd.FixedAssetDefinition.CalibrationPeriod ,(DateTime)fmd.LastCalibrationDate ,(int)Year);
                        for (int i = 0; i < availableDatesOnlyCalibration.Count; i++)
                        {
                            //WorkShopUserDefinition p = null;
                            MaintenancePlan_PlannedWork mpw = new MaintenancePlan_PlannedWork(ObjectContext);
                            mpw.CurrentStateDefID = MaintenancePlan_PlannedWork.States.New;
                            mpw.MaintenancePlan = this;
                            mpw.FixedAssetMaterialDefinition = fmd;
                            mpw.Service = fmd.Service;
                            //Personel Seç
                            if (wsu == null)
                            {
                                mpw.WorkShopUser = SelectAvailableUser();
                            }
                            else
                            {
                                mpw.WorkShopUser = wsu;
                            }
                            mpw.MaintenancePlanType = MaintenancePlanTypeEnum.Calibration;
                            mpw.Date = (DateTime)availableDatesOnlyCalibration[i];
                            UpdateWorkloads(CalibrationWorkload, mpw);
                        }
                    }
                    break;
                case MaintenancePlanTypeEnum.Maintenance:
                    ArrayList availableDatesOnlyMaintenance = AvailableDates((double)fmd.FixedAssetDefinition.MaintenancePeriod ,(DateTime)fmd.LastMaintenanceDate ,(int)Year);
                    for (int i = 0; i < availableDatesOnlyMaintenance.Count; i++)
                    {
                        //WorkShopUserDefinition p = null;
                        MaintenancePlan_PlannedWork mpw = new MaintenancePlan_PlannedWork(ObjectContext);
                        mpw.CurrentStateDefID = MaintenancePlan_PlannedWork.States.New;
                        mpw.MaintenancePlan = this;
                        mpw.FixedAssetMaterialDefinition = fmd;
                        mpw.Service = fmd.Service;
                        //Personel Seç
                        if (wsu == null)
                        {
                            mpw.WorkShopUser = SelectAvailableUser();
                        }
                        else
                        {
                            mpw.WorkShopUser = wsu;
                        }
                        mpw.MaintenancePlanType = MaintenancePlanTypeEnum.Maintenance;
                        mpw.Date = (DateTime)availableDatesOnlyMaintenance[i];
                        UpdateWorkloads(CalibrationWorkload, mpw);
                    }
                    break;
                case MaintenancePlanTypeEnum.MaintenanceWithCalibration:
                    if(cal)
                    {
                        ArrayList availableDatesCalibration = AvailableDates((double)fmd.FixedAssetDefinition.CalibrationPeriod ,(DateTime)fmd.LastCalibrationDate ,(int)Year);
                        for ( int i=0 ; i< availableDatesCalibration.Count ; i++)
                        {
                            WorkShopUserDefinition p = null;
                            MaintenancePlan_PlannedWork mpwc = new MaintenancePlan_PlannedWork(ObjectContext);
                            mpwc.CurrentStateDefID = MaintenancePlan_PlannedWork.States.New;
                            mpwc.MaintenancePlan = this;
                            mpwc.FixedAssetMaterialDefinition = fmd;
                            mpwc.Service = fmd.Service;
                            //Personel Seç
                            if (wsu == null)
                            {
                                mpwc.WorkShopUser = SelectAvailableUser();
                            }
                            else
                            {
                                mpwc.WorkShopUser = wsu;
                            }
                            mpwc.MaintenancePlanType = MaintenancePlanTypeEnum.Calibration;
                            mpwc.Date = (DateTime)availableDatesCalibration[i];
                            UpdateWorkloads(CalibrationWorkload, mpwc);
                        }
                    }
                    ArrayList availableDatesMaintenance = AvailableDates((double)fmd.FixedAssetDefinition.MaintenancePeriod ,(DateTime)fmd.LastMaintenanceDate ,(int)Year);
                    for ( int i=0 ; i< availableDatesMaintenance.Count ; i++)
                    {
                        WorkShopUserDefinition p = null;
                        MaintenancePlan_PlannedWork mpwm = new MaintenancePlan_PlannedWork(ObjectContext);
                        mpwm.CurrentStateDefID = MaintenancePlan_PlannedWork.States.New;
                        mpwm.MaintenancePlan = this;
                        mpwm.FixedAssetMaterialDefinition = fmd;
                        mpwm.Service = fmd.Service;
                        //Personel Seç
                        if (wsu == null)
                        {
                            mpwm.WorkShopUser = SelectAvailableUser();
                        }
                        else
                        {
                            mpwm.WorkShopUser = wsu;
                        }
                        mpwm.MaintenancePlanType = MaintenancePlanTypeEnum.Maintenance;
                        mpwm.Date = (DateTime)availableDatesMaintenance[i];
                        UpdateWorkloads(CalibrationWorkload, mpwm);
                    }
                    break;

                default:
                    throw new TTUtils.TTException(SystemMessage.GetMessage(967));
                    //break;
            }
        }
        
        
        /// <summary>
        /// Bakım ve Kalibrasyon işlemlerini yaratır.
        /// </summary>
        public void CreateAllWorks()
        {
            foreach(MaintenancePlan_PlannedWork mpw in MaintenancePlan_PlannedWorks)
            {
                if (mpw.MaintenancePlanType == MaintenancePlanTypeEnum.Calibration)
                {
                    Calibration cal = new Calibration(ObjectContext);
                    cal.FixedAssetMaterialDefinition = mpw.FixedAssetMaterialDefinition;
                    cal.RequestDate = mpw.Date;
                    cal.WorkListDate = mpw.Date;
                    cal.WorkShop = findWorkShop((ResUser)mpw.WorkShopUser);
                    cal.Section = findSection(cal.WorkShop);
                    cal.ResponsibleUser = mpw.WorkShopUser ;
                    cal.CurrentStateDefID = Calibration.States.ForkNew;
                    mpw.Calibration = cal;
                }
                else
                {
                    Maintenance m = new Maintenance(ObjectContext);
                    m.FixedAssetMaterialDefinition = mpw.FixedAssetMaterialDefinition;
                    m.RequestDate = mpw.Date;
                    m.WorkListDate = mpw.Date;
                    m.WorkShop = findWorkShop((ResUser)mpw.WorkShopUser);
                    m.Section  = findSection(m.WorkShop);
                    m.ResponsibleUser = mpw.WorkShopUser;
                    m.CurrentStateDefID = Maintenance.States.ForkNew;
                    mpw.Maintenance = m;
                }
            }
        }

        public ResDivisionSubSection findWorkShop(ResUser wuser)
        {
            ResDivisionSubSection subSection = null;
            foreach (UserResource userResource in wuser.UserResources)
            {
                if (userResource.Resource is ResDivisionSubSection)
                {
                    subSection = (ResDivisionSubSection)userResource.Resource;
                    break;
                }
            }
            return subSection;
        }

        public ResDivisionSection findSection(ResDivisionSubSection uworkShop)
        {
            ResDivisionSection section = uworkShop.DivisionSection;
            return section;
        }

        public ResUser SelectAvailableUser()
        {
            ResUser p = null;
            
            int lowest = 99999;
            foreach(MaintenancePlan_Personnel pers in MaintenancePlan_Personnels)
            {
                if (pers.Workload.Value < lowest)
                {
                    lowest = pers.Workload.Value;
                    p = pers.WorkShopUser ;
                }
            }
            return p;
        }
        
        
        
        public void UpdateWorkloads(int deviceWorkload, MaintenancePlan_PlannedWork mpw)
        {
            foreach(MaintenancePlan_Personnel pers in MaintenancePlan_Personnels)
            {
                if (pers.WorkShopUser == mpw.WorkShopUser)
                {
                    pers.Workload += deviceWorkload;
                    break;
                }
            }
        }

        public void CreateMaintenance(MaintenancePlan_PlannedWork mpw, FixedAssetMaterialDefinition fmd)
        {
            Maintenance main =  new Maintenance(ObjectContext);
            main.FixedAssetMaterialDefinition = fmd;
            mpw.Maintenance = main;
            //return main;
        }
        
        public void CreateCalibration(MaintenancePlan_PlannedWork mpw, FixedAssetMaterialDefinition fmd)
        {
            Calibration cal = new Calibration(ObjectContext);
            cal.FixedAssetMaterialDefinition = fmd;
            mpw.Calibration = cal;
            //return cal;
        }

        
        public int GetTotalPersonnelWorkload(WorkShopUserDefinition p, DateTime dateToCheck)
        {
            int Workload = 0;
            foreach(MaintenancePlan_PlannedWork mpw in MaintenancePlan_PlannedWorks)
            {
                foreach(MaintenancePlan_PlannedWorkDetail mpwd in mpw.MaintenancePlan_PlannedWorkDetails)
                {
                    if (mpw.WorkShopUser == p && mpwd.Date == dateToCheck)
                    {
                        Workload += mpwd.Workload.Value;
                    }
                }
            }
            return Workload;
        }

        public void AddPlannedWorkDetail(DateTime date, int workload, MaintenancePlan_PlannedWork maintenanceplannedwork)
        {
            MaintenancePlan_PlannedWorkDetail mpwd = new MaintenancePlan_PlannedWorkDetail(ObjectContext);
            mpwd.MaintenancePlan_PlannedWork = maintenanceplannedwork;
            mpwd.Date = date;
            mpwd.Workload = workload;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaintenancePlan).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaintenancePlan.States.Completed && toState == MaintenancePlan.States.Cancelled)
                PreTransition_Completed2Cancelled();
            else if (fromState == MaintenancePlan.States.New && toState == MaintenancePlan.States.Approval)
                PreTransition_New2Approval();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaintenancePlan).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaintenancePlan.States.Approval && toState == MaintenancePlan.States.Completed)
                PostTransition_Approval2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MaintenancePlan).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MaintenancePlan.States.Completed && toState == MaintenancePlan.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
        }

    }
}