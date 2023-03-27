
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
    /// Patoloji İş Listesi
    /// </summary>
    public partial class PatWLCriteriaForm : EpisodeActionWLCriteriaForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

#region PatWLCriteriaForm_Methods
        public override void OnSave()
        {
            try
            {
                base.OnSave();
                this.SaveCriteria("MATPRTNOSTRING","System.String",MaterialProtocolID.Text);
                //SPECIAL PROCEDURES
                string spValue = "";
                if (this.chkSpecialProcedure.Value == true)
                    spValue = this.chkSpecialProcedure.Value.ToString();
                else
                    spValue = "";
                this.SaveCriteria("HASSPECIALPROCEDURES","System.Boolean",spValue);
                
                if(this.chkOnlyAuthorizedUser.Value == true)
                {
                    this.SaveCriteria("RESPONSIBLEDOCTOR","System.String",Common.CurrentResource.ObjectID.ToString());
                }
                else
                {
                    CriteriaValue crValUser = this.GetCriteriaValue("RESPONSIBLEDOCTOR");
                    CriteriaDefinition pDef = this.GetCriteriaDefinition("RESPONSIBLEDOCTOR");
                    if(crValUser != null && pDef != null) pDef.CriteriaValues.Remove(crValUser);
                }
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            CriteriaValue crValNo = this.GetCriteriaValue("MATPRTNOSTRING");
            if(crValNo != null && !string.IsNullOrEmpty(crValNo.Value))
            {
                try
                {
                    MaterialProtocolID.Text = crValNo.Value;
                }
                catch(Exception ex)
                {
                    InfoBox.Show(ex);
                }
            }
            this.chkSpecialProcedure.Value = false;
            CriteriaValue crValSpecialProcedures = this.GetCriteriaValue("HASSPECIALPROCEDURES");
            if(crValSpecialProcedures != null)
            {
                if(crValSpecialProcedures.Value == "True")
                    this.chkSpecialProcedure.Value = true;
                else
                    this.chkSpecialProcedure.Value = false;
            }
            else
                this.chkSpecialProcedure.Value = false;
        }
        
        public override IList ExecuteNQL(TTObjectContext context, DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true && String.IsNullOrEmpty(this.MaterialProtocolID.Text) == true)
                return Pathology.WorkListNQL(context, dtStart, dtEnd, sExpression);
            else
                return Pathology.GetByWLFilterExpression(context, sExpression);
        }
        
        public override IList ExecuteReportNQL(DateTime dtStart, DateTime dtEnd, string sExpression)
        {
            if(String.IsNullOrEmpty(this.ActionID.Text) == true && String.IsNullOrEmpty(this.MaterialProtocolID.Text) == true)
                return Pathology.GetByPatTestWorklistDateReport(dtStart, dtEnd, sExpression);
            else
                return Pathology.GetByPatTestFilterExpressionReport(sExpression);
        }
        
        public override IList ExecuteReportNQL(string sExpression)
        {
            return Pathology.GetByPatTestFilterExpressionReport(sExpression);
        }
        
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                
            }
            return base.ProcessDialogKey(keyData);
        }
        
        // Get a handle to an application window.
        [DllImport("USER32.DLL",CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        
        //Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter)
            {
                if(this.ActiveControl.Name == "MaterialProtocolID")
                {
                    TTTextBox txtMatPrt = (TTTextBox)this.ActiveControl;
                    {
                        string MatPrtNo = txtMatPrt.Text;
                        txtMatPrt.SelectAll();
                    }
                }
                
                IntPtr Handle = FindWindow("TTHospital","WorkListForm");
                
                SetForegroundWindow(Handle);
                SendKeys.SendWait("{F12}");
                SendKeys.SendWait("{ENTER}");
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLostFocus(EventArgs e)
        {
            foreach(Control control in this.Controls)
            {
                if(control.Name == "MaterialProtocolID")
                {
                    control.Focus();
                }
            }
            base.OnLostFocus(e);
        }
        
#endregion PatWLCriteriaForm_Methods
    }
}