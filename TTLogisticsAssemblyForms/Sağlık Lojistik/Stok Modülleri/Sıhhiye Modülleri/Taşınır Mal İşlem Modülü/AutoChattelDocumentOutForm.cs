
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
    public partial class AutoChattelDocumentOut : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ChattelDocCreat.Click += new TTControlEventDelegate(ChattelDocCreat_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ChattelDocCreat.Click -= new TTControlEventDelegate(ChattelDocCreat_Click);
            base.UnBindControlEvents();
        }

        private void ChattelDocCreat_Click()
        {
#region AutoChattelDocumentOut_ChattelDocCreat_Click
   if (this.Accountancy != null && this.MainStore != null)
            {
                TaskChattelDocumentScript((Accountancy)this.Accountancy.SelectedObject, (MainStoreDefinition)this.MainStore.SelectedObject);
                InfoBox.Show("Taşınır Mal Çıkış Belgeleri Oluşturuldu.");
            }
            else
                throw new Exception("Önce Gönderileceği yeri Seçin");
#endregion AutoChattelDocumentOut_ChattelDocCreat_Click
        }

#region AutoChattelDocumentOut_Methods
        public void TaskChattelDocumentScript(Accountancy accountancy, MainStoreDefinition mainStoreDefinition)
        {

            TTObjectContext context = new TTObjectContext(false);

            Dictionary<Material, ChattelDocumentOutputDetailWithAccountancy> chattelDocumentDictionary = new Dictionary<Material, ChattelDocumentOutputDetailWithAccountancy>();
            BindingList<ChattelDocumentOutputWithAccountancy> chattelDoc2 = context.QueryObjects<ChattelDocumentOutputWithAccountancy>();


            Dictionary<Guid, ReturningDocumentMaterial> dicRetuningMaterial = new Dictionary<Guid, ReturningDocumentMaterial>();
            BindingList<ReturningDocument> returningDoc = context.QueryObjects<ReturningDocument>("IsChattelDocFlag = 1 and CURRENTSTATEDEFID ='252b3df0-3cc1-496b-805c-dcf5780f3ac8'");
            foreach (ReturningDocument retDoc in returningDoc)
            {
                foreach (ReturningDocumentMaterial retDocMat in retDoc.ReturningDocumentMaterials)
                {
                    dicRetuningMaterial.Add(retDocMat.ObjectID, retDocMat);
                }
            }

            foreach (KeyValuePair<Guid, ReturningDocumentMaterial> r in dicRetuningMaterial)
            {

                ChattelDocumentOutputDetailWithAccountancy newChatDocOutDet = new ChattelDocumentOutputDetailWithAccountancy(context);
                newChatDocOutDet.Material = r.Value.Material;
                newChatDocOutDet.Amount = r.Value.Amount;
                newChatDocOutDet.Material.Barcode = r.Value.Material.Barcode;
                newChatDocOutDet.Material.StockCard.DistributionType = r.Value.Material.StockCard.DistributionType;
                newChatDocOutDet.StockLevelType = r.Value.StockLevelType;

                chattelDocumentDictionary.Add(newChatDocOutDet.Material, newChatDocOutDet);

            }

            if (dicRetuningMaterial.Count > 0)
            {
                int count = 0;
                ChattelDocumentOutputWithAccountancy chattelDoc = null;
                foreach (KeyValuePair<Material, ChattelDocumentOutputDetailWithAccountancy> matOut in chattelDocumentDictionary)
                {
                    if (count == 0)
                    {
                        chattelDoc = new ChattelDocumentOutputWithAccountancy(context);
                        chattelDoc.CurrentStateDefID = ChattelDocumentOutputWithAccountancy.States.New;
                        chattelDoc.Accountancy = accountancy;
                        chattelDoc.Store = mainStoreDefinition;
                    }

                    ChattelDocumentOutputDetailWithAccountancy chattelDocOutDet = matOut.Value;
                    chattelDocOutDet.StockAction = chattelDoc;


                    count++;
                    if (count == 20)
                        count = 0;


                }

                List<ResUser> toUsers = new List<ResUser>();
                if (chattelDoc.DestinationStore is MainStoreDefinition)
                {
                    if (((MainStoreDefinition)chattelDoc.DestinationStore).GoodsResponsible != null)
                    {
                        toUsers.Add(((MainStoreDefinition)chattelDoc.DestinationStore).GoodsResponsible);
                    }
                }
                if (chattelDoc.Store is SubStoreDefinition)
                {
                    if (((SubStoreDefinition)chattelDoc.Store).StoreResponsible != null)
                        toUsers.Add(((SubStoreDefinition)chattelDoc.Store).StoreResponsible);
                }
                else if (chattelDoc.Store is PharmacyStoreDefinition)
                {
                    if (((PharmacyStoreDefinition)chattelDoc.Store).StoreResponsible != null)
                        toUsers.Add(((PharmacyStoreDefinition)chattelDoc.Store).StoreResponsible);
                }

                context.Save();
            }
            context.Dispose();
        }
        
#endregion AutoChattelDocumentOut_Methods
    }
}