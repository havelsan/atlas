
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// İş İstek ve İş Emri
    /// </summary>
    public partial class IsIstekveIsEmri : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public IsIstekveIsEmri MyParentReport
            {
                get { return (IsIstekveIsEmri)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField MATERIAL { get {return Header().MATERIAL;} }
            public TTReportField FAULTDESCRIPTION { get {return Header().FAULTDESCRIPTION;} }
            public TTReportField NewField121 { get {return Header().NewField121;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField151 { get {return Header().NewField151;} }
            public TTReportField NewField181 { get {return Header().NewField181;} }
            public TTReportField NewField191 { get {return Header().NewField191;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField REPAIRMILITARYUNIT { get {return Header().REPAIRMILITARYUNIT;} }
            public TTReportField REGISTERNUMBER { get {return Header().REGISTERNUMBER;} }
            public TTReportField ARRIVALDATE { get {return Header().ARRIVALDATE;} }
            public TTReportField NewField1101 { get {return Header().NewField1101;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField1131 { get {return Header().NewField1131;} }
            public TTReportField WORKSHOP { get {return Header().WORKSHOP;} }
            public TTReportField NewField1151 { get {return Header().NewField1151;} }
            public TTReportField NewField1161 { get {return Header().NewField1161;} }
            public TTReportField NewField1171 { get {return Header().NewField1171;} }
            public TTReportField NewField1221 { get {return Header().NewField1221;} }
            public TTReportField NewField1321 { get {return Header().NewField1321;} }
            public TTReportField NewField1411 { get {return Header().NewField1411;} }
            public TTReportField NewField1511 { get {return Header().NewField1511;} }
            public TTReportField NewField1611 { get {return Header().NewField1611;} }
            public TTReportField NewField1711 { get {return Header().NewField1711;} }
            public TTReportField NewField1231 { get {return Header().NewField1231;} }
            public TTReportField GENERAL { get {return Header().GENERAL;} }
            public TTReportField TECHNICIAN { get {return Header().TECHNICIAN;} }
            public TTReportField NewField1201 { get {return Header().NewField1201;} }
            public TTReportField NewField1241 { get {return Header().NewField1241;} }
            public TTReportField NewField1331 { get {return Header().NewField1331;} }
            public TTReportField ORDERDATE { get {return Header().ORDERDATE;} }
            public TTReportField REQUESTNO { get {return Header().REQUESTNO;} }
            public TTReportField NewField1421 { get {return Header().NewField1421;} }
            public TTReportField NewField1261 { get {return Header().NewField1261;} }
            public TTReportField SERIALNUMBER { get {return Header().SERIALNUMBER;} }
            public TTReportField MODEL { get {return Header().MODEL;} }
            public TTReportField MATERIALTREE { get {return Header().MATERIALTREE;} }
            public TTReportField NewField1291 { get {return Header().NewField1291;} }
            public TTReportField NewField1721 { get {return Header().NewField1721;} }
            public TTReportField AMOUNT0 { get {return Header().AMOUNT0;} }
            public TTReportField NewField1301 { get {return Header().NewField1301;} }
            public TTReportField AMOUNT1 { get {return Header().AMOUNT1;} }
            public TTReportField CONSUMEDMATERIAL1 { get {return Header().CONSUMEDMATERIAL1;} }
            public TTReportField NewField1781 { get {return Header().NewField1781;} }
            public TTReportField NewField1791 { get {return Header().NewField1791;} }
            public TTReportField NewField1871 { get {return Header().NewField1871;} }
            public TTReportField NewField1971 { get {return Header().NewField1971;} }
            public TTReportField NewField1981 { get {return Header().NewField1981;} }
            public TTReportField NewField1801 { get {return Header().NewField1801;} }
            public TTReportField NewField1851 { get {return Header().NewField1851;} }
            public TTReportField NewField1861 { get {return Header().NewField1861;} }
            public TTReportField ITEMEQUIPMENT0 { get {return Header().ITEMEQUIPMENT0;} }
            public TTReportField NewField1681 { get {return Header().NewField1681;} }
            public TTReportField NewField1691 { get {return Header().NewField1691;} }
            public TTReportField NewField1901 { get {return Header().NewField1901;} }
            public TTReportField NewField1701 { get {return Header().NewField1701;} }
            public TTReportField NewField1941 { get {return Header().NewField1941;} }
            public TTReportField NewField1961 { get {return Header().NewField1961;} }
            public TTReportField NewField1491 { get {return Header().NewField1491;} }
            public TTReportField NewField11001 { get {return Header().NewField11001;} }
            public TTReportField NewField11021 { get {return Header().NewField11021;} }
            public TTReportField NewField11041 { get {return Header().NewField11041;} }
            public TTReportField NewField14011 { get {return Header().NewField14011;} }
            public TTReportField NewField11051 { get {return Header().NewField11051;} }
            public TTReportField NewField110661 { get {return Header().NewField110661;} }
            public TTReportField NewField13011 { get {return Header().NewField13011;} }
            public TTReportField NewField13021 { get {return Header().NewField13021;} }
            public TTReportField NewField12031 { get {return Header().NewField12031;} }
            public TTReportField NewField16011 { get {return Header().NewField16011;} }
            public TTReportField NewField110771 { get {return Header().NewField110771;} }
            public TTReportField DELIVERERUSER { get {return Header().DELIVERERUSER;} }
            public TTReportField NewField170111 { get {return Header().NewField170111;} }
            public TTReportField DELIVEREDPERSON { get {return Header().DELIVEREDPERSON;} }
            public TTReportField NewField170221 { get {return Header().NewField170221;} }
            public TTReportField RESPONSIBLEUSER { get {return Header().RESPONSIBLEUSER;} }
            public TTReportField NewField17031 { get {return Header().NewField17031;} }
            public TTReportField NewField18031 { get {return Header().NewField18031;} }
            public TTReportField NewField17041 { get {return Header().NewField17041;} }
            public TTReportField NewField18041 { get {return Header().NewField18041;} }
            public TTReportField NewField17051 { get {return Header().NewField17051;} }
            public TTReportField NewField120771 { get {return Header().NewField120771;} }
            public TTReportField NewField13071 { get {return Header().NewField13071;} }
            public TTReportField NewField14071 { get {return Header().NewField14071;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField1621 { get {return Header().NewField1621;} }
            public TTReportField NewField1271 { get {return Header().NewField1271;} }
            public TTReportField NewField115071 { get {return Header().NewField115071;} }
            public TTReportField ACTUALDELIVERYDATE { get {return Header().ACTUALDELIVERYDATE;} }
            public TTReportField ACTUALDELIVERYDATE2 { get {return Header().ACTUALDELIVERYDATE2;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField114081 { get {return Header().NewField114081;} }
            public TTReportShape NewLine112 { get {return Header().NewLine112;} }
            public TTReportShape NewLine122 { get {return Header().NewLine122;} }
            public TTReportShape NewLine1122 { get {return Header().NewLine1122;} }
            public TTReportField ITEMEQUIPMENT1 { get {return Header().ITEMEQUIPMENT1;} }
            public TTReportField ITEMEQUIPMENT2 { get {return Header().ITEMEQUIPMENT2;} }
            public TTReportField ITEMEQUIPMENT3 { get {return Header().ITEMEQUIPMENT3;} }
            public TTReportField ITEMEQUIPMENT4 { get {return Header().ITEMEQUIPMENT4;} }
            public TTReportField ITEMEQUIPMENT5 { get {return Header().ITEMEQUIPMENT5;} }
            public TTReportField ITEMEQUIPMENT6 { get {return Header().ITEMEQUIPMENT6;} }
            public TTReportField ITEMEQUIPMENT7 { get {return Header().ITEMEQUIPMENT7;} }
            public TTReportField ITEMEQUIPMENT8 { get {return Header().ITEMEQUIPMENT8;} }
            public TTReportField ITEMEQUIPMENT9 { get {return Header().ITEMEQUIPMENT9;} }
            public TTReportField OWNERMILITARYUNIT { get {return Header().OWNERMILITARYUNIT;} }
            public TTReportField AMOUNT2 { get {return Header().AMOUNT2;} }
            public TTReportField AMOUNT3 { get {return Header().AMOUNT3;} }
            public TTReportField AMOUNT4 { get {return Header().AMOUNT4;} }
            public TTReportField AMOUNT5 { get {return Header().AMOUNT5;} }
            public TTReportField AMOUNT6 { get {return Header().AMOUNT6;} }
            public TTReportField AMOUNT7 { get {return Header().AMOUNT7;} }
            public TTReportField AMOUNT8 { get {return Header().AMOUNT8;} }
            public TTReportField AMOUNT9 { get {return Header().AMOUNT9;} }
            public TTReportField AMOUNT10 { get {return Header().AMOUNT10;} }
            public TTReportField AMOUNT11 { get {return Header().AMOUNT11;} }
            public TTReportField AMOUNT12 { get {return Header().AMOUNT12;} }
            public TTReportField AMOUNT13 { get {return Header().AMOUNT13;} }
            public TTReportField AMOUNT14 { get {return Header().AMOUNT14;} }
            public TTReportField AMOUNT15 { get {return Header().AMOUNT15;} }
            public TTReportField CONSUMEDMATERIAL2 { get {return Header().CONSUMEDMATERIAL2;} }
            public TTReportField CONSUMEDMATERIAL3 { get {return Header().CONSUMEDMATERIAL3;} }
            public TTReportField CONSUMEDMATERIAL4 { get {return Header().CONSUMEDMATERIAL4;} }
            public TTReportField CONSUMEDMATERIAL5 { get {return Header().CONSUMEDMATERIAL5;} }
            public TTReportField CONSUMEDMATERIAL6 { get {return Header().CONSUMEDMATERIAL6;} }
            public TTReportField CONSUMEDMATERIAL7 { get {return Header().CONSUMEDMATERIAL7;} }
            public TTReportField CONSUMEDMATERIAL8 { get {return Header().CONSUMEDMATERIAL8;} }
            public TTReportField CONSUMEDMATERIAL9 { get {return Header().CONSUMEDMATERIAL9;} }
            public TTReportField CONSUMEDMATERIAL10 { get {return Header().CONSUMEDMATERIAL10;} }
            public TTReportField CONSUMEDMATERIAL11 { get {return Header().CONSUMEDMATERIAL11;} }
            public TTReportField CONSUMEDMATERIAL12 { get {return Header().CONSUMEDMATERIAL12;} }
            public TTReportField CONSUMEDMATERIAL13 { get {return Header().CONSUMEDMATERIAL13;} }
            public TTReportField CONSUMEDMATERIAL14 { get {return Header().CONSUMEDMATERIAL14;} }
            public TTReportField CONSUMEDMATERIAL15 { get {return Header().CONSUMEDMATERIAL15;} }
            public TTReportField CONSUMEDMATERIAL0 { get {return Header().CONSUMEDMATERIAL0;} }
            public TTReportShape NewLine1112 { get {return Header().NewLine1112;} }
            public TTReportField NewField116011 { get {return Footer().NewField116011;} }
            public TTReportField NewField111071 { get {return Footer().NewField111071;} }
            public TTReportField NewField117011 { get {return Footer().NewField117011;} }
            public TTReportField NewField112071 { get {return Footer().NewField112071;} }
            public TTReportField NewField1188011 { get {return Footer().NewField1188011;} }
            public TTReportField NewField1133071 { get {return Footer().NewField1133071;} }
            public TTReportField NewField1188021 { get {return Footer().NewField1188021;} }
            public TTReportField NewField1144071 { get {return Footer().NewField1144071;} }
            public TTReportField NewField19011 { get {return Footer().NewField19011;} }
            public TTReportField NewField15071 { get {return Footer().NewField15071;} }
            public TTReportField NewField19021 { get {return Footer().NewField19021;} }
            public TTReportField NewField111001 { get {return Footer().NewField111001;} }
            public TTReportField NewField17071 { get {return Footer().NewField17071;} }
            public TTReportField NewField12101 { get {return Footer().NewField12101;} }
            public TTReportField NewField112091 { get {return Footer().NewField112091;} }
            public TTReportField NewField111091 { get {return Footer().NewField111091;} }
            public TTReportField NewField117051 { get {return Footer().NewField117051;} }
            public TTReportField NewField112092 { get {return Footer().NewField112092;} }
            public TTReportField NewField1100111 { get {return Footer().NewField1100111;} }
            public TTReportField NewField117071 { get {return Footer().NewField117071;} }
            public TTReportField NewField110121 { get {return Footer().NewField110121;} }
            public TTReportField NewField1190211 { get {return Footer().NewField1190211;} }
            public TTReportField NewField111092 { get {return Footer().NewField111092;} }
            public TTReportField NewField117052 { get {return Footer().NewField117052;} }
            public TTReportField NewField112093 { get {return Footer().NewField112093;} }
            public TTReportField NewField1100112 { get {return Footer().NewField1100112;} }
            public TTReportField NewField117072 { get {return Footer().NewField117072;} }
            public TTReportField NewField110122 { get {return Footer().NewField110122;} }
            public TTReportField NewField1190212 { get {return Footer().NewField1190212;} }
            public TTReportField NewField111093 { get {return Footer().NewField111093;} }
            public TTReportField NewField117053 { get {return Footer().NewField117053;} }
            public TTReportField NewField112094 { get {return Footer().NewField112094;} }
            public TTReportField NewField1100113 { get {return Footer().NewField1100113;} }
            public TTReportField NewField117073 { get {return Footer().NewField117073;} }
            public TTReportField NewField110123 { get {return Footer().NewField110123;} }
            public TTReportField NewField1190213 { get {return Footer().NewField1190213;} }
            public TTReportField NewField111094 { get {return Footer().NewField111094;} }
            public TTReportField NewField117054 { get {return Footer().NewField117054;} }
            public TTReportField NewField112095 { get {return Footer().NewField112095;} }
            public TTReportField NewField1100114 { get {return Footer().NewField1100114;} }
            public TTReportField NewField117074 { get {return Footer().NewField117074;} }
            public TTReportField NewField110124 { get {return Footer().NewField110124;} }
            public TTReportField NewField1190214 { get {return Footer().NewField1190214;} }
            public TTReportField NewField111095 { get {return Footer().NewField111095;} }
            public TTReportField NewField117055 { get {return Footer().NewField117055;} }
            public TTReportField NewField112096 { get {return Footer().NewField112096;} }
            public TTReportField NewField1100115 { get {return Footer().NewField1100115;} }
            public TTReportField NewField117075 { get {return Footer().NewField117075;} }
            public TTReportField NewField110125 { get {return Footer().NewField110125;} }
            public TTReportField NewField1190215 { get {return Footer().NewField1190215;} }
            public TTReportField NewField111096 { get {return Footer().NewField111096;} }
            public TTReportField NewField117056 { get {return Footer().NewField117056;} }
            public TTReportField NewField112097 { get {return Footer().NewField112097;} }
            public TTReportField NewField1100116 { get {return Footer().NewField1100116;} }
            public TTReportField NewField117076 { get {return Footer().NewField117076;} }
            public TTReportField NewField110126 { get {return Footer().NewField110126;} }
            public TTReportField NewField1190216 { get {return Footer().NewField1190216;} }
            public TTReportField NewField111097 { get {return Footer().NewField111097;} }
            public TTReportField NewField117057 { get {return Footer().NewField117057;} }
            public TTReportField NewField112098 { get {return Footer().NewField112098;} }
            public TTReportField NewField1100117 { get {return Footer().NewField1100117;} }
            public TTReportField NewField117077 { get {return Footer().NewField117077;} }
            public TTReportField NewField110127 { get {return Footer().NewField110127;} }
            public TTReportField NewField1190217 { get {return Footer().NewField1190217;} }
            public TTReportField NewField111098 { get {return Footer().NewField111098;} }
            public TTReportField NewField117058 { get {return Footer().NewField117058;} }
            public TTReportField NewField112099 { get {return Footer().NewField112099;} }
            public TTReportField NewField1100118 { get {return Footer().NewField1100118;} }
            public TTReportField NewField117078 { get {return Footer().NewField117078;} }
            public TTReportField NewField110128 { get {return Footer().NewField110128;} }
            public TTReportField NewField1190218 { get {return Footer().NewField1190218;} }
            public TTReportField NewField111099 { get {return Footer().NewField111099;} }
            public TTReportField NewField117059 { get {return Footer().NewField117059;} }
            public TTReportField NewField112100 { get {return Footer().NewField112100;} }
            public TTReportField NewField1100119 { get {return Footer().NewField1100119;} }
            public TTReportField NewField117079 { get {return Footer().NewField117079;} }
            public TTReportField NewField110129 { get {return Footer().NewField110129;} }
            public TTReportField NewField1190219 { get {return Footer().NewField1190219;} }
            public TTReportField NewField111100 { get {return Footer().NewField111100;} }
            public TTReportField NewField117060 { get {return Footer().NewField117060;} }
            public TTReportField NewField112101 { get {return Footer().NewField112101;} }
            public TTReportField NewField1100120 { get {return Footer().NewField1100120;} }
            public TTReportField NewField117080 { get {return Footer().NewField117080;} }
            public TTReportField NewField110130 { get {return Footer().NewField110130;} }
            public TTReportField NewField1190220 { get {return Footer().NewField1190220;} }
            public TTReportField NewField111101 { get {return Footer().NewField111101;} }
            public TTReportField NewField117061 { get {return Footer().NewField117061;} }
            public TTReportField NewField112102 { get {return Footer().NewField112102;} }
            public TTReportField NewField1100121 { get {return Footer().NewField1100121;} }
            public TTReportField NewField117081 { get {return Footer().NewField117081;} }
            public TTReportField NewField110131 { get {return Footer().NewField110131;} }
            public TTReportField NewField1190221 { get {return Footer().NewField1190221;} }
            public TTReportField NewField111102 { get {return Footer().NewField111102;} }
            public TTReportField NewField117062 { get {return Footer().NewField117062;} }
            public TTReportField NewField112103 { get {return Footer().NewField112103;} }
            public TTReportField NewField1100122 { get {return Footer().NewField1100122;} }
            public TTReportField NewField117082 { get {return Footer().NewField117082;} }
            public TTReportField NewField110132 { get {return Footer().NewField110132;} }
            public TTReportField NewField1190222 { get {return Footer().NewField1190222;} }
            public TTReportField NewField111103 { get {return Footer().NewField111103;} }
            public TTReportField NewField117063 { get {return Footer().NewField117063;} }
            public TTReportField NewField112104 { get {return Footer().NewField112104;} }
            public TTReportField NewField1100123 { get {return Footer().NewField1100123;} }
            public TTReportField NewField117083 { get {return Footer().NewField117083;} }
            public TTReportField NewField110133 { get {return Footer().NewField110133;} }
            public TTReportField NewField1190223 { get {return Footer().NewField1190223;} }
            public TTReportField NewField111104 { get {return Footer().NewField111104;} }
            public TTReportField NewField117064 { get {return Footer().NewField117064;} }
            public TTReportField NewField112105 { get {return Footer().NewField112105;} }
            public TTReportField NewField1100124 { get {return Footer().NewField1100124;} }
            public TTReportField NewField117084 { get {return Footer().NewField117084;} }
            public TTReportField NewField110134 { get {return Footer().NewField110134;} }
            public TTReportField NewField1190224 { get {return Footer().NewField1190224;} }
            public TTReportField NewField111105 { get {return Footer().NewField111105;} }
            public TTReportField NewField117065 { get {return Footer().NewField117065;} }
            public TTReportField NewField112106 { get {return Footer().NewField112106;} }
            public TTReportField NewField1100125 { get {return Footer().NewField1100125;} }
            public TTReportField NewField117085 { get {return Footer().NewField117085;} }
            public TTReportField NewField110135 { get {return Footer().NewField110135;} }
            public TTReportField NewField1190225 { get {return Footer().NewField1190225;} }
            public TTReportField NewField111106 { get {return Footer().NewField111106;} }
            public TTReportField NewField117066 { get {return Footer().NewField117066;} }
            public TTReportField NewField112107 { get {return Footer().NewField112107;} }
            public TTReportField NewField1100126 { get {return Footer().NewField1100126;} }
            public TTReportField NewField117086 { get {return Footer().NewField117086;} }
            public TTReportField NewField110136 { get {return Footer().NewField110136;} }
            public TTReportField NewField1190226 { get {return Footer().NewField1190226;} }
            public TTReportField NewField111108 { get {return Footer().NewField111108;} }
            public TTReportField NewField117068 { get {return Footer().NewField117068;} }
            public TTReportField NewField112109 { get {return Footer().NewField112109;} }
            public TTReportField NewField1100128 { get {return Footer().NewField1100128;} }
            public TTReportField NewField117088 { get {return Footer().NewField117088;} }
            public TTReportField NewField110138 { get {return Footer().NewField110138;} }
            public TTReportField NewField1190228 { get {return Footer().NewField1190228;} }
            public TTReportField NewField1110611 { get {return Footer().NewField1110611;} }
            public TTReportField NewField111111 { get {return Footer().NewField111111;} }
            public TTReportField NewField111112 { get {return Footer().NewField111112;} }
            public TTReportField NewField1111111 { get {return Footer().NewField1111111;} }
            public TTReportField NewField1211111 { get {return Footer().NewField1211111;} }
            public TTReportField NewField1111112 { get {return Footer().NewField1111112;} }
            public TTReportField NewField1211112 { get {return Footer().NewField1211112;} }
            public TTReportField NewField1111113 { get {return Footer().NewField1111113;} }
            public TTReportField NewField1211113 { get {return Footer().NewField1211113;} }
            public TTReportField NewField1111114 { get {return Footer().NewField1111114;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public TTReportShape NewLine1111 { get {return Footer().NewLine1111;} }
            public TTReportShape NewLine121 { get {return Footer().NewLine121;} }
            public TTReportShape NewLine1121 { get {return Footer().NewLine1121;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public IsIstekveIsEmri MyParentReport
                {
                    get { return (IsIstekveIsEmri)ParentReport; }
                }
                
                public TTReportField MATERIAL;
                public TTReportField FAULTDESCRIPTION;
                public TTReportField NewField121;
                public TTReportField NewField131;
                public TTReportField NewField141;
                public TTReportField NewField151;
                public TTReportField NewField181;
                public TTReportField NewField191;
                public TTReportField NewField111;
                public TTReportField REPAIRMILITARYUNIT;
                public TTReportField REGISTERNUMBER;
                public TTReportField ARRIVALDATE;
                public TTReportField NewField1101;
                public TTReportField NewField1121;
                public TTReportField NewField1131;
                public TTReportField WORKSHOP;
                public TTReportField NewField1151;
                public TTReportField NewField1161;
                public TTReportField NewField1171;
                public TTReportField NewField1221;
                public TTReportField NewField1321;
                public TTReportField NewField1411;
                public TTReportField NewField1511;
                public TTReportField NewField1611;
                public TTReportField NewField1711;
                public TTReportField NewField1231;
                public TTReportField GENERAL;
                public TTReportField TECHNICIAN;
                public TTReportField NewField1201;
                public TTReportField NewField1241;
                public TTReportField NewField1331;
                public TTReportField ORDERDATE;
                public TTReportField REQUESTNO;
                public TTReportField NewField1421;
                public TTReportField NewField1261;
                public TTReportField SERIALNUMBER;
                public TTReportField MODEL;
                public TTReportField MATERIALTREE;
                public TTReportField NewField1291;
                public TTReportField NewField1721;
                public TTReportField AMOUNT0;
                public TTReportField NewField1301;
                public TTReportField AMOUNT1;
                public TTReportField CONSUMEDMATERIAL1;
                public TTReportField NewField1781;
                public TTReportField NewField1791;
                public TTReportField NewField1871;
                public TTReportField NewField1971;
                public TTReportField NewField1981;
                public TTReportField NewField1801;
                public TTReportField NewField1851;
                public TTReportField NewField1861;
                public TTReportField ITEMEQUIPMENT0;
                public TTReportField NewField1681;
                public TTReportField NewField1691;
                public TTReportField NewField1901;
                public TTReportField NewField1701;
                public TTReportField NewField1941;
                public TTReportField NewField1961;
                public TTReportField NewField1491;
                public TTReportField NewField11001;
                public TTReportField NewField11021;
                public TTReportField NewField11041;
                public TTReportField NewField14011;
                public TTReportField NewField11051;
                public TTReportField NewField110661;
                public TTReportField NewField13011;
                public TTReportField NewField13021;
                public TTReportField NewField12031;
                public TTReportField NewField16011;
                public TTReportField NewField110771;
                public TTReportField DELIVERERUSER;
                public TTReportField NewField170111;
                public TTReportField DELIVEREDPERSON;
                public TTReportField NewField170221;
                public TTReportField RESPONSIBLEUSER;
                public TTReportField NewField17031;
                public TTReportField NewField18031;
                public TTReportField NewField17041;
                public TTReportField NewField18041;
                public TTReportField NewField17051;
                public TTReportField NewField120771;
                public TTReportField NewField13071;
                public TTReportField NewField14071;
                public TTReportField NewField11;
                public TTReportField NewField1621;
                public TTReportField NewField1271;
                public TTReportField NewField115071;
                public TTReportField ACTUALDELIVERYDATE;
                public TTReportField ACTUALDELIVERYDATE2;
                public TTReportField STARTDATE;
                public TTReportField ENDDATE;
                public TTReportField NewField114081;
                public TTReportShape NewLine112;
                public TTReportShape NewLine122;
                public TTReportShape NewLine1122;
                public TTReportField ITEMEQUIPMENT1;
                public TTReportField ITEMEQUIPMENT2;
                public TTReportField ITEMEQUIPMENT3;
                public TTReportField ITEMEQUIPMENT4;
                public TTReportField ITEMEQUIPMENT5;
                public TTReportField ITEMEQUIPMENT6;
                public TTReportField ITEMEQUIPMENT7;
                public TTReportField ITEMEQUIPMENT8;
                public TTReportField ITEMEQUIPMENT9;
                public TTReportField OWNERMILITARYUNIT;
                public TTReportField AMOUNT2;
                public TTReportField AMOUNT3;
                public TTReportField AMOUNT4;
                public TTReportField AMOUNT5;
                public TTReportField AMOUNT6;
                public TTReportField AMOUNT7;
                public TTReportField AMOUNT8;
                public TTReportField AMOUNT9;
                public TTReportField AMOUNT10;
                public TTReportField AMOUNT11;
                public TTReportField AMOUNT12;
                public TTReportField AMOUNT13;
                public TTReportField AMOUNT14;
                public TTReportField AMOUNT15;
                public TTReportField CONSUMEDMATERIAL2;
                public TTReportField CONSUMEDMATERIAL3;
                public TTReportField CONSUMEDMATERIAL4;
                public TTReportField CONSUMEDMATERIAL5;
                public TTReportField CONSUMEDMATERIAL6;
                public TTReportField CONSUMEDMATERIAL7;
                public TTReportField CONSUMEDMATERIAL8;
                public TTReportField CONSUMEDMATERIAL9;
                public TTReportField CONSUMEDMATERIAL10;
                public TTReportField CONSUMEDMATERIAL11;
                public TTReportField CONSUMEDMATERIAL12;
                public TTReportField CONSUMEDMATERIAL13;
                public TTReportField CONSUMEDMATERIAL14;
                public TTReportField CONSUMEDMATERIAL15;
                public TTReportField CONSUMEDMATERIAL0;
                public TTReportShape NewLine1112; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 297;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 102, 54, 122, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIAL.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIAL.TextFont.Name = "Arial";
                    MATERIAL.TextFont.Size = 9;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"";

                    FAULTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 16, 137, 94, 152, false);
                    FAULTDESCRIPTION.Name = "FAULTDESCRIPTION";
                    FAULTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAULTDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.TextFont.Name = "Arial";
                    FAULTDESCRIPTION.TextFont.Size = 9;
                    FAULTDESCRIPTION.TextFont.CharSet = 162;
                    FAULTDESCRIPTION.Value = @"";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 200, 20, false);
                    NewField121.Name = "NewField121";
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 11;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"İŞ İSTEK VE İŞ EMRİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 24, 95, 29, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField131.TextFont.Name = "Arial";
                    NewField131.TextFont.Size = 9;
                    NewField131.TextFont.Bold = true;
                    NewField131.TextFont.CharSet = 162;
                    NewField131.Value = @"Onarım İSTEYEN Birlik";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 24, 200, 29, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField141.TextFont.Name = "Arial";
                    NewField141.TextFont.Size = 9;
                    NewField141.TextFont.Bold = true;
                    NewField141.TextFont.CharSet = 162;
                    NewField141.Value = @"Onarım/İmalat Yapacak Birlik Bilgileri";

                    NewField151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 29, 95, 38, false);
                    NewField151.Name = "NewField151";
                    NewField151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField151.TextFont.Name = "Arial";
                    NewField151.TextFont.Size = 9;
                    NewField151.TextFont.CharSet = 162;
                    NewField151.Value = @"Onarım İmalat İsteyen Birlik";

                    NewField181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 29, 140, 38, false);
                    NewField181.Name = "NewField181";
                    NewField181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField181.MultiLine = EvetHayirEnum.ehEvet;
                    NewField181.TextFont.Name = "Arial";
                    NewField181.TextFont.Size = 9;
                    NewField181.TextFont.CharSet = 162;
                    NewField181.Value = @"Onarım/İmalat
Yapacak Birlik";

                    NewField191 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 29, 168, 38, false);
                    NewField191.Name = "NewField191";
                    NewField191.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField191.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField191.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField191.MultiLine = EvetHayirEnum.ehEvet;
                    NewField191.TextFont.Name = "Arial";
                    NewField191.TextFont.Size = 9;
                    NewField191.TextFont.CharSet = 162;
                    NewField191.Value = @"Siparişin Alındığı
Tarih";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 29, 200, 38, false);
                    NewField111.Name = "NewField111";
                    NewField111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111.TextFont.Name = "Arial";
                    NewField111.TextFont.Size = 9;
                    NewField111.TextFont.CharSet = 162;
                    NewField111.Value = @"Belge Kayıt Nu.";

                    REPAIRMILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 38, 140, 51, false);
                    REPAIRMILITARYUNIT.Name = "REPAIRMILITARYUNIT";
                    REPAIRMILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    REPAIRMILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRMILITARYUNIT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REPAIRMILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REPAIRMILITARYUNIT.TextFont.Name = "Arial";
                    REPAIRMILITARYUNIT.TextFont.Size = 9;
                    REPAIRMILITARYUNIT.TextFont.CharSet = 162;
                    REPAIRMILITARYUNIT.Value = @"";

                    REGISTERNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 38, 200, 51, false);
                    REGISTERNUMBER.Name = "REGISTERNUMBER";
                    REGISTERNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    REGISTERNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    REGISTERNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REGISTERNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REGISTERNUMBER.TextFont.Name = "Arial";
                    REGISTERNUMBER.TextFont.Size = 9;
                    REGISTERNUMBER.TextFont.CharSet = 162;
                    REGISTERNUMBER.Value = @"";

                    ARRIVALDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 38, 168, 51, false);
                    ARRIVALDATE.Name = "ARRIVALDATE";
                    ARRIVALDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ARRIVALDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ARRIVALDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ARRIVALDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ARRIVALDATE.TextFont.Name = "Arial";
                    ARRIVALDATE.TextFont.Size = 9;
                    ARRIVALDATE.TextFont.CharSet = 162;
                    ARRIVALDATE.Value = @"";

                    NewField1101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 51, 140, 60, false);
                    NewField1101.Name = "NewField1101";
                    NewField1101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1101.TextFont.Name = "Arial";
                    NewField1101.TextFont.Size = 9;
                    NewField1101.TextFont.CharSet = 162;
                    NewField1101.Value = @"Onarım/İmalat
Yapılacak Atölye";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 51, 168, 60, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1121.TextFont.Name = "Arial";
                    NewField1121.TextFont.Size = 9;
                    NewField1121.TextFont.CharSet = 162;
                    NewField1121.Value = @"Tercih Sırası";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 51, 200, 60, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 9;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"Bkm.Onr.Kyt.Nu.";

                    WORKSHOP = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 60, 140, 76, false);
                    WORKSHOP.Name = "WORKSHOP";
                    WORKSHOP.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP.TextFont.Name = "Arial";
                    WORKSHOP.TextFont.Size = 9;
                    WORKSHOP.TextFont.CharSet = 162;
                    WORKSHOP.Value = @"";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 60, 200, 76, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.TextFont.Size = 8;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 60, 168, 76, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1161.TextFont.Size = 8;
                    NewField1161.TextFont.CharSet = 162;
                    NewField1161.Value = @"";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 76, 140, 81, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Size = 9;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"Muayene Astsb.";

                    NewField1221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 76, 168, 81, false);
                    NewField1221.Name = "NewField1221";
                    NewField1221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1221.TextFont.Name = "Arial";
                    NewField1221.TextFont.Size = 9;
                    NewField1221.TextFont.CharSet = 162;
                    NewField1221.Value = @"Tahmini İş saati";

                    NewField1321 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 76, 200, 81, false);
                    NewField1321.Name = "NewField1321";
                    NewField1321.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1321.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1321.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1321.TextFont.Name = "Arial";
                    NewField1321.TextFont.Size = 9;
                    NewField1321.TextFont.CharSet = 162;
                    NewField1321.Value = @"Gerçek İş Saati";

                    NewField1411 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 81, 140, 97, false);
                    NewField1411.Name = "NewField1411";
                    NewField1411.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1411.TextFont.Size = 8;
                    NewField1411.TextFont.CharSet = 162;
                    NewField1411.Value = @"";

                    NewField1511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 81, 200, 97, false);
                    NewField1511.Name = "NewField1511";
                    NewField1511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1511.TextFont.Size = 8;
                    NewField1511.TextFont.CharSet = 162;
                    NewField1511.Value = @"";

                    NewField1611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 81, 168, 97, false);
                    NewField1611.Name = "NewField1611";
                    NewField1611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1611.TextFont.Size = 8;
                    NewField1611.TextFont.CharSet = 162;
                    NewField1611.Value = @"";

                    NewField1711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 51, 55, 60, false);
                    NewField1711.Name = "NewField1711";
                    NewField1711.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1711.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1711.TextFont.Name = "Arial";
                    NewField1711.TextFont.Size = 9;
                    NewField1711.TextFont.CharSet = 162;
                    NewField1711.Value = @"Birlik XXXXXXı";

                    NewField1231 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 51, 95, 60, false);
                    NewField1231.Name = "NewField1231";
                    NewField1231.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1231.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1231.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1231.TextFont.Name = "Arial";
                    NewField1231.TextFont.Size = 9;
                    NewField1231.TextFont.CharSet = 162;
                    NewField1231.Value = @"Kull.Birlik Kad.Tekns.";

                    GENERAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 60, 55, 81, false);
                    GENERAL.Name = "GENERAL";
                    GENERAL.DrawStyle = DrawStyleConstants.vbSolid;
                    GENERAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    GENERAL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    GENERAL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GENERAL.TextFont.Name = "Arial";
                    GENERAL.TextFont.Size = 9;
                    GENERAL.TextFont.CharSet = 162;
                    GENERAL.Value = @"";

                    TECHNICIAN = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 60, 95, 81, false);
                    TECHNICIAN.Name = "TECHNICIAN";
                    TECHNICIAN.DrawStyle = DrawStyleConstants.vbSolid;
                    TECHNICIAN.FieldType = ReportFieldTypeEnum.ftVariable;
                    TECHNICIAN.MultiLine = EvetHayirEnum.ehEvet;
                    TECHNICIAN.TextFont.Name = "Arial";
                    TECHNICIAN.TextFont.Size = 9;
                    TECHNICIAN.TextFont.CharSet = 162;
                    TECHNICIAN.Value = @"";

                    NewField1201 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 92, 95, 97, false);
                    NewField1201.Name = "NewField1201";
                    NewField1201.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1201.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1201.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1201.TextFont.Name = "Arial";
                    NewField1201.TextFont.Size = 9;
                    NewField1201.TextFont.Bold = true;
                    NewField1201.TextFont.CharSet = 162;
                    NewField1201.Value = @"Malzeme Bilgileri";

                    NewField1241 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 81, 55, 86, false);
                    NewField1241.Name = "NewField1241";
                    NewField1241.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1241.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1241.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1241.TextFont.Name = "Arial";
                    NewField1241.TextFont.Size = 9;
                    NewField1241.TextFont.CharSet = 162;
                    NewField1241.Value = @"Sipariş Tarihi";

                    NewField1331 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 81, 95, 86, false);
                    NewField1331.Name = "NewField1331";
                    NewField1331.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1331.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1331.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1331.TextFont.Name = "Arial";
                    NewField1331.TextFont.Size = 9;
                    NewField1331.TextFont.CharSet = 162;
                    NewField1331.Value = @"Birlik Kayıt Nu.";

                    ORDERDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 86, 55, 92, false);
                    ORDERDATE.Name = "ORDERDATE";
                    ORDERDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERDATE.TextFormat = @"Short Date";
                    ORDERDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERDATE.TextFont.Name = "Arial";
                    ORDERDATE.TextFont.Size = 9;
                    ORDERDATE.TextFont.CharSet = 162;
                    ORDERDATE.Value = @"";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 86, 95, 92, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbSolid;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    REQUESTNO.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    REQUESTNO.TextFont.Name = "Arial";
                    REQUESTNO.TextFont.Size = 9;
                    REQUESTNO.TextFont.CharSet = 162;
                    REQUESTNO.Value = @"";

                    NewField1421 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 97, 55, 102, false);
                    NewField1421.Name = "NewField1421";
                    NewField1421.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1421.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1421.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1421.TextFont.Name = "Arial";
                    NewField1421.TextFont.Size = 9;
                    NewField1421.TextFont.CharSet = 162;
                    NewField1421.Value = @"Malın Cinsi";

                    NewField1261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 97, 95, 102, false);
                    NewField1261.Name = "NewField1261";
                    NewField1261.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1261.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1261.TextFont.Name = "Arial";
                    NewField1261.TextFont.Size = 9;
                    NewField1261.TextFont.CharSet = 162;
                    NewField1261.Value = @"Plaka Seri Nu.";

                    SERIALNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 102, 95, 122, false);
                    SERIALNUMBER.Name = "SERIALNUMBER";
                    SERIALNUMBER.DrawStyle = DrawStyleConstants.vbSolid;
                    SERIALNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNUMBER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    SERIALNUMBER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SERIALNUMBER.TextFont.Name = "Arial";
                    SERIALNUMBER.TextFont.Size = 9;
                    SERIALNUMBER.TextFont.CharSet = 162;
                    SERIALNUMBER.Value = @"";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 127, 55, 137, false);
                    MODEL.Name = "MODEL";
                    MODEL.DrawStyle = DrawStyleConstants.vbSolid;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MODEL.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MODEL.TextFont.Name = "Arial";
                    MODEL.TextFont.Size = 9;
                    MODEL.TextFont.CharSet = 162;
                    MODEL.Value = @"";

                    MATERIALTREE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 127, 95, 137, false);
                    MATERIALTREE.Name = "MATERIALTREE";
                    MATERIALTREE.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALTREE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTREE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALTREE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALTREE.TextFont.Name = "Arial";
                    MATERIALTREE.TextFont.Size = 9;
                    MATERIALTREE.TextFont.CharSet = 162;
                    MATERIALTREE.Value = @"";

                    NewField1291 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 97, 200, 102, false);
                    NewField1291.Name = "NewField1291";
                    NewField1291.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1291.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1291.TextFont.Name = "Arial";
                    NewField1291.TextFont.Size = 9;
                    NewField1291.TextFont.Bold = true;
                    NewField1291.TextFont.CharSet = 162;
                    NewField1291.Value = @"   Onarım/İmalatta Kullanılan Malzeme";

                    NewField1721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 102, 118, 107, false);
                    NewField1721.Name = "NewField1721";
                    NewField1721.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1721.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1721.TextFont.Name = "Arial";
                    NewField1721.TextFont.Size = 9;
                    NewField1721.TextFont.CharSet = 162;
                    NewField1721.Value = @"Miktarı";

                    AMOUNT0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 107, 118, 122, false);
                    AMOUNT0.Name = "AMOUNT0";
                    AMOUNT0.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT0.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT0.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT0.TextFont.Name = "Arial";
                    AMOUNT0.TextFont.Size = 9;
                    AMOUNT0.TextFont.CharSet = 162;
                    AMOUNT0.Value = @"";

                    NewField1301 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 102, 200, 107, false);
                    NewField1301.Name = "NewField1301";
                    NewField1301.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1301.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1301.TextFont.Name = "Arial";
                    NewField1301.TextFont.Size = 9;
                    NewField1301.TextFont.CharSet = 162;
                    NewField1301.Value = @"   Stok Nu. ve İsmi";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 122, 118, 127, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT1.TextFont.Name = "Arial";
                    AMOUNT1.TextFont.Size = 9;
                    AMOUNT1.TextFont.CharSet = 162;
                    AMOUNT1.Value = @"";

                    CONSUMEDMATERIAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 122, 200, 127, false);
                    CONSUMEDMATERIAL1.Name = "CONSUMEDMATERIAL1";
                    CONSUMEDMATERIAL1.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL1.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL1.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL1.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL1.TextFont.Size = 9;
                    CONSUMEDMATERIAL1.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL1.Value = @"";

                    NewField1781 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 152, 55, 162, false);
                    NewField1781.Name = "NewField1781";
                    NewField1781.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1781.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1781.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1781.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1781.TextFont.Name = "Arial";
                    NewField1781.TextFont.Size = 9;
                    NewField1781.TextFont.CharSet = 162;
                    NewField1781.Value = @"Garanti
