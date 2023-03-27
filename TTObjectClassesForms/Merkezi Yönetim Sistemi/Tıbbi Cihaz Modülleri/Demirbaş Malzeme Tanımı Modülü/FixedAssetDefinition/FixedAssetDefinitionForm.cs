
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
    /// Demirbaş Malzeme Tanımı
    /// </summary>
    public partial class FixedAssetDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            NeedCalibration.CheckedChanged += new TTControlEventDelegate(NeedCalibration_CheckedChanged);
            cmdChangeTypeToConsumable.Click += new TTControlEventDelegate(cmdChangeTypeToConsumable_Click);
            cmdSendChanging.Click += new TTControlEventDelegate(cmdSendChanging_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            NeedCalibration.CheckedChanged -= new TTControlEventDelegate(NeedCalibration_CheckedChanged);
            cmdChangeTypeToConsumable.Click -= new TTControlEventDelegate(cmdChangeTypeToConsumable_Click);
            cmdSendChanging.Click -= new TTControlEventDelegate(cmdSendChanging_Click);
            base.UnBindControlEvents();
        }

        private void NeedCalibration_CheckedChanged()
        {
#region FixedAssetDefinitionForm_NeedCalibration_CheckedChanged
   if (NeedCalibration.Value == true)
            {
                CalibrationPeriod.Enabled = true;
                CalibrationTime.Enabled = true;
            }
            else
            {
                CalibrationPeriod.Text = "";
                CalibrationTime.Text = "";
                CalibrationPeriod.Enabled = false;
                CalibrationTime.Enabled = false;
            }
#endregion FixedAssetDefinitionForm_NeedCalibration_CheckedChanged
        }

        private void cmdChangeTypeToConsumable_Click()
        {
#region FixedAssetDefinitionForm_cmdChangeTypeToConsumable_Click
   //sahalarda güncel mi bakalım
            //ET 29.05.2012
            
            if (_FixedAssetDefinition.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
            {
                throw new Exception("Demirbaş seri numaralı olduğu için sarf malzemeye çevrilemez.");
            }
            else
            {
                TTForm checkForm = new CheckSitesBeforeChangeToConsumableMaterialForm();
                checkForm.ShowEdit(this.FindForm(), _FixedAssetDefinition, false);
            }
            
            //   string result = ShowBox.Show(ShowBoxTypeEnum.Choice, "&Evet,&Hayır", "E,H", "Dikkat!!!", "Malzeme sarfa çevrilecek. Onaylıyor musunuz?");
            //            if (result == "E")
            //            {
            //                TTObjectDataSet dataset = new TTObjectDataSet();
            //                Dictionary<string, object> requiredProps = new Dictionary<string, object>();
            //                TTObjectDef fixedAssetDef = TTObjectDefManager.Instance.GetObjectDef(typeof(FixedAssetDefinition));
            //                TTObjectDef consumableDef = TTObjectDefManager.Instance.GetObjectDef(typeof(ConsumableMaterialDefinition));
            //                dataset.ChangeTTObjectObjectDef(_FixedAssetDefinition.ObjectID, _FixedAssetDefinition.ObjectDef.ID, consumableDef.ID, requiredProps);
//
            //                TTObjectContext context = new TTObjectContext(false);
            //                Material mat = (Material)context.GetObject(_FixedAssetDefinition.ObjectID, typeof(Material).Name);
            //                Guid consGuid = new Guid("db691203-2c64-426c-a737-d0e89859d767");
            //                mat.MaterialTree = (MaterialTreeDefinition)context.GetObject(consGuid, typeof(MaterialTreeDefinition).Name);
            //                context.Save();
            //                context.Dispose();
//
            //                List<string> keys = new List<string>();
            //                List<object> values = new List<object>();
//
            //                foreach(KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
            //                {
            //                    FixedAssetDefinition.RemoteMethods.ChangeFixedAssetMaterialToConsumable(kp.Key, _FixedAssetDefinition.ObjectID, keys, values);
            //                }
//
            //                InfoBox.Show("Değişiklik tüm aktif sahalara yollanmıştır", MessageIconEnum.InformationMessage);
            //                this.Close();
            //            }
            //            else
            //                InfoBox.Show("İşlemden vazgeçildi", MessageIconEnum.InformationMessage);
#endregion FixedAssetDefinitionForm_cmdChangeTypeToConsumable_Click
        }

        private void cmdSendChanging_Click()
        {
#region FixedAssetDefinitionForm_cmdSendChanging_Click
   DataTable tbl = TTAuditRecord.GetObjectAuditRecords(_FixedAssetDefinition.ObjectID, null, null, TTUser.CurrentUser.IsSuperUser);
            bool ChangedBefore = false;
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                if (Convert.ToByte(row["OPERATIONTYPE"]) == 24)
                {
                    ChangedBefore = true;
                    break;
                }
            }

            if (ChangedBefore)
            {
                List<string> keys = new List<string>();
                List<object> values = new List<object>();
                keys.Add("CALIBRATIONPERIOD");
                values.Add(_FixedAssetDefinition.CalibrationPeriod);
                keys.Add("CALIBRATIONTIME");
                values.Add(_FixedAssetDefinition.CalibrationTime);
                keys.Add("MAINTENANCEPERIOD");
                values.Add(_FixedAssetDefinition.MaintenancePeriod);
                keys.Add("MAINTENANCETIME");
                values.Add(_FixedAssetDefinition.MaintenanceTime);
                keys.Add("ISCALIBRATOR");
                values.Add(_FixedAssetDefinition.IsCalibrator);
                keys.Add("NEEDCALIBRATION");
                values.Add(_FixedAssetDefinition.NeedCalibration);

                foreach(KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
                {
                   // ConsumableMaterialDefinition.RemoteMethods.ChangeConsumableMaterialToFixedAsset(kp.Key, _FixedAssetDefinition.ObjectID, keys, values);
                }
                
                InfoBox.Show("Değişiklik tüm aktif sahalara yollanmıştır", MessageIconEnum.InformationMessage);
            }
            else
                InfoBox.Show("Bu malzemeye ait eski tarihli bir sınıf değişikliği bulunamadı");
#endregion FixedAssetDefinitionForm_cmdSendChanging_Click
        }

        protected override void PreScript()
        {
#region FixedAssetDefinitionForm_PreScript
    base.PreScript();
            
            if(TTObjectClasses.SystemParameter.GetSite() == null)
            {
                cmdChangeTypeToConsumable.Enabled = false;
                return;
            }
            
            Sites mySite = TTObjectClasses.SystemParameter.GetSite();
            
            
            if(mySite.ObjectID == Sites.SiteMerkezSagKom)
            {
                cmdChangeTypeToConsumable.Enabled = true;
                cmdSendChanging.Enabled = true;
            }
            else
            {
                cmdChangeTypeToConsumable.Enabled = false;
                cmdSendChanging.Enabled = false;
            }
#endregion FixedAssetDefinitionForm_PreScript

            }
                }
}