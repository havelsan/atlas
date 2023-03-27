
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
    public partial class SetMedulaHastaKabulByEpisodeAction : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
            #region Body
            if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
            {
                if (Interface.GetMedulaHastaKabul() == null)
                {
                 
                    PatientMedulaHastaKabul medulaHastaKabul = null;

                    if (Interface.GetEpisodeActionObject() != null)
                    {
                        
                        medulaHastaKabul = Interface.GetEpisodeActionObject().GetMedulaHastaKabul();
                    }

                    if (medulaHastaKabul != null)
                    {
                        //CheckIfMedulaTedaviTipiAllowed(medulaHastaKabul);
                        Interface.SetMedulaHastaKabul(medulaHastaKabul);
                    }
                }
            }
            #endregion Body
        }

        #region Methods
        //        public void CheckIfMedulaTedaviTipiAllowed(PatientMedulaHastaKabul medulaHastaKabul)
        //        {
        //            
        //            IMedulaChildOfEpisodeAction subaction = (IMedulaChildOfEpisodeAction)ObjectContext.GetObject(Interface.ObjectID, Interface.ObjectDef);
        //            if (subaction is SubActionProcedure)
        //            {
        //                ProcedureDefinition procedureObject = ((SubActionProcedure)subaction).ProcedureObject;
        //                if (procedureObject.MedulaTedaviTipi != null && procedureObject.MedulaTedaviTipi != "0")
        //                {
        //                    if (procedureObject.MedulaTedaviTipi != medulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.tedaviTipi)
        //                        throw new Exception("'" + procedureObject.Name.ToString() + "' Hizmeti yalnızca '" + TedaviTipi.GetTedaviTipi(procedureObject.MedulaTedaviTipi).tedaviTipiAdi + "' Tedavi tipindeki Medula Hasta Kabul ile gerçekleştirilebilir.\n\r Mevcut İşleme ait Medula Hasta Kabul'ün Tedavi Tipi '" + TedaviTipi.GetTedaviTipi(medulaHastaKabul.BaseHastaKabul.provizyonGirisDVO.tedaviTipi).tedaviTipiAdi + "'");
        //                }
        //            }
        //        }
        #endregion Methods

        public override void Check(TTAttribute attribute)
        {
            #region CheckBody

            #endregion CheckBody
        }
    }
}