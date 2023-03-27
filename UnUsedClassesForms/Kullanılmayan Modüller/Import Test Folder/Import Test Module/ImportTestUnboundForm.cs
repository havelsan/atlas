
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
    public partial class ImportTestUnboundForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttbutton2.Click += new TTControlEventDelegate(ttbutton2_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttbutton2.Click -= new TTControlEventDelegate(ttbutton2_Click);
            base.UnBindControlEvents();
        }

        private void ttbutton2_Click()
        {
#region ImportTestUnboundForm_ttbutton2_Click
   TTObjectContext roContext = new TTObjectContext(true);
            try
            {
                IList iaList = InpatientAdmission.GetDischargedInPatientAdmissions(roContext);
                int i = 0;
                foreach(InpatientAdmission iaReadOnly in iaList)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    try
                    {    
                        InpatientAdmission ia = (InpatientAdmission)context.GetObject(iaReadOnly.ObjectID,iaReadOnly.ObjectDef);
                        ((ITTObject)ia).UndoLastTransition("Yatakları Boşaltmak İçin.");
                        ia.IgnoreEpisodeStateOnUpdate = true;
                        ia.Update();
                        ia.CurrentStateDefID = InpatientAdmission.States.Discharged;
                        context.Save();
                        i++;
                    }
                    catch(Exception ex)
                    {
                        
                    }
                    finally
                    {
                        context.Dispose();
                    }
                }
                
                InfoBox.Show(i  + " adet kayıt güncellendi.");
            }
            catch(Exception ex)
            {
                InfoBox.Show(ex);
            }
#endregion ImportTestUnboundForm_ttbutton2_Click
        }
    }
}