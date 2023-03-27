
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
    public partial class BaseDirectPurchaseActionForm : TTForm
    {
        protected override void PreScript()
        {
#region BaseDirectPurchaseActionForm_PreScript
    base.PreScript();
            if(Common.CurrentDoctor != null)
            {
                if(this._DirectPurchaseAction.RequesterDoctor == null)
                    this._DirectPurchaseAction.RequesterDoctor = Common.CurrentDoctor;
            }
            
            if(this._DirectPurchaseAction.DirectPurchaseActionType.HasValue == false)
            {
                if (this._DirectPurchaseAction.MasterResource is ResClinic && ((ResClinic)this._DirectPurchaseAction.MasterResource).Brans != null)
                {
                    if (((ResClinic)this._DirectPurchaseAction.MasterResource).Brans.Code == "3400" || ((ResClinic)this._DirectPurchaseAction.MasterResource).Brans.Code == "9900")
                        this._DirectPurchaseAction.DirectPurchaseActionType = DirectPurchaseActionTypeEnum.RadioPharmaceutical;
                    else
                        this._DirectPurchaseAction.DirectPurchaseActionType = DirectPurchaseActionTypeEnum.Titubb;
                }
                else
                    this._DirectPurchaseAction.DirectPurchaseActionType = DirectPurchaseActionTypeEnum.Titubb;
            }
#endregion BaseDirectPurchaseActionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseDirectPurchaseActionForm_PostScript
    base.PostScript(transDef);
            
            if(this._DirectPurchaseAction.CommissionMembers.Count != 6)
                throw new TTException("Komisyon Üyeleri; 1 asil başkan, 2 asil üye ve 1 yedek başkan, 2 yedek üyeden oluşmalıdır.");
            else
            {
                int primeChiefCount = 0;
                int backupChiefCount = 0;
                int primeMemberCount = 0;
                int backupMemberCount = 0;
                foreach (DirectPurchaseCommisionMember commisionMember in  this._DirectPurchaseAction.CommissionMembers)
                {
                    if(this._DirectPurchaseAction.RequesterDoctor != null && this._DirectPurchaseAction.RequesterDoctor.ObjectID.Equals(commisionMember.ResUser.ObjectID))
                        throw new TTException("İsteği yapan doktor, komisyon üyeleri arasında bulunamaz.");
                    if(commisionMember.MemberDuty.HasValue && commisionMember.MemberDuty.Value.ToString() == DPACommisionMemberDutyEnum.Chief.ToString() && commisionMember.PrimeBackup == true)
                        primeChiefCount++;
                    if(commisionMember.MemberDuty.HasValue && commisionMember.MemberDuty.Value.ToString() == DPACommisionMemberDutyEnum.Chief.ToString() && commisionMember.PrimeBackup != true)
                        backupChiefCount++;
                    if(commisionMember.MemberDuty.HasValue && commisionMember.MemberDuty.Value.ToString() == DPACommisionMemberDutyEnum.Member.ToString() && commisionMember.PrimeBackup == true)
                        primeMemberCount++;
                    if(commisionMember.MemberDuty.HasValue && commisionMember.MemberDuty.Value.ToString() == DPACommisionMemberDutyEnum.Member.ToString() && commisionMember.PrimeBackup != true)
                        backupMemberCount++;
                }
                if(primeChiefCount != 1)
                    throw new TTException("Komisyon üyeleri arasında 1 asil başkan olmalıdır.");
                if(backupChiefCount != 1)
                    throw new TTException("Komisyon üyeleri arasında 1 yedek başkan olmalıdır.");
                if(primeMemberCount != 2)
                    throw new TTException("Komisyon üyeleri arasında 2 asil üye olmalıdır.");
                if(backupMemberCount != 2)
                    throw new TTException("Komisyon üyeleri arasında 2 yedek üye olmalıdır.");
            }
#endregion BaseDirectPurchaseActionForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseDirectPurchaseActionForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
#endregion BaseDirectPurchaseActionForm_ClientSidePostScript

        }

#region BaseDirectPurchaseActionForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            ProductDefinition productDefinition = null;
            ProductSUTMatchDefinition productSutMatchDefinition = null;
            IBindingList productList = _DirectPurchaseAction.ObjectContext.QueryObjects("PRODUCTDEFINITION","PRODUCTNUMBER='"+value+"'");
            if (productList.Count == 0)
                InfoBox.Show(value + " barkodlu TITUBB ürünü bulunamadı.",MessageIconEnum.ErrorMessage);
            else
            {
                IList<ProductSUTMatchDefinition> productSutMatchList = new List<ProductSUTMatchDefinition>();
                foreach(ProductDefinition product in productList)
                {
                    foreach(ProductSUTMatchDefinition productSutMatch in product.ProductSUTMatchs)
                        productSutMatchList.Add(productSutMatch);
                }
                
                if(productSutMatchList.Count == 0)
                {
                    InfoBox.Show(value + " barkodlu TITUBB ürününün fiyat tanımı bulunamadı.",MessageIconEnum.ErrorMessage);
                }
                else if(productSutMatchList.Count == 1)
                {
                    productSutMatchDefinition = (ProductSUTMatchDefinition)productSutMatchList[0];
                }
                else
                {
                    MultiSelectForm multiSelectForm = new MultiSelectForm();
                    foreach (ProductSUTMatchDefinition sutMatch in productSutMatchList)
                    {
                        string msItem = "";
                        if(sutMatch.SUTPrice.HasValue == true)
                            msItem = sutMatch.SUTCode + " - " + sutMatch.Product.Name + " - " + sutMatch.SUTPrice.Value.ToString("#.00") + "TL";
                        else
                            msItem = sutMatch.SUTCode + " - " + sutMatch.Product.Name + " - " + "Fiyat Bulunamadı";
                        multiSelectForm.AddMSItem(msItem , sutMatch.ObjectID.ToString(), sutMatch);
                    }
                    string key = multiSelectForm.GetMSItem(this.ParentForm, "Ürün Seçiniz");

                    if (string.IsNullOrEmpty(key))
                        InfoBox.Show("Herhangi bir ürün seçilmedi.", MessageIconEnum.ErrorMessage);
                    else
                        productSutMatchDefinition = multiSelectForm.MSSelectedItemObject as ProductSUTMatchDefinition;
                }
            }

            if (productSutMatchDefinition != null)
            {
                string retAmount = InputForm.GetText("Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                
                DirectPurchaseActionDetail directPurchaseActionDetail = _DirectPurchaseAction.DirectPurchaseActionDetails.AddNew();
                directPurchaseActionDetail.SUTCode = productSutMatchDefinition;
                directPurchaseActionDetail.SUTName = productSutMatchDefinition.Product.Name;
                directPurchaseActionDetail.SUTPrice = productSutMatchDefinition.SUTPrice.HasValue ? (Currency?)productSutMatchDefinition.SUTPrice.Value : null;
                directPurchaseActionDetail.Amount = amount;
            }
        }
        
#endregion BaseDirectPurchaseActionForm_ClientSideMethods
    }
}