Kapsamında mı?";

                    NewField1791 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 162, 35, 172, false);
                    NewField1791.Name = "NewField1791";
                    NewField1791.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1791.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1791.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1791.TextFont.Name = "Arial";
                    NewField1791.TextFont.Size = 9;
                    NewField1791.TextFont.CharSet = 162;
                    NewField1791.Value = @"EVET";

                    NewField1871 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 152, 95, 162, false);
                    NewField1871.Name = "NewField1871";
                    NewField1871.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1871.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1871.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1871.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1871.TextFont.Name = "Arial";
                    NewField1871.TextFont.Size = 9;
                    NewField1871.TextFont.CharSet = 162;
                    NewField1871.Value = @"Yetki
Dışı mı?";

                    NewField1971 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 35, 162, 55, 172, false);
                    NewField1971.Name = "NewField1971";
                    NewField1971.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1971.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1971.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1971.TextFont.Name = "Arial";
                    NewField1971.TextFont.Size = 9;
                    NewField1971.TextFont.CharSet = 162;
                    NewField1971.Value = @"HAYIR";

                    NewField1981 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 162, 75, 172, false);
                    NewField1981.Name = "NewField1981";
                    NewField1981.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1981.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1981.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1981.TextFont.Name = "Arial";
                    NewField1981.TextFont.Size = 9;
                    NewField1981.TextFont.CharSet = 162;
                    NewField1981.Value = @"EVET";

                    NewField1801 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 75, 162, 95, 172, false);
                    NewField1801.Name = "NewField1801";
                    NewField1801.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1801.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1801.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1801.TextFont.Name = "Arial";
                    NewField1801.TextFont.Size = 9;
                    NewField1801.TextFont.CharSet = 162;
                    NewField1801.Value = @"HAYIR";

                    NewField1851 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 172, 95, 182, false);
                    NewField1851.Name = "NewField1851";
                    NewField1851.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1851.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1851.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1851.TextFont.Name = "Arial";
                    NewField1851.TextFont.Size = 9;
                    NewField1851.TextFont.CharSet = 162;
                    NewField1851.Value = @"Teslimde Malla Beraber Bulunan Malzeme";

                    NewField1861 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 182, 20, 187, false);
                    NewField1861.Name = "NewField1861";
                    NewField1861.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1861.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1861.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1861.TextFont.Name = "Arial";
                    NewField1861.TextFont.Size = 9;
                    NewField1861.TextFont.CharSet = 162;
                    NewField1861.Value = @" 1.";

                    ITEMEQUIPMENT0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 182, 95, 187, false);
                    ITEMEQUIPMENT0.Name = "ITEMEQUIPMENT0";
                    ITEMEQUIPMENT0.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT0.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT0.TextFont.Name = "Arial";
                    ITEMEQUIPMENT0.TextFont.Size = 9;
                    ITEMEQUIPMENT0.TextFont.CharSet = 162;
                    ITEMEQUIPMENT0.Value = @"";

                    NewField1681 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 187, 20, 192, false);
                    NewField1681.Name = "NewField1681";
                    NewField1681.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1681.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1681.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1681.TextFont.Name = "Arial";
                    NewField1681.TextFont.Size = 9;
                    NewField1681.TextFont.CharSet = 162;
                    NewField1681.Value = @" 2.";

                    NewField1691 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 192, 20, 197, false);
                    NewField1691.Name = "NewField1691";
                    NewField1691.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1691.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1691.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1691.TextFont.Name = "Arial";
                    NewField1691.TextFont.Size = 9;
                    NewField1691.TextFont.CharSet = 162;
                    NewField1691.Value = @" 3.";

                    NewField1901 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 197, 20, 202, false);
                    NewField1901.Name = "NewField1901";
                    NewField1901.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1901.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1901.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1901.TextFont.Name = "Arial";
                    NewField1901.TextFont.Size = 9;
                    NewField1901.TextFont.CharSet = 162;
                    NewField1901.Value = @" 4.";

                    NewField1701 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 202, 20, 207, false);
                    NewField1701.Name = "NewField1701";
                    NewField1701.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1701.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1701.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1701.TextFont.Name = "Arial";
                    NewField1701.TextFont.Size = 9;
                    NewField1701.TextFont.CharSet = 162;
                    NewField1701.Value = @" 5.";

                    NewField1941 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 207, 20, 212, false);
                    NewField1941.Name = "NewField1941";
                    NewField1941.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1941.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1941.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1941.TextFont.Name = "Arial";
                    NewField1941.TextFont.Size = 9;
                    NewField1941.TextFont.CharSet = 162;
                    NewField1941.Value = @" 6.";

                    NewField1961 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 212, 20, 217, false);
                    NewField1961.Name = "NewField1961";
                    NewField1961.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1961.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1961.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1961.TextFont.Name = "Arial";
                    NewField1961.TextFont.Size = 9;
                    NewField1961.TextFont.CharSet = 162;
                    NewField1961.Value = @" 7.";

                    NewField1491 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 217, 20, 222, false);
                    NewField1491.Name = "NewField1491";
                    NewField1491.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1491.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1491.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1491.TextFont.Name = "Arial";
                    NewField1491.TextFont.Size = 9;
                    NewField1491.TextFont.CharSet = 162;
                    NewField1491.Value = @" 8.";

                    NewField11001 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 222, 20, 227, false);
                    NewField11001.Name = "NewField11001";
                    NewField11001.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11001.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11001.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11001.TextFont.Name = "Arial";
                    NewField11001.TextFont.Size = 9;
                    NewField11001.TextFont.CharSet = 162;
                    NewField11001.Value = @" 9.";

                    NewField11021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 227, 20, 232, false);
                    NewField11021.Name = "NewField11021";
                    NewField11021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11021.TextFont.Name = "Arial";
                    NewField11021.TextFont.Size = 9;
                    NewField11021.TextFont.CharSet = 162;
                    NewField11021.Value = @" 10.";

                    NewField11041 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 197, 200, 202, false);
                    NewField11041.Name = "NewField11041";
                    NewField11041.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11041.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11041.TextFont.Name = "Arial";
                    NewField11041.TextFont.Size = 9;
                    NewField11041.TextFont.CharSet = 162;
                    NewField11041.Value = @"  Muharebe Sırasında Kullanılabilir";

                    NewField14011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 202, 189, 207, false);
                    NewField14011.Name = "NewField14011";
                    NewField14011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14011.TextFont.Name = "Arial";
                    NewField14011.TextFont.Size = 9;
                    NewField14011.TextFont.CharSet = 162;
                    NewField14011.Value = @"  Mevcut Hali İle Muharebe Sırasında Kullanılabilir";

                    NewField11051 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 207, 189, 212, false);
                    NewField11051.Name = "NewField11051";
                    NewField11051.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11051.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11051.TextFont.Name = "Arial";
                    NewField11051.TextFont.Size = 9;
                    NewField11051.TextFont.CharSet = 162;
                    NewField11051.Value = @"  Mevcut Hali İle Muharebe Sırasında Kullanılamaz";

                    NewField110661 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 212, 200, 217, false);
                    NewField110661.Name = "NewField110661";
                    NewField110661.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110661.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110661.TextFont.Name = "Arial";
                    NewField110661.TextFont.Size = 9;
                    NewField110661.TextFont.CharSet = 162;
                    NewField110661.Value = @"  Yetki Dışı İse Gideceği Kademe";

                    NewField13011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 217, 200, 232, false);
                    NewField13011.Name = "NewField13011";
                    NewField13011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13011.TextFont.Size = 8;
                    NewField13011.TextFont.CharSet = 162;
                    NewField13011.Value = @"";

                    NewField13021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 202, 200, 207, false);
                    NewField13021.Name = "NewField13021";
                    NewField13021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13021.TextFont.Size = 8;
                    NewField13021.TextFont.CharSet = 162;
                    NewField13021.Value = @"";

                    NewField12031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 189, 207, 200, 212, false);
                    NewField12031.Name = "NewField12031";
                    NewField12031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12031.TextFont.Size = 8;
                    NewField12031.TextFont.CharSet = 162;
                    NewField12031.Value = @"";

                    NewField16011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 232, 200, 239, false);
                    NewField16011.Name = "NewField16011";
                    NewField16011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField16011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField16011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField16011.TextFont.Name = "Arial";
                    NewField16011.TextFont.Size = 9;
                    NewField16011.TextFont.Bold = true;
                    NewField16011.TextFont.CharSet = 162;
                    NewField16011.Value = @"İmza Bloğu";

                    NewField110771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 239, 55, 252, false);
                    NewField110771.Name = "NewField110771";
                    NewField110771.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110771.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110771.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110771.TextFont.Name = "Arial";
                    NewField110771.TextFont.Size = 9;
                    NewField110771.TextFont.CharSet = 162;
                    NewField110771.Value = @"Malı Teslim Eden";

                    DELIVERERUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 252, 55, 262, false);
                    DELIVERERUSER.Name = "DELIVERERUSER";
                    DELIVERERUSER.DrawStyle = DrawStyleConstants.vbSolid;
                    DELIVERERUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVERERUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVERERUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVERERUSER.TextFont.Name = "Arial";
                    DELIVERERUSER.TextFont.Size = 9;
                    DELIVERERUSER.TextFont.CharSet = 162;
                    DELIVERERUSER.Value = @"";

                    NewField170111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 239, 95, 252, false);
                    NewField170111.Name = "NewField170111";
                    NewField170111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField170111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField170111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField170111.TextFont.Name = "Arial";
                    NewField170111.TextFont.Size = 9;
                    NewField170111.TextFont.CharSet = 162;
                    NewField170111.Value = @"Malı Teslim Alan";

                    DELIVEREDPERSON = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 252, 95, 262, false);
                    DELIVEREDPERSON.Name = "DELIVEREDPERSON";
                    DELIVEREDPERSON.DrawStyle = DrawStyleConstants.vbSolid;
                    DELIVEREDPERSON.FieldType = ReportFieldTypeEnum.ftVariable;
                    DELIVEREDPERSON.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    DELIVEREDPERSON.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DELIVEREDPERSON.TextFont.Name = "Arial";
                    DELIVEREDPERSON.TextFont.Size = 9;
                    DELIVEREDPERSON.TextFont.CharSet = 162;
                    DELIVEREDPERSON.Value = @"";

                    NewField170221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 239, 140, 252, false);
                    NewField170221.Name = "NewField170221";
                    NewField170221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField170221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField170221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField170221.TextFont.Name = "Arial";
                    NewField170221.TextFont.Size = 9;
                    NewField170221.TextFont.CharSet = 162;
                    NewField170221.Value = @"Onarım/İmalatı Yapan";

                    RESPONSIBLEUSER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 252, 140, 262, false);
                    RESPONSIBLEUSER.Name = "RESPONSIBLEUSER";
                    RESPONSIBLEUSER.DrawStyle = DrawStyleConstants.vbSolid;
                    RESPONSIBLEUSER.FieldType = ReportFieldTypeEnum.ftVariable;
                    RESPONSIBLEUSER.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    RESPONSIBLEUSER.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    RESPONSIBLEUSER.TextFont.Name = "Arial";
                    RESPONSIBLEUSER.TextFont.Size = 9;
                    RESPONSIBLEUSER.TextFont.CharSet = 162;
                    RESPONSIBLEUSER.Value = @"";

                    NewField17031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 239, 168, 252, false);
                    NewField17031.Name = "NewField17031";
                    NewField17031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17031.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17031.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17031.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17031.TextFont.Name = "Arial";
                    NewField17031.TextFont.Size = 9;
                    NewField17031.TextFont.CharSet = 162;
                    NewField17031.Value = @"Atölye Amiri,
