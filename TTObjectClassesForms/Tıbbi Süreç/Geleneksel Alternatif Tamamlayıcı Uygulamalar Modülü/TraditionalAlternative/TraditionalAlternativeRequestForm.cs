
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
    /// Geleneksel Alternatif Tamamlayıcı Uygulamalar
    /// </summary>
    public partial class TraditionalAlternativeRequestForm : EpisodeActionForm
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
#region TraditionalAlternativeRequestForm_PreScript
    base.PreScript();
            this.SetProcedureDoctorAsCurrentResource();
            //this.SetProcedureDoctorListFilter();
            #endregion TraditionalAlternativeRequestForm_PreScript

        }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region TraditionalAlternativeRequestForm_PostScript
    base.PostScript(transDef);
    if (this._TraditionalAlternative.TraditionalAlternativeProcedures.Count < 1)
    {
        throw new Exception("Alternatif Tamamlayıcı Uygulama bilgisini seçmediniz.");
    }

         //   this._TraditionalAlternative.TurnMyAccountTransactionsToPatientShare();
#endregion TraditionalAlternativeRequestForm_PostScript

            }
            
#region TraditionalAlternativeRequestForm_Methods
        protected void SetProcedureDoctorListFilter()
        {
            if ((TTObjectClasses.SystemParameter.GetParameterValue("MANIPULATIONREQUESTDOCTORFILTER", "FALSE") == "TRUE"))
            {
                TTObjectContext context = new TTObjectContext(true);
                string filterString = "OBJECTID IN (''";

                IList userList = ResUser.GetResUserByUserTypeAndResource(context, UserTypeEnum.Doctor, this._EpisodeAction.MasterResource.ObjectID);
                foreach (ResUser user in userList)
                {
                    filterString += " ,'" + user.ObjectID.ToString() + "'";
                }
                filterString += ")";
                ((ITTObjectListBox)ProcedureDoctor).ListFilterExpression = filterString;
            }
        }
        
#endregion TraditionalAlternativeRequestForm_Methods
    }
}