
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
    /// Eşdeğer İlaçlar
    /// </summary>
    public partial class DrugEquivalentForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdUserCancelled.Click += new TTControlEventDelegate(cmdUserCancelled_Click);
            cmdChange.Click += new TTControlEventDelegate(cmdChange_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUserCancelled.Click -= new TTControlEventDelegate(cmdUserCancelled_Click);
            cmdChange.Click -= new TTControlEventDelegate(cmdChange_Click);
            base.UnBindControlEvents();
        }

        private void cmdUserCancelled_Click()
        {
#region DrugEquivalentForm_cmdUserCancelled_Click
   this.Close();
#endregion DrugEquivalentForm_cmdUserCancelled_Click
        }

        private void cmdChange_Click()
        {
#region DrugEquivalentForm_cmdChange_Click
   if (this.Equivalents.SelectedItems.Count > 0)
            {
                _DrugOrder.Material = ((Material)this.Equivalents.SelectedItems[0].Tag);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                InfoBox.Show("Hiç ilaç seçmediniz.", MessageIconEnum.WarningMessage);
            }
#endregion DrugEquivalentForm_cmdChange_Click
        }

        protected override void PreScript()
        {
#region DrugEquivalentForm_PreScript
    base.PreScript();
            this.cmdOK.Visible = false ;
            this.cmdCancel.Visible = false ;

            //if (_DrugOrder is OutPatientDrugOrder)
            //            {
            //                this.DropStateButton(OutPatientDrugOrder.States.Planned);
            //                this.DropStateButton(OutPatientDrugOrder.States.Approve);
            //                this.DropStateButton(OutPatientDrugOrder.States.Cancelled);
            //                this.DropStateButton(OutPatientDrugOrder.States.Completed);
            //                this.DropStateButton(OutPatientDrugOrder.States.Continued);
            //                this.DropStateButton(OutPatientDrugOrder.States.Stopped);
            //                this.DropStateButton(OutPatientDrugOrder.States.UnCompleted);
            //            }
            
            if (_DrugOrder is OutPatientDrugOrder == false)
            {
                this.DropStateButton(DrugOrder.States.Planned);
                this.DropStateButton(DrugOrder.States.Approve);
                this.DropStateButton(DrugOrder.States.Cancelled);
                this.DropStateButton(DrugOrder.States.Completed);
                this.DropStateButton(DrugOrder.States.Continued);
                this.DropStateButton(DrugOrder.States.Stopped);
            }

            if(TTObjectClasses.SystemParameter.GetParameterValue("USEDEQUIVALENT","false")== "true")
            {
                this.cmdUserCancelled.Enabled = false;
            }
            
            TTObjectContext context = new TTObjectContext(false);
            Material material = ((Material)_DrugOrder.Material) ;
            
            
            foreach(DrugDefinition equivalent in ((DrugDefinition)material).EquivalentDrugs )
            {
                if(((Material)equivalent).ExistingInheld(_DrugOrder.Store))
                {
                    ITTListViewItem listViewItem = this.Equivalents.Items.Add(((Material)equivalent).Name);
                    listViewItem.Tag = equivalent;
                }
            }
#endregion DrugEquivalentForm_PreScript

            }
                }
}