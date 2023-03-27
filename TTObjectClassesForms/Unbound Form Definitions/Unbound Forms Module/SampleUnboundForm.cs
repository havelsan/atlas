
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
    /// Sample Unbound Form
    /// </summary>
    public partial class SampleUnboundForm : TTUnboundForm
    {
        override protected void BindControlEvents()
        {
            ttAddConsultationProcedureBtn.Click += new TTControlEventDelegate(ttAddConsultationProcedureBtn_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ttAddConsultationProcedureBtn.Click -= new TTControlEventDelegate(ttAddConsultationProcedureBtn_Click);
            base.UnBindControlEvents();
        }

        private void ttAddConsultationProcedureBtn_Click()
        {
            TTObjectContext context = new TTObjectContext(true);
            try {
                BindingList<Consultation> consultations = Consultation.GetConsultationHasNotProcedure(context);
                foreach(Consultation consultation in consultations)
                {
                    try
                    {
                        TTObjectContext cntx = new TTObjectContext(false);
                        Consultation cons = cntx.GetObject<Consultation>(consultation.ObjectID);
                        cons.AddConsultationProcedure();
                        cntx.Save();
                        Logger.WriteError(cons.ObjectID.ToString() + " id li konsültasyona hizmet eklendi.");
                    }
                    catch(Exception ex)
                    {
                        Logger.WriteError(consultation.ObjectID.ToString() + " id li konsültasyona hizmet eklerken hata oluþtu. Hata : " + ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteError(ex.ToString());
            }
        }
    }
}