
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
    /// Kan Bankası Kan Ürünü Hazır
    /// </summary>
    public partial class BloodProductReadyForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            grdProducts.CellContentClick += new TTGridCellEventDelegate(grdProducts_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            grdProducts.CellContentClick -= new TTGridCellEventDelegate(grdProducts_CellContentClick);
            base.UnBindControlEvents();
        }

        private void grdProducts_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BloodProductReadyForm_grdProducts_CellContentClick
            //TODO:ShowEdit!
            //if ((((ITTGridCell)grdProducts.CurrentCell).OwningColumn != null) && (((ITTGridCell)grdProducts.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //{
            //    BloodBankBloodProducts_CokluOzelDurumForm codf = new BloodBankBloodProducts_CokluOzelDurumForm();
            //    BloodBankBloodProducts inp = (BloodBankBloodProducts)grdProducts.CurrentCell.OwningRow.TTObject;
            //    codf.ShowEdit(this.FindForm(), inp);
            //}

            if ((((ITTGridCell)grdProducts.CurrentCell).OwningColumn != null) && (((ITTGridCell)grdProducts.CurrentCell).OwningColumn.Name == "btnCancel"))
      {
                //TODO:ShowEdit!
                //DialogResult result = MessageBox.Show("Kan ürünü istek iptal edilecektir.Devam etmek istiyor musunuz?","İstek iptal ediliyor...",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                //if(result == DialogResult.Yes)
                //{
                //      BloodBankBloodProducts bloodProduct = (BloodBankBloodProducts)grdProducts.CurrentCell.OwningRow.TTObject;
                //      if(bloodProduct.CurrentStateDefID != BloodBankBloodProducts.States.Completed && bloodProduct.CurrentStateDefID != BloodBankBloodProducts.States.Cancelled)
                //      {
                //          try
                //          {
                //              bloodProduct.CurrentStateDefID = BloodBankBloodProducts.States.Cancelled;
                //              bloodProduct.ObjectContext.Save();
                //              InfoBox.Show("Kan ürünü istek iptali başarıyla gerçekleştirilmiştir.",MessageIconEnum.InformationMessage);
                //          }
                //          catch(Exception ex)
                //          {
                //              throw new Exception(ex.ToString());
                //          }
                //          finally
                //          {
                //              this.Close();
                //          }
                //      }
                //      else
                //      {
                //          throw new Exception("Tamamlanmış veya iptal edilmiş kan ürünlerinin iptali gerçekleştirilemez!");
                //      }  
                //}

                var a = 1;

            }
            #endregion BloodProductReadyForm_grdProducts_CellContentClick
        }

        protected override void PreScript()
        {
#region BloodProductReadyForm_PreScript
    base.PreScript();

            this.DropStateButton(BloodProductRequest.States.BloodProductGivingBack);
            this.cmdOK.Visible = false;

            if(this._BloodProductRequest.CurrentStateDefID == BloodProductRequest.States.Completed)
            {
                this.grdProducts.Columns["chkUsed"].Visible = false;
                this.grdProducts.Columns["chkReturn"].Visible = false;
            }
            
            foreach (ITTGridRow row in this.grdProducts.Rows)
            {
                BloodBankBloodProducts product = row.TTObject as BloodBankBloodProducts;
                if (product != null)
                {
                    if (row.Cells["txtProductNo"].Value != null)
                    {
                        row.Cells["txtProductNo"].ReadOnly = true;
                    }
                    else
                    {
                        row.Cells["chkReturn"].ReadOnly = true;
                        row.Cells["chkUsed"].ReadOnly = true;
                    }
                    foreach (BloodBankSubProduct subProduct in product.BloodBankSubProducts)
                    {
                        //Işınlanma testi kontorlü
                        if (subProduct.ProcedureObject.ObjectID == new Guid("392b0f3c-157c-4871-a7c3-694132300206"))
                        {
                            row.Cells["chkIsinlanmis"].Value = 1;
                        }
                        //Filtreleme testi kontorlü
                        //if (subProduct.ProcedureObject.ObjectID == new Guid("392b0f3c-157c-4871-a7c3-694132300206"))
                        //{
                        //    row.Cells["chkFiltrelenmis"].Value = 1;
                        //}
                    }

                    //TODO : warning CS0184: The given expression is never of the provided('BloodBankSubProduct') type
                    //if (product is BloodBankSubProduct)
                    //{
                    //    product.Used = true;
                    //    row.ReadOnly = true;

                    //}

                    row.Cells["txtBloodProductState"].Value = product.CurrentStateDef.DisplayText;
                    
                    if(product.CurrentStateDefID == BloodBankBloodProducts.States.Cancelled)
                    {
                        row.Cells["ttlistbox1"].BackColor = Color.Silver;
                        row.Cells["ISBTUnitNumber"].BackColor = Color.Silver;
                        row.Cells["ISBTElementCode"].BackColor = Color.Silver;
                        row.Cells["txtProductNo"].BackColor = Color.Silver;
                        row.Cells["txtNotes"].BackColor = Color.Silver;
                        row.Cells["txtBloodProductState"].BackColor = Color.Silver;
                    }
                    
                    if(product.CurrentStateDefID == BloodBankBloodProducts.States.New)
                    {
                        row.Cells["ttlistbox1"].BackColor = Color.Goldenrod;
                        row.Cells["ISBTUnitNumber"].BackColor = Color.Goldenrod;
                        row.Cells["ISBTElementCode"].BackColor = Color.Goldenrod;
                        row.Cells["txtProductNo"].BackColor = Color.Goldenrod;
                        row.Cells["txtNotes"].BackColor = Color.Goldenrod;
                        row.Cells["txtBloodProductState"].BackColor = Color.Goldenrod;
                    }
                        
                }
            }
#endregion BloodProductReadyForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BloodProductReadyForm_PostScript
    base.PostScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == BloodProductRequest.States.Completed)
                {
                    foreach (BloodBankBloodProducts product in this._BloodProductRequest.BloodProducts)
                    {
                        if (product.ProductNumber != null && product.Used == null && product.Returned == null)
                        {
                            throw new Exception("Kullanıldı veya İade işaretlenmemiş.");
                            //break;
                        }
                    }
                }
            }
#endregion BloodProductReadyForm_PostScript

            }
                }
}