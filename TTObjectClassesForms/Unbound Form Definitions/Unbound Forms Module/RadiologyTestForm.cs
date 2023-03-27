
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
    /// Radyoloji Test Formu
    /// </summary>
    public partial class RadiologyTestForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            cmdSendUsersToPACS.Click += new TTControlEventDelegate(cmdSendUsersToPACS_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdSendUsersToPACS.Click -= new TTControlEventDelegate(cmdSendUsersToPACS_Click);
            base.UnBindControlEvents();
        }

        private void cmdSendUsersToPACS_Click()
        {
#region RadiologyTestForm_cmdSendUsersToPACS_Click
   TTObjectContext oContext = new TTObjectContext(true);
            int count = 0;
            string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("HL7ENGINEALIVE",null);
            if(sysparam == "TRUE")
            {
                foreach (TTStorageManager.Security.TTUser u in TTUser.GetAllUsers())
                {
                    ResUser resUser = (ResUser)oContext.GetObject(new Guid(u.TTObjectID.ToString()),"ResUser");
                    bool hasDepartment = false;
                    if(resUser.UserResources.Count > 0)
                        hasDepartment = true;
                    
                    if(hasDepartment)
                    {
                        List<Guid> resUserIDs = new List<Guid>();
                        resUserIDs.Add(resUser.ObjectID);
                        try
                        {
                            //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.MediumPriority,"InternalTcpClient","HL7Remoting","SendHospitalMessageToEngine", null, resUserIDs,"M02","PACS");
                            //count += count;
                            //this.lblCount.Text = this.lblCount.Text + " " + count.ToString();
                        }
                        catch(Exception ex)
                        {
                            TTVisual.InfoBox.Show("Kullanıcı bilgisi PACS'a gönderilmedi! " + ex.Message, ex);
                        }
                    }
                }
            }
#endregion RadiologyTestForm_cmdSendUsersToPACS_Click
        }
    }
}