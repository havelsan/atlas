
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
    public partial class ChangeToFixedAssetFromConsumableForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ChangeToFixedAssetFromConsumableForm_PostScript
    base.PostScript(transDef);
            
            string errMsg = string.Empty;
            if (string.IsNullOrEmpty(txtCalibrationPeriod.Text))
                errMsg += "\r\nKalibrasyon Periyodu";
            if (string.IsNullOrEmpty(txtCalibrationTime.Text))
                errMsg += "\r\nKalibrasyon Saati";
            if (string.IsNullOrEmpty(txtMaintenancePeriod.Text))
                errMsg += "\r\nBakım Periyodu";
            if (string.IsNullOrEmpty(txtMaintenanceTime.Text))
                errMsg += "\r\nBakım Saati";

            if (!string.IsNullOrEmpty(errMsg))
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(1270,new string[] {errMsg}));

            TTObjectDataSet dataset = new TTObjectDataSet();
            Dictionary<string, object> requiredProps = new Dictionary<string,object>();
            requiredProps.Add("CALIBRATIONPERIOD", txtCalibrationPeriod.Text);
            requiredProps.Add("CALIBRATIONTIME", txtCalibrationTime.Text);
            requiredProps.Add("MAINTENANCEPERIOD", txtMaintenancePeriod.Text);
            requiredProps.Add("MAINTENANCETIME", txtMaintenanceTime.Text);
            requiredProps.Add("ISCALIBRATOR", isCalibrator.Value);
            requiredProps.Add("NEEDCALIBRATION", NeedCalibration.Value);
            TTObjectDef fixedAssetDef = TTObjectDefManager.Instance.GetObjectDef(typeof(FixedAssetDefinition));
            dataset.ChangeTTObjectObjectDef(_ConsumableMaterialDefinition.ObjectID, _ConsumableMaterialDefinition.ObjectDef.ID, fixedAssetDef.ID, requiredProps);

            TTObjectContext context = new TTObjectContext(false);
            Material mat = (Material)context.GetObject(_ConsumableMaterialDefinition.ObjectID, typeof(Material).Name);
            Guid fixGuid = new Guid("a6f5144e-b7dd-4f17-9e45-935a3ff249fb");
            mat.MaterialTree = (MaterialTreeDefinition)context.GetObject(fixGuid, typeof(MaterialTreeDefinition).Name);
            context.Save();
            context.Dispose();

//            Dictionary<string, string> strReqProps = new Dictionary<string, string>();
//            foreach (KeyValuePair<string, object> kp in requiredProps)
//            {
//                strReqProps.Add(kp.Key, kp.Value.ToString());
//            }

            List<string> keys = new List<string>();
            List<object> values = new List<object>();
            keys.Add("CALIBRATIONPERIOD");
            values.Add(txtCalibrationPeriod.Text);
            keys.Add("CALIBRATIONTIME");
            values.Add(txtCalibrationTime.Text);
            keys.Add("MAINTENANCEPERIOD");
            values.Add(txtMaintenancePeriod.Text);
            keys.Add("MAINTENANCETIME");
            values.Add(txtMaintenanceTime.Text);
            keys.Add("ISCALIBRATOR");
            values.Add(isCalibrator.Value);
            keys.Add("NEEDCALIBRATION");
            values.Add(NeedCalibration.Value);

            foreach(KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
            {
                //ConsumableMaterialDefinition.RemoteMethods.ChangeConsumableMaterialToFixedAsset(kp.Key, _ConsumableMaterialDefinition.ObjectID, keys, values);
            }
            
            
            
            InfoBox.Alert("Değişiklik tüm aktif sahalara yollanmıştır", MessageIconEnum.InformationMessage);
#endregion ChangeToFixedAssetFromConsumableForm_PostScript

            }
                }
}