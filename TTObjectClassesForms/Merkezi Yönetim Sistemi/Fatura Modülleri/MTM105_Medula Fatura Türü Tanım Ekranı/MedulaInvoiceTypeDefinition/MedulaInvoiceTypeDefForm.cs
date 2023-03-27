
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
    /// Medula Fatura Türü Tanım Ekranı
    /// </summary>
    public partial class MedulaInvoiceTypeDefForm : TerminologyManagerDefForm
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
#region MedulaInvoiceTypeDefForm_PreScript
    base.PreScript();
#endregion MedulaInvoiceTypeDefForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region MedulaInvoiceTypeDefForm_ClientSidePreScript
    base.ClientSidePreScript();
#endregion MedulaInvoiceTypeDefForm_ClientSidePreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region MedulaInvoiceTypeDefForm_PostScript
    base.PostScript(transDef);
#endregion MedulaInvoiceTypeDefForm_PostScript

            }
                }
}