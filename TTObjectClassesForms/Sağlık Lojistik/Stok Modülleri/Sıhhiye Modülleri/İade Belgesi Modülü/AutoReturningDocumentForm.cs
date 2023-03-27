
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
    public partial class AutoReturningDocument : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ReturningDocCreat.Click += new TTControlEventDelegate(ReturningDocCreat_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ReturningDocCreat.Click -= new TTControlEventDelegate(ReturningDocCreat_Click);
            base.UnBindControlEvents();
        }

        private void ReturningDocCreat_Click()
        {
#region AutoReturningDocument_ReturningDocCreat_Click
   TaskScript();
#endregion AutoReturningDocument_ReturningDocCreat_Click
        }

#region AutoReturningDocument_Methods
        public void TaskScript()
        {
            TTObjectContext readOnlyContex = new TTObjectContext(true);
            IList storeList = readOnlyContex.QueryObjects("STORE", "OBJECTDEFID IN('5132326b-d01f-4086-897f-7daf0f3dce5a','009d82e7-40a9-444f-b8c6-a3ca69eca81c') AND STATUS = 1 AND ISACTIVE = 1 AND AUTORETURNINGDOCUMENTCREAT = 1");
            StockTransactionDefinition stockTransactionDefinition = (StockTransactionDefinition)readOnlyContex.GetObject(new Guid("0899912a-e828-4e81-a84a-808d20971a22"), "STOCKTRANSACTIONDEFINITION");
            foreach (Store store in storeList)
            {
                TTObjectContext context = new TTObjectContext(false);
                Dictionary<Material, ReturningDocumentMaterial> returningMaterial = new Dictionary<Material, ReturningDocumentMaterial>();
                BindingList<Stock> stocks = store.Stocks.Select("inheld > 0 or consigned > 0");
                
                
                if (stocks != null)
                {
                    foreach (Stock stock in stocks)
                    {
                        if (returningMaterial.ContainsKey(stock.Material))
                        {
                            returningMaterial[stock.Material].Amount = returningMaterial[stock.Material].Amount + (Currency)stock.Inheld;
                        }
                        else
                        {
                            IList prescriptionPapers = readOnlyContex.QueryObjects("PRESCRIPTIONPAPER", "STOCK =" + ConnectionManager.GuidToString(stock.ObjectID));
                            if (prescriptionPapers != null)
                            {
                                ReturningDocumentMaterial returningDocument = new ReturningDocumentMaterial(context);
                                returningDocument.Amount = stock.Inheld;
                                returningDocument.RequireAmount = stock.Inheld;
                                returningDocument.Material = stock.Material;
                                returningDocument.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                                returningDocument.Material.StockCard.DistributionType = stock.Material.StockCard.DistributionType;

                                returningMaterial.Add(stock.Material, returningDocument);
                            }
                        }
                    }
                }

                if (returningMaterial.Count > 0)
                {
                    int count = 0;
                    ReturningDocument returningDocument = null;
                    foreach (KeyValuePair<Material, ReturningDocumentMaterial> matOut in returningMaterial)
                    {
                        if (count == 0)
                        {
                            returningDocument = new ReturningDocument(context);
                            returningDocument.CurrentStateDefID = ReturningDocument.States.New;
                            returningDocument.Store = store;


                            IList mainStores = MainStoreDefinition.GetAllMainStores(context);
                            if (mainStores.Count == 0)
                                throw new TTException("Saymanlık deposu bulunamadı.");
                            if (mainStores.Count == 1)
                            {
                                returningDocument.DestinationStore = (MainStoreDefinition)mainStores[0];
                            }
                            else
                            {
                                throw new TTException("Birden fazla saymanlık deposu bulundu.");
                            }
                            returningDocument.Update();
                        }
                        ReturningDocumentMaterial returningDocumentMaterial = matOut.Value;
                        returningDocumentMaterial.StockAction = returningDocument;
                        count++;
                        if (count == 30)
                            count = 0;
                    }

                    List<ResUser> toUsers = new List<ResUser>();
                    if (returningDocument.DestinationStore is MainStoreDefinition)
                    {
                        if (((MainStoreDefinition)returningDocument.DestinationStore).GoodsResponsible != null)
                        {
                            toUsers.Add(((MainStoreDefinition)returningDocument.DestinationStore).GoodsResponsible);
                        }
                    }
                    if (returningDocument.Store is SubStoreDefinition)
                    {
                        if (((SubStoreDefinition)returningDocument.Store).StoreResponsible != null)
                            toUsers.Add(((SubStoreDefinition)returningDocument.Store).StoreResponsible);
                    }
                    else if (returningDocument.Store is PharmacyStoreDefinition)
                    {
                        if (((PharmacyStoreDefinition)returningDocument.Store).StoreResponsible != null)
                            toUsers.Add(((PharmacyStoreDefinition)returningDocument.Store).StoreResponsible);
                    }

                    string msg = returningDocument.Store.Name + " deposu için İade Belgesi oluşturulmuştur.";
                    UserMessage.SendMessageInternalWithResUser(context, toUsers, "Otomatik Oluşturulan İade Belgesi", Globals.StringToRTF(msg));
                    InfoBox.Show(msg);
                    context.Save();
                }
                context.Dispose();

            }
        }
        
#endregion AutoReturningDocument_Methods
    }
}