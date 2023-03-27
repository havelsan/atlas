
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
    /// Ek Ameliyat
    /// </summary>
    public partial class SubSurgeryExpertForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridSurgeryExpends.CellContentClick += new TTGridCellEventDelegate(GridSurgeryExpends_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridSurgeryExpends.CellContentClick -= new TTGridCellEventDelegate(GridSurgeryExpends_CellContentClick);
            base.UnBindControlEvents();
        }

        private void GridSurgeryExpends_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region SubSurgeryExpertForm_GridSurgeryExpends_CellContentClick

            // TODO ShowEdit!
            //if (((ITTGridCell)GridSurgeryExpends.CurrentCell).OwningColumn.Name == "CokluOzelDurum")
            //         {

            //             SubSurgeryCokluOzelDurumForm codf = new SubSurgeryCokluOzelDurumForm();
            //             codf.ShowEdit(this.FindForm(), _SubSurgery);
            //         }
            var a = 1;
            #endregion SubSurgeryExpertForm_GridSurgeryExpends_CellContentClick
        }

        protected override void PreScript()
        {
#region SubSurgeryExpertForm_PreScript
    base.PreScript();
            this.DropStateButton(SubSurgery.States.Cancelled);
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["SubSurgeryExpend"], (ITTGridColumn)this.GridSurgeryExpends.Columns["CAMaterial"]);
            
            this.SetDirectPurchaseListFilter((ITTGridColumn)this.SubSurgeryDirectPurchaseGrids.Columns["DPADetailFirmPriceOffer"]);
#endregion SubSurgeryExpertForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region SubSurgeryExpertForm_ClientSidePreScript
    base.ClientSidePreScript();
            this.DirectPurchaseMaterialByPatient();
#endregion SubSurgeryExpertForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SubSurgeryExpertForm_PostScript
    base.PostScript(transDef);
            
             if(_SubSurgery.SubSurgeryDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach(SurgeryDirectPurchaseGrid sdg in _SubSurgery.SubSurgeryDirectPurchaseGrids)
                {
                    if(materials.Contains(sdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(sdg.DPADetailFirmPriceOffer);
                }
            }
            
            if (_SubSurgery.SubSurgery_CodelessMaterialDirectPurchaseGrids.Count > 0)
            {
                List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
                foreach (CodelessMaterialDirectPurchaseGrid cdg in _SubSurgery.SubSurgery_CodelessMaterialDirectPurchaseGrids)
                {
                    if(materials.Contains(cdg.DPADetailFirmPriceOffer))
                        throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
                    else
                        materials.Add(cdg.DPADetailFirmPriceOffer);
                }
            }
           
            Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            foreach(SurgeryDirectPurchaseGrid sdg in this._SubSurgery.SubSurgeryDirectPurchaseGrids)
            {
                sdg.Material = (Material)this._SubSurgery.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }
            
            foreach(CodelessMaterialDirectPurchaseGrid cdg in _SubSurgery.SubSurgery_CodelessMaterialDirectPurchaseGrids)
            {
                cdg.Material = (Material)_SubSurgery.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
                //cdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
                cdg.Amount = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            }

            if (transDef != null)
            {
                 this.MakingDirectPurchaseHasUsed();
                if (transDef.ToStateDefID == Manipulation.States.Completed)
                {
                    this.CreateSubActionMatPricingDet();
                }
            }
#endregion SubSurgeryExpertForm_PostScript

            }
                }
}