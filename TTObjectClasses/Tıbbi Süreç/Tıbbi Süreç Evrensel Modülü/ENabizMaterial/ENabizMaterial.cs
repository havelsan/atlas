
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
    public partial class ENabizMaterial : TTObject
    {
        protected override void PostInsert()
        {
            //ENabiz a Islem bilgisi gondermek icin paket bilgisi yaziliyor.
            if (SubActionMaterial.SubEpisode != null && SubActionMaterial.SendToENabiz())
                new SendToENabiz(ObjectContext, SubActionMaterial.SubEpisode, ObjectID, ObjectDef.Name, "102", Common.RecTime());
            else
            {
                if (SubActionMaterial.Episode.SubEpisodes.Count > 0 && SubActionMaterial.SendToENabiz())
                    new SendToENabiz(ObjectContext, SubActionMaterial.Episode.SubEpisodes[0], ObjectID, ObjectDef.Name, "102", Common.RecTime());

            }
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ENabizMaterial).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == ENabizMaterial.States.Completed && toState == ENabizMaterial.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            DeleteFromENabiz();

            #endregion PostTransition_Completed2Cancelled
        }

        public void DeleteFromENabiz()
        {
            //Eğer hizmet nabız tablosuna atıldıysa ama gönderim henüz yapılmadıysa statusu updatelenecek(3)
            //Nabıza kaydı yapılmış bir işlem ise nabızdan silinecek
            bool hasSendFlag = false;
            TTObjectClasses.SendToENabiz[] nabizArray = TTObjectClasses.SendToENabiz.GetByObjectID(ObjectContext, ObjectID, "102").ToArray();
            for (int i = 0; i < nabizArray.Length; i++)
            {
                if (nabizArray[i].Status == SendToENabizEnum.Successful)
                {
                    hasSendFlag = true;
                    break;
                }
            }

            if (hasSendFlag)
            {
                if (SubActionMaterial.SubEpisode != null)
                    new SendToENabiz(ObjectContext, SubActionMaterial.SubEpisode, ObjectID, ObjectDef.Name, "302", Common.RecTime());
                else
                    new SendToENabiz(ObjectContext, SubActionMaterial.Episode.SubEpisodes[0], ObjectID, ObjectDef.Name, "302", Common.RecTime());
            }
            else
            {
                foreach (SendToENabiz item in nabizArray)
                {
                    TTObjectClasses.SendToENabiz nabizImported = (TTObjectClasses.SendToENabiz)ObjectContext.GetObject(item.ObjectID, "SendToENabiz");
                    nabizImported.Status = SendToENabizEnum.NotToBeSent;
                }

            }
        }
    }
}