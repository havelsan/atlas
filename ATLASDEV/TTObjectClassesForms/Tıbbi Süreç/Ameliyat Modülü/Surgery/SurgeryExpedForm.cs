
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
    /// Ameliyat
    /// </summary>
    public partial class SurgeryExpedForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            getSurgerySablonButton.Click += new TTControlEventDelegate(getSurgerySablonButton_Click);
            GridSurgeryExpends.RowEnter += new TTGridCellEventDelegate(GridSurgeryExpends_RowEnter);
            GridSurgeryExpends.CellContentClick += new TTGridCellEventDelegate(GridSurgeryExpends_CellContentClick);
            GridSurgeryExpends.CellValueChanged += new TTGridCellEventDelegate(GridSurgeryExpends_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            getSurgerySablonButton.Click -= new TTControlEventDelegate(getSurgerySablonButton_Click);
            GridSurgeryExpends.RowEnter -= new TTGridCellEventDelegate(GridSurgeryExpends_RowEnter);
            GridSurgeryExpends.CellContentClick -= new TTGridCellEventDelegate(GridSurgeryExpends_CellContentClick);
            GridSurgeryExpends.CellValueChanged -= new TTGridCellEventDelegate(GridSurgeryExpends_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void getSurgerySablonButton_Click()
        {
#region SurgeryExpedForm_getSurgerySablonButton_Click
   IList userTemplates = _Surgery.ObjectContext.QueryObjects("USERTEMPLATE", "RESUSER =" + ConnectionManager.GuidToString(Common.CurrentResource.ObjectID) + "AND TAOBJECTDEFID = " + ConnectionManager.GuidToString(_Surgery.ObjectDef.ID)+ " AND FILITERDATA ='"+_Surgery.ObjectDef.Name+"'");
            //IList userTepmlates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(_OutPatientPrescription.ObjectDef.ID)+ " AND FILITERDATA ='"+ prescriptionTypeFiliter+"'" );
            if (userTemplates.Count > 0)
            {
                MultiSelectForm pForm = new MultiSelectForm();
                foreach (UserTemplate userTemplate in userTemplates)
                {
                    pForm.AddMSItem(userTemplate.Description, userTemplate.ObjectID.ToString(), userTemplate);
                }
                string sKey = pForm.GetMSItem(this, "Şablon seçiniz.", false, false, false, false, true, false);
                if (!String.IsNullOrEmpty(sKey))
                {
                    UserTemplate selectedTemplate = (UserTemplate)pForm.MSSelectedItemObject;
                    Surgery surgery = (Surgery)_Surgery.ObjectContext.GetObject((Guid)selectedTemplate.TAObjectID, (Guid)selectedTemplate.TAObjectDefID);
                    foreach (SurgeryExpend surgeryExpend in surgery.SurgeryExpends)
                    {
                        SurgeryExpend newSurgeryExpend = _Surgery.SurgeryExpends.AddNew();
                        newSurgeryExpend.Material = surgeryExpend.Material;
                        newSurgeryExpend.Amount = surgeryExpend.Amount;
                        newSurgeryExpend.Store = surgeryExpend.Store;
                    }
                }
            }
            else
                InfoBox.Show("Herhangibir reçete şablonunuz bulunmamaktadır", MessageIconEnum.InformationMessage);
#endregion SurgeryExpedForm_getSurgerySablonButton_Click
        }

        private void GridSurgeryExpends_RowEnter(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryExpedForm_GridSurgeryExpends_RowEnter
   ITTGridRow enteredRow = GridSurgeryExpends.Rows[rowIndex];

            if (enteredRow != null)
            {
                SurgeryExpend currentSurgeryExpend = enteredRow.TTObject as SurgeryExpend;
                if (currentSurgeryExpend != null && currentSurgeryExpend.Store != null)
                    CAMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentSurgeryExpend.Store.ObjectID);
            }
#endregion SurgeryExpedForm_GridSurgeryExpends_RowEnter
        }

        private void GridSurgeryExpends_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryExpedForm_GridSurgeryExpends_CellContentClick
   ITTGridRow enteredRow = GridSurgeryExpends.Rows[rowIndex];

            if (enteredRow != null)
            {
                SurgeryExpend currentSurgeryExpend = enteredRow.TTObject as SurgeryExpend;
                if (currentSurgeryExpend != null && currentSurgeryExpend.Store != null)
                    CAMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentSurgeryExpend.Store.ObjectID);
            }
#endregion SurgeryExpedForm_GridSurgeryExpends_CellContentClick
        }

        private void GridSurgeryExpends_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region SurgeryExpedForm_GridSurgeryExpends_CellValueChanged
   ITTGridRow enteredRow = GridSurgeryExpends.Rows[rowIndex];

            if (enteredRow != null)
            {
                SurgeryExpend currentSurgeryExpend = enteredRow.TTObject as SurgeryExpend;
                if (currentSurgeryExpend != null && currentSurgeryExpend.Store != null)
                    CAMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(currentSurgeryExpend.Store.ObjectID);
            }
#endregion SurgeryExpedForm_GridSurgeryExpends_CellValueChanged
        }

        protected override void PreScript()
        {
#region SurgeryExpedForm_PreScript
    base.PreScript();
            this.DropStateButton(Surgery.States.Cancelled);
            CAMaterial.ListFilterExpression = " 1=2 ";

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
                storeObjectId = storeObjectId.Substring(0, storeObjectId.Length - 1);
                CAStore.ListFilterExpression = "OBJECTID IN (" + storeObjectId + ")";
            }
            
           /// this.SetDirectPurchaseListFilter((ITTGridColumn)this.SurgeryDirectPurchaseGrids.Columns["DPADetailFirmPriceOffer"]);
