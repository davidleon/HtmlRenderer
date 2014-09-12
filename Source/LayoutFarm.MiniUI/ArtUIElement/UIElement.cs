﻿//2014 Apache2, WinterDev
using System;
using System.Collections.Generic;
using System.Drawing;

namespace LayoutFarm.Presentation.UI
{
    public abstract partial class UIElement : IEventListener
    {
        public UIElement()
        {
        }

        int oneBitNativeEventFlags;
        protected void RegisterNativeEvent(int eventFlags)
        {
            this.oneBitNativeEventFlags |= eventFlags;
        }

       
        public abstract RenderElement PrimaryRenderElement { get; }


        protected virtual void OnLostFocus(UIFocusEventArgs e)
        {
        }
        protected virtual void OnLostMouseFocus(UIFocusEventArgs2 e)
        {
        }
        protected virtual void OnGotFocus(UIFocusEventArgs e)
        {
        }

        protected virtual void OnDoubleClick(UIMouseEventArgs e)
        {


        }
        protected virtual void OnMouseDown(UIMouseEventArgs e)
        {


        }
        protected virtual void OnMouseWheel(UIMouseEventArgs e)
        {
        }
        protected virtual void OnDragStart(UIDragEventArgs e)
        {

        }
        protected virtual void OnDragEnter(UIDragEventArgs e)
        {

        }
        protected virtual void OnDragOver(UIDragEventArgs e)
        {

        }
        protected virtual void OnDragLeave(UIDragEventArgs e)
        {

        }
        protected virtual void OnDragStop(UIDragEventArgs e)
        {

        }
        protected virtual void OnDragging(UIDragEventArgs e)
        {
        }
        protected virtual void OnDragDrop(UIDragEventArgs e)
        {
        }
        protected virtual void OnCollapsed()
        {
        }
        protected virtual void OnExpanded()
        {

        }
        protected virtual void OnElementLanded()
        {

        }

        protected virtual void OnShown()
        {
        }
        protected virtual void OnHide()
        {
        }
        protected virtual void OnNotifyChildDoubleClick(UIElement fromElement, UIMouseEventArgs e)
        {

        }
        protected virtual void OnKeyDown(UIKeyEventArgs e)
        {
        }
        protected virtual void OnKeyUp(UIKeyEventArgs e)
        {
        }
        protected virtual void OnKeyPress(UIKeyPressEventArgs e)
        {
        }
        protected virtual bool OnProcessDialogKey(UIKeyEventArgs e)
        {
            return false;
        }

        protected virtual void OnMouseMove(UIMouseEventArgs e)
        {
        }
        protected virtual void OnMouseHover(UIMouseEventArgs e)
        {
        }
        protected virtual void OnMouseUp(UIMouseEventArgs e)
        {
        }
        protected virtual void OnMouseEnter(UIMouseEventArgs e)
        {

        }
        protected virtual void OnMouseLeave(UIMouseEventArgs e)
        {
        }
        protected virtual void OnDropInto()
        {

        }
        protected virtual void OnSizeChanged(UISizeChangedEventArgs e)
        {

        }
#if DEBUG
        object dbugTagObject;
        public object dbugTag
        {
            get
            {
                return this.dbugTagObject;
            }
            set
            {
                this.dbugTagObject = value;
            }
        }
#endif
    }
}