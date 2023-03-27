
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
    /// Sayim Tarti Cizelgesi
    /// </summary>
    public partial class STFActionFrom : TTForm
    {
        override protected void BindControlEvents()
        {
            STCActions.RowLeave += new TTGridCellEventDelegate(STCActions_RowLeave);
            STCActions.CellValueChanged += new TTGridCellEventDelegate(STCActions_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            STCActions.RowLeave -= new TTGridCellEventDelegate(STCActions_RowLeave);
            STCActions.CellValueChanged -= new TTGridCellEventDelegate(STCActions_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void STCActions_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
#region STFActionFrom_STCActions_RowLeave
   STCAction stcAction = null;
            if (rowIndex < this.STCActions.Rows.Count && rowIndex > -1)
            {
                if (((ITTObject)this.STCActions.Rows[rowIndex].TTObject).IsNew)
                {
                    TTObjectContext readonlyContext = new TTObjectContext(true);
                    stcAction = (STCAction)((ITTGridRow)this.STCActions.Rows[rowIndex]).TTObject;
                    // Aynı Malzeme ve Aynı Masada aynı Sıra numaralı varmı kontrolü.
                    if (stcAction.Material != null)
                    {
                        IList mdbTartilar = readonlyContext.QueryObjects("STCACTION", "MATERIAL =" + ConnectionManager.GuidToString(stcAction.Material.ObjectID));
                        if (mdbTartilar.Count > 0)
                        {
                            InfoBox.Show(stcAction.Material.Name + " isimli malzeme daha önce girilmiştir.", MessageIconEnum.ErrorMessage);
                        }

                        IList mlocalTartilar = _STFAction.ObjectContext.LocalQuery("STCACTION", "MATERIAL =" + ConnectionManager.GuidToString(stcAction.Material.ObjectID));
                        if (mdbTartilar.Count > 1)
                        {
                            InfoBox.Show(stcAction.Material.Name + " isimli malzeme daha önce girilmiştir.", MessageIconEnum.ErrorMessage);
                        }
                    }
                    else
                    {
                        InfoBox.Show("Malzeme seçmelisi!!", MessageIconEnum.ErrorMessage);
                    }

                    if (stcAction.SiraNu != null && stcAction.ResCardDrawer != null)
                    {
                        IList sdbTartilar = readonlyContext.QueryObjects("STCACTION", "SIRANU = " + stcAction.SiraNu + " AND RESCARDDRAWER =" + ConnectionManager.GuidToString(stcAction.ResCardDrawer.ObjectID));
                        if (sdbTartilar.Count > 0)
                        {
                            InfoBox.Show(stcAction.ResCardDrawer.Name + " masaya " + stcAction.SiraNu.ToString() + " sıra numarası girilmiştir.", MessageIconEnum.ErrorMessage);
                        }
                        IList slocalTartilar = _STFAction.ObjectContext.LocalQuery("STCACTION", "SIRANU = " + stcAction.SiraNu + " AND RESCARDDRAWER =" + ConnectionManager.GuidToString(stcAction.ResCardDrawer.ObjectID));
                        if (slocalTartilar.Count > 1)
                        {
                            InfoBox.Show(stcAction.ResCardDrawer.Name + " masaya " + stcAction.SiraNu.ToString() + " sıra numarası girilmiştir.", MessageIconEnum.ErrorMessage);
                        }
                    }
                    else
                    {
                        InfoBox.Show("Sıra Numarası Girmelisiniz.!!", MessageIconEnum.ErrorMessage);
                    }
                    //Sarf Malzeme ve İlaçlarda Hek Mevcudunun sıfır olması kontrolü
                    if (stcAction.HEKMevcut != null)
                    {
                        if (stcAction.Material is ConsumableMaterialDefinition || stcAction.Material is DrugDefinition)
                        {
                            if (stcAction.HEKMevcut > 0)
                            {
                                InfoBox.Show("Sarf Malzeme ve / veya ilaç için Hek Mevcudu 0 dan büyük giremezsiniz!!", MessageIconEnum.ErrorMessage);
                            }
                        }
                    }
                    
                    //Son Kullanma tarihi kontrolü
                    if (stcAction.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated)
                    {
                        if (stcAction.SKTarihi == null)
                            InfoBox.Show("Son kullanma tarihi girmelisiniz.", MessageIconEnum.ErrorMessage);
                    }
                }
            }
#endregion STFActionFrom_STCActions_RowLeave
        }

        private void STCActions_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region STFActionFrom_STCActions_CellValueChanged
   ITTGridRow stcActionRow = STCActions.Rows[STCActions.CurrentCell.RowIndex];
            STCAction sTCAction = ((STCAction)stcActionRow.TTObject);
            if (stcActionRow.Cells["YeniMevcutSTCAction"].Value != null && stcActionRow.Cells["KullanilmisMevcutSTCAction"].Value != null && stcActionRow.Cells["HEKMevcutSTCAction"].Value != null && stcActionRow.Cells["MuvakkatenVerilenSTCAction"].Value != null)
            {
                
                double yMevcut = Convert.ToDouble(stcActionRow.Cells["YeniMevcutSTCAction"].Value);
                double kMevcut = Convert.ToDouble(stcActionRow.Cells["KullanilmisMevcutSTCAction"].Value);
                double hMevcut = Convert.ToDouble(stcActionRow.Cells["HEKMevcutSTCAction"].Value);
                double mMevcut = Convert.ToDouble(stcActionRow.Cells["MuvakkatenVerilenSTCAction"].Value);
                sTCAction.Toplam = yMevcut + kMevcut + hMevcut + mMevcut;

//                if (sTCAction.Material is DrugDefinition || sTCAction.Material is ConsumableMaterialDefinition)
//                {
//                    if (((double)stcActionRow.Cells["KullanilmisMevcutSTCAction"].Value) > 0 || ((double)stcActionRow.Cells["HEKMevcutSTCAction"].Value) > 0)
//                    {
//                        throw new TTException("Sarf edilebilen malzemeler için Hek veya Kullanılmış Mevcut giremezsiniz.");
//                    }
//                }
            }
#endregion STFActionFrom_STCActions_CellValueChanged
        }

        protected override void PreScript()
        {
#region STFActionFrom_PreScript
    base.PreScript();
            this.cmdOK.Visible = false ;
#endregion STFActionFrom_PreScript

            }
                }
}