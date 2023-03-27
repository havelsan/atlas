
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
    /// Demirbaş Bilgileri Tanımlama
    /// </summary>
    public  partial class FixedAssetMaterialDefinition : TerminologyManagerDef
    {
        public partial class FixedAssetMaterialListNQL_Class : TTReportNqlObject 
        {
        }

        public partial class FixedAssetMaterialDefFormNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialPresentationReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialDebitReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialAtRepairReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialAtMaintenanceReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialDefinitionNotUseReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialGuarantyReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialTrackingReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetSetMaterialDetail_Class : TTReportNqlObject 
        {
        }

        public partial class GetDebitReport_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialDistBySerialReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetFixedAssetMaterialAtCalibrationReportQuery_Class : TTReportNqlObject 
        {
        }

        
                    
#region Methods
        public override List<string> GetMyLocalPropertyNamesList()
        {
            
            List<string> localPropertyNamesList = base. GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("RESUSER");
            localPropertyNamesList.Add("RESOURCE");
            localPropertyNamesList.Add("USERNOTE");
            localPropertyNamesList.Add("STOCK");
            localPropertyNamesList.Add("PERSONNEL");
            localPropertyNamesList.Add("SERVICE");
            
            return localPropertyNamesList;
        }
        
        protected override void OnBeforeImportFromObject(DataRow dataRow)
        {
            base.OnBeforeImportFromObject(dataRow);

            dataRow["STOCK"] = null;
            dataRow["RESOURCE"] = null;
            dataRow["RESUSER"] = null;
            dataRow["USERNOTE"] = null;
            dataRow["PERSONNEL"] = null;
            dataRow["SERVICE"] = null;
        }
        
        public void CopyFromFixedAssetInDetail(FixedAssetInDetail fixedAssetInDetail)
        {
            Description = fixedAssetInDetail.Description;
            FixedAssetNO = fixedAssetInDetail.FixedAssetNO;
            GuarantyStartDate = fixedAssetInDetail.GuarantyStartDate;
            GuarantyEndDate = fixedAssetInDetail.GuarantyEndDate;
            Mark = fixedAssetInDetail.Mark;
            Model = fixedAssetInDetail.Model;
            SerialNumber = fixedAssetInDetail.SerialNumber;
            Status = fixedAssetInDetail.Status;
            Resource = fixedAssetInDetail.Resource;
            FixedAssetDefinition = (FixedAssetDefinition)fixedAssetInDetail.StockActionDetail.Material;
            ProductionDate = fixedAssetInDetail.ProductionDate;
            Power = fixedAssetInDetail.Power;
            Voltage = fixedAssetInDetail.Voltage;
            Frequency = fixedAssetInDetail.Frequency;
            CMRStatus = FixedAssetCMRStatusEnum.InUse;
            
            if(fixedAssetInDetail.FixedAssetMaterialDefDetail != null)
            {
                if(FixedAssetMaterialDefDetail == null)
                    FixedAssetMaterialDefDetail = new FixedAssetMaterialDefinitionDetail (ObjectContext);
                
                FixedAssetMaterialDefDetail = (FixedAssetMaterialDefinitionDetail)fixedAssetInDetail.FixedAssetMaterialDefDetail.Clone();
                FixedAssetMaterialDefDetail.IsFixedAsset = YesNoEnum.Yes;
            }
        }

        
        public int checkCalibrationStatus()
        {
            //TODO:Server tarihi ile kontrol edilmeli
            if (FixedAssetDefinition.CalibrationPeriod == null)
            {
                return -2;
            }
            else
            {
                if (FixedAssetDefinition.CalibrationPeriod == 0)
                {
                    return -2;
                }
                else
                {
                    if (CMRStatus == FixedAssetCMRStatusEnum.InCalibrationProgress)
                    {
                        return -1;
                    }
                    else
                    {
                        if (LastCalibrationDate == null)
                        {
                            return -3;
                        }
                        else
                        {
                            int calibrationPeriod = FixedAssetDefinition.CalibrationPeriod.Value;
                            DateTime lastCalibrationDate = (DateTime)LastCalibrationDate;
                            {
                                TimeSpan sp = System.DateTime.Now.Subtract(lastCalibrationDate);
                                return (calibrationPeriod - sp.Days);
                            }
                        }
                    }
                }
            }
        }
        
        public string DecodeCalibrationStatus()
        {
            int calibrationCheck;
            string retValue;
            
            calibrationCheck = Convert.ToInt16(checkCalibrationStatus());
            
            switch (calibrationCheck)
            {
                case -2:
                    retValue = TTUtils.CultureService.GetText("M25364", "Cihazın kalibrasyon periyodu bilgisi veya son kalibrasyon tarihinde hata var.");
                    break;
                case -1:
                    retValue = TTUtils.CultureService.GetText("M26259", "Kalibrasyonda");
                    break;
                default:
                    if (calibrationCheck > 0)
                    {
                        retValue = "Kalibrasyonuna " + calibrationCheck.ToString() + " gün var";
                    }
                    else
                    {
                        retValue = "Kalibrasyon süresi " + (calibrationCheck * -1).ToString() + " gün geçmiş";
                    }
                    break;
            }
            return retValue;
        }
        
        public bool IsUnderGuaranty()
        {
            DateTime GuarantyEndDate = new DateTime();
            GuarantyEndDate = this.GuarantyEndDate.Value;
            if (DateTime.Compare(GuarantyEndDate, DateTime.Now) > 0)
                return true;
            else
                return false;
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.FixedAssetMaterialDefinitionInfo;
        }
        
#endregion Methods

    }
}