using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Home3__MVC.Models;

namespace Home3__MVC.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString NumericUpDown(this HtmlHelper htmlHelper, string id, string min, string max, string startValue)
        {
            TagBuilder input = new TagBuilder("input");
            input.MergeAttribute("id", id);
            input.MergeAttribute("min", min);
            input.MergeAttribute("max", max);
            input.MergeAttribute("value", startValue);
            input.MergeAttribute("type", "number");
            input.AddCssClass("numericUpDown");
            return new MvcHtmlString(input.ToString());
        }
        public static MvcHtmlString Button(this HtmlHelper htmlHelper, string id, string price, string url, string innerHtml)
        {
            TagBuilder tag = new TagBuilder("button");
            tag.MergeAttribute("data-id", id);
            tag.MergeAttribute("data-price", price);
            tag.MergeAttribute("data-url", url);
            tag.InnerHtml = innerHtml;
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString SelectBasis(this HtmlHelper htmlHelper, List<Basis> elements)
        {
            TagBuilder div = new TagBuilder("div");
            TagBuilder form = new TagBuilder("form");
            TagBuilder fieldset = new TagBuilder("fieldset");
            TagBuilder label = new TagBuilder("label");
            var br = new TagBuilder("br").ToString(TagRenderMode.SelfClosing);
            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("id", "basis");
            foreach (var item in elements)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", item.Coefficient.ToString());
                option.MergeAttribute("id", item.Id.ToString());
                option.SetInnerText(item.Name);
                select.InnerHtml += option.ToString();
            }
            label.MergeAttribute("for", "basis");
            label.SetInnerText("Basis");
            fieldset.InnerHtml += label.ToString();
            fieldset.InnerHtml += br;
            fieldset.InnerHtml += select.ToString();
            form.InnerHtml += fieldset.ToString();
            div.InnerHtml += form.ToString();
            return new MvcHtmlString(div.ToString());
        }

        public static MvcHtmlString SelectSize(this HtmlHelper htmlHelper, List<Size> elements)
        {
            TagBuilder div = new TagBuilder("div");
            TagBuilder form = new TagBuilder("form");
            TagBuilder fieldset = new TagBuilder("fieldset");
            TagBuilder label = new TagBuilder("label");
            var br = new TagBuilder("br").ToString(TagRenderMode.SelfClosing);
            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("id", "size");
            foreach (var item in elements)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", item.Weight.ToString());
                option.MergeAttribute("id", item.Id.ToString());
                option.SetInnerText(item.Name);
                select.InnerHtml += option.ToString();
            }
            label.MergeAttribute("for", "size");
            label.SetInnerText("Size");
            fieldset.InnerHtml += label.ToString();
            fieldset.InnerHtml += br;
            fieldset.InnerHtml += select.ToString();
            form.InnerHtml += fieldset.ToString();
            div.InnerHtml += form.ToString();
            return new MvcHtmlString(div.ToString());
        }

        public static MvcHtmlString SelectSauce(this HtmlHelper htmlHelper, List<Sauce> elements)
        {
            TagBuilder div = new TagBuilder("div");
            TagBuilder form = new TagBuilder("form");
            TagBuilder fieldset = new TagBuilder("fieldset");
            TagBuilder label = new TagBuilder("label");
            var br = new TagBuilder("br").ToString(TagRenderMode.SelfClosing);
            TagBuilder select = new TagBuilder("select");
            select.MergeAttribute("id", "sauce");
            foreach (var item in elements)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", item.Price.ToString());
                option.MergeAttribute("id", item.Id.ToString());
                option.SetInnerText(item.Name);
                select.InnerHtml += option.ToString();
            }
            label.MergeAttribute("for", "sauce");
            label.SetInnerText("Sauce");
            fieldset.InnerHtml += label.ToString();
            fieldset.InnerHtml += br;
            fieldset.InnerHtml += select.ToString();
            form.InnerHtml += fieldset.ToString();
            div.InnerHtml += form.ToString();
            return new MvcHtmlString(div.ToString());
        }

        public static MvcHtmlString Ingredients(this HtmlHelper htmlHelper, List<Ingredient> ingredients)
        {
            string content = String.Empty;
            foreach(var item in ingredients)
            {
                TagBuilder div = new TagBuilder("div");

                div.MergeAttribute("id", item.Id.ToString());
                div.MergeAttribute("data-name", item.Name);
                div.MergeAttribute("data-price", item.Price.ToString());
                div.MergeAttribute("data-weight", item.Weight.ToString());
                div.AddCssClass("ingrid");

                TagBuilder innerDiv = new TagBuilder("div");
                innerDiv.AddCssClass("pull-right ing-price");
                innerDiv.SetInnerText(item.Price.ToString() + "uah");

                TagBuilder innerSpan = new TagBuilder("span");
                innerSpan.AddCssClass("ing-weight");
                innerSpan.SetInnerText($" ({item.Weight}g)");

                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("text");
                span.SetInnerText(item.Name);
                span.InnerHtml += innerSpan;
                span.InnerHtml += innerDiv;

                div.InnerHtml += span;                
                content += div.ToString();
            }
            return new MvcHtmlString(content);
        }
    }
}