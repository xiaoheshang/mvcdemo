using demo1.Common.MenuHelper.Base;
using demo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo1.Common.MenuHelper
{
    public class HtmlBuilder:BaseHtmlTagEngine<Model.cd>
    {

        public HtmlBuilder(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }


        protected override void BuildTagContainer(Model.cd item, TagContainer parent)
        {
            TagContainer tc = FillTag(item, parent);

            foreach (Model.cd mmi in item.GetChildren())
            {
                BuildTagContainer(mmi, tc);
            }
        }

        /// <summary>
        /// item有子成员返回ul container, 没有子成员返回li container
        /// </summary>
        /// <param name="item"></param>
        /// <param name="tc_parent"></param>
        /// <returns></returns>
        TagContainer FillTag(Model.cd item, TagContainer tc_parent)
        {
            //先把本身的菜单项加上
            TagContainer li_tc = new TagContainer(ref _CntNumber, tc_parent);
            li_tc.Name = item.cdmc;
            li_tc.Tb = AddItem(item); //构建li标签里面的内容

            //如果有子菜单把上面的li标签当作父容器在其下面创建一个ul标签，并返回这个ul标签容器
            if (HasChildren(item))
            {
                TagContainer ui_container = new TagContainer(ref _CntNumber, li_tc);
                ui_container.Name = "ul";
                ui_container.Tb = Add_UL_Tag();
                return ui_container;
            }

            return li_tc;
        }

        /// <summary>
        /// 增加一个 li （即一个菜单项）
        /// </summary>
        /// <param name="mi"></param>
        /// <returns>li</returns>
        TagBuilder AddItem(Model.cd mi)
        {
            //<li>
            var li_tag = new TagBuilder("li");
            //<a>
            var a_tag = new TagBuilder("a");
            a_tag.AddCssClass("sideline");
            string a_href = "";
            if (mi.gnid != null)
            {
                a_href = getUrlByGnid(mi.gnid.Value,_htmlHelper);
            }
            a_tag.Attributes.Add("href", a_href);
            //<i>
            var i_tag = new TagBuilder("i");
            if (!string.IsNullOrEmpty(mi.icon))
            {
                i_tag.AddCssClass(mi.icon + " nav-icon");
            }
            //<span>
            var span_tag = new TagBuilder("span");
            span_tag.AddCssClass("title");

            //有下级菜单需添加的html标签
            //< i class="zmdi zmdi-caret-down icon-down"></i>
            //<span class="label-rounded">3</span>
            var sub_i_tag = new TagBuilder("i");
            sub_i_tag.AddCssClass("zmdi zmdi-caret-down icon-down");
            var sub_span_tag = new TagBuilder("span");
            sub_span_tag.AddCssClass("label-rounded");
            if (HasChildren(mi))
            {
                sub_span_tag.InnerHtml = mi.GetChildren().Count().ToString();
                a_tag.MergeAttribute("data-click", "toggle-section", true);
                a_tag.MergeAttribute("data-id", "ksxxxz",true);
                a_tag.MergeAttribute("href", "javascript:void(0)", true);
                a_tag.InnerHtml += sub_i_tag.ToString();
                a_tag.InnerHtml += sub_span_tag.ToString();
            }

            //组合
            span_tag.InnerHtml = mi.cdmc;
            a_tag.InnerHtml += i_tag.ToString();
            a_tag.InnerHtml += span_tag.ToString();

            li_tag.InnerHtml = a_tag.ToString();
            return li_tag;
        }

        protected TagBuilder Add_UL_Tag()
        {
            TagBuilder ul_tag = new TagBuilder("ul");
            ul_tag.AddCssClass("l2 sub-list section-ksxxxz");
            return ul_tag;
        }
        
        string getUrlByGnid(int gnid,HtmlHelper htmlHelper)
        {
            DAL.gn gndal = new DAL.gn();
            Model.gn gn = gndal.GetModel(gnid);

            string contentUrl = UrlHelper.GenerateContentUrl("~/", htmlHelper.ViewContext.HttpContext);
            var url = contentUrl + gn.controller;
            if (!string.IsNullOrEmpty(gn.action))
            {
                url += "/" + gn.action;
            }

            return url;
        }
        
    }
}