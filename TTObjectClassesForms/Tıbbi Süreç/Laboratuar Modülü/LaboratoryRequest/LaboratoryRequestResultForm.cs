
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
    /// Laboratuvar Sonuç Formu
    /// </summary>
    public partial class LaboratoryRequestResultForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            ttPrintResultReport.Click += new TTControlEventDelegate(ttPrintResultReport_Click);
            GridLabProcedures.CellContentClick += new TTGridCellEventDelegate(GridLabProcedures_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttPrintResultReport.Click -= new TTControlEventDelegate(ttPrintResultReport_Click);
            GridLabProcedures.CellContentClick -= new TTGridCellEventDelegate(GridLabProcedures_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ttPrintResultReport_Click()
        {
#region LaboratoryRequestResultForm_ttPrintResultReport_Click
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            
            TTReportTool.PropertyCache<object> cache1 = new TTReportTool.PropertyCache<object>();
            cache1.Add("VALUE", this._LaboratoryRequest.ObjectID.ToString());
            parameters.Add("TTOBJECTID",cache1);
            
            if(this._LaboratoryRequest.BarcodeID.HasValue)
            {
                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", this._LaboratoryRequest.BarcodeID.Value.ToString());
                parameters.Add("BARCODEID", cache);
            }
           
            
            try
            {
                //TODO:Cursor!
                //this.Cursor = Cursors.WaitCursor;
                
                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_LaboratoryBarcodeResultReport), true, 1, parameters);
                
            }
            catch(Exception ex)
            {
                //TODO:Cursor!
                //this.Cursor = Cursors.Default;
                InfoBox.Show(ex.ToString(),MessageIconEnum.ErrorMessage);
            }
            finally
            {
                //TODO:Cursor!
                //this.Cursor = Cursors.Default;
            }
#endregion LaboratoryRequestResultForm_ttPrintResultReport_Click
        }

        private void GridLabProcedures_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region LaboratoryRequestResultForm_GridLabProcedures_CellContentClick
            //TODO:ShowEdit!
            //if (GridLabProcedures.CurrentCell != null)
            //{
            //    switch (GridLabProcedures.CurrentCell.OwningColumn.Name)
            //    {
            //        case "Detail":
            //            LaboratoryProcedure procedure = (LaboratoryProcedure)GridLabProcedures.CurrentCell.OwningRow.TTObject;
            //            LaboratoryProcedureDetailForm detailForm = new LaboratoryProcedureDetailForm();
            //            detailForm.ShowEdit(this.FindForm(), procedure, true);
            //            break;
            //        default:
            //            break;
            //    }
            //}
            var a = 1;
            #endregion LaboratoryRequestResultForm_GridLabProcedures_CellContentClick
        }

        protected override void PreScript()
        {
#region LaboratoryRequestResultForm_PreScript
    base.PreScript();
            
            if(this._LaboratoryRequest.BarcodeID != null)
            {
                this.labelBarcode.Visible = true;
                this.textBarcode.Visible = true;
                this.textBarcode.Text = this._LaboratoryRequest.BarcodeID.ToString();
            }
            
            //            if(this._EpisodeAction.CurrentStateDefID == LaboratoryRequest.States.Completed && !(TTUser.CurrentUser.IsSuperUser || TTUser.CurrentUser.IsPowerUser))
            //            {
            //                bool hcFound  = false;
            //                foreach (TTUserRole role in TTUser.CurrentUser.Roles)
            //                {
            //                    if (role.Name == "Sağlık Kurulu Başkanı" || role.Name == "Sağlık Kurulu Yazıcısı")
            //                    {
            //                        foreach(EpisodeAction ea in this._LaboratoryRequest.Episode.EpisodeActions)
            //                        {
            //                            if(ea is HealthCommittee)
            //                            {
            //                                hcFound = true;
            //                                break;
            //                            }
            //                        }
            //                        if(!hcFound)
            //                            throw new Exception("Sağlık Kurulu işlemi olmayan bir vakada \"Laboratuvar Sonuç Formu\"na erişim yetkiniz bulunmamaktadır.");
            //                        break;
            //                    }
            //                }
            //            }

            TabForInformations.HideTabPage(TabPageFutureRequest);
#endregion LaboratoryRequestResultForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region LaboratoryRequestResultForm_ClientSidePreScript
    base.ClientSidePreScript();
                  this.FillLabResults();
#endregion LaboratoryRequestResultForm_ClientSidePreScript

        }

