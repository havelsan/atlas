
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
    /// Sipariş Onay
    /// </summary>
    public partial class ApprovalForm_MaintenanceO : TTForm
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
#region ApprovalForm_MaintenanceO_PreScript
    base.PreScript();
            
            if (_MaintenanceOrder.OrderStatus == OrderStatusEnum.HEKFromFromExamination)
            {
                this.DropStateButton(MaintenanceOrder.States.DivisionChiefApproval);
            }
            else
            {
                this.DropStateButton(MaintenanceOrder.States.HEK);
                if(_MaintenanceOrder.ReferType == ReferTypeEnum.Calibration)
                {
                    this.DropStateButton(MaintenanceOrder.States.TechnicalDirectorApproval);
                }
            }

            if( _MaintenanceOrder.CurrentStateDefID ==  MaintenanceOrder.States.OrderApproval )
               {
                   if (_MaintenanceOrder.MaintenanceOrderType.TypeCode == "FS")
                   {
                       this.DropStateButton(MaintenanceOrder.States.DivisionChiefApproval);
                   }
                   
                   if(_MaintenanceOrder.MaintenanceOrderType.TypeCode == "MS")
                   {
                       this.DropStateButton(MaintenanceOrder.States.TechnicalDirectorApproval);
                   }
                   
               }
               //            else
               //            {
               //                if(_MaintenanceOrder.CurrentStateDefID != MaintenanceOrder.States.TechnicalDirectorApproval)
               //                {
               //                    this.DropStateButton(MaintenanceOrder.States.DivisionChiefApproval);
               //                }
               //            }
               
               string txtSeq = _MaintenanceOrder.RequestNoSeq.Value.ToString();
               if (txtSeq.Length == 1)
               {
                   txtSeq = "000" + txtSeq.ToString();
               }
               if (txtSeq.Length == 2)
               {
                   txtSeq = "00" + txtSeq.ToString();
               }
               if (txtSeq.Length == 3)
               {
                   txtSeq = "0" + txtSeq.ToString();
               }
               _MaintenanceOrder.RequestNo = _MaintenanceOrder.RequestNo.Substring(0, 6).ToString() + txtSeq.ToString();
#endregion ApprovalForm_MaintenanceO_PreScript

            }
                }
}