D/Ds.Tk.K.";

                    NewField18031 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 252, 168, 262, false);
                    NewField18031.Name = "NewField18031";
                    NewField18031.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18031.TextFont.Size = 8;
                    NewField18031.TextFont.CharSet = 162;
                    NewField18031.Value = @"";

                    NewField17041 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 239, 200, 252, false);
                    NewField17041.Name = "NewField17041";
                    NewField17041.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17041.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17041.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17041.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17041.TextFont.Name = "Arial";
                    NewField17041.TextFont.Size = 9;
                    NewField17041.TextFont.CharSet = 162;
                    NewField17041.Value = @"Onarım/İmalatı
Müteakiben Malı
Teslim Alan";

                    NewField18041 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 252, 200, 262, false);
                    NewField18041.Name = "NewField18041";
                    NewField18041.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField18041.TextFont.Size = 8;
                    NewField18041.TextFont.CharSet = 162;
                    NewField18041.Value = @"";

                    NewField17051 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 262, 55, 271, false);
                    NewField17051.Name = "NewField17051";
                    NewField17051.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17051.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17051.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17051.TextFont.Name = "Arial";
                    NewField17051.TextFont.Size = 9;
                    NewField17051.TextFont.CharSet = 162;
                    NewField17051.Value = @"Tarih";

                    NewField120771 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 262, 140, 271, false);
                    NewField120771.Name = "NewField120771";
                    NewField120771.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField120771.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField120771.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField120771.MultiLine = EvetHayirEnum.ehEvet;
                    NewField120771.TextFont.Name = "Arial";
                    NewField120771.TextFont.Size = 9;
                    NewField120771.TextFont.CharSet = 162;
                    NewField120771.Value = @"Onarım/İmalat Başlangıç
Tarihi-Zamanı";

                    NewField13071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 262, 168, 271, false);
                    NewField13071.Name = "NewField13071";
                    NewField13071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField13071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField13071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField13071.TextFont.Name = "Arial";
                    NewField13071.TextFont.Size = 9;
                    NewField13071.TextFont.CharSet = 162;
                    NewField13071.Value = @"Onarım/İmalat
Bitiş Tarihi-Zamanı";

                    NewField14071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 262, 200, 271, false);
                    NewField14071.Name = "NewField14071";
                    NewField14071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField14071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField14071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField14071.TextFont.Name = "Arial";
                    NewField14071.TextFont.Size = 9;
                    NewField14071.TextFont.CharSet = 162;
                    NewField14071.Value = @"İade Tarihi-
