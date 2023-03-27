
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
    public partial class LaboratoryResultsReportForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbuttonSearch.Click += new TTControlEventDelegate(ttbuttonSearch_Click);
            ttActionList.SelectedIndexChanged += new TTControlEventDelegate(ttActionList_SelectedIndexChanged);
            ttPrint.Click += new TTControlEventDelegate(ttPrint_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbuttonSearch.Click -= new TTControlEventDelegate(ttbuttonSearch_Click);
            ttActionList.SelectedIndexChanged -= new TTControlEventDelegate(ttActionList_SelectedIndexChanged);
            ttPrint.Click -= new TTControlEventDelegate(ttPrint_Click);
            base.UnBindControlEvents();
        }

        private void ttbuttonSearch_Click()
        {
#region LaboratoryResultsReportForm_ttbuttonSearch_Click
   ttActionList.Items.Clear();
            ttActionDetails.Items.Clear();
            this.ttgroupboxPatient.Visible = false;
            
            bool goOn = true;
            goOn = PreCheckControls();
            
            if(goOn == false)
                return;
            
            BindingList<LaboratoryRequest.GetLaboratoryRequestByFilter_Class> requests;
            requests = LaboratoryRequest.GetLaboratoryRequestByFilter(GenerateFilterExpression());
            
            if(requests.Count > 0)
            {
                foreach(LaboratoryRequest.GetLaboratoryRequestByFilter_Class request in requests)
                {
                    ITTListViewItem listViewItem = null;
                    
                    if(request.WorkListDate.HasValue)
                        listViewItem = ttActionList.Items.Add(request.WorkListDate.Value.ToString());
                    else
                        listViewItem = ttActionList.Items.Add(string.Empty);
                    
                    listViewItem.Tag = request.ObjectID;
                    
                    if(request.BarcodeID.HasValue)
                        listViewItem.SubItems.Add(request.BarcodeID.Value.ToString());
                    else
                        listViewItem.SubItems.Add(string.Empty);
                    
                    if(request.ID.HasValue)
                        listViewItem.SubItems.Add(request.ID.Value.ToString());
                    else
                        listViewItem.SubItems.Add(string.Empty);
                    
                    if(request.HospitalProtocolNo.HasValue)
                        listViewItem.SubItems.Add(request.HospitalProtocolNo.Value.ToString());
                    else
                        listViewItem.SubItems.Add(string.Empty);                    
                }
                
                ttActionList.Items[0].Selected = true;
                ttUniquerefNo.Text = string.Empty;//TC kimlik No textBox'ı temizleniyor...
            }
#endregion LaboratoryResultsReportForm_ttbuttonSearch_Click
        }

        private void ttActionList_SelectedIndexChanged()
        {
#region LaboratoryResultsReportForm_ttActionList_SelectedIndexChanged
   this.ttActionDetails.Items.Clear();

            BindingList<LaboratoryProcedure.GetLabProcedureByFilter_Class> procedures;
            BindingList<LaboratorySubProcedure.GetLabSubProcedureByFilter_Class> subProcedures;
            
            Color itemStateColor = Color.White;
            
            Color itemColorTemp = Color.White;
            int itemCounter = 0;
            
            if(this.ttActionList.SelectedItems.Count > 0)
            {
                this.ttBarcode.Text = this.ttActionList.SelectedItems[0].SubItems[1].Text;

                procedures = LaboratoryProcedure.GetLabProcedureByFilter(" AND LABORATORY.OBJECTID = '" +this.ttActionList.SelectedItems[0].Tag.ToString() +"'");
            }
            else
            {
                return;
            }
            
            if(procedures.Count > 0)
            {
                foreach(LaboratoryProcedure.GetLabProcedureByFilter_Class procedure in procedures)
                {
                    TTListViewItem listViewItem = new TTListViewItem();
                    
                    //
                    if(itemCounter % 2 == 0)
                    {
                        listViewItem.BackColor = Color.White;
                        itemColorTemp = Color.White;
                    }
                    else
                    {
                        listViewItem.BackColor = Color.AliceBlue;
                        itemColorTemp = Color.AliceBlue;
                    }
                    //
                    
                    if(!String.IsNullOrEmpty(procedure.Name))
                    {
                        listViewItem.Text = procedure.Name.Trim();
                        
                    }
                    else
                    {
                        listViewItem.Text = string.Empty;
                    }
                    
                    listViewItem.Tag = procedure.ObjectID;
                    
                    listViewItem.SubItems.Add(string.Empty);
                    
                    if(!String.IsNullOrEmpty(procedure.Result))
                    {
                        listViewItem.SubItems.Add(procedure.Result);
                    }
                    else
                    {
                        listViewItem.SubItems.Add(string.Empty);
                    }
                    
                    if(!String.IsNullOrEmpty(procedure.Reference))
                    {
                        listViewItem.SubItems.Add(procedure.Reference);
                    }
                    else
                    {
                        listViewItem.SubItems.Add(string.Empty);
                    }
                    
                    if(!String.IsNullOrEmpty(procedure.Unit))
                    {
                        listViewItem.SubItems.Add(procedure.Unit);
                    }
                    else
                    {
                        listViewItem.SubItems.Add(string.Empty);
                    }
                    
                    //Uyarılar listeleniyor...
                    TTListViewSubItem subitemProcWarning = new TTListViewSubItem();
                    if(procedure.Warning.HasValue)
                    {
                        if(procedure.Warning.Value == HighLowEnum.High)
                        {
                            subitemProcWarning.Text = "Yüksek";
                            listViewItem.ForeColor = Color.OrangeRed;
                        }
                        if(procedure.Warning.Value == HighLowEnum.Low)
                        {
                            subitemProcWarning.Text = "Düşük";
                            listViewItem.ForeColor = Color.DodgerBlue;
                        }
                        if(procedure.Warning.Value == HighLowEnum.Normal)
                        {
                            subitemProcWarning.Text = "Normal";
                        }
                        if(procedure.Warning.Value == HighLowEnum.None)
                        {
                            subitemProcWarning.Text = string.Empty;
                        }
                        if(procedure.Warning.Value == HighLowEnum.Panic)
                        {
                            if(procedure.Panic.HasValue)
                            {
                                //listViewItem.Font = new Font("Tahoma", 10, FontStyle.Bold);
                                listViewItem.ForeColor = Color.FloralWhite;
                                listViewItem.BackColor = Color.Crimson;
                                
                                if(procedure.Panic.Value == LaboratoryAbnormalFlagsEnum.HH)
                                {
                                    subitemProcWarning.Text = "Çok Yüksek";
                                }
                                if (procedure.Panic.Value == LaboratoryAbnormalFlagsEnum.H)
                                {
                                    subitemProcWarning.Text = "Yüksek";
                                }
                                if (procedure.Panic.Value == LaboratoryAbnormalFlagsEnum.LL)
                                {
                                    subitemProcWarning.Text = "Çok Düşük";
                                }
                                if (procedure.Panic.Value == LaboratoryAbnormalFlagsEnum.L)
                                {
                                    subitemProcWarning.Text = "Düşük";
                                }
                            }
                        }
                    }
                    else
                    {
                        subitemProcWarning.Text = string.Empty;
                    }
                    listViewItem.SubItems.Add(subitemProcWarning);
                    
                    //İşlem Durumu listeleniyor...
                    TTListViewSubItem subitemProcState = new TTListViewSubItem();
                    if(procedure.CurrentStateDefID.HasValue)
                    {
                        if(procedure.CurrentStateDefID == LaboratoryProcedure.States.New)
                        {
                            subitemProcState.Text = "Yeni";
                            itemStateColor = Color.Moccasin;
                        }
                        if(procedure.CurrentStateDefID == LaboratoryProcedure.States.SampleAccept)
                        {
                            subitemProcState.Text = "Numune Kabul";
                            itemStateColor = Color.Moccasin;
                        }
                        if(procedure.CurrentStateDefID == LaboratoryProcedure.States.Procedure)
                        {
                            subitemProcState.Text = "Laboratuvarda";
                            itemStateColor = Color.PapayaWhip;
                        }
                        if(procedure.CurrentStateDefID == LaboratoryProcedure.States.Completed)
                        {
                            subitemProcState.Text = "Tamamlandı";
                            itemStateColor = Color.LightGreen;
                        }
                        if(procedure.CurrentStateDefID == LaboratoryProcedure.States.Cancelled)
                        {
                            subitemProcState.Text = "İptal Edildi";
                            itemStateColor = Color.LightCoral;
                        }
                        if(procedure.CurrentStateDefID == LaboratoryProcedure.States.SampleReject)
                        {
                            subitemProcState.Text = "Reddedildi";
                            itemStateColor = Color.LightCoral;
                        }
                        
                    }
                    listViewItem.SubItems.Add(subitemProcState);
                    ttActionDetails.Items.Add(listViewItem);
                    
                                        
                    itemCounter++;
                    
                    
                    //Alt Tetkikler varsa buradan sonra listelenir...
                    
                    subProcedures = LaboratorySubProcedure.GetLabSubProcedureByFilter(" AND MASTERSUBACTIONPROCEDURE.OBJECTID = '" + procedure.ObjectID.ToString() +"'");
                    
                    if(subProcedures.Count > 0)
                    {
                        foreach(LaboratorySubProcedure.GetLabSubProcedureByFilter_Class subProcedure in subProcedures)
                        {
                            TTListViewItem listViewSubItem = new TTListViewItem();
                            
                            //
                            listViewSubItem.BackColor = itemColorTemp;
                            //
                            
                            listViewSubItem.Text = string.Empty; //ttActionDetails.Items.Add(string.Empty);
                            
                            listViewSubItem.Tag = subProcedure.ObjectID;
                            
                            if(!String.IsNullOrEmpty(subProcedure.Name))
                            {
                                listViewSubItem.SubItems.Add(subProcedure.Name.Trim());
                            }
                            else
                            {
                                listViewSubItem.SubItems.Add(string.Empty);
                            }
                            
                            
                            if(!String.IsNullOrEmpty(subProcedure.Result))
                            {
                                listViewSubItem.SubItems.Add(subProcedure.Result);
                            }
                            else
                            {
                                listViewSubItem.SubItems.Add(string.Empty);
                            }
                            
                            if(!String.IsNullOrEmpty(subProcedure.Reference))
                            {
                                listViewSubItem.SubItems.Add(subProcedure.Reference);
                            }
                            else
                            {
                                listViewSubItem.SubItems.Add(string.Empty);
                            }
                            
                            if(!String.IsNullOrEmpty(subProcedure.Unit))
                            {
                                listViewSubItem.SubItems.Add(subProcedure.Unit);
                            }
                            else
                            {
                                listViewSubItem.SubItems.Add(string.Empty);
                            }
                            
                            TTListViewSubItem subitemSubProcWarning = new TTListViewSubItem();
                            if(subProcedure.Warning.HasValue)
                            {
                                if(subProcedure.Warning.Value == HighLowEnum.High)
                                {
                                    subitemSubProcWarning.Text = "? Yüksek";
                                    listViewSubItem.ForeColor = Color.OrangeRed;
                                }
                                if(subProcedure.Warning.Value == HighLowEnum.Low)
                                {
                                    subitemSubProcWarning.Text = "? Düşük";
                                    listViewSubItem.ForeColor = Color.DodgerBlue;
                                }
                                if(subProcedure.Warning.Value == HighLowEnum.Normal)
                                {
                                    subitemSubProcWarning.Text = "? Normal";
                                }
                                if(subProcedure.Warning.Value == HighLowEnum.None)
                                {
                                    subitemSubProcWarning.Text = string.Empty;
                                }
                                if(subProcedure.Warning.Value == HighLowEnum.Panic)
                                {
                                    if(subProcedure.Panic.HasValue)
                                    {
                                        //listViewSubItem.Font = new Font("Tahoma", 10, FontStyle.Bold);
                                        listViewSubItem.ForeColor = Color.FloralWhite;
                                        listViewSubItem.BackColor = Color.Crimson;
                                        
                                       /* if(subProcedure.Panic.Value == HighLowEnum.High)
                                        {
                                            subitemSubProcWarning.Text = " ? Çok Yüksek";
                                        }
                                        
                                        if(subProcedure.Panic.Value == HighLowEnum.Low)
                                        {
                                            subitemSubProcWarning.Text = " ? Çok Düşük";
                                        } */
                                    }
                                }
                            }
                            
                            else
                            {
                                subitemSubProcWarning.Text = string.Empty;
                            }
                            listViewSubItem.SubItems.Add(subitemSubProcWarning);
                            listViewSubItem.SubItems.Add(string.Empty);
                            
                            
                            ttActionDetails.Items.Add(listViewSubItem);
                        }
                    }
                }
            }
#endregion LaboratoryResultsReportForm_ttActionList_SelectedIndexChanged
        }

        private void ttPrint_Click()
        {
#region LaboratoryResultsReportForm_ttPrint_Click
   try
            {
              //  this.Cursor = Cursors.WaitCursor;
                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
                TTReportTool.PropertyCache<object> cache = new TTReportTool.PropertyCache<object>();
                cache.Add("VALUE", this.ttBarcode.Text.Trim());
                parameters.Add("BARCODEID", cache);
                
                if(this.ttReportPreviewCheck.Value == true)
                {
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_LaboratoryBarcodeResultReport), true, 1, parameters);
                }
                else
                {
                    TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_LaboratoryBarcodeResultReport), false, 1, parameters);
                }
            }
            catch(Exception ex)
            {
                //this.Cursor = Cursors.Default;
                InfoBox.Show(ex.ToString(),MessageIconEnum.ErrorMessage);
            }
            finally
            {
               // this.Cursor = Cursors.Default;
                this.ttBarcode.Text = string.Empty;
                this.ttBarcode.Focus();
            }
