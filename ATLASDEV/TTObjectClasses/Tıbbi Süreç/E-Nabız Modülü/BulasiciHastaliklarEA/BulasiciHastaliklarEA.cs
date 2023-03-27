
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class BulasiciHastaliklarEA : EpisodeAction
    {
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(BulasiciHastaliklarEA).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            if (fromState == BulasiciHastaliklarEA.States.New && toState == BulasiciHastaliklarEA.States.Approved)
                PostTransition_New2Approved();
            else if (fromState == BulasiciHastaliklarEA.States.New && toState == BulasiciHastaliklarEA.States.Cancelled)
                PostTransition_New2Cancelled();
            else if (fromState == BulasiciHastaliklarEA.States.Approved && toState == BulasiciHastaliklarEA.States.Cancelled)
                PostTransition_Approved2Cancelled();
        }

        protected void PostTransition_New2Approved()
        {
            if (SubEpisode != null && SendToENabiz())
            {
                new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "214", Common.RecTime());
            }
        }

        protected void PostTransition_New2Cancelled()
        {
            CancelBH();
        }
        protected void PostTransition_Approved2Cancelled()
        {
            CancelBH();
        }

        protected void CancelBH()
        {
            SendToENabiz s = new SendToENabiz();
            string res = s.ENABIZSend200(SubEpisode.ObjectID.ToString(), "BULASICI_HASTALIK_BILDIRIM");
        }

    }
}