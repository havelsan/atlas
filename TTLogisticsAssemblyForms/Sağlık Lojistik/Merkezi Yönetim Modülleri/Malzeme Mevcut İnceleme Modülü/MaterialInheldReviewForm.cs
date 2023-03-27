
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
    /// Malzeme Mevcut İnceleme
    /// </summary>
    public partial class MaterialInheldReviewForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdCreateStability.Click += new TTControlEventDelegate(cmdCreateStability_Click);
            cmdAddStability.Click += new TTControlEventDelegate(cmdAddStability_Click);
            cmdListMaterialStability.Click += new TTControlEventDelegate(cmdListMaterialStability_Click);
            MaterialStabilitListview.DoubleClick += new TTControlEventDelegate(MaterialStabilitListview_DoubleClick);
            ttbuttonLotNuGetir.Click += new TTControlEventDelegate(ttbuttonLotNuGetir_Click);
            cmdGetInheld.Click += new TTControlEventDelegate(cmdGetInheld_Click);
            SiteListview.DoubleClick += new TTControlEventDelegate(SiteListview_DoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdCreateStability.Click -= new TTControlEventDelegate(cmdCreateStability_Click);
            cmdAddStability.Click -= new TTControlEventDelegate(cmdAddStability_Click);
            cmdListMaterialStability.Click -= new TTControlEventDelegate(cmdListMaterialStability_Click);
            MaterialStabilitListview.DoubleClick -= new TTControlEventDelegate(MaterialStabilitListview_DoubleClick);
            ttbuttonLotNuGetir.Click -= new TTControlEventDelegate(ttbuttonLotNuGetir_Click);
            cmdGetInheld.Click -= new TTControlEventDelegate(cmdGetInheld_Click);
            SiteListview.DoubleClick -= new TTControlEventDelegate(SiteListview_DoubleClick);
            base.UnBindControlEvents();
        }

        private void cmdCreateStability_Click()
        {
#region MaterialInheldReviewForm_cmdCreateStability_Click
   bool create = false;
            if(this.StabilityGrid.Rows.Count > 0)
            {
                for (int i = 0; i < this.StabilityGrid.Rows.Count; i++)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    
                    MaterialStabilityAction materialStabilityAction = new MaterialStabilityAction(context);
                    
                    Material material = this.MaterialListBox.SelectedObject as Material ;
                    Accountancy receiveAccountancy = (Accountancy)context.GetObject(new Guid(this.StabilityGrid.Rows[i].Cells["ReceivAccountancy"].Value.ToString()),typeof (Accountancy));
                    Accountancy sendingAccountancy = (Accountancy)context.GetObject(new Guid(this.StabilityGrid.Rows[i].Cells["SendingAccountancy"].Value.ToString()),typeof (Accountancy));
                    Sites toSite =(Sites)context.GetObject(new Guid(this.StabilityGrid.Rows[i].Cells["Site"].Value.ToString()),typeof (Sites));
                    Sites fromSite = (Sites)context.GetObject(Sites.SiteMerkezSagKom, typeof(Sites));
                    
                    materialStabilityAction.Material = material;
                    materialStabilityAction.ReceiveAccountancy = receiveAccountancy;
                    materialStabilityAction.SendingAccountancy = sendingAccountancy;
                    string retAmount = this.StabilityGrid.Rows[i].Cells["StabilityAmount"].Value.ToString();
                    Currency? amount = 0;
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));

                    materialStabilityAction.Amount = amount;
                    materialStabilityAction.FromSite = fromSite;
                    materialStabilityAction.ToSite = toSite;
                    materialStabilityAction.MainStoreID = new Guid(this.StabilityGrid.Rows[i].Cells["MainStoreID"].Value.ToString());
                    materialStabilityAction.Description = this.txtDescription.Text;
                    materialStabilityAction.WorkListDescription = material.StockCard.NATOStockNO.ToString() + " " + material.Name;
                    materialStabilityAction.CurrentStateDefID = MaterialStabilityAction.States.Request;
                    context.Update();
                    materialStabilityAction.CurrentStateDefID = MaterialStabilityAction.States.RequestStability;
                    context.Save();
                    context.Dispose();
                    create = true;
                }
            }
            else
                InfoBox.Show("Hiç muvazene seçilmemiş.",MessageIconEnum.ErrorMessage);
            
            if(create)
                InfoBox.Show("Muvazene oluşturulmuştur.",MessageIconEnum.InformationMessage);
