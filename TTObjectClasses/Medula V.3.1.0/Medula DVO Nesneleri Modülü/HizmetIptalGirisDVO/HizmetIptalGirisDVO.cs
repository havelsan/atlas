
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
    public  partial class HizmetIptalGirisDVO : BaseMedulaObject
    {
#region Methods
        public string[] hizmetSunucuRefNolari
        {
            get
            {
                string[] retvalue = new string[hizmetSunucuRefNoDVOs.Count];
                int i = 0;
                foreach (HizmetSunucuRefNoDVO hizmetSunucuRefNoDVO in hizmetSunucuRefNoDVOs)
                {
                    retvalue[i] = hizmetSunucuRefNoDVO.hizmetSunucuRefNo;
                    i++;
                }

                return retvalue;
            }
        }

        public string[] islemSiraNumaralari
        {
            get
            {
                string[] retvalue = new string[islemSiraNumarasiDVOs.Count];
                int i = 0;
                foreach (IslemSiraNoDVO islemSiraNoDVO in islemSiraNumarasiDVOs)
                {
                    retvalue[i] = islemSiraNoDVO.islemSiraNo;
                    i++;
                }

                return retvalue;
            }
        }
        
#endregion Methods

    }
}