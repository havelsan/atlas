
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
    /// İlaç Tanımı
    /// </summary>
    public partial class DrugDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            cmdChangeTypeToConsumableButton.Click += new TTControlEventDelegate(cmdChangeTypeToConsumableButton_Click);
            btnCalculate.Click += new TTControlEventDelegate(btnCalculate_Click);
            searchMedicineFromMedula.Click += new TTControlEventDelegate(searchMedicineFromMedula_Click);
            cmdAddEquiv.Click += new TTControlEventDelegate(cmdAddEquiv_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdChangeTypeToConsumableButton.Click -= new TTControlEventDelegate(cmdChangeTypeToConsumableButton_Click);
            btnCalculate.Click -= new TTControlEventDelegate(btnCalculate_Click);
            searchMedicineFromMedula.Click -= new TTControlEventDelegate(searchMedicineFromMedula_Click);
            cmdAddEquiv.Click -= new TTControlEventDelegate(cmdAddEquiv_Click);
            base.UnBindControlEvents();
        }

        private void cmdChangeTypeToConsumableButton_Click()
        {
#region DrugDefinitionForm_cmdChangeTypeToConsumableButton_Click
   TTForm checkForm = new CheckSitesBeforeChangeDrugToConsumableMaterialForm();
            checkForm.ShowEdit(this.FindForm(), _DrugDefinition, false);
#endregion DrugDefinitionForm_cmdChangeTypeToConsumableButton_Click
        }

        private void btnCalculate_Click()
        {
#region DrugDefinitionForm_btnCalculate_Click
   if (string.IsNullOrEmpty(txtTestAmount.Text))
                InfoBox.Alert("Hesaplama yapabilmek için Test Miktarı girilmelidir.", MessageIconEnum.WarningMessage);
            else
            {
                double testAmount = 0;
                try
                {
                    testAmount = Convert.ToDouble(txtTestAmount.Text);
                }
                catch
                {
                    InfoBox.Alert("Test Miktarı sayısal bir değer olmalıdır.", MessageIconEnum.WarningMessage);
                    return;
                }
                
                if(testAmount == 0)
                    InfoBox.Alert("Test Miktarı sıfır olmamalıdır.", MessageIconEnum.WarningMessage);
                else
                {
                    ArrayList pricingDetailList = new ArrayList();
                    TTObjectContext objectContext = new TTObjectContext(true);
                    PricingListDefinition drugPriceList = (PricingListDefinition)PricingListDefinition.GetByObjectID(objectContext, TTObjectClasses.SystemParameter.GetParameterValue("DRUGPRICELISTOBJECTID", "57c5a43f-2083-433a-9f05-94c49c284436").ToString())[0];
                    if(drugPriceList == null)
                        InfoBox.Alert("İlaç Fiyat Listesi bulunamadı.", MessageIconEnum.WarningMessage);
                    else
                    {
                        pricingDetailList = _DrugDefinition.GetMaterialPricingDetail(drugPriceList, Common.RecTime());
                        string calculationInfo = string.Empty;
                        
                        if(pricingDetailList.Count == 0)
                            InfoBox.Alert("İlaç Fiyat Listesi'nde ilacın eşleştiği aktif fiyat bulunamadı.", MessageIconEnum.InformationMessage);
                        else
                        {
                            PricingDetailDefinition pricingDetailDefinition = (PricingDetailDefinition)pricingDetailList[0];
                            
                            if (!pricingDetailDefinition.Price.HasValue)
                                InfoBox.Alert("İlacın eşleştiği fiyat tanımındaki fiyat bilgisi bulunamadı.", MessageIconEnum.InformationMessage);
                            else
                            {
                                calculationInfo += "İlaç Fiyatı : " + pricingDetailDefinition.Price.ToString() + "\r\n";
                                calculationInfo += "Birim Fiyat Böleni : " + (_DrugDefinition.AccTrxUnitPriceDivider.HasValue ? _DrugDefinition.AccTrxUnitPriceDivider.Value.ToString() : string.Empty) + "\r\n";
                                calculationInfo += "Miktar Çarpanı : " + (_DrugDefinition.AccTrxAmountMultiplier.HasValue ? _DrugDefinition.AccTrxAmountMultiplier.Value.ToString() : string.Empty) + "\r\n";
                                calculationInfo += "Test Miktarı : " + txtTestAmount.Text + "\r\n\r\n";
                                
                                double unitPrice = Convert.ToDouble(pricingDetailDefinition.Price);
                                if(_DrugDefinition.AccTrxUnitPriceDivider.HasValue)
                                    unitPrice = unitPrice / _DrugDefinition.AccTrxUnitPriceDivider.Value;
                                
                                double amount = Convert.ToDouble(txtTestAmount.Text);
                                if(_DrugDefinition.AccTrxAmountMultiplier.HasValue)
                                    amount = amount * _DrugDefinition.AccTrxAmountMultiplier.Value;
                                
                                double totalPrice = unitPrice * amount;
                                
                                calculationInfo += "Ücretlenince Oluşacak Birim Fiyat : " + unitPrice.ToString() + "\r\n";
                                calculationInfo += "Ücretlenince Oluşacak Miktar : " + amount.ToString() + "\r\n";
                                calculationInfo += "Ücretlenince Oluşacak Toplam Fiyat : " + totalPrice.ToString() + "\r\n";

                                InfoBox.Alert(calculationInfo, MessageIconEnum.InformationMessage);
                            }
                        }
                    }
                }
            }
#endregion DrugDefinitionForm_btnCalculate_Click
        }

        private void searchMedicineFromMedula_Click()
        {
#region DrugDefinitionForm_searchMedicineFromMedula_Click
   MedulaYardimciIslemler.ilacAraGirisDVO requset = new MedulaYardimciIslemler.ilacAraGirisDVO();
            requset.ilacAdi = Name.Text;
            requset.barkod = Barcode.Text;
            requset.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            MedulaYardimciIslemler.ilacAraCevapDVO response = MedulaYardimciIslemler.WebMethods.ilacAraSync(Sites.SiteLocalHost, requset);
            if (response != null)
            {
                if (response.ilaclar == null)
                {
                    InfoBox.Alert(response.sonucMesaji);
                }
            }
#endregion DrugDefinitionForm_searchMedicineFromMedula_Click
        }

        private void cmdAddEquiv_Click()
        {
#region DrugDefinitionForm_cmdAddEquiv_Click
   bool error = false;
            /*if (_DrugDefinition.IsArmyDrug == false)
            {
                if (_DrugDefinition.SPTSDrugID != null)
                    error = true;
                IList sosFarma = _DrugDefinition.ObjectContext.QueryObjects("SOSURUNBILGISI","XXXXXXDRUGDEFINITION=" + ConnectionManager.GuidToString(_DrugDefinition.ObjectID));
                if(sosFarma.Count > 0)
                    error = true;
            }*/
            if (error == false)
            {
                TTListDef listDef = TTObjectDefManager.Instance.ListDefs["DrugList"];
                string listFilterExpression = string.Empty;
                TTList List = TTList.NewList(_DrugDefinition.ObjectContext, listDef, listFilterExpression);
                TTObject[] _selectedObjects;
                TTListFormMultiSelect frm = new TTListFormMultiSelect(List);

                _selectedObjects = frm.GetSelectedObjects();

                if (_selectedObjects != null)
                {
                    List<Guid> oldID = new List<Guid>();
                    foreach (ManuelEquivalentDrug.GetManuelEquivalentDrugs_Class oldEqu in ManuelEquivalentDrug.GetManuelEquivalentDrugs(_DrugDefinition.ObjectID))
                        oldID.Add((Guid)oldEqu.EquivalentDrug);

                    foreach (TTObject obj in _selectedObjects)
                    {
                        if (oldID.Contains(obj.ObjectID) == false)
                        {
                            DrugDefinition equivalentDrug = (DrugDefinition)_DrugDefinition.ObjectContext.GetObject(obj.ObjectID, "DRUGDEFINITION");


                            ManuelEquivalentDrug manuelEquivalentDrug = new ManuelEquivalentDrug(_DrugDefinition.ObjectContext);
                            manuelEquivalentDrug.EquivalentDrug = equivalentDrug;
                            _DrugDefinition.ManuelEquivalentDrugs.Add(manuelEquivalentDrug);

                            List<Guid> equOldID = new List<Guid>();
                            foreach (ManuelEquivalentDrug.GetManuelEquivalentDrugs_Class oldEqu in ManuelEquivalentDrug.GetManuelEquivalentDrugs(equivalentDrug.ObjectID))
                                equOldID.Add((Guid)oldEqu.EquivalentDrug);

                            if (equOldID.Contains(_DrugDefinition.ObjectID) == false)
                            {
                                ManuelEquivalentDrug equivalentDrugEquivalent = new ManuelEquivalentDrug(_DrugDefinition.ObjectContext);
                                equivalentDrugEquivalent.EquivalentDrug = _DrugDefinition;
                                equivalentDrug.ManuelEquivalentDrugs.Add(equivalentDrugEquivalent);
                            }
                        }
                    }
                }
            }
            else
                InfoBox.Alert("Manuel eşdeğer ekleyebilmeniz için ilacın SPTS veya İlaç Bilgi Bankasından gelmemiş olması veya XXXXXX İlacı olması gerekmektedir.", MessageIconEnum.ErrorMessage);
#endregion DrugDefinitionForm_cmdAddEquiv_Click
        }

        protected override void PreScript()
        {
#region DrugDefinitionForm_PreScript
    base.PreScript();
            //this.MalzelemeGetData.ListFilterExpression = " MALZEMETURID <> 'DM' ";
            
            
            tttabcontrol1.HideTabPage(Ek2EquivalentTabPage);
            BindingList<SOSUrunBilgisi.GetSOSUrunBilgisiRQ_Class> sosUrunBilgisi = SOSUrunBilgisi.GetSOSUrunBilgisiRQ(_DrugDefinition.ObjectID);
            if (sosUrunBilgisi.Count > 0)
                this.SosFarmaCheckBox.Value = true;
            else
                this.SosFarmaCheckBox.Value = false;

            BindingList<DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class> equivalentDrugs = DrugDefinition.GetDrugDefinitionByEquivalentReportQuery(((DrugDefinition)this._ttObject).EquivalentCRC);
            EquivalentsGrid.Rows.Clear();
            foreach (DrugDefinition.GetDrugDefinitionByEquivalentReportQuery_Class drug in equivalentDrugs)
            {
                if (drug.ObjectID.Equals(this._ttObject.ObjectID) == false)
                {
                    ITTGridRow gridRow = EquivalentsGrid.Rows.Add();
                    gridRow.Cells["EquivalentDrugName"].Value = drug.Name;
                }
            }

            Sites mySite = TTObjectClasses.SystemParameter.GetSite();

            /*if (mySite.ObjectID == Sites.SiteMerkezSagKom)
                this.IsExpendableMaterial.ReadOnly = false;
            else
                this.IsExpendableMaterial.ReadOnly = true;*/

            this.MaterialPriceGrid.Rows.Clear();

            BindingList<MaterialPrice.MaterialPriceByMaterialForDefinition_Class> drugPrices = MaterialPrice.MaterialPriceByMaterialForDefinition(this._ttObject.ObjectID.ToString());

            foreach (MaterialPrice.MaterialPriceByMaterialForDefinition_Class materialPrice in drugPrices)
            {
                //if (materialPrice.PricingDetail.DateEnd > Common.RecTime())
                //{
                ITTGridRow addedRow = this.MaterialPriceGrid.Rows.Add();
                addedRow.Cells["PriceCode"].Value = materialPrice.ExternalCode;
                addedRow.Cells["PriceDesc"].Value = materialPrice.Description;
                addedRow.Cells["PricingList"].Value = materialPrice.Pricelistname;
                addedRow.Cells["Price"].Value = materialPrice.Price;
                addedRow.Cells["CurrencyType"].Value = materialPrice.Currencytype;
                //}
            }


            if (mySite.ObjectID == Sites.SiteMerkezSagKom)
            {
                cmdChangeTypeToConsumableButton.Enabled = true;
            }
            else
            {
                cmdChangeTypeToConsumableButton.Enabled = false;
            }

            /*if (mySite.ObjectID == Sites.SiteMerkezSagKom)
                cmdAddEquiv.ReadOnly = false;
            else
                cmdAddEquiv.ReadOnly = true;*/
#endregion DrugDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DrugDefinitionForm_PostScript
    base.PostScript(transDef);
            
            if(_DrugDefinition.AccTrxUnitPriceDivider.HasValue && _DrugDefinition.AccTrxUnitPriceDivider.Value == 0)
                throw new TTUtils.TTException("Birim Fiyat Böleni sıfır olamaz, sıfırdan farklı bir değer giriniz.");
            
            if(_DrugDefinition.AccTrxAmountMultiplier.HasValue && _DrugDefinition.AccTrxAmountMultiplier.Value == 0)
                throw new TTUtils.TTException("Miktar Çarpanı sıfır olamaz, sıfırdan farklı bir değer giriniz.");
#endregion DrugDefinitionForm_PostScript

            }
                }
}