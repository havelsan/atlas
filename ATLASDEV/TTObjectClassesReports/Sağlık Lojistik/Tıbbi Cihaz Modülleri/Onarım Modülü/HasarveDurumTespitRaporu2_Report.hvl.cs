
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
    /// Hasar ve Durum Tespit Raporu
    /// </summary>
    public partial class HasarveDurumTespitRaporu2 : TTReport
    {
        public class ReportRuntimeParameters 
        {
        }

        public partial class MAINGroup : TTReportGroup
        {
            public HasarveDurumTespitRaporu2 MyParentReport
            {
                get { return (HasarveDurumTespitRaporu2)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NewField11 { get {return Body().NewField11;} }
            public TTReportField NewField121 { get {return Body().NewField121;} }
            public TTReportField NewField1131 { get {return Body().NewField1131;} }
            public TTReportField NewField11511 { get {return Body().NewField11511;} }
            public TTReportField NewField11151 { get {return Body().NewField11151;} }
            public TTReportField NewField11521 { get {return Body().NewField11521;} }
            public TTReportField NewField11251 { get {return Body().NewField11251;} }
            public TTReportField NewField11531 { get {return Body().NewField11531;} }
            public TTReportField NewField11351 { get {return Body().NewField11351;} }
            public TTReportField ORDERNAME11 { get {return Body().ORDERNAME11;} }
            public TTReportField WORKSHOP11 { get {return Body().WORKSHOP11;} }
            public TTReportField MONTH11 { get {return Body().MONTH11;} }
            public TTReportField SHARPDIRECTLABORTIME11 { get {return Body().SHARPDIRECTLABORTIME11;} }
            public TTReportField AVARAGEDIRECTLABORCOST11 { get {return Body().AVARAGEDIRECTLABORCOST11;} }
            public TTReportField LABORCOST11 { get {return Body().LABORCOST11;} }
            public TTReportField NewField11541 { get {return Body().NewField11541;} }
            public TTReportField TOTALLABORCOST11 { get {return Body().TOTALLABORCOST11;} }
            public TTReportField TOTALTIME11 { get {return Body().TOTALTIME11;} }
            public TTReportField NewField114511 { get {return Body().NewField114511;} }
            public TTReportField NewField1141 { get {return Body().NewField1141;} }
            public TTReportField NewField11161 { get {return Body().NewField11161;} }
            public TTReportField NewField12541 { get {return Body().NewField12541;} }
            public TTReportField NewField11261 { get {return Body().NewField11261;} }
            public TTReportField NewField11551 { get {return Body().NewField11551;} }
            public TTReportField NewField11361 { get {return Body().NewField11361;} }
            public TTReportField NewField11561 { get {return Body().NewField11561;} }
            public TTReportField NewField11571 { get {return Body().NewField11571;} }
            public TTReportField MATERIALNAME11 { get {return Body().MATERIALNAME11;} }
            public TTReportField NEWPRICE11 { get {return Body().NEWPRICE11;} }
            public TTReportField OLDPRICE11 { get {return Body().OLDPRICE11;} }
            public TTReportField DEADPRICE11 { get {return Body().DEADPRICE11;} }
            public TTReportField UNITPRICE11 { get {return Body().UNITPRICE11;} }
            public TTReportField MATERIALCOST11 { get {return Body().MATERIALCOST11;} }
            public TTReportField AMOUNT11 { get {return Body().AMOUNT11;} }
            public TTReportField NewField1151 { get {return Body().NewField1151;} }
            public TTReportField TOTALMATERIALCOST11 { get {return Body().TOTALMATERIALCOST11;} }
            public TTReportField NewField11611 { get {return Body().NewField11611;} }
            public TTReportField NewField11171 { get {return Body().NewField11171;} }
            public TTReportField NewField11181 { get {return Body().NewField11181;} }
            public TTReportField GRANDTOTALLABORCOST11 { get {return Body().GRANDTOTALLABORCOST11;} }
            public TTReportField GRANDTOTALMATERIALCOST11 { get {return Body().GRANDTOTALMATERIALCOST11;} }
            public TTReportField GRANDTOTAL11 { get {return Body().GRANDTOTAL11;} }
            public TTReportField NewField1171 { get {return Body().NewField1171;} }
            public TTReportField YAPILANIS11141 { get {return Body().YAPILANIS11141;} }
            public TTReportField ORDERNAME111 { get {return Body().ORDERNAME111;} }
            public TTReportField WORKSHOP111 { get {return Body().WORKSHOP111;} }
            public TTReportField MONTH111 { get {return Body().MONTH111;} }
            public TTReportField SHARPDIRECTLABORTIME111 { get {return Body().SHARPDIRECTLABORTIME111;} }
            public TTReportField AVARAGEDIRECTLABORCOST111 { get {return Body().AVARAGEDIRECTLABORCOST111;} }
            public TTReportField LABORCOST111 { get {return Body().LABORCOST111;} }
            public TTReportField ORDERNAME121 { get {return Body().ORDERNAME121;} }
            public TTReportField WORKSHOP121 { get {return Body().WORKSHOP121;} }
            public TTReportField MONTH121 { get {return Body().MONTH121;} }
            public TTReportField SHARPDIRECTLABORTIME121 { get {return Body().SHARPDIRECTLABORTIME121;} }
            public TTReportField AVARAGEDIRECTLABORCOST121 { get {return Body().AVARAGEDIRECTLABORCOST121;} }
            public TTReportField LABORCOST121 { get {return Body().LABORCOST121;} }
            public TTReportField ORDERNAME131 { get {return Body().ORDERNAME131;} }
            public TTReportField WORKSHOP131 { get {return Body().WORKSHOP131;} }
            public TTReportField MONTH131 { get {return Body().MONTH131;} }
            public TTReportField SHARPDIRECTLABORTIME131 { get {return Body().SHARPDIRECTLABORTIME131;} }
            public TTReportField AVARAGEDIRECTLABORCOST131 { get {return Body().AVARAGEDIRECTLABORCOST131;} }
            public TTReportField LABORCOST131 { get {return Body().LABORCOST131;} }
            public TTReportField ORDERNAME141 { get {return Body().ORDERNAME141;} }
            public TTReportField WORKSHOP141 { get {return Body().WORKSHOP141;} }
            public TTReportField MONTH141 { get {return Body().MONTH141;} }
            public TTReportField SHARPDIRECTLABORTIME141 { get {return Body().SHARPDIRECTLABORTIME141;} }
            public TTReportField AVARAGEDIRECTLABORCOST141 { get {return Body().AVARAGEDIRECTLABORCOST141;} }
            public TTReportField LABORCOST141 { get {return Body().LABORCOST141;} }
            public TTReportField ORDERNAME151 { get {return Body().ORDERNAME151;} }
            public TTReportField WORKSHOP151 { get {return Body().WORKSHOP151;} }
            public TTReportField MONTH151 { get {return Body().MONTH151;} }
            public TTReportField SHARPDIRECTLABORTIME151 { get {return Body().SHARPDIRECTLABORTIME151;} }
            public TTReportField AVARAGEDIRECTLABORCOST151 { get {return Body().AVARAGEDIRECTLABORCOST151;} }
            public TTReportField LABORCOST151 { get {return Body().LABORCOST151;} }
            public TTReportField ORDERNAME161 { get {return Body().ORDERNAME161;} }
            public TTReportField WORKSHOP161 { get {return Body().WORKSHOP161;} }
            public TTReportField MONTH161 { get {return Body().MONTH161;} }
            public TTReportField SHARPDIRECTLABORTIME161 { get {return Body().SHARPDIRECTLABORTIME161;} }
            public TTReportField AVARAGEDIRECTLABORCOST161 { get {return Body().AVARAGEDIRECTLABORCOST161;} }
            public TTReportField LABORCOST161 { get {return Body().LABORCOST161;} }
            public TTReportField ORDERNAME171 { get {return Body().ORDERNAME171;} }
            public TTReportField WORKSHOP171 { get {return Body().WORKSHOP171;} }
            public TTReportField MONTH171 { get {return Body().MONTH171;} }
            public TTReportField SHARPDIRECTLABORTIME171 { get {return Body().SHARPDIRECTLABORTIME171;} }
            public TTReportField AVARAGEDIRECTLABORCOST171 { get {return Body().AVARAGEDIRECTLABORCOST171;} }
            public TTReportField LABORCOST171 { get {return Body().LABORCOST171;} }
            public TTReportField MATERIALNAME111 { get {return Body().MATERIALNAME111;} }
            public TTReportField NEWPRICE111 { get {return Body().NEWPRICE111;} }
            public TTReportField OLDPRICE111 { get {return Body().OLDPRICE111;} }
            public TTReportField DEADPRICE111 { get {return Body().DEADPRICE111;} }
            public TTReportField UNITPRICE111 { get {return Body().UNITPRICE111;} }
            public TTReportField MATERIALCOST111 { get {return Body().MATERIALCOST111;} }
            public TTReportField AMOUNT111 { get {return Body().AMOUNT111;} }
            public TTReportField MATERIALNAME121 { get {return Body().MATERIALNAME121;} }
            public TTReportField NEWPRICE121 { get {return Body().NEWPRICE121;} }
            public TTReportField OLDPRICE121 { get {return Body().OLDPRICE121;} }
            public TTReportField DEADPRICE121 { get {return Body().DEADPRICE121;} }
            public TTReportField UNITPRICE121 { get {return Body().UNITPRICE121;} }
            public TTReportField MATERIALCOST121 { get {return Body().MATERIALCOST121;} }
            public TTReportField AMOUNT121 { get {return Body().AMOUNT121;} }
            public TTReportField MATERIALNAME131 { get {return Body().MATERIALNAME131;} }
            public TTReportField NEWPRICE131 { get {return Body().NEWPRICE131;} }
            public TTReportField OLDPRICE131 { get {return Body().OLDPRICE131;} }
            public TTReportField DEADPRICE131 { get {return Body().DEADPRICE131;} }
            public TTReportField UNITPRICE131 { get {return Body().UNITPRICE131;} }
            public TTReportField MATERIALCOST131 { get {return Body().MATERIALCOST131;} }
            public TTReportField AMOUNT131 { get {return Body().AMOUNT131;} }
            public TTReportField MATERIALNAME141 { get {return Body().MATERIALNAME141;} }
            public TTReportField NEWPRICE141 { get {return Body().NEWPRICE141;} }
            public TTReportField OLDPRICE141 { get {return Body().OLDPRICE141;} }
            public TTReportField DEADPRICE141 { get {return Body().DEADPRICE141;} }
            public TTReportField UNITPRICE141 { get {return Body().UNITPRICE141;} }
            public TTReportField MATERIALCOST141 { get {return Body().MATERIALCOST141;} }
            public TTReportField AMOUNT141 { get {return Body().AMOUNT141;} }
            public TTReportField MATERIALNAME151 { get {return Body().MATERIALNAME151;} }
            public TTReportField NEWPRICE151 { get {return Body().NEWPRICE151;} }
            public TTReportField OLDPRICE151 { get {return Body().OLDPRICE151;} }
            public TTReportField DEADPRICE151 { get {return Body().DEADPRICE151;} }
            public TTReportField UNITPRICE151 { get {return Body().UNITPRICE151;} }
            public TTReportField MATERIALCOST151 { get {return Body().MATERIALCOST151;} }
            public TTReportField AMOUNT151 { get {return Body().AMOUNT151;} }
            public TTReportField MATERIALNAME161 { get {return Body().MATERIALNAME161;} }
            public TTReportField NEWPRICE161 { get {return Body().NEWPRICE161;} }
            public TTReportField OLDPRICE161 { get {return Body().OLDPRICE161;} }
            public TTReportField DEADPRICE161 { get {return Body().DEADPRICE161;} }
            public TTReportField UNITPRICE161 { get {return Body().UNITPRICE161;} }
            public TTReportField MATERIALCOST161 { get {return Body().MATERIALCOST161;} }
            public TTReportField AMOUNT161 { get {return Body().AMOUNT161;} }
            public TTReportField MATERIALNAME171 { get {return Body().MATERIALNAME171;} }
            public TTReportField NEWPRICE171 { get {return Body().NEWPRICE171;} }
            public TTReportField OLDPRICE171 { get {return Body().OLDPRICE171;} }
            public TTReportField DEADPRICE171 { get {return Body().DEADPRICE171;} }
            public TTReportField UNITPRICE171 { get {return Body().UNITPRICE171;} }
            public TTReportField MATERIALCOST171 { get {return Body().MATERIALCOST171;} }
            public TTReportField AMOUNT171 { get {return Body().AMOUNT171;} }
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
                public HasarveDurumTespitRaporu2 MyParentReport
                {
                    get { return (HasarveDurumTespitRaporu2)ParentReport; }
                }
                
                public TTReportField NewField11;
                public TTReportField NewField121;
                public TTReportField NewField1131;
                public TTReportField NewField11511;
                public TTReportField NewField11151;
                public TTReportField NewField11521;
                public TTReportField NewField11251;
                public TTReportField NewField11531;
                public TTReportField NewField11351;
                public TTReportField ORDERNAME11;
                public TTReportField WORKSHOP11;
                public TTReportField MONTH11;
                public TTReportField SHARPDIRECTLABORTIME11;
                public TTReportField AVARAGEDIRECTLABORCOST11;
                public TTReportField LABORCOST11;
                public TTReportField NewField11541;
                public TTReportField TOTALLABORCOST11;
                public TTReportField TOTALTIME11;
                public TTReportField NewField114511;
                public TTReportField NewField1141;
                public TTReportField NewField11161;
                public TTReportField NewField12541;
                public TTReportField NewField11261;
                public TTReportField NewField11551;
                public TTReportField NewField11361;
                public TTReportField NewField11561;
                public TTReportField NewField11571;
                public TTReportField MATERIALNAME11;
                public TTReportField NEWPRICE11;
                public TTReportField OLDPRICE11;
                public TTReportField DEADPRICE11;
                public TTReportField UNITPRICE11;
                public TTReportField MATERIALCOST11;
                public TTReportField AMOUNT11;
                public TTReportField NewField1151;
                public TTReportField TOTALMATERIALCOST11;
                public TTReportField NewField11611;
                public TTReportField NewField11171;
                public TTReportField NewField11181;
                public TTReportField GRANDTOTALLABORCOST11;
                public TTReportField GRANDTOTALMATERIALCOST11;
                public TTReportField GRANDTOTAL11;
                public TTReportField NewField1171;
                public TTReportField YAPILANIS11141;
                public TTReportField ORDERNAME111;
                public TTReportField WORKSHOP111;
                public TTReportField MONTH111;
                public TTReportField SHARPDIRECTLABORTIME111;
                public TTReportField AVARAGEDIRECTLABORCOST111;
                public TTReportField LABORCOST111;
                public TTReportField ORDERNAME121;
                public TTReportField WORKSHOP121;
                public TTReportField MONTH121;
                public TTReportField SHARPDIRECTLABORTIME121;
                public TTReportField AVARAGEDIRECTLABORCOST121;
                public TTReportField LABORCOST121;
                public TTReportField ORDERNAME131;
                public TTReportField WORKSHOP131;
                public TTReportField MONTH131;
                public TTReportField SHARPDIRECTLABORTIME131;
                public TTReportField AVARAGEDIRECTLABORCOST131;
                public TTReportField LABORCOST131;
                public TTReportField ORDERNAME141;
                public TTReportField WORKSHOP141;
                public TTReportField MONTH141;
                public TTReportField SHARPDIRECTLABORTIME141;
                public TTReportField AVARAGEDIRECTLABORCOST141;
                public TTReportField LABORCOST141;
                public TTReportField ORDERNAME151;
                public TTReportField WORKSHOP151;
                public TTReportField MONTH151;
                public TTReportField SHARPDIRECTLABORTIME151;
                public TTReportField AVARAGEDIRECTLABORCOST151;
                public TTReportField LABORCOST151;
                public TTReportField ORDERNAME161;
                public TTReportField WORKSHOP161;
                public TTReportField MONTH161;
                public TTReportField SHARPDIRECTLABORTIME161;
                public TTReportField AVARAGEDIRECTLABORCOST161;
                public TTReportField LABORCOST161;
                public TTReportField ORDERNAME171;
                public TTReportField WORKSHOP171;
                public TTReportField MONTH171;
                public TTReportField SHARPDIRECTLABORTIME171;
                public TTReportField AVARAGEDIRECTLABORCOST171;
                public TTReportField LABORCOST171;
                public TTReportField MATERIALNAME111;
                public TTReportField NEWPRICE111;
                public TTReportField OLDPRICE111;
                public TTReportField DEADPRICE111;
                public TTReportField UNITPRICE111;
                public TTReportField MATERIALCOST111;
                public TTReportField AMOUNT111;
                public TTReportField MATERIALNAME121;
                public TTReportField NEWPRICE121;
                public TTReportField OLDPRICE121;
                public TTReportField DEADPRICE121;
                public TTReportField UNITPRICE121;
                public TTReportField MATERIALCOST121;
                public TTReportField AMOUNT121;
                public TTReportField MATERIALNAME131;
                public TTReportField NEWPRICE131;
                public TTReportField OLDPRICE131;
                public TTReportField DEADPRICE131;
                public TTReportField UNITPRICE131;
                public TTReportField MATERIALCOST131;
                public TTReportField AMOUNT131;
                public TTReportField MATERIALNAME141;
                public TTReportField NEWPRICE141;
                public TTReportField OLDPRICE141;
                public TTReportField DEADPRICE141;
                public TTReportField UNITPRICE141;
                public TTReportField MATERIALCOST141;
                public TTReportField AMOUNT141;
                public TTReportField MATERIALNAME151;
                public TTReportField NEWPRICE151;
                public TTReportField OLDPRICE151;
                public TTReportField DEADPRICE151;
                public TTReportField UNITPRICE151;
                public TTReportField MATERIALCOST151;
                public TTReportField AMOUNT151;
                public TTReportField MATERIALNAME161;
                public TTReportField NEWPRICE161;
                public TTReportField OLDPRICE161;
                public TTReportField DEADPRICE161;
                public TTReportField UNITPRICE161;
                public TTReportField MATERIALCOST161;
                public TTReportField AMOUNT161;
                public TTReportField MATERIALNAME171;
                public TTReportField NEWPRICE171;
                public TTReportField OLDPRICE171;
                public TTReportField DEADPRICE171;
                public TTReportField UNITPRICE171;
                public TTReportField MATERIALCOST171;
                public TTReportField AMOUNT171; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 210;
                    RepeatCount = 0;
                    
                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 10, 175, 15, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11.TextFont.Name = "Arial";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @"HİZMETE ÖZEL";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 25, 290, 33, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField121.TextFont.Name = "Arial";
                    NewField121.TextFont.Size = 12;
                    NewField121.TextFont.Bold = true;
                    NewField121.TextFont.CharSet = 162;
                    NewField121.Value = @"HASAR VE DURUM TESPİT RAPORU";

                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 33, 290, 41, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1131.TextFont.Name = "Arial";
                    NewField1131.TextFont.Size = 11;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.TextFont.CharSet = 162;
                    NewField1131.Value = @"DİREKT İŞÇİLİK GİDERİ";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 41, 116, 51, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11511.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11511.TextFont.Name = "Arial";
                    NewField11511.TextFont.Bold = true;
                    NewField11511.TextFont.CharSet = 162;
                    NewField11511.Value = @"Yapılan İş";

                    NewField11151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 41, 156, 51, false);
                    NewField11151.Name = "NewField11151";
                    NewField11151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11151.TextFont.Name = "Arial";
                    NewField11151.TextFont.Bold = true;
                    NewField11151.TextFont.CharSet = 162;
                    NewField11151.Value = @"Kısım";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 41, 184, 51, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11521.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11521.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11521.TextFont.Name = "Arial";
                    NewField11521.TextFont.Bold = true;
                    NewField11521.TextFont.CharSet = 162;
                    NewField11521.Value = @"Ay";

                    NewField11251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 41, 218, 51, false);
                    NewField11251.Name = "NewField11251";
                    NewField11251.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11251.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11251.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11251.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11251.TextFont.Name = "Arial";
                    NewField11251.TextFont.Bold = true;
                    NewField11251.TextFont.CharSet = 162;
                    NewField11251.Value = @"Net Direk
İşçilik Saati";

                    NewField11531 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 41, 263, 51, false);
                    NewField11531.Name = "NewField11531";
                    NewField11531.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11531.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11531.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11531.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11531.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11531.TextFont.Name = "Arial";
                    NewField11531.TextFont.Bold = true;
                    NewField11531.TextFont.CharSet = 162;
                    NewField11531.Value = @"Ortalama Direk
İşçilik Gideri";

                    NewField11351 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 41, 290, 51, false);
                    NewField11351.Name = "NewField11351";
                    NewField11351.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11351.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11351.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11351.MultiLine = EvetHayirEnum.ehEvet;
                    NewField11351.WordBreak = EvetHayirEnum.ehEvet;
                    NewField11351.TextFont.Name = "Arial";
                    NewField11351.TextFont.Bold = true;
                    NewField11351.TextFont.CharSet = 162;
                    NewField11351.Value = @"İşçilik
Gideri";

                    ORDERNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 51, 116, 56, false);
                    ORDERNAME11.Name = "ORDERNAME11";
                    ORDERNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME11.TextFont.Name = "Arial";
                    ORDERNAME11.TextFont.Size = 9;
                    ORDERNAME11.TextFont.CharSet = 162;
                    ORDERNAME11.Value = @"";

                    WORKSHOP11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 51, 156, 56, false);
                    WORKSHOP11.Name = "WORKSHOP11";
                    WORKSHOP11.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP11.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP11.TextFont.Name = "Arial";
                    WORKSHOP11.TextFont.Size = 9;
                    WORKSHOP11.TextFont.CharSet = 162;
                    WORKSHOP11.Value = @"";

                    MONTH11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 51, 184, 56, false);
                    MONTH11.Name = "MONTH11";
                    MONTH11.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH11.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH11.TextFont.Name = "Arial";
                    MONTH11.TextFont.Size = 9;
                    MONTH11.TextFont.CharSet = 162;
                    MONTH11.Value = @"";

                    SHARPDIRECTLABORTIME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 51, 218, 56, false);
                    SHARPDIRECTLABORTIME11.Name = "SHARPDIRECTLABORTIME11";
                    SHARPDIRECTLABORTIME11.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME11.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME11.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME11.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME11.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME11.Value = @"";

                    AVARAGEDIRECTLABORCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 51, 263, 56, false);
                    AVARAGEDIRECTLABORCOST11.Name = "AVARAGEDIRECTLABORCOST11";
                    AVARAGEDIRECTLABORCOST11.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST11.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST11.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST11.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST11.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST11.Value = @"";

                    LABORCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 51, 290, 56, false);
                    LABORCOST11.Name = "LABORCOST11";
                    LABORCOST11.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST11.TextFormat = @"#,##0.#0";
                    LABORCOST11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST11.TextFont.Name = "Arial";
                    LABORCOST11.TextFont.Size = 9;
                    LABORCOST11.TextFont.CharSet = 162;
                    LABORCOST11.Value = @"";

                    NewField11541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 91, 184, 101, false);
                    NewField11541.Name = "NewField11541";
                    NewField11541.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11541.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField11541.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11541.TextFont.Name = "Arial";
                    NewField11541.TextFont.Bold = true;
                    NewField11541.TextFont.CharSet = 162;
                    NewField11541.Value = @"TOPLAM ";

                    TOTALLABORCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 91, 290, 101, false);
                    TOTALLABORCOST11.Name = "TOTALLABORCOST11";
                    TOTALLABORCOST11.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALLABORCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALLABORCOST11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALLABORCOST11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALLABORCOST11.TextFont.Name = "Arial";
                    TOTALLABORCOST11.TextFont.Size = 9;
                    TOTALLABORCOST11.TextFont.CharSet = 162;
                    TOTALLABORCOST11.Value = @"";

                    TOTALTIME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 91, 218, 101, false);
                    TOTALTIME11.Name = "TOTALTIME11";
                    TOTALTIME11.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALTIME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALTIME11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALTIME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALTIME11.TextFont.Name = "Arial";
                    TOTALTIME11.TextFont.Size = 9;
                    TOTALTIME11.TextFont.CharSet = 162;
                    TOTALTIME11.Value = @"";

                    NewField114511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 91, 263, 101, false);
                    NewField114511.Name = "NewField114511";
                    NewField114511.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField114511.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField114511.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField114511.TextFont.Name = "Arial";
                    NewField114511.TextFont.Bold = true;
                    NewField114511.TextFont.CharSet = 162;
                    NewField114511.Value = @"TOPLAM ";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 101, 290, 109, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1141.TextFont.Name = "Arial";
                    NewField1141.TextFont.Size = 11;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.TextFont.CharSet = 162;
                    NewField1141.Value = @"DİREKT MALZEME GİDERİ";

                    NewField11161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 109, 105, 119, false);
                    NewField11161.Name = "NewField11161";
                    NewField11161.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11161.TextFont.Name = "Arial";
                    NewField11161.TextFont.Bold = true;
                    NewField11161.TextFont.CharSet = 162;
                    NewField11161.Value = @"Malzemenin Cinsi";

                    NewField12541 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 109, 156, 119, false);
                    NewField12541.Name = "NewField12541";
                    NewField12541.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField12541.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12541.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField12541.TextFont.Name = "Arial";
                    NewField12541.TextFont.Bold = true;
                    NewField12541.TextFont.CharSet = 162;
                    NewField12541.Value = @"Yeni Fiyatı";

                    NewField11261 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 109, 184, 119, false);
                    NewField11261.Name = "NewField11261";
                    NewField11261.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11261.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11261.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11261.TextFont.Name = "Arial";
                    NewField11261.TextFont.Bold = true;
                    NewField11261.TextFont.CharSet = 162;
                    NewField11261.Value = @"Eskime Fiyatı";

                    NewField11551 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 109, 218, 119, false);
                    NewField11551.Name = "NewField11551";
                    NewField11551.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11551.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11551.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11551.TextFont.Name = "Arial";
                    NewField11551.TextFont.Bold = true;
                    NewField11551.TextFont.CharSet = 162;
                    NewField11551.Value = @"Hurda Fiyatı";

                    NewField11361 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 109, 247, 119, false);
                    NewField11361.Name = "NewField11361";
                    NewField11361.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11361.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11361.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11361.TextFont.Name = "Arial";
                    NewField11361.TextFont.Bold = true;
                    NewField11361.TextFont.CharSet = 162;
                    NewField11361.Value = @"Ödenti Fiyatı";

                    NewField11561 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 109, 290, 119, false);
                    NewField11561.Name = "NewField11561";
                    NewField11561.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11561.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11561.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11561.TextFont.Name = "Arial";
                    NewField11561.TextFont.Bold = true;
                    NewField11561.TextFont.CharSet = 162;
                    NewField11561.Value = @"Malzeme Gideri";

                    NewField11571 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 109, 129, 119, false);
                    NewField11571.Name = "NewField11571";
                    NewField11571.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11571.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11571.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11571.TextFont.Name = "Arial";
                    NewField11571.TextFont.Bold = true;
                    NewField11571.TextFont.CharSet = 162;
                    NewField11571.Value = @"Miktar";

                    MATERIALNAME11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 119, 105, 124, false);
                    MATERIALNAME11.Name = "MATERIALNAME11";
                    MATERIALNAME11.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME11.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME11.TextFont.Name = "Arial";
                    MATERIALNAME11.TextFont.Size = 9;
                    MATERIALNAME11.TextFont.CharSet = 162;
                    MATERIALNAME11.Value = @"";

                    NEWPRICE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 119, 156, 124, false);
                    NEWPRICE11.Name = "NEWPRICE11";
                    NEWPRICE11.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE11.TextFont.Name = "Arial";
                    NEWPRICE11.TextFont.Size = 9;
                    NEWPRICE11.TextFont.CharSet = 162;
                    NEWPRICE11.Value = @"";

                    OLDPRICE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 119, 184, 124, false);
                    OLDPRICE11.Name = "OLDPRICE11";
                    OLDPRICE11.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE11.TextFont.Name = "Arial";
                    OLDPRICE11.TextFont.Size = 9;
                    OLDPRICE11.TextFont.CharSet = 162;
                    OLDPRICE11.Value = @"";

                    DEADPRICE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 119, 218, 124, false);
                    DEADPRICE11.Name = "DEADPRICE11";
                    DEADPRICE11.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE11.TextFont.Name = "Arial";
                    DEADPRICE11.TextFont.Size = 9;
                    DEADPRICE11.TextFont.CharSet = 162;
                    DEADPRICE11.Value = @"";

                    UNITPRICE11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 119, 247, 124, false);
                    UNITPRICE11.Name = "UNITPRICE11";
                    UNITPRICE11.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE11.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE11.TextFormat = @"#,##0.#0";
                    UNITPRICE11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE11.TextFont.Name = "Arial";
                    UNITPRICE11.TextFont.Size = 9;
                    UNITPRICE11.TextFont.CharSet = 162;
                    UNITPRICE11.Value = @"";

                    MATERIALCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 119, 290, 124, false);
                    MATERIALCOST11.Name = "MATERIALCOST11";
                    MATERIALCOST11.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST11.TextFormat = @"#,##0.#0";
                    MATERIALCOST11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST11.TextFont.Name = "Arial";
                    MATERIALCOST11.TextFont.Size = 9;
                    MATERIALCOST11.TextFont.CharSet = 162;
                    MATERIALCOST11.Value = @"";

                    AMOUNT11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 119, 129, 124, false);
                    AMOUNT11.Name = "AMOUNT11";
                    AMOUNT11.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT11.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT11.TextFont.Name = "Arial";
                    AMOUNT11.TextFont.Size = 9;
                    AMOUNT11.TextFont.CharSet = 162;
                    AMOUNT11.Value = @"";

                    NewField1151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 159, 247, 169, false);
                    NewField1151.Name = "NewField1151";
                    NewField1151.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NewField1151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1151.TextFont.Name = "Arial";
                    NewField1151.TextFont.Bold = true;
                    NewField1151.TextFont.CharSet = 162;
                    NewField1151.Value = @"TOPLAM ";

                    TOTALMATERIALCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 159, 290, 169, false);
                    TOTALMATERIALCOST11.Name = "TOTALMATERIALCOST11";
                    TOTALMATERIALCOST11.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALMATERIALCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALMATERIALCOST11.TextFormat = @"#,##0.#0";
                    TOTALMATERIALCOST11.HorzAlign = HorizontalAlignmentEnum.haRight;
                    TOTALMATERIALCOST11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    TOTALMATERIALCOST11.TextFont.Name = "Arial";
                    TOTALMATERIALCOST11.TextFont.Size = 9;
                    TOTALMATERIALCOST11.TextFont.CharSet = 162;
                    TOTALMATERIALCOST11.Value = @"";

                    NewField11611 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 169, 86, 179, false);
                    NewField11611.Name = "NewField11611";
                    NewField11611.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11611.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11611.TextFont.Name = "Arial";
                    NewField11611.TextFont.Bold = true;
                    NewField11611.TextFont.CharSet = 162;
                    NewField11611.Value = @" Direk İşçilik Gideri";

                    NewField11171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 179, 86, 189, false);
                    NewField11171.Name = "NewField11171";
                    NewField11171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11171.TextFont.Name = "Arial";
                    NewField11171.TextFont.Bold = true;
                    NewField11171.TextFont.CharSet = 162;
                    NewField11171.Value = @" Direk Malzeme Gideri";

                    NewField11181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 189, 86, 199, false);
                    NewField11181.Name = "NewField11181";
                    NewField11181.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField11181.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField11181.TextFont.Name = "Arial";
                    NewField11181.TextFont.Bold = true;
                    NewField11181.TextFont.CharSet = 162;
                    NewField11181.Value = @" Toplam Ödetme Maliyeti";

                    GRANDTOTALLABORCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 169, 116, 179, false);
                    GRANDTOTALLABORCOST11.Name = "GRANDTOTALLABORCOST11";
                    GRANDTOTALLABORCOST11.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTALLABORCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTALLABORCOST11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTALLABORCOST11.TextFont.Name = "Arial";
                    GRANDTOTALLABORCOST11.TextFont.Size = 9;
                    GRANDTOTALLABORCOST11.TextFont.CharSet = 162;
                    GRANDTOTALLABORCOST11.Value = @"";

                    GRANDTOTALMATERIALCOST11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 179, 116, 189, false);
                    GRANDTOTALMATERIALCOST11.Name = "GRANDTOTALMATERIALCOST11";
                    GRANDTOTALMATERIALCOST11.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTALMATERIALCOST11.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTALMATERIALCOST11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTALMATERIALCOST11.TextFont.Name = "Arial";
                    GRANDTOTALMATERIALCOST11.TextFont.Size = 9;
                    GRANDTOTALMATERIALCOST11.TextFont.CharSet = 162;
                    GRANDTOTALMATERIALCOST11.Value = @"";

                    GRANDTOTAL11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 86, 189, 116, 199, false);
                    GRANDTOTAL11.Name = "GRANDTOTAL11";
                    GRANDTOTAL11.DrawStyle = DrawStyleConstants.vbSolid;
                    GRANDTOTAL11.FieldType = ReportFieldTypeEnum.ftVariable;
                    GRANDTOTAL11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    GRANDTOTAL11.TextFont.Name = "Arial";
                    GRANDTOTAL11.TextFont.Size = 9;
                    GRANDTOTAL11.TextFont.CharSet = 162;
                    GRANDTOTAL11.Value = @"";

                    NewField1171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 169, 290, 179, false);
                    NewField1171.Name = "NewField1171";
                    NewField1171.DrawStyle = DrawStyleConstants.vbSolid;
                    NewField1171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NewField1171.TextFont.Name = "Arial";
                    NewField1171.TextFont.Bold = true;
                    NewField1171.TextFont.CharSet = 162;
                    NewField1171.Value = @"İş Hzl. Ks. A.                                                                                                    Bakım Müdürü";

                    YAPILANIS11141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 179, 290, 199, false);
                    YAPILANIS11141.Name = "YAPILANIS11141";
                    YAPILANIS11141.DrawStyle = DrawStyleConstants.vbSolid;
                    YAPILANIS11141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    YAPILANIS11141.TextFont.Name = "Arial";
                    YAPILANIS11141.TextFont.Size = 9;
                    YAPILANIS11141.TextFont.CharSet = 162;
                    YAPILANIS11141.Value = @"";

                    ORDERNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 56, 116, 61, false);
                    ORDERNAME111.Name = "ORDERNAME111";
                    ORDERNAME111.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME111.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME111.TextFont.Name = "Arial";
                    ORDERNAME111.TextFont.Size = 9;
                    ORDERNAME111.TextFont.CharSet = 162;
                    ORDERNAME111.Value = @"";

                    WORKSHOP111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 56, 156, 61, false);
                    WORKSHOP111.Name = "WORKSHOP111";
                    WORKSHOP111.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP111.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP111.TextFont.Name = "Arial";
                    WORKSHOP111.TextFont.Size = 9;
                    WORKSHOP111.TextFont.CharSet = 162;
                    WORKSHOP111.Value = @"";

                    MONTH111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 56, 184, 61, false);
                    MONTH111.Name = "MONTH111";
                    MONTH111.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH111.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH111.TextFont.Name = "Arial";
                    MONTH111.TextFont.Size = 9;
                    MONTH111.TextFont.CharSet = 162;
                    MONTH111.Value = @"";

                    SHARPDIRECTLABORTIME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 56, 218, 61, false);
                    SHARPDIRECTLABORTIME111.Name = "SHARPDIRECTLABORTIME111";
                    SHARPDIRECTLABORTIME111.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME111.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME111.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME111.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME111.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME111.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME111.Value = @"";

                    AVARAGEDIRECTLABORCOST111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 56, 263, 61, false);
                    AVARAGEDIRECTLABORCOST111.Name = "AVARAGEDIRECTLABORCOST111";
                    AVARAGEDIRECTLABORCOST111.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST111.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST111.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST111.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST111.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST111.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST111.Value = @"";

                    LABORCOST111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 56, 290, 61, false);
                    LABORCOST111.Name = "LABORCOST111";
                    LABORCOST111.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST111.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST111.TextFormat = @"#,##0.#0";
                    LABORCOST111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST111.TextFont.Name = "Arial";
                    LABORCOST111.TextFont.Size = 9;
                    LABORCOST111.TextFont.CharSet = 162;
                    LABORCOST111.Value = @"";

                    ORDERNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 61, 116, 66, false);
                    ORDERNAME121.Name = "ORDERNAME121";
                    ORDERNAME121.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME121.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME121.TextFont.Name = "Arial";
                    ORDERNAME121.TextFont.Size = 9;
                    ORDERNAME121.TextFont.CharSet = 162;
                    ORDERNAME121.Value = @"";

                    WORKSHOP121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 61, 156, 66, false);
                    WORKSHOP121.Name = "WORKSHOP121";
                    WORKSHOP121.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP121.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP121.TextFont.Name = "Arial";
                    WORKSHOP121.TextFont.Size = 9;
                    WORKSHOP121.TextFont.CharSet = 162;
                    WORKSHOP121.Value = @"";

                    MONTH121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 61, 184, 66, false);
                    MONTH121.Name = "MONTH121";
                    MONTH121.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH121.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH121.TextFont.Name = "Arial";
                    MONTH121.TextFont.Size = 9;
                    MONTH121.TextFont.CharSet = 162;
                    MONTH121.Value = @"";

                    SHARPDIRECTLABORTIME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 61, 218, 66, false);
                    SHARPDIRECTLABORTIME121.Name = "SHARPDIRECTLABORTIME121";
                    SHARPDIRECTLABORTIME121.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME121.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME121.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME121.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME121.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME121.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME121.Value = @"";

                    AVARAGEDIRECTLABORCOST121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 61, 263, 66, false);
                    AVARAGEDIRECTLABORCOST121.Name = "AVARAGEDIRECTLABORCOST121";
                    AVARAGEDIRECTLABORCOST121.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST121.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST121.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST121.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST121.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST121.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST121.Value = @"";

                    LABORCOST121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 61, 290, 66, false);
                    LABORCOST121.Name = "LABORCOST121";
                    LABORCOST121.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST121.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST121.TextFormat = @"#,##0.#0";
                    LABORCOST121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST121.TextFont.Name = "Arial";
                    LABORCOST121.TextFont.Size = 9;
                    LABORCOST121.TextFont.CharSet = 162;
                    LABORCOST121.Value = @"";

                    ORDERNAME131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 66, 116, 71, false);
                    ORDERNAME131.Name = "ORDERNAME131";
                    ORDERNAME131.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME131.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME131.TextFont.Name = "Arial";
                    ORDERNAME131.TextFont.Size = 9;
                    ORDERNAME131.TextFont.CharSet = 162;
                    ORDERNAME131.Value = @"";

                    WORKSHOP131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 66, 156, 71, false);
                    WORKSHOP131.Name = "WORKSHOP131";
                    WORKSHOP131.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP131.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP131.TextFont.Name = "Arial";
                    WORKSHOP131.TextFont.Size = 9;
                    WORKSHOP131.TextFont.CharSet = 162;
                    WORKSHOP131.Value = @"";

                    MONTH131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 66, 184, 71, false);
                    MONTH131.Name = "MONTH131";
                    MONTH131.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH131.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH131.TextFont.Name = "Arial";
                    MONTH131.TextFont.Size = 9;
                    MONTH131.TextFont.CharSet = 162;
                    MONTH131.Value = @"";

                    SHARPDIRECTLABORTIME131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 66, 218, 71, false);
                    SHARPDIRECTLABORTIME131.Name = "SHARPDIRECTLABORTIME131";
                    SHARPDIRECTLABORTIME131.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME131.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME131.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME131.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME131.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME131.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME131.Value = @"";

                    AVARAGEDIRECTLABORCOST131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 66, 263, 71, false);
                    AVARAGEDIRECTLABORCOST131.Name = "AVARAGEDIRECTLABORCOST131";
                    AVARAGEDIRECTLABORCOST131.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST131.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST131.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST131.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST131.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST131.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST131.Value = @"";

                    LABORCOST131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 66, 290, 71, false);
                    LABORCOST131.Name = "LABORCOST131";
                    LABORCOST131.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST131.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST131.TextFormat = @"#,##0.#0";
                    LABORCOST131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST131.TextFont.Name = "Arial";
                    LABORCOST131.TextFont.Size = 9;
                    LABORCOST131.TextFont.CharSet = 162;
                    LABORCOST131.Value = @"";

                    ORDERNAME141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 71, 116, 76, false);
                    ORDERNAME141.Name = "ORDERNAME141";
                    ORDERNAME141.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME141.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME141.TextFont.Name = "Arial";
                    ORDERNAME141.TextFont.Size = 9;
                    ORDERNAME141.TextFont.CharSet = 162;
                    ORDERNAME141.Value = @"";

                    WORKSHOP141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 71, 156, 76, false);
                    WORKSHOP141.Name = "WORKSHOP141";
                    WORKSHOP141.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP141.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP141.TextFont.Name = "Arial";
                    WORKSHOP141.TextFont.Size = 9;
                    WORKSHOP141.TextFont.CharSet = 162;
                    WORKSHOP141.Value = @"";

                    MONTH141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 71, 184, 76, false);
                    MONTH141.Name = "MONTH141";
                    MONTH141.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH141.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH141.TextFont.Name = "Arial";
                    MONTH141.TextFont.Size = 9;
                    MONTH141.TextFont.CharSet = 162;
                    MONTH141.Value = @"";

                    SHARPDIRECTLABORTIME141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 71, 218, 76, false);
                    SHARPDIRECTLABORTIME141.Name = "SHARPDIRECTLABORTIME141";
                    SHARPDIRECTLABORTIME141.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME141.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME141.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME141.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME141.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME141.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME141.Value = @"";

                    AVARAGEDIRECTLABORCOST141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 71, 263, 76, false);
                    AVARAGEDIRECTLABORCOST141.Name = "AVARAGEDIRECTLABORCOST141";
                    AVARAGEDIRECTLABORCOST141.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST141.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST141.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST141.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST141.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST141.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST141.Value = @"";

                    LABORCOST141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 71, 290, 76, false);
                    LABORCOST141.Name = "LABORCOST141";
                    LABORCOST141.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST141.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST141.TextFormat = @"#,##0.#0";
                    LABORCOST141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST141.TextFont.Name = "Arial";
                    LABORCOST141.TextFont.Size = 9;
                    LABORCOST141.TextFont.CharSet = 162;
                    LABORCOST141.Value = @"";

                    ORDERNAME151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 76, 116, 81, false);
                    ORDERNAME151.Name = "ORDERNAME151";
                    ORDERNAME151.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME151.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME151.TextFont.Name = "Arial";
                    ORDERNAME151.TextFont.Size = 9;
                    ORDERNAME151.TextFont.CharSet = 162;
                    ORDERNAME151.Value = @"";

                    WORKSHOP151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 76, 156, 81, false);
                    WORKSHOP151.Name = "WORKSHOP151";
                    WORKSHOP151.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP151.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP151.TextFont.Name = "Arial";
                    WORKSHOP151.TextFont.Size = 9;
                    WORKSHOP151.TextFont.CharSet = 162;
                    WORKSHOP151.Value = @"";

                    MONTH151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 76, 184, 81, false);
                    MONTH151.Name = "MONTH151";
                    MONTH151.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH151.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH151.TextFont.Name = "Arial";
                    MONTH151.TextFont.Size = 9;
                    MONTH151.TextFont.CharSet = 162;
                    MONTH151.Value = @"";

                    SHARPDIRECTLABORTIME151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 76, 218, 81, false);
                    SHARPDIRECTLABORTIME151.Name = "SHARPDIRECTLABORTIME151";
                    SHARPDIRECTLABORTIME151.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME151.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME151.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME151.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME151.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME151.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME151.Value = @"";

                    AVARAGEDIRECTLABORCOST151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 76, 263, 81, false);
                    AVARAGEDIRECTLABORCOST151.Name = "AVARAGEDIRECTLABORCOST151";
                    AVARAGEDIRECTLABORCOST151.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST151.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST151.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST151.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST151.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST151.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST151.Value = @"";

                    LABORCOST151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 76, 290, 81, false);
                    LABORCOST151.Name = "LABORCOST151";
                    LABORCOST151.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST151.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST151.TextFormat = @"#,##0.#0";
                    LABORCOST151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST151.TextFont.Name = "Arial";
                    LABORCOST151.TextFont.Size = 9;
                    LABORCOST151.TextFont.CharSet = 162;
                    LABORCOST151.Value = @"";

                    ORDERNAME161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 81, 116, 86, false);
                    ORDERNAME161.Name = "ORDERNAME161";
                    ORDERNAME161.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME161.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME161.TextFont.Name = "Arial";
                    ORDERNAME161.TextFont.Size = 9;
                    ORDERNAME161.TextFont.CharSet = 162;
                    ORDERNAME161.Value = @"";

                    WORKSHOP161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 81, 156, 86, false);
                    WORKSHOP161.Name = "WORKSHOP161";
                    WORKSHOP161.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP161.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP161.TextFont.Name = "Arial";
                    WORKSHOP161.TextFont.Size = 9;
                    WORKSHOP161.TextFont.CharSet = 162;
                    WORKSHOP161.Value = @"";

                    MONTH161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 81, 184, 86, false);
                    MONTH161.Name = "MONTH161";
                    MONTH161.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH161.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH161.TextFont.Name = "Arial";
                    MONTH161.TextFont.Size = 9;
                    MONTH161.TextFont.CharSet = 162;
                    MONTH161.Value = @"";

                    SHARPDIRECTLABORTIME161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 81, 218, 86, false);
                    SHARPDIRECTLABORTIME161.Name = "SHARPDIRECTLABORTIME161";
                    SHARPDIRECTLABORTIME161.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME161.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME161.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME161.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME161.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME161.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME161.Value = @"";

                    AVARAGEDIRECTLABORCOST161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 81, 263, 86, false);
                    AVARAGEDIRECTLABORCOST161.Name = "AVARAGEDIRECTLABORCOST161";
                    AVARAGEDIRECTLABORCOST161.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST161.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST161.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST161.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST161.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST161.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST161.Value = @"";

                    LABORCOST161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 81, 290, 86, false);
                    LABORCOST161.Name = "LABORCOST161";
                    LABORCOST161.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST161.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST161.TextFormat = @"#,##0.#0";
                    LABORCOST161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST161.TextFont.Name = "Arial";
                    LABORCOST161.TextFont.Size = 9;
                    LABORCOST161.TextFont.CharSet = 162;
                    LABORCOST161.Value = @"";

                    ORDERNAME171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 86, 116, 91, false);
                    ORDERNAME171.Name = "ORDERNAME171";
                    ORDERNAME171.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNAME171.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNAME171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ORDERNAME171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ORDERNAME171.TextFont.Name = "Arial";
                    ORDERNAME171.TextFont.Size = 9;
                    ORDERNAME171.TextFont.CharSet = 162;
                    ORDERNAME171.Value = @"";

                    WORKSHOP171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 116, 86, 156, 91, false);
                    WORKSHOP171.Name = "WORKSHOP171";
                    WORKSHOP171.DrawStyle = DrawStyleConstants.vbSolid;
                    WORKSHOP171.FieldType = ReportFieldTypeEnum.ftVariable;
                    WORKSHOP171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    WORKSHOP171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    WORKSHOP171.TextFont.Name = "Arial";
                    WORKSHOP171.TextFont.Size = 9;
                    WORKSHOP171.TextFont.CharSet = 162;
                    WORKSHOP171.Value = @"";

                    MONTH171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 86, 184, 91, false);
                    MONTH171.Name = "MONTH171";
                    MONTH171.DrawStyle = DrawStyleConstants.vbSolid;
                    MONTH171.FieldType = ReportFieldTypeEnum.ftVariable;
                    MONTH171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MONTH171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MONTH171.TextFont.Name = "Arial";
                    MONTH171.TextFont.Size = 9;
                    MONTH171.TextFont.CharSet = 162;
                    MONTH171.Value = @"";

                    SHARPDIRECTLABORTIME171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 86, 218, 91, false);
                    SHARPDIRECTLABORTIME171.Name = "SHARPDIRECTLABORTIME171";
                    SHARPDIRECTLABORTIME171.DrawStyle = DrawStyleConstants.vbSolid;
                    SHARPDIRECTLABORTIME171.FieldType = ReportFieldTypeEnum.ftVariable;
                    SHARPDIRECTLABORTIME171.TextFormat = @"#,##0.#0";
                    SHARPDIRECTLABORTIME171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    SHARPDIRECTLABORTIME171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    SHARPDIRECTLABORTIME171.TextFont.Name = "Arial";
                    SHARPDIRECTLABORTIME171.TextFont.Size = 9;
                    SHARPDIRECTLABORTIME171.TextFont.CharSet = 162;
                    SHARPDIRECTLABORTIME171.Value = @"";

                    AVARAGEDIRECTLABORCOST171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 86, 263, 91, false);
                    AVARAGEDIRECTLABORCOST171.Name = "AVARAGEDIRECTLABORCOST171";
                    AVARAGEDIRECTLABORCOST171.DrawStyle = DrawStyleConstants.vbSolid;
                    AVARAGEDIRECTLABORCOST171.FieldType = ReportFieldTypeEnum.ftVariable;
                    AVARAGEDIRECTLABORCOST171.TextFormat = @"#,##0.#0";
                    AVARAGEDIRECTLABORCOST171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    AVARAGEDIRECTLABORCOST171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AVARAGEDIRECTLABORCOST171.TextFont.Name = "Arial";
                    AVARAGEDIRECTLABORCOST171.TextFont.Size = 9;
                    AVARAGEDIRECTLABORCOST171.TextFont.CharSet = 162;
                    AVARAGEDIRECTLABORCOST171.Value = @"";

                    LABORCOST171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 263, 86, 290, 91, false);
                    LABORCOST171.Name = "LABORCOST171";
                    LABORCOST171.DrawStyle = DrawStyleConstants.vbSolid;
                    LABORCOST171.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORCOST171.TextFormat = @"#,##0.#0";
                    LABORCOST171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    LABORCOST171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    LABORCOST171.TextFont.Name = "Arial";
                    LABORCOST171.TextFont.Size = 9;
                    LABORCOST171.TextFont.CharSet = 162;
                    LABORCOST171.Value = @"";

                    MATERIALNAME111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 124, 105, 129, false);
                    MATERIALNAME111.Name = "MATERIALNAME111";
                    MATERIALNAME111.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME111.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME111.TextFont.Name = "Arial";
                    MATERIALNAME111.TextFont.Size = 9;
                    MATERIALNAME111.TextFont.CharSet = 162;
                    MATERIALNAME111.Value = @"";

                    NEWPRICE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 124, 156, 129, false);
                    NEWPRICE111.Name = "NEWPRICE111";
                    NEWPRICE111.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE111.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE111.TextFont.Name = "Arial";
                    NEWPRICE111.TextFont.Size = 9;
                    NEWPRICE111.TextFont.CharSet = 162;
                    NEWPRICE111.Value = @"";

                    OLDPRICE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 124, 184, 129, false);
                    OLDPRICE111.Name = "OLDPRICE111";
                    OLDPRICE111.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE111.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE111.TextFont.Name = "Arial";
                    OLDPRICE111.TextFont.Size = 9;
                    OLDPRICE111.TextFont.CharSet = 162;
                    OLDPRICE111.Value = @"";

                    DEADPRICE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 124, 218, 129, false);
                    DEADPRICE111.Name = "DEADPRICE111";
                    DEADPRICE111.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE111.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE111.TextFont.Name = "Arial";
                    DEADPRICE111.TextFont.Size = 9;
                    DEADPRICE111.TextFont.CharSet = 162;
                    DEADPRICE111.Value = @"";

                    UNITPRICE111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 124, 247, 129, false);
                    UNITPRICE111.Name = "UNITPRICE111";
                    UNITPRICE111.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE111.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE111.TextFormat = @"#,##0.#0";
                    UNITPRICE111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE111.TextFont.Name = "Arial";
                    UNITPRICE111.TextFont.Size = 9;
                    UNITPRICE111.TextFont.CharSet = 162;
                    UNITPRICE111.Value = @"";

                    MATERIALCOST111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 124, 290, 129, false);
                    MATERIALCOST111.Name = "MATERIALCOST111";
                    MATERIALCOST111.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST111.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST111.TextFormat = @"#,##0.#0";
                    MATERIALCOST111.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST111.TextFont.Name = "Arial";
                    MATERIALCOST111.TextFont.Size = 9;
                    MATERIALCOST111.TextFont.CharSet = 162;
                    MATERIALCOST111.Value = @"";

                    AMOUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 124, 129, 129, false);
                    AMOUNT111.Name = "AMOUNT111";
                    AMOUNT111.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT111.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT111.TextFont.Name = "Arial";
                    AMOUNT111.TextFont.Size = 9;
                    AMOUNT111.TextFont.CharSet = 162;
                    AMOUNT111.Value = @"";

                    MATERIALNAME121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 129, 105, 134, false);
                    MATERIALNAME121.Name = "MATERIALNAME121";
                    MATERIALNAME121.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME121.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME121.TextFont.Name = "Arial";
                    MATERIALNAME121.TextFont.Size = 9;
                    MATERIALNAME121.TextFont.CharSet = 162;
                    MATERIALNAME121.Value = @"";

                    NEWPRICE121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 129, 156, 134, false);
                    NEWPRICE121.Name = "NEWPRICE121";
                    NEWPRICE121.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE121.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE121.TextFont.Name = "Arial";
                    NEWPRICE121.TextFont.Size = 9;
                    NEWPRICE121.TextFont.CharSet = 162;
                    NEWPRICE121.Value = @"";

                    OLDPRICE121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 129, 184, 134, false);
                    OLDPRICE121.Name = "OLDPRICE121";
                    OLDPRICE121.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE121.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE121.TextFont.Name = "Arial";
                    OLDPRICE121.TextFont.Size = 9;
                    OLDPRICE121.TextFont.CharSet = 162;
                    OLDPRICE121.Value = @"";

                    DEADPRICE121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 129, 218, 134, false);
                    DEADPRICE121.Name = "DEADPRICE121";
                    DEADPRICE121.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE121.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE121.TextFont.Name = "Arial";
                    DEADPRICE121.TextFont.Size = 9;
                    DEADPRICE121.TextFont.CharSet = 162;
                    DEADPRICE121.Value = @"";

                    UNITPRICE121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 129, 247, 134, false);
                    UNITPRICE121.Name = "UNITPRICE121";
                    UNITPRICE121.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE121.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE121.TextFormat = @"#,##0.#0";
                    UNITPRICE121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE121.TextFont.Name = "Arial";
                    UNITPRICE121.TextFont.Size = 9;
                    UNITPRICE121.TextFont.CharSet = 162;
                    UNITPRICE121.Value = @"";

                    MATERIALCOST121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 129, 290, 134, false);
                    MATERIALCOST121.Name = "MATERIALCOST121";
                    MATERIALCOST121.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST121.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST121.TextFormat = @"#,##0.#0";
                    MATERIALCOST121.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST121.TextFont.Name = "Arial";
                    MATERIALCOST121.TextFont.Size = 9;
                    MATERIALCOST121.TextFont.CharSet = 162;
                    MATERIALCOST121.Value = @"";

                    AMOUNT121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 129, 129, 134, false);
                    AMOUNT121.Name = "AMOUNT121";
                    AMOUNT121.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT121.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT121.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT121.TextFont.Name = "Arial";
                    AMOUNT121.TextFont.Size = 9;
                    AMOUNT121.TextFont.CharSet = 162;
                    AMOUNT121.Value = @"";

                    MATERIALNAME131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 134, 105, 139, false);
                    MATERIALNAME131.Name = "MATERIALNAME131";
                    MATERIALNAME131.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME131.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME131.TextFont.Name = "Arial";
                    MATERIALNAME131.TextFont.Size = 9;
                    MATERIALNAME131.TextFont.CharSet = 162;
                    MATERIALNAME131.Value = @"";

                    NEWPRICE131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 134, 156, 139, false);
                    NEWPRICE131.Name = "NEWPRICE131";
                    NEWPRICE131.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE131.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE131.TextFont.Name = "Arial";
                    NEWPRICE131.TextFont.Size = 9;
                    NEWPRICE131.TextFont.CharSet = 162;
                    NEWPRICE131.Value = @"";

                    OLDPRICE131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 134, 184, 139, false);
                    OLDPRICE131.Name = "OLDPRICE131";
                    OLDPRICE131.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE131.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE131.TextFont.Name = "Arial";
                    OLDPRICE131.TextFont.Size = 9;
                    OLDPRICE131.TextFont.CharSet = 162;
                    OLDPRICE131.Value = @"";

                    DEADPRICE131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 134, 218, 139, false);
                    DEADPRICE131.Name = "DEADPRICE131";
                    DEADPRICE131.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE131.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE131.TextFont.Name = "Arial";
                    DEADPRICE131.TextFont.Size = 9;
                    DEADPRICE131.TextFont.CharSet = 162;
                    DEADPRICE131.Value = @"";

                    UNITPRICE131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 134, 247, 139, false);
                    UNITPRICE131.Name = "UNITPRICE131";
                    UNITPRICE131.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE131.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE131.TextFormat = @"#,##0.#0";
                    UNITPRICE131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE131.TextFont.Name = "Arial";
                    UNITPRICE131.TextFont.Size = 9;
                    UNITPRICE131.TextFont.CharSet = 162;
                    UNITPRICE131.Value = @"";

                    MATERIALCOST131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 134, 290, 139, false);
                    MATERIALCOST131.Name = "MATERIALCOST131";
                    MATERIALCOST131.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST131.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST131.TextFormat = @"#,##0.#0";
                    MATERIALCOST131.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST131.TextFont.Name = "Arial";
                    MATERIALCOST131.TextFont.Size = 9;
                    MATERIALCOST131.TextFont.CharSet = 162;
                    MATERIALCOST131.Value = @"";

                    AMOUNT131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 134, 129, 139, false);
                    AMOUNT131.Name = "AMOUNT131";
                    AMOUNT131.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT131.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT131.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT131.TextFont.Name = "Arial";
                    AMOUNT131.TextFont.Size = 9;
                    AMOUNT131.TextFont.CharSet = 162;
                    AMOUNT131.Value = @"";

                    MATERIALNAME141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 139, 105, 144, false);
                    MATERIALNAME141.Name = "MATERIALNAME141";
                    MATERIALNAME141.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME141.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME141.TextFont.Name = "Arial";
                    MATERIALNAME141.TextFont.Size = 9;
                    MATERIALNAME141.TextFont.CharSet = 162;
                    MATERIALNAME141.Value = @"";

                    NEWPRICE141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 139, 156, 144, false);
                    NEWPRICE141.Name = "NEWPRICE141";
                    NEWPRICE141.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE141.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE141.TextFont.Name = "Arial";
                    NEWPRICE141.TextFont.Size = 9;
                    NEWPRICE141.TextFont.CharSet = 162;
                    NEWPRICE141.Value = @"";

                    OLDPRICE141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 139, 184, 144, false);
                    OLDPRICE141.Name = "OLDPRICE141";
                    OLDPRICE141.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE141.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE141.TextFont.Name = "Arial";
                    OLDPRICE141.TextFont.Size = 9;
                    OLDPRICE141.TextFont.CharSet = 162;
                    OLDPRICE141.Value = @"";

                    DEADPRICE141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 139, 218, 144, false);
                    DEADPRICE141.Name = "DEADPRICE141";
                    DEADPRICE141.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE141.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE141.TextFont.Name = "Arial";
                    DEADPRICE141.TextFont.Size = 9;
                    DEADPRICE141.TextFont.CharSet = 162;
                    DEADPRICE141.Value = @"";

                    UNITPRICE141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 139, 247, 144, false);
                    UNITPRICE141.Name = "UNITPRICE141";
                    UNITPRICE141.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE141.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE141.TextFormat = @"#,##0.#0";
                    UNITPRICE141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE141.TextFont.Name = "Arial";
                    UNITPRICE141.TextFont.Size = 9;
                    UNITPRICE141.TextFont.CharSet = 162;
                    UNITPRICE141.Value = @"";

                    MATERIALCOST141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 139, 290, 144, false);
                    MATERIALCOST141.Name = "MATERIALCOST141";
                    MATERIALCOST141.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST141.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST141.TextFormat = @"#,##0.#0";
                    MATERIALCOST141.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST141.TextFont.Name = "Arial";
                    MATERIALCOST141.TextFont.Size = 9;
                    MATERIALCOST141.TextFont.CharSet = 162;
                    MATERIALCOST141.Value = @"";

                    AMOUNT141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 139, 129, 144, false);
                    AMOUNT141.Name = "AMOUNT141";
                    AMOUNT141.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT141.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT141.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT141.TextFont.Name = "Arial";
                    AMOUNT141.TextFont.Size = 9;
                    AMOUNT141.TextFont.CharSet = 162;
                    AMOUNT141.Value = @"";

                    MATERIALNAME151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 144, 105, 149, false);
                    MATERIALNAME151.Name = "MATERIALNAME151";
                    MATERIALNAME151.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME151.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME151.TextFont.Name = "Arial";
                    MATERIALNAME151.TextFont.Size = 9;
                    MATERIALNAME151.TextFont.CharSet = 162;
                    MATERIALNAME151.Value = @"";

                    NEWPRICE151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 144, 156, 149, false);
                    NEWPRICE151.Name = "NEWPRICE151";
                    NEWPRICE151.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE151.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE151.TextFont.Name = "Arial";
                    NEWPRICE151.TextFont.Size = 9;
                    NEWPRICE151.TextFont.CharSet = 162;
                    NEWPRICE151.Value = @"";

                    OLDPRICE151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 144, 184, 149, false);
                    OLDPRICE151.Name = "OLDPRICE151";
                    OLDPRICE151.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE151.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE151.TextFont.Name = "Arial";
                    OLDPRICE151.TextFont.Size = 9;
                    OLDPRICE151.TextFont.CharSet = 162;
                    OLDPRICE151.Value = @"";

                    DEADPRICE151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 144, 218, 149, false);
                    DEADPRICE151.Name = "DEADPRICE151";
                    DEADPRICE151.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE151.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE151.TextFont.Name = "Arial";
                    DEADPRICE151.TextFont.Size = 9;
                    DEADPRICE151.TextFont.CharSet = 162;
                    DEADPRICE151.Value = @"";

                    UNITPRICE151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 144, 247, 149, false);
                    UNITPRICE151.Name = "UNITPRICE151";
                    UNITPRICE151.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE151.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE151.TextFormat = @"#,##0.#0";
                    UNITPRICE151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE151.TextFont.Name = "Arial";
                    UNITPRICE151.TextFont.Size = 9;
                    UNITPRICE151.TextFont.CharSet = 162;
                    UNITPRICE151.Value = @"";

                    MATERIALCOST151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 144, 290, 149, false);
                    MATERIALCOST151.Name = "MATERIALCOST151";
                    MATERIALCOST151.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST151.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST151.TextFormat = @"#,##0.#0";
                    MATERIALCOST151.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST151.TextFont.Name = "Arial";
                    MATERIALCOST151.TextFont.Size = 9;
                    MATERIALCOST151.TextFont.CharSet = 162;
                    MATERIALCOST151.Value = @"";

                    AMOUNT151 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 144, 129, 149, false);
                    AMOUNT151.Name = "AMOUNT151";
                    AMOUNT151.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT151.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT151.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT151.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT151.TextFont.Name = "Arial";
                    AMOUNT151.TextFont.Size = 9;
                    AMOUNT151.TextFont.CharSet = 162;
                    AMOUNT151.Value = @"";

                    MATERIALNAME161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 149, 105, 154, false);
                    MATERIALNAME161.Name = "MATERIALNAME161";
                    MATERIALNAME161.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME161.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME161.TextFont.Name = "Arial";
                    MATERIALNAME161.TextFont.Size = 9;
                    MATERIALNAME161.TextFont.CharSet = 162;
                    MATERIALNAME161.Value = @"";

                    NEWPRICE161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 149, 156, 154, false);
                    NEWPRICE161.Name = "NEWPRICE161";
                    NEWPRICE161.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE161.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE161.TextFont.Name = "Arial";
                    NEWPRICE161.TextFont.Size = 9;
                    NEWPRICE161.TextFont.CharSet = 162;
                    NEWPRICE161.Value = @"";

                    OLDPRICE161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 149, 184, 154, false);
                    OLDPRICE161.Name = "OLDPRICE161";
                    OLDPRICE161.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE161.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE161.TextFont.Name = "Arial";
                    OLDPRICE161.TextFont.Size = 9;
                    OLDPRICE161.TextFont.CharSet = 162;
                    OLDPRICE161.Value = @"";

                    DEADPRICE161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 149, 218, 154, false);
                    DEADPRICE161.Name = "DEADPRICE161";
                    DEADPRICE161.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE161.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE161.TextFont.Name = "Arial";
                    DEADPRICE161.TextFont.Size = 9;
                    DEADPRICE161.TextFont.CharSet = 162;
                    DEADPRICE161.Value = @"";

                    UNITPRICE161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 149, 247, 154, false);
                    UNITPRICE161.Name = "UNITPRICE161";
                    UNITPRICE161.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE161.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE161.TextFormat = @"#,##0.#0";
                    UNITPRICE161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE161.TextFont.Name = "Arial";
                    UNITPRICE161.TextFont.Size = 9;
                    UNITPRICE161.TextFont.CharSet = 162;
                    UNITPRICE161.Value = @"";

                    MATERIALCOST161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 149, 290, 154, false);
                    MATERIALCOST161.Name = "MATERIALCOST161";
                    MATERIALCOST161.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST161.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST161.TextFormat = @"#,##0.#0";
                    MATERIALCOST161.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST161.TextFont.Name = "Arial";
                    MATERIALCOST161.TextFont.Size = 9;
                    MATERIALCOST161.TextFont.CharSet = 162;
                    MATERIALCOST161.Value = @"";

                    AMOUNT161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 149, 129, 154, false);
                    AMOUNT161.Name = "AMOUNT161";
                    AMOUNT161.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT161.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT161.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT161.TextFont.Name = "Arial";
                    AMOUNT161.TextFont.Size = 9;
                    AMOUNT161.TextFont.CharSet = 162;
                    AMOUNT161.Value = @"";

                    MATERIALNAME171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 154, 105, 159, false);
                    MATERIALNAME171.Name = "MATERIALNAME171";
                    MATERIALNAME171.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALNAME171.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MATERIALNAME171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALNAME171.TextFont.Name = "Arial";
                    MATERIALNAME171.TextFont.Size = 9;
                    MATERIALNAME171.TextFont.CharSet = 162;
                    MATERIALNAME171.Value = @"";

                    NEWPRICE171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 129, 154, 156, 159, false);
                    NEWPRICE171.Name = "NEWPRICE171";
                    NEWPRICE171.DrawStyle = DrawStyleConstants.vbSolid;
                    NEWPRICE171.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEWPRICE171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    NEWPRICE171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    NEWPRICE171.TextFont.Name = "Arial";
                    NEWPRICE171.TextFont.Size = 9;
                    NEWPRICE171.TextFont.CharSet = 162;
                    NEWPRICE171.Value = @"";

                    OLDPRICE171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 156, 154, 184, 159, false);
                    OLDPRICE171.Name = "OLDPRICE171";
                    OLDPRICE171.DrawStyle = DrawStyleConstants.vbSolid;
                    OLDPRICE171.FieldType = ReportFieldTypeEnum.ftVariable;
                    OLDPRICE171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    OLDPRICE171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    OLDPRICE171.TextFont.Name = "Arial";
                    OLDPRICE171.TextFont.Size = 9;
                    OLDPRICE171.TextFont.CharSet = 162;
                    OLDPRICE171.Value = @"";

                    DEADPRICE171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 184, 154, 218, 159, false);
                    DEADPRICE171.Name = "DEADPRICE171";
                    DEADPRICE171.DrawStyle = DrawStyleConstants.vbSolid;
                    DEADPRICE171.FieldType = ReportFieldTypeEnum.ftVariable;
                    DEADPRICE171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    DEADPRICE171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    DEADPRICE171.TextFont.Name = "Arial";
                    DEADPRICE171.TextFont.Size = 9;
                    DEADPRICE171.TextFont.CharSet = 162;
                    DEADPRICE171.Value = @"";

                    UNITPRICE171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 218, 154, 247, 159, false);
                    UNITPRICE171.Name = "UNITPRICE171";
                    UNITPRICE171.DrawStyle = DrawStyleConstants.vbSolid;
                    UNITPRICE171.FieldType = ReportFieldTypeEnum.ftVariable;
                    UNITPRICE171.TextFormat = @"#,##0.#0";
                    UNITPRICE171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    UNITPRICE171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    UNITPRICE171.TextFont.Name = "Arial";
                    UNITPRICE171.TextFont.Size = 9;
                    UNITPRICE171.TextFont.CharSet = 162;
                    UNITPRICE171.Value = @"";

                    MATERIALCOST171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 247, 154, 290, 159, false);
                    MATERIALCOST171.Name = "MATERIALCOST171";
                    MATERIALCOST171.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALCOST171.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALCOST171.TextFormat = @"#,##0.#0";
                    MATERIALCOST171.HorzAlign = HorizontalAlignmentEnum.haRight;
                    MATERIALCOST171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    MATERIALCOST171.TextFont.Name = "Arial";
                    MATERIALCOST171.TextFont.Size = 9;
                    MATERIALCOST171.TextFont.CharSet = 162;
                    MATERIALCOST171.Value = @"";

                    AMOUNT171 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 154, 129, 159, false);
                    AMOUNT171.Name = "AMOUNT171";
                    AMOUNT171.DrawStyle = DrawStyleConstants.vbSolid;
                    AMOUNT171.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT171.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT171.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    AMOUNT171.TextFont.Name = "Arial";
                    AMOUNT171.TextFont.Size = 9;
                    AMOUNT171.TextFont.CharSet = 162;
                    AMOUNT171.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NewField11.CalcValue = NewField11.Value;
                    NewField121.CalcValue = NewField121.Value;
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField11151.CalcValue = NewField11151.Value;
                    NewField11521.CalcValue = NewField11521.Value;
                    NewField11251.CalcValue = NewField11251.Value;
                    NewField11531.CalcValue = NewField11531.Value;
                    NewField11351.CalcValue = NewField11351.Value;
                    ORDERNAME11.CalcValue = @"";
                    WORKSHOP11.CalcValue = @"";
                    MONTH11.CalcValue = @"";
                    SHARPDIRECTLABORTIME11.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST11.CalcValue = @"";
                    LABORCOST11.CalcValue = @"";
                    NewField11541.CalcValue = NewField11541.Value;
                    TOTALLABORCOST11.CalcValue = @"";
                    TOTALTIME11.CalcValue = @"";
                    NewField114511.CalcValue = NewField114511.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    NewField11161.CalcValue = NewField11161.Value;
                    NewField12541.CalcValue = NewField12541.Value;
                    NewField11261.CalcValue = NewField11261.Value;
                    NewField11551.CalcValue = NewField11551.Value;
                    NewField11361.CalcValue = NewField11361.Value;
                    NewField11561.CalcValue = NewField11561.Value;
                    NewField11571.CalcValue = NewField11571.Value;
                    MATERIALNAME11.CalcValue = @"";
                    NEWPRICE11.CalcValue = @"";
                    OLDPRICE11.CalcValue = @"";
                    DEADPRICE11.CalcValue = @"";
                    UNITPRICE11.CalcValue = @"";
                    MATERIALCOST11.CalcValue = @"";
                    AMOUNT11.CalcValue = @"";
                    NewField1151.CalcValue = NewField1151.Value;
                    TOTALMATERIALCOST11.CalcValue = @"";
                    NewField11611.CalcValue = NewField11611.Value;
                    NewField11171.CalcValue = NewField11171.Value;
                    NewField11181.CalcValue = NewField11181.Value;
                    GRANDTOTALLABORCOST11.CalcValue = @"";
                    GRANDTOTALMATERIALCOST11.CalcValue = @"";
                    GRANDTOTAL11.CalcValue = @"";
                    NewField1171.CalcValue = NewField1171.Value;
                    YAPILANIS11141.CalcValue = YAPILANIS11141.Value;
                    ORDERNAME111.CalcValue = @"";
                    WORKSHOP111.CalcValue = @"";
                    MONTH111.CalcValue = @"";
                    SHARPDIRECTLABORTIME111.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST111.CalcValue = @"";
                    LABORCOST111.CalcValue = @"";
                    ORDERNAME121.CalcValue = @"";
                    WORKSHOP121.CalcValue = @"";
                    MONTH121.CalcValue = @"";
                    SHARPDIRECTLABORTIME121.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST121.CalcValue = @"";
                    LABORCOST121.CalcValue = @"";
                    ORDERNAME131.CalcValue = @"";
                    WORKSHOP131.CalcValue = @"";
                    MONTH131.CalcValue = @"";
                    SHARPDIRECTLABORTIME131.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST131.CalcValue = @"";
                    LABORCOST131.CalcValue = @"";
                    ORDERNAME141.CalcValue = @"";
                    WORKSHOP141.CalcValue = @"";
                    MONTH141.CalcValue = @"";
                    SHARPDIRECTLABORTIME141.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST141.CalcValue = @"";
                    LABORCOST141.CalcValue = @"";
                    ORDERNAME151.CalcValue = @"";
                    WORKSHOP151.CalcValue = @"";
                    MONTH151.CalcValue = @"";
                    SHARPDIRECTLABORTIME151.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST151.CalcValue = @"";
                    LABORCOST151.CalcValue = @"";
                    ORDERNAME161.CalcValue = @"";
                    WORKSHOP161.CalcValue = @"";
                    MONTH161.CalcValue = @"";
                    SHARPDIRECTLABORTIME161.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST161.CalcValue = @"";
                    LABORCOST161.CalcValue = @"";
                    ORDERNAME171.CalcValue = @"";
                    WORKSHOP171.CalcValue = @"";
                    MONTH171.CalcValue = @"";
                    SHARPDIRECTLABORTIME171.CalcValue = @"";
                    AVARAGEDIRECTLABORCOST171.CalcValue = @"";
                    LABORCOST171.CalcValue = @"";
                    MATERIALNAME111.CalcValue = @"";
                    NEWPRICE111.CalcValue = @"";
                    OLDPRICE111.CalcValue = @"";
                    DEADPRICE111.CalcValue = @"";
                    UNITPRICE111.CalcValue = @"";
                    MATERIALCOST111.CalcValue = @"";
                    AMOUNT111.CalcValue = @"";
                    MATERIALNAME121.CalcValue = @"";
                    NEWPRICE121.CalcValue = @"";
                    OLDPRICE121.CalcValue = @"";
                    DEADPRICE121.CalcValue = @"";
                    UNITPRICE121.CalcValue = @"";
                    MATERIALCOST121.CalcValue = @"";
                    AMOUNT121.CalcValue = @"";
                    MATERIALNAME131.CalcValue = @"";
                    NEWPRICE131.CalcValue = @"";
                    OLDPRICE131.CalcValue = @"";
                    DEADPRICE131.CalcValue = @"";
                    UNITPRICE131.CalcValue = @"";
                    MATERIALCOST131.CalcValue = @"";
                    AMOUNT131.CalcValue = @"";
                    MATERIALNAME141.CalcValue = @"";
                    NEWPRICE141.CalcValue = @"";
                    OLDPRICE141.CalcValue = @"";
                    DEADPRICE141.CalcValue = @"";
                    UNITPRICE141.CalcValue = @"";
                    MATERIALCOST141.CalcValue = @"";
                    AMOUNT141.CalcValue = @"";
                    MATERIALNAME151.CalcValue = @"";
                    NEWPRICE151.CalcValue = @"";
                    OLDPRICE151.CalcValue = @"";
                    DEADPRICE151.CalcValue = @"";
                    UNITPRICE151.CalcValue = @"";
                    MATERIALCOST151.CalcValue = @"";
                    AMOUNT151.CalcValue = @"";
                    MATERIALNAME161.CalcValue = @"";
                    NEWPRICE161.CalcValue = @"";
                    OLDPRICE161.CalcValue = @"";
                    DEADPRICE161.CalcValue = @"";
                    UNITPRICE161.CalcValue = @"";
                    MATERIALCOST161.CalcValue = @"";
                    AMOUNT161.CalcValue = @"";
                    MATERIALNAME171.CalcValue = @"";
                    NEWPRICE171.CalcValue = @"";
                    OLDPRICE171.CalcValue = @"";
                    DEADPRICE171.CalcValue = @"";
                    UNITPRICE171.CalcValue = @"";
                    MATERIALCOST171.CalcValue = @"";
                    AMOUNT171.CalcValue = @"";
                    return new TTReportObject[] { NewField11,NewField121,NewField1131,NewField11511,NewField11151,NewField11521,NewField11251,NewField11531,NewField11351,ORDERNAME11,WORKSHOP11,MONTH11,SHARPDIRECTLABORTIME11,AVARAGEDIRECTLABORCOST11,LABORCOST11,NewField11541,TOTALLABORCOST11,TOTALTIME11,NewField114511,NewField1141,NewField11161,NewField12541,NewField11261,NewField11551,NewField11361,NewField11561,NewField11571,MATERIALNAME11,NEWPRICE11,OLDPRICE11,DEADPRICE11,UNITPRICE11,MATERIALCOST11,AMOUNT11,NewField1151,TOTALMATERIALCOST11,NewField11611,NewField11171,NewField11181,GRANDTOTALLABORCOST11,GRANDTOTALMATERIALCOST11,GRANDTOTAL11,NewField1171,YAPILANIS11141,ORDERNAME111,WORKSHOP111,MONTH111,SHARPDIRECTLABORTIME111,AVARAGEDIRECTLABORCOST111,LABORCOST111,ORDERNAME121,WORKSHOP121,MONTH121,SHARPDIRECTLABORTIME121,AVARAGEDIRECTLABORCOST121,LABORCOST121,ORDERNAME131,WORKSHOP131,MONTH131,SHARPDIRECTLABORTIME131,AVARAGEDIRECTLABORCOST131,LABORCOST131,ORDERNAME141,WORKSHOP141,MONTH141,SHARPDIRECTLABORTIME141,AVARAGEDIRECTLABORCOST141,LABORCOST141,ORDERNAME151,WORKSHOP151,MONTH151,SHARPDIRECTLABORTIME151,AVARAGEDIRECTLABORCOST151,LABORCOST151,ORDERNAME161,WORKSHOP161,MONTH161,SHARPDIRECTLABORTIME161,AVARAGEDIRECTLABORCOST161,LABORCOST161,ORDERNAME171,WORKSHOP171,MONTH171,SHARPDIRECTLABORTIME171,AVARAGEDIRECTLABORCOST171,LABORCOST171,MATERIALNAME111,NEWPRICE111,OLDPRICE111,DEADPRICE111,UNITPRICE111,MATERIALCOST111,AMOUNT111,MATERIALNAME121,NEWPRICE121,OLDPRICE121,DEADPRICE121,UNITPRICE121,MATERIALCOST121,AMOUNT121,MATERIALNAME131,NEWPRICE131,OLDPRICE131,DEADPRICE131,UNITPRICE131,MATERIALCOST131,AMOUNT131,MATERIALNAME141,NEWPRICE141,OLDPRICE141,DEADPRICE141,UNITPRICE141,MATERIALCOST141,AMOUNT141,MATERIALNAME151,NEWPRICE151,OLDPRICE151,DEADPRICE151,UNITPRICE151,MATERIALCOST151,AMOUNT151,MATERIALNAME161,NEWPRICE161,OLDPRICE161,DEADPRICE161,UNITPRICE161,MATERIALCOST161,AMOUNT161,MATERIALNAME171,NEWPRICE171,OLDPRICE171,DEADPRICE171,UNITPRICE171,MATERIALCOST171,AMOUNT171};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public HasarveDurumTespitRaporu2()
        {
            MAIN = new MAINGroup(this,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            Name = "HASARVEDURUMTESPITRAPORU2";
            Caption = "Hasar ve Durum Tespit Raporu";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oeLandscape;
            UserMarginLeft = 15;
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