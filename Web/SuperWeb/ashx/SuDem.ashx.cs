using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using NCCQ.BLL;
using NCCQ.Model;

namespace Web.SuperWeb.ashx
{
    /// <summary>
    /// SuDem 的摘要说明
    /// </summary>
    public class SuDem : IHttpHandler, IReadOnlySessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //同步到公共资源交易网站添加交易项目信息
            string str =  new T_SupplyDemandBll().ProcessRequest(context);
            string action = context.Request.QueryString["action"].ToString();
            if (action == "add")
            {
                if (str.CompareTo("成功") > -1)
                {
                    try
                    {
                        cn.rcggzy.www.WangZhan cc = new cn.rcggzy.www.WangZhan();
                        NCCQ.Model.T_SupplyDemand model = new T_SupplyDemand();
                        model = GetModel(context);
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<span style=\" font-size:14px; line-height:35px;\">");
                        if (model.SupplyOrDemand == 1)
                        {
                            sb.Append("供应信息：<br/>");
                            sb.Append("项目名称：" + model.ProName + "<br/>");
                            sb.Append("供应方姓名：" + model.dName + "<br/>");
                            sb.Append("供应面积：" + model.dArea + "<br/>");
                            sb.Append("概况：" + model.dGlebePurpose + "<br/>");
                            sb.Append("价格：" + model.dQuotation + "<br/>");
                            sb.Append("联系电话：" + model.dCenterContact + "<br/>");

                        }
                        else
                        {
                            sb.Append("需求信息：<br/>");
                            sb.Append("项目名称：" + model.ProName + "<br/>");
                            sb.Append("需求方：" + model.sName + "<br/>");
                            sb.Append("需求面积：" + model.sOutArea + "<br/>");
                            sb.Append("概况：" + model.sLocated + "<br/>");
                            sb.Append("价格：" + model.sListingPrice + "<br/>");
                            sb.Append("联系电话：" + model.sProContact + "<br/>");
                        }


                        sb.Append(" </span>");

                        cc.PushNongCunChanQuan(model.ProName, sb.ToString(), "", "", "2");
                    }
                    catch { }
                }
            }
            context.Response.Write(str);
        }
        private T_SupplyDemand GetModel(HttpContext context)
        {
            T_SupplyDemand model = new T_SupplyDemand();
           
            try { model.SupplyOrDemand = int.Parse(context.Request.Form["rSupplyOrDemand"].ToString()); }
            catch { }
            model.ProName = context.Request.Form["ProName"].ToString();
            model.KeyWord = context.Request.Form["KeyWord"].ToString();
            model.ProNum = context.Request.Form["ProNum"].ToString();
            model.dName = context.Request.Form["dName"].ToString();
            model.dGlebePurpose = context.Request.Form["dGlebePurpose"].ToString();
            try { model.dListingDate = DateTime.Parse(context.Request.Form["dListingDate"].ToString()); }
            catch { }
            model.dArea = context.Request.Form["dArea"].ToString();
            model.dQuotation = context.Request.Form["dQuotation"].ToString();
            model.dcirculation = context.Request.Form["dcirculation"].ToString();
            model.dDeadline = context.Request.Form["dDeadline"].ToString();
            model.dCenterContact = context.Request.Form["dCenterContact"].ToString();
            model.dProContact = context.Request.Form["dProContact"].ToString();
            model.sName = context.Request.Form["sName"].ToString();
            model.sLandProperties = context.Request.Form["sLandProperties"].ToString();
            model.sOther = context.Request.Form["sOther"].ToString();
            model.sLocated = context.Request.Form["sLocated"].ToString();
            model.sOutArea = context.Request.Form["sOutArea"].ToString();
            model.sDeadline = context.Request.Form["sDeadline"].ToString();
            model.sOutWay = context.Request.Form["sOutWay"].ToString();
            try { model.sListedData = DateTime.Parse(context.Request.Form["sListedData"].ToString()); }
            catch { }
            model.sOutAgain = context.Request.Form["sOutAgain"].ToString();
            model.sTransactions = context.Request.Form["sTransactions"].ToString();
            model.sIsMorSeal = context.Request.Form["sIsMorSeal"].ToString();
            model.sListingPrice = context.Request.Form["sListingPrice"].ToString();
            model.sCenterContact = context.Request.Form["sCenterContact"].ToString();
            model.sProContact = context.Request.Form["sProContact"].ToString();
            model.sSettlement = context.Request.Form["sSettlement"].ToString();
            model.Remark = context.Request.Form["Remark"].ToString();
            return model;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}