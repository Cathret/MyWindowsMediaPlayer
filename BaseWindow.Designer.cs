﻿namespace MyWindowsMediaPlayer
{
    partial class BaseWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.ToolStrip runtimeToolStrip;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseWindow));
            this.runtimeToolStrip = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // runtimeToolStrip
            // 
            resources.ApplyResources(this.runtimeToolStrip, "runtimeToolStrip");
            this.runtimeToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.runtimeToolStrip.Name = "runtimeToolStrip";
            this.runtimeToolStrip.ShowItemToolTips = false;
            // 
            // BaseWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.runtimeToolStrip);
            this.Name = "BaseWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

