using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NCCQ.Model;
using NCCQ.DBFactory;
using System.IO;

namespace NCCQ.DAL
{
    public class T_NewsDal
    {
        //创建新闻
        public bool Create(T_News model)
        {
            try
            {
                object[] obj = { model.AdminUserId, model.NewsTypeId, model.Keyword, model.Content, model.UnitCode, model.NewsTitle, model.NewsSubheading, model.NewsSource, model.NewsContent, model.NewsImg, model.NumClicks, model.IfShow, model.IfHost, model.IfDel, model.IfUp, model.IsCheck, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss") };
                string strSql = string.Format("insert into T_News(AdminUserId,NewsTypeId,Keyword,Content,UnitCode,NewsTitle,NewsSubheading,NewsSource,NewsContent,NewsImg,NumClicks,IfShow,IfHost,IfDel,IfUp,IsCheck,Editor,CreateDate) values ({0},{1},'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13},{14},{15},'{16}','{17}')", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) >0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception) { throw; }
        }
        //删除新闻
        public bool Delete(int userId, int id)
        {
            try
            {
                string strSql = string.Format("delete from T_News where Id={0} and AdminUserId={1}", id, userId);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        //删除新闻
        public bool Delete(int id)
        {
            try
            {
                string strSql = string.Format("delete from T_News where Id={0} ", id);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        //更新新闻
        public bool Update(T_News model)
        {
            try
            {
                object[] obj = { model.AdminUserId, model.NewsTypeId, model.Keyword, model.Content, model.UnitCode, model.NewsTitle, model.NewsSubheading, model.NewsSource, model.NewsContent, model.NewsImg, model.NumClicks, model.IfShow, model.IfHost, model.IfDel, model.IfUp, model.IsCheck, model.Editor, model.CreateDate.ToString("yyyy-MM-dd HH:mm:ss"), model.Id };
                string strSql = string.Format("update T_News set AdminUserId={0},NewsTypeId={1},Keyword='{2}',Content='{3}',UnitCode='{4}',NewsTitle='{5}',NewsSubheading='{6}',NewsSource='{7}',NewsContent='{8}',NewsImg='{9}',NumClicks={10},IfShow={11},IfHost={12},IfDel={13},IfUp={14},IsCheck={15},Editor='{16}',CreateDate='{17}'  where Id={18}", obj);
                if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
        //获取单个对象
        public T_News GetModel(int id)
        {
            try
            {
                string strSql = string.Format("select top 1 Id,AdminUserId,NewsTypeId,Keyword,Content,UnitCode,NewsTitle,NewsSubheading,NewsSource,NewsContent,NewsImg,NumClicks,IfShow,IfHost,IfDel,IfUp,IsCheck,Editor,CreateDate from T_News where Id={0}", id);
                T_News model = null;
                using (dynamic read = DbHelper.Factory().ExecuteReader(strSql.ToString()))
                {
                    model = new T_News();
                    if (read.Read())
                    {

                        model.Id = int.Parse(read["Id"].ToString());
                        try { model.AdminUserId = int.Parse(read["AdminUserId"].ToString()); }
                        catch { }
                        try { model.NewsTypeId = int.Parse(read["NewsTypeId"].ToString()); }
                        catch { }
                        model.Keyword = read["Keyword"].ToString();
                        model.Content = read["Content"].ToString();
                        model.UnitCode = read["UnitCode"].ToString();
                        model.NewsTitle = read["NewsTitle"].ToString();
                        model.NewsSubheading = read["NewsSubheading"].ToString();
                        model.NewsSource = read["NewsSource"].ToString();
                        model.NewsContent = read["NewsContent"].ToString();
                        model.NewsImg = read["NewsImg"].ToString();
                        try { model.NumClicks = int.Parse(read["NumClicks"].ToString()); }
                        catch { }
                        try { model.IfShow = int.Parse(read["IfShow"].ToString()); }
                        catch { }
                        try { model.IfHost = int.Parse(read["IfHost"].ToString()); }
                        catch { }
                        try { model.IfDel = int.Parse(read["IfDel"].ToString()); }
                        catch { }
                        try { model.IfUp = int.Parse(read["IfUp"].ToString()); }
                        catch { }
                        try { model.IsCheck = int.Parse(read["IsCheck"].ToString()); }
                        catch { }
                        model.Editor = read["Editor"].ToString();
                        try { model.CreateDate = DateTime.Parse(read["CreateDate"].ToString()); }
                        catch { }
                    }
                    read.Dispose();
                }
                return model;
            }
            catch (Exception) { throw; }
        }
        //前台获取新闻信息列表
        public DataTable GetAllList(string newType, int startIndex, int pageSize)
        {
            string strSql = string.Format(" select [Id],[AdminUserId],[NewsTypeId],[Keyword],[Content],[UnitCode],[NewsTitle],[NewsSubheading],[NewsSource],[NewsContent],[NewsImg],[NumClicks],[IfShow],[IfHost],[IfDel],[IfUp],[IsCheck],[Editor],[CreateDate] from T_News where [NewsTypeId]= {0} and IsCheck = 1 and IfDel = 0 order by CreateDate desc", newType);
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_News");
        }
        //更新新闻点击数
        public void UpdateNumClicks(int id)
        {
            try
            {
                string strSql = string.Format("update T_News set NumClicks=NumClicks+1 where Id= {0}", id);
                DbHelper.Factory().ExecuteNonQuery(strSql);
            }
            catch (Exception) { throw; }
        }
        //首页显示
        public DataTable GetTopPageShow(string newType, string top)
        {
            string strSql = string.Format(" select top {0} [Id],[AdminUserId],[NewsTypeId],[Keyword],[Content],[UnitCode],[NewsTitle],[NewsSubheading],[NewsSource],[NewsContent],[NewsImg],[NumClicks],[IfShow],[IfHost],[IfDel],[IfUp],[IsCheck],[Editor],[CreateDate] from T_News where [NewsTypeId]= {1} and IsCheck = 1 and IfDel = 0 order by CreateDate desc", top, newType);
            return DbHelper.Factory().ExecuteDataTable(strSql);
        }
        //获取总和
        public int CountNum(string where)
        {
            string strSql = "select count(Id) from T_News ";
            if (where != "")
            {
                strSql += string.Format(" where {0}", where);
            }
            return (int)DbHelper.Factory().ExecuteScalar(strSql);
        }
        //更新新闻状态
        public bool UpdateState(string row, string value, string where)
        {
            string strSql = string.Format("update T_News set {0}={1} where Id ={2}", row, value, where);
            if (DbHelper.Factory().ExecuteNonQuery(strSql) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //----------------------------------------------------------------------------------
        //后台管理使用的新闻集合
        public DataTable GetAllList(string sqlWhere, int startIndex, int pageSize, string order)
        {
            string strSql = "select [T_News].[Id],[T_News].[AdminUserId],[T_NewsType].[NewsTypeName] as [NewsTypeId],[T_News].[Keyword],[T_News].[Content],[T_Organization].[OrgShortName] as [UnitCode],[T_News].[NewsTitle],[T_News].[NewsSubheading],[T_News].[NewsSource],[T_News].[NewsContent],[T_News].[NewsImg],[T_News].[NumClicks],[T_News].[IfShow],[T_News].[IfHost],[T_News].[IfDel],[T_News].[IfUp],[T_News].[IsCheck],[T_News].[Editor],[T_News].[CreateDate] from [T_News] left join [T_Organization] on [T_News].[UnitCode] = [T_Organization].[OrgCode] left join [T_NewsType] on [T_News].[NewsTypeId] = [T_NewsType].[Id] ";
            if (sqlWhere != "")
            {
                strSql += string.Format(" where {0}", sqlWhere);
            }
            strSql += order;
            return DbHelper.Factory().ExecuteDataTable(strSql, startIndex * pageSize, pageSize, "T_News");
        }
    }
}
