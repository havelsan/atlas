
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
    public partial class DoctorPerformance : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnPOUnCheckAll.Click += new TTControlEventDelegate(btnPOUnCheckAll_Click);
            btnPOReject.Click += new TTControlEventDelegate(btnPOReject_Click);
            btnPOCheckAll.Click += new TTControlEventDelegate(btnPOCheckAll_Click);
            btnPOList.Click += new TTControlEventDelegate(btnPOList_Click);
            btnPLList.Click += new TTControlEventDelegate(btnPLList_Click);
            SendDP.Click += new TTControlEventDelegate(SendDP_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnPOUnCheckAll.Click -= new TTControlEventDelegate(btnPOUnCheckAll_Click);
            btnPOReject.Click -= new TTControlEventDelegate(btnPOReject_Click);
            btnPOCheckAll.Click -= new TTControlEventDelegate(btnPOCheckAll_Click);
            btnPOList.Click -= new TTControlEventDelegate(btnPOList_Click);
            btnPLList.Click -= new TTControlEventDelegate(btnPLList_Click);
            SendDP.Click -= new TTControlEventDelegate(SendDP_Click);
            base.UnBindControlEvents();
        }

        private void btnPOUnCheckAll_Click()
        {
#region DoctorPerformance_btnPOUnCheckAll_Click
   foreach (ITTGridRow row in this.grdPerformanceApprove.Rows)
                row.Cells[gcPOCheck.Name].Value = false;
#endregion DoctorPerformance_btnPOUnCheckAll_Click
        }

        private void btnPOReject_Click()
        {
#region DoctorPerformance_btnPOReject_Click
   foreach (ITTGridRow row in this.grdPerformanceApprove.Rows)
            {
                if(row.Cells[gcPOCheck.Name].Value != null && row.Cells[gcPOCheck.Name].Value.Equals(true))
                    row.Cells[gcPOCommitteePoint.Name].Value = "0";
            }
            
            GetTotalCommitteePoint();
#endregion DoctorPerformance_btnPOReject_Click
        }

        private void btnPOCheckAll_Click()
        {
#region DoctorPerformance_btnPOCheckAll_Click
   foreach (ITTGridRow row in this.grdPerformanceApprove.Rows)
                row.Cells[gcPOCheck.Name].Value = true;
#endregion DoctorPerformance_btnPOCheckAll_Click
        }

        private void btnPOList_Click()
        {
#region DoctorPerformance_btnPOList_Click
   if(PODoctor.SelectedObject == null)
            {
                InfoBox.Show("Doktor seçiniz.", MessageIconEnum.WarningMessage);
                return;
            }
            
            grdPerformanceApprove.Rows.Clear();
            performanceDetailList.Clear();
            int totalPoint = 0;
            
            List<PerformanceDetail> performancePointList = GetPerformancePointsByDoctor((ResUser)PODoctor.SelectedObject);
            
            foreach (PerformanceDetail data in performancePointList)
            {
                PerformanceDetail performanceDetail = new PerformanceDetail(data.ObjectID, data.Date, data.ProcedureCode, data.Amount, data.Point, data.Description);
                performanceDetailList.Add(performanceDetail);
                totalPoint += performanceDetail.Point;
            }
            
            foreach (PerformanceDetail performanceDetail in performanceDetailList)
            {
                ITTGridRow newRow = grdPerformanceApprove.Rows.Add();
                newRow.Cells[gcPOObjectID.Name].Value = performanceDetail.ObjectID;
                newRow.Cells[gcPODate.Name].Value = performanceDetail.Date;
                newRow.Cells[gcPOUniqueRefNo.Name].Value = performanceDetail.UniqueRefNo;
                newRow.Cells[gcPONameSurname.Name].Value = performanceDetail.NameSurname;
                newRow.Cells[gcPOProtocolNo.Name].Value = performanceDetail.ProtocolNo;
                newRow.Cells[gcPOActionID.Name].Value = performanceDetail.ActionID;
                newRow.Cells[gcPOProcedureCode.Name].Value = performanceDetail.ProcedureCode;
                newRow.Cells[gcPOProcedureName.Name].Value = performanceDetail.ProcedureName;
                newRow.Cells[gcPOAmount.Name].Value = performanceDetail.Amount;
                newRow.Cells[gcPOPoint.Name].Value = performanceDetail.Point;
                newRow.Cells[gcPODescription.Name].Value = performanceDetail.Description;
            }
           
            POTotalPoint.Text = totalPoint.ToString();
            POCommitteeTotalPoint.Text = totalPoint.ToString();
#endregion DoctorPerformance_btnPOList_Click
        }

        private void btnPLList_Click()
        {
#region DoctorPerformance_btnPLList_Click
   if(PLDoctor.SelectedObject == null)
            {
                InfoBox.Show("Doktor seçiniz.", MessageIconEnum.WarningMessage);
                return;
            }
            
            grdPerformanceList.Rows.Clear();
            performanceList.Clear();
            performanceDetailList.Clear();
            int totalPoint = 0;
           
            List<PerformanceDetail> performancePointList = GetPerformancePointsByDoctor((ResUser)PLDoctor.SelectedObject);
            
            foreach (PerformanceDetail data in performancePointList)
            {
                PerformanceDetail performanceDetail = new PerformanceDetail(data.ObjectID, data.Date, data.ProcedureCode, data.Amount, data.Point, data.Description);
                performanceDetailList.Add(performanceDetail);

                bool found = false;
                foreach (Performance performance in performanceList)
                {
                    if (performance.ProcedureCode == data.ProcedureCode)
                    {
                        performance.Amount += performanceDetail.Amount;
                        performance.Point += performanceDetail.Point;
                        found = true;
                        break;
                    }
                }

                if(!found)
                    performanceList.Add(new Performance(data.ObjectID, data.ProcedureCode, data.Amount, data.Point));
                
                totalPoint += performanceDetail.Point;
            }
            
            if(chkPLDetailedList.Value == true)
            {
                foreach (PerformanceDetail performanceDetail in performanceDetailList)
                {
                    ITTGridRow newRow = grdPerformanceList.Rows.Add();
                    newRow.Cells[gcPLObjectID.Name].Value = performanceDetail.ObjectID;
                    newRow.Cells[gcPLDate.Name].Value = performanceDetail.Date;
                    newRow.Cells[gcPLUniqueRefNo.Name].Value = performanceDetail.UniqueRefNo;
                    newRow.Cells[gcPLNameSurname.Name].Value = performanceDetail.NameSurname;
                    newRow.Cells[gcPLProtocolNo.Name].Value = performanceDetail.ProtocolNo;
                    newRow.Cells[gcPLActionID.Name].Value = performanceDetail.ActionID;
                    newRow.Cells[gcPLProcedureCode.Name].Value = performanceDetail.ProcedureCode;
                    newRow.Cells[gcPLProcedureName.Name].Value = performanceDetail.ProcedureName;
                    newRow.Cells[gcPLAmount.Name].Value = performanceDetail.Amount;
                    newRow.Cells[gcPLPoint.Name].Value = performanceDetail.Point;
                    newRow.Cells[gcPLDescription.Name].Value = performanceDetail.Description;
                }
                grdPerformanceList.Columns["gCPLDate"].Visible = true;
                grdPerformanceList.Columns["gCPLUniqueRefNo"].Visible = true;
                grdPerformanceList.Columns["gCPLNameSurname"].Visible = true;
                grdPerformanceList.Columns["gCPLProtocolNo"].Visible = true;
                grdPerformanceList.Columns["gCPLActionID"].Visible = true;
                grdPerformanceList.Columns["gCPLDescription"].Visible = true;
            }
            else
            {
                foreach (Performance performance in performanceList)
                {
                    ITTGridRow newRow = grdPerformanceList.Rows.Add();
                    newRow.Cells[gcPLProcedureCode.Name].Value = performance.ProcedureCode;
                    newRow.Cells[gcPLProcedureName.Name].Value = performance.ProcedureName;
                    newRow.Cells[gcPLAmount.Name].Value = performance.Amount;
                    newRow.Cells[gcPLPoint.Name].Value = performance.Point;
                }
                grdPerformanceList.Columns["gCPLDate"].Visible = false;
                grdPerformanceList.Columns["gCPLUniqueRefNo"].Visible = false;
                grdPerformanceList.Columns["gCPLNameSurname"].Visible = false;
                grdPerformanceList.Columns["gCPLProtocolNo"].Visible = false;
                grdPerformanceList.Columns["gCPLActionID"].Visible = false;
                grdPerformanceList.Columns["gCPLDescription"].Visible = false;
            }
            
            PLTotalPoint.Text = totalPoint.ToString();
            
            /*
            foreach (ITTGridRow row in this.grdPerformanceList.Rows)
            {
                if (row.Cells[gcPLPoint.Name].Value != null && !string.IsNullOrEmpty(row.Cells[gcPLPoint.Name].Value.ToString()))
                    totalPoint += Convert.ToUInt16(row.Cells[gcPLPoint.Name].Value.ToString());
            }
            */
#endregion DoctorPerformance_btnPLList_Click
        }

        private void SendDP_Click()
        {
            #region DoctorPerformance_SendDP_Click

            //TTObjectContext objectContext = new TTObjectContext(false);

            //InvoiceInclusionMaster IIM = objectContext.GetObject(new Guid("1b806182-ffb9-4e3c-8d7a-d9c571458332"), typeof(InvoiceInclusionMaster)) as InvoiceInclusionMaster;
            //ProcedureDefinition pre = objectContext.GetObject(new Guid("4cdb02d3-9422-4a4b-a672-989a84c50944"), typeof(ProcedureDefinition)) as ProcedureDefinition;
            //SubEpisodeProtocol sep = objectContext.GetObject(new Guid("c10b54a9-6913-45c0-8193-3445e0087dad"), typeof(SubEpisodeProtocol)) as SubEpisodeProtocol;


            //sep.ArrangeAllTrxs();

            //objectContext.Save();

            //IIM.GetResultForSingleTrx(pre);

            SendToDoctorPerformance.SendAllDPs();
            #endregion DoctorPerformance_SendDP_Click
        }