Zamanı";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 15, 200, 20, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"EK-A";

                    NewField1621 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 122, 95, 127, false);
                    NewField1621.Name = "NewField1621";
                    NewField1621.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1621.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1621.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1621.TextFont.Name = "Arial";
                    NewField1621.TextFont.Size = 9;
                    NewField1621.TextFont.CharSet = 162;
                    NewField1621.Value = @"Malın Sınıfı";

                    NewField1271 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 122, 55, 127, false);
                    NewField1271.Name = "NewField1271";
                    NewField1271.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1271.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1271.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1271.TextFont.Name = "Arial";
                    NewField1271.TextFont.Size = 9;
                    NewField1271.TextFont.CharSet = 162;
                    NewField1271.Value = @"Modeli";

                    NewField115071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 262, 95, 271, false);
                    NewField115071.Name = "NewField115071";
                    NewField115071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField115071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField115071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField115071.TextFont.Name = "Arial";
                    NewField115071.TextFont.Size = 9;
                    NewField115071.TextFont.CharSet = 162;
                    NewField115071.Value = @"Tarih";

                    ACTUALDELIVERYDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 271, 55, 281, false);
                    ACTUALDELIVERYDATE.Name = "ACTUALDELIVERYDATE";
                    ACTUALDELIVERYDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTUALDELIVERYDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTUALDELIVERYDATE.TextFormat = @"dd/MM/yyyy";
                    ACTUALDELIVERYDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTUALDELIVERYDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTUALDELIVERYDATE.TextFont.Name = "Arial";
                    ACTUALDELIVERYDATE.TextFont.Size = 9;
                    ACTUALDELIVERYDATE.TextFont.CharSet = 162;
                    ACTUALDELIVERYDATE.Value = @"";

                    ACTUALDELIVERYDATE2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 271, 95, 281, false);
                    ACTUALDELIVERYDATE2.Name = "ACTUALDELIVERYDATE2";
                    ACTUALDELIVERYDATE2.DrawStyle = DrawStyleConstants.vbSolid;
                    ACTUALDELIVERYDATE2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ACTUALDELIVERYDATE2.TextFormat = @"dd/MM/yyyy";
                    ACTUALDELIVERYDATE2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ACTUALDELIVERYDATE2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ACTUALDELIVERYDATE2.TextFont.Name = "Arial";
                    ACTUALDELIVERYDATE2.TextFont.Size = 9;
                    ACTUALDELIVERYDATE2.TextFont.CharSet = 162;
                    ACTUALDELIVERYDATE2.Value = @"";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 271, 140, 281, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"dd/MM/yyyy";
                    STARTDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    STARTDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    STARTDATE.TextFont.Name = "Arial";
                    STARTDATE.TextFont.Size = 9;
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 140, 271, 168, 281, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.DrawStyle = DrawStyleConstants.vbSolid;
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"dd/MM/yyyy";
                    ENDDATE.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ENDDATE.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ENDDATE.TextFont.Name = "Arial";
                    ENDDATE.TextFont.Size = 9;
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"";

                    NewField114081 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 168, 271, 200, 281, false);
                    NewField114081.Name = "NewField114081";
                    NewField114081.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114081.TextFont.Size = 8;
                    NewField114081.TextFont.CharSet = 162;
                    NewField114081.Value = @"";

                    NewLine112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 24, 15, 281, false);
                    NewLine112.Name = "NewLine112";
                    NewLine112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine112.DrawWidth = 2;

                    NewLine122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 24, 200, 24, false);
                    NewLine122.Name = "NewLine122";
                    NewLine122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine122.DrawWidth = 2;

                    NewLine1122 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 281, 200, 281, false);
                    NewLine1122.Name = "NewLine1122";
                    NewLine1122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1122.DrawWidth = 2;

                    ITEMEQUIPMENT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 187, 95, 192, false);
                    ITEMEQUIPMENT1.Name = "ITEMEQUIPMENT1";
                    ITEMEQUIPMENT1.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT1.TextFont.Name = "Arial";
                    ITEMEQUIPMENT1.TextFont.Size = 9;
                    ITEMEQUIPMENT1.TextFont.CharSet = 162;
                    ITEMEQUIPMENT1.Value = @"";

                    ITEMEQUIPMENT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 192, 95, 197, false);
                    ITEMEQUIPMENT2.Name = "ITEMEQUIPMENT2";
                    ITEMEQUIPMENT2.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT2.TextFont.Name = "Arial";
                    ITEMEQUIPMENT2.TextFont.Size = 9;
                    ITEMEQUIPMENT2.TextFont.CharSet = 162;
                    ITEMEQUIPMENT2.Value = @"";

                    ITEMEQUIPMENT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 197, 95, 202, false);
                    ITEMEQUIPMENT3.Name = "ITEMEQUIPMENT3";
                    ITEMEQUIPMENT3.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT3.TextFont.Name = "Arial";
                    ITEMEQUIPMENT3.TextFont.Size = 9;
                    ITEMEQUIPMENT3.TextFont.CharSet = 162;
                    ITEMEQUIPMENT3.Value = @"";

                    ITEMEQUIPMENT4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 202, 95, 207, false);
                    ITEMEQUIPMENT4.Name = "ITEMEQUIPMENT4";
                    ITEMEQUIPMENT4.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT4.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT4.TextFont.Name = "Arial";
                    ITEMEQUIPMENT4.TextFont.Size = 9;
                    ITEMEQUIPMENT4.TextFont.CharSet = 162;
                    ITEMEQUIPMENT4.Value = @"";

                    ITEMEQUIPMENT5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 207, 95, 212, false);
                    ITEMEQUIPMENT5.Name = "ITEMEQUIPMENT5";
                    ITEMEQUIPMENT5.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT5.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT5.TextFont.Name = "Arial";
                    ITEMEQUIPMENT5.TextFont.Size = 9;
                    ITEMEQUIPMENT5.TextFont.CharSet = 162;
                    ITEMEQUIPMENT5.Value = @"";

                    ITEMEQUIPMENT6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 212, 95, 217, false);
                    ITEMEQUIPMENT6.Name = "ITEMEQUIPMENT6";
                    ITEMEQUIPMENT6.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT6.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT6.TextFont.Name = "Arial";
                    ITEMEQUIPMENT6.TextFont.Size = 9;
                    ITEMEQUIPMENT6.TextFont.CharSet = 162;
                    ITEMEQUIPMENT6.Value = @"";

                    ITEMEQUIPMENT7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 217, 95, 222, false);
                    ITEMEQUIPMENT7.Name = "ITEMEQUIPMENT7";
                    ITEMEQUIPMENT7.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT7.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT7.TextFont.Name = "Arial";
                    ITEMEQUIPMENT7.TextFont.Size = 9;
                    ITEMEQUIPMENT7.TextFont.CharSet = 162;
                    ITEMEQUIPMENT7.Value = @"";

                    ITEMEQUIPMENT8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 222, 95, 227, false);
                    ITEMEQUIPMENT8.Name = "ITEMEQUIPMENT8";
                    ITEMEQUIPMENT8.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT8.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT8.TextFont.Name = "Arial";
                    ITEMEQUIPMENT8.TextFont.Size = 9;
                    ITEMEQUIPMENT8.TextFont.CharSet = 162;
                    ITEMEQUIPMENT8.Value = @"";

                    ITEMEQUIPMENT9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 227, 95, 232, false);
                    ITEMEQUIPMENT9.Name = "ITEMEQUIPMENT9";
                    ITEMEQUIPMENT9.DrawStyle = DrawStyleConstants.vbSolid;
                    ITEMEQUIPMENT9.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMEQUIPMENT9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ITEMEQUIPMENT9.TextFont.Name = "Arial";
                    ITEMEQUIPMENT9.TextFont.Size = 9;
                    ITEMEQUIPMENT9.TextFont.CharSet = 162;
                    ITEMEQUIPMENT9.Value = @"";

                    OWNERMILITARYUNIT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 38, 95, 51, false);
                    OWNERMILITARYUNIT.Name = "OWNERMILITARYUNIT";
                    OWNERMILITARYUNIT.DrawStyle = DrawStyleConstants.vbSolid;
                    OWNERMILITARYUNIT.FieldType = ReportFieldTypeEnum.ftVariable;
                    OWNERMILITARYUNIT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    OWNERMILITARYUNIT.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OWNERMILITARYUNIT.MultiLine = EvetHayirEnum.ehEvet;
                    OWNERMILITARYUNIT.WordBreak = EvetHayirEnum.ehEvet;
                    OWNERMILITARYUNIT.TextFont.Name = "Arial";
                    OWNERMILITARYUNIT.TextFont.Size = 9;
                    OWNERMILITARYUNIT.TextFont.CharSet = 162;
                    OWNERMILITARYUNIT.Value = @"";

                    AMOUNT2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 127, 118, 132, false);
                    AMOUNT2.Name = "AMOUNT2";
                    AMOUNT2.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT2.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT2.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT2.TextFont.Name = "Arial";
                    AMOUNT2.TextFont.Size = 9;
                    AMOUNT2.TextFont.CharSet = 162;
                    AMOUNT2.Value = @"";

                    AMOUNT3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 132, 118, 137, false);
                    AMOUNT3.Name = "AMOUNT3";
                    AMOUNT3.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT3.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT3.TextFont.Name = "Arial";
                    AMOUNT3.TextFont.Size = 9;
                    AMOUNT3.TextFont.CharSet = 162;
                    AMOUNT3.Value = @"";

                    AMOUNT4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 137, 118, 142, false);
                    AMOUNT4.Name = "AMOUNT4";
                    AMOUNT4.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT4.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT4.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT4.TextFont.Name = "Arial";
                    AMOUNT4.TextFont.Size = 9;
                    AMOUNT4.TextFont.CharSet = 162;
                    AMOUNT4.Value = @"";

                    AMOUNT5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 142, 118, 147, false);
                    AMOUNT5.Name = "AMOUNT5";
                    AMOUNT5.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT5.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT5.TextFont.Name = "Arial";
                    AMOUNT5.TextFont.Size = 9;
                    AMOUNT5.TextFont.CharSet = 162;
                    AMOUNT5.Value = @"";

                    AMOUNT6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 147, 118, 152, false);
                    AMOUNT6.Name = "AMOUNT6";
                    AMOUNT6.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT6.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT6.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT6.TextFont.Name = "Arial";
                    AMOUNT6.TextFont.Size = 9;
                    AMOUNT6.TextFont.CharSet = 162;
                    AMOUNT6.Value = @"";

                    AMOUNT7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 152, 118, 157, false);
                    AMOUNT7.Name = "AMOUNT7";
                    AMOUNT7.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT7.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT7.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT7.TextFont.Name = "Arial";
                    AMOUNT7.TextFont.Size = 9;
                    AMOUNT7.TextFont.CharSet = 162;
                    AMOUNT7.Value = @"";

                    AMOUNT8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 157, 118, 162, false);
                    AMOUNT8.Name = "AMOUNT8";
                    AMOUNT8.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT8.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT8.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT8.TextFont.Name = "Arial";
                    AMOUNT8.TextFont.Size = 9;
                    AMOUNT8.TextFont.CharSet = 162;
                    AMOUNT8.Value = @"";

                    AMOUNT9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 162, 118, 167, false);
                    AMOUNT9.Name = "AMOUNT9";
                    AMOUNT9.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT9.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT9.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT9.TextFont.Name = "Arial";
                    AMOUNT9.TextFont.Size = 9;
                    AMOUNT9.TextFont.CharSet = 162;
                    AMOUNT9.Value = @"";

                    AMOUNT10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 167, 118, 172, false);
                    AMOUNT10.Name = "AMOUNT10";
                    AMOUNT10.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT10.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT10.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT10.TextFont.Name = "Arial";
                    AMOUNT10.TextFont.Size = 9;
                    AMOUNT10.TextFont.CharSet = 162;
                    AMOUNT10.Value = @"";

                    AMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 172, 118, 177, false);
                    AMOUNT11.Name = "AMOUNT11";
                    AMOUNT11.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT11.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT11.TextFont.Name = "Arial";
                    AMOUNT11.TextFont.Size = 9;
                    AMOUNT11.TextFont.CharSet = 162;
                    AMOUNT11.Value = @"";

                    AMOUNT12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 177, 118, 182, false);
                    AMOUNT12.Name = "AMOUNT12";
                    AMOUNT12.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT12.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT12.TextFont.Name = "Arial";
                    AMOUNT12.TextFont.Size = 9;
                    AMOUNT12.TextFont.CharSet = 162;
                    AMOUNT12.Value = @"";

                    AMOUNT13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 182, 118, 187, false);
                    AMOUNT13.Name = "AMOUNT13";
                    AMOUNT13.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT13.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT13.TextFont.Name = "Arial";
                    AMOUNT13.TextFont.Size = 9;
                    AMOUNT13.TextFont.CharSet = 162;
                    AMOUNT13.Value = @"";

                    AMOUNT14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 187, 118, 192, false);
                    AMOUNT14.Name = "AMOUNT14";
                    AMOUNT14.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT14.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT14.TextFont.Name = "Arial";
                    AMOUNT14.TextFont.Size = 9;
                    AMOUNT14.TextFont.CharSet = 162;
                    AMOUNT14.Value = @"";

                    AMOUNT15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 192, 118, 197, false);
                    AMOUNT15.Name = "AMOUNT15";
                    AMOUNT15.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT15.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT15.TextFont.Name = "Arial";
                    AMOUNT15.TextFont.Size = 9;
                    AMOUNT15.TextFont.CharSet = 162;
                    AMOUNT15.Value = @"";

                    CONSUMEDMATERIAL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 127, 200, 132, false);
                    CONSUMEDMATERIAL2.Name = "CONSUMEDMATERIAL2";
                    CONSUMEDMATERIAL2.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL2.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL2.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL2.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL2.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL2.TextFont.Size = 9;
                    CONSUMEDMATERIAL2.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL2.Value = @"";

                    CONSUMEDMATERIAL3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 132, 200, 137, false);
                    CONSUMEDMATERIAL3.Name = "CONSUMEDMATERIAL3";
                    CONSUMEDMATERIAL3.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL3.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL3.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL3.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL3.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL3.TextFont.Size = 9;
                    CONSUMEDMATERIAL3.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL3.Value = @"";

                    CONSUMEDMATERIAL4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 137, 200, 142, false);
                    CONSUMEDMATERIAL4.Name = "CONSUMEDMATERIAL4";
                    CONSUMEDMATERIAL4.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL4.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL4.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL4.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL4.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL4.TextFont.Size = 9;
                    CONSUMEDMATERIAL4.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL4.Value = @"";

                    CONSUMEDMATERIAL5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 142, 200, 147, false);
                    CONSUMEDMATERIAL5.Name = "CONSUMEDMATERIAL5";
                    CONSUMEDMATERIAL5.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL5.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL5.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL5.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL5.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL5.TextFont.Size = 9;
                    CONSUMEDMATERIAL5.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL5.Value = @"";

                    CONSUMEDMATERIAL6 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 147, 200, 152, false);
                    CONSUMEDMATERIAL6.Name = "CONSUMEDMATERIAL6";
                    CONSUMEDMATERIAL6.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL6.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL6.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL6.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL6.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL6.TextFont.Size = 9;
                    CONSUMEDMATERIAL6.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL6.Value = @"";

                    CONSUMEDMATERIAL7 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 152, 200, 157, false);
                    CONSUMEDMATERIAL7.Name = "CONSUMEDMATERIAL7";
                    CONSUMEDMATERIAL7.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL7.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL7.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL7.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL7.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL7.TextFont.Size = 9;
                    CONSUMEDMATERIAL7.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL7.Value = @"";

                    CONSUMEDMATERIAL8 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 157, 200, 162, false);
                    CONSUMEDMATERIAL8.Name = "CONSUMEDMATERIAL8";
                    CONSUMEDMATERIAL8.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL8.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL8.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL8.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL8.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL8.TextFont.Size = 9;
                    CONSUMEDMATERIAL8.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL8.Value = @"";

                    CONSUMEDMATERIAL9 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 162, 200, 167, false);
                    CONSUMEDMATERIAL9.Name = "CONSUMEDMATERIAL9";
                    CONSUMEDMATERIAL9.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL9.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL9.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL9.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL9.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL9.TextFont.Size = 9;
                    CONSUMEDMATERIAL9.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL9.Value = @"";

                    CONSUMEDMATERIAL10 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 167, 200, 172, false);
                    CONSUMEDMATERIAL10.Name = "CONSUMEDMATERIAL10";
                    CONSUMEDMATERIAL10.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL10.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL10.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL10.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL10.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL10.TextFont.Size = 9;
                    CONSUMEDMATERIAL10.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL10.Value = @"";

                    CONSUMEDMATERIAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 172, 200, 177, false);
                    CONSUMEDMATERIAL11.Name = "CONSUMEDMATERIAL11";
                    CONSUMEDMATERIAL11.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL11.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL11.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL11.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL11.TextFont.Size = 9;
                    CONSUMEDMATERIAL11.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL11.Value = @"";

                    CONSUMEDMATERIAL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 177, 200, 182, false);
                    CONSUMEDMATERIAL12.Name = "CONSUMEDMATERIAL12";
                    CONSUMEDMATERIAL12.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL12.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL12.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL12.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL12.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL12.TextFont.Size = 9;
                    CONSUMEDMATERIAL12.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL12.Value = @"";

                    CONSUMEDMATERIAL13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 182, 200, 187, false);
                    CONSUMEDMATERIAL13.Name = "CONSUMEDMATERIAL13";
                    CONSUMEDMATERIAL13.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL13.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL13.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL13.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL13.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL13.TextFont.Size = 9;
                    CONSUMEDMATERIAL13.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL13.Value = @"";

                    CONSUMEDMATERIAL14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 187, 200, 192, false);
                    CONSUMEDMATERIAL14.Name = "CONSUMEDMATERIAL14";
                    CONSUMEDMATERIAL14.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL14.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL14.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL14.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL14.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL14.TextFont.Size = 9;
                    CONSUMEDMATERIAL14.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL14.Value = @"";

                    CONSUMEDMATERIAL15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 192, 200, 197, false);
                    CONSUMEDMATERIAL15.Name = "CONSUMEDMATERIAL15";
                    CONSUMEDMATERIAL15.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL15.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL15.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL15.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL15.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL15.TextFont.Size = 9;
                    CONSUMEDMATERIAL15.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL15.Value = @"";

                    CONSUMEDMATERIAL0 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 107, 200, 122, false);
                    CONSUMEDMATERIAL0.Name = "CONSUMEDMATERIAL0";
                    CONSUMEDMATERIAL0.DrawStyle = DrawStyleConstants.vbSolid;
                    CONSUMEDMATERIAL0.FieldType = ReportFieldTypeEnum.ftVariable;
                    CONSUMEDMATERIAL0.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CONSUMEDMATERIAL0.MultiLine = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL0.WordBreak = EvetHayirEnum.ehEvet;
                    CONSUMEDMATERIAL0.TextFont.Name = "Arial";
                    CONSUMEDMATERIAL0.TextFont.Size = 9;
                    CONSUMEDMATERIAL0.TextFont.CharSet = 162;
                    CONSUMEDMATERIAL0.Value = @"";

                    NewLine1112 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 24, 200, 281, false);
                    NewLine1112.Name = "NewLine1112";
                    NewLine1112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1112.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    MATERIAL.CalcValue = @"";
                    FAULTDESCRIPTION.CalcValue = @"";
                    NewField121.CalcValue = NewField121.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField151.CalcValue = NewField151.Value;
                    NewField181.CalcValue = NewField181.Value;
                    NewField191.CalcValue = NewField191.Value;
                    NewField111.CalcValue = NewField111.Value;
                    REPAIRMILITARYUNIT.CalcValue = @"";
                    REGISTERNUMBER.CalcValue = @"";
                    ARRIVALDATE.CalcValue = @"";
                    NewField1101.CalcValue = NewField1101.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    WORKSHOP.CalcValue = @"";
                    NewField1151.CalcValue = NewField1151.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField1171.CalcValue = NewField1171.Value;
                    NewField1221.CalcValue = NewField1221.Value;
                    NewField1321.CalcValue = NewField1321.Value;
                    NewField1411.CalcValue = NewField1411.Value;
                    NewField1511.CalcValue = NewField1511.Value;
                    NewField1611.CalcValue = NewField1611.Value;
                    NewField1711.CalcValue = NewField1711.Value;
                    NewField1231.CalcValue = NewField1231.Value;
                    GENERAL.CalcValue = @"";
                    TECHNICIAN.CalcValue = @"";
                    NewField1201.CalcValue = NewField1201.Value;
                    NewField1241.CalcValue = NewField1241.Value;
                    NewField1331.CalcValue = NewField1331.Value;
                    ORDERDATE.CalcValue = @"";
                    REQUESTNO.CalcValue = @"";
                    NewField1421.CalcValue = NewField1421.Value;
                    NewField1261.CalcValue = NewField1261.Value;
                    SERIALNUMBER.CalcValue = @"";
                    MODEL.CalcValue = @"";
                    MATERIALTREE.CalcValue = @"";
                    NewField1291.CalcValue = NewField1291.Value;
                    NewField1721.CalcValue = NewField1721.Value;
                    AMOUNT0.CalcValue = @"";
                    NewField1301.CalcValue = NewField1301.Value;
                    AMOUNT1.CalcValue = @"";
                    CONSUMEDMATERIAL1.CalcValue = @"";
                    NewField1781.CalcValue = NewField1781.Value;
                    NewField1791.CalcValue = NewField1791.Value;
                    NewField1871.CalcValue = NewField1871.Value;
                    NewField1971.CalcValue = NewField1971.Value;
                    NewField1981.CalcValue = NewField1981.Value;
                    NewField1801.CalcValue = NewField1801.Value;
                    NewField1851.CalcValue = NewField1851.Value;
                    NewField1861.CalcValue = NewField1861.Value;
                    ITEMEQUIPMENT0.CalcValue = @"";
                    NewField1681.CalcValue = NewField1681.Value;
                    NewField1691.CalcValue = NewField1691.Value;
                    NewField1901.CalcValue = NewField1901.Value;
                    NewField1701.CalcValue = NewField1701.Value;
                    NewField1941.CalcValue = NewField1941.Value;
                    NewField1961.CalcValue = NewField1961.Value;
                    NewField1491.CalcValue = NewField1491.Value;
                    NewField11001.CalcValue = NewField11001.Value;
                    NewField11021.CalcValue = NewField11021.Value;
                    NewField11041.CalcValue = NewField11041.Value;
                    NewField14011.CalcValue = NewField14011.Value;
                    NewField11051.CalcValue = NewField11051.Value;
                    NewField110661.CalcValue = NewField110661.Value;
                    NewField13011.CalcValue = NewField13011.Value;
                    NewField13021.CalcValue = NewField13021.Value;
                    NewField12031.CalcValue = NewField12031.Value;
                    NewField16011.CalcValue = NewField16011.Value;
                    NewField110771.CalcValue = NewField110771.Value;
                    DELIVERERUSER.CalcValue = @"";
                    NewField170111.CalcValue = NewField170111.Value;
                    DELIVEREDPERSON.CalcValue = @"";
                    NewField170221.CalcValue = NewField170221.Value;
                    RESPONSIBLEUSER.CalcValue = @"";
                    NewField17031.CalcValue = NewField17031.Value;
                    NewField18031.CalcValue = NewField18031.Value;
                    NewField17041.CalcValue = NewField17041.Value;
                    NewField18041.CalcValue = NewField18041.Value;
                    NewField17051.CalcValue = NewField17051.Value;
                    NewField120771.CalcValue = NewField120771.Value;
                    NewField13071.CalcValue = NewField13071.Value;
                    NewField14071.CalcValue = NewField14071.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField1621.CalcValue = NewField1621.Value;
                    NewField1271.CalcValue = NewField1271.Value;
                    NewField115071.CalcValue = NewField115071.Value;
                    ACTUALDELIVERYDATE.CalcValue = @"";
                    ACTUALDELIVERYDATE2.CalcValue = @"";
                    STARTDATE.CalcValue = @"";
                    ENDDATE.CalcValue = @"";
                    NewField114081.CalcValue = NewField114081.Value;
                    ITEMEQUIPMENT1.CalcValue = @"";
                    ITEMEQUIPMENT2.CalcValue = @"";
                    ITEMEQUIPMENT3.CalcValue = @"";
                    ITEMEQUIPMENT4.CalcValue = @"";
                    ITEMEQUIPMENT5.CalcValue = @"";
                    ITEMEQUIPMENT6.CalcValue = @"";
                    ITEMEQUIPMENT7.CalcValue = @"";
                    ITEMEQUIPMENT8.CalcValue = @"";
                    ITEMEQUIPMENT9.CalcValue = @"";
                    OWNERMILITARYUNIT.CalcValue = @"";
                    AMOUNT2.CalcValue = @"";
                    AMOUNT3.CalcValue = @"";
                    AMOUNT4.CalcValue = @"";
                    AMOUNT5.CalcValue = @"";
                    AMOUNT6.CalcValue = @"";
                    AMOUNT7.CalcValue = @"";
                    AMOUNT8.CalcValue = @"";
                    AMOUNT9.CalcValue = @"";
                    AMOUNT10.CalcValue = @"";
                    AMOUNT11.CalcValue = @"";
                    AMOUNT12.CalcValue = @"";
                    AMOUNT13.CalcValue = @"";
                    AMOUNT14.CalcValue = @"";
                    AMOUNT15.CalcValue = @"";
                    CONSUMEDMATERIAL2.CalcValue = @"";
                    CONSUMEDMATERIAL3.CalcValue = @"";
                    CONSUMEDMATERIAL4.CalcValue = @"";
                    CONSUMEDMATERIAL5.CalcValue = @"";
                    CONSUMEDMATERIAL6.CalcValue = @"";
                    CONSUMEDMATERIAL7.CalcValue = @"";
                    CONSUMEDMATERIAL8.CalcValue = @"";
                    CONSUMEDMATERIAL9.CalcValue = @"";
                    CONSUMEDMATERIAL10.CalcValue = @"";
                    CONSUMEDMATERIAL11.CalcValue = @"";
                    CONSUMEDMATERIAL12.CalcValue = @"";
                    CONSUMEDMATERIAL13.CalcValue = @"";
                    CONSUMEDMATERIAL14.CalcValue = @"";
                    CONSUMEDMATERIAL15.CalcValue = @"";
                    CONSUMEDMATERIAL0.CalcValue = @"";
                    return new TTReportObject[] { MATERIAL,FAULTDESCRIPTION,NewField121,NewField131,NewField141,NewField151,NewField181,NewField191,NewField111,REPAIRMILITARYUNIT,REGISTERNUMBER,ARRIVALDATE,NewField1101,NewField1121,NewField1131,WORKSHOP,NewField1151,NewField1161,NewField1171,NewField1221,NewField1321,NewField1411,NewField1511,NewField1611,NewField1711,NewField1231,GENERAL,TECHNICIAN,NewField1201,NewField1241,NewField1331,ORDERDATE,REQUESTNO,NewField1421,NewField1261,SERIALNUMBER,MODEL,MATERIALTREE,NewField1291,NewField1721,AMOUNT0,NewField1301,AMOUNT1,CONSUMEDMATERIAL1,NewField1781,NewField1791,NewField1871,NewField1971,NewField1981,NewField1801,NewField1851,NewField1861,ITEMEQUIPMENT0,NewField1681,NewField1691,NewField1901,NewField1701,NewField1941,NewField1961,NewField1491,NewField11001,NewField11021,NewField11041,NewField14011,NewField11051,NewField110661,NewField13011,NewField13021,NewField12031,NewField16011,NewField110771,DELIVERERUSER,NewField170111,DELIVEREDPERSON,NewField170221,RESPONSIBLEUSER,NewField17031,NewField18031,NewField17041,NewField18041,NewField17051,NewField120771,NewField13071,NewField14071,NewField11,NewField1621,NewField1271,NewField115071,ACTUALDELIVERYDATE,ACTUALDELIVERYDATE2,STARTDATE,ENDDATE,NewField114081,ITEMEQUIPMENT1,ITEMEQUIPMENT2,ITEMEQUIPMENT3,ITEMEQUIPMENT4,ITEMEQUIPMENT5,ITEMEQUIPMENT6,ITEMEQUIPMENT7,ITEMEQUIPMENT8,ITEMEQUIPMENT9,OWNERMILITARYUNIT,AMOUNT2,AMOUNT3,AMOUNT4,AMOUNT5,AMOUNT6,AMOUNT7,AMOUNT8,AMOUNT9,AMOUNT10,AMOUNT11,AMOUNT12,AMOUNT13,AMOUNT14,AMOUNT15,CONSUMEDMATERIAL2,CONSUMEDMATERIAL3,CONSUMEDMATERIAL4,CONSUMEDMATERIAL5,CONSUMEDMATERIAL6,CONSUMEDMATERIAL7,CONSUMEDMATERIAL8,CONSUMEDMATERIAL9,CONSUMEDMATERIAL10,CONSUMEDMATERIAL11,CONSUMEDMATERIAL12,CONSUMEDMATERIAL13,CONSUMEDMATERIAL14,CONSUMEDMATERIAL15,CONSUMEDMATERIAL0};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    TTObjectContext ctx = new TTObjectContext(true);
            string objectID = ((IsIstekveIsEmri)ParentReport).RuntimeParameters.TTOBJECTID.ToString();
            CMRAction cmrAction = (CMRAction)ctx.GetObject(new Guid(objectID), typeof(CMRAction));

            
            if(cmrAction is CMRActionRequest)
            {
                CMRActionRequest cmrRequest = (CMRActionRequest)cmrAction;

                

                if (cmrRequest.OwnerMilitaryUnit != null)
                    OWNERMILITARYUNIT.CalcValue = cmrRequest.OwnerMilitaryUnit.Name;
                if (cmrRequest.DeviceUser != null)
                {
                    TECHNICIAN.CalcValue = "\n\n\n " + cmrRequest.DeviceUser.Name + "\n ";
                    if(cmrRequest.DeviceUser.Rank != null)
                        TECHNICIAN.CalcValue += cmrRequest.DeviceUser.Rank.ShortName + " ";
                    if(cmrRequest.DeviceUser.Title != null)
                        TECHNICIAN.CalcValue += TTObjectClasses.Common.GetEnumValueDefOfEnumValue((Enum)cmrRequest.DeviceUser.Title).DisplayText;
                }
                ORDERDATE.CalcValue = cmrRequest.RequestDate.ToString();
                REQUESTNO.CalcValue = cmrRequest.RequestNo;
                
                if (cmrRequest.FixedAssetMaterialDefinition != null)
                {
                    string materialName = string.Empty;
                    if(cmrAction.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard != null)
                    {
                        materialName = cmrAction.FixedAssetMaterialDefinition.FixedAssetDefinition.StockCard.NATOStockNO  ;
                        materialName = materialName + " - " + cmrAction.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString();
                    }
                    else
                        materialName = cmrAction.FixedAssetMaterialDefinition.FixedAssetDefinition.Name.ToString();
                    
                    MATERIAL.CalcValue = materialName.ToString(); 
                    SERIALNUMBER.CalcValue = cmrRequest.FixedAssetMaterialDefinition.SerialNumber;
                    MODEL.CalcValue = cmrRequest.FixedAssetMaterialDefinition.Model;
                    AMOUNT0.CalcValue = cmrRequest.FixedAssetMaterialAmount.ToString();
                    
                    if(cmrRequest.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                    {
                        if(cmrRequest.FixedAssetMaterialDefinition.FixedAssetDefinition.MaterialTree != null)
                            MATERIALTREE.CalcValue = cmrRequest.FixedAssetMaterialDefinition.FixedAssetDefinition.MaterialTree.Name;
                    }
                }
                else
                {
                    MATERIAL.CalcValue = ((CMRActionRequest)cmrAction).FixedAssetDefinition.Name.ToString(); // MCA
                    AMOUNT0.CalcValue = ((CMRActionRequest)cmrAction).FixedAssetMaterialAmount.ToString();
                }
                FAULTDESCRIPTION.CalcValue = cmrRequest.FaultDescription;

                if (cmrRequest.CMR_ItemEquipments.Count > 0)
                {
                    int equipmentCount;
                    if (cmrRequest.CMR_ItemEquipments.Count > 10)
                        equipmentCount = 10;
                    else
                        equipmentCount = cmrRequest.CMR_ItemEquipments.Count;
                    
                    for (int i = 0; i < equipmentCount; i++)
                    {
                        TTReportField rf = FieldsByName("ITEMEQUIPMENT" + i);
                        rf.CalcValue = " " + cmrRequest.CMR_ItemEquipments[i].ItemName;
                    }
                }
            }

            if (cmrAction is Repair)
            {
                Repair repair = (Repair)cmrAction;
                if (repair != null)
                {
                    if (repair.OwnerMilitaryUnit != null)
                        OWNERMILITARYUNIT.CalcValue = repair.OwnerMilitaryUnit.Name;
                    if (repair.ResponsibleUser != null)
                    {
                        TECHNICIAN.CalcValue = "\n\n\n " + repair.ResponsibleUser.Name + "\n ";
                        if(repair.ResponsibleUser.Rank != null)
                            TECHNICIAN.CalcValue += repair.ResponsibleUser.Rank.ShortName + " ";
                        if(repair.ResponsibleUser.Title != null)
                            TECHNICIAN.CalcValue += TTObjectClasses.Common.GetEnumValueDefOfEnumValue((Enum)repair.ResponsibleUser.Title).DisplayText;
                    }
                    ORDERDATE.CalcValue = repair.RequestDate.ToString();
                    REQUESTNO.CalcValue = repair.RequestNo;
                    if (repair.FixedAssetMaterialDefinition != null)
                    {
                        MATERIAL.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.Name;
                        SERIALNUMBER.CalcValue = repair.FixedAssetMaterialDefinition.SerialNumber;
                        MODEL.CalcValue = repair.FixedAssetMaterialDefinition.Model;
                        
                        if(repair.FixedAssetMaterialDefinition.FixedAssetDefinition != null)
                        {
                            if(repair.FixedAssetMaterialDefinition.FixedAssetDefinition.MaterialTree != null)
                                MATERIALTREE.CalcValue = repair.FixedAssetMaterialDefinition.FixedAssetDefinition.MaterialTree.Name;
                        }
                    }
                    FAULTDESCRIPTION.CalcValue = repair.FaultDescription;

                    if (repair.Repair_ItemEquipments.Count > 0)
                    {
                        int equipmentCount;
                        if (repair.Repair_ItemEquipments.Count > 10)
                            equipmentCount = 10;
                        else
                            equipmentCount = repair.Repair_ItemEquipments.Count;

                        for (int i = 0; i < equipmentCount; i++)
                        {
                            TTReportField rf = FieldsByName("ITEMEQUIPMENT" + i);
                            rf.CalcValue = " " + repair.Repair_ItemEquipments[i].ItemName;
                        }
                    }
                }
                
                WORKSHOP.CalcValue = repair.WorkShop.Name;
                RESPONSIBLEUSER.CalcValue = repair.ResponsibleUser.Name;
                if(repair.DelivererUser != null)
                    DELIVERERUSER.CalcValue = repair.DelivererUser.Name;
                DELIVEREDPERSON.CalcValue = repair.DeliveredPerson;
                ACTUALDELIVERYDATE.CalcValue = repair.ActualDeliveryDate.ToString();
                ACTUALDELIVERYDATE2.CalcValue = repair.ActualDeliveryDate.ToString();
                if (repair.UsedConsumedMaterails.Count > 0)
                {
                    int materialCount;
                    if (repair.UsedConsumedMaterails.Count > 16)
                        materialCount = 16;
                    else
                        materialCount = repair.UsedConsumedMaterails.Count;

                    for (int i = 0; i < materialCount; i++)
                    {
                        TTReportField rf = FieldsByName("AMOUNT" + i);
                        rf.CalcValue = " " + repair.UsedConsumedMaterails[i].Amount.ToString();
                        rf = FieldsByName("CONSUMEDMATERIAL" + i);
                        rf.CalcValue = " " + repair.UsedConsumedMaterails[i].Material.NATOStockNO
                            + " " + repair.UsedConsumedMaterails[i].Material.Name;
                    }
                }
                STARTDATE.CalcValue = repair.StartDate.ToString();
                ENDDATE.CalcValue = repair.EndDate.ToString();
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public IsIstekveIsEmri MyParentReport
                {
                    get { return (IsIstekveIsEmri)ParentReport; }
                }
                
                public TTReportField NewField116011;
                public TTReportField NewField111071;
                public TTReportField NewField117011;
                public TTReportField NewField112071;
                public TTReportField NewField1188011;
                public TTReportField NewField1133071;
                public TTReportField NewField1188021;
                public TTReportField NewField1144071;
                public TTReportField NewField19011;
                public TTReportField NewField15071;
                public TTReportField NewField19021;
                public TTReportField NewField111001;
                public TTReportField NewField17071;
                public TTReportField NewField12101;
                public TTReportField NewField112091;
                public TTReportField NewField111091;
                public TTReportField NewField117051;
                public TTReportField NewField112092;
                public TTReportField NewField1100111;
                public TTReportField NewField117071;
                public TTReportField NewField110121;
                public TTReportField NewField1190211;
                public TTReportField NewField111092;
                public TTReportField NewField117052;
                public TTReportField NewField112093;
                public TTReportField NewField1100112;
                public TTReportField NewField117072;
                public TTReportField NewField110122;
                public TTReportField NewField1190212;
                public TTReportField NewField111093;
                public TTReportField NewField117053;
                public TTReportField NewField112094;
                public TTReportField NewField1100113;
                public TTReportField NewField117073;
                public TTReportField NewField110123;
                public TTReportField NewField1190213;
                public TTReportField NewField111094;
                public TTReportField NewField117054;
                public TTReportField NewField112095;
                public TTReportField NewField1100114;
                public TTReportField NewField117074;
                public TTReportField NewField110124;
                public TTReportField NewField1190214;
                public TTReportField NewField111095;
                public TTReportField NewField117055;
                public TTReportField NewField112096;
                public TTReportField NewField1100115;
                public TTReportField NewField117075;
                public TTReportField NewField110125;
                public TTReportField NewField1190215;
                public TTReportField NewField111096;
                public TTReportField NewField117056;
                public TTReportField NewField112097;
                public TTReportField NewField1100116;
                public TTReportField NewField117076;
                public TTReportField NewField110126;
                public TTReportField NewField1190216;
                public TTReportField NewField111097;
                public TTReportField NewField117057;
                public TTReportField NewField112098;
                public TTReportField NewField1100117;
                public TTReportField NewField117077;
                public TTReportField NewField110127;
                public TTReportField NewField1190217;
                public TTReportField NewField111098;
                public TTReportField NewField117058;
                public TTReportField NewField112099;
                public TTReportField NewField1100118;
                public TTReportField NewField117078;
                public TTReportField NewField110128;
                public TTReportField NewField1190218;
                public TTReportField NewField111099;
                public TTReportField NewField117059;
                public TTReportField NewField112100;
                public TTReportField NewField1100119;
                public TTReportField NewField117079;
                public TTReportField NewField110129;
                public TTReportField NewField1190219;
                public TTReportField NewField111100;
                public TTReportField NewField117060;
                public TTReportField NewField112101;
                public TTReportField NewField1100120;
                public TTReportField NewField117080;
                public TTReportField NewField110130;
                public TTReportField NewField1190220;
                public TTReportField NewField111101;
                public TTReportField NewField117061;
                public TTReportField NewField112102;
                public TTReportField NewField1100121;
                public TTReportField NewField117081;
                public TTReportField NewField110131;
                public TTReportField NewField1190221;
                public TTReportField NewField111102;
                public TTReportField NewField117062;
                public TTReportField NewField112103;
                public TTReportField NewField1100122;
                public TTReportField NewField117082;
                public TTReportField NewField110132;
                public TTReportField NewField1190222;
                public TTReportField NewField111103;
                public TTReportField NewField117063;
                public TTReportField NewField112104;
                public TTReportField NewField1100123;
                public TTReportField NewField117083;
                public TTReportField NewField110133;
                public TTReportField NewField1190223;
                public TTReportField NewField111104;
                public TTReportField NewField117064;
                public TTReportField NewField112105;
                public TTReportField NewField1100124;
                public TTReportField NewField117084;
                public TTReportField NewField110134;
                public TTReportField NewField1190224;
                public TTReportField NewField111105;
                public TTReportField NewField117065;
                public TTReportField NewField112106;
                public TTReportField NewField1100125;
                public TTReportField NewField117085;
                public TTReportField NewField110135;
                public TTReportField NewField1190225;
                public TTReportField NewField111106;
                public TTReportField NewField117066;
                public TTReportField NewField112107;
                public TTReportField NewField1100126;
                public TTReportField NewField117086;
                public TTReportField NewField110136;
                public TTReportField NewField1190226;
                public TTReportField NewField111108;
                public TTReportField NewField117068;
                public TTReportField NewField112109;
                public TTReportField NewField1100128;
                public TTReportField NewField117088;
                public TTReportField NewField110138;
                public TTReportField NewField1190228;
                public TTReportField NewField1110611;
                public TTReportField NewField111111;
                public TTReportField NewField111112;
                public TTReportField NewField1111111;
                public TTReportField NewField1211111;
                public TTReportField NewField1111112;
                public TTReportField NewField1211112;
                public TTReportField NewField1111113;
                public TTReportField NewField1211113;
                public TTReportField NewField1111114;
                public TTReportShape NewLine111;
                public TTReportShape NewLine1111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1121; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 297;
                    RepeatCount = 0;
                    
                    NewField116011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 15, 200, 22, false);
                    NewField116011.Name = "NewField116011";
                    NewField116011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField116011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField116011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField116011.TextFont.Name = "Arial";
                    NewField116011.TextFont.Size = 9;
                    NewField116011.TextFont.Bold = true;
                    NewField116011.TextFont.CharSet = 162;
                    NewField116011.Value = @"Operasyon/Muayene Formu";

                    NewField111071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 22, 25, 35, false);
                    NewField111071.Name = "NewField111071";
                    NewField111071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111071.TextFont.Name = "Arial";
                    NewField111071.TextFont.Size = 9;
                    NewField111071.TextFont.Bold = true;
                    NewField111071.TextFont.CharSet = 162;
                    NewField111071.Value = @"S/NU.";

                    NewField117011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 22, 55, 35, false);
                    NewField117011.Name = "NewField117011";
                    NewField117011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117011.TextFont.Name = "Arial";
                    NewField117011.TextFont.Size = 9;
                    NewField117011.TextFont.Bold = true;
                    NewField117011.TextFont.CharSet = 162;
                    NewField117011.Value = @"YAPILACAK
