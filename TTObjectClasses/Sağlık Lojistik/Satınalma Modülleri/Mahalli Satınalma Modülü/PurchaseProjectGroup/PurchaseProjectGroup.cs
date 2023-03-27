
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
    /// Mahalli Satınalmada İhale Tipi "Grup Toplam" İse, İHale Grupları İçin Kullanılan Sınıftır. Her Grup İçin Bir Adet Instance Yaratılır
    /// </summary>
    public  partial class PurchaseProjectGroup : TTObject
    {
        public partial class GetProjectGroups_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            
            base.PreUpdate();
            
            if(BestSupplier != null && SecondSupplier != null)
            {
                if(BestSupplier == SecondSupplier)
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(1001));
                }
            }

#endregion PreUpdate
        }

#region Methods
        public void FindBestAndSecondProposalDetail()
        {
            GroupSumProposal bestPd = null;
            GroupSumProposal secPd = null;
            foreach (GroupSumProposal gsp in GroupSumProposals)
            {
                if (gsp.TotalProposalPrice != null && gsp.TotalProposalPrice != 0)
                {
                    if (gsp.Status != ProposalDetailStatusEnum.Denied && gsp.CurrentStateDefID != GroupSumProposal.States.Cancelled)
                    {
                        if (bestPd == null)
                        {
                            bestPd = gsp;
                        }
                        else
                        {
                            if (gsp.TotalProposalPrice < bestPd.TotalProposalPrice)
                            {
                                secPd = bestPd;
                                bestPd = gsp;
                            }
                            else
                            {
                                if (secPd == null)
                                {
                                    secPd = gsp;
                                }
                                else
                                {
                                    if (gsp.TotalProposalPrice < secPd.TotalProposalPrice)
                                    {
                                        secPd = gsp;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (bestPd != null)
            {
                bestPd.Status = ProposalDetailStatusEnum.Best;
            }
            if (secPd != null)
            {
                secPd.Status = ProposalDetailStatusEnum.Second;
            }
        }
        
#endregion Methods

    }
}