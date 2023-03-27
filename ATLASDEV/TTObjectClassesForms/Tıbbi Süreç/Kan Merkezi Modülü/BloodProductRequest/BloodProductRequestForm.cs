
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
    /// Kan Bankası Kan Ürünü İstek
    /// </summary>
    public partial class BloodProductRequestForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            chkWithTest.CheckedChanged += new TTControlEventDelegate(chkWithTest_CheckedChanged);
            chkWithoutTests.CheckedChanged += new TTControlEventDelegate(chkWithoutTests_CheckedChanged);
            chkUrgentCross.CheckedChanged += new TTControlEventDelegate(chkUrgentCross_CheckedChanged);
            chkWithoutCross.CheckedChanged += new TTControlEventDelegate(chkWithoutCross_CheckedChanged);
            chkNormal.CheckedChanged += new TTControlEventDelegate(chkNormal_CheckedChanged);
            chkBlock.CheckedChanged += new TTControlEventDelegate(chkBlock_CheckedChanged);
            chkOther.CheckedChanged += new TTControlEventDelegate(chkOther_CheckedChanged);
            chkHB.CheckedChanged += new TTControlEventDelegate(chkHB_CheckedChanged);
            chkPrepare.CheckedChanged += new TTControlEventDelegate(chkPrepare_CheckedChanged);
            chkSurgery.CheckedChanged += new TTControlEventDelegate(chkSurgery_CheckedChanged);
            chkPregnancy.CheckedChanged += new TTControlEventDelegate(chkPregnancy_CheckedChanged);
            chkTransfused.CheckedChanged += new TTControlEventDelegate(chkTransfused_CheckedChanged);
            chkUrgent.CheckedChanged += new TTControlEventDelegate(chkUrgent_CheckedChanged);
            ttgrid1.CellContentClick += new TTGridCellEventDelegate(ttgrid1_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            chkWithTest.CheckedChanged -= new TTControlEventDelegate(chkWithTest_CheckedChanged);
            chkWithoutTests.CheckedChanged -= new TTControlEventDelegate(chkWithoutTests_CheckedChanged);
            chkUrgentCross.CheckedChanged -= new TTControlEventDelegate(chkUrgentCross_CheckedChanged);
            chkWithoutCross.CheckedChanged -= new TTControlEventDelegate(chkWithoutCross_CheckedChanged);
            chkNormal.CheckedChanged -= new TTControlEventDelegate(chkNormal_CheckedChanged);
            chkBlock.CheckedChanged -= new TTControlEventDelegate(chkBlock_CheckedChanged);
            chkOther.CheckedChanged -= new TTControlEventDelegate(chkOther_CheckedChanged);
            chkHB.CheckedChanged -= new TTControlEventDelegate(chkHB_CheckedChanged);
            chkPrepare.CheckedChanged -= new TTControlEventDelegate(chkPrepare_CheckedChanged);
            chkSurgery.CheckedChanged -= new TTControlEventDelegate(chkSurgery_CheckedChanged);
            chkPregnancy.CheckedChanged -= new TTControlEventDelegate(chkPregnancy_CheckedChanged);
            chkTransfused.CheckedChanged -= new TTControlEventDelegate(chkTransfused_CheckedChanged);
            chkUrgent.CheckedChanged -= new TTControlEventDelegate(chkUrgent_CheckedChanged);
            ttgrid1.CellContentClick -= new TTGridCellEventDelegate(ttgrid1_CellContentClick);
            base.UnBindControlEvents();
        }

        private void chkWithTest_CheckedChanged()
        {
#region BloodProductRequestForm_chkWithTest_CheckedChanged
   if (chkWithTest.Value != null)
            {
                if ((bool)chkWithTest.Value)
                {
                    chkWithoutTests.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkWithTest_CheckedChanged
        }

        private void chkWithoutTests_CheckedChanged()
        {
#region BloodProductRequestForm_chkWithoutTests_CheckedChanged
   if (chkWithoutTests.Value != null)
            {
                if ((bool)chkWithoutTests.Value)
                {
                    chkWithTest.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkWithoutTests_CheckedChanged
        }

        private void chkUrgentCross_CheckedChanged()
        {
#region BloodProductRequestForm_chkUrgentCross_CheckedChanged
   if (chkUrgentCross.Value != null)
            {
                if ((bool)chkUrgentCross.Value)
                {
                    chkWithoutCross.Value = false;
                    chkNormal.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkUrgentCross_CheckedChanged
        }

        private void chkWithoutCross_CheckedChanged()
        {
#region BloodProductRequestForm_chkWithoutCross_CheckedChanged
   if (chkWithoutCross.Value != null)
            {
                if ((bool)chkWithoutCross.Value)
                {
                    chkNormal.Value = false;
                    chkUrgentCross.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkWithoutCross_CheckedChanged
        }

        private void chkNormal_CheckedChanged()
        {
#region BloodProductRequestForm_chkNormal_CheckedChanged
   if (chkNormal.Value != null)
            {
                if ((bool)chkNormal.Value)
                {
                    chkWithoutCross.Value = false;
                    chkUrgentCross.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkNormal_CheckedChanged
        }

        private void chkBlock_CheckedChanged()
        {
#region BloodProductRequestForm_chkBlock_CheckedChanged
   if (chkBlock.Value != null)
            {
                if ((bool)chkBlock.Value)
                {
                    chkPrepare.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkBlock_CheckedChanged
        }

        private void chkOther_CheckedChanged()
        {
#region BloodProductRequestForm_chkOther_CheckedChanged
   if (chkOther.Value != null)
            {
                if ((bool)chkOther.Value)
                {
                    chkSurgery.Value = false;
                    chkHB.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkOther_CheckedChanged
        }

        private void chkHB_CheckedChanged()
        {
#region BloodProductRequestForm_chkHB_CheckedChanged
   if (chkHB.Value != null)
            {
                if ((bool)chkHB.Value)
                {
                    chkSurgery.Value = false;
                    chkOther.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkHB_CheckedChanged
        }

        private void chkPrepare_CheckedChanged()
        {
#region BloodProductRequestForm_chkPrepare_CheckedChanged
   if (chkPrepare.Value != null)
            {
                if ((bool)chkPrepare.Value)
                {
                    chkBlock.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkPrepare_CheckedChanged
        }

        private void chkSurgery_CheckedChanged()
        {
#region BloodProductRequestForm_chkSurgery_CheckedChanged
   if (chkSurgery.Value != null)
            {
                if ((bool)chkSurgery.Value)
                {
                    chkHB.Value = false;
                    chkOther.Value = false;
                }
            }
#endregion BloodProductRequestForm_chkSurgery_CheckedChanged
        }

        private void chkPregnancy_CheckedChanged()
        {
#region BloodProductRequestForm_chkPregnancy_CheckedChanged
   if (chkPregnancy.Value != null)
            {
                if ((bool)chkPregnancy.Value)
                {
                    dtPregnancy.Enabled = true;
                }
                else
                {
                    dtPregnancy.Enabled = false;
                }
            }
#endregion BloodProductRequestForm_chkPregnancy_CheckedChanged
        }

        private void chkTransfused_CheckedChanged()
        {
#region BloodProductRequestForm_chkTransfused_CheckedChanged
   if (chkTransfused.Value != null)
            {
                if ((bool)chkTransfused.Value)
                {
                    dtTransfused.Enabled = true;
                }
                else
                {
                    dtTransfused.Enabled = false;
                }
            }
#endregion BloodProductRequestForm_chkTransfused_CheckedChanged
        }

        private void chkUrgent_CheckedChanged()
        {
#region BloodProductRequestForm_chkUrgent_CheckedChanged
   if (chkUrgent.Value != null)
            {
                if ((bool)chkUrgent.Value)
                {
                    pnlUrgent.Visible = true;
                }
                else
                {
                    pnlUrgent.Visible = false;
                }
            }
#endregion BloodProductRequestForm_chkUrgent_CheckedChanged
        }

        private void ttgrid1_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region BloodProductRequestForm_ttgrid1_CellContentClick
            //TODO:ShowEdit
            //if ((((ITTGridCell)ttgrid1.CurrentCell).OwningColumn != null) && (((ITTGridCell)ttgrid1.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //         {
            //             BloodBankBloodProducts_CokluOzelDurumForm codf = new BloodBankBloodProducts_CokluOzelDurumForm();
            //             BloodBankBloodProducts inp = (BloodBankBloodProducts)ttgrid1.CurrentCell.OwningRow.TTObject;
            //             codf.ShowEdit(this.FindForm(), inp);
            //         }
            var a = 1;
            #endregion BloodProductRequestForm_ttgrid1_CellContentClick
        }

        protected override void PreScript()
        {
#region BloodProductRequestForm_PreScript
    base.PreScript();
            this._BloodProductRequest.RequestDoctor = Common.CurrentResource;
            this.DropStateButton(BloodProductRequest.States.BloodProductSupply);
            
            this.cmdOK.Visible = false;
#endregion BloodProductRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BloodProductRequestForm_PostScript
    base.PostScript(transDef);

            TTObjectContext oContext = this._BloodProductRequest.ObjectContext;


            List<BloodBankBloodProducts> liste = new List<BloodBankBloodProducts>();
            foreach (BloodBankBloodProducts productitem in this._BloodProductRequest.BloodProducts)
            {
                liste.Add(productitem);
            }
            foreach (BloodBankBloodProducts product in liste)
            {
                if (product is BloodBankBloodProducts)
                {
                    int cloneCount = (int)product.Amount - 1;
                    product.Amount = 1;
                    for (int i = 0; i < cloneCount; i++)
                    {
                        BloodBankBloodProducts cloneProduct = null;
                   
                        cloneProduct = (BloodBankBloodProducts)product.Clone();
                        //cloneProduct.EpisodeAction = product.EpisodeAction;
                        TTSequence.allowSetSequenceValue = true;
                        cloneProduct.ID.SetSequenceValue(0);
                        cloneProduct.ID.GetNextValue();
                        if (cloneProduct.IsIsinlama == true)
                        {
                            BloodBankSubProduct subProduct = new BloodBankSubProduct(oContext);
                            BloodBankTestDefinition testDef = (BloodBankTestDefinition)oContext.GetObject(new Guid("392b0f3c-157c-4871-a7c3-694132300206"), "BLOODBANKTESTDEFINITION");
                            subProduct.ProcedureObject = testDef;
                            subProduct.MasterResource = product.MasterResource;
                            subProduct.FromResource = product.FromResource;
                            subProduct.EpisodeAction = product.EpisodeAction;
                            cloneProduct.BloodBankSubProducts.Add(subProduct);
                        }
                        this._BloodProductRequest.BloodProducts.Add(cloneProduct);
                    }
                    if (product.IsIsinlama == true)
                    {
                        BloodBankSubProduct subProduct = new BloodBankSubProduct(oContext);
                        BloodBankTestDefinition testDef = (BloodBankTestDefinition)oContext.GetObject(new Guid("392b0f3c-157c-4871-a7c3-694132300206"), "BLOODBANKTESTDEFINITION");
                        subProduct.ProcedureObject = testDef;
                        subProduct.MasterResource = product.MasterResource;
                        subProduct.FromResource = product.FromResource;
                        subProduct.EpisodeAction = product.EpisodeAction;
                        product.BloodBankSubProducts.Add(subProduct);
                    }
                }
            }
            oContext.Save();
#endregion BloodProductRequestForm_PostScript

            }
            
#region BloodProductRequestForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            //Cursor current = Cursor.Current;
            //Cursor.Current = Cursors.WaitCursor;
            try
            {
                BloodProductRequest.SendToBloodBank(this._BloodProductRequest); //Entegrasyon için.
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cursor.Current = current;
            }
        }
        
#endregion BloodProductRequestForm_Methods
    }
}