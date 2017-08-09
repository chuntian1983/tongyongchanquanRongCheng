using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NCCQ.DBFactory;
using System.Data;
using System.Data.SqlClient;

namespace Web.website
{
    public partial class Gpinfo : System.Web.UI.Page
    {
        public string ClassName;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClassName = "挂牌项目";
            if (Request.QueryString["id"]!=null)
            {
                DataTable dt = new DataTable();
                dt = DbHelper.Factory().ExecuteDataTable("select * from T_ListedProject where id='"+Request.QueryString["id"]+"'");
                if (dt.Rows.Count>0)
                {
                    this.lbxmbh.Text = dt.Rows[0]["ProNum"].ToString();
                    this.lbxmbh0.Text = dt.Rows[0]["Region"].ToString();
                    NCCQ.Model.T_ListedProjectType model = new NCCQ.Model.T_ListedProjectType();
                    NCCQ.BLL.T_ListedProjectTypeBll bll = new NCCQ.BLL.T_ListedProjectTypeBll();
                    model = bll.getModel(dt.Rows[0]["ProType"].ToString());
                    this.lbxmbh1.Text = model.ListedProjectTypeName;
                    this.lbxmbh2.Text = dt.Rows[0]["OutProName"].ToString();
                    this.lbxmbh3.Text = dt.Rows[0]["OutName"].ToString();
                    this.lbxmbh4.Text = dt.Rows[0]["ListingPrice"].ToString();
                    this.lbxmbh5.Text = dt.Rows[0]["OutPeriod"].ToString();
                    this.lbxmbh6.Text = dt.Rows[0]["Authorization"].ToString();
                    this.lbxmbh7.Text = dt.Rows[0]["Located"].ToString();
                    this.lbxmbh8.Text = dt.Rows[0]["ManageAuth"].ToString();
                    this.lbxmbh9.Text = dt.Rows[0]["ContractKind"].ToString();
                    this.lbxmbh10.Text = dt.Rows[0]["OutArea"].ToString();
                    this.lbxmbh11.Text = dt.Rows[0]["FarmersNum"].ToString();
                    this.lbxmbh12.Text = dt.Rows[0]["East"].ToString();
                    this.lbxmbh13.Text = dt.Rows[0]["South"].ToString();
                    this.lbxmbh14.Text = dt.Rows[0]["West"].ToString();
                    this.lbxmbh15.Text = dt.Rows[0]["North"].ToString();
                    this.lbxmbh16.Text = dt.Rows[0]["GlebePurpose"].ToString();
                    this.lbxmbh17.Text = dt.Rows[0]["WhetherAgainOut"].ToString();
                    this.lbxmbh18.Text = dt.Rows[0]["OutWay"].ToString();
                    this.lbxmbh19.Text = dt.Rows[0]["FarmersWishes"].ToString();
                    this.lbxmbh20.Text = dt.Rows[0]["ListedPeriod"].ToString();
                    this.lbxmbh21.Text = dt.Rows[0]["TwoApplication"].ToString();
                    this.lbxmbh22.Text = dt.Rows[0]["TranCondition"].ToString();
                    this.lbxmbh23.Text = dt.Rows[0]["TranMode"].ToString();
                    this.lbxmbh24.Text = dt.Rows[0]["IsMorSeal"].ToString();
                    this.lbxmbh25.Text = dt.Rows[0]["Other"].ToString();
                    this.lbxmbh26.Text = dt.Rows[0]["EndDate"].ToString();
                    this.lbxmbh27.Text = dt.Rows[0]["ListingStatus"].ToString();
                }
            }
        }
    }
}