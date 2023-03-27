
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
    public partial class SOSFarmaTestForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton1.Click += new TTControlEventDelegate(ttbutton1_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton1.Click -= new TTControlEventDelegate(ttbutton1_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton1_Click()
        {
#region SOSFarmaTestForm_ttbutton1_Click
   TTObjectContext context = new TTObjectContext(true);
            SOSFarmaXXXXXX sos = new SOSFarmaXXXXXX(context);
            List<TTObject> updatedObject =  sos.FetchSOSFarma();

            List<Sites> targetSites = new List<Sites>();
            foreach (KeyValuePair<Guid, Sites> site in Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST)
            {
                if (site.Key != Sites.SiteMerkezSagKom)
                    targetSites.Add(site.Value);
            }

            foreach (TTObject obj in updatedObject)
            {
                if(obj is DrugDefinition)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((DrugDefinition)obj, targetSites);
                }

                if (obj is SOSUrunBilgisi )
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((SOSUrunBilgisi)obj, targetSites);
                }

                if (obj is DrugATC)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((DrugATC)obj, targetSites);
                }

                if (obj is SOSUrunAtc)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((SOSUrunAtc)obj, targetSites);
                }

                if (obj is SOSUrunFiyat)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((SOSUrunFiyat)obj, targetSites);
                }

                if (obj is SOSUrunEtkenMadde)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((SOSUrunEtkenMadde)obj, targetSites);
                }

                if (obj is DrugActiveIngredient)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((DrugActiveIngredient)obj, targetSites);
                }

                if (obj is MaterialPrice)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((MaterialPrice)obj, targetSites);
                }

                if (obj is PricingDetailDefinition)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((PricingDetailDefinition)obj, targetSites);
                }

                if (obj is SOSRpIlacProspektus)
                {
                    TerminologyManagerDef.RunSendWithTerminologyManagerDefV2((SOSRpIlacProspektus)obj, targetSites);
                }
            }
#endregion SOSFarmaTestForm_ttbutton1_Click
        }
    }
}