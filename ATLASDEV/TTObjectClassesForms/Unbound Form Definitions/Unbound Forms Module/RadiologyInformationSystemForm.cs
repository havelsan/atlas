
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
    /// Radyoloji İşlemleri
    /// </summary>
    public partial class RadiologyInformationSystemForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            TestGrid.CellContentClick += new TTGridCellEventDelegate(TestGrid_CellContentClick);
            ttcheckbox1.CheckedChanged += new TTControlEventDelegate(ttcheckbox1_CheckedChanged);
            ttbutton3.Click += new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            PatientGrid.CellContentClick += new TTGridCellEventDelegate(PatientGrid_CellContentClick);
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            TestGrid.CellContentClick -= new TTGridCellEventDelegate(TestGrid_CellContentClick);
            ttcheckbox1.CheckedChanged -= new TTControlEventDelegate(ttcheckbox1_CheckedChanged);
            ttbutton3.Click -= new TTControlEventDelegate(ttbutton3_Click);
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            PatientGrid.CellContentClick -= new TTGridCellEventDelegate(PatientGrid_CellContentClick);
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void TestGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region RadiologyInformationSystemForm_TestGrid_CellContentClick
   //?imdilik value lar tam ters control edilecek
            
            
            //   System.Diagnostics.Debugger.Break();
            
            if ( ((TTGrid)TestGrid).Rows[rowIndex].ReadOnly == false )
            {
                if (columnIndex == ((TTGrid) this.TestGrid).Columns.Count - 1)
                {
                    if ( (bool) ((TTGrid) this.TestGrid).Rows[rowIndex].Cells[columnIndex].Value == false)
                    {
                        if (this.alistSendTest.Contains( ((TTGrid) this.TestGrid).Rows[rowIndex].Cells[0].Value.ToString() ) != true)
                        {
                            
                            //   this.alistCheckedTest.Add(rowIndex);
                            alistCheckedTest.Add( ((TTGrid) this.TestGrid).Rows[rowIndex].Cells[0].Value.ToString() );
                            
                            
                        }
                        
                    }
                    else
                    {
                        
                        this.alistCheckedTest.Remove( ((TTGrid) this.TestGrid).Rows[rowIndex].Cells[0].Value.ToString() );
                        
                        
                    }
                    
                    
                }
                
                else if (columnIndex == ((TTGrid) this.TestGrid).Columns.Count - 2)
                {
                    
                    //------------------
                    //     tgSelectedRow.Text = rowIndex.ToString();
                    
                    //     RadiologyTestForm RadTestForm = new RadiologyTestForm();
                    
                    //     RadTestForm.ShowDialog(this);
                    //-------------------
                    
              //      System.Diagnostics.Debugger.Break();
                     tgSelectedRow.Text = rowIndex.ToString();
                    
                    TTObjectContext objectContext = new TTObjectContext(false);
                    try
                    {
                        string ObjId = ( (TTGrid) this.TestGrid).Rows[rowIndex].Cells["ObjectId"].Value.ToString();
                        
                        Guid TestObjectID = new Guid(ObjId);

                        //---------------QueryObeject--------------------- 
                        //    IList RadiologyTests = new  List<RadiologyTest>();


                        //IList RadiologyTests = radtestcontext.QueryObjects("RadiologyTest", "OBJECTID = " + ConnectionManager.GuidToString(TestObjectID));


                        // Static Context yüzünden kapatıldı
                        //if (Convert.ToBoolean(RadiologyTests.Count))
                        //{
                        //    //buras? de?i?ecek
                        //    //------------
                        //    TTObject ttObject = (TTObject)RadiologyTests [0];
                        //    if (ttObject == null)
                        //        return;
                        //    ttObject = objectContext.GetObject(ttObject.ObjectID, ttObject.ObjectDef);
                        //     ((RadiologyTest) ttObject).OwnerType = "TTUnboundForm";
                        //    //-------------------------
                        //    TTForm frm = new RadiologyTestCompletedForm();
                        //    ( (RadiologyTestCompletedForm) frm).Uparentform = (TTUnboundForm) this;   
                        //    frm.ShowEdit(this,(TTObject) ttObject );
                        //}
                        
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        objectContext.Dispose();
                    }

                    
                    
                }
                
                
                
            }
