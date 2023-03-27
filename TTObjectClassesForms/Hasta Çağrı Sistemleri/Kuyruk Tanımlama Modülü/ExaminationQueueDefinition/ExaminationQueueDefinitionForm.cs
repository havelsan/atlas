
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
    public partial class ExaminationQueueDefinitionForm : TTDefinitionForm
    {
        override protected void BindControlEvents()
        {
            QueuePriorityTemplateDef.SelectedObjectChanged += new TTControlEventDelegate(QueuePriorityTemplateDef_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            QueuePriorityTemplateDef.SelectedObjectChanged -= new TTControlEventDelegate(QueuePriorityTemplateDef_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void QueuePriorityTemplateDef_SelectedObjectChanged()
        {
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ExaminationQueueDefinitionForm_PostScript
    base.PostScript(transDef);
            
            if(_ExaminationQueueDefinition.IsEmergencyQueue != null && !(bool)_ExaminationQueueDefinition.IsEmergencyQueue && _ExaminationQueueDefinition.ResSection == null)
                throw new TTUtils.TTException("Acil kuyruğu olmayan kuyruklarda poliklinik zorunludur.");
                
            //if(_ExaminationQueueDefinition.IsEmergencyQueue != null && !(bool)_ExaminationQueueDefinition.IsEmergencyQueue && _ExaminationQueueDefinition.QueuePriorityTemplateDef == null)
            //    throw new TTUtils.TTException("Acil kuyruğu olmayan kuyruklarda öncelik sırası şablonu zorunludur.");
#endregion ExaminationQueueDefinitionForm_PostScript

            }
                }
}