#region DoctorPerformance_Methods
        protected override void OnLoad(EventArgs e)
        {
            if (Common.CurrentUser.IsSuperUser == false)
            {
                if (Common.CurrentUser.HasRole(Common.DoctorPerformanceApproveUserRoleID))
                {
                    tabPerformance.TabPages.Remove(tpList);
                    tabPerformance.TabPages.Remove(tpProcedureEntry);
                }
                else
                {
                    if(Common.CurrentResource.TakesPerformanceScore != true)
                    {
                        InfoBox.Show("Performans Puanı alan bir kullanıcı olarak tanımlanmadığınız için Doktor Performans formu açılamamaktadır.", MessageIconEnum.WarningMessage);
                        Close();
                    }
                    tabPerformance.TabPages.Remove(tpApproval);
                }
            }
            PLDoctor.SelectedObject = Common.CurrentResource;
            PLDoctor.Enabled = false;
        }
        
        public class Performance
        {
            public string ProcedureCode;
            public string ProcedureName;
            public int Amount;
            public int Point;

            public Performance(string objectID, string procedureCode, int amount, int point)
            {
                ProcedureCode = procedureCode;
                Amount = amount;
                Point = point;

                TTObjectContext objectContext = new TTObjectContext(true);
                SubActionProcedure subActionProcedure = objectContext.GetObject(new Guid(objectID), typeof(SubActionProcedure)) as SubActionProcedure;

                if (subActionProcedure != null)
                    ProcedureName = subActionProcedure.ProcedureObject.Name;
            }

            public Performance(string objectID, DateTime date, string procedureCode, int amount, int point, string description)
            {
            }
        }

        public class PerformanceDetail : Performance
        {
            public string ObjectID;
            public DateTime Date;
            public string UniqueRefNo;
            public string NameSurname;
            public string ProtocolNo;
            public string ActionID;
            public string Description;

            public PerformanceDetail(string objectID, DateTime date, string procedureCode, int amount, int point, string description) : base(objectID, date, procedureCode, amount, point, description)
            {
                ObjectID = objectID;
                Date = date;
                ProcedureCode = procedureCode;
                Amount = amount;
                Point = point;
                Description = description;

                TTObjectContext objectContext = new TTObjectContext(true);
                SubActionProcedure subActionProcedure = objectContext.GetObject(new Guid(ObjectID), typeof(SubActionProcedure)) as SubActionProcedure;

                if(subActionProcedure != null)
                {
                    ProtocolNo = subActionProcedure.Episode.HospitalProtocolNo.ToString();
                    UniqueRefNo = subActionProcedure.Episode.Patient.UniqueRefNo.ToString();
                    NameSurname = subActionProcedure.Episode.Patient.FullName;
                    ProcedureName = subActionProcedure.ProcedureObject.Name;
                    
                    SubactionProcedureFlowable spFlowable = subActionProcedure as SubactionProcedureFlowable;
                    if(spFlowable != null)
                        ActionID = spFlowable.ID.ToString();
                    else
                        ActionID = subActionProcedure.EpisodeAction.ID.ToString();
                }
            }
        }
        
        List<Performance> performanceList = new List<Performance>();
        List<PerformanceDetail> performanceDetailList = new List<PerformanceDetail>();
        
        // Doktorun performans puanlarını getiren metod
        public List<PerformanceDetail> GetPerformancePointsByDoctor(ResUser doctor)
        {
            List<PerformanceDetail> performancePointList = new List<PerformanceDetail>(); // Performans programından gelecek veri
            
            performancePointList.Add(new PerformanceDetail("f5ee9e13-6c6e-41ea-8559-8733696aac68", Common.RecTime(), "520030", 1, 30, "Açıklama 1"));
            performancePointList.Add(new PerformanceDetail("50b3f80e-ee91-4298-ad21-a5c376d7fdb2", Common.RecTime(), "520040", 1, 40, null));
            performancePointList.Add(new PerformanceDetail("d0502782-a964-4c16-938b-1ce5430ebd76", Common.RecTime(), "520050", 1, 50, null));
            performancePointList.Add(new PerformanceDetail("34c1b02a-00ad-4c32-9fca-3438f61337e9", Common.RecTime(), "520060", 1, 60, "Açıklama 2"));
            performancePointList.Add(new PerformanceDetail("f5ee9e13-6c6e-41ea-8559-8733696aac68", Common.RecTime(), "520030", 1, 30, "Açıklama 3"));
            performancePointList.Add(new PerformanceDetail("50b3f80e-ee91-4298-ad21-a5c376d7fdb2", Common.RecTime(), "520040", 1, 40, null));
            performancePointList.Add(new PerformanceDetail("d0502782-a964-4c16-938b-1ce5430ebd76", Common.RecTime(), "520050", 1, 50, null));
            performancePointList.Add(new PerformanceDetail("34c1b02a-00ad-4c32-9fca-3438f61337e9", Common.RecTime(), "520070", 1, 60, null));
            
            return performancePointList;
        }
        
        public void GetTotalCommitteePoint()
        {
            int totalCommitteePoint = 0;
            
            foreach (ITTGridRow row in this.grdPerformanceApprove.Rows)
            {
                if(row.Cells[gcPOCommitteePoint.Name].Value != null)
                    totalCommitteePoint += Convert.ToInt32(row.Cells[gcPOCommitteePoint.Name].Value);
                else
                    totalCommitteePoint += Convert.ToInt32(row.Cells[gcPOPoint.Name].Value);
            }
            
            POCommitteeTotalPoint.Text = totalCommitteePoint.ToString();
        }
        
#endregion DoctorPerformance_Methods
    }
}