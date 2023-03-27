
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
    public partial class CompleteBloodProductsForm : ScheduledTaskBaseForm
    {
        override protected void BindControlEvents()
        {
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton2_Click()
        {
#region CompleteBloodProductsForm_ttbutton2_Click
   //BURASI
            if (ttbutton1.Visible == false)
            {
                ttbutton1.Visible = true;
                tttextbox1.Visible = true;
            }
            else
            {
                ttbutton1.Visible = false;
                tttextbox1.Visible = false;
            }
#endregion CompleteBloodProductsForm_ttbutton2_Click
        }

        private void ttbutton3_Click()
        {
#region CompleteBloodProductsForm_ttbutton3_Click
   TTObjectContext objectContext = new TTObjectContext(false);
            //double expireLimit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("BLOODPRODUCTEXPIRELIMIT","72"));  // Değer saat türünde
            //DateTime expireDate = Common.RecTime().AddHours(-(expireLimit));
            
            double expireLimit = Convert.ToDouble("1");
            DateTime expireDate = Common.RecTime().AddMinutes(-(expireLimit));
            string objectDetails = String.Empty;
            
            //IList products = BloodBankBloodProducts.GetExpiredBloodProducts(objectContext, expireDate);
            IList products = BloodBankBloodProducts.GetExpiredBloodProductsToCancel(objectContext, expireDate);
            foreach(BloodBankBloodProducts product in products)
            {
                objectDetails = "BloodProductRequest.ID ="+product.EpisodeAction.ID+" - "+"BloodBankBloodProducts.ObjectID = " + product.ObjectID.ToString();
      
                if(product.BloodProductRequest.ObjectID.ToString().Trim() == "ffc68197-94a9-4a3f-9a2f-0461a59ee32d" || product.BloodProductRequest.ObjectID.ToString().Trim() == "2b0b8fa3-1838-45e7-939f-bb44f1f260c4" )
                {
                    try
                    {
                        if(product.BloodProductRequest.CurrentStateDefID == BloodProductRequest.States.BloodProductPreparation && product.CurrentStateDefID == BloodBankBloodProducts.States.New)
                        {
                            product.BloodProductRequest.CurrentStateDefID = BloodProductRequest.States.Reject;
                            objectContext.Save();
                            //this.AddLog(product.BloodProductRequest.ID.ToString() + " işlem numaralı kan ürün istek otomatik olarak iptal edildi.\r\n" + objectDetails);   
                        }
                        if(product.BloodProductRequest.CurrentStateDefID == BloodProductRequest.States.Completed && product.CurrentStateDefID == BloodBankBloodProducts.States.New)
                        {
                            product.CurrentStateDefID = BloodBankBloodProducts.States.Cancelled;
                            objectContext.Save();
                            //this.AddLog(product.BloodProductRequest.ID.ToString() + " işlem numaralı kan ürün istek otomatik olarak iptal edildi.\r\n" + objectDetails);   
                        }
                    }
                    catch (Exception ex)
                    {
                        //this.AddLog(ex.Message+" "+ objectDetails);
                    }
                }
                
                
            }
#endregion CompleteBloodProductsForm_ttbutton3_Click
        }

        private void ttbutton1_Click()
        {
#region CompleteBloodProductsForm_ttbutton1_Click
   //BURASI
   /*
            TTObjectContext objectContext = new TTObjectContext(false);
            dictionaryOfEpisodeProtocols = new Dictionary<Guid, Guid?>();
            //double expireLimit = Convert.ToDouble(TTObjectClasses.SystemParameter.GetParameterValue("BLOODPRODUCTEXPIRELIMIT","72"));  // Değer saat türünde
            //DateTime expireDate = Common.RecTime().AddHours(-(expireLimit));
            string objectDetails = String.Empty;
            string paramObjectId = tttextbox1.Text;
            //IList products = BloodBankBloodProducts.GetExpiredBloodProducts(objectContext, expireDate);
            //IList products = BloodBankBloodProducts.GetByObjectID(objectContext, "58aea7b9-20c5-41a5-a200-dbf475570edb");
            IList products = BloodBankBloodProducts.GetByObjectID(objectContext, paramObjectId);
            foreach (BloodBankBloodProducts product in products)
            {
                //
                _IsEpisodeProtocolsOpened = false;
                _IsPayerInvoiceCancelled = false;
                //
                if (CheckEpisodeProtocolCountOfThisEpisode(product.Episode))
                {
                    OpenEpisodeProtocols(product.Episode);
                    objectContext.Save();
                }
                //
                if (CheckPayerInvoiceCountOfThisEpisode(product.Episode))
                {
                    CancelPayerInvoiceOfThisEpisode(product.Episode);
                    objectContext.Save();
                }
                //
                
                //
                objectDetails = "BloodBankBloodProducts.ObjectID = " + product.ObjectID.ToString();
                bool hasUncompletedProduct = false;
                try
                {
                    if (product.BloodProductRequest.CurrentStateDefID == BloodProductRequest.States.BloodProductUsage)
                    {
                        if (product.CurrentStateDefID == BloodBankBloodProducts.States.New)
                        {
                            product.Used = true;
                            product.CurrentStateDefID = BloodBankBloodProducts.States.Completed;
                        }

                        foreach (BloodBankBloodProducts otherProduct in product.BloodProductRequest.BloodProducts)
                        {
                            if (otherProduct.ProductNumber != String.Empty && otherProduct.ProductDate != null && otherProduct.CurrentStateDefID == BloodBankBloodProducts.States.New)
                            {
                                hasUncompletedProduct = true;
                                break;
                            }
                        }

                        if (hasUncompletedProduct == false)
                            product.BloodProductRequest.CurrentStateDefID = BloodProductRequest.States.Completed;

                        objectContext.Save();
                        //
                        if (_IsPayerInvoiceCancelled)
                        {
                            RestorePayerInvoiceOfThisEpisode(objectContext);
                            objectContext.Save();
                        }
                        if (_IsEpisodeProtocolsOpened)
                        {
                            RestoreEpisodeProtocols(product.Episode);
                            objectContext.Save();
                        }
                        
                        //
                        //this.AddLog(product.ProductNumber + " torba numaralı ürün otomatik olarak tamamlandı.\r\n" + objectDetails);
                        MessageBox.Show(product.ProductNumber + " torba numaralı ürün otomatik olarak tamamlandı.\r\n" + objectDetails);
                    }
                }
                catch (Exception ex)
                {
                    //this.AddLog(ex.Message+" "+ objectDetails);

                    if (_IsPayerInvoiceCancelled)
                    {
                        RestorePayerInvoiceOfThisEpisode(objectContext);
                        objectContext.Save();
                    }
                    if (_IsEpisodeProtocolsOpened)
                    {
                        RestoreEpisodeProtocols(product.Episode);
                        objectContext.Save();
                    }
                    MessageBox.Show(ex.Message + " " + objectDetails);
                }*/
                    /*
                finally
                {
                    RestoreEpisodeProtocols(product.Episode);
                    objectContext.Save();
                    RestorePayerInvoiceOfThisEpisode(objectContext);
                    objectContext.Save();
                }
                     */ 
            //}
            
            /*
            ///
            TTObjectContext objectContext = new TTObjectContext(false);
            IList products = BloodBankBloodProducts.GetByObjectID(objectContext, "58aea7b9-20c5-41a5-a200-dbf475570edb");
            foreach(BloodBankBloodProducts product in products)
            {
                string messageOfPayerInvoice = CheckPayerInvoiceStatus(product.Episode).ToString();
                MessageBox.Show(messageOfPayerInvoice);
            }
            ///
             */
#endregion CompleteBloodProductsForm_ttbutton1_Click
        }

#region CompleteBloodProductsForm_Methods
        //BURASI

        //Değişkenler
        Dictionary<Guid, Guid?> dictionaryOfEpisodeProtocols;
        bool _IsEpisodeProtocolsOpened;
        bool _IsPayerInvoiceCancelled;
        PayerInvoice tempPayerInvoice;
        
        private bool CheckPayerInvoiceCountOfThisEpisode(Episode episode)
        {
            int counter = 0;
            foreach (EpisodeAction epAction in episode.EpisodeActions)
            {
                if (epAction is PayerInvoice &&(epAction.CurrentStateDefID == PayerInvoice.States.Invoiced ||epAction.CurrentStateDefID == PayerInvoice.States.ReadyToCollectedInvoice ))
                {
                    counter++;
                }
            }
            if (counter >= 1)
                return true;
            else
                return false;
        }
        
        /*
        private bool CheckEpisodeProtocolCountOfThisEpisode(Episode ep)
        {
            if (ep.EpisodeProtocols.Count >= 1)
                return true;
            else
                return false;
        }
        */

        private void CancelPayerInvoiceOfThisEpisode(Episode ep)
        {
            ResUser tempUser;
            foreach (EpisodeAction epAction in ep.EpisodeActions)
            {
                if (epAction is PayerInvoice && (epAction.CurrentStateDefID == PayerInvoice.States.ReadyToCollectedInvoice || epAction.CurrentStateDefID == PayerInvoice.States.Invoiced))
                {
                    tempPayerInvoice = (PayerInvoice)epAction;
                    tempUser = ((PayerInvoice)epAction).PayerInvoiceDocument.CashierLog.ResUser;
                    ((PayerInvoice)epAction).PayerInvoiceDocument.CashierLog.ResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                    epAction.Update();
                    epAction.CurrentStateDefID = PayerInvoice.States.Cancelled;
                    ((PayerInvoice)epAction).PayerInvoiceDocument.CashierLog.ResUser = tempUser;
                    tempPayerInvoice.PayerInvoiceDocument.CashierLog.ResUser = tempUser;
                    _IsPayerInvoiceCancelled = true;
                }
            }
        }
        
        
        //Bu metodun PayerInvoiceForm'un prescriptine göre yeniden gözden geçirilmesi gerekiyor.
        /*
        private void RestorePayerInvoiceOfThisEpisode(TTObjectContext objectContext)
        {
            EpisodeProtocol myEpisodeProtocol = tempPayerInvoice.Episode.MyEpisodeProtocol();

            PayerInvoice payerInvoice = new PayerInvoice(objectContext);
            payerInvoice.FromResource = tempPayerInvoice.FromResource;
            payerInvoice.MasterResource = tempPayerInvoice.MasterResource;
            payerInvoice.CurrentStateDefID = PayerInvoice.States.New;
            payerInvoice.Episode = tempPayerInvoice.Episode;
            payerInvoice.Payer = tempPayerInvoice.Payer;
            payerInvoice.Protocol = tempPayerInvoice.Protocol;
            payerInvoice.PISubEpisode = tempPayerInvoice.PISubEpisode;
            payerInvoice.PATIENTSTATUS = tempPayerInvoice.PATIENTSTATUS;

            payerInvoice.CashOfficeName = tempPayerInvoice.CashOfficeName;
            payerInvoice.PROCEDUREGROUP = tempPayerInvoice.PROCEDUREGROUP;
            //payerInvoice.TotalDiscountEntry = tempPayerInvoice.TotalDiscountEntry;
            //payerInvoice.TotalPrice = tempPayerInvoice.TotalPrice;
            //payerInvoice.TotalDiscountPrice = tempPayerInvoice.TotalDiscountPrice;
            //payerInvoice.GeneralTotalPrice = tempPayerInvoice.GeneralTotalPrice;

            payerInvoice.PayerInvoiceDocument = new PayerInvoiceDocument(objectContext);
            payerInvoice.PayerInvoiceDocument.CurrentStateDefID = tempPayerInvoice.PayerInvoiceDocument.CurrentStateDefID;
            payerInvoice.PayerInvoiceDocument.CashierLog = tempPayerInvoice.PayerInvoiceDocument.CashierLog;
            payerInvoice.PayerInvoiceDocument.DocumentDate = tempPayerInvoice.PayerInvoiceDocument.DocumentDate;
            payerInvoice.PayerInvoiceDocument.Payer = tempPayerInvoice.PayerInvoiceDocument.Payer;


            IList myList = InvoiceCashOfficeDefinition.GetByCashOffice(payerInvoice.ObjectContext, payerInvoice.PayerInvoiceDocument.CashierLog.CashOffice.ObjectID.ToString());
            if (myList.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(213, new string[] { payerInvoice.CashOfficeName }));
            else
            {
                InvoiceCashOfficeDefinition _myInvoiceCashOfficeDefinition = (InvoiceCashOfficeDefinition)myList[0];
                payerInvoice.PayerInvoiceDocument.DocumentNo = (string)_myInvoiceCashOfficeDefinition.GetCurrentInvoiceNumber();
            }
            //payerInvoice.PayerInvoiceDocument.TotalDiscountPrice = tempPayerInvoice.PayerInvoiceDocument.TotalDiscountPrice;
            //payerInvoice.PayerInvoiceDocument.TotalPrice = tempPayerInvoice.PayerInvoiceDocument.TotalPrice;

            


            //Gridlerdeki verilerin doldurulmasi
            double totalPrice = 0;
            AccountPayableReceivable myAPR = myEpisodeProtocol.Payer.MyAPR();
            if (myAPR == null)
                throw new TTUtils.TTException(SystemMessage.GetMessage(215));
            else
            {
                // Hızlandırmadan sonraki kısım
                IList procedureTrxList = null;
                IList packageTrxList = null;
                IList materialTrxList = null;

                procedureTrxList = AccountTransaction.GetProcedureTrxsForInvoice(payerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
                packageTrxList = AccountTransaction.GetPackageTrxsForInvoice(payerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);
                materialTrxList = AccountTransaction.GetMaterialTrxsForInvoice(payerInvoice.ObjectContext, AccountTransaction.States.New, myAPR.ObjectID, myEpisodeProtocol.ObjectID);

                // Hizmetler
                foreach (AccountTransaction accTrx in procedureTrxList)
                {
                    PayerInvoiceProcedure invproc = new PayerInvoiceProcedure(payerInvoice.ObjectContext);
                    invproc.ActionDate = accTrx.TransactionDate.Value;
                    invproc.ExternalCode = accTrx.ExternalCode;
                    invproc.Description = accTrx.Description;
                    invproc.Amount = (int)accTrx.Amount;
                    invproc.UnitPrice = accTrx.UnitPrice;
                    invproc.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
                    invproc.Paid = true;
                    invproc.AccountTransaction.Add(accTrx);

                    payerInvoice.PayerInvoiceProcedures.Add(invproc);
                    totalPrice = totalPrice + (double)invproc.TotalPrice;
                }

                // Paketler
                foreach (AccountTransaction accTrx in packageTrxList)
                {
                    PayerInvoicePackage invpack = new PayerInvoicePackage(payerInvoice.ObjectContext);
                    invpack.ActionDate = accTrx.TransactionDate.Value;
                    invpack.PackageCode = accTrx.ExternalCode;
                    invpack.PackageName = accTrx.Description;
                    invpack.Amount = (int)accTrx.Amount;
                    invpack.PackagePrice = accTrx.UnitPrice;
                    invpack.TotalPrice = (double)((int)accTrx.Amount * accTrx.UnitPrice);
                    invpack.Paid = true;
                    invpack.PackageAccountTransaction.Add(accTrx);

                    payerInvoice.PayerInvoicePackages.Add(invpack);
                    totalPrice = totalPrice + (double)invpack.TotalPrice;
                }

                // Malzeme ve İlaçlar
                foreach (AccountTransaction accTrx in materialTrxList)
                {
                    PayerInvoiceMaterial invmat = new PayerInvoiceMaterial(payerInvoice.ObjectContext);
                    invmat.ActionDate = (DateTime)accTrx.TransactionDate;
                    invmat.ExternalCode = accTrx.ExternalCode;
                    invmat.Description = accTrx.Description;
                    invmat.Amount = accTrx.Amount;
                    invmat.UnitPrice = accTrx.UnitPrice;
                    invmat.TotalPrice = (double)(accTrx.Amount * accTrx.UnitPrice);
                    invmat.Paid = true;
                    invmat.AccountTransaction.Add(accTrx);

                    payerInvoice.PayerInvoiceMaterials.Add(invmat);
                    totalPrice = totalPrice + (double)invmat.TotalPrice;
                }

                payerInvoice.TotalPrice = totalPrice;
                payerInvoice.TotalDiscountEntry = 0;
                payerInvoice.TotalDiscountPrice = 0;
                payerInvoice.PayerInvoiceDocument.TotalDiscountPrice = 0;
                payerInvoice.PayerInvoiceDocument.TotalPrice = payerInvoice.TotalPrice;
                payerInvoice.GeneralTotalPrice = payerInvoice.TotalPrice - payerInvoice.TotalDiscountPrice;
                payerInvoice.PayerInvoiceDocument.CurrentStateDefID = PayerInvoiceDocument.States.New;

                payerInvoice.Update();

                if (tempPayerInvoice.CurrentStateDefID == PayerInvoice.States.Invoiced)
                {
                    payerInvoice.CurrentStateDefID = PayerInvoice.States.Invoiced;
                    objectContext.Save();
                }
                else
                {
                    payerInvoice.CurrentStateDefID = PayerInvoice.States.ReadyToCollectedInvoice;
                    if (tempPayerInvoice.CurrentStateDefID == PayerInvoice.States.CollectedInvoiced)
                    {
                        payerInvoice.CurrentStateDefID = PayerInvoice.States.CollectedInvoiced;
                        objectContext.Save();
                    }
                    objectContext.Save();
                }

            }
        }
        */
        /*
        private void OpenEpisodeProtocols(Episode ep)
        {
            foreach (EpisodeProtocol protocol in ep.EpisodeProtocols)
            {
                dictionaryOfEpisodeProtocols.Add(protocol.ObjectID, protocol.CurrentStateDefID);
                protocol.CurrentStateDefID = EpisodeProtocol.States.OPEN;
                _IsEpisodeProtocolsOpened = true;
            }
        }

        private void RestoreEpisodeProtocols(Episode ep)
        {
            foreach(EpisodeProtocol protocol in ep.EpisodeProtocols)
            {
                foreach (KeyValuePair<Guid,Guid?> item in dictionaryOfEpisodeProtocols)
                {
                    if (protocol.ObjectID == item.Key)
                    {
                        protocol.CurrentStateDefID = item.Value;
                    }
                }
            }
            dictionaryOfEpisodeProtocols.Clear();
        }
        */
        
#endregion CompleteBloodProductsForm_Methods
    }
}