#endregion SurgeryExpedForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region SurgeryExpedForm_ClientSidePreScript
    base.ClientSidePreScript();
            this.DirectPurchaseMaterialByPatient();
#endregion SurgeryExpedForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SurgeryExpedForm_PostScript
    base.PostScript(transDef);

            //Servera taşındı
            //if(this._Surgery.SurgeryDirectPurchaseGrids.Count > 0)
            //{
            //    List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
            //    foreach(SurgeryDirectPurchaseGrid sdg in this._Surgery.SurgeryDirectPurchaseGrids )
            //    {
            //        if(materials.Contains(sdg.DPADetailFirmPriceOffer))
            //            throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
            //        else
            //            materials.Add(sdg.DPADetailFirmPriceOffer);
            //    }
            //}

            //if (this._Surgery.Surgery_CodelessMaterialDirectPurchaseGrids.Count > 0)
            //{
            //    List<DPADetailFirmPriceOffer> materials = new List<DPADetailFirmPriceOffer>();
            //    foreach (CodelessMaterialDirectPurchaseGrid cdg in this._Surgery.Surgery_CodelessMaterialDirectPurchaseGrids)
            //    {
            //        if(materials.Contains(cdg.DPADetailFirmPriceOffer))
            //            throw new TTException("Aynı Malzemeyi Birden Fazla Giremezsiniz ! ");
            //        else
            //            materials.Add(cdg.DPADetailFirmPriceOffer);
            //    }
            //}
            
            //if (transDef != null)
            //{
            //    if (transDef.ToStateDefID  == Surgery.States.SurgeryReport)
            //    {
            //        foreach(SurgeryDirectPurchaseGrid sdg in this._Surgery.SurgeryDirectPurchaseGrids )
            //        {
            //            SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(this._Surgery.ObjectContext);
            //            titubbPrice.PatientPrice = 0;
            //            titubbPrice.SubActionMaterial = sdg;

            //            if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode != null)
            //            {
            //                titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
            //                titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
            //                titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
            //            }
            //            //                else
            //            //                {
            //            //                    titubbPrice.ExternalCode = "KODSUZ";
            //            //                    titubbPrice.Description = productDefinition.Name;
            //            //                    titubbPrice.PayerPrice = 0;
            //            //                }
            //            titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
            //        }
            //        foreach(CodelessMaterialDirectPurchaseGrid cdg in this._Surgery.Surgery_CodelessMaterialDirectPurchaseGrids )
            //        {
            //            SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(this._Surgery.ObjectContext);
            //            titubbPrice.PatientPrice = 0;
            //            titubbPrice.SubActionMaterial = cdg;
                        
            //          //  titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
            //            titubbPrice.Description = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.DPA22FCodelessMaterial.MaterialName;
            //            titubbPrice.PayerPrice = 0;
                        
            //           // titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
            //        }
            //    }
            //}
            
            //this.MakingDirectPurchaseHasUsed();
            //Guid malzemeObjectID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            
            //foreach(SurgeryDirectPurchaseGrid sdg in this._Surgery.SurgeryDirectPurchaseGrids )
            //{
            //    sdg.Material = (Material)this._Surgery.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
            //    sdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
            //    sdg.Amount = sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            //}
            //foreach(CodelessMaterialDirectPurchaseGrid cdg in this._Surgery.Surgery_CodelessMaterialDirectPurchaseGrids )
            //{
            //    cdg.Material = (Material)this._Surgery.ObjectContext.GetObject(malzemeObjectID, "MATERIAL");
            //    //cdg.UBBCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product != null ? sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product.ProductNumber : null;
            //    cdg.Amount = cdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.CertainAmount;
            //}
#endregion SurgeryExpedForm_PostScript

            }
            
#region SurgeryExpedForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if(_Surgery.SurgeryTemplate !=null  && _Surgery.SurgeryTemplate == true)
            {
                if (transDef != null)
                {
                    string description = InputForm.GetText("Şablon İsmini Giriniz");
                    if (string.IsNullOrEmpty(description) == false)
                    {
                        IList userTemplates = Common.CurrentResource.UserTemplates.Select("TAOBJECTDEFID = " + ConnectionManager.GuidToString(_Surgery.ObjectDef.ID) + " AND DESCRIPTION = '" + description + "'");
                        
                        if (userTemplates.Count == 0)
                        {
                            TTObjectContext context = new TTObjectContext(false);
                            UserTemplate userTemplate = new UserTemplate(context);
                            userTemplate.ResUser = (ResUser)Common.CurrentResource;
                            userTemplate.Description = description;
                            userTemplate.TAObjectID = _Surgery.ObjectID;
                            userTemplate.TAObjectDefID = _Surgery.ObjectDef.ID;
                            userTemplate.FiliterData = _Surgery.ObjectDef.Name;
                            context.Save();
                            context.Dispose();
                        }
                        else
                        {
                            InfoBox.Show(description + " isimli şablonunuz bulunduğu için şablon kayıt edilemedi", MessageIconEnum.ErrorMessage);
                        }
                    }
                    else
                        InfoBox.Show("Şablona isim vermeden kaydedemezsiniz.", MessageIconEnum.ErrorMessage);
                }
            }
        }
        
#endregion SurgeryExpedForm_Methods
    }
}