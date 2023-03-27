
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
    public partial class QueuePriorityTemplateDefForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            QueueTemplatePriorityGridObjects.CellValueChanged += new TTGridCellEventDelegate(QueueTemplatePriorityGridObjects_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            QueueTemplatePriorityGridObjects.CellValueChanged -= new TTGridCellEventDelegate(QueueTemplatePriorityGridObjects_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void QueueTemplatePriorityGridObjects_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region QueuePriorityTemplateDefForm_QueueTemplatePriorityGridObjects_CellValueChanged
   if(QueueTemplatePriorityGridObjects.CurrentCell.OwningColumn.Name == QueuePriorityDefinitionQueueTempPriorityGridObject.Name)
                QueueTemplatePriorityGridObjects.CurrentCell.OwningRow.Cells[QueuePrioritySystem.Name].Value = null;
            else if (QueueTemplatePriorityGridObjects.CurrentCell.OwningColumn.Name == QueuePrioritySystem.Name)
                QueueTemplatePriorityGridObjects.CurrentCell.OwningRow.Cells[QueuePriorityDefinitionQueueTempPriorityGridObject.Name].Value = null;
#endregion QueuePriorityTemplateDefForm_QueueTemplatePriorityGridObjects_CellValueChanged
        }
    }
}