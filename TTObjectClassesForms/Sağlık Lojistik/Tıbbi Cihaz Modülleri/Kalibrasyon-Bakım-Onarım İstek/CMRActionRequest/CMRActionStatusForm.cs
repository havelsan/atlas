
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
    /// Kalibrasyon/Bakım/Onarım
    /// </summary>
    public partial class CMRActionStatusForm : CMRActionBaseForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region CMRActionStatusForm_PreScript
    base.PreScript();
            
            this.DropStateButton(CMRActionRequest.States.StageApproval);
            this.DropStateButton(CMRActionRequest.States.Comleted);
            this.DropStateButton(CMRActionRequest.States.Cancelled);                    
            
            switch (_CMRActionRequest.RequestType.Value)
            {
                case RequestTypeEnum.Calibration:
                    Calibration calibration = ((Calibration)_CMRActionRequest.ForkCMRAction[0]) ;
                    this.Statuslabel.Text = "İşlem Durumu : " + calibration.CurrentStateDef.DisplayText.ToString() ;
                    break;
                case RequestTypeEnum.Maintenance:
                    Maintenance maintenance = ((Maintenance)_CMRActionRequest.ForkCMRAction[0]) ;
                    this.Statuslabel.Text = "İşlem Durumu : " + maintenance.CurrentStateDef.DisplayText.ToString() ;
                    break;
                case RequestTypeEnum.Repair:
                    Repair repair = ((Repair)_CMRActionRequest.ForkCMRAction[0]) ;
                    this.Statuslabel.Text = "İşlem Durumu : " + repair.CurrentStateDef.DisplayText.ToString() ;
                    break;
                default:
                    throw new TTUtils.TTException(SystemMessage.GetMessage(940));
                    //break;
            }
#endregion CMRActionStatusForm_PreScript

            }
                }
}