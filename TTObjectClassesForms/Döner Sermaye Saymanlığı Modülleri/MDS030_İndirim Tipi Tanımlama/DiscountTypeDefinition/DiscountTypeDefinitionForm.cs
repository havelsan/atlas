
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
    /// İndirim Tipi Tanımlama
    /// </summary>
    public partial class DiscountTypeDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            GRIDProcedureGroups.CellValueChanged += new TTGridCellEventDelegate(GRIDProcedureGroups_CellValueChanged);
            GRIDProcedureExceptions.CellValueChanged += new TTGridCellEventDelegate(GRIDProcedureExceptions_CellValueChanged);
            GRIDMaterialGroups.CellValueChanged += new TTGridCellEventDelegate(GRIDMaterialGroups_CellValueChanged);
            GRIDMaterialExceptions.CellValueChanged += new TTGridCellEventDelegate(GRIDMaterialExceptions_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GRIDProcedureGroups.CellValueChanged -= new TTGridCellEventDelegate(GRIDProcedureGroups_CellValueChanged);
            GRIDProcedureExceptions.CellValueChanged -= new TTGridCellEventDelegate(GRIDProcedureExceptions_CellValueChanged);
            GRIDMaterialGroups.CellValueChanged -= new TTGridCellEventDelegate(GRIDMaterialGroups_CellValueChanged);
            GRIDMaterialExceptions.CellValueChanged -= new TTGridCellEventDelegate(GRIDMaterialExceptions_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GRIDProcedureGroups_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DiscountTypeDefinitionForm_GRIDProcedureGroups_CellValueChanged
   // Hizmet/Malzeme grubu bazinda tutar indirimi yapilmasi simdilik yapilmayacak, ihtiyac olursa gelsitirilecek
            /*
            if (columnIndex == 3)
            {
                if (GRIDProcedureGroups.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDProcedureGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                        GRIDProcedureGroups.Rows[rowIndex].Cells[2].Value = (bool)false ;
                    else if (GRIDProcedureGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                    {
                        GRIDProcedureGroups.Rows[rowIndex].Cells[2].Value = (bool)true;
                        GRIDProcedureGroups.Rows[rowIndex].Cells[1].Value = null ;
                    }
                }
            }
            
            if (columnIndex == 2)
            {
                if (GRIDProcedureGroups.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDProcedureGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                    {
                        GRIDProcedureGroups.Rows[rowIndex].Cells[3].Value = (bool)false ;
                        GRIDProcedureGroups.Rows[rowIndex].Cells[1].Value = null ;
                    }
                    else if (GRIDProcedureGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                        GRIDProcedureGroups.Rows[rowIndex].Cells[3].Value = (bool)true;
                }
            }

            if (columnIndex == 1)
            {
                if (GRIDProcedureGroups.Rows[rowIndex].Cells[columnIndex].Value != null)
                    GRIDProcedureGroups.Rows[rowIndex].Cells[3].Value = (bool)true;
                
            }
            */
#endregion DiscountTypeDefinitionForm_GRIDProcedureGroups_CellValueChanged
        }

        private void GRIDProcedureExceptions_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DiscountTypeDefinitionForm_GRIDProcedureExceptions_CellValueChanged
   // Hizmet/Malzeme grubu bazinda tutar indirimi yapilmasi simdilik yapilmayacak, ihtiyac olursa gelsitirilecek
/*
            if (columnIndex == 3)
            {
                if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                        GRIDProcedureExceptions.Rows[rowIndex].Cells[2].Value = (bool)false ;
                    else if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                    {
                        GRIDProcedureExceptions.Rows[rowIndex].Cells[2].Value = (bool)true;
                        GRIDProcedureExceptions.Rows[rowIndex].Cells[1].Value = null ;
                    }
                }
            }
            
            if (columnIndex == 2)
            {
                if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                    {
                        GRIDProcedureExceptions.Rows[rowIndex].Cells[3].Value = (bool)false ;
                        GRIDProcedureExceptions.Rows[rowIndex].Cells[1].Value = null ;
                    }
                    else if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                        GRIDProcedureExceptions.Rows[rowIndex].Cells[3].Value = (bool)true;
                }
            }

            if (columnIndex == 1)
            {
                if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value != null)
                    GRIDProcedureExceptions.Rows[rowIndex].Cells[3].Value = (bool)true;
                
            }
            
            */
#endregion DiscountTypeDefinitionForm_GRIDProcedureExceptions_CellValueChanged
        }

        private void GRIDMaterialGroups_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DiscountTypeDefinitionForm_GRIDMaterialGroups_CellValueChanged
   // Hizmet/Malzeme grubu bazinda tutar indirimi yapilmasi simdilik yapilmayacak, ihtiyac olursa gelsitirilecek

            /*
            if (columnIndex == 3)
            {
                if (GRIDMaterialGroups.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDMaterialGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                        GRIDMaterialGroups.Rows[rowIndex].Cells[2].Value = (bool)false ;
                    else if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                    {
                        GRIDMaterialGroups.Rows[rowIndex].Cells[2].Value = (bool)true;
                        GRIDMaterialGroups.Rows[rowIndex].Cells[1].Value = null ;
                    }
                }
            }
            
            if (columnIndex == 2)
            {
                if (GRIDMaterialGroups.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDMaterialGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                    {
                        GRIDMaterialGroups.Rows[rowIndex].Cells[3].Value = (bool)false ;
                        GRIDMaterialGroups.Rows[rowIndex].Cells[1].Value = null ;
                    }
                    else if (GRIDMaterialGroups.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                        GRIDMaterialGroups.Rows[rowIndex].Cells[3].Value = (bool)true;
                }
            }

            if (columnIndex == 1)
            {
                if (GRIDMaterialGroups.Rows[rowIndex].Cells[columnIndex].Value != null)
                    GRIDMaterialGroups.Rows[rowIndex].Cells[3].Value = (bool)true;
                
            }
            
            */
