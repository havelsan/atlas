
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
    /// <summary>
    /// Yılsonu / Çift Sıfırlı Kart Devir İşlemi
    /// </summary>
    public  partial class CheckStockCensusAction : BaseAction, IWorkListBaseAction
    {
#region Methods
        //nuri
        public string SingOfCensusAction(SignUserTypeEnum type)
        {
            string personnel =string.Empty ;

            foreach (CensusSignUser censusSignUser in CensusSignUserDetails)
            {
                if (censusSignUser.InspectionUserType == type )
                {
                    personnel = censusSignUser.NameString + "\n" + censusSignUser.ShortMilitaryClass +  " - "  + censusSignUser.ShortRank;
                    break;
                }
            }
            return personnel;
        }
        
        public string SignOfAccontingterm(Guid resCardDrawer)
        {
            string personnel ="";
            foreach(StockCensusCardDrawer stockCensusCardDrawer in StockCensusCardDrawers)
            {
                if(stockCensusCardDrawer.CardDrawer.ObjectID.Equals(resCardDrawer))
                {
                    if(stockCensusCardDrawer.ResUser != null)
                    {
                    personnel =  stockCensusCardDrawer.ResUser.Name+"\n"+stockCensusCardDrawer.ResUser.MilitaryClass+ " - " +stockCensusCardDrawer.ResUser.Rank;
                    break;
                    }
                }
            }
            return personnel;
        }
        public string SignOfAccontingterm2(Guid resCardDrawer)
        {
            string personnel ="";
            foreach(StockCensusCardDrawer stockCensusCardDrawer in StockCensusCardDrawers)
            {
                if(stockCensusCardDrawer.CardDrawer.ObjectID.Equals(resCardDrawer))
                {
                    if(stockCensusCardDrawer.ResUser != null)
                    {
                    personnel =  stockCensusCardDrawer.ResUser.Name+"\n"+stockCensusCardDrawer.ResUser.MilitaryClass+ " - " +stockCensusCardDrawer.ResUser.Rank;
                    break;
                    }
                }
            }
            return personnel;
        }

        public IList<string> SingOfCensusAction_Muf()
        {
            IList<string> muf = null;
            foreach (CensusSignUser censusSignUser in CensusSignUserDetails)
            {
                if (censusSignUser.InspectionUserType == SignUserTypeEnum.TeftisKuruluMufettisi)
                {
                    muf.Add(censusSignUser.NameString + "\n" + censusSignUser.ShortMilitaryClass +  " - "  + censusSignUser.ShortRank);
                }
            }
            return muf;
        }
        
#endregion Methods

    }
}