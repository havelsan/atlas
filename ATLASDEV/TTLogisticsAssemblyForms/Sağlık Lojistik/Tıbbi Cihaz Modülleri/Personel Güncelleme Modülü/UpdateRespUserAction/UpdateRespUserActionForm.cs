
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
    /// Personel Güncelleme
    /// </summary>
    public partial class UpdateRespUserActionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdUpdateCMRAction.Click += new TTControlEventDelegate(cmdUpdateCMRAction_Click);
            cmdGetCMRAction.Click += new TTControlEventDelegate(cmdGetCMRAction_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUpdateCMRAction.Click -= new TTControlEventDelegate(cmdUpdateCMRAction_Click);
            cmdGetCMRAction.Click -= new TTControlEventDelegate(cmdGetCMRAction_Click);
            base.UnBindControlEvents();
        }

        private void cmdUpdateCMRAction_Click()
        {
#region UpdateRespUserActionForm_cmdUpdateCMRAction_Click
   if (_UpdateRespUserAction.UpdateUser != null)
            {
                this.cmdUpdateCMRAction.Enabled = false;
                this.UpdateUser.ReadOnly = false;
                foreach (UpdateRespUserActionDetail updateRespUserActionDetail in _UpdateRespUserAction.UpdateRespUserActionDetails)
                {
                    updateRespUserActionDetail.UpdateResUser = _UpdateRespUserAction.UpdateUser;
                }
            }
            else
            {
                throw new TTException("Personel seçmediniz.");
            }
#endregion UpdateRespUserActionForm_cmdUpdateCMRAction_Click
        }

        private void cmdGetCMRAction_Click()
        {
#region UpdateRespUserActionForm_cmdGetCMRAction_Click
   if (_UpdateRespUserAction.ResponsibleUser != null)
            {
                IList activeCMRActions = CMRAction.ActiveCMRActionByRespUser(_UpdateRespUserAction.ObjectContext, _UpdateRespUserAction.ResponsibleUser.ObjectID);
                Dictionary<Guid, CMRAction> actions = new Dictionary<Guid, CMRAction>();
                foreach (CMRAction cmrAction in activeCMRActions)
                {
                    if (cmrAction is Repair)
                        if (cmrAction.CurrentStateDefID == Repair.States.Repair)
                            actions.Add(cmrAction.ObjectID, cmrAction);

                    if (cmrAction is MaterialRepair)
                        if (cmrAction.CurrentStateDefID == MaterialRepair.States.Repair)
                            actions.Add(cmrAction.ObjectID, cmrAction);

                    if (cmrAction is Maintenance)
                        if (cmrAction.CurrentStateDefID == Maintenance.States.Maintenance)
                            actions.Add(cmrAction.ObjectID, cmrAction);

                    if (cmrAction is MaterialMaintenance)
                        if (cmrAction.CurrentStateDefID == MaterialMaintenance.States.Maintenance)
                            actions.Add(cmrAction.ObjectID, cmrAction);

                    if (cmrAction is Calibration)
                        if (cmrAction.CurrentStateDefID == Calibration.States.Calibration)
                            actions.Add(cmrAction.ObjectID, cmrAction);


                    if (cmrAction is MaintenanceOrder)
                        if (cmrAction.CurrentStateDefID == MaintenanceOrder.States.Repair || cmrAction.CurrentStateDefID == MaintenanceOrder.States.SpecialWork || cmrAction.CurrentStateDefID == MaintenanceOrder.States.Manufacturing || cmrAction.CurrentStateDefID == MaintenanceOrder.States.Calibration  )
                            actions.Add(cmrAction.ObjectID, cmrAction);
                }
                foreach (KeyValuePair<Guid, CMRAction> pAction in actions)
                {
                    UpdateRespUserActionDetail updateRespUserActionDetail = new UpdateRespUserActionDetail(_UpdateRespUserAction.ObjectContext);
                    updateRespUserActionDetail.CMRAction = pAction.Value ;
                    updateRespUserActionDetail.UpdateRespUserAction = _UpdateRespUserAction;
                }
                this.cmdGetCMRAction.Enabled = false;
                this.ttobjectlistbox1.ReadOnly = false;
            }
            else
            {
                throw new TTException("Personel Seçmediniz.");
            }
#endregion UpdateRespUserActionForm_cmdGetCMRAction_Click
        }
    }
}