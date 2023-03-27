
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
    public partial class AnnouncementDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            cmdAppendAll.Click += new TTControlEventDelegate(cmdAppendAll_Click);
            cmdAppendAllTypes.Click += new TTControlEventDelegate(cmdAppendAllTypes_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdAppendAll.Click -= new TTControlEventDelegate(cmdAppendAll_Click);
            cmdAppendAllTypes.Click -= new TTControlEventDelegate(cmdAppendAllTypes_Click);
            base.UnBindControlEvents();
        }

        private void cmdAppendAll_Click()
        {
#region AnnouncementDefinitionForm_cmdAppendAll_Click
   _AnnouncementDefinition.AnnouncementHospitals.Clear();
            foreach (KeyValuePair<Guid, Sites> kp in Sites.AllActiveSites)
            {
                AnnouncementHospital announcementHospital = new AnnouncementHospital(_AnnouncementDefinition.ObjectContext);
                announcementHospital.AnnouncementDefinition = _AnnouncementDefinition;
                announcementHospital.Site = (Sites)kp.Value;
            }
#endregion AnnouncementDefinitionForm_cmdAppendAll_Click
        }

        private void cmdAppendAllTypes_Click()
        {
#region AnnouncementDefinitionForm_cmdAppendAllTypes_Click
   _AnnouncementDefinition.AnnouncementUserTypes.Clear();

            Array tValues = Enum.GetValues(typeof(UserTypeEnum));
            foreach (UserTypeEnum value in Enum.GetValues(typeof(UserTypeEnum)))
            {
                AnnouncementUserType type = new AnnouncementUserType(_AnnouncementDefinition.ObjectContext);
                type.AnnouncementDefinition = _AnnouncementDefinition;
                type.UserType = value;
            }
#endregion AnnouncementDefinitionForm_cmdAppendAllTypes_Click
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region AnnouncementDefinitionForm_PostScript
    base.PostScript(transDef);

//            if (_AnnouncementDefinition.AnnouncementHospitals.Count == 0)
//                throw new TTUtils.TTException("En az bir saha seçmelisiniz!");
//            
//            if (_AnnouncementDefinition.AnnouncementUserTypes.Count == 0)
//                throw new TTUtils.TTException("En az bir kullanıcı grubu seçmelisiniz!");
#endregion AnnouncementDefinitionForm_PostScript

            }
                }
}