#endregion MaterialInheldReviewForm_cmdCreateStability_Click
        }

        private void cmdAddStability_Click()
        {
#region MaterialInheldReviewForm_cmdAddStability_Click
   //TTObjectContext context = new TTObjectContext(true);
            if (SiteListview.SelectedItems.Count == 0)
                throw new TTException("Herhangi bir saha seçmediniz!");

            ITTListViewItem listViewItem = SiteListview.SelectedItems[0];
            
            string retAmount = InputForm.GetText("Çıkış Yapılacak Miktarı Giriniz.");
            Currency? amount = 0;
            if (string.IsNullOrEmpty(retAmount) == false)
            {
                if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                    throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                
                //Sites site = context.GetObject(new Guid(listViewItem.SubItems[3].Text),typeof(Sites));
                //Guid mainStoreID = new Guid(listViewItem.SubItems[4].Text);
                //Accountancy sAccountancy = context.GetObject(new Guid(listViewItem.SubItems[5].Text),typeof(Accountancy));
                //Accountancy rAccountancy = (Accountancy)this.AccountancyListBox.SelectedObject;
                
                ITTGridRow row = this.StabilityGrid.Rows.Add();
                row.Cells["SendingAccountancy"].Value = new Guid(listViewItem.SubItems[7].Text);
                row.Cells["ReceivAccountancy"].Value = this.AccountancyListBox.SelectedObjectID;
                row.Cells["StabilityAmount"].Value = amount;
                row.Cells["Site"].Value = new Guid(listViewItem.SubItems[5].Text);
                row.Cells["MainStoreID"].Value = new Guid(listViewItem.SubItems[6].Text);
            }
#endregion MaterialInheldReviewForm_cmdAddStability_Click
        }

        private void cmdListMaterialStability_Click()
        {
#region MaterialInheldReviewForm_cmdListMaterialStability_Click
   MaterialStabilitListview.Items.Clear();
            if (this.MaterialListBox.SelectedObject != null)
            {
                DateTime startDate = this.startDate.NullableValue.Value;
                DateTime endDate = this.endDate.NullableValue.Value;
                BindingList<MaterialStabilityAction.GetMaterialStabilityAction_Class> actions = MaterialStabilityAction.GetMaterialStabilityAction(endDate, startDate, (Guid)this.MaterialListBox.SelectedObjectID);
                foreach (MaterialStabilityAction.GetMaterialStabilityAction_Class action in actions)
                {
                    TTObjectContext readOnlyContext = new TTObjectContext(true);
                    MaterialStabilityAction materialStabilityAction = (MaterialStabilityAction)readOnlyContext.GetObject((Guid)action.ObjectID, typeof(MaterialStabilityAction));
                    ITTListViewItem listViewItem = MaterialStabilitListview.Items.Add(materialStabilityAction.ToSite.Name);
                    listViewItem.Tag = materialStabilityAction;
                    listViewItem.SubItems.Add(materialStabilityAction.CurrentStateDef.Description);
                    readOnlyContext.Dispose();
                }
            }
            else
                InfoBox.Show("Malzeme seçmelisiniz", MessageIconEnum.ErrorMessage);
#endregion MaterialInheldReviewForm_cmdListMaterialStability_Click
        }

        private void MaterialStabilitListview_DoubleClick()
        {
#region MaterialInheldReviewForm_MaterialStabilitListview_DoubleClick
   if (MaterialStabilitListview.SelectedItems.Count > 0)
            {
                ITTListViewItem listViewItem = MaterialStabilitListview.SelectedItems[0];
                TTObjectContext context = new TTObjectContext(true);
                MaterialStabilityAction materialStabilityAction = (MaterialStabilityAction)context.GetObject(((MaterialStabilityAction)listViewItem.Tag).ObjectID, typeof(MaterialStabilityAction));
                if (materialStabilityAction != null)
                {
                    TTForm frm = TTForm.GetEditForm(materialStabilityAction);
                    frm.ShowReadOnly(this, materialStabilityAction);
                }
                context.Dispose();
            }
#endregion MaterialInheldReviewForm_MaterialStabilitListview_DoubleClick
        }

        private void ttbuttonLotNuGetir_Click()
        {
#region MaterialInheldReviewForm_ttbuttonLotNuGetir_Click
   this.MaterialLotListView.Items.Clear();
            if (this.MaterialListBox.SelectedObject != null)
            {
                if(this.ttLotNuTextBox.Text != string.Empty)
                {
                    foreach (KeyValuePair<Guid, Sites> targetSite in Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST)
                    {
                        //List<RemotingInfoClass.MaterialInheldInfo> materialInheldInfos = Stock.RemoteMethods.GetMaterialInheldWithLotNo (targetSite.Key , this.MaterialListBox.SelectedObjectID.ToString(),ttLotNuTextBox.Text);
                        //if (materialInheldInfos != null && materialInheldInfos.Count > 0)
                        //{
                        //    foreach (RemotingInfoClass.MaterialInheldInfo materialInheldInfo in materialInheldInfos)
                        //    {
                        //        ITTListViewItem listViewItem = MaterialLotListView.Items.Add(materialInheldInfo.accountancy.Name);
                        //        listViewItem.Tag = materialInheldInfo;
                        //        listViewItem.SubItems.Add(materialInheldInfo.inheld.ToString());
                        //        listViewItem.SubItems.Add(materialInheldInfo.lotNo);
                        //        listViewItem.SubItems.Add(materialInheldInfo.mainStoreObjectID.ToString());
                        //    }
                        //}
                    }
                }
                else
                    InfoBox.Show("Lot numarası girmediniz",MessageIconEnum.ErrorMessage);
            }
            else
                InfoBox.Show("Malzeme seçmelisiniz",MessageIconEnum.ErrorMessage);
#endregion MaterialInheldReviewForm_ttbuttonLotNuGetir_Click
        }

        private void cmdGetInheld_Click()
        {
#region MaterialInheldReviewForm_cmdGetInheld_Click
   SiteListview.Items.Clear();
            if (this.MaterialListBox.SelectedObject != null)
            {
                foreach (KeyValuePair<Guid, Sites> targetSite in Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                        (backgroundWorker_RunWorkerCompleted);
                    Application.DoEvents();
                    bw.RunWorkerAsync(new KeyValuePair<Guid, String>(targetSite.Key, this.MaterialListBox.SelectedObjectID.ToString()));
                    
                    
                    //this.RunMaterialInheld(targetSite.Value);
                    //                    List<RemotingInfoClass.MaterialInheldInfo> materialInheldInfos = Stock.RemoteMethods.GetMaterialInheld (targetSite.Key , this.MaterialListBox.SelectedObjectID.ToString());
                    //                    if (materialInheldInfos != null && materialInheldInfos.Count > 0)
                    //                    {
                    //                        foreach (RemotingInfoClass.MaterialInheldInfo materialInheldInfo in materialInheldInfos)
                    //                        {
                    //                            ITTListViewItem listViewItem = SiteListview.Items.Add(materialInheldInfo.accountancy.Name);
                    //                            listViewItem.Tag = materialInheldInfo;
                    //                            listViewItem.SubItems.Add(materialInheldInfo.inheld.ToString());
                    //                            listViewItem.SubItems.Add(materialInheldInfo.consigned.ToString());
                    //                            listViewItem.SubItems.Add(materialInheldInfo.maxLevel.ToString());
                    //                            listViewItem.SubItems.Add(materialInheldInfo.minLevel.ToString());
                    //                            listViewItem.SubItems.Add(targetSite.Key.ToString());
                    //                            listViewItem.SubItems.Add(materialInheldInfo.mainStoreObjectID.ToString());
                    //                            listViewItem.SubItems.Add(materialInheldInfo.accountancy.ObjectID.ToString());
                    //                        }
                    //                    }
                }
            }
            else
            {
                InfoBox.Show("Malzeme seçmelisiniz.",MessageIconEnum.ErrorMessage);
            }
#endregion MaterialInheldReviewForm_cmdGetInheld_Click
        }

        private void SiteListview_DoubleClick()
        {
#region MaterialInheldReviewForm_SiteListview_DoubleClick
   if (this.MaterialListBox.SelectedObject != null)
            {
                if (SiteListview.SelectedItems.Count > 0)
                {
                    ITTListViewItem listViewItem = SiteListview.SelectedItems[0];
                    Guid siteID = new Guid(listViewItem.SubItems[5].Text);
                    Guid mainStoreID = new Guid(listViewItem.SubItems[6].Text);
                    //RemotingInfoClass.MaterialInheldDetailInfo materialInheldDetailInfo = Stock.RemoteMethods.GetMetarialInheldDetails(siteID, this.MaterialListBox.SelectedObjectID.ToString(), mainStoreID.ToString());
                    //this.OutableGrid.Rows.Clear();
                    //if (materialInheldDetailInfo != null)
                    //{
                    //    this.txtInheld.Text = materialInheldDetailInfo.inheld.ToString();
                    //    this.txtConsigned.Text = materialInheldDetailInfo.consigned.ToString();
                    //    this.txtMaxLevel.Text = materialInheldDetailInfo.maxLevel.ToString();
                    //    this.txtMinLevel.Text = materialInheldDetailInfo.minLevel.ToString();
                    //    this.txtTotalIn.Text = materialInheldDetailInfo.totalIn.ToString();
                    //    this.txtTotalOut.Text = materialInheldDetailInfo.totalOut.ToString();
                    //    this.txtCensusTotalIn.Text = materialInheldDetailInfo.censusTotalIn.ToString();
                    //    this.txtCensusTotalOut.Text = materialInheldDetailInfo.censusTotalOut.ToString();
                    //    this.txtCensusYearCensus.Text = materialInheldDetailInfo.censusYearCensus.ToString();
                    //    this.txtCensusTotalInheld.Text = materialInheldDetailInfo.censusTotalInheld.ToString();
                    //    this.txtReservationAmount.Text = materialInheldDetailInfo.reservationAmount.ToString();
                    //    this.lblTerm.Text = materialInheldDetailInfo.censusDescription;

                    //    foreach (RemotingInfoClass.MaterialOutableDetailInfo outable in materialInheldDetailInfo.materialOutableDetailInfos)
                    //    {
                    //        ITTGridRow row = this.OutableGrid.Rows.Add();
                    //        row.Cells["LotNo"].Value = outable.lotNo;
                    //        row.Cells["ExpirationDate"].Value = outable.expirationDate;
                    //        row.Cells["Amount"].Value = outable.restAmount;
                    //    }
                    //}
                }
                else
                {
                    InfoBox.Show("Bir saha seçmelisiniz.", MessageIconEnum.ErrorMessage);
                }
            }
            else
            {
                InfoBox.Show("Malzeme seçmediniz.", MessageIconEnum.ErrorMessage);
            }
#endregion MaterialInheldReviewForm_SiteListview_DoubleClick
        }

