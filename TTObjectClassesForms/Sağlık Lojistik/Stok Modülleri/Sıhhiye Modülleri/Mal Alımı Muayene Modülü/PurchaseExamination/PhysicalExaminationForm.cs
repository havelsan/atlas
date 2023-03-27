
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
    /// Fiziksel Muayene ve Numune Alma  
    /// </summary>
    public partial class PhysicalExaminationForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            StockActionInDetails.CellContentClick += new TTGridCellEventDelegate(StockActionInDetails_CellContentClick);
            StockActionInDetails.CellValueChanged += new TTGridCellEventDelegate(StockActionInDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionInDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionInDetails_CellContentClick);
            StockActionInDetails.CellValueChanged -= new TTGridCellEventDelegate(StockActionInDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void StockActionInDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PhysicalExaminationForm_StockActionInDetails_CellContentClick
   if(StockActionInDetails.CurrentCell == null)
                return;
            
            if(StockActionInDetails.CurrentCell.OwningColumn == StockActionInDetails.Columns[CheckList.Name])
            {
                CheckListForm cf = new CheckListForm();
                cf.ShowEdit(this.FindForm(), (PurchaseExaminationDetail)StockActionInDetails.CurrentCell.OwningRow.TTObject);
            }
#endregion PhysicalExaminationForm_StockActionInDetails_CellContentClick
        }

        private void StockActionInDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PhysicalExaminationForm_StockActionInDetails_CellValueChanged
   if(StockActionInDetails.CurrentCell == null)
                return;
            
            if(StockActionInDetails.CurrentCell.OwningColumn.Name == "PurchaseExaminationDetStatus")
            {
                
                PurchaseExaminationDetail ped = (PurchaseExaminationDetail)StockActionInDetails.CurrentCell.OwningRow.TTObject;
                bool eligable = true;
                
                if(StockActionInDetails.CurrentCell.OwningColumn.Name == "PurchaseExaminationDetStatus")
                {
                    if(ped.PurchaseExaminationDetStatus == PurchaseExaminationDetailStatusEnum.Accept)
                    {
                        foreach(ExaminationDetail ed in ped.ExaminationDetails)
                        {
                            if((bool)ed.Confirmed == false)
                            {
                                eligable = false;
                                break;
                            }
                        }
                    }
                    
                    if(eligable)
                        SetStateButtons();
                    else
                    {
                        InfoBox.Show("Uygun olmayan muayene maddesi bulunmakta.");
                        ped.PurchaseExaminationDetStatus = PurchaseExaminationDetailStatusEnum.Reject;
                    }
                }
            }
#endregion PhysicalExaminationForm_StockActionInDetails_CellValueChanged
        }

        protected override void PreScript()
        {
#region PhysicalExaminationForm_PreScript
    base.PreScript();
                        
            SetStateButtons();
#endregion PhysicalExaminationForm_PreScript

            }
            
#region PhysicalExaminationForm_Methods
        bool rejected = false;
        
        public void SetStateButtons()
        {
            foreach(StockActionDetailIn sdin in _PurchaseExamination.StockActionInDetails)
            {
                PurchaseExaminationDetail pd = (PurchaseExaminationDetail)sdin;
                if(pd.PurchaseExaminationDetStatus == PurchaseExaminationDetailStatusEnum.Reject)
                {
                    this.DropStateButton(PurchaseExamination.States.Completed);
                    AddStateButton(PurchaseExamination.States.RejectNotice);
                }
                else
                {
                    this.DropStateButton(PurchaseExamination.States.RejectNotice);
                    AddStateButton(PurchaseExamination.States.Completed);
                }
            }
        }
        
#endregion PhysicalExaminationForm_Methods
    }
}