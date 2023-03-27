
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
    public partial class PathologyTestReportForm 
    {
        //TODO ASLI Formlar Revize edilecek
        //        override protected void BindControlEvents()
        //        {
        //            base.BindControlEvents();
        //        }

        //        override protected void UnBindControlEvents()
        //        {
        //            base.UnBindControlEvents();
        //        }

        //        protected override void PreScript()
        //        {
        //#region PathologyTestReportForm_PreScript
        //    base.PreScript();
        //            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["BaseTreatmentMaterial"],(ITTGridColumn)this.GridPathologyMaterials.Columns["Material"]);

        //            foreach(ITTTabPage tabPage in TabPathologyProcedure.TabPages)
        //                if(tabPage.Visible == false)
        //                    TabPathologyProcedure.HideTabPage(tabPage);

        //            foreach(ITTTabPage tabPage in TABExtraInformations.TabPages)
        //                if(tabPage.Visible == false)
        //                    TABExtraInformations.HideTabPage(tabPage);



        //             if(this.RemoteSpecialDoctor.Text!= null )
        //             {
        //                if(this.RemoteSpecialDoctor.Text!="")

        //                {
        //                      this.RemoteSpecialDoctor.Visible = true;
        //                    this.labelRemoteSpecialDoctor.Visible =true;
        //                }
        //                 else
        //                {
        //                    this.RemoteSpecialDoctor.Visible = false;
        //                    this.labelRemoteSpecialDoctor.Visible = false;
        //                }
        //             }
        //              this.SetProcedureDoctorAsCurrentResource();
        //#endregion PathologyTestReportForm_PreScript

        //            }
    }
}