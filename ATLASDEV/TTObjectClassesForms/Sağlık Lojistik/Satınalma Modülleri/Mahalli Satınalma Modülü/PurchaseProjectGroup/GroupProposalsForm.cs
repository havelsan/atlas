
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
    /// Grup Teklifleri
    /// </summary>
    public partial class GroupProposalsForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region GroupProposalsForm_PreScript
    base.PreScript();
            
            for (int i = 0; i < GroupProposalsGrid.Rows.Count; i++)
            {
                GroupSumProposal ppg = (GroupSumProposal)GroupProposalsGrid.Rows[i].TTObject;
                
                if (ppg.Status == ProposalDetailStatusEnum.Best)
                {
                    ((TTGrid)GroupProposalsGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                }
                else if (ppg.Status == ProposalDetailStatusEnum.Second)
                {
                    ((TTGrid)GroupProposalsGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.PaleTurquoise;
                }
                else if (ppg.Status == ProposalDetailStatusEnum.Denied)
                {
                    ((TTGrid)GroupProposalsGrid).Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.RosyBrown;
                    ((TTGrid)GroupProposalsGrid).Rows[i].Cells["Status"].ReadOnly = true;
                }
            }
#endregion GroupProposalsForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region GroupProposalsForm_PostScript
    base.PostScript(transDef);
            
            int bestcnt = 0;
            int seccnt = 0;
            
            foreach(GroupSumProposal gsp in _PurchaseProjectGroup.GroupSumProposals)
            {
                if (gsp.CurrentStateDefID != GroupSumProposal.States.Cancelled)
                {
                    if (gsp.Status == ProposalDetailStatusEnum.Best)
                        bestcnt++;
                    if (gsp.Status == ProposalDetailStatusEnum.Second)
                        seccnt++;
                }
            }
            
            if (bestcnt > 1)
                throw new TTUtils.TTException(SystemMessage.GetMessage(1003));
            if (seccnt > 1)
                throw new TTUtils.TTException(SystemMessage.GetMessage(1002));
#endregion GroupProposalsForm_PostScript

            }
                }
}