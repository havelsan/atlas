
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
    /// İlaç / Etken Madde Sorgulama Formu
    /// </summary>
    public partial class EtkenMaddeIlacSorgulamaFormu : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnEtkinMaddeAra.Click += new TTControlEventDelegate(btnEtkinMaddeAra_Click);
            btnIlacAra.Click += new TTControlEventDelegate(btnIlacAra_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnEtkinMaddeAra.Click -= new TTControlEventDelegate(btnEtkinMaddeAra_Click);
            btnIlacAra.Click -= new TTControlEventDelegate(btnIlacAra_Click);
            base.UnBindControlEvents();
        }

        private void btnEtkinMaddeAra_Click()
        {
#region EtkenMaddeIlacSorgulamaFormu_btnEtkinMaddeAra_Click
   IBindingList drugs = null;
            gridEtkinMaddeler.Rows.Clear();
            TTObjectContext context = new TTObjectContext(true);
            
            if(lstIlac.SelectedValue != null )
            {
                DrugDefinition drugDefinition =(DrugDefinition)((TTListBox)this.lstIlac).SelectedObject;
                if(drugDefinition != null)
                {
                    drugs = context.QueryObjects("DRUGDEFINITION", "NAME like '%" + drugDefinition.Name + "%'" );
//                    if(txtIlacınAdi.Text != null )
//                        drugs = context.QueryObjects("DRUGDEFINITION", "NAME like '%" + this.txtIlacınAdi.Text + "%' OR ORIGINALNAME LIKE '%" + this.txtIlacınAdi.Text + "%'" );
//                    else if(txtBarcode.Text!= null)
//                        drugs = context.QueryObjects("DRUGDEFINITION", "BARCODE like '%" + this.txtBarcode.Text + "%'");
//                    else
//                        return;
                    
                    if(drugs != null)
                    {
                        foreach (DrugDefinition drug in drugs)
                        {
                            if(drug.EtkinMadde != null)
                            {
                                ITTGridRow newRow = gridEtkinMaddeler.Rows.Add();
                                newRow.Cells[txtGridEtkinMaddeKodu.Name].Value = drug.EtkinMadde.etkinMaddeKodu ;
                                newRow.Cells[txtGridEtkinMaddeAdi.Name].Value =  drug.EtkinMadde.etkinMaddeAdi ;
                            }
                        }
                    }
                }
            }
#endregion EtkenMaddeIlacSorgulamaFormu_btnEtkinMaddeAra_Click
        }

        private void btnIlacAra_Click()
        {
#region EtkenMaddeIlacSorgulamaFormu_btnIlacAra_Click
   IBindingList drugs = null;
            gridIlaclar.Rows.Clear();
            if(lstEtkinMadde.SelectedValue != null )
            {
                EtkinMadde etkinMadde =(EtkinMadde)((TTListBox)this.lstEtkinMadde).SelectedObject;
                if(etkinMadde != null)
                {
                    drugs = DrugDefinition.GetDrugDefByEtkinMaddeKodu(etkinMadde.etkinMaddeKodu);
                    if(drugs != null)
                    {
                        foreach (DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class drug in drugs)
                        {
                            ITTGridRow newRow = gridIlaclar.Rows.Add();
                            newRow.Cells[txtIlacAdi.Name].Value = drug.Name ;
                            newRow.Cells[txtGridBarcode.Name].Value = drug.Barcode ;
                        }
                    }
                }
            }
#endregion EtkenMaddeIlacSorgulamaFormu_btnIlacAra_Click
        }

#region EtkenMaddeIlacSorgulamaFormu_Methods
        public static EtkenMaddeIlacSorgulamaFormu NewEtkenMaddeIlacSorgulamaFormu(DrugDefinition drugDefinition) //  : this()        
        {
            EtkenMaddeIlacSorgulamaFormu etkenMaddeIlacSorgulamaFormu  = new EtkenMaddeIlacSorgulamaFormu();
            TTObjectContext context = new TTObjectContext(true);
            IBindingList drugs = null;
            etkenMaddeIlacSorgulamaFormu.lstIlac.SelectedObject = drugDefinition;
            if(drugDefinition.Name != null)
            {
                drugs = context.QueryObjects("DRUGDEFINITION", "NAME like '%" + drugDefinition.Name + "%'");
                if(drugs != null)
                {
                    foreach (DrugDefinition drug in drugs)
                    {
                        if(drug.EtkinMadde != null)
                        {
                            ITTGridRow newRow = etkenMaddeIlacSorgulamaFormu.gridEtkinMaddeler.Rows.Add();
                            newRow.Cells[0].Value = drug.EtkinMadde.etkinMaddeKodu ;
                            newRow.Cells[1].Value =  drug.EtkinMadde.etkinMaddeAdi ;
                        }
                    }
                }
            }
            //ilacEtkinMaddeSorgulamaForm.cmdOK.Visible = false;
              return etkenMaddeIlacSorgulamaFormu;
        }
        
        public static EtkenMaddeIlacSorgulamaFormu  NewIEtkenMaddeIlacSorgulamaFormu2(ParticipationFreeDrgGrid participationFreeDrgGrid) //  : this()        
        {
            EtkenMaddeIlacSorgulamaFormu etkenMaddeIlacSorgulamaFormu  = new EtkenMaddeIlacSorgulamaFormu();
            TTObjectContext context = new TTObjectContext(true);
            IBindingList drugs = null;
            etkenMaddeIlacSorgulamaFormu.lstEtkinMadde.SelectedObject = participationFreeDrgGrid.EtkinMadde;
            if(participationFreeDrgGrid.EtkinMadde != null)
            {
                drugs = DrugDefinition.GetDrugDefByEtkinMaddeKodu(participationFreeDrgGrid.EtkinMadde.etkinMaddeKodu);
                if(drugs != null)
                {
                    foreach (DrugDefinition.GetDrugDefByEtkinMaddeKodu_Class drug in drugs)
                    {
                        ITTGridRow newRow = etkenMaddeIlacSorgulamaFormu.gridIlaclar.Rows.Add();
                        newRow.Cells[0].Value = drug.Barcode ;
                        newRow.Cells[1].Value = drug.Name ;
                    }
                }
            }
            //ilacEtkinMaddeSorgulamaForm.cmdOK.Visible = false;
              return etkenMaddeIlacSorgulamaFormu;
        }
        
#endregion EtkenMaddeIlacSorgulamaFormu_Methods
    }
}