#endregion DiscountTypeDefinitionForm_GRIDMaterialGroups_CellValueChanged
        }

        private void GRIDMaterialExceptions_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DiscountTypeDefinitionForm_GRIDMaterialExceptions_CellValueChanged
   // Hizmet/Malzeme grubu bazinda tutar indirimi yapilmasi simdilik yapilmayacak, ihtiyac olursa gelsitirilecek
/*
            if (columnIndex == 3)
            {
                if (GRIDMaterialExceptions.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDMaterialExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                        GRIDMaterialExceptions.Rows[rowIndex].Cells[2].Value = (bool)false ;
                    else if (GRIDProcedureExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                    {
                        GRIDMaterialExceptions.Rows[rowIndex].Cells[2].Value = (bool)true;
                        GRIDMaterialExceptions.Rows[rowIndex].Cells[1].Value = null ;
                    }
                }
            }
            
            if (columnIndex == 2)
            {
                if (GRIDMaterialExceptions.Rows[rowIndex].Cells[columnIndex].Value != null)
                {
                    if (GRIDMaterialExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "True" )
                    {
                        GRIDMaterialExceptions.Rows[rowIndex].Cells[3].Value = (bool)false ;
                        GRIDMaterialExceptions.Rows[rowIndex].Cells[1].Value = null ;
                    }
                    else if (GRIDMaterialExceptions.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "False" )
                        GRIDMaterialExceptions.Rows[rowIndex].Cells[3].Value = (bool)true;
                }
            }

            if (columnIndex == 1)
            {
                if (GRIDMaterialExceptions.Rows[rowIndex].Cells[columnIndex].Value != null)
                    GRIDMaterialExceptions.Rows[rowIndex].Cells[3].Value = (bool)true;
                
            }
            
            */
#endregion DiscountTypeDefinitionForm_GRIDMaterialExceptions_CellValueChanged
        }
    }
}