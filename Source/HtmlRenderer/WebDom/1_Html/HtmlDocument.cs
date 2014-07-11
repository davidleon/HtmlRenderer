﻿//BSD  2014 ,WinterDev 

using HtmlRenderer.RenderDom;
namespace HtmlRenderer.WebDom
{

    public class HtmlDocument
    {

        UniqueStringTable uniqueStringTable = HtmlPredefineNames.CreateUniqueStringTableClone();
        HtmlElement rootNode;
        public HtmlDocument()
        {
            rootNode = new BrigeRootElement(this);
        }

        public HtmlElement RootNode
        {
            get
            {
                return rootNode;
            }
        }
        public int AddStringIfNotExists(string uniqueString)
        {
            return uniqueStringTable.AddStringIfNotExist(uniqueString);
        }
        public string GetString(int index)
        {
            return uniqueStringTable.GetString(index);
        }
        public int FindStringIndex(string uniqueString)
        {
            return uniqueStringTable.GetStringIndex(uniqueString);
        }
        public HtmlAttribute CreateAttribute(string prefix, string localName)
        {


            return new HtmlAttribute(this,
                uniqueStringTable.AddStringIfNotExist(prefix),
                uniqueStringTable.AddStringIfNotExist(localName));
        }

        public HtmlElement CreateElement(string prefix, string localName)
        {
            return new BridgeHtmlElement(this,
                uniqueStringTable.AddStringIfNotExist(prefix),
                uniqueStringTable.AddStringIfNotExist(localName));

            //return new HtmlElement(this,
            //    uniqueStringTable.AddStringIfNotExist(prefix),
            //    uniqueStringTable.AddStringIfNotExist(localName));
        }

        public HtmlComment CreateComent()
        {
            return new HtmlComment(this);
        }
        public HtmlProcessInstructionNode CreateProcessInstructionNode(int nameIndex)
        {
            return new HtmlProcessInstructionNode(this, nameIndex);
        }

        public HtmlTextNode CreateTextNode(char[] strBufferForElement)
        {
            return new BridgeHtmlTextNode(this, strBufferForElement); 
        }
        public HtmlCDataNode CreateCDataNode()
        {
            return new HtmlCDataNode(this);
        }
    }
}