
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
    /// Prosedür
    /// </summary>
    public partial class RadiologyProcedureForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridRadiologyTests.CellContentClick += new TTGridCellEventDelegate(GridRadiologyTests_CellContentClick);
            GridMaterial.RowEnter += new TTGridCellEventDelegate(GridMaterial_RowEnter);
            GridMaterial.CellContentClick += new TTGridCellEventDelegate(GridMaterial_CellContentClick);
            GridMaterial.CellValueChanged += new TTGridCellEventDelegate(GridMaterial_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridRadiologyTests.CellContentClick -= new TTGridCellEventDelegate(GridRadiologyTests_CellContentClick);
            GridMaterial.RowEnter -= new TTGridCellEventDelegate(GridMaterial_RowEnter);
            GridMaterial.CellContentClick -= new TTGridCellEventDelegate(GridMaterial_CellContentClick);
            GridMaterial.CellValueChanged -= new TTGridCellEventDelegate(GridMaterial_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridRadiologyTests_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region RadiologyProcedureForm_GridRadiologyTests_CellContentClick
   if(GridRadiologyTests.CurrentCell != null)
            {
                RadiologyTest test = (RadiologyTest)GridRadiologyTests.CurrentCell.OwningRow.TTObject;
                switch (GridRadiologyTests.CurrentCell.OwningColumn.Name)
                {
                    case "Cancel":
                        
                        // Rollback'li yapılacak
                        // Son test iptal edildiğinde bütün işlemi iptal etme veya bütün işlemi tamamlama yapılacak
                        //Cursor current = Cursor.Current;
                      //  Cursor.Current = Cursors.WaitCursor;
                        Guid savePoint = this._Radiology.ObjectContext.BeginSavePoint();
                        try
                        {                          
                            bool hasUncompletedTest = false;
                            if(test.CurrentStateDefID == RadiologyTest.States.RequestAcception)
                            {
                                test.CurrentStateDefID = RadiologyTest.States.Cancelled;
                                foreach(RadiologyTest radTest in this._Radiology.RadiologyTests)
                                {
                                    if((radTest.CurrentStateDefID != RadiologyTest.States.Cancelled)
                                       && (radTest.CurrentStateDefID != RadiologyTest.States.Completed)
                                       && (radTest.CurrentStateDefID != RadiologyTest.States.Reject))
                                    {
                                        hasUncompletedTest = true;
                                        break;
                                    }
                                }
                                if(!hasUncompletedTest)
                                {                                    
                                    this._Radiology.CurrentStateDefID = Radiology.States.Reject;
                                }
                                this._Radiology.ObjectContext.Save();
                            }
                            else
                            {
                                InfoBox.Show("İstek Kabul aşamasında olmayan test iptal edilemez!");
                            }
                        }
                        catch
                        {
                            this._Radiology.ObjectContext.RollbackSavePoint(savePoint);
                            throw;
                        }
                        finally
                        {
                            //Cursor.Current = current;
                        }
                        break;
                    default:
                        break;
                }
            }
#endregion RadiologyProcedureForm_GridRadiologyTests_CellContentClick
        }

        private void GridMaterial_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region RadiologyProcedureForm_GridMaterial_RowEnter
   ITTGridRow enteredRow = GridMaterial.Rows[rowIndex];

            if (enteredRow != null)
            {
                BaseTreatmentMaterial currentTreatmentMaterial = enteredRow.TTObject as BaseTreatmentMaterial;
                if (currentTreatmentMaterial != null && currentTreatmentMaterial.Store != null)
                    Material.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentTreatmentMaterial.Store.ObjectID);
            }
#endregion RadiologyProcedureForm_GridMaterial_RowEnter
        }

        private void GridMaterial_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region RadiologyProcedureForm_GridMaterial_CellContentClick
   ITTGridRow enteredRow = GridMaterial.Rows[rowIndex];

            if (enteredRow != null)
            {
                BaseTreatmentMaterial currentTreatmentMaterial = enteredRow.TTObject as BaseTreatmentMaterial;
                if (currentTreatmentMaterial != null && currentTreatmentMaterial.Store != null)
                    Material.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentTreatmentMaterial.Store.ObjectID);
            }
#endregion RadiologyProcedureForm_GridMaterial_CellContentClick
        }

        private void GridMaterial_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region RadiologyProcedureForm_GridMaterial_CellValueChanged
   ITTGridRow enteredRow = GridMaterial.Rows[rowIndex];

            if (enteredRow != null)
            {
                BaseTreatmentMaterial currentTreatmentMaterial = enteredRow.TTObject as BaseTreatmentMaterial;
                if (currentTreatmentMaterial != null && currentTreatmentMaterial.Store != null)
                    Material.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentTreatmentMaterial.Store.ObjectID);
            }
#endregion RadiologyProcedureForm_GridMaterial_CellValueChanged
        }

        protected override void PreScript()
        {
#region RadiologyProcedureForm_PreScript
    base.PreScript();
            
            //            this.RTest = this.GetChosenRadiologyTest(_Radiology);
//
            //            TTGrid aa =    (TTGrid)this.ttgrid1;
            //            aa.VirtualMode = false;
            //            foreach(RadiologyTest deneme in this.RTest)
            //            {
//
            //                //   this.ttgrid1.Rows.Add(new object[] {deneme.ProcedureObject,deneme.Description});
//
            //                aa.Rows.Add(new object[] {deneme.ProcedureObject,deneme.Description});
//
            //            }

            Material.ListFilterExpression = " 1=2 ";

            string storeObjectId = "";
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                if (userResource.Resource.Store != null)
                {
                    storeObjectId = storeObjectId + ConnectionManager.GuidToString(userResource.Resource.Store.ObjectID);
                    storeObjectId = storeObjectId + ",";
                }
            }
            if (storeObjectId.Length > 0)
            {
                storeObjectId = storeObjectId.Substring(0,storeObjectId.Length-1);
                RStore.ListFilterExpression = "OBJECTID IN (" + storeObjectId + ")";
            }
#endregion RadiologyProcedureForm_PreScript

            }
            
#region RadiologyProcedureForm_Methods
        public IList RTest;
        
        
        public IList GetChosenRadiologyTest(Radiology Rad)
        {
 
            IList RadiologTestx =  _Radiology.ObjectContext.QueryObjects("RadiologyTest", " RADIOLOGY = " + ConnectionManager.GuidToString(Rad.ObjectID) );
            return RadiologTestx;
            
        }
        
#endregion RadiologyProcedureForm_Methods
    }
}