
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
    public  partial class AppointmentCarrier : TTObject
    {
#region Methods
        private List<UserTypeEnum> m_userType=new List<UserTypeEnum>();
        public List<UserTypeEnum> UserTypes
        {
            get{ return m_userType; }
        }

        public AppointmentDefinition DefaultAppointmentDefinition
        {
            get;
            set;
        }

        public Resource DefaultMasterResource
        {
            get;
            set;
        }

        public Resource DefaultResource
        {
            get;
            set;
        }

        #endregion Methods

    }
}