
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
    /// Üç Uzman Tabip İmzalı Rapor
    /// </summary>
    public partial class HCTSRequestForm : EpisodeActionForm
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
#region HCTSRequestForm_PreScript
    base.PreScript();
            this._HealthCommitteeWithThreeSpecialist.CheckForDiagnosis();

            this.ttobjectlistboxDepartment.SelectedObjectID = this._HealthCommitteeWithThreeSpecialist.MasterResource.ObjectID;
#endregion HCTSRequestForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region HCTSRequestForm_PostScript
    base.PostScript(transDef);

            //1.uzman doktor authorizedUser olarak ekleniyor
            AuthorizedUser pAUser = new AuthorizedUser(this._HealthCommitteeWithThreeSpecialist.ObjectContext);
            pAUser.Action = this._HealthCommitteeWithThreeSpecialist;
            pAUser.User = Common.CurrentResource;
            this._HealthCommitteeWithThreeSpecialist.AuthorizedUsers.Add(pAUser);
#endregion HCTSRequestForm_PostScript

            }
                }
}