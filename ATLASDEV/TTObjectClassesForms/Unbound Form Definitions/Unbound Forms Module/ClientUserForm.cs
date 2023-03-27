
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
    /// New Unbound Form
    /// </summary>
    public partial class ClientUser : TTUnboundForm
    {
#region ClientUser_Methods
        public static class CurrentUser
        {

            public static ArrayList InPatientUserResources;
            public static ArrayList OutPatientUserResources;
            public static ArrayList SecMasterUserResources;
            public static ResUser User;

            static CurrentUser()
            {
                User = TTStorageManager.Security.TTUser.CurrentUser.UserObject as ResUser;
                TTObjectContext context = new TTObjectContext(true);

                InPatientUserResources = new ArrayList();
                OutPatientUserResources = new ArrayList();
                SecMasterUserResources = new ArrayList();

                if (User != null)
                {
                    foreach (UserResource userResource in User.UserResources)
                    {

                        switch (userResource.Resource.EnabledType)
                        {
                            case ResourceEnableType.BothInpatientAndOutPatient:
                                InPatientUserResources.Add(userResource.Resource);
                                OutPatientUserResources.Add(userResource.Resource);
                                break;
                            case ResourceEnableType.InPatient:
                                InPatientUserResources.Add(userResource.Resource);
                                break;
                            case ResourceEnableType.OutPatient:
                                OutPatientUserResources.Add(userResource.Resource);
                                break;
                            case ResourceEnableType.Secmaster:
                                SecMasterUserResources.Add(userResource.Resource);
                                break;
                        }

                    }
                }
            }
        }
        
#endregion ClientUser_Methods
    }
}