#region LaboratoryRequestResultForm_ClientSideMethods
        private TTListView GenerateLabRequestedTab(string tabName)
        {
            TTTabPage tabPage = new TTTabPage();
            tabPage.Name = tabName;
            tabPage.Text = tabName;
            //tabPage.Tag = tabDef;
            TTListView listView = new TTListView();

            TTListViewColumn listViewColumnDetail = new TTListViewColumn();
            listViewColumnDetail.Text = "Rapor";
            listViewColumnDetail.Width = 50;
            listView.Columns.Add(listViewColumnDetail);

            TTListViewColumn listViewColumn1 = new TTListViewColumn();
            listViewColumn1.Text = "Adı";
            listViewColumn1.Width = 200;
            listView.Columns.Add(listViewColumn1);

            TTListViewColumn listViewColumn = new TTListViewColumn();
            listViewColumn.Text = "*";
            listViewColumn.Width = 20;
            listView.Columns.Add(listViewColumn);

            TTListViewColumn listViewColumn2 = new TTListViewColumn();
            listViewColumn2.Text = "Sonuç";
            listViewColumn2.Width = 100;
            listView.Columns.Add(listViewColumn2);

            TTListViewColumn listViewColumn3 = new TTListViewColumn();
            listViewColumn3.Text = "Sapma";
            listViewColumn3.Width = 80;
            listView.Columns.Add(listViewColumn3);

            TTListViewColumn listViewColumn4 = new TTListViewColumn();
            listViewColumn4.Text = "Referans";
            listViewColumn4.Width = 100;
            listView.Columns.Add(listViewColumn4);

            TTListViewColumn listViewColumn5 = new TTListViewColumn();
            listViewColumn5.Text = "Özel Değerler";
            listViewColumn5.Width = 80;
            listView.Columns.Add(listViewColumn5);

            TTListViewColumn listViewColumn6 = new TTListViewColumn();
            listViewColumn6.Text = "Birim";
            listViewColumn6.Width = 80;
            listView.Columns.Add(listViewColumn6);

            TTListViewColumn listViewColumn7 = new TTListViewColumn();
            listViewColumn7.Text = "Açıklama";
            listViewColumn7.Width = 100;
            listView.Columns.Add(listViewColumn7);
            
            TTListViewColumn listViewColumn8 = new TTListViewColumn();
            listViewColumn8.Text = "Panik Bildirim";
            listViewColumn8.Width = 170;
            listView.Columns.Add(listViewColumn8);
            
            TTListViewColumn listViewColumn9 = new TTListViewColumn();
            listViewColumn9.Text = "Numune Red Sebebi";
            listViewColumn9.Width = 170;
            listView.Columns.Add(listViewColumn9);

            listView.Name = "ListView";
            listView.View = View.Details;
            listView.FullRowSelect = true;
            //listView.Dock = DockStyle.Fill;
            //listView.BorderStyle = BorderStyle.None;
            listView.GridLines = true;
            listView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.OpenLongReportForm);

            tabPage.Controls.Add(listView);
            tabResults.TabPages.Add(tabPage);
            return listView;
        }

        private void FillLabResults()
        {
            // All Test Tab
            BindingList<LaboratoryProcedure> allProcedureList = LaboratoryProcedure.GetLabResults(this._LaboratoryRequest.ObjectContext, " WHERE CURRENTSTATE <> '" + LaboratoryProcedure.States.Cancelled +"' AND CURRENTSTATE <> '" + LaboratoryProcedure.States.PendingCancel + "' AND EPISODEACTION = '" + this._LaboratoryRequest.ObjectID.ToString() + "' ORDER BY REQUESTEDTAB");
            if (allProcedureList.Count > 0)
            {
                TTListView listView = GenerateLabRequestedTab("Tüm Tetkikler");
                foreach (LaboratoryProcedure labProcedure in allProcedureList)
                {
                    this.FillLabProcedure(labProcedure, listView);
                    foreach (LaboratorySubProcedure labSubProcedure in labProcedure.LaboratorySubProcedures)
                        this.FillLabProcedure(labSubProcedure, listView);
                }
            }

            BindingList<LaboratoryRequestFormTabDefinition> liste = LaboratoryRequestFormTabDefinition.GetLabTabs(this._LaboratoryRequest.ObjectContext, " AND (LABORATORYDEPARTMENT = '" + this._LaboratoryRequest.MasterResource.ObjectID.ToString() + "' OR LABORATORYDEPARTMENT IS NULL) ORDER BY TABORDER");
            if (liste.Count > 0)
            {
                foreach (LaboratoryRequestFormTabDefinition tabDef in liste)
                {
                    BindingList<LaboratoryProcedure> procedureList = LaboratoryProcedure.GetLabResults(this._LaboratoryRequest.ObjectContext, " WHERE CURRENTSTATE <> '" + LaboratoryProcedure.States.Cancelled +"' AND CURRENTSTATE <> '" + LaboratoryProcedure.States.PendingCancel + "' AND EPISODEACTION = '" + this._LaboratoryRequest.ObjectID.ToString() + "' AND REQUESTEDTAB = '" + tabDef.ObjectID.ToString() + "'");
                    if (procedureList.Count > 0)
                    {
                        TTListView listView = GenerateLabRequestedTab(tabDef.Name);
                        BindingList<LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection_Class> tabNamesGridList = LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection(this._LaboratoryRequest.ObjectContext, " WHERE REQUESTFORMTAB = '" + tabDef.ObjectID.ToString() + "' ORDER BY TABORDER");
                        {
                            foreach (LaboratoryTabNamesGrid.GetLabTabNamesGridByInjection_Class tabNameGrid in tabNamesGridList)
                            {
                                foreach (LaboratoryProcedure labProcedure in procedureList)
                                {
                                    if (tabNameGrid.Testdefid == ((LaboratoryTestDefinition)labProcedure.ProcedureObject).ObjectID)
                                    {
                                        this.FillLabProcedure(labProcedure, listView);
                                        BindingList<LaboratoryGridPanelTestDefinition> panelTests = LaboratoryGridPanelTestDefinition.GetLabGridPanels(this._LaboratoryRequest.ObjectContext, labProcedure.ProcedureObject.ObjectID);
                                        foreach (LaboratoryGridPanelTestDefinition testInPanel in panelTests)
                                        {
                                            foreach (LaboratorySubProcedure labSubProcedure in labProcedure.LaboratorySubProcedures)
                                            {
                                                if (testInPanel.LaboratoryTest.ObjectID == labSubProcedure.ProcedureObject.ObjectID)
                                                {
                                                    this.FillLabProcedure(labSubProcedure, listView);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        /*
                        foreach (LaboratoryProcedure labProcedure in procedureList)
                        {
                            FillLabProcedure(labProcedure, listView);
                            BindingList<LaboratoryGridPanelTestDefinition> panelTests = LaboratoryGridPanelTestDefinition.GetLabGridPanels(this._LaboratoryRequest.ObjectContext, labProcedure.ProcedureObject.ObjectID);
                            foreach (LaboratoryGridPanelTestDefinition testInPanel in panelTests)
                            {
                                foreach (LaboratorySubProcedure labSubProcedure in labProcedure.LaboratorySubProcedures)
                                {
                                    if (testInPanel.LaboratoryTest.ObjectID == labSubProcedure.ProcedureObject.ObjectID)
                                    {
                                        FillLabProcedure(labSubProcedure, listView);
                                        break;
                                    }
                                }
                            }
                        }
                         */
                    }
                }
            }
        }

        private void OpenLongReportForm(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.Item.Tag == null || !e.IsSelected)
                return;
            if (e.Item.Tag.ToString() != String.Empty)
            {
                SubactionProcedureFlowable baseProc = null;
                baseProc = (SubactionProcedureFlowable)this._LaboratoryRequest.ObjectContext.GetObject(new Guid(e.Item.Tag.ToString()), TTObjectDefManager.Instance.ObjectDefs[typeof(SubactionProcedureFlowable).Name], false);
                if (baseProc is LaboratoryProcedure)
                {
                    //TODO:ShowEdit!
                    //LaboratoryProcedure labProc = (LaboratoryProcedure)baseProc;
                    //LaboratoryProcedureLongReportForm LongReportForm = new LaboratoryProcedureLongReportForm();
                    //LongReportForm.ShowEdit(this.FindForm(), labProc, true);

                }
                else if (baseProc is LaboratorySubProcedure)
                {
                    //TODO:ShowEdit!
                    //LaboratorySubProcedure labSubProc = (LaboratorySubProcedure)baseProc;
                    //LaboratorySubProcedureLongReportForm LongReportForm = new LaboratorySubProcedureLongReportForm();
                    //LongReportForm.ShowEdit(this.FindForm(), labSubProc, true);
                }
            }
        }

        private void FillLabProcedure(LaboratoryProcedure labProcedure, ITTListView listView)
        {
            bool hasWarning = false;
            if (labProcedure.Warning.HasValue && labProcedure.Warning.Value != HighLowEnum.Normal)
                hasWarning = true;

            TTListViewItem item = new TTListViewItem();
            
            if(labProcedure.LongReport != null)
            {
                if(Common.GetTextOfRTFString(labProcedure.LongReport.ToString()).Trim() != string.Empty) //if (labProcedure.LongReport != null)
                {
                    item.Text = "> Aç <";
                    item.Tag = labProcedure.ObjectID.ToString();
                    //item.Font = new Font("Tahoma", 8);
                    item.BackColor = Color.DeepSkyBlue;
                }
            }

            LaboratoryTestDefinition labTestDef = labProcedure.ProcedureObject as LaboratoryTestDefinition;
            if (labTestDef != null && labTestDef.IsPanel == true)
            {
                item.BackColor = Color.FromArgb(240, 247, 255);
                //item.Font = new Font("Tahoma", 9, FontStyle.Bold);
            }

            if (hasWarning)
            {
                if (labProcedure.Warning.Value == HighLowEnum.High)
                {
                    item.ForeColor = Color.OrangeRed;
                }
                if (labProcedure.Warning.Value == HighLowEnum.Low)
                {
                    item.ForeColor = Color.DodgerBlue;
                }
                if (labProcedure.Warning.Value == HighLowEnum.Panic)
                {
                    //item.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    item.ForeColor = Color.Red;
                }
            }
            
            if(labProcedure.Panic != null)
            {
                if(labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.H || labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.HH || labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.L || labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.LL)
                {
                    //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    item.ForeColor = Color.FloralWhite;
                    item.BackColor = Color.Crimson;
                }
            }
            
            if(labProcedure.MicrobiologyPanicNotification != null)
            {
                if(labProcedure.MicrobiologyPanicNotification == true)
                {
                    //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    item.ForeColor = Color.FloralWhite;
                    item.BackColor = Color.Crimson;
                }
            }

            TTListViewSubItem subitemName = new TTListViewSubItem(); //Adı
            subitemName.Text = labProcedure.ProcedureObject.Name;
            item.SubItems.Add(subitemName);

            TTListViewSubItem subitemStar = new TTListViewSubItem(); //Flag
            if (hasWarning)
            {
                if (labProcedure.Warning.Value == HighLowEnum.High)
                {
                    subitemStar.Text = "*";
                }
                if (labProcedure.Warning.Value == HighLowEnum.Low)
                {
                    subitemStar.Text = "*";
                }
                if (labProcedure.Warning.Value == HighLowEnum.Panic)
                {
                    subitemStar.Text = "!";
                }
            }
            item.SubItems.Add(subitemStar);

            TTListViewSubItem subitem = new TTListViewSubItem(); //Sonuç
            subitem.Text = labProcedure.Result;
            item.SubItems.Add(subitem);

            TTListViewSubItem subitem2 = new TTListViewSubItem(); //Sapma
            subitem2.Text = labProcedure.Warning.HasValue == true ? Common.GetDisplayTextOfDataTypeEnum(labProcedure.Warning.Value) : "";
            item.SubItems.Add(subitem2);

            TTListViewSubItem subitem3 = new TTListViewSubItem(); //Referans
            subitem3.Text = labProcedure.Reference;
            item.SubItems.Add(subitem3);

            TTListViewSubItem subitem4 = new TTListViewSubItem(); //Özel Değerler
            subitem4.Text = labProcedure.SpecialReference != null ? Common.GetTextOfRTFString(labProcedure.SpecialReference.ToString()) : "";
            item.SubItems.Add(subitem4);

            TTListViewSubItem subitem5 = new TTListViewSubItem(); //Birim
            subitem5.Text = labProcedure.Unit;
            item.SubItems.Add(subitem5);

            TTListViewSubItem subitem6 = new TTListViewSubItem(); //Açıklama
            subitem6.Text = labProcedure.ResultDescription;
            item.SubItems.Add(subitem6);
            
            TTListViewSubItem subitem7 = new TTListViewSubItem(); //Panik
            if(labProcedure.Panic != null)
            {
                //if(labProcedure.Panic.Value == HighLowEnum.High)
                //{
                //    subitem7.Text = "Çok Yüksek Değer";
                //}
                if (labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.H)
                {
                    subitem7.Text = "Yüksek Değer";
                }
                if(labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.LL)
                {
                    subitem7.Text = "Çok Düşük Değer";
                }
                if (labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.L)
                {
                    subitem7.Text = "Düşük Değer";
                }
                if(labProcedure.Panic.Value == LaboratoryAbnormalFlagsEnum.NULL)
                {
                    subitem7.Text = "Bildirim Yok";
                }
            }
            
            if(labProcedure.MicrobiologyPanicNotification != null)
            {
                if(labProcedure.MicrobiologyPanicNotification == true)
                {
                    subitem7.Text = "Mikrobiyoloji Panik Sonuç Bildirimi!";
                }
            }
            
            item.SubItems.Add(subitem7);
            
            TTListViewSubItem subitem8 = new TTListViewSubItem(); //Numune Red Sebebi
            if(labProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleReject)
            {
                if(labProcedure.SampleRejectionReason != null)
                {
                    subitem8.Text = labProcedure.SampleRejectionReason.Reason.Trim();
                    item.BackColor = Color.DimGray;
                    item.ForeColor = Color.White;
                    subitem.Text = "Laboratuvar Red";
                }
                else
                {
                    subitem8.Text = String.Empty;
                }
                
            }
            item.SubItems.Add(subitem8);

            listView.Items.Add(item);
        }

        private void FillLabProcedure(LaboratorySubProcedure labProcedure, ITTListView listView)
        {
            bool hasWarning = false;
            if (labProcedure.Warning.HasValue && labProcedure.Warning.Value != HighLowEnum.Normal)
                hasWarning = true;

            TTListViewItem item = new TTListViewItem();
            item.BackColor = Color.FromArgb(244, 250, 255);
            
            if(labProcedure.LongReport != null)
            {
                if(Common.GetTextOfRTFString(labProcedure.LongReport.ToString()).Trim() != string.Empty) //if (labProcedure.LongReport != null)
                {
                    item.Text = "> Aç <";
                    item.Tag = labProcedure.ObjectID.ToString();
                    //item.Font = new Font("Tahoma", 8);
                    item.BackColor = Color.DeepSkyBlue;
                }
            }
            
            if (hasWarning)
            {
                if (labProcedure.Warning.Value == HighLowEnum.High)
                {
                    item.ForeColor = Color.OrangeRed;
                }
                if (labProcedure.Warning.Value == HighLowEnum.Low)
                {
                    item.ForeColor = Color.RoyalBlue;
                }
                if (labProcedure.Warning.Value == HighLowEnum.Panic)
                {
                    //item.Font = new Font("Tahoma", 8, FontStyle.Bold);
                    item.ForeColor = Color.Red;
                }
            }
            
            if(labProcedure.Panic != null)
            {
               /* if(labProcedure.Panic.Value == HighLowEnum.High || labProcedure.Panic.Value == HighLowEnum.Low)
                {
                    //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    item.ForeColor = Color.FloralWhite;
                    item.BackColor = Color.Crimson;
                } */
            }
            
            if(labProcedure.MicrobiologyPanicNotification != null)
            {
                if(labProcedure.MicrobiologyPanicNotification == true)
                {
                    //item.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    item.ForeColor = Color.FloralWhite;
                    item.BackColor = Color.Crimson;
                }
            }

            TTListViewSubItem subitemName = new TTListViewSubItem(); //Adı
            subitemName.Text = labProcedure.ProcedureObject.Name;
            item.SubItems.Add(subitemName);

            TTListViewSubItem subitemStar = new TTListViewSubItem(); //Flag
            if (hasWarning)
            {
                if (labProcedure.Warning.Value == HighLowEnum.High)
                {
                    subitemStar.Text = "*";
                }
                if (labProcedure.Warning.Value == HighLowEnum.Low)
                {
                    subitemStar.Text = "*";
                }
                if (labProcedure.Warning.Value == HighLowEnum.Panic)
                {
                    subitemStar.Text = "!";
                }
            }
            item.SubItems.Add(subitemStar);

            TTListViewSubItem subitem = new TTListViewSubItem(); //Sonuç
            subitem.Text = labProcedure.Result;
            item.SubItems.Add(subitem);

            TTListViewSubItem subitem2 = new TTListViewSubItem(); //Sapma
            subitem2.Text = labProcedure.Warning.HasValue == true ? Common.GetDisplayTextOfDataTypeEnum(labProcedure.Warning.Value) : "";
            item.SubItems.Add(subitem2);

            TTListViewSubItem subitem3 = new TTListViewSubItem(); //Referans
            subitem3.Text = labProcedure.Reference;
            item.SubItems.Add(subitem3);

            TTListViewSubItem subitem4 = new TTListViewSubItem(); //Özel Değerler
            subitem4.Text = labProcedure.SpecialReference != null ? Common.GetTextOfRTFString(labProcedure.SpecialReference.ToString()) : "";
            item.SubItems.Add(subitem4);

            TTListViewSubItem subitem5 = new TTListViewSubItem(); //Birim
            subitem5.Text = labProcedure.Unit;
            item.SubItems.Add(subitem5);

            TTListViewSubItem subitem6 = new TTListViewSubItem(); //Açıklama
            subitem6.Text = labProcedure.ResultDescription;
            item.SubItems.Add(subitem6);
            
            TTListViewSubItem subitem7 = new TTListViewSubItem(); //Panik
            if(labProcedure.Panic != null)
            {
              /*  if(labProcedure.Panic.Value == HighLowEnum.High)
                {
                    subitem7.Text = "Çok Yüksek Değer";
                }
                if(labProcedure.Panic.Value == HighLowEnum.Low)
                {
                    subitem7.Text = "Çok Düşük Değer";
                }
                if(labProcedure.Panic.Value == HighLowEnum.None)
                {
                    subitem7.Text = "Bildirim Yok";
                }
                */
            }
            
            if(labProcedure.MicrobiologyPanicNotification != null)
            {
                if(labProcedure.MicrobiologyPanicNotification == true)
                {
                    subitem7.Text = "Mikrobiyoloji Panik Sonuç Bildirimi!";
                }
            }
            
            item.SubItems.Add(subitem7);

            listView.Items.Add(item);

        }
        
#endregion LaboratoryRequestResultForm_ClientSideMethods
    }
}