İŞLEM /
ONARIMLAR";

                    NewField112071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 22, 73, 35, false);
                    NewField112071.Name = "NewField112071";
                    NewField112071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112071.TextFont.Name = "Arial";
                    NewField112071.TextFont.Size = 9;
                    NewField112071.TextFont.Bold = true;
                    NewField112071.TextFont.CharSet = 162;
                    NewField112071.Value = @"TAHMİNİ
İŞ
SAATİ";

                    NewField1188011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 22, 114, 35, false);
                    NewField1188011.Name = "NewField1188011";
                    NewField1188011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1188011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1188011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1188011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1188011.TextFont.Name = "Arial";
                    NewField1188011.TextFont.Size = 9;
                    NewField1188011.TextFont.Bold = true;
                    NewField1188011.TextFont.CharSet = 162;
                    NewField1188011.Value = @"ONARIM/İMALATI
YAPACAK ATÖLYE
D/Ds.Tk.-Ks";

                    NewField1133071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 22, 144, 35, false);
                    NewField1133071.Name = "NewField1133071";
                    NewField1133071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1133071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1133071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1133071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1133071.TextFont.Name = "Arial";
                    NewField1133071.TextFont.Size = 9;
                    NewField1133071.TextFont.Bold = true;
                    NewField1133071.TextFont.CharSet = 162;
                    NewField1133071.Value = @"MUAYENE