#endregion RadiologyInformationSystemForm_TestGrid_CellContentClick
        }

        private void ttcheckbox1_CheckedChanged()
        {
#region RadiologyInformationSystemForm_ttcheckbox1_CheckedChanged
   // System.Diagnostics.Debugger.Break();
            for(int i = 0; i<=this.TestGrid.Rows.Count -1; i++)
            {
                
                if( ((TTGrid)this.TestGrid).Rows[i].Visible == true )
                {
                    
                    
                    
                    //if(alistSendTest.Contains(i) == false )
                    
                    
                    if( alistSendTest.Contains( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() ) == false )
                    {
                        ((TTGrid)this.TestGrid).Rows[i].Cells["Check"].Value = ((TTCheckBox)this.ttcheckbox1).Value;
                        
                        if(((TTCheckBox)this.ttcheckbox1).Value == true )
                        {
                            alistCheckedTest.Add( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        }
                        else {
                            alistCheckedTest.Remove( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                            
                        }
                        
                    }
                    
                    
                }
                
            }
            
            ((TTGrid)this.TestGrid).Refresh();
#endregion RadiologyInformationSystemForm_ttcheckbox1_CheckedChanged
        }

        private void ttbutton3_Click()
        {
#region RadiologyInformationSystemForm_ttbutton3_Click
   this.TestView();
#endregion RadiologyInformationSystemForm_ttbutton3_Click
        }

        private void ttbutton2_Click()
        {
#region RadiologyInformationSystemForm_ttbutton2_Click
   this.TestView();
#endregion RadiologyInformationSystemForm_ttbutton2_Click
        }

        private void PatientGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region RadiologyInformationSystemForm_PatientGrid_CellContentClick
   if(columnIndex == ((TTGrid)PatientGrid).Columns.Count - 1)
            {
                
                ((TTGrid)PatientGrid).Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                
                for (int i =0; i<= ((TTGrid)PatientGrid).Rows.Count - 1; i++  )
                {
                    if (i != rowIndex)
                    {
                        ((TTGrid)PatientGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                        
                    }
                }
                
                ((TTGrid)PatientGrid).Refresh();
                
                
                for (int i =0; i<= ((TTGrid)this.TestGrid).Rows.Count - 1; i++  )
                {
                    
                    if(   ((TTGrid)PatientGrid).Rows[rowIndex].Cells["ObjectId"].Value.ToString() == ((TTGrid)this.TestGrid).Rows[i].Cells["PatientObjectId"].Value.ToString() )
                    {
                     
                        ((TTGrid)this.TestGrid).Rows[i].Visible = true;
                        
                        
                    }
                    else
                    {
                     ((TTGrid)this.TestGrid).Rows[i].Visible = false;
                        
                    
                    }
                    
                    
                }
                
                ((TTGrid)this.TestGrid).Refresh();
                        
                
                
                
            }
#endregion RadiologyInformationSystemForm_PatientGrid_CellContentClick
        }

        private void ttbutton1_Click()
        {
#region RadiologyInformationSystemForm_ttbutton1_Click
   alistPatinet.Clear();
            alistCheckedTest.Clear();
            alistSendTest.Clear();
            // tümünü seç \ kaldır check i
            ttcheckbox1.Visible = false;
            
            ((TTGroupBox) this.ttgroupbox3).Visible = false;
            this.DeleteButtons();
            this.TestGrid.Rows.Clear();
            this.PatientGrid.Rows.Clear();
            this.ArrangeGridField((Guid)this.ttlistview1.SelectedItems[0].Tag);
            
            
            
            
            string QueryText = "";
            ((TTGrid)this.TestGrid).VirtualMode = false;
            
            ((TTGrid)this.PatientGrid).VirtualMode = false;
            
            //  QueryText = " TESTDATE >= CONVERT(DATETIME, '" + ((TTDateTimePicker)this.Sdate).Value.Date.ToString("yyyy-MM-dd HH:mm:ss") + "', 102)  AND TESTDATE <= CONVERT(DATETIME,  '" +  ((TTDateTimePicker)this.Edate).Value.Date.ToString("yyyy-MM-dd HH:mm:ss") + "', 102) " ;
            
            TTObjectContext context = new TTObjectContext(false);
          
              //---------------QueryObeject--------------------- 
         //   IList RadTest = new  List<RadiologyTest>();
            
         
              //###################################              
            // IList RadTest = context.QueryObjects("RadiologyTest" );
         System.Diagnostics.Debugger.Break();   
          IList RadTest =  RadiologyTest.GetTests(context,((TTDateTimePicker)this.Sdate).Value,((TTDateTimePicker)this.Edate).Value);
            
            
            if(Convert.ToBoolean(RadTest.Count))
            {
                
                
                foreach (RadiologyTest test in RadTest)
                {
                    if (test.TestDate != null)
                    {
                       //######
                       if (test.CurrentStateDefID == (System.Guid) this.ttlistview1.SelectedItems[0].Tag
                          
                           //  && (test.TestDate >= ((TTDateTimePicker)this.Sdate).Value && test.TestDate <= ((TTDateTimePicker)this.Edate).Value )
                            
                      
                      
                      
                      
                           )
                        {
                            ((TTGrid)this.TestGrid).Rows.Add(new object[] {test.ObjectID.ToString()
                                                                     ,test.Episode.Patient.ObjectID.ToString()
                                                                     ,test.Episode.Patient.ID.ToString()
                                                                     ,test.Episode.Patient.Name.ToString()
                                                                     ,test.ProcedureObject
                                                                     ,test.ProcedureObject.Name.ToString()
                                                                     ,test.Department
                                                                     ,test.Equipment
                                                                     ,test.TechnicianNote
                                                                     ,test.Description
                                                                     ,test.Report
                                                                     ,test.RejectReason
                                                                     ,test.TestDate.ToString()
                                                                     ,"..."
                                                                     
                                                             });
                            
                            
                            
                            
                            
                            
                            
                            
                            
                            if (alistPatinet.Contains(test.Radiology.Episode.Patient) == false)
                            {
                                alistPatinet.Add(test.Radiology.Episode.Patient);
                            }
                            
                            
                            
                            
                        }
                    }
                }
                
                
                
                
                
                
            }
            
            
            if (((TTGrid)this.TestGrid).Rows.Count >= 1)
            {
                
                this.SetPatientGrid();
                ttcheckbox1.Visible = true;
                ((TTGroupBox) this.ttgroupbox3).Visible = true;
                
                for(int i = 0; i <= ((TTGrid)this.TestGrid).Rows.Count -1; i++ )
                {
                    if(ix == 1)
                        ((TTGrid)this.TestGrid).Rows[i].Visible = false;
                    else
                        ((TTGrid)this.TestGrid).Rows[i].Visible = true;
                }
                
                
                
                
                
                this.BeginSetChecks();
              
                this.LocateButtons( (Guid)ttlistview1.SelectedItems[0].Tag );
                
                
            }
#endregion RadiologyInformationSystemForm_ttbutton1_Click
        }

#region RadiologyInformationSystemForm_Methods
        ArrayList btnList= new ArrayList();
        
        public Dictionary<Guid, TTObjectStateTransitionDef> nextTransitions;
        public int ix = 1;
        public ArrayList alistCheckedTest = new ArrayList();
        public ArrayList alistSendTest = new ArrayList();
        
        public TTObjectContext radtestcontext = new TTObjectContext(false);
        //public RadiologyTest radx = new RadiologyTest(radtestcontext);
        
        public ArrayList alistPatinet = new ArrayList();
        
        
        
        public string[]     statename = {"Yeni İstek"
                ,"Prosedür"
                ,"Sonuç Giriş"
                ,"Onay"
                ,"Tamam"
                ,"Red"        };
        public object[]   stateid = {RadiologyTest.States.RequestAcception
                ,RadiologyTest.States.Procedure
                ,RadiologyTest.States.ResultEntry
                ,RadiologyTest.States.Approve
                ,RadiologyTest.States.Completed
                ,RadiologyTest.States.Reject
                
        };
        
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.FillTestState();
            
            this.ttbutton3.Enabled = true;
            this.ttbutton2.Enabled = false;
            tgSelectedRow.Visible = false;
            
            
            ((TTDateTimePicker)this.Sdate).Format = DateTimePickerFormat.Custom;
            ((TTDateTimePicker)this.Edate).Format = DateTimePickerFormat.Custom;
            ((TTDateTimePicker)this.Sdate).CustomFormat = "dd.MM.yyyy    HH:mm";
            ((TTDateTimePicker)this.Edate).CustomFormat = "dd.MM.yyyy    HH:mm";
            
            ((TTDateTimePicker)this.Sdate).Value = DateTime.Now.Date.AddHours(0).AddMinutes(0);
            ((TTDateTimePicker)this.Edate).Value = DateTime.Now.Date.AddHours(23).AddMinutes(59);
            
            
            ((TTGrid)this.TestGrid).AllowUserToAddRows = false;
            ((TTGrid)this.TestGrid).AllowUserToDeleteRows = false;
            ((TTGrid)this.TestGrid).AllowUserToResizeRows = false;
            ((TTGrid)this.TestGrid).AllowUserToResizeColumns = false;
            ((TTGrid)this.TestGrid).AllowDrop = false;
            ((TTGrid)this.TestGrid).MultiSelect = false;
            ((TTGrid)this.TestGrid).RowHeadersVisible = false;
            
            ((TTGrid)this.PatientGrid).AllowUserToAddRows = false;
            ((TTGrid)this.PatientGrid).AllowUserToDeleteRows = false;
            ((TTGrid)this.PatientGrid).AllowUserToResizeRows = false;
            ((TTGrid)this.PatientGrid).AllowUserToResizeColumns = false;
            ((TTGrid)this.PatientGrid).AllowDrop = false;
            ((TTGrid)this.PatientGrid).MultiSelect = false;
            ((TTGrid)this.PatientGrid).RowHeadersVisible = false;
            
            
            
            
            
            //  ((TTCheckBox)this.ttcheckbox1).ThreeState = false;
            ttcheckbox1.Visible = false;
            ((TTGroupBox) this.ttgroupbox3).Visible = false;
            ((TTCheckBoxColumn)((TTGrid)this.TestGrid).Columns["Check"]).ThreeState = false;
            
            alistCheckedTest.Clear();
            alistSendTest.Clear();
            
        }
        
        
        
        
        public void FillTestState()
        {
            ttlistview1.Columns.Add("Test Durumu",130);
            
            
            for (int i = 0;i<=5;i++)
            {
                ITTListViewItem listItem = new TTListViewItem();
                listItem.Text = statename[i];
                listItem.Tag = stateid[i];
                this.ttlistview1.Items.Add(listItem);
                
                
            }
            
            ttlistview1.Items[0].Selected = true;
            this.ArrangeGridField((Guid)this.ttlistview1.SelectedItems[0].Tag);
            
        }
        
        
        
        public void BeginSetChecks()
        {
            
            for(int i = 0; i<=this.TestGrid.Rows.Count -1; i++)
            {
                this.TestGrid.Rows[i].Cells["Check"].Value = false;
                
            }
            
        }
        
        
        public void DeleteButtons()
        {
            foreach(TTButton btn in btnList)
            {
                ((TTGroupBox) this.ttgroupbox3).Controls.Remove(btn);
                
            }
            btnList.Clear();
            
        }
        
        public bool CheckedTestControl()
        {
            bool chk  = false;
            
            //buraya dikkat et
            
            for( int i=0; i<= ((TTGrid)this.TestGrid).Rows.Count - 1; i++ )
            {
                if( ((TTGrid)this.TestGrid).Rows[i].Visible == true )
                {
                    
                    if(  alistCheckedTest.Contains ( ((TTGrid)this.TestGrid).Rows[i].Cells[0].Value.ToString() ) == true )
                    {
                        chk = true;
                        break;
                    }
                    
                    
                    
                }
            }
            
            if ( !chk)
            {
                MessageBox.Show(" Enaz bir test seçilmeli!");
                
            }

            return chk;
            
        }
        
        
        public void CreateButton(string btnName,string btnText,int x,int y)

        {
            
            TTButton btn = new TTButton();
            btn.Text = btnText;
            ///btn.Location = new Point(x,y);
           // btn.Size = new Size(84,23);
            
            switch (btnName)
            {
                case "Procedure":
                    btn.Click += new TTControlEventDelegate(ToProcedure);
                    //btn.BackColor = System.Drawing.Color.LightBlue;
                    break;
                case "Appointment":
                    btn.Click += new TTControlEventDelegate(ToAppointment);
                    
                    break;
                case "Approve":
                    btn.Click += new TTControlEventDelegate(ToApprove);
                    
                    break;
                case "ResultEntry":
                    btn.Click += new TTControlEventDelegate(ToResultEntry);
                    break;
                    
                case "Completed":
                    btn.Click += new TTControlEventDelegate(ToCompleted);
                    break;
                    
                case "Reject":
                    btn.Click += new TTControlEventDelegate(ToReject);
                    //  btn.BackColor = System.Drawing.Color.Red;
                    //  btn.ForeColor = System.Drawing.Color.White;
                    break;
                    
                    
                default:
                    break;
            }
            
            //  btn.Visible = true;
            ((TTGroupBox) this.ttgroupbox3).Controls.Add(btn);
            this.btnList.Add(btn);

            
        }
        
        
        //---------------------------------------------------------------------
        
        /*private void FillNextTransitionsOnUnBound()
        {
            nextTransitions = new Dictionary<Guid, TTObjectStateTransitionDef>();
            if (_RadiologyTest.CurrentStateDef == null)
                return;
            
            

            foreach (TTObjectStateTransitionDef transDef in _RadiologyTest.CurrentStateDef.OutgoingTransitions.Values)
            {
                if (TTUser.CurrentUser.HasRight(transDef,_RadiologyTest, (int)TTSecurityAuthority.RightsEnum.Transition))
                { nextTransitions.Add(transDef.StateTransitionDefID, transDef); }
            }
            
            
        }

         */
        
        
        //---------------------------------------------------------------------
        
        
        
        
        public void LocateButtons(Guid SelectedState )
        {
            int x = 6;
            int y = 20;
            int s = 0;
            //    System.Diagnostics.Debugger.Break();
            
            if ((Guid) SelectedState == RadiologyTest.States.RequestAcception)
            {
                
                this.CreateButton("Procedure","Prosedür",x,y + s);
                s = s+30;
                this.CreateButton("Appointment","Randevu",x,y + s);
                
                
                s = s+150;
                this.CreateButton("Reject","Red",x,y + s);
                
            }
            
            else if ((Guid) SelectedState == RadiologyTest.States.Procedure)
            {
                
                
                this.CreateButton("ResultEntry","Sonuç Giriş",x,y + s);
                s = s+30;
                this.CreateButton("Appointment","Randevu",x,y + s);
                s = s+30;
                
                
                s = s+150;
                this.CreateButton("Reject","Red",x,y + s);
                
                
                
            }
            
            else if ((Guid) SelectedState == RadiologyTest.States.ResultEntry)
            {
                
                this.CreateButton("Approve","Onay",x,y + s);
                s = s+30;
                this.CreateButton("Completed","Tamam",x,y + s);
                s = s+30;
                this.CreateButton("Procedure","Prosedür Tekrar",x,y + s);
                s = s+30;
                
                
                
                s = s+150;
                this.CreateButton("Reject","Red",x,y + s);
                
                
                
            }
            
            else if ((Guid) SelectedState == RadiologyTest.States.Approve)
            {
                
                this.CreateButton("Completed","Tamam",x,y + s);
                s = s+30;
                this.CreateButton("ResultEntry","Sonuç Giriş",x,y + s);
                s = s+30;
                
                
                
                s = s+150;
                this.CreateButton("Reject","Red",x,y + s);
                
                
                
            }
            
            else if ((Guid) SelectedState == RadiologyTest.States.Completed)
            {
                this.CreateButton("Approve","Onay",x,y + s);
                s = s+30;
                
                this.CreateButton("ResultEntry","Sonuç Giriş",x,y + s);
                
                
            }
            
            
            
            
            
            
            
            
        }
        
        public void ArrangeGridField(Guid State)
            
        {
            if (State == (Guid) RadiologyTest.States.RequestAcception)
            {
                this.TestGrid.Columns["Description"].ReadOnly = false;
                this.TestGrid.Columns["Report"].Visible = false;
                this.TestGrid.Columns["TechnicianNote"].Visible = false;
                this.TestGrid.Columns["Department"].Visible = true;
                this.TestGrid.Columns["Equipment"].Visible =  true;
                this.TestGrid.Columns["RejectReason"].Visible =  true;
                this.TestGrid.Columns["RejectReason"].ReadOnly = false;
                
                ((TTGrid)this.TestGrid).Refresh();
            }
            else if ((Guid) this.ttlistview1.SelectedItems[0].Tag == RadiologyTest.States.Procedure)
            {
                
                this.TestGrid.Columns["Report"].Visible = false;
                this.TestGrid.Columns["TechnicianNote"].Visible = true;
                this.TestGrid.Columns["TechnicianNote"].ReadOnly= false;
                this.TestGrid.Columns["Department"].Visible = false;
                this.TestGrid.Columns["Equipment"].Visible =  false;
                this.TestGrid.Columns["RejectReason"].Visible =  true;
                this.TestGrid.Columns["RejectReason"].ReadOnly = false;
                this.TestGrid.Columns["Description"].ReadOnly = false;
                
                ((TTGrid)this.TestGrid).Refresh();
                
                
            }
            
            else if ((Guid) this.ttlistview1.SelectedItems[0].Tag == RadiologyTest.States.ResultEntry || (Guid) this.ttlistview1.SelectedItems[0].Tag == RadiologyTest.States.Approve )
            {
                
                this.TestGrid.Columns["Report"].Visible = true;
                this.TestGrid.Columns["TechnicianNote"].Visible = true;
                this.TestGrid.Columns["Department"].Visible = false;
                this.TestGrid.Columns["Equipment"].Visible =  false;
                this.TestGrid.Columns["Report"].ReadOnly = false;
                this.TestGrid.Columns["Department"].ReadOnly = false;
                this.TestGrid.Columns["RejectReason"].Visible =  true;
                this.TestGrid.Columns["RejectReason"].ReadOnly =  false;
                this.TestGrid.Columns["Description"].ReadOnly = false;
                
                ((TTGrid)this.TestGrid).Refresh();
                
                
                if ((Guid) this.ttlistview1.SelectedItems[0].Tag == RadiologyTest.States.ResultEntry) {this.TestGrid.Columns["TechnicianNote"].ReadOnly= false;}
                else {this.TestGrid.Columns["TechnicianNote"].ReadOnly= true;}
                
            }
            
            
            else if ((Guid) this.ttlistview1.SelectedItems[0].Tag == RadiologyTest.States.Completed)
            {
                
                this.TestGrid.Columns["Report"].Visible = true;
                this.TestGrid.Columns["Department"].Visible = false;
                this.TestGrid.Columns["Equipment"].Visible =  false;
                
                this.TestGrid.Columns["Report"].ReadOnly = true;
                this.TestGrid.Columns["TechnicianNote"].ReadOnly = true;
                this.TestGrid.Columns["TechnicianNote"].Visible = true;
                this.TestGrid.Columns["Department"].ReadOnly = true;
                
                this.TestGrid.Columns["Description"].ReadOnly = true;
                
                this.TestGrid.Columns["RejectReason"].Visible =  false;
                
                ((TTGrid)this.TestGrid).Refresh();
                
                
            }
            
            
            else if ((Guid) this.ttlistview1.SelectedItems[0].Tag == RadiologyTest.States.Reject)
            {
                this.TestGrid.Columns["Report"].Visible = false;
                this.TestGrid.Columns["Department"].Visible = false;
                this.TestGrid.Columns["Equipment"].Visible =  false;
                
                this.TestGrid.Columns["Report"].Visible = false;
                this.TestGrid.Columns["TechnicianNote"].ReadOnly = true;
                this.TestGrid.Columns["TechnicianNote"].Visible = true;
                this.TestGrid.Columns["Description"].ReadOnly = true;
                
                this.TestGrid.Columns["RejectReason"].Visible =  true;
                this.TestGrid.Columns["RejectReason"].ReadOnly =  true;
                
                
                
            }
            
            
            
            
            
        }
        
        
        public RadiologyTest GetRadiologyTest(string ObjectId)
        {
            TTObjectContext rcontext = new TTObjectContext(false);
            Guid TestObjectID = new Guid(ObjectId);
            RadiologyTestDefinition Testn;
            //---------------QueryObeject--------------------- 
           // IList RadTest = new  List<RadiologyTest>();
        
            IList RadTest = rcontext.QueryObjects("RadiologyTest", "OBJECTID = " + ConnectionManager.GuidToString(TestObjectID));
            return (RadiologyTest) RadTest[0];
            
            
            
            
        }
        
        
        
        
        public void  SetPatientGrid()
        {
            foreach(Patient p in alistPatinet )
            {
                ((TTGrid)this.PatientGrid).Rows.Add(new object[] {p.ObjectID.ToString()
                                                            ,p.ID
                                                            ,p.Name.ToString()
                                                            ,"..."
                                                    });
                
            }
            
            ((TTGrid)this.PatientGrid).Refresh();
            
            alistPatinet.Clear();
            
        }
        
        
        public void  TestView()
        {
            
            if (ix == 0)
            {
                this.ttbutton3.Enabled = true;
                this.ttbutton2.Enabled = false;
                
                this.PatientGrid.Visible = true;
                
                //((TTGrid)TestGrid).Location = new Point(267,20);
                //((TTGrid)TestGrid).Size = new Size(592,379);
                
                ((TTGrid)TestGrid).Columns["PatientId"].Visible = false;
                ((TTGrid)TestGrid).Columns["PatientName"].Visible = false;
                
                for(int i = 0; i <= ((TTGrid)this.TestGrid).Rows.Count -1; i++ )
                {
                    ((TTGrid)this.TestGrid).Rows[i].Visible = false;
                }
                
                
                ((TTGrid)TestGrid).Refresh();
                
                
                ix = 1;
                
            }
            
            else
            {
                this.ttbutton2.Enabled = true;
                this.ttbutton3.Enabled = false;
                
                this.PatientGrid.Visible = false;
                
                for (int i =0; i<= ((TTGrid)PatientGrid).Rows.Count - 1; i++  )
                {
                    ((TTGrid)PatientGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    
                }
                
                
                
                
                
                //((TTGrid)TestGrid).Location = new Point(10,20);
                //((TTGrid)TestGrid).Size = new Size(739,379);
                
                ((TTGrid)TestGrid).Columns["PatientId"].Visible = true;
                ((TTGrid)TestGrid).Columns["PatientName"].Visible = true;
                
                for(int i = 0; i <= ((TTGrid)this.TestGrid).Rows.Count -1; i++ )
                {
                    ((TTGrid)this.TestGrid).Rows[i].Visible = true;
                }
                
                
                
                ((TTGrid)TestGrid).Refresh();
                
                ix = 0;
                
                
            }
            
            
        }
        
        
        
        public void ToProcedure()
        {
            if ( !(bool) this.CheckedTestControl())
            {
                MessageBox.Show("Procedure");
                return;
            }
            
         //   System.Diagnostics.Debugger.Break();
            for( int i=0; i<= ((TTGrid)this.TestGrid).Rows.Count - 1; i++ )
                
            {
                if( ((TTGrid)this.TestGrid).Rows[i].Visible == true )
                {
                    
                    if(  alistCheckedTest.Contains ( ((TTGrid)this.TestGrid).Rows[i].Cells[0].Value.ToString() ) == true )
                    {
                        
                        
                        ResRadiologyDepartment Department = null ;
                        ResRadiologyEquipment  Equipment = null ;
                        
                        if(((TTGrid)TestGrid).Rows[i].Cells["Department"].Value !=null)
                        {
                            if(  ((TTGrid)TestGrid).Rows[i].Cells["Department"].Value.GetType() == System.Type.GetType("System.Guid"))
                            {
                                TTObjectContext rcontext = new TTObjectContext(true);
                           
                                 //---------------QueryObeject--------------------- 
                                 // IList Dep = new  List<ResRadiologyDepartment>();
                                
                                 IList Dep = rcontext.QueryObjects("ResRadiologyDepartment", "OBJECTID = " + ConnectionManager.GuidToString((Guid) ((TTGrid)TestGrid).Rows[i].Cells["Department"].Value));
                                if(Convert.ToBoolean(Dep.Count))
                                {
                                    Department = (ResRadiologyDepartment)Dep[0];
                                }
                            }
                            else
                            {
                                Department = (ResRadiologyDepartment) ((TTGrid)TestGrid).Rows[i].Cells["Department"].Value;
                            }
                            
                            
                        }
                        
                        else
                        {
                            Department = null;
                        }
                        
                        if(((TTGrid)TestGrid).Rows[i].Cells["Equipment"].Value !=null)
                        {
                            if(  ((TTGrid)TestGrid).Rows[i].Cells["Equipment"].Value.GetType() == System.Type.GetType("System.Guid"))
                            {
                                TTObjectContext rcontext = new TTObjectContext(true);
                                
                                //---------------QueryObeject--------------------- 
                                // IList Equ = new  List<ResRadiologyEquipment>();
                                
                                
                                IList Equ = rcontext.QueryObjects("ResRadiologyEquipment", "OBJECTID = " + ConnectionManager.GuidToString((Guid) ((TTGrid)TestGrid).Rows[i].Cells["Equipment"].Value));
                                if(Convert.ToBoolean(Equ.Count))
                                {
                                    Equipment = (ResRadiologyEquipment)Equ[0];
                                }
                            }
                            else
                            {
                                Equipment = (ResRadiologyEquipment) ((TTGrid)TestGrid).Rows[i].Cells["Equipment"].Value;
                            }
                            
                            
                            
                        }
                        
                        else
                        {
                            Equipment = null;
                        }

                        // Static Context yüzünden kapatıldı
                        //   static   TTObjectContext   radtestcontext = new TTObjectContext(false);
                        //            RadiologyTest radx = new RadiologyTest(radtestcontext);

                        //radx.Department = Department;
                        //radx.Equipment = Equipment;
                        //radx.Description = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Description"].Value;
                        
                        //RadiologyTest RadTest = (RadiologyTest) this.GetRadiologyTest(((TTGrid)TestGrid).Rows[i].Cells["ObjectId"].Value.ToString());
                        

                        
                        //RadTest.ToProcedure(radx);
                        
                        
                        
                        
                        ((TTGrid)TestGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        ((TTGrid)TestGrid).Rows[i].ReadOnly = true;
                        alistSendTest.Add( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        alistCheckedTest.Remove( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        
                        //alistCheckedTest.Remove(i);
                        
                    }
                    
                }
            }
            
            ((TTGrid)TestGrid).Refresh();
            
            
            
            
        }
        
        public void ToResultEntry()
        {
            if ( !(bool) this.CheckedTestControl()){
                MessageBox.Show("ResultEntry");
                return;}
            
            for( int i=0; i<= ((TTGrid)this.TestGrid).Rows.Count - 1; i++ )
                
            {
                if( ((TTGrid)this.TestGrid).Rows[i].Visible == true )
                {
                    
                    if(  alistCheckedTest.Contains ( ((TTGrid)this.TestGrid).Rows[i].Cells[0].Value.ToString() ) == true )
                    {

                        // Static Context yüzünden kapatıldı
                        //radx.Description = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Description"].Value;
                        //radx.TechnicianNote = (string)  ((TTGrid)TestGrid).Rows[i].Cells["TechnicianNote"].Value;
                        //radx.Report = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Report"].Value;
                        
                        //RadiologyTest RadTest = (RadiologyTest) this.GetRadiologyTest(((TTGrid)TestGrid).Rows[i].Cells["ObjectId"].Value.ToString());
                    
                        
                        //RadTest.ToResultEntry(radx);
                        
                        ((TTGrid)TestGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        ((TTGrid)TestGrid).Rows[i].ReadOnly = true;
                        alistSendTest.Add( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        alistCheckedTest.Remove( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        
                    }
                }
            }
            
            ((TTGrid)TestGrid).Refresh();
            
            
            
            
        }
        
        
        
        
        
        public void ToApprove()
        {
            if ( !(bool) this.CheckedTestControl())
            {
                MessageBox.Show("Approve");
                return;
            }
            
            for( int i=0; i<= ((TTGrid)this.TestGrid).Rows.Count - 1; i++ )
                
            {
                if( ((TTGrid)this.TestGrid).Rows[i].Visible == true )
                {
                    
                    if(  alistCheckedTest.Contains ( ((TTGrid)this.TestGrid).Rows[i].Cells[0].Value.ToString() ) == true )
                    {
                        
                        RadiologyTest RadTest = (RadiologyTest) this.GetRadiologyTest(((TTGrid)TestGrid).Rows[i].Cells["ObjectId"].Value.ToString());
                        
                        RadTest.Description = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Description"].Value;
                        RadTest.Report = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Report"].Value;
                        RadTest.CurrentStateDefID = RadiologyTest.States.Approve;
                        RadTest.TestDate = DateTime.Now;
                        RadTest.ObjectContext.Save();
                        
                        ((TTGrid)TestGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        ((TTGrid)TestGrid).Rows[i].ReadOnly = true;
                        alistSendTest.Add( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        alistCheckedTest.Remove( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        
                        
                        
                    }
                }
            }
            
            
            
            
            
            
            
            
            
            
        }
        public void ToCompleted()
        {
            if ( !(bool) this.CheckedTestControl()){
                MessageBox.Show("Completed");
                return;}
            
            
            for( int i=0; i<= ((TTGrid)this.TestGrid).Rows.Count - 1; i++ )
                
            {
                if( ((TTGrid)this.TestGrid).Rows[i].Visible == true )
                {
                    
                    if(  alistCheckedTest.Contains ( ((TTGrid)this.TestGrid).Rows[i].Cells[0].Value.ToString() ) == true )
                    {
                        
                        RadiologyTest RadTest = (RadiologyTest) this.GetRadiologyTest(((TTGrid)TestGrid).Rows[i].Cells["ObjectId"].Value.ToString());
                        
                        RadTest.Description = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Description"].Value;
                        RadTest.Report = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Report"].Value;
                        RadTest.CurrentStateDefID = RadiologyTest.States.Completed;
                        RadTest.TestDate = DateTime.Now;
                        RadTest.ObjectContext.Save();
                        
                        ((TTGrid)TestGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        ((TTGrid)TestGrid).Rows[i].ReadOnly = true;
                        alistSendTest.Add( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        alistCheckedTest.Remove( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        
                        
                        
                        
                        
                    }
                }
            }
            
            
            
            
            
        }
        
        public void ToAppointment()
        {
            if ( !(bool) this.CheckedTestControl()){
                MessageBox.Show("Appointment");
                return;}
        }
        
        
        
        
        
        
        
        public void ToReject()
        {
            if ( !(bool) this.CheckedTestControl()){
                MessageBox.Show("Reject");
                return;}
            for( int i=0; i<= ((TTGrid)this.TestGrid).Rows.Count - 1; i++ )
                
            {
                if( ((TTGrid)this.TestGrid).Rows[i].Visible == true )
                {
                    
                    if(  alistCheckedTest.Contains ( ((TTGrid)this.TestGrid).Rows[i].Cells[0].Value.ToString() ) == true )
                    {
                        
                        RadiologyRejectReasonDefinition RadRejectReason = null;
                        
                        if(((TTGrid)TestGrid).Rows[i].Cells["RejectReason"].Value !=null)
                        {
                            if(  ((TTGrid)TestGrid).Rows[i].Cells["RejectReason"].Value.GetType() == System.Type.GetType("System.Guid"))
                            {
                                TTObjectContext rcontext = new TTObjectContext(true);
                                
                                
                                
                                 //---------------QueryObeject--------------------- 
                                 //IList Reject = new  List<RadiologyRejectReasonDefinition>();
                                
                                IList Reject = rcontext.QueryObjects("RadiologyRejectReasonDefinition", "OBJECTID = " + ConnectionManager.GuidToString((Guid) ((TTGrid)TestGrid).Rows[i].Cells["RejectReason"].Value));
                                
                                
                                
                                
                                if(Convert.ToBoolean(Reject.Count))
                                {
                                    RadRejectReason = (RadiologyRejectReasonDefinition)Reject[0];
                                }
                            }
                            else
                            {
                                RadRejectReason = (RadiologyRejectReasonDefinition) ((TTGrid)TestGrid).Rows[i].Cells["Department"].Value;
                            }
                            
                            
                        }
                        
                        else
                        {
                            MessageBox.Show("Red nedeni boş olamaz..");
                            break;
                            
                        }
                        
                        RadiologyTest RadTest = (RadiologyTest) this.GetRadiologyTest(((TTGrid)TestGrid).Rows[i].Cells["ObjectId"].Value.ToString());
                        
                        RadTest.RejectReason = RadRejectReason;
                        RadTest.Description = (string)  ((TTGrid)TestGrid).Rows[i].Cells["Description"].Value;
                        RadTest.TechnicianNote = (string)  ((TTGrid)TestGrid).Rows[i].Cells["TechnicianNote"].Value;
                        
                        
                        
                        RadTest.CurrentStateDefID = RadiologyTest.States.Reject;
                        RadTest.TestDate = DateTime.Now;
                        RadTest.ObjectContext.Save();
                        
                        ((TTGrid)TestGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                        ((TTGrid)TestGrid).Rows[i].ReadOnly = true;
                        alistSendTest.Add( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        alistCheckedTest.Remove( ((TTGrid) this.TestGrid).Rows[i].Cells[0].Value.ToString() );
                        
                        
                        
                        
                        
                        
                        
                    }
                }
            }
            
            
            
            
        }
        
#endregion RadiologyInformationSystemForm_Methods
    }
}