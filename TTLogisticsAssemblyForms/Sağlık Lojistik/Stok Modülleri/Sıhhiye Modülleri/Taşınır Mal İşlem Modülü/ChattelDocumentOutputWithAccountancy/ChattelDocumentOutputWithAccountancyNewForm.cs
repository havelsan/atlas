
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
    public partial class ChattelDocumentOutputWithAccountancyNewForm : BaseChattelDocumentOutputWithAccountancy
    {
        protected override void PreScript()
        {
            #region ChattelDocumentOutputWithAccountancyNewForm_PreScript
            base.PreScript();
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
            ((ITTListBoxColumn)((ITTGridColumn)this.ChattelDocumentDetailsWithAccountancy.Columns["MaterialChattelDocumentDetailWithAccountancy"])).ListFilterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(_ChattelDocumentOutputWithAccountancy.Store.ObjectID) + " AND STOCKS.INHELD > 0";
            #endregion ChattelDocumentOutputWithAccountancyNewForm_PreScript


            if (_ChattelDocumentOutputWithAccountancy.Store is MainStoreDefinition)
            {
                _ChattelDocumentOutputWithAccountancy.MKYS_TeslimEden = ((MainStoreDefinition)_ChattelDocumentOutputWithAccountancy.Store).GoodsAccountant.Name;
                _ChattelDocumentOutputWithAccountancy.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_ChattelDocumentOutputWithAccountancy.Store).GoodsAccountant.ObjectID;
            }
        }


        protected override void ClientSidePreScript()
        {
            #region ChattelDocumentOutputWithAccountancyNewForm_ClientSidePreScript
            base.ClientSidePreScript();

            this._ChattelDocumentOutputWithAccountancy.MKYS_CikisIslemTuru = MKYS_ECikisIslemTuruEnum.cikis;

            #endregion ChattelDocumentOutputWithAccountancyNewForm_ClientSidePreScript

        }


        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ChattelDocumentOutputWithAccountancyNewForm_PostScript
    base.PostScript(transDef);
            
            int count = 20;
            _ChattelDocumentOutputWithAccountancy.CheckStockCardCardNofCount(count);
            
            
//            if(_ChattelDocumentOutputWithAccountancy.Accountancy.AccountancyMilitaryUnit == null)
//                throw new TTUtils.TTException("Çıkış yaptığınız saymanlığın birliği tanımlı değildir. Bu saymanlığa merkezden birlik tanımlanmalıdır. Sağlık XXXXXX ile irtibata geçiniz.");
#endregion ChattelDocumentOutputWithAccountancyNewForm_PostScript

            }
            
#region ChattelDocumentOutputWithAccountancyNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _ChattelDocumentOutputWithAccountancy.ObjectContext.QueryObjects("MATERIAL","BARCODE='"+value+"'");
            if (materials.Count == 0)
                InfoBox.Show(value + " UBB/Barkodlu malzeme bulunamadı.",MessageIconEnum.ErrorMessage);
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name , m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                
                string retAmount = InputForm.GetText("Çıkış Yapılacak Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                
                ChattelDocumentOutputDetailWithAccountancy chattelDocumentOutputDetailWithAccountancy = _ChattelDocumentOutputWithAccountancy.ChattelDocumentOutputDetailsWithAccountancy.AddNew();
                chattelDocumentOutputDetailWithAccountancy.Material = material;
                chattelDocumentOutputDetailWithAccountancy.Amount = amount;
                chattelDocumentOutputDetailWithAccountancy.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                
            }
        }
        
#endregion ChattelDocumentOutputWithAccountancyNewForm_ClientSideMethods
    }
}