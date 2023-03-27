
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Muhasebe Yetkilisi Mutemedi Alındısı İade işlemi
    /// </summary>
    public partial class ReceiptBack : EpisodeAccountAction, IWorkListEpisodeAction
    {
        public partial class ReceiptBackReportQuery_Class : TTReportNqlObject
        {
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            if (memberName != "SUBEPISODE")
                switch (memberName)
                {
                    case "RECEIPTBACKDOCUMENT":
                        {
                            ReceiptBackDocument value = (ReceiptBackDocument)newValue;
                            #region RECEIPTBACKDOCUMENT_SetParentScript
                            if (value != null)
                                value.EpisodeAccountAction = this;
                            #endregion RECEIPTBACKDOCUMENT_SetParentScript
                        }
                        break;

                    default:
                        base.RunSetMemberValueScript(memberName, newValue);
                        break;

                }
        }

        protected void PostTransition_ReturnBack2Cancelled()
        {
            // From State : ReturnBack   To State : Cancelled
            #region PostTransition_ReturnBack2Cancelled
            Cancel();
            #endregion PostTransition_ReturnBack2Cancelled
        }

        protected void UndoTransition_ReturnBack2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ReturnBack   To State : Cancelled
            #region UndoTransition_ReturnBack2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_ReturnBack2Cancelled
        }

        protected void PostTransition_New2ReturnBack()
        {
            // From State : New   To State : ReturnBack
            #region PostTransition_New2ReturnBack


            if (ReceiptBackDetails.Count >= 0 && ReceiptBackDetails.Count(x => x.Return == true) <= 0)
                throw new TTException(TTUtils.CultureService.GetText("M25994", "İade edilecek hizmet seçilmedi!"));

            if (ReturnTotalPrice == 0)
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(177));
            }
            else
            {
                ReceiptBackDocumentGroup rdg = new ReceiptBackDocumentGroup(ObjectContext);
                rdg.GroupCode = "I";
                rdg.GroupDescription = TTUtils.CultureService.GetText("M25996", "İade Kalemler");
                rdg.AccountDocument = ReceiptBackDocument;

                string message;
                foreach (ReceiptBackDetail receiptBackDet in ReceiptBackDetails)
                {
                    if (receiptBackDet.Return == true)
                    {
                        if (receiptBackDet.ReceiptDocumentDetail.CurrentStateDefID == ReceiptDocumentDetail.States.ReturnBack)
                            throw new TTException(TTUtils.CultureService.GetText("M25995", "İade edilmiş makbuz tekrar iade edilemez!"));

                        if (receiptBackDet.AccountTransaction[0].SubActionProcedure != null)
                        {
                            if (receiptBackDet.AccountTransaction[0].SubActionProcedure.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                                throw new TTException(TTUtils.CultureService.GetText("M27029", "Tamamlandı durumundaki hizmet iade edilemez!"));
                        }
                        else if (receiptBackDet.AccountTransaction[0].SubActionMaterial != null)
                        {
                            if (receiptBackDet.AccountTransaction[0].SubActionMaterial.CurrentStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                                throw new TTException(TTUtils.CultureService.GetText("M27030", "Tamamlandı durumundaki malzeme iade edilemez!"));
                        }

                        // Kan bankası için eklenen kısım.
                        if (receiptBackDet.AccountTransaction[0].SubActionProcedure != null)
                        {
                            SubActionProcedure sp = receiptBackDet.AccountTransaction[0].SubActionProcedure;

                            if (sp is BloodBankBloodProducts && !(sp is BloodBankSubProduct))
                            {
                                message = "";
                                foreach (ReceiptBackDetail childReceiptBackDet in ReceiptBackDetails)
                                {
                                    if (childReceiptBackDet.Return == false && childReceiptBackDet.AccountTransaction[0].SubActionProcedure != null)
                                    {
                                        if (childReceiptBackDet.AccountTransaction[0].SubActionProcedure.MasterSubActionProcedure == sp)
                                        {
                                            BloodBankTestDefinition testDef = childReceiptBackDet.AccountTransaction[0].SubActionProcedure.ProcedureObject as BloodBankTestDefinition;
                                            if (testDef != null)
                                            {
                                                if (testDef.OnlyChargeWithProduct == true)
                                                    message = message + childReceiptBackDet.ExternalCode + " " + childReceiptBackDet.AccountTransaction[0].Description + " , ";
                                            }
                                        }

                                    }
                                }
                                if (message != "")
                                {
                                    message = message.Substring(0, (message.Length - 3));
                                    message = "(İşlemler : " + message + ")";
                                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(178, new string[] { message }));
                                }
                            }
                            else if (sp is BloodBankSubProduct)
                            {
                                BloodBankTestDefinition testDef = sp.ProcedureObject as BloodBankTestDefinition;
                                if (testDef != null)
                                {
                                    if (testDef.OnlyChargeWithProduct == true)
                                    {
                                        foreach (ReceiptBackDetail masterReceiptBackDet in ReceiptBackDetails)
                                        {
                                            if (masterReceiptBackDet.Return == false && masterReceiptBackDet.AccountTransaction[0].SubActionProcedure != null)
                                            {
                                                if (sp.MasterSubActionProcedure == masterReceiptBackDet.AccountTransaction[0].SubActionProcedure)
                                                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(179, new string[] { "(İşlem : " + receiptBackDet.ExternalCode + " " + receiptBackDet.AccountTransaction[0].Description + " ----- Kan ürünü : " + masterReceiptBackDet.ExternalCode + " " + masterReceiptBackDet.AccountTransaction[0].Description + ")" }));
                                            }
                                        }
                                    }
                                    else
                                        throw new TTUtils.TTException(SystemMessage.GetMessageV3(180, new string[] { "(İşlem : " + receiptBackDet.ExternalCode + " " + receiptBackDet.AccountTransaction[0].Description + ")" }));
                                }
                            }
                        }
                        //

                        ReceiptBackDocumentDetail rdd = new ReceiptBackDocumentDetail(ObjectContext);
                        AccountTrxDocument accTrxDoc = new AccountTrxDocument(ObjectContext);

                        rdd.ExternalCode = receiptBackDet.ExternalCode;
                        rdd.Description = receiptBackDet.Description;
                        rdd.Amount = receiptBackDet.Amount;
                        rdd.UnitPrice = receiptBackDet.UnitPrice;
                        rdd.TotalDiscountedPrice = receiptBackDet.PaymentPrice;
                        rdd.CurrentStateDefID = ReceiptBackDocumentDetail.States.Paid;

                        accTrxDoc.AccountDocumentDetail = rdd;
                        accTrxDoc.AccountTransaction = receiptBackDet.AccountTransaction[0];
                        accTrxDoc.AccountTransaction.CurrentStateDefID = AccountTransaction.States.New;

                        if (accTrxDoc.AccountTransaction.SubActionProcedure is LaboratoryProcedure && accTrxDoc.AccountTransaction.SubActionProcedure.CurrentStateDefID == LaboratoryProcedure.States.PendingCancel)
                        {
                            ((ITTObject)(accTrxDoc.AccountTransaction.SubActionProcedure)).Cancel();
                        }

                        rdd.ReceiptDocumentDetail = receiptBackDet.ReceiptDocumentDetail;
                        rdd.ReceiptDocumentDetail.CurrentStateDefID = ReceiptDocumentDetail.States.ReturnBack;
                        //receiptBackDet.ReceiptDocumentDetail.CurrentStateDefID = ReceiptDocumentDetail.States.ReturnBack;

                        rdg.ReceiptBackDocumentDetails.Add(rdd);
                    }
                    ReceiptBackDocument.DocumentNo = Receipt.ReceiptDocument.DocumentNo;
                    ReceiptBackDocument.TotalPrice = ReturnTotalPrice;
                    ReceiptBackDocument.EpisodeAccountAction.TotalPrice = ReturnTotalPrice;
                    PatientPaymentDetail ppDetail = ReceiptDocument.GetPatientPaymentDetail(receiptBackDet.AccountTransaction[0].ObjectID, Receipt.ReceiptDocument);
                    ppDetail.IsBack = true;
                }

                APRTrx aprTrx = new APRTrx(ObjectContext);
                aprTrx.AccountDocument = ReceiptBackDocument;
                aprTrx.Price = -1 * ReceiptBackDocument.TotalPrice;
                aprTrx.AccountPayableReceivable = Episode.Patient.MyAPR();
                aprTrx.AccountPayableReceivable.UpdateBalance((decimal)aprTrx.Price);
                ReceiptBackDocument.APRTrx.Add(aprTrx);
                ReceiptBackDocument.CurrentStateDefID = ReceiptBackDocument.States.Paid;
                ReceiptBackDocument.SendToAccounting = false;

                DoBackForAccountVoucher();

                // Muhasebe Yetkilisi Mutemedi Alındısı İade işlemi vezneden yapılıyorsa hemen muhasebeleştiriliyor,
                // muhasebe yetkilisi mutemedi tarafından yapılıyorsa hemen muhasebeleşmeyecek.
                /*if (TTObjectClasses.SystemParameter.GetParameterValue("ACCOUNTENTEGRATION", "FALSE") == "TRUE")
                {
                    if(this.ReceiptBackDocument.CashierLog.CashOffice.Type == CashOfficeTypeEnum.MainCashOffice)
                    {
                        IList<AccountDocument.ReceiptInfo> ReceiptList = new List<AccountDocument.ReceiptInfo>();
                        AccountDocument.ReceiptInfo RI;
                        RI = this.ReceiptBackDocument.CreateReceiptInfoForAccounting();
                        RI.Description = "Hasta: " + this.Episode.Patient.ID.ToString() + " " + this.Episode.Patient.FullName.ToString() + " / H.Protokol No: " + this.Episode.HospitalProtocolNo + " / " + this.ReasonOfReturn;
                        
                        if (RI != null)
                        {
                            ReceiptList.Add(RI);
                            this.ReceiptBackDocument.SendToAccounting = true;
                        }
                        
                        if (ReceiptList.Count > 0)
                        {
                            TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "Invoice.Integration", "InvoiceUtils", "CreateReceipt", null, ReceiptList);
                        }
                    }
                }*/
            }
            #endregion PostTransition_New2ReturnBack
        }

        protected void UndoTransition_New2ReturnBack(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : ReturnBack
            #region UndoTransition_New2ReturnBack
            NoBackStateBack();
            #endregion UndoTransition_New2ReturnBack
        }

        #region Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.EpisodeAccountAction;
            }
        }

        public override void Cancel()
        {
            base.Cancel();

            //ResUser _myResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;

            //CashierLog _myCashierLog = null;
            //if (_myResUser != null)
            //    _myCashierLog = (CashierLog)_myResUser.GetOpenCashCashierLog();

            //if (_myCashierLog == null)
            //    throw new TTUtils.TTException(SystemMessage.GetMessage(174));
            //else
            //{
            //    this.ReceiptBackDocument.Cancel();
            //}
            ResUser currentResUser = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
            if (ReceiptBackDocument.ResUser.ObjectID == currentResUser.ObjectID)
                ReceiptBackDocument.Cancel();
            else
                throw new TTException(TTUtils.CultureService.GetText("M27257", "Yetkisiz işlem!"));

            UndoBackForAccountVoucher();
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReceiptBack).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReceiptBack.States.New && toState == ReceiptBack.States.ReturnBack)
                PostTransition_New2ReturnBack();
            else if (fromState == ReceiptBack.States.ReturnBack && toState == ReceiptBack.States.Cancelled)
                PostTransition_ReturnBack2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ReceiptBack).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ReceiptBack.States.ReturnBack && toState == ReceiptBack.States.Cancelled)
                UndoTransition_ReturnBack2Cancelled(transDef);
            else if (fromState == ReceiptBack.States.New && toState == ReceiptBack.States.ReturnBack)
                UndoTransition_New2ReturnBack(transDef);
        }

        //protected override void OnBeforeImportFromObject(DataRow dataRow)
        //{
        //    base.OnBeforeImportFromObject(dataRow);
        //    dataRow["RECEIPTBACKDOCUMENT"] = DBNull.Value;
        //    dataRow["RECEIPT"] = DBNull.Value;
        //}

        public void PrepareNewReceiptBack(/*string computerName*/)
        {
            if (CurrentStateDefID == ReceiptBack.States.New)
            {
                ResUser resUser = TTUser.CurrentUser.UserObject as ResUser;
                //resUser.ClientComputerName = computerName;
                CashOfficeDefinition selectedCashOffice = ResUser.SelectCurrentUserCashOffice(CashOfficeTypeEnum.CashOffice, resUser);

                if (selectedCashOffice == null)
                    throw new TTException(TTUtils.CultureService.GetText("M25325", "Bu kullanıcı için tanımlı bir vezne yok ya da Makbuz kesmeye yetikiniz bulunmamaktadır!!"));

                CashOfficeName = selectedCashOffice.Name;
                if (ReceiptBackDocument == null)
                {
                    ReceiptBackDocument = new ReceiptBackDocument(ObjectContext);
                    ReceiptBackDocument.CashOffice = selectedCashOffice;
                    CashOfficeName = selectedCashOffice.Name;
                    ReceiptBackDocument.DocumentDate = DateTime.Now.Date;
                    ReceiptBackDocument.CurrentStateDefID = ReceiptBackDocument.States.New;
                    ReceiptBackDocument.ResUser = resUser;
                }
            }
        }

        public void DoBackForAccountVoucher()
        {
            foreach (ReceiptBackDocumentGroup receiptBackGroup in ReceiptBackDocument.ReceiptBackDocumentGroups)
            {
                foreach (ReceiptBackDocumentDetail receiptBackDetail in receiptBackGroup.ReceiptBackDocumentDetails)
                {
                    foreach (AccountVoucherDetail avDetail in receiptBackDetail.ReceiptDocumentDetail.AccountVoucherDetails)
                        avDetail.Back();
                }
            }
        }

        public void UndoBackForAccountVoucher()
        {
            foreach (ReceiptBackDocumentGroup receiptBackGroup in ReceiptBackDocument.ReceiptBackDocumentGroups)
            {
                foreach (ReceiptBackDocumentDetail receiptBackDetail in receiptBackGroup.ReceiptBackDocumentDetails)
                {
                    foreach (AccountVoucherDetail avDetail in receiptBackDetail.ReceiptDocumentDetail.AccountVoucherDetails)
                        avDetail.UndoBack();
                }
            }
        }
    }
}