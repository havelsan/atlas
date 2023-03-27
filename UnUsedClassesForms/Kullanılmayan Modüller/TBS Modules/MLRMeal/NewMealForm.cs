
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
    /// Yeni yemel Girişi
    /// </summary>
    public partial class NewMealForm : TTForm
    {
        override protected void BindControlEvents()
        {
            SupplyGrid.CellDoubleClick += new TTGridCellEventDelegate(SupplyGrid_CellDoubleClick);
            SupplyGrid.CurrentCellChanged += new TTControlEventDelegate(SupplyGrid_CurrentCellChanged);
            SupplyGrid.SelectionChanged += new TTControlEventDelegate(SupplyGrid_SelectionChanged);
            SupplyGrid.RowEnter += new TTGridCellEventDelegate(SupplyGrid_RowEnter);
            SupplyGrid.RowLeave += new TTGridCellEventDelegate(SupplyGrid_RowLeave);
            SupplyGrid.CellContentClick += new TTGridCellEventDelegate(SupplyGrid_CellContentClick);
            SupplyGrid.CellValueChanged += new TTGridCellEventDelegate(SupplyGrid_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            SupplyGrid.CellDoubleClick -= new TTGridCellEventDelegate(SupplyGrid_CellDoubleClick);
            SupplyGrid.CurrentCellChanged -= new TTControlEventDelegate(SupplyGrid_CurrentCellChanged);
            SupplyGrid.SelectionChanged -= new TTControlEventDelegate(SupplyGrid_SelectionChanged);
            SupplyGrid.RowEnter -= new TTGridCellEventDelegate(SupplyGrid_RowEnter);
            SupplyGrid.RowLeave -= new TTGridCellEventDelegate(SupplyGrid_RowLeave);
            SupplyGrid.CellContentClick -= new TTGridCellEventDelegate(SupplyGrid_CellContentClick);
            SupplyGrid.CellValueChanged -= new TTGridCellEventDelegate(SupplyGrid_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void SupplyGrid_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region NewMealForm_SupplyGrid_CellDoubleClick
   //throw new TTException("Cell Double Click");
#endregion NewMealForm_SupplyGrid_CellDoubleClick
        }

        private void SupplyGrid_CurrentCellChanged()
        {
#region NewMealForm_SupplyGrid_CurrentCellChanged
   //throw new TTException("CurrentCellChanged");
#endregion NewMealForm_SupplyGrid_CurrentCellChanged
        }

        private void SupplyGrid_SelectionChanged()
        {
#region NewMealForm_SupplyGrid_SelectionChanged
   //  throw new TTException("Selection Changed");
#endregion NewMealForm_SupplyGrid_SelectionChanged
        }

        private void SupplyGrid_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region NewMealForm_SupplyGrid_RowEnter
   // throw new TTException("RowEnter");
#endregion NewMealForm_SupplyGrid_RowEnter
        }

        private void SupplyGrid_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
#region NewMealForm_SupplyGrid_RowLeave
   //  throw new TTException("_RowLeave");
#endregion NewMealForm_SupplyGrid_RowLeave
        }

        private void SupplyGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region NewMealForm_SupplyGrid_CellContentClick
   // throw new TTException("Cell Content Click");
#endregion NewMealForm_SupplyGrid_CellContentClick
        }

        private void SupplyGrid_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region NewMealForm_SupplyGrid_CellValueChanged
   if(columnIndex == 0)
            {
                try{
                    System.Diagnostics.Debugger.Break();
                    
                    Guid g = (Guid)SupplyGrid.CurrentCell.Value;
                    MLRSupply sply = this.getMLRSupply(g);
                    if(sply != null)
                    {
             
                        Console.WriteLine("Sonunda yaw :)"+sply.CaloriePerUnit);
                        Console.WriteLine("---------------->\n"+sply.SupplyCode);
                        Console.WriteLine(sply.CalorieUnit);
                        Console.WriteLine(sply.CaloriePerUnit+"\n-------------->");
                    }
                    Console.WriteLine(g.ToString());
                }catch(Exception ex)
                {
                    Console.WriteLine("mati excweption -->> "+ex.ToString());
                    return;
                }
                
            }
            
            if(columnIndex == 1)
            {
                Console.WriteLine("metin");
                MLRSupply sply;
                ITTGridCell cell;
                Guid g;
                
                cell = this.SupplyGrid.Rows[rowIndex].Cells[0];
                if(cell == null)
                {
                    Console.WriteLine("Hangi malzemeyi kullanacaginizi belirtmelisiniz");
                    
                }else
                {
                    g = (Guid)cell.Value;
                    sply = this._MLRMeal.getSupply(g);
                    Console.WriteLine("< "+sply.SupplyCode +" >");
                    Console.WriteLine("< "+sply.CalorieUnit +" >");
                    Console.WriteLine("< "+sply.CaloriePerUnit +" >");
                    int amount = (int)this.SupplyGrid.CurrentCell.Value;
                    Console.WriteLine("Amount elimizde");
                    this.SupplyGrid.Rows[rowIndex].Cells[2].Value = ""+(amount*sply.CaloriePerUnit);
                    Console.WriteLine("taaam yaw  :) ");
                    evaluateTotalMealCalorie();
                }
            }

            //this.SupplyGrid.CellValueChanged.EndInvoke(null);
#endregion NewMealForm_SupplyGrid_CellValueChanged
        }

#region NewMealForm_Methods
        public MLRSupply getMLRSupply(Guid g)
        {
            return (this._MLRMeal.getSupply(g));
            //return null;
        }
        public void evaluateTotalMealCalorie()
        {
            int rowCount,tCalorie = 0;

            
            rowCount = this.SupplyGrid.Rows.Count;
            for(int i = 0; i < rowCount-1; i++)
            {
               // int a = this.SupplyGrid.Rows[i].Cells[2].Value.GetType();
               Console.WriteLine(i);
               if(this.SupplyGrid.Rows[i].Cells[2] != null)
                    
                   Console.WriteLine(this.SupplyGrid.Rows[i].Cells[2].Value.GetType());
                   tCalorie += (int)this.SupplyGrid.Rows[i].Cells[2].Value;
            }
            this.TotalMealCalorie.Text = (""+tCalorie);
        }
        
#endregion NewMealForm_Methods
    }
}