#endregion LaboratoryResultsReportForm_ttPrint_Click
        }

#region LaboratoryResultsReportForm_Methods
        public string GenerateFilterExpression()
        {
            string filterExpression = string.Empty;
            
            if(this.ttUniquerefNo.Text != null && this.ttUniquerefNo.Text.Trim() != string.Empty)
            {
                //BindingList<Patient> patients = Patient.GetPatientsByUniqueRefNo(context, Convert.ToInt64(this.ttUniquerefNo.Text.Trim()));
                BindingList<Patient.GetPatientByInjection_Class> patients = Patient.GetPatientByInjection(" WHERE UNIQUEREFNO = '"+ this.ttUniquerefNo.Text.Trim()+"'");
                if(patients.Count > 0)
                {
                    //Güvenlikli Hasta Kontrolü
                    if(patients[0].SecurePerson.HasValue)
                    {
                        if(patients[0].SecurePerson.Value == true)
                        {
                            Guid guid = new Guid("26c276d6-4b77-4f9d-ad8d-246dc965c8f1"); //Laboratuvar Güvenlikli Barkodlu Rapor Yazdırma
                            if (!Common.CurrentUser.HasRole(guid))
                            {
                                throw new TTUtils.TTException("Güvenlikli Hasta görüntüleme için yetkili değilsiniz!");
                            }     
                        }
                    }
                    
                    
                    this.ttlabelUniquerefno.Text = this.ttUniquerefNo.Text.Trim();
                    this.ttlabelPatientName.Text = patients[0].Name.Trim();
                    this.ttlabelPatientSurname.Text = patients[0].Surname.Trim();
                    
                    
                    
                    this.ttgroupboxPatient.Visible = true;
                    
                    filterExpression += " AND EPISODE.PATIENT.OBJECTID = '" + patients[0].ObjectID.ToString() +"'";
                }
            }
            
            if(this.ttBarcode.Text != null && this.ttBarcode.Text.Trim() != string.Empty)
            {
                filterExpression += " AND BARCODEID = '" + this.ttBarcode.Text.Trim()+"'";
            }
            
            filterExpression += " ORDER BY WORKLISTDATE DESC"; 
            
            return filterExpression;
            
        }
        
        public bool PreCheckControls()
        {
            if(String.IsNullOrEmpty(this.ttBarcode.Text) && String.IsNullOrEmpty(this.ttUniquerefNo.Text))
                return false;
            else
                return true;
                
        }
        
#endregion LaboratoryResultsReportForm_Methods
    }
}