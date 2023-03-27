
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
    public partial class SutRuleCheckResultsForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            btnCancel.Click += new TTControlEventDelegate(btnCancel_Click);
            btnContinue.Click += new TTControlEventDelegate(btnContinue_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnCancel.Click -= new TTControlEventDelegate(btnCancel_Click);
            btnContinue.Click -= new TTControlEventDelegate(btnContinue_Click);
            base.UnBindControlEvents();
        }

        private void btnCancel_Click()
        {
#region SutRuleCheckResultsForm_btnCancel_Click
   // vazgeç ile istek yapma işlemi gerçekleştirilmeyecek
            this.DialogResult = DialogResult.Cancel;
            this.Close();
#endregion SutRuleCheckResultsForm_btnCancel_Click
        }

        private void btnContinue_Click()
        {
#region SutRuleCheckResultsForm_btnContinue_Click
   this.DialogResult = DialogResult.Ignore;
            this.Close();
#endregion SutRuleCheckResultsForm_btnContinue_Click
        }

#region SutRuleCheckResultsForm_Methods
        private TTUtils.Entities.RuleViolateMessageDto[] _ruleViolateMessages;
        public TTUtils.Entities.RuleViolateMessageDto[] RuleViolateMessages
        {
            get
            {
                return _ruleViolateMessages;
            }

            set
            {
                _ruleViolateMessages = value;
            }
        }

        private bool _blockRequest;
        public bool BlockRequest
        {
            get
            {
                return _blockRequest;
            }
            set
            {
                _blockRequest = value;
            }
        }

        private void LoadMessages()
        {
            if (!EnumerableHelper.Any(RuleViolateMessages))
                return;

            this.grdResults.Rows.Clear();

            foreach (TTUtils.Entities.RuleViolateMessageDto message in RuleViolateMessages)
            {
                ITTGridRow gridRow = this.grdResults.Rows.Add();
                
                ITTGridCell cellMessage = gridRow.Cells["dgvcMessage"];
                cellMessage.Value = message.Message;

                if (EnumerableHelper.Any(message.Icd10List))
                {
                    ITTGridCell cellDiagList = gridRow.Cells["dgvcDiagList"];
                    cellDiagList.Value = string.Join("; ", message.Icd10List);
                }
                
            }

            btnContinue.Enabled = true;
            if (BlockRequest == true)
            {
                btnContinue.Enabled = false;
            }

        }
        
        [System.ComponentModel.EditorBrowsableAttribute()]
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            btnContinue.Enabled = true;

            LoadMessages();
        }
        
#endregion SutRuleCheckResultsForm_Methods
    }
}