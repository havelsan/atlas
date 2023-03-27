
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
    /// HEK İşlemleri
    /// </summary>
    public partial class HEKForm_MaintenanceO : TTForm
    {
        override protected void BindControlEvents()
        {
            MaintanenceOrderHEKReasons.CellValueChanged += new TTGridCellEventDelegate(MaintanenceOrderHEKReasons_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            MaintanenceOrderHEKReasons.CellValueChanged -= new TTGridCellEventDelegate(MaintanenceOrderHEKReasons_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void MaintanenceOrderHEKReasons_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region HEKForm_MaintenanceO_MaintanenceOrderHEKReasons_CellValueChanged
   ITTGridRow mainCheckRow = MaintanenceOrderHEKReasons.Rows[MaintanenceOrderHEKReasons.CurrentCell.RowIndex];
            if (MaintanenceOrderHEKReasons.CurrentCell == mainCheckRow.Cells["CheckMaintanenceOrderHEKReasons"])
            {
                foreach (MaintanenceOrderHEKReasons maintanenceOrderHEKReason in _MaintenanceOrder.MaintanenceOrderHEKReasons)
                {
                    if (maintanenceOrderHEKReason.ObjectID.Equals(mainCheckRow.TTObject.ObjectID) == false)
                        maintanenceOrderHEKReason.Check = false;
                }
               
            }
#endregion HEKForm_MaintenanceO_MaintanenceOrderHEKReasons_CellValueChanged
        }

        protected override void PreScript()
        {
#region HEKForm_MaintenanceO_PreScript
    if (_MaintenanceOrder.OrderStatus == OrderStatusEnum.HEKFromFromExamination)
            {
                this.DropStateButton(MaintenanceOrder.States.LastControl);
                this.DropStateButton(MaintenanceOrder.States.Repair);
            }
            else
            {
                this.DropStateButton(MaintenanceOrder.States.OrderClose);
            }
          
            
            
            
            TTObjectContext context = new TTObjectContext(true);
                     
            if(_MaintenanceOrder.MaintanenceOrderHEKReasons.Count == 0)
            {
                IList reas = _MaintenanceOrder.ObjectContext.QueryObjects("COUSESOFTHEHEKDEFINITION");
                foreach (CousesOfTheHekDefinition cs in reas)
                {
                    MaintanenceOrderHEKReasons maintanenceOrderHEKReasons = _MaintenanceOrder.MaintanenceOrderHEKReasons.AddNew();
                    maintanenceOrderHEKReasons.CousesOfTheHekDefinition = cs;
                    maintanenceOrderHEKReasons.Check = false;
                }
            }
#endregion HEKForm_MaintenanceO_PreScript

            }
                }
}