EDENİN
PARAFESİ";

                    NewField1188021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 22, 182, 35, false);
                    NewField1188021.Name = "NewField1188021";
                    NewField1188021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1188021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1188021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1188021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1188021.TextFont.Name = "Arial";
                    NewField1188021.TextFont.Size = 9;
                    NewField1188021.TextFont.Bold = true;
                    NewField1188021.TextFont.CharSet = 162;
                    NewField1188021.Value = @"ONARIMI/İMALATI
YAPAN TEKNİSYENİN
PARAFESİ";

                    NewField1144071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 22, 200, 35, false);
                    NewField1144071.Name = "NewField1144071";
                    NewField1144071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1144071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1144071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1144071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1144071.TextFont.Name = "Arial";
                    NewField1144071.TextFont.Size = 9;
                    NewField1144071.TextFont.Bold = true;
                    NewField1144071.TextFont.CharSet = 162;
                    NewField1144071.Value = @"GERÇEK
İŞ
SAATİ";

                    NewField19011 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 35, 25, 44, false);
                    NewField19011.Name = "NewField19011";
                    NewField19011.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19011.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19011.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19011.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19011.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19011.TextFont.Size = 8;
                    NewField19011.TextFont.CharSet = 162;
                    NewField19011.Value = @"";

                    NewField15071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 35, 55, 44, false);
                    NewField15071.Name = "NewField15071";
                    NewField15071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField15071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField15071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField15071.WordBreak = EvetHayirEnum.ehEvet;
                    NewField15071.TextFont.Size = 8;
                    NewField15071.TextFont.CharSet = 162;
                    NewField15071.Value = @"";

                    NewField19021 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 35, 73, 44, false);
                    NewField19021.Name = "NewField19021";
                    NewField19021.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField19021.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField19021.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField19021.MultiLine = EvetHayirEnum.ehEvet;
                    NewField19021.WordBreak = EvetHayirEnum.ehEvet;
                    NewField19021.TextFont.Size = 8;
                    NewField19021.TextFont.CharSet = 162;
                    NewField19021.Value = @"";

                    NewField111001 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 35, 114, 44, false);
                    NewField111001.Name = "NewField111001";
                    NewField111001.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111001.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111001.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111001.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111001.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111001.TextFont.Size = 8;
                    NewField111001.TextFont.CharSet = 162;
                    NewField111001.Value = @"";

                    NewField17071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 35, 144, 44, false);
                    NewField17071.Name = "NewField17071";
                    NewField17071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField17071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField17071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField17071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField17071.WordBreak = EvetHayirEnum.ehEvet;
                    NewField17071.TextFont.Size = 8;
                    NewField17071.TextFont.CharSet = 162;
                    NewField17071.Value = @"";

                    NewField12101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 35, 182, 44, false);
                    NewField12101.Name = "NewField12101";
                    NewField12101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField12101.WordBreak = EvetHayirEnum.ehEvet;
                    NewField12101.TextFont.Size = 8;
                    NewField12101.TextFont.CharSet = 162;
                    NewField12101.Value = @"";

                    NewField112091 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 35, 200, 44, false);
                    NewField112091.Name = "NewField112091";
                    NewField112091.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112091.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112091.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112091.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112091.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112091.TextFont.Size = 8;
                    NewField112091.TextFont.CharSet = 162;
                    NewField112091.Value = @"";

                    NewField111091 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 44, 25, 53, false);
                    NewField111091.Name = "NewField111091";
                    NewField111091.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111091.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111091.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111091.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111091.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111091.TextFont.Size = 8;
                    NewField111091.TextFont.CharSet = 162;
                    NewField111091.Value = @"";

                    NewField117051 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 44, 55, 53, false);
                    NewField117051.Name = "NewField117051";
                    NewField117051.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117051.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117051.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117051.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117051.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117051.TextFont.Size = 8;
                    NewField117051.TextFont.CharSet = 162;
                    NewField117051.Value = @"";

                    NewField112092 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 44, 73, 53, false);
                    NewField112092.Name = "NewField112092";
                    NewField112092.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112092.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112092.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112092.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112092.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112092.TextFont.Size = 8;
                    NewField112092.TextFont.CharSet = 162;
                    NewField112092.Value = @"";

                    NewField1100111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 44, 114, 53, false);
                    NewField1100111.Name = "NewField1100111";
                    NewField1100111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100111.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100111.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100111.TextFont.Size = 8;
                    NewField1100111.TextFont.CharSet = 162;
                    NewField1100111.Value = @"";

                    NewField117071 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 44, 144, 53, false);
                    NewField117071.Name = "NewField117071";
                    NewField117071.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117071.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117071.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117071.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117071.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117071.TextFont.Size = 8;
                    NewField117071.TextFont.CharSet = 162;
                    NewField117071.Value = @"";

                    NewField110121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 44, 182, 53, false);
                    NewField110121.Name = "NewField110121";
                    NewField110121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110121.TextFont.Size = 8;
                    NewField110121.TextFont.CharSet = 162;
                    NewField110121.Value = @"";

                    NewField1190211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 44, 200, 53, false);
                    NewField1190211.Name = "NewField1190211";
                    NewField1190211.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190211.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190211.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190211.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190211.TextFont.Size = 8;
                    NewField1190211.TextFont.CharSet = 162;
                    NewField1190211.Value = @"";

                    NewField111092 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 53, 25, 62, false);
                    NewField111092.Name = "NewField111092";
                    NewField111092.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111092.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111092.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111092.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111092.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111092.TextFont.Size = 8;
                    NewField111092.TextFont.CharSet = 162;
                    NewField111092.Value = @"";

                    NewField117052 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 53, 55, 62, false);
                    NewField117052.Name = "NewField117052";
                    NewField117052.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117052.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117052.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117052.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117052.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117052.TextFont.Size = 8;
                    NewField117052.TextFont.CharSet = 162;
                    NewField117052.Value = @"";

                    NewField112093 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 53, 73, 62, false);
                    NewField112093.Name = "NewField112093";
                    NewField112093.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112093.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112093.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112093.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112093.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112093.TextFont.Size = 8;
                    NewField112093.TextFont.CharSet = 162;
                    NewField112093.Value = @"";

                    NewField1100112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 53, 114, 62, false);
                    NewField1100112.Name = "NewField1100112";
                    NewField1100112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100112.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100112.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100112.TextFont.Size = 8;
                    NewField1100112.TextFont.CharSet = 162;
                    NewField1100112.Value = @"";

                    NewField117072 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 53, 144, 62, false);
                    NewField117072.Name = "NewField117072";
                    NewField117072.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117072.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117072.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117072.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117072.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117072.TextFont.Size = 8;
                    NewField117072.TextFont.CharSet = 162;
                    NewField117072.Value = @"";

                    NewField110122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 53, 182, 62, false);
                    NewField110122.Name = "NewField110122";
                    NewField110122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110122.TextFont.Size = 8;
                    NewField110122.TextFont.CharSet = 162;
                    NewField110122.Value = @"";

                    NewField1190212 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 53, 200, 62, false);
                    NewField1190212.Name = "NewField1190212";
                    NewField1190212.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190212.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190212.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190212.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190212.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190212.TextFont.Size = 8;
                    NewField1190212.TextFont.CharSet = 162;
                    NewField1190212.Value = @"";

                    NewField111093 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 62, 25, 71, false);
                    NewField111093.Name = "NewField111093";
                    NewField111093.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111093.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111093.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111093.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111093.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111093.TextFont.Size = 8;
                    NewField111093.TextFont.CharSet = 162;
                    NewField111093.Value = @"";

                    NewField117053 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 62, 55, 71, false);
                    NewField117053.Name = "NewField117053";
                    NewField117053.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117053.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117053.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117053.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117053.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117053.TextFont.Size = 8;
                    NewField117053.TextFont.CharSet = 162;
                    NewField117053.Value = @"";

                    NewField112094 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 62, 73, 71, false);
                    NewField112094.Name = "NewField112094";
                    NewField112094.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112094.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112094.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112094.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112094.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112094.TextFont.Size = 8;
                    NewField112094.TextFont.CharSet = 162;
                    NewField112094.Value = @"";

                    NewField1100113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 62, 114, 71, false);
                    NewField1100113.Name = "NewField1100113";
                    NewField1100113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100113.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100113.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100113.TextFont.Size = 8;
                    NewField1100113.TextFont.CharSet = 162;
                    NewField1100113.Value = @"";

                    NewField117073 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 62, 144, 71, false);
                    NewField117073.Name = "NewField117073";
                    NewField117073.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117073.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117073.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117073.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117073.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117073.TextFont.Size = 8;
                    NewField117073.TextFont.CharSet = 162;
                    NewField117073.Value = @"";

                    NewField110123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 62, 182, 71, false);
                    NewField110123.Name = "NewField110123";
                    NewField110123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110123.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110123.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110123.TextFont.Size = 8;
                    NewField110123.TextFont.CharSet = 162;
                    NewField110123.Value = @"";

                    NewField1190213 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 62, 200, 71, false);
                    NewField1190213.Name = "NewField1190213";
                    NewField1190213.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190213.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190213.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190213.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190213.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190213.TextFont.Size = 8;
                    NewField1190213.TextFont.CharSet = 162;
                    NewField1190213.Value = @"";

                    NewField111094 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 71, 25, 80, false);
                    NewField111094.Name = "NewField111094";
                    NewField111094.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111094.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111094.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111094.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111094.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111094.TextFont.Size = 8;
                    NewField111094.TextFont.CharSet = 162;
                    NewField111094.Value = @"";

                    NewField117054 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 71, 55, 80, false);
                    NewField117054.Name = "NewField117054";
                    NewField117054.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117054.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117054.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117054.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117054.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117054.TextFont.Size = 8;
                    NewField117054.TextFont.CharSet = 162;
                    NewField117054.Value = @"";

                    NewField112095 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 71, 73, 80, false);
                    NewField112095.Name = "NewField112095";
                    NewField112095.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112095.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112095.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112095.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112095.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112095.TextFont.Size = 8;
                    NewField112095.TextFont.CharSet = 162;
                    NewField112095.Value = @"";

                    NewField1100114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 71, 114, 80, false);
                    NewField1100114.Name = "NewField1100114";
                    NewField1100114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100114.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100114.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100114.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100114.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100114.TextFont.Size = 8;
                    NewField1100114.TextFont.CharSet = 162;
                    NewField1100114.Value = @"";

                    NewField117074 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 71, 144, 80, false);
                    NewField117074.Name = "NewField117074";
                    NewField117074.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117074.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117074.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117074.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117074.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117074.TextFont.Size = 8;
                    NewField117074.TextFont.CharSet = 162;
                    NewField117074.Value = @"";

                    NewField110124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 71, 182, 80, false);
                    NewField110124.Name = "NewField110124";
                    NewField110124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110124.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110124.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110124.TextFont.Size = 8;
                    NewField110124.TextFont.CharSet = 162;
                    NewField110124.Value = @"";

                    NewField1190214 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 71, 200, 80, false);
                    NewField1190214.Name = "NewField1190214";
                    NewField1190214.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190214.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190214.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190214.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190214.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190214.TextFont.Size = 8;
                    NewField1190214.TextFont.CharSet = 162;
                    NewField1190214.Value = @"";

                    NewField111095 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 80, 25, 89, false);
                    NewField111095.Name = "NewField111095";
                    NewField111095.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111095.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111095.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111095.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111095.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111095.TextFont.Size = 8;
                    NewField111095.TextFont.CharSet = 162;
                    NewField111095.Value = @"";

                    NewField117055 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 80, 55, 89, false);
                    NewField117055.Name = "NewField117055";
                    NewField117055.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117055.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117055.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117055.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117055.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117055.TextFont.Size = 8;
                    NewField117055.TextFont.CharSet = 162;
                    NewField117055.Value = @"";

                    NewField112096 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 80, 73, 89, false);
                    NewField112096.Name = "NewField112096";
                    NewField112096.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112096.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112096.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112096.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112096.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112096.TextFont.Size = 8;
                    NewField112096.TextFont.CharSet = 162;
                    NewField112096.Value = @"";

                    NewField1100115 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 80, 114, 89, false);
                    NewField1100115.Name = "NewField1100115";
                    NewField1100115.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100115.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100115.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100115.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100115.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100115.TextFont.Size = 8;
                    NewField1100115.TextFont.CharSet = 162;
                    NewField1100115.Value = @"";

                    NewField117075 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 80, 144, 89, false);
                    NewField117075.Name = "NewField117075";
                    NewField117075.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117075.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117075.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117075.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117075.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117075.TextFont.Size = 8;
                    NewField117075.TextFont.CharSet = 162;
                    NewField117075.Value = @"";

                    NewField110125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 80, 182, 89, false);
                    NewField110125.Name = "NewField110125";
                    NewField110125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110125.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110125.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110125.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110125.TextFont.Size = 8;
                    NewField110125.TextFont.CharSet = 162;
                    NewField110125.Value = @"";

                    NewField1190215 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 80, 200, 89, false);
                    NewField1190215.Name = "NewField1190215";
                    NewField1190215.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190215.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190215.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190215.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190215.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190215.TextFont.Size = 8;
                    NewField1190215.TextFont.CharSet = 162;
                    NewField1190215.Value = @"";

                    NewField111096 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 89, 25, 98, false);
                    NewField111096.Name = "NewField111096";
                    NewField111096.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111096.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111096.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111096.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111096.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111096.TextFont.Size = 8;
                    NewField111096.TextFont.CharSet = 162;
                    NewField111096.Value = @"";

                    NewField117056 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 89, 55, 98, false);
                    NewField117056.Name = "NewField117056";
                    NewField117056.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117056.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117056.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117056.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117056.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117056.TextFont.Size = 8;
                    NewField117056.TextFont.CharSet = 162;
                    NewField117056.Value = @"";

                    NewField112097 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 89, 73, 98, false);
                    NewField112097.Name = "NewField112097";
                    NewField112097.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112097.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112097.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112097.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112097.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112097.TextFont.Size = 8;
                    NewField112097.TextFont.CharSet = 162;
                    NewField112097.Value = @"";

                    NewField1100116 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 89, 114, 98, false);
                    NewField1100116.Name = "NewField1100116";
                    NewField1100116.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100116.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100116.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100116.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100116.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100116.TextFont.Size = 8;
                    NewField1100116.TextFont.CharSet = 162;
                    NewField1100116.Value = @"";

                    NewField117076 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 89, 144, 98, false);
                    NewField117076.Name = "NewField117076";
                    NewField117076.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117076.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117076.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117076.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117076.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117076.TextFont.Size = 8;
                    NewField117076.TextFont.CharSet = 162;
                    NewField117076.Value = @"";

                    NewField110126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 89, 182, 98, false);
                    NewField110126.Name = "NewField110126";
                    NewField110126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110126.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110126.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110126.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110126.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110126.TextFont.Size = 8;
                    NewField110126.TextFont.CharSet = 162;
                    NewField110126.Value = @"";

                    NewField1190216 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 89, 200, 98, false);
                    NewField1190216.Name = "NewField1190216";
                    NewField1190216.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190216.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190216.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190216.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190216.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190216.TextFont.Size = 8;
                    NewField1190216.TextFont.CharSet = 162;
                    NewField1190216.Value = @"";

                    NewField111097 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 98, 25, 107, false);
                    NewField111097.Name = "NewField111097";
                    NewField111097.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111097.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111097.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111097.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111097.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111097.TextFont.Size = 8;
                    NewField111097.TextFont.CharSet = 162;
                    NewField111097.Value = @"";

                    NewField117057 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 98, 55, 107, false);
                    NewField117057.Name = "NewField117057";
                    NewField117057.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117057.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117057.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117057.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117057.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117057.TextFont.Size = 8;
                    NewField117057.TextFont.CharSet = 162;
                    NewField117057.Value = @"";

                    NewField112098 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 98, 73, 107, false);
                    NewField112098.Name = "NewField112098";
                    NewField112098.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112098.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112098.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112098.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112098.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112098.TextFont.Size = 8;
                    NewField112098.TextFont.CharSet = 162;
                    NewField112098.Value = @"";

                    NewField1100117 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 98, 114, 107, false);
                    NewField1100117.Name = "NewField1100117";
                    NewField1100117.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100117.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100117.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100117.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100117.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100117.TextFont.Size = 8;
                    NewField1100117.TextFont.CharSet = 162;
                    NewField1100117.Value = @"";

                    NewField117077 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 98, 144, 107, false);
                    NewField117077.Name = "NewField117077";
                    NewField117077.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117077.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117077.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117077.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117077.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117077.TextFont.Size = 8;
                    NewField117077.TextFont.CharSet = 162;
                    NewField117077.Value = @"";

                    NewField110127 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 98, 182, 107, false);
                    NewField110127.Name = "NewField110127";
                    NewField110127.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110127.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110127.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110127.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110127.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110127.TextFont.Size = 8;
                    NewField110127.TextFont.CharSet = 162;
                    NewField110127.Value = @"";

                    NewField1190217 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 98, 200, 107, false);
                    NewField1190217.Name = "NewField1190217";
                    NewField1190217.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190217.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190217.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190217.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190217.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190217.TextFont.Size = 8;
                    NewField1190217.TextFont.CharSet = 162;
                    NewField1190217.Value = @"";

                    NewField111098 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 107, 25, 116, false);
                    NewField111098.Name = "NewField111098";
                    NewField111098.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111098.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111098.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111098.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111098.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111098.TextFont.Size = 8;
                    NewField111098.TextFont.CharSet = 162;
                    NewField111098.Value = @"";

                    NewField117058 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 107, 55, 116, false);
                    NewField117058.Name = "NewField117058";
                    NewField117058.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117058.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117058.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117058.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117058.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117058.TextFont.Size = 8;
                    NewField117058.TextFont.CharSet = 162;
                    NewField117058.Value = @"";

                    NewField112099 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 107, 73, 116, false);
                    NewField112099.Name = "NewField112099";
                    NewField112099.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112099.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112099.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112099.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112099.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112099.TextFont.Size = 8;
                    NewField112099.TextFont.CharSet = 162;
                    NewField112099.Value = @"";

                    NewField1100118 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 107, 114, 116, false);
                    NewField1100118.Name = "NewField1100118";
                    NewField1100118.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100118.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100118.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100118.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100118.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100118.TextFont.Size = 8;
                    NewField1100118.TextFont.CharSet = 162;
                    NewField1100118.Value = @"";

                    NewField117078 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 107, 144, 116, false);
                    NewField117078.Name = "NewField117078";
                    NewField117078.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117078.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117078.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117078.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117078.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117078.TextFont.Size = 8;
                    NewField117078.TextFont.CharSet = 162;
                    NewField117078.Value = @"";

                    NewField110128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 107, 182, 116, false);
                    NewField110128.Name = "NewField110128";
                    NewField110128.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110128.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110128.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110128.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110128.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110128.TextFont.Size = 8;
                    NewField110128.TextFont.CharSet = 162;
                    NewField110128.Value = @"";

                    NewField1190218 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 107, 200, 116, false);
                    NewField1190218.Name = "NewField1190218";
                    NewField1190218.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190218.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190218.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190218.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190218.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190218.TextFont.Size = 8;
                    NewField1190218.TextFont.CharSet = 162;
                    NewField1190218.Value = @"";

                    NewField111099 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 116, 25, 125, false);
                    NewField111099.Name = "NewField111099";
                    NewField111099.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111099.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111099.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111099.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111099.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111099.TextFont.Size = 8;
                    NewField111099.TextFont.CharSet = 162;
                    NewField111099.Value = @"";

                    NewField117059 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 116, 55, 125, false);
                    NewField117059.Name = "NewField117059";
                    NewField117059.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117059.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117059.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117059.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117059.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117059.TextFont.Size = 8;
                    NewField117059.TextFont.CharSet = 162;
                    NewField117059.Value = @"";

                    NewField112100 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 116, 73, 125, false);
                    NewField112100.Name = "NewField112100";
                    NewField112100.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112100.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112100.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112100.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112100.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112100.TextFont.Size = 8;
                    NewField112100.TextFont.CharSet = 162;
                    NewField112100.Value = @"";

                    NewField1100119 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 116, 114, 125, false);
                    NewField1100119.Name = "NewField1100119";
                    NewField1100119.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100119.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100119.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100119.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100119.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100119.TextFont.Size = 8;
                    NewField1100119.TextFont.CharSet = 162;
                    NewField1100119.Value = @"";

                    NewField117079 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 116, 144, 125, false);
                    NewField117079.Name = "NewField117079";
                    NewField117079.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117079.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117079.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117079.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117079.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117079.TextFont.Size = 8;
                    NewField117079.TextFont.CharSet = 162;
                    NewField117079.Value = @"";

                    NewField110129 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 116, 182, 125, false);
                    NewField110129.Name = "NewField110129";
                    NewField110129.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110129.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110129.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110129.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110129.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110129.TextFont.Size = 8;
                    NewField110129.TextFont.CharSet = 162;
                    NewField110129.Value = @"";

                    NewField1190219 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 116, 200, 125, false);
                    NewField1190219.Name = "NewField1190219";
                    NewField1190219.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190219.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190219.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190219.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190219.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190219.TextFont.Size = 8;
                    NewField1190219.TextFont.CharSet = 162;
                    NewField1190219.Value = @"";

                    NewField111100 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 125, 25, 134, false);
                    NewField111100.Name = "NewField111100";
                    NewField111100.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111100.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111100.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111100.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111100.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111100.TextFont.Size = 8;
                    NewField111100.TextFont.CharSet = 162;
                    NewField111100.Value = @"";

                    NewField117060 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 125, 55, 134, false);
                    NewField117060.Name = "NewField117060";
                    NewField117060.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117060.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117060.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117060.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117060.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117060.TextFont.Size = 8;
                    NewField117060.TextFont.CharSet = 162;
                    NewField117060.Value = @"";

                    NewField112101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 125, 73, 134, false);
                    NewField112101.Name = "NewField112101";
                    NewField112101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112101.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112101.TextFont.Size = 8;
                    NewField112101.TextFont.CharSet = 162;
                    NewField112101.Value = @"";

                    NewField1100120 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 125, 114, 134, false);
                    NewField1100120.Name = "NewField1100120";
                    NewField1100120.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100120.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100120.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100120.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100120.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100120.TextFont.Size = 8;
                    NewField1100120.TextFont.CharSet = 162;
                    NewField1100120.Value = @"";

                    NewField117080 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 125, 144, 134, false);
                    NewField117080.Name = "NewField117080";
                    NewField117080.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117080.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117080.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117080.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117080.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117080.TextFont.Size = 8;
                    NewField117080.TextFont.CharSet = 162;
                    NewField117080.Value = @"";

                    NewField110130 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 125, 182, 134, false);
                    NewField110130.Name = "NewField110130";
                    NewField110130.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110130.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110130.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110130.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110130.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110130.TextFont.Size = 8;
                    NewField110130.TextFont.CharSet = 162;
                    NewField110130.Value = @"";

                    NewField1190220 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 125, 200, 134, false);
                    NewField1190220.Name = "NewField1190220";
                    NewField1190220.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190220.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190220.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190220.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190220.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190220.TextFont.Size = 8;
                    NewField1190220.TextFont.CharSet = 162;
                    NewField1190220.Value = @"";

                    NewField111101 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 134, 25, 143, false);
                    NewField111101.Name = "NewField111101";
                    NewField111101.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111101.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111101.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111101.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111101.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111101.TextFont.Size = 8;
                    NewField111101.TextFont.CharSet = 162;
                    NewField111101.Value = @"";

                    NewField117061 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 134, 55, 143, false);
                    NewField117061.Name = "NewField117061";
                    NewField117061.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117061.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117061.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117061.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117061.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117061.TextFont.Size = 8;
                    NewField117061.TextFont.CharSet = 162;
                    NewField117061.Value = @"";

                    NewField112102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 134, 73, 143, false);
                    NewField112102.Name = "NewField112102";
                    NewField112102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112102.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112102.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112102.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112102.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112102.TextFont.Size = 8;
                    NewField112102.TextFont.CharSet = 162;
                    NewField112102.Value = @"";

                    NewField1100121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 134, 114, 143, false);
                    NewField1100121.Name = "NewField1100121";
                    NewField1100121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100121.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100121.TextFont.Size = 8;
                    NewField1100121.TextFont.CharSet = 162;
                    NewField1100121.Value = @"";

                    NewField117081 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 134, 144, 143, false);
                    NewField117081.Name = "NewField117081";
                    NewField117081.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117081.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117081.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117081.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117081.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117081.TextFont.Size = 8;
                    NewField117081.TextFont.CharSet = 162;
                    NewField117081.Value = @"";

                    NewField110131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 134, 182, 143, false);
                    NewField110131.Name = "NewField110131";
                    NewField110131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110131.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110131.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110131.TextFont.Size = 8;
                    NewField110131.TextFont.CharSet = 162;
                    NewField110131.Value = @"";

                    NewField1190221 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 134, 200, 143, false);
                    NewField1190221.Name = "NewField1190221";
                    NewField1190221.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190221.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190221.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190221.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190221.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190221.TextFont.Size = 8;
                    NewField1190221.TextFont.CharSet = 162;
                    NewField1190221.Value = @"";

                    NewField111102 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 143, 25, 152, false);
                    NewField111102.Name = "NewField111102";
                    NewField111102.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111102.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111102.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111102.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111102.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111102.TextFont.Size = 8;
                    NewField111102.TextFont.CharSet = 162;
                    NewField111102.Value = @"";

                    NewField117062 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 143, 55, 152, false);
                    NewField117062.Name = "NewField117062";
                    NewField117062.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117062.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117062.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117062.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117062.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117062.TextFont.Size = 8;
                    NewField117062.TextFont.CharSet = 162;
                    NewField117062.Value = @"";

                    NewField112103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 143, 73, 152, false);
                    NewField112103.Name = "NewField112103";
                    NewField112103.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112103.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112103.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112103.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112103.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112103.TextFont.Size = 8;
                    NewField112103.TextFont.CharSet = 162;
                    NewField112103.Value = @"";

                    NewField1100122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 143, 114, 152, false);
                    NewField1100122.Name = "NewField1100122";
                    NewField1100122.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100122.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100122.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100122.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100122.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100122.TextFont.Size = 8;
                    NewField1100122.TextFont.CharSet = 162;
                    NewField1100122.Value = @"";

                    NewField117082 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 143, 144, 152, false);
                    NewField117082.Name = "NewField117082";
                    NewField117082.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117082.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117082.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117082.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117082.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117082.TextFont.Size = 8;
                    NewField117082.TextFont.CharSet = 162;
                    NewField117082.Value = @"";

                    NewField110132 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 143, 182, 152, false);
                    NewField110132.Name = "NewField110132";
                    NewField110132.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110132.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110132.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110132.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110132.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110132.TextFont.Size = 8;
                    NewField110132.TextFont.CharSet = 162;
                    NewField110132.Value = @"";

                    NewField1190222 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 143, 200, 152, false);
                    NewField1190222.Name = "NewField1190222";
                    NewField1190222.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190222.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190222.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190222.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190222.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190222.TextFont.Size = 8;
                    NewField1190222.TextFont.CharSet = 162;
                    NewField1190222.Value = @"";

                    NewField111103 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 152, 25, 161, false);
                    NewField111103.Name = "NewField111103";
                    NewField111103.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111103.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111103.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111103.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111103.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111103.TextFont.Size = 8;
                    NewField111103.TextFont.CharSet = 162;
                    NewField111103.Value = @"";

                    NewField117063 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 152, 55, 161, false);
                    NewField117063.Name = "NewField117063";
                    NewField117063.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117063.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117063.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117063.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117063.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117063.TextFont.Size = 8;
                    NewField117063.TextFont.CharSet = 162;
                    NewField117063.Value = @"";

                    NewField112104 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 152, 73, 161, false);
                    NewField112104.Name = "NewField112104";
                    NewField112104.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112104.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112104.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112104.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112104.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112104.TextFont.Size = 8;
                    NewField112104.TextFont.CharSet = 162;
                    NewField112104.Value = @"";

                    NewField1100123 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 152, 114, 161, false);
                    NewField1100123.Name = "NewField1100123";
                    NewField1100123.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100123.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100123.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100123.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100123.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100123.TextFont.Size = 8;
                    NewField1100123.TextFont.CharSet = 162;
                    NewField1100123.Value = @"";

                    NewField117083 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 152, 144, 161, false);
                    NewField117083.Name = "NewField117083";
                    NewField117083.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117083.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117083.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117083.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117083.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117083.TextFont.Size = 8;
                    NewField117083.TextFont.CharSet = 162;
                    NewField117083.Value = @"";

                    NewField110133 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 152, 182, 161, false);
                    NewField110133.Name = "NewField110133";
                    NewField110133.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110133.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110133.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110133.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110133.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110133.TextFont.Size = 8;
                    NewField110133.TextFont.CharSet = 162;
                    NewField110133.Value = @"";

                    NewField1190223 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 152, 200, 161, false);
                    NewField1190223.Name = "NewField1190223";
                    NewField1190223.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190223.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190223.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190223.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190223.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190223.TextFont.Size = 8;
                    NewField1190223.TextFont.CharSet = 162;
                    NewField1190223.Value = @"";

                    NewField111104 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 161, 25, 170, false);
                    NewField111104.Name = "NewField111104";
                    NewField111104.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111104.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111104.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111104.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111104.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111104.TextFont.Size = 8;
                    NewField111104.TextFont.CharSet = 162;
                    NewField111104.Value = @"";

                    NewField117064 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 161, 55, 170, false);
                    NewField117064.Name = "NewField117064";
                    NewField117064.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117064.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117064.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117064.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117064.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117064.TextFont.Size = 8;
                    NewField117064.TextFont.CharSet = 162;
                    NewField117064.Value = @"";

                    NewField112105 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 161, 73, 170, false);
                    NewField112105.Name = "NewField112105";
                    NewField112105.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112105.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112105.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112105.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112105.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112105.TextFont.Size = 8;
                    NewField112105.TextFont.CharSet = 162;
                    NewField112105.Value = @"";

                    NewField1100124 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 161, 114, 170, false);
                    NewField1100124.Name = "NewField1100124";
                    NewField1100124.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100124.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100124.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100124.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100124.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100124.TextFont.Size = 8;
                    NewField1100124.TextFont.CharSet = 162;
                    NewField1100124.Value = @"";

                    NewField117084 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 161, 144, 170, false);
                    NewField117084.Name = "NewField117084";
                    NewField117084.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117084.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117084.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117084.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117084.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117084.TextFont.Size = 8;
                    NewField117084.TextFont.CharSet = 162;
                    NewField117084.Value = @"";

                    NewField110134 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 161, 182, 170, false);
                    NewField110134.Name = "NewField110134";
                    NewField110134.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110134.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110134.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110134.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110134.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110134.TextFont.Size = 8;
                    NewField110134.TextFont.CharSet = 162;
                    NewField110134.Value = @"";

                    NewField1190224 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 161, 200, 170, false);
                    NewField1190224.Name = "NewField1190224";
                    NewField1190224.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190224.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190224.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190224.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190224.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190224.TextFont.Size = 8;
                    NewField1190224.TextFont.CharSet = 162;
                    NewField1190224.Value = @"";

                    NewField111105 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 170, 25, 179, false);
                    NewField111105.Name = "NewField111105";
                    NewField111105.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111105.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111105.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111105.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111105.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111105.TextFont.Size = 8;
                    NewField111105.TextFont.CharSet = 162;
                    NewField111105.Value = @"";

                    NewField117065 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 170, 55, 179, false);
                    NewField117065.Name = "NewField117065";
                    NewField117065.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117065.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117065.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117065.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117065.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117065.TextFont.Size = 8;
                    NewField117065.TextFont.CharSet = 162;
                    NewField117065.Value = @"";

                    NewField112106 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 170, 73, 179, false);
                    NewField112106.Name = "NewField112106";
                    NewField112106.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112106.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112106.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112106.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112106.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112106.TextFont.Size = 8;
                    NewField112106.TextFont.CharSet = 162;
                    NewField112106.Value = @"";

                    NewField1100125 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 170, 114, 179, false);
                    NewField1100125.Name = "NewField1100125";
                    NewField1100125.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100125.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100125.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100125.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100125.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100125.TextFont.Size = 8;
                    NewField1100125.TextFont.CharSet = 162;
                    NewField1100125.Value = @"";

                    NewField117085 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 170, 144, 179, false);
                    NewField117085.Name = "NewField117085";
                    NewField117085.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117085.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117085.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117085.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117085.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117085.TextFont.Size = 8;
                    NewField117085.TextFont.CharSet = 162;
                    NewField117085.Value = @"";

                    NewField110135 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 170, 182, 179, false);
                    NewField110135.Name = "NewField110135";
                    NewField110135.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110135.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110135.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110135.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110135.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110135.TextFont.Size = 8;
                    NewField110135.TextFont.CharSet = 162;
                    NewField110135.Value = @"";

                    NewField1190225 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 170, 200, 179, false);
                    NewField1190225.Name = "NewField1190225";
                    NewField1190225.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190225.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190225.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190225.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190225.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190225.TextFont.Size = 8;
                    NewField1190225.TextFont.CharSet = 162;
                    NewField1190225.Value = @"";

                    NewField111106 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 179, 25, 188, false);
                    NewField111106.Name = "NewField111106";
                    NewField111106.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111106.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111106.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111106.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111106.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111106.TextFont.Size = 8;
                    NewField111106.TextFont.CharSet = 162;
                    NewField111106.Value = @"";

                    NewField117066 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 179, 55, 188, false);
                    NewField117066.Name = "NewField117066";
                    NewField117066.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117066.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117066.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117066.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117066.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117066.TextFont.Size = 8;
                    NewField117066.TextFont.CharSet = 162;
                    NewField117066.Value = @"";

                    NewField112107 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 179, 73, 188, false);
                    NewField112107.Name = "NewField112107";
                    NewField112107.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112107.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112107.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112107.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112107.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112107.TextFont.Size = 8;
                    NewField112107.TextFont.CharSet = 162;
                    NewField112107.Value = @"";

                    NewField1100126 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 179, 114, 188, false);
                    NewField1100126.Name = "NewField1100126";
                    NewField1100126.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100126.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100126.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100126.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100126.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100126.TextFont.Size = 8;
                    NewField1100126.TextFont.CharSet = 162;
                    NewField1100126.Value = @"";

                    NewField117086 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 179, 144, 188, false);
                    NewField117086.Name = "NewField117086";
                    NewField117086.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117086.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117086.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117086.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117086.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117086.TextFont.Size = 8;
                    NewField117086.TextFont.CharSet = 162;
                    NewField117086.Value = @"";

                    NewField110136 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 179, 182, 188, false);
                    NewField110136.Name = "NewField110136";
                    NewField110136.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110136.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110136.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110136.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110136.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110136.TextFont.Size = 8;
                    NewField110136.TextFont.CharSet = 162;
                    NewField110136.Value = @"";

                    NewField1190226 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 179, 200, 188, false);
                    NewField1190226.Name = "NewField1190226";
                    NewField1190226.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190226.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190226.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190226.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190226.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190226.TextFont.Size = 8;
                    NewField1190226.TextFont.CharSet = 162;
                    NewField1190226.Value = @"";

                    NewField111108 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 188, 25, 197, false);
                    NewField111108.Name = "NewField111108";
                    NewField111108.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111108.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111108.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111108.MultiLine = EvetHayirEnum.ehEvet;
                    NewField111108.WordBreak = EvetHayirEnum.ehEvet;
                    NewField111108.TextFont.Size = 8;
                    NewField111108.TextFont.CharSet = 162;
                    NewField111108.Value = @"";

                    NewField117068 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 25, 188, 55, 197, false);
                    NewField117068.Name = "NewField117068";
                    NewField117068.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117068.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117068.TextFont.Name = "Arial";
                    NewField117068.TextFont.Size = 9;
                    NewField117068.TextFont.Bold = true;
                    NewField117068.TextFont.CharSet = 162;
                    NewField117068.Value = @"  TOPLAM";

                    NewField112109 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 188, 73, 197, false);
                    NewField112109.Name = "NewField112109";
                    NewField112109.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField112109.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField112109.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField112109.MultiLine = EvetHayirEnum.ehEvet;
                    NewField112109.WordBreak = EvetHayirEnum.ehEvet;
                    NewField112109.TextFont.Size = 8;
                    NewField112109.TextFont.CharSet = 162;
                    NewField112109.Value = @"";

                    NewField1100128 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 73, 188, 114, 197, false);
                    NewField1100128.Name = "NewField1100128";
                    NewField1100128.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1100128.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1100128.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1100128.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1100128.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1100128.TextFont.Size = 8;
                    NewField1100128.TextFont.CharSet = 162;
                    NewField1100128.Value = @"";

                    NewField117088 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 114, 188, 144, 197, false);
                    NewField117088.Name = "NewField117088";
                    NewField117088.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField117088.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField117088.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField117088.MultiLine = EvetHayirEnum.ehEvet;
                    NewField117088.WordBreak = EvetHayirEnum.ehEvet;
                    NewField117088.TextFont.Size = 8;
                    NewField117088.TextFont.CharSet = 162;
                    NewField117088.Value = @"";

                    NewField110138 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 144, 188, 182, 197, false);
                    NewField110138.Name = "NewField110138";
                    NewField110138.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField110138.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField110138.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField110138.MultiLine = EvetHayirEnum.ehEvet;
                    NewField110138.WordBreak = EvetHayirEnum.ehEvet;
                    NewField110138.TextFont.Size = 8;
                    NewField110138.TextFont.CharSet = 162;
                    NewField110138.Value = @"";

                    NewField1190228 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 182, 188, 200, 197, false);
                    NewField1190228.Name = "NewField1190228";
                    NewField1190228.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1190228.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1190228.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1190228.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1190228.WordBreak = EvetHayirEnum.ehEvet;
                    NewField1190228.TextFont.Size = 8;
                    NewField1190228.TextFont.CharSet = 162;
                    NewField1190228.Value = @"";

                    NewField1110611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 197, 200, 204, false);
                    NewField1110611.Name = "NewField1110611";
                    NewField1110611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1110611.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1110611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1110611.TextFont.Name = "Arial";
                    NewField1110611.TextFont.Size = 9;
                    NewField1110611.TextFont.Bold = true;
                    NewField1110611.TextFont.CharSet = 162;
                    NewField1110611.Value = @"VARSA KULLANILAN İLAVE MALZEMELER";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 204, 108, 213, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111111.TextFont.Size = 8;
                    NewField111111.TextFont.CharSet = 162;
                    NewField111111.Value = @"";

                    NewField111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 204, 200, 213, false);
                    NewField111112.Name = "NewField111112";
                    NewField111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField111112.TextFont.Size = 8;
                    NewField111112.TextFont.CharSet = 162;
                    NewField111112.Value = @"";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 213, 108, 222, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111111.TextFont.Size = 8;
                    NewField1111111.TextFont.CharSet = 162;
                    NewField1111111.Value = @"";

                    NewField1211111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 213, 200, 222, false);
                    NewField1211111.Name = "NewField1211111";
                    NewField1211111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211111.TextFont.Size = 8;
                    NewField1211111.TextFont.CharSet = 162;
                    NewField1211111.Value = @"";

                    NewField1111112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 222, 108, 231, false);
                    NewField1111112.Name = "NewField1111112";
                    NewField1111112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111112.TextFont.Size = 8;
                    NewField1111112.TextFont.CharSet = 162;
                    NewField1111112.Value = @"";

                    NewField1211112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 222, 200, 231, false);
                    NewField1211112.Name = "NewField1211112";
                    NewField1211112.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211112.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211112.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211112.TextFont.Size = 8;
                    NewField1211112.TextFont.CharSet = 162;
                    NewField1211112.Value = @"";

                    NewField1111113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 231, 108, 240, false);
                    NewField1111113.Name = "NewField1111113";
                    NewField1111113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1111113.TextFont.Size = 8;
                    NewField1111113.TextFont.CharSet = 162;
                    NewField1111113.Value = @"";

                    NewField1211113 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 108, 231, 200, 240, false);
                    NewField1211113.Name = "NewField1211113";
                    NewField1211113.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1211113.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1211113.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1211113.TextFont.Size = 8;
                    NewField1211113.TextFont.CharSet = 162;
                    NewField1211113.Value = @"";

                    NewField1111114 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 240, 200, 281, false);
                    NewField1111114.Name = "NewField1111114";
                    NewField1111114.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1111114.TextFont.Name = "Arial";
                    NewField1111114.TextFont.Size = 9;
                    NewField1111114.TextFont.Bold = true;
                    NewField1111114.TextFont.CharSet = 162;
                    NewField1111114.Value = @"  AÇIKLAMALAR";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 15, 15, 281, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 15, 200, 281, false);
                    NewLine1111.Name = "NewLine1111";
                    NewLine1111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1111.DrawWidth = 2;

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 15, 200, 15, false);
                    NewLine121.Name = "NewLine121";
                    NewLine121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine121.DrawWidth = 2;

                    NewLine1121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 15, 281, 200, 281, false);
                    NewLine1121.Name = "NewLine1121";
                    NewLine1121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine1121.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField116011.CalcValue = NewField116011.Value;
                    NewField111071.CalcValue = NewField111071.Value;
                    NewField117011.CalcValue = NewField117011.Value;
                    NewField112071.CalcValue = NewField112071.Value;
                    NewField1188011.CalcValue = NewField1188011.Value;
                    NewField1133071.CalcValue = NewField1133071.Value;
                    NewField1188021.CalcValue = NewField1188021.Value;
                    NewField1144071.CalcValue = NewField1144071.Value;
                    NewField19011.CalcValue = NewField19011.Value;
                    NewField15071.CalcValue = NewField15071.Value;
                    NewField19021.CalcValue = NewField19021.Value;
                    NewField111001.CalcValue = NewField111001.Value;
                    NewField17071.CalcValue = NewField17071.Value;
                    NewField12101.CalcValue = NewField12101.Value;
                    NewField112091.CalcValue = NewField112091.Value;
                    NewField111091.CalcValue = NewField111091.Value;
                    NewField117051.CalcValue = NewField117051.Value;
                    NewField112092.CalcValue = NewField112092.Value;
                    NewField1100111.CalcValue = NewField1100111.Value;
                    NewField117071.CalcValue = NewField117071.Value;
                    NewField110121.CalcValue = NewField110121.Value;
                    NewField1190211.CalcValue = NewField1190211.Value;
                    NewField111092.CalcValue = NewField111092.Value;
                    NewField117052.CalcValue = NewField117052.Value;
                    NewField112093.CalcValue = NewField112093.Value;
                    NewField1100112.CalcValue = NewField1100112.Value;
                    NewField117072.CalcValue = NewField117072.Value;
                    NewField110122.CalcValue = NewField110122.Value;
                    NewField1190212.CalcValue = NewField1190212.Value;
                    NewField111093.CalcValue = NewField111093.Value;
                    NewField117053.CalcValue = NewField117053.Value;
                    NewField112094.CalcValue = NewField112094.Value;
                    NewField1100113.CalcValue = NewField1100113.Value;
                    NewField117073.CalcValue = NewField117073.Value;
                    NewField110123.CalcValue = NewField110123.Value;
                    NewField1190213.CalcValue = NewField1190213.Value;
                    NewField111094.CalcValue = NewField111094.Value;
                    NewField117054.CalcValue = NewField117054.Value;
                    NewField112095.CalcValue = NewField112095.Value;
                    NewField1100114.CalcValue = NewField1100114.Value;
                    NewField117074.CalcValue = NewField117074.Value;
                    NewField110124.CalcValue = NewField110124.Value;
                    NewField1190214.CalcValue = NewField1190214.Value;
                    NewField111095.CalcValue = NewField111095.Value;
                    NewField117055.CalcValue = NewField117055.Value;
                    NewField112096.CalcValue = NewField112096.Value;
                    NewField1100115.CalcValue = NewField1100115.Value;
                    NewField117075.CalcValue = NewField117075.Value;
                    NewField110125.CalcValue = NewField110125.Value;
                    NewField1190215.CalcValue = NewField1190215.Value;
                    NewField111096.CalcValue = NewField111096.Value;
                    NewField117056.CalcValue = NewField117056.Value;
                    NewField112097.CalcValue = NewField112097.Value;
                    NewField1100116.CalcValue = NewField1100116.Value;
                    NewField117076.CalcValue = NewField117076.Value;
                    NewField110126.CalcValue = NewField110126.Value;
                    NewField1190216.CalcValue = NewField1190216.Value;
                    NewField111097.CalcValue = NewField111097.Value;
                    NewField117057.CalcValue = NewField117057.Value;
                    NewField112098.CalcValue = NewField112098.Value;
                    NewField1100117.CalcValue = NewField1100117.Value;
                    NewField117077.CalcValue = NewField117077.Value;
                    NewField110127.CalcValue = NewField110127.Value;
                    NewField1190217.CalcValue = NewField1190217.Value;
                    NewField111098.CalcValue = NewField111098.Value;
                    NewField117058.CalcValue = NewField117058.Value;
                    NewField112099.CalcValue = NewField112099.Value;
                    NewField1100118.CalcValue = NewField1100118.Value;
                    NewField117078.CalcValue = NewField117078.Value;
                    NewField110128.CalcValue = NewField110128.Value;
                    NewField1190218.CalcValue = NewField1190218.Value;
                    NewField111099.CalcValue = NewField111099.Value;
                    NewField117059.CalcValue = NewField117059.Value;
                    NewField112100.CalcValue = NewField112100.Value;
                    NewField1100119.CalcValue = NewField1100119.Value;
                    NewField117079.CalcValue = NewField117079.Value;
                    NewField110129.CalcValue = NewField110129.Value;
                    NewField1190219.CalcValue = NewField1190219.Value;
                    NewField111100.CalcValue = NewField111100.Value;
                    NewField117060.CalcValue = NewField117060.Value;
                    NewField112101.CalcValue = NewField112101.Value;
                    NewField1100120.CalcValue = NewField1100120.Value;
                    NewField117080.CalcValue = NewField117080.Value;
                    NewField110130.CalcValue = NewField110130.Value;
                    NewField1190220.CalcValue = NewField1190220.Value;
                    NewField111101.CalcValue = NewField111101.Value;
                    NewField117061.CalcValue = NewField117061.Value;
                    NewField112102.CalcValue = NewField112102.Value;
                    NewField1100121.CalcValue = NewField1100121.Value;
                    NewField117081.CalcValue = NewField117081.Value;
                    NewField110131.CalcValue = NewField110131.Value;
                    NewField1190221.CalcValue = NewField1190221.Value;
                    NewField111102.CalcValue = NewField111102.Value;
                    NewField117062.CalcValue = NewField117062.Value;
                    NewField112103.CalcValue = NewField112103.Value;
                    NewField1100122.CalcValue = NewField1100122.Value;
                    NewField117082.CalcValue = NewField117082.Value;
                    NewField110132.CalcValue = NewField110132.Value;
                    NewField1190222.CalcValue = NewField1190222.Value;
                    NewField111103.CalcValue = NewField111103.Value;
                    NewField117063.CalcValue = NewField117063.Value;
                    NewField112104.CalcValue = NewField112104.Value;
                    NewField1100123.CalcValue = NewField1100123.Value;
                    NewField117083.CalcValue = NewField117083.Value;
                    NewField110133.CalcValue = NewField110133.Value;
                    NewField1190223.CalcValue = NewField1190223.Value;
                    NewField111104.CalcValue = NewField111104.Value;
                    NewField117064.CalcValue = NewField117064.Value;
                    NewField112105.CalcValue = NewField112105.Value;
                    NewField1100124.CalcValue = NewField1100124.Value;
                    NewField117084.CalcValue = NewField117084.Value;
                    NewField110134.CalcValue = NewField110134.Value;
                    NewField1190224.CalcValue = NewField1190224.Value;
                    NewField111105.CalcValue = NewField111105.Value;
                    NewField117065.CalcValue = NewField117065.Value;
                    NewField112106.CalcValue = NewField112106.Value;
                    NewField1100125.CalcValue = NewField1100125.Value;
                    NewField117085.CalcValue = NewField117085.Value;
                    NewField110135.CalcValue = NewField110135.Value;
                    NewField1190225.CalcValue = NewField1190225.Value;
                    NewField111106.CalcValue = NewField111106.Value;
                    NewField117066.CalcValue = NewField117066.Value;
                    NewField112107.CalcValue = NewField112107.Value;
                    NewField1100126.CalcValue = NewField1100126.Value;
                    NewField117086.CalcValue = NewField117086.Value;
                    NewField110136.CalcValue = NewField110136.Value;
                    NewField1190226.CalcValue = NewField1190226.Value;
                    NewField111108.CalcValue = NewField111108.Value;
                    NewField117068.CalcValue = NewField117068.Value;
                    NewField112109.CalcValue = NewField112109.Value;
                    NewField1100128.CalcValue = NewField1100128.Value;
                    NewField117088.CalcValue = NewField117088.Value;
                    NewField110138.CalcValue = NewField110138.Value;
                    NewField1190228.CalcValue = NewField1190228.Value;
                    NewField1110611.CalcValue = NewField1110611.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField111112.CalcValue = NewField111112.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    NewField1211111.CalcValue = NewField1211111.Value;
                    NewField1111112.CalcValue = NewField1111112.Value;
                    NewField1211112.CalcValue = NewField1211112.Value;
                    NewField1111113.CalcValue = NewField1111113.Value;
                    NewField1211113.CalcValue = NewField1211113.Value;
                    NewField1111114.CalcValue = NewField1111114.Value;
                    return new TTReportObject[] { NewField116011,NewField111071,NewField117011,NewField112071,NewField1188011,NewField1133071,NewField1188021,NewField1144071,NewField19011,NewField15071,NewField19021,NewField111001,NewField17071,NewField12101,NewField112091,NewField111091,NewField117051,NewField112092,NewField1100111,NewField117071,NewField110121,NewField1190211,NewField111092,NewField117052,NewField112093,NewField1100112,NewField117072,NewField110122,NewField1190212,NewField111093,NewField117053,NewField112094,NewField1100113,NewField117073,NewField110123,NewField1190213,NewField111094,NewField117054,NewField112095,NewField1100114,NewField117074,NewField110124,NewField1190214,NewField111095,NewField117055,NewField112096,NewField1100115,NewField117075,NewField110125,NewField1190215,NewField111096,NewField117056,NewField112097,NewField1100116,NewField117076,NewField110126,NewField1190216,NewField111097,NewField117057,NewField112098,NewField1100117,NewField117077,NewField110127,NewField1190217,NewField111098,NewField117058,NewField112099,NewField1100118,NewField117078,NewField110128,NewField1190218,NewField111099,NewField117059,NewField112100,NewField1100119,NewField117079,NewField110129,NewField1190219,NewField111100,NewField117060,NewField112101,NewField1100120,NewField117080,NewField110130,NewField1190220,NewField111101,NewField117061,NewField112102,NewField1100121,NewField117081,NewField110131,NewField1190221,NewField111102,NewField117062,NewField112103,NewField1100122,NewField117082,NewField110132,NewField1190222,NewField111103,NewField117063,NewField112104,NewField1100123,NewField117083,NewField110133,NewField1190223,NewField111104,NewField117064,NewField112105,NewField1100124,NewField117084,NewField110134,NewField1190224,NewField111105,NewField117065,NewField112106,NewField1100125,NewField117085,NewField110135,NewField1190225,NewField111106,NewField117066,NewField112107,NewField1100126,NewField117086,NewField110136,NewField1190226,NewField111108,NewField117068,NewField112109,NewField1100128,NewField117088,NewField110138,NewField1190228,NewField1110611,NewField111111,NewField111112,NewField1111111,NewField1211111,NewField1111112,NewField1211112,NewField1111113,NewField1211113,NewField1111114};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public IsIstekveIsEmri MyParentReport
            {
                get { return (IsIstekveIsEmri)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public IsIstekveIsEmri MyParentReport
                {
                    get { return (IsIstekveIsEmri)ParentReport; }
                }
                 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 10;
                    RepeatCount = 2;
                    RepeatWidth = 93;
                    
                }
                
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public IsIstekveIsEmri()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "ISISTEKVEISEMRI";
            Caption = "İş İstek ve İş Emri";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}