#region MaterialInheldReviewForm_Methods
        public static void OpenMaterialInheldReviewForm()
        {
            MaterialInheldReviewForm materialInheldReviewForm = new MaterialInheldReviewForm();
            InfoBox.Show(" materialInheldReviewForm.ShowDialog();");
            //materialInheldReviewForm.ShowDialog(parentForm);
            materialInheldReviewForm.CenterToScreen();
        }
        
        protected override void OnLoad(EventArgs e)
        {
            Sites ownSite = TTObjectClasses.SystemParameter.GetSite();
            if (ownSite.ObjectID.Equals(Sites.SiteMerkezSagKom) == false)
            {
                InfoBox.Show("Bu ekran sadece Sağlık XXXXXX tarafından kullanılabilir.",MessageIconEnum.ErrorMessage);
                this.Close();
            }
            this.CenterToParent();
            TTDateTimePicker startDate = ((TTDateTimePicker)this.startDate);
            startDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + "00:00:00");
            TTDateTimePicker endDate = ((TTDateTimePicker)this.endDate);
            endDate.Value = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + "23:59:59");
        }
        
        //        public static void RunMaterialInheldThead(object site)
        //        {
        //            Guid sendSiteObjectID = (Guid)site ;
        //            MaterialInheldReviewForm.RunMaterialInheld(sendSiteObjectID);
        //        }

        private object _lockListView = new object();
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            KeyValuePair<Guid, String> param = (KeyValuePair<Guid, String>)e.Argument;
            try
            {
                //List<RemotingInfoClass.MaterialInheldInfo> materialInheldInfos = Stock.RemoteMethods.GetMaterialInheld(param.Key, param.Value);
                //e.Result = new KeyValuePair<Guid,List<RemotingInfoClass.MaterialInheldInfo>>(param.Key, materialInheldInfos);
            }
            catch
            {
                e.Result = new KeyValuePair<Guid,List<RemotingInfoClass.MaterialInheldInfo>>(param.Key, null);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            KeyValuePair<Guid,List<RemotingInfoClass.MaterialInheldInfo>> result = (KeyValuePair<Guid,List<RemotingInfoClass.MaterialInheldInfo>>)e.Result;
            List<RemotingInfoClass.MaterialInheldInfo> materialInheldInfos = result.Value;
            if (materialInheldInfos == null)
            {
                TTObjectContext contex = new TTObjectContext(true);
                Sites s = (Sites)contex.GetObject(result.Key, typeof(Sites));
                ITTListViewItem listViewItem = SiteListview.Items.Add(s.Description +" sahasına ulaşılmıyor");
            }
            else if (materialInheldInfos.Count > 0)
            {
                lock(_lockListView)
                {
                    foreach (RemotingInfoClass.MaterialInheldInfo materialInheldInfo in materialInheldInfos)
                    {
                        ITTListViewItem listViewItem = SiteListview.Items.Add(materialInheldInfo.accountancy.Name);
                        listViewItem.Tag = materialInheldInfo;
                        listViewItem.SubItems.Add(materialInheldInfo.inheld.ToString());
                        listViewItem.SubItems.Add(materialInheldInfo.consigned.ToString());
                        listViewItem.SubItems.Add(materialInheldInfo.maxLevel.ToString());
                        listViewItem.SubItems.Add(materialInheldInfo.minLevel.ToString());
                        listViewItem.SubItems.Add(result.Key.ToString());
                        listViewItem.SubItems.Add(materialInheldInfo.mainStoreObjectID.ToString());
                        listViewItem.SubItems.Add(materialInheldInfo.accountancy.ObjectID.ToString());
                    }
                }
            }
        }
        
#endregion MaterialInheldReviewForm_Methods
    }
}