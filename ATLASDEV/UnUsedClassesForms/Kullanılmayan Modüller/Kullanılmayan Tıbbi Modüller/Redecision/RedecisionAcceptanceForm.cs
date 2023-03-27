
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
    /// Zeyil(Ek Rapor)
    /// </summary>
    public partial class RedecisionAcceptanceForm : EpisodeActionForm
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
#region RedecisionAcceptanceForm_PreScript
    base.PreScript();          
 //                RedecisionMatterSliceAnectodeGrid MSAG = new RedecisionMatterSliceAnectodeGrid(_Redecision.ObjectContext);
//                MSAG.Anectode= "1";
//                MSAG.Slice= "2";
//                MSAG.Matter= "3";
//                _Redecision.MatterSliceAnectodes.Add(MSAG);
               // _Redecision.ReasonForExamination.Reason = "Deneme";
                ;
#endregion RedecisionAcceptanceForm_PreScript

            }
                }
}