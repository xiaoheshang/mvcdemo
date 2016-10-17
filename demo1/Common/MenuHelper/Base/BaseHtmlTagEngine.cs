using demo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo1.Common.MenuHelper.Base
{
    public abstract class BaseHtmlTagEngine<T> where T:IItem<T>
    {
        protected int _CntNumber = 0;
        TagContainer _TopTagContainer;
        string _OutString;
        protected HtmlHelper _htmlHelper;

        public BaseHtmlTagEngine(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public TagContainer TopTagContainer
        {
            get { return _TopTagContainer; }
        }


        public void buildTreeStruct(MenuViewModel<T> model)
        {
            _CntNumber = 0;
            try
            {
                //创建根容器
                _TopTagContainer = new TagContainer(ref _CntNumber, null);
                TagBuilder tb = new TagBuilder("ul");
                tb.AddCssClass("l1 section-content");
                _TopTagContainer.Tb = tb;

                //
                foreach(T mi in model.MenuItems)
                {
                    BuildTagContainer(mi, _TopTagContainer);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 将树解析成html
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            //try
            //{
                while (true)
                {
                    //获取第一个叶节点
                    TagContainer tc = GetNoChildNode(_TopTagContainer);

                    bool PrcComplete = false;

                    Levelup(tc, ref PrcComplete);

                    if (PrcComplete)
                    {
                        break;
                    }
                }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            return _OutString;
        }
        /// <summary>
        /// Cutting the branches and rescanning the tree, and again
        /// </summary>
        /// <param name="tc"></param>
        /// <param name="PrcComplete"></param>
        private void Levelup(TagContainer tc, ref bool ProcessingComplete)
        {
            while (tc != null)
            {
                if (tc.ParentContainer != null)
                {
                    if (tc.ParentContainer.Tb != null)
                    {
                        tc.ParentContainer.Tb.InnerHtml += tc.Tb.ToString();
                        _OutString = tc.ParentContainer.Tb.ToString();
                    }
                    else
                    {
                        ProcessingComplete = true;
                        break; //dummy or invalid container
                    }

                    if (tc.ParentContainer.ChildrenContainers.Count > 1)
                    {
                        // this branch has to be cut off, we move all the content up
                        tc.ParentContainer.ChildrenContainers.Remove(tc);
                        break;
                    }

                    tc = tc.ParentContainer; // moving up the tree
                }
                else
                {
                    ProcessingComplete = true;
                    break;
                }
            }
        }

        protected abstract void BuildTagContainer(T item, TagContainer parent);

        protected static bool HasChildren(T item)
        {
            if (item == null)
            {
                return false;
            }

            return item.GetChildren().Count > 0;
        }


        /// <summary>
        /// 获取第一个枝叶点
        /// </summary>
        /// <param name="tc">查询枝叶点的起始叶点</param>
        /// <returns></returns>
        TagContainer GetNoChildNode(TagContainer tc)
        {
            List<TagContainer> containerList = new List<TagContainer>();

            CollectNoChildNodes(tc, containerList);

            return containerList.First();

        }

        /// <summary>
        /// 找到所有叶节点，添加到containerList
        /// </summary>
        /// <param name="tc"></param>
        /// <param name="containerList"></param>
        private void CollectNoChildNodes(TagContainer tc, List<TagContainer> containerList)
        {
            if (tc == null)
            {
                return;
            }
            if (tc.ChildrenContainers.Count == 0)
            {
                containerList.Add(tc);
            }

            foreach (TagContainer tcc in tc.ChildrenContainers)
            {
                CollectNoChildNodes(tcc, containerList);
            }

        }
    }
}