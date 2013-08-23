using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Net;
using Microsoft.Office.Interop.Outlook;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using OutlookAddIn2.Forms;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.Framework.Client;

namespace OutlookTFSWorkItemAddIn
{
    public partial class ThisAddIn
    {
        Microsoft.Office.Interop.Outlook.Explorer _explorer = null;

        const string CreateWorkItem = "Create Work Item";
       


        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _explorer = this.Application.ActiveExplorer();
            _explorer.SelectionChange += new ExplorerEvents_10_SelectionChangeEventHandler(_explorer_SelectionChange);
        }

        // event fired when any selection changes.
        void _explorer_SelectionChange()
        {
            foreach (object selectedItem in _explorer.Selection)
            {
                MailItem mailItem = selectedItem as MailItem;
                if (mailItem != null)
                {
                    DeleteExistingCustomActions(mailItem);
                    AddNewCustomActions(mailItem);
                }
            }
        }

        public void DeleteExistingCustomActions(MailItem mailItem)
        {
            string[] existingCustomActions = { CreateWorkItem };
            foreach (string customAction in existingCustomActions)
            {
                if (mailItem.Actions[customAction] != null)
                    mailItem.Actions[customAction].Delete();
            }
        }


        public void AddNewCustomActions(MailItem mailItem)
        {
            string[] newCustomActions = { CreateWorkItem };
            foreach (string customAction in newCustomActions)
            {
                if (mailItem.Actions[customAction] == null)
                {
                    Microsoft.Office.Interop.Outlook.Action newAction;
                    newAction = mailItem.Actions.Add();
                    newAction.Name = customAction;
                    newAction.ShowOn = OlActionShowOn.olMenu;
                    newAction.Enabled = true;
                    mailItem.Save();
                }
            }

          mailItem.CustomAction += new ItemEvents_10_CustomActionEventHandler(item_CustomAction);
        }

        void item_CustomAction(object Action, object Response, ref bool Cancel)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Action mailAction = (Microsoft.Office.Interop.Outlook.Action)Action;
                MailItem mailItem = _explorer.Selection[1] as MailItem;
                if (mailItem != null)
                {
                    switch (mailAction.Name)
                    {
                        case CreateWorkItem:
                            CreateTfsWorkItem(mailItem);
                            break;
                    }
                }
            }
            finally
            {
                Cancel = true;
            }
        }


        
        public void CreateTfsWorkItem(MailItem mailItem)
        {
            if (mailItem != null)
            {
                WorkItemForm frm = new WorkItemForm(mailItem);
                DialogResult rs = frm.ShowDialog();
                if (rs == DialogResult.OK)
                {
                }
            }
            
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
