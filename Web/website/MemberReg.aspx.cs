using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using NCCQ.Model;

namespace Web.website
{
    public partial class MemberReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            T_UserInfo model = new T_UserInfo();
            model.CardId = this.mem_card.Value;
            model.CreateDate = System.DateTime.Now;
            model.EndDate = System.DateTime.Now;
            model.IsCheck = 0;
            model.UserAddress = this.men_address.Value;
            model.UserEmail = this.mem_email.Value;
            model.UserLogName = this.mem_account.Value;
            model.UserLogPass = this.mem_password.Value;
            model.UserName = this.mem_name.Value;
            model.UserSex = this.ddlsex.SelectedValue;
            model.UserState = 1;
            model.UserTel = this.mem_phone.Value;
            NCCQ.BLL.T_UserInfoBll bll = new NCCQ.BLL.T_UserInfoBll();
            if (bll.CheckUserName(model.UserLogName))
            {
                if (this.mem_password.Value == this.con_password.Value)
                {
                    string str = bll.Create(model);
                    MessageBox.Show(this, str);
                    this.men_address.Value = "";
                    this.mem_name.Value = "";
                    this.mem_account.Value = "";
                    this.mem_email.Value = "";
                    this.mem_phone.Value = "";
                    
                }
                else { MessageBox.Show(this, "两次密码不一致，请重新输入！"); this.mem_password.Value = ""; this.con_password.Value = ""; }
            }
            else
            {
                MessageBox.Show(this,"该登陆账号已经存在，请重新填写！");
            }
            
        }
    }
}