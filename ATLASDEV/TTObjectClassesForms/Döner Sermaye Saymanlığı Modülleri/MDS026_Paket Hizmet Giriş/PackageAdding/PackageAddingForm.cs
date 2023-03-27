
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
    /// Paket Hizmet Giriş
    /// </summary>
    public partial class PackageAddingForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            btnAddSPP.Click += new TTControlEventDelegate(btnAddSPP_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnAddSPP.Click -= new TTControlEventDelegate(btnAddSPP_Click);
            base.UnBindControlEvents();
        }

        private void btnAddSPP_Click()
        {
#region PackageAddingForm_btnAddSPP_Click
   if(_PackageAdding.PackageProcedureDefinition == null)
                InfoBox.Alert("Paket Hizmet seçiniz.", MessageIconEnum.WarningMessage);
            else
            {
                if (_PackageAdding.StartDate == null || _PackageAdding.EndDate == null)
                    InfoBox.Alert(SystemMessage.GetMessage(621), MessageIconEnum.WarningMessage);
                else
                {
                    if (Common.DateDiffV2(0, Convert.ToDateTime(_PackageAdding.EndDate), Convert.ToDateTime(_PackageAdding.StartDate), false) < 0)
                        InfoBox.Alert(SystemMessage.GetMessage(337), MessageIconEnum.WarningMessage);
                    else
                    {
                        _PackageAdding.AddSubactionPackageProcedures();
                    }
                }
            }
#endregion PackageAddingForm_btnAddSPP_Click
        }

        protected override void PreScript()
        {
#region PackageAddingForm_PreScript
    base.PreScript();
            if (_PackageAdding.CurrentStateDefID == PackageAdding.States.New)
            {
                // Tebliğ anlaşması açıksa veya tebliğ hizmeti varsa uyarı verilir ve paket eklemeye izin verilmez
                /*
                ProtocolDefinition bulletinProtocol = null;
                try
                {
                    Guid bulletinProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", ""));
                    bulletinProtocol = (ProtocolDefinition)_PackageAdding.ObjectContext.GetObject(bulletinProtocolGuid,"ProtocolDefinition");
                }
                catch
                {
                    throw new TTException(SystemMessage.GetMessage(229));
                }
                
                if(_PackageAdding.Episode.MyEpisodeProtocol() != null)
                {
                    if(_PackageAdding.Episode.MyEpisodeProtocol().Protocol == bulletinProtocol)
                        throw new TTException(SystemMessage.GetMessage(235));
                }
                else
                    throw new TTException(SystemMessage.GetMessage(622));
                */
                
                this.PackageSubEpisode.ListFilterExpression = "EPISODE.OBJECTID = '" +  _PackageAdding.Episode.ObjectID.ToString() + "'";
                ((ITTListBoxColumn)((ITTGridColumn)this.GridPackageProcedure.Columns["PSubEpisode"])).ListFilterExpression = "EPISODE.OBJECTID = '" +  _PackageAdding.Episode.ObjectID.ToString() + "'";
                
                this.cmdOK.Visible = false;
            }
#endregion PackageAddingForm_PreScript

            }
                }
}