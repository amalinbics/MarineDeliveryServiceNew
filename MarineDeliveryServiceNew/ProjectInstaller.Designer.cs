﻿namespace MarineDeliveryServiceNew
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spiMarineDeliveryNew = new System.ServiceProcess.ServiceProcessInstaller();
            this.siMarineDeliveryNew = new System.ServiceProcess.ServiceInstaller();
            // 
            // spiMarineDeliveryNew
            // 
            this.spiMarineDeliveryNew.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.spiMarineDeliveryNew.Password = null;
            this.spiMarineDeliveryNew.Username = null;
            // 
            // siMarineDeliveryNew
            // 
            this.siMarineDeliveryNew.ServiceName = "MarineDliveryNew";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.spiMarineDeliveryNew,
            this.siMarineDeliveryNew});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller spiMarineDeliveryNew;
        private System.ServiceProcess.ServiceInstaller siMarineDeliveryNew;
    }
}