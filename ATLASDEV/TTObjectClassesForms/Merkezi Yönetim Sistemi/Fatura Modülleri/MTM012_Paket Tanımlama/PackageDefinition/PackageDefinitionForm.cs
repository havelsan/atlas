
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
    /// Paket Tanımı
    /// </summary>
    public partial class PackageDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            GRIDDetailProcedure.CellValueChanged += new TTGridCellEventDelegate(GRIDDetailProcedure_CellValueChanged);
            GRIDMaterialDetail.CellValueChanged += new TTGridCellEventDelegate(GRIDMaterialDetail_CellValueChanged);
            GRIDPackageExceptionProcedures.CellValueChanged += new TTGridCellEventDelegate(GRIDPackageExceptionProcedures_CellValueChanged);
            GRIDPackageExceptionMaterials.CellValueChanged += new TTGridCellEventDelegate(GRIDPackageExceptionMaterials_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GRIDDetailProcedure.CellValueChanged -= new TTGridCellEventDelegate(GRIDDetailProcedure_CellValueChanged);
            GRIDMaterialDetail.CellValueChanged -= new TTGridCellEventDelegate(GRIDMaterialDetail_CellValueChanged);
            GRIDPackageExceptionProcedures.CellValueChanged -= new TTGridCellEventDelegate(GRIDPackageExceptionProcedures_CellValueChanged);
            GRIDPackageExceptionMaterials.CellValueChanged -= new TTGridCellEventDelegate(GRIDPackageExceptionMaterials_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GRIDDetailProcedure_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PackageDefinitionForm_GRIDDetailProcedure_CellValueChanged
   if (columnIndex == 1)
            {
                if (GRIDDetailProcedure.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "1") // PackageInclusiveEnum.Included)
                    GRIDDetailProcedure.Rows[rowIndex].Cells["PPricingList"].ReadOnly = false;
                else if (GRIDDetailProcedure.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "0") //PackageInclusiveEnum.Excluded.ToString())
                {
                    if (GRIDDetailProcedure.Rows[rowIndex].Cells["PPricingList"].Value != null)
                        GRIDDetailProcedure.Rows[rowIndex].Cells["PPricingList"].Value = null;
                    GRIDDetailProcedure.Rows[rowIndex].Cells["PPricingList"].ReadOnly = true;
                }
            }
#endregion PackageDefinitionForm_GRIDDetailProcedure_CellValueChanged
        }

        private void GRIDMaterialDetail_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PackageDefinitionForm_GRIDMaterialDetail_CellValueChanged
   if (columnIndex == 1)
            {
                if (GRIDMaterialDetail.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "1") // PackageInclusiveEnum.Included)
                    GRIDMaterialDetail.Rows[rowIndex].Cells["MPricingList"].ReadOnly = false;
                else if (GRIDMaterialDetail.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "0") //PackageInclusiveEnum.Excluded.ToString())
                {
                    if (GRIDMaterialDetail.Rows[rowIndex].Cells["MPricingList"].Value != null)
                        GRIDMaterialDetail.Rows[rowIndex].Cells["MPricingList"].Value = null;
                    GRIDMaterialDetail.Rows[rowIndex].Cells["MPricingList"].ReadOnly = true;
                }
            }
#endregion PackageDefinitionForm_GRIDMaterialDetail_CellValueChanged
        }

        private void GRIDPackageExceptionProcedures_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PackageDefinitionForm_GRIDPackageExceptionProcedures_CellValueChanged
   if (columnIndex == 1)
            {
                 if (GRIDPackageExceptionProcedures.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "1") // PackageInclusiveEnum.Included)
                    GRIDPackageExceptionProcedures.Rows[rowIndex].Cells["PexcPricingList"].ReadOnly = false;
                else if (GRIDPackageExceptionProcedures.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "0") //PackageInclusiveEnum.Excluded.ToString())
                {
                    if (GRIDPackageExceptionProcedures.Rows[rowIndex].Cells["PexcPricingList"].Value != null)
                        GRIDPackageExceptionProcedures.Rows[rowIndex].Cells["PexcPricingList"].Value = null;
                    GRIDPackageExceptionProcedures.Rows[rowIndex].Cells["PexcPricingList"].ReadOnly = true;
                }
            }
#endregion PackageDefinitionForm_GRIDPackageExceptionProcedures_CellValueChanged
        }

        private void GRIDPackageExceptionMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PackageDefinitionForm_GRIDPackageExceptionMaterials_CellValueChanged
   if (columnIndex == 1)
            {
                if (GRIDPackageExceptionMaterials.Rows[rowIndex].Cells[columnIndex].Value.ToString() == "1") // PackageInclusiveEnum.Included)
                    GRIDPackageExceptionMaterials.Rows[rowIndex].Cells["MexcPricingList"].ReadOnly = false;
                else if (GRIDPackageExceptionMaterials.Rows[rowIndex].Cells[columnIndex].Value.ToString() ==  "0") //PackageInclusiveEnum.Excluded.ToString())
                {
                    if (GRIDPackageExceptionMaterials.Rows[rowIndex].Cells["MexcPricingList"].Value != null)
                        GRIDPackageExceptionMaterials.Rows[rowIndex].Cells["MexcPricingList"].Value = null;
                    GRIDPackageExceptionMaterials.Rows[rowIndex].Cells["MexcPricingList"].ReadOnly = true;
                }
            }
#endregion PackageDefinitionForm_GRIDPackageExceptionMaterials_CellValueChanged
        }

        protected override void PreScript()
        {
#region PackageDefinitionForm_PreScript
    base.PreScript();
            
            Guid SiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            if(Sites.SiteMerkezSagKom.Equals(SiteGuid))
            {
                for (int i=0; i<GRIDMaterialDetail.Rows.Count -1; i++)
                {
                    if (GRIDMaterialDetail.Rows[i].Cells["MInclusive"].Value.ToString() == "1")
                        GRIDMaterialDetail.Rows[i].Cells["MPricingList"].ReadOnly = false;
                    else if (GRIDMaterialDetail.Rows[i].Cells["MInclusive"].Value.ToString() == "0")
                        GRIDMaterialDetail.Rows[i].Cells["MPricingList"].ReadOnly = true;
                }
                
                for (int i=0; i<GRIDDetailProcedure.Rows.Count -1; i++)
                {
                    if (GRIDDetailProcedure.Rows[i].Cells["PInclusive"].Value.ToString() == "1")
                        GRIDDetailProcedure.Rows[i].Cells["PPricingList"].ReadOnly = false;
                    else if (GRIDDetailProcedure.Rows[i].Cells["PInclusive"].Value.ToString() == "0")
                        GRIDDetailProcedure.Rows[i].Cells["PPricingList"].ReadOnly = true;
                }

                
                for (int i=0; i<GRIDPackageExceptionProcedures.Rows.Count -1; i++)
                {
                    if (GRIDPackageExceptionProcedures.Rows[i].Cells["PexcInclusive"].Value.ToString() == "1")
                        GRIDPackageExceptionProcedures.Rows[i].Cells["PexcPricingList"].ReadOnly = false;
                    else if (GRIDPackageExceptionProcedures.Rows[i].Cells["PexcInclusive"].Value.ToString() == "0")
                        GRIDPackageExceptionProcedures.Rows[i].Cells["PexcPricingList"].ReadOnly = true;
                }

                
                for (int i=0; i<GRIDPackageExceptionMaterials.Rows.Count -1; i++)
                {
                    if (GRIDPackageExceptionMaterials.Rows[i].Cells["MexcInclusive"].Value.ToString() == "1")
                        GRIDPackageExceptionMaterials.Rows[i].Cells["MexcPricingList"].ReadOnly = false;
                    else if (GRIDPackageExceptionMaterials.Rows[i].Cells["MexcInclusive"].Value.ToString() == "0")
                        GRIDPackageExceptionMaterials.Rows[i].Cells["MexcPricingList"].ReadOnly = true;
                }
            }
#endregion PackageDefinitionForm_PreScript

            }
                }
}