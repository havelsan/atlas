
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
    /// İlaç Direktifi
    /// </summary>
    public partial class DrugOrderForm : TTForm
    {
        override protected void BindControlEvents()
        {
            Drug.SelectedObjectChanged += new TTControlEventDelegate(Drug_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            Drug.SelectedObjectChanged -= new TTControlEventDelegate(Drug_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void Drug_SelectedObjectChanged()
        {
#region DrugOrderForm_Drug_SelectedObjectChanged
   //            DrugOrder drugOrder = (DrugOrder)_InpatientDrugOrder;
//            DrugDefinition drugDefinition = ((DrugDefinition)drugOrder.Material);
//            
//            drugOrder.Frequency = drugDefinition.Frequency;
//            drugOrder.DoseAmount = drugDefinition.RoutineDose;
//            drugOrder.Day = 1;// drugDefinition.RoutineDay;
#endregion DrugOrderForm_Drug_SelectedObjectChanged
        }

        protected override void PreScript()
        {
#region DrugOrderForm_PreScript
    ITTObject ttObject = (ITTObject)_DrugOrder;
    
    
    if (ttObject.IsNew)
    {
        int hour = DateTime.Now.Hour + 1;
        DateTime plannedStartTime = DateTime.Today.AddHours(hour);

        this.PlannedStartTime.NullableValue = plannedStartTime;
        this.DropStateButton(DrugOrder.States.Planned);
        this.DropStateButton(DrugOrder.States.Approve);
        this.DropStateButton(DrugOrder.States.Completed);
        this.DropStateButton(DrugOrder.States.Cancelled);
    }
    else
    {
        this.DropStateButton(DrugOrder.States.Planned);
        this.DropStateButton(DrugOrder.States.Approve);
        this.DropStateButton(DrugOrder.States.Completed);
        if (_DrugOrder.CurrentStateDefID != DrugOrder.States.Stopped)
        {
            this.DropStateButton(DrugOrder.States.Continued);
        }

        if (_DrugOrder.Type == "K-Çizelgesi")
        {
            bool kSchedule = false;
            foreach (DrugOrderDetail drugOrderDetail in _DrugOrder.DrugOrderDetails)
            {
                if (drugOrderDetail.KScheduleCollectedOrder != null)
                    kSchedule = true;
            }
            if (kSchedule)
            {
                this.DropStateButton(DrugOrder.States.Cancelled);
            }
            else
            {
                this.DropStateButton(DrugOrder.States.Stopped);
            }
        }
        else
        {
            this.DropStateButton(DrugOrder.States.Cancelled);
            this.DropStateButton(DrugOrder.States.Stopped);
            this.DrugOrderDetails.DataMember = "INPATIENTDRUGORDERDETAILS";

        }
    }
#endregion DrugOrderForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DrugOrderForm_PostScript
    // System.Diagnostics.Debugger.Break();
            
            DrugOrder drugOrder = _DrugOrder;
            //if(drugOrder.CurrentStateDefID == DrugOrder.States.New)
            //{
            //    if (!DrugOrder.GetContinueDrugOrder(drugOrder, (DateTime)drugOrder.PlannedStartTime))
            //    {
            //        //çok önemli unutma
            //        IList myDrugOrder = drugOrder.ObjectContext.QueryObjects("DRUGORDER", " CURRENTSTATEDEFID = '" + DrugOrder.States.Continued.ToString() + "' OR CURRENTSTATEDEFID = '" + DrugOrder.States.Planned.ToString() + "'");
            //        foreach (DrugOrder olddrugOrder in myDrugOrder)
            //        {
            //            if (olddrugOrder.Material == drugOrder.Material)
            //            {
            //                BindingList<DrugOrderDetail> drugOrderDetails = DrugOrderDetail.GetSequenceOrderPlanedDates(drugOrder.ObjectContext, olddrugOrder.ObjectID.ToString());
            //                foreach (DrugOrderDetail drugOrderDetail in drugOrderDetails)
            //                {
            //                    DateTime detailTime = (DateTime)drugOrderDetail.OrderPlannedDate;
            //                    double detailTimePeriod = DrugOrder.GetDetailTimePeriod(olddrugOrder.Frequency);
            //                    detailTime = detailTime.AddHours(detailTimePeriod);
            //                    drugOrderDetail.OrderPlannedDate = detailTime ;
            //                    throw new TTUtils.TTException("\nBu ilaç daha önce order edilmiş ve hala tedavisi devam etmektedir.  " + drugOrderDetail.OrderPlannedDate.ToString() +" tarihi itibariyle ilaç direktifi verebilirsiniz!! \n\n");
            //                }
            //            }
                        
            //        }
            //    }
            //}
            
                    
            drugOrder.Amount = 1;
#endregion DrugOrderForm_PostScript

            }
                }
}