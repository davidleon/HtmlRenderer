﻿// 2015,2014 ,BSD, WinterDev 
//ArthurHub

using System;
using System.Collections.Generic;

using PixelFarm.Drawing; 
using LayoutFarm.HtmlBoxes; 
using LayoutFarm.Composers;

namespace LayoutFarm.WebDom
{

    public class HtmlDocument : WebDocument
    {
        DomElement rootNode;
        int domUpdateVersion;
        EventHandler domUpdatedHandler;


        public HtmlDocument()
            : base(HtmlPredefineNames.CreateUniqueStringTableClone())
        {
            //default root
            rootNode = new HtmlRootElement(this);
        }
        internal HtmlDocument(UniqueStringTable sharedUniqueStringTable)
            : base(sharedUniqueStringTable)
        {
            //default root
            rootNode = new HtmlRootElement(this);
        }
        public override DomElement RootNode
        {
            get
            {
                return rootNode;
            }
            set
            {
                this.rootNode = value;
            }
        }
        public override int DomUpdateVersion
        {
            get { return this.domUpdateVersion; }
            set
            {
                this.domUpdateVersion = value;
                if (domUpdatedHandler != null)
                {
                    domUpdatedHandler(this, EventArgs.Empty);
                }
            }
        }

        public override DomElement CreateElement(string prefix, string localName)
        {
            return new HtmlElement(this,
                AddStringIfNotExists(prefix),
                AddStringIfNotExists(localName));
        }
        public DomAttribute CreateAttribute(WellknownName attrName)
        {
            return new DomAttribute(this,
                0,
                (int)attrName);
        }
        public override DomTextNode CreateTextNode(char[] strBufferForElement)
        {
            return new HtmlTextNode(this, strBufferForElement);
        }

        public DomElement CreateWrapperElement(
            LazyCssBoxCreator lazyCssBoxCreator)
        {
            return new ExternalHtmlElement(this,
                AddStringIfNotExists(null),
                AddStringIfNotExists("x"),
                lazyCssBoxCreator);
        }

        internal void SetDomUpdateHandler(EventHandler h)
        {
            this.domUpdatedHandler = h;
        }
        internal CssActiveSheet CssActiveSheet
        {
            get;
            set;
        }

    }


    public class FragmentHtmlDocument : HtmlDocument
    {
        HtmlDocument primaryHtmlDoc;
        internal FragmentHtmlDocument(HtmlDocument primaryHtmlDoc)
            : base(primaryHtmlDoc.UniqueStringTable)
        {
            this.primaryHtmlDoc = primaryHtmlDoc;

        }

    }
}