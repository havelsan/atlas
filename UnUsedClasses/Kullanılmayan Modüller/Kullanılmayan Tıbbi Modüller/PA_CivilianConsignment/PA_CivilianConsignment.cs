
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
    /// Sivil Sevkli Kabul 
    /// </summary>
    public  partial class PA_CivilianConsignment : PatientAdmission
    {
        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();

#endregion PostUpdate
        }

        protected void PostTransition_DocumentApproval2Completed()
        {
            // From State : DocumentApproval   To State : Completed
#region PostTransition_DocumentApproval2Completed
            //this.ControlBulletinProtocol();
#endregion PostTransition_DocumentApproval2Completed
        }

        protected void PostTransition_DocumentApproval2Rejected()
        {
            // From State : DocumentApproval   To State : Rejected
#region PostTransition_DocumentApproval2Rejected
            // hasta kabul reddedilirse episode kapatılır.
            Episode.CloseEpisode();
#endregion PostTransition_DocumentApproval2Rejected
        }

        protected void UndoTransition_DocumentApproval2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DocumentApproval   To State : Rejected
#region UndoTransition_DocumentApproval2Rejected
            
            Episode.UndoCloseEpisode();
#endregion UndoTransition_DocumentApproval2Rejected
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            if(!IsSGKPatientAdmission)
            {
                if(Donor == false)//Acil kabullerde ve Donorlerde  sorulmasın
                {
                    string warning = "";
                    if(IdCardCopyTaken != true)
                        warning += "'Kimlik Belgesi Fotokopisi Alındı' bölümünün işaretli olması gerekir.\n";
                    if(ConsignmentDocumentTaken != true)
                        warning += "'Sevk Belgesi Alındı' bölümünün işaretli olması gerekir.\n";
                    if(DocumentDate == null)
                        warning += "'Sevk Evrak Tarihi' nin seçilmesi gerekir.\n";
                    if(string.IsNullOrEmpty(DocumentNumber) || DocumentNumber.Trim() == "0")
                        warning += "'Sevk Evrak Sayısı' nın girilmesi gerekir.\n";
                    if(!string.IsNullOrEmpty(warning))
                        throw new Exception(warning.Substring(0,warning.Length-1));
                }
            }
#endregion PostTransition_New2Completed
        }

#region Methods
        protected override void SetPatientGroup()
        {
    
        }
        
#endregion Methods
        

    }
}