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
    /// listpro 的摘要说明
    /// </summary>
    public class listpro : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            
            //同步到公共资源交易网站添加交易项目和成交公告信息
            string str = new T_ListedProjectBll().ProcessRequest(context);
            string action = context.Request.QueryString["action"].ToString();
            //添加的时候同步
            if (action == "add")
            {
                if (str.CompareTo("成功")>-1)
                {
                    cn.rcggzy.www.WangZhan cc = new cn.rcggzy.www.WangZhan();
                    NCCQ.Model.T_ListedProject model = new T_ListedProject();
                    model= GetModel(context);
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<span style=\" font-size:14px; line-height:35px;\">");
                    sb.Append("所在区域："+model.Region+"<br/>");
                    sb.Append("转出方：" + model.OutName + "<br/>");
                    sb.Append("挂牌价格：" + model.ListingPrice + "<br/>");
                    sb.Append("拟转出期限：" + model.OutPeriod + "<br/>");
                    sb.Append("拟转出面积（亩）：" + model.OutArea + "<br/>");
                    sb.Append("挂牌状态：" + model.ListingStatus + "<br/>");
                    sb.Append(" </span>");
                    try
                    {
                        cc.PushNongCunChanQuan(model.OutProName, sb.ToString(), "", "", "1");
                    }
                    catch { }
                }
            }
            else if (action=="up")//修改交易完成变成成交公告时候同步
            {
                if (str.CompareTo("成功")>-1)
                {
                    cn.rcggzy.www.WangZhan cc = new cn.rcggzy.www.WangZhan();
                    NCCQ.Model.T_ListedProject model = new T_ListedProject();
                    model= GetModel(context);
                    if (model.ListingStatus == "交易完成")
                    {


                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<span style=\" font-size:14px; line-height:35px;\">");
                        sb.Append("所在区域：" + model.Region + "<br/>");
                        sb.Append("转出方：" + model.OutName + "<br/>");
                        sb.Append("挂牌价格：" + model.ListingPrice + "<br/>");
                        sb.Append("拟转出期限：" + model.OutPeriod + "<br/>");
                        sb.Append("拟转出面积（亩）：" + model.OutArea + "<br/>");
                        sb.Append("挂牌状态：" + model.ListingStatus + "<br/>");
                        sb.Append(" </span>");
                        try
                        {
                            cc.PushNongCunChanQuan(model.OutProName, sb.ToString(), "", "", "3");
                        }
                        catch { }
                    }
                }
            }

            context.Response.Write(str);
        }
        private T_ListedProject GetModel(HttpContext context)
        {
            T_ListedProject model = new T_ListedProject();
            try { model.Id = int.Parse(context.Request.Form["Id"].ToString()); }
            catch { }
            
            model.UnitCode = context.Request.Form["UnitCode"].ToString();
            if ("" != context.Request.Form["ProNum"].ToString())
            {
                model.ProNum = context.Request.Form["ProNum"].ToString();
            }
            else
            {
                model.ProNum = model.UnitCode + DateTime.Now.ToString("yyyyMMddhhmmss");
            }
            model.Region = context.Request.Form["Region"].ToString();
            model.ProType = context.Request.Form["ProType"].ToString();
            model.OutProName = context.Request.Form["OutProName"].ToString();
            model.OutName = context.Request.Form["OutName"].ToString();
            model.ListingPrice = context.Request.Form["ListingPrice"].ToString();
            model.OutPeriod = context.Request.Form["OutPeriod"].ToString();
            model.Authorization = context.Request.Form["Authorization"].ToString();
            model.Located = context.Request.Form["Located"].ToString();
            model.ManageAuth = context.Request.Form["ManageAuth"].ToString();
            model.ContractKind = context.Request.Form["ContractKind"].ToString();
            model.OutArea = context.Request.Form["OutArea"].ToString();
            model.FarmersNum = context.Request.Form["FarmersNum"].ToString();
            model.East = context.Request.Form["East"].ToString();
            model.South = context.Request.Form["South"].ToString();
            model.West = context.Request.Form["West"].ToString();
            model.North = context.Request.Form["North"].ToString();
            model.GlebePurpose = context.Request.Form["GlebePurpose"].ToString();
            model.WhetherAgainOut = context.Request.Form["WhetherAgainOut"].ToString();
            model.OutWay = context.Request.Form["OutWay"].ToString();
            model.FarmersWishes = context.Request.Form["FarmersWishes"].ToString();
            model.ListedPeriod = context.Request.Form["ListedPeriod"].ToString();
            model.TwoApplication = context.Request.Form["TwoApplication"].ToString();
            model.TranCondition = context.Request.Form["TranCondition"].ToString();
            model.TranMode = context.Request.Form["TranMode"].ToString();
            model.IsMorSeal = context.Request.Form["IsMorSeal"].ToString();
            model.Other = context.Request.Form["Other"].ToString();
            try { model.EndDate = DateTime.Parse(context.Request.Form["EndDate"].ToString()); }
            catch { model.EndDate = DateTime.Now; }
            model.ListingStatus = context.Request.Form["ListingStatus"].ToString();
            try { model.IfUp = int.Parse(context.Request.Form["IfUp"].ToString()); }
            catch { }
           
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