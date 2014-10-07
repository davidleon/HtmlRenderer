﻿//BSD 2014, WinterDev 
//ArthurHub

// "Therefore those skilled at the unorthodox
// are infinite as heaven and earth,
// inexhaustible as the great rivers.
// When they come to an end,
// they begin again,
// like the days and months;
// they die and are reborn,
// like the four seasons."
// 
// - Sun Tsu,
// "The Art of War"

using System;
using HtmlRenderer.Css;
using LayoutFarm.Drawing;
using HtmlRenderer.Boxes;

namespace HtmlRenderer.Composers
{

    /// <summary>
    /// Parser to parse CSS stylesheet source string into CSS objects.
    /// </summary>
    public static class CssParserHelper
    {

        /// <summary>
        /// Parse the given stylesheet source to CSS blocks dictionary.<br/>
        /// The CSS blocks are organized into two level buckets of media type and class name.<br/>
        /// Root media type are found under 'all' bucket.<br/>
        /// If <paramref name="combineWithDefault"/> is true the parsed css blocks are added to the 
        /// default css data (as defined by W3), merged if class name already exists. If false only the data in the given stylesheet is returned.
        /// </summary>
        /// <seealso cref="http://www.w3.org/TR/CSS21/sample.html"/>
        /// <param name="stylesheet">raw css stylesheet to parse</param>
        /// <param name="combineWithDefault">true - combine the parsed css data with default css data, false - return only the parsed css data</param>
        /// <returns>the CSS data with parsed CSS objects (never null)</returns>
        public static WebDom.CssActiveSheet ParseStyleSheet(
            string stylesheet,
            bool combineWithDefault)
        {
            var cssData = combineWithDefault ?
                CssDefaults.DefaultCssData.Clone(new object()) : new WebDom.CssActiveSheet();

            if (!string.IsNullOrEmpty(stylesheet))
            {
                ParseStyleSheet(cssData, stylesheet);
            }
            return cssData;
        }



        /// <summary>
        /// Parse the given stylesheet source to CSS blocks dictionary.<br/>
        /// The CSS blocks are organized into two level buckets of media type and class name.<br/>
        /// Root media type are found under 'all' bucket.<br/>
        /// The parsed css blocks are added to the given css data, merged if class name already exists.
        /// </summary>
        /// <param name="cssData">the CSS data to fill with parsed CSS objects</param>
        /// <param name="cssTextSource">raw css stylesheet to parse</param>
        internal static void ParseStyleSheet(WebDom.CssActiveSheet cssData, string cssTextSource)
        {
            if (!String.IsNullOrEmpty(cssTextSource))
            {
                var parser = new WebDom.Parser.CssParser();
                parser.ParseCssStyleSheet(cssTextSource.ToCharArray());
                //-----------------------------------
                WebDom.CssDocument cssDoc = parser.OutputCssDocument;
                WebDom.CssActiveSheet cssActiveDoc = new WebDom.CssActiveSheet();
                cssActiveDoc.LoadCssDoc(cssDoc);

                if (cssData != null)
                {
                    //merge ?
                    cssData.Combine(cssActiveDoc);
                }
                else
                {
                    //cssData.ActiveDoc = cssActiveDoc;
                }
